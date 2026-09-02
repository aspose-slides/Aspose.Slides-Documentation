---
title: "使用 PHP 管理簡報中的圖像變換效果"
linktitle: "圖像變換效果"
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
description: "透過 Java 的 Aspose.Slides for PHP，套用、串接、檢查、移除並驗證圖片框的圖像變換效果。"
---
## **概述**

Aspose.Slides 將圖片調整表示為有序的圖像變換操作集合。對於圖片框，從框的 [Picture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picture/) 開始，存取 [Picture::getImageTransform](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picture/getimagetransform/)。回傳的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/) 讓您能在不重新寫入原始影像位元組的情況下，追加、列舉、檢查、移除與清除效果。

本章示範了完整的亮度與對比度、色彩變換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證的工作流程。

## **了解效果所有權與影像重用**

影像資源與顯示它的圖片是不同的物件：

- [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 儲存或參照簡報所擁有的來源影像資料。
- [Picture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picture/) 屬於圖片填充，參照影像資源，同時儲存影像變換集合。
- [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁切設定以及其他框層級格式。

因此，影像變換操作不會修改 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 中的位元組。當相同的 `PPImage` 多次傳遞給 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/) 時，每個新圖片框都會取得自己的 `Picture` 與自己的變換集合。對其中一個框套用灰階不會讓其他框變成灰階，即使它們皆重用相同的嵌入影像資源。

相同的 `Picture::getImageTransform` 模型也用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦在圖片框上。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使特定函式庫版本未立即拒絕所有超出範圍的值，也請將值限制在這些範圍內；目標簡報格式可能會在儲存時或 PowerPoint 開啟檔案時正規化、省略或拒絕無效資料。

| 操作 | 參數 | 有效範圍與單位 |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持元件不變。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | 無 | 無數值參數。Alpha 保持不變。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | 兩種顏色分別用於深色與淺色像素。`java.awt.Color` 的 RGB 與 alpha 通道使用 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相 `0`（含）到 `360`（不含）度；量值 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相 `0`（含）到 `360`（不含）度；飽和度與亮度為 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | 替換顏色的各通道值為 `0` 到 `255`。現有的 alpha 值保持不變。 |
| [addBlurEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半徑為非負值，單位為點（points）；`grow` 為布林值，決定模糊內容是否能超出原始邊界。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負百分比。普通不透明度縮放使用 `0` 到 `100`：`0` 為完全透明，`100` 保持原有 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比 alpha 閾值。低於此值的像素變透明；等於或高於此值的像素變不透明。 |

對於固定的 alpha 調變，透明度與不透明度是互補的。例如，35% 透明度等同於 65% 的 alpha 調變量。

## **套用亮度與對比度**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) 會回傳一個 [Luminance](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/luminance/) 操作。其純量設定在建立操作時提供。[Luminance::getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/luminance/geteffective/) 會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改嵌入影像的情況下呈現預覽：

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

`Luminance` 是標準 DrawingML 的亮度與對比度效果。當這些設定在 PPTX 循環後必須保持可編輯時，請重新開啟已儲存的簡報，並驗證操作類型與其有效值。

## **套用色彩變換**

色彩效果可以獨立套用在重用同一影像資源的不同圖片框上。以下範例建立五個框，分別套用灰階、雙色調、色調、HSL 調整與顏色替換。

[Duotone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/duotone/) 包含兩個可獨立編輯的顏色參數：`color1` 映射深色像素，`color2` 映射淺色像素。這使它成為一個設定比單一純量值更複雜的範例。

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

[addColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) 會將每個像素的顏色替換為固定顏色，同時保留 alpha。它與 [addColorChangeEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) 不同，後者會將一種來源顏色映射為另一種目標顏色，且會同時暴露來源與目標的顏色格式。

## **加入模糊、透明度與 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) 會影響所有顏色通道，包括 alpha。當模糊邊緣可能延伸超出原始圖片邊界時，將 `grow` 設為 `true`。

若需統一透明度，請使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/)。它會乘以每個既有的 alpha 值，使部分透明的像素保持比例差異。[addAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) 則會將所有像素的 alpha 設為同一值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) 會根據閾值將 alpha 轉為兩個層級。

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

其他無參數的 alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)，它會將每個非零 alpha 設為完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)，它會將低於 100% 的 alpha 設為完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)，它會將 alpha 變為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `add...Effect` 方法都會將新操作追加至集合的最後。渲染器會將集合視為有序管線：操作 0 的輸出成為操作 1 的輸入，依此類推。因此，同樣的操作如果順序不同，會產生不同的圖像。

舉例來說，先套用灰階再套用色調，會先去除色彩資訊再重新上色亮度結果。先套用色調再套用灰階則會把色調再次移除。同理，alpha 替換可以覆寫先前操作計算出的 alpha，而 alpha 調變則會保留它們的相對差異。

以下範例建立四個操作的鏈，將其儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並呈現重新開啟的結果：

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

此集合不會強制相容性矩陣，限制顏色、alpha 與模糊操作只能在不同鏈中使用。它們可以組合，但組合不一定有用。固定的顏色替換會移除先前顏色效果產生的 RGB 變化；在雙色調之後再套用灰階會移除兩個選擇的顏色；而 alpha ceiling、floor、replace 或 bi‑level 操作會捨棄先前創建的 alpha 細節。請依照期望的像素處理順序構建鏈，而非將其項目視為無序的格式旗標。

## **檢查可編輯與有效值**

可編輯的操作是儲存在 `Picture::getImageTransform` 中的物件。依效果不同，它可能會直接暴露可寫成員。例如，[Blur](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/blur/) 暴露可寫的 `radius` 與 `grow`，[AlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/alphamodulatefixed/) 暴露可寫的 `amount`，[AlphaBiLevel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/alphabilevel/) 暴露可寫的 `threshold`。[Duotone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/duotone/) 等顏色效果則暴露可變更的 [ColorFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorformat/) 物件。

某些操作，例如 [Luminance](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/luminance/)、[HSL](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tint/) 與 [AlphaReplace](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/alphareplace/)，不會將其建立時的純量以可寫屬性暴露。若要變更這些設定，請移除該操作，並在所需位置加入替代操作。

`getEffective()` 回傳的有效資料是計算後且唯讀的。它對於解析以佈景主題為依據的顏色以及取得渲染器實際使用的正規化值很有幫助，但不是另一個編輯介面。以下範例列舉鏈並檢查那些 API 提供的有效值：

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

無參數的效果（如灰階、alpha ceiling、alpha inverse）仍會有有效資料物件，但沒有可列印的純量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除影像變換**

使用 [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/removeat/) 依索引移除單一操作。因為移除後索引會移位，請先搜尋目標，列舉後再移除。使用 [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagetransformoperationcollection/clear/) 可移除整個鏈。

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

移除或清除變換僅會更改圖片格式。它不會刪除、重新壓縮或以其他方式改變被重用的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 資源。

## **考慮簡報格式與匯出目標**

影像變換起源於 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，並非所有操作都具備完全相同的可攜性：

- 標準 DrawingML 操作（如 luminance、grayscale、duotone、tint、HSL、blur 以及常見的 alpha 操作）最有機會在 PPTX 循環後存活。若需保留，務必重新開啟產生的檔案並檢查集合。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的操作、將鏈縮減為支援的子集，或以近似方式呈現外觀。切勿將 PPT 作為驗證複雜可編輯鏈的格式。
- 輸出為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺格式時，會將支援的鏈套用於渲染結果。這些輸出不會包含可編輯的 `ImageTransformOperationCollection`；點陣圖格式會將結果平鋪成像素，文件或向量匯出則會儲存自己的渲染表現。
- 效果不會讓連結的影像變為自包含。渲染連結圖片仍然依賴於載入簡報時能取得該連結資源。

不同的簡報檢視程式可能對邊緣案例有不同的呈現，尤其當多個 alpha 或色彩量化操作結合時。對於關鍵輸出，請使用與生產環境相同的 Aspose.Slides 版本，同時測試可編輯的循環與最終匯出格式。

## **常見問題**

**影像變換效果會修改嵌入的影像資料嗎？**

不會。這些操作屬於圖片填充使用的 `Picture`。底層的 `PPImage` 位元組保持不變。

**重用相同影像的兩個圖片框會共享它們的效果嗎？**

不會。重用 `PPImage` 可避免影像資料重複，但每個圖片框通常都有各自的 `Picture` 與影像變換集合。

**可以同時結合顏色、模糊與 alpha 效果嗎？**

可以。集合允許在同一有序鏈中混合使用。請考慮每個操作對前一個操作輸出的影響，因為替換與閾值操作可能會捨棄先前的顏色或 alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。若操作在變換集合中有可寫成員，請直接編輯該操作；若無，則必須移除它並以新的建立參數加入替代操作。

**應使用哪種格式才能保留變換鏈？**

使用 PPTX 並透過重新開啟檔案進行驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，且渲染匯出格式僅保留外觀而非可編輯的變換操作。