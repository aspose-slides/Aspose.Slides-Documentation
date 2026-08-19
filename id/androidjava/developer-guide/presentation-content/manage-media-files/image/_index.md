---
title: Optimalkan Manajemen Gambar dalam Presentasi di Android
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/androidjava/image/
keywords:
- menambahkan gambar
- menambahkan foto
- mengganti gambar
- koleksi gambar
- bingkai gambar
- gambar tertaut
- latar belakang
- menambahkan PNG
- menambahkan JPG
- menambahkan SVG
- SVG ke bentuk
- sumber daya SVG eksternal
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan, menggunakan kembali, menautkan, mengganti, dan mengelola gambar raster serta SVG dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android via Java."
---
## **Pendahuluan**

Aspose.Slides untuk Android via Java menyediakan beberapa cara untuk bekerja dengan gambar, dan masing‑masing melayani tujuan yang berbeda. Anda dapat menyimpan gambar dalam presentasi, menampilkannya dalam bingkai gambar, menggunakannya sebagai latar belakang slide, menautkan ke gambar eksternal, mengganti sumber gambar yang dibagikan, atau mengonversi konten SVG menjadi bentuk yang dapat diedit.  

Artikel ini berfokus pada sumber gambar dan bagaimana mereka digunakan di seluruh presentasi. Untuk pemotongan, transparansi, efek, peregangan, dan format lainnya yang diterapkan pada satu bingkai gambar, lihat [Picture Frame](/slides/id/androidjava/picture-frame/).

## **Memahami Model Gambar**

Konsep API berikut saling terkait namun tidak dapat dipertukarkan:

- [koleksi gambar presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagecollection/) menyimpan sumber gambar yang digunakan oleh presentasi. Gunakan [ImageCollection.addImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imagecollection/) untuk menambahkan data gambar dan memperoleh sumber [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/).
- Sebuah [bingkai gambar](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) adalah bentuk yang menampilkan gambar pada slide, tata letak, atau master. Gunakan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/) untuk menempatkan sumber gambar pada slide.
- Latar belakang slide menggunakan gambar sebagai bagian dari isian slide bukan sebagai bentuk. Oleh karena itu tidak berperilaku seperti bingkai gambar.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) mengganti sumber gambar. Jika beberapa elemen presentasi menggunakan sumber tersebut, semuanya akan menggunakan penggantiannya.
- Mengonversi SVG menjadi bentuk menghasilkan bentuk slide yang dapat diedit. Setelah konversi, konten tidak lagi dikelola sebagai satu sumber gambar.

Alur kerja tipikal jadi: tambahkan data gambar ke koleksi gambar, terima sebuah [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/), dan kemudian gunakan sumber tersebut dalam satu atau lebih bingkai gambar atau isian.

## **Menambahkan Gambar Tersemat**

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

Gambar yang ditambahkan dengan cara ini tersemat dalam presentasi, sehingga berkas hasil tidak bergantung pada ketersediaan berkas gambar asli.

### **Menambahkan Gambar dari Web**

Ketika sebuah gambar tersedia melalui HTTP atau HTTPS, unduh bajetnya, tambahkan ke koleksi gambar presentasi, dan gunakan sumber gambar yang dikembalikan dengan cara yang sama seperti gambar lokal.

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

Dalam aplikasi yang berjalan lama, gunakan kembali klien HTTP atau strategi manajemen koneksi yang sesuai dengan aplikasi daripada terus‑menerus membuat infrastruktur jaringan yang tidak diperlukan. Juga validasi URL remote, ukuran respons, dan tipe konten ketika sumber tidak terpercaya.

## **Menggunakan Ulang Gambar di Seluruh Slide**

Jika gambar yang sama diperlukan lebih dari satu kali, tambahkan ke presentasi sekali dan gunakan kembali [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) saat membuat bingkai gambar tambahan. Ini menghindari pemuatan berulang data sumber yang sama dan membuat hubungan antara sumber gambar yang dibagikan dan penggunaannya menjadi eksplisit.

Untuk grafik yang harus muncul secara otomatis pada banyak slide, seperti logo perusahaan, pertimbangkan menempatkan bingkai gambar pada [slide master](/slides/id/androidjava/slide-master/) atau tata letak alih‑alih menambahkan bentuk yang setara ke setiap slide.

## **Menggunakan Gambar sebagai Latar Belakang Slide**

