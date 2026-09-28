---
title: 在 JavaScript 中管理簡報投影片母版
linktitle: 投影片母版
type: docs
weight: 70
url: /zh-hant/nodejs-java/slide-master/
keywords:
- 投影片母版
- 母版投影片
- PPT 母版投影片
- 多個母版投影片
- 比較母版投影片
- 背景
- 佔位元件
- 複製母版投影片
- 複製母版投影片
- 重複母版投影片
- 未使用的母版投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中管理投影片母版：存取、編輯、複製、比較與移除 PowerPoint 與 OpenDocument 簡報中的母版投影片。"
---
## **概述**

**投影片母版** 定義一組投影片的共用設計設定。它可以包含共用圖形、商標、背景、文字樣式、佈景主題設定，以及頁尾設定。在 PowerPoint 中，編輯投影片母版是保持簡報一致性的常用方式，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for Node.js via Java 支援相同的模型。一個簡報可以包含一個或多個母版投影片，而每個母版投影片可以包含多個版面投影片。一般投影片通常不會直接參照母版投影片，而是使用版面投影片，而該版面投影片屬於某個母版投影片。

層級結構如下：

1. **投影片母版** ─ 定義共用的設計與佈景主題。  
1. **版面投影片** ─ 定義特定的佔位元件排列與版面層級格式。  
1. **一般投影片** ─ 含有實際的簡報內容，並使用一個版面投影片。

![母版投影片、版面投影片與一般投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母版由 [MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) 類別表示。簡報中所有母版投影片可透過 `Presentation.getMasters()` 集合取得。

{{% alert color="info" title="Inheritance" %}}
當同一屬性在多個層級中都有定義時，較具體的層級會優先。舉例來說，若母版投影片與版面投影片都定義了背景，基於該版面的投影片會使用版面的背景。關於版面投影片的更多資訊，請參閱 [Apply or Change Slide Layouts](/nodejs-java/slide-layout/)。
{{% /alert %}}

## **存取投影片母版**

在 PowerPoint 中，您可以從 **檢視** > **投影片母版** 開啟投影片母版檢視。

![PowerPoint 檢視索籤上的投影片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合存取母版投影片：

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

您也可以透過一般投影片的版面取得其所使用的母版投影片：

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

## **投影片母版的內容**

母版投影片是一種類似投影片的物件。它繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/)，因此會暴露許多一般投影片與版面投影片共用的屬性。母版專屬的成員請參閱 [MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) API 頁面。

常用的母版投影片成員包含：

| 成員 | 目的 |
| --- | --- |
| `getBackground()` | 設定母版層級的投影片背景。 |
| `getShapes()` | 儲存放置於母版上的圖形，例如商標、圖片框與共用文字。 |
| `getLayoutSlides()` | 儲存屬於該母版的版面投影片。 |
| `getThemeManager()` | 取得母版佈景主題 API。 |
| `getHeaderFooterManager()` | 控制母版及其子版面的頁首、頁尾、日期與投影片編號。 |
| `getDependingSlides()` | 取得透過版面依賴該母版的普通投影片。 |

## **將影像加入投影片母版**

將影像加入母版投影片後，使用該母版版面的投影片都會顯示該影像。這對於商標、水印、裝飾條帶等重複出現的視覺元素非常有用。

以下範例在第一個母版投影片上加入一個商標：

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

有關圖片框的更多資訊，請參閱 [Picture Frame](/nodejs-java/picture-frame/)。

## **控制母版圖形的可見性**

使用 [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) 可隱藏繼承自母版的圖形（例如商標或裝飾形狀），而不必從母版中刪除它們。在需要省略這些圖形的投影片上，對 [Slide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#setShowMasterShapes) 傳入 `false`，而在需要顯示的投影片上則保持 `true`。

以下自行完整的範例在母版上建立藍色裝飾條帶，並在兩張使用相同空白版面的投影片中分別顯示與隱藏該條帶。此範例不需要輸入簡報或影像。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此範例使用新簡報附帶的 **Blank** 版面，並移除初始投影片自帶的佔位元件。

### **選擇設定的範圍**

一般投影片透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getLayoutSlide) 與 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#getMasterSlide) 使用其母版。將屬性設定於單一投影片只會影響該投影片本身。將 `false` 傳給 [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) 會隱藏使用該共用版面的所有投影片的母版圖形，即使它們各自的設定為 `true`。若只想在單一投影片上隱藏圖形，請變更該投影片的屬性，保持共用版面不變。

此設定在母版投影片本身上不支援可見性控制。對母版而言，`getShowMasterShapes` 永遠回傳 `false`，而呼叫 `setShowMasterShapes(true)` 會拋出例外。請改在一般投影片或版面上套用。

### **將圖形與背景區分**

| 操作 | 效果 |
| --- | --- |
| 隱藏母版圖形 | 在不刪除圖形或變更投影片自身圖形的情況下，控制繼承自母版的形狀之可見性。 |
| 更改投影片背景填色 | 改變背景顏色、漸層或影像。母版圖形是獨立形狀，可保持在背景之上顯示。請參閱 [Presentation Background](/slides/zh-hant/nodejs-java/presentation-background/)。 |
| 從母版中刪除形狀 | 移除共用來源形狀，所有使用該母版的投影片將不再看到此形狀。 |

## **使用佔位元件**

佔位元件通常在版面投影片上定義。母版投影片提供版面繼承的共用樣式與佈景主題，而每個版面決定哪些佔位元件可用以及它們的放置位置。

在 PowerPoint 中，佔位元件指令可於投影片母版檢視中找到。

![PowerPoint 投影片母版檢視中的「插入佔位元件」指令](slide-master_5.png)

若要使用 Aspose.Slides 新增佔位元件，請操作屬於母版的版面投影片：

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

您也可以格式化已存在於母版投影片上的佔位元件形狀。以下範例尋找標題佔位元件並套用線性漸層填色：

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

![一般投影片繼承的已格式化標題佔位元件](slide-master_8.png)

欲取得更多佔位元件與文字格式設定選項，請參閱 [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) 與 [Text Formatting](/nodejs-java/text-formatting/)。

## **變更投影片母版背景**

母版背景會被版面與未覆寫背景的投影片繼承。以下範例為第一個母版投影片設定單色背景：

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

## **將投影片母版複製至其他簡報**

使用 `MasterSlideCollection.addClone` 可將母版投影片複製到另一個簡報。複製後的母版即可被目的簡報中的版面與投影片使用。

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

如果需要同時複製一般投影片及其母版，請參閱 [Clone Slides](/nodejs-java/clone-slides/)。

## **新增多個投影片母版**

簡報可以包含多個母版投影片。當不同章節需要不同的品牌、頁面結構或佈景主題設定時，這非常實用。

![PowerPoint 插入與管理母版投影片的指令](slide-master_9.jpg)

以下範例複製預設母版、為副本設定不同背景、在該複製母版下建立版面，最後依該版面新增投影片：

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

## **比較投影片母版**

母版投影片可使用繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/) 的 `equals` 方法進行比較。比較會檢查結構與靜態內容，例如形狀、文字、格式、動畫與其他投影片設定。它不會比較唯一識別碼（如投影片 ID）或動態佔位元件值（如目前日期）。

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

