---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 14.8.0
linktitle: Aspose.Slides untuk Java 14.8.0
type: docs
weight: 70
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 
Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/), setiap pembatasan baru, dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) yang diperkenalkan dengan API Aspose.Slides untuk Java 14.8.0.
{{% /alert %}} 
## **Perubahan API Publik**
### **Menambahkan Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap(), dan setOverlap(byte) Metode**
Aspose.Slides.Charts.IChartSeries.getOverlap() menentukan seberapa banyak batang dan kolom harus saling tumpang tindih pada diagram 2D (dalam rentang -100 hingga 100).
Metode ini tidak hanya berlaku untuk seri tertentu, tetapi untuk semua seri dalam grup seri induk – ini merupakan proyeksi properti grup yang sesuai.

- Gunakan metode IChartSeries.getParentSeriesGroup() untuk mengakses grup seri induk.
- Gunakan metode IChartSeriesGroup.getOverlap() dan setOverlap(byte) untuk mengelola nilai.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **Menambahkan Nilai Enum ShapeThumbnailBounds.Appearance**
Metode pembuatan thumbnail bentuk ini memungkinkan pengembang menghasilkan thumbnail bentuk dalam batas penampilannya. Metode ini memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **Menambahkan Kelas VbaProject dan Interface IVbaProject, Mengubah Metode Presentation.getVbaProject() dan setVbaProject(VbaProject)**
Fitur baru memungkinkan pengembang membuat dan mengedit proyek VBA dalam sebuah presentasi.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// Buat Proyek VBA baru

pres.setVbaProject(new VbaProject());

// Tambahkan modul kosong ke proyek VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// Setel kode sumber modul

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

pres.save("test.pptm", SaveFormat.Pptm);
```