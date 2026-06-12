---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.8.0
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
description: "Tinjau pembaruan API publik dan perubahan signifikan di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}}

Halaman ini mencantumkan semua [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) atau [dihapus](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) kelas, metode, properti, dan seterusnya, serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for Java 15.8.0.

{{% /alert %}}
## **Perubahan API Publik**
#### **Metode getDoughnutHoleSize(), setDoughnutHoleSize(byte) telah ditambahkan ke IChartSeries dan ChartSeries**
Menentukan ukuran lubang pada bagan donat.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```