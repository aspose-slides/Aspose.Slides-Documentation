---
title: 管理 C++ 中的簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/cpp/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for C++ 檢查與編輯文字、圖片、圖表與內容佔位符，並了解佔位符的繼承機制。"
---
## **概觀**

佔位符是一種形狀，用於在投影片範本中保留特定類型內容的位置。常見的例子包括標題、內文、圖片、圖表以及一般用途的內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片繼承其位置、大小、格式和其他設定。

Aspose.Slides 透過 [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) 方法公開佔位符資訊。該方法會傳回 [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) 物件，對於普通形狀則傳回 `nullptr`。使用 [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) 來判斷佔位符預期包含的內容。

在了解佔位符類型後，形狀介面仍然很重要：

- 空的文字、圖片、圖表或內容佔位符通常由 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 表示。
- 已填入內容的圖片佔位符可以由 [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) 表示。
- 已填入內容的圖表佔位符可以由 [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) 表示。
- 內容佔位符可以包含多種內容。請同時檢查 [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) 與執行時的形狀介面，而不要假設每個佔位符都是 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。

{{% alert color="warning" title="警告" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) 描述佔位符的角色；它並不保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體相關成員之前，請先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片投影片定義可重複使用的樣式，且在某些情況下定義母片層級的佔位符。
2. 版面投影片定義一或多個普通投影片的版面配置，且可從母片繼承。
3. 普通投影片包含該投影片的佔位符，且可從其版面繼承。

呼叫 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) 可在此層級向上移動一層。投影片佔位符通常會傳回其版面佔位符；版面佔位符則可傳回其母片佔位符。若形狀沒有基礎佔位符，該方法會傳回 `nullptr`。

以下範例列出第一張投影片的佔位符，並回報其基礎佔位符：

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

編輯普通投影片上的佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響所有仍繼承該設定的投影片。本機普通形狀沒有基礎佔位符，僅因其佔用相同座標而不會開始繼承。

## **移除佔位符狀態**

在調整範本時，使用 [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) 可將現有物件保留為普通形狀。其 [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) 方法會傳回 `nullptr`，但形狀仍保留在投影片的集合中。相較之下， [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) 會從該集合中刪除形狀。

以下範例需要 `template.pptx`，且至少包含一張投影片及第一張投影片上有非空的文字佔位符。使用從版面或母片繼承格式的佔位符，以觀察移除該關係的效果。範例會檢查相同的形狀仍在，然後在現在的普通形狀上再次呼叫此方法，並儲存結果。

{{% alert color="warning" title="警告" %}}
移除佔位符狀態不會自動保留繼承的外觀設定。以下範例刻意不變更這些設定，因此輸出可能看起來不同。若形狀的定位與大小全部繼承，在呼叫後可能會變為零座標與尺寸，雖仍存在於集合中卻變得不可見。
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // 在普通形狀上呼叫此方法不會產生任何效果。
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

對於匹配的佔位符，三個檢查皆會印出 `True`。文字會保留，但當移除佔位符關係時，繼承的定位、大小、旋轉、字型、段落對齊、文字框邊距、垂直錨點、填滿與線條設定可能會改變。例如，繼承的標題格式可能退回為普通文字格式。請參閱 [Slide Layout](/slides/zh-hant/cpp/slide-layout/) 以取得更多版面資訊。

為了保留預期的外觀，請在呼叫前捕獲已解析的位置、大小與旋轉，並將所需的有效格式值複製到單獨的變數。可透過 [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/)、[IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/)、[ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/)、[IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/)、以及 [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) 取得這些值。不要僅依賴保留有效格式物件，因為在關係移除後，其文字格式值可能會改變。之後請明確將捕獲的值套用到普通形狀，包括字型族、大小、樣式、顏色、段落設定、文字框設定、填滿與線條等屬於範本的設定。

繼承的形狀幾何也可能需要透過 [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/) 明確指派。對於矩形文字佔位符，這表示要指派 [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)；僅還原填滿與線條可能無法恢復可見的矩形。具有額外效果或較複雜格式的範本亦需同樣處理這些設定。

## **變更佔位符文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。在使用其 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) 方法前，請先檢查是否為 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。

此範例會更新第一張投影片的第一個標題佔位符，並儲存結果：

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

此模式避免將圖片、圖表、表格或媒體佔位符轉型為 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。它亦透過用途辨識佔位符，而非依賴脆弱的形狀索引。

## **在版面上設定提示文字**

提示文字是顯示在空佔位符中的設計時指示，例如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是嘗試透過普通投影片的形狀集合取得。可透過 [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) 取得版面，並遍歷 [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/)。

以下範例會變更第一張投影片使用之版面的標題與副標題提示文字：

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

提示文字並非普通投影片內容。它僅供 PowerPoint 等編輯應用中的空佔位符使用。當使用者或程式提供實際內容後，提示文字即不再顯示。變更提示文字亦不會取代使用該版面的投影片上已有的文字。

## **更新圖片佔位符**

有兩種情況需要處理：

- 如果圖片佔位符已填入內容且由 [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) 表示，請透過 [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) 與 [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) 取代影像。
- 如果仍是空佔位符，請使用 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) 在佔位符座標處新增圖片框，並移除空的佔位符。

以下範例同時支援這兩種情況，並儲存簡報：

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

對於空佔位符所建立的取代品會是一個本機圖片框，而非新的佔位符，因為 [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) 為唯讀。它保留保留的位置，但不再繼承佔位符專屬的行為。如果必須保留佔位符關係，請先在 PowerPoint 中準備並填入佔位符，然後再使用 Aspose.Slides 更新產生的 [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/)。

若需處理圖像透明度、裁剪及其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/cpp/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符中繼資料。

## **使用圖表與內容佔位符**

已填入內容的圖表佔位符可以由 [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) 表示。此範例同時以佔位符類型與執行時介面查找此類圖表，變更其標題，並儲存檔案：

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

一般內容佔位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填入內容後，請檢查實際的形狀介面以了解其包含什麼。特化的版面也可能曝露 [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) 或 [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)。

Aspose.Slides 不會僅透過變更 [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) 就將空的 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 佔位符轉換為 [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/)；此類型為唯讀。若要以程式方式填入空的圖表或內容區域，請在佔位符座標處新增所需的物件，然後移除空的佔位符。以下範例針對圖表執行此操作：

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

新增的圖表是一個普通的本機圖表。它佔用佔位符的區域，但不會從版面佔位符繼承。當需要取代其類別、系列或工作簿資料時，請使用專門的 [chart management articles](/slides/zh-hant/cpp/powerpoint-charts/) 。

## **完整範例：更新文字或圖像內容**

以下端到端範例會開啟範本，於第一張投影片搜尋標題或圖片佔位符，檢查佔位符與形狀類型，更新相應的內容，並儲存輸出。此範例刻意避免假設形狀索引或將每個佔位符轉型為相同介面。

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

## **常見問題**

**什麼是基礎佔位符？**

基礎佔位符是版面或母片上對應的形狀，其他佔位符會從其繼承。使用 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) 取得它。普通的本機形狀會傳回 `nullptr`，因為它不屬於佔位符層級結構。

**我可以透過編輯版面佔位符來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在普通投影片上。若要在整份簡報中取代實際的標題文字，請遍歷投影片並更新每個標題佔位符。

**如何管理日期、投影片編號、頁首與頁尾佔位符？**

在適當的投影片、版面、母片、備註或講義範圍使用頁首與頁尾管理工具。請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/cpp/presentation-header-and-footer/) 以獲得完整範例。