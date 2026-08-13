---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.2.0
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
description: "Tinjau pembaruan API publik dan perubahan yang tidak kompatibel di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) kelas, metode, properti, dan sebagainya, serta batasan baru dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) lain yang diperkenalkan dengan API Aspose.Slides for Java 15.2.0.

{{% /alert %}} {{% alert color="info" %}} 

Terdapat masalah yang diketahui dengan beberapa bullet gambar dan objek WordArt yang akan diperbaiki di Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **metode addDataPointForDoughnutSeries telah ditambahkan**
Dua overload dari metode IChartDataPointCollection.addDataPointForDoughnutSeries() telah ditambahkan untuk menambahkan titik data ke dalam seri tipe Doughnut.
### **kelas com.aspose.slides.SmartArtShape telah mewarisi dari kelas com.aspose.slides.GeometryShape**
Kelas com.aspose.slides.SmartArtShape telah mewarisi dari kelas com.aspose.slides.GeometryShape. Perubahan ini meningkatkan model objek Aspose.Slides dan menambahkan fitur baru ke kelas SmartArtShape.
### **metode IGradientStopCollection.add(...) dan IGradientStopCollection.insert(...) telah diubah**
Tanda tangan IGradientStop add(float position, int presetColor) digantikan dengan tanda tangan IGradientStop addPresetColor(float position, int presetColor).

Tanda tangan metode IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) digantikan dengan tanda tangan IGradientStop addSchemeColor(float position, int schemeColor).

Tanda tangan metode IGradientStopCollection void insert(int index, float position, int presetColor) digantikan dengan tanda tangan void insertPresetColor(int index, float position, int presetColor).

Tanda tangan metode IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) digantikan dengan tanda tangan void insertSchemeColor(int index, float position, int schemeColor).
### **metode java.awt.Color getAutomaticSeriesColor() telah ditambahkan ke com.aspose.slides.IChartSeries**
Metode getAutomaticSeriesColor() mengembalikan warna otomatis untuk seri berdasarkan indeks seri dan gaya chart. Warna ini digunakan secara default jika FillType bernilai NotDefined.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Metode untuk menghapus titik data chart dan kategori chart berdasarkan indeksnya telah ditambahkan**
Metode IChartDataPointCollection.removeAt(int index) telah ditambahkan untuk menghapus titik data chart berdasarkan indeksnya.
Metode IChartCategoryCollection.removeAt(int index) telah ditambahkan untuk menghapus kategori chart berdasarkan indeksnya.
### **nilai PptXPptY telah ditambahkan ke enumerasi com.aspose.slides.PropertyType**
Nilai PptXPptY telah ditambahkan ke enumerasi com.aspose.slides.PropertyType dalam rangka memperbaiki masalah serialisasi.