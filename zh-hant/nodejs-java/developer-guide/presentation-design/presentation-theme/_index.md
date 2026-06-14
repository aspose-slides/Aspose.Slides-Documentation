---
title: 在 JavaScript 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/nodejs-java/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 附加調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中管理簡報主題，以建立、客製化與轉換具有一致品牌識別的 PowerPoint 檔案。"
---
## **介紹**

簡報主題定義了設計元素的屬性。當您選取簡報主題時，實際上是選擇了一組特定的視覺元素及其屬性。

在 PowerPoint 中，主題包括顏色、[字型](/slides/zh-hant/nodejs-java/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/nodejs-java/presentation-background/)以及效果。

![主題構成](theme-constituents.png)

## **變更主題顏色**

PowerPoint 主題會為投影片上的不同元素使用特定的顏色組合。如果您不喜歡這些顏色，可以透過套用新顏色來變更主題顏色。為了讓您選取新的主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SchemeColor) 列舉中提供了相應的值。

這段 JavaScript 程式碼示範如何變更主題的強調色：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

您可以這樣取得結果顏色的實際值：

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

為了進一步示範顏色變更操作，我們建立另一個元素並將先前取得的強調色指派給它，然後在主題中變更顏色：

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

新的顏色會自動套用到兩個元素上。

### **從附加調色盤設定主題顏色**

當您對主要主題顏色 (1) 套用亮度變換時，會產生來自附加調色盤 (2) 的顏色。之後您即可設定與取得這些主題顏色。

![附加調色盤顏色](additional-palette-colors.png)

**1** - 主要主題顏色  
**2** - 附加調色盤的顏色。

這段 JavaScript 程式碼示範一個操作，從主要主題顏色取得附加調色盤的顏色，然後在圖形中使用這些顏色：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // 強調色 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // 強調色 4, 較亮 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // 強調色 4, 較亮 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // 強調色 4, 較亮 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // 強調色 4, 較暗 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // 強調色 4, 較暗 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **將 `SchemeColor` 對映至 `ColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 時，可能會注意到它包含以下主題顏色值：

`Background1`、`Background2`、`Text1` 與 `Text2`。

然而，`Presentation.getMasterTheme().getColorScheme()` 會傳回 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/)，其顯示相對應的顏色為：

`Dark1`、`Dark2`、`Light1` 與 `Light2`。

這個差異僅在命名上。這些值指向相同的主題顏色插槽，映射關係是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換，它們只是相同主題顏色的替代名稱。

這種命名差異源自 Microsoft Office 的術語。舊版 Office 使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而新版 UI 則以 `Text 1`、`Background 1`、`Text 2`、`Background 2` 顯示相同的插槽。

## **變更主題字型**

為了讓您選取字型用於主題及其他用途，Aspose.Slides 使用以下特殊識別碼（類似於 PowerPoint 中的使用方式）：

* **+mn-lt** - 本文字型 Latin（次要 Latin 字型）
* **+mj-lt** - 標題字型 Latin（主要 Latin 字型）
* **+mn-ea** - 本文字型 東亞（次要東亞字型）
* **+mj-ea** - 本文字型 東亞（主要東亞字型）

這段 JavaScript 程式碼示範如何將 Latin 字型指定給主題元素：

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

這段 JavaScript 程式碼示範如何變更簡報的主題字型：

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

所有文字方塊的字型都會被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 字型](/slides/zh-hant/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

## **變更主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預設背景，但在一般簡報中僅會儲存其中的 3 種。

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，可以執行以下 JavaScript 程式碼以查詢簡報中預設背景的數量：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FormatScheme) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 屬性，您可以在 PowerPoint 主題中新增或存取背景樣式。
{{% /alert %}} 

這段 JavaScript 程式碼示範如何為簡報設定背景：

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**索引說明**：0 代表無填色。索引從 1 開始。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 背景](/slides/zh-hant/nodejs-java/presentation-background/)。
{{% /alert %}}

## **變更主題效果**

PowerPoint 主題通常在每個樣式陣列中包含 3 個值。這些陣列會結合成 3 種效果：細緻、適中與強烈。例如，當效果套用到特定圖形時的結果如下：

![todo:image_alt_text](presentation-design_10.png)

使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FormatScheme) 類別的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)），您可以變更主題中的元素（比 PowerPoint 的選項更具彈性）。

這段 JavaScript 程式碼示範如何透過變更元素部分來調整主題效果：

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

產生的變化包括填色、填充類型、陰影效果等：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

**我可以在不更改母片的情況下，只對單一投影片套用主題嗎？**

是的。Aspose.Slides 支援投影片層級的主題覆寫，您可以只在該投影片上套用本機主題，同時保持母片主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidethememanager/)）。

**將主題從一個簡報搬移到另一個簡報的最安全方法是什麼？**

將 [Clone slides](/slides/zh-hant/nodejs-java/clone-slides/) 連同其母片一起複製到目標簡報。這樣可保留原始的母片、版面配置以及相關的主題，確保外觀一致。

**如何查看所有繼承與覆寫後的「實際」值？**

使用 API 的「[effective]」檢視（/slides/zh-hant/nodejs-java/shape-effective-properties/）以取得主題／顏色／字型／效果的實際值。這些會回傳套用母片與任何本機覆寫後的最終屬性。