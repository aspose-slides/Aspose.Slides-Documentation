---
title: Format File yang Didukung
type: docs
weight: 96
url: /id/net/supported-file-formats/
keywords:
- format file yang didukung
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
- .NET
- C#
- Aspose.Slides
description: "Lihat format file mana yang dapat dimuat, diimpor, disimpan, dan dirender oleh Aspose.Slides untuk .NET, serta API mana yang membaca atau menulis masing‑masing."
---
## **Gambaran Umum**

Aspose.Slides untuk .NET membuka dan menyimpan presentasi PowerPoint serta OpenDocument. Ia juga mengimpor konten PDF dan HTML ke dalam slide, menyimpan presentasi ke format dokumen, web, dan gambar, serta merender slide serta bentuk secara individual sebagai gambar. Artikel ini mencantumkan setiap format yang didukung serta nama API yang membacanya atau menuliskannya.

Kedua paket NuGet, Aspose.Slides.NET dan Aspose.Slides.NET6.CrossPlatform, mendukung format yang sama; lihat [Installation](/slides/id/net/installation/) untuk memilih di antara keduanya. Untuk gambaran umum fitur penyuntingan, lihat [Features Overview](/slides/id/net/features-overview/).

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
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Catatan" %}}

Presentasi yang disimpan oleh PowerPoint 95 dan versi sebelumnya tidak dapat dibuka. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) mengenali berkas PowerPoint 95 dan melaporkan `LoadFormat.Ppt95`, tetapi konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) melempar [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) untuknya.

{{% /alert %}}

## **Format File yang Didukung**

Tabel ini menggunakan empat operasi:

- **Load**: konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) membuka berkas sebagai presentasi yang dapat diedit.
- **Import**: metode [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) membuat slide dari konten berkas dan menambahkannya ke presentasi yang ada. Konstruktor Presentation tidak memuat berkas-berkas ini sebagai presentasi.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) menulis presentasi ke berkas atau aliran. Setiap format kecuali XAML dipilih dengan nilai [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
- **Render**: metode perenderan menggambar slide atau bentuk sebagai gambar. Format yang hanya dapat dirender bukanlah nilai SaveFormat.

|**Format**|**Deskripsi**|**Muat / Impor**|**Simpan / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentasi PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Template PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Slide Show PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentasi PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Template PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Slide Show PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Presentasi PowerPoint dengan Makro|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Template PowerPoint dengan Makro|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Slide Show PowerPoint dengan Makro|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Presentasi OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Presentasi Flat XML OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Template Presentasi OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Presentasi XML PowerPoint|Load|Save|`SaveFormat.Xml`; berkas yang dimuat melaporkan `SourceFormat.Xml` (tidak ada nilai `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Format Dokumen Portabel|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Bahasa Markah Hiperteks|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Spesifikasi Kertas XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (satu slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animasi, semua slide); `ImageFormat.Gif` (satu slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.Save(IXamlOptions)`, satu berkas XAML per slide; bukan nilai `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Gambar JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Gambar Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Muat dan Impor**

- **Muat:** Berikan jalur berkas atau aliran ke konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Format dideteksi dari konten; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) menyediakan pengaturan seperti kata sandi. Untuk memeriksa berkas sebelum membukanya, panggil [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), yang melaporkan nilai [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). Ia melaporkan `LoadFormat.Unknown` untuk PowerPoint XML, tetapi konstruktor tetap membuka berkas tersebut, dan [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) kemudian mengembalikan `SourceFormat.Xml`. Lihat [Open Presentations](/slides/id/net/open-presentation/) dan [Determine the Original Presentation Format](/slides/id/net/detect-presentation-source-format/).
- **Impor:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) menambahkan satu slide per halaman PDF ke akhir presentasi. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) menambah slide yang dibuat dari HTML, dan [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) menyisipkannya pada posisi tertentu. Konstruktor Presentation tidak mengimpor: ia melempar [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) untuk berkas PDF dan tidak mengonversi markup HTML menjadi konten slide. Lihat [Import Presentations from PDF or HTML](/slides/id/net/import-presentation/).

## **Simpan dan Render**

- **Simpan:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) menulis presentasi dalam format nilai [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Overload yang juga menerima objek opsi mengontrol output, misalnya [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), dan [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Overload yang menerima array posisi slide, dimulai dari 1, menulis hanya slide‑slide tersebut; mereka menerima PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, dan Markdown, tetapi tidak format presentasi atau PowerPoint XML. XAML memiliki overload tersendiri yang menerima [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Lihat [Save Presentations](/slides/id/net/save-presentation/), [Convert Presentations](/slides/id/net/convert-presentation/), dan [Export Presentations to XAML](/slides/id/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) dan [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) mengembalikan sebuah [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), dan [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) menulisnya sebagai PNG, JPEG, BMP, GIF, atau TIFF, dipilih lewat nilai [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) merender semua slide atau slide terpilih sekaligus. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) dan [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) menulis SVG, dan [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) menulis EMF. Lihat [Convert Presentation Slides to Images](/slides/id/net/convert-slide/) dan [Render a Slide as an SVG Image](/slides/id/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Peringatan" %}}

ImageFormat juga memiliki nilai `Emf`, `Wmf`, `Icon`, `Exif`, dan `MemoryBmp`, tetapi IImage.Save tidak menghasilkan format‑format tersebut: berkas yang ditulisnya berisi data PNG. Untuk mendapatkan gambar EMF dari slide, gunakan Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Apakah saya dapat mengonversi presentasi PPT ke PPTX atau ODP?**

Ya. Buka berkas PPT dengan konstruktor Presentation dan simpan dengan `SaveFormat.Pptx` atau `SaveFormat.Odp`. Lihat [Convert PPT to PPTX](/slides/id/net/convert-ppt-to-pptx/).

**Apakah saya dapat membuka berkas PDF atau HTML sebagai presentasi?**

Tidak. Buat atau buka presentasi, impor halaman PDF atau konten HTML ke dalamnya dengan metode koleksi slide yang dijelaskan di atas, lalu simpan dalam format apa pun yang didukung.

**Apakah saya dapat memuat gambar PNG atau SVG yang diekspor sebagai presentasi yang dapat diedit?**

Tidak. Output gambar merekam tampilan slide, bukan teks, bentuk, atau diagramnya. Simpan presentasi sumber jika Anda perlu mengeditnya kemudian.

**Apakah saya dapat menyimpan dokumen PDF/A atau PDF/UA?**

Ya. Atur [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) ke nilai [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, atau PDF/UA.

**Apakah saya dapat memeriksa apakah berkas dilindungi kata sandi sebelum membukanya?**

Ya. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) memeriksa berkas tanpa membuat objek Presentation, dan properti [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) melaporkan apakah kata sandi diperlukan. Lihat [Password-Protect Presentations](/slides/id/net/password-protected-presentation/).

**Apakah dua paket NuGet mendukung format yang berbeda?**

Tidak. Aspose.Slides.NET dan Aspose.Slides.NET6.CrossPlatform memiliki nilai LoadFormat dan SaveFormat serta metode impor dan perenderan yang sama. Mereka berbeda pada platform tempat mereka berjalan dan kebutuhan platform tersebut; lihat [Installation](/slides/id/net/installation/).