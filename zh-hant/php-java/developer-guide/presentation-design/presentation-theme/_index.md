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
- 外部主題
- THMX
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP（透過 Java）中管理簡報主題，以建立、客製化及轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一套協調的顏色、字型、背景樣式、填色、線條與效果。具備主題感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因而一次變更主題即可更新多個物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 取得。簡報也可能在較低層級包含主題覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterthememanager/) 覆寫簡報主題，而版面配置或個別投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/) 覆寫其繼承的主題。實務上，投影片的實際主題是透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![主題元件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下各節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 暴露主題的色彩配置、字型配置與格式配置。在變更之前檢查這些集合特別有用，因為來自外部來源的簡報其樣式項目的數量與內容可能不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少個背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際主題。檢查與投影片關聯的母片，並在版面配置或投影片覆寫可能存在時使用本文稍後說明的實際主題工作流程。

## **變更主題顏色**

具備主題感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 中變更相應條目時，所有仍參照該主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件不會因主題顏色更新而變更。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟，並列印實際填色顏色：

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

由於矩形仍連結至 `Accent4`，主題變更後其可見顏色會變成紅色。如果您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用額外調色盤的顏色**

PowerPoint 會透過套用顏色轉換，從主題顏色衍生出較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colortransformoperation/) 列舉公開這些轉換。

![主要主題顏色與從額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 從主要主題顏色產生的較亮與較暗變體。

以下範例建立六個基於 `Accent4` 的矩形，對其中五個套用亮度轉換，並儲存結果：

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

這些變體仍以主題顏色為基礎。若之後 `Accent4` 變更，轉換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題插槽。對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些只是同一主題插槽的別名，並非會動態相互轉換的值。

## **變更主題字型**

主題字型配置包含標題的主要字型集合與內文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/) 方法公開這兩套字型。

PowerPoint 相容的主題字型識別碼可用於文字格式化：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 主題字型的標題與一個使用次要 Latin 主題字型的內文，然後變更主題字型並儲存結果：

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

標題遵循主要字型，內文則遵循次要字型。若文字使用了明確的字型名稱而非主題識別碼，則在主題字型配置變更時不會自動切換。

主要與次要字型集合也可以包含針對個別書寫系統（例如西里爾字母、阿拉伯文、日文、喬治亞文與 Thaana）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/php-java/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}

欲取得更多關於簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/php-java/powerpoint-fonts/)。

