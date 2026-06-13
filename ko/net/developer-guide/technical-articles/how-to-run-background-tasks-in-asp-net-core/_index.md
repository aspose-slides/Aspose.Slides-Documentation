---
title: ASP.NET Core에서 백그라운드 작업 실행 방법
type: docs
weight: 300
url: /ko/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- 백그라운드 작업
- 백그라운드 처리
- 호스트된 서비스
- 백그라운드 워커
- 작업 큐
- 비동기 작업 스케줄링
- 서버 측 파일 처리
- 진행 상황 추적
- 상태 폴링
- SignalR 알림
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- 확장 가능한 아키텍처
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Hosted Services, 작업 큐 및 상태 업데이트를 사용하여 ASP.NET Core에서 백그라운드 작업을 실행하고, Aspose.Slides를 사용해 PPT, PPTX 및 ODP를 처리·변환합니다."
---
## **소개**

파일 처리(예: 프레젠테이션을 PDF로 내보내기)는 전형적인 서버 측 작업입니다. 요청 핸들러 내부에서 수행(클라이언트가 대기)하면 다음과 같은 단점이 있습니다:

- *UI가 좋지 않음.* 페이지가 멈추고 사용자는 결과를 기다려야 합니다. 페이지를 새로 고치면 작업이 취소됩니다.
- *작업 시간 초과.* 처리 시간이 고정된 기간 내에 완료된다는 보장이 없으므로 사용자는 “작업 시간 초과” 오류를 볼 가능성이 높습니다.
- *처리량 및 확장성 낮음.* ASP.NET Core는 많은 요청을 비동기적으로 처리하도록 설계되었습니다. CPU 바운드이며 오래 실행되는 작업은 스레드를 차단하고 서버 처리량을 감소시킵니다.
- *내결함성 낮음.* 오래 실행되는 작업 중에 문제가 발생하면(예: 연결 문제) 처리가 실패하고 처음부터 다시 시작해야 합니다.

[A 더 나은 접근 방식](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests)은 작업을 비동기적으로 예약하고 백그라운드에서 처리한 뒤 결과가 준비되면 반환하는 것입니다.

이 모델에서는 사용자가 현재 상태를 확인할 수 있고(페이지를 떠나거나 새로 고침해도 됨), 서버 리소스를 효율적으로 확장 및 조정할 수 있으며, 재시도 정책을 적용할 수 있습니다.

전형적인 백그라운드 처리 솔루션에는 다음이 포함됩니다:

1. 작업을 예약하기 위한 API.
1. 작업 상태를 추적하기 위한 API.
1. 예약된 작업을 처리하는 백그라운드 워커.
1. 결과를 저장하고 검색하기 위한 API.

## **백그라운드 작업 예제**

이 접근 방식을 보여주기 위해 [샘플 ASP.NET Core 3.1 웹 애플리케이션](./BackgroundJobDemo.zip)을 고려하십시오. 이 앱에는 사용자가 프레젠테이션을 업로드하고 **Export to PDF** 버튼을 클릭하면 파일이 업로드된 뒤 백그라운드 워커가 PDF로 변환하는 페이지가 포함되어 있습니다.

## **웹 앱**

샘플 웹 앱(*BackgroundJobDemo* 프로젝트)에는 다음이 포함됩니다:

- 파일 업로드 페이지(Razor 페이지 "Upload").
- 진행 상황 페이지(Razor 페이지 "Progress"와 상태를 확인하고 표시하는 몇 가지 JavaScript 함수).
- 처리 상태를 제공하는 컨트롤러(`JobStatusController`)(`api/status/{jobId}`).
- 내보낸 PDF 파일을 반환하는 컨트롤러(`JobResultController`)(`api/result/{id}`).
- ASP.NET Core 호스팅 서비스를 기반으로 하는 백그라운드 워커(`WorkerService` 클래스 참조).

Razor 페이지, 컨트롤러 및 백그라운드 워커는 *BackgroundJobDemo.Common* 프로젝트에 정의된 인터페이스를 통해 실제 작업을 위임합니다. 작업 관리 및 처리에 대한 구체적인 구현은 별도 프로젝트(*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* 등)에 제공되며 `Startup.ConfigureServices` 메서드에서 전환할 수 있습니다.

