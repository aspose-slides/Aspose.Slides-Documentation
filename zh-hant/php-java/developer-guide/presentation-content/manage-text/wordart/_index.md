---
title: 在 PHP 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/php-java/wordart/
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
- PHP
- Aspose.Slides
description: 在 Aspose.Slides for PHP via Java 中建立與自訂 WordArt 效果。本分步指南協助開發人員以專業的文字提升簡報。
---
## **概覽**

WordArt 效果可讓您在 PowerPoint 簡報中加入視覺上吸引人且具風格的文字。使用 Aspose.Slides，開發人員可以以程式方式建立、客製化並管理 WordArt，與 Microsoft PowerPoint 的操作方式相同，且不需要安裝 Office。本文概述了 WordArt 的使用方式，包括如何套用文字變形、填色樣式、輪廓、陰影以及其他格式設定，讓簡報內容更具表現力與吸引力。WordArt 允許您將文字視為圖形物件，透過對文字套用效果或特殊變更，使其更具吸引力或突出。

## **建立簡易 WordArt 範本並套用至文字**

**使用 Aspose.Slides** 

首先，我們使用以下 PHP 程式碼建立簡單的文字：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
接著，透過以下程式碼將文字的字型高度設定為較大值，以使效果更明顯：

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**使用 Microsoft PowerPoint**

前往 Microsoft PowerPoint 中的 WordArt 效果功能表：

![todo:image_alt_text](image-20200930113926-1.png)

在右側功能表中，您可以選擇預先定義的 WordArt 效果；在左側功能表中，您可以為新 WordArt 指定設定。

