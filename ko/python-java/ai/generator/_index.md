---
title: AI 기반 다국어 슬라이드 생성기
linktitle: AI 기반 생성기
type: docs
weight: 40
url: /ko/python-java/ai/generator/
keywords:
- 다국어 프레젠테이션
- 다국어 슬라이드
- AI 프레젠테이션 생성기
- AI 슬라이드 생성기
- 프레젠테이션 템플릿
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 텍스트에서 다국어 프레젠테이션을 생성합니다. 콘텐츠 상세 정도를 선택하고 템플릿을 적용하여 PowerPoint 또는 PDF로 내보낼 수 있습니다."
---
## **소개**

Aspose.Slides for Python via Java의 AI 프레젠테이션 생성기는 주제 설명, 요약, 인용문 또는 글머리표에서 프레젠테이션을 생성합니다. 프롬프트에 필요한 언어를 지정하고, 콘텐츠 양을 선택하며, 선택적으로 레이아웃과 디자인을 정의하는 프레젠테이션 템플릿을 제공할 수 있습니다.

생성기는 텍스트 블록, 글머리 목록 및 표를 사용하여 콘텐츠를 구성합니다. 이미지는 생성되지 않으며, 이후 결과 프레젠테이션에 추가할 수 있습니다. 프레젠테이션을 공유하기 전에 생성된 콘텐츠와 레이아웃을 검토하십시오.

## **작동 방식**

[SlidesAIAgent](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesaiagent/)은 외부 모델과 통신하기 위해 AI 클라이언트를 사용합니다. 아래 예제들은 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-java/aspose.slides/openaiwebclient/)를 사용합니다. Aspose.Slides는 모델의 응답을 처리하고 편집하거나 내보낼 수 있는 프레젠테이션을 구축합니다.

[SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesaiagent/#generatePresentation)을 텍스트 설명과 [PresentationContentAmountType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationcontentamounttype/) 값과 함께 사용합니다. 세 번째 인수를 사용하는 오버로드는 디자인 템플릿으로 사용할 프레젠테이션을 허용합니다.

## **필수 조건**

[Installation](/slides/ko/python-java/installation/)을 따라 Python, Java, JPype 및 Aspose.Slides를 구성하십시오. 예제를 실행하기 전에 `OPENAI_API_KEY`와 `OPENAI_MODEL` 환경 변수를 설정합니다. 내장 클라이언트에서 지원하고 API 계정에서 사용할 수 있는 모델을 선택하십시오.

{{% alert color="info" title="Note" %}}
AI 서비스는 인터넷 연결과 별도의 API 액세스가 필요합니다. 프롬프트는 구성된 서비스로 전송되며, 사용 요금은 Aspose.Slides 라이선스와 별도로 부과됩니다.
{{% /alert %}}

각 예제는 JVM이 이미 실행 중이 아닌 경우에만 시작하고 이후 작업을 위해 그대로 유지합니다. 노트북용 코드를 조정할 때는 [JVM lifecycle guidance](/slides/ko/python-java/limitations-and-api-differences/#import-the-library)를 참조하십시오.

## **텍스트에서 프레젠테이션 생성**

이 예제는 중간 정도의 콘텐츠 양을 가진 영어 프레젠테이션을 생성하고 PowerPoint 파일로 저장합니다.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **템플릿을 사용한 프레젠테이션 생성**

`masterPresentation.pptx`를 작업 디렉터리에 배치하십시오. 이 예제는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)을 사용해 파일을 로드하고, 자세한 콘텐츠를 가진 스페인어 프레젠테이션을 생성한 후 PDF로 내보냅니다. 생성 또는 저장에 실패하더라도 템플릿과 생성된 프레젠테이션은 모두 해제됩니다.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

프록시 또는 연결 시간 초과를 구성해야 하는 경우, [Configure the HTTP Connection](/slides/ko/python-java/ai/translator/#configure-the-http-connection)를 참조하십시오. 생성기에 결과 클라이언트를 전달할 수도 있습니다.

## **주요 이점**

생성은 교육 자료, 제품 개요, 고객 보고서 및 내부 프레젠테이션의 초기 초안 작업을 감소시킬 수 있습니다. 프롬프트는 주제와 언어를 제어하고, 템플릿을 사용하면 기존 프레젠테이션 디자인을 재사용할 수 있습니다.

## **FAQ**

**생성된 프레젠테이션의 길이를 어떻게 조절합니까?**

[Brief](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationcontentamounttype/#Medium), 또는 [Detailed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationcontentamounttype/#Detailed)를 선택합니다. 이러한 설정은 슬라이드 수와 각 슬라이드의 상세 수준 모두에 영향을 미치지만 정확한 슬라이드 수를 지정하지는 않습니다.

**다른 언어로 슬라이드를 생성할 수 있습니까?**

예. 텍스트 설명에 원하는 언어를 포함하십시오. 결과는 선택한 모델의 언어 지원 범위에 따라 달라집니다.

**PDF로 내보낼 때 편집 가능한 버전을 유지할 수 있습니까?**

예. 생성된 프레젠테이션을 폐기하기 전에 첫 번째 예제의 방법을 사용해 PPTX 형식으로도 저장하십시오.