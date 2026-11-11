---
title: 在 PHP 中將簡報投影片匯出為 SVG 圖像
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
description: "在 PHP 中以 Aspose.Slides 匯出 PowerPoint 投影片為 SVG 圖像，並控制字型、文字、圖片、ID 與事件。"
---
## **概述**

SVG 是一種可伸縮的基於 XML 的圖像格式，適用於網頁出版、投影片檢視器、可存取性工作流程，以及自動後處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔案，讓您可以控制文字、字型、圖片和 SVG 元素的寫入方式。

當匯出的 SVG 必須緊湊、在不同瀏覽器間具備可預測性，或已備妥供互動使用時，請使用 [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/)。

## **匯出投影片為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)，選取投影片，並使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) 將其寫入串流。以下範例會把簡報中的每張投影片匯出為個別的 SVG 檔案。

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

檔名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) 而非迴圈索引。若投影片檢視器或網頁只需要特定圖形，也可以使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) 匯出單一圖形。

## **配置 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) 控制 SVG 的呈現方式。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) 會將文字框納入繪製區域，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) 決定是否套用框的旋轉。若文字必須在無連字的情況下呈現，請將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `true`。

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

## **控制文字和字型**

在將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參照方式。以下選項有助於在匯出 SVG 時平衡視覺一致性、文字選取以及字型相依性。

### **向量化全部文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) 設為 `true`，即可把所有投影片文字寫入為向量圖形。這樣可消除字型相依性，使視覺結果在各瀏覽器間更一致，但文字將無法在 SVG 中被選取或搜尋。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) 會使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) 的值來處理外部載入的字型。選擇 `AddLinksToFontFiles` 以參照獨立的字型檔案，選擇 `Embed` 以將字型資料嵌入 SVG，或選擇 `Vectorize` 只將使用外部字型的文字渲染為圖形。嵌入字型前請先確認授權。

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

## **縮小嵌入圖片的大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) 以降低嵌入圖片的解析度，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 省略被裁切的來源區域，並使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) 來控制 JPEG 編碼品質。這些設定會在減少檔案大小的同時，以影像保真度或保留的圖像資料為代價。

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

## **控制圖形檔光柵化解析度**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) 設定在 SVG 匯出期間對圖形檔光柵化的下限解析度。可用來在光柵化 EMF 或 WMF 圖像時平衡細節與檔案大小。此設定不會為 SVG 定義全域 DPI，也不會強制投影片上的每個物件皆成為光柵圖像。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含一張斜線密集的 EMF 圖像。以下範例透過 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) 以三種光柵化解析度匯出其第一張投影片。其他匯出設定保持相同，以便比較結果。

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

在輸出中，EMF 會在每個 SVG 中變成一個嵌入的 PNG。下列測量值僅針對此示範簡報；不構成將 DPI 轉換為像素尺寸的一般公式。

| 圖形檔光柵化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小（位元組） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下比較顯示相同區域的嵌入光柵在相同放大顯示尺寸下的差異。斜線在 72 DPI 時呈現可見像素化，較高解析度則顯示更平滑的邊緣，且 SVG 檔案會隨之增大。提升此值不一定能改善每個細節或改變每張匯出圖像。

![放大後的斜線細節（72、150、300 DPI）](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) 控制圖像解析度的降低，可能掩蓋變更圖形檔光柵化解析度的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) 控制 JPEG 編碼品質，而非圖形檔光柵化解析度。

## **為圖形與文字指派穩定的 ID**

提供一個格式化回呼給 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)，以設定每個 SVG 圖形的 [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId)。回呼也可以在文字的 `tspan` 元素上設定 [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) 值。

PhpJavaBridge 在串流模式下無法從 `writeAsSvg` 呼叫 PHP 回呼。請將格式化邏輯放入小型 Java 輔助類別，編譯後將產生的 JAR 檔加入橋接器的 classpath。輔助類別可使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)，此 ID 在圖形生命週期內保持穩定，並使用可重複的計數器為其文字跨度命名。請參考 [StableSvgIdController 的 Java 實作](/slides/zh-hant/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) 了解輔助程式碼。

將編譯好的 `com.example.slides.StableSvgIdController` 類別加入橋接器 classpath 後，於 PHP 中實例化並指派給 `SVGOptions`：

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

在格式化回呼中，使用 [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) 並傳入 [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) 值，即可為匯出的圖形新增 JavaScript 事件處理程序。以 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) 指派回呼，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

與穩定 ID 相同，若 PhpJavaBridge 使用串流模式，請在 Java 輔助類別中實作回呼。[SvgEventController 的 Java 實作](/slides/zh-hant/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) 會為名為 `ActionButton` 的圖形指派 ID 與 `OnClick` 處理程序。編譯該輔助類別，將其以 `com.example.slides.SvgEventController` 加入橋接器 classpath，然後在 PHP 中如以下範例使用：

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

宿主頁面可以定義由處理程序參考的 JavaScript 函式。指派 ID 與事件處理程序可支援投影片檢視器、可存取性增強以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) 而非 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

當所有文字必須獨立於字型時，請使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)。當僅需將使用外部字型的文字轉換為圖形時，請使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)。

**縮小 SVG 的最佳方法是什麼？**

首先壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境能提供字型檔時選擇連結字型檔。請測試結果，因為降低圖片解析度、降低 JPEG 品質以及向量化文字皆會對品質與尺寸產生不同的取捨。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化回呼指派 ID，之後即可在後處理工具或瀏覽器腳本中選取相符的 SVG 元素。