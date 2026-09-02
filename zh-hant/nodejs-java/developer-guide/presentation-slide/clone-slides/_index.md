---
title: 在 JavaScript 中克隆簡報投影片
linktitle: 克隆投影片
type: docs
weight: 35
url: /zh-hant/nodejs-java/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 保存投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 快速複製 PowerPoint 投影片。遵循我們的程式範例，在數秒內自動化 PPT 建立，消除手動操作。"
---
## **簡介**

克隆是製作某物的完全相同副本或複製的過程。Aspose.Slides for Node.js via Java 也能讓您複製任何投影片，並將該克隆投影片插入目前或其他已開啟的簡報中。投影片克隆的過程會產生一個新投影片，開發人員可以對其進行修改，而不會更改原始投影片。克隆投影片有以下幾種方式：

- 在簡報中於末端克隆。
- 在簡報中於其他位置克隆。
- 在另一簡報的末端克隆。
- 在另一簡報的其他位置克隆。
- 在另一簡報的特定位置克隆。

在 Aspose.Slides for Node.js via Java 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件曝光的 (一個由 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide) 物件組成的集合) 提供 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法，以執行上述投影片克隆類型。

## **在簡報中於末端克隆**
如果您想克隆投影片，然後在同一簡報檔案的現有投影片末端使用它，請依下列步驟使用 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件曝光的 Slides 集合，實例化 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 類別。
3. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 物件曝光的 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，並將要克隆的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法。
4. 寫入已修改的簡報檔案。

以下範例示範，我們已將投影片（位於簡報的第一個位置—零索引）克隆至簡報的末端。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 將所需的投影片克隆至同一簡報中投影片集合的末端
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // 將已修改的簡報寫入磁碟
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在簡報中於其他位置克隆**
如果您想克隆投影片，然後在同一簡報檔案的不同位置使用它，請使用 [insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件曝光的 **Slides** 集合，實例化此類別。
3. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 物件曝光的 [insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法，並將要克隆的投影片以及新位置的索引作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法。
4. 將已修改的簡報寫成 PPTX 檔案。

以下範例示範，我們已將投影片（位於簡報的索引 1—位置 2）克隆至索引 2—位置 3。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 將所需的投影片克隆至同一簡報中投影片集合的末端
    var slds = pres.getSlides();
    // 將所需的投影片克隆至同一簡報中的指定索引
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 將已修改的簡報寫入磁碟
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一簡報的末端克隆**
如果您需要從一個簡報克隆投影片，並在另一簡報檔案的現有投影片末端使用它：

1. 建立包含要克隆投影片來源的簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 建立包含目標簡報之 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，以將投影片加入其中。
3. 透過參考目標簡報的 Presentation 物件所曝光的 **Slides** 集合，實例化 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection) 類別。
4. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 物件曝光的 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，並將來源簡報的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法。
5. 寫入已修改的目標簡報檔案。

以下範例示範，我們已將投影片（來源簡報的第一個索引）克隆至目標簡報的末端。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化 Presentation 類別以載入來源簡報檔案
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆至此）
    var destPres = new aspose.slides.Presentation();
    try {
        // 將來源簡報中所需的投影片克隆至目標簡報的投影片集合末端
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

## **在另一簡報的其他位置克隆**
如果您需要從一個簡報克隆投影片，並在另一簡報檔案的特定位置使用它：

1. 建立包含要克隆投影片來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別實例，以將投影片加入其中。
3. 透過參考目標簡報的 Presentation 物件所曝光的 Slides 集合，實例化 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 類別。
4. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 物件曝光的 [insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法，並將來源簡報的投影片以及所需位置作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法。
5. 寫入已修改的目標簡報檔案。

以下範例示範，我們已將投影片（來源簡報的零索引）克隆至目標簡報的索引 1（位置 2）。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化 Presentation 類別以載入來源簡報檔案
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 實例化用於目標 PPTX 的 Presentation 類別（投影片將被克隆至此）
    var destPres = new aspose.slides.Presentation();
    try {
        // 將來源簡報中所需的投影片克隆至目標簡報的投影片集合末端
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // 將目標簡報寫入磁碟
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一簡報的特定位置克隆**
如果您需要從一個簡報克隆帶有主題投影片的投影片，並在另一簡報中使用，必須先將來源簡報的目標主題投影片克隆至目標簡報。然後使用該主題投影片來克隆帶主題的投影片。 [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 會期望來自目標簡報的主題投影片，而非來源簡報。為了克隆帶有主題的投影片，請依照以下步驟進行：

1. 建立包含要克隆投影片來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別實例，以將投影片克隆至其中。
3. 取得要克隆的投影片及其主題投影片。
4. 透過參考目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件所曝光的 Masters 集合，實例化 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterSlideCollection) 類別。
5. 呼叫由 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterSlideCollection) 物件曝光的 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，並將來源 PPTX 的主題投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法。
6. 透過設定對目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 物件所曝光的 Slides 集合的參考，實例化 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 類別。
7. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 物件曝光的 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，並將來源簡報要克隆的投影片及主題投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法。
8. 寫入已修改的目標簡報檔案。

以下範例示範，我們已將帶有主題的投影片（位於來源簡報的零索引）使用來源投影片的主題克隆至目標簡報的末端。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化 Presentation 類別以載入來源簡報檔案
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 實例化用於目標簡報的 Presentation 類別（投影片將被克隆至此）
    var destPres = new aspose.slides.Presentation();
    try {
        // 從來源簡報的投影片集合中實例化 ISlide，並同時取得
        // 主題投影片
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 從來源簡報克隆所需的主題投影片至
        // 目標簡報的主題集合
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // 從來源簡報以所需的主題克隆所需的投影片至
        // 目標簡報的投影片集合的末端
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // 將目標簡報儲存至磁碟
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定區段的末端克隆**
如果您想克隆投影片，然後在同一簡報檔案的不同區段中使用它，請使用由 [**SlideCollection**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection) 類別所曝光的 [**addClone**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) 方法。Aspose.Slides for Node.js via Java 允許您從第一區段克隆投影片，並將該克隆投影片插入同一簡報的第二區段。

以下程式碼片段示範如何克隆投影片並將克隆的投影片插入指定區段。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 將目標簡報儲存至磁碟
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **確保投影片尺寸匹配**
在將投影片克隆至另一簡報時，請確保目標簡報的投影片尺寸與來源相同。如投影片尺寸不同，Aspose.Slides 不會自動重新調整克隆形狀的大小——其原始座標與尺寸會被保留，可能導致內容對齊不正確或超出投影片邊界。

您可以在克隆主題與投影片之前，將目標簡報的投影片尺寸設定為與來源相同：

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

請在克隆主題與投影片之前執行此操作。

## **FAQ**

**演講者備註和審閱者評論會被克隆嗎？**

是的。備註頁面與審閱評論會包含在克隆中。如果您不想保留它們，請在插入後 [移除它們](/slides/zh-hant/nodejs-java/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式設定與嵌入的資料皆會被複製。如果圖表連結到外部來源（例如 OLE 嵌入的活頁簿），此連結會以 [OLE 物件](/slides/zh-hant/nodejs-java/manage-ole/) 形式保留。檔案搬移後，請確認資料可用性以及重新整理行為。

**我可以控制克隆的插入位置與區段嗎？**

可以。您可以在特定的投影片索引插入克隆，並將其放入選定的 [區段](/slides/zh-hant/nodejs-java/slide-section/)。如果目標區段不存在，請先建立該區段，然後再將投影片移入其中。