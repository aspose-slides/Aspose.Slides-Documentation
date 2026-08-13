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
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 도형을 손쉽게 크기 조정—슬라이드 레이아웃 조정을 자동화하고 생산성을 높입니다."
---
## **개요**

Aspose.Slides for C++ 고객이 가장 흔히 묻는 질문 중 하나는 슬라이드 크기가 변경될 때 데이터가 잘리지 않도록 도형의 크기를 조정하는 방법이다. 이 짧은 기술 문서에서는 그 방법을 보여준다.

## **도형 크기 조정**

슬라이드 크기가 변경될 때 도형이 정렬이 흐트러지는 것을 방지하려면, 각 도형의 위치와 크기를 새로운 슬라이드 레이아웃에 맞게 업데이트해야 합니다.

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

// 모든 슬라이드의 도형 크기를 조정하고 위치를 재설정합니다.
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

{{% alert color="info" %}} 
슬라이드에 표가 포함된 경우 위 코드가 올바르게 작동하지 않습니다. 이 경우 표의 각 셀을 별도로 크기 조정해야 합니다.
{{% /alert %}} 

표가 포함된 슬라이드를 크기 조정하려면 아래 코드를 사용하십시오. 표의 너비나 높이를 설정하는 것은 특수한 경우이며, 표 전체 크기를 변경하려면 개별 행 높이와 열 너비를 조정해야 합니다.

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
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **FAQ**

### 슬라이드를 크기 조정한 후 도형이 왜 왜곡되거나 잘리나요?

슬라이드를 크기 조정하면 별도로 스케일을 변경하지 않는 한 도형은 원래 위치와 크기를 유지합니다. 이로 인해 내용이 잘리거나 도형이 정렬이 흐트러질 수 있습니다.

### 제공된 코드가 모든 도형 유형에 적용되나요?

기본 예제는 대부분의 도형 유형(텍스트 상자, 이미지, 차트 등)에 적용됩니다. 하지만 표의 경우 개별 셀의 크기로 전체 높이와 너비가 결정되므로 행과 열을 별도로 처리해야 합니다.

### 슬라이드를 크기 조정할 때 표는 어떻게 크기 조정하나요?

두 번째 코드 예제와 같이 표의 모든 행과 열을 반복하면서 높이와 너비를 비례적으로 조정해야 합니다.

### 이 크기 조정이 마스터 슬라이드와 레이아웃 슬라이드에도 적용되나요?

예, 하지만 [마스터] (https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_masters/)와 [레이아웃 슬라이드] (https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_layoutslides/)를 반복하면서 동일한 스케일링 로직을 적용하여 프레젠테이션 전체의 일관성을 유지해야 합니다.

### 슬라이드 방향(세로/가로)를 변경하면서 크기 조정을 할 수 있나요?

예. [presentation->get_SlideSize()->set_Orientation] (https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidesize/set_orientation/) 메서드를 사용하여 방향을 변경할 수 있습니다. 레이아웃을 유지하려면 스케일링 로직을 그에 맞게 설정하십시오.

### 설정할 수 있는 슬라이드 크기에 제한이 있나요?

Aspose.Slides는 사용자 지정 크기를 지원하지만, 매우 큰 크기는 성능이나 일부 PowerPoint 버전과의 호환성에 영향을 줄 수 있습니다.

### 고정 비율이 잠긴 도형이 왜곡되는 것을 어떻게 방지하나요?

스케일링 전에 도형의 `get_AspectRatioLocked` 메서드를 확인하십시오. 비율이 잠겨 있으면 개별적으로 스케일링하지 말고 너비와 높이를 비례적으로 조정하십시오.