---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.7.0
linktitle: Aspose.Slides untuk Java 15.7.0
type: docs
weight: 150
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang mematahkan di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 
Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) atau [dihapus](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for Java 15.7.0.
{{% /alert %}} 
## **Perubahan API Publik**
#### **Enum com.aspose.slides.ImagePixelFormat telah ditambahkan**
Enum com.aspose.slides.ImagePixelFormat telah ditambahkan untuk menentukan format piksel bagi gambar yang dihasilkan.
#### **metode com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() telah ditambahkan**
Metode ini mengembalikan warna otomatis untuk titik data berdasarkan indeks seri, indeks titik data, parentSeriesGroup, nilai isColorVaried, dan gaya bagan. Warna ini digunakan secara default jika fillType bernilai NotDefined.
#### **Metode getPixelFormat(), setPixelFormat(int) telah ditambahkan ke com.aspose.slides.ITiffOptions**
Metode getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) telah ditambahkan ke com.aspose.slides.ITiffOptions dan com.aspose.slides.TiffOptions untuk menentukan format piksel bagi gambar TIFF yang dihasilkan.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```