---
title: 使用 PHP 在簡報中套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/php-java/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔和邊緣效果
- 效果格式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，透過進階形狀效果轉換您的 PPT 與 PPTX 檔案——在幾秒內製作引人注目、專業的簡報投影片。"
---
## **簡介**

儘管 PowerPoint 中的效果可用於讓形狀更突出，但它們與 [填色](/slides/zh-hant/php-java/shape-formatting/#gradient-fill) 或輪廓不同。利用 PowerPoint 效果，您可以在形狀上創建逼真的倒影、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合比其他組合更好看。為此，PowerPoint 在 **Preset** 下提供選項。預設選項是兩個或多個已知好看的效果組合。這樣，透過選擇預設，您不必浪費時間測試或組合不同效果以找到理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 類別下提供屬性與方法，讓您能在 PowerPoint 簡報中對形狀套用相同的效果。

## **套用陰影效果**

Aspose.Slides for PHP via Java 支援形狀的外部與內部陰影。您可以自訂它們的顏色、方向、距離與模糊半徑，以符合簡報設計。

### **套用外部陰影**

使用外部陰影讓卡片或面板在投影片背景上更顯眼。陰影延伸至形狀邊緣之外，產生形狀高於投影片的感覺。調整其顏色、方向、距離與模糊半徑，以配合模板的光源與樣式。

此 PHP 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用到矩形：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![陰影效果](shadow_effect.png)

#### **控制形狀旋轉時的陰影方向**

預設情況下，外部陰影會隨形狀旋轉。若要讓不同旋轉角度的形狀看起來皆來自相同方向的光源，請以 `false` 呼叫 [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape)，並使用 [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) 為它們的陰影設定相同方向。

此範例建立兩個藍色箭頭，並將灰色陰影向右偏移 42 點 (0°)。接著複製投影片，將兩個箭頭順時針旋轉 90°。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在第二張投影片中，左側箭頭的陰影向下投射，而右側箭頭的陰影仍向右。兩個陰影的方向皆保持 0°。

![PowerPoint 於 90° 旋轉前後的呈現。兩個陰影起始位於右側。旋轉後，左側箭頭的陰影移至下方，右側箭頭的陰影仍在右側。](arrow-shadow-rotation.png)

### **套用內部陰影**

在還原模板的視覺樣式時，使用內部陰影讓卡片或面板呈現凹陷效果。外部陰影向外延伸，使形狀看起來凸起；內部陰影則在邊緣內側著色。

先呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)，再設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) 取得的陰影。較大的模糊半徑會產生較柔和的邊緣。

此 PHP 範例建立一個淡藍色卡片，並套用深灰色內部陰影，最後保存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![帶有內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的效果格式上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

### **套用、更改與移除預設陰影**

呼叫 [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) 以啟用預設陰影。使用 [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) 選取 [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) 或在同一形狀上切換至其他樣式。呼叫 [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) 可在保留填色與輪廓的同時移除陰影。

此 PHP 範例在前三個階段之後各複製一次矩形，讓您能在同一投影片上並排比較四個階段。兩個陰影皆偏移 10 點。225° 的方向將第一個陰影置於矩形的左上方，45° 的方向將第二個陰影置於右下方。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 原始 | 第一個預設 | 第二個預設 | 移除後 |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **套用反射效果**

若要在 Aspose.Slides for PHP via Java 中套用反射效果，您可以為形狀加入類鏡面的反射，並調整距離、透明度與大小等參數。此效果透過賦予形狀更精緻、專業的外觀，提升簡報的美感。實作簡單，只需少量程式碼，即可在多個元素間快速套用，保持設計一致性。

此 PHP 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) 套用到形狀：

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![反射效果](reflection_effect.png)

## **套用發光效果**

要在 Aspose.Slides for PHP via Java 中為形狀套用發光效果，您可以在形狀周圍加入柔和的光暈，並調整顏色與大小等屬性。此效果能讓形狀更突出，為簡報增添吸睛的視覺元素。實作簡易，僅需少量程式碼，即可提升投影片的整體觀感。

此 PHP 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) 套用到形狀：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![發光效果](glow_effect.png)

## **套用柔和邊緣效果**

若要在 Aspose.Slides for PHP via Java 中套用柔和邊緣效果，您可以在形狀的邊緣周圍建立平滑、模糊的過渡。此效果為設計增添細膩、精緻的感受，適合需要柔和外觀的版面。您可以輕鬆調整半徑等參數，以在簡報中的各種形狀上達到理想的視覺效果。

此 PHP 程式碼示範如何將 [柔和邊緣效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用到形狀：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![柔和邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可在保持形狀可編輯的前提下柔化其填色與輪廓。對形狀的效果格式呼叫 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)。半徑以點為單位 (1/72 英吋)：使用非負值，值越大模糊程度越強。半徑為零時外觀保持不變。

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 設定控制效果的可見範圍。`false` 時，模糊被裁剪至原始繪製範圍（含輪廓）；`true` 時，模糊可延伸超出該範圍。此設定不會改變形狀的位置或尺寸。

以下比較使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形比較，模糊半徑分別為 5 點與 15 點，分別在關閉與開啟 grow 時的樣子](shape_blur_comparison.png)

此 PHP 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) 變更為 15 點模糊，並保存兩種模糊狀態；最後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) 並保存未模糊的形狀。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

形狀模糊會同時影響填色與輪廓。柔和邊緣效果會淡化形狀邊緣，而陰影模糊僅柔化陰影本身。影像變換效果作用於影像內容；此範例直接在形狀的效果格式上套用模糊，無需將形狀轉換為影像。

## **常見問答**

**我可以對同一個形狀套用多個效果嗎？**

可以，您可以在同一個形狀上結合不同的效果，例如陰影、反射與發光，以打造更具動態感的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖形、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，效果會套用到整個群組。