---
title: 在 Java 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 素描效果
- 素描形狀線條
- 格式化接合樣式
- 漸層填充
- 圖案填充
- 圖片填充
- 紋理填充
- 純色填充
- 形狀透明度
- 旋轉形狀
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完全控制地為 PPT、PPTX 與 ODP 檔案設定填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以向投影片加入形狀。由於形狀是由線條組成，您可以透過修改或套用效果於其輪廓來格式化它們。此外，您還可以透過設定控制內部填充方式來格式化形狀。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java 提供介面和方法，讓您能使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂線條樣式。以下步驟說明了這個程序：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [線條樣式](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [虛線樣式](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/linedashstyle/)。
1. 為形狀設定線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```java
    // 實例化代表簡報檔的 Presentation 類別。
    Presentation presentation = new Presentation();
    try {
        // 取得第一張投影片。
        ISlide slide = presentation.getSlides().get_Item(0);

        // 新增一個類型為矩形的自動形狀。
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

        // 設定矩形形狀的填充顏色。
        shape.getFillFormat().setFillType(FillType.NoFill);

        // 為矩形的線條套用格式。
        shape.getLineFormat().setStyle(LineStyle.ThickThin);
        shape.getLineFormat().setWidth(7);
        shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

        // 設定矩形線條的顏色。
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

        // 將 PPTX 檔案儲存至磁碟。
        presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

結果：

![The formatted lines in the presentation](formatted-lines.png)

## **套用素描效果於形狀線條**

素描效果會使形狀線條看起來像手繪。使用 [IShape.getLineFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 來取得線條設定，使用 [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilineformat/) 來取得素描設定，並使用 [ISketchFormat.setSketchType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isketchformat/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/linesketchtype/) 列舉中選取值。

以下 Java 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/linesketchtype/) 效果、讀取明確指定的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/linesketchtype/) 移除該效果：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 存取形狀的線條格式及其草圖格式。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // 套用草圖效果。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 讀取直接指派給形狀的草圖效果。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // 移除草圖效果。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isketchformat/) 代表直接指派給形狀的設定。若線條格式可以從佈景主題、母片投影片或版面投影片繼承，請使用 [ILineFormat.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilineformat/)，取得 [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilineformateffectivedata/)，並讀取 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isketchformateffectivedata/)。有效值反映在繼承解析後實際套用的格式：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **格式化接合樣式**

以下是三種接合類型選項：

* 圓形
* 斜角
* 斜面

預設情況下，PowerPoint 在以角度（例如形狀的角落）連接兩條線時，會使用 **圓形** 設定。然而，若您繪製的形狀具有銳角，您可能會偏好 **斜角** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 Java 程式碼示範如何使用斜角、斜面與圓形接合類型設定，建立如上圖所示的三個矩形：

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增三個類型為矩形的自動形狀。
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 設定每個矩形形狀的填充顏色。
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 設定線條寬度。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 設定每個矩形線條的顏色。
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 設定接合樣式。
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 為每個矩形加入文字。
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **漸層填充**

在 PowerPoint 中，漸層填充是一種格式化選項，可讓您將連續的顏色混合套用於形狀。例如，您可以以逐漸由一種顏色過渡到另一種顏色的方式套用兩種或以上的顏色。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填充：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igradientformat/) 介面所提供的 gradient stop 集合的 `add` 方法，加入您偏好的兩種顏色並定義其位置。
1. 將修改後的簡報儲存為 PPTX 檔案。

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為橢圓的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 為橢圓套用漸層格式。
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 設定漸層的方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 新增兩個漸層停點。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The ellipse with gradient fill](gradient-fill.png)

## **圖案填充**

在 PowerPoint 中，圖案填充是一種格式化選項，讓您可以將雙色設計（例如點、條紋、交叉陰影或格子）套用於形狀。您可以為圖案的前景色與背景色自行選擇自訂顏色。

Aspose.Slides 提供超過 45 種預定義的圖案樣式，您可以套用於形狀以提升簡報的視覺效果。即使在選取預定義圖案後，仍可指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖案填充：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 為 `Pattern`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/patternformat/#getBackColor--)。
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/patternformat/#getForeColor--)。
1. 將修改後的簡報儲存為 PPTX 檔案。

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為矩形的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為圖案。
    shape.getFillFormat().setFillType(FillType.Pattern);

    // 設定圖案樣式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 設定圖案的背景色與前景色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填充**

在 PowerPoint 中，圖片填充是一種格式化選項，允許您在形狀內插入圖像，實質上將圖像作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填充：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 為 `Picture`。
1. 設定圖片填充模式為 `Tile`（或其他您偏好的模式）。
1. 從您想使用的圖像建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 物件。
1. 將圖像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，內容如下圖所示：

![The lotus picture](lotus.png)

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為矩形的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 設定填充類型為圖片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 設定圖片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 載入影像並將其加入簡報資源。
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // 設定圖片。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The shape with picture fill](picture-fill.png)

### **將圖片平鋪為紋理**

如果您想將平鋪的圖片設定為紋理並自訂平鋪行為，可使用以下 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/picturefillformat/) 類別的方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 設定圖片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 指定平鋪在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 設定平鋪相對於形狀原點的水平偏移量（點）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 設定平鋪相對於形狀原點的垂直偏移量（點）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 定義平鋪的水平縮放比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 定義平鋪的垂直縮放比例（百分比）。

以下程式碼範例示範如何新增一個帶平鋪圖片填充的矩形形狀，並設定平鋪選項：

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 新增一個矩形自動形狀。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定形狀的填充類型為圖片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 載入影像並將其加入簡報資源。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 將影像指派給形狀。
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 設定圖片填充模式與平鋪屬性。
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The tile options](tile-options.png)

## **純色填充**

在 PowerPoint 中，純色填充是一種格式化選項，可使用單一均勻的顏色填滿形狀。此純粹的背景色不含任何漸層、紋理或圖案。

以下說明如何使用 Aspose.Slides 為形狀套用純色填充：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 為 `Solid`。
1. 為形狀指定您偏好的填色。
1. 將修改後的簡報儲存為 PPTX 檔案。

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為矩形的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為純色。
    shape.getFillFormat().setFillType(FillType.Solid);

    // 設定填充顏色。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對形狀套用純色、漸層、圖片或紋理填充時，也可以設定透明度以控制填充的不透明度。較高的透明度值會使形狀更透明，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填充顏色的 alpha 值來設定透明度。以下說明如何操作：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 為 `Solid`。
1. 使用 `Color` 定義具透明度的顏色（`alpha` 成分控制透明度）。
1. 儲存簡報。

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個實心矩形自動形狀。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心形狀上方新增一個透明矩形自動形狀。
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The transparent shape](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在需要特定對齊或設計需求的視覺元素定位時相當有用。

要在投影片上旋轉形狀，請依以下步驟：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定形狀的旋轉屬性為所需角度。
1. 儲存簡報。

```java
// 實例化代表簡報檔的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為矩形的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 將形狀旋轉 5 度。
    shape.setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The shape rotation](shape-rotation.png)

