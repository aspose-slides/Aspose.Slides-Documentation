---
title: 在 Java 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/java/wordart/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中建立並自訂 WordArt 效果。本分步指南協助開發人員在 Java 中以專業文字增強簡報。"
---
## **概覽**

WordArt 效果讓您可以在 PowerPoint 簡報中加入視覺上吸引人、具風格化的文字。使用 Aspose.Slides，開發人員能夠以程式方式建立、客製化與管理 WordArt，就像在 Microsoft PowerPoint 中一樣──無需安裝 Office。本篇文章概述了如何使用 WordArt，包括套用文字變形、填色樣式、輪廓、陰影以及其他格式化選項，使您的簡報內容更具表現力與吸引力。WordArt 讓您將文字視為圖形物件。它由套用於文字的效果或特殊修改組成，以使文字更具吸引力或顯眼。

## **建立簡易 WordArt 範本並套用至文字**

**使用 Aspose.Slides** 

首先，我們使用以下 Java 程式碼建立一段簡單的文字：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
接下來，我們使用以下程式碼將文字的字型高度設定為較大的值，以使效果更明顯：

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中前往 WordArt 效果選單：

![todo:image_alt_text](image-20200930113926-1.png)

在右側功能表中，您可以選擇預先定義的 WordArt 效果。於左側功能表，您可以設定新 WordArt 的參數。 

