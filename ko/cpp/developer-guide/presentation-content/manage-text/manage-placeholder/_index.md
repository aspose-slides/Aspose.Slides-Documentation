---
title: C++에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/cpp/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 콘텐츠 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속을 이해하는 방법을 배웁니다."
---
## **개요**

플레이스홀더는 프레젠테이션 템플릿에서 특정 종류의 콘텐츠 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 범용 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 [IShape::get_Placeholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_placeholder/) 메서드를 통해 플레이스홀더 정보를 노출합니다. 이 메서드는 일반 도형에 대해 `nullptr`를 반환하거나 [IPlaceholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iplaceholder/) 객체를 반환합니다. 플레이스홀더가 어떤 콘텐츠를 포함하도록 설계되었는지 확인하려면 [IPlaceholder::get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iplaceholder/get_type/)을 사용하십시오.

플레이스홀더 유형을 알게 된 후에도 도형 인터페이스는 여전히 중요합니다:
- 빈 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)으로 표시됩니다.
- 내용이 채워진 그림 플레이스홀더는 [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)으로 표시될 수 있습니다.
- 내용이 채워진 차트 플레이스홀더는 [IChart](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/)으로 표시될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)이라고 가정하지 말고 [IPlaceholder::get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iplaceholder/get_type/)과 런타임 도형 인터페이스를 모두 확인하십시오.

{{% alert color="warning" title="경고" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iplaceholder/get_type/)은 플레이스홀더의 역할을 설명하지만 도형의 런타임 유형을 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어 관련 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 형성합니다:
1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고 경우에 따라 마스터 수준의 플레이스홀더를 정의합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드에서 사용되는 배치를 정의하며 마스터로부터 상속될 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속될 수 있습니다.

[IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getbaseplaceholder/)을 호출하면 이 계층 구조에서 한 단계 위로 이동합니다. 슬라이드 플레이스홀더는 일반적으로 자신의 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 도형에 기본 플레이스홀더가 없을 경우 메서드는 `nullptr`를 반환합니다.

다음 예제는 첫 번째 슬라이드의 플레이스홀더를 나열하고 해당 기본 플레이스홀더를 보고합니다:
```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃 또는 마스터를 편집하면 해당 설정을 아직 상속하고 있는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며 동일한 좌표에 위치한다고 해서 상속을 시작하지 않습니다.

## **플레이스홀더의 텍스트 변경**

제목, 중앙 제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. 해당 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)인지 확인한 후에 [get_TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/get_textframe/) 메서드를 사용하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:
```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)으로 캐스팅하는 것을 방지합니다. 또한 불안정한 도형 인덱스에 의존하는 대신 목적에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 빈 플레이스홀더에 표시되는 디자인 타임 지시문이며 예를 들어 *제목을 추가하려면 클릭*과 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려 하지 말고 레이아웃 플레이스홀더에 사용자 지정 프롬프트 텍스트를 설정하십시오. 레이아웃은 [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/get_layoutslide/)을 통해 접근하고 [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/get_shapes/)를 순회하십시오.

다음 예제는 첫 번째 슬라이드에 사용되는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:
```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션의 빈 플레이스홀더용으로 설계되었습니다. 사용자가 실제 콘텐츠를 제공하면 프롬프트는 더 이상 표시되지 않습니다. 프롬프트를 변경해도 레이아웃을 사용하는 슬라이드의 기존 텍스트가 교체되지 않습니다.

## **그림 플레이스홀더 업데이트**

처리해야 할 두 가지 경우가 있습니다:
- 그림 플레이스홀더가 이미 채워져 있고 [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)으로 표현된 경우, [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/get_picture/) 및 [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidespicture/set_image/)을 통해 이미지를 교체합니다.
- 아직 빈 플레이스홀더인 경우, [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addpictureframe/)을 사용하여 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 제거합니다.

다음 예제는 두 경우를 모두 지원하고 프레젠테이션을 저장합니다:
```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

빈 플레이스홀더에 대해 생성된 교체는 새 플레이스홀더가 아니라 로컬 그림 프레임이며, 이는 [IShape::get_Placeholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_placeholder/)이 읽기 전용이기 때문입니다. 예약된 위치는 유지되지만 더 이상 플레이스홀더 전용 동작을 상속하지 않습니다. 플레이스홀더 관계를 유지해야 하는 경우 먼저 PowerPoint에서 플레이스홀더를 준비하고 채운 다음 Aspose.Slides를 사용해 결과 [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)을 업데이트하십시오.

이미지 투명도, 자르기 및 기타 그림 전용 효과에 대해서는 [그림 프레임 관리](/slides/ko/cpp/picture-frame/)를 참조하십시오. 이러한 작업은 플레이스홀더 메타데이터가 아니라 그림 프레임 또는 그림 채우기에 해당합니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [IChart](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/)으로 표시될 수 있습니다. 이 예제는 플레이스홀더 유형과 런타임 인터페이스를 모두 사용해 해당 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:
```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

일반 콘텐츠 플레이스홀더는 일반적으로 [PlaceholderType::Object](https://reference.aspose.com/slides/ko/cpp/aspose.slides/placeholdertype/)를 가집니다. PowerPoint에서 이는 차트, 표, 다이어그램, 그림 및 미디어 등 여러 콘텐츠 유형을 시작하는 런처 역할을 합니다. 내용이 채워진 후에는 실제 도형 인터페이스를 검사하여 포함된 내용을 확인하십시오. 특수 레이아웃은 [PlaceholderType::Chart](https://reference.aspose.com/slides/ko/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/ko/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/ko/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/ko/cpp/aspose.slides/placeholdertype/), 또는 [PlaceholderType::Diagram](https://reference.aspose.com/slides/ko/cpp/aspose.slides/placeholdertype/)을 노출할 수도 있습니다.

Aspose.Slides는 빈 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 플레이스홀더를 [IPlaceholder::get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iplaceholder/get_type/)을 변경함으로써 [IChart](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/)로 변환하지 않습니다; 유형은 읽기 전용입니다. 빈 차트 또는 콘텐츠 영역을 프로그래밍 방식으로 채우려면 필요한 객체를 플레이스홀더 좌표에 추가한 뒤 빈 플레이스홀더를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:
```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

추가된 차트는 일반 로컬 차트입니다. 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 차트의 범주, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [차트 관리 문서](/slides/ko/cpp/powerpoint-charts/)를 사용하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 전체 예제는 템플릿을 열고 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트하여 결과를 저장합니다. 이 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일한 인터페이스로 캐스팅하는 것을 의도적으로 피합니다.
```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**기본 플레이스홀더란 무엇입니까?**

기본 플레이스홀더는 다른 플레이스홀더가 상속받는 레이아웃 또는 마스터상의 해당 도형을 말합니다. 이를 가져오려면 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getbaseplaceholder/)를 사용하십시오. 일반 로컬 도형은 플레이스홀더 계층 구조에 속하지 않으므로 `nullptr`를 반환합니다.

**레이아웃 플레이스홀더를 편집하여 모든 슬라이드 제목을 변경할 수 있습니까?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 기존 제목 콘텐츠는 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 실제 제목 텍스트를 교체하려면 슬라이드를 순회하면서 각 제목 플레이스홀더를 업데이트하십시오.

**날짜, 슬라이드 번호, 머리글 및 바닥글 플레이스홀더를 어떻게 관리합니까?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 배포 범위에서 헤더 및 바닥글 관리자를 사용하십시오. 전체 예제는 [프레젠테이션 헤더 및 바닥글 관리](/slides/ko/cpp/presentation-header-and-footer/)를 참조하십시오.