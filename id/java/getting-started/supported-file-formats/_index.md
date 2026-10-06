---
title: Format Berkas yang Didukung
type: docs
weight: 106
url: /id/java/supported-file-formats/
keywords:
- format berkas yang didukung
- muat presentasi
- impor PDF
- impor HTML
- simpan presentasi
- render slide
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
description: "Lihat format berkas apa yang dapat dimuat, diimpor, disimpan, dan dirender oleh Aspose.Slides for Java, serta API mana yang membaca atau menulis masing-masing."
---
## **Ikhtisar**

Aspose.Slides for Java membuka dan menyimpan presentasi PowerPoint serta OpenDocument. Ia juga mengimpor konten PDF dan HTML ke dalam slide, menyimpan presentasi ke format dokumen, web, dan gambar, serta merender slide dan bentuk individual sebagai gambar. Artikel ini mencantumkan setiap format yang didukung dan menyebutkan API yang membacanya atau menuliskannya.

Untuk ikhtisar fitur penyuntingan, lihat [Features Overview](/slides/id/java/features-overview/).

## **Versi Microsoft PowerPoint yang Didukung**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint untuk Mac
- PowerPoint untuk Microsoft 365 (sebelumnya Office 365)

{{% alert color="info" title="Note" %}}

Presentasi yang disimpan oleh PowerPoint 95 dan versi sebelumnya tidak dapat dibuka. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) mengenali file PowerPoint 95 dan melaporkan `LoadFormat.Ppt95`, tetapi konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) melempar [PptUnsupportedFormatException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptunsupportedformatexception/) untuk file tersebut.

{{% /alert %}}

## **Format Berkas yang Didukung**

Tabel ini menggunakan empat operasi:

- **Muat**: konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) membuka berkas sebagai presentasi yang dapat diedit.
- **Impor**: metode [SlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidecollection/) membuat slide dari konten berkas dan menambahkannya ke presentasi yang sudah ada. Konstruktor Presentation tidak mengonversi berkas-berkas ini menjadi slide.
- **Simpan**: [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) menulis presentasi ke berkas atau aliran. Setiap format kecuali XAML dipilih dengan nilai [SaveFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/).
- **Render**: metode perenderan menggambar slide atau bentuk sebagai gambar. Format yang hanya dirender bukanlah nilai SaveFormat.

