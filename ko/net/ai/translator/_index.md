---
title: AI 기반 프레젠테이션 번역기
linktitle: AI 기반 번역기
type: docs
weight: 20
url: /ko/net/ai/translator/
keywords:
- AI 프레젠테이션 번역기
- AI 슬라이드 번역기
- AI 기반 기능
- 다국어 프레젠테이션
- 다국어 슬라이드
- 프레젠테이션 번역
- 슬라이드 번역
- AI 구동 기능
- AI 역량
- AI 에이전트
- 웹 클라이언트
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 AI로 PowerPoint 슬라이드를 번역합니다. 레이아웃을 유지하면서 PPT, PPTX 및 ODP를 현지화합니다—빠르고 개발자 친화적입니다. 지금 사용해 보세요."
---
## **소개**

Aspose.Slides는 프로그래밍 방식으로 PowerPoint 프레젠테이션을 관리하기 위한 강력한 API입니다. 슬라이드를 생성, 편집 및 변환하는 것 외에도 다국어 슬라이드 콘텐츠를 위한 [Presentation Translation API](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/)과 같은 AI 기반 기능을 제공합니다.

## **작동 방식**

Aspose.Slides는 기본 AI 기능을 포함하지 않지만 인터넷을 통해 외부 AI 모델과 통합됩니다. 이 기능은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/slidesaiagent) 클래스를 통해 노출되며, 이 클래스는 AI 서비스와 통신하기 위해 [IAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/iaiwebclient/) 인터페이스의 구현을 사용합니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)을 사용하여 OpenAI API에 연결하거나, 다른 AI 제공자나 언어 모델을 사용하기 위해 자체 [IAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/iaiwebclient/)를 구현할 수 있습니다.

Aspose.Slides는 통신을 처리하고, AI 응답을 파싱하며, 원본 슬라이드 레이아웃과 서식을 유지하면서 번역된 콘텐츠를 지능적으로 삽입합니다.

{{% alert color="primary" %}}
OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 사용할 때 계정을 생성하고 API 키를 제공해야 합니다.
{{% /alert %}}

## **예제**

이 예제에서는 지정된 OpenAI [model](https://platform.openai.com/docs/models)을 사용하여 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)으로 PowerPoint 프레젠테이션을 일본어로 번역합니다.

```csharp
// 번역할 프레젠테이션을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient로 AI 클라이언트를 만들고, 모델과 API 키를 지정합니다.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI 클라이언트를 사용해 SlidesAIAgent를 초기화합니다.
var aiAgent = new SlidesAIAgent(aiWebClient);

// 프레젠테이션을 일본어로 번역합니다.
await aiAgent.TranslateAsync(presentation, "japanese");

// 번역된 프레젠테이션을 PDF로 저장합니다.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

기본적으로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)은 자체 내부 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 인스턴스를 생성 및 관리하며, 수명 주기와 폐기를 자동으로 처리합니다. 그러나 더 나은 리소스 관리와 성능을 위해 [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory)를 사용하는 등 직접 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)를 관리하고 싶다면, [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 생성할 때 자체 `HttpClient` 인스턴스를 제공할 수 있습니다.

```csharp
// IHttpClientFactory 인스턴스가 있다고 가정합니다(예: 종속성 주입을 통해 주입됨).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides는 일반적으로 동기 환경에서 사용됩니다. 이를 지원하기 위해, [SlidesAIAgent](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/slidesaiagent/) 클래스는 동기 및 비동기 메서드를 모두 제공하므로 애플리케이션 워크플로에 가장 적합한 방식을 선택할 수 있습니다.

## **핵심 이점**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/)는 다국어 PowerPoint 프레젠테이션을 제공하기 위한 AI 기반 솔루션을 제공합니다. 레이아웃과 디자인을 유지하면서 번역을 자동화함으로써 수동 워크플로에 비해 시간 절약과 오류 최소화를 실현합니다. 개발자, 교육자, 비즈니스 전문가 등 어떤 역할이든 이 API를 사용하면 전 세계 청중을 위한 매력적이고 현지화된 프레젠테이션을 만들 수 있어 범위가 확대되고 커뮤니케이션이 향상됩니다.