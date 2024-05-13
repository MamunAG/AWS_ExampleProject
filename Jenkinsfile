pipeline {
    agent any
 
    environment {
        registry = '1almamun/aws_docker_example'
        registryCredentialUp = 'docker_up'
        dockerImage = ''
    }

    stages {
        stage('Start') {
            steps {
                echo 'Pipeline start.'
            }
        }
    
        stage('Building image') {
            steps{
                script {
                    dockerImage = docker.build registry + ":$BUILD_NUMBER"
                }
            }
        }

        stage('Push to dockerhub') {
            steps{
                script {
                    docker.withRegistry( '', registryCredentialUp ) {
                        dockerImage.push()
                    }   
                }
            }
        }

        stage('Cleaning up') {
            steps{
                sh "docker rmi $registry:$BUILD_NUMBER"
            }
        }

        stage('Tigger CD Pipeline') {
            steps{
                script {
                    sh """
                        curl -X POST http://172.16.100.237:8080/job/CD_Pipeline/buildWithParameters \
                        --data-urlencode "IMAGE_TAG=${BUILD_NUMBER}" \
                        --user jenkins:115735c0bbed54d44a1d1d87a715607d5b
                    """ 
                }
            }
        }
    }
 
    post {
        success {
            echo 'Docker image build and push successful!'
        }
        failure {
            error 'Docker image build or push failed!'
        }
    }
}
