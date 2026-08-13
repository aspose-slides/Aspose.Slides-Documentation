---
title: 在 Android 上管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/androidjava/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 佈景主題色彩
- 額外調色盤
- 佈景主題字型
- 佈景主題樣式
- 佈景主題效果
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 透過 Java 管理簡報佈景主題，以建立、客製化及轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義設計元素的屬性。當您選擇簡報佈景主題時，實質上是選擇一組特定的視覺元素及其屬性。

在 PowerPoint 中，佈景主題包括顏色、[字型](/slides/zh-hant/androidjava/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/androidjava/presentation-background/)與效果。

![theme-constituents](theme-constituents.png)

## **變更佈景主題色彩**

PowerPoint 佈景主題會為投影片上的不同元素使用一組特定的顏色。如果您不喜歡這些顏色，可以透過套用新顏色來變更主題顏色。為了讓您選取新的佈景主題色彩，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SchemeColor) 列舉中提供了相關值。

以下 Java 程式碼示範如何變更佈景主題的強調色：

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

為了進一步示範顏色變更操作，我們會建立另一個元素，並將先前的強調色指派給它。接著在佈景主題中變更該顏色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

新顏色會自動套用至兩個元素。

### **從額外調色盤設定佈景主題色彩**

當您對主佈景主題色彩 (1) 套用亮度變換時，會產生來自額外調色盤 (2) 的顏色。之後即可設定與取得這些佈景主題色彩。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主佈景主題色彩  
**2** - 來自額外調色盤的顏色

以下 Java 程式碼示範如何從主佈景主題色彩取得額外調色盤的顏色，並在圖形中使用這些顏色：

```java
import com.aspose.slides.*;

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

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **將 `SchemeColor` 對映至 `IColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 時，可能會注意到它包含以下佈景主題顏色值：`Background1`、`Background2`、`Text1` 與 `Text2`。

然而，`Presentation.getMasterTheme().getColorScheme()` 會回傳 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/)，其公開的對應顏色為：`Dark1`、`Dark2`、`Light1`、`Light2`。

此差異僅在於命名。這些值指向相同的佈景主題顏色槽位，且對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

在 `Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換。它們僅是相同佈景主題顏色的替代名稱。

此命名差異源自 Microsoft Office 的術語。較舊的 Office 版使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而較新的 UI 版則以 `Text 1`、`Background 1`、`Text 2`、`Background 2` 顯示相同的槽位。

## **變更佈景主題字型**

為了讓您為佈景主題及其他用途選取字型，Aspose.Slides 使用以下特殊識別碼（類似於 PowerPoint 所使用的）：

* **+mn-lt** - 正文字型拉丁語（次要拉丁字型）
* **+mj-lt** - 標題字型拉丁語（主要拉丁字型）
* **+mn-ea** - 正文字型東亞語系（次要東亞字型）
* **+mj-ea** - 正文字型東亞語系（主要東亞字型）

以下 Java 程式碼示範如何將拉丁字型指派給佈景主題元素：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

以下 Java 程式碼示範如何變更簡報的佈景主題字型：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

所有文字方塊中的字型都會被更新。

{{% alert color="info" title="TIP" %}} 
您可能想參閱 [PowerPoint 字型](/slides/zh-hant/androidjava/powerpoint-fonts/)。
{{% /alert %}}

## **變更佈景主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預定義背景，但在一般簡報中僅會儲存這 12 種背景中的 3 種。

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，您可以執行以下 Java 程式碼，以查詢簡報中預定義背景的數量：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) 屬性，您可以在 PowerPoint 佈景主題中新增或存取背景樣式。
{{% /alert %}} 

以下 Java 程式碼示範如何設定簡報的背景：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**索引說明**：0 代表無填色。索引從 1 開始。

{{% alert color="info" title="TIP" %}} 
您可能想參閱 [PowerPoint 背景](/slides/zh-hant/androidjava/presentation-background/)。
{{% /alert %}}

## **變更佈景主題效果**

PowerPoint 佈景主題通常為每個樣式陣列包含 3 個值。這些陣列會結合為三種效果：細緻、適中與強烈。例如，以下是將效果套用至特定圖形時的結果：

![todo:image_alt_text](presentation-design_10.png)

使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme) 類別的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)），您可以變更佈景主題中的元素（比 PowerPoint 的選項更具彈性）。

以下 Java 程式碼示範如何透過變更元素部份來改變佈景主題效果：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

產生的變化包括填充顏色、填充類型、陰影效果等：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

### 是否可以在不更改母片的情況下，將佈景主題套用於單一投影片？

是的。Aspose.Slides 支援投影片層級的佈景主題覆寫，您可以僅對該投影片套用本機佈景主題，同時保持母片佈景主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidethememanager/)）。

### 從一個簡報搬移佈景主題到另一個簡報最安全的方法是什麼？

[Clone slides](/slides/zh-hant/androidjava/clone-slides/) 連同其母片一起複製到目標簡報。這樣可保留原始的母片、版面配置以及相關的佈景主題，確保外觀保持一致。

### 如何在所有繼承與覆寫之後查看「實際」值？

使用 API 的 [「實際」視圖](/slides/zh-hant/androidjava/shape-effective-properties/)（針對佈景主題/顏色/字型/效果）。這些視圖會在套用母片以及任何本機覆寫後，返回已解析的最終屬性。