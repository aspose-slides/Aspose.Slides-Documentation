---
title: 在 JavaScript 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/nodejs-java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 素描效果
- 素描形狀線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 形狀透明度
- 旋轉形狀
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中格式化 PowerPoint 形狀——精確且完整控制地為 PPT、PPTX 和 ODP 檔案設定填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增形狀。由於形狀是由線條組成，您可以透過修改或套用效果於其輪廓來格式化它們。此外，您還可以透過指定控制內部填充方式的設定來格式化形狀。

![PowerPoint 形狀格式化](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java 提供的類別與方法，讓您使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟說明了操作流程：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 設定形狀的 [線條樣式](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linedashstyle/)。
1. 設定形狀的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // 設定矩形形狀的填充顏色。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 套用矩形線條的格式化。
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

## **套用草圖效果於形狀線條**

草圖效果會讓形狀線條看起來像是手繪。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 取得線條設定，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/lineformat/) 取得草圖設定，並使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sketchformat/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linesketchtype/) 列舉中選取值。

以下 JavaScript 程式碼顯示如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linesketchtype/) 效果、讀取明確指定的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linesketchtype/) 移除效果：

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // 存取形狀的線條格式及其草圖格式。
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

[SketchFormat.getSketchType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sketchformat/) 回傳的值代表直接指派給形狀的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/lineformat/)，在回傳的物件上呼叫 `getSketchFormat`，再呼叫其 `getSketchType` 方法。有效值會反映繼承解析後實際套用的格式：

```js
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

## **格式化接合樣式**

以下是三種接合類型選項：

* 圓角
* 斜角
* 斜面

預設情況下，當 PowerPoint 在角度處（例如形狀的角落）連接兩條線時，會使用 **圓角** 設定。然而，若您繪製的是銳角形狀，可能會偏好 **斜角** 選項。

![簡報中的接合樣式](join-style-powerpoint.png)

以下 JavaScript 程式碼示範如何使用斜角、斜面、圓角接合設定建立上述圖片中的三個矩形：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增三個矩形類型的自動形狀。
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // 設定每個矩形形狀的填充顏色。
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

## **漸層填色**

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您將連續的顏色混合套用到形狀。例如，您可以以兩種或多種顏色的方式，使一種顏色逐漸淡入另一種顏色。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用由 [GradientFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/gradientformat/) 類別公開的漸層停止集合的 `add` 方法，加入兩個您偏好的顏色與其位置。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何為橢圓形套用漸層填色效果：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個橢圓形類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 為橢圓形套用漸層格式。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // 設定漸層的方向。
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

![漸層填色的橢圓形](gradient-fill.png)

## **圖案填色**

在 PowerPoint 中，圖案填色是一種格式化選項，可讓您將兩種顏色的圖案（如點、條紋、交叉陰影或格子）套用到形狀。您可以為圖案的前景色與背景色選擇自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可以將它們套用到形狀上以提升簡報的視覺效果。即使選取了預定義圖案，仍可指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/patternformat/#getBackColor--)。
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/patternformat/#getForeColor--)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何為矩形套用圖案填色：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為圖案。
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

![圖案填色的矩形](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在形狀內插入圖像，實際上將圖像作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填色模式設為 `Tile`（或其他您偏好的模式）。
1. 從欲使用的圖像建立 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 物件。
1. 將圖像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，其圖片如下：

![蓮花圖片](lotus.png)

以下 JavaScript 程式碼示範如何以圖片填充形狀：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 設定填充類型為圖片。
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

![圖片填色的形狀](picture-fill.png)

### **將圖片鋪排為紋理**

如果您想將圖片以平鋪方式作為紋理，並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填充模式，可為 `Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪圖案在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪圖案是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪圖案相對於形狀原點的水平偏移量（以點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪圖案相對於形狀原點的垂直偏移量（以點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義水平縮放比例。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義垂直縮放比例。

以下程式碼示範如何新增一個具有平鋪圖片填色的矩形形狀，並設定平鋪選項：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let firstSlide = presentation.getSlides().get_Item(0);

    // 新增一個矩形自動形狀。
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定形狀的填充類型為圖片。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 載入影像並將其加入簡報資源。
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 將影像指定給形狀。
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

![鋪排選項](tile-options.png)

## **純色填色**

在 PowerPoint 中，純色填色是一種格式化選項，會以單一均勻的顏色填滿形狀。此背景色不包含任何漸層、紋理或圖案。

若要使用 Aspose.Slides 為形狀套用純色填色，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Solid`。
1. 為形狀指定您偏好的填色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何在 PowerPoint 投影片中的矩形套用純色填色：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為純色。
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

![純色填色的形狀](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您為形狀套用純色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的不透明程度。較高的透明度值會使形狀更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色所使用顏色的 alpha 值來設定透明度。以下說明如何操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義具有透明度的顏色（alpha 成分控制透明度）。
1. 儲存簡報。

以下 JavaScript 程式碼示範如何為矩形套用透明填色：

```js
// 實例化表示簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個純色矩形自動形狀。
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 在純色形狀上方新增一個透明矩形自動形狀。
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

![透明形狀](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在需要特定對齊或設計需求的視覺元素定位時相當有用。

若要在投影片上旋轉形狀，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 將形狀的旋轉屬性設定為所需角度。
1. 儲存簡報。

以下 JavaScript 程式碼示範如何將形狀旋轉 5 度：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
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

![形狀旋轉](shape-rotation.png)

## **新增 3D 斜角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 屬性，為形狀套用 3D 斜角效果。

若要為形狀新增 3D 斜角效果，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 JavaScript 程式碼示範如何為形狀套用 3D 斜角效果：

```js
// 建立 Presentation 類別的實例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 在投影片上新增一個形狀。
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

![3D 斜角效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 屬性，為形狀套用 3D 旋轉效果。

若要對形狀套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/camera/#setCameraType) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/lightrig/#setLightType) 定義 3D 旋轉。
1. 儲存簡報。

以下 JavaScript 程式碼示範如何為形狀套用 3D 旋轉效果：

```js
// 建立 Presentation 類別的實例。
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

![3D 旋轉效果](3D-rotation-effect.png)

## **重設格式**

以下 Java 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) 上所有具佔位符的形狀之位置、大小與格式恢復為預設設定：

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // 重設投影片上在版面上具有占位符的每個形狀。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的圖像與媒體佔用大部分檔案空間，而形狀的顏色、效果與漸層等參數以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片中具有相同格式的形狀以便將它們分組？**

比較每個形狀的關鍵格式屬性──填色、線條與效果設定。若所有對應的值皆相同，則視為樣式相同，可在邏輯上將這些形狀分組，從而簡化後續的樣式管理。

**我可以將一組自訂形狀樣式儲存為單獨檔案以在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範例形狀存放於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式形狀，並在需要的地方重新套用其格式。