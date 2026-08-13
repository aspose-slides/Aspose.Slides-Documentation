---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.8.0
linktitle: Aspose.Slides untuk Java 15.8.0
type: docs
weight: 160
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
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
{{% alert color="info" %}} 
Halaman ini menampilkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) atau [dihapus](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for Java 15.8.0.
{{% /alert %}} 
## **Perubahan API Publik**
#### **Metode getDoughnutHoleSize(), setDoughnutHoleSize(byte) telah ditambahkan ke IChartSeries dan ChartSeries**
Menentukan ukuran lubang pada diagram donat.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```