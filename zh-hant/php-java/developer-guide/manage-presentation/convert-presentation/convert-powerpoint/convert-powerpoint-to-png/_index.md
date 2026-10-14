---
title: 在 PHP 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/php-java/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報 轉 PNG
- 投影片 轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 將 PPT 儲存為 PNG
- 將 PPTX 儲存為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。"
---
## **概述**

本文說明如何使用 Aspose.Slides for PHP via Java 將簡報投影片轉換為 PNG 圖像。您可以載入 PPT、PPTX、ODP 等格式的簡報，渲染每張投影片，並將其儲存為單獨的 PNG 圖片。

以下範例示範了以預設比例渲染、放大比例、以像素指定輸出尺寸，以及選擇漸層渲染樣式。

## **將 PowerPoint 轉換為 PNG**

使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別載入簡報，並透過 [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 集合存取投影片。此範例使用未傳遞參數的 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 來渲染每張投影片，以產生縮圖。之後呼叫 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) 並使用 [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) 將每張渲染後的投影片儲存為 PNG 圖像。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
未帶參數的 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 重載以 0.2 的比例渲染。例如，尺寸為 720 × 540 點的投影片會產生 144 × 108 像素的縮圖。若要控制輸出尺寸，請使用帶比例因子或明確影像大小的重載，如下所示。
{{% /alert %}}

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

將水平與垂直比例因子傳遞給 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 以控制渲染尺寸。在此範例中，兩個因子皆為 2，因而尺寸為 720 Г— 540 點的投影片會產生 1440 Г— 1080 像素的影像。相等的比例因子會保留投影片的長寬比。每張影像皆使用 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) 以 PNG 格式儲存。
```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **將 PowerPoint 轉換為 PNG（自訂大小）**

若要以像素指定輸出尺寸，請傳遞尺寸給 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 而非比例因子。此範例將每張投影片渲染為 960 Г— 720 像素，並使用 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) 儲存結果。請選擇與投影片長寬比相符的尺寸，以避免影像被拉伸。
```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **選擇漸層渲染樣式**

假設投影片包含漸層填色，但匯出的 PNG 中的過渡色看起來較淡或與 PowerPoint 中的顯示不同。您可以使用 [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) 方法（由 [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) 繼承）來選擇漸層的渲染方式。

下載 [gradient-styles.pptx](gradient-styles.pptx) 並將其放置於應用程式的工作目錄中。其第一張投影片包含兩個線性漸層：上方由青色漸變至橙色，下方由藍色漸變至黃色。每個漸層都有兩個停止點，分別位於 0% 和 100%。

以下範例載入此簡報，並使用 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 以兩種模式渲染相同的第一張投影片。
```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

下方的影像顯示同一張投影片的輸出結果，每張影像皆包含兩個漸層：

| Default | PowerPointUI |
| --- | --- |
| ![以 Default 呈現的青色至橙色與藍色至黃色漸層](gradient-Default.png) | ![以 PowerPointUI 呈現的相同漸層](gradient-PowerPointUI.png) |

在此範例中，`Default` 產生較淡的中間顏色，而 `PowerPointUI` 產生較深的中間顏色。差異取決於漸層中的顏色與停止點。

若標準的 Aspose.Slides 輸出滿足需求，請選擇 `Default`。若您的優先考量是與 PowerPoint 的外觀相符，請嘗試 `PowerPointUI`。把兩種輸出與您的預期結果比較；兩種模式皆無絕對優劣。

## **常見問題**

**如何匯出特定形狀（例如圖表或圖片），而非整張投影片？**  
Aspose.Slides 支援 [為單一形狀產生縮圖](/slides/zh-hant/php-java/create-shape-thumbnails/)，讓您能將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**  
是的。為每個執行緒或處理序使用獨立的簡報實例；[不要在執行緒之間共用同一實例](/slides/zh-hant/php-java/multithreading/)。

**在匯出為 PNG 時，評估版有何限制？**  
評估模式會在輸出影像上加入浮水印，且會套用 [其他限制](/slides/zh-hant/php-java/licensing/)，直至安裝授權為止。