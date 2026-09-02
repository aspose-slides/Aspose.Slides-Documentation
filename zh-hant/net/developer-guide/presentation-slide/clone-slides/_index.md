---
title: ".NET 中的簡報投影片複製"
linktitle: "複製投影片"
type: docs
weight: 40
url: /zh-hant/net/clone-slides/
keywords:
- 複製投影片
- 拷貝投影片
- 儲存投影片
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速複製 PowerPoint 投影片。遵循我們清晰的程式碼範例，即可在數秒內自動建立 PPT，省去手動操作。"
---
## **簡介**

Cloning 是製作某物精確複本或副本的過程。Aspose.Slides 也允許您複製（clone）任意投影片，然後將複製的投影片插入目前的簡報或任何其他開啟的簡報。投影片複製會建立新的投影片，開發人員可以在不影響原始投影片的情況下進行修改。複製投影片有以下幾種方式：

- 在簡報的結尾處複製。
- 在同一簡報的其他位置複製。
- 在其他簡報的結尾處複製。
- 在其他簡報的其他位置複製。
- 連同其母片一起複製到其他簡報。

在 Aspose.Slides for .NET 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 物件公開的投影片集合（[ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 物件的集合）提供了 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 和 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/insertclone/) 方法，以執行上述投影片複製操作。

## **在簡報結尾處複製投影片**

如果您想要複製投影片，然後在同一簡報檔案中於現有投影片的結尾處使用它，請依照以下步驟使用 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 透過參考 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，並將欲複製的投影片作為參數傳遞給 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 寫入已修改的簡報檔案。

在下方的範例中，我們將投影片（位於簡報的第一個位置 – 索引 0 –）複製到簡報的結尾處。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 將所需投影片複製到同一簡報中投影片集合的末尾
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 將已修改的簡報寫入磁碟
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **在同一簡報內的其他位置複製投影片**

如果您想要複製投影片，然後在同一簡報檔案的不同位置使用它，請使用 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件公開的 **Slides** 集合，實例化此類別。
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，並將欲複製的投影片以及新位置的索引作為參數傳遞給 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法。
1. 將已修改的簡報寫入為 PPTX 檔案。

在下方的範例中，我們將投影片（位於索引 1 – 第 2 個位置 –）複製到索引 2 – 第 3 個位置 –。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 將所需投影片複製到同一簡報中投影片集合的末尾
    ISlideCollection slds = pres.Slides;

    // 將所需投影片複製到同一簡報中指定的索引位置
    slds.InsertClone(2, pres.Slides[1]);

    // 將已修改的簡報寫入磁碟
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **在另一簡報的結尾處複製投影片**

如果您需要從一個簡報複製投影片，並在另一個簡報檔案的現有投影片結尾處使用它：

1. 建立包含欲複製投影片來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別實例。
1. 建立包含目標簡報（投影片要加入的簡報）的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別實例。
1. 透過參考目標簡報之 Presentation 物件公開的 **Slides** 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，並將來源簡報的投影片作為參數傳遞給 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 寫入已修改的目標簡報檔案。

在下方的範例中，我們將投影片（來自來源簡報的第一個索引）複製到目標簡報的結尾處。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化 Presentation 類別以載入來源簡報檔案
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 實例化目的地 PPTX 的 Presentation 類別（投影片將被複製的地方）
    using (Presentation destPres = new Presentation())
    {
        // 從來源簡報中複製所需投影片至目的地簡報的投影片集合末尾
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 將目的地簡報寫入磁碟
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **在另一簡報的其他位置複製投影片**

如果您需要從一個簡報複製投影片，並在另一個簡報檔案的特定位置使用它：

1. 建立包含來源簡報（投影片將從其複製）的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別實例。
1. 建立包含目標簡報（投影片將加入其中）的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別實例。
1. 透過參考目標簡報之 Presentation 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，並將來源簡報的投影片以及所需位置作為參數傳遞給 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法。
1. 寫入已修改的目標簡報檔案。

在下方的範例中，我們將投影片（來源簡報的索引 0）複製到目標簡報的索引 1（第 2 個位置）。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化 Presentation 類別以載入來源簡報檔案
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 實例化目的地 PPTX 的 Presentation 類別（投影片將被複製的地方）
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 將目的地簡報寫入磁碟
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **將投影片連同其母片一起複製到另一簡報**

如果您需要從一個簡報複製投影片，並在另一個簡報使用它，必須先將所需的母片從來源簡報複製到目標簡報。然後使用該母片來複製帶母片的投影片。**AddClone(ISlide, IMasterSlide)** 需要的是目標簡報的母片，而不是來源簡報的母片。要同時複製投影片與其母片，請遵循以下步驟：

1. 建立包含來源簡報（投影片將從其複製）的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別實例。
1. 建立包含目標簡報（投影片將複製到其中）的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別實例。
1. 取得要複製的投影片及其母片。
1. 透過參考目標簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件所公開的 Masters 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection) 類別。
1. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，並將來源 PPTX 中的母片作為參數傳遞給 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 透過設定對目標簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件所公開的 Slides 集合的參考，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，並將來源簡報的投影片及母片作為參數傳遞給 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 寫入已修改的目標簡報檔案。

在下方的範例中，我們將投影片（連同其母片，位於來源簡報的索引 0）使用來源投影片的母片複製到目標簡報的結尾處。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化 Presentation 類別以載入來源簡報檔案

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 實例化目的地簡報的 Presentation 類別（投影片將被複製的地方）
    using (Presentation destPres = new Presentation())
    {

        // 從來源簡報的投影片集合中實例化 ISlide，並搭配
        // 母片
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 從來源簡報中複製所需的母片至母片集合中
        // 目的地簡報
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 從來源簡報中複製所需的母片至母片集合中
        // 目的地簡報
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 從來源簡報中以所需母片複製目標投影片到結尾
        // 目的地簡報的投影片集合
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 從來源簡報中複製所需的母片至目的地簡報的母片集合
        // 將目的地簡報寫入磁碟
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **在指定區段的結尾處複製投影片**

使用 Aspose.Slides for .NET，您可以從簡報的一個區段複製投影片，並將其插入同一簡報的另一個區段。在此情況下，必須使用來自 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 介面的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法。

以下 C# 程式碼示範如何複製投影片並將複製的投影片插入指定的區段：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // 待複製
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **確保投影片尺寸相符**

在將投影片複製到另一個簡報時，請確保目標簡報的投影片尺寸與來源相同。如果尺寸不同，Aspose.Slides 不會自動重新縮放複製的圖形——其原始座標和尺寸會被保留，可能導致內容對齊不正確或超出投影片邊界。

您可以在複製母片與投影片之前，將目標簡報的投影片尺寸設定為與來源相同：

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

請在複製母片與投影片之前執行此操作。

## **常見問題**

**講者備註與審閱者評論會被複製嗎？**

是的。備註頁面與審閱評論會包含在複製中。如果您不想要它們，請在插入後[移除它們](/slides/zh-hant/net/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式設定與嵌入的資料都會被複製。如果圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE 物件](/slides/zh-hant/net/manage-ole/) 形式保留。移動檔案後，請驗證資料是否可用以及重新整理的行為。

**我可以控制複製品的插入位置與區段嗎？**

可以。您可以在特定的投影片索引插入複製品，並將其放入選擇的 [區段](/slides/zh-hant/net/slide-section/)。如果目標區段不存在，請先建立該區段，然後將投影片移入其中。