---
title: 중단 가능한 라이브러리 지원
type: docs
weight: 120
url: /ko/python-java/support-for-interruptable-library/
keywords:
- 중단 가능한 라이브러리
- 중단 토큰
- 취소 토큰
- 장시간 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 장시간 작업을 취소 가능하게 만듭니다. PowerPoint 및 OpenDocument에 대한 렌더링 및 변환을 안전하게 중단할 수 있으며, 예제가 포함되어 있습니다."
---
## **개요**

Aspose.Slides는 역직렬화, 직렬화 및 렌더링과 같은 장시간 실행 프레젠테이션 작업에 대한 중단 가능한 처리 메커니즘을 제공합니다. 이 메커니즘은 [InterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontoken/) 및 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/) 클래스를 기반으로 합니다.

[InterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontoken/)은 [LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/)에 지정하고 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 생성자에 전달할 수 있습니다. [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/#interrupt)가 호출되면 연결된 장시간 작업이 중단됩니다.

## **중단 가능한 라이브러리**

Aspose.Slides for Python via Java는 [InterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontoken/) 및 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/) 클래스를 제공합니다. 이를 통해 역직렬화, 직렬화 및 렌더링과 같은 장시간 작업을 중단할 수 있습니다.

- [InterruptionTokenSource](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/)은 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setInterruptionToken)으로 전달되는 토큰의 소스입니다.
- [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setInterruptionToken)가 호출되고 [LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/) 인스턴스가 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 생성자에 전달될 때, [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하면 해당 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)과 연결된 모든 장시간 작업이 중단됩니다.

다음 코드 조각은 실행 중인 작업을 중단하는 방법을 보여줍니다:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # 작업을 별도의 스레드에서 실행합니다.
    time.sleep(10)  # 시간 초과.
    token_source.interrupt()  # 변환을 중단합니다.
    conversion_task.result()
```

## **FAQ**

**Aspose.Slides 중단 라이브러리의 목적은 무엇입니까?**

프레젠테이션을 로드, 저장 또는 렌더링하는 등 장시간 실행되는 작업을 완료되기 전에 중단할 수 있는 메커니즘을 제공합니다. 처리 시간을 제한하거나 작업이 더 이상 필요하지 않을 때 유용합니다.

**[InterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontoken/)과 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/)의 차이점은 무엇입니까?**

- [InterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontoken/)은 Aspose.Slides API에 전달되어 장시간 작업 중에 확인됩니다.
- [InterruptionTokenSource](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/)는 코드에서 토큰을 생성하고 [interrupt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하여 중단을 트리거하는 데 사용됩니다.

**어떤 작업을 중단할 수 있습니까?**

[InterruptionToken](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontoken/)을 허용하는 모든 Aspose.Slides 작업—예를 들어 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)으로 프레젠테이션을 로드하거나 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)으로 저장하는 경우—는 중단할 수 있습니다.

**중단이 즉시 발생합니까?**

아니요. 중단은 협력형입니다: 작업이 주기적으로 토큰을 확인하고 [interrupt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/#interrupt)가 호출된 것을 감지하면 바로 중단됩니다.

**작업이 이미 완료된 후에 [interrupt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하면 어떻게 됩니까?**

아무 일도 일어나지 않습니다—해당 작업이 이미 완료된 경우 호출은 영향을 주지 않습니다.

**여러 작업에 동일한 [InterruptionTokenSource](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/)를 재사용할 수 있습니까?**

예—but 해당 소스에서 [interrupt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하면 해당 토큰을 사용하는 모든 작업이 중단됩니다. 작업을 독립적으로 관리하려면 별도의 토큰 소스를 사용하십시오.