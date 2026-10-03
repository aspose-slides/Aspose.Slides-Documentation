---
title: 支援的檔案格式
type: docs
weight: 106
url: /zh-hant/java/supported-file-formats/
keywords:
- 支援的檔案格式
- 載入簡報
- 匯入 PDF
- 匯入 HTML
- 儲存簡報
- 渲染投影片
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "查看 Aspose.Slides for Java 能夠載入、匯入、儲存、渲染哪些檔案格式，以及哪個 API 讀寫每種格式。"
---
## **概觀**

Aspose.Slides for Java 可開啟與儲存 PowerPoint 與 OpenDocument 簡報。它還可將 PDF 與 HTML 內容匯入至投影片，將簡報儲存為文件、網頁與影像格式，並將單一投影片與圖形渲染為影像。此文章列出每種支援的格式，並說明讀取或寫入該格式的 API。

如需編輯功能概覽，請參閱[Features Overview](/slides/zh-hant/java/features-overview/)。

## **支援的 Microsoft PowerPoint 版本**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

PowerPoint 95 及以前版本儲存的簡報無法開啟。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 會辨識 PowerPoint 95 檔案並回報 `LoadFormat.Ppt95`，但 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 建構式會針對該檔案拋出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptunsupportedformatexception/)。

{{% /alert %}}

## **支援的檔案格式**

此表格使用四種操作：

- **Load**：使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 建構式開啟檔案為可編輯的簡報。會根據內容偵測格式；[LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 可提供密碼等設定。若要在開啟前檢查檔案，請呼叫 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)，其會回報一個 [LoadFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadformat/) 值。對於 PowerPoint XML 會回報 `LoadFormat.Unknown`，但建構式仍能開啟，之後 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSourceFormat--) 會回傳 `SourceFormat.Xml`。請參閱[Open Presentations](/slides/zh-hant/java/open-presentation/)與[Determine the Original Presentation Format](/slides/zh-hant/java/detect-presentation-source-format/)。
- **Import**：使用 [SlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/) 方法從檔案內容建立投影片並加入現有簡報。Presentation 建構式不會執行此類轉換。
- **Save**：[Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 依據 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 寫入簡報至檔案或串流。除 XAML 外的每種格式均以 SaveFormat 值選取。
- **Render**：渲染方法將投影片或圖形繪製為影像。僅能渲染的格式不屬於 SaveFormat 值。

|**格式**|**說明**|**載入 / 匯入**|**儲存 / 渲染**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 投影片放映|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 投影片放映|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 含巨集的簡報|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 含巨集的範本|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 含巨集的投影片放映|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument 簡報|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **載入與匯入**

- **Load**：將檔案路徑或串流傳入 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 建構式。格式會從內容自動偵測；[LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 可提供密碼等設定。若要在開啟前先檢查檔案，請呼叫 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)，它會回報一個 [LoadFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadformat/)。對於 PowerPoint XML 會回報 `LoadFormat.Unknown`，但建構式仍能開啟，之後 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSourceFormat--) 會回傳 `SourceFormat.Xml`。請參閱[Open Presentations](/slides/zh-hant/java/open-presentation/)與[Determine the Original Presentation Format](/slides/zh-hant/java/detect-presentation-source-format/)。
- **Import**：`[SlideCollection.addFromPdf](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-)` 會為 PDF 每一頁新增一張投影片至簡報尾端。`[SlideCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-)` 會從 HTML 建立投影片，`[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-)` 則可在指定位置插入。Presentation 建構式不會匯入：對 PDF 會拋出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptunsupportedformatexception/)，而 HTML 標記也不會自動轉換為投影片內容。請參閱[Import Presentations from PDF or HTML](/slides/zh-hant/java/import-presentation/)。

## **儲存與渲染**

- **Save**：`[Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-)` 依據 [SaveFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/) 寫入檔案。接受選項物件的重載可控制輸出，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/htmloptions/)、[Html5Options](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/)、[TiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/)、[GifOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/gifoptions/)。接受投影片位置陣列（從 1 起算）的重載僅寫入指定投影片；它支援 PDF、XPS、TIFF、HTML、HTML5、SWF、GIF 與 Markdown，但不支援簡報格式或 PowerPoint XML。XAML 有自己的重載 `[Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)`，接受 `[IXamlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ixamloptions/)`。請參閱[Save Presentations](/slides/zh-hant/java/save-presentation/)、[Convert Presentations](/slides/zh-hant/java/convert-presentation/)與[Export Presentations to XAML](/slides/zh-hant/java/export-to-xaml/)。
- **Render**：`[Slide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getImage-float-float-)` 與 `[Shape.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage--)` 會回傳一個 `[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/)`，而 `[IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-)` 可依據 `[ImageFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/)` 寫成 PNG、JPEG、BMP、GIF 或 TIFF。`[Presentation.getImages](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)` 可一次渲染全部或選取的投影片。`[Slide.writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-)` 與 `[Shape.writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-)` 可寫成 SVG，`[Slide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-)` 可寫成 EMF。請參閱[Convert Presentation Slides to Images](/slides/zh-hant/java/convert-slide/)與[Render Presentation Slides as SVG Images](/slides/zh-hant/java/render-a-slide-as-an-svg-image/)。

{{% alert color="warning" title="Warning" %}}

ImageFormat 也有 `Emf`、`Wmf`、`Icon`、`Exif` 與 `MemoryBmp` 值，但 `[IImage.save]` 不會產生這些格式：它寫出的檔案實際上是 PNG 資料。若需投影片的 EMF 影像，請使用 `Slide.writeAsEmf`。

{{% /alert %}}

## **常見問題**

**我可以將 PPT 簡報轉換為 PPTX 或 ODP 嗎？**

可以。使用 Presentation 建構式開啟 PPT 檔案，然後以 `SaveFormat.Pptx` 或 `SaveFormat.Odp` 儲存。請參閱[Convert PPT to PPTX](/slides/zh-hant/java/convert-ppt-to-pptx/)。

**我可以將 PDF 或 HTML 檔案直接當作簡報開啟嗎？**

不行。Presentation 建構式會對 PDF 檔案拋出 PptUnsupportedFormatException，且不會將 HTML 標記轉換為投影片。請先建立或開啟簡報，使用前述的投影片集合方法匯入 PDF 頁面或 HTML 內容，之後再儲存為任意支援格式。

**我可以將匯出的 PNG 或 SVG 圖片載入為可編輯的簡報嗎？**

不行。影像輸出只記錄投影片的外觀，並不包含文字、圖形或圖表。若需日後編輯，請保留原始簡報檔案。

**我可以儲存 PDF/A 或 PDF/UA 文件嗎？**

可以。將 `[PdfCompliance](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfcompliance/)` 值傳入 `[PdfOptions.setCompliance](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/#setCompliance-int-)`，支援 PDF/A-1a、PDF/A-1b、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 與 PDF/UA。

**我可以在開啟檔案前檢查是否受密碼保護嗎？**

可以。[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 會在未建立 Presentation 物件的情況下檢查檔案，而 `[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)` 會回報是否需要密碼。請參閱[Password-Protect Presentations](/slides/zh-hant/java/password-protected-presentation/)。