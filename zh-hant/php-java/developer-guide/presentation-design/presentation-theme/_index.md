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
description: "透過 Java 在 Aspose.Slides for PHP 中掌握簡報主題，以建立、客製化與轉換具一致品牌識別的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一套協調的顏色、字型、背景樣式、填色、線條與效果。具備主題意識的物件會參照這些共用定義，而不是將每個視覺屬性儲存為固定值，因而一次變更主題即可更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 取得。簡報也可以在較低層級包含主題覆寫。母片可透過 [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/) 覆寫簡報主題，而版面或個別投影片則可透過 [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) 覆寫其繼承的主題。實務上，投影片的有效主題是透過以下繼承鏈解析得到的：簡報主題、母片覆寫、版面覆寫與投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下章節說明最常見的主題工作流程：檢視主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) 物件會透過 [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)、[MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)、[MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) 暴露主題的色彩方案、字型方案與格式方案。變更前先檢查這些集合特別有用，因為從外部來源取得的簡報，其樣式項目的數量與內容可能各不相同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。請檢查與投影片相關的母片，並在版面或投影片可能有覆寫時，使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具備主題意識的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當你在 [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) 中變更相對應的條目時，所有仍參照該主題顏色的物件都會以新值解析。直接使用 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的形狀，將主題的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟，並列印有效的填色：

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

因為矩形仍連結至 `Accent4`，主題變更後其可見顏色會變成紅色。若你在形狀上以直接顏色取代此配色，之後對 `Accent4` 的變更就不會再影響該填色。

### **使用來自額外調色盤的顏色**

PowerPoint 會透過套用色彩變換，從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主題顏色。

**2** - 由主題顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍基於主題顏色。如果之後 `Accent4` 變更，變換後的顏色會重新以新的 `Accent4` 值計算。

### **對應 `SchemeColor` 值至 `ColorScheme` 欄位**

[SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題欄位。對應關係是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是相同主題欄位的別名，並非會在執行時互相轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集與內文的次要字型集。[FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) 與 [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) 方法會暴露這些集合。

PowerPoint 相容的主題字型識別子可用於文字格式設定：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 East Asian（次要東亞字型）
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）
* `+mn-cs` - 內文字型 Complex Script（次要複雜文字字型）
* `+mj-cs` - 標題字型 Complex Script（主要複雜文字字型）

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

標題遵循主要字型，內文遵循次要字型。若文字明確使用字型名稱而非主題識別子，則在字型方案變更時不會自動切換。

主要與次要字型集合也可以包含針對個別書寫系統（例如西里爾文、阿拉伯文、日文、喬治亞文與 Thaana）的字型對應。若要檢視、加入、取代或移除這些對應，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/php-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
For more information about presentation fonts, see [PowerPoint Fonts](/slides/zh-hant/php-java/powerpoint-fonts/).
{{% /alert %}}

### **解析主題字型參照**

在檢查文字時，[FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) 可能會回傳如 `+mn-lt` 之類的主題參照，而非字型名稱。使用適當的有效主題資料呼叫 [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) 以解析該參照。`+mj` 與 `+mn` 前綴選擇主要或次要字型集；`-lt`、`-ea`、`-cs` 後綴分別選擇其 Latin、East Asian 與 Complex Script 字型。

透過在套用於檢查文字的物件上呼叫 [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)，取得有效的主題。對於普通投影片文字，於投影片本身呼叫此方法，以確保上下文包含該投影片繼承的主題與本地覆寫。檢查版面或母片本身時，則使用其自身的有效主題。不要假設第一個母片的主題套用於所有投影片。

以下範例建立一段明確參照次要 Latin 字型的文字。它透過 [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) 初始化投影片字型方案，並將主要與次要 Latin 字型族設為 `Arial` 與 `Calibri`，使範例可在沒有輸入檔的情況下重現：

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

輸出為 `+mn-lt -> Calibri` 接著是 `Verdana -> Verdana`。儲存的參照保持不變，而明確的字型名稱則原樣回傳。若文字使用 `+mj-lt`，則會在此主題中解析為 `Arial`。

解析主題參照會找出主題指定的字型族，並不會檢查字型是否可用或在渲染期間替代/字形回退後實際使用的字型檔案。相關步驟請參閱 [Font Selection Sequence](/slides/zh-hant/php-java/font-selection-sequence/) 與 [Font Substitution](/slides/zh-hant/php-java/font-substitution/)。

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至主投影片所依賴的投影片**

當你有 PowerPoint 主題檔（`.thmx`）且想重新樣式化所有依賴特定母片的投影片時，請使用 [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)。從 [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 集合中選取母片（此集合由 [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) 表示），並將主題檔路徑傳入方法。

此方法執行以下操作：

1. 依所選母片建立新母片投影片。
1. 將外部主題套用至新母片。
1. 將先前依賴所選母片的所有投影片指派給新母片。
1. 回傳新建立的 [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)。

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

無效、損毀或不受支援的主題可能會拋出 [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並在主題成功套用後再儲存簡報。

只有依賴所選母片的投影片會被重新指派。與其他母片關聯的投影片會保留既有的母片與主題。具備主題意識的顏色、字型、填色、線條、背景與效果會依外部主題解析。直接指定的顏色、字型、填色與其他明確格式化可能保持不變。版面層級與投影片層級的覆寫也可能優先於新母片繼承的值。

主題可能參照在執行環境中不可取得的字型。為確保渲染與匯出一致，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/php-java/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/php-java/font-substitution/)。

這是一個直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先不知道相關母片時，可透過 [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) 及 [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) 取得代表性投影片的母片。在套用任何主題前先保存原始母片參照，因為每次呼叫都會在簡報中建立另一個母片。

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

第一次呼叫僅影響依賴 `$firstGroupMaster` 的投影片，第二次呼叫僅影響依賴 `$secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **移動投影片時保留來源主題**

如果要將投影片移至其他簡報並保留原始設計，請使用 [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) 將來源母片複製至目標簡報，然後使用 [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) 以及複製的母片來複製投影片。如此即可同時攜帶母片、其版面與相關主題。

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

當來源投影片必須在目標簡報中保持相同外觀時，這是建議的工作流程。單純將內容複製至不相關的目標母片可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，請從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)、[OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) 與 [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) 方法將三個主要主題元件複製到覆寫中。

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

此作業會在不改變其他投影片繼承主題的情況下變更該投影片使用的主題。若要移除本機覆寫並回復至繼承值，請呼叫 [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/) 使用：

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

在需要多個版面與投影片共享相同基礎設計時，使用母片或簡報層級的主題；在單一版面族需要不同樣式時，使用版面覆寫；僅在真正例外時才使用投影片覆寫。過多的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中呈現的背景選項往往多於此集合實際儲存的填色定義，因為 UI 能將主題填色與主題顏色及其他樣式參照組合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的 [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/)。樣式索引為 `0` 代表沒有主題填色；正值則為主題背景樣式參照。這與直接以 PHP 集合索引不同，`get_Item(0)` 代表第一筆儲存項目。請勿假設每個簡報都有相同數量的背景填色樣式。

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

最終顯示的結果取決於母片參考的主題條目以及版面或投影片層級的任何背景覆寫。若投影片自行設定背景，只變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
Do not treat the style index as a zero-based collection index. Also avoid hard-coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation-specific.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
For direct background formatting and background inheritance, see [Presentation Background](/slides/zh-hant/php-java/presentation-background/).
{{% /alert %}}

## **更新主題效果**

主題格式方案包含分別的填色、線條與效果樣式集合，分別透過 [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)、[FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)、[FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) 暴露。一般 Office 主題常包含三個主要樣式條目，視覺上對應微妙、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 PHP 中存取這些集合時，集合索引為零基礎：`get_Item(0)` 為第一筆儲存樣式，`get_Item(2)` 為第三筆。形狀的樣式參照索引是另一概念，由 [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響參照該主題樣式的形狀；直接格式化的形狀可能保持不變。

以下範例確認所需的樣式條目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對參照這些欄位的形狀而言，第一個主題線條樣式會變紅，第三個主題填色樣式會變為實心森林綠，第三個效果樣式則會新增距離 10 點的外部陰影。最終視覺結果仍取決於每個形狀參照的樣式槽位以及直接格式化是否覆寫主題。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **為形狀選取主題填色與線條樣式**

形狀可透過 [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) 與 [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex) 分別獨立選擇填色與輪廓。對於任一方法，索引 `1` 代表選取相對應主題集合中的第一筆條目 (`get_Item(0)`)，索引 `2` 代表第二筆 (`get_Item(1)`)。

以下範例在新簡報的預設主題中設定兩個填色樣式（金色與天藍）與兩個線條樣式（深藍 6 pt 與深紅 12 pt），並在三個階段儲存投影片，以便於在 PowerPoint 中比較結果：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 初始樣式 | 變更右側輪廓 | 編輯第一個主題填色 |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

選取不同的線條樣式只會變更右側矩形的輪廓。編輯第一個主題填色則會更新所有使用該填色的形狀。此例中，只有左側矩形變為綠色。

在現有形狀上，若本機填色、線條顏色或線條寬度覆寫了主題樣式的對應部分，則會優先使用本機設定。如果變更樣式索引後沒有可見效果，請檢查形狀的 [direct formatting](/slides/zh-hant/php-java/shape-formatting/)。

## **判斷有效實心填色是否使用主題顏色**

填色可以直接儲存在物件上，也可以繼承自段落、版面、母片、主題樣式或其他格式層級。呼叫 [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 以將此層級階層解析為不可變的有效填色資料。首先檢查其 `getFillType` 結果。僅當結果為 `FillType::Solid` 時才讀取實心填色屬性。

對於實心填色，`getSolidFillColor` 會回傳在繼承、主題查找與色彩變換後的最終 RGB 值。`getSolidFillSchemeColor` 方法會回傳相對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 欄位，例如 `Text1` 或 `Accent6`。`SchemeColor::NotDefined` 表示有效實心填色並非基於配色方案。於僅使用主題顏色或直接 RGB 顏色的工作流程中，這個值即代表直接的 RGB 填色。

不要僅依賴本機的 [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) 來判斷填色。例如，文字段落可能沒有本機定義的配色方案顏色，其本機值為 `NotDefined`，但其有效填色繼承自主題且解析為 `Text1` 或 `Accent6`。相反地，`getSolidFillSchemeColor` 告訴你是哪個邏輯主題槽位產生了最終顏色，但不會告訴你該槽位來自物件、段落、版面、母片或其他層級。

以下範例載入簡報，稽核形狀填色與文字段落填色，列印每個最終的 RGB 值與相關的配色方案顏色，並標記不會追蹤主題顏色變更的實心填色：

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

`NotDefined` 分支會提供一份不會回應主題配色槽位變更的實心填色稽核清單。在簡報必須遵循新品牌調色盤時，請檢查這些物件。報告的 RGB 值仍顯示目前外觀，而配色方案值說明該外觀是否與主題相連。

有效格式物件是快照。變更簡報主題、主題覆寫或任何繼承的格式後，請再次呼叫 `getEffective`，並在比較或報告顏色前讀取新的有效填色資料。

## **讀取有效主題值**

原始主題物件只能告訴你在特定層級上定義了什麼。有效值則告訴你投影片或形狀在繼承與本機覆寫解析後實際使用了什麼。對投影片而言，呼叫 [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/)。對背景使用 [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)，對填色使用 [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)。

以下範例讀取投影片的有效主題、背景與第一個形狀的填色：

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

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查 [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)，可能會遺漏母片、版面、投影片或形狀的覆寫，從而錯過最終外觀的變化。

## **常見問題**

**套用外部主題是否會影響簡報中的每張投影片？**

不會。[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有主題。

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍會繼承其既有主題。

**將主題從一個簡報搬到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，請將來源母片以 [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) 複製到目標簡報，然後使用 [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) 搭配該母片複製投影片。這樣可同時保留母片、版面與主題。

**如何檢視繼承與覆寫後的有效值？**

對投影片或版面主題使用 [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/)，對格式物件則使用對應的有效資料方法，例如 [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) 與 [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)。這些 API 會在繼承與覆寫套用後返回解析後的值。