#!/bin/bash
awslocal s3 mb s3://users
awslocal s3 mb s3://settings
awslocal sqs create-queue --queue-name test
awslocal sqs list-queues