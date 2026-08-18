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
description: "使用 Aspose.Slides for Java 快速複製 PowerPoint 投影片。遵循我們清晰的程式碼範例，在秒內自動化 PPT 建立，省去手動操作。"
---
## **簡介**

克隆是製作某物完全相同的副本或複製的過程。Aspose.Slides for Java 也可以對任何投影片進行複製或克隆，然後將該克隆投影片插入目前或其他已開啟的簡報中。投影片克隆的過程會建立一個新投影片，開發人員可以對其進行修改，而不會更改原始投影片。克隆投影片有以下幾種可能的方式：

- 在簡報內的末端克隆。
- 在簡報內的其他位置克隆。
- 在另一簡報的末端克隆。
- 在另一簡報的其他位置克隆。
- 連同其母片一起克隆至另一簡報。

在 Aspose.Slides for Java，（由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件公開的 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 物件集合）提供 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以執行上述類型的投影片克隆

## **在簡報末端克隆投影片**
如果您想克隆投影片，然後在同一簡報檔案的末端使用它，請依照下列步驟使用 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 類別。  
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將欲克隆的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。  
4. 寫入已修改的簡報檔案。

在下方示例中，我們將位於簡報第一個位置（索引為 0）的投影片克隆至簡報的末端。

```java
import com.aspose.slides.*;

// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 將所需投影片克隆至同一簡報中投影片集合的末端
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 將已修改的簡報寫入磁碟
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在同一簡報內的其他位置克隆投影片**
如果您想克隆投影片，並在同一簡報檔案的不同位置使用它，請使用 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件公開的 **Slides** 集合，實例化該類別。  
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，並將欲克隆的投影片與新位置的索引一起作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。  
4. 將已修改的簡報寫入為 PPTX 檔案。

在下方示例中，我們將位於索引 1（位置 2）的投影片克隆至索引 2（位置 3）。

```java
import com.aspose.slides.*;

// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 取得簡報中的投影片集合
    ISlideCollection slds = pres.getSlides();

    // 將所需投影片克隆至同一簡報中指定的索引位置
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 將已修改的簡報寫入磁碟
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一簡報的末端克隆投影片**
如果您需要從一個簡報克隆投影片，並在另一簡報檔案的末端使用它：

1. 建立包含欲克隆投影片之來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。  
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例，以便將投影片加入其中。  
3. 透過參考目標簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件所公開的 **Slides** 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection) 類別。  
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將來源簡報中的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。  
5. 寫入已修改的目標簡報檔案。

在下方示例中，我們將來源簡報第一個索引的投影片克隆至目標簡報的末端。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化 Presentation 類別為目標 PPTX (where slide is to be cloned)
    Presentation destPres = new Presentation();
    try {
        // 將所需投影片從來源簡報克隆至目標簡報的投影片集合末端
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
如果您需要從一個簡報克隆投影片，並在另一簡報檔案的特定位置使用它：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。  
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。  
3. 透過參考目標簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件所公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 類別。  
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，並將來源簡報的投影片與欲插入的位置一起作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。  
5. 寫入已修改的目標簡報檔案。

在下方示例中，我們將來源簡報零索引的投影片克隆至目標簡報索引 1（位置 2）。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆的地方）
    Presentation destPres = new Presentation();
    try {
        // 將來源簡報中的指定投影片克隆至目標簡報的指定索引位置
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // 將目標簡報寫入磁碟
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一簡報中克隆帶有母片的投影片**
如果您需要將帶有母片的投影片從一個簡報克隆至另一簡報，必須先將來源簡報中所需的母片克隆至目標簡報，然後使用該母片來克隆投影片。[addClone(ISlide, IMasterSlide, boolean)] 方法會期望傳入目標簡報的母片而非來源簡報的母片。請遵循以下步驟來克隆帶母片的投影片：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。  
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別實例。  
3. 存取欲克隆的投影片及其母片。  
4. 透過參考目標簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件所公開的 Masters 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IMasterSlideCollection) 類別。  
5. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IMasterSlideCollection) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將來源 PPTX 中的母片作為參數傳遞給 [addClone] 方法。  
6. 透過設定對目標簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 物件所公開的 Slides 集合的參照，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 類別。  
7. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將來源簡報的投影片與母片作為參數傳遞給 [addClone] 方法。  
8. 寫入已修改的目標簡報檔案。

在下方示例中，我們將來源簡報零索引的帶母片投影片克隆至目標簡報的末端，使用來源投影片的母片。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 實例化用於目標簡報的 Presentation 類別（投影片將被克隆的地方）
    Presentation destPres = new Presentation();
    try {
        // 從來源簡報的投影片集合中實例化 ISlide，並且
        // 母片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 將所需的母片從來源簡報克隆至
        // 目標簡報的母片集合中
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // 將來源簡報中具備指定母片的所需投影片克隆至
        // 目標簡報的投影片集合末端
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // 將目標簡報儲存至磁碟
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定章節的末端克隆投影片**
如果您想克隆投影片，並在同一簡報檔案的不同章節使用它，請使用由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection) 介面公開的 [addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for Java 可以將第一章節的投影片克隆，然後將該克隆投影片插入同一簡報的第二章節。

以下程式碼片段示範如何克隆投影片並將克隆投影片插入指定章節。

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // 將目標簡報儲存至磁碟
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **確保投影片尺寸相符**

在將投影片克隆到另一簡報時，請確保目標簡報的投影片尺寸與來源相同。如果投影片尺寸不同，Aspose.Slides 不會自動重新縮放克隆的形狀——它們的原始座標和尺寸會被保留，可能導致內容對齊錯誤或超出投影片邊界。

您可以在克隆母片與投影片之前，先將目標簡報的投影片尺寸設定為與來源相同：

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

在克隆母片與投影片之前執行此操作。

## **常見問題**

**會克隆演講者備註和審閱者評論嗎？**

會。備註頁面和審閱評論都會包含在克隆中。如果不需要它們，請在插入後[刪除它們](/slides/zh-hant/java/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式以及嵌入的資料皆會被複製。如果圖表連結到外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE 物件](/slides/zh-hant/java/manage-ole/) 形式保留下來。移動檔案後，請確認資料可用性並檢查重新整理行為。

**我可以控制克隆的插入位置和章節嗎？**

可以。您可以在特定投影片索引插入克隆，並將其放入選擇的[章節](/slides/zh-hant/java/slide-section/)。如果目標章節不存在，請先建立，然後再將投影片移入該章節。