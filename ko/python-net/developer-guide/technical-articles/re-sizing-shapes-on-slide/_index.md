---
title: 파이썬에서 프레젠테이션 슬라이드의 모양 크기 조정
type: docs
weight: 130
url: /ko/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/크기-조정-모양-슬라이드/
  - /ko/python-net/re-sizing-shapes-on-slide/
keywords:
- 모양 크기 조정
- 모양 크기 변경
- 파워포인트
- 오픈문서
- 프레젠테이션
- 파이썬
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 모양을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높입니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새로운 차원에 맞게 모양의 크기를 조정하고 위치를 재배치해야 할 수도 있습니다. 이 문서에서는 모양을 수동으로 스케일링하는 방법과 슬라이드, 마스터, 레이아웃의 테이블을 처리하는 방법을 보여줍니다.

## **모양 크기 조정**

각 모양의 상대적 위치와 크기를 유지하려면 새 슬라이드 너비와 원래 너비의 비율로 수평 좌표와 너비를 곱합니다. 해당 높이 비율을 수직 좌표와 높이에 적용합니다.

첫 번째 예제는 슬라이드에 테이블이 없는 프레젠테이션을 로드하고 슬라이드 크기를 A4로 변경한 후 결과를 저장합니다. 여기서는 [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)와 [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/)를 사용하여 이후 루프가 스케일링을 제어하도록 합니다. 비율은 단위가 없으며 모양의 위치와 차원은 포인트 단위로 측정됩니다. 너비와 높이 비율이 다르면 모양이 왜곡될 수 있으며, 모양의 차원을 변경해도 글꼴 크기는 스케일되지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 독립적인 가로 및 세로 스케일 계수를 계산합니다.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
테이블은 별도로 처리해야 합니다: 테이블 전체 너비와 높이를 지정하는 대신 열 너비와 행 높이를 스케일링합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청된 것보다 크게 유지될 수 있습니다.
{{% /alert %}}

두 번째 예제는 테이블을 지원하고 마스터와 레이아웃 및 개별 슬라이드의 모양을 처리한 후 크기 조정된 프레젠테이션을 저장합니다. 이 도우미는 각 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)을 [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/)와 [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/)을 스케일링하여 처리합니다. 그런 다음 테이블 전체 차원을 별도로 스케일링하지 않고 테이블의 위치만 스케일링합니다.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # 테이블 차원은 열 너비 및 행 높이에 의해 제어됩니다.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # 독립적인 가로 및 세로 스케일 계수를 계산합니다.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # 마스터와 레이아웃, 그리고 개별 슬라이드에 정의된 모양을 크기 조정합니다.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **자주 묻는 질문**

**왜 슬라이드 크기를 조정한 후 모양이 왜곡되거나 잘리나요?**  
슬라이드 크기를 변경하면서 모양을 스케일하지 않으면 모양은 원래 위치와 차원을 유지하므로 슬라이드 밖으로 벗어날 수 있습니다. 너비와 높이를 서로 다른 비율로 스케일하면 모양이 왜곡될 수도 있습니다.

**제공된 코드가 모든 모양 유형에서 작동하나요?**  
첫 번째 예제는 모양 경계를 직접 변경하며 테이블이 없는 슬라이드를 대상으로 합니다. 두 번째 예제는 테이블을 별도로 처리합니다. 이 예제들은 글꼴 크기를 스케일하지 않고 테이블 내용이 행 높이를 제한할 수 있기 때문에 특히 텍스트와 테이블의 결과 레이아웃을 확인하십시오.

**슬라이드 크기를 조정할 때 테이블 크기는 어떻게 조정하나요?**  
열 너비를 너비 비율로, 최소 행 높이를 높이 비율로 스케일링한 다음, 두 번째 예제와 같이 테이블의 위치를 스케일링합니다.

**마스터 슬라이드와 레이아웃 슬라이드에서도 이 크기 조정이 작동하나요?**  
예. 두 번째 예제는 [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/)와 각 마스터의 [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/)를 순회하면서 해당 모양에 동일한 크기 조정 논리를 적용합니다.

**슬라이드 크기 조정과 함께 슬라이드 방향(세로/가로)을 변경할 수 있나요?**  
예. 슬라이드 크기를 변경한 후 및 대상 치수를 읽기 전에 [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/)을 설정하면 스케일 계수가 최종 방향을 반영합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**  
다음의 [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)을 사용하여 사용자 지정 슬라이드 치수를 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식 및 파일을 여는 애플리케이션에 따라 달라집니다.

**고정된 종횡비를 가진 모양이 왜곡되는 것을 어떻게 방지할 수 있나요?**  
너비와 높이에 동일한 스케일 팩터를 사용하십시오. 원래 레이아웃을 새 슬라이드 치수에 맞추려면 너비와 높이 비율 중 더 작은 값을 두 차원과 위치에 모두 적용합니다. 이렇게 하면 비율이 유지되지만 한쪽 가장자리에 사용되지 않은 공간이 남을 수 있습니다.