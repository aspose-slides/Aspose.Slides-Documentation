---
title: 管理 C++ 簡報佔位符
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
description: "了解如何使用 Aspose.Slides for C++ 檢查與編輯文字、圖片、圖表及內容佔位符，並理解佔位符的繼承機制。"
---
## **概覽**

佔位符是一種保留在簡報範本中特定內容位置的形狀。常見的例子包括標題、內文、圖片、圖表以及通用內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [IShape::get_Placeholder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_placeholder/) 方法公開佔位符資訊。此方法會回傳 [IPlaceholder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iplaceholder/) 物件，或在一般形狀時回傳 `nullptr`。使用 [IPlaceholder::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iplaceholder/get_type/) 來判斷佔位符預期包含的內容。

在得知佔位符類型後，仍須關注形狀介面：

- 空的文字、圖片、圖表或內容佔位符通常以 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 表示。
- 已填入圖片的佔位符可以由 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 表示。
- 已填入圖表的佔位符可以由 [IChart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/) 表示。
- 內容佔位符可以包含多種內容。請同時檢查 [IPlaceholder::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iplaceholder/get_type/) 以及執行時形狀介面，而不要假設每個佔位符都是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iplaceholder/get_type/) 描述了佔位符的角色；它並不保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體特定成員前，務必先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片定義可重複使用的樣式，且在某些情況下定義母片層級的佔位符。
2. 版面投影片定義一個或多個一般投影片使用的版面配置，且可從母片繼承。
3. 一般投影片包含該投影片的佔位符，且可從其版面繼承。

呼叫 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/getbaseplaceholder/) 可以向上移動一層層級。投影片佔位符通常會回傳其版面佔位符；版面佔位符可以回傳其母片佔位符。當形狀沒有基礎佔位符時，該方法會回傳 `nullptr`。

以下範例列出第一張投影片上的佔位符，並回報其基礎佔位符：

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

在一般投影片上編輯佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響仍繼承該設定的所有投影片。本機普通形狀沒有基礎佔位符，僅因佔據相同座標並不會開始繼承。

## **變更佔位符中的文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。使用前請先確認是否為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)，再呼叫其 [get_TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/get_textframe/) 方法。

以下範例更新第一張投影片上的第一個標題佔位符，並儲存結果：

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

此模式避免將圖片、圖表、表格或媒體佔位符轉型為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。它也透過目的而非脆弱的形狀索引來辨識佔位符。

## **設定版面佔位符的提示文字**

提示文字是設計時在空佔位符中顯示的指示，如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是試圖透過一般投影片的形狀集合取得。可透過 [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/get_layoutslide/) 取得版面，並遍歷 [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslide/get_shapes/)。

以下範例變更第一張投影片所使用版面的標題與副標題提示文字：

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

提示文字並非一般投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位符中顯示。當使用者或程式提供實際內容後，提示文字即不再顯示。變更提示文字也不會取代使用該版面的投影片上已存在的文字。

## **更新圖片佔位符**

有兩種情況需要處理：

- 若圖片佔位符已被填入且以 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 表示，請透過 [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/get_picture/) 與 [ISlidesPicture::set_Image](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/set_image/) 置換影像。
- 若仍為空佔位符，請使用 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addpictureframe/) 在佔位符座標加入圖片框，並移除空佔位符。

以下範例同時支援上述兩種情況，並儲存簡報：

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

為空佔位符建立的取代物是一個本機圖片框，而非新佔位符，因為 [IShape::get_Placeholder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_placeholder/) 為唯讀。它保留了預留位置，但不再繼承佔位符特有的行為。如果必須保留佔位符關係，請先在 PowerPoint 中準備並填入佔位符，然後再使用 Aspose.Slides 更新產生的 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/)。

欲了解影像透明度、裁切及其他圖片專屬效果，請參考 [Manage Picture Frames](/slides/zh-hant/cpp/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符中繼資料。

## **使用圖表與內容佔位符**

已填入的圖表佔位符可以由 [IChart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/) 表示。以下範例透過佔位符類型與執行時介面同時找到此圖表，變更其標題，並儲存檔案：

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

一般內容佔位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型（圖表、表格、圖示、圖片、媒體等）的啟動器。填入後，請檢查實際形狀介面以了解其包含何種內容。特殊版面亦可能公開 [PlaceholderType::Chart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/placeholdertype/)、或 [PlaceholderType::Diagram](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/placeholdertype/)。

Aspose.Slides 並不會僅透過變更 [IPlaceholder::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iplaceholder/get_type/) 來將空的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 佔位符轉換成 [IChart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/)，因為類型為唯讀。若要以程式方式填充空圖表或內容區域，請在佔位符座標加入所需物件，然後移除空佔位符。以下範例示範如何為圖表執行此操作：

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

新增的圖表是一個普通本機圖表。它佔據佔位符的區域，但不會繼承自版面佔位符。當需要替換其類別、系列或工作簿資料時，請使用專門的 [chart management articles](/slides/zh-hant/cpp/powerpoint-charts/)。

## **完整範例：更新文字或圖像內容**

以下端到端範例開啟範本、搜尋第一張投影片上的標題或圖片佔位符、檢查佔位符與形狀類型、更新相應內容，並儲存輸出。此範例刻意避免假設形狀索引或將所有佔位符都轉型為相同介面。

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

基礎佔位符是版面或母片上對應的形狀，其他佔位符會從它繼承。使用 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/getbaseplaceholder/) 取得。普通本機形狀會回傳 `nullptr`，因為它不屬於佔位符層級。

**我能透過編輯版面佔位符來變更所有投影片的標題嗎？**

可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在一般投影片上。若要取代簡報中所有投影片的實際標題文字，需要遍歷投影片並更新每個標題佔位符。

**如何管理日期、投影片編號、頁首與頁尾佔位符？**

請在適當的投影片、版面、母片、備註或講義範圍內使用頁首與頁尾管理器。參閱 [Manage Presentation Header and Footer](/slides/zh-hant/cpp/presentation-header-and-footer/) 取得完整範例。