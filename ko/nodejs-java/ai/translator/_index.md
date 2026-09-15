---
title: AI 기반 프레젠테이션 번역기
linktitle: AI 기반 번역기
type: docs
weight: 20
url: /ko/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 AI로 PowerPoint 슬라이드를 번역합니다. 레이아웃을 유지하면서 PPT, PPTX 및 ODP를 현지화하며—빠르고 개발자 친화적입니다. 사용해 보세요."
---
## **소개**

Aspose.Slides는 PowerPoint 프레젠테이션을 프로그래밍 방식으로 관리할 수 있는 강력한 API입니다. 슬라이드 생성, 편집 및 변환뿐만 아니라 다국어 슬라이드 콘텐츠를 위한 Presentation Translation API와 같은 AI 기반 기능을 제공합니다.

## **작동 방식**

Aspose.Slides는 내장 AI 기능을 제공하지 않지만 인터넷을 통해 외부 AI 모델과 통합됩니다. 이 기능은 AI 서비스와 통신하기 위해 [SlidesAIAgent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesaiagent/) 클래스를 통해 노출됩니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)를 사용하여 OpenAI API에 연결할 수 있습니다.

Aspose.Slides는 통신을 처리하고 AI 응답을 파싱한 뒤 원본 슬라이드 레이아웃과 서식을 유지하면서 번역된 콘텐츠를 스마트하게 삽입합니다.

{{% alert color="info" title="Note" %}}
OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)를 사용할 때 계정을 생성하고 API 키를 제공해야 합니다.
{{% /alert %}}

## **예제**

이 예제에서는 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)와 지정된 OpenAI [model](https://platform.openai.com/docs/models)을 사용하여 PowerPoint 프레젠테이션을 일본어로 번역합니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 번역할 프레젠테이션을 로드합니다.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI 클라이언트로 SlidesAIAgent를 초기화합니다.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // 프레젠테이션을 일본어로 번역합니다.
    aiAgent.translate(presentation, "japanese");

    // 번역된 프레젠테이션을 PDF로 저장합니다.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

기본적으로 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)은 자체 내부 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 인스턴스를 생성하고 관리하여 수명 주기를 자동으로 처리합니다. 그러나 프록시와 같은 필수 설정을 구성하거나, 더 나은 리소스 관리 및 성능을 위해 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 또는 다른 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html)를 사용하려는 경우 — 직접 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)을 관리하고 싶다면 — [OpenAIWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaiwebclient/)를 생성할 때 자체 `HttpURLConnection` 인스턴스를 제공할 수 있습니다.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI 예제**

번역기를 [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/openaicompatiblewebclient/)를 사용하여 Azure OpenAI 배포를 사용하도록 구성할 수 있습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

이 코드 조각은 Azure OpenAI 엔드포인트를 사용하여 프레젠테이션을 번역하는 방법을 보여줍니다. 자리 표시자 값을 배포 이름, API 키 및 엔드포인트 URL로 교체하세요.

## **주요 이점**

Aspose.Slides Presentation Translation API는 다국어 PowerPoint 프레젠테이션을 제공하기 위한 AI 기반 솔루션을 제공합니다. 레이아웃과 디자인을 유지하면서 번역을 자동화함으로써 수동 작업에 비해 시간 절약과 오류 감소 효과가 있습니다. 개발자, 교육자, 비즈니스 전문가 등 어떤 역할이든 이 API를 통해 전 세계 청중을 위한 매력적이고 현지화된 프레젠테이션을 만들 수 있어 범위를 확장하고 커뮤니케이션을 향상시킵니다.