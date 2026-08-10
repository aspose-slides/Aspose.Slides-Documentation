---
title: Render Slide Presentasi sebagai Gambar SVG di Android
linktitle: Slide ke SVG
type: docs
weight: 50
url: /id/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint ke SVG
- presentasi ke SVG
- slide ke SVG
- PPT ke SVG
- PPTX ke SVG
- opsi ekspor SVG
- SVG interaktif
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Ekspor slide PowerPoint sebagai gambar SVG di Android dan kendalikan font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang skalabel dan bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, dan pemrosesan pasca otomatis. Aspose.Slides untuk Android via Java mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Mengekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/), pilih sebuah slide, dan tulis ke aliran dengan [ISlide.writeAsSvg](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Contoh berikut mengekspor setiap slide dalam sebuah presentasi sebagai file SVG terpisah.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Nama file menggunakan [ISlide.getSlideNumber](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#getSlideNumber--) bukan indeks perulangan. Anda juga dapat mengekspor bentuk individual dengan [IShape.writeAsSvg](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ketika penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Mengkonfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/) mengontrol perenderan SVG. Untuk bingkai teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) menyertakan bingkai teks dalam area perenderan, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) menentukan apakah rotasi bingkai diterapkan. Setel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) ke `true` ketika teks harus dirender tanpa ligatur.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Mengontrol Teks dan Font**

### **Vektorkan Semua Teks**

Setel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan pada font dan membuat hasil visual lebih konsisten di semua peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Pilih Cara Penanganan Font Eksternal**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk merujuk file font terpisah, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk menyertakan data font dalam SVG, atau [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Kurangi Ukuran Gambar Tersemat**

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) untuk mengurangi resolusi gambar tersemat, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran berkas dengan mengorbankan kesetiaan gambar atau data gambar yang dipertahankan.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) untuk menyetel [ISvgShape.setId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) bagi setiap bentuk SVG. Untuk menyetel nilai [ISvgTSpan.setId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) pada elemen `tspan` teks juga, terapkan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Tetapkan salah satu controller dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Pengontrol berikut menggunakan [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), yang stabil selama masa hidup bentuk, dan penghitung berulang untuk rentang teksnya. Ini menjadikan ID yang dihasilkan cocok untuk pemrosesan pasca pada presentasi yang tidak diubah.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Tambahkan Penangan Peristiwa SVG**

Dalam sebuah [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), panggil [ISvgShape.setEventHandler](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) dengan nilai [SvgEvent](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgevent/) untuk menambahkan penangan peristiwa JavaScript pada bentuk yang diekspor. Tetapkan controller dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasil tersebut.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Halaman host dapat mendefinisikan fungsi JavaScript yang dirujuk oleh penangan. Penetapan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Gunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus diubah menjadi grafik.

**Apa cara terbaik untuk memperkecil ukuran SVG?**

Mulailah dengan mengompres gambar tersemat, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang dipindai menjadi vektor masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Bisakah saya memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui controller format, lalu pilih elemen SVG yang cocok dalam alat pemrosesan pasca atau skrip peramban Anda.