---
title: 在 JavaScript 中管理簡報投影片母片
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
- 占位符
- 複製母片投影片
- 拷貝母片投影片
- 重複母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中管理投影片母片：存取、編輯、複製、比較及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概述**

A **slide master** 定義一組投影片的共同設計設定。它可以包含共用圖形、標誌、背景、文字樣式、佈景主題設定和頁尾設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常見方式，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for Node.js via Java 支援相同的模型。簡報可以包含一個或多個母片，每個母片可以包含多個版面投影片。一般投影片通常不會直接參照母片，而是使用版面投影片，而該版面投影片屬於某個母片。

層級結構如下：

1. **Slide master** - 定義共享的設計與佈景主題。
2. **Layout slide** - 定義占位符的具體排列以及版面層級的格式設定。
3. **Normal slide** - 包含實際的簡報內容，使用一個版面投影片。

![母片、版面投影片與一般投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片以 [MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) 類別表示。簡報中的所有母片可透過 `Presentation.getMasters()` 集合取得。

{{% alert color="info" title="繼承" %}}

當相同屬性在多個層級定義時，較具體的層級會取得優先。例如，若母片與版面投影片皆定義背景，基於該版面的投影片會使用版面的背景。欲了解更多版面投影片資訊，請參考 [Apply or Change Slide Layouts](/nodejs-java/slide-layout/)。

{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **View** > **Slide Master** 開啟投影片母片檢視。

![PowerPoint 檢視索引標籤上的投影片母片指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合存取母片：

```javascript
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

## **投影片母片的內容**

母片是一種類似投影片的物件。它從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/) 繼承一般投影片行為，因此提供與一般投影片和版面投影片相同的許多屬性。母片專屬的成員列於 [MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `getBackground()` | 設定母片層級的投影片背景。 |
| `getShapes()` | 儲存放在母片上的圖形，如標誌、圖片框與共用文字。 |
| `getLayoutSlides()` | 儲存屬於該母片的版面投影片。 |
| `getThemeManager()` | 提供存取母片佈景主題 API。 |
| `getHeaderFooterManager()` | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| `getDependingSlides()` | 回傳透過版面依賴於該母片的一般投影片。 |

## **將影像新增至投影片母片**

將影像加入母片時，使用該母片版面的投影片皆會顯示該影像。這對於標誌、浮水印、裝飾條紋以及其他重複視覺元素非常有用。

以下示例將標誌新增至第一個母片：

```javascript
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

欲了解圖片框的更多資訊，請參考 [Picture Frame](/nodejs-java/picture-frame/)。

## **操作占位符**

占位符通常在版面投影片上定義。母片提供共用樣式與佈景主題，版面則決定哪些占位符可用以及其位置。

在 PowerPoint 中，占位符指令可在投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的插入占位符指令](slide-master_5.png)

若要在 Aspose.Slides 中新增占位符，請操作屬於母片的版面投影片：

```javascript
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

您也可以格式化已存在於母片上的占位符圖形。以下示例尋找標題占位符並套用線性漸層填色：

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![一般投影片繼承的已格式化標題占位符](slide-master_8.png)

欲取得更多占位符與文字格式化選項，請參考 [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) 與 [Text Formatting](/nodejs-java/text-formatting/)。

## **變更投影片母片的背景**

母片背景會被其版面與未覆寫背景的投影片繼承。以下示例將第一個母片的背景設定為純色：

```javascript
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

相關主題請參考 [Presentation Background](/nodejs-java/presentation-background/) 與 [Presentation Theme](/nodejs-java/presentation-theme/)。

## **將投影片母片複製至另一個簡報**

使用 `MasterSlideCollection.addClone` 可將母片複製到其他簡報。複製後的母片即可供目標簡報的版面與投影片使用。

```javascript
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

若需同時複製一般投影片及其母片，請參考 [Clone Slides](/nodejs-java/clone-slides/)。

## **新增多個投影片母片**

簡報可以包含多個母片。這在不同章節需要不同品牌識別、頁面結構或佈景主題設定時非常有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下示例複製預設母片、為複製品設定不同背景、在該複製母片下建立版面，並基於該版面新增投影片：

```javascript
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

母片可使用從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/) 繼承的 `equals` 方法進行比較。比較會檢查結構與靜態內容，如圖形、文字、格式、動畫與其他投影片設定。它不會比較唯一識別碼（如投影片 ID）或動態占位符值（如目前日期）。

```javascript
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

更多資訊請參考 [Compare Presentation Slides](/nodejs-java/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/viewproperties/) 的 `setLastView` 方法可控制 PowerPoint 首次開啟的檢視。以下示例在投影片母片檢視中開啟簡報：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

更多檢視設定請參考 [Save Presentation](/nodejs-java/save-presentation/)。

## **移除未使用的投影片母片**

簡報有時會包含不再被任何一般投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 `removeUnused` 於 `getMasters()` 集合中移除未使用的母片：

```javascript
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
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問與答**

**投影片母片與版面投影片有何不同？**

投影片母片定義共享的設計設定，如佈景主題、背景、共用圖形與文字樣式。版面投影片屬於母片，定義占位符的具體排列。一般投影片使用版面投影片，從版面與母片同時繼承設定。

**一個簡報可以包含多個投影片母片嗎？**

可以。簡報可包含多個投影片母片。當不同章節需要不同的視覺系統或品牌識別時，請使用多個母片。

**應該將占位符新增至母片還是版面投影片？**

大多數情況下，應將占位符新增至版面投影片。將共享的視覺元素與格式放在母片上，然後在一般投影片會使用的版面上放置內容占位符。

**可以刪除仍被使用的投影片母片嗎？**

不能。具有相依投影片的母片不能直接安全刪除。應先將那些投影片移至另一個母片的版面，或使用僅移除未使用母片的清理方法。