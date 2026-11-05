---
title: 在 PHP 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/php-java/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 草圖效果
- 圖形線條草圖
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 黑白圖形呈現
- 灰階圖形呈現
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式化
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中使用 Aspose.Slides 格式化 PowerPoint 圖形——精確且完整控制 PPT 與 PPTX 檔案的填色、線條與效果樣式。"
---
## **簡介**

透過調整外框、填色和效果，於 PowerPoint 中格式化圖案。Aspose.Slides for PHP via Java 讓您以程式方式控制這些設定，包括透明度、旋轉和 3D 格式化。

![PowerPoint 中的圖案格式化選項](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java 提供類別與方法，讓您使用 PowerPoint 中相同的選項來格式化圖案。

## **格式化線條**

使用 [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) 來控制圖案的外框。本範例建立一個未填色、藍色虛線外框的矩形。[LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) 選擇粗細複合線，而 [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) 設定寬度為 7 點，並且 [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) 選擇虛線樣式。

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![簡報中已格式化的線條](formatted-lines.png)

### **設定自訂線條虛線模式**

當預設線條樣式無法提供所需的虛線長度與間隔時，請使用 [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern)，例如品牌外框或技術圖表。指定模式後會自動將線條虛線樣式變更為 [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/)。

陣列項目在虛線與間隔長度之間交替，從虛線開始。每個值都是線寬的倍數：在寬度為 3 點時 `[4, 2]` 會產生 12 點虛線接著 6 點間隔。使用成對的有限、非負值來定義完整的虛線與間隔段落。範例使用正值，以確保每個虛線與間隔皆可見。

此範例建立五條藍色線條，長度相同且端點為平坦。前三條在寬度 3 點下比較不同模式。第四條以兩倍寬度重複第一種模式，虛線與間隔長度同時加倍。第五條則從自訂模式切換為實線。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // 將最後一條線設定為實線樣式。
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若要改回預設的虛線樣式，請將 [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) 傳遞給 [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle)。所選樣式會控制線條的外觀。

PowerPoint 中的結果，從上到下：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![三種自訂虛線模式、使用第一種模式且較寬的線條，以及實線在 PowerPoint 中的顯示](custom-dash-patterns.png)

### **設定線條端點樣式**

使用 [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) 設定開放線條的端點。[LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) 類別提供三種明確的端點樣式：

- `Flat`：筆畫於端點處停止。
- `Round`：半圓形端點延伸至端點之外，延伸距離為線寬的一半。
- `Square`：方形端點延伸至端點之外，延伸距離為線寬的一半。

此類別亦包含 `NotDefined`，表示未明確指派端點樣式。

端點樣式不同於箭頭（在端點加入符號）以及接合點（控制線段之間的拐角）。此範例透過 [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) 和 [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) 停用箭頭，以便僅比較端點形狀。

以下範例建立三條除端點樣式外完全相同的水平線條，寬度為 20 點。從上到下分別使用平坦、圓形與方形端點。它們的端點水平座標相同；圓形與方形端點在每個端點之外延伸 10 點。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的結果，從上到下：**Flat**、**Round**、**Square**。

![在 PowerPoint 中相同粗線的平坦、圓形與方形端點](line-caps.png)

## **將草圖效果套用到圖案線條**

草圖效果讓圖案線條看起來像手繪。使用 [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) 取得線條設定，接著使用 [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) 取得草圖設定，並透過 [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) 從 [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 類別中選取值。

以下 PHP 程式碼示範如何套用 [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並使用 [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 移除效果：

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) 回傳的值代表直接指派給圖案的設定。若線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective)，存取回傳物件的 `getSketchFormat` 方法，並讀取其 `getSketchType` 值。Effective 值會在繼承解析後反映實際套用的格式。此範例需要一個已有的簡報，且第一張投影片上至少有一個圖案，並列印兩個值：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **格式化接合樣式**

以下是三種接合類型選項：

* Round
* Miter
* Bevel

接合樣式控制兩段外框在拐角處的相接方式。使用 **Round** 產生圓角，**Miter** 產生尖角，**Bevel** 產生平緩的拐角。

![簡報中的接合樣式](join-style-powerpoint.png)

此範例建立三個黑色矩形，藍色外框寬度 15 點。分別將 [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) 設為 [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) 中的斜接、斜角和平滑，以比較拐角的繪製方式。

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **在尖銳拐角限制斜接**

使用 [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) 搭配將 [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) 設為 [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) 以限制尖銳拐角的延伸程度。

此限制為內外拐角距離與線寬的比例。例如，值 `8` 允許斜接長度最高為線寬的八倍；這不是以點數作為測量單位。若拐角長度超過限制，PowerPoint 會在該拐角使用斜角接合。較大的限制可產生更銳利的點。此設定僅影響斜接，當拐角仍在兩個限制內時，變更不會產生可見效果。

此範例建立兩個相同、未填色的三角形，外框寬度 20 點。左側三角形使用 `2` 的限制，右側使用 `8`。每個三角形寬 80 點、高 160 點，頂部拐角的斜接長度與線寬比例約為 `4.12`。因此 PowerPoint 會將左側尖端斜角化，右側則保留尖銳尖端。

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的結果：左側 **Miter limit 2**，右側 **miter limit 8**。

![在 PowerPoint 中，斜接限制 2 的斜角與斜接限制 8 的尖銳角](miter-limits.png)

## **漸層填色**

漸層填色會在圖案內混合顏色。本範例使用 [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) 在橢圓形上套用 45 度角的線性漸層，顏色從紅色到紫色。[GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) 方法在 0 與 1 位置（漸層的起始與結束）放置顏色停點。清除現有停點可確保僅使用這兩種顏色。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![具有漸層填色的橢圓形](gradient-fill.png)

若匯出圖像的漸層與 PowerPoint 中顯示不同，請參閱 [選擇漸層呈現樣式](/slides/zh-hant/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不變更簡報中儲存的漸層填色的前提下，選擇不同的呈現樣式。

### **設定線性漸層角度**

使用 [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) 來控制 [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) 填色的方向。角度以度為單位，順時針遞增：`0` 為左至右，`90` 為上至下，`180` 為右至左，`270` 為下至上。支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一圈，例如 `-45` 變為 `315`，`360` 變為 `0`。

此範例建立六個矩形，均使用相同的紅、綠、藍三個停點，位置分別為 `0`、`0.5`、`1`。停用縮放，使角度比較不受矩形比例影響。從左至右的角度依序為第一列的 `0`、`45`、`90`，第二列的 `135`、`180`、`270`。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的結果：

![上排 0、45、90 度的線性漸層，下排 135、180、270 度的線性漸層](linear-gradient-angles.png)

### **以圖形縮放線性漸層**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) 接受 [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 值。將其明確設為 `False`，在圖形比例變化時保留幾何漸層角度；設為 `True`，則隨圖形的寬高一起縮放漸層。啟用縮放時，非正方形圖形的可見角度可能與指定角度不同。

以下範例使用 `45` 度角與先前相同的顏色停點。左欄設為 `False`，右欄設為 `True`。每欄包含一個寬矩形上方與一個高矩形下方。兩個矩形最初尺寸相同；變更第二個矩形的寬高，可觀察在不改變漸層設定的前提下，填色如何回應調整大小。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的結果：左側縮放停用，右側縮放啟用：

![寬矩形與高矩形的 45 度漸層，左側 LinearGradientScaled 為 False，右側為 True](linear-gradient-scaling.png)

縮放停用時，對角色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨圖形比例伸展。此行為有助於在將圖形調整至不同大小時，復製範本的漸層效果。在正方形上，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定僅適用於線性漸層，並不控制 [GradientShape::Radial 或 GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) 填色。

### **結合角度與漸層方向**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) 從 [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) 類別中選取漸層樣式；它並非數值角度的替代方案。對於線性漸層，角落樣式可以改變顏色分布的區域，而不改變透過 [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) 指定的角度。比較角度或縮放時，請保持方向不變。

以下範例以相反的順序套用相同設定。兩個矩形的外觀相同：先設定方向再設定角度或相反，結果皆不變。

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **圖案填色**

圖案填色會套用兩色設計，例如點、條紋或棋盤。本範例使用 [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) 選取格子圖案。[PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) 提供淡灰色背景，而 [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) 提供黃色圖案顏色。

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![具有圖案填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色將影像放入圖案內。本範例需要本機影像，並使用 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) 載入至簡報的影像集合。將 [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) 設為平鋪模式，即可在矩形內重複影像。以下顯示使用的來源圖片：

![蓮花圖片](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![具有圖片填色的圖案](picture-fill.png)

### **將圖片平鋪為紋理**

若想將平鋪圖片設定為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填色模式 — `Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪在圖形內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪是否水平、垂直或雙向翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪相對於圖形原點的水平偏移（點）。
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪相對於圖形原點的垂直偏移（點）。
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX)：定義平鋪的水平比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY)：定義平鋪的垂直比例（百分比）。

此範例需要本機圖片，並將 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 設定為以原始大小 50% 重複。將 X、Y 偏移設為 -32 點，使平鋪在水平與垂直方向上平移；右下對齊且雙向翻轉決定了重複紋理的排列方式。

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![平鋪選項示意圖](tile-options.png)

## **純色填色**

純色填色為圖案賦予單一、均勻的顏色。本範例將 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 設為純色填色模式，並透過 [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 指派黃色，最後將矩形儲存至簡報。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![具有純色填色的圖案](solid-color-fill.png)

### **在保留佈景主題參照的前提下複製顏色**

使用 [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) 複製顏色定義，包含其顏色類型、佈景主題參照與變換。此方式在將填色在不同圖案間傳遞時仍能跟隨簡報主題。此方法僅複製顏色本身，不會複製填色類型、外框或其他圖案格式。請使用 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 明確設定目標的填色類型。

此範例建立三個矩形，從左至右分別為：來源、具佈景主題感知的副本、以及固定 RGB 的副本。來源使用 [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) 參照第一個強調色，並透過 [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add) 加上色調。RGB 副本使用來源的有效填色，因此三者最初看起來相同。呼叫 [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) 後，會設定固定的 RGB 值，並清除任何既有的顏色變換。

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // 主題參照會跟隨新的強調色；固定的 RGB 值不會。
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在更改佈景主題前，所有三個填色相同：

![來源、copyFrom 目的地與固定 RGB 目的地的相同藍色填色](color-copy-before.png)

更改佈景主題後，來源與具佈景主題感知的副本會跟隨新的強調色並保留色調，固定 RGB 副本仍保持藍色：

![來源與 copyFrom 目的地呈現橘色填色，固定 RGB 目的地仍為藍色](color-copy-after.png)

複製的定義獨立於來源。之後若變更來源的佈景主題參照、指派其他顏色，或增減其變換，都不會影響目的地。佈景主題變更仍會同時影響兩個圖案，因為它們各自獨立參照相同的佈景主題顏色。

儲存並重新開啟 PPTX 時，會保留由 [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType) 回傳的顏色類型、佈景主題參照，以及由 [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform) 回傳的變換集合；不會將定義扁平化為 RGB。

在不同佈景主題上下文（例如佈景主題色盤不同的簡報）之間複製時，複製的參照會以目的地的佈景主題進行解析。因此相同的參照與變換可能產生不同的可見顏色。請參閱 [簡報佈景主題](/slides/zh-hant/php-java/presentation-theme/) 以了解更多佈景主題顏色設定資訊。

## **將投影片背景作為圖案填色**

當圖案需要與投影片背景一致時（例如在簡報範本中），請使用 [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill)。先以 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 設為 [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 以移除任何顯式填色，然後再啟用此旗標。這樣圖案會使用投影片背景而非其樣式填色。僅啟用旗標不會移除已存在的顯式填色。

這與 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 不同：背景填色會以投影片背景的相應區域覆蓋圖案後方的物件，而無填色則會讓這些物件保持可見。漸層仍會與投影片對齊，且不會在每個圖案內重新開始。

以下範例建立一個由母片繼承的背景，投影片上放置一條品紅色帶，置於三個矩形後方。左側矩形使用背景填色，中間矩形無填色，右側矩形則從背景填色切換為顯式的橙色填色。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // 從母片繼承漸層。
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // 先加入此物件，使其顯示在矩形後方。
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // 在套用明確填色前停用背景填色。
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果，從左至右：**背景填色**、**無填色**、**顯式填色**。品紅色帶被左側與右側矩形遮蓋，但在中間矩形下仍可見。

![背景填色、無填色與顯式橙色填色覆蓋在品紅色帶上](background-fill.png)

相同的行為亦適用於直接在投影片上或從版面繼承的背景。圖案會使用投影片解析後的背景；本範例將投影片與版面的背景皆保持未定義，讓母片提供背景。

## **設定透明度**

對於純色填色，顏色的 alpha 成分控制不透明度：0 為完全透明，255 為完全不透明。本範例將 alpha 設為 128，為黃色矩形提供約 50% 的透明度，使其下方的矩形仍可見。顏色透過 [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 指派。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![具有透明效果的圖形](shape-transparency.png)

## **旋轉圖案**

使用 [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 以在投影片平面上旋轉圖案。角度以度為單位；本範例將矩形順時針旋轉 5 度，並儲存簡報。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![圖形旋轉效果](shape-rotation.png)

## **添加 3D 斜角效果**

使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) 為圖案賦予深度與斜角邊緣。本範例建立一個綠色橢圓，橙色外框，將 [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) 設為 4 點，並透過 [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) 設定寬高皆為 6 點的圓形上斜角。使用正視正交相機與三點照明，使斜角可見。

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![3D 斜角效果示意圖](3D-bevel-effect.png)

## **添加 3D 旋轉效果**

圖案的 3D 視圖由相機設定控制。本範例使用 [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) 設定緯度、經度與翻轉角度分別為 40、35、20 度。然後透過 [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) 選擇等角相機，並使用 [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) 設定平衡光源，最後儲存已格式化的矩形。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![3D 旋轉效果示意圖](3D-rotation-effect.png)

## **控制圖案的黑白呈現模式**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定在以黑白模式檢視或處理簡報時，個別圖案的呈現方式。此設定本身不會啟用黑白顯示，也不會在正常彩色模式下更改圖案的填色、線條或其他格式。

請使用 [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) 類別中的值選取所需行為。例如，`Automatic` 讓呈現應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階顏色，`BlackWhite` 只使用黑白，`Black` 與 `White` 強制單一顏色，`Color` 保留正常著色，`Hidden` 在黑白模式下隱藏圖案，`NotDefined` 表示未指派圖案層級模式。

此範例建立一個橙色矩形，並將 [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) 設為灰色。儲存的圖案在正常彩色顯示時仍保留橙色填色，且在遵循黑白顯示設定的應用程式中會以灰色呈現：

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在正常彩色模式下，矩形保留橙色填色。在黑白顯示工作流程中，因模式設定為 `Gray`，會使用灰色著色。這讓您在保留完整彩色投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式化**

使用 [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) 從對應的版面佈局占位符還原投影片占位符的位置、大小與格式。本範例需要一個已存在且占位符已連結至版面的簡報，並在儲存前重設每張投影片。沒有對應版面占位符的圖案不會被重設。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題集**

**圖案格式化會影響最終簡報檔案大小嗎？**

相較於嵌入的影像與多媒體，顏色、線條樣式與效果設定通常只會增加少量資料。圖片填色可能會因其影像儲存於簡報中而增大檔案大小。

**如何偵測投影片上具有相同格式的圖案，以便將它們分組？**

比較每個圖案的關鍵格式屬性——填色、線條與效果設定。若全部對應值相同，即可視為樣式相同，並在邏輯上將這些圖案分組，這樣可簡化後續的樣式管理。

**我可以將自訂的圖案樣式集合儲存至獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範例圖案儲存於範本投影片或 .POTX 範本檔。建立新簡報時，開啟該範本，複製所需的樣式圖案，並在需要的地方重新套用其格式。