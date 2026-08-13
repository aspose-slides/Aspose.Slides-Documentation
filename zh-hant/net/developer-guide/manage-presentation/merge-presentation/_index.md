---
title: 在 .NET 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/net/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併簡報
- 合併投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合簡報
- 結合投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆合併 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報，簡化您的工作流程。"
---
## **概述**

Aspose.Slides 允許您透過從一個簡報複製投影片到另一個簡報來合併簡報。本篇文章說明如何合併整個簡報或選取的投影片、在合併過程中使用投影片母片或特定版面配置、處理具有不同投影片大小的簡報，以及將合併的投影片加入簡報的節 (section)。同時也涵蓋與合併內容相關的實用注意事項，包括講者備註、註解、受密碼保護的來源檔案，以及執行緒使用情形。

## **優化簡報合併**

使用 [Aspose.Slides for .NET](https://products.aspose.com/slides/zh-hant/net/)，可無縫結合 PowerPoint 簡報，同時保留樣式、版面配置與所有元素。與其他工具不同，Aspose.Slides 在合併簡報時不會降低品質或遺失資料。可合併整個簡報、特定投影片，甚至不同檔案格式（PPT 轉 PPTX 等）。

### **合併功能**

- **完整簡報合併：** 將所有投影片組合成單一檔案。  
- **特定投影片合併：** 選取並組合選定的投影片。  
- **跨格式合併：** 整合不同格式的簡報，同時維持完整性。  

{{% alert title="Tip" color="info" %}}  

在尋找快速且 **免費的線上工具** 來 **合併 PowerPoint 簡報** 嗎？請試用 [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/zh-hant/merger)。  

- **輕鬆合併 PowerPoint 檔案**：將多個 **PPT、PPTX、ODP** 簡報合併為單一檔案。  
- **支援不同格式**：合併 **PPT 轉 PPTX**、**PPTX 轉 ODP** 等等。  
- **無需安裝**：直接在瀏覽器中執行，快速且安全。  

[![線上合併 PowerPoint 檔案](slides-merger.png)](https://products.aspose.app/slides/zh-hant/merger)  

立即使用 **Aspose 免費線上工具** 開始合併您的 PowerPoint 檔案！  

{{% /alert %}}

## **簡報合併**

當您 [將一個簡報合併至另一個簡報](https://products.aspose.com/slides/zh-hant/net/merger/ppt/)，即是將它們的投影片合併於單一簡報中，以產生一個檔案。 

{{% alert title="Info" color="info" %}}

大多數簡報程式（PowerPoint 或 OpenOffice）皆缺乏允許使用者以此方式合併簡報的功能。

然而，[**Aspose.Slides for .NET**](https://products.aspose.com/slides/zh-hant/net/) 能以多種方式合併簡報。您可以合併簡報的所有形狀、樣式、文字、格式、註解、動畫等，且無需擔心品質或資料遺失。

**另請參閱**

[Clone Slides](https://docs.aspose.com/slides/zh-hant/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **可合併的項目**

使用 Aspose.Slides，您可以合併

* 整個簡報。所有簡報的投影片都會匯入至同一簡報  
* 特定投影片。選取的投影片匯入至同一簡報  
* 同一格式的簡報（PPT 轉 PPT、PPTX 轉 PPTX 等）以及不同格式的簡報（PPT 轉 PPTX、PPTX 轉 ODP 等）相互合併。  

{{% alert title="Note" color="warning" %}} 

除了簡報之外，Aspose.Slides 也允許合併其他檔案：

* [Images](https://products.aspose.com/slides/zh-hant/net/merger/image-to-image/)，例如 [JPG 轉 JPG](https://products.aspose.com/slides/zh-hant/net/merger/jpg-to-jpg/) 或 [PNG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/merger/png-to-png/)  
* 文件，例如 [PDF 轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/pdf-to-pdf/) 或 [HTML 轉 HTML](https://products.aspose.com/slides/zh-hant/net/merger/html-to-html/)  
* 以及兩種不同類型的檔案，例如 [image 轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/image-to-pdf/)、[JPG 轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/jpg-to-pdf/) 或 [TIFF 轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/tiff-to-pdf/)。  

{{% /alert %}}

### **合併選項**

您可以套用選項以決定：

* 輸出簡報中的每張投影片是否保留各自獨立的樣式  
* 是否對所有投影片使用相同的特定樣式。  

要合併簡報，Aspose.Slides 提供 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone) 方法（來自 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 介面）。`AddClone` 方法有多種實作，允許您定義合併過程的參數。每個 Presentation 物件都有一個 [Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/properties/slides) 集合，因此您可以在欲合併投影片的目標簡報上呼叫 `AddClone` 方法。

`AddClone` 方法會回傳一個 `ISlide` 物件，即來源投影片的副本。輸出簡報中的投影片僅是來源投影片的拷貝。因此，您可以對產生的投影片進行變更（例如套用樣式、格式選項或版面配置），而不必擔心會影響來源簡報。

## **合併簡報** 

Aspose.Slides 提供 [**AddClone (ISlide)**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone) 方法，允許在合併投影片時保留其版面配置與樣式（預設參數）。 

以下 C# 程式碼示範如何合併簡報：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **使用投影片母片合併簡報** 

Aspose.Slides 提供 [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.islidecollection/addclone/methods/2) 方法，允許在合併投影片時套用投影片母片範本。如此一來，必要時即可變更輸出簡報中投影片的樣式。 

以下 C# 程式碼示範上述操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 

投影片母片的版面配置會自動判斷。若無法決定適當的版面配置，且 `AddClone` 方法的 `allowCloneMissingLayout` 布林參數設為 true，則會使用來源投影片的版面配置。否則，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception)。 

{{% /alert %}}

如果您希望輸出簡報中的投影片使用不同的版面配置，合併時請改為使用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.islidecollection/addclone/methods/1) 方法。

## **合併簡報中的特定投影片** 

從多個簡報中合併特定投影片有助於建立自訂簡報組。Aspose.Slides for .NET 允許您只選取並匯入所需的投影片。API 會保留原始投影片的格式、版面配置與設計。 

以下 C# 程式碼會建立新簡報，從另外兩個簡報中加入標題投影片，並將結果儲存為檔案：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```
```cs
using Aspose.Slides;

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **使用投影片版面配置合併簡報** 

以下 C# 程式碼示範如何在合併簡報投影片時套用您偏好的投影片版面配置，以產生單一輸出簡報：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **合併不同投影片大小的簡報** 

{{% alert title="Note" color="warning" %}} 

合併具有不同投影片大小的簡報不會產生錯誤，但合併後的投影片會採用目標簡報的投影片大小，而其形狀仍保留原始位置與尺寸，可能導致內容錯位或超出投影片範圍。 

{{% /alert %}}

若要合併兩個投影片大小不同的簡報且保持內容正確排版，請先將其中一個簡報的大小調整為與另一個簡報相同。 

以下範例程式碼示範上述操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **合併投影片至簡報節** 

以下 C# 程式碼示範如何將特定投影片合併至簡報的節中：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

該投影片會被加入至節的末端。 

{{% alert title="Tip" color="info" %}}

Aspose 提供一個 [免費 Collage 網頁應用程式](https://products.aspose.app/slides/zh-hant/collage)。透過此線上服務，您可以合併 [JPG 轉 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 轉 PNG 圖片、建立 [相簿格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等等。 

{{% /alert %}}

## **常見問題**

### 合併過程中會保留講者備註嗎？

會。當複製投影片時，Aspose.Slides 會一起攜帶所有投影片元素，包含備註、格式與動畫。

### 註解及其作者會被轉移嗎？

註解作為投影片內容的一部份，會隨投影片一起複製。註解的作者標籤會以註解物件的形式保留於產生的簡報中。

### 如果來源簡報有密碼保護怎麼辦？

必須透過 [LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 搭配正確密碼開啟（參考 /slides/zh-hant/net/password-protected-presentation/），載入後即可安全地將這些投影片複製至未受保護的目標檔案（或同樣受保護的檔案）。

### 合併操作的執行緒安全性如何？

請勿在 [多執行緒](/slides/zh-hant/net/multithreading/) 中使用相同的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。建議的原則是「一個文件 — 一個執行緒」；不同檔案可於不同執行緒平行處理。