---
title: Konversi Slide PowerPoint ke PNG di Android
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

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke gambar PNG menggunakan Aspose.Slides. Artikel ini menunjukkan cara memuat file presentasi dalam format seperti PPT, PPTX, dan ODP, merender slide sebagai gambar, dan menyimpan hasilnya dalam format PNG.

Artikel ini juga menunjukkan cara menyesuaikan gambar PNG yang dihasilkan dengan mengatur nilai skala atau menentukan lebar dan tinggi yang diinginkan.

## **Konversi PowerPoint ke PNG**

Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan objek slide dari koleksi [Presentation.getSlides()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) di bawah antarmuka [ISlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlide).
3. Gunakan metode [ISlide.getImage()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlide) untuk mendapatkan thumbnail setiap slide.
4. Gunakan metode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) untuk menyimpan thumbnail slide ke format PNG.

Kode Java berikut menunjukkan cara mengonversi presentasi PowerPoint ke PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Jika Anda ingin memperoleh file PNG dengan skala tertentu, Anda dapat mengatur nilai `desiredX` dan `desiredY`, yang menentukan dimensi thumbnail yang dihasilkan. 

Kode Java berikut mendemonstrasikan operasi tersebut:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Jika Anda ingin memperoleh file PNG dengan ukuran tertentu, Anda dapat memberikan argumen `width` dan `height` yang Anda inginkan untuk `ImageSize`. 

Kode ini menunjukkan cara mengonversi PowerPoint ke PNG sambil menentukan ukuran gambar: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana cara mengekspor hanya bentuk tertentu (misalnya grafik atau gambar) bukan seluruh slide?**

Aspose.Slides mendukung [generating thumbnails for individual shapes](/slides/id/androidjava/create-shape-thumbnails/); Anda dapat merender sebuah bentuk menjadi gambar PNG.

**Apakah konversi paralel didukung di server?**

Ya, tetapi [don’t share](/slides/id/androidjava/multithreading/) satu instance presentasi di antara thread. Gunakan instance terpisah per thread atau proses.

**Apa batasan versi percobaan saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar keluaran dan memberlakukan [other restrictions](/slides/id/androidjava/licensing/) hingga lisensi diterapkan.