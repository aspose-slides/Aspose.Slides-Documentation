---
title: 支援的檔案格式
type: docs
weight: 96
url: /zh-hant/net/supported-file-formats/
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
- .NET
- C#
- Aspose.Slides
description: "查看 Aspose.Slides for .NET 能夠載入、匯入、儲存及渲染哪些檔案格式，以及哪個 API 讀寫每種格式。"
---
## **概覽**

Aspose.Slides for .NET 可開啟與儲存 PowerPoint 與 OpenDocument 簡報。它亦可將 PDF 與 HTML 內容匯入投影片，將簡報儲存為文件、網站與影像格式，並將單一投影片或圖形渲染為影像。本文列出所有支援的格式，並說明讀寫該格式的 API。

兩個 NuGet 套件 Aspose.Slides.NET 與 Aspose.Slides.NET6.CrossPlatform 支援相同的格式；請參閱[Installation](/slides/zh-hant/net/installation/)以選擇使用哪一個。欲了解編輯功能的概觀，請參閱[Features Overview](/slides/zh-hant/net/features-overview/)。

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

{{% alert color="info" title="注意" %}}

PowerPoint 95 及更早版本儲存的簡報無法開啟。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 會辨識 PowerPoint 95 檔案並回報 `LoadFormat.Ppt95`，但 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/presentation/) 建構式會拋出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptunsupportedformatexception/)。

{{% /alert %}}

## **支援的檔案格式**

此表格使用四種操作：

- **Load**：使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/presentation/) 建構式開啟檔案作為可編輯的簡報。
- **Import**：使用 [SlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/) 方法將檔案內容建立為投影片，並加入現有簡報。Presentation 建構式不會將此類檔案載入為簡報。
- **Save**：[Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 以檔案或串流寫入簡報。除 XAML 外的每種格式皆透過 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 指定。
- **Render**：渲染方法將投影片或圖形繪製為影像。僅能渲染的格式不屬於 SaveFormat 值。

|**Format**|**Description**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 投影片放映|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 投影片放映|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|支援巨集的 PowerPoint 簡報|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|支援巨集的 PowerPoint 範本|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|支援巨集的 PowerPoint 投影片放映|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument 簡報|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|可攜式文件格式|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|超文字標記語言|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 紙張規格|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|標記圖像檔案格式|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|圖形交換格式|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型 Web 格式（Flash）|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|可擴充應用程式標記語言|—|Save|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|可攜式網路圖形|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG 圖像|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|點陣圖像|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|增強型圖形檔案|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可伸縮向量圖形|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **載入與匯入**

- **Load**：將檔案路徑或串流傳入 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/presentation/) 建構式。系統會依內容偵測格式；[LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/) 可提供密碼等設定。若要在開啟前先檢查檔案，請呼叫 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/)，它會回報一個 [LoadFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadformat/) 值。對於 PowerPoint XML 會回報 `LoadFormat.Unknown`，但建構式仍能開啟，之後可使用 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sourceformat/) 取得 `SourceFormat.Xml`。參考[Open Presentations](/slides/zh-hant/net/open-presentation/)與[Determine the Original Presentation Format](/slides/zh-hant/net/detect-presentation-source-format/)。
- **Import**：[SlideCollection.AddFromPdf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/addfrompdf/) 會為每一頁 PDF 新增一張投影片至簡報末端。[SlideCollection.AddFromHtml](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/addfromhtml/) 會從 HTML 建立投影片，且 [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/insertfromhtml/) 可在指定位置插入。Presentation 建構式不會匯入：對 PDF 檔會拋出 [PptUnsupportedFormatException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptunsupportedformatexception/)，且不會將 HTML 標記轉換為投影片內容。請參閱[Import Presentations from PDF or HTML](/slides/zh-hant/net/import-presentation/)。

## **保存與渲染**

- **Save**：[Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 以 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 的值寫入檔案。接受選項物件的重載可控制輸出，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/)、[Html5Options](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/html5options/)、[TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/)、[GifOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/gifoptions/)。接受投影片位置陣列（從 1 開始）的重載只寫入指定投影片；它支援 PDF、XPS、TIFF、HTML、HTML5、SWF、GIF 與 Markdown，但不支援簡報格式或 PowerPoint XML。XAML 有自行的重載，接受 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/ixamloptions/)。請參閱[Save Presentations](/slides/zh-hant/net/save-presentation/)、[Convert Presentations](/slides/zh-hant/net/convert-presentation/)與[Export Presentations to XAML](/slides/zh-hant/net/export-to-xaml/)。
- **Render**：[Slide.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage/) 與 [Shape.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage/) 會回傳一個 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/)，而 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/save/) 可依 [ImageFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/) 的值寫為 PNG、JPEG、BMP、GIF 或 TIFF。[Presentation.GetImages](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages/) 可一次渲染全部或指定投影片。[Slide.WriteAsSvg](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/writeassvg/) 與 [Shape.WriteAsSvg](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/writeassvg/) 可寫入 SVG，[Slide.WriteAsEmf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/writeasemf/) 可寫入 EMF。請參閱[Convert Presentation Slides to Images](/slides/zh-hant/net/convert-slide/)與[Render a Slide as an SVG Image](/slides/zh-hant/net/render-a-slide-as-an-svg-image/)。

{{% alert color="warning" title="警告" %}}

ImageFormat 也有 `Emf`、`Wmf`、`Icon`、`Exif`、`MemoryBmp` 等值，但 IImage.Save 並不會產生這些格式：寫出的檔案仍是 PNG 資料。若需取得投影片的 EMF 影像，請使用 Slide.WriteAsEmf。

{{% /alert %}}

## **常見問題**

**我可以將 PPT 簡報轉換為 PPTX 或 ODP 嗎？**

可以。使用 Presentation 建構式開啟 PPT 檔，然後以 `SaveFormat.Pptx` 或 `SaveFormat.Odp` 儲存。請參閱[Convert PPT to PPTX](/slides/zh-hant/net/convert-ppt-to-pptx/)。

**我可以將 PDF 或 HTML 檔案直接當作簡報開啟嗎？**

不能。請先建立或開啟一個簡報，再使用前述的投影片集合方法匯入 PDF 頁面或 HTML 內容，最後儲存為任意支援的格式。

**我可以將輸出的 PNG 或 SVG 圖像載入為可編輯的簡報嗎？**

不能。影像僅記錄投影片的外觀，無法包含文字、圖形或圖表。若需之後編輯，請保留原始簡報。

**我可以儲存 PDF/A 或 PDF/UA 文件嗎？**

可以。將 [PdfOptions.Compliance](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/compliance/) 設為相應的 [PdfCompliance](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfcompliance/) 值：PDF/A-1a、PDF/A-1b、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b 或 PDF/UA。

**我能在開啟前檢查檔案是否受密碼保護嗎？**

可以。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 會在不建立 Presentation 物件的情況下檢查檔案，其 [IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/ispasswordprotected/) 屬性會回報是否需要密碼。請參閱[Password-Protect Presentations](/slides/zh-hant/net/password-protected-presentation/)。

**兩個 NuGet 套件支援的格式不同嗎？**

不會。Aspose.Slides.NET 與 Aspose.Slides.NET6.CrossPlatform 具有相同的 LoadFormat 與 SaveFormat 值，且支援相同的匯入與渲染方法。它們的差異在於執行平台與平台需求；請參閱[Installation](/slides/zh-hant/net/installation/)。