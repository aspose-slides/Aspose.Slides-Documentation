---
title: 管理 Java 中的簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/java/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 附加調色板
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中掌握簡報主題，以建立、客製化及轉換 PowerPoint 檔案，確保品牌一致性。"
---
## **簡介**

簡報主題定義設計元素的屬性。當您選取簡報主題時，實際上是選擇了一組特定的視覺元素及其屬性。

在 PowerPoint 中，主題包括顏色、[fonts](/slides/zh-hant/java/powerpoint-fonts/)、[background styles](/slides/zh-hant/java/presentation-background/) 與效果。

![主題構成要素](theme-constituents.png)

## **變更主題顏色**

PowerPoint 主題為投影片上的不同元素使用特定的顏色組合。如果您不喜歡這些顏色，可透過套用新顏色來變更主題顏色。為了讓您選取新的主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SchemeColor) 列舉中提供了相應的值。

此 Java 程式碼示範如何變更主題的重點顏色：

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

您可以透過以下方式取得結果顏色的實際值：

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

為了進一步說明顏色變更操作，我們建立另一個元素，並將（從最初操作取得的）重點顏色指派給它。然後在主題中變更顏色：

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

新顏色會自動套用至兩個元素。

### **從附加調色板設定主題顏色**

當您對主要主題顏色(1)套用亮度變換時，會產生來自附加調色板(2)的顏色。之後您即可設定或取得這些主題顏色。

![附加調色板顏色](additional-palette-colors.png)

**1** - 主要主題顏色  

**2** - 來自附加調色板的顏色。

此 Java 程式碼示範如何從主要主題顏色取得附加調色板顏色，並在圖形中使用：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 強調色 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // 強調色 4，較亮 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // 強調色 4，較亮 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // 強調色 4，較亮 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // 強調色 4，較暗 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 強調色 4，較暗 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **將 `SchemeColor` 映射到 `IColorScheme` 顏色**

使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 時，您會注意到它包含以下主題顏色值：

`Background1`、`Background2`、`Text1` 與 `Text2`。

然而，`Presentation.getMasterTheme().getColorScheme()` 會回傳 [IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/)，其對應的顏色名稱為：

`Dark1`、`Dark2`、`Light1` 與 `Light2`。

這僅是命名上的差異。這些值指向相同的主題顏色槽，對映關係固定：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

`Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換，它們只是同一主題顏色的替代名稱。

此命名差異來源於 Microsoft Office 的術語。較舊的 Office 版本使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而較新的 UI 版本則顯示為 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **變更主題字型**

為了讓您為主題及其他用途選擇字型，Aspose.Slides 使用以下特殊識別碼（類似 PowerPoint 中的使用方式）：

* **+mn-lt** - 正文字型 Latin（次要 Latin 字型）  
* **+mj-lt** - 標題字型 Latin（主要 Latin 字型）  
* **+mn-ea** - 正文字型 東亞（次要 東亞 字型）  
* **+mj-ea** - 標題字型 東亞（主要 東亞 字型）

此 Java 程式碼示範如何將 Latin 字型指派給主題元素：

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

此 Java 程式碼示範如何變更簡報的主題字型：

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

所有文字方塊的字型都會被更新。

{{% alert color="primary" title="TIP" %}}  
您可能想參考 [PowerPoint fonts](/slides/zh-hant/java/powerpoint-fonts/)。  
{{% /alert %}}

## **變更主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預設背景，但在一般簡報中僅會儲存其中的 3 種。

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，您可以執行以下 Java 程式碼，以找出簡報中包含的預設背景數量：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}}  
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) 屬性，您可以在 PowerPoint 主題中新增或存取背景樣式。  
{{% /alert %}}  

此 Java 程式碼示範如何為簡報設定背景：

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**索引說明**：0 代表「無填色」。索引值從 1 開始。

{{% alert color="primary" title="TIP" %}}  
您可能想參考 [PowerPoint Background](/slides/zh-hant/java/presentation-background/)。  
{{% /alert %}}

## **變更主題效果**

PowerPoint 主題通常為每個樣式陣列包含 3 個值。這些陣列會結合成三種效果：微妙、適中與強烈。例如，以下示意圖顯示將效果套用於特定圖形時的結果：

![todo:image_alt_text](presentation-design_10.png)

使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme) 類別的三個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getEffectStyles--)），您可以比 PowerPoint 提供的選項更彈性地變更主題中的元素。

此 Java 程式碼示範如何透過調整元素的部分屬性來變更主題效果：

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

 resulting changes 的示意圖（填色、填充類型、陰影效果等）：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

**我可以在不更改母版的情況下，僅對單一投影片套用主題嗎？**  
可以。Aspose.Slides 支援投影片層級的主題覆寫，您可以僅為該投影片套用本地主題，同時保留母版主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidethememanager/)）。

**將主題從一個簡報安全地搬移到另一個簡報的最佳方式是什麼？**  
將投影片（連同其母版）[Clone slides](/slides/zh-hant/java/clone-slides/) 到目標簡報。這樣會保留原始母版、版面配置以及相關的主題，確保外觀保持一致。

**如何查看在所有繼承與覆寫後的「實際」值？**  
使用 API 的「[effective]」檢視（/slides/zh-hant/java/shape-effective-properties/）取得主題、顏色、字型、效果等的最終解析屬性。