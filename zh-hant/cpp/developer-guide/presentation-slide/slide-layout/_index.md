---
title: 在 C++ 中套用或變更投影片版面配置
linktitle: 投影片版面配置
type: docs
weight: 60
url: /zh-hant/cpp/slide-layout/
keywords:
- 投影片版面配置
- 內容版面配置
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
description: "在 Aspose.Slides for C++ 中套用、建立與修改投影片版面配置，加入佔位符，移除未使用的版面，並控制頁腳可見性。"
---
## **概觀**

投影片版面配置會定義標題、文字、圖片、圖表與表格等佔位符的位置與格式。套用版面配置可讓投影片具有一致的結構，同時讓每張投影片保有自己的內容。

最常見的版面配置包括：

- **標題投影片**：包含標題與副標題佔位符。
- **標題與內容**：包含標題佔位符與通用內容佔位符。
- **空白**：不包含任何內容佔位符，適用於需要手動定位每個圖形的情況。

## **了解版面繼承**

簡報有三個相關層級：

1. [母片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/) 定義主題、共用格式、背景與共用物件。
1. [版面投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/) 屬於母片，定義特定的佔位符排列。
1. [普通投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 使用一個版面，並儲存該投影片的內容。

普通投影片會從其版面繼承主題與格式，版面則從其母片繼承。直接在普通投影片上設定的值會覆蓋該層級的繼承值。建立普通投影片時，會根據所選版面產生佔位符圖形，而填入這些佔位符的內容屬於普通投影片。

在從版面建立投影片之前，請先在版面中加入所需的佔位符。之後再為版面加入佔位符不會自動為現有的普通投影片新增對應的佔位符圖形。

此關係有兩個重要的結果：

- 變更版面的繼承格式或既有佔位符的幾何形狀會更新所有依賴該版面的投影片。在編輯已在使用中的版面前，請先檢查其依賴的投影片並審視最終簡報。
- 仍被投影片使用的版面無法移除。必須先將其依賴的投影片重新指派至其他版面，或僅移除未使用的版面。

如需了解此階層的最高層級，請參閱 [投影片母片](/slides/zh-hant/cpp/slide-master/)。

## **選取與套用投影片版面配置**

當簡報遵循標準 PowerPoint 版面定義時，請使用版面類型。版面名稱可由使用者編輯且可本地化，除非您掌握來源範本，否則基於名稱的選取可靠度較低。

以下範例在第一個母片上尋找 **標題與內容**。如果該版面不存在，則會明確退回到 **空白**。第二個 null 檢查是必要的，因為簡報可能僅包含自訂版面。選取的版面接著會透過 [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/set_layoutslide/) 方法套用到第一張普通投影片。

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

變更投影片的版面不會移除直接添加於投影片的普通圖形。然而，佔位符位置、繼承格式以及現有佔位符與新版面之間的對應關係可能會變化，切換差異較大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前面的範例僅選取現有版面，並未建立新版面。若要建立版面，請對目標母片的版面集合呼叫 [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterlayoutslidecollection/add/) 方法。

以下範例始終新增一個名為 `Report Title and Content` 的 **標題與內容** 版面，然後基於它新增普通投影片。版面名稱在集合內必須唯一。

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

僅在範本真正需要另一個可重複使用的結構時才新增版面。如果已存在合適的版面，請選取並重複使用，而非建立重複的版面。

## **在版面投影片中新增佔位符**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) 方法會提供一個 [ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/) 供在版面中新增佔位符圖形。

| PowerPoint 佔位符 | `ILayoutPlaceholderManager` 方法 |
| ------------------- | -------------------------------- |
| ![Content](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

以下範例驗證 **空白** 版面是否存在，然後向其新增四個佔位符，最後建立使用已修改版面的普通投影片。順序是有意為之：先加入佔位符，再建立普通投影片，以便 Aspose.Slides 能在該投影片上產生相對應的佔位符圖形。

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

{{% alert color="warning" title="Warning" %}}
變更繼承格式或既有版面佔位符的幾何形狀可能會影響依賴的投影片。新加入的版面佔位符不會自動回填至現有的普通投影片。請在簡報副本上測試版面變更，並檢查每一張依賴投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用 [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法可移除未被任何普通投影片參照的版面。此方法會保留仍在使用中的版面。

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

若要移除特定版面，先使用其 [get_HasDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) 方法或 [GetDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/getdependingslides/) 方法。移除前請先重新指派任何依賴的投影片，然後呼叫 [ILayoutSlide::Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/remove/) 方法。嘗試移除仍在使用中的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxeditexception/)。

## **在版面投影片上控制頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位符。使用 [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) 方法可為單一版面控制這些佔位符。這在例如內容版面需要顯示頁腳、而標題版面則不需要時非常有用。

以下範例安全地選取版面，並將其頁腳元素設為可見：

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

## **在母片及其子版面上控制頁腳可見性**

若要在母片層級中套用一致的頁腳設定，請使用 [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/get_headerfootermanager/) 方法。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslideheaderfootermanager/) 的傳播方法會作用於母片本身、其相依的版面投影片以及普通投影片；不會僅針對單一普通投影片。

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

## **常見問答**

**母片與版面投影片有何不同？**

母片定義簡報的主題與共用格式。版面投影片屬於母片，定義一組可重複使用的佔位符排列。普通投影片使用這些版面並儲存投影片特有的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用 [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igloballayoutslidecollection/addclone/) 方法將複本加入目標集合。跨簡報複製時，同時需要驗證來源版面使用的字型、主題、影像與其他資源。

**當我修改已在使用中的版面會發生什麼事？**

相依的投影片會繼承版面的變更，除非它們在本機覆寫了受影響的格式或物件。佔位符的幾何形狀與繼承樣式可能會一次性在多張投影片上變更。使用 [GetDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/getdependingslides/) 先找出受影響的投影片，再編輯版面。

**如果我移除仍在使用中的版面會怎樣？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxeditexception/)。請先重新指派相依的投影片，或使用 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 只移除未被參照的版面。