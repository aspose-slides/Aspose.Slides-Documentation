---
title: 在 PHP 中將 PowerPoint 簡報轉換為 HTML
linktitle: PowerPoint 轉 HTML
type: docs
weight: 30
url: /zh-hant/php-java/convert-powerpoint-to-html/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 HTML
- 簡報轉 HTML
- 投影片轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- 將 PowerPoint 儲存為 HTML
- 將簡報儲存為 HTML
- 將投影片儲存為 HTML
- 將 PPT 儲存為 HTML
- 將 PPTX 儲存為 HTML
- 匯出 PPT 為 HTML
- 匯出 PPTX 為 HTML
- PHP
- Aspose.Slides
description: "在 PHP 中將 PowerPoint 簡報轉換為 HTML。使用 Aspose.Slides 匯出 PPT 與 PPTX 檔案、選取的投影片、備註、字型、影像、SVG 與媒體。"
---
## **概觀**

Aspose.Slides for PHP via Java 可以在沒有 Microsoft PowerPoint 的情況下將 PowerPoint 簡報儲存為 HTML。基本的轉換只需載入單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，然後使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/) 進行 `save` 呼叫。當需要控制匯出佈局、字型、影像、備註、評論、SVG 輸出或連結資源時，請使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/)。

本文檔聚焦於實務的 HTML 匯出情境：

- 匯出整個簡報或選取的投影片。
- 產生固定版面、響應式或基於 SVG 的 HTML。
- 包含講者備註與評論。
- 控制影像品質與裁切的影像資料。
- 嵌入字型或將字型檔案分別儲存。
- 選擇外部資源與媒體檔案的寫入方式與參照方式。

預設情況下，HTML 匯出會產生一個自包含的 HTML 文件，絕大多數資源皆以內嵌方式呈現。這樣方便共享單一檔案，但會增加輸出大小。對於網路發佈，請考慮使用外部資源、降低影像 DPI，並僅嵌入目標環境中不可靠可取得的字型。

## **將簡報轉換為 HTML**

若要將簡報匯出為 HTML，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 載入簡報，並以 [SaveFormat.Html](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveformat/) 存檔。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

此範例會寫入一個 HTML 檔案。簡報物件會在 `finally` 區塊中釋放，從而在匯出後釋放檔案句柄與渲染資源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/) 是 HTML 匯出的主要設定類別。常見的設定包括：

- `SlidesLayoutOptions`：加入備註、評論、講義或其他版面資訊。
- `HtmlFormatter`：變更 HTML 文件結構或將格式化委派給控制器。
- `SlideImageFormat`：變更投影片的表示方式，例如以 SVG 形式。
- `PicturesCompression`：控制影像 DPI 與輸出大小。
- `DeletePicturesCroppedAreas`：保留或移除裁切的影像資料。
- `SvgResponsiveLayout`：讓匯出的 SVG 內容自適應其容器。
- `ShowHiddenSlides`：在需要時包含隱藏投影片。

以下各節分別說明最常見的選項，您可依工作流程需求僅組合所需的設定。

## **將選取的投影片轉換為 HTML**

接受投影片編號的 `save` 多載使用 1 起算的投影片位置。以下迴圈會將每張投影片儲存為個別的 HTML 檔案。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

當網站或應用程式需要每張投影片對應一個 HTML 頁面時，請使用此模式。若每張投影片皆使用相同版面，請建立一個 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/) 實例，並在每次 `save` 呼叫時傳入。

## **建立響應式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/responsivehtmlcontroller/) 透過 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmlformatter/) 提供響應式 HTML 輸出。當匯出的頁面需要更佳地適應瀏覽器寬度時，請使用它。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

若採用基於 SVG 的響應式版面，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/) 上設定 `SvgResponsiveLayout`。當投影片內容以可伸縮的 SVG 標記匯出時，這非常有用。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **包含講者備註與評論**

透過 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/) 可加入講者備註或評論。備註與評論預設為隱藏，除非您指定其顯示位置。

假設原始簡報包含講者備註：

![PowerPoint 中具備講者備註的投影片](slide_with_notes.png)

以下程式碼會將投影片內容與投影片下方的講者備註一起匯出。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

匯出的 HTML 包含備註區域：

![包含投影片與講者備註的 HTML 輸出](HTML_with_notes.png)

