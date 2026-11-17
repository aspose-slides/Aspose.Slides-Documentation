---
title: 使用 PHP 在簡報中管理圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/php-java/image-transform-effects/
keywords:
- 圖像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙色調
- 色調
- HSL
- 顏色取代
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 透過 Java，套用、串接、檢查、移除並驗證圖片框的圖像變換效果。"
---
## **概觀**

Aspose.Slides 將圖片調整表示為有序的圖像變換操作集合。對於圖片框，請從框架的 [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) 開始，並存取 [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/)。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) 允許您在不重新寫入原始圖像位元組的情況下，添加、列舉、檢查、移除和清除效果。

本文示範了調整亮度與對比度、顏色變換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證的完整工作流程。

## **了解效果所有權與圖像重用**

圖像資源與顯示它的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 儲存或參照演示文稿擁有的來源圖像資料。
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) 屬於圖片填充，參考圖像資源，同時儲存圖像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁切設定以及其他框層級的格式設定。

因此，圖像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 中的位元組。當同一個 `PPImage` 被多次傳遞給 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) 時，每個新圖片框會取得自己的 `Picture` 與自己的變換集合。對一個框套用灰階不會使其他框變成灰階，即使它們共用相同的嵌入圖像資源。

相同的 `Picture::getImageTransform` 模型也用於其他圖片填充，例如形狀或投影片背景。下列範例集中於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使某些程式庫版本不會立即拒絕所有超出範圍的值，也請將值限制在此範圍內；目標簡報格式可能在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 使該組件保持不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | 無數值參數。Alpha 保持不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | 兩個顏色分別用於暗像素與亮像素。`java.awt.Color` 中的 RGB 與 Alpha 通道使用 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相 `hue` 為包含 `0`、不含 `360` 的度數；`amount` 為 `-100` 到 `100` 的百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相 `hue` 為包含 `0`、不含 `360` 的度數；飽和度與亮度為 `-100` 到 `100` 的百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | 替換顏色使用 `0` 到 `255` 的通道值。現有的 Alpha 值保持不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半徑為非負，單位為點；`grow` 為布林值，控制模糊內容是否可延伸至原始邊界之外。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行一般不透明度縮放：`0` 為完全透明，`100` 保持現有 Alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比 Alpha 閾值。低於閾值的像素變為透明，等於或高於閾值的像素變為不透明。 |

對於固定的 Alpha 調變，透明度與不透明度是互補的。例如，35% 透明度對應到 65% 的 Alpha 調變量。

## **套用亮度與對比度**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) 會返回一個 [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/) 操作。其標量設定在建立操作時提供。[Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提高 15%，對比度提升 20%，然後在不修改嵌入圖像的情況下渲染預覽：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` 是標準 DrawingML 的亮度與對比度效果。當這些設定必須在 PPTX 循環後仍可編輯時，請重新開啟已儲存的簡報，並驗證操作類型與其有效值。

## **套用顏色變換**

顏色效果可以獨立套用於重用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙色調、色調、HSL 調整與顏色取代。

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) 包含兩個可獨立編輯的顏色參數：`color1` 用於暗像素，`color2` 用於亮像素。這使其成為一個設定較為複雜、超過單一標量值的有用範例。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) 會將每個像素的顏色替換為固定顏色，同時保留 Alpha。它不同於 [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)，後者會將一個來源顏色映射到另一個顏色，並同時公開來源與目標顏色的格式。

### **套用亮度閾值**

亮度閾值可讓掃描頁面的淡淡痕跡更易於從背景中辨識。[addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) 會保留中間的灰階色階。[addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) 會將亮度映射為黑或白，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) 則對不透明度套用閾值。

亮度閾值範圍為 0% 到 100%，含兩端。低於閾值的像素變為黑色，等於或高於閾值的像素變為白色。提升閾值會使更多色階變黑，因為更多像素落在閾值以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 至包含 PHP 腳本的目錄。每個標籤顯示原始灰階值，範圍 0 至 255。範例將原始圖像放在兩個副本旁邊，並將每個副本的閾值儲存至簡報中。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中開啟輸出簡報以比較三個框。標記為 96 的樣本約有 38% 的亮度（96/255）。在 20% 閾值時會變白，在 60% 閾值時會變黑。

![原始灰階樣本旁的黑白結果（亮度閾值 20% 與 60%）](luminance-threshold.png)

## **添加模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) 會影響所有顏色通道，包括 Alpha。當模糊邊緣可能超出原始圖片範圍時，將 `grow` 設為 `true`。

若需統一透明度，請使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/)。它會將每個現有的 Alpha 值相乘，使部分透明像素保持比例差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) 則會將所有像素設定為同一 Alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) 會根據閾值將 Alpha 轉換為兩個層級。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

其他無參數的 Alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)，它會使所有非零 Alpha 變為完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)，它會使所有低於 100% 的 Alpha 變為完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)，它會將 Alpha 改為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `add...Effect` 方法會將新操作追加到集合的末端。渲染器會將集合視為有序管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，以不同順序排列相同操作可能產生不同圖像。

例如，先執行灰階再色調會先移除色彩資訊，然後重新上色；相反的順序則會再次移除色調。類似地，Alpha 取代可以覆寫先前操作計算出的 Alpha 值，而 Alpha 調變則會保留其相對差異。

以下範例建立四個操作的鏈，將其儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

此集合不會施加限制顏色、Alpha 與模糊操作必須分開鏈的相容性矩陣。它們可以結合使用，但組合未必都有實用價值。固定的顏色取代會移除先前顏色效果產生的 RGB 變化；在雙色調之後再套用灰階會去除兩個選取的顏色；Alpha Ceiling、Floor、Replace 或 BiLevel 操作則可能捨棄先前建立的 Alpha 細節。請依照所需的像素處理序列建立鏈，而非將其視為無序的格式旗標。

<!-- visual-explanation:image-transform-effects:start -->
[![相同的圖像先經過灰階再色調，與先色調再灰階。兩個最終的灰階圖像具有不同的色調。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此示範性的 Aspose.Slides for .NET 26.11 渲染中，220°、25% 的色調不會改變灰階圖像。先套用相同的色調再執行灰階會產生不同的色調。*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `Picture::getImageTransform` 中的物件。根據效果的不同，它可能直接公開可寫成員。例如，[Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) 會公開可寫的 `radius` 與 `grow`，[AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) 會公開可寫的 `amount`，而 [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) 會公開可寫的 `threshold`。如 [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) 等顏色效果則會公開可變的 [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) 物件。

某些操作，包括 [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/)、[HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/) 與 [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/)，不會將建立時的標量暴露為可寫屬性。若要變更這些設定，請移除該操作並在所需位置加入替代操作。

`getEffective()` 回傳的有效資料是計算後的唯讀值。它對解析主題相關顏色與讀取渲染器使用的正規化值很有用，但並非另一個可編輯的表面。以下範例列舉鏈並在相應的 API 提供時檢查有效值：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

無參數的效果如灰階、Alpha Ceiling、Alpha Inverse 仍會有有效資料物件，但沒有可列印的標量設定。它們的存在與在集合中的位置即是重要資訊。

## **移除或清除圖像變換**

使用 [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) 可依索引移除單一操作。因為移除後索引會移位，請先搜尋目標再在列舉後移除。使用 [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) 可移除整個鏈。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

移除或清除變換僅會變更圖片格式，並不會刪除、重新壓縮或以其他方式改變重用的 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換源自 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，也不是所有操作都有相同的可移植性：

- 標準 DrawingML 操作（如 luminance、grayscale、duotone、tint、HSL、blur 以及常見的 alpha 操作）最有可能在 PPTX 循環後存活。若需保留，務必重新開啟產生的檔案並檢查集合。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援的子集合，或以近似方式呈現。不要將 PPT 用作驗證複雜可編輯鏈的格式。
- 渲染為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於呈現結果。這些輸出不會包含可編輯的 `ImageTransformOperationCollection`；點陣圖格式會將結果平鋪成像素，文件或向量匯出則會存儲它們自己的渲染表示。
- 效果不會使連結圖像變成自包含。渲染連結圖片仍然依賴於載入簡報時連結資源的可用性。

不同的簡報消費者可能會在邊緣案例上呈現不同，特別是當多個 alpha 或顏色量化操作結合時。對於關鍵輸出，請同時測試可編輯的循環以及最終匯出格式，並使用與生產環境相同的 Aspose.Slides 版本。

## **常見問題**

**圖像變換效果會修改嵌入的圖像資料嗎？**

不會。這些操作屬於圖片填充使用的 `Picture`。底層的 `PPImage` 位元組保持不變。

**重用同一圖像的兩個圖片框會共享它們的效果嗎？**

不會。重用 `PPImage` 只避免了重複的圖像資料，但每個圖片框通常都有各自的 `Picture` 與圖像變換集合。

**可以同時結合顏色、模糊與 Alpha 效果嗎？**

可以。集合接受它們在同一有序鏈中。請考慮每個操作對前一個操作輸出的影響，因為取代與閾值操作可能會捨棄早期的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。請在變換集合中編輯那些具有可寫成員的操作；若沒有，請移除它並以新的建立參數加入替代操作。

**應使用哪種格式來保留變換鏈？**

使用 PPTX 並透過重新開啟檔案來驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，且渲染匯出格式僅保留外觀而非可編輯的變換操作。