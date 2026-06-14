---
title: 在 JavaScript 中克隆簡報投影片
linktitle: 克隆投影片
type: docs
weight: 35
url: /zh-hant/nodejs-java/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 儲存投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 快速複製 PowerPoint 投影片。遵循我們的程式碼範例，在數秒內自動化 PPT 建立，消除手動操作。"
---
## **簡介**

複製是將某物製作成完全相同的副本或複製品的過程。Aspose.Slides for Node.js via Java 也可以對任何投影片進行複製或克隆，然後將該克隆的投影片插入到目前的或其他已開啟的簡報中。投影片克隆的過程會建立一個新投影片，開發人員可以對其進行修改而不會更改原始投影片。克隆投影片有多種可能方式：

- 在簡報內的最後位置克隆。
- 在簡報內的其他位置克隆。
- 在另一個簡報的最後位置克隆。
- 在另一個簡報的其他位置克隆。
- 在另一個簡報的特定位置克隆。

在 Aspose.Slides for Node.js via Java 中，由 [Presentation] 物件所公開的 (一個由 [投影片] 物件組成的集合) 提供了 [addClone] 與 [insertClone] 方法，以執行上述類型的投影片克隆。

## **在簡報內的最後位置克隆**
如果您想克隆投影片並在同一簡報檔案中於現有投影片的最後位置使用它，請依照下列步驟使用 [addClone] 方法：

1. 建立 [Presentation] 類別的實例。
1. 透過參考由 [Presentation] 物件公開的 Slides 集合，實例化 [SlideCollection] 類別。
1. 呼叫由 [SlideCollection] 物件公開的 [addClone] 方法，並將欲克隆的投影片作為參數傳入 [addClone] 方法。
1. 寫入已修改的簡報檔案。

在下方的範例中，我們將投影片（位於簡報的第一個位置 - 零索引）克隆至簡報的最後。

```javascript
// 實例化代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 將指定的投影片克隆至同一簡報中投影片集合的末端
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // 將修改後的簡報寫入磁碟
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在簡報內的其他位置克隆**
如果您想克隆投影片並在同一簡報檔案的不同位置使用它，請使用 [insertClone] 方法：

1. 建立 [Presentation] 類別的實例。
1. 透過參考由 [Presentation] 物件公開的 **Slides** 集合，實例化該類別。
1. 呼叫由 [SlideCollection] 物件公開的 [insertClone] 方法，並將欲克隆的投影片以及新位置的索引作為參數傳入 [insertClone] 方法。
1. 將已修改的簡報寫入為 PPTX 檔案。

在下方的範例中，我們將投影片（位於零索引 – 位置 1 – 的簡報）克隆至索引 1 – 位置 2 – 的簡報。

```javascript
// 實例化代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 將指定的投影片克隆至同一簡報中投影片集合的末端
    var slds = pres.getSlides();
    // 將指定的投影片克隆至同一簡報中的指定索引位置
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 將修改後的簡報寫入磁碟
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一個簡報的最後位置克隆**
如果您需要從一個簡報克隆投影片並將其用於另一個簡報檔案的最後位置（即現有投影片的末端）：

1. 建立包含來源簡報（即要克隆投影片的簡報）的 [Presentation] 類別實例。
1. 建立包含目標簡報（即要加入投影片的簡報）的 [Presentation] 類別實例。
1. 透過參考目標簡報之 Presentation 物件所公開的 **Slides** 集合，實例化 [SlideCollection] 類別。
1. 呼叫由 [SlideCollection] 物件公開的 [addClone] 方法，並將來源簡報中的投影片作為參數傳入 [addClone] 方法。
1. 寫入已修改的目標簡報檔案。

在下方的範例中，我們將投影片（來自來源簡報的第一個索引）克隆至目標簡報的最後位置。

