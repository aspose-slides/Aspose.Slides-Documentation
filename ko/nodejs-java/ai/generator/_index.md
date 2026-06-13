---
title: AI 기반 다국어 슬라이드 생성기
linktitle: AI 기반 생성기
type: docs
weight: 40
url: /ko/nodejs-java/ai/generator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 텍스트에서 다국어 슬라이드를 생성합니다. 템플릿을 적용하고 PowerPoint 및 OpenDocument 형식으로 깔끔한 프레젠테이션을 내보낼 수 있습니다. 자세히 알아보세요."
---
## **소개**

Aspose.Slides는 새로운 AI 기반 기능인 Presentation Generator를 소개합니다. 이 기능을 사용하면 개발자는 주제 설명, 요약, 인용문 또는 글머리표와 같은 간단한 텍스트 입력으로 잘 구조화된 PowerPoint 프레젠테이션을 자동으로 생성할 수 있습니다.

사용자는 콘텐츠 상세 수준을 조정하고 선택적으로 사용자 정의 프레젠테이션 템플릿을 적용하여 시각 디자인을 정의할 수 있습니다.

현재 AI Presentation Generator는 텍스트 블록, 글머리표 목록 및 표를 사용하여 콘텐츠를 구조화합니다. 이미지 생성은 아직 지원되지 않지만, 이미지는 Aspose.Slides 도구를 사용하거나 수동으로 쉽게 추가할 수 있습니다.

출력은 즉시 사용할 수 있거나 Aspose.Slides API에서 지원하는 모든 형식으로 내보낼 수 있는 완전한 PowerPoint 프레젠테이션입니다. 생성기가 높은 품질의 결과를 제공하지만, 특정 요구 사항을 충족하기 위해 약간의 사후 편집이 필요할 수 있습니다.

## **작동 원리**

Aspose.Slides는 내장 AI 모델을 포함하지 않으며, 대신 인터넷을 통해 외부 AI 서비스와 통합됩니다. 이 통합은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesaiagent/) 클래스로 처리됩니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)을 사용하면 OpenAI API에 연결할 수 있습니다. Aspose.Slides는 AI 서비스와의 모든 통신을 관리하고 AI 응답을 처리하여 슬라이드를 생성합니다. OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)를 사용할 때는 계정과 API 키가 필요합니다.

## **코드 작성**

### **예제 1**

이 예제는 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)을 사용하여 Aspose.Slides 주제에 대한 프레젠테이션을 생성하는 방법을 보여줍니다.

```js
// OpenAIWebClient 인스턴스를 생성합니다. 이는 OpenAI 웹 클라이언트의 내장 구현입니다.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // SlidesAIAgent 인스턴스를 생성합니다. 이는 AI 기반 기능에 대한 접근을 제공합니다.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // 프레젠테이션을 생성하기 위한 지시문을 정의합니다.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 지시문을 기반으로 중간 정도 양의 콘텐츠가 포함된 프레젠테이션을 생성합니다.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // 생성된 프레젠테이션을 로컬 디스크에 PowerPoint(.pptx) 파일로 저장합니다.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **예제 2**

다음 예제는 [generatePresentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) 메서드의 오버로드를 보여줍니다. 이 경우 외부에서 관리되는 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 인스턴스와 사용자의 `master presentation`이 사용됩니다.

기본적으로 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)은 자체 내부 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 인스턴스를 생성하고 관리하여 수명 주기를 자동으로 처리합니다. 그러나 직접 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)을 관리하고 싶다면—예를 들어 리소스 관리와 성능 향상을 위해 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html)나 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html)를 사용할 때—[OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)를 구성할 때 사용자 정의 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 인스턴스를 제공할 수 있습니다.

```js
// HttpURLConnection을 OpenAIWebClient 생성자에 전달합니다.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // SlidesAIAgent 인스턴스를 생성합니다.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // 프레젠테이션을 생성하기 위한 지시문을 정의합니다.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 디자인 템플릿으로 사용할 마스터 프레젠테이션을 로컬 디스크에서 로드합니다.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // 지시문과 마스터 템플릿을 사용하여 상세 프레젠테이션을 생성합니다.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // 생성된 프레젠테이션을 PDF로 저장합니다.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **핵심 이점**

Aspose.Slides의 새로운 AI Presentation Generator는 간단한 텍스트 프롬프트로부터 구조화된 슬라이드 데크를 빠르고 유연하게 생성하는 방법을 제공합니다. 사용자 정의 템플릿 및 외부에서 관리되는 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 인스턴스를 지원하여 다양한 애플리케이션에 원활히 통합될 수 있습니다.

전형적인 사용 사례에는 마케팅 프레젠테이션, 교육 자료, 고객 보고서 및 내부 슬라이드 데크 생성이 포함됩니다. 이미지 생성은 아직 지원되지 않지만, 이 도구는 프레젠테이션 자동화에 강력한 기반을 이미 제공하고 있으며 향후 추가 개선이 기대됩니다.