---
title: 在 PHP 中管理簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 70
url: /zh-hant/php-java/slide-master/
keywords:
- 投影片母片
- 母片投影片
- PPT 母片投影片
- 多個母片投影片
- 比較母片投影片
- 背景
- 佔位元
- 克隆母片投影片
- 複製母片投影片
- 重製母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中管理投影片母片：存取、編輯、克隆、比較及移除 PowerPoint 和 OpenDocument 簡報中的母片投影片。"
---
## **概觀**

**投影片母片** 定義一組投影片的共用設計設定。它可以包含通用形狀、商標、背景、文字樣式、主題設定以及頁腳設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常見做法，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for PHP via Java 支援相同的模型。一份簡報可以包含一個或多個母片，而每個母片可以包含多個版面投影片。普通投影片通常不會直接參考母片。相反地，普通投影片會使用版面投影片，而該版面投影片屬於某個母片。

層級結構為：

1. **Slide master** - 定義共用的設計與主題。
1. **Layout slide** - 定義佔位元的特定排列及版面層級的格式設定。
1. **Normal slide** - 包含實際的簡報內容，並使用一個版面投影片。

![母片、版面投影片與普通投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 類別表示。簡報中的所有母片可透過 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getMasters) 方法取得，該方法會回傳一個 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 物件。

{{% alert color="info" title="繼承" %}}

當相同的屬性在多個層級被定義時，以較具體的層級為準。例如，若母片與版面投影片皆定義背景，基於該版面的投影片會使用版面的背景。如需了解更多版面投影片資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/php-java/slide-layout/)。

{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint 檢視索引標籤上的投影片母片指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters` 方法來存取母片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

您也可以透過普通投影片的版面取得其使用的母片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **投影片母片包含什麼**

母片是一種類似投影片的物件。它繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/)，因此提供與普通與版面投影片相同的許多投影片屬性。母片特有的成員列於 [MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `getBackground` | 設定母片層級的投影片背景。 |
| `getShapes` | 儲存放置於母片上的形狀，例如商標、圖片框與共用文字。 |
| `getLayoutSlides` | 儲存屬於此母片的版面投影片。 |
| `getThemeManager` | 提供存取母片主題 API 的方式。 |
| `getHeaderFooterManager` | 控制母片及其子版面的頁首、頁腳、日期與投影片編號。 |
| `getDependingSlides` | 回傳透過版面依賴此母片的普通投影片。 |

## **將影像加入投影片母片**

當您將影像加入母片時，使用該母片版面的投影片皆會顯示此影像。此功能適用於商標、浮水印、裝飾條紋及其他重複的視覺元素。

以下範例將商標加入第一個母片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如需瞭解圖片框的更多資訊，請參閱 [Picture Frame](/slides/zh-hant/php-java/picture-frame/)。

## **使用佔位元**

佔位元通常在版面投影片上定義。母片提供共用的樣式與主題，讓這些版面繼承；每個版面則決定哪些佔位元可用及其放置位置。

在 PowerPoint 中，佔位元指令可於投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的插入佔位元指令](slide-master_5.png)

若要使用 Aspose.Slides 新增佔位元，請處理屬於母片的版面投影片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

您也可以格式化已存在於母片上的佔位元形狀。以下範例尋找標題佔位元，並套用線性漸層填色：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![已格式化的標題佔位元，普通投影片繼承](slide-master_8.png)

如需更多佔位元與文字格式化選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/php-java/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/php-java/text-formatting/)。

## **變更投影片母片背景**

母片背景會被未覆寫的版面與投影片繼承。以下範例為第一個母片設定純色背景：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

相關主題請參閱 [Presentation Background](/slides/zh-hant/php-java/presentation-background/) 與 [Presentation Theme](/slides/zh-hant/php-java/presentation-theme/)。

## **將投影片母片克隆至其他簡報**

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 的 `addClone` 方法可將母片複製至另一份簡報。複製的母片即可在目標簡報的版面與投影片中使用。

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

若需同時克隆普通投影片及其母片，請參閱 [Clone Slides](/slides/zh-hant/php-java/clone-slides/)。

## **新增多個投影片母片**

一份簡報可以包含多個母片。當不同章節需要不同的品牌、頁面結構或主題設定時，這非常有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例會克隆預設母片，為克隆的母片設定不同的背景，在該克隆母片下建立版面，並根據該版面新增投影片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **比較投影片母片**

可使用從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/) 繼承的 `equals` 方法比較母片。比較會檢查結構與靜態內容，例如形狀、文字、格式、動畫以及其他投影片設定。但不會比較唯一識別碼（如投影片 ID）或動態佔位元值（如目前日期）。

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

如需更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/php-java/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/) 的 `setLastView` 方法可控制 PowerPoint 首次開啟的檢視。以下範例會在投影片母片檢視中開啟簡報：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

更多檢視設定請參閱 [Save Presentation](/slides/zh-hant/php-java/save-presentation/)。

## **移除未使用的投影片母片**

簡報有時會包含已不再被任何普通投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 的 `removeUnused` 方法可從 `getMasters` 集合中移除未使用的母片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

您也可以使用 [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 類別的低程式碼 `removeUnusedMasterSlides` 方法：

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**投影片母片與版面投影片有何差異？**

投影片母片定義共用的設計設定，例如主題、背景、通用形狀與文字樣式。版面投影片屬於某個母片，定義佔位元的特定排列。普通投影片使用版面投影片，因而同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**

是的。一份簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，請使用多個母片。

**應該將佔位元加入母片還是版面投影片？**

在大多數情況下，請將佔位元加入版面投影片。將共用的視覺元素與格式放在母片上，然後在普通投影片使用的版面上放置內容佔位元。

**我可以刪除仍在使用中的母片嗎？**

不能。具有相依投影片的母片無法直接安全刪除。必須先將那些投影片移至另一個母片下的版面，或使用僅移除未被使用的母片的清理方法。