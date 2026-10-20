---
title: C++에서 프레젠테이션 슬라이드의 도형 크기 조정
type: docs
weight: 130
url: /ko/cpp/resizing-shapes-on-slide/
aliases:
  - /ko/cpp/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 도형을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 향상시킵니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새로운 치수에 맞게 도형을 크기 조정하고 위치를 재배치해야 할 수 있습니다. 이 문서에서는 도형을 수동으로 스케일링하는 방법과 슬라이드, 마스터, 레이아웃에 있는 표를 처리하는 방법을 보여줍니다.

## **도형 크기 조정**

각 도형의 상대적인 위치와 크기를 유지하려면 새 슬라이드 너비와 원래 너비의 비율을 사용해 가로 좌표와 너비를 곱합니다. 세로 좌표와 높이에는 해당 높이 비율을 적용합니다.

첫 번째 예제는 슬라이드에 표가 없고 슬라이드 크기를 A4로 변경한 후 결과를 저장하는 프레젠테이션을 로드합니다. 여기서는 [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/)을 [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/)과 함께 사용하여 이후 루프가 스케일링을 제어하도록 합니다. 비율은 단위가 없으며 도형 위치와 치수는 포인트 단위로 측정됩니다. 너비와 높이 비율이 다르면 도형이 왜곡될 수 있고, 도형의 치수를 변경해도 글꼴 크기는 스케일되지 않습니다.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
표는 별도로 처리해야 합니다. 전체 표의 너비와 높이를 지정하는 대신 열 너비와 행 높이를 스케일링합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청된 크기보다 크게 유지될 수 있습니다.
{{% /alert %}}

두 번째 예제는 표를 지원하고 마스터와 레이아웃의 도형을 개별 슬라이드와 함께 처리한 뒤 크기 조정된 프레젠테이션을 저장합니다. 도우미는 각 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)을 처리하여 [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/)와 [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/)을 스케일링합니다. 그런 다음 표 전체 치수를 별도로 스케일링하지 않고 표의 위치만 스케일링합니다.
```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRRow.h>
#include <DOM/Table/IRRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 수평 및 수직 스케일링 팩터를 독립적으로 계산합니다.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // 표 크기는 열 너비와 행 높이에 의해 제어됩니다.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// 마스터와 레이아웃 및 개별 슬라이드에 정의된 도형을 크기 조정합니다.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **자주 묻는 질문**

**슬라이드 크기를 조정한 후 도형이 왜 왜곡되거나 잘리는가요?**  
슬라이드 크기를 변경하면서 도형을 스케일링하지 않으면 도형은 원래 위치와 치수를 유지하고 슬라이드를 넘어설 수 있습니다. 너비와 높이를 다른 비율로 스케일링하면 도형이 왜곡될 수도 있습니다.

**제공된 코드가 모든 도형 유형에 대해 작동하나요?**  
첫 번째 예제는 도형 경계를 직접 변경하며 표가 없는 슬라이드에 적용하도록 설계되었습니다. 두 번째 예제는 표를 별도로 처리합니다. 이 예제들은 글꼴 크기를 스케일링하지 않으며 표 내용이 행 높이를 제한할 수 있으므로 결과 레이아웃, 특히 텍스트와 표를 확인하세요.

**슬라이드 크기를 조정할 때 표는 어떻게 크기 조정하나요?**  
열 너비는 너비 비율로, 최소 행 높이는 높이 비율로 스케일링한 다음, 두 번째 예제와 같이 표의 위치를 스케일링합니다.

**마스터 슬라이드와 레이아웃 슬라이드에도 이 크기 조정이 적용되나요?**  
예. 두 번째 예제는 [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)와 각 마스터의 [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/)를 반복하면서 해당 도형에 동일한 크기 조정 논리를 적용합니다.

**슬라이드 방향(세로/가로)을 크기 조정과 함께 변경할 수 있나요?**  
예. 슬라이드 크기를 변경한 후 목표 치수를 읽기 전에 [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/)을 설정하면 스케일 팩터가 최종 방향을 반영합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**  
[SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/)을 사용하여 사용자 지정 슬라이드 치수를 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식과 파일을 여는 애플리케이션에 따라 다릅니다.

**고정 종횡비를 가진 도형이 왜곡되지 않게 하려면 어떻게 해야 하나요?**  
너비와 높이에 동일한 스케일 팩터를 사용합니다. 원래 레이아웃을 새 슬라이드 치수에 맞추려면 너비와 높이 비율 중 더 작은 값을 두 차원과 위치에 모두 적용합니다. 이렇게 하면 비율은 유지되지만 한쪽 가장자리에 빈 공간이 남을 수 있습니다.