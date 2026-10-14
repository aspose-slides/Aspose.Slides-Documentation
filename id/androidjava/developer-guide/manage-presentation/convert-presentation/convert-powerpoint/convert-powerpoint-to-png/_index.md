---
title: Mengonversi Slide PowerPoint ke PNG di Android
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/androidjava/convert-powerpoint-to-png/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- simpan PPT sebagai PNG
- simpan PPTX sebagai PNG
- ekspor PPT ke PNG
- ekspor PPTX ke PNG
- Android
- Java
- Aspose.Slides
description: "Konversi presentasi PowerPoint menjadi gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk Android melalui Java, memastikan hasil yang tepat dan otomatis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi slide presentasi menjadi gambar PNG menggunakan Aspose.Slides untuk Android melalui Java. Anda dapat memuat presentasi dalam format seperti PPT, PPTX, dan ODP, merender setiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh di bawah ini menunjukkan proses rendering pada skala default, meningkatkan skala, menentukan dimensi output dalam piksel, dan memilih gaya rendering gradien.

## **Mengonversi PowerPoint ke PNG**

Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) dan akses slide-nya melalui koleksi [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) . Contoh ini merender setiap slide dengan [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) tanpa parameter untuk membuat thumbnail. Kemudian memanggil [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) dengan [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) untuk menyimpan tiap slide yang telah dirender sebagai gambar PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Overload [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) tanpa parameter merender pada skala 0.2. Misalnya, slide berukuran 720 × 540 poin menghasilkan thumbnail 144 × 108 piksel. Untuk mengontrol dimensi output, gunakan overload dengan faktor skala atau ukuran gambar eksplisit yang ditunjukkan di bawah.
{{% /alert %}}

## **Mengonversi PowerPoint ke PNG dengan Dimensi Kustom**

Berikan faktor skala horizontal dan vertikal ke [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) untuk mengontrol dimensi rendering. Pada contoh ini, kedua faktor adalah 2, sehingga slide berukuran 720 × 540 poin menghasilkan gambar 1440 × 1080 piksel. Faktor skala yang sama mempertahankan rasio aspek slide. Setiap gambar disimpan dalam format PNG dengan [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mengonversi PowerPoint ke PNG dengan Ukuran Kustom**

Untuk menentukan dimensi output dalam piksel, berikan ukuran ke [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) alih-alih faktor skala. Contoh ini merender setiap slide pada 960 × 720 piksel dan menyimpan hasilnya dengan [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Pilih dimensi yang sesuai dengan rasio aspek slide untuk menghindari gambar terdistorsi.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Pilih Gaya Rendering Gradien**

Misalkan sebuah slide berisi isian gradien, tetapi transisi pada PNG yang diekspor tampak lebih terang atau berbeda dari yang Anda lihat di PowerPoint. Anda dapat menggunakan metode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) yang diwarisi oleh [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) untuk memilih cara gradien dirender.

Unduh [gradient-styles.pptx](gradient-styles.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi dua gradien linear: sian ke oranye di atas dan biru ke kuning di bawah. Setiap gradien memiliki dua titik henti, pada 0% dan 100%.

Contoh berikut memuat presentasi ini dan merender slide pertama yang sama dalam kedua mode dengan [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Gambar di bawah ini menunjukkan output dari slide yang sama, dengan kedua gradien di setiap gambar:

| Default | PowerPointUI |
| --- | --- |
| ![Gradien sian-ke-oranye dan biru-ke-kuning dirender dengan Default](gradient-Default.png) | ![Gradien yang sama dirender dengan PowerPointUI](gradient-PowerPointUI.png) |

Pada contoh ini, `Default` menghasilkan warna antara yang lebih terang, sedangkan `PowerPointUI` menghasilkan warna antara yang lebih gelap. Perbedaannya tergantung pada warna dan titik henti dalam gradien.

Pilih `Default` ketika output standar Aspose.Slides sesuai kebutuhan Anda. Coba `PowerPointUI` ketika prioritas Anda adalah mencocokkan tampilan di PowerPoint. Bandingkan kedua output dengan hasil yang diinginkan; tidak ada mode yang secara universal lebih baik.

## **FAQ**

**Bagaimana saya dapat mengekspor bentuk tertentu, seperti diagram atau gambar, alih-alih seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individual](/slides/id/androidjava/create-shape-thumbnails/), memungkinkan Anda merender sebuah bentuk sebagai gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya. Gunakan instance presentasi terpisah untuk setiap thread atau proses; [jangan bagikan satu instance di antara thread](/slides/id/androidjava/multithreading/).

**Apa batasan evaluasi saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lainnya](/slides/id/androidjava/licensing/) hingga lisensi diterapkan.