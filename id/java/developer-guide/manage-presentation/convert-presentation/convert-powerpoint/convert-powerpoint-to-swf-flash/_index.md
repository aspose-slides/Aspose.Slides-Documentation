---
title: Mengonversi Presentasi PowerPoint ke SWF Flash dalam Java
linktitle: PowerPoint ke SWF
type: docs
weight: 80
url: /id/java/convert-powerpoint-to-swf-flash/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke SWF
- presentasi ke SWF
- slide ke SWF
- PPT ke SWF
- PPTX ke SWF
- PowerPoint ke Flash
- presentasi ke Flash
- slide ke Flash
- PPT ke Flash
- PPTX ke Flash
- simpan PPT sebagai SWF
- simpan PPTX sebagai SWF
- ekspor PPT ke SWF
- ekspor PPTX ke SWF
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Mengonversi PowerPoint (PPT/PPTX) ke SWF Flash dalam Java dengan Aspose.Slides. Contoh kode langkah demi langkah, output berkualitas tinggi cepat, tanpa otomatisasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke SWF dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyimpan sebuah presentasi sebagai file SWF dengan metode [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) dan cara mengonfigurasi ekspor dengan [SwfOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/swfoptions/), termasuk pengaturan penampil serta tata letak catatan atau komentar.

## **Mengonversi Presentasi ke Flash**

Metode [save](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dapat digunakan untuk mengonversi seluruh presentasi menjadi dokumen **SWF**. Contoh berikut menunjukkan cara mengonversi presentasi menjadi dokumen **SWF** dengan menggunakan opsi yang disediakan oleh kelas [**SWFOptions**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SwfOptions). Anda juga dapat menyertakan komentar dalam SWF yang dihasilkan menggunakan kelas [**ISWFOptions**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISwfOptions) dan antarmuka [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/id/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Menyimpan presentasi
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menyertakan slide tersembunyi dalam SWF?**

Ya. Aktifkan slide tersembunyi menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) pada [SwfOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/swfoptions/). Secara default, slide tersembunyi tidak diekspor.

**Bagaimana saya dapat mengontrol kompresi dan ukuran akhir SWF?**

Gunakan metode [setCompressed](https://reference.aspose.com/slides/id/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) dan [atur kualitas JPEG](https://reference.aspose.com/slides/id/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) untuk menyeimbangkan ukuran file dan kualitas gambar.

**Apa fungsi 'setViewerIncluded', dan kapan saya harus menonaktifkannya?**

[setViewerIncluded](https://reference.aspose.com/slides/id/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) menambahkan UI pemutar tersemat (kontrol navigasi, panel, pencarian). Nonaktifkan bila Anda berencana menggunakan pemutar sendiri atau memerlukan kerangka SWF polos tanpa UI.

**Apa yang terjadi jika font sumber tidak tersedia pada mesin ekspor?**

Aspose.Slides akan menggantikan font yang Anda tentukan melalui [setDefaultRegularFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) di [SwfOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/swfoptions/) untuk menghindari fallback yang tidak diinginkan.