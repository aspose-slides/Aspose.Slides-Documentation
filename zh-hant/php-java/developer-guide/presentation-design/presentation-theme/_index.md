---
title: 在 PHP 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/php-java/presentation-theme/
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
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP（透過 Java）中管理簡報主題，以建立、客製化並轉換具一致品牌識別的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填滿、線條與效果。支援主題的物件會參照這些共用定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時可以一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)取得。簡報亦可在較低層級包含主題覆寫。母片可透過[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterthememanager/)覆寫簡報主題，而版面或個別投影片可透過[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)覆寫其繼承的主題。實務上，投影片的有效主題是透過以下繼承鏈決定：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題元件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 物件透過[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)與[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)提供主題的顏色方案、字型方案與格式方案。變更前先檢查這些集合特別有用，因為外部來源的簡報其樣式條目數量與內容可能不同。

以下範例讀取主要主題屬性，並回報主題中儲存的背景、填滿、線條與效果樣式數量：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。檢查與投影片關聯的母片，並在版面或投影片有覆寫可能時，使用本文後面說明的有效主題工作流程。

## **變更主題顏色**

支援主題的填滿、線條與文字可以參照[SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在[ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 中變更對應的條目時，所有仍參照該主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟，並印出有效的填滿顏色：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

因為矩形仍連結到 `Accent4`，在變更主題後其可見顏色會變成紅色。若您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響此填滿。

### **使用額外調色盤的顏色**

PowerPoint 會透過顏色轉換產生主題顏色的較亮與較暗變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colortransformoperation/) 列舉提供這些轉換。

![主要主題顏色與由額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 從主要主題顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度轉換，並儲存結果：

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

這些變體仍以主題顏色為基礎。如果之後 `Accent4` 變更，轉換後的顏色會依新 `Accent4` 重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而[ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 方式公開相同的主題插槽。對映關係固定：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

這些僅是同一主題插槽的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型方案包含用於標題的主要字型集與用於內文的次要字型集。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/) 方法公開這兩套字型。

PowerPoint 相容的主題字型識別子可在文字格式化時使用：

* `+mn-lt` - 內文字型拉丁文（Minor Latin Font）  
* `+mj-lt` - 標題字型拉丁文（Major Latin Font）  
* `+mn-ea` - 內文字型東亞文字（Minor East Asian Font）  
* `+mj-ea` - 標題字型東亞文字（Major East Asian Font）

以下範例建立一個使用主要拉丁字型的標題與一個使用次要拉丁字型的內文行，然後變更主題字型並儲存結果：

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

標題會遵循主要字型，內文會遵循次要字型。若文字使用明確的字型名稱而非主題識別子，當主題字型方案變更時不會自動切換。

主要與次要字型集合亦可能包含針對個別書寫系統（如西里爾、阿拉伯、日文、喬治亞文與塔納文）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script‑Specific Theme Fonts](/slides/zh-hant/php-java/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}

欲取得有關簡報字型的更多資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/php-java/powerpoint-fonts/)。

{{% /alert %}}

## **複製或套用主題**

有兩種常見工作流程，且解決不同的問題。

### **在移動投影片時保留來源主題**

若要將投影片搬移至其他簡報且保留其原始設計，請使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/)將來源母片克隆至目標簡報，接著使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/)與克隆的母片克隆投影片。這會同時攜帶母片、其版面與相關主題。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

當來源投影片必須在目的端保持相同外觀時，這是首選工作流程。僅將內容克隆至不相關的目的母片可能會改變主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須停留在其目前的母片與版面上，請使用來源主題初始化投影片層級的覆寫。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/) 方法會將三個主要主題元件複製入覆寫。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

此變更只會影響該投影片使用的主題，不會改變其他投影片繼承的主題。若要移除本地覆寫並回復至繼承值，呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslidethememanager/) 使用：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

當許多版面與投影片需要共用相同基礎設計時，使用母片或簡報層級主題；當單一版面族群需要不同樣式時，使用版面覆寫；僅在真正例外情況下才使用投影片覆寫。過多的投影片層級覆寫會讓之後的全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填滿儲存在[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中呈現的背景選擇可能多於此集合實際儲存的填滿定義，因為 UI 能將主題填滿與主題顏色及其他樣式參照組合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。`0` 表示無主題填滿；正值則是主題背景樣式的參照。這與直接索引 PHP 集合不同，`get_Item(0)` 代表第一筆儲存項目。請勿假設每個簡報都有相同數量的背景填滿樣式。

以下範例回報可用的背景填滿計數，將第一個母片指派為主題背景參照，並儲存簡報：

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

最終呈現結果取決於母片參照的主題條目以及版面或投影片層級的任何背景覆寫。如果投影片使用自己的背景，只變更母片背景可能不會影響該投影片。當需要取得繼承後的最終背景時，請使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。

{{% alert color="warning" title="警告" %}}

請勿將樣式索引當作零基集合索引。也不要硬編碼某檔案的樣式編號，並假設在另一檔案中會有相同外觀；主題樣式定義是與簡報特定的。

{{% /alert %}}

{{% alert color="info" title="提示" %}}

欲取得直接背景格式化與背景繼承的資訊，請參閱 [Presentation Background](/slides/zh-hant/php-java/presentation-background/)。

{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的填滿、線條與效果樣式集合，分別透過[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 暴露。一般 Office 主題通常包含三個主要樣式條目，視覺上分別對應細緻、適中與強烈的格式化，但程式碼應檢查每個集合而非假設固定數量。

![細緻、適中與強烈的主題效果套用於相同圖形](presentation-design_10.png)

在 PHP 中存取這些集合時，集合索引是零基的：`get_Item(0)` 為第一筆儲存的樣式，`get_Item(2)` 為第三筆。圖形的樣式參照索引是另一概念，透過[ShapeStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapestyle/) 暴露。變更主題樣式會影響參照該主題樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、變更第三個填滿樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

對於參照這些插槽的圖形，第一個主題線條樣式會變成紅色，第三個主題填滿樣式會變成實心森林綠，第三個效果樣式會獲得距離 10 點的外部陰影。最終視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填滿與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效的主題值**

原始主題物件只能告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對於投影片，呼叫[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)。對於背景，使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)，對於填滿，使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/)。

以下範例讀取投影片的有效主題、背景與第一個圖形的填滿：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

使用有效資料進行渲染偵錯、驗證與比較。如果您僅檢查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，可能會遺漏母片、版面、投影片或圖形的覆寫，從而錯過最終外觀的變化。

## **常見問題集**

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的[SlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更只會局部套用於該投影片，其他投影片繼續繼承其既有主題。

**從一個簡報搬移主題到另一個簡報，最安全的做法是什麼？**

在搬移投影片並保留來源外觀時，請使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目標簡報，然後以該母片克隆投影片，使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/)。這會同時保留母片、版面與主題。

**如何在繼承與覆寫後查看有效值？**

對於投影片或版面主題，使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)。對於格式物件（例如[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/)），使用對應的有效資料方法。這些 API 會在繼承與覆寫應用後返回解析後的值。