---
title: 在 .NET 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，輕鬆合併 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報，簡化您的工作流程。"
---
## **概觀**

Aspose.Slides 允許您透過從一個簡報複製投影片到另一個簡報來合併簡報。本文說明了如何合併整個簡報或選取的投影片、在合併過程中使用投影片母片或特定版面、處理具有不同投影片尺寸的簡報，以及將合併的投影片加入簡報章節。還涵蓋與合併內容相關的實用說明，包括講者備註、評論、受密碼保護的來源檔案，以及執行緒使用方式。

## **最佳化您的簡報合併**

使用 [Aspose.Slides for .NET](https://products.aspose.com/slides/zh-hant/net/)，可無縫結合 PowerPoint 簡報，同時保留樣式、版面配置以及所有元素。與其他工具不同，Aspose.Slides 在合併簡報時不會犧牲品質或遺失資料。您可以合併整個簡報、特定投影片，甚至不同檔案格式（PPT 轉 PPTX 等）。

### **合併功能**

- **完整簡報合併：** 將所有投影片組合成單一檔案。
- **特定投影片合併：** 選取並結合指定的投影片。
- **跨格式合併：** 整合不同格式的簡報，保持完整性。

{{% alert title="Tip" color="primary" %}}  

尋找快速且 **免費的線上工具** 來 **合併 PowerPoint 簡報**？試試 [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/zh-hant/merger)。  

- **輕鬆合併 PowerPoint 檔案**：將多個 **PPT、PPTX、ODP** 簡報合併為單一檔案。  
- **支援不同格式**：合併 **PPT 轉 PPTX**、**PPTX 轉 ODP** 等。  
- **無需安裝**：直接在瀏覽器中使用，快速且安全。  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/zh-hant/merger)  

立即使用 **Aspose 免費線上工具** 合併您的 PowerPoint 檔案！  

{{% /alert %}}

## **簡報合併**

當您 [將一個簡報合併至另一個簡報](https://products.aspose.com/slides/zh-hant/net/merger/ppt/)，實際上是將它們的投影片合併成單一簡報，以取得唯一的檔案。

{{% alert title="Info" color="info" %}}

大多數簡報程式（PowerPoint 或 OpenOffice）都缺乏允許使用者以此方式合併簡報的功能。  

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/zh-hant/net/)，卻允許您以多種方式合併簡報。您可以合併簡報的所有圖形、樣式、文字、格式、評論、動畫等，而不必擔心品質或資料遺失。  

**另見**  