데모 목적으로 “Upload” 페이지는 버퍼링된 모델 바인딩을 사용하지만, 대용량 파일 업로드의 경우 [권장](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)되는 비버퍼링 스트리밍을 사용해야 합니다. 실제 운영 환경에서는 관련 [보안 측면](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations)을 고려하십시오. “Progress” 페이지는 JavaScript를 통해 2초마다(이 간격은 구성 가능) 예약된 작업 상태를 폴링합니다. 폴링은 일반적인 방법이지만, 더 발전된 시나리오에서는 WebSocket을 통한 실시간 알림이 필요할 수 있습니다(실시간 통신은 이 글의 범위를 벗어납니다). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)은 실시간 통신을 위한 간단하면서도 강력한 도구입니다.

백그라운드 워커를 서버 프로세스에 호스팅하는 것은 간단한 애플리케이션에 편리하지만 [단점](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx)이 있습니다. 보다 견고하고 확장 가능한 방법은 워커를 별도 프로세스에 배포하는 것입니다(예: *BackgroundJobDemo.Worker* 콘솔 애플리케이션 참조).

## **기본 구현**

*BackgroundJobDemo.Local* 프로젝트는 SQLite 데이터베이스를 활용한 간단한 작업 관리 구현을 제공합니다(데이터베이스 경로는 `LocalConfig.DbFilePath`를 통해 구성; `Startup.ConfigureServices` 참조). 업로드 및 처리된 파일은 파일 시스템에 저장됩니다(스토리지 폴더 경로는 `LocalConfig.FileStorageFolderPath`를 통해 구성; `Startup.ConfigureServices` 참조). 실제 환경에서는 작업 스케줄링을 메시지 큐(RabbitMQ, AWS SQS, Azure Storage Queue 등)를 통해 구현하는 것이 내결함성과 성능면에서 더 좋습니다.

## **Amazon Web Services 기반 분산 구현**

*BackgroundJobDemo.Aws* 프로젝트는 Amazon Web Services에서 작업 처리를 구현하고 수평적으로 확장 가능한 분산 아키텍처를 보여줍니다. 포함된 구성 요소는 다음과 같습니다:

- 웹 앱 — 사용자와 상호 작용하고 PPTX‑to‑PDF 내보내기 작업 등을 예약합니다.
- 워커 — 내보내기를 처리합니다(인‑프로세스, 아웃‑프로세스 또는 AWS Lambda).
- 메시지 큐 — 처리할 작업을 저장합니다(Amazon SQS).
- 파일 스토리지 — 업로드 및 처리된 파일을 저장합니다(Amazon S3).
- 키‑값 저장소 — 작업 처리 상태를 추적합니다(Amazon DynamoDB).

전형적인 분산 아키텍처는 [메시지 큐](https://aws.amazon.com/message-queue/)에 기반합니다: 웹 앱이 백그라운드 작업을 큐에 넣고, 백그라운드 워커가 큐에서 작업을 가져와 수행합니다. 이는 구성 요소를 느슨하게 결합하고 처리를 비동기적이며 신뢰할 수 있게 만듭니다. 큐는 전달을 보장하고 *visibility timeout*을 사용합니다: 한 워커가 메시지를 가져가면 다른 워커에게는 보이지 않으며, 작업 워커가 완료 시에만 메시지를 제거합니다. 가시성 타임아웃 내에 처리가 끝나지 않으면(예: 실패나 네트워크 문제) 메시지는 다시 보이게 됩니다.

우리 구현은 마이크로서비스, 분산 시스템 및 서버리스 애플리케이션을 위한 완전 관리형 메시지 큐인 [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)(SQS)를 사용합니다.

메시지 큐는 가벼운 메시지(예: SQS 메시지 크기 제한은 256 KB)를 위한 것이므로 메시지에는 작업 설명만 포함해야 합니다. 파일과 같이 무거운 데이터는 별도로 저장하고 메시지에서 참조해야 합니다. 업로드 및 처리된 파일은 [Amazon S3](https://aws.amazon.com/s3/)에 저장합니다.

작업 결과를 ID 기반으로 지속 및 검색하려면 키‑값 저장소가 필요합니다. 예제에서는 빠르고 유연한 NoSQL 데이터베이스 서비스인 [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)를 사용합니다.

Amazon Web Services와 함께 데모 앱을 실행하려면:

1. 동일한 AWS 리전에서 다음을 생성 및 구성합니다:
   1. SQS 큐,
   1. S3 버킷,
   1. DynamoDB 테이블.
1. `Startup.ConfigureServices`에서 *AddAws*를 호출하고 SQS 큐 URL, S3 버킷 이름, DynamoDB 테이블 이름 및 AWS 리전을 제공하여 웹 앱을 이 서비스에 연결합니다.

## **참고 문서**

- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [Real-time ASP.NET with SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Message Queues](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)