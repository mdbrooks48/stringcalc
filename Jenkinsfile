#!/usr/bin/env groovy
pipeline {
  agent any

  stages {
    stage('Build') {
        steps {
            sh 'dotnet build StringCalc.sln'
        }
    }
    stage('Test'){
        steps {
            sh 'dotnet test StringCalc.core.test/StringCalc.core.test.csproj --logger:trx --results-directory:"./"'
            step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])
        }
    }
    stage('Package') {
        steps {
            sh 'docker build -t stringcalc:$BUILD_NUMBER .'
        }
    }
    stage('Deploy') {
        steps {
            sh 'docker stop stringcalc || true && docker rm stringcalc || true'
            sh 'docker run -d -p 5000:80 --name stringcalc stringcalc:$BUILD_NUMBER'
        }
    }
  }
}