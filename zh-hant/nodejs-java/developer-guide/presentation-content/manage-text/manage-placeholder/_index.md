---
title: 在 JavaScript 中管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js（透過 Java）檢查與編輯文字、圖片、圖表和內容佔位符，並理解佔位符的繼承關係。"
---
## **概覽**

佔位符是一種形狀，用於在簡報範本中保留特定類型內容的位置。常見的例子包括標題、內文、圖片、圖表以及通用內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片投影片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [Shape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getPlaceholder) 方法公開佔位符資訊。該方法會傳回 [Placeholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholder/) 物件，或對於一般形狀傳回 `null`。使用 [Placeholder.getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholder/#getType) 以判斷佔位符預計容納的內容類型。

即便已知佔位符類型，形狀類別仍然重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 代表。
- 已填入圖片的佔位符可以用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 代表。
- 已填入圖表的佔位符可以用 [Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/) 代表。
- 內容佔位符可能包含多種內容。請同時檢查 [Placeholder.getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholder/#getType) 與執行階段的形狀類別，而不要假設每個佔位符都是 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholder/#getType) 只描述佔位符的角色；它並不保證形狀的執行階段類型。存取文字、圖片、圖表、表格或媒體相關成員之前，請務必先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片投影片定義可重複使用的樣式，並在某些情況下提供母片層級的佔位符。  
2. 版面投影片定義供一個或多個普通投影片使用的版面配置，且可從母片繼承。  
3. 普通投影片包含該投影片的佔位符，並可從其版面繼承。

呼叫 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 可向上移動一層。投影片佔位符通常傳回其版面佔位符；版面佔位符則可傳回其母片佔位符。當形狀沒有基礎佔位符時，該方法傳回 `null`。

以下範例列出第一張投影片的佔位符，並回報它們的基礎佔位符：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

編輯普通投影片上的佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響仍在繼承該設定的所有投影片。本機普通形狀沒有基礎佔位符，僅因佔據相同座標而不會開始繼承。

## **變更佔位符中的文字**

標題、居中標題、副標題、內文與文字佔位符通常支援文字。使用前先檢查是否為 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)，再呼叫其 [getTextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/#getTextFrame) 方法。

以下範例更新第一張投影片的第一個標題佔位符，並保存結果：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此模式避免將圖片、圖表、表格或媒體佔位符誤當作 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 物件處理，同時透過目的而非脆弱的形狀索引辨識佔位符。

## **在版面上設定提示文字**

提示文字是空佔位符中顯示的設計時說明，例如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是透過普通投影片的形狀集合去取得。可透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getLayoutSlide) 取得版面，並遍歷 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getShapes) 回傳的集合。

以下範例變更第一張投影片所使用版面的標題與副標題提示文字：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

提示文字並非普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位符中顯示。當使用者或程式提供真實內容後，提示文字即不再顯示。變更提示文字也不會取代已使用該版面的投影片上已有的文字。

## **更新圖片佔位符**

需處理兩種情況：

- 若圖片佔位符已被填入，且以 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 表示，請透過 [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)、[PictureFillFormat.getPicture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#getPicture) 與 [Picture.setImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picture/#setImage) 取代圖像。  
- 若仍為空佔位符，請使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) 在佔位符座標加入圖片框，並移除空佔位符。

以下範例同時支援兩種情況，並保存簡報：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對空佔位符所產生的取代物是一個本機圖片框，而非新佔位符，因為 [Shape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getPlaceholder) 沒有提供設定子。它保留了保留位置，但不再繼承佔位符的行為。如果必須保留佔位符關係，請先在 PowerPoint 中準備並填入佔位符，然後再以 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/)。

關於影像透明度、裁切及其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/nodejs-java/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符的中繼資料。

## **處理圖表與內容佔位符**

已填入的圖表佔位符可以用 [Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/) 代表。以下範例同時依佔位符類型與執行階段類別尋找圖表，變更其標題，並保存檔案：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

一般內容佔位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholdertype/#Object)。在 PowerPoint 中，它充當多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填入後，請檢查實際形狀類別以了解其內容。特定版面亦可曝露 [PlaceholderType.Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholdertype/#Media) 或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholdertype/#Diagram)。

Aspose.Slides 不會僅透過變更 [Placeholder.getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholder/#getType) 就把空的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 佔位符轉換為 [Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/)；類型無法直接變更。若要以程式方式填入空圖表或內容區域，請在佔位符座標加入所需物件，然後移除空佔位符。以下範例示範對圖表的操作：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

新增的圖表是一個普通本機圖表。它佔據了佔位符的區域，但不會繼承自版面佔位符。當需要替換其類別、序列或工作簿資料時，請參考專門的 [chart management articles](/slides/zh-hant/nodejs-java/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例開啟範本、在第一張投影片搜尋標題或圖片佔位符、檢查佔位符與形狀類型、更新相應內容，最後儲存輸出。此範例刻意避免假設形狀索引或將每個佔位符視為相同類別。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題集**

**什麼是基礎佔位符？**

基礎佔位符是版面或母片上對應的形狀，其他佔位符會從它繼承。使用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 取得它。普通本機形狀會傳回 `null`，因為它不屬於佔位符層級。

**我可以透過編輯版面佔位符一次更改所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但實際的標題內容儲存在普通投影片上。若要替換整份簡報的標題文字，必須遍歷投影片並逐一更新每個標題佔位符。

**如何管理日期、投影片編號、頁眉與頁腳佔位符？**

請在相應的投影片、版面、母片、備註頁或講義範圍使用頁眉頁腳管理器。詳情請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/nodejs-java/presentation-header-and-footer/) 以取得完整範例。