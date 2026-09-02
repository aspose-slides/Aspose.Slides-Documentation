---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan Java
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/java/image/
keywords:
- tambahkan gambar
- tambahkan gambar
- ganti gambar
- koleksi gambar
- bingkai gambar
- gambar tertaut
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- SVG ke bentuk
- sumber daya SVG eksternal
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan, menggunakan kembali, menautkan, mengganti, dan mengelola gambar raster serta SVG dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Java."
---
## **Pendahuluan**

Aspose.Slides for Java menyediakan beberapa cara untuk bekerja dengan gambar, dan setiap cara melayani tujuan yang berbeda. Anda dapat menyimpan gambar dalam presentasi, menampilkannya dalam bingkai gambar, menggunakannya sebagai latar belakang slide, menautkan ke gambar eksternal, mengganti sumber daya gambar bersama, atau mengonversi konten SVG menjadi bentuk yang dapat diedit.

Artikel ini fokus pada sumber daya gambar dan bagaimana mereka digunakan di seluruh presentasi. Untuk pemotongan, transparansi, efek, peregangan, dan pemformatan lainnya yang diterapkan pada bingkai gambar individual, lihat [Bingkai Gambar](/slides/id/java/picture-frame/).

## **Pahami Model Gambar**

Konsep API berikut terkait erat tetapi tidak dapat dipertukarkan:

- [Koleksi gambar presentasi](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagecollection/) menyimpan sumber daya gambar yang digunakan oleh presentasi. Gunakan [ImageCollection.addImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/imagecollection/) untuk menambahkan data gambar dan memperoleh sumber daya [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/).
- Sebuah [Bingkai Gambar](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) adalah bentuk yang menampilkan gambar pada slide, tata letak, atau master. Gunakan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/) untuk menempatkan sumber daya gambar pada slide.
- Latar belakang slide menggunakan gambar sebagai bagian dari isian slide, bukan sebagai bentuk. Oleh karena itu tidak berperilaku seperti bingkai gambar.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) menggantikan sumber daya gambar. Jika beberapa elemen presentasi menggunakan sumber daya itu, semuanya akan menggunakan pengganti.
- Mengonversi SVG menjadi bentuk menciptakan bentuk slide yang dapat diedit. Setelah konversi, konten tidak lagi dikelola sebagai satu sumber daya gambar.

Alur kerja tipikal oleh karena itu: tambahkan data gambar ke koleksi gambar, terima sebuah [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/), dan kemudian gunakan sumber daya tersebut di satu atau lebih bingkai gambar atau isian.

## **Tambahkan Gambar yang Disematkan**

Untuk menyisipkan gambar lokal, muat berkas, tambahkan ke koleksi gambar, dan buat bingkai gambar yang menggunakan `IPPImage` yang dikembalikan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gambar yang ditambahkan dengan cara ini disematkan dalam presentasi, sehingga berkas hasil tidak bergantung pada ketersediaan berkas gambar asli.

### **Tambahkan Gambar dari Web**

Ketika gambar tersedia melalui HTTP atau HTTPS, unduh byte-nya, tambahkan ke koleksi gambar presentasi, dan gunakan sumber daya gambar yang dikembalikan dengan cara yang sama seperti gambar lokal.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dalam aplikasi yang berjalan lama, gunakan kembali klien HTTP atau strategi manajemen koneksi yang sesuai dengan aplikasi daripada terus-menerus membuat infrastruktur jaringan yang tidak perlu. Juga validasi URL remote, ukuran respons, dan tipe konten ketika sumber tidak terpercaya.

## **Gunakan Kembali Gambar di Seluruh Slide**

Jika gambar yang sama diperlukan lebih dari satu kali, tambahkan ke presentasi satu kali dan gunakan kembali IPPImage yang dikembalikan saat membuat bingkai gambar tambahan. Ini menghindari pemuatan berulang data sumber yang sama dan membuat hubungan antara sumber daya gambar bersama dan penggunaannya menjadi eksplisit.

Untuk grafik yang harus muncul secara otomatis pada banyak slide, seperti logo perusahaan, pertimbangkan menempatkan bingkai gambar pada [master slide](/slides/id/java/slide-master/) atau tata letak alih-alih menambahkan bentuk setara ke setiap slide.

## **Gunakan Gambar Sebagai Latar Belakang Slide**