Gambar latar belakang ditetapkan pada isian slide; tidak ditambahkan sebagai bentuk bingkai gambar. Ini berguna ketika gambar harus menutupi latar belakang slide dan tidak boleh dimanipulasi sebagai objek slide biasa.

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

Untuk opsi latar belakang tambahan, termasuk latar belakang master dan tata letak, lihat [Presentation Background](/slides/id/androidjava/presentation-background/).

## **Gambar Tersemat dan Gambar Tertaut**

Gambar tersemat dan gambar tertaut memiliki pertukaran portabilitas dan ukuran berkas yang berbeda:

- **Gambar tersemat:** data gambar disimpan di dalam presentasi. Presentasi bersifat mandiri, namun ukuran berkas mencakup data gambar.
- **Gambar tertaut:** presentasi menyimpan jalur atau URL ke gambar eksternal. Ini dapat mengurangi ukuran presentasi, tetapi sumber eksternal harus tetap dapat diakses ketika presentasi dibuka atau dirender.

Gambar tertaut dapat dibuat dengan menetapkan jalur atau URL eksternal melalui [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidespicture/) alih‑alih menanamkan data gambar.

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

Gunakan gambar tertaut hanya ketika lingkungan penyebaran dapat mengakses sumber eksternal dengan andal. Untuk presentasi yang harus bekerja offline atau dipindahkan antar sistem, gambar tersemat biasanya lebih aman.

## **Bekerja dengan Gambar SVG**

SVG adalah format vektor, sehingga berguna untuk ikon, diagram, dan grafik lain yang harus diskalakan tanpa kehilangan detail seperti gambar raster. Aspose.Slides mendukung SVG baik sebagai sumber gambar maupun sebagai sumber bentuk slide yang dapat diedit.

### **Menambahkan SVG sebagai Gambar**

Buat sebuah [SvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgimage/), tambahkan ke koleksi gambar, dan tempatkan sumber gambar yang dihasilkan dalam sebuah bingkai gambar.

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

SVG dapat merujuk ke gambar eksternal, stylesheet, atau font. Untuk kasus ini, [SvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/svgimage/) menyediakan konstruktor yang menerima [IExternalResourceResolver](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iexternalresourceresolver/) dan URI dasar. Resolver dapat memetakan URI relatif ke URI absolut yang diizinkan dan mengembalikan aliran untuk sumber yang diminta.  

Resolver membuat sumber eksternal tersedia saat Aspose.Slides memproses SVG, tetapi tidak menulis ulang SVG menjadi dokumen mandiri. Jika SVG harus tetap portabel, sematkan sumber yang diperlukan di dalam SVG itu sendiri, misalnya dengan menggunakan URI `data:` untuk gambar tertaut.  

Ketika berkas SVG datang dari sumber yang tidak terpercaya, batasi skema, lokasi berkas, dan host yang dapat diakses resolver. Resolver jaringan juga harus menerapkan batas waktu, batas ukuran respons, dan validasi konten.

### **Mengonversi SVG menjadi Bentuk yang Dapat Diedit**

Aspose.Slides dapat mengonversi SVG menjadi grup bentuk slide yang dapat diedit, mirip dengan perintah PowerPoint yang bersesuaian.

![PowerPoint Popup Menu](img_01_01.png)

Gunakan overload [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/) yang menerima [ISvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/) untuk melakukan konversi.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan konversi SVG‑ke‑bentuk ketika elemen vektor individual perlu diedit sebagai bentuk PowerPoint. Jika SVG hanya perlu ditampilkan, menyimpannya sebagai gambar lebih sederhana dan menghindari pembuatan banyak bentuk terpisah.

## **Mengganti Sumber Gambar yang Ada**

Gunakan [IPPImage.replaceImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) ketika Anda ingin mengganti sumber gambar yang ada. Ini sangat berguna untuk grafik yang dibagikan seperti logo.

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

Jika beberapa bingkai gambar, latar belakang, master, atau tata letak menggunakan sumber gambar yang sama, mengganti sumber tersebut memperbarui semua penggunaan tersebut. Jika hanya satu bingkai gambar yang harus berubah, tetapkan gambar berbeda ke bingkai itu alih‑alih mengganti sumber yang dibagikan.  

`replaceImage` juga menyediakan overload yang menerima array byte atau [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) lain.

