---
title: Python via Java에서 슬라이드 쇼 관리
linktitle: 슬라이드 쇼
type: docs
weight: 90
url: /ko/python-java/manage-slide-show/
keywords:
- 슬라이드 유형
- 발표자에 의해 제시
- 개인별 탐색
- 키오스크에서 탐색
- 쇼 옵션
- 지속적 루프
- 내레이션 없이 표시
- 애니메이션 없이 표시
- 펜 색상
- 슬라이드 표시
- 맞춤 쇼
- 슬라이드 진행
- 수동
- 타이밍 사용
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 슬라이드 쇼를 관리하는 방법을 배웁니다. PPT, PPTX 및 ODP 형식에서 슬라이드 전환, 타이밍 등을 쉽게 제어할 수 있습니다."
---
## **소개**

Microsoft PowerPoint의 **Set Up Show** 옵션을 사용하면 쇼 유형을 선택하고, 루프를 활성화하며, 슬라이드를 선택하고, 슬라이드 진행 방식을 제어할 수 있습니다. Aspose.Slides for Python via Java를 사용하면 이러한 옵션을 프로그래밍 방식으로 구성하고 프레젠테이션 파일에 저장할 수 있습니다.

The [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlideShowSettings) 메서드는 이러한 옵션을 제어하는 ​​[SlideShowSettings](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/) 객체를 반환합니다. 아래 예제들은 Aspose.Slides for Python via Java와 호환되는 Java 런타임이 필요합니다. 각 예제는 필요에 따라 JVM을 시작하고 완료 시 프레젠테이션을 해제합니다.

## **쇼 유형 선택**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/#setSlideShowType) 메서드는 슬라이드 쇼 유형을 정의하며, 다음 클래스 중 하나의 인스턴스가 될 수 있습니다: [PresentedBySpeaker](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/ko/python-java/aspose.slides/browsedbyindividual/), 또는 [BrowsedAtKiosk](https://reference.aspose.com/slides/ko/python-java/aspose.slides/browsedatkiosk/). 이 메서드를 사용하면 자동 키오스크나 수동 프레젠테이션과 같은 다양한 사용 시나리오에 맞게 프레젠테이션을 조정할 수 있습니다.

아래 코드 예제는 새 프레젠테이션을 만들고 스크롤바를 표시하지 않은 상태에서 쇼 유형을 "Browsed by an individual"(개별 사용자가 탐색)으로 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **쇼 옵션 활성화**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/#setLoop) 메서드는 슬라이드 쇼가 수동으로 중지될 때까지 루프 반복할지 여부를 결정합니다. 이는 지속적으로 실행되어야 하는 자동 프레젠테이션에 유용합니다. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/#setShowNarration) 메서드는 슬라이드 쇼 중에 음성 내레이션을 재생할지 여부를 결정합니다. 이는 청중에게 음성 안내가 포함된 자동 프레젠테이션에 유용합니다. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/#setShowAnimation) 메서드는 슬라이드 객체에 추가된 애니메이션을 재생할지 여부를 결정합니다. 이는 프레젠테이션의 전체 시각 효과를 제공하는 데 유용합니다.

다음 코드 예제는 새 프레젠테이션을 만들고 슬라이드 쇼를 루프합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표시할 슬라이드 선택**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/#setSlides) 메서드는 프레젠테이션 중에 표시할 슬라이드 범위를 선택할 수 있게 합니다. 이는 전체 슬라이드가 아닌 프레젠테이션의 일부만 표시해야 할 때 유용합니다. 다음 코드 예제는 9개의 슬라이드가 있는 프레젠테이션을 만들고 슬라이드 2부터 9까지를 선택합니다. 범위는 1부터 시작하는 슬라이드 번호를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # 선택된 범위가 존재하도록 9개의 슬라이드를 생성합니다.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **슬라이드 진행 제어**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/#setUseTimings) 메서드를 사용하면 각 슬라이드에 대한 사전 설정된 타이밍 사용을 활성화하거나 비활성화할 수 있습니다. 이는 미리 정의된 표시 기간으로 슬라이드를 자동으로 표시할 때 유용합니다. 아래 코드 예제는 새 프레젠테이션을 만들고 타이밍 사용을 비활성화합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **미디어 컨트롤 표시**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) 메서드는 멀티미디어 콘텐츠(예: 비디오 또는 오디오)가 재생될 때 슬라이드 쇼 중에 미디어 컨트롤(재생, 일시 정지, 정지 등)을 표시할지 여부를 결정합니다. 이는 프레젠테이션 중 발표자에게 미디어 재생 제어 권한을 부여하고 싶을 때 유용합니다.

다음 코드 예제는 새 프레젠테이션을 만들고 미디어 컨트롤을 표시하도록 활성화합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**프레젠테이션을 저장하여 슬라이드 쇼 모드로 바로 열 수 있나요?**

예. 파일을 PPSX 또는 PPSM 형식으로 저장하면 PowerPoint에서 열었을 때 바로 슬라이드 쇼 모드로 실행됩니다. Aspose.Slides에서는 해당 저장 형식을 [during export](/slides/ko/python-java/save-presentation/)에서 선택합니다.

**파일에서 삭제하지 않고 개별 슬라이드를 쇼에서 제외할 수 있나요?**

예. 슬라이드를 [hidden](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#setHidden)으로 표시하면 됩니다. 숨긴 슬라이드는 프레젠테이션에 남아 있지만 슬라이드 쇼 중에는 표시되지 않습니다.

**Aspose.Slides가 슬라이드 쇼를 재생하거나 화면에서 실시간 프레젠테이션을 제어할 수 있나요?**

아니요. Aspose.Slides는 프레젠테이션 파일을 편집·분석·변환할 뿐이며, 실제 재생은 PowerPoint와 같은 뷰어 애플리케이션이 담당합니다.