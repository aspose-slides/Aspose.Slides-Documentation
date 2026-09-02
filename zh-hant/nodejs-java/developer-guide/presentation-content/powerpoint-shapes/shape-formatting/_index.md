---
title: 在 JavaScript 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/nodejs-java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填滿
- 圖案填滿
- 圖片填滿
- 紋理填滿
- 實色填滿
- 形狀透明度
- 黑白形狀呈現
- 灰階形狀呈現
- 旋轉形狀
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且全控制地設定 PPT、PPTX 和 ODP 檔案的填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增形狀。由於形狀由線條構成，您可以透過修改或套用效果於輪廓來設定其格式。除此之外，您亦可透過指定設定來控制形狀內部的填滿方式。

![格式形狀 PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java 提供的類別與方法，使您能使用 PowerPoint 中相同的選項來設定形狀的格式。

## **格式線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟說明此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定形狀的 [線條樣式](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linestyle/)。
5. 設定線條寬度。
6. 設定線條的 [虛線樣式](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linedashstyle/)。
7. 設定形狀的線條顏色。
8. 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 建立代表簡報檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個 Rectangle 類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // 移除矩形形狀的填滿。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 套用格式設定至矩形的線條。
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // 設定矩形線條的顏色。
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![簡報中已格式化的線條](formatted-lines.png)

## **套用草圖效果至形狀線條**

草圖效果會使形狀線條看起來像手繪。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 取得線條設定，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/lineformat/) 取得草圖設定，並使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sketchformat/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linesketchtype/) 列舉中選取值。

以下 JavaScript 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linesketchtype/) 效果、讀取明確指定的值，並使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linesketchtype/) 移除效果：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // 取得形狀的線條格式及其草圖格式。
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // 套用草圖效果。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // 讀取直接指派給形狀的草圖效果。
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // 移除草圖效果。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sketchformat/) 回傳的值代表直接指派給形狀的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/lineformat/) 取得繼承後的物件，對該物件呼叫 `getSketchFormat`，再呼叫其 `getSketchType` 方法。有效值會反映繼承解析後實際套用的格式：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **格式接合樣式**

以下是三種接合類型選項：

* Round（圓形）
* Miter（斜接）
* Bevel（斜面）

預設情況下，PowerPoint 在角度（例如形狀的角落）處連接兩條線時，使用 **Round** 設定。但如果您繪製的形狀具有銳角，可能會偏好 **Miter** 選項。

![投影片中的接合樣式](join-style-powerpoint.png)

以下 JavaScript 程式碼示範如圖所示的三個矩形分別使用 Miter、Bevel 和 Round 接合樣式建立：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增三個 Rectangle 類型的自動形狀。
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // 設定每個矩形形狀的填色。
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // 設定線條寬度。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 設定每個矩形線條的顏色。
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // 設定接合樣式。
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // 為每個矩形加入文字。
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **漸層填滿**

在 PowerPoint 中，漸層填滿是一種格式設定選項，允許您將連續的顏色混合套用於形狀。例如，您可以以逐漸淡入的方式將兩種或多種顏色混合。

以下是使用 Aspose.Slides 套用漸層填滿至形狀的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 為 `Gradient`。
5. 使用 [GradientFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/gradientformat/) 類別公開的漸層停止集合的 `add` 方法，依定義的位置加入您偏好的兩種顏色。
6. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何對橢圓套用漸層填滿效果：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個 Ellipse 類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 套用漸層格式至橢圓。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // 設定漸層方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // 新增兩個漸層停止點。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有漸層填滿的橢圓](gradient-fill.png)

## **圖案填滿**

在 PowerPoint 中，圖案填滿是一種格式設定選項，讓您可以將兩色的圖案（例如點、條紋、交叉或格子）套用於形狀。您可自行為圖案的前景色與背景色選擇自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可以將它們套用到形狀，以提升簡報的視覺效果。即使選取了預定義圖案，仍可指定圖案實際使用的顏色。

以下是使用 Aspose.Slides 套用圖案填滿至形狀的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 為 `Pattern`。
5. 從預定義選項中選取圖案樣式。
6. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/patternformat/#getBackColor--)。
7. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/patternformat/#getForeColor--)。
8. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何對矩形套用圖案填滿：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個 Rectangle 類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 將填充類型設定為 Pattern。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // 設定圖案樣式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // 設定圖案的背景色與前景色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有圖案填滿的矩形](pattern-fill.png)

## **圖片填滿**

在 PowerPoint 中，圖片填滿是一種格式設定選項，允許您將影像插入形狀內部，實質上將影像作為形狀的背景。

以下是使用 Aspose.Slides 將圖片填滿套用至形狀的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 為 `Picture`。
5. 設定圖片填滿模式為 `Tile`（或其他偏好模式）。
6. 從您要使用的圖檔建立 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 物件。
7. 將圖像傳遞給 `ISlidesPicture.setImage` 方法。
8. 將修改後的簡報儲存為 PPTX 檔案。

以下為「lotus.png」檔案的示例圖片：

![蓮花圖片](lotus.png)