## **新增 3D 倒角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/) 屬性，為形狀套用 3D 倒角效果。

要為形狀新增 3D 倒角效果，請依以下步驟：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/) 以定義倒角設定。
1. 儲存簡報。

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在投影片上新增一個形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 設定形狀的 ThreeDFormat 屬性。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The 3D bevel effect](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/) 屬性，為形狀套用 3D 旋轉效果。

要對形狀套用 3D 旋轉，請：

1. 建立 [演示文稿](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icamera/#setCameraType-int-) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilightrig/#setLightType-int-) 來定義 3D 旋轉。
1. 儲存簡報。

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![The 3D rotation effect](3D-rotation-effect.png)

## **重設格式**

以下 Java 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslide/) 上所有帶佔位符的形狀的定位、大小與格式恢復為預設設定：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重設投影片上每個在版面上具有佔位符的形狀。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的圖片與媒體佔用大部分檔案空間，而形狀的參數（如顏色、效果與漸層）以中繼資料儲存，幾乎不會增加額外大小。

**我該如何偵測投影片上具有相同格式的形狀以便將它們分組？**

比較每個形狀的關鍵格式屬性──填充、線條與效果設定。若所有對應值皆相同，即可視為樣式相同，並在邏輯上將這些形狀分組，從而簡化之後的樣式管理。

**我能將一組自訂形狀樣式儲存到獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的樣本形狀存於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式形狀，並在需要的地方重新套用其格式設定。