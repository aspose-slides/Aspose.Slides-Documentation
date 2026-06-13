---
title: Python으로 프레젠테이션의 도형 크기 조정
linktitle: 도형 크기 조정
type: docs
weight: 130
url: /ko/python-net/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 도형을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높입니다."
---
## **개요**

Aspose.Slides for Python 고객이 가장 자주 묻는 질문 중 하나는 슬라이드 크기가 변경될 때 데이터가 잘리지 않도록 도형의 크기를 조정하는 방법입니다. 이 짧은 기술 문서는 그 방법을 보여줍니다.

## **도형 크기 조정**

슬라이드 크기가 변경될 때 도형이 어긋나는 것을 방지하려면 각 도형의 위치와 크기를 새 슬라이드 레이아웃에 맞게 업데이트해야 합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 로드합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 원본 슬라이드 크기를 가져옵니다.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 새 슬라이드 크기를 가져옵니다.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # 모든 슬라이드의 도형을 크기 조정하고 위치를 재조정합니다.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # 도형 크기를 스케일링합니다.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 도형 위치를 스케일링합니다.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
슬라이드에 표가 포함되어 있는 경우 위 코드가 올바르게 작동하지 않습니다. 이 경우 표의 각 셀을 개별적으로 크기 조정해야 합니다.
{{% /alert %}} 

표가 포함된 슬라이드를 크기 조정하려면 아래 코드를 사용하십시오. 표의 너비 또는 높이를 설정하는 것은 특수한 경우이며, 표 전체 크기를 변경하려면 개별 행 높이와 열 너비를 조정해야 합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 원본 슬라이드 크기를 가져옵니다.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 새 슬라이드 크기를 가져옵니다.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # 도형 크기를 스케일링합니다.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 도형 위치를 스케일링합니다.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # 도형 크기를 스케일링합니다.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # 도형 위치를 스케일링합니다.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # 도형 크기를 스케일링합니다.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 도형 위치를 스케일링합니다.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**슬라이드 크기를 조정한 후 도형이 왜 왜곡되거나 잘리나요?**

슬라이드 크기를 조정할 때 도형은 별도로 비율을 변경하지 않으면 원래 위치와 크기를 유지합니다. 이로 인해 내용이 잘리거나 도형이 어긋날 수 있습니다.

**제공된 코드가 모든 도형 유형에서 작동하나요?**

기본 예제는 대부분의 도형 유형(텍스트 상자, 이미지, 차트 등)에서 작동합니다. 그러나 표의 경우 개별 셀의 차원에 의해 전체 높이와 너비가 결정되므로 행과 열을 별도로 처리해야 합니다.

**슬라이드 크기를 조정할 때 표는 어떻게 크기 조정하나요?**

표의 모든 행과 열을 순회하면서 높이와 너비를 비례적으로 조정하면 됩니다. 두 번째 코드 예제에서 이를 확인할 수 있습니다.

**이 크기 조정이 마스터 슬라이드와 레이아웃 슬라이드에도 적용되나요?**

예, 적용됩니다. 프레젠테이션 전반에 일관성을 유지하려면 [Masters](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/masters/)와 [Layout slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/layout_slides/)을 순회하면서 동일한 스케일링 로직을 도형에 적용해야 합니다.

**슬라이드 방향(세로/가로)을 함께 변경하면서 크기 조정할 수 있나요?**

예. [presentation.slide_size.orientation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/islidesize/orientation/)을 사용하여 방향을 변경할 수 있습니다. 레이아웃을 유지하려면 스케일링 로직을 그에 맞게 설정하십시오.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

Aspose.Slides는 사용자 지정 크기를 지원하지만, 매우 큰 크기는 성능에 영향을 주거나 일부 PowerPoint 버전과 호환성 문제가 발생할 수 있습니다.

**고정 종횡비 도형이 왜곡되는 것을 어떻게 방지하나요?**

스케일링 전에 도형의 `aspect_ratio_locked` 속성을 확인하십시오. 종횡비가 잠겨 있는 경우 개별적으로 스케일링하지 말고 너비와 높이를 비례적으로 조정하십시오.