以下 JavaScript 程式碼示範如何以圖片填滿形狀：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個 Rectangle 類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 將填充類型設定為 Picture。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 設定圖片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // 載入影像並將其加入簡報資源。
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // 設定圖片。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有圖片填滿的形狀](picture-fill.png)

### **將圖片平鋪為紋理**

如果想將平鋪的圖片設定為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填滿模式—`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪相對於形狀原點的水平偏移（單位為點）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪相對於形狀原點的垂直偏移（單位為點）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義水平縮放比例。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義垂直縮放比例。

以下程式碼示範如何加入帶有平鋪圖片填滿的矩形形狀，並設定平鋪選項：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let firstSlide = presentation.getSlides().get_Item(0);

    // 新增一個矩形自動形狀。
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // 將形狀的填充類型設定為 Picture。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 載入影像並將其加入簡報資源。
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 將影像指派給形狀。
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 設定圖片填充模式與平鋪屬性。
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![平鋪選項示例](tile-options.png)

## **實色填滿**

在 PowerPoint 中，實色填滿是一種格式設定選項，會以單一、均勻的顏色填滿形狀。此背景色不含任何漸層、紋理或圖案。

使用 Aspose.Slides 為形狀套用實色填滿的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 為 `Solid`。
5. 將您偏好的填充顏色指定給形狀。
6. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何在 PowerPoint 投影片的矩形上套用實色填滿：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個 Rectangle 類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Solid。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // 設定填充顏色。
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有實色填滿的形狀](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，對形狀套用實色、漸層、圖片或紋理填滿時，您也可以設定透明度等級，以控制填充的不透明程度。較高的透明度會使形狀更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填充顏色的 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 為 `Solid`。
5. 使用 `Color` 定義具透明度的顏色（alpha 成分控制透明度）。
6. 儲存簡報。

以下 JavaScript 程式碼示範如何為矩形套用透明填充顏色：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個實心矩形自動形狀。
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心形狀上方新增一個透明矩形自動形狀。
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明形狀示例](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 可讓您在 PowerPoint 簡報中旋轉形狀，這在需要特定對齊或設計需求時相當實用。

在投影片上旋轉形狀的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定形狀的旋轉屬性為所需角度。
5. 儲存簡報。

以下 JavaScript 程式碼示範如何將形狀旋轉 5 度：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個 Rectangle 類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 將形狀旋轉 5 度。
    shape.setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![形狀旋轉示例](shape-rotation.png)

## **新增 3D 倒角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 屬性，為形狀套用 3D 倒角效果。

為形狀新增 3D 倒角效果的步驟如下：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 以定義倒角設定。
5. 儲存簡報。

以下 JavaScript 程式碼示範如何為形狀套用 3D 倒角效果：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 建立代表簡報檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 在投影片上新增形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // 設定形狀的 ThreeDFormat 屬性。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![3D 倒角效果示例](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 屬性，為形狀套用 3D 旋轉效果。

套用 3D 旋轉效果的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
2. 取得指定索引的投影片參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/camera/#setCameraType) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/lightrig/#setLightType) 定義 3D 旋轉。
5. 儲存簡報。

以下 JavaScript 程式碼示範如何為形狀套用 3D 旋轉效果：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 建立 Presentation 類別的執行個體。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![3D 旋轉效果示例](3D-rotation-effect.png)

## **控制形狀的黑白顯示方式**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定在以黑白模式檢視或處理簡報時，單一形狀的呈現方式。此方法不會自行啟用黑白顯示，也不會在正常彩色模式下更改形狀的填充、線條或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/blackwhitemode/) 列舉中的值來選擇期望的行為。例如，`Automatic` 讓呈現應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階，`BlackWhite` 僅使用黑白，`Black` 與 `White` 強制單一顏色，`Color` 保留正常顏色，`Hidden` 在黑白模式下隱藏形狀，`NotDefined` 表示未指定形狀層級的模式。

以下 JavaScript 程式碼建立一個彩色形狀，並在黑白顯示模式下使其呈現為灰色：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // 保持橙色填充於彩色模式，但在黑白模式下以灰色呈現形狀。
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在正常彩色模式下，矩形保持橙色填充；在黑白顯示工作流程中，因其模式設為 `Gray`，會使用灰色呈現。如此可在保留完整彩色投影片的同時，為列印、預覽或其他遵循黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

以下 JavaScript 程式碼示範如何重設投影片格式，並將所有占位符形狀在 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) 上的位置、大小與格式恢復為預設設定：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // 重設投影片上在版面配置中具有占位符的每個形狀。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**形狀格式設定會影響最終簡報檔案大小嗎？**

影響極小。嵌入的圖片與媒體佔用大部分檔案空間，而形狀的顏色、效果、漸層等參數僅以中繼資料儲存，幾乎不會增加額外大小。

**如何偵測投影片中具有相同格式的形狀，以便將它們分組？**

比對每個形狀的關鍵格式屬性——填充、線條與效果設定。若所有對應值相同，則視為樣式相同，可在邏輯上將這些形狀分組，簡化後續樣式管理。

**我可以將自訂的形狀樣式集合儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例形狀存於模板投影片或 .POTX 模板檔。建立新簡報時，開啟此模板，複製需要的樣式形狀，並在需要的地方重新套用其格式。