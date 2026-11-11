---
title: 使用 PHP 將簡報投影片匯出為 SVG 圖片
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報轉 SVG
- 投影片轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- 互動式 SVG
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 將 PowerPoint 投影片匯出為 SVG 圖片，並控制字型、文字、影像、ID 與事件。"
---
## **概觀**

SVG 是一種可伸縮的 XML 為基礎的影像格式，適合用於網路發佈、投影片檢視器、可及性工作流程與自動化後處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片與 SVG 元素的寫入方式。

當匯出的 SVG 必須緊湊、在瀏覽器間具可預測性，或準備好供互動使用時，請使用 [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)，選取投影片，並使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) 將其寫入串流。以下範例將簡報中的每張投影片匯出為單獨的 SVG 檔案。

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

檔名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) 而非迴圈索引。當投影片檢視器或網頁只需要某個圖形時，您也可以使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) 匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) 控制 SVG 的呈現方式。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) 會將文字框納入繪製區域，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) 決定是否套用框的旋轉。若文字必須在沒有連字的情況下呈現，請將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `true`。

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

## **控制箭頭頭端的線段裁切**

SVG 1.1 沒有標記插入設定可指定線段在箭頭下方何處停止。預設情況下，Aspose.Slides 會縮短匯出的線段，使其筆畫不會突入標記。將 [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) 設為 `true`，即可讓筆畫畫到線段原始端點。此設定僅影響 SVG 輸出，線段在投影片上的位置與長度保持不變。

範例在第 2 點與第 10 點寬的線條上繪製三角形與菱形箭頭，並分別以不同的裁切設定匯出同一投影片兩次。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

比較圖顯示 10 點寬線條的三角形箭頭。啟用裁切時，箭頭尖端銳利；停用裁切時，筆畫會穿過斜側標記，留下平整的末端。

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

在範例的其他線條中，2 點寬的三角形上穿出的筆畫較不明顯。填充的菱形在兩種寬度下都覆蓋了筆畫的末端。

## **控制文字與字型**

將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參照方式。以下選項可協助您在視覺一致性、文字選取與字型相依性之間取得平衡。

### **向量化全部文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) 設為 `true`，即可將所有投影片文字寫入為向量圖形。這會消除字型相依性，使視覺結果在不同瀏覽器間更一致，但文字將無法在 SVG 中被選取或搜尋。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) 會使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) 之值來處理外部載入的字型。選擇 `AddLinksToFontFiles` 以參照獨立的字型檔案，`Embed` 以在 SVG 中嵌入字型資料，或 `Vectorize` 只將使用外部字型的文字轉為圖形。嵌入字型前請確認字型授權。

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

## **縮小嵌入圖像的大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) 降低嵌入圖片的解析度，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 省略裁切過的來源區域，並使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) 控制 JPEG 編碼品質。這些設定會以犧牲影像細節或保留的圖像資料為代價來減少檔案大小。

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

## **控制圖形檔的點陣化解析度**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) 設定在 SVG 匯出過程中對圖形檔點陣化的最低解析度上限。使用它可在點陣化 EMF 或 WMF 圖像時平衡細節與檔案大小。它不會為整個 SVG 定義全域 DPI，也不會強制投影片上的每個物件皆變成點陣圖。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，內含一個擁有緊密對角線的 EMF 圖像。以下範例透過 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) 以三種點陣化解析度匯出其第一張投影片。其他匯出設定保持相同，以便比較結果。

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

在輸出中，EMF 會變成每個 SVG 中嵌入的 PNG。以下測量值僅針對此簡報，並非將 DPI 轉換為像素尺寸的通用公式。

| Metafile rasterization DPI | Embedded PNG dimensions | SVG file size (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下方比較顯示相同區域在相同放大顯示尺寸下的點陣化影像。72 DPI 時對角線可見像素化，較高解析度則呈現較平滑的邊緣，同時 SVG 檔案大小會增加。提升 DPI 不一定會改善每個細節或改變每張匯出圖像。

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) 控制圖像解析度降低，可能會掩蓋變更圖形檔點陣化解析度的影響。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) 控制 JPEG 編碼品質，而非圖形檔點陣化解析度。

## **為圖形與文字指派穩定的 ID**

提供一個格式化回呼給 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)，以設定每個 SVG 圖形的 [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId)。回呼同時也可為文字 `tspan` 元素設定 [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) 值。

PhpJavaBridge 在串流模式下無法從 `writeAsSvg` 呼叫 PHP 回呼。請將格式化邏輯放入小型 Java 輔助類別，編譯後將產生的 JAR 加入 bridge 的 classpath。該輔助類別可以使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)（此 ID 在圖形生命週期內保持穩定），以及用於文字跨度的可重複計數器。請參考 [Java implementation of `StableSvgIdController`](/slides/zh-hant/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) 取得輔助程式碼。

將編譯好的 `com.example.slides.StableSvgIdController` 類別加入 bridge classpath 後，於 PHP 中實例化並指派給 `SVGOptions`：

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

在格式化回呼中，使用 [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) 搭配 [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) 之值，為匯出的圖形新增 JavaScript 事件處理程序。以 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) 指派回呼，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

與穩定 ID 相同，當 PhpJavaBridge 使用串流模式時，請在 Java 輔助類別中實作回呼。請參考 [Java implementation of `SvgEventController`](/slides/zh-hant/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) 其中的程式碼會為名為 `ActionButton` 的圖形指派 ID 與 `OnClick` 處理程序。編譯此輔助類別，將其加入 bridge classpath 並以 `com.example.slides.SvgEventController` 在 PHP 中使用，如下所示：

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

宿主頁面可以定義由處理程序參考的 JavaScript 函式。指派 ID 與事件處理程序可讓投影片檢視器、可及性增強功能以及其他互動式 SVG 工作流程得以運作。

## **常見問題**

**什麼時候應該使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

當所有文字必須脫離字型相依性時，請使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)；若僅需將使用外部字型的文字轉為圖形，則使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)。  

**縮小 SVG 的最佳方法是什麼？**

先壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境能提供時使用連結字型檔。請測試結果，因為降低圖像解析度、降低 JPEG 品質與向量化文字各有不同的品質與大小權衡。  

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化回呼指派 ID，之後在後處理工具或瀏覽器腳本中選取相應的 SVG 元素進行修改。