更多資訊請參閱 [Compare Presentation Slides](/slides/zh-hant/nodejs-java/compare-slides/)。

## **將投影片母版檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/) 的 `setLastView` 方法可控制 PowerPoint 開啟時的預設檢視。以下範例在投影片母版檢視中開啟簡報：

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

## **移除未使用的投影片母版**

簡報有時會包含已不再被任何一般投影片使用的母版。移除未使用的母版可減少檔案大小並簡化範本維護。

使用 `removeUnused` 可從 `getMasters()` 集合中移除未使用的母版：

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

## **常見問答**

**投影片母版與版面投影片有什麼差異？**

投影片母版定義共用的設計設定（如佈景主題、背景、共用圖形與文字樣式）。版面投影片屬於母版，定義特定的佔位元件排列。一般投影片使用版面投影片，因而同時繼承版面與母版的設定。

**一個簡報可以包含多個投影片母版嗎？**

可以。簡報可以包含多個投影片母版。當不同章節需要不同的視覺系統或品牌時，請使用多個母版。

**應該在母版投影片還是版面投影片上新增佔位元件？**

大多數情況下，應在版面投影片上新增佔位元件。將共用的視覺元素與共用格式放在母版上，然後在一般投影片會使用的版面上放置內容佔位元件。

**我可以刪除仍被使用的母版投影片嗎？**

不能。仍有相依投影片的母版不能直接安全刪除。請先將那些投影片移至另一個母版的版面，或使用僅移除未使用母版的清理方法。