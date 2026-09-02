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
description: "使用 Aspose.Slides for Android 複製 PowerPoint 投影片。遵循我們清晰的 Java 程式碼範例，於數秒內自動化 PPT 建立，省去手動操作。"
---
## **簡介**

克隆是製作某物的完全相同副本或複製品的過程。Aspose.Slides for Android via Java 也可以對任何投影片製作副本或克隆，然後將該克隆投影片插入當前或其他已開啟的簡報。投影片克隆的過程會產生一個新投影片，開發人員可以在不更改原始投影片的情況下對其進行修改。克隆投影片有多種可能的方式：

- 在演示文稿內的末尾進行克隆。
- 在演示文稿內的其他位置進行克隆。
- 在另一份演示文稿的末尾進行克隆。
- 在另一份演示文稿的其他位置進行克隆。
- 在另一份演示文稿的特定位置進行克隆。

在 Aspose.Slides for Android via Java 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件公開的 (一個由 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlide) 物件組成的集合) 提供 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以執行上述各種投影片克隆。

## **在簡報結尾克隆投影片**
如果您想克隆投影片，然後在同一簡報檔案的現有投影片之後使用它，請依照下列步驟使用 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 類別。  
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，並將欲克隆的投影片作為參數傳遞給該方法。  
4. 寫入已修改的簡報檔案。

在下方範例中，我們將第一個位置（索引為零）的投影片克隆至簡報的結尾。

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 將所需的投影片克隆至同一簡報中投影片集合的末尾
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 將修改後的簡報寫入磁碟
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在簡報內的其他位置克隆投影片**
如果您想克隆投影片，然後在同一簡報檔案的不同位置使用它，請使用 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 物件公開的 **Slides** 集合，實例化該類別。  
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，將欲克隆的投影片以及新位置的索引作為參數傳遞給該方法。  
4. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們將位於索引 1（第 2 個位置）的投影片克隆至索引 2（第 3 個位置）。

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 取得同一簡報中的投影片集合
    ISlideCollection slds = pres.getSlides();

    // 將所需的投影片克隆至同一簡報中的指定索引
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 將修改後的簡報寫入磁碟
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一份簡報的結尾克隆投影片**
如果您需要從一個簡報克隆投影片，再將其加入另一份簡報檔案的末尾：

1. 建立包含來源簡報（要克隆投影片的簡報）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。  
2. 建立包含目標簡報（要加入克隆投影片的簡報）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。  
3. 透過參考目標簡報的 **Slides** 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection) 類別。  
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，將來源簡報的投影片作為參數傳遞給該方法。  
5. 寫入已修改的目標簡報檔案。

在下方範例中，我們將來源簡報第一個索引的投影片克隆至目標簡報的結尾。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化 Destination PPTX 的 Presentation 類別（投影片將被克隆的目標）
    Presentation destPres = new Presentation();
    try {
        // 從來源簡報克隆所需的投影片至目標簡報的投影片集合末端
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

## **在另一份簡報的其他位置克隆投影片**
如果您需要從一個簡報克隆投影片，並在另一份簡報的特定位置使用它：

1. 建立包含來源簡報（要克隆投影片的簡報）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。  
2. 建立包含目標簡報（要加入克隆投影片的簡報）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。  
3. 透過參考目標簡報的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 類別。  
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，將來源簡報的投影片與期望的位置作為參數傳遞給該方法。  
5. 寫入已修改的目標簡報檔案。

在下方範例中，我們將來源簡報的零索引投影片克隆至目標簡報的索引 1（第 2 個位置）。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化 Presentation 類別以作為目標 PPTX（投影片將被克隆的地方）
    Presentation destPres = new Presentation();
    try {
        // 從來源簡報克隆所需的投影片至目標簡報的指定索引位置
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

## **在另一份簡報的特定位置克隆帶有母片的投影片**
如果您需要從一個簡報克隆包含母片的投影片並在另一份簡報中使用，必須先將來源簡報的目標母片克隆至目標簡報，然後使用該母片來克隆投影片。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 需要目標簡報的母片，而非來源簡報的母片。請依照以下步驟進行帶母片的投影片克隆：

1. 建立包含來源簡報（要克隆投影片的簡報）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。  
2. 建立包含目標簡報（要克隆投影片的簡報）的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別實例。  
3. 取得欲克隆的投影片及其母片。  
4. 透過參考目標簡報的 Masters 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMasterSlideCollection) 類別。  
5. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMasterSlideCollection) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，將來源 PPTX 的母片作為參數傳遞，以便在目標簡報中建立對應的母片。  
6. 透過參考目標簡報的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 類別。  
7. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，將來源簡報的投影片與剛才克隆的母片作為參數傳遞。  
8. 寫入已修改的目標簡報檔案。

在下方範例中，我們將來源簡報零索引的帶母片投影片克隆至目標簡報的結尾，使用了來源投影片的母片。

```java
import com.aspose.slides.*;

// 實例化 Presentation 類別以載入來源簡報檔案
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 實例化 Presentation 類別作為目標簡報（投影片將被克隆的地方）
    Presentation destPres = new Presentation();
    try {
        // 從來源簡報的投影片集合中實例化 ISlide，並同時取得
        // 母片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 從來源簡報克隆所需的母片至目標簡報的母片集合中
        // 目標簡報
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 從來源簡報克隆所需的投影片（搭配所需的母片）至
        // 目標簡報投影片集合的末端
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

## **在指定章節的結尾克隆投影片**
如果您想克隆投影片，然後在同一簡報檔案的不同章節使用，請使用由 [**ISlideCollection**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection) 介面公開的 [**addClone**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for Android via Java 允許從第一章節克隆投影片，然後將該克隆投影片插入同一簡報的第二章節。

以下程式碼片段示範如何克隆投影片並將克隆的投影片插入指定章節。

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

在將投影片克隆至另一份簡報時，請確保目標簡報的投影片尺寸與來源簡報相同。若尺寸不同，Aspose.Slides 不會自動重新縮放克隆的圖形——它們的原始座標與尺寸會被保留，可能導致內容顯示位置錯位或超出投影片邊界。

您可以在克隆母片與投影片之前，先將目標簡報的投影片尺寸設定為與來源相同：

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

在克隆母片與投影片之前執行此操作。

## **常見問題**  

**演講者備註和審閱者評論會被克隆嗎？**  

是的。備註頁面和審閱評論會包含在克隆中。如果不需要它們，請在插入後 [將它們移除](/slides/zh-hant/androidjava/presentation-notes/)。

**圖表及其資料來源如何處理？**  

圖表物件、格式以及內嵌資料都會被複製。如果圖表連結至外部來源（例如 OLE 嵌入的工作簿），該連結會以 [OLE 物件](/slides/zh-hant/androidjava/manage-ole/) 形式保留。移動檔案後，請確認資料可用性並檢查刷新行為。

**我可以控制克隆的插入位置和章節嗎？**  

可以。您可以在特定投影片索引插入克隆，並將其放入選擇的 [章節](/slides/zh-hant/androidjava/slide-section/)。如果目標章節不存在，請先建立章節，然後再將投影片移入其中。