---
title: 在 JavaScript 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/nodejs-java/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 顯示效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中建立與自訂 WordArt 效果。本分步指南協助開發人員以專業文字提升簡報品質。"
---
## **概觀**

WordArt 效果讓您可以在 PowerPoint 簡報中加入視覺吸引、具風格的文字。使用 Aspose.Slides，開發人員可以以程式方式建立、客製化與管理 WordArt，就像在 Microsoft PowerPoint 中操作一樣——不需要安裝 Office。本文章概述了 WordArt 的使用方式，包括如何套用文字變形、填色樣式、輪廓、陰影以及其他格式選項，讓您的簡報內容更加表現力豐富且引人入勝。WordArt 讓您把文字當作圖形物件來處理。它是一組套用於文字的效果或特殊變更，使文字更具吸引力或更顯眼。

## **建立簡易 WordArt 範本並套用至文字**

**使用 Aspose.Slides** 

首先，我們使用以下 JavaScript 程式碼建立簡單的文字：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
接著，透過下列程式碼將文字的字型高度設定為較大的值，以讓效果更加明顯：

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**使用 Microsoft PowerPoint**

前往 Microsoft PowerPoint 中的 WordArt 效果功能表：

![todo:image_alt_text](image-20200930113926-1.png)

在右側功能表中，您可以選擇預先定義的 WordArt 效果；在左側功能表中，您可以為新 WordArt 指定設定。

以下是部分可用的參數或選項：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我們將文字的圖案色彩套用為 [SmallGrid](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PatternStyle#SmallGrid) 並使用以下程式碼加入 1 像素寬的黑色文字邊框：

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

產生的文字如下：

![todo:image_alt_text](image-20200930114108-4.png)

## **套用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程式的功能表中，您可以將這些效果套用至文字、文字方塊、圖形或類似的元件：

![todo:image_alt_text](image-20200930114129-5.png)

例如，Shadow、Reflection 與 Glow 效果可套用於文字；3D Format 與 3D Rotation 效果可套用於文字方塊；Soft Edges 屬性可套用於 Shape 物件（即使未設定 3D Format 屬性仍會產生效果）。

### **套用陰影效果**

此處我們僅針對文字本身設定屬性。使用以下 JavaScript 程式碼將陰影效果套用至文字：

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

Aspose.Slides API 支援三種陰影類型：OuterShadow、InnerShadow 與 PresetShadow。

使用 PresetShadow 時，您可以以預設值為文字套用陰影。

**使用 Microsoft PowerPoint**

在 PowerPoint 中只能使用單一類型的陰影。以下為示範：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 甚至允許同時套用兩種陰影：InnerShadow 與 PresetShadow。

**注意：**

- 同時使用 OuterShadow 與 PresetShadow 時，僅會套用 OuterShadow 效果。  
- 若同時使用 OuterShadow 與 InnerShadow，實際套用的效果取決於 PowerPoint 版本，例如在 PowerPoint 2013 中會產生雙重效果，而在 PowerPoint 2007 中則只套用 OuterShadow。

### **套用 Display 效果至文字**

我們使用以下 JavaScript 程式碼為文字加入 Display 效果：

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **套用 Glow 效果至文字**

使用下列程式碼將 Glow 效果套用至文字，使其發光或更突出：

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

操作結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以變更陰影、Display 與 Glow 的參數。這些效果的屬性會分別套用於文字的每個區段。

{{% /alert %}} 

### **在 WordArt 中使用變形 (Transformations)**

我們透過以下程式碼使用 Transform 屬性（套用於整個文字區塊）：

```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

結果如下：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 與 Aspose.Slides for Node.js via Java 均提供了多種預定義的變形類型。

{{% /alert %}} 

**使用 PowerPoint**

前往 **格式** → **文字效果** → **變形** 以存取預定義的變形類型。

**使用 Aspose.Slides**

使用 TextShapeType 列舉可選取變形類型。

### **套用 3D 效果至文字與圖形**

我們使用以下範例程式碼將 3D 效果套用至文字圖形：

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

產生的文字與圖形如下：

![todo:image_alt_text](image-20200930114816-9.png)

接著，我們使用此 JavaScript 程式碼為文字套用 3D 效果：

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

操作結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

3D 效果套用於文字或其圖形時，與其他效果的交互遵循特定規則。

將文字與其所在圖形視為同一場景。3D 效果包含 3D 物件表示與放置該物件的場景。

- 若場景同時設定於圖形與文字，圖形的場景優先，文字的場景會被忽略。  
- 若圖形本身沒有場景但有 3D 表示，則使用文字的場景。  
- 若圖形原本沒有任何 3D 效果，則圖形保持平面，3D 效果僅套用於文字。

上述說明與 ThreeDFormat.getLightRig() 與 ThreeDFormat.getCamera() 方法相關。

{{% /alert %}} 

## **為文字套用 Outer Shadow 效果**

Aspose.Slides for Node.js via Java 提供 [**OuterShadow**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/outershadow/) 與 [**InnerShadow**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/innershadow/) 類別，讓您能對由 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 所承載的文字套用陰影效果。請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 例項。  
2. 依索引取得投影片參考。  
3. 在投影片上新增類型為 Rectangle 的 AutoShape。  
4. 取得該 AutoShape 關聯的 TextFrame。  
5. 將 AutoShape 的 FillType 設為 NoFill。  
6. 實例化 OuterShadow 類別。  
7. 設定陰影的 BlurRadius。  
8. 設定陰影的 Direction。  
9. 設定陰影的 Distance。  
10. 將 RectanglelAlign 設為 TopLeft。  
11. 將陰影的 PresetColor 設為 Black。  
12. 將簡報寫出為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下 Java 範例程式碼示範如何將 Outer Shadow 效果套用至文字：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 取得投影片的參考
    var sld = pres.getSlides().get_Item(0);
    // 新增矩形類型的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 為矩形加入 TextFrame
    ashp.addTextFrame("Aspose TextBox");
    // 停用圖形填色，以便取得文字的陰影
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 新增外部陰影並設定所有必要參數
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // 將簡報寫入磁碟
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **為圖形套用 Inner Shadow 效果**

請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 例項。  
2. 取得投影片參考。  
3. 新增類型為 Rectangle 的 AutoShape。  
4. 啟用 InnerShadowEffect。  
5. 設定所有必要參數。  
6. 將 ColorType 設為 Scheme。  
7. 設定 Scheme Color。  
8. 將簡報寫出為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例程式碼（根據上述步驟）示範如何在 JavaScript 中於兩個圖形之間加入連接線：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 取得投影片的參考
    var slide = pres.getSlides().get_Item(0);
    // 新增矩形類型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 為矩形加入 TextFrame
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // 啟用 InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // 設定所有必要參數
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // 設定 ColorType 為 Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // 設定 Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // 儲存簡報
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題集 (FAQ)**

**我可以在不同字型或文字系統（例如阿拉伯文、中文）中使用 WordArt 效果嗎？**

可以，Aspose.Slides 支援 Unicode，並能與所有主要字型與文字系統合作。Shadow、Fill、Outline 等 WordArt 效果均可套用於任何語言，儘管字型的可用性與呈現可能受系統安裝的字型影響。

**我可以將 WordArt 效果套用至投影片母版元素嗎？**

可以，您可以在母版投影片上的形狀（例如標題占位符、頁腳或背景文字）套用 WordArt 效果。對母版版面的變更會套用至所有使用該母版的投影片。

**WordArt 效果會影響簡報檔案大小嗎？**

會略微影響。陰影、Glow、漸層填色等效果會因為額外的格式資訊而稍微增加檔案大小，但差異通常可以忽略不計。

**我可以在未儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

可以，您可以使用 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 或 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/) 類別的 `getImage` 方法將含有 WordArt 的投影片渲染為影像（如 PNG、JPEG），以在記憶體或螢幕上即時預覽結果，無需先儲存完整簡報。