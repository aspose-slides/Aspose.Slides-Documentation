---
title: 在 Android 上將 PowerPoint 簡報轉換為 HTML
linktitle: PowerPoint 轉 HTML
type: docs
weight: 30
url: /zh-hant/androidjava/convert-powerpoint-to-html/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 HTML
- 簡報 轉 HTML
- 投影片 轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- 將 PowerPoint 儲存為 HTML
- 將簡報儲存為 HTML
- 將投影片儲存為 HTML
- 將 PPT 儲存為 HTML
- 將 PPTX 儲存為 HTML
- 匯出 PPT 為 HTML
- 匯出 PPTX 為 HTML
- Android
- Java
- Aspose.Slides
description: "在 Android 上將 PowerPoint 簡報轉換為 HTML。使用 Aspose.Slides for Android via Java 匯出 PPT 與 PPTX 檔案、選取的投影片、備註、字型、圖像、SVG 與媒體。"
---
## **概覽**

Aspose.Slides for Android via Java 可以在不使用 Microsoft PowerPoint 的情況下將 PowerPoint 簡報儲存為 HTML。基本的轉換只需要載入單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)，然後使用 `save` 呼叫搭配 [SaveFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/)。當您需要控制匯出布局、字型、圖像、備註、評論、SVG 輸出或連結資源時，請使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/)。

本指南專注於實用的 HTML 匯出情境：

- 匯出整個簡報或選取的投影片。
- 產生固定布局、回應式或基於 SVG 的 HTML。
- 包含講者備註與評論。
- 控制圖像品質與裁切圖像資料。
- 嵌入字型或將字型檔案分別儲存。
- 選擇外部資源與媒體檔案的寫入與參照方式。

預設情況下，HTML 匯出會產生一個自包含的 HTML 文件，將大多數資源嵌入其中。這對於分享單一檔案很方便，但會增加輸出檔案大小。若要進行網站發佈，請考慮使用外部資源、降低圖像 DPI，僅嵌入目標環境中不可靠取得的字型。

## **將簡報轉換為 HTML**

若要將簡報匯出為 HTML，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 載入，並以 [SaveFormat.Html](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/) 儲存。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

此範例寫入單一 HTML 檔案。`finally` 區塊會釋放 `Presentation` 物件，以關閉檔案句柄與渲染資源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/) 是 HTML 匯出的主要設定類別。常用設定包括：

- `SlidesLayoutOptions`：加入備註、評論、講義或其他布局資訊。
- `HtmlFormatter`：變更 HTML 文件結構或將格式化委派給控制器。
- `SlideImageFormat`：變更投影片的呈現方式，例如以 SVG 形式。
- `PicturesCompression`：控制圖像 DPI 與輸出大小。
- `DeletePicturesCroppedAreas`：保留或移除裁切圖像資料。
- `SvgResponsiveLayout`：使匯出的 SVG 內容自適應其容器。
- `ShowHiddenSlides`：在需要時包含隱藏投影片。

以下各節分別說明最常用的選項，您可根據工作流程僅組合需要的部分。

## **將選取的投影片轉換為 HTML**

接受投影片編號的 `Presentation.save` 多載使用 1 為基礎的投影片位置。以下迴圈會將每張投影片儲存為單獨的 HTML 檔案。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

當網站或應用程式需要每張投影片一個 HTML 頁面時，請使用此模式。若每張投影片的布局相同，請建立單一的 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/) 實例，並在每次 `save` 呼叫時傳入。

## **建立回應式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/responsivehtmlcontroller/) 透過 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmlformatter/) 提供回應式 HTML 輸出。當匯出的頁面需要更好地適應瀏覽器寬度時，請使用它。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

若要使用基於 SVG 的回應式布局，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/) 上設定 `SvgResponsiveLayout`。當投影片內容以可縮放的 SVG 標記匯出時，這非常有用。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **包含講者備註與評論**

透過 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 以包含講者備註或評論。備註與評論預設為隱藏，除非您指定其位置。

假設來源簡報包含講者備註：

![PowerPoint 中含有講者備註的投影片](slide_with_notes.png)

以下程式碼會將投影片內容與投影片下方的講者備註一起匯出。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

匯出的 HTML 會包含備註區域：

![包含投影片與講者備註的 HTML 輸出](HTML_with_notes.png)

