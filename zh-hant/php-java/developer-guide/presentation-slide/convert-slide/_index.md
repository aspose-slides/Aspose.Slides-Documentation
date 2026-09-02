---
title: 在 PHP 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 35
url: /zh-hant/php-java/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉為影像
- 將投影片保存為影像
- 投影片轉為 EMF
- 投影片轉為 PNG
- 投影片轉為 JPEG
- 投影片轉為點陣圖
- 投影片轉為 TIFF
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中將 PPT、PPTX 與 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 以及其他影像格式。"
---
## **簡介**

Aspose.Slides for PHP via Java 可以將 PowerPoint 和 OpenDocument 簡報的單張投影片渲染為 PNG、JPEG、GIF、TIFF 以及其他影像格式。

若要將投影片轉換為影像，請遵循以下步驟：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入簡報。
2. 選取要渲染的投影片。
3. 如有需要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別設定渲染參數。
4. 呼叫 [Slide::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage) 方法。它會傳回一個 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 物件。
5. 呼叫 [IImage::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/#save) 方法，並使用 [ImageFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imageformat/) 值指定輸出格式。

## **將投影片轉為 PNG 影像**

最簡單的轉換使用預設渲染設定。產生的 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 物件可在記憶體中處理或儲存為檔案。

以下 PHP 範例會渲染第一張投影片並將其儲存為 PNG 影像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **使用自訂尺寸將投影片轉為影像**

使用接受 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 值的 [Slide::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage) 重載，以精確的像素尺寸渲染投影片。

以下範例會建立 1820 × 1040 的 JPEG 影像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **將含註記與評論的投影片轉為影像**

預設情況下，投影片影像不會包含註記或評論。將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法，以控制註記與評論的顯示位置。

以下範例會將截斷的註記放在投影片下方，評論則放在右側：

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
對於投影片轉影像的轉換，請勿將 [BottomFull](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notespositions/) 傳遞給 [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法。註記的文字可能超出固定影像尺寸的容納範圍。請改用 [BottomTruncated](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notespositions/)。
{{% /alert %}}

## **使用 TIFF 選項將投影片轉為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別讓您可以控制所渲染 TIFF 影像的尺寸、解析度以及其他屬性。

以下範例會將第一張投影片渲染為 2160 × 2880、解析度 300 DPI 的 TIFF 影像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
在 JDK 9 之前的 Java 版本中，無法保證支援 TIFF。
{{% /alert %}}

## **將所有投影片轉為影像**

迭代投影片集合，以將整份簡報轉換為一系列影像。除非明確跳過，否則也會包含隱藏投影片。

以下範例會將每張投影片渲染為水平與垂直縮放係數皆為 2 的 JPEG 影像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **建立增強型圖形檔 (EMF) 輸出**

增強型圖形檔 (EMF) 在需要與 Microsoft Office 或其他支援 Windows 圖形檔的 Windows 應用程式交換向量圖形時相當有用。與基於像素的影像不同，EMF 可保留向量繪圖操作，在縮放時不會喪失銳利度。然而，EMF 主要是一種供具備 Windows 圖形檔支援之應用程式使用的相容性格式，並非通用的交換格式。此外，複雜的投影片內容（例如點陣圖影像和部分效果）可能會以光柵化元素儲存在向量圖形檔容器中。

### **將投影片匯出為 EMF**

[Slide::writeAsEmf](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#writeAsEmf) 方法會將投影片寫入目標串流，採用 EMF 格式。以下範例載入簡報、選取第一張投影片，並將其寫入 EMF 檔案串流：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

呼叫端擁有傳遞給 [Slide::writeAsEmf](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#writeAsEmf) 的串流，並負責如上所示關閉該串流。

### **將 SVG 影像轉換為 EMF 並加入簡報**

使用 [SvgImage::writeAsEmf](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/#writeAsEmf) 可將 SVG 內容轉換為 EMF。產生的位元組可透過 [ImageCollection::addImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/#addImage) 加入簡報，並使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addPictureFrame) 放置於投影片上。

以下範例會從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/)，將其轉換為記憶體中的 EMF，插入第一張投影片，並儲存簡報：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/#writeAsEmf) 不會取得目的串流的所有權。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 會將所有產生的資料儲存於記憶體中，因此在呼叫 `toByteArray` 前無需重設位置。即使串流已關閉，返回的位元組陣列仍然有效。

EMF 產生在所選擇的 Aspose.Slides for PHP via Java 以及 JDK 設定支援的作業系統上皆可使用，但當字型或圖形相依項缺乏時，各平台的渲染結果可能會有所不同。請安裝來源內容使用的字型或設定適當的替代方案，並遵循 Aspose.Slides for PHP via Java 的 [platform requirements](/slides/zh-hant/php-java/system-requirements/) ，於目標 EMF 消費應用程式中驗證結果。Linux 與 macOS 應用程式通常對顯示與編輯 Windows 圖形檔的支援有限或不一致。

## **彩色表情符號渲染**

{{% alert title="Note" color="info" %}}
若要在將簡報投影片轉換為影像時正確呈現彩色表情符號，必須在執行轉換的系統上安裝並提供簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji** 而該字型缺失，則輸出影像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染含動畫的投影片？**

否。 [Slide::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage) 方法僅渲染投影片的靜態影像，且不會匯出動畫。

**可以將隱藏投影片匯出為影像嗎？**

可以。隱藏投影片可像一般投影片一樣渲染。請將它們納入處理迴圈，如上述範例所示。

**投影片影像會保留陰影與其他效果嗎？**

會。Aspose.Slides 會在投影片影像中呈現陰影、透明度以及其他支援的圖形效果。