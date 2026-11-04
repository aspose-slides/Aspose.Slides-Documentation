---
title: 在簡報中使用 PHP 套用形狀效果
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
description: "使用 Aspose.Slides for PHP via Java 以進階形狀效果轉換您的 PPT 和 PPTX 檔案──在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

PowerPoint 的效果可用於讓形狀突出，但它們不同於 [填色](/slides/zh-hant/php-java/shape-formatting/#gradient-fill) 或輪廓。使用 PowerPoint 效果，您可以在形狀上製作逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一種或多種效果。

某些效果組合比其他組合更佳。為此，PowerPoint 在 **Preset** 下提供選項。Preset 選項是兩種或多種已知效果良好組合的預設。透過選取預設，您不必花時間測試或組合不同效果以尋找合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 類別中提供屬性與方法，讓您能在 PowerPoint 簡報的形狀上套用相同的效果。

## **套用陰影效果**

Aspose.Slides for PHP via Java 支援形狀的外部與內部陰影。您可以自訂顏色、方向、距離與模糊半徑，使其符合簡報設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景上突出。陰影延伸至形狀邊緣之外，營造形狀浮起於投影片上的感受。調整其顏色、方向、距離與模糊半徑，以符合範本的光線與樣式。

以下 PHP 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用至矩形：

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

在還原範本的視覺樣式時，使用內部陰影可為卡片或面板營造凹陷的外觀。外部陰影延伸於形狀外部，使其看起來浮起；內部陰影則為其邊緣內側增添陰影。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) 取得的陰影。較大的模糊半徑會產生較柔和的邊緣。

以下 PHP 範例會建立一個淡藍色卡片，並套用深灰色內部陰影，最後儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

![內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請對形狀的 effect format 呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

## **套用反射效果**

在 Aspose.Slides for PHP via Java 中套用反射效果時，您可以為形狀新增鏡面般的反射，並調整距離、透明度與大小等參數。此效果可提升簡報的美感，使形狀呈現更精緻與高雅的外觀。只需簡單程式碼即可輕鬆實作，快速於多個元素套用，以維持一致的設計風格。

以下 PHP 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) 套用至形狀：

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

在 Aspose.Slides for PHP via Java 中為形狀套用發光效果時，您可以在形狀周圍加入柔和且發光的光環，並調整顏色與大小等屬性。此效果有助於讓形狀突出，為簡報增添吸引目光的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 PHP 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) 套用至形狀：

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

在 Aspose.Slides for PHP via Java 中套用柔和邊緣效果時，您可以在形狀邊緣創建平滑且模糊的過渡。此效果增添更細緻且精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報各種形狀上取得理想效果。

以下 PHP 程式碼示範如何將 [柔和邊緣效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用至形狀：

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

使用形狀模糊可柔化形狀的填色與輪廓，同時保持形狀可編輯。對形狀的 effect format 呼叫 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)。半徑以點 (1/72 英吋) 為單位：使用非負值，較大的數值會產生較強的模糊。半徑為零則不改變外觀。

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 設定控制效果的可見範圍。設定為 `false` 時，模糊會被裁剪至原始繪製範圍，包括輪廓；設定為 `true` 時，模糊可延伸至該範圍之外。此設定不會改變形狀的位置或尺寸。

下方比較使用相同的填色、輪廓與形狀尺寸。上列使用 `grow = false`；下列使用 `grow = true`。

![原始矩形比較，模糊半徑 5 與 15 點，grow 關閉與啟用](shape_blur_comparison.png)

以下 PHP 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) 將其更新為 15 點模糊。它會儲存兩個模糊狀態，接著呼叫 [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) 並儲存未套用模糊的形狀。

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

形狀模糊同時影響填色與輪廓。柔和邊緣效果會淡化形狀的邊緣，而陰影模糊僅軟化陰影。影像轉換效果作用於影像內容；此範例直接對形狀的 effect format 套用模糊，未將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同效果，例如陰影、反射與發光，以產生更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。該效果會套用於整個群組。