若要匯出評論，請設定 `CommentsPosition`，例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`。僅需要評論時可省略 `NotesPosition`；若同時需要備註與評論，則同時設定兩個屬性。

## **控制圖像品質與裁切區域**

HTML 匯出可以壓縮投影片圖像以減少輸出大小。當您需要較高圖像品質時，請將 `PicturesCompression` 設為 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturescompression/) 中的相應值。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

預設情況下，圖像的裁切區域可能會從匯出結果中移除。僅在使用者必須能恢復或檢視這些隱藏圖像部分時才保留裁切資料。保留會增加 HTML 大小。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **新增 CSS**

若只需簡單樣式，將 CSS 字串傳給 `HtmlFormatter.createDocumentFormatter`。這會改變外圍的 HTML 文件，同時 Aspose.Slides 繼續渲染投影片內容。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

若需自訂文件標頭、連結的 CSS 檔案，或在投影片與圖形周圍加入自訂標記，請實作 [IHtmlFormattingController](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihtmlformattingcontroller/) 並以 `createCustomFormatter` 方式傳給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmlformatter/)。

## **嵌入字型**

如果目標環境可能未安裝簡報使用的字型，請使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) 在 HTML 中嵌入字型。嵌入可提升視覺忠實度，但會增加輸出大小。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

僅在確信目標瀏覽器或系統已提供相同字型時才排除嵌入。對於品牌字型或較不常見的字型，嵌入通常較安全。

## **連結字型檔而非嵌入**

為降低 HTML 檔案大小，您可以將字型資料寫入獨立的 WOFF 檔案，並在 HTML 中加入 `@font-face` 規則。以下輔助類別繼承自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) 並覆寫 `writeFont`。

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

在此範例中，字型檔案會儲存至 `html-output/fonts`，HTML 會以 `fonts/BrandFont-normal-400.woff` 等 URL 參照它們。若 HTML 檔案與字型檔部署至其他位置，請設定 `fontUrlPrefix` 使其匹配部署後的 URL 路徑。

## **將資源外部儲存**

自包含的 HTML 易於搬移，但內嵌的 Base64 資源會使檔案變大。若您的應用程式需要外部圖像檔案，請實作 [ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinkembedcontroller/) 並於建構子傳入 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/)。

外部化資源時，請有意識地選擇兩條路徑：

- **檔案系統輸出路徑**：您的應用程式寫入產生的圖像、字型、音訊或視訊的目錄。
- **URL 路徑**：瀏覽器從 HTML 文件載入這些檔案時使用的路徑。

## **匯出媒體檔案**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) 會匯出影片與音訊檔案，並產生可在瀏覽器播放的 HTML。其建構子接受：

- `path`：產生的媒體檔案寫入的目錄。
- `fileName`：正在產生的 HTML 檔案名稱。
- `baseUri`：HTML 中指向媒體檔案的絕對 URI 前綴。

如果 HTML 檔案位於 `html-output/presentation.html`，而媒體檔案儲存在 `html-output/media`，則 `path` 應指向磁碟上的 media 目錄，`baseUri` 應指向瀏覽器端相同目錄的 URL。本機預覽時，可從 media 目錄建立 `file:///` URI；部署時則使用已發佈媒體目錄的絕對 URL。

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

請為每次匯出作業使用唯一的輸出目錄，特別是在伺服器應用程式中。共享的輸出路徑會導致不同轉換產生的檔案相互覆寫。

## **效能與資源管理**

HTML 轉換屬於渲染操作，處理時間與記憶體使用量取決於投影片數量、圖像解析度、字型、特效、圖表與內嵌媒體。較高的 `PicturesCompression` DPI 值、嵌入字型、SVG 輸出與保留裁切圖像區域會提升相似度，但通常會增加輸出大小。

批次轉換時的建議：

- 盡快釋放每個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例。
- 為不同作業使用獨立的輸出目錄。
- 除非相似度要求極高，否則避免嵌入常見字型。
- 當 HTML 用於預覽或縮圖時降低圖像 DPI。
- 在部署路徑最終確定前，保留原始簡報、產生的 HTML 與外部資源在一起。

## **常見問題**

**HTML 輸出中會保留超連結嗎？**

會。簡報中的超連結會匯出為 HTML，且在目標 URL 有效時仍可點擊。

**我可以平行轉換簡報為 HTML 嗎？**

可以，但請勿在多執行緒間共享同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例。對不同檔案使用獨立的簡報實例、獨立的串流與獨立的輸出目錄。詳情請參閱 [multithreading guidance](/slides/zh-hant/androidjava/multithreading/)。

**Presentation 物件是執行緒安全的嗎？**

不是。單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例應在同一執行緒上載入、修改、儲存並釋放。若需要平行作業，請為每個執行緒或程序建立獨立的實例。

**為何產生的 HTML 檔案很大？**

預設匯出會直接將資源嵌入 HTML。嵌入的字型、高 DPI 圖像、媒體、SVG 內容以及保留的裁切圖像區域都會增加檔案大小。使用外部資源、排除常見字型的嵌入，並在對相似度要求不高時降低 `PicturesCompression`，即可縮小輸出。

**為何 PowerPoint 中的 24 pt 字型在 HTML 中顯示為 17.999819 pt？**

這是因為 PowerPoint 與 HTML 使用了不同的 DPI 模型。PowerPoint 依據 72 DPI 的排版點存儲字型大小，而 HTML 版面則基於 96 DPI 的 CSS 像素。Aspose.Slides 在匯出簡報為 HTML 時，需要在這兩套系統之間進行換算，換算過程可能會產生細微的捨入差異。

這些數值並不代表實際可見的字型大小變化，僅是 PowerPoint 與 HTML 文字度量換算的數學副作用。

**應如何為媒體匯出選擇 baseUri？**

請從瀏覽器的觀點選擇 `baseUri`，並以絕對 URI 形式傳入。本機預覽時，可從輸出目錄使用 `mediaDirectory.toUri().toString()` 取得；部署時則使用已發佈媒體目錄的絕對 URL。檔案系統的 `path` 與瀏覽器的 `baseUri` 不必相同字串，但必須指向同一資源位置。

**我可以包含隱藏投影片嗎？**

可以。當必須匯出隱藏投影片時，請於 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/) 上將 `ShowHiddenSlides` 設為 `true`。