---
title: Mengonversi Presentasi PowerPoint ke SWF Flash dalam JavaScript
linktitle: PowerPoint ke SWF
type: docs
weight: 80
url: /id/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- mengonversi PPTX
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonversi PowerPoint (PPT/PPTX) menjadi SWF Flash dengan Aspose.Slides untuk Node.js. Contoh kode langkah demi langkah, output cepat berkualitas, tanpa otomasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke SWF dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyimpan presentasi sebagai file SWF dengan metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) dan cara mengkonfigurasi ekspor dengan [SwfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/swfoptions/), termasuk pengaturan penampil serta tata letak catatan atau komentar.

## **Mengonversi PPT(X) ke SWF**
Metode [save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) yang dihadirkan oleh kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dapat digunakan untuk mengonversi seluruh presentasi menjadi dokumen **SWF**. Contoh berikut menunjukkan cara mengonversi presentasi menjadi dokumen **SWF** dengan menggunakan opsi yang disediakan oleh kelas [**SWFOptions**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SwfOptions). Anda juga dapat menyertakan komentar dalam SWF yang dihasilkan menggunakan [**SWFOptions**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SwfOptions) dan kelas [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Menyimpan presentasi
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menyertakan slide tersembunyi dalam SWF?**

Ya. Gunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) di [SwfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/swfoptions/). Secara default, slide tersembunyi tidak diekspor.

**Bagaimana cara mengontrol kompresi dan ukuran akhir SWF?**

Gunakan metode [setCompressed](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/swfoptions/setcompressed/) dan [setJpegQuality](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/swfoptions/setjpegquality/) untuk menyeimbangkan ukuran file dan ketelitian gambar.

**Untuk apa 'setViewerIncluded', dan kapan saya harus menggunakannya?**

[setViewerIncluded](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) menambahkan UI pemutar tersemat (kontrol navigasi, panel, pencarian). Gunakan jika Anda berencana menggunakan pemutar sendiri atau memerlukan frame SWF bersih tanpa UI.

**Apa yang terjadi jika font sumber tidak ada pada mesin ekspor?**

Aspose.Slides akan mengganti font yang Anda tentukan melalui [setDefaultRegularFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) di [SwfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/swfoptions/) untuk menghindari fallback yang tidak diinginkan.