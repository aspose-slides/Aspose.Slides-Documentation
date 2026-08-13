---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.11.0
linktitle: Aspose.Slides untuk Java 15.11.0
type: docs
weight: 190
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
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
Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [added](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) atau [removed](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for Java 15.11.0.
{{% /alert %}} 
## **Public API Changes**
#### **Metode usang pada kelas com.aspose.slides.DataLabelCollection telah dihapus**
Metode usang pada kelas com.aspose.slides.DataLabelCollection telah dihapus:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)

#### **Metode baru getFirstSlideNumber() dan setFirstSlideNumber() telah ditambahkan ke kelas Presentation**
Metode baru getFirstSlideNumber() dan setFirstSlideNumber() memungkinkan untuk mendapatkan atau mengatur nomor slide pertama dalam sebuah presentasi.
Saat nilai nomor slide pertama baru ditentukan, semua nomor slide akan dihitung ulang.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```