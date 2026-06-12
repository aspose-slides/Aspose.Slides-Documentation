---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk Java 16.1.0
linktitle: Aspose.Slides untuk Java 16.1.0
type: docs
weight: 200
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang memutuskan di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) atau [dihapus](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk Java 16.1.0.

{{% /alert %}} 
## **Perubahan API Publik**


#### **Metode getRotationAngle() dan setRotationAngle() telah ditambahkan ke antarmuka IChartTextBlockFormat dan ITextFrameFormat**  
Metode getRotationAngle() dan setRotationAngle() telah ditambahkan ke antarmuka com.aspose.slides.IChartTextBlockFormat dan com.aspose.slides.ITextFrameFormat. Mereka menyediakan akses ke rotasi khusus yang diterapkan pada teks di dalam kotak pembatas.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```