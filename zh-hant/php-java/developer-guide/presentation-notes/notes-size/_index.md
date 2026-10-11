---
title: 在 PHP 中變更備註頁面大小與方向
linktitle: 備註頁面大小
type: docs
weight: 10
url: /zh-hant/php-java/notes-size/
keywords:
- 備註頁面大小
- 備註方向
- 橫向備註
- 直向備註
- 講義大小
- PowerPoint
- 簡報
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for PHP 中讀取並變更備註頁面尺寸，切換方向、驗證已儲存的尺寸，並將備註或講義匯出為 PDF 與影像。"
---
## **概述**

使用 [Presentation::getNotesSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getnotessize/) 取得簡報的備註頁面設定。它會傳回一個 [NotesSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notessize/) 物件，其 [setSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notessize/setsize/) 方法可設定頁面尺寸。雖然設定物件本身無法被取代，但您可以透過此方法指派新的尺寸。

寬度與高度的單位為 **點 (points)**，每英吋 72 點。例如，900 × 600 點等於 12.5 × 8⅓ 英吋。這些設定套用於整個簡報，而不是單一投影片的備註。

| Setting | Purpose |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getnotessize/) | 控制備註頁面的尺寸與列印講義匯出的頁面尺寸。 |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getslidesize/) | 透過 [SlideSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/) 控制一般簡報投影片的尺寸。 |

變更任一設定不會自動變更另一個。變更備註頁面方向也不會旋轉一般投影片。請參閱 [Slide Size](/slides/zh-hant/php-java/slide-size/) 以調整一般投影片的尺寸。

下列範例使用現有的 `sample.pptx`。匯出範例需使用至少包含一張含有演講者備註的投影片的簡報。每個範例皆可在載入 PHP/Java Bridge 與 Aspose.Slides PHP 包裝器後獨立執行。由 Java 回傳的數值會在比較或計算前以 `java_values` 轉換為 PHP 值。

## **讀取備註頁面的大小與方向**

讀取寬度與高度並比較它們以判斷方向：較寬的頁面為橫向，較高的頁面為直向，尺寸相等則為正方形頁面。此範例會以點為單位印出實際尺寸，且不假設任何標準紙張大小。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **僅切換為橫向而不變更紙張大小**

若只想更改方向，只需交換現有的寬度與高度。此方式會保留兩邊的長度，包括自訂紙張大小的長度。下列條件可避免已為橫向的頁面再次被切換回直向，且正方形頁面保持不變。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

對於直向，請在 `java_values($size->getWidth()) > java_values($size->getHeight())` 時使用相同的指派。除非您也想變更紙張大小，否則不要改寫為 A4 或 Letter 的尺寸。

## **設定並驗證自訂備註頁面大小**

一次指派兩個尺寸，然後使用 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/save/) 將簡報寫入檔案。此範例設定 900 × 600 點的橫向頁面，將其儲存為 PPTX，並再次開啟已儲存的檔案以檢查持久化的值。比較時允許 0.01 點的誤差以因應浮點數值；此容差並不保證每種檔案格式皆精確。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

預期結果為 `900 x 600 points` 與 `Size preserved: true`。重新開啟簡報的檢查可驗證已儲存的檔案，而不只是記憶體中的設定。

## **匯出備註與講義**

頁面尺寸定義了備註或講義版面可使用的區域。僅設定尺寸並不會自動啟用這些版面：仍需設定匯出選項。一般投影片的匯出仍會使用投影片尺寸。

### **將備註匯出為 PDF 與 PNG**

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/) 指派給 [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 以在 PDF 中包含備註。此範例同時使用 [Slide::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/) 將第一張含備註的投影片渲染為 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notespositions/) 模式會將備註保留在單頁上；無法放下的備註會被截斷。PDF 使用 900 × 600 點的頁面。以下程式碼以 1 × 1 的影像比例渲染，PNG 為 900 × 600 像素。點用來描述頁面幾何，像素則描述光柵輸出，其尺寸亦受渲染比例影響。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

若要在 PDF 匯出長篇備註時自動產生多頁，可使用 [BottomFull](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notespositions/)。不要將該模式與上述僅支援單張投影片影像呼叫結合使用。調整尺寸後，請檢查輸出是否有被截斷的備註，以及現有備註母版物件的排列；僅變更頁面尺寸並不保證所有內容皆能完整呈現。更多備註匯出資訊請參閱 [Convert PowerPoint to PDF with Notes](/slides/zh-hant/php-java/convert-powerpoint-to-pdf-with-notes/)。

### **將講義匯出為 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handoutlayoutingoptions/) 以在單頁上放置多張投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用 [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handouttype/) 以水平方式排列每頁最多四張投影片。水平預設控制投影片的排序；頁面方向則由其寬度與高度決定。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

變更頁面大小會改變講義格線的可用區域，但不會改變來源投影片的尺寸。若要取得講義影像，請使用 [Presentation::getImages](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getimages/) 搭配講義版面，而不是單一投影片的影像方法。在 Aspose.Slides 中，簡報層級的講義渲染會使用備註頁面尺寸，而個別投影片影像呼叫則不會產生講義頁面。更多版面配置請參閱 [Handout Mode](/slides/zh-hant/php-java/convert-powerpoint-in-handout-mode/)。

## **檢視器、匯出與列印時的頁面尺寸**

請將儲存於簡報中的尺寸、匯出的頁面尺寸與列印時的紙張尺寸分開考慮：

- **簡報檢視器：** 檢視器可以依自己的版面規則顯示或列印備註。若其他應用程式儲存檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會使尺寸正規化。
- **匯出格式：** 以上的備註與講義 PDF 範例皆使用已設定的頁面尺寸。光柵影像使用整數像素尺寸與渲染比例，故點數的小數部分可能在影像輸出時被四捨五入。匯出一般投影片時不會套用備註頁面尺寸。
- **印表機驅動程式：** 紙張選擇、自動旋轉與自動調整至頁面等設定可在不變更簡報或 PDF 中儲存尺寸的前提下改變實際輸出。若使用特定紙張大小，請匹配印表機設定並檢查列印預覽。

## **常見問題**

**我能為單一投影片設定備註大小嗎？**

備註頁面大小是簡報層級的設定。單一投影片可以有不同的備註內容，但此屬性不會為每張投影片提供獨立的頁面大小。

**為什麼變更備註方向時投影片沒有一起旋轉？**

備註頁面與一般投影片的尺寸是相互獨立的。若要調整投影片本身的尺寸，請使用一般投影片尺寸設定。

**為什麼我的儲存或列印結果尺寸不同？**

請先重新開啟已儲存的簡報並比較其備註尺寸。若已變更，檢查是否有其他應用程式在儲存或轉換時改變了頁面設定。若未變更，則需檢查匯出版面、影像比例、檢視器設定與印表機紙張選擇。