以下為可用的參數或選項範例：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我們將 [SmallGrid](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/patternstyle/#SmallGrid) 圖案色彩套用至文字，並使用以下程式碼加入 1 寬度的黑色文字框線：

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

產生的文字如下：

![todo:image_alt_text](image-20200930114108-4.png)

## **套用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程式介面中，您可以將這些效果套用至文字、文字方塊、圖案或類似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，陰影、反射與發光效果可套用於文字；3D 格式與 3D 旋轉效果可套用於文字方塊；柔化邊緣屬性則可套用於圖形物件（即使未設定 3D 格式屬性亦會產生效果）。

### **套用陰影效果**

此範例僅針對文字設定相關屬性，使用以下程式碼將陰影效果套用至文字：

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```

Aspose.Slides API 支援三種陰影類型：OuterShadow、InnerShadow 與 PresetShadow。

使用 PresetShadow 時，您可以套用預設值的文字陰影。

**使用 Microsoft PowerPoint**

在 PowerPoint 中只能使用一種陰影類型，範例如下：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 實際上允許同時套用兩種陰影：InnerShadow 與 PresetShadow。

**注意事項：**

- 同時使用 OuterShadow 與 PresetShadow 時，僅會套用 OuterShadow 效果。 
- 若同時使用 OuterShadow 與 InnerShadow，最終套用的效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中效果會加倍，而在 PowerPoint 2007 中則只套用 OuterShadow。

### **套用文字反射效果**

使用以下程式範例為文字加入反射：

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **套用文字發光效果**

使用以下程式碼將發光效果套用至文字，使其閃耀或突出：

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

操作結果如下：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以變更陰影、反射與發光的參數。這些效果屬性會分別設定於文字的每個區段。 

{{% /alert %}} 

### **在 WordArt 中使用變形**

使用以下程式碼透過 Transform 屬性（適用於整個文字區塊）套用變形：

```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

結果如下：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 與 Aspose.Slides for PHP via Java 均提供多種預先定義的變形類型。

{{% /alert %}} 

**使用 PowerPoint**

前往 **格式** → **文字效果** → **變形** 以存取預先定義的變形類型。

**使用 Aspose.Slides**

使用 TextShapeType 列舉選取變形類型。

### **套用 3D 效果至文字與圖形**

使用以下範例程式碼將 3D 效果套用至文字圖形：

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

產生的文字與圖形如下：

![todo:image_alt_text](image-20200930114816-9.png)

使用以下 PHP 程式碼將 3D 效果套用至文字：

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

操作結果如下：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

文字或其圖形套用 3D 效果及效果之間的相互作用遵循特定規則。

將文字與包含該文字的圖形視為一個場景。3D 效果包含 3D 物件表示與放置該物件的場景。

- 若圖形與文字皆設定了場景，圖形的場景優先—文字的場景會被忽略。 
- 若圖形沒有自己的場景但具有 3D 表示，則使用文字的場景。 
- 其他情況下——圖形原本沒有 3D 效果——圖形保持平面，3D 效果僅套用於文字。 

上述說明與 ThreeDFormat.getLightRig() 與 ThreeDFormat.getCamera() 方法相關。

{{% /alert %}} 

## **套用外部陰影效果至文字**
Aspose.Slides for PHP via Java 提供 [OuterShadow](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/outershadow/) 與 [InnerShadow](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/innershadow/) 類別，讓您對由 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 所承載的文字套用陰影效果。請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 向投影片新增類型為 Rectangle 的 AutoShape。  
4. 取得該 AutoShape 所關聯的 TextFrame。  
5. 將 AutoShape 的 FillType 設為 NoFill。  
6. 實例化 OuterShadow 類別。  
7. 設定陰影的 BlurRadius。  
8. 設定陰影的 Direction。  
9. 設定陰影的 Distance。  
10. 將 RectanglelAlign 設為 TopLeft。  
11. 將陰影的 PresetColor 設為 Black。  
12. 將簡報寫出為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例程式碼展示了上述步驟的實作，說明如何將外部陰影效果套用至文字：

```php
  $pres = new Presentation();
  try {
    # 取得投影片的參考
    $sld = $pres->getSlides()->get_Item(0);
    # 新增類型為 Rectangle 的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 為矩形新增 TextFrame
    $ashp->addTextFrame("Aspose TextBox");
    # 停用圖形填色，以便取得文字的陰影
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 新增外部陰影並設定所有必要參數
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # 將簡報寫入磁碟
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **套用內部陰影效果至圖形**
請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 取得投影片的參考。  
3. 新增類型為 Rectangle 的 AutoShape。  
4. 啟用 InnerShadowEffect。  
5. 設定所有必要參數。  
6. 將 ColorType 設為 Scheme。  
7. 設定 Scheme Color。  
8. 將簡報寫出為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例程式碼（根據上述步驟）示範如何在兩個圖形之間新增連接器：

```php
  $pres = new Presentation();
  try {
    # 取得投影片的參考
    $slide = $pres->getSlides()->get_Item(0);
    # 新增類型為 Rectangle 的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 為矩形新增 TextFrame
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # 啟用 InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # 設定所有必要參數
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # 將 ColorType 設為 Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # 設定 Scheme 顏色
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # 儲存簡報
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以在不同字型或文字系統（例如阿拉伯文、中文）上使用 WordArt 效果嗎？**

可以，Aspose.Slides 支援 Unicode，並可與所有主要字型與文字系統配合使用。無論語言為何，皆可套用陰影、填色與輪廓等 WordArt 效果；但字型的可用性與渲染可能會受到系統字型的影響。

**我可以將 WordArt 效果套用於投影片母片元素嗎？**

可以，您可以對母片投影片上的圖形套用 WordArt 效果，包括標題佔位符、頁腳或背景文字。對母片版面的變更會套用至所有相關投影片。

**WordArt 效果會影響簡報檔案大小嗎？**

會稍微增加。陰影、發光與漸層填色等效果會因為額外的格式化中繼資料而略增檔案大小，但差異通常可以忽略不計。

**我可以在未儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

可以，您可以使用 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 或 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 類別的 `getImage` 方法將包含 WordArt 的投影片渲染為影像（例如 PNG、JPEG），從而在記憶體或螢幕上即時預覽結果，而無需儲存或匯出完整簡報。