## **Panduan Praktis Manajemen Gambar**

### **Mengontrol Ukuran Presentasi**

Gambar raster besar dapat membuat presentasi terlalu besar. Gunakan gambar sumber dengan dimensi yang sesuai untuk ukuran tampilan yang dimaksud, gunakan kembali sumber gambar yang dibagikan bila memungkinkan, dan hindari menanamkan salinan berulang dari grafik resolusi penuh yang sama.  

Untuk gambar raster yang sudah ditempatkan dalam bingkai gambar, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/) dapat mengurangi data gambar sesuai resolusi dan pengaturan pemotongan yang dipilih. Ini merupakan proses bingkai gambar bukan manajemen koleksi gambar, jadi lihat [Picture Frame](/slides/id/androidjava/picture-frame/) untuk operasi format terkait.

### **Pilih antara Konten Tersemat dan Tertaut**

Menanamkan membuat presentasi portabel karena semua data gambar yang diperlukan ikut dalam berkas. Menautkan dapat mengurangi ukuran berkas, tetapi menimbulkan ketergantungan eksternal. Gunakan tautan hanya ketika ketergantungan tersebut dapat diterima dan stabil.

### **Gunakan Ulang Branding yang Dibagikan**

Untuk logo, watermark, atau grafik dekoratif yang berulang, gunakan satu sumber gambar dan gunakan kembali. Jika grafik merupakan bagian dari desain presentasi bukan konten slide, letakkan pada master atau tata letak sehingga diwarisi oleh slide yang sesuai.

### **Jaga Sumber Daya SVG Portabel**

SVG mandiri lebih mudah dipindahkan dan dirender secara konsisten dibanding SVG yang bergantung pada berkas eksternal atau sumber jaringan. Bila memungkinkan, sematkan sumber yang diperlukan sebelum mengimpor SVG. Konversi SVG menjadi bentuk hanya ketika elemen vektor individual perlu diedit.

### **Gunakan API Gambar Lintas‑Platform Modern**

Untuk kode Android via Java baru, gunakan API Aspose.Slides [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) dan [Images](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/images/) alih‑alih API publik warisan yang berbasis `android.graphics.Bitmap`. Lihat [Modern API](/slides/id/androidjava/modern-api/) untuk panduan migrasi.  

WMF dan EMF memerlukan pertimbangan khusus. Ketika format ini dilewatkan melalui [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imagecollection/) mengonversi metafile menjadi representasi PNG raster sebelum penyisipan. Jika menjaga data metafile penting, gunakan overload [ImageCollection.addImage] berbasis aliran. Menghasilkan konten EMF dari spreadsheet atau produk lain merupakan alur integrasi terpisah dan di luar ruang lingkup artikel ini.

## **FAQ**

**Apa perbedaan antara koleksi gambar dan bingkai gambar?**  

Koleksi gambar menyimpan sumber gambar yang dapat digunakan kembali. Bingkai gambar adalah bentuk slide yang menampilkan salah satu sumber tersebut dan menyediakan pemformatan khusus gambar seperti pemotongan dan efek.

**Apa cara terbaik untuk mengganti logo yang sama di semua tempat?**  

Jika logo sudah dibagikan sebagai satu sumber gambar, ganti sumber tersebut dengan [IPPImage.replaceImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/). Untuk branding di seluruh presentasi, menempatkan logo pada master atau tata letak juga dapat mengurangi duplikasi konten slide.

**Mengapa gambar tertaut menghilang di komputer lain?**  

Gambar tertaut bergantung pada berkas atau URL eksternal. Jika sumber tersebut tidak dapat dijangkau dari komputer lain, gambar tertaut mungkin tidak tersedia. Tanamkan gambar ketika presentasi harus mandiri.

**Apakah SVG yang disisipkan dapat diedit sebagai bentuk PowerPoint?**  

Ya. Konversi SVG dengan [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/); grup yang dihasilkan berisi bentuk slide yang dapat diedit, bukan satu gambar SVG.

**Bagaimana saya dapat menjaga presentasi dengan banyak gambar tetap kecil?**  

Gunakan kembali sumber gambar yang dibagikan, hindari sumber raster yang terlalu besar, kompres gambar raster yang sesuai bila diperlukan, simpan branding yang berulang pada master atau tata letak, dan gunakan gambar tertaut hanya ketika ketergantungan eksternal dapat diterima.