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
description: "使用 Aspose.Slides for PHP via Java 轉換您的 PPT 與 PPTX 檔案，套用進階形狀效果——在數秒內製作引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓形狀突出，但它們與 [fills](/slides/zh-hant/php-java/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在形狀上建立逼真的倒影、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合看起來比其他組合更好。因此，PowerPoint 在 **Preset** 下提供了選項。Preset 選項是已知看起來不錯的兩種或多種效果的組合。這樣，透過選取預設，您就不必浪費時間測試或組合不同的效果以找到理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 類別中提供屬性與方法，讓您在 PowerPoint 簡報的形狀上套用相同的效果。

## **套用陰影效果**

Aspose.Slides for PHP via Java 支援對形狀使用外部與內部陰影。您可以自訂它們的顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景上脫穎而出。陰影延伸至形狀邊緣之外，營造形狀浮於投影片之上的感覺。調整顏色、方向、距離與模糊半徑，使其符合範本的光線與樣式。

以下 PHP 程式碼示範如何將 [outer shadow effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用到矩形：

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

### **套用內部陰影**

在重現範本的視覺樣式時，使用內部陰影可讓卡片或面板呈現凹陷外觀。外部陰影延伸至形狀之外，使其看起來抬升；而內部陰影則在形狀邊緣內側著色。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然後使用 [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) 取得的陰影進行設定。較大的模糊半徑會產生較柔和的邊緣。

以下 PHP 範例建立一個淡藍色卡片，並加上深灰色內部陰影，最後將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

![帶內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的 effect format 上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

### **套用、變更與移除預設陰影**

呼叫 [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) 以啟用預設陰影。使用 [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) 來選取 [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) 或在同一形狀上切換至其他樣式。呼叫 [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) 可在保留填色與輪廓的同時移除陰影。

以下 PHP 範例在每個前置階段後都會克隆矩形，讓您在同一張投影片上並排比較四個階段。兩個陰影均偏移 10 點。225° 的方向將第一個陰影置於矩形的左上方，45° 的方向則將第二個陰影置於右下方。

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

要在 Aspose.Slides for PHP via Java 中套用反射效果，您可以為形狀加入鏡面般的反射，調整距離、透明度與大小等參數。此效果可提升簡報的美感，使形狀更具精緻與專業感。使用簡單程式碼即可快速在多個元素上套用，實現一致的設計風格。

以下 PHP 程式碼示範如何將 [reflection effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) 套用到形狀：

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

要在 Aspose.Slides for PHP via Java 中為形狀套用發光效果，您可以在形狀周圍加入柔和的光暈，並調整顏色與大小等屬性。此效果有助於讓形狀突出，為簡報增添吸引人的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 PHP 程式碼示範如何將 [glow effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) 套用到形狀：

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

要在 Aspose.Slides for PHP via Java 中套用柔和邊緣效果，您可以在形狀邊緣周圍建立平滑、模糊的過渡。此效果可為設計增添更細緻、柔和的外觀，特別適合需要柔和呈現的版面。您可以輕鬆調整半徑等參數，以在簡報中的各種形狀上實現理想效果。

以下 PHP 程式碼示範如何將 [soft edges effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用到形狀：

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

使用形狀模糊可在保持形狀可編輯的前提下，使其填色與輪廓變得柔和。對形狀的 effect format 呼叫 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)。半徑以點 (1/72 英吋) 為單位；使用非負值，值越大模糊程度越強。半徑為零時外觀保持不變。

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 設定控制效果的可視範圍。設定為 `false` 時，模糊會被限制在原始繪製範圍內（包括輪廓）；設定為 `true` 時，模糊可延伸超出該範圍。此設定不會改變形狀的位置或尺寸。

下方比較使用相同的填色、輪廓與形狀尺寸，上排為 `grow = false`，下排為 `grow = true`。

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

以下 PHP 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) 改為 15 點模糊，並分別儲存兩個模糊狀態。最後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) 並儲存未模糊的形狀。

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

形狀模糊同時影響填色與輪廓。柔和邊緣效果會淡化形狀的邊緣，而陰影模糊僅軟化陰影。影像變換效果作用於影像內容；本範例直接對形狀的 effect format 套用模糊，未將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

可以，您可以將陰影、反射、發光等不同效果組合在單一形狀上，產生更具動態的外觀。

**哪些形狀可以套用效果？**

您可以對各種形狀套用效果，包括自動圖形、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，效果會套用到整個群組。