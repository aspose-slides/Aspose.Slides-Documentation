---
title: Python에서 장시간 실행 프리젠테이션 작업 중단
linktitle: 프리젠테이션 작업 중단
type: docs
weight: 150
url: /ko/python-net/support-for-interruptable-library/
keywords:
- 중단 가능한 작업
- 중단 토큰
- PDF 내보내기 취소
- PowerPoint
- Python
- Aspose.Slides
description: "Python에서 프리젠테이션 변환을 취소하고 취소 전에 내보내기가 완료된 슬라이드 목록을 반환하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET은 로드, 저장 및 프리젠테이션 렌더링과 같은 장시간 실행 작업 중에 협력적 취소를 지원합니다. 슬라이드를 개별적으로 내보낼 때 슬라이드 사이에서 취소를 확인하고 내보내기가 완료된 슬라이드 번호를 반환할 수 있습니다.

## **프리젠테이션 변환 취소**

새 [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/)를 생성하고 해당 [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/)을 [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/)에 할당한 다음 옵션을 [Presentation 생성자](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/)에 전달합니다. 토큰은 프리젠테이션 전체 수명 동안 적용됩니다. 애플리케이션에서 취소를 요청하려면 [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/)를 호출합니다.

예제는 `sample.pptx`를 `sample.pdf`로 변환합니다. [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer)가 20초 후에 `source.interrupt`를 호출합니다. 파일을 열기 전에 타이머를 시작하면 로드와 저장 모두에 타임아웃이 적용됩니다. 취소 버튼이 있는 애플리케이션은 이벤트 핸들러에서 동일한 메서드를 호출할 수 있습니다.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

로드 후 명시적인 검사는 타임아웃이 이미 경과한 경우 내보내기를 건너뜁니다. 로드 또는 저장 중에 요청을 감지하면 취소 예외가 호출자에게 전달됩니다. 저장이 요청을 감지하기 전에 완료될 수도 있으며, 이 경우 PDF가 완전하게 생성됩니다.

## **다음 슬라이드 처리 전에 중지**

각 내보내기 전마다 [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/)를 확인합니다. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)는 1부터 시작하는 슬라이드 번호 목록을 허용합니다. PDF가 성공적으로 저장된 후에만 해당 번호를 완료 목록에 추가합니다.

슬라이드가 최소 두 개 이상 있는 `sample.pptx` 파일을 사용합니다. 결과를 재현 가능하게 만들기 위해 예제는 슬라이드 1이 완료되는 즉시 취소를 요청합니다. 애플리케이션에서는 슬라이드가 저장되는 동안 다른 스레드에서 요청이 올 수 있습니다.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

예제는 `slide-1.pdf`를 작성하고 `Starting slide 1`을 출력한 뒤 `Completed: [1]`을 표시합니다. 다음 반복은 슬라이드 2를 시작하기 전에 요청을 확인합니다. 취소가 저장을 방해하면 예외 처리기가 이전 반복에서 기록된 번호를 반환합니다. 다른 내보내기 오류는 호출자에게 전달됩니다.

호출자가 취소를 예외로 처리해야 하는 경우 루프 상단의 검사와 `break`를 [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/)으로 교체합니다. 또한 저장 주위의 `try`/`except` 블록을 제거합니다. 동일한 입력으로 슬라이드 1은 저장되고 두 번째 반복은 슬라이드 2를 시작하기 전에 취소 예외를 발생시킵니다.

## **FAQ**

**취소 요청은 언제 적용됩니까?**

취소 가능한 작업은 토큰을 주기적으로 확인합니다. 요청을 감지하면 작업이 중단됩니다. 이미 완료된 작업은 기존 결과를 유지합니다.

**source와 token의 차이점은 무엇입니까?**

source는 애플리케이션이 취소를 요청할 수 있게 해줍니다. token은 프리젠테이션과 사용자 코드가 해당 요청을 확인할 수 있게 해줍니다.

**여러 작업이 동일한 source를 공유할 수 있습니까?**

예. `interrupt`를 호출하면 해당 source에서 만든 토큰을 사용하는 모든 작업에 취소가 요청됩니다. 작업을 독립적으로 취소해야 하면 각 작업에 별도의 source를 제공하십시오.