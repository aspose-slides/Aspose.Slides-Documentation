---
title: Render Slide Presentasi sebagai Gambar SVG pada Android
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

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, dan pemrosesan pasca otomatis. Aspose.Slides untuk Android melalui Java mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), pilih sebuah slide, dan tulis ke stream dengan [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Contoh berikut mengekspor setiap slide dalam presentasi sebagai file SVG terpisah.

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

Nama file menggunakan [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) alih-alih indeks perulangan. Anda juga dapat mengekspor bentuk individual dengan [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ketika penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Konfigurasikan Output SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) mengontrol render SVG. Untuk bingkai teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) menyertakan bingkai teks dalam area render, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) ke `true` ketika teks harus dirender tanpa ligatur.

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

Saat mengekspor slide ke SVG, Anda dapat mengontrol apakah teks tetap sebagai teks atau diubah menjadi grafik vektor, serta bagaimana font eksternal disertakan atau direferensikan. Opsi berikut membantu Anda menyeimbangkan konsistensi visual, pemilihan teks, dan ketergantungan font dalam SVG yang diekspor.

### **Vektorisasi Semua Teks**

Atur [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan font dan membuat hasil visual lebih konsisten di semua peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk mereferensikan file font terpisah, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk menyertakan data font dalam SVG, atau [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

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

## **Kurangi Ukuran Gambar yang Ditanamkan**

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) untuk mengurangi resolusi gambar yang ditanamkan, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran berkas dengan mengorbankan fidelitas gambar atau data gambar yang dipertahankan.

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

## **Kontrol Resolusi Rasterisasi Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) menetapkan batas resolusi rendah untuk merasterisasi metafile selama ekspor SVG. Gunakan untuk menyeimbangkan detail dan ukuran berkas ketika gambar EMF atau WMF dirasterisasi. Ini tidak mendefinisikan DPI global untuk SVG atau memaksa setiap objek pada slide menjadi gambar raster.

Unduh [metafile-rasterization.pptx](metafile-rasterization.pptx), yang berisi gambar EMF dengan garis diagonal berjarak rapat. Contoh berikut mengekspor slide pertamanya pada tiga resolusi rasterisasi melalui [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Semua pengaturan ekspor lainnya tetap identik sehingga hasil dapat dibandingkan.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Dalam keluaran, EMF menjadi satu PNG yang ditanamkan di setiap SVG. Pengukuran berikut untuk presentasi yang disediakan; mereka bukan rumus umum untuk mengonversi DPI ke dimensi piksel.

| DPI rasterisasi Metafile | Dimensi PNG yang ditanamkan | Ukuran berkas SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Perbandingan di bawah menunjukkan area raster yang ditanamkan dengan ukuran tampilan yang diperbesar sama. Garis diagonal menunjukkan pixelation yang terlihat pada 72 DPI dan tepi yang lebih halus pada resolusi lebih tinggi, sementara berkas SVG membesar. Meningkatkan nilai tidak selalu meningkatkan setiap detail atau mengubah setiap gambar yang diekspor.

![Detail garis diagonal yang diperbesar pada 72, 150, dan 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) mengontrol pengurangan resolusi gambar dan dapat menyamarkan efek perubahan resolusi rasterisasi metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) mengontrol kualitas enkoding JPEG, bukan resolusi rasterisasi metafile.

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) untuk menetapkan [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) pada setiap bentuk SVG. Untuk menetapkan nilai [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) pada elemen teks `tspan` juga, terapkan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Tetapkan salah satu kontroler dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Kontroler berikut menggunakan [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), yang stabil selama masa hidup bentuk, dan penghitung yang dapat diulang untuk rentang teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan pasca pada presentasi yang tidak berubah.

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

Dalam [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), panggil [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) dengan nilai [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan kontroler dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menyajikan hasil.

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

Halaman host dapat mendefinisikan fungsi JavaScript yang direferensikan oleh penangan. Penetapan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Gunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus diubah menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompres gambar yang ditanamkan, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang vektorisasi masing-masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui kontroler pemformatan, lalu pilih elemen SVG yang cocok dalam alat pemrosesan pasca atau skrip peramban Anda.