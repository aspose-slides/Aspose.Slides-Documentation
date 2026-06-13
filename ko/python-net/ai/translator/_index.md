---
title: AI 기반 프레젠테이션 번역기
linktitle: AI 기반 번역기
type: docs
weight: 20
url: /ko/python-net/ai/translator/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 AI로 PowerPoint 슬라이드를 번역합니다. 레이아웃을 유지하면서 PPT, PPTX 및 ODP를 현지화하며—빠르고 개발자 친화적입니다. 사용해 보세요."
---
## **Introduction**

Aspose.Slides는 프로그래밍 방식으로 PowerPoint 프레젠테이션을 관리할 수 있는 강력한 API입니다. 슬라이드 생성, 편집 및 변환뿐만 아니라 다국어 슬라이드 콘텐츠를 위한 [프레젠테이션 번역 API](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/)와 같은 AI 기반 기능을 제공합니다.

## **How it Works**

Aspose.Slides에는 기본 AI 기능이 포함되어 있지 않지만 인터넷을 통해 외부 AI 모델과 통합됩니다. 이 기능은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/slidesaiagent/) 클래스를 통해 노출되며, 해당 클래스는 AI 서비스와 통신하기 위해 [IAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/iaiwebclient/) 하위 클래스를 사용합니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/openaiwebclient/)를 사용하여 OpenAI API에 연결하거나, 다른 AI 공급자 또는 언어 모델을 사용하기 위해 자체 [IAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/iaiwebclient/)를 구현할 수 있습니다.

Aspose.Slides는 통신을 처리하고 AI 응답을 분석하며, 원본 슬라이드 레이아웃과 서식을 유지하면서 번역된 콘텐츠를 지능적으로 삽입합니다.

{{% alert color="primary" %}}
OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/openaiwebclient/)를 사용할 때 계정을 생성하고 API 키를 제공해야 합니다.
{{% /alert %}}

## **Example**

이 예제에서는 지정된 OpenAI [모델](https://platform.openai.com/docs/models)을 사용하여 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/openaiwebclient/)으로 PowerPoint 프레젠테이션을 일본어로 번역합니다.

```py
# 프레젠테이션을 로드하여 번역합니다.
with slides.Presentation("sample.pptx") as presentation:

    # OpenAIWebClient로 AI 클라이언트를 생성하고 모델 및 API 키를 지정합니다.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # AI 클라이언트를 사용하여 SlidesAIAgent를 초기화합니다.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # 프레젠테이션을 일본어로 번역합니다.
        ai_agent.translate(presentation, "japanese")

        # 번역된 프레젠테이션을 PDF로 저장합니다.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **Key Benefits**

Aspose.Slides [프레젠테이션 번역 API](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/)는 다국어 PowerPoint 프레젠테이션을 제공하기 위한 AI 기반 솔루션을 제공합니다. 레이아웃과 디자인을 유지하면서 번역을 자동화함으로써 수동 작업에 비해 시간 절약과 오류 최소화를 실현합니다. 개발자, 교육자, 비즈니스 전문가 등 누구든지 이 API를 활용하여 글로벌 청중을 위한 매력적이고 현지화된 프레젠테이션을 만들어 범위를 확장하고 커뮤니케이션을 향상시킬 수 있습니다.