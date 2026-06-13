---
title: 프레젠테이션 슬라이드에서 도형 크기 조정
type: docs
weight: 100
url: /ko/cpp/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 도형을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높입니다."
---
## **개요**

Aspose.Slides for C++ 고객이 가장 많이 묻는 질문 중 하나는 슬라이드 크기가 변경될 때 데이터가 잘리지 않도록 도형의 크기를 조정하는 방법입니다. 이 짧은 기술 문서에서는 그 방법을 보여줍니다.

## **도형 크기 조정**

슬라이드 크기가 변경될 때 도형이 정렬이 어긋나지 않도록, 각 도형의 위치와 크기를 새로운 슬라이드 레이아웃에 맞게 업데이트합니다.

```cpp
// 프레젠테이션 파일을 로드합니다.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// 원본 슬라이드 크기를 가져옵니다.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// 새 슬라이드 크기를 가져옵니다.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// 모든 슬라이드에서 도형의 크기를 조정하고 위치를 재설정합니다.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 도형 크기를 스케일링합니다.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 도형 위치를 스케일링합니다.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
슬라이드에 표가 포함된 경우, 위 코드는 올바르게 작동하지 않습니다. 이 경우 표의 각 셀을 크기 조정해야 합니다.
{{% /alert %}} 

표가 포함된 슬라이드를 크기 조정하려면 아래 코드를 사용하십시오. 표의 경우 너비나 높이를 설정하는 것이 특수한 경우이며, 전체 표 크기를 변경하려면 개별 행 높이와 열 너비를 조정해야 합니다.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 원본 슬라이드 크기를 가져옵니다.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// 새 슬라이드 크기를 가져옵니다.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // 도형 크기를 스케일링합니다.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 도형 위치를 스케일링합니다.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // 도형 크기를 스케일링합니다.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // 도형 위치를 스케일링합니다.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 도형 크기를 스케일링합니다.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 도형 위치를 스케일링합니다.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **자주 묻는 질문**

**왜 슬라이드를 크기 조정한 후 도형이 왜곡되거나 잘리나요?**

슬라이드 크기를 조정할 때, 스케일을 명시적으로 변경하지 않으면 도형은 원래 위치와 크기를 유지합니다. 이로 인해 콘텐츠가 잘리거나 도형이 정렬이 어긋날 수 있습니다.

**제공된 코드가 모든 도형 유형에 적용되나요?**

기본 예제는 대부분의 도형 유형(텍스트 상자, 이미지, 차트 등)에 적용됩니다. 그러나 표의 경우 개별 셀의 크기에 따라 표의 높이와 너비가 결정되므로 행과 열을 별도로 처리해야 합니다.

**슬라이드 크기를 조정할 때 표를 어떻게 크기 조정하나요?**

두 번째 코드 예제에 표시된 대로 표의 모든 행과 열을 순회하면서 높이와 너비를 비례적으로 조정해야 합니다.

**마스터 슬라이드와 레이아웃 슬라이드에도 이 크기 조정이 적용되나요?**

예, 하지만 프레젠테이션 전반의 일관성을 위해 [Masters](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_masters/)와 [Layout slides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_layoutslides/)를 순회하고 도형에 동일한 스케일링 논리를 적용해야 합니다.

**슬라이드의 방향(세로/가로)을 크기 조정과 함께 변경할 수 있나요?**

예. [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidesize/set_orientation/)을 사용하여 방향을 변경할 수 있습니다. 레이아웃을 유지하려면 스케일링 논리를 적절히 설정하십시오.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

Aspose.Slides는 사용자 정의 크기를 지원하지만, 매우 큰 크기는 성능에 영향을 주거나 일부 PowerPoint 버전과의 호환성 문제를 일으킬 수 있습니다.

**고정 종횡비 도형이 왜곡되는 것을 어떻게 방지할 수 있나요?**

스케일링 이전에 도형의 `get_AspectRatioLocked` 메서드를 확인할 수 있습니다. 종횡비가 잠겨 있는 경우 개별적으로 스케일링하지 말고 너비 또는 높이를 비례적으로 조정하십시오.