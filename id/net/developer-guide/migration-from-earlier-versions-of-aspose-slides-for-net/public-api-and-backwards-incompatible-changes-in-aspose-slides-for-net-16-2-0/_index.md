---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 16.2.0
linktitle: Aspose.Slides untuk .NET 16.2.0
type: docs
weight: 230
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang merusak di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="primary" %}} 

Halaman ini menampilkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 16.2.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Properti UpdateDateTimeFields dan UpdateSlideNumberFields Telah Dihapus**
Properti UpdateDateTimeFields dan UpdateSlideNumberFields telah dihapus dari kelas Aspose.Slides.Presentation dan dari antarmuka Aspose.Slides.IPresentation.  
Properti Text pada kelas Aspose.Slides.TextFrame, Paragraph, Portion serta antarmuka Aspose.Slides.ITextFrame, IParagraph, IPortion mengembalikan teks dengan bidang "datetime" yang diperbarui.  
Selain itu, properti Presentation.DocumentProperties.CreatedTime, LastSavedTime, dan LastPrinted menjadi hanya-baca.  
#### **Enum Slides.Charts.CategoryAxisType Telah Dijadikan Publik**
Digunakan pada properti IAxis.CategoryAxisType dan Axis.CategoryAxisType untuk menentukan tipe sumbu kategori.  
- CategoryAxisType.Auto - tipe sumbu kategori akan ditentukan secara otomatis selama serialisasi (perilaku ini belum diimplementasikan).  
- CategoryAxisType.Text - tipe sumbu kategori adalah Teks.  
- CategoryAxisType.Date - tipe sumbu kategori adalah DateTime.  
#### **Ekstraksi Teks Cepat**
Metode statis baru GetPresentationText telah ditambahkan ke kelas Presentation. Ada dua overload untuk metode ini:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Argumen enum ExtractionMode menunjukkan mode untuk mengatur keluaran hasil teks dan dapat diatur ke nilai berikut:  
- Unarranged - teks mentah tanpa memperhatikan posisi pada slide  
- Arranged - teks ditempatkan dalam urutan yang sama seperti pada slide  

Mode Unarranged dapat digunakan ketika kecepatan sangat penting, ia lebih cepat daripada mode Arranged.  

PresentationText mewakili teks mentah yang diekstrak dari presentasi. Ia berisi properti SlidesText dari namespace Aspose.Slides.Util yang mengembalikan array objek ISlideText. Setiap objek mewakili teks pada slide yang bersangkutan. Objek ISlideText memiliki properti berikut:  
- ISlideText.Text - Teks pada bentuk-bentuk slide  
- ISlideText.MasterText - Teks pada bentuk-bentuk master page untuk slide ini  
- ISlideText.LayoutText - Teks pada bentuk-bentuk layout page untuk slide ini  
- ISlideText.NotesText - Teks pada bentuk-bentuk notes page untuk slide ini  

Ada juga kelas SlideText yang mengimplementasikan antarmuka ISlideText.  

API baru dapat digunakan seperti ini:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Antarmuka ILegacyDiagram dan Kelas LegacyDiagram Telah Ditambahkan**
Antarmuka Aspose.Slides.ILegacyDiagram dan kelas Aspose.Slides.LegacyDiagram telah ditambahkan untuk mewakili objek diagram legacy. Objek diagram legacy adalah format lama diagram dari PowerPoint 97-2003.  
Kelas baru menyediakan metode untuk mengonversi diagram legacy menjadi objek SmartArt yang dapat diedit modern atau menjadi GroupShape yang dapat diedit.  
#### **Anggota Enum Aspose.Slides.TextAlignment Baru Ditambahkan (JustifyLow)**
Anggota baru enum TextAlignment telah ditambahkan:  
- JustifyLow - justifikasi Kashida rendah.  
#### **Properti Baru untuk Aspose.Slides.IOleObjectFrame dan OleObjectFrame**
Properti baru telah ditambahkan ke antarmuka IOleObjectFrame dan kelas OleObjectFrame yang mengimplementasikan antarmuka ini. Properti-properti ini digunakan untuk memberikan informasi tentang objek yang ditanamkan ke dalam presentasi:  
- EmbeddedFileExtension - Mengembalikan ekstensi file untuk objek tertanam saat ini atau string kosong jika objek bukan tautan.  
- EmbeddedFileLabel - Mengembalikan nama file dari objek OLE yang tertanam.  
- EmbeddedFileName - Mengembalikan jalur objek OLE yang tertanam.  
#### **Properti Baru CategoryAxisType Telah Ditambahkan ke Kelas IAxis dan Axis**
Properti CategoryAxisType menentukan tipe sumbu kategori.

``` csharp

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

``` 
#### **Properti Baru ShowLabelAsDataCallout Telah Ditambahkan ke Kelas DataLabelFormat dan Antarmuka IDataLabelFormat**
Properti ShowLabelAsDataCallout menentukan apakah label data grafik yang ditentukan akan ditampilkan sebagai data callout atau sebagai label data.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **Properti DrawSlidesFrame Telah Ditambahkan ke PdfOptions dan XpsOptions**
Properti boolean DrawSlidesFrame telah ditambahkan ke antarmuka Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions serta ke kelas terkait Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Bingkai hitam di sekitar setiap slide akan digambar jika properti ini disetel ke 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```