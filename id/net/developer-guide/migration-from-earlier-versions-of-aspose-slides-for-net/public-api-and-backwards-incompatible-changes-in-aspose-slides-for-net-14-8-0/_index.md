---
title: "Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.8.0"
linktitle: "Aspose.Slides untuk .NET 14.8.0"
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah kompatibilitas di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 
Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [added](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) atau [removed](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 14.8.0.
{{% /alert %}} 
## **Perubahan API Publik**
### **Properti yang Diubah**
#### **Menambahkan Antarmuka IVbaProject, Mengubah Properti Presentation.VbaProject**
Properti VbaProject pada kelas Presentation telah digantikan. Alih‑alih h3. Added Interfaces, Properties and Enumeration Options representasi byte mentah properti VbaProject dari proyek VBA, implementasi antarmuka IVbaProject yang baru telah ditambahkan.

Gunakan properti IVbaProject untuk mengelola proyek VBA yang disematkan dalam presentasi. Anda dapat menambahkan referensi proyek baru, mengedit modul yang ada, dan membuat yang baru.

Selain itu, Anda dapat membuat proyek VBA baru menggunakan kelas VbaProject yang mengimplementasikan antarmuka IVbaProject.

Contoh berikut menunjukkan pembuatan proyek VBA sederhana yang berisi satu modul dan menambahkan dua referensi yang diperlukan ke perpustakaan.

```csharp
    using (Presentation pres = new Presentation())
{
    // Membuat Proyek VBA baru
    pres.VbaProject = new VbaProject();

    // Menambahkan modul kosong ke proyek VBA
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Menetapkan kode sumber modul
    module.SourceCode =
        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Membuat referensi ke <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Membuat referensi ke Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Menambahkan referensi ke proyek VBA
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

Contoh ini menunjukkan cara menyalin proyek VBA dari presentasi yang ada ke presentasi baru.

```csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())
{
    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());
}
``` 
### **Antarmuka, Properti, dan Opsi Enumerasi yang Ditambahkan**
#### **Menambahkan Properti Aspose.Slides.Charts.IChartSeries.Overlap**
Properti Aspose.Slides.Charts.IChartSeries.Overlap menentukan seberapa banyak batang dan kolom harus tumpang tindih pada diagram 2D (berkisaran dari -100 hingga 100).

Properti ini tidak hanya berlaku untuk seri ini, tetapi untuk semua seri dalam grup seri induk – ini merupakan proyeksi dari properti grup yang sesuai. Karena itu properti ini bersifat baca‑saja.

- Gunakan properti ParentSeriesGroup untuk mengakses grup seri induk.
- Gunakan properti ParentSeriesGroup.Overlap yang dapat dibaca/ditulis untuk mengubah nilai.

```csharp

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

```csharp



using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
   IChartSeriesCollection series = chart.ChartData.Series;
   series[0].ParentSeriesGroup.Overlap = -30;
}
``` 
#### **Menambahkan Nilai Enum ShapeThumbnailBounds.Appearance**
Metode pembuatan thumbnail bentuk ini memungkinkan Anda menghasilkan thumbnail bentuk dalam batas penampilannya. Metode ini memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide.

```csharp



using (Presentation p = new Presentation("Presentation.pptx"))
{
    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);
    st.Save("ShapeThumbnail.png", ImageFormat.Png);
}
```