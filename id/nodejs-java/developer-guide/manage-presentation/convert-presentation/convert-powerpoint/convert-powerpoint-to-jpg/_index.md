---
title: Mengonversi PPT dan PPTX ke JPG dalam JavaScript
linktitle: PowerPoint ke JPG
type: docs
weight: 60
url: /id/nodejs-java/convert-powerpoint-to-jpg/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonversi slide PowerPoint (PPT, PPTX) menjadi gambar JPG berkualitas tinggi dalam JavaScript dengan Aspose.Slides untuk Node.js via Java menggunakan contoh kode yang cepat dan dapat diandalkan."
---
## **Pendahuluan**

Mengonversi presentasi PowerPoint dan OpenDocument menjadi gambar JPG membantu dalam membagikan slide, mengoptimalkan kinerja, dan menyematkan konten ke situs web atau aplikasi. Aspose.Slides memungkinkan Anda mengubah file PPTX, PPT, dan ODP menjadi gambar JPEG berkualitas tinggi. Panduan ini menjelaskan berbagai metode konversi.

Dengan fitur‑fitur ini, mudah untuk mengimplementasikan penampil presentasi Anda sendiri dan membuat thumbnail untuk setiap slide. Ini dapat berguna jika Anda ingin melindungi slide presentasi dari penyalinan atau menampilkan presentasi dalam mode hanya baca. Aspose.Slides memungkinkan Anda mengonversi seluruh presentasi atau slide tertentu ke format gambar.

## **Konversi PowerPoint PPT/PPTX ke JPG**
Berikut langkah‑langkah untuk mengonversi PPT/PPTX ke JPG:

1. Buat sebuah instance dari tipe [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan objek slide dari tipe [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide) dari koleksi [Presentation.getSlides()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Buat thumbnail setiap slide dan kemudian konversi ke JPG. Metode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide#getImage-float-float-) digunakan untuk mendapatkan thumbnail sebuah slide, metode ini mengembalikan objek [Imagess](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Images) sebagai hasil. Metode [getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) harus dipanggil dari slide yang diperlukan dari tipe [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide), skala thumbnail yang dihasilkan diteruskan ke metode.
4. Setelah Anda mendapatkan thumbnail slide, panggil metode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/#save) dari objek thumbnail. Berikan nama file hasil dan format gambar ke dalamnya.

{{% alert color="primary" %}}
**Catatan**: Konversi PPT/PPTX ke JPG berbeda dari konversi ke tipe lain dalam API Aspose.Slides. Untuk tipe lain, biasanya Anda menggunakan metode [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), namun di sini Anda perlu metode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/#save).
{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Membuat gambar skala penuh
        var slideImage = sld.getImage(1.0, 1.0);
        // Menyimpan gambar ke disk dalam format JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konversi PowerPoint PPT/PPTX ke JPG dengan Dimensi yang Disesuaikan**
Untuk mengubah dimensi thumbnail dan gambar JPG yang dihasilkan, Anda dapat mengatur nilai *ScaleX* dan *ScaleY* dengan melewatkannya ke metode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide#getImage-float-float-):

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Mendefinisikan dimensi
    var desiredX = 1200;
    var desiredY = 800;
    // Mendapatkan nilai skala X dan Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Membuat gambar skala penuh
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Menyimpan gambar ke disk dalam format JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Render Komentar saat menyimpan Presentasi menjadi Gambar**
Aspose.Slides untuk Node.js via Java menyediakan fasilitas yang memungkinkan Anda merender komentar pada slide presentasi saat Anda mengonversi slide tersebut menjadi gambar. Kode JavaScript ini menunjukkan cara kerjanya:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose menyediakan [aplikasi web Collage GRATIS](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan gambar [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan sebagainya. 
{{% /alert %}}

## **Lihat juga**

Lihat opsi lain untuk mengonversi PPT/PPTX menjadi gambar seperti:

- [Konversi PPT/PPTX ke SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Apakah metode ini mendukung konversi batch?**

Ya, Aspose.Slides memungkinkan konversi batch banyak slide ke JPG dalam satu operasi.

**Apakah konversi mendukung SmartArt, diagram, dan objek kompleks lainnya?**

Ya, Aspose.Slides merender semua konten, termasuk SmartArt, diagram, tabel, bentuk, dan lainnya. Namun, akurasi rendering mungkin sedikit berbeda dibandingkan PowerPoint, terutama saat menggunakan font khusus atau yang tidak ada.

**Apakah ada batasan pada jumlah slide yang dapat diproses?**

Aspose.Slides sendiri tidak memberlakukan batasan ketat pada jumlah slide yang dapat Anda proses. Namun, Anda mungkin mengalami kesalahan out-of-memory saat bekerja dengan presentasi besar atau gambar beresolusi tinggi.