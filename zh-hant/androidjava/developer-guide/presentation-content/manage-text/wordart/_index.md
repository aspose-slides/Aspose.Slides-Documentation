---
title: 在 Android 上建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/androidjava/wordart/
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
- Android
- Java
- Aspose.Slides
description: 在 Aspose.Slides for Android 中建立與自訂 WordArt 效果。此逐步指南協助開發人員在 Java 中以專業文字增強簡報。
---
## **概觀**

WordArt 效果可讓您在 PowerPoint 簡報中加入視覺上吸引且具樣式的文字。使用 Aspose.Slides，開發人員可以以程式方式建立、客製化與管理 WordArt，與在 Microsoft PowerPoint 中的操作相同——無需安裝 Office。本篇文章概述了使用 WordArt 的方法，包括如何套用文字變形、填色樣式、輪廓、陰影及其他格式選項，讓您的簡報內容更具表現力與吸引力。WordArt 允許您將文字視為圖形物件。它由套用於文字的各種效果或特殊修改組成，使文字更具吸引力或顯眼。

## **建立簡易 WordArt 範本並套用至文字**

**使用 Aspose.Slides** 

首先，我們使用以下 Java 程式碼建立簡單文字：

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
接著，我們透過以下程式碼將文字的字型高度設定為較大值，使效果更為明顯：

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**使用 Microsoft PowerPoint**

前往 Microsoft PowerPoint 中的 WordArt 效果功能表：

![todo:image_alt_text](image-20200930113926-1.png)

在右側功能表中，您可以選取預先定義的 WordArt 效果；在左側功能表中，您可以為新的 WordArt 設定參數。  
以下是部分可用的參數或選項：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

此處，我們使用以下程式碼將 [SmallGrid](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PatternStyle#SmallGrid) 圖案色彩套用至文字，並加上寬度為 1 的黑色文字框線：

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

在程式介面中，您可以將這些效果套用到文字、文字區塊、圖形或類似的元素上：

![todo:image_alt_text](image-20200930114129-5.png)

例如，可將陰影、反射與發光效果套用至文字；可將 3D 格式與 3D 旋轉效果套用至文字區塊；軟邊緣屬性則可套用至圖形物件（即使未設定 3D 格式屬性，仍會產生效果）。

### **套用陰影效果**

此處，我們僅針對文字設定相關屬性，並使用以下 Java 程式碼將陰影效果套用至文字：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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
使用 PresetShadow 時，您可套用預設的文字陰影。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您只能使用一種陰影類型。以下為範例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 實際上允許一次套用兩種陰影：InnerShadow 與 PresetShadow。

**注意：**

- 同時使用 OuterShadow 與 PresetShadow 時，僅會套用 OuterShadow 效果。  
- 若同時使用 OuterShadow 與 InnerShadow，最終套用的效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果會加倍；而在 PowerPoint 2007 中，則套用 OuterShadow 效果。

### **套用反射效果至文字**

我們透過以下 Java 程式範例為文字加入反射效果：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **套用發光效果至文字**

我們使用以下程式碼將發光效果套用至文字，使其閃亮或突出：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
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

您可以變更陰影、反射與發光的參數。效果屬性會分別套用於文字的每個段落。 

{{% /alert %}} 

### **在 WordArt 中使用變形**

我們透過以下程式碼使用 Transform 屬性（適用於整個文字區塊）：

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Microsoft PowerPoint 與 Aspose.Slides for Android (Java) 都提供多種預先定義的變形類型。 

{{% /alert %}} 

**使用 PowerPoint**

若要使用預先定義的變形類型，請依序前往：**格式** -> **文字效果** -> **變形**

**使用 Aspose.Slides**

若要選取變形類型，請使用 TextShapeType 列舉。 

### **套用 3D 效果至文字與圖形**

我們使用以下範例程式碼為文字圖形設定 3D 效果：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

文字或其圖形套用 3D 效果以及效果之間的互動遵循特定規則。  
可將文字與其所屬圖形視為一個場景。3D 效果包含 3D 物件的表示以及物件被放置的場景。

- 若圖形與文字皆設定了場景，則以圖形的場景為較高優先權，文字的場景將被忽略。  
- 若圖形本身沒有場景但具備 3D 表示，則會使用文字的場景。  
- 其他情況下——若圖形原本沒有 3D 效果——則圖形保持平面，3D 效果僅套用於文字。  

上述說明與 ThreeDFormat.getLightRig() 與 ThreeDFormat.getCamera() 方法相關。 

{{% /alert %}} 

## **套用外部陰影效果至文字**
Aspose.Slides for Android via Java 提供 [**IOuterShadow**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioutershadow/) 與 [**IInnerShadow**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinnershadow/) 類別，以便將陰影效果套用至由 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/) 承載的文字。請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。  
2. 使用索引取得投影片的參考。  
3. 在投影片中加入 Rectangle 類型的 AutoShape。  
4. 取得與 AutoShape 相關聯的 TextFrame。  
5. 將 AutoShape 的 FillType 設為 NoFill。  
6. 建立 OuterShadow 類別的實例。  
7. 設定陰影的 BlurRadius。  
8. 設定陰影的 Direction。  
9. 設定陰影的 Distance。  
10. 將 RectangleAlign 設為 TopLeft。  
11. 將陰影的 PresetColor 設為 Black。  
12. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 取得投影片的參考
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增一個矩形類型的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 為矩形新增 TextFrame
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

## **套用內部陰影效果至圖形**
請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。  
2. 取得該投影片的參考。  
3. 在投影片中加入 Rectangle 類型的 AutoShape。  
4. 啟用 InnerShadowEffect。  
5. 設定所有必要參數。  
6. 將 ColorType 設為 Scheme。  
7. 設定 Scheme Color。  
8. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 取得投影片的參考
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增一個矩形類型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 為矩形新增 TextFrame
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // 啟用 InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 設定所有必要的參數
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // 設定 ColorType 為 Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // 設定 Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // 儲存簡報
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### 我可以在不同的字型或文字系統（例如阿拉伯文、中文）上使用 WordArt 效果嗎？

可以，Aspose.Slides 支援 Unicode，並與所有主要字型與文字系統相容。陰影、填色與輪廓等 WordArt 效果均可套用，雖然字型可用性與呈現可能受系統字型影響。

### 我可以將 WordArt 效果套用到投影片母片元素嗎？

可以，您可以將 WordArt 效果套用至母片投影片上的圖形，包括標題佔位區、頁腳或背景文字。對母版佈局所做的變更會套用到所有相關投影片上。

### WordArt 效果會影響簡報檔案大小嗎？

會略微影響。陰影、發光與漸層填色等效果會因新增的格式資訊稍微增加檔案大小，但差異通常可忽略不計。

### 我能在未儲存簡報的情況下預覽 WordArt 效果的結果嗎？

可以，您可使用 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 介面的 `getImage` 方法將含有 WordArt 的投影片渲染為圖片（例如 PNG、JPEG），以便在記憶體或螢幕上即時預覽結果，無需儲存或匯出完整簡報。