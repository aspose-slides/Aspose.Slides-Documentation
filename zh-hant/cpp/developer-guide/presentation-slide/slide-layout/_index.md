---
title: 在 C++ 中套用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/cpp/slide-layout/
keywords:
- 投影片版面
- 內容版面
- 佔位符
- 簡報設計
- 投影片設計
- 未使用的版面
- 頁腳可見性
- 標題投影片
- 標題與內容
- 章節標題
- 雙內容
- 比較
- 僅標題
- 空白版面
- 含說明文字的內容
- 含說明文字的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中套用、建立與修改投影片版面，新增佔位符、移除未使用的版面，並控制頁腳可見性。"
---
## **概述**

投影片版面定義了標題、文字、圖片、圖表與表格等佔位符的位置與格式。套用版面可為投影片提供一致的結構，同時允許每張投影片包含各自的內容。

最常見的版面包括：

- **標題投影片**：包含標題與副標題佔位符。
- **標題與內容**：包含一個標題佔位符和一個通用內容佔位符。
- **空白**：不包含任何內容佔位符，適用於需要手動定位所有圖形的情況。

## **了解版面繼承**

簡報有三個相關層級：

1. A [母片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/) 定義主題、共用格式、背景以及共通物件。
2. A [版面投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/) 屬於母片，並定義特定的佔位符排列。
3. A [普通投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 使用一個版面，並儲存該投影片輸入的內容。

普通投影片會自版面繼承主題與格式，版面則自母片繼承。直接在普通投影片上設定的值會覆寫該層級的繼承值。建立普通投影片時，會根據所選版面產生其佔位符形狀，而輸入至這些佔位符的內容屬於普通投影片本身。

在使用版面建立投影片之前，先在版面中加入所需的佔位符。之後再向版面添加佔位符，並不會自動在已存在的普通投影片中加入相應的佔位符形狀。

此關係帶來兩個重要的結果：

- 變更版面上繼承的格式或現有佔位符的幾何形狀，可能會更新所有依賴該版面的投影片。編輯已在使用中的版面之前，請檢查其依賴的投影片並審閱最終簡報。
- 仍被投影片使用的版面無法移除。必須先將其依賴的投影片重新指派至其他版面，或僅移除未使用的版面。

如需瞭解此層級頂層的更多資訊，請參閱[投影片母片](/slides/zh-hant/cpp/slide-master/)。

若要在單一投影片或透過共用版面隱藏繼承的標誌或裝飾性母片圖形，請參閱[控制母片圖形的可見性](/slides/zh-hant/cpp/slide-master/)。此範例比較了使用相同母片的兩張投影片。

## **選取與套用投影片版面**

當簡報遵循標準 PowerPoint 版面定義時，請使用版面類型。版面名稱可由使用者編輯且能本地化，因此除非您掌控來源範本，否則僅依名稱選取的可靠性較低。

以下範例在第一個母片中搜尋 **標題與內容**。若未找到該版面，則會故意回退到 **空白**。第二個空值檢查是必要的，因為簡報可能僅包含自訂版面。選取的版面接著透過 [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/set_layoutslide/) 方法套用至第一張普通投影片。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

變更投影片的版面不會移除直接新增於投影片的普通圖形。然而，佔位符位置、繼承的格式以及現有佔位符與新版面之間的對應關係可能會改變，因此在切換差異大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前一個範例僅選取現有版面，並未建立新的版面。若要建立版面，請在目標母片的版面集合上呼叫 [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterlayoutslidecollection/add/) 方法。

以下範例始終新增一個名為 `Report Title and Content` 的 **標題與內容** 版面，然後基於該版面新增普通投影片。版面名稱在集合內必須唯一。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

僅當範本確實需要另一個可重複使用的結構時才新增版面。如果已有合適的版面，請選取並重複使用，而非建立重複的版面。

## **向版面投影片新增佔位符**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) 方法提供一個 [ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/) 供向版面新增佔位符形狀。

| PowerPoint 佔位符 | `ILayoutPlaceholderManager` Method |
| ----------------- | ---------------------------------- |
| ![內容](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![內容（垂直）](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![文字](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![文字（垂直）](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![圖片](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![圖表](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![表格](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![媒體](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![線上圖像](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

以下範例驗證 **空白** 版面是否存在，向其新增四個佔位符，然後建立使用該修改後版面的普通投影片。此順序刻意設計：先新增佔位符再建立普通投影片，讓 Aspose.Slides 能在該投影片上產生相對應的佔位符形狀。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![版面投影片上的佔位符](add_placeholders.png)

{{% alert color="warning" title="警告" %}}
變更繼承的格式或現有版面佔位符的幾何形狀可能會影響依賴的投影片。新加入的版面佔位符不會回填至已有的普通投影片。請在簡報的副本上測試版面變更，並檢查每一個依賴的投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用 [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法移除未被任何普通投影片參照的版面。此方法會保留仍在使用中的版面。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若要移除特定版面，請先使用其 [get_HasDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) 方法或 [GetDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/getdependingslides/) 方法。於呼叫 [ILayoutSlide::Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/remove/) 之前，先重新指派任何依賴的投影片。嘗試移除仍在使用的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位符。使用 [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) 方法可控制單一版面的這些佔位符。這在例如內容版面需要顯示頁腳而標題版面則不需要時非常有用。

以下範例安全地選取版面，並使其頁腳元素可見：

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **控制母片及其子版面的頁腳可見性**

若要在母片層級中套用一致的頁腳設定，請使用 [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/get_headerfootermanager/) 方法。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslideheaderfootermanager/) 的傳播方法會作用於母片及其依賴的版面投影片與普通投影片；不會僅針對單一普通投影片。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**什麼是母片與版面投影片之間的差異？**

母片定義簡報的主題與共用格式。版面投影片屬於母片，定義一個可重複使用的佔位符排列。普通投影片使用這些版面並儲存投影片特定的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用 [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igloballayoutslidecollection/addclone/) 方法將複本加入目標集合。於在簡報間複製時，亦需確認來源版面使用的字型、主題、圖像及其他資源。

**當我修改已在使用中的版面時會發生什麼？**

依賴的投影片會繼承版面變更，除非它們在本地覆寫受影響的格式或物件。因此，許多投影片的佔位符幾何形狀與繼承樣式可能一次變更。編輯版面前，先使用 [GetDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/getdependingslides/) 以識別受影響的投影片。

**如果我移除仍在使用中的版面會發生什麼？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxeditexception/)。請先重新指派依賴的投影片，或使用 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 僅移除未被參照的版面。