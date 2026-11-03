---
title: 在 JavaScript 中管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 影像佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js（透過 Java）檢查與編輯文字、圖片、圖表與內容佔位符，並理解佔位符的繼承機制。"
---
## **概述**

佔位符是一種形狀，用於在投影片範本中保留特定類型內容的位置。常見的範例包括標題、內文、圖片、圖表以及一般用途的內容佔位符。與普通形狀不同，佔位符可以從佈局投影片或母片繼承其位置、大小、格式設定以及其他屬性。

Aspose.Slides 透過 [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) 方法公開佔位符資訊。此方法會回傳一個 [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) 物件，若為普通形狀則回傳 `null`。使用 [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 可判斷佔位符預計容納的內容類型。

即使取得佔位符類型後，形狀類別仍然很重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 表示。
- 已填入圖片的佔位符可以以 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 表示。
- 已填入圖表的佔位符可以以 [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) 表示。
- 內容佔位符可能包含多種內容。請同時檢查 [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 與執行時的形狀類別，而不要假設所有佔位符皆為 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 說明佔位符的角色；但它無法保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體相關成員前，請先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成階層結構：

1. 母片定義可重複使用的樣式，並在某些情況下提供母片層級的佔位符。
2. 版面投影片定義供一或多張普通投影片使用的排列，且可繼承自母片。
3. 普通投影片包含該投影片的佔位符，並可繼承自其版面。

呼叫 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 可以向上移動一層。投影片佔位符通常回傳其版面佔位符；版面佔位符則可回傳其母片佔位符。若形狀沒有基礎佔位符，該方法會回傳 `null`。

以下範例列出第一張投影片上的佔位符，並報告它們的基礎佔位符：

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

在普通投影片上編輯佔位符會為該投影片建立或變更本地覆寫。編輯相關的版面或母片則可能影響仍繼承該設定的所有投影片。本地普通形狀沒有基礎佔位符，也不會僅因佔據相同座標而開始繼承。

## **移除佔位符狀態**

在調整範本時，使用 [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) 可將現有物件保留為普通形狀。其 [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) 方法會回傳 `null`，但形狀仍留在投影片的集合中。相較之下，[ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) 會將形狀從該集合中刪除。

以下範例需要一個至少包含一張投影片且第一張投影片上有非空文字佔位符的 `template.pptx`。使用從版面或母片繼承格式的佔位符，可觀察移除該關聯的效果。範例會檢查相同形狀仍然存在，再對現在的普通形狀再次呼叫該方法，最後保存結果。

{{% alert color="warning" title="Warning" %}}
移除佔位符狀態不會自動保留繼承的外觀設定。下列範例故意保留這些設定不變，可能導致輸出外觀不同。若位置與大小全部繼承，呼叫後可能會得到座標與尺寸為零的形狀，導致即使仍在集合中也不可見。
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // 在普通形狀上呼叫此方法不會產生任何效果。
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

對於符合條件的佔位符，所有三個檢查皆會印出 `true`。文字會保留下來，但繼承的定位、大小、旋轉、字型、段落對齊、文字框邊距、垂直錨點、填色與線條設定在移除佔位符關聯後可能會變更。例如，繼承的標題格式可能會退回一般文字格式。請參閱 [Slide Layout](/slides/zh-hant/nodejs-java/slide-layout/) 以取得更多版面相關資訊。

為了保留預期的外觀，請在呼叫前先取得解析後的位置、大小與旋轉，並將必要的有效格式值複製到獨立變數中。可透過 [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective)、[ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective)、[TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective)、[FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) 與 [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) 取得這些值。不要只保留有效格式物件，因為關聯移除後其文字格式值可能會改變。之後請將取得的值明確套用回普通形狀，包括字型族、大小、樣式、顏色、段落設定、文字框設定、填色與線條等。

繼承的形狀幾何也可能需要透過 [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) 明確設定。對於矩形文字佔位符，須指派 [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle)；僅還原填色與線條可能無法恢復可見的矩形。具備額外效果或更複雜格式的範本亦需同樣處理這些設定。

## **變更佔位符文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。使用前請先檢查是否為 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)，再呼叫其 [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) 方法。

以下範例更新第一張投影片上的第一個標題佔位符，並保存結果：

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

此模式可避免將圖片、圖表、表格或媒體佔位符當作 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 物件處理，同時也會以用途而非脆弱的形狀索引來辨識佔位符。

## **在版面設定提示文字**

提示文字是顯示於空佔位符中的設計階段指示，例如 *按一下以新增標題*。請於版面佔位符上設定自訂提示文字，而不是透過普通投影片的形狀集合來取得。可透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) 取得版面，然後遍歷 [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) 回傳的集合。

以下範例變更第一張投影片所用版面上的標題與副標題提示文字：

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

提示文字不是普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位符時顯示。一旦使用者或程式提供實際內容，提示文字即不再顯示。變更提示文字也不會取代已使用該版面的投影片上現有的文字。

## **更新圖片佔位符**

需處理兩種情況：

- 若圖片佔位符已被填入，且以 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 表示，請透過 [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)、[PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) 與 [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) 置換圖像。
- 若仍為空佔位符，請使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) 在佔位符座標加入圖片框，然後移除空佔位符。

以下範例同時支援這兩種情況，並保存簡報：

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

對於空佔位符所建立的替代品是一個本地圖片框，而非新佔位符，因為 [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) 未提供設定子。如需保留佔位符關聯，請先在 PowerPoint 中建立並填入佔位符，之後再以 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)。

有關影像透明度、裁切與其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/nodejs-java/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符的中繼資料。

## **處理圖表與內容佔位符**

已填入的圖表佔位符可由 [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) 表示。以下範例同時依佔位符類型與執行時類別搜尋此類圖表，變更其標題，然後保存檔案：

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

一般內容佔位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object)。在 PowerPoint 中，它充當多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填入後，請檢查實際的形狀類別以了解其內容。特化版面亦可能暴露 [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) 或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram)。

Aspose.Slides 不會僅透過變更 [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 就將空的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 佔位符轉換為 [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)；類型無法透過物件變更。若需以程式方式填入空的圖表或內容區域，請在佔位符座標加入所需物件，然後移除空佔位符。以下範例示範如何為圖表執行此動作：

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

新增的圖表是普通的本地圖表。它會佔據佔位符的區域，但不會從版面佔位符繼承。當需要取代圖表的類別、系列或工作簿資料時，請參考專門的 [chart management articles](/slides/zh-hant/nodejs-java/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例會開啟一個範本，搜尋第一張投影片的標題或圖片佔位符，檢查佔位符與形狀類型，更新相應的內容，最後保存輸出。此範例刻意避免假設形狀索引或將所有佔位符視為相同類別。

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

## **FAQ**

**什麼是基礎佔位符？**

基礎佔位符是指版面或母片上對應的形狀，其他佔位符會從它繼承。請使用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 取得。普通本地形狀會回傳 `null`，因為它不屬於佔位符階層。

**我可以透過編輯版面佔位符來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但實際的標題內容儲存在普通投影片上。若要在整份簡報中取代真正的標題文字，需遍歷投影片並逐一更新標題佔位符。

**如何管理日期、投影片編號、頁首與頁尾佔位符？**

請在相應的投影片、版面、母片、備註或講義範圍內使用頁首與頁尾管理器。完整範例請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/nodejs-java/presentation-header-and-footer/)。