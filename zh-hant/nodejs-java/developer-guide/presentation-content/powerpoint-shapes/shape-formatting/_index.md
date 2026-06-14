---
title: 在 JavaScript 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/nodejs-java/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式化
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中格式化 PowerPoint 圖形——精確且完整地設定 PPT、PPTX 與 ODP 檔案的填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增圖形。由於圖形是由線條組成，您可以透過修改或套用效果來格式化其輪廓。除此之外，您也可以透過指定內部填充設定來格式化圖形。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java 提供類別與方法，讓您使用 PowerPoint 中相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明了整個程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // 設定矩形圖形的填充顏色。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 套用格式化至矩形的線條。
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

![The formatted lines in the presentation](formatted-lines.png)

## **格式化接合樣式**

以下是三種接合類型的選項：

* Round
* Miter
* Bevel

預設情況下，PowerPoint 在以角度（例如圖形的角落）連接兩條線時，會使用 **Round** 設定。但如果您在繪製具有尖銳角度的圖形，可能會較偏好 **Miter** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 JavaScript 程式碼示範如何使用 Miter、Bevel 與 Round 接合類型設定來建立上圖中顯示的三個矩形：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增三個矩形類型的自動圖形。
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // 設定每個矩形圖形的填充顏色。
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // 設定線寬。
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

在 PowerPoint 中，Gradient Fill 是一種格式化選項，可讓您將連續的顏色漸層套用至圖形。例如，您可以以逐漸淡出方式將兩種或多種顏色混合。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/gradientformat/) 類別所公開的漸層停止集合的 `add` 方法，依定義的位置加入您偏好的兩種顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何為橢圓套用漸層填色效果：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個橢圓類型的自動圖形。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 為橢圓套用漸層格式化。
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

![The ellipse with gradient fill](gradient-fill.png)

## **圖案填色**

在 PowerPoint 中，Pattern Fill 是一種格式化選項，可讓您將兩色設計（如點狀、條紋、交叉條紋或格子）套用至圖形。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可將其套用至圖形，以提升簡報的視覺效果。即使選取了預定義圖案，仍可指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/patternformat/#getBackColor--)。
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/patternformat/#getForeColor--)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何為矩形套用圖案填色：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Pattern。
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

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，Picture Fill 是一種格式化選項，允許您在圖形內插入影像──實質上使用影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填色模式設定為 `Tile`（或其他您偏好的模式）。
1. 從您想使用的影像建立 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 物件。
1. 將影像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，其圖示如下：

![The lotus picture](lotus.png)

以下 JavaScript 程式碼示範如何以圖片填滿圖形：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 設定填充類型為 Picture。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 設定圖片填色模式。
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

![The shape with picture fill](picture-fill.png)

### **將圖片平鋪為紋理**

如果您想將平鋪的圖片作為紋理，並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填色模式──`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪在圖形內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪相對於圖形原點的水平位移（單位為點）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪相對於圖形原點的垂直位移（單位為點）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義平鋪的水平縮放。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義平鋪的垂直縮放。

以下程式碼範例示範如何新增具有平鋪圖片填色的矩形圖形，並設定平鋪選項：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let firstSlide = presentation.getSlides().get_Item(0);

    // 新增一個矩形自動圖形。
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // 將圖形的填充類型設為 Picture。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 載入影像並將其加入簡報資源。
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 將影像指定給圖形。
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

![The tile options](tile-options.png)

## **純色填色**

在 PowerPoint 中，Solid Color Fill 是一種格式化選項，會以單一、均勻的顏色填滿圖形。此純色背景不含任何漸層、紋理或圖案。

若要使用 Aspose.Slides 為圖形套用純色填色，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指派您偏好的填色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何在 PowerPoint 投影片的矩形上套用純色填色：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
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

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對圖形套用純色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的不透明程度。較高的透明度值會使圖形更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色所使用的顏色之 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義具透明度的顏色（alpha 成分控制透明度）。
1. 儲存簡報。

以下 JavaScript 程式碼示範如何為矩形套用透明填色：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個實心矩形自動圖形。
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心圖形上方新增一個透明矩形自動圖形。
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

![The transparent shape](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 讓您在 PowerPoint 簡報中旋轉圖形。此功能在需要特定對齊或設計需求的視覺元素定位時相當實用。

若要在投影片上旋轉圖形，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 將圖形的 rotation 屬性設定為目標角度。
1. 儲存簡報。

以下 JavaScript 程式碼示範如何將圖形旋轉 5 度：

```js
// 實例化代表簡報檔案的 Presentation 類別。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 將圖形旋轉 5 度。
    shape.setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 斜角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 屬性，為圖形套用 3D 斜角效果。

若要為圖形新增 3D 斜角效果，請依照以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 JavaScript 程式碼說明如何為圖形套用 3D 斜角效果：

```js
// 建立 Presentation 類別的實例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 新增一個圖形至投影片。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // 設定圖形的 ThreeDFormat 屬性。
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

![The 3D bevel effect](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

若要對圖形套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 新增至投影片。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/camera/#setCameraType) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/lightrig/#setLightType) 定義 3D 旋轉。
1. 儲存簡報。

以下 JavaScript 程式碼示範如何對圖形套用 3D 旋轉效果：

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

![The 3D rotation effect](3D-rotation-effect.png)

## **重設格式化**

以下 Java 程式碼示範如何重設投影片的格式化，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) 上所有具佔位符的圖形之位置、大小與格式還原為預設設定：

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // 重設投影片上在版面配置中具有占位符的每個圖形。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與媒體檔案佔用大部分空間，而圖形參數（如顏色、效果與漸層）僅以中繼資料形式儲存，幾乎不會增加額外容量。

**如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性──填色、線條與效果設定。若所有相對應的值皆相同，即可視為樣式相同，並將這些圖形邏輯性分組，這樣可簡化後續的樣式管理。

**我可以將一組自訂的圖形樣式儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例圖形存放於模板投影片檔或 .POTX 模板檔。建立新簡報時，開啟該模板，複製需要的已樣式化圖形，並在需要的地方重新套用其格式。