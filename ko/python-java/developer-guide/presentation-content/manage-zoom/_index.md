---
title: Python via Java로 프레젠테이션 줌 관리
linktitle: 줌 관리
type: docs
weight: 60
url: /ko/python-java/manage-zoom/
keywords:
- 줌
- 줌 프레임
- 슬라이드 줌
- 섹션 줌
- 요약 줌
- 줌 추가
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 줌을 만들고 사용자 지정하세요 — 섹션 사이를 이동하고, PPT, PPTX 및 ODP 프레젠테이션에 썸네일과 전환 효과를 추가합니다."
---
## **소개**

PowerPoint의 줌 기능을 사용하면 프레젠테이션의 특정 슬라이드, 섹션 및 부분으로 이동하거나 돌아올 수 있습니다. 발표 중에 콘텐츠를 빠르게 탐색하는 이 기능은 매우 유용할 수 있습니다.

![overview_image](overview.png)

* 전체 프레젠테이션을 한 슬라이드에 요약하려면 [요약 줌](#summary-zoom)을 사용하십시오.
* 선택된 슬라이드만 표시하려면 [슬라이드 줌](#slide-zoom)을 사용하십시오.
* 단일 섹션만 표시하려면 [섹션 줌](#section-zoom)을 사용하십시오.

## **슬라이드 줌**
슬라이드 줌은 프레젠테이션을 보다 역동적으로 만들 수 있으며, 발표 흐름을 방해하지 않고 원하는 순서대로 슬라이드 사이를 자유롭게 탐색할 수 있게 합니다. 슬라이드 줌은 섹션이 많지 않은 짧은 프레젠테이션에 적합하지만, 다양한 시나리오에서도 활용할 수 있습니다.

슬라이드 줌을 사용하면 마치 하나의 캔버스에 있는 것처럼 여러 정보를 자세히 살펴볼 수 있습니다.

![overview_image](slidezoomsel.png)

슬라이드 줌 개체에 대해 Aspose.Slides는 [ZoomImageType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomimagetype/) 열거형, [ZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomframe/) 클래스 및 [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 클래스의 일부 메서드를 제공합니다.

### **줌 프레임 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 줌 프레임을 연결할 새 슬라이드를 생성합니다.
3. 생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4. 첫 번째 슬라이드에 (생성된 슬라이드에 대한 참조를 포함하는) 줌 프레임을 추가합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  두 번째 슬라이드의 배경 생성
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  두 번째 슬라이드에 텍스트 상자 생성
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  세 번째 슬라이드의 배경 생성
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  세 번째 슬라이드에 텍스트 상자 생성
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # ZoomFrame 객체 추가
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **사용자 지정 이미지로 줌 프레임 만들기**
Aspose.Slides for Python via Java를 사용하면 다음과 같이 다른 슬라이드 미리보기 이미지가 있는 줌 프레임을 만들 수 있습니다.
1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 줌 프레임을 연결할 새 슬라이드를 생성합니다.
3. 슬라이드에 식별 텍스트와 배경을 추가합니다.
4. 프레임을 채우는 데 사용할 이미지를 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체와 연결된 이미지 컬렉션에 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 생성합니다.
5. 첫 번째 슬라이드에 (생성된 슬라이드에 대한 참조를 포함하는) 줌 프레임을 추가합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  두 번째 슬라이드의 배경 생성
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  두 번째 슬라이드에 텍스트 상자 생성
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  줌 개체를 위한 새 이미지 생성
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # ZoomFrame 객체 추가
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **줌 프레임 서식 지정**
앞섹션에서는 간단한 줌 프레임을 만드는 방법을 보여 주었습니다. 보다 복잡한 줌 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 줌 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다.

슬라이드에서 줌 프레임의 서식을 다음과 같이 제어할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 줌 프레임을 연결할 새 슬라이드를 생성합니다.
3. 생성된 슬라이드에 식별 텍스트와 배경을 추가합니다.
4. 첫 번째 슬라이드에 (생성된 슬라이드에 대한 참조를 포함하는) 줌 프레임을 추가합니다.
5. 프레임을 채우는 데 사용할 이미지를 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체와 연결된 이미지 컬렉션에 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 생성합니다.
6. 첫 번째 줌 프레임 객체에 사용자 지정 이미지를 설정합니다.
7. 두 번째 줌 프레임 객체의 선 서식을 변경합니다.
8. 두 번째 줌 프레임 객체 이미지의 배경을 제거합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  두 번째 슬라이드의 배경 생성
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  두 번째 슬라이드에 텍스트 상자 생성
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  세 번째 슬라이드의 배경 생성
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  세 번째 슬라이드에 텍스트 상자 생성
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # ZoomFrame 객체 추가
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  줌 개체를 위한 새 이미지 생성
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  first_zoom_frame 객체에 사용자 지정 이미지 설정
    first_zoom_frame.setZoomImage(picture)

    #  second_zoom_frame 객체에 줌 프레임 서식 지정
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  second_zoom_frame 객체에 배경 표시 안 함 설정
    second_zoom_frame.setShowBackground(False)

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **섹션 줌**

섹션 줌은 프레젠테이션의 특정 섹션에 대한 링크입니다. 강조하고 싶은 섹션으로 돌아가거나 프레젠테이션의 여러 부분이 어떻게 연결되는지 강조할 때 섹션 줌을 사용할 수 있습니다.

![overview_image](seczoomsel.png)

섹션 줌 개체에 대해 Aspose.Slides는 [SectionZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectionzoomframe/) 클래스와 [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 클래스의 일부 메서드를 제공합니다.

### **섹션 줌 프레임 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 새 슬라이드를 생성합니다.
3. 생성된 슬라이드에 구별되는 배경을 추가합니다.
4. 줌 프레임을 연결할 새 섹션을 생성합니다.
5. 첫 번째 슬라이드에 (생성된 섹션에 대한 참조를 포함하는) 섹션 줌 프레임을 추가합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 1", slide)

    #  SectionZoomFrame 객체 추가
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **사용자 지정 이미지로 섹션 줌 프레임 만들기**

Aspose.Slides for Python via Java를 사용하면 다음과 같이 다른 슬라이드 미리보기 이미지가 있는 섹션 줌 프레임을 만들 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 새 슬라이드를 생성합니다.
3. 생성된 슬라이드에 구별되는 배경을 추가합니다.
4. 줌 프레임을 연결할 새 섹션을 생성합니다.
5. 프레임을 채우는 데 사용할 이미지를 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체와 연결된 이미지 컬렉션에 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 생성합니다.
6. 첫 번째 슬라이드에 (생성된 섹션에 대한 참조를 포함하는) 섹션 줌 프레임을 추가합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 1", slide)

    #  줌 개체를 위한 새 이미지 생성
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  SectionZoomFrame 객체 추가
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **섹션 줌 프레임 서식 지정**

보다 복잡한 섹션 줌 프레임을 만들려면 단순 프레임의 서식을 변경해야 합니다. 섹션 줌 프레임에 적용할 수 있는 서식 옵션이 여러 가지 있습니다.

슬라이드에서 섹션 줌 프레임의 서식을 다음과 같이 제어할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 새 슬라이드를 생성합니다.
3. 생성된 슬라이드에 구별되는 배경을 추가합니다.
4. 줌 프레임을 연결할 새 섹션을 생성합니다.
5. 첫 번째 슬라이드에 (생성된 섹션에 대한 참조를 포함하는) 섹션 줌 프레임을 추가합니다.
6. 생성된 섹션 줌 개체의 크기와 위치를 변경합니다.
7. 프레임을 채우는 데 사용할 이미지를 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체와 연결된 이미지 컬렉션에 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 생성합니다.
8. 생성된 섹션 줌 프레임 개체에 사용자 지정 이미지를 설정합니다.
9. *링크된 섹션에서 원본 슬라이드로 돌아가기* 기능을 설정합니다.
10. 섹션 줌 프레임 개체 이미지의 배경을 제거합니다.
11. 섹션 줌 프레임 개체의 선 서식을 변경합니다.
12. 전환 지속 시간을 변경합니다.
13. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 1", slide)

    #  SectionZoomFrame 객체 추가
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  SectionZoomFrame 서식 지정
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **요약 줌**

요약 줌은 프레젠테이션의 모든 요소가 한 번에 표시되는 랜딩 페이지와 같습니다. 발표 중에 줌을 사용하면 원하는 순서대로 프레젠테이션의 어느 위치든 이동할 수 있습니다. 창의적으로 전환하거나, 앞뒤로 건너뛰거나, 슬라이드 쇼의 특정 부분을 다시 방문하면서도 흐름을 끊지 않을 수 있습니다.

![overview_image](sumzoomsel.png)

요약 줌 개체에 대해 Aspose.Slides는 [SummaryZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomsection/), [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomsectioncollection/) 클래스와 [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 클래스의 일부 메서드를 제공합니다.

### **요약 줌 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 구별되는 배경과 새 섹션이 있는 새 슬라이드를 생성합니다.
3. 첫 번째 슬라이드에 요약 줌 프레임을 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 1", slide)

    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 2", slide)

    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 3", slide)

    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 4", slide)

    #  SummaryZoomFrame 객체 추가
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **요약 줌 섹션 추가 및 제거**

요약 줌 프레임의 모든 섹션은 [SummaryZoomSection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomsection/) 객체로 표현되며, 이는 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomsectioncollection/) 객체에 저장됩니다. 다음과 같이 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomsectioncollection/) 클래스를 통해 요약 줌 섹션 객체를 추가하거나 제거할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 구별되는 배경과 새 섹션이 있는 새 슬라이드를 생성합니다.
3. 첫 번째 슬라이드에 요약 줌 프레임을 추가합니다.
4. 프레젠테이션에 새 슬라이드와 섹션을 추가합니다.
5. 생성된 섹션을 요약 줌 프레임에 추가합니다.
6. 요약 줌 프레임에서 첫 번째 섹션을 제거합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 1", slide)

    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 2", slide)

    #  SummaryZoomFrame 객체 추가
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Summary Zoom에 섹션 추가
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Summary Zoom에서 섹션 제거
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **요약 줌 섹션 서식 지정**

보다 복잡한 요약 줌 섹션 객체를 만들려면 단순 프레임의 서식을 변경해야 합니다. 요약 줌 섹션 객체에 적용할 수 있는 서식 옵션이 여러 가지 있습니다.

요약 줌 프레임에서 요약 줌 섹션 객체의 서식을 다음과 같이 제어할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 구별되는 배경과 새 섹션이 있는 새 슬라이드를 생성합니다.
3. 첫 번째 슬라이드에 요약 줌 프레임을 추가합니다.
4. [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/summaryzoomsectioncollection/)에서 첫 번째 요약 줌 섹션 객체를 가져옵니다.
5. 프레임을 채우는 데 사용할 이미지를 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체와 연결된 이미지 컬렉션에 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 생성합니다.
6. 요약 줌 섹션 객체에 사용자 지정 이미지를 설정합니다.
7. *링크된 섹션에서 원본 슬라이드로 돌아가기* 기능을 설정합니다.
8. 요약 줌 섹션 객체의 선 서식을 변경합니다.
9. 전환 지속 시간을 변경합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 1", slide)

    # 프레젠테이션에 새 슬라이드 추가
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  프레젠테이션에 새 섹션 추가
    presentation.getSections().addSection("Section 2", slide)

    #  SummaryZoomFrame 객체 추가
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  첫 번째 SummaryZoomSection 객체 가져오기
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  SummaryZoomSection 객체 서식 지정
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  프레젠테이션 저장
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**대상 표시 후 '상위' 슬라이드로 돌아가는 것을 제어할 수 있나요?**

예. [ZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomframe/) 또는 [SectionZoomFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sectionzoomframe/)은 [setReturnToParent](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomobject/#setReturnToParent)를 통해 원본 슬라이드로 되돌아가는 기능을 지원합니다.

**Zoom 전환의 '속도' 또는 지속 시간을 조정할 수 있나요?**

예. Zoom은 [setTransitionDuration](https://reference.aspose.com/slides/ko/python-java/aspose.slides/zoomobject/#setTransitionDuration)를 사용하여 전환 지속 시간을 설정할 수 있으므로 애니메이션 시간을 제어할 수 있습니다.

**프레젠테이션에 포함될 수 있는 Zoom 객체 수에 제한이 있나요?**

문서화된 하드 API 제한은 없습니다. 실제 제한은 전체 프레젠테이션의 복잡도와 뷰어 성능에 따라 달라집니다. 많은 Zoom 프레임을 추가할 수 있지만 파일 크기와 렌더링 시간을 고려해야 합니다.