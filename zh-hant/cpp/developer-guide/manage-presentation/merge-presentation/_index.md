---
title: 在 C++ 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/cpp/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併 簡報
- 合併 投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合 簡報
- 結合 投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆合併 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）簡報，簡化您的工作流程。"
---
## **概述**

Aspose.Slides 允許您透過從一個簡報複製投影片到另一個簡報的方式合併簡報。本文說明如何合併整個簡報或選取的投影片、在合併期間使用投影片母片或特定版面配置、處理具有不同投影片尺寸的簡報，以及將合併的投影片加入簡報的節中。亦會討論合併內容相關的實務注意事項，包括講者備註、評論、受密碼保護的來源檔案，以及執行緒使用方式。

{{% alert title="Info" color="info" %}}

大多數簡報程式（PowerPoint 或 OpenOffice）都缺乏讓使用者以此方式合併簡報的功能。

[**Aspose.Slides for C++**](https://products.aspose.com/slides/zh-hant/cpp/)，可讓您以不同方式合併簡報。您可以合併簡報的所有形狀、樣式、文字、格式、評論、動畫等，而不必擔心品質或資料遺失。

**另請參閱**

[Clone Slides](https://docs.aspose.com/slides/zh-hant/cpp/clone-slides/)*.*

{{% /alert %}}

### **可以合併的內容**

使用 Aspose.Slides，您可以合併

* 整份簡報。所有投影片會匯入至同一個簡報
* 特定投影片。選取的投影片會匯入至同一個簡報
* 同一格式的簡報（PPT 轉 PPT、PPTX 轉 PPTX 等）或不同格式的簡報（PPT 轉 PPTX、PPTX 轉 ODP 等）相互之間。

{{% alert title="Note" color="warning" %}} 

除了簡報之外，Aspose.Slides 也允許您合併其他檔案：

* [Images](https://products.aspose.com/slides/zh-hant/cpp/merger/image-to-image/)，例如 [JPG to JPG](https://products.aspose.com/slides/zh-hant/cpp/merger/jpg-to-jpg/) 或 [PNG to PNG](https://products.aspose.com/slides/zh-hant/cpp/merger/png-to-png/)
* 文件，例如 [PDF to PDF](https://products.aspose.com/slides/zh-hant/cpp/merger/pdf-to-pdf/) 或 [HTML to HTML](https://products.aspose.com/slides/zh-hant/cpp/merger/html-to-html/)
* 兩種不同類型的檔案，例如 [image to PDF](https://products.aspose.com/slides/zh-hant/cpp/merger/image-to-pdf/) 或 [JPG to PDF](https://products.aspose.com/slides/zh-hant/cpp/merger/jpg-to-pdf/) 或 [TIFF to PDF](https://products.aspose.com/slides/zh-hant/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **合併選項**

您可以套用以下選項以決定

* 輸出簡報中的每張投影片是否保留唯一樣式
* 所有投影片是否使用相同樣式

為了合併簡報，Aspose.Slides 提供了 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法（來自 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_slide_collection) 介面）。`AddClone` 方法有多種實作，可定義簡報合併過程的參數。每個 Presentation 物件都有一個 [Slides](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 集合，您可以從欲合併投影片的目標簡報呼叫 `AddClone` 方法。

`AddClone` 方法會回傳一個 `ISlide` 物件，即來源投影片的克隆。輸出簡報中的投影片只是來源投影片的副本。因此，您可以對結果投影片進行變更（例如套用樣式、格式或版面配置），而不會影響來源簡報。

## **合併簡報**

Aspose.Slides 提供了 [**AddClone (ISlide)**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法，允許您在保留投影片版面與樣式的情況下合併投影片（預設參數）。

以下 C++ 程式碼示範如何合併簡報：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **合併簡報與投影片母片**

Aspose.Slides 提供了 [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) 方法，允許您在套用投影片母片範本的同時合併投影片。這樣若有需要，您即可變更輸出簡報中投影片的樣式。

以下 C++ 程式碼示範上述操作：

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

投影片母片的版面配置會自動判定。若無法判定適當的版面，且 `AddClone` 方法的 `allowCloneMissingLayout` 布林參數設為 true，則會使用來源投影片的版面；否則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)。

{{% /alert %}}

如果您希望輸出簡報的投影片使用不同的版面配置，合併時請改用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) 方法。

## **從簡報中合併特定投影片**

從多個簡報中合併特定投影片，可用於建立自訂的投影片組。Aspose.Slides C++ 允許您只選取並匯入所需的投影片，且 API 會保留原始投影片的格式、版面與設計。

以下 C++ 程式碼會建立新簡報，從兩個其他簡報中加入標題投影片，並將結果儲存為檔案：

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 在上方程式碼中已宣告。
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **合併簡報與投影片版面配置**

此 C++ 程式碼示範如何在合併投影片時套用您偏好的版面配置，以產生單一輸出簡報：

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **合併具有不同投影片尺寸的簡報**

{{% alert title="Note" color="warning" %}} 

無法合併尺寸不同的簡報。

{{% /alert %}}

若要合併兩個投影片尺寸不同的簡報，必須先調整其中一個簡報的尺寸，使其與另一簡報的尺寸相符。

以下範例程式碼示範上述操作：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **將投影片合併至簡報節**

此 C++ 程式碼示範如何將特定投影片合併至簡報的某個節：

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

投影片會被添加至該節的末端。

{{% alert title="Tip" color="info" %}}

Aspose 提供一個 **免費** 的 Collage 網頁應用程式（[Collage 網頁應用程式](https://products.aspose.app/slides/zh-hant/collage)）。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 圖片，建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，等等。

{{% /alert %}}

## **常見問題**

### 合併時會保留講者備註嗎？

會。當克隆投影片時，Aspose.Slides 會將所有投影片元素（包括備註、格式與動畫）一起帶入。

### 評論及其作者會被轉移嗎？

評論屬於投影片內容的一部份，會隨投影片一起複製。評論作者標籤會以評論物件的形式保留在結果簡報中。

### 若來源簡報受密碼保護該怎麼處理？

必須使用 [LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/) 以密碼開啟（/slides/zh-hant/cpp/password-protected-presentation/），載入後即可安全地將這些投影片克隆至未受保護的目標檔案（或同樣受保護的檔案）。

### 合併操作的執行緒安全性如何？

請勿在 [多執行緒](/slides/zh-hant/cpp/multithreading/) 中同時使用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例。建議的規則是「一個文件—一個執行緒」；不同檔案可在獨立執行緒中平行處理。