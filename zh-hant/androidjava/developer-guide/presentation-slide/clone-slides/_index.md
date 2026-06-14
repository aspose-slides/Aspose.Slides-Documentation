---
title: 在 Android 上克隆簡報投影片
linktitle: 克隆投影片
type: docs
weight: 35
url: /zh-hant/androidjava/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 儲存投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 複製 PowerPoint 投影片。遵循我們清晰的 Java 程式碼範例，讓您在數秒內自動化 PPT 的建立，免除手動操作。"
---
## **簡介**

克隆是製作某物精確副本或複製的過程。Aspose.Slides for Android via Java 也能夠對任何投影片製作副本或克隆，然後將該克隆投影片插入當前或任何其他已開啟的簡報。投影片克隆的過程會產生一個新的投影片，開發人員可以對其進行修改而不會更改原始投影片。克隆投影片有以下幾種可能方式：

- 在簡報中於結尾處克隆。
- 在簡報中於其他位置克隆。
- 在另一個簡報的結尾處克隆。
- 在另一個簡報的其他位置克隆。
- 在另一個簡報的特定位置克隆。

在 Aspose.Slides for Android via Java 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件所公開的 (一組 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlide) 物件) 提供了 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 與 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以執行上述投影片克隆類型

## **在簡報的結尾克隆投影片**
如果您想要克隆投影片，然後在同一個簡報檔案的現有投影片末端使用它，請依照下列步驟使用 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 類別。
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將要克隆的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
4. 寫入已修改的簡報檔案。

在以下範例中，我們將一張位於簡報第一個位置（索引為 0）的投影片克隆至簡報的結尾。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 將所需投影片克隆至同一簡報中投影片集合的末端
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 將修改後的簡報寫入磁碟
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在同一簡報內的其他位置克隆投影片**
如果您想要克隆投影片，然後在同一個簡報檔案的不同位置使用它，請使用 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件公開的 [**Slides**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，實例化該類別。
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，並將要克隆的投影片以及新位置的索引作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
4. 將已修改的簡報寫入為 PPTX 檔案。

在以下範例中，我們將一張位於簡報零索引（位置 1）的投影片克隆至索引 1（位置 2）。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 將所需投影片克隆至同一簡報中投影片集合的末端
    ISlideCollection slds = pres.getSlides();

    // 將所需投影片克隆至同一簡報中的指定索引位置
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 將修改後的簡報寫入磁碟
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一簡報的結尾克隆投影片**
如果您需要從一個簡報克隆投影片，並在另一個簡報檔案的現有投影片末端使用它：

1. 建立包含來源簡報（將從中克隆投影片）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報（投影片將被加入其中）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。
3. 透過參考目標簡報的 Presentation 物件所公開的 [**Slides**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection) 類別。
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將來源簡報的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
5. 寫入已修改的目標簡報檔案。

在以下範例中，我們將來源簡報的第一個索引的投影片克隆至目標簡報的結尾。

```java
// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆到此）
    Presentation destPres = new Presentation();
    try {
        // 將來源簡報中的目標投影片克隆至目標簡報投影片集合的末端
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

## **在另一簡報的其他位置克隆投影片**
如果您需要從一個簡報克隆投影片，並在另一個簡報檔案的特定位置使用它：

1. 建立包含來源簡報（將從中克隆投影片）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報（投影片將被加入其中）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。
3. 透過參考目標簡報的 Presentation 物件所公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 類別。
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，並將來源簡報的投影片以及所需位置作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
5. 寫入已修改的目標簡報檔案。

在以下範例中，我們將來源簡報零索引的投影片克隆至目標簡報的索引 1（位置 2）。

```java
// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆到此）
    Presentation destPres = new Presentation();
    try {
        // 將來源簡報中的目標投影片克隆至目標簡報投影片集合的末端
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

## **在另一簡報的特定位置克隆投影片**
如果您需要從一個簡報克隆帶有母片的投影片並在另一個簡報中使用，必須先將所需的母片從來源簡報克隆至目標簡報。然後使用該母片來克隆帶母片的投影片。 [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 期待的是目標簡報的母片而非來源簡報的母片。為了克隆帶母片的投影片，請依照以下步驟操作：

1. 建立包含來源簡報（將從中克隆投影片）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報（投影片將被克隆至其中）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。
3. 取得要克隆的投影片及其母片。
4. 透過參考目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件所公開的 Masters 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMasterSlideCollection) 類別。
5. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMasterSlideCollection) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將來源 PPTX 的母片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法以進行克隆。
6. 透過設定對目標簡報的 Slides 集合的參考，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 類別。
7. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將來源簡報的投影片以及母片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) 方法。
8. 寫入已修改的目標簡報檔案。

在以下範例中，我們將來源簡報零索引的帶母片投影片克隆至目標簡報的結尾，使用來源投影片的母片。

```java
// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 實例化用於目標簡報的 Presentation 類別（投影片將被克隆到此）
    Presentation destPres = new Presentation();
    try {
        // 從來源簡報的投影片集合中實例化 ISlide，並同時取得
        // 母片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 將來源簡報中所需的母片克隆至目標簡報的母片集合中
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 將來源簡報中所需的母片克隆至目標簡報的母片集合中
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 將來源簡報中帶有指定母片的目標投影片克隆至目標簡報投影片集合的末端
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 將目標簡報寫入磁碟
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定章節的結尾克隆投影片**
如果您想要克隆投影片，然後在同一個簡報檔案的不同章節使用它，請使用由 [**ISlideCollection**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection) 介面公開的 [**addClone**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for Android via Java 能夠從第一章節克隆投影片，然後將該克隆投影片插入同一簡報的第二章節。

以下程式碼片段示範如何克隆投影片並將克隆投影片插入指定章節。

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

**演講者備註與審閱者評論會被克隆嗎？**

是的。備註頁面和審閱意見會包含在克隆中。如果您不需要它們，請在插入後 [移除它們](/slides/zh-hant/androidjava/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式設定與嵌入的資料都會被複製。如果圖表鏈結到外部來源（例如 OLE 嵌入的活頁簿），則此鏈結會以 [OLE 物件](/manage-ole/) 的形式保留。檔案移動後，請確認資料可用性並檢查重新整理行為。

**我可以控制克隆的插入位置和章節嗎？**

可以。您可以在特定的投影片索引插入克隆，並將其放入選擇的 [章節](/slides/zh-hant/androidjava/slide-section/)。如果目標章節不存在，請先建立章節，再將投影片移入其中。