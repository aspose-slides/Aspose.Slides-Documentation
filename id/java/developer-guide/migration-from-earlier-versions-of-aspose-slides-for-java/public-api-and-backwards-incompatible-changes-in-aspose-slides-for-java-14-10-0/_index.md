---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 14.10.0
linktitle: Aspose.Slides untuk Java 14.10.0
type: docs
weight: 90
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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
Halaman ini mencantumkan semua kelas, metode, properti, dan lain-lain yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), serta batasan baru dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) yang diperkenalkan dengan API Aspose.Slides for Java 14.10.0.
{{% /alert %}} 
## **Perubahan API Publik**
### **Metode com.aspose.slides.FieldType.getFooter() telah ditambahkan**
Metode getFooter() mengembalikan tipe field footer. Metode ini ditambahkan untuk mengimplementasikan kemampuan membuat field tipe ini dan untuk serialisasi presentasi yang valid.
### **Elemen com.aspose.slides.ShapeElementFillSource.Own telah dihapus**
Elemen ShapeElementFillSource.Own telah dihapus karena duplikat. Gunakan ShapeElementFillSource.Shape alih-alih ShapeElementFillSource.Own.
### **Metode untuk menghapus data poin diagram dan kategori telah ditambahkan**
**Metode berikut, yang memungkinkan menghapus data poin diagram dari koleksi data poin diagram, telah ditambahkan:**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**Metode berikut, yang memungkinkan menghapus kategori diagram dari koleksi yang menyertakannya, telah ditambahkan:**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // hapus dengan ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // hapus dengan ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // hapus dengan ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Metode Aspose.Slides.ParagraphFormat yang usang telah dihapus**
Metode getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() dan metode set yang bersesuaian telah dihapus. Mereka telah ditandai usang sejak lama.
### **Konstruktor yang tidak berguna dan usang telah dihapus**
Konstruktor berikut telah dihapus:

com.aspose.slides.AlphaBiLevel(float)  
com.aspose.slides.AlphaModulateFixed(float)  
com.aspose.slides.AlphaReplace(float)  
com.aspose.slides.BiLevel(float)  
com.aspose.slides.Blur(double, boolean)  
com.aspose.slides.HSL(float, float, float)  
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)  
com.aspose.slides.Luminance(float, float)  
com.aspose.slides.Tint(float, float)  
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)  
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)  
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)