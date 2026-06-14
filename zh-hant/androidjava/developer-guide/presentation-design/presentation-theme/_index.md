---
title: 在 Android 上管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/androidjava/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 額外調色板
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for Android 中掌握簡報主題，以建立、客製化及轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了設計元素的屬性。當您選取簡報主題時，實際上是選擇了一組特定的視覺元素及其屬性。

在 PowerPoint 中，主題包括顏色、[字型](/slides/zh-hant/androidjava/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/androidjava/presentation-background/)以及效果。

![主題構成要素](theme-constituents.png)

## **變更主題顏色**

PowerPoint 主題在投影片的不同元素上使用特定的一組顏色。如果您不喜歡這些顏色，可以透過為主題套用新顏色來更改它們。為了讓您選取新主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SchemeColor) 列舉中提供了相應的值。

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

您可以藉此方式取得最終顏色的實際值：

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

為了更進一步示範顏色變更操作，我們建立另一個元素，並將首個操作中的強調顏色指派給它。接著在主題中更改該顏色：

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

新顏色會自動套用到兩個元素上。

### **從額外調色板設定主題顏色**

當您對主主題顏色 (1) 套用亮度變換時，會產生來自額外調色板 (2) 的顏色。之後您即可設定與取得這些主題顏色。

![額外調色板顏色](additional-palette-colors.png)

**1** - 主主題顏色  

**2** - 來自額外調色板的顏色。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 強調色 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // 強調色 4, 較亮 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // 強調色 4, 較亮 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // 強調色 4, 較亮 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // 強調色 4, 較暗 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 強調色 4, 較暗 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **將 `SchemeColor` 對映到 `IColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 時，您可能會注意到它包含以下主題顏色值：

`Background1`, `Background2`, `Text1`, and `Text2`.

然而，`Presentation.getMasterTheme().getColorScheme()` 會回傳 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/)，其對應的顏色分別為：

`Dark1`, `Dark2`, `Light1`, and `Light2`.

此差異僅在於命名。這些值指向相同的主題顏色槽位，且對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

在 `Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換。它們僅是相同主題顏色的別名。

此命名差異源自 Microsoft Office 的術語。舊版 Office 使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而較新 UI 版本則將相同的槽位顯示為 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **變更主題字型**

為了讓您為主題及其他用途選擇字型，Aspose.Slides 使用以下特殊識別碼（類似於 PowerPoint 中使用的）：

* **+mn-lt** - 正文字型拉丁文 (Minor Latin Font)
* **+mj-lt** - 標題字型拉丁文 (Major Latin Font)
* **+mn-ea** - 正文字型東亞 (Minor East Asian Font)
* **+mj-ea** - 正文字型東亞 (Major East Asian Font)

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

以下 Java 程式碼示範如何將拉丁字型指派給主題元素：

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

所有文字方塊的字型將會更新。

{{% alert color="primary" title="TIP" %}} 
您可能想參考 [PowerPoint 字型](/slides/zh-hant/androidjava/powerpoint-fonts/)。
{{% /alert %}}

## **變更主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預定義背景，但在一般簡報中僅會儲存其中的 3 種背景。

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，可以執行以下 Java 程式碼以查詢簡報中預定義背景的數量：

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
利用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) 屬性，您可以在 PowerPoint 主題中新增或存取背景樣式。
{{% /alert %}} 

以下 Java 程式碼示範如何為簡報設定背景：

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**索引說明**：0 代表無填充。索引從 1 開始。

{{% alert color="primary" title="TIP" %}} 
您可能想參閱 [PowerPoint 背景](/slides/zh-hant/androidjava/presentation-background/)。
{{% /alert %}}

## **變更主題效果**

PowerPoint 主題通常為每個樣式陣列包含 3 個值。這些陣列會結合成 3 種效果：細微、適中與強烈。例如，將效果套用至特定形狀時的結果如下：

![todo:image_alt_text](presentation-design_10.png)

透過 [FormatScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme) 類別中的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)），您可以變更主題中的元素（比 PowerPoint 提供的選項更具彈性）。

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

最終會改變填色、填充類型、陰影效果等：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

**我可以在不更改母片的情況下，將主題套用於單一投影片嗎？**  

可以。Aspose.Slides 支援投影片層級的主題覆寫，您可以僅對該投影片套用本地主題，同時保持母片主題完整 (透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidethememanager/))。

**將主題從一個簡報安全搬移至另一個簡報的最佳方法是什麼？**  

將 [Clone slides](/slides/zh-hant/androidjava/clone-slides/) 連同其母片一起複製到目標簡報中。這樣可保留原始的母片、版面配置以及相關的主題，使外觀保持一致。

**如何查看在所有繼承與覆寫之後的「實際」值？**  

使用 API 的 ["effective" views](/slides/zh-hant/androidjava/shape-effective-properties/)（主題/顏色/字型/效果）。這些會在套用母片及任何本地覆寫後回傳解析完成的最終屬性。