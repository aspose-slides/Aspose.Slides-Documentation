---
title: Mengonversi PPT dan PPTX ke JPG dalam Java
linktitle: PowerPoint ke JPG
type: docs
weight: 60
url: /id/java/convert-powerpoint-to-jpg/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke JPG
- presentasi ke JPG
- slide ke JPG
- PPT ke JPG
- PPTX ke JPG
- simpan PowerPoint sebagai JPG
- simpan presentasi sebagai JPG
- simpan slide sebagai JPG
- simpan PPT sebagai JPG
- simpan PPTX sebagai JPG
- ekspor PPT ke JPG
- ekspor PPTX ke JPG
- Java
- Aspose.Slides
description: "Konversi slide PowerPoint (PPT, PPTX) menjadi gambar JPG berkualitas tinggi di Java dengan Aspose.Slides untuk Java menggunakan contoh kode yang cepat dan andal."
---
## **Pendahuluan**

Mengonversi presentasi PowerPoint dan OpenDocument ke gambar JPG membantu dalam berbagi slide, mengoptimalkan kinerja, dan menyematkan konten ke situs web atau aplikasi. Aspose.Slides memungkinkan Anda mengubah file PPTX, PPT, dan ODP menjadi gambar JPEG berkualitas tinggi. Panduan ini menjelaskan berbagai metode konversi.

Dengan fitur-fitur ini, mudah untuk mengimplementasikan penampil presentasi Anda sendiri dan membuat thumbnail untuk setiap slide. Ini mungkin berguna jika Anda ingin melindungi slide presentasi dari penyalinan atau menampilkan presentasi dalam mode hanya-baca. Aspose.Slides memungkinkan Anda mengonversi seluruh presentasi atau slide tertentu ke format gambar.

## **Konversi PowerPoint PPT/PPTX ke JPG**

Berikut langkah‑langkah untuk mengonversi PPT/PPTX ke JPG:

1. Buat instance tipe [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan objek slide tipe [ISlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide) dari koleksi [Presentation.getSlides()](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--).
3. Buat thumbnail setiap slide dan kemudian konversi ke JPG. Metode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide#getImage-float-float-) digunakan untuk memperoleh thumbnail slide, yang mengembalikan objek [Images](https://reference.aspose.com/slides/id/java/com.aspose.slides/Images) sebagai hasil. Metode [getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) harus dipanggil dari slide yang diperlukan dari tipe [ISlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide), skala thumbnail yang dihasilkan diteruskan ke metode.
4. Setelah Anda mendapatkan thumbnail slide, panggil metode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) dari objek thumbnail. Berikan nama file hasil dan format gambar ke dalamnya.

{{% alert color="primary" %}}
**Catatan**: Konversi PPT/PPTX ke JPG berbeda dari konversi ke tipe lain dalam API Aspose.Slides. Untuk tipe lain, biasanya Anda menggunakan metode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), tetapi di sini Anda memerlukan metode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Membuat gambar skala penuh
        IImage slideImage = sld.getImage(1f, 1f);

        // Menyimpan gambar ke disk dalam format JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konversi PowerPoint PPT/PPTX ke JPG dengan Dimensi yang Disesuaikan**

Untuk mengubah dimensi thumbnail dan gambar JPG yang dihasilkan, Anda dapat mengatur nilai *ScaleX* dan *ScaleY* dengan meneruskannya ke metode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Mendefinisikan dimensi
    int desiredX = 1200;
    int desiredY = 800;
    // Mendapatkan nilai skala X dan Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Membuat gambar skala penuh
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Menyimpan gambar ke disk dalam format JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Render Komentar Saat Menyimpan Slide sebagai Gambar**

Aspose.Slides untuk Java menyediakan fasilitas yang memungkinkan Anda merender komentar dalam slide presentasi saat mengonversi slide tersebut menjadi gambar. Kode Java berikut mendemonstrasikan operasi tersebut:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose menyediakan aplikasi web [FREE Collage](https://products.aspose.app/slides/id/collage) secara gratis. Menggunakan layanan daring ini, Anda dapat menggabungkan [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan sebagainya.

Dengan prinsip yang sama seperti yang dijelaskan dalam artikel ini, Anda dapat mengonversi gambar dari satu format ke format lain. Untuk informasi lebih lanjut, lihat halaman berikut: konversi [image to JPG](https://products.aspose.com/slides/id/java/conversion/image-to-jpg/); konversi [JPG to image](https://products.aspose.com/slides/id/java/conversion/jpg-to-image/); konversi [JPG to PNG](https://products.aspose.com/slides/id/java/conversion/jpg-to-png/), konversi [PNG to JPG](https://products.aspose.com/slides/id/java/conversion/png-to-jpg/); konversi [PNG to SVG](https://products.aspose.com/slides/id/java/conversion/png-to-svg/), konversi [SVG to PNG](https://products.aspose.com/slides/id/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Apakah metode ini mendukung konversi batch?**

Ya, Aspose.Slides memungkinkan konversi batch beberapa slide ke JPG dalam satu operasi.

**Apakah konversi mendukung SmartArt, diagram, dan objek kompleks lainnya?**

Ya, Aspose.Slides merender semua konten, termasuk SmartArt, diagram, tabel, bentuk, dan lainnya. Namun, akurasi render dapat sedikit bervariasi dibandingkan PowerPoint, terutama ketika menggunakan font khusus atau yang tidak tersedia.

**Apakah ada batasan jumlah slide yang dapat diproses?**

Aspose.Slides sendiri tidak memberlakukan batasan ketat pada jumlah slide yang dapat Anda proses. Namun, Anda mungkin mengalami kesalahan out-of-memory saat bekerja dengan presentasi besar atau gambar beresolusi tinggi.

## **Lihat Juga**

Lihat opsi lain untuk mengonversi PPT/PPTX menjadi gambar seperti:

- [Konversi PPT/PPTX ke SVG](/slides/id/java/render-a-slide-as-an-svg-image/).