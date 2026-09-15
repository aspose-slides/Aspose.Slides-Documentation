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
- AI 기능
- AI 에이전트
- 웹 클라이언트
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 AI로 PowerPoint 슬라이드를 번역합니다. 레이아웃을 유지하면서 PPT, PPTX 및 ODP를 현지화합니다—빠르고 개발자 친화적입니다. 사용해 보세요."
---
## **Introduction**

Aspose.Slides은 프로그래밍 방식으로 PowerPoint 프레젠테이션을 관리하는 강력한 API입니다. 슬라이드 생성, 편집 및 변환뿐만 아니라 다국어 슬라이드 콘텐츠를 위한 [Presentation Translation API](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/)와 같은 AI 기반 기능을 제공합니다.

## **How It Works**

Aspose.Slides에는 기본 AI 기능이 포함되어 있지 않지만, 인터넷을 통해 외부 AI 모델과 통합됩니다. 이 기능은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/slidesaiagent) 클래스를 통해 노출되며, 이 클래스는 [IAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/iaiwebclient/) 인터페이스 구현을 사용해 AI 서비스와 통신합니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 사용해 OpenAI API에 연결하거나, 다른 AI 공급자나 언어 모델을 사용하려면 자체 [IAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/iaiwebclient/)를 구현할 수 있습니다.

Aspose.Slides는 통신을 처리하고 AI 응답을 파싱한 뒤, 원본 슬라이드 레이아웃과 서식을 유지하면서 번역된 콘텐츠를 지능적으로 삽입합니다.

{{% alert color="info" title="Note" %}}
OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 사용할 때는 계정을 생성하고 API 키를 제공해야 합니다.
{{% /alert %}}

## **Example**

이 예제에서는 지정된 OpenAI [model](https://platform.openai.com/docs/models)을 사용해 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)으로 PowerPoint 프레젠테이션을 일본어로 번역합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// 번역할 프레젠테이션을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient로 AI 클라이언트를 생성하고 모델 및 API 키를 지정합니다.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI 클라이언트를 사용하여 SlidesAIAgent를 초기화합니다.
var aiAgent = new SlidesAIAgent(aiWebClient);

// 프레젠테이션을 일본어로 번역합니다.
await aiAgent.TranslateAsync(presentation, "japanese");

// 번역된 프레젠테이션을 PDF로 저장합니다.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

기본적으로 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)은 자체 내부 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 인스턴스를 생성 및 관리하여 수명 주기와 폐기를 자동으로 처리합니다. 그러나 [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory)와 같이 리소스 관리와 성능을 향상시키기 위해 직접 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)를 관리하고 싶은 경우, [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 생성할 때 직접 만든 `HttpClient` 인스턴스를 제공할 수 있습니다.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// 직접 관리하는 HttpClient를 사용합니다 - 예를 들어 IHttpClientFactory로 생성된 경우
// 의존성 주입을 통해 주입된 경우.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides는 일반적으로 동기 환경에서 사용됩니다. 이를 지원하기 위해 [SlidesAIAgent](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/slidesaiagent/) 클래스는 동기 및 비동기 메서드를 모두 제공하므로 애플리케이션 워크플로에 가장 적합한 방식을 선택할 수 있습니다.

### **Azure OpenAI Example**

Aspose.Slides for .NET은 Azure OpenAI를 포함한 OpenAI 호환 공급자를 지원합니다. [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaicompatiblewebclient/)를 사용해 사내 Azure 배포를 번역기에 설정할 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

이 스니펫은 Azure OpenAI 엔드포인트를 사용해 프레젠테이션을 번역하는 방법을 보여줍니다. 자리표시자 값을 배포 이름, API 키 및 엔드포인트 URL로 바꾸세요.

## **Key Benefits**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/)는 다국어 PowerPoint 프레젠테이션을 제공하기 위한 AI 기반 솔루션을 제공합니다. 레이아웃과 디자인을 유지하면서 번역을 자동화함으로써 수작업에 비해 시간을 절약하고 오류를 최소화합니다. 개발자, 교육자 또는 비즈니스 전문가이든 관계없이 이 API를 사용하면 전 세계 청중을 위한 매력적이고 현지화된 프레젠테이션을 손쉽게 만들 수 있어 도달 범위를 확대하고 커뮤니케이션을 개선할 수 있습니다.