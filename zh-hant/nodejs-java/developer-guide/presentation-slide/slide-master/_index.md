---
title: 管理 JavaScript 中的簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 70
url: /zh-hant/nodejs-java/slide-master/
keywords:
- 投影片母片
- 母片投影片
- PPT 母片投影片
- 多個母片投影片
- 比較母片投影片
- 背景
- 佔位符
- 複製母片投影片
- 複製母片投影片
- 重製母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中管理投影片母片：存取、編輯、克隆、比較及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概觀**

**投影片母片** 定義一組投影片的共用設計設定。它可以包含共用圖形、標誌、背景、文字樣式、主題設定以及頁腳設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常用方法，無需在每一張投影片上重複相同的格式設定。

Aspose.Slides for Node.js via Java 支援相同的模型。簡報可以包含一個或多個母片，而且每個母片可以包含多個版面投影片。一般投影片通常不直接參照母片。相反地，一般投影片使用版面投影片，而該版面投影片屬於某個母片。

層級結構如下：

1. **投影片母片** - 定義共用的設計與主題。  
1. **版面投影片** - 定義佔位符的具體排列以及版面層級的格式設定。  
1. **一般投影片** - 包含實際的簡報內容，並使用一個版面投影片。  

![投影片母片、版面投影片與一般投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) 類別表示。簡報中的所有母片可透過 `Presentation.getMasters()` 集合存取。

{{% alert color="info" title="Inheritance" %}}
當相同屬性在多個層級中皆有定義時，以較具體的層級為準。例如，若母片與版面投影片都定義了背景，則基於該版面的投影片會使用版面的背景。欲取得關於版面投影片的更多資訊，請參閱 [Apply or Change Slide Layouts](/nodejs-java/slide-layout/)。  
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint 檢視標籤上的投影片母片指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合來存取母片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

您也可以透過一般投影片的版面取得其使用的母片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **投影片母片包含什麼**

母片是一種類似投影片的物件。它從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/) 繼承共用投影片行為，因而提供與一般投影片與版面投影片相同的許多投影片屬性。母片專屬的成員列於 [MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `getBackground()` | 設定母片層級的投影片背景。 |
| `getShapes()` | 儲存放置於母片上的圖形，如標誌、圖片框與共用文字。 |
| `getLayoutSlides()` | 儲存屬於該母片的版面投影片。 |
| `getThemeManager()` | 提供存取母片主題 API 的功能。 |
| `getHeaderFooterManager()` | 控制母片及其子版面的頁首、頁腳、日期和投影片編號。 |
| `getDependingSlides()` | 回傳透過版面依賴該母片的一般投影片。 |

## **將影像新增至投影片母片**

當您將影像新增至母片時，使用該母片版面的投影片都會顯示此影像。這對於標誌、水印、裝飾帶以及其他重複出現的視覺元素相當有用。

以下範例將標誌新增至第一個母片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

欲取得關於圖片框的更多資訊，請參閱 [Picture Frame](/nodejs-java/picture-frame/)。

## **使用佔位符**

佔位符通常在版面投影片上定義。母片提供共用的樣式與主題，讓這些版面繼承；每個版面則決定哪些佔位符可用以及它們的放置位置。

在 PowerPoint 中，佔位符指令可在投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的插入佔位符指令](slide-master_5.png)

若要使用 Aspose.Slides 新增佔位符，請操作屬於母片的版面投影片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以格式化已存在於母片上的佔位符圖形。以下範例找出標題佔位符並套用線性漸層填色：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![已格式化的標題佔位符，會由一般投影片繼承](slide-master_8.png)

欲取得更多佔位符與文字格式設定選項，請參閱 [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) 與 [Text Formatting](/nodejs-java/text-formatting/)。

## **變更投影片母片背景**

母片的背景會被未覆寫的版面與投影片繼承。以下範例為第一個母片設定純色背景：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相關主題請參閱 [Presentation Background](/nodejs-java/presentation-background/) 與 [Presentation Theme](/nodejs-java/presentation-theme/)。

## **將投影片母片克隆至其他簡報**

使用 `MasterSlideCollection.addClone` 將母片複製到其他簡報中。複製的母片即可在目標簡報的版面與投影片中使用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

若需要同時克隆含母片的一般投影片，請參閱 [Clone Slides](/nodejs-java/clone-slides/)。

## **新增多個投影片母片**

簡報可以包含多個母片。當不同章節需要不同的品牌、頁面結構或主題設定時，此功能非常有用。

![PowerPoint 用於插入與管理母片的指令](slide-master_9.jpg)

以下範例會克隆預設母片、為克隆版設定不同的背景、於該克隆母片下建立版面，並新增一張基於該版面的投影片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **比較投影片母片**

可使用繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/) 的 `equals` 方法比較母片。比較會檢查結構與靜態內容，例如圖形、文字、格式、動畫以及其他投影片設定。它不會比較唯一識別碼（如投影片 ID）或動態佔位符值（如當前日期）。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

欲取得更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/nodejs-java/compare-slides/)。

## **將投影片母片檢視設定為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/) 的 `setLastView` 方法可控制 PowerPoint 首次開啟的檢視。以下範例於投影片母片檢視中開啟簡報：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

更多檢視設定請參閱 [Save Presentation](/slides/zh-hant/nodejs-java/save-presentation/)。

## **移除未使用的投影片母片**

簡報有時會包含已不再被任何一般投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 `removeUnused` 從 `getMasters()` 集合中移除未使用的母片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以使用低程式碼的 `Compress.removeUnusedMasterSlides` 方法：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問與答**

### 投影片母片與版面投影片的差異是什麼？

投影片母片定義共用的設計設定，例如主題、背景、共用圖形與文字樣式。版面投影片屬於某個母片，並定義佔位符的特定排版。一般投影片使用版面投影片，因此同時繼承版面與母片的設定。

### 一個簡報可以包含多個投影片母片嗎？

可以。簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，可使用多個母片。

### 應該將佔位符新增至母片還是版面投影片？

大多數情況下，應將佔位符新增至版面投影片。將共用的視覺元素與格式放在母片上，然後在一般投影片會使用的版面上放置內容佔位符。

### 我可以刪除仍被使用的母片嗎？

不能。具有相依投影片的母片無法直接安全地刪除。必須先將那些投影片移至其他母片下的版面，或使用只會移除未被使用的母片的清理方法。