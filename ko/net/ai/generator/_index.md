---
title: AI 기반 다국어 슬라이드 생성기
linktitle: AI 기반 생성기
type: docs
weight: 40
url: /ko/net/ai/generator/
keywords:
- 다국어 프레젠테이션
- 다국어 슬라이드
- AI 프레젠테이션 생성기
- AI 슬라이드 생성기
- AI 기반 기능
- AI 에이전트
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 텍스트에서 다국어 슬라이드를 생성합니다. 템플릿을 적용하고 PowerPoint와 OpenDocument로 정교한 데크를 내보내십시오. 자세히 알아보세요."
---
## **Introduction**

Aspose.Slides는 새로운 AI 기반 기능인 Presentation Generator를 도입하여, 주제 설명, 요약, 인용문, 또는 핵심 포인트와 같은 간단한 텍스트 입력만으로 개발자가 구조화된 PowerPoint 프레젠테이션을 자동으로 생성할 수 있게 합니다.

사용자는 콘텐츠 상세 수준을 조정하고, 시각 디자인을 정의하기 위해 사용자 지정 프레젠테이션 템플릿을 선택적으로 적용할 수 있습니다.

현재 AI Presentation Generator는 텍스트 블록, 글머리표 목록 및 표를 사용해 콘텐츠를 구조화합니다. 이미지 생성은 아직 지원되지 않지만, Aspose.Slides 도구나 수동으로 나중에 이미지를 쉽게 추가할 수 있습니다.

출력은 바로 사용할 수 있거나 Aspose.Slides API가 지원하는 모든 형식으로 내보낼 수 있는 완전한 PowerPoint 프레젠테이션입니다. 생성된 결과는 고품질이지만 특정 요구 사항을 충족하기 위해 약간의 후편집이 필요할 수 있습니다.

## **How It Works**

Aspose.Slides는 자체 AI 모델을 포함하지 않으며, 대신 인터넷을 통해 외부 AI 서비스와 통합됩니다. 이 통합은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/slidesaiagent/) 클래스를 통해 처리되며, 이 클래스는 [IAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/iaiwebclient/) 인터페이스 구현을 사용해 AI 모델과 통신합니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 사용하면 OpenAI API에 연결할 수 있으며, 다른 AI 제공자나 언어 모델과 작업하려면 [IAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/iaiwebclient/)의 사용자 정의 구현을 제공하면 됩니다. Aspose.Slides는 AI 서비스와의 모든 통신을 관리하고 AI 응답을 처리해 슬라이드를 생성합니다. OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 사용할 때는 계정과 API 키가 필요합니다.

## **Let's Code**

### **Example 1**

이 예제는 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 사용하여 Aspose.Slides 주제로 프레젠테이션을 생성하는 방법을 보여줍니다.

```csharp
// OpenAIWebClient의 인스턴스를 생성합니다. 이는 OpenAI 웹 클라이언트의 내장 구현입니다.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// SlidesAIAgent의 인스턴스를 생성합니다. 이는 AI 기반 기능에 접근할 수 있게 합니다.
var aiAgent = new SlidesAIAgent(aiWebClient);

// 프레젠테이션 생성을 위한 지시문을 정의합니다.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// 지시문을 기반으로 중간 양의 콘텐츠를 포함한 프레젠테이션을 생성합니다.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// 생성된 프레젠테이션을 PowerPoint(.pptx) 파일로 로컬 디스크에 저장합니다.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Example 2**

다음 예제는 [GeneratePresentation](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/slidesaiagent/generatepresentation/) 메서드의 오버로드를 보여줍니다. 이 경우 외부에서 관리되는 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 인스턴스와 사용자의 `master presentation`이 사용됩니다.

기본적으로 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)는 자체 내부 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 인스턴스를 생성하고 관리하며, 수명 주기와 폐기를 자동으로 처리합니다. 그러나 [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory)를 사용해 리소스 관리 및 성능을 향상시키고 싶다면, [OpenAIWebClient](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/openaiwebclient/)를 구성할 때 직접 만든 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 인스턴스를 제공할 수 있습니다.

```csharp
// 외부에서 관리되는 HttpClient 인스턴스를 생성합니다.
using var httpClient = new HttpClient();

// HttpClient를 OpenAIWebClient 생성자에 전달합니다.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// SlidesAIAgent 인스턴스를 생성합니다.
var aiAgent = new SlidesAIAgent(aiWebClient);

// 프레젠테이션 생성을 위한 지시문을 정의합니다.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// 디자인 템플릿으로 사용할 마스터 프레젠테이션을 로컬 디스크에서 로드합니다.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// 지시문과 마스터 템플릿을 사용하여 상세한 프레젠테이션을 생성합니다.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// 생성된 프레젠테이션을 PDF로 저장합니다.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

많은 고객이 Aspose.Slides를 동기식 컨텍스트에서 사용한다는 점을 고려할 필요가 있습니다. 이를 지원하기 위해 [SlidesAIAgent](https://reference.aspose.com/slides/ko/net/aspose.slides.ai/slidesaiagent/) 클래스는 동기식 및 비동기식 메서드를 모두 제공하므로 애플리케이션 워크플로에 가장 적합한 방식을 선택할 수 있습니다.

## **Key Benefits**

Aspose.Slides의 새로운 AI Presentation Generator는 간단한 텍스트 프롬프트만으로 구조화된 슬라이드 덱을 빠르고 유연하게 생성하는 방법을 제공합니다. 사용자 지정 템플릿, 외부에서 관리되는 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) 인스턴스, 그리고 동기식·비동기식 워크플로를 지원함으로써 다양한 애플리케이션에 원활히 통합될 수 있습니다.

주요 사용 사례에는 마케팅 프레젠테이션, 교육 자료, 고객 보고서 및 내부 슬라이드 덱 생성이 포함됩니다. 이미지 생성은 아직 지원되지 않지만, 도구는 이미 프레젠테이션 자동화의 강력한 기반을 제공하며 향후 추가 기능이 기대됩니다.