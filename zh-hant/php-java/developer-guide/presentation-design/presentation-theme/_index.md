---
title: 在 PHP 中管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/php-java/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 佈景顏色
- 附加調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for PHP 中管理簡報佈景主題，以建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填色、線條和效果。具備佈景感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因而一次佈景變更即可更新許多物件。

在 Aspose.Slides 中，簡報層級的佈景可透過[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 取得。簡報也可以在較低層級中包含佈景覆寫。母片可透過[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterthememanager/) 覆寫簡報佈景，而版面配置或個別投影片則可透過[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/) 覆寫其繼承的佈景。實務上，投影片的實際佈景是透過以下繼承鏈解析：簡報佈景 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下章節說明最常見的佈景工作流程：檢查佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，以及在繼承與覆寫解決後讀取實際值。

## **檢查佈景**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 物件會透過[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 與[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 暴露佈景的顏色方案、字型方案與格式方案。在變更前先檢查這些集合尤其在簡報來自外部來源時很有用，因為樣式項目的數量與內容都可能不同。

以下範例會讀取主要佈景屬性，並回報佈景中儲存了多少背景、填色、線條與效果樣式：

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

如果檔案使用了多個母片，請不要假設每張投影片都有相同的實際佈景。檢查與投影片相關的母片，並在版面配置或投影片可能有覆寫時，使用本文稍後說明的實際佈景工作流程。

## **變更佈景顏色**

具備佈景感知的填色、線條與文字可以參照[SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在[ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 中變更對應項目時，所有仍參照該佈景顏色的物件都會使用新值重新解析。直接使用 RGB 的物件則不會受到佈景顏色更新的影響。

以下端對端範例會建立一個使用 `Accent4` 的圖形，將佈景的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟，並輸出實際填色：

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

因為矩形仍連結至 `Accent4`，主題變更後其可見顏色會變成紅色。如果您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色盤的顏色**

PowerPoint 會透過套用顏色變換，從佈景顏色衍生較亮與較暗的變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主要佈景顏色。  
**2** - 由主要佈景顏色產生的較亮與較暗變體。

以下範例會建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍以佈景顏色為基礎。若 `Accent4` 後續變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 欄位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而[ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 露出相同的佈景槽位。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是相同佈景槽位的別名，並非會在執行時動態相互轉換的值。

## **變更佈景字型**

佈景字型方案包含標題的主要字型集合與內文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/) 與[FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/) 方法會暴露這兩個集合。

PowerPoint 相容的佈景字型識別子可在文字格式化時使用：

* `+mn-lt` - 內文字型拉丁文 (Minor Latin Font)
* `+mj-lt` - 標題字型拉丁文 (Major Latin Font)
* `+mn-ea` - 內文字型東亞 (Minor East Asian Font)
* `+mj-ea` - 標題字型東亞 (Major East Asian Font)

以下範例建立一個使用主要拉丁字型的標題與一個使用次要拉丁字型的內文，之後變更佈景字型並儲存結果：

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

標題會遵循主要字型，內文會遵循次要字型。若文字明確指定了字型名稱而非佈景識別子，則在佈景字型方案變更時不會自動切換。

{{% alert color="info" title="提示" %}}
欲了解更多簡報字型資訊，請參閱[PowerPoint Fonts](/slides/zh-hant/php-java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景**

有兩種常見工作流程，且解決的問題不同。

### **在移動投影片時保留來源佈景**

若您想將投影片移至其他簡報且保留其原始設計，請使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目標簡報，接著使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 與已克隆的母片一起克隆投影片。這樣會同時攜帶母片、其版面配置以及相關的佈景。

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

當來源投影片必須在目的端保持相同外觀時，此流程是首選。僅將內容克隆至不相關的目標母片可能會改變佈景驅動的顏色、字型、背景與效果。

### **將佈景值套用至既有投影片**

若目標投影片必須保留其現有母片與版面配置，請從來源佈景初始化投影片層級的覆寫。使用[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/) 與[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/) 方法將三個主要佈景組件複製到覆寫中。

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

此動作會變更該投影片使用的佈景，而不會影響其他投影片繼承的佈景。若要移除本機覆寫並回復至繼承值，請呼叫[OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)。

### **將佈景覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslidethememanager/) 使用：

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

當多個版面配置與投影片需要共享相同基礎設計時，使用母片或簡報層級的佈景；若某個版面配置族需要不同樣式，則使用版面配置覆寫；僅在真正例外的情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域佈景變更難以預測。

## **更新佈景背景樣式**

佈景的背景填色儲存在[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 能將佈景填色與佈景顏色及其他樣式參考組合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。`0` 表示沒有佈景填色；正值代表佈景背景樣式參考。這與直接以 PHP 索引集合不同，`get_Item(0)` 代表第一個儲存項目。不要假設每個簡報都有相同數量的背景填色樣式。

以下範例會回報可用的背景填色數量，將佈景背景參考指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片參考的佈景條目，以及版面配置或投影片層級的任何背景覆寫。若投影片自行設定背景，僅變更母片背景可能不會影響該投影片。需要取得套用繼承後最終背景時，請使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。

{{% alert color="warning" title="警告" %}}
不要將樣式索引當作零基索引集合。亦避免從一個檔案硬編碼樣式編號，並假設在另一個檔案中會呈現相同外觀；佈景樣式定義是簡報特定的。
{{% /alert %}}

{{% alert color="info" title="提示" %}}
欲取得直接背景格式化與背景繼承的資訊，請參閱[Presentation Background](/slides/zh-hant/php-java/presentation-background/)。
{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含分別的填色、線條與效果樣式集合，透過[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 暴露。一般 Office 佈景常包含三個主要樣式條目，對應於細緻、適中與強烈的格式化，但程式碼應檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 PHP 中存取這些集合時，集合索引採零基：`get_Item(0)` 為第一個儲存的樣式，`get_Item(2)` 為第三個。圖形的樣式參考索引是另一概念，透過[ShapeStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapestyle/) 暴露。修改佈景樣式會影響參照該佈景樣式的圖形；直接格式化的圖形可能保持不變。

以下範例會檢查所需的樣式條目是否存在，變更第一個線條樣式、第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於參照這些槽位的圖形，第一個佈景線條樣式會變成紅色，第三個佈景填色樣式會變成實心森林綠，第三個效果樣式會增加距離 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參考的樣式槽位，以及直接格式化是否覆寫佈景。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **讀取實際佈景值**

原始佈景物件告訴您在特定層級上定義了什麼。實際值則告訴您投影片或圖形在繼承與本機覆寫解決後實際使用的內容。對於投影片，請呼叫[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)。對於背景，使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)，對於填色，使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/)。

以下範例會從投影片讀取實際佈景、背景與第一個圖形的填色：

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

使用實際資料進行渲染診斷、驗證與比較。如果僅檢查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，可能會錯過母片、版面配置、投影片或圖形的覆寫，從而錯過最終外觀的變化。

## **常見問題**

**我可以在不變更母片的情況下，僅對單一投影片套用佈景嗎？**

可以。使用該投影片的[SlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidethememanager/) 並初始化其覆寫佈景。變更將僅限於該投影片，其他投影片仍會繼承其現有佈景。

**將佈景從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且保留來源外觀時，使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目的簡報，然後以[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 將投影片與該母片一起克隆。這樣可同時保留母片、版面配置與佈景。

**如何在繼承與覆寫之後查看實際值？**

對於投影片或版面配置佈景，使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)。對於格式物件，如[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/) 與[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/)，則使用對應的實際資料方法。這些 API 會在繼承與覆寫套用後回傳已解析的值。