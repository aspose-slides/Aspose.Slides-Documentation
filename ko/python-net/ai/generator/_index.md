---
title: AI 기반 다국어 슬라이드 생성기
linktitle: AI 기반 생성기
type: docs
weight: 40
url: /ko/python-net/ai/generator/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 텍스트에서 다국어 슬라이드를 생성합니다. 템플릿을 적용하고 PowerPoint 및 OpenDocument 형식으로 깔끔한 데크를 내보냅니다. 자세히 알아보세요."
---
## **소개**

Aspose.Slides는 새로운 AI 기반 기능인 Presentation Generator를 도입하여 개발자가 주제 설명, 요약, 인용문 또는 글머리표와 같은 간단한 텍스트 입력만으로 잘 구조화된 PowerPoint 프레젠테이션을 자동으로 생성할 수 있게 합니다.

사용자는 콘텐츠 상세 수준을 조정하고 선택적으로 사용자 지정 프레젠테이션 템플릿을 적용하여 시각 디자인을 정의할 수 있습니다.

현재 AI Presentation Generator는 텍스트 블록, 글머리표 목록 및 표를 사용하여 콘텐츠를 구조화합니다. 이미지 생성은 아직 지원되지 않지만, 이후에 Aspose.Slides 도구를 사용하거나 수동으로 이미지를 쉽게 추가할 수 있습니다.

출력은 즉시 사용할 수 있거나 Aspose.Slides API에서 지원하는 모든 형식으로 내보낼 수 있는 완전한 PowerPoint 프레젠테이션입니다. 생성기는 고품질 결과를 제공하지만, 특정 요구 사항을 충족하기 위해 약간의 사후 편집이 필요할 수 있습니다.

## **작동 방식**

Aspose.Slides는 내장 AI 모델을 포함하지 않으며, 대신 인터넷을 통해 외부 AI 서비스와 통합됩니다. 이러한 통합은 [SlidesAIAgent](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/slidesaiagent/) 클래스를 통해 처리되며, 이 클래스는 AI 모델과 통신하기 위해 [IAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/iaiwebclient/) 클래스의 구현을 사용합니다.

내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/openaiwebclient/)를 사용하여 OpenAI API에 연결하거나, 다른 AI 제공자 또는 언어 모델과 작업하기 위해 [IAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/iaiwebclient/)의 사용자 정의 구현을 제공할 수 있습니다. Aspose.Slides는 AI 서비스와의 모든 통신을 관리하고 AI의 응답을 처리하여 슬라이드를 생성합니다. OpenAI API는 유료 서비스이므로, 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/openaiwebclient/)를 사용할 때는 계정과 API 키가 필요합니다.

## **코드 작성**

### **예제 1**

이 예제는 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/openaiwebclient/)를 사용하여 Aspose.Slides 주제로 프레젠테이션을 생성하는 방법을 보여줍니다.

```py
# OpenAIWebClient 인스턴스를 생성합니다. OpenAI 웹 클라이언트의 기본 구현입니다.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # SlidesAIAgent 인스턴스를 생성합니다. AI 기반 기능에 접근할 수 있습니다.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # 프레젠테이션 생성 지시문을 정의합니다.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # 지시문을 기반으로 중간 양의 콘텐츠를 가진 프레젠테이션을 생성합니다.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # 생성된 프레젠테이션을 로컬 디스크에 PowerPoint(.pptx) 파일로 저장합니다.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **예제 2**

다음 예제는 [generate_presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation) 메서드의 오버로드를 보여줍니다. 이 경우 사용자의 `master presentation`이 사용됩니다.

```py
# HttpClient를 OpenAIWebClient 생성자에 전달합니다.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # SlidesAIAgent 인스턴스를 생성합니다.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # 프레젠테이션 생성 지시문을 정의합니다.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # 디자인 템플릿으로 사용할 마스터 프레젠테이션을 로컬 디스크에서 로드합니다.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # 지시문과 마스터 템플릿을 사용하여 자세한 프레젠테이션을 생성합니다.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # 생성된 프레젠테이션을 PDF로 저장합니다.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **핵심 이점**

Aspose.Slides의 새로운 AI Presentation Generator는 간단한 텍스트 프롬프트로부터 구조화된 슬라이드 덱을 빠르고 유연하게 생성하는 방법을 제공합니다. 사용자 지정 템플릿을 지원하므로 다양한 애플리케이션에 원활하게 통합될 수 있습니다.

일반적인 사용 사례로는 마케팅 프레젠테이션, 교육 자료, 클라이언트 보고서 및 내부 슬라이드 덱 생성이 있습니다. 아직 이미지 생성을 지원하지 않지만, 이 도구는 프레젠테이션 자동 생성의 강력한 기반을 제공하며 향후 추가 개선이 기대됩니다.