---
title: Python에서 프레젠테이션에 워터마크 추가
linktitle: 워터마크
type: docs
weight: 40
url: /ko/python-java/watermark/
keywords:
- 워터마크
- 텍스트 워터마크
- 이미지 워터마크
- 워터마크 추가
- 워터마크 변경
- 워터마크 제거
- 워터마크 삭제
- PPT에 워터마크 추가
- PPTX에 워터마크 추가
- ODP에 워터마크 추가
- PPT에서 워터마크 제거
- PPTX에서 워터마크 제거
- ODP에서 워터마크 제거
- PPT에서 워터마크 삭제
- PPTX에서 워터마크 삭제
- ODP에서 워터마크 삭제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트와 이미지 워터마크를 관리하여 초안, 기밀 정보, 저작권 등을 표시합니다."
---
## **소개**

프레젠테이션의 워터마크는 슬라이드 또는 전체 프레젠테이션 슬라이드에 사용되는 텍스트 또는 이미지 스탬프입니다. 일반적으로 워터마크는 프레젠테이션이 초안임을 표시하기 위해(예: "Draft" 워터마크), 기밀 정보를 포함하고 있음을 나타내기 위해(예: "Confidential" 워터마크), 어느 회사에 속하는지 지정하기 위해(예: "Company Name" 워터마크), 프레젠테이션 저자를 식별하기 위해 등 사용됩니다. 워터마크는 프레젠테이션을 복사해서는 안 된다는 표시를 통해 저작권 침해를 방지하는 데 도움을 줍니다. 워터마크는 PowerPoint와 OpenOffice 프레젠테이션 형식 모두에서 사용됩니다. Aspose.Slides에서는 PowerPoint PPT, PPTX 및 OpenOffice ODP 파일 형식에 워터마크를 추가할 수 있습니다.

[**Aspose.Slides**](https://products.aspose.com/slides/ko/python-java/)에서는 PowerPoint 또는 OpenOffice 문서에 워터마크를 만들고 디자인 및 동작을 수정하는 다양한 방법을 제공합니다. 일반적인 부분은 텍스트 워터마크를 추가하려면 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 클래스를 사용하고, 이미지 워터마크를 추가하려면 [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/) 클래스를 사용하거나 워터마크 모양을 이미지로 채우는 것입니다. [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)은 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 클래스를 상속받아 모양 객체의 모든 유연한 설정을 사용할 수 있습니다. [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)은 모양이 아니며 설정이 제한적이므로 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 객체에 래핑됩니다.

워터마크를 적용하는 방법은 두 가지가 있습니다: 단일 슬라이드에 적용하거나 모든 프레젠테이션 슬라이드에 적용하는 것입니다. 모든 슬라이드에 워터마크를 적용하려면 슬라이드 마스터를 사용합니다 — 워터마크는 슬라이드 마스터에 추가되어 전체 디자인이 이루어지고, 개별 슬라이드에서 워터마크를 수정할 수 있는 권한에 영향을 주지 않고 모든 슬라이드에 적용됩니다.

워터마크는 일반적으로 다른 사용자가 편집할 수 없도록 간주됩니다. 워터마크(또는 워터마크의 상위 모양)가 편집되지 않도록 하려면 Aspose.Slides에서 제공하는 모양 잠금 기능을 사용할 수 있습니다. 특정 모양은 일반 슬라이드나 슬라이드 마스터에서 잠글 수 있습니다. 슬라이드 마스터에서 워터마크 모양을 잠그면 모든 프레젠테이션 슬라이드에 적용됩니다.

워터마크에 이름을 지정하면 이후에 삭제하고 싶을 때 슬라이드의 모양 목록에서 이름으로 쉽게 찾을 수 있습니다.

워터마크는 원하는 대로 디자인할 수 있지만, 일반적으로 중앙 정렬, 회전, 앞쪽 위치 등 공통적인 특징이 있습니다. 아래 예제에서는 이러한 기능들을 어떻게 사용하는지 살펴보겠습니다.

## **텍스트 워터마크**

### **슬라이드에 텍스트 워터마크 추가**

PPT, PPTX 또는 ODP에 텍스트 워터마크를 추가하려면 먼저 슬라이드에 모양을 추가하고, 그 모양에 텍스트 프레임을 추가하면 됩니다. 텍스트 프레임은 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 클래스로 표현됩니다. 이 유형은 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)을 상속하지 않으며, 워터마크를 유연하게 배치하기 위한 다양한 속성을 제공합니다. 따라서 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 객체는 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 객체에 래핑됩니다. 모양에 워터마크 텍스트를 추가하려면 아래와 같이 [addTextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#addTextFrame) 메서드를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [텍스트 프레임 클래스 사용 방법](/slides/ko/python-java/text-formatting/)
{{% /alert %}}

### **프레젠테이션에 텍스트 워터마크 추가**

전체 프레젠테이션(즉, 모든 슬라이드)에 텍스트 워터마크를 추가하려면 [MasterSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/)에 추가합니다. 나머지 로직은 단일 슬라이드에 워터마크를 추가할 때와 동일합니다 — [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 객체를 만들고 [addTextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#addTextFrame) 메서드를 사용해 워터마크를 추가합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [슬라이드 마스터 사용 방법](/slides/ko/python-java/slide-master/)
{{% /alert %}}

### **워터마크 모양 투명도 설정**

기본적으로 사각형 모양은 채우기 및 선 색상으로 스타일이 지정됩니다. 다음 코드 줄은 모양을 투명하게 만듭니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **텍스트 워터마크의 글꼴 설정**

아래와 같이 텍스트 워터마크의 글꼴을 변경할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **워터마크 텍스트 색상 설정**

워터마크 텍스트 색상을 설정하려면 아래 코드를 사용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **텍스트 워터마크 중앙 정렬**

슬라이드에서 워터마크를 중앙에 배치할 수 있으며, 이를 위해 다음과 같이 할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

아래 이미지가 최종 결과를 보여줍니다.

![텍스트 워터마크](text_watermark.png)

## **이미지 워터마크**

### **프레젠테이션에 이미지 워터마크 추가**

프레젠테이션 슬라이드에 이미지 워터마크를 추가하려면 다음과 같이 할 수 있습니다:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **워터마크 편집 잠금**

워터마크가 편집되는 것을 방지해야 할 경우, 해당 모양에 대해 [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#getAutoShapeLock) 메서드를 사용합니다. 이 속성을 사용하면 모양을 선택, 크기 변경, 위치 이동, 다른 요소와 그룹화, 텍스트 편집 잠금 등 다양한 방면에서 보호할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # 워터마크 모양을 수정으로부터 잠급니다.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **워터마크를 앞쪽으로 가져오기**

Aspose.Slides에서는 모양의 Z-순서를 [ShapeCollection.reorder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#reorder) 메서드로 설정할 수 있습니다. 이를 위해 슬라이드의 모양 컬렉션에서 이 메서드를 호출하고 모양 참조와 순번을 전달합니다. 이렇게 하면 모양을 앞쪽으로 가져오거나 뒤로 보낼 수 있습니다. 이 기능은 워터마크를 프레젠테이션 앞에 배치해야 할 때 특히 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **워터마크 회전 설정**

다음은 워터마크의 회전을 조정하여 슬라이드 대각선에 배치하는 코드 예시입니다:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **워터마크 이름 설정**

Aspose.Slides에서는 모양의 이름을 지정할 수 있습니다. 모양 이름을 사용하면 이후에 해당 모양에 접근하여 수정하거나 삭제할 수 있습니다. 워터마크 모양의 이름을 설정하려면 [Shape.setName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setName) 메서드에 이름을 전달합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **워터마크 제거**

워터마크 모양을 제거하려면 [Shape.getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getName) 메서드로 슬라이드 모양 중 해당 모양을 찾은 다음, [ShapeCollection.remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#remove) 메서드에 전달합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**워터마크란 무엇이며 왜 사용해야 하나요?**

워터마크는 슬라이드에 적용되는 텍스트 또는 이미지 오버레이로, 지적 재산을 보호하고, 브랜드 인지도를 높으며, 프레젠테이션의 무단 사용을 방지하는 데 도움이 됩니다.

**프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있나요?**

네, Aspose.Slides를 사용하면 프로그램을 통해 프레젠테이션의 모든 슬라이드에 워터마크를 추가할 수 있습니다. 모든 슬라이드를 순회하면서 각각에 워터마크 설정을 적용하면 됩니다.

**워터마크의 투명도를 어떻게 조정할 수 있나요?**

워터마크의 투명도는 모양의 채우기 설정([getFillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getFillFormat))을 수정하여 조정할 수 있습니다. 이는 워터마크가 은은하게 표시되어 슬라이드 내용의 방해가 되지 않도록 합니다.

**워터마크에 지원되는 이미지 형식은 어떤 것이 있나요?**

Aspose.Slides는 PNG, JPEG, GIF, BMP, SVG 등 다양한 이미지 형식을 지원합니다.

**텍스트 워터마크의 글꼴과 스타일을 맞춤화할 수 있나요?**

네, 원하는 글꼴, 크기, 스타일을 선택하여 프레젠테이션 디자인과 브랜드 일관성을 유지할 수 있습니다.

**워터마크의 위치나 방향을 어떻게 변경하나요?**

워터마크의 위치와 방향은 모양의 좌표, 크기 및 회전 속성을 프로그래밍으로 수정하여 조정할 수 있습니다.