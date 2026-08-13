---
title: AI 기반 프레젠테이션 번역기
linktitle: AI 기반 번역기
type: docs
weight: 20
url: /ko/androidjava/ai/translator/
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
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides를 사용하여 AI로 PowerPoint 슬라이드를 번역합니다. 레이아웃을 유지하면서 PPT, PPTX 및 ODP를 현지화—빠르고 개발자 친화적입니다. 사용해 보세요."
---
## **소개**

Aspose.Slides는 PowerPoint 프레젠테이션을 프로그래밍 방식으로 관리할 수 있는 강력한 API입니다. 슬라이드 생성, 편집 및 변환은 물론, 다국어 슬라이드 콘텐츠를 위한 Presentation Translation API와 같은 AI 기반 기능을 제공합니다.

## **작동 방식**

Aspose.Slides는 자체 AI 기능을 제공하지 않으며, 인터넷을 통해 외부 AI 모델과 통합됩니다. 이 기능은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidesaiagent/) 클래스를 통해 노출되며, AI 서비스와 통신하기 위해 [IAIWebClient](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaiwebclient/) 인터페이스 구현을 사용합니다.

기본 제공되는 [OpenAIWebClient](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/openaiwebclient/)를 사용해 OpenAI API에 연결하거나, 다른 AI 제공자 또는 언어 모델을 사용하려면 자체 [IAIWebClient](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaiwebclient/)를 구현하면 됩니다.

Aspose.Slides는 통신을 처리하고 AI 응답을 파싱한 뒤, 원본 슬라이드 레이아웃과 서식을 유지하면서 번역된 콘텐츠를 지능적으로 삽입합니다.

{{% alert color="info" %}}
OpenAI API는 유료 서비스이므로, 기본 제공 [OpenAIWebClient](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/openaiwebclient/)를 사용할 때 계정을 만들고 API 키를 제공해야 합니다.
{{% /alert %}}

## **예제**

이 예제에서는 기본 제공 [OpenAIWebClient](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/openaiwebclient/)와 지정된 OpenAI [model](https://platform.openai.com/docs/models)을 사용해 PowerPoint 프레젠테이션을 일본어로 번역합니다.

```java
import com.aspose.slides.*;

// 번역할 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");

// 모델과 API 키를 지정하여 OpenAIWebClient로 AI 클라이언트를 생성합니다.
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

기본 제공 [OpenAIWebClient](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/openaiwebclient/)는 자체 내부 `HttpURLConnection` 인스턴스를 생성·관리하여 수명 주기를 자동으로 처리합니다. 그러나 프록시와 같은 필수 설정을 구성하거나, `URLStreamHandlerFactory` 또는 다른 `HttpClient`를 사용해 리소스 관리와 성능을 최적화하려는 경우, [OpenAIWebClient](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/openaiwebclient/)를 생성할 때 직접 `HttpURLConnection` 인스턴스를 제공할 수 있습니다.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // 직접 HttpURLConnection 인스턴스를 구성합니다 (예: 사용자 지정 타임아웃, 프록시 설정 등).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // 연결을 OpenAIWebClient 생성자에 전달합니다.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **주요 장점**

Aspose.Slides Presentation Translation API는 다국어 PowerPoint 프레젠테이션을 제공하기 위한 AI 기반 솔루션을 제공합니다. 레이아웃과 디자인을 유지하면서 번역을 자동화함으로써 수작업보다 시간 절약과 오류 감소 효과를 누릴 수 있습니다. 개발자, 교육자, 비즈니스 전문가 등 어떤 역할이든, 이 API를 통해 글로벌 청중을 위한 매력적인 현지화 프레젠테이션을 손쉽게 만들 수 있어 도달 범위를 넓히고 커뮤니케이션을 향상시킬 수 있습니다.