Gambar latar belakang ditetapkan pada isian slide; gambar tidak ditambahkan sebagai bentuk bingkai gambar. Ini berguna ketika gambar harus menutupi latar belakang slide dan tidak boleh dimanipulasi sebagai objek slide biasa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk opsi latar belakang tambahan, termasuk latar belakang master dan tata letak, lihat [Latar Belakang Presentasi](/slides/id/java/presentation-background/).

## **Gambar yang Disematkan dan Gambar yang Ditautkan**

Gambar yang disematkan dan gambar yang ditautkan memiliki trade‑off portabilitas dan ukuran berkas yang berbeda:

- **Gambar yang disematkan:** data gambar disimpan di dalam presentasi. Presentasi menjadi mandiri, tetapi ukuran berkas mencakup data gambar.
- **Gambar yang ditautkan:** presentasi menyimpan jalur atau URL ke gambar eksternal. Ini dapat mengurangi ukuran presentasi, tetapi sumber eksternal harus tetap dapat diakses ketika presentasi dibuka atau dirender.

Gambar yang ditautkan dapat dibuat dengan menetapkan jalur atau URL eksternal melalui [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidespicture/) bukan dengan menyematkan data gambar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan gambar yang ditautkan hanya ketika lingkungan penerapan dapat secara andal mengakses sumber eksternal. Untuk presentasi yang harus bekerja offline atau dipindahkan antar sistem, gambar yang disematkan biasanya lebih aman.

## **Bekerja dengan Gambar SVG**

SVG adalah format vektor, sehingga dapat berguna untuk ikon, diagram, dan grafik lain yang harus skala tanpa kehilangan detail seperti gambar raster. Aspose.Slides mendukung SVG baik sebagai sumber daya gambar maupun sebagai sumber untuk bentuk slide yang dapat diedit.

### **Tambahkan SVG sebagai Gambar**

Buat sebuah [SvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgimage/), tambahkan ke koleksi gambar, dan tempatkan sumber daya gambar yang dihasilkan dalam bingkai gambar.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Berkas SVG dengan Sumber Daya Eksternal**

Sebuah SVG dapat merujuk ke gambar, lembar gaya, atau font eksternal. Untuk kasus ini, [SvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgimage/) menyediakan konstruktor yang menerima [IExternalResourceResolver](https://reference.aspose.com/slides/id/java/com.aspose.slides/iexternalresourceresolver/) dan URI dasar. Resolver dapat memetakan URI relatif ke URI absolut yang diizinkan dan mengembalikan stream untuk sumber daya yang diminta.

Resolver membuat sumber daya eksternal tersedia saat Aspose.Slides memproses SVG, tetapi tidak menulis ulang SVG menjadi dokumen mandiri. Jika SVG harus tetap portabel, sematkan sumber daya yang diperlukan di dalam SVG itu sendiri, misalnya dengan menggunakan URI `data:` untuk gambar yang ditautkan.

Ketika berkas SVG berasal dari sumber yang tidak terpercaya, batasi skema, lokasi berkas, dan host yang dapat diakses resolver. Resolver jaringan juga harus menerapkan batas waktu, batas ukuran respons, dan validasi konten.

### **Konversi SVG ke Bentuk yang Dapat Diedit**

Aspose.Slides dapat mengonversi SVG menjadi grup bentuk slide yang dapat diedit, mirip dengan perintah PowerPoint yang bersangkutan.

![PowerPoint Popup Menu](img_01_01.png)

Gunakan overload [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/) yang menerima [ISvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/) untuk melakukan konversi.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan konversi SVG‑ke‑bentuk ketika elemen vektor individual perlu diedit sebagai bentuk PowerPoint. Jika SVG hanya perlu ditampilkan, mempertahankannya sebagai gambar saja lebih sederhana dan menghindari pembuatan banyak bentuk terpisah.

## **Ganti Sumber Daya Gambar yang Ada**

Gunakan [IPPImage.replaceImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) ketika Anda ingin mengganti sumber daya gambar yang ada. Ini sangat berguna untuk grafik bersama seperti logo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika banyak bingkai gambar, latar belakang, master, atau tata letak menggunakan sumber daya gambar yang sama, mengganti sumber daya tersebut memperbarui semua penggunaan tersebut. Jika hanya satu bingkai gambar yang harus berubah, tetapkan gambar lain ke bingkai itu alih-alih mengganti sumber daya bersama.

`replaceImage` juga menyediakan overload yang menerima array byte atau [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) lain.

## **Panduan Praktis Manajemen Gambar**

### **Kontrol Ukuran Presentasi**

Gambar raster besar dapat membuat presentasi menjadi terlalu besar. Gunakan gambar sumber dengan dimensi yang sesuai untuk ukuran tampilan yang dimaksud, gunakan kembali sumber daya gambar bersama bila memungkinkan, dan hindari menyematkan salinan berulang grafik resolusi penuh yang sama.

Untuk gambar raster yang sudah ditempatkan dalam bingkai gambar, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/) dapat mengurangi data gambar berdasarkan resolusi dan pengaturan pemotongan yang dipilih. Ini adalah pemrosesan bingkai gambar bukan manajemen koleksi gambar, jadi lihat [Bingkai Gambar](/slides/id/java/picture-frame/) untuk operasi pemformatan terkait.

### **Pilih Antara Konten Disematkan dan Ditautkan**

Menyematkan membuat presentasi portabel karena semua data gambar yang diperlukan ikut bersama berkas. Menautkan dapat mengurangi ukuran berkas, tetapi memperkenalkan ketergantungan eksternal. Gunakan tautan hanya ketika ketergantungan tersebut dapat diterima dan stabil.

### **Gunakan Kembali Branding Bersama**

Untuk logo, watermark, atau grafik dekoratif yang berulang, gunakan satu sumber daya gambar dan gunakan kembali. Jika grafik tersebut merupakan bagian dari desain presentasi bukan konten slide, tempatkan di master atau tata letak sehingga diwariskan ke slide yang relevan.

### **Jaga Sumber Daya SVG Tetap Portabel**

SVG yang mandiri lebih mudah dipindahkan dan dirender secara konsisten dibandingkan SVG yang bergantung pada berkas eksternal atau sumber jaringan. Bila memungkinkan, sematkan sumber daya yang dibutuhkan sebelum mengimpor SVG. Konversi SVG ke bentuk hanya ketika elemen vektor individual perlu diedit.

### **Gunakan API Gambar Lintas‑Platform Modern**

Untuk kode Java baru, gunakan API Aspose.Slides [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) dan [Images](https://reference.aspose.com/slides/id/java/com.aspose.slides/images/) alih‑alih API publik lama yang berbasis `java.awt.image.BufferedImage`. Lihat [API Modern](/slides/id/java/modern-api/) untuk panduan migrasi.

WMF dan EMF memerlukan pertimbangan khusus. Ketika format ini dilewatkan melalui [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/imagecollection/) mengonversi metafile menjadi representasi PNG raster sebelum penyisipan. Jika mempertahankan data metafile penting, gunakan overload berbasis stream dari [ImageCollection.addImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/imagecollection/). Membuat konten EMF dari spreadsheet atau produk lain adalah alur kerja integrasi terpisah dan berada di luar lingkup artikel ini.

## **FAQ**

**Apa perbedaan antara koleksi gambar dan bingkai gambar?**

Koleksi gambar menyimpan sumber daya gambar yang dapat digunakan kembali. Bingkai gambar adalah bentuk slide yang menampilkan salah satu sumber daya tersebut dan menyediakan pemformatan khusus gambar seperti pemotongan dan efek.

**Cara terbaik mengganti logo yang sama di semua tempat?**

Jika logo sudah dibagikan sebagai satu sumber daya gambar, ganti sumber daya tersebut dengan [IPPImage.replaceImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/). Untuk branding seluruh presentasi, menempatkan logo pada master atau tata letak juga dapat mengurangi duplikasi konten slide.

**Mengapa gambar yang ditautkan hilang di komputer lain?**

Gambar yang ditautkan bergantung pada berkas atau URL eksternal. Jika sumber tersebut tidak dapat dijangkau dari komputer lain, gambar yang ditautkan mungkin tidak tersedia. Sebaiknya sematkan gambar ketika presentasi harus mandiri.

**Apakah SVG yang disisipkan dapat diedit sebagai bentuk PowerPoint?**

Ya. Konversi SVG dengan [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/); grup hasil berisi bentuk slide yang dapat diedit bukan satu gambar SVG.

**Bagaimana cara menjaga presentasi dengan banyak gambar tetap kecil?**

Gunakan kembali sumber daya gambar bersama, hindari sumber raster yang terlalu besar, kompres gambar raster yang cocok bila perlu, letakkan branding berulang pada master atau tata letak, dan gunakan gambar yang ditautkan hanya ketika ketergantungan eksternal dapat diterima.