|**Format**|**Deskripsi**|**Muat / Impor**|**Simpan / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentasi PowerPoint 97-2003|Muat|Simpan|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Templat PowerPoint 97-2003|Muat|Simpan|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Slide Show PowerPoint 97-2003|Muat|Simpan|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentasi PowerPoint|Muat|Simpan|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Templat PowerPoint|Muat|Simpan|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Slide Show PowerPoint|Muat|Simpan|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentasi PowerPoint yang Mendukung Makro|Muat|Simpan|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Templat PowerPoint yang Mendukung Makro|Muat|Simpan|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Slide Show PowerPoint yang Mendukung Makro|Muat|Simpan|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentasi OpenDocument|Muat|Simpan|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Presentasi Flat XML OpenDocument|Muat|Simpan|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Templat Presentasi OpenDocument|Muat|Simpan|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Presentasi XML PowerPoint|Muat|Simpan|`SaveFormat.Xml`; berkas yang dimuat melaporkan `SourceFormat.Xml` (tidak ada nilai `LoadFormat` )|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Impor|Simpan|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Impor|Simpan|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Simpan|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Simpan, Render|`SaveFormat.Tiff` (satu halaman per slide); `ImageFormat.Tiff` (satu slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Simpan, Render|`SaveFormat.Gif` (animasi, semua slide); `ImageFormat.Gif` (satu slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Simpan|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Simpan|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Simpan|`Presentation.save(IXamlOptions)`, satu berkas XAML per slide; bukan nilai `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Gambar JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Gambar Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Muat dan Impor**

- **Muat:** Berikan jalur berkas atau aliran ke konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Format dideteksi dari konten; [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/) menyediakan pengaturan seperti kata sandi. Untuk memeriksa sebuah berkas sebelum membukanya, panggil [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), yang melaporkan nilai [LoadFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadformat/). Ia melaporkan `LoadFormat.Unknown` untuk PowerPoint XML, tetapi konstruktor tetap membuka berkas tersebut, dan [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSourceFormat--) kemudian mengembalikan `SourceFormat.Xml`. Lihat [Open Presentations](/slides/id/java/open-presentation/) dan [Determine the Original Presentation Format](/slides/id/java/detect-presentation-source-format/).
- **Impor:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) menambahkan satu slide per halaman PDF ke akhir presentasi. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) menambahkan slide yang dibuat dari HTML, dan [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) menyisipkannya pada posisi tertentu. Konstruktor Presentation tidak mengimpor: ia melempar [PptUnsupportedFormatException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptunsupportedformatexception/) untuk berkas PDF dan tidak mengonversi markup HTML menjadi konten slide. Lihat [Import Presentations from PDF or HTML](/slides/id/java/import-presentation/).

## **Simpan dan Render**

- **Simpan:** [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) menulis presentasi dengan nilai [SaveFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/). Overload yang juga menerima objek opsi mengontrol output, misalnya [PdfOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/tiffoptions/), dan [GifOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/gifoptions/). Overload yang menerima array posisi slide, dimulai dari 1, menulis hanya slide‑slide tersebut; mereka menerima PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, dan Markdown, tetapi tidak format presentasi atau PowerPoint XML. XAML memiliki overload tersendiri, [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), yang menerima [IXamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloptions/). Lihat [Save Presentations](/slides/id/java/save-presentation/), [Convert Presentations](/slides/id/java/convert-presentation/), dan [Export Presentations to XAML](/slides/id/java/export-to-xaml/).
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#getImage-float-float-) dan [Shape.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage--) mengembalikan sebuah [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/), dan [IImage.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/#save-java.lang.String-int-) menuliskannya sebagai PNG, JPEG, BMP, GIF, atau TIFF, dipilih dengan nilai [ImageFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) merender semua slide atau slide terpilih sekaligus. [Slide.writeAsSvg](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) dan [Shape.writeAsSvg](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) menulis SVG, dan [Slide.writeAsEmf](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) menulis EMF. Lihat [Convert Presentation Slides to Images](/slides/id/java/convert-slide/) dan [Render Presentation Slides as SVG Images](/slides/id/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat juga memiliki nilai `Emf`, `Wmf`, `Icon`, `Exif`, dan `MemoryBmp`, tetapi IImage.save tidak menghasilkan format tersebut: berkas yang ditulis berisi data PNG. Untuk mendapatkan gambar EMF dari slide, gunakan Slide.writeAsEmf.

{{% /alert %}}

## **FAQ**

**Apakah saya dapat mengonversi presentasi PPT ke PPTX atau ODP?**

Ya. Buka berkas PPT dengan konstruktor Presentation dan simpan dengan `SaveFormat.Pptx` atau `SaveFormat.Odp`. Lihat [Convert PPT to PPTX](/slides/id/java/convert-ppt-to-pptx/).

**Apakah saya dapat membuka berkas PDF atau HTML sebagai presentasi?**

Tidak. Konstruktor Presentation melempar PptUnsupportedFormatException untuk berkas PDF dan tidak mengonversi markup HTML menjadi slide. Buat atau buka presentasi, impor halaman PDF atau konten HTML ke dalamnya dengan metode koleksi slide yang dijelaskan di atas, lalu simpan dalam format apa pun yang didukung.

**Apakah saya dapat memuat gambar PNG atau SVG yang diekspor sebagai presentasi yang dapat diedit?**

Tidak. Output gambar hanya merekam tampilan slide, bukan teks, bentuk, atau diagramnya. Simpan presentasi sumber jika Anda perlu mengeditnya nanti.

**Apakah saya dapat menyimpan dokumen PDF/A atau PDF/UA?**

Ya. Berikan nilai [PdfCompliance](https://reference.aspose.com/slides/id/java/com.aspose.slides/pdfcompliance/) ke [PdfOptions.setCompliance](https://reference.aspose.com/slides/id/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, atau PDF/UA.

**Apakah saya dapat memeriksa apakah sebuah berkas dilindungi kata sandi sebelum membukanya?**

Ya. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) memeriksa berkas tanpa membuat objek Presentation, dan [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) melaporkan apakah kata sandi diperlukan. Lihat [Password-Protect Presentations](/slides/id/java/password-protected-presentation/).