{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至依賴特定母片的投影片**

當您擁有 PowerPoint 主題檔 (`.thmx`) 並希望重新樣式化所有依賴特定母片的投影片時，可使用 [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/)。從 [Presentation::getMasters](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 集合中選取母片（由 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 代表），並將主題檔路徑傳入方法。

此方法執行以下操作：

1. 以所選母片為基礎建立新母片。
1. 將外部主題套用至新母片。
1. 將先前依賴所選母片的所有投影片指派給新母片。
1. 回傳新建立的 [MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/)。

以下範例將外部主題套用至依賴第一個母片的投影片，並儲存簡報：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

無效、損毀或不支援的主題會拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

只有依賴所選母片的投影片會被重新指派。屬於其他母片的投影片仍保留其既有母片與主題。具備主題感知的顏色、字型、填色、線條、背景與效果會以外部主題重新解析。直接指定的顏色、字型、填色與其他明確格式化可能保持不變。版面配置層級與投影片層級的覆寫亦可能優先於從新母片繼承的值。

主題可能參照執行環境中不存在的字型。為了確保一致的渲染與匯出，請安裝必要的字型、透過 [custom font sources](/slides/zh-hant/php-java/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/php-java/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面配置層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先不知道相關母片時，請透過 [Slide::getLayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 以及 [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 從具代表性的投影片取得母片。於套用任何主題前先保存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片定位其母片，並對每組投影片套用不同的外部主題：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

第一次呼叫僅影響依賴 `$firstGroupMaster` 的投影片，第二次呼叫僅影響依賴 `$secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **在移動投影片時保留來源主題**

若要將投影片搬移至另一簡報且保留其原始設計，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目標簡報，之後再以 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 搭配已克隆的母片克隆投影片。此操作會同時攜帶母片、其版面配置與關聯的主題。

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

此為在目的簡報中必須保持外觀相同的首選工作流程。單純將內容克隆至不相關的目的母片可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留其目前的母片與版面配置，請從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/) 方法將三大主題元件複製到覆寫中。

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

此變更僅影響該投影片使用的主題，不會改變其他投影片繼承的主題。若要移除本地覆寫並回復至繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面的投影片，除非特定投影片有其自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslidethememanager/) 使用：

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

當許多版面配置與投影片需要共享相同的基礎設計時，使用母片或簡報層級的主題；當單一版面配置族群需要不同樣式時，使用版面配置覆寫；而投影片覆寫僅在真正的例外情況下使用。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 中。PowerPoint 的 UI 可能呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 可以將主題填色與主題顏色及其他樣式參照結合。

![PowerPoint 針對簡報主題的背景樣式畫廊](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。`0` 代表沒有主題填色；正值則是主題背景樣式參照。這與直接以 PHP 集合索引不同，`get_Item(0)` 代表第一個儲存項目。不要假設每個簡報都包含相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主題背景參照指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片參照的主題條目以及版面配置或投影片層級的任何背景覆寫。若投影片使用自己的背景，只變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。

{{% alert color="warning" title="警告" %}}

請勿將樣式索引視為零基的集合索引。同時避免硬編碼來自單一檔案的樣式編號，並假設在另一檔案中會有相同外觀；主題樣式定義是依簡報而異的。

{{% /alert %}}

{{% alert color="info" title="提示" %}}

欲了解直接的背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/php-java/presentation-background/)。

{{% /alert %}}

## **更新主題效果**

主題格式配置包含分別的填色、線條與效果樣式集合，可透過 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 取得。典型的 Office 主題常包含三個主要樣式條目，視覺上對應細緻、適中與強烈的格式化，但程式碼應檢查每個集合，而非假設固定筆數。

![細緻、適中與強烈的主題效果套用於相同圖形](presentation-design_10.png)

在 PHP 中存取這些集合時，集合索引為零基：`get_Item(0)` 為第一個儲存的樣式，`get_Item(2)` 為第三個。圖形的樣式參照索引是另一概念，透過 [ShapeStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響引用該主題樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於引用這些插槽的圖形，第一個主題線條樣式會變為紅色，第三個主題填色樣式會變為實心森林綠，第三個效果樣式會獲得距離 10 點的外部陰影。最終的視覺結果仍取決於每個圖形引用的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **判斷實際的單色填色是否使用主題顏色**

填色可以直接儲存在物件上，或從段落、版面配置、母片、主題樣式或其他格式層級繼承。呼叫 [FillFormat::getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 以將層級解析為不可變的實際填色資料。首先檢查其 `getFillType` 結果。只有在返回 `FillType::Solid` 時才應讀取單色填色屬性。

對於單色填色，`getSolidFillColor` 會在繼承、主題查找與顏色轉換完成後，返回最終呈現的 RGB 值。`getSolidFillSchemeColor` 方法則返回對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 插槽，例如 `Text1` 或 `Accent6`。若返回 `SchemeColor::NotDefined`，表示實際的單色填色並未基於方案顏色。在只使用主題顏色或直接 RGB 顏色的工作流程中，這個值即可辨識為直接 RGB 填色。

請勿僅依賴本地的 [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorformat/) 值來分類填色。例如，文字段落可能本地未定義方案顏色，因而本地值為 `NotDefined`，但其實際填色繼承自主題顏色，最終會解析為 `Text1` 或 `Accent6`。相對地，`getSolidFillSchemeColor` 告訴您是哪個邏輯主題插槽產生了實際顏色，但不會說明該插槽來源於物件、段落、版面配置、母片或其他層級。

以下範例載入簡報，稽核圖形填色與文字段落填色，列印每個最終 RGB 值與相關的方案顏色，並標記不會跟隨主題顏色變更的單色填色：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`NotDefined` 分支提供一份稽核清單，列出在主題顏色插槽變更時不會回應的單色填色。當簡報必須遵循新品牌調色盤時，請檢查這些物件。報告的 RGB 值仍顯示目前外觀，而方案值說明該外觀是否與主題相連。

實際格式物件是快照。變更簡報主題、主題覆寫或任何繼承的格式後，請再次呼叫 `getEffective`，取得新的實際填色資料再進行比較或報告。

## **讀取實際主題值**

原始主題物件僅告訴您在特定層級定義了什麼。實際值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)，對於填色則使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/)。

以下範例讀取投影片的實際主題、背景與第一個圖形的填色：

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

使用實際資料進行渲染診斷、驗證與比較。如果只檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，可能會錯過改變最終外觀的母片、版面配置、投影片或圖形覆寫。

## **常見問題**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 僅重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有主題。

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍繼承其既有主題。

**從一個簡報搬移主題到另一個簡報的最安全方法是什麼？**

在搬移投影片且需保留來源外觀時，先使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目的簡報，然後以 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 搭配已克隆的母片克隆投影片。這樣可同時保留母片、版面配置與主題。

**如何看到繼承與覆寫之後的實際值？**

對於投影片或版面配置主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)；對於格式物件則使用對應的實際資料方法，例如 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/)。這些 API 會在繼承與覆寫完成後回傳解析後的值。