[複製投影片](https://docs.aspose.com/slides/zh-hant/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  

{{% /alert %}}

### **可以合併的內容**

使用 Aspose.Slides，您可以合併  

* 整個簡報。所有簡報中的投影片最終匯聚於一個簡報中  
* 特定投影片。選取的投影片最終匯聚於一個簡報中  
* 同一格式的簡報（PPT 轉 PPT、PPTX 轉 PPTX 等）及不同格式的簡報（PPT 轉 PPTX、PPTX 轉 ODP 等）相互合併  

{{% alert title="Note" color="warning" %}} 

除了簡報之外，Aspose.Slides 也允許您合併其他檔案：

* [影像](https://products.aspose.com/slides/zh-hant/net/merger/image-to-image/)，例如 [JPG 轉 JPG](https://products.aspose.com/slides/zh-hant/net/merger/jpg-to-jpg/) 或 [PNG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/merger/png-to-png/)  
* 文件，例如 [PDF 轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/pdf-to-pdf/) 或 [HTML 轉 HTML](https://products.aspose.com/slides/zh-hant/net/merger/html-to-html/)  
* 以及兩種不同類型的檔案，例如 [影像轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/image-to-pdf/) 或 [JPG 轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/jpg-to-pdf/) 或 [TIFF 轉 PDF](https://products.aspose.com/slides/zh-hant/net/merger/tiff-to-pdf/)  

{{% /alert %}}

### **合併選項**

您可以套用選項以決定是否  

* 輸出簡報中的每一張投影片保留各自的樣式  
* 所有投影片使用相同的樣式  

要合併簡報，Aspose.Slides 提供 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone) 方法（來自 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 介面）。`AddClone` 方法有多種實作，定義了簡報合併過程的參數。每個 Presentation 物件都有一個 [Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/properties/slides) 集合，您可以從欲合併投影片的簡報呼叫 `AddClone` 方法。  

`AddClone` 方法會回傳一個 `ISlide` 物件，該物件是來源投影片的複製品。輸出簡報中的投影片僅是來源投影片的副本。因此，您可以對產生的投影片進行變更（例如套用樣式、格式設定或版面配置），而不必擔心會影響來源簡報。  

## **合併簡報** 

Aspose.Slides 提供 [**AddClone (ISlide)**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone) 方法，可在保留投影片版面與樣式（預設參數）的情況下合併投影片。  

以下 C# 程式碼示範如何合併簡報：

```c#
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

Aspose.Slides 提供 [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.islidecollection/addclone/methods/2) 方法，可在合併投影片時套用投影片母片範本。如此一來，必要時您就能變更輸出簡報中投影片的樣式。  

以下 C# 程式碼示範上述操作：

```c#
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

投影片母片的版面會自動決定。當無法判斷適當的版面時，若 `AddClone` 方法的 `allowCloneMissingLayout` 布林參數設為 true，則使用來源投影片的版面；否則將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxeditexception)。  

{{% /alert %}}

若您希望輸出簡報中的投影片使用不同的投影片版面，請改用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.islidecollection/addclone/methods/1) 方法進行合併。  

## **從簡報中合併特定投影片** 

從多個簡報合併特定投影片可用於建立自訂投影片組。Aspose.Slides for .NET 允許您僅選取並匯入所需的投影片。API 會保留原始投影片的格式、版面與設計。  

以下 C# 程式碼會建立新簡報，從兩個其他簡報中加入標題投影片，並將結果儲存為檔案：

```cs
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
```
```cs
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

## **使用投影片版面合併簡報** 

此 C# 程式碼示範如何從簡報中合併投影片，同時套用您偏好的投影片版面，最終產生單一輸出簡報：

```c#
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

## **合併不同投影片尺寸的簡報** 

{{% alert title="Note" color="warning" %}} 

無法合併投影片尺寸不同的簡報。  

{{% /alert %}}

若要合併兩個投影片尺寸不同的簡報，必須先將其中一個簡報的尺寸調整為與另一個簡報相同。  

以下範例程式碼示範此操作：

```c#
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

## **將投影片合併至簡報章節** 

此 C# 程式碼示範如何將特定投影片合併至簡報的章節：

```c#
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

投影片會被加入至該章節的末端。  

{{% alert title="Tip" color="primary" %}}

Aspose 提供一個 [FREE Collage 網路應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG 轉 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 轉 PNG 圖片，建立 [相片網格](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。  

{{% /alert %}}

## **常見問題** 

**合併時會保留講者備註嗎？**  

會。當複製投影片時，Aspose.Slides 會攜帶所有投影片元素，包括備註、格式與動畫。  

**評論及其作者會被轉移嗎？**  

評論作為投影片內容的一部分，會被一起複製。評論作者的標籤會以評論物件形式保留在產生的簡報中。  

**如果來源簡報受密碼保護怎麼辦？**  

必須使用 [LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 透過密碼開啟（請參閱 [/slides/zh-hant/net/password-protected-presentation/](/slides/zh-hant/net/password-protected-presentation/)），載入後即可安全地將投影片複製至未受保護的目標檔案（或同樣受保護的檔案）。  

**合併操作的執行緒安全性如何？**  

請勿在 [多個執行緒](/slides/zh-hant/net/multithreading/) 中共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。建議的規則是「一個文件—一個執行緒」；不同檔案可在各自的執行緒中平行處理。