---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.8.0
linktitle: Aspose.Slides untuk .NET 14.8.0
type: docs
weight: 100
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 14.8.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **Properti yang Diubah**
#### **Menambahkan Antarmuka IVbaProject, Mengubah Properti Presentation.VbaProject**
Properti VbaProject pada kelas Presentation telah diganti. Alih‑alih representasi byte mentah proyek VBA pada properti VbaProject, implementasi antarmuka IVbaProject yang baru telah ditambahkan.

Gunakan properti IVbaProject untuk mengelola proyek VBA yang tertanam dalam presentasi. Anda dapat menambahkan referensi proyek baru, mengedit modul yang ada, dan membuat modul baru.

Selain itu, Anda dapat membuat proyek VBA baru menggunakan kelas VbaProject yang mengimplementasikan antarmuka IVbaProject.

Contoh berikut menunjukkan pembuatan proyek VBA sederhana yang berisi satu modul dan menambahkan dua referensi yang diperlukan ke perpustakaan.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Buat proyek VBA baru

    pres.VbaProject = new VbaProject();

    // Tambahkan modul kosong ke proyek VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Atur kode sumber modul

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Buat referensi ke <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Buat referensi ke Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Tambahkan referensi ke proyek VBA

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

Contoh ini menunjukkan cara menyalin proyek VBA dari presentasi yang ada ke presentasi baru.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Menambahkan Antarmuka, Properti, dan Opsi Enumerasi**
#### **Menambahkan Properti Aspose.Slides.Charts.IChartSeries.Overlap**
Properti Aspose.Slides.Charts.IChartSeries.Overlap menentukan seberapa banyak batang dan kolom saling tumpang tindih pada diagram 2D (dengan rentang dari -100 hingga 100).

Properti ini bukan hanya untuk seri ini, tetapi untuk semua seri dalam grup seri induk – merupakan proyeksi dari properti grup yang sesuai. Oleh karena itu properti ini bersifat read‑only.

- Gunakan properti ParentSeriesGroup untuk mengakses grup seri induk.
- Gunakan properti ParentSeriesGroup.Overlap yang dapat dibaca/ditulis untuk mengubah nilai.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Menambahkan Properti Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Properti Aspose.Slides.Charts.IChartSeriesGroup.Overlap menentukan seberapa banyak batang dan kolom harus tumpang tindih pada diagram 2D (dari -100 hingga 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Menambahkan Nilai Enum ShapeThumbnailBounds.Appearance**
Metode pembuatan thumbnail bentuk ini memungkinkan Anda menghasilkan thumbnail bentuk dalam batas penampilannya. Metode ini memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```