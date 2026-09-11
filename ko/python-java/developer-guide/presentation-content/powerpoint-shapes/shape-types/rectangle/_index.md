---
title: Python을 이용한 Java에서 프레젠테이션에 사각형 추가
linktitle: 사각형
type: docs
weight: 80
url: /ko/python-java/rectangle/
keywords:
- 사각형 추가
- 사각형 만들기
- 사각형 모양
- 단순 사각형
- 서식 있는 사각형
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 사각형을 추가함으로써 PowerPoint 프레젠테이션을 강화하고, 프로그래밍 방식으로 도형을 손쉽게 디자인하고 수정할 수 있습니다."
---
## **Overview**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 사각형 모양을 추가하는 방법을 보여줍니다. 간단한 사각형 만들기, 서식이 지정된 사각형 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 과정을 다룹니다.

또한 채우기 색상, 선 색상 및 선 두께와 같은 기본 사각형 서식을 적용하는 방법을 확인할 수 있습니다. 추가로, 문서의 FAQ에서는 모서리 둥글게 만들기, 이미지 채우기, 시각 효과, 하이퍼링크, 도형 잠금, 내보내기 옵션 및 유효한 속성과 같은 관련 사각형 작업을 안내합니다.

## **Add a Rectangle to a Slide**

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 인덱스로 슬라이드에 대한 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 사각형 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 슬라이드에 간단한 사각형을 추가했습니다.

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

    # 사각형 모양을 추가합니다.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add a Formatted Rectangle to a Slide**

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 인덱스로 슬라이드에 대한 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 사각형 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)를 추가합니다.
- 사각형의 [fill type](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filltype/)을 실색(단색)으로 설정합니다.
- [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 객체와 연결된 [FillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/) 객체의 실색 채우기 색상에 대해 [setColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/colorformat/#setColor) 메서드를 사용하여 사각형 색상을 설정합니다.
- 사각형 윤곽선 색상을 설정합니다.
- 사각형 윤곽선 두께를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계는 아래 예시에서 구현되었습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 사각형 모양을 추가합니다.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # 사각형 채우기 형식을 지정합니다.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # 사각형 윤곽선 형식을 지정합니다.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**How do I add a rectangle with rounded corners?**

모서리 둥근 [shape type](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapetype/)을 사용하고 도형 속성에서 모서리 반경을 조정합니다; 기하학적 조정을 통해 각 모서리마다 둥근 모양을 적용할 수도 있습니다.

**How do I fill a rectangle with an image (texture)?**

그림 [fill type](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filltype/)을 선택하고 이미지 소스를 제공한 뒤, [stretching/tiling modes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillmode/)를 구성합니다.

**Can a rectangle have shadow and glow?**

예. 조정 가능한 매개변수를 갖춘 [Outer/inner shadow, glow, and soft edges](/slides/ko/python-java/shape-effect/)를 사용할 수 있습니다.

**Can I turn a rectangle into a button with a hyperlink?**

예. 도형 클릭에 [Assign a hyperlink](/slides/ko/python-java/manage-hyperlinks/)을 지정하여 슬라이드, 파일, 웹 주소 또는 이메일로 이동하도록 할 수 있습니다.

**How can I protect a rectangle from moving and changes?**

[Use shape locks](/slides/ko/python-java/applying-protection-to-presentation/): 이동, 크기 조정, 선택 또는 텍스트 편집을 금지하여 레이아웃을 유지할 수 있습니다.

**Can I convert a rectangle to a raster image or SVG?**

예. 지정된 크기/비율로 이미지를 만들기 위해 [render the shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage) 를 사용하거나 벡터 용도로 [export it as SVG](/slides/ko/python-java/create-shape-thumbnails/)를 수행할 수 있습니다.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/ko/python-java/shape-effective-properties/): API가 테마 스타일, 레이아웃 및 로컬 설정을 반영한 계산된 값을 반환하여 서식 분석을 간소화합니다.