---
title: 管理 PHP 中的簡報主題
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
- 附加調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for PHP 中管理母片簡報主題，以建立、客製化與轉換擁有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義一組協調的顏色、字型、背景樣式、填充、線條和效果。支援主題的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時可以一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)取得。簡報也可以在較低層級包含主題覆寫。母片可透過[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterthememanager/)覆寫簡報主題，而版面或單一投影片則可透過[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)覆寫其繼承的主題。實務上，投影片的有效主題是透過以下繼承鏈解析：簡報主題、母片覆寫、版面覆寫與投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下段落說明最常見的主題工作流程：檢視主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/) 物件透過[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)與[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mastertheme/)公開主題的顏色方案、字型方案與格式方案。變更前先檢視這些集合特別有用，因為來自外部來源的簡報其樣式項目的數量與內容可能各不相同。

以下範例讀取主要主題屬性，並回報在主題中儲存了多少背景、填充、線條與效果樣式：

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

如果檔案使用多個母片，請不要假設每張投影片都有相同的有效主題。檢視與投影片關聯的母片，並在可能存在版面或投影片覆寫時使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

支援主題的填充、線條與文字可以參照[SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更[ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 中對應的項目時，仍參照該主題顏色的所有物件會以新值重新解析。使用直接 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色變更為紅色，儲存簡報、重新開啟，並列印有效的填充顏色：

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

因為矩形仍與 `Accent4` 連結，主題變更後其可見顏色會變成紅色。如果您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填充。

### **使用附加調色盤中的顏色**

PowerPoint 會透過顏色轉換從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colortransformoperation/) 列舉公開這些轉換。

![主要主題顏色以及由附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

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

這些變體仍基於主題顏色。如果之後 `Accent4` 變更，轉換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映到 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 方式公開相同的主題插槽。對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是相同主題插槽的別名；它們不是會動態相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與正文的次要字型集合。`[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/)` 與 `[FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontscheme/)` 方法公開這兩個集合。

PowerPoint 相容的主題字型識別碼可在文字格式設定中使用：

* `+mn-lt` - 正文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 正文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 主題字型的標題，與一個使用次要 Latin 主題字型的正文行，然後變更主題字型並儲存結果：

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

標題遵循主要字型，正文文字遵循次要字型。若文字明確指定了字型名稱而非主題識別碼，則在字型方案變更時不會自動切換。

主要與次要字型集合也可以包含針對個別書寫系統（例如西里爾文、阿拉伯文、日文、喬治亞文與塔納文）的字型對映。若需檢視、添加、取代或移除這些對映，請參閱[Script-Specific Theme Fonts](/slides/zh-hant/php-java/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}
欲取得更多簡報字型資訊，請參閱[PowerPoint Fonts](/slides/zh-hant/php-java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至母片相依的投影片**

當您有 PowerPoint 主題檔（`.thmx`）且想重新樣式化所有依賴特定母片的投影片時，使用[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/)。從[Presentation::getMasters](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)集合中選取母片（此集合由[MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 表示），並將主題檔路徑傳遞給該方法。

該方法執行以下操作：

1. 依選取的母片建立新的母片投影片。
2. 將外部主題套用至新母片。
3. 將先前依賴選取母片的所有投影片指派給新母片。
4. 回傳新建立的[MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/)。

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

無效、損毀或不支援的主題可能會拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

只有依賴所選母片的投影片會被重新指派。與其他母片關聯的投影片會保留其現有的母片與主題。支援主題的顏色、字型、填充、線條、背景與效果會依外部主題重新解析。直接指派的顏色、字型、填充與其他明確格式化可能保持不變。版面層級與投影片層級的覆寫亦可能優先於新母片繼承的值。

主題可能會引用執行環境中不存在的字型。為確保一致的呈現與匯出，請安裝所需字型、透過[custom font sources](/slides/zh-hant/php-java/custom-font/) 提供，或設定[font substitution](/slides/zh-hant/php-java/font-substitution/)。

這是一個直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，無需手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先不知道相關母片時，透過[Slide::getLayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 取得版面，再由[LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 取得母片。套用任何主題前先保存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片定位其母片，並對每個群組套用不同的外部主題：

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

第一個呼叫僅影響依賴 `$firstGroupMaster` 的投影片，第二個呼叫僅影響依賴 `$secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **在搬移投影片時保留來源主題**

若要將投影片搬移至另一個簡報且保留其原始設計，先使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/)將來源母片複製到目標簡報，然後使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/)連同已複製的母片一起複製投影片。這會同時攜帶母片、其版面與相關主題。

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

當需要在目標簡報中呈現相同外觀時，這是首選工作流程。僅將內容克隆到無關的目標母片可能會改變由主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，可從來源主題為投影片層級建立覆寫。使用[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)與[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)方法將三大主題組件複製到覆寫中。

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

此操作會變更該投影片使用的主題，同時不會影響其他投影片繼承的主題。若要移除本地覆寫並回復至繼承值，請呼叫[OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/overridetheme/)。

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

當許多版面與投影片應共享相同基礎設計時，使用母片或簡報層級的主題；當單一版面族需要不同樣式時使用版面覆寫；僅在真實例外情況下才使用投影片覆寫。過多的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填充儲存在[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中可呈現的背景選項比此集合實際儲存的填充定義更多，因為 UI 能將主題填充與主題顏色及其他樣式參照結合。

![PowerPoint 簡報主題的背景樣式畫廊](presentation-design_8.png)

在使用背景樣式之前，請檢查已儲存的集合以及目前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。`0` 代表沒有主題填充；正值代表主題背景樣式參照。這與直接以 PHP 方式索引集合不同，`get_Item(0)` 表示第一個儲存項目。請勿假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充計數，將主題背景參照指派給第一個母片，並儲存簡報：

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

可見結果取決於母片所參照的主題項目，以及版面或投影片層級的任何背景覆寫。如果投影片使用自己的背景，僅變更母片背景可能不會影響該投影片。當需要取得繼承後的最終背景時，請使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)。

{{% alert color="warning" title="警告" %}}
請勿將樣式索引當作零基集合索引。也不要硬編碼來自單一檔案的樣式編號，並假設在另一檔案中會有相同外觀；主題樣式定義是簡報專屬的。
{{% /alert %}}

{{% alert color="info" title="提示" %}}
有關直接背景格式化與背景繼承，請參閱[Presentation Background](/slides/zh-hant/php-java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含透過[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 與[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/formatscheme/) 暴露的獨立填充、線條與效果樣式集合。典型的 Office 主題通常包含三個主要樣式條目，視覺上分別對應細微、適中與強烈的格式化，但程式碼應檢查每個集合而非假設固定數量。

![相同圖形套用的細微、適中與強烈主題效果](presentation-design_10.png)

在 PHP 中存取這些集合時，集合索引採零基：`get_Item(0)` 為第一個儲存樣式，`get_Item(2)` 為第三個。圖形的樣式參照索引是另一概念，透過[ShapeStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響參照該主題樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一條線條樣式、變更第三條填充樣式、在第三條效果樣式中啟用外部陰影，並儲存結果：

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

對於參照這些插槽的圖形，第一條主題線條樣式會變成紅色，第三條主題填充樣式會變為實心森林綠，第三條效果樣式會新增一個距離為 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填充與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效主題值**

原始主題物件只告訴您在特定層級上定義了什麼。有效值則告訴您投影片或圖形在繼承及本地覆寫解析後實際使用的內容。對於投影片，呼叫[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)。對於背景，使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/)，對於填充，使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/)。

以下範例讀取投影片的有效主題、背景以及第一個圖形的填充：

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

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，可能會錯過改變最終外觀的母片、版面、投影片或圖形覆寫。

## **常見問題集**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其現有主題。

**我能否在不變更母片的情況下，將主題套用到單一投影片？**

可以。使用投影片的[SlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍會繼承其現有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且需要保留來源外觀時，先使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 將來源母片複製到目的簡報，然後使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 將投影片連同該母片一起複製。這樣可同時保留母片、版面與主題。

**如何在繼承與覆寫之後查看有效值？**

對投影片或版面主題使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseoverridethememanager/)，以及對格式物件如[Background.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/background/) 和[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 使用相應的有效資料方法。這些 API 會在繼承與覆寫套用後返回解析後的值。