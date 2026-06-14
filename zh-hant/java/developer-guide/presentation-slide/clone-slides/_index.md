---
title: 在 Java 中克隆簡報投影片
linktitle: 克隆投影片
type: docs
weight: 35
url: /zh-hant/java/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 儲存投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 快速複製 PowerPoint 投影片。遵循我們清晰的程式碼範例，以在數秒內自動化 PPT 建立，消除手動操作。"
---
## **簡介**

複製（Cloning）是製作某物精確副本或複製的過程。Aspose.Slides for Java 也可以對任何投影片進行複製或克隆，然後將該克隆投影片插入當前或任何其他已開啟的簡報中。投影片克隆的過程會產生一個新投影片，開發人員可以對其進行修改，而不會更改原始投影片。有多種克隆投影片的方式：

- 在簡報內的結尾處克隆。
- 在簡報內的其他位置克隆。
- 在另一個簡報的結尾處克隆。
- 在另一個簡報的其他位置克隆。
- 在另一個簡報的特定位置克隆。

在 Aspose.Slides for Java 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件所公開的 (ISlide 物件集合) 提供 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 與 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以執行上述投影片克隆類型

## **在簡報的結尾處克隆投影片**
如果您想克隆投影片，並在同一簡報檔案的現有投影片結尾處使用它，請依照以下步驟使用 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過參考 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件所公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 類別。
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將要克隆的投影片作為參數傳遞給該方法。
4. 寫入已修改的簡報檔案。

在下列範例中，我們將投影片（位於簡報的第一個位置—零索引）克隆至簡報的結尾。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 將目標投影片克隆至同一簡報中投影片集合的末端
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 將已修改的簡報寫入磁碟
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在簡報內的其他位置克隆投影片**
如果您想克隆投影片，並在同一簡報檔案的不同位置使用它，請使用 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過參考 **[Slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--)** 集合，實例化該類別。
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件所公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，並將要克隆的投影片與新位置的索引一起作為參數傳遞給該方法。
4. 將修改後的簡報寫入為 PPTX 檔案。

在下列範例中，我們將投影片（位於零索引—位置 1—的投影片）克隆至索引 1—位置 2—的投影片。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 將目標投影片克隆至同一簡報中投影片集合的末端
    ISlideCollection slds = pres.getSlides();

    // 將目標投影片克隆至同一簡報中指定索引的位置
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 將已修改的簡報寫入磁碟
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一個簡報的結尾處克隆投影片**
如果您需要從一個簡報克隆投影片到另一個簡報檔案的結尾處：

1. 建立包含來源投影片的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。
3. 透過參考目標簡報的 **[Slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--)** 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection) 類別。
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將來源簡報的投影片作為參數傳遞給該方法。
5. 寫入已修改的目標簡報檔案。

在下列範例中，我們將投影片（來自來源簡報的第一個索引）克隆至目標簡報的結尾。

```java
// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆至此）
    Presentation destPres = new Presentation();
    try {
        // 將來源簡報的目標投影片克隆至目標簡報中投影片集合的末端
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 將目標簡報寫入磁碟
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一個簡報的其他位置克隆投影片**
如果您需要從一個簡報克隆投影片到另一個簡報檔案的特定位置：

1. 建立包含來源投影片的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。
3. 透過參考目標簡報的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 類別。
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件所公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，並將來源簡報的投影片與期望的位置一起作為參數傳遞給該方法。
5. 寫入已修改的目標簡報檔案。

在下列範例中，我們將投影片（來自來源簡報的零索引）克隆至目標簡報的索引 1（位置 2）。

```java
// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆至此）
    Presentation destPres = new Presentation();
    try {
        // 將來源簡報的目標投影片克隆至目標簡報中投影片集合的末端
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // 將目標簡報寫入磁碟
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一個簡報的特定位置克隆投影片**
如果您需要從一個簡報克隆投影片（含母投影片）到另一個簡報，必須先將來源簡報的目標母投影片克隆至目標簡報，然後使用該母投影片進行投影片克隆。方法 [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 期待的是目標簡報的母投影片，而非來源簡報的。請依照以下步驟克隆帶母投影片的投影片：

1. 建立包含來源投影片的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。
3. 取得要克隆的投影片及其母投影片。
4. 透過參考目標簡報的 **Masters** 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IMasterSlideCollection) 類別。
5. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IMasterSlideCollection) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，將來源 PPTX 的母投影片作為參數傳遞，以克隆母投影片。
6. 透過參考目標簡報的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 類別。
7. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件所公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，將來源投影片與已克隆的母投影片一起作為參數傳遞，以完成克隆。
8. 寫入已修改的目標簡報檔案。

在下列範例中，我們將帶有母投影片的投影片（位於來源簡報的零索引）克隆至目標簡報的結尾，使用來源投影片的母投影片。

```java
// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 實例化用於目標簡報的 Presentation 類別（投影片將被克隆至此）
    Presentation destPres = new Presentation();
    try {
        // 從來源簡報的投影片集合中實例化 ISlide，並同時取得
        // 母投影片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 從來源簡報克隆所需的母投影片至母投影片集合中
        // 目標簡報
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 從來源簡報克隆所需的母投影片至母投影片集合中
        // 目標簡報
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 從來源簡報以所需的母投影片克隆指定投影片至
        // 目標簡報的投影片集合末端
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 將目標簡報儲存至磁碟
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定節的結尾處克隆投影片**
如果您想在同一簡報的不同節中克隆投影片，請使用由 **[ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection)** 介面所公開的 [**addClone**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for Java 允許從第一節克隆投影片，然後將該克隆投影片插入同一簡報的第二節。

以下程式碼片段示範如何克隆投影片並將其插入指定節。

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// 將目標簡報寫入磁碟
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **常見問題**

**講者備註與審閱者評論會被克隆嗎？**

是的。備註頁與審閱評論會包含在克隆中。如果您不想保留它們，請[移除它們](/slides/zh-hant/java/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式以及內嵌資料都會被複製。如果圖表連結到外部來源（例如 OLE 嵌入的活頁簿），該連結會以[OLE 物件](/slides/zh-hant/java/manage-ole/)形式保留。移動檔案後，請確認資料可用性並刷新行為。

**我可以控制克隆的插入位置和節嗎？**

可以。您可以在特定投影片索引插入克隆，並將其放入選定的[節](/slides/zh-hant/java/slide-section/)。如果目標節不存在，請先建立該節，然後再將投影片移入其中。