```javascript
// 實例化 Presentation 類別以載入來源簡報檔案
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化目標 PPTX 的 Presentation 類別（投影片將被克隆的地方）
    var destPres = new aspose.slides.Presentation();
    try {
        // 將來源簡報中的指定投影片克隆至目標簡報的投影片集合末端
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // 將目標簡報寫入磁碟
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一個簡報的其他位置克隆**
如果您需要從一個簡報克隆投影片並在另一個簡報檔案的特定位置使用它：

1. 建立包含來源簡報（即要克隆投影片的簡報）的 [Presentation] 類別實例。
1. 建立包含目標簡報（即要加入投影片的簡報）的 [Presentation] 類別實例。
1. 透過參考目標簡報之 Presentation 物件所公開的 Slides 集合，實例化 [SlideCollection] 類別。
1. 呼叫由 [SlideCollection] 物件公開的 [insertClone] 方法，並將來源簡報的投影片以及欲插入的位置作為參數傳入 [insertClone] 方法。
1. 寫入已修改的目標簡報檔案。

在下方的範例中，我們將投影片（來自來源簡報的零索引）克隆至目標簡報的索引 1（位置 2）。

```javascript
// 實例化 Presentation 類別以載入來源簡報檔案
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化目標 PPTX 的 Presentation 類別（投影片將被克隆的地方）
    var destPres = new aspose.slides.Presentation();
    try {
        // 將來源簡報中的指定投影片克隆至目標簡報的投影片集合末端
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // 將目標簡報寫入磁碟
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一個簡報的特定位置克隆**
如果您需要從一個簡報中克隆帶有母片的投影片並在另一個簡報中使用，必須先將來源簡報中所需的母片克隆至目標簡報，之後才能使用該母片來克隆帶母片的投影片。[**addClone(ISlide, IMasterSlide, boolean)**] 方法期望傳入目標簡報的母片，而非來源簡報的母片。為了克隆帶母片的投影片，請依照以下步驟操作：

1. 建立包含來源簡報（即要克隆投影片的簡報）的 [Presentation] 類別實例。
1. 建立包含目標簡報（即要克隆投影片至的簡報）的 [Presentation] 類別實例。
1. 取得欲克隆的投影片及其母片。
1. 透過參考目標簡報之 Presentation 物件所公開的 Masters 集合，實例化 [MasterSlideCollection] 類別。
1. 呼叫由 [MasterSlideCollection] 物件公開的 [addClone] 方法，並將來源 PPTX 中的母片作為參數傳入 [addClone] 方法。
1. 透過設定指向目標簡報之 Presentation 物件所公開的 Slides 集合的參考，實例化 [SlideCollection] 類別。
1. 呼叫由 [SlideCollection] 物件公開的 [addClone] 方法，並將來源簡報中的投影片以及母片作為參數傳入 [addClone] 方法。
1. 寫入已修改的目標簡報檔案。

在下方的範例中，我們將帶有母片的投影片（位於來源簡報的零索引）使用來源投影片的母片克隆至目標簡報的最後位置。

```javascript
// 實例化 Presentation 類別以載入來源簡報檔案
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 實例化目標簡報的 Presentation 類別（投影片將被克隆的地方）
    var destPres = new aspose.slides.Presentation();
    try {
        // 從來源簡報的投影片集合中實例化 ISlide，並取得
        // 母片
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 將來源簡報中需要的母片克隆至目標簡報的母片集合中
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 將來源簡報中需要的母片克隆至目標簡報的母片集合中
        var iSlide = masters.addClone(SourceMaster);
        // 將來源簡報的指定投影片連同所需母片克隆至目標簡報的投影片集合末端
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // 將目標簡報寫入磁碟
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定區段的最後位置克隆**
如果您想克隆投影片並在同一簡報檔案的不同區段中使用它，請使用由 [**SlideCollection**] 類別公開的 [**addClone**] 方法。Aspose.Slides for Node.js via Java 可以將第一區段的投影片克隆，然後將該克隆投影片插入同一簡報的第二區段。

以下程式碼片段示範如何克隆投影片並將克隆的投影片插入指定的區段。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 將目標簡報寫入磁碟
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **常見問題**

**演講者備註與審閱者評論會被克隆嗎？**

是的。備註頁面與審閱評論會包含在克隆中。如果您不需要它們，請在插入後[移除它們](/slides/zh-hant/nodejs-java/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式以及嵌入的資料皆會被複製。如果圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE 物件](/slides/zh-hant/nodejs-java/manage-ole/) 形式保留。檔案間移動後，請確認資料是否仍可用並檢查重新整理的行為。

**我可以控制克隆的插入位置和區段嗎？**

可以。您可以在特定投影片索引處插入克隆，並將其放入選擇的 [區段](/slides/zh-hant/nodejs-java/slide-section/)。如果目標區段不存在，請先建立該區段，然後再將投影片移入其中。