---
title: 在 Java 中管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/java/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 佈景色彩
- 額外調色板
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中掌握簡報佈景主題，以建立、客製化並轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題會定義設計元素的屬性。當您選取簡報佈景主題時，實際上是在挑選一組特定的視覺元素及其屬性。

在 PowerPoint 中，佈景主題包含色彩、[字型](/slides/zh-hant/java/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/java/presentation-background/)以及效果。

![theme-constituents](theme-constituents.png)

## **變更佈景色彩**

PowerPoint 佈景主題會對投影片上不同元素使用一組特定的色彩。如果您不喜歡這些色彩，可以透過套用新色彩來變更佈景主題的顏色。為了讓您選取新的佈景色彩，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SchemeColor) 列舉中提供了相應的值。

以下 Java 程式碼示範如何變更佈景的強調色彩：

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

您可以透過以下方式取得最終色彩的實際值：

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

為了進一步說明色彩變更操作，我們建立另一個元素，並將先前取得的強調色彩指派給它，然後在佈景主題中變更色彩：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

新色彩會自動套用到兩個元素上。

### **從附加調色板設定佈景色彩**

當您對主佈景色彩 (1) 套用亮度變換時，會產生來自附加調色板 (2) 的色彩。接著您即可設定與取得這些佈景色彩。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主佈景色彩  
**2** - 來自附加調色板的色彩。

以下 Java 程式碼示範從主佈景色彩取得附加調色板色彩，並在圖形中使用的操作：

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

### **將 `SchemeColor` 映射至 `IColorScheme` 色彩**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 時，可能會注意到它包含以下佈景色彩值：

`Background1`、`Background2`、`Text1` 與 `Text2`。

但是，`Presentation.getMasterTheme().getColorScheme()` 會回傳 [IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/)，其公開的相對應色彩為：

此差異僅在於命名。這些值對應相同的佈景色彩槽，映射關係固定：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換，它們只是相同佈景色彩的別名。

此命名差異源自 Microsoft Office 的術語。舊版 Office 使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而新版 UI 則將相同的槽位顯示為 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **變更佈景字型**

為了讓您為佈景及其他用途選取字型，Aspose.Slides 使用以下特殊識別碼（類似於 PowerPoint 中使用的）：

* **+mn-lt** - 正文字型 Latin（次要 Latin 字型）
* **+mj-lt** - 標題字型 Latin（主要 Latin 字型）
* **+mn-ea** - 正文字型 東亞（次要 東亞 字型）
* **+mj-ea** - 正文字型 東亞（主要 東亞 字型）

以下 Java 程式碼示範如何將 Latin 字型指派給佈景元素：

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

以下 Java 程式碼示範如何變更簡報佈景的字型：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

所有文字方塊的字型都會被更新。

{{% alert color="info" title="TIP" %}} 
您可能想參考 [PowerPoint 字型](/slides/zh-hant/java/powerpoint-fonts/)。
{{% /alert %}}

## **變更佈景背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預設背景，但在一般簡報中僅會儲存其中的 3 種背景。

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，可執行以下 Java 程式碼，以查詢簡報中預設背景的數量：

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
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) 屬性，您可以在 PowerPoint 佈景中新增或存取背景樣式。 
{{% /alert %}} 

以下 Java 程式碼示範如何為簡報設定背景：

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
您可能想參考 [PowerPoint 背景](/slides/zh-hant/java/presentation-background/)。
{{% /alert %}}

## **變更佈景效果**

PowerPoint 佈景通常為每個樣式陣列包含 3 個值。這些陣列會結合成 3 種效果：細緻、適中與強烈。例如，將效果套用於特定形狀時的結果如下：

![todo:image_alt_text](presentation-design_10.png)

使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme) 類別的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FormatScheme#getEffectStyles--)），您可以變更佈景中的元素（比 PowerPoint 的選項更具彈性）。

以下 Java 程式碼示範如何透過修改元素部份來變更佈景效果：

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

產生的填色、填充類型、陰影效果等變化如下：

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### 我可以在不變更母片的情況下，僅對單一投影片套用佈景嗎？

可以。Aspose.Slides 支援投影片層級的佈景覆寫，因此您可以只對該投影片套用本地佈景，同時保持母片佈景不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidethememanager/)）。

### 將佈景從一個簡報安全搬移到另一個簡報的最佳方式是什麼？

將投影片（包括其母片）一起[複製](/slides/zh-hant/java/clone-slides/)到目標簡報。這會保留原始的母片、版面配置以及相關的佈景，確保外觀一致。

### 如何在所有繼承與覆寫後查看「實際」值？

使用 API 的「[實際]」檢視（/slides/zh-hant/java/shape-effective-properties/）來取得佈景、色彩、字型、效果的最終屬性。這些檢視會在套用母片與任何本地覆寫後，返回解析後的最終屬性。