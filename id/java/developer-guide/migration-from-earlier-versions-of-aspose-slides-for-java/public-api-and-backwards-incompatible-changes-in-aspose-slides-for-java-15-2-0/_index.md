---
title: API Publik dan Perubahan yang Tidak Kompatibel ke Belakang di Aspose.Slides untuk Java 15.2.0
linktitle: Aspose.Slides untuk Java 15.2.0
type: docs
weight: 110
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
{{% alert color="primary" %}}

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) , setiap pembatasan baru, dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) lain yang diperkenalkan dengan API Aspose.Slides for Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}}

Terdapat masalah yang diketahui dengan beberapa bullet gambar dan objek WordArt yang akan diperbaiki dalam Aspose.Slides for Java 15.2.0.

{{% /alert %}}
## **Perubahan API Publik**
### **Metode addDataPointForDoughnutSeries telah ditambahkan**
Dua overload dari metode IChartDataPointCollection.addDataPointForDoughnutSeries() telah ditambahkan untuk menambahkan titik data ke dalam seri tipe Doughnut.
### **Kelas com.aspose.slides.SmartArtShape telah diwarisi dari kelas com.aspose.slides.GeometryShape**
Kelas com.aspose.slides.SmartArtShape telah diwarisi dari kelas com.aspose.slides.GeometryShape. Perubahan ini meningkatkan model objek Aspose.Slides dan menambahkan fitur baru ke kelas SmartArtShape.
### **Metode IGradientStopCollection.add(...) dan IGradientStopCollection.insert(...) telah diubah**
Tanda tangan IGradientStop add(float position, int presetColor) diganti dengan tanda tangan IGradientStop addPresetColor(float position, int presetColor).

Tanda tangan metode IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) diganti dengan tanda tangan IGradientStop addSchemeColor(float position, int schemeColor).

Tanda tangan metode IGradientStopCollection void insert(int index, float position, int presetColor) diganti dengan tanda tangan void insertPresetColor(int index, float position, int presetColor).

Tanda tangan metode IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) diganti dengan tanda tangan void insertSchemeColor(int index, float position, int schemeColor).
### **Metode java.awt.Color getAutomaticSeriesColor() telah ditambahkan ke com.aspose.slides.IChartSeries**
Metode getAutomaticSeriesColor() mengembalikan warna otomatis untuk seri berdasarkan indeks seri dan gaya diagram. Warna ini digunakan secara default jika FillType bernilai NotDefined.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Metode untuk menghapus titik data diagram dan kategori diagram berdasarkan indeksnya telah ditambahkan**
Metode IChartDataPointCollection.removeAt(int index) telah ditambahkan untuk menghapus titik data diagram berdasarkan indeksnya.
Metode IChartCategoryCollection.removeAt(int index) telah ditambahkan untuk menghapus kategori diagram berdasarkan indeksnya.
### **Nilai PptXPptY telah ditambahkan ke enumerasi com.aspose.slides.PropertyType**
Nilai PptXPptY telah ditambahkan ke enumerasi com.aspose.slides.PropertyType dalam rangka memperbaiki masalah serialisasi.