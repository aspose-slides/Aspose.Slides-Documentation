---
title: Python에서 장기 실행 프레젠테이션 작업 중단
linktitle: 프레젠테이션 작업 중단
type: docs
weight: 120
url: /ko/python-java/support-for-interruptable-library/
keywords:
- 중단 가능한 작업
- 중단 토큰
- 취소 토큰
- 장기 실행 작업
- 작업 중단
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 장기 실행 프레젠테이션 작업을 취소하는 방법과 슬라이드를 루프에서 내보낼 때 부분 결과를 반환하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via Java은 로드, 저장, 렌더링과 같은 장시간 실행 작업을 중단시킬 수 있습니다. 애플리케이션은 동일한 중단 토큰을 사용하여 다음 슬라이드 처리를 시작하기 전에 루프를 중지할 수 있습니다.

## **프레젠테이션 작업 중단**

[InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)를 만들고, [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken)으로 토큰을 얻은 다음, 토큰을 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken)에 전달합니다. 로드 옵션을 [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)에 전달합니다. 취소를 요청하려면 소스에서 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) 메서드를 호출합니다. 중단 가능한 작업은 요청을 감지하면 중지합니다. `jpype.JClass`를 사용하여 Python에서 Java 예외 `com.aspose.slides.exceptions.OperationCanceledException`을 잡습니다.

예제는 백그라운드 스레드에서 `sample.pptx`를 `sample.ppt`로 변환합니다. 호출 스레드는 변환이 완료될 때까지 최대 10초 동안 기다립니다. 변환이 아직 진행 중이면 취소를 요청하고 작업 스레드가 종료될 때까지 기다립니다.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Python 타임아웃을 Aspose.Slides에 연결**

프레젠테이션 작업에 시간 제한을 설정하려면 [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer)를 사용해 타임아웃이 만료될 때 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출합니다. 예제는 `sample.pptx`를 로드하고 `sample.pdf`로 내보내는 데 20초를 허용합니다. 내보내기가 일찍 완료되면 애플리케이션은 예약된 요청을 취소합니다.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **다음 슬라이드 처리 전 중단**

프레젠테이션과 슬라이드 내보내기 루프에 동일한 [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/)을 사용합니다. 각 내보내기 전에 [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested)를 확인합니다. 호출자가 부분 결과를 사용할 수 있다면, 성공적으로 완료된 내보내기 슬라이드 번호를 반환합니다.

두 개 이상의 슬라이드가 포함된 `sample.pptx` 프레젠테이션을 사용합니다. Java `int[]`를 받는 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 오버로드는 슬라이드 번호를 1부터 사용합니다. `jpype.JArray(jpype.JInt)`를 사용해 Python에서 해당 배열을 만들습니다. 예제는 각 슬라이드를 개별 PDF로 저장하고 첫 번째 성공적인 내보내기를 기록한 직후 취소를 요청합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

예제는 `slide-1.pdf`를 작성하고 `Starting slide 1`을 출력한 뒤 `Completed: [1]`을 출력합니다. 루프는 슬라이드 2를 시작하기 전에 요청을 감지합니다. 저장 중에 취소가 발생하면 해당 슬라이드를 완료된 것으로 기록하기 전에 루프가 종료됩니다.

호출자가 취소를 처리해야 하는 경우, 루프 상단의 확인과 `break`를 `token.throwIfInterruptionRequested()`로 교체합니다. 저장 주변의 `try`/`except` 블록을 제거하여 내보내기 중 취소가 호출자에게 전달되도록 합니다. 동일한 입력으로 예제는 `Starting slide 1`만 출력하고 `slide-1.pdf`만 작성합니다. 두 번째 반복 시작 시 [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) 메서드가 `com.aspose.slides.exceptions.OperationCanceledException`을 발생시켜 다음 내보내기가 시작되기 전에 예외가 호출자에게 전파됩니다. 함수가 리스트를 반환하기 전에 예외가 전파됩니다.

## **FAQ**

**언제 취소를 요청해야 하나요?**

작업이 시간 제한을 초과하거나 애플리케이션이 더 이상 결과가 필요하지 않을 때 취소를 요청합니다.

**[InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/)과 [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)의 차이점은 무엇인가요?**

소스는 애플리케이션이 취소를 요청할 수 있게 해줍니다. 토큰은 Aspose.Slides와 애플리케이션이 해당 요청을 확인할 수 있게 해줍니다.

**Python 타이머에서 작업을 취소할 수 있나요?**

예. 프레젠테이션과 연결된 소스에서 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하도록 예약합니다.

**어떤 작업을 중단할 수 있나요?**

로드, 저장, 렌더링을 중단할 수 있습니다. 토큰을 [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)에 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken)을 통해 전달합니다. 이후 프레젠테이션은 PDF 저장과 같은 후속 작업 중에 취소를 감지할 수 있습니다.

**작업이 즉시 중단되나요?**

취소는 협조적으로 이루어집니다. 작업은 토큰을 주기적으로 확인하고 요청을 감지하면 중단합니다.

**작업이 끝난 뒤에 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하면 어떻게 되나요?**

이미 완료된 작업은 그 결과를 유지합니다.

**여러 작업이 동일한 [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)를 공유할 수 있나요?**

예. [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하면 해당 소스에서 만든 토큰을 사용하는 모든 작업에 취소 요청이 전달됩니다. 독립적으로 취소하려는 각 작업마다 별도의 소스를 사용하십시오.