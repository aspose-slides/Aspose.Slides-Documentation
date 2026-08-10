---
title: Render Slide Presentasi sebagai Gambar SVG di Java
linktitle: Slide ke SVG
type: docs
weight: 50
url: /id/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Ekspor slide PowerPoint sebagai gambar SVG di Java dan kendalikan font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, serta pemrosesan otomatis setelahnya. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/), pilih sebuah slide, dan tulis ke stream dengan [ISlide.writeAsSvg](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Contoh berikut mengekspor setiap slide dalam sebuah presentasi sebagai file SVG terpisah.

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

Nama file menggunakan [ISlide.getSlideNumber](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#getSlideNumber--) bukan indeks loop. Anda juga dapat mengekspor bentuk individual dengan [IShape.writeAsSvg](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ketika penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Konfigurasikan Output SVG**

[SVGOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) memasukkan bingkai teks ke area rendering, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) ke `true` ketika teks harus dirender tanpa ligatur.

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

## **Kontrol Teks dan Font**

### **Vektorkan Semua Teks**

Atur [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan pada font dan membuat hasil visual lebih konsisten di semua peramban, namun teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

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

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) untuk mengurangi resolusi gambar tersemat, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran berkas dengan mengorbankan kesetiaan atau data gambar yang dipertahankan.

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

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgshapeformattingcontroller/) untuk mengatur [ISvgShape.setId](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) bagi setiap bentuk SVG. Untuk mengatur nilai [ISvgTSpan.setId](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) pada elemen `tspan` teks juga, implementasikan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Tetapkan salah satu kontroler dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

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

Dalam sebuah [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgshapeformattingcontroller/), panggil [ISvgShape.setEventHandler](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) dengan nilai [SvgEvent](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan kontroler dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasilnya.

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

Halaman host dapat mendefinisikan fungsi JavaScript yang direferensikan oleh penangan. Menetapkan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **Tanya Jawab**

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgexternalfontshandling/)?**

Gunakan [SVGOptions.setVectorizeText] ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize] ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompresi gambar tersemat, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena penurunan resolusi gambar, penurunan kualitas JPEG, dan teks yang diverktorkan masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui kontroler format, lalu pilih elemen SVG yang cocok dalam alat pasca‑pemrosesan atau skrip peramban Anda.