若要匯出評論，請設定 `CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。若只需要評論，可省略 `NotesPosition`。若同時需要備註與評論，請同時設定兩個屬性。

## **控制影像品質與裁切區域**

HTML 匯出可以壓縮投影片影像以減少輸出大小。當需要更高影像品質時，請將 `PicturesCompression` 設為來自 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturescompression/) 的值。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

預設情況下，影像的裁切區域可能會從匯出結果中移除。僅在使用者必須能夠復原或檢視那些被隱藏的影像部份時才保留裁切資料。保留它會增加 HTML 大小。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **加入 CSS**

若僅需簡單樣式，可透過 `createDocumentFormatter` 将 CSS 字串傳遞給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmlformatter/)。這會變更外層 HTML 文件，同時 Aspose.Slides 繼續渲染投影片內容。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

若需要自訂文件標頭、連結的 CSS 檔案，或投影片與形狀周圍的自訂標記，請使用自訂格式化控制器，並以 `createCustomFormatter` 傳遞給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmlformatter/)。

## **嵌入字型**

若目標環境可能未安裝簡報所使用的字型，請使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/embedallfontshtmlcontroller/) 將字型嵌入 HTML。嵌入可以提升視覺一致性，但會增加輸出大小。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

僅在確信目標瀏覽器或系統已提供該字型時才排除嵌入。對於品牌字型或較不常見的字型，嵌入通常較為安全。

## **使用字型檔案連結取代嵌入**

為了減少 HTML 檔案大小，您可以將字型資料寫入單獨的 WOFF 檔案，並在 HTML 中加入 `@font-face` 規則。在 PHP via Java 中，通常會以繼承自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/embedallfontshtmlcontroller/) 的小型 Java 輔助類別來實作此情境，該類別會將字型位元寫入輸出目錄，並將 `@font-face` 規則注入產生的 HTML。編譯此輔助類別、將其加入 PHP Java Bridge 的類別路徑，然後在 PHP 中以 `new Java(...)` 例項化它。

建立此類輔助程式時，請刻意選擇兩個路徑：

- 檔案系統輸出路徑，用於寫入產生的字型檔案。
- URL 路徑，瀏覽器會根據 HTML 文件中的此路徑載入字型檔案。

## **外部儲存資源**

自包含的 HTML 易於搬移，但內嵌的 Base64 資源會使檔案變大。若您的應用程式需要外部影像檔案，請向 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/) 建構子提供自訂的連結/嵌入控制器。

在外部化資源時，請刻意選擇兩個路徑：

- 檔案系統輸出路徑，您的應用程式會在此寫入產生的影像、字型、音訊或視訊。
- URL 路徑，瀏覽器會根據 HTML 文件中的此路徑載入這些檔案。

請確保這些路徑與部署佈局一致，以便產生的 HTML 在移至 Web 伺服器或其他目錄後，仍能正確載入外部資源。

## **匯出媒體檔案**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/videoplayerhtmlcontroller/) 會匯出視訊與音訊檔案，並產生可在瀏覽器中播放的 HTML。其建構子接受：

- `path`：產生的 HTML 與媒體檔案使用的輸出目錄。
- `fileName`：正在產生的 HTML 檔案名稱。
- `baseUri`：HTML 中連結至媒體檔案時使用的絕對 URI 前綴。

若 HTML 檔案為 `html-output/presentation.html`，則 `path` 應指向 `html-output`，而 `baseUri` 應指向瀏覽器觀點下相同的目錄。對於本機預覽，可從輸出目錄產生 `file:///` URI。若為已部署的應用程式，請使用已發布輸出目錄的絕對 URL。

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

請為每個匯出作業使用唯一的輸出目錄，特別是在伺服器應用程式中。共用的輸出路徑可能導致不同轉換的檔案互相覆寫。

## **效能與資源管理**

HTML 轉換屬於渲染操作，處理時間與記憶體使用量取決於投影片數量、影像解析度、字型、特效、圖表與嵌入的媒體。較高的 `PicturesCompression` DPI、嵌入字型、SVG 輸出及保留裁切影像區域可提升忠實度，但通常會增加輸出大小。

進行批次轉換時：

- 盡快釋放每個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例。
- 為每個作業使用不同的輸出目錄。
- 除非需要最高忠實度，否則避免嵌入常見字型。
- 當 HTML 用於預覽或縮圖時，降低影像 DPI。
- 在部署路徑最終確定之前，保持原始簡報、產生的 HTML 以及外部資源一起保存。

## **常見問答**

**HTML 輸出中會保留超連結嗎？**

是的。簡報中的超連結會匯出至 HTML，且在目標 URL 有效時仍可點擊。

**我可以平行將簡報轉換為 HTML 嗎？**

可以，但請勿在多執行緒間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例。請以獨立的簡報實例、獨立的串流以及獨立的輸出目錄來處理不同的檔案。

**Presentation 物件是執行緒安全的嗎？**

不是。單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例應在同一執行緒上載入、修改、儲存與釋放。若要平行處理，請為每個執行緒或程序建立獨立的實例。

**為什麼產生的 HTML 檔案會很大？**

預設匯出會直接將資源內嵌於 HTML 中。嵌入的字型、高 DPI 影像、媒體、SVG 內容以及保留的裁切影像區域都會增加檔案大小。若較小的輸出比最高忠實度更重要，請使用外部資源、排除一般字型的嵌入，並降低 `PicturesCompression`。

**為什麼 PowerPoint 中的字型大小 (例如 24 pt) 會在 HTML 中顯示為 17.999819 pt？**

這可能是因為 PowerPoint 與 HTML 使用不同的 DPI 模型所致。PowerPoint 依據 72 DPI 以排版點數儲存文字大小，而 HTML 版面則以 96 DPI 的 CSS 像素為基準。Aspose.Slides 在將簡報匯出為 HTML 時，會在這兩套系統之間轉換字型大小，轉換過程中可能會產生微小的四捨五入差異。

這些數值並不代表實際的視覺字型大小變化，只是 PowerPoint 與 HTML 之間文字度量轉換的數學副作用。

**應該如何選擇 media 匯出的 baseUri？**

請從瀏覽器的觀點選擇 `baseUri`，並以絕對 URI 傳遞。對於本機預覽，可從輸出目錄產生 Java 檔案 URI。部署時，請使用已發佈媒體目錄的絕對 URL。檔案系統的 `path` 與瀏覽器的 `baseUri` 不必是相同的字串，但必須指向同一資源位置。

**我可以包含隱藏的投影片嗎？**

可以。當必須匯出隱藏投影片時，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/) 上將 `ShowHiddenSlides` 設為 `true`。