以下是部分可用的參數或選項：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我們使用以下程式碼將 [SmallGrid](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PatternStyle#SmallGrid) 圖案顏色套用至文字，並加上一條寬度為 1 的黑色文字邊框：

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

產生的文字如下：

![todo:image_alt_text](image-20200930114108-4.png)

## **套用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程式介面中，您可以將這些效果套用到文字、文字區塊、圖形或類似的元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，可將陰影、反射與發光效果套用於文字；3D 格式與 3D 旋轉效果可套用於文字區塊；柔和邊緣屬性可套用於圖形物件（即使未設定 3D 格式屬性仍會產生效果）。

### **套用陰影效果**

此處，我們僅針對文字設定相關屬性，並使用以下 Java 程式碼將陰影效果套用至文字：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

Aspose.Slides API 支援三種陰影類型：OuterShadow、InnerShadow 與 PresetShadow。 

使用 PresetShadow，您可以針對文字套用預設值的陰影。 

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您只能使用一種陰影。以下為示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

實際上，Aspose.Slides 允許同時套用兩種陰影：InnerShadow 與 PresetShadow。

**注意事項：**

- 當同時使用 OuterShadow 與 PresetShadow 時，僅會套用 OuterShadow 效果。 
- 若同時使用 OuterShadow 與 InnerShadow，套用的效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果會加倍；但在 PowerPoint 2007 中，則只套用 OuterShadow 效果。 

### **套用 Display 效果於文字**

我們透過以下 Java 程式碼為文字加入 Display 效果：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
} finally {
    if (pres != null) pres.dispose();
}
```

### **套用發光效果於文字**

我們使用以下程式碼將發光效果套用於文字，使其閃耀或突顯：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

操作結果如下：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

您可以變更陰影、Display 與發光的參數。這些效果的屬性會分別套用於文字的每個部分。 

{{% /alert %}} 

### **在 WordArt 中使用變形**

我們透過以下程式碼使用 Transform 屬性（適用於整個文字區塊）：

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

結果如下：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Microsoft PowerPoint 與 Aspose.Slides for Java 都提供若干預先定義的變形類型。 

{{% /alert %}} 

**使用 PowerPoint**

若要存取預先定義的變形類型，請依序前往：**Format** -> **TextEffect** -> **Transform**

**使用 Aspose.Slides**

若要選取變形類型，請使用 TextShapeType 列舉。 

### **套用 3D 效果於文字與圖形**

我們使用以下範例程式碼為文字圖形設定 3D 效果：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

產生的文字及其圖形如下：

![todo:image_alt_text](image-20200930114816-9.png)

我們使用以下 Java 程式碼將 3D 效果套用至文字：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

操作結果如下：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

將 3D 效果套用於文字或其圖形，以及效果之間的互動，皆遵循特定規則。 

考慮文字與包含該文字之圖形的場景。3D 效果包含 3D 物件的表示以及放置物件的場景。 

- 當場景同時設定於圖形與文字時，圖形的場景具有較高優先權——文字的場景會被忽略。 
- 當圖形本身沒有場景但具有 3D 表示時，會使用文字的場景。 
- 否則——當圖形原本沒有 3D 效果時，圖形保持平面，3D 效果僅套用於文字。 

這些描述與 ThreeDFormat.getLightRig() 與 ThreeDFormat.getCamera() 方法相關。 

{{% /alert %}} 

## **套用外部陰影效果於文字**
Aspose.Slides for Java 提供 [**IOuterShadow**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ioutershadow/) 與 [**IInnerShadow**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinnershadow/) 類別，讓您能夠對由 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/) 所承載的文字套用陰影效果。請依照以下步驟進行：

1. 建立 [Presentation] 類別的實例。  
2. 使用索引取得投影片的參考。  
3. 在投影片中新增一個類型為 Rectangle 的 AutoShape。  
4. 取得與 AutoShape 關聯的 TextFrame。  
5. 將 AutoShape 的 FillType 設為 NoFill。  
6. 實例化 OuterShadow 類別。  
7. 設定陰影的 BlurRadius。  
8. 設定陰影的 Direction。  
9. 設定陰影的 Distance。  
10. 將 RectanglelAlign 設為 TopLeft。  
11. 將陰影的 PresetColor 設為 Black。  
12. 將簡報寫入為 [PPTX] 檔案。  

此範例程式碼（Java）示範如何將外部陰影效果套用至文字：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 取得投影片的參考
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增一個類型為矩形的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 在矩形上加入 TextFrame
    ashp.addTextFrame("Aspose TextBox");

    // 停用形狀填充，以便取得文字的陰影
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 新增外部陰影並設定所有必要參數
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // 將簡報寫入磁碟
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **套用內部陰影效果於圖形**
請依照以下步驟進行：

1. 建立 [Presentation] 類別的實例。  
2. 取得投影片的參考。  
3. 新增一個類型為 Rectangle 的 AutoShape。  
4. 啟用 InnerShadowEffect。  
5. 設定所有必要的參數。  
6. 將 ColorType 設為 Scheme。  
7. 設定 Scheme Color。  
8. 將簡報寫入為 [PPTX] 檔案。  

此範例程式碼（Java）示範如何將內部陰影效果套用於圖形中的文字：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 取得投影片的參考
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增一個矩形類型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 在矩形上加入 TextFrame
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // 啟用內部陰影效果
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 設定所有必要的參數
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // 設定 ColorType 為 Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // 設定 Scheme 顏色
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // 儲存簡報
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### 我可以在不同字型或文字系統（例如阿拉伯文、中文）上使用 WordArt 效果嗎？

可以，Aspose.Slides 支援 Unicode，並可與所有主要字型與文字系統一起使用。無論語言為何，都能套用陰影、填色與輪廓等 WordArt 效果，惟字型的可用性與呈現可能取決於系統字型。

### 我可以將 WordArt 效果套用到投影片母片元素嗎？

可以，您可以在母片投影片上的圖形套用 WordArt 效果，包括標題佔位符、頁腳或背景文字。對母片版面的變更會反映至所有相關投影片。

### WordArt 效果會影響簡報檔案大小嗎？

會稍微增加。陰影、發光與漸層填色等 WordArt 效果會因加入格式化資料而略增檔案大小，但差異通常可以忽略不計。

### 我可以在不儲存簡報的情況下預覽 WordArt 效果的結果嗎？

可以，您可以使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 介面的 `getImage` 方法，將含有 WordArt 的投影片渲染為影像（如 PNG、JPEG）。這讓您能在記憶體或螢幕上預覽結果，無需儲存或匯出完整簡報。