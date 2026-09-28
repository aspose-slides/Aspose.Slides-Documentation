---
title: "在 PHP 中管理簡報投影片母片"
linktitle: "投影片母片"
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
- 佔位符
- 克隆母片投影片
- 複製母片投影片
- 複製母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中管理投影片母片：存取、編輯、克隆、比較以及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概述**

**投影片母片** 定義一組投影片的共用設計設定。它可以包含共用形狀、標誌、背景、文字樣式、主題設定以及頁腳設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性且不必在每張投影片上重複相同格式的常用方法。

Aspose.Slides for PHP via Java 支援相同的模型。簡報可以包含一個或多個母片，且每個母片可以包含多個版面投影片。一般投影片通常不會直接參照母片。相反地，一般投影片使用版面投影片，而該版面投影片屬於某個母片。

層級結構如下：

1. **投影片母片** - 定義共用的設計與主題。
1. **版面投影片** - 定義佔位符的具體排列以及版面層級的格式設定。
1. **一般投影片** - 包含實際的簡報內容，並使用一個版面投影片。

![母片、版面投影片與一般投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 類別表示。簡報中所有的母片可透過 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getMasters) 方法取得，該方法傳回一個 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 物件。

{{% alert color="info" title="Inheritance" %}}
當相同屬性在多個層級上都有定義時，較具體的層級會優先。舉例來說，若母片與版面投影片都定義了背景，則基於該版面的投影片會使用版面的背景。更多關於版面投影片的資訊，請參閱 [套用或變更投影片版面](/slides/zh-hant/php-java/slide-layout/)。
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint 檢視索標籤上的 投影片母片 命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters` 方法存取母片：

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

您也可以透過一般投影片的版面取得其所使用的母片：

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

母片是一種類似投影片的物件。它繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/)，因此擁有許多一般投影片與版面投影片共用的屬性。母片專屬的成員列於 [MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 目的 |
| --- | --- |
| `getBackground` | 設定母片層級的投影片背景。 |
| `getShapes` | 儲存放置於母片上的形狀，例如標誌、圖片框與共用文字。 |
| `getLayoutSlides` | 儲存屬於該母片的版面投影片。 |
| `getThemeManager` | 提供存取母片主題 API 的介面。 |
| `getHeaderFooterManager` | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| `getDependingSlides` | 傳回依賴該母片的版面的普通投影片。 |

## **在投影片母片中新增圖片**

將圖片加入母片時，使用該母片版面的投影片都會顯示該圖片。這對於標誌、浮水印、裝飾帶等重複的視覺元素非常有用。

以下範例在第一個母片上加入一個標誌：

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

更多關於圖片框的資訊，請參閱 [圖片框](/slides/zh-hant/php-java/picture-frame/)。

## **控制母片圖形的可見性**

使用 [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#setShowMasterShapes) 可在不將圖形從母片中刪除的情況下隱藏繼承自母片的圖形（例如標誌或裝飾形狀）。在要省略這些圖形的投影片上呼叫 [Slide::setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#setShowMasterShapes) 並傳入 `false`，而在需要顯示的投影片則保持 `true`。

以下獨立範例在母片上建立藍色裝飾帶，並在兩張使用相同空白版面的投影片中分別顯示與隱藏該帶狀。此範例不需要輸入簡報或圖片。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此範例使用新簡報內建的 **Blank** 版面，並移除初始投影片的佔位符。

### **選擇設定的範圍**

一般投影片透過 [Slide::getLayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getLayoutSlide) 以及 [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#getMasterSlide) 取得母片。將屬性設定於單一投影片只會影響該投影片。若對 [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/#setShowMasterShapes) 傳入 `false`，則所有使用該共用版面的投影片皆會隱藏母片圖形，即使它們自己的設定為 `true`。若只想隱藏單一投影片的圖形，請變更該投影片的屬性且保留版面不變。

此設定不支援直接在母片本身作為可見性控制。對於母片而言，[getShowMasterShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/#getShowMasterShapes) 總是回傳 `false`，且對 [setShowMasterShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/#setShowMasterShapes) 傳入 `true` 會拋出例外。請將其套用於一般投影片或版面。

### **將圖形與背景區分**

| 操作 | 效果 |
| --- | --- |
| 隱藏母片圖形 | 控制繼承自母片的圖形可見性，而不會刪除它們或變更投影片本身的圖形。 |
| 變更投影片背景填充 | 改變背景的顏色、漸層或圖片。母片圖形是獨立的形狀，可保持在該背景之上可見。請參閱[簡報背景](/slides/zh-hant/php-java/presentation-background/)。 |
| 從母片刪除形狀 | 移除共用來源形狀，因而不再供任何使用該母片的投影片使用。 |

## **使用佔位符**

佔位符通常定義於版面投影片上。母片提供版面繼承的共用樣式與主題，而每個版面決定哪些佔位符可用以及它們的位置。

在 PowerPoint 中，佔位符命令位於投影片母片檢視中。

![PowerPoint 投影片母片檢視中的 插入佔位符 命令](slide-master_5.png)

若要使用 Aspose.Slides 新增佔位符，請對屬於母片的版面投影片進行操作：

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

您也可以格式化已存在於母片上的佔位符形狀。以下範例尋找標題佔位符並套用線性漸層填充：

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

![已由一般投影片繼承的已格式化標題佔位符](slide-master_8.png)

更多佔位符與文字格式化選項，請參閱 [在佔位符中設定提示文字](/slides/zh-hant/php-java/manage-placeholder/) 與 [文字格式](/slides/zh-hant/php-java/text-formatting/)。

## **變更投影片母片背景**

母片背景會被其下的版面與未自行覆寫背景的投影片繼承。以下範例為第一個母片設定實心背景色：

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

相關主題請參閱 [簡報背景](/slides/zh-hant/php-java/presentation-background/) 與 [簡報主題](/slides/zh-hant/php-java/presentation-theme/)。

## **將投影片母片克隆至其他簡報**

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 的 `addClone` 方法可將母片複製至另一個簡報。複製後的母片即可被目的簡報中的版面與投影片使用。

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

若需要同時克隆普通投影片及其母片，請參閱 [克隆投影片](/slides/zh-hant/php-java/clone-slides/)。

## **新增多個投影片母片**

簡報可以包含多個母片。當不同章節需要不同品牌、版面或主題設定時，此功能相當有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例克隆預設母片、為克隆後的母片設定不同背景、於該克隆母片下建立版面，並依該版面新增投影片：

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

可使用從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/) 繼承的 `equals` 方法比較母片。比較會檢查結構與靜態內容（例如形狀、文字、格式、動畫與其他投影片設定），但不會比較唯一識別碼（如投影片 ID）或動態佔位符值（例如目前日期）。

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

更多資訊，請參閱 [比較簡報投影片](/slides/zh-hant/php-java/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

在 [ViewProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/viewproperties/) 上使用 `setLastView` 方法可控制 PowerPoint 首次開啟的檢視。以下範例在投影片母片檢視中開啟簡報：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

更多檢視設定，請參閱 [儲存簡報](/slides/zh-hant/php-java/save-presentation/)。

## **移除未使用的投影片母片**

有時簡報中會保留已不被任何一般投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslidecollection/) 的 `removeUnused` 方法從 `getMasters` 集合中移除未使用的母片：

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

**投影片母片與版面投影片有何不同？**

投影片母片定義共用的設計設定，例如主題、背景、共用形狀與文字樣式。版面投影片屬於母片，定義佔位符的具體排列。一般投影片使用版面投影片，因此同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**

可以。簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，可使用多個母片。

**應該在母片還是版面投影片上新增佔位符？**

大多數情況下，應在版面投影片上新增佔位符。將共用的視覺元素與共用格式放在母片上，然後在一般投影片將使用的版面上放置內容佔位符。

**我可以刪除仍在使用中的母片嗎？**

不能。仍有依賴投影片的母片無法直接安全刪除。請先將那些投影片移至另一個母片的版面，或使用僅刪除未使用母片的清理方法。