---
title: Python을 사용한 Java 경유 프레젠테이션 슬라이드의 도형 크기 조정
type: docs
weight: 110
url: /ko/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /ko/python-java/re-sizing-shapes-on-slide/
keywords:
  - 도형 크기 조정
  - 도형 크기 변경
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 도형을 손쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높입니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새 치수에 맞게 도형의 크기를 조정하고 위치를 재배치해야 할 수도 있습니다. 이 문서에서는 도형을 수동으로 스케일링하는 방법과 슬라이드, 마스터 및 레이아웃의 테이블을 처리하는 방법을 보여줍니다.

## **도형 크기 조정**

각 도형의 상대적인 위치와 크기를 유지하려면 새 슬라이드 너비와 원래 너비의 비율로 도형의 가로 좌표와 너비를 곱합니다. 동일한 높이 비율을 적용하여 세로 좌표와 높이를 조정합니다.

첫 번째 예제는 슬라이드에 테이블이 없는 프레젠테이션을 로드하고, 슬라이드 크기를 A4로 변경한 뒤 결과를 저장합니다. 여기서는 [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize)를 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale)와 함께 사용하여 이후 루프에서 스케일링을 제어합니다. 비율은 단위가 없으며 도형의 위치와 차원은 포인트 단위로 측정됩니다. 가로와 세로 비율이 다르면 도형이 왜곡될 수 있으며, 도형의 크기를 변경해도 글꼴 크기는 스케일되지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # 수평 및 수직 독립 스케일 요인을 계산합니다.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
테이블은 별도로 처리해야 합니다. 테이블 전체 너비와 높이를 지정하는 대신 열 너비와 행 높이를 스케일링합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청한 크기보다 크게 유지될 수 있습니다.
{{% /alert %}}

두 번째 예제는 테이블을 지원하고 마스터와 레이아웃의 도형뿐만 아니라 개별 슬라이드의 도형도 처리한 뒤 크기가 조정된 프레젠테이션을 저장합니다. 이 도우미는 각 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)을 [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth)로 열 너비를, [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight)으로 최소 행 높이를 스케일링합니다. 그런 다음 테이블 전체 차원을 별도로 스케일링하지 않고 위치만 스케일링합니다.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # 테이블 치수는 열 너비와 행 높이로 제어됩니다.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # 수평 및 수직 독립 스케일 요인을 계산합니다.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # 마스터와 레이아웃, 개별 슬라이드에 정의된 도형을 크기 조정합니다.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**슬라이드 크기를 조정한 후 도형이 왜 왜곡되거나 잘리는가?**

슬라이드 크기를 변경하면서 도형을 스케일링하지 않으면 도형은 원래 위치와 차원을 유지하므로 슬라이드를 넘어설 수 있습니다. 가로와 세로를 서로 다른 비율로 스케일링하면 도형이 왜곡될 수 있습니다.

**제공된 코드가 모든 도형 유형에 대해 작동하는가?**

첫 번째 예제는 도형 경계를 직접 변경하며 테이블이 없는 슬라이드를 대상으로 합니다. 두 번째 예제는 테이블을 별도로 처리합니다. 이러한 예제는 글꼴 크기를 스케일하지 않으므로 텍스트와 테이블을 특히 확인해야 하며, 테이블 내용이 행 높이를 제한할 수 있습니다.

**슬라이드 크기를 조정할 때 테이블은 어떻게 크기 조정하는가?**

두 번째 예제와 같이 열 너비를 가로 비율로, 최소 행 높이를 세로 비율로 스케일링한 다음 테이블의 위치만 스케일링합니다.

**마스터 슬라이드와 레이아웃 슬라이드에도 이 크기 조정이 적용되는가?**

예. 두 번째 예제는 [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters)와 각 마스터의 [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides)를 순회하며 동일한 크기 조정 로직을 도형에 적용합니다.

**슬라이드 방향(세로/가로)을 변경하면서 크기 조정을 할 수 있는가?**

예. 슬라이드 크기를 변경한 후, 대상 치수를 읽기 전에 [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation)를 호출하면 최종 방향을 반영한 스케일 팩터가 적용됩니다.

**설정할 수 있는 슬라이드 크기에 제한이 있는가?**

[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize)를 사용하여 사용자 정의 슬라이드 치수를 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식 및 파일을 여는 애플리케이션에 따라 달라질 수 있습니다.

**고정 종횡비를 가진 도형이 왜곡되지 않게 하려면 어떻게 해야 하는가?**

가로와 세로에 동일한 스케일 팩터를 사용합니다. 원래 레이아웃을 새 슬라이드 치안에 맞추려면 가로와 세로 비율 중 작은 값을 두 차원과 위치에 적용합니다. 이렇게 하면 비율은 유지되지만 한쪽 가장자리에 사용되지 않는 공간이 남을 수 있습니다.