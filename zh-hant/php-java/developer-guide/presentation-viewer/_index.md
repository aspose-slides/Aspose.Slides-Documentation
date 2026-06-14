---
title: 在 PHP 中建立簡報檢視器
linktitle: 簡報檢視器
type: docs
weight: 50
url: /zh-hant/php-java/presentation-viewer/
keywords:
- 檢視簡報
- 簡報檢視器
- 建立簡報檢視器
- 檢視 PPT
- 檢視 PPTX
- 檢視 ODP
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 建立自訂的簡報檢視器。輕鬆在未安裝 Microsoft PowerPoint 的情況下顯示 PowerPoint 與 OpenDocument 檔案。"
---
## **簡介**

Aspose.Slides for PHP via Java 用於建立包含投影片的簡報檔案。這些投影片可以透過在 Microsoft PowerPoint 等程式中開啟簡報來檢視。然而，有時開發人員可能需要在自己偏好的圖像檢視器中查看投影片，或自行建立簡報檢視器。在此情況下，Aspose.Slides 允許您將單一投影片匯出為圖像。本文說明如何執行此操作。

## **產生投影片的 SVG 圖像**

若要使用 Aspose.Slides 從簡報投影片產生 SVG 圖像，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 開啟檔案串流。
1. 將投影片以 SVG 圖像儲存至檔案串流。

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **產生具有自訂形狀 ID 的 SVG**

可使用 Aspose.Slides 從投影片產生具備自訂形狀 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。為此，請使用來自 [SvgShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgshape/) 的 `setId` 方法。`CustomSvgShapeFormattingController` 可用於設定形狀 ID。

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **建立投影片縮圖影像**

Aspose.Slides 可協助您產生投影片的縮圖影像。若要使用 Aspose.Slides 產生投影片的縮圖，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 依指定比例取得參考投影片的縮圖影像。
1. 將縮圖影像以任何所需的圖像格式儲存。

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **建立使用者自訂尺寸的投影片縮圖**

若要建立具有使用者自訂尺寸的投影片縮圖影像，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 以自訂尺寸取得參考投影片的縮圖影像。
1. 將縮圖影像以任何所需的圖像格式儲存。

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **建立含講者備註的投影片縮圖**

若要使用 Aspose.Slides 產生含講者備註的投影片縮圖，請依照以下步驟操作：

1. 建立 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/) 類別的實例。
1. 使用 `RenderingOptions.setSlidesLayoutOptions` 方法設定講者備註的位置。
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 使用渲染選項取得參考投影片的縮圖影像。
1. 將縮圖影像以任何所需的圖像格式儲存。

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **即時範例**

您可以試用免費應用程式 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh-hant/viewer/) 來看看使用 Aspose.Slides API 能實作什麼：

![線上 PowerPoint 檢視器](online-PowerPoint-viewer.png)

## **常見問題**

**我可以在網頁應用程式中嵌入簡報檢視器嗎？**

是的。您可以在伺服器端使用 Aspose.Slides 將投影片渲染為圖像或 HTML，並在瀏覽器中顯示。可使用 JavaScript 實作導覽與縮放功能，以提供互動體驗。

**在自訂檢視器中顯示投影片的最佳方式是什麼？**

建議的做法是使用 Aspose.Slides 將每張投影片渲染為圖像（例如 PNG 或 SVG）或轉換為 HTML，然後將產生的內容顯示在圖片框（桌面應用程式）或 HTML 容器（網頁）中。

**如何處理擁有大量投影片的簡報？**

對於大型簡報，建議使用延遲載入或按需渲染投影片的方式。也就是說僅在使用者切換到該投影片時才產生其內容，以降低記憶體使用量與載入時間。