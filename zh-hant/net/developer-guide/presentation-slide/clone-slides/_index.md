---
title: 在 .NET 中克隆簡報投影片
linktitle: 克隆投影片
type: docs
weight: 40
url: /zh-hant/net/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 儲存投影片
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速複製 PowerPoint 投影片。遵循我們清晰的程式碼範例，在數秒內自動建立 PPT，省去手動操作。"
---
## **簡介**

克隆是製作某物精確副本或複製的過程。Aspose.Slides 也允許您複製（克隆）任何投影片，然後將克隆的投影片插入到當前簡報或任何其他開啟的簡報中。投影片克隆會建立一個新投影片，開發人員可以在不影響原始投影片的情況下修改它。克隆投影片有多種方式：

- 在簡報的末端克隆。
- 在簡報的其他位置克隆。
- 在另一個簡報的末端克隆。
- 在另一個簡報的其他位置克隆。
- 在另一個簡報的特定位置克隆。

在 Aspose.Slides for .NET 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 物件所公開的投影片集合（[ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 物件的集合）提供 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 與 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/insertclone/) 方法，以執行上述的投影片克隆操作。

## **在簡報的末端克隆投影片**

如果您想要克隆投影片並在同一簡報檔案的現有投影片末端使用它，請依照以下步驟使用 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
1. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件所公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。  
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，並將要克隆的投影片作為參數傳遞給該方法。  
1. 寫入已修改的簡報檔案。

在下列範例中，我們將投影片（位於簡報的第一個位置——索引 0）克隆至簡報的末端。

```c#
// 實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 將所需的投影片克隆至同一簡報中投影片集合的末端
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 將已修改的簡報寫入磁碟
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **在簡報內的其他位置克隆投影片**
如果您想要克隆投影片並在同一簡報檔案的其他位置使用它，請使用 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
1. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 物件所公開的 **Slides** 集合，實例化相應的類別。  
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，並將要克隆的投影片與新位置的索引作為參數傳遞給該方法。  
1. 將修改後的簡報寫入為 PPTX 檔案。

在下列範例中，我們將投影片（位於索引 0——位置 1——的投影片）克隆至索引 1——位置 2——的地方。

```c#
// 實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 將所需的投影片克隆至同一簡報中投影片集合的末端
    ISlideCollection slds = pres.Slides;

    // 將所需的投影片克隆至同一簡報中指定的索引位置
    slds.InsertClone(2, pres.Slides[1]);

    // 將已修改的簡報寫入磁碟
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **在另一個簡報的末端克隆投影片**
如果您需要從一個簡報克隆投影片並將其加入另一個簡報檔案的末端：

1. 建立包含來源投影片的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
1. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體，該簡報將接收克隆的投影片。  
1. 透過參考目標簡報的 Presentation 物件所公開的 **Slides** 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。  
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，並將來源簡報的投影片作為參數傳遞給該方法。  
1. 寫入已修改的目標簡報檔案。

在下列範例中，我們將來源簡報第一個索引的投影片克隆至目標簡報的末端。

```c#
// 實例化 Presentation 類別以載入來源簡報檔案
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆的位置）
    using (Presentation destPres = new Presentation())
    {
        // 將來源簡報中所需的投影片克隆至目標簡報投影片集合的末端
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 將目標簡報寫入磁碟
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **在另一個簡報的其他位置克隆投影片**
如果您需要從一個簡報克隆投影片並在另一個簡報檔案的特定位置使用它：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
1. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
1. 透過參考目標簡報的 Presentation 物件所公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。  
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，並將來源簡報的投影片與期望的位置作為參數傳遞給該方法。  
1. 寫入已修改的目標簡報檔案。

在下列範例中，我們將來源簡報的索引 0 的投影片克隆至目標簡報的索引 1（位置 2）。

```c#
// 實例化 Presentation 類別以載入來源簡報檔案
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆的位置）
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 將目標簡報寫入磁碟
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **在另一個簡報的特定位置克隆帶有母片的投影片**
如果您需要從一個簡報克隆帶有母片的投影片並在另一個簡報中使用，必須先將來源簡報的目標母片克隆至目標簡報，然後使用該母片來克隆投影片。**AddClone(ISlide, IMasterSlide)** 需要的是目標簡報中的母片，而不是來源簡報的母片。請依照以下步驟克隆帶母片的投影片：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
1. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。  
1. 取得要克隆的投影片及其母片。  
1. 透過參考目標簡報的 Presentation 物件所公開的 Masters 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection) 類別。  
1. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，將來源 PPTX 的母片作為參數傳遞。  
1. 透過參考目標簡報的 Presentation 物件所公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 類別。  
1. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法，將來源簡報的投影片與剛才克隆的母片作為參數傳遞。  
1. 寫入已修改的目標簡報檔案。

在下列範例中，我們將來源簡報零索引的投影片（帶有母片）克隆至目標簡報的末端，使用來源投影片的母片。

```c#
// 實例化 Presentation 類別以載入來源簡報檔案

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 實例化用於目標簡報的 Presentation 類別（投影片將被克隆的位置）
    using (Presentation destPres = new Presentation())
    {

        // 從來源簡報的投影片集合中實例化 ISlide，並同時取得
        // 母片
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 將來源簡報中所需的母片克隆至目標簡報的母片集合中
        // （Destination presentation）
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 將來源簡報中所需的母片克隆至目標簡報的母片集合中
        // （Destination presentation）
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 從來源簡報中以所需的母片將投影片克隆至目標簡報投影片集合的末端
        // （Collection of slides in the destination presentation）
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 將來源簡報中所需的母片克隆至目標簡報的母片集合中 // Destination presentation
        // 將目標簡報寫入磁碟
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **在指定章節的末端克隆投影片**

使用 Aspose.Slides for .NET，您可以從簡報的一個章節克隆投影片，並將該投影片插入同一簡報的另一個章節。此情況下，必須使用來自 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection) 介面的 [AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/methods/addclone/index) 方法。

以下 C# 程式碼示範如何克隆投影片並將克隆的投影片插入指定章節：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // 用於克隆
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**會一起克隆講者備註和審閱者評論嗎？**

會。備註頁與審閱評論都會包含在克隆中。如果不需要，請在插入後 [移除它們](/slides/zh-hant/net/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式以及嵌入的資料皆會被複製。若圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE 物件](/slides/zh-hant/net/manage-ole/) 形式保留。搬移檔案後，請確認資料可用性並重新整理。

**我能控制克隆的插入位置與章節嗎？**

可以。您可以在指定的投影片索引插入克隆，並將其放入選定的 [章節](/slides/zh-hant/net/slide-section/)。若目標章節不存在，請先建立章節，然後再將投影片移入其中。