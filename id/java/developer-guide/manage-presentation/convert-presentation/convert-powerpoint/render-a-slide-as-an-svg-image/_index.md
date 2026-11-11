---
title: Render Slide Presentasi sebagai Gambar SVG dalam Java
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
description: "Ekspor slide PowerPoint sebagai gambar SVG dalam Java dan kendalikan font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, dan pemrosesan otomatis setelahnya. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), pilih sebuah slide, dan tulis ke aliran dengan [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Contoh berikut mengekspor setiap slide dalam sebuah presentasi sebagai file SVG terpisah.

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

Nama file menggunakan [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) alih-alih indeks loop. Anda juga dapat mengekspor bentuk individual dengan [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ketika penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Konfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) menyertakan bingkai teks dalam area rendering, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) ke `true` ketika teks harus dirender tanpa ligatur.

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

## **Kendalikan Pemotongan Ujung Garis pada Kepala Panah**

SVG 1.1 tidak memiliki pengaturan inset penanda untuk menentukan di mana sebuah garis harus berhenti di bawah kepala panah. Secara default, Aspose.Slides memendekkan garis yang diekspor sehingga goresannya tidak menonjol melalui penanda. Panggil [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) dengan `true` untuk menggambar goresan hingga ke titik akhir asli garis. Pengaturan ini hanya memengaruhi output SVG. Garis tetap mempertahankan posisi dan panjangnya pada slide.

Contoh ini menggambar kepala panah segitiga dan berlian pada garis dengan lebar 2 dan 10 poin. Ia mengekspor slide yang sama dua kali, hanya mengubah opsi pemotongan.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

Perbandingan tersebut menunjukkan kepala panah segitiga pada garis 10 poin. Dengan pemotongan diaktifkan, ujungnya tajam. Dengan pemotongan dinonaktifkan, goresan menonjol melalui sisi miring penanda dan meninggalkan ujung datar.

![Segitiga 10 poin yang diperbesar dengan ujung tajam ketika pemotongan diaktifkan dan ujung datar ketika pemotongan dinonaktifkan](line-end-cropping.png)

Pada garis lain dalam contoh, goresan yang menonjol kurang terlihat pada segitiga 2 poin. Berlian yang diisi menutupi ujung goresan pada kedua lebar.

## **Kendalikan Teks dan Font**

Saat mengekspor slide ke SVG, Anda dapat mengontrol apakah teks tetap sebagai teks atau dikonversi menjadi grafik vektor, serta bagaimana font eksternal disertakan atau direferensikan. Opsi berikut membantu Anda menyeimbangkan konsistensi visual, pemilihan teks, dan ketergantungan font dalam SVG yang diekspor.

### **Vektorkan Semua Teks**

Atur [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan font dan membuat hasil visual lebih konsisten di semua peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk ke file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

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

## **Kurangi Ukuran Gambar yang Disematkan**

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) untuk mengurangi resolusi gambar yang disematkan, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran file dengan mengorbankan ketelitian gambar atau data gambar yang dipertahankan.

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

## **Kendalikan Resolusi Rasterisasi Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) menetapkan batas resolusi rendah untuk merasterisasi metafile selama ekspor SVG. Gunakan untuk menyeimbangkan detail dan ukuran file ketika gambar EMF atau WMF dirasterisasi. Ini tidak menetapkan DPI global untuk SVG atau memaksa setiap objek pada slide menjadi gambar raster.

Unduh [metafile-rasterization.pptx](metafile-rasterization.pptx), yang berisi gambar EMF dengan garis diagonal berjarak rapat. Contoh berikut mengekspor slide pertamanya pada tiga resolusi rasterisasi melalui [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Semua pengaturan ekspor lainnya tetap identik sehingga hasil dapat dibandingkan.

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

Dalam output, EMF menjadi satu PNG yang disematkan di setiap SVG. Pengukuran berikut berlaku untuk presentasi yang disediakan; ini bukan rumus umum untuk mengonversi DPI ke dimensi piksel.

| DPI rasterisasi Metafile | Dimensi PNG yang Disematkan | Ukuran file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Perbandingan di bawah ini menunjukkan area yang sama dari raster yang disematkan pada ukuran tampilan yang diperbesar sama. Garis diagonal menunjukkan pixelasi yang terlihat pada 72 DPI dan tepi yang lebih halus pada resolusi lebih tinggi, sementara file SVG menjadi lebih besar. Meningkatkan nilai tidak selalu memperbaiki setiap detail atau mengubah setiap gambar yang diekspor.

![Detail garis diagonal yang diperbesar pada 72, 150, dan 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) mengontrol pengurangan resolusi gambar dan dapat menyamarkan efek perubahan resolusi rasterisasi metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) mengontrol kualitas enkoding JPEG, bukan resolusi rasterisasi metafile.

## **Berikan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) untuk mengatur [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) bagi setiap bentuk SVG. Untuk mengatur nilai [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) pada elemen `tspan` teks juga, implementasikan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Tetapkan salah satu kontroler dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Kontroler berikut menggunakan [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), yang stabil selama masa hidup bentuk, dan penghitung yang dapat diulang untuk span teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak diubah.

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

Dalam sebuah [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), panggil [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) dengan nilai [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan kontroler dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasilnya.

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

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Gunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompresi gambar yang disematkan, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang vektorisasi masing-masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui kontroler pemformatan, lalu pilih elemen SVG yang sesuai dalam alat pemrosesan lanjutan atau skrip peramban Anda.