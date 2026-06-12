---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 14.8.0
linktitle: Aspose.Slides untuk Java 14.8.0
type: docs
weight: 70
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migrasi
- kode lama
- kode modern
- pendekatan lama
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda secara mulus."
---
{{% alert color="primary" %}} 

Halaman ini memuat semua [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) kelas, metode, properti, dan sebagainya, semua pembatasan baru, serta [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) yang diperkenalkan dengan API Aspose.Slides for Java 14.8.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **Menambahkan Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), dan setOverlap(byte) Mehtods**
Aspose.Slides.Charts.IChartSeries.getOverlap() menentukan seberapa banyak batang dan kolom harus tumpang tindih pada diagram 2D (dalam rentang -100 hingga 100). Metode ini tidak hanya berlaku untuk seri tertentu, melainkan untuk semua seri dalam grup seri induk – ini merupakan proyeksi properti grup yang sesuai.

- Gunakan metode IChartSeries.getParentSeriesGroup() untuk mengakses grup seri induk.
- Gunakan metode IChartSeriesGroup.getOverlap() dan setOverlap(byte) untuk mengelola nilai.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **Menambahkan Nilai Enum ShapeThumbnailBounds.Appearance**
Metode pembuatan thumbnail bentuk ini memungkinkan pengembang menghasilkan thumbnail bentuk dalam batas penampilannya. Metode ini mempertimbangkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Menambahkan Kelas VbaProject dan Antarmuka IVbaProject, Mengubah Metode Presentation.getVbaProject() dan setVbaProject(VbaProject)**
Fitur baru memungkinkan pengembang untuk membuat dan mengedit proyek VBA dalam sebuah presentasi.

``` java

 Presentation pres = new Presentation();

// Buat Proyek VBA baru

pres.setVbaProject(new VbaProject());

// Tambahkan modul kosong ke proyek VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Atur kode sumber modul

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// Buat referensi ke <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Buat referensi ke Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Tambahkan referensi ke proyek VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```