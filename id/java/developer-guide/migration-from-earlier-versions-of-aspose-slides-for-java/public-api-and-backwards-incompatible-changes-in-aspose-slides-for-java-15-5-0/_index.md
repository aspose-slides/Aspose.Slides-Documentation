---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.5.0
linktitle: Aspose.Slides untuk Java 15.5.0
type: docs
weight: 130
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah kompatibilitas di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 

Halaman ini menampilkan semua [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) kelas, metode, properti, dan sebagainya, semua pembatasan baru, serta [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) yang diperkenalkan dengan API Aspose.Slides untuk Java 15.5.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **Kelas CommonSlideViewProperties dan antarmuka ICommonSlideViewProperties telah ditambahkan**
Kelas com.aspose.slides.CommonSlideViewProperties (dan antarmukanya com.aspose.slides.ICommonSlideViewProperties) mewakili properti tampilan slide umum (saat ini opsi skala tampilan).
### **Metode IAxis.getLabelOffset() dan setLabelOffset(int) telah ditambahkan**
Metode IAxis.getLabelOffset() dan setLabelOffset(int) memungkinkan untuk memperoleh dan menentukan jarak label dari sumbu. Diterapkan pada sumbu kategori atau tanggal.
### **Metode IChartTextBlockFormat.getAutofitType() dan setAutofitType(byte) telah ditambahkan**
Metode getAutofitType() dan setAutofitType(/**TextAutofitType**/byte) telah ditambahkan ke antarmuka com.aspose.slides.IChartTextBlockFormat. Mengubah nilai ini dapat memberikan pengaruh tertentu hanya untuk bagian chart berikut: DataLabel dan DataLabelFormat (dukungan penuh di PowerPoint 2013; di PowerPoint 2007 tidak ada efek pada rendering).
### **Metode IChartTextBlockFormat.getWrapText() dan setWrapText(byte) telah ditambahkan**
Metode getWrapText() dan setWrapText(/**NullableBool**/byte) telah ditambahkan ke antarmuka com.aspose.slides.IChartTextBlockFormat. Mengubah nilai ini dapat memberikan pengaruh tertentu hanya untuk bagian chart berikut: DataLabel dan DataLabelFormat (dukungan penuh di PowerPoint 2007/2013).
### **Metode untuk mengelola margin telah ditambahkan ke IChartTextBlockFormat**
Metode getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() dan setMarginBottom(double) telah ditambahkan ke antarmuka com.aspose.slides.IChartTextBlockFormat. Mengubah nilai-nilai ini dapat memberikan pengaruh tertentu hanya untuk bagian chart berikut: DataLabel dan DataLabelFormat (dukungan penuh di PowerPoint 2013; di PowerPoint 2007 tidak ada efek pada rendering).
### **Metode ViewProperties.getNotesViewProperties() telah ditambahkan**
Properti com.aspose.slides.ViewProperties.getNotesViewProperties() telah ditambahkan. Properti ini memperoleh properti tampilan umum yang terkait dengan mode tampilan catatan.
### **Metode ViewProperties.getSlideViewProperties() telah ditambahkan**
Metode com.aspose.slides.ViewProperties.getSlideViewProperties() telah ditambahkan. Metode ini memperoleh properti tampilan umum yang terkait dengan mode tampilan slide.