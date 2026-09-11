---
title: Python via Java에서 프레젠테이션에 선 형태 추가
linktitle: 선
type: docs
weight: 50
url: /ko/python-java/line/
keywords:
- 선
- 선 만들기
- 선 추가
- 일반 선
- 선 구성
- 선 사용자 지정
- 대시 스타일
- 화살표 머리
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 선 서식을 조작하는 방법을 배웁니다. 속성, 메서드 및 예제를 확인하세요."
---
## **Overview**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 슬라이드에 선 형태를 추가할 수 있습니다. 이 문서에서는 간단한 선을 만드는 방법과 선을 화살표처럼 보이도록 사용자 지정하는 방법을 보여줍니다.

슬라이드에 선 형태를 추가하고 시각적 모양을 조정한 뒤 업데이트된 프레젠테이션을 저장하는 방법을 배웁니다. 예제에서는 선 스타일, 두께, 대시 패턴, 화살촉 옵션 및 채우기 색상과 같은 실용적인 선 서식 설정에 중점을 둡니다.

## **Create a Plain Line**

프레젠테이션의 선택된 슬라이드에 간단한 선을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래의 인스턴스를 생성합니다.
- 인덱스로 슬라이드에 대한 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 객체의 [addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 선 형태를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 선 형태를 추가합니다.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Create an Arrow-Shaped Line**

Aspose.Slides for Python via Java은 선 속성을 구성하여 선을 더욱 돋보이게 할 수 있게 합니다. 선을 화살표처럼 보이게 구성하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래의 인스턴스를 생성합니다.
- 인덱스로 슬라이드에 대한 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 객체의 [addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 선 형태를 추가합니다.
- [line style](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linestyle/)을 Aspose.Slides for Python via Java이 제공하는 스타일 중 하나로 설정합니다.
- 선의 두께를 설정합니다.
- [dash style](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linedashstyle/)을 Aspose.Slides for Python via Java이 제공하는 스타일 중 하나로 설정합니다.
- 선 시작 부분에 [arrowhead style](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linearrowheadstyle/) 및 [length](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linearrowheadlength/)을 설정합니다.
- 선 끝 부분에 [arrowhead style](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linearrowheadstyle/) 및 [length](https://reference.aspose.com/slides/ko/python-java/aspose.slides/linearrowheadlength/)을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 선 형태를 추가합니다.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # 선에 서식을 적용합니다.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/ko/python-java/aspose.slides/connector/) type and the [corresponding APIs](/slides/ko/python-java/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/ko/python-java/shape-effective-properties/) of the line and its fill—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#getAutoShapeLock) that let you [disallow editing operations](/slides/ko/python-java/applying-protection-to-presentation/).