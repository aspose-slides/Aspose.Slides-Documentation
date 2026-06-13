---
title: AI 기반 프레젠테이션 번역기
linktitle: AI 기반 번역기
type: docs
weight: 20
url: /ko/java/ai/translator/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 AI로 PowerPoint 슬라이드를 번역합니다. 레이아웃을 유지하면서 PPT, PPTX 및 ODP를 현지화합니다—빠르고 개발자 친화적입니다. 사용해 보세요."
---
## **소개**

Aspose.Slides는 프로그래밍 방식으로 PowerPoint 프레젠테이션을 관리할 수 있는 강력한 API입니다. 슬라이드 생성, 편집 및 변환 외에도 다국어 슬라이드 콘텐츠를 위한 Presentation Translation API와 같은 AI 기반 기능을 제공합니다.

## **작동 방식**

Aspose.Slides는 기본 AI 기능을 포함하고 있지 않지만 인터넷을 통해 외부 AI 모델과 통합됩니다. 이 기능은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidesaiagent/) 클래스에 의해 노출되며, AI 서비스와 통신하기 위해 [IAIWebClient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iaiwebclient/) 인터페이스의 구현을 사용합니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/openaiwebclient/)을 사용하여 OpenAI API에 연결하거나, 다른 AI 공급자 또는 언어 모델을 사용하려면 자체 [IAIWebClient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iaiwebclient/)를 구현할 수 있습니다.

Aspose.Slides는 통신을 처리하고 AI 응답을 파싱하며 원본 슬라이드 레이아웃과 서식을 유지하면서 번역된 콘텐츠를 지능적으로 삽입합니다.

{{% alert color="primary" %}}
OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/openaiwebclient/)을 사용할 때 계정을 생성하고 API 키를 제공해야 합니다.
{{% /alert %}}

## **예시**

이 예제에서는 지정된 OpenAI [model](https://platform.openai.com/docs/models)를 사용하여 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/openaiwebclient/)으로 PowerPoint 프레젠테이션을 일본어로 번역합니다.

```java
// 번역할 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient를 사용하여 AI 클라이언트를 생성하고, 모델과 API 키를 지정합니다.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI 클라이언트로 SlidesAIAgent를 초기화합니다.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // 프레젠테이션을 일본어로 번역합니다.
    aiAgent.translate(presentation, "japanese");

    // 번역된 프레젠테이션을 PDF로 저장합니다.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

기본적으로 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/openaiwebclient/)은 자체 내부 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 인스턴스를 생성 및 관리하며, 수명 주기를 자동으로 처리합니다. 그러나 프록시와 같은 필수 설정을 구성하거나 더 나은 리소스 관리 및 성능을 위해 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 또는 다른 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html)를 사용하려는 경우와 같이 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)을 직접 관리하고 싶다면, [OpenAIWebClient](https://reference.aspose.com/slides/ko/java/com.aspose.slides/openaiwebclient/)를 구성할 때 자체 `HttpURLConnection` 인스턴스를 제공할 수 있습니다.

```java
// 사전 구성된 HttpURLConnection 인스턴스가 있다고 가정합니다 (예: 사용자 지정 타임아웃, 프록시 설정 등).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **핵심 이점**

Aspose.Slides Presentation Translation API는 다국어 PowerPoint 프레젠테이션을 제공하기 위한 AI 기반 솔루션을 제공합니다. 레이아웃과 디자인을 유지하면서 번역을 자동화함으로써 수작업 워크플로에 비해 시간 절약과 오류 최소화를 실현합니다. 개발자, 교육자, 비즈니스 전문가 여부에 관계없이 이 API를 사용하면 전 세계 청중을 위한 매력적이고 현지화된 프레젠테이션을 만들어 범위를 확대하고 커뮤니케이션을 향상시킬 수 있습니다.