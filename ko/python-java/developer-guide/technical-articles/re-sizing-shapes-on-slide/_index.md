---
title: Python via Java를 사용한 프레젠테이션 슬라이드의 모양 크기 조정
type: docs
weight: 110
url: /ko/python-java/resizing-shapes-on-slide/
aliases:
  - /ko/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
- 모양 크기 조정
- 모양 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 모양을 쉽게 크기 조정하고—슬라이드 레이아웃 조정을 자동화하며 생산성을 높입니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면, 새 크기에 맞게 모양을 크기 조정하고 위치를 재조정해야 할 수도 있습니다. 이 문서에서는 모양을 수동으로 스케일링하는 방법과 슬라이드, 마스터 및 레이아웃의 표를 처리하는 방법을 보여줍니다.

## **모양 크기 조정**

각 모양의 상대적 위치와 크기를 유지하려면, 새로운 슬라이드 너비와 원래 너비의 비율로 가로 좌표와 너비를 곱합니다. 동일한 높이 비율을 사용해 세로 좌표와 높이에도 적용합니다.

첫 번째 예제는 슬라이드에 표가 없는 프레젠테이션을 로드하고, 슬라이드 크기를 A4로 변경한 뒤 결과를 저장합니다. 이후 루프가 스케일링을 제어하도록 [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize)와 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale)를 사용합니다. 비율은 단위가 없으며, 모양의 위치와 크기는 포인트 단위로 측정됩니다. 너비와 높이 비율이 다르면 모양이 왜곡될 수 있고, 모양의 크기를 변경해도 글꼴 크기는 스케일되지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # 독립적인 가로 및 세로 스케일 팩터를 계산합니다.
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
표는 별도로 처리해야 합니다: 전체 너비와 높이를 지정하는 대신 열 너비와 행 높이를 스케일링합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청한 것보다 크게 유지될 수 있습니다.
{{% /alert %}}

두 번째 예제는 표를 지원하고, 리사이즈된 프레젠테이션을 저장하기 전에 마스터와 레이아웃, 개별 슬라이드의 모양을 처리합니다. 도우미는 각 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)을 [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth)으로 열 너비를 스케일링하고, [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight)으로 최소 행 높이를 스케일링하여 처리합니다. 그런 다음 전체 차원을 별도로 스케일링하지 않고 표의 위치만 스케일링합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # 표의 치수는 열 너비와 행 높이로 제어됩니다.
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
    # 독립적인 가로 및 세로 스케일 팩터를 계산합니다.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # 마스터 및 레이아웃에 정의된 모양과 개별 슬라이드의 모양을 크기 조정합니다.
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

**슬라이드 크기 조정 후 모양이 왜 왜곡되거나 잘리나요?**

모양을 스케일링하지 않고 슬라이드 크기만 변경하면 모양은 원래 위치와 크기를 유지해 슬라이드 영역을 벗어날 수 있습니다. 너비와 높이를 다른 비율로 스케일링하면 모양이 왜곡될 수도 있습니다.

**제공된 코드가 모든 모양 유형에 대해 작동합니까?**

첫 번째 예제는 모양 경계를 직접 변경하며 표가 없는 슬라이드를 대상으로 합니다. 두 번째 예제는 표를 별도로 처리합니다. 이러한 예제는 글꼴 크기를 스케일링하지 않으며 표 내용이 행 높이를 제한할 수 있으므로 결과 레이아웃, 특히 텍스트와 표를 확인하십시오.

**슬라이드 크기를 조정할 때 표는 어떻게 리사이즈합니까?**

열 너비는 너비 비율에, 최소 행 높이는 높이 비율에 따라 스케일링하고, 그런 다음 두 번째 예제와 같이 표의 위치만 스케일링합니다.

**이 리사이징이 마스터 슬라이드와 레이아웃 슬라이드에도 적용되나요?**

예. 두 번째 예제는 [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters)와 각 마스터의 [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides)를 순회하며 그 모양에 동일한 리사이징 논리를 적용합니다.

**리사이징과 함께 슬라이드의 방향(세로/가로)을 변경할 수 있나요?**

예. 슬라이드 크기를 변경한 후, 대상 크기를 읽기 전에 [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation)를 호출하여 스케일 팩터가 최종 방향을 반영하도록 합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize)를 사용해 사용자 정의 슬라이드 크기를 지정할 수 있습니다. 지원되는 크기는 프레젠테이션 형식 및 파일을 여는 애플리케이션에 따라 달라집니다.

**고정 종횡비를 가진 모양이 왜곡되는 것을 어떻게 방지할 수 있나요?**

너비와 높이에 동일한 스케일 팩터를 사용합니다. 원본 레이아웃을 새 슬라이드 크기에 맞추려면 너비와 높이 비율 중 작은 값을 두 차원과 위치 모두에 적용합니다. 이렇게 하면 비율이 유지되지만 한쪽 가장자리에 사용되지 않은 공간이 남을 수 있습니다.