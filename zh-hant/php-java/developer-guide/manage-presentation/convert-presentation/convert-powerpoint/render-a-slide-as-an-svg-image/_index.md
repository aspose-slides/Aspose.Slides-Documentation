---
title: 在 PHP 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/php-java/render-a-slide-as-an-svg-image/
keywords:
  - PowerPoint 轉 SVG
  - 簡報 轉 SVG
  - 投影片 轉 SVG
  - PPT 轉 SVG
  - PPTX 轉 SVG
  - SVG 匯出選項
  - 互動式 SVG
  - PowerPoint
  - 簡報
  - PHP
  - Aspose.Slides
description: "在 PHP 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、圖像、ID 與事件。"
---
## **概觀**

SVG 是一種可伸縮的基於 XML 的影像格式，適用於網站發佈、投影片檢視器、無障礙工作流程以及自動化後處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片以及 SVG 元素的寫入方式。

當匯出的 SVG 必須緊湊、在各瀏覽器間具有可預測性，或需要可互動使用時，請使用[SVGOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

建立[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，選取投影片，並使用[Slide.writeAsSvg](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#writeAsSvg)將其寫入串流。以下範例將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

檔名使用[Slide.getSlideNumber](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getSlideNumber)而非迴圈索引。當投影片檢視器或網頁只需要特定圖形時，也可以使用[Shape.writeAsSvg](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#writeAsSvg)匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/) 控制 SVG 的呈現。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setUseFrameSize) 會將文字框納入繪製區域，而[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setUseFrameRotation) 決定是否套用框架旋轉。當文字必須以不含連字的方式呈現時，將[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `true`。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **控制文字與字型**

### **向量化全部文字**

將[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setVectorizeText) 設為 `true`，即可將所有投影片文字寫入為向量圖形。這會消除字型相依性，並使視覺效果在各瀏覽器間更一致，但文字將不再能作為 SVG 文字被選取或搜尋。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **選擇外部字型的處理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) 會針對外部載入的字型使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgexternalfontshandling/) 值。選擇 `AddLinksToFontFiles` 以參照單獨的字型檔案、`Embed` 以將字型資料嵌入 SVG，或 `Vectorize` 只將使用外部字型的文字渲染為圖形。嵌入字型前請先確認字型授權。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **減少嵌入影像的大小**

使用[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setPicturesCompression)可降低嵌入圖片的解析度，[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)可省略被裁切的來源區域，[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setJpegQuality)則可控制 JPEG 編碼品質。這些設定會以影像保真度或保留的影像資料為代價減少檔案大小。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **為圖形與文字指派穩定 ID**

提供格式化回呼給[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setShapeFormattingController)，以設定每個 SVG 圖形的[SvgShape.setId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgshape/#setId)。此回呼亦可於文字 `tspan` 元素上設定[SvgTSpan.setId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgtspan/#setId)值。

在串流模式下，PhpJavaBridge 無法從 `writeAsSvg` 呼叫 PHP 回呼。請將格式化邏輯放入小型 Java 輔助類別，編譯後將產生的 JAR 檔加入橋接的 classpath。此輔助類別可使用[Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getOfficeInteropShapeId)，該 ID 在圖形生命週期內保持穩定，並使用可重複的計數器處理其文字跨度。請參閱[Java implementation of `StableSvgIdController`](/slides/zh-hant/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)以取得輔助程式碼。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **加入 SVG 事件處理程序**

在格式化回呼中，使用[SvgShape.setEventHandler](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgshape/#setEventHandler)搭配[SvgEvent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgevent/)值，為匯出的圖形加入 JavaScript 事件處理程序。透過[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setShapeFormattingController)指派此回呼，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

如同穩定 ID 的情況，當 PhpJavaBridge 使用串流模式時，請在 Java 輔助類別中實作回呼。[Java implementation of `SvgEventController`](/slides/zh-hant/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) 會為名為 `ActionButton` 的圖形指派 ID 以及 `OnClick` 處理程序。編譯該輔助類別，將其以 `com.example.slides.SvgEventController` 加入橋接的 classpath，然後在 PHP 中如下使用：

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

宿主頁面可定義由處理程序參考的 JavaScript 函式。指派 ID 與事件處理程序可提升投影片檢視器、無障礙功能以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setVectorizeText)而非[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgexternalfontshandling/)?**

當所有文字必須與字型獨立時，使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#setVectorizeText)。當僅需將使用外部字型的文字轉換為圖形時，使用[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgexternalfontshandling/)。

**如何最有效地縮小 SVG 大小？**

首先壓縮嵌入的圖片、刪除裁切的影像區域，並在目標環境能提供字型檔時選擇連結字型檔。請測試結果，因為較低的影像解析度、較低的 JPEG 品質，以及向量化文字各自都有不同的品質與大小權衡。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化回呼指派 ID，之後在後置處理工具或瀏覽器腳本中選取相對應的 SVG 元素。