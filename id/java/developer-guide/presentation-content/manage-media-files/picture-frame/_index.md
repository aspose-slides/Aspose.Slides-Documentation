---
title: Kelola Picture Frame dalam Presentasi Menggunakan Java
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/java/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- gambar tersemat
- gambar tertaut
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area yang dipotong
- kompres gambar
- StretchOffset
- pemformatan bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres bingkai gambar dalam presentasi dengan Aspose.Slides untuk Java."
---
## **Gambaran Umum**

Picture frame adalah bentuk slide yang menampilkan gambar. Di Aspose.Slides, sumber daya gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) memiliki sumber daya gambar tersemat melalui [IImageCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagecollection/), sementara sebuah [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat frame lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari sekali. Tambahkan gambar ke presentasi sekali, simpan [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) yang dikembalikan, dan gunakan sumber daya gambar tersebut saat membuat picture frame.

Picture frame dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar tertaut alih‑alih menyimpan byte gambar di dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran berkas, ekstraksi, dan perilaku ekspor, sehingga penting memutuskan cara penyimpanan gambar sebelum menerapkan pemformatan atau optimasi.

## **Menambahkan dan Memformat Gambar Tersemat**

Untuk gambar tersemat, tambahkan data gambar ke presentasi dan buat picture frame dengan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri ketika dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat frame dengan dimensi asli gambar, dan menerapkan format garis serta rotasi:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Picture frame mengontrol geometri yang ditampilkan; mengubah ukuran frame tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar tersemat. Perbedaan ini menjadi penting ketika memotong atau mengompresi gambar di kemudian hari.

## **Menggunakan Skala Relatif**

[IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) mengekspos skala lebar dan tinggi relatif untuk frame melalui [setRelativeScaleWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) dan [setRelativeScaleHeight](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Nilai `1.0` mewakili 100 % ukuran gambar asli. Skala relatif berguna ketika alur kerja harus mempertahankan hubungan dengan ukuran gambar sumber alih‑alih menghitung dimensi akhir secara manual.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skala relatif mengubah pengaturan skala frame; tidak melakukan resampling atau kompresi pada gambar tersemat.

## **Gambar Tersemat dan Tertaut**

Gambar tersemat menyimpan data gambar di dalam presentasi dan karenanya merupakan pilihan paling aman untuk portabilitas serta rendering yang dapat diprediksi. Gambar tertaut menyimpan lokasi eksternal melalui metode [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) alih‑alih menyematkan data gambar dengan cara yang sama.

Gambar tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi memperkenalkan ketergantungan eksternal. File tertaut harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, picture frame tertaut mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim email, diarsipkan, atau dirender di lingkungan terisolasi, gambar tersemat biasanya lebih dapat diandalkan.

### **Menambahkan Gambar Tertaut**

Contoh berikut membuat picture frame dan menunjukannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video merupakan alur kerja media terpisah dan sengaja tidak dicampur ke contoh ini.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan tautan ketika manajemen file eksternal memang diinginkan. Jangan gunakan hanya sebagai pengganti kompresi: PPTX kecil dengan ketergantungan gambar yang rusak biasanya kurang berguna dibandingkan presentasi mandiri yang lebih besar.

## **Mengekstrak Gambar dari Picture Frame**

Sebelum mengekstrak gambar dari presentasi yang ada, pastikan bahwa bentuk tersebut memang sebuah [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) dan bahwa ia berisi gambar tersemat. Picture frame tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) secara langsung dan tidak memerlukan wrapper gambar Java lama. Contoh berikut menemukan gambar raster tersemat pertama pada slide dan menyimpannya sebagai PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Menyimpan melalui [IImage.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/#save-java.lang.String-int-) mengonversi gambar yang diekstrak ke format output yang diminta. Jika Anda memerlukan byte terenkode yang disimpan dalam presentasi alih‑alih file raster yang telah dikonversi, gunakan data biner sumber daya gambar tersebut.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) mengekspos objek [ISvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/). Hal ini memungkinkan Anda mengambil data SVG secara langsung alih‑alih merasterkan gambar terlebih dahulu.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Menjaga konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG secara otomatis merender konten vektor tersebut ke piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh dianggap sebagai salinan byte‑per‑byte dari SVG tersemat asli; gunakan data [ISvgImage.getSvgData](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/#getSvgData--) ketika sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam frame. Nilai pemotongan pada [IPictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan awalnya tidak menghapus piksel tersembunyi dari gambar tersemat; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan picture frame dengan aman dan menerapkan nilai pemotongan:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Karena data gambar tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran berkas lebih penting daripada kemampuan membatalkan, wilayah yang dipotong dapat dihapus secara fisik seperti yang dijelaskan pada bagian berikut.

## **Menghapus Data Gambar yang Dipotong**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) menghapus data gambar di luar persegi panjang pemotongan saat ini dan mengembalikan sumber daya gambar yang dihasilkan. Ini dapat mengurangi ukuran berkas, tetapi merupakan optimasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi pembatalan pemotongan di kemudian hari.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Metode ini mungkin menambahkan sumber daya gambar baru ke presentasi. Jika gambar asli juga digunakan oleh picture frame lain, frame‑frame tersebut tetap memerlukan sumber daya yang ada, sehingga penghapusan area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompresi Gambar Raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) mengurangi resolusi gambar raster relatif terhadap ukuran saat gambar ditampilkan. Metode ini juga dapat menghapus wilayah yang dipotong dalam satu operasi. Metode mengembalikan `true` ketika gambar diubah ukurannya atau dipotong, dan `false` bila tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/java/com.aspose.slides/picturescompression/) yang telah ditentukan sebelumnya ketika target resolusi standar sudah cukup:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Nilai DPI positif khusus dapat diberikan alih‑alih nilai yang telah ditentukan ketika target spesifik diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak dikurangi oleh alur kerja kompresi raster ini. Ingat juga bahwa resolusi lebih rendah dan wilayah yang dipotong yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimasi. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar benar‑benar akan dilihat atau diekspor, bukan dengan menerapkan DPI terendah secara global.

## **Mengelola Efek Transformasi Gambar**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai berurutan, inspeksi, penghapusan, dan verifikasi putar‑balik, lihat [Image Transform Effects](/slides/id/java/image-transform-effects/).

## **Mengunci Geometri Picture Frame**

Pengaturan [IPictureFrameLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk picture frame. Misalnya, [setAspectRatioLocked](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) mempertahankan proporsi bentuk saat diubah ukurannya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Penguncian berlaku pada bentuk picture frame. Ia tidak memaksa gambar sumber untuk dire-sample atau secara permanen diubah menjadi rasio aspek yang sama.

## **Menyesuaikan Nilai StretchOffset**

Ketika mode isian gambar adalah stretch, nilai stretch‑offset pada [IPictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/) menentukan persegi isi relatif terhadap kotak batas picture frame. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; offset stretch mengubah persegi tempat isian gambar yang terlihat diregangkan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan stretch offset untuk penempatan isian. Gunakan properti pemotongan ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Penyimpanan, Ukuran Berkas, dan Pertimbangan Ekspor**

Trade‑off utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan picture frame diperlakukan terpisah:

- **Gambar tersemat** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar tertaut** dapat menjaga paket tetap lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia di jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya non‑destruktif. Piksel tersembunyi tetap tersemat hingga area yang dipotong secara eksplisit dihapus atau dihilangkan selama kompresi.
- **Kompresi** dapat mengurangi ukuran berkas secara signifikan untuk gambar raster yang berukuran berlebih, tetapi mengorbankan resolusi sumber. Kompresi sebaiknya diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG tersemat secara langsung ketika Anda memerlukan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender menjadi piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber daya [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) yang ada bila memungkinkan alih‑alih memuat file yang sama berulang kali ke alur kerja presentasi.

Untuk presentasi besar, optimasi gambar biasanya paling efektif bila dilakukan secara selektif: simpan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya bila penyuntingan di kemudian hari tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan menjadi bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara picture frame dan sumber daya gambar?**

[IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) mewakili sumber daya gambar yang terkait dengan presentasi. [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta format tingkat frame seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Haruskah saya menyematkan atau menautkan gambar?**

Sematkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber daya eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang diinginkan dan lokasi eksternal dapat dipertahankan dengan handal.

**Apakah pemotongan mengurangi ukuran berkas PPTX?**

Tidak secara otomatis. Pengaturan pemotongan standar menyembunyikan bagian gambar sumber tetapi tetap menyimpan piksel di bawahnya. Gunakan [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya mengembalikan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat menurunkan resolusi raster yang disimpan, dan penghapusan wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi bila penyuntingan beresolusi tinggi di masa depan mungkin diperlukan.

**Bagaimana cara menangani gambar SVG?**

Pertahankan konten SVG sebagai SVG ketika fidelitas vektor penting. [ISvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/) yang tersemat dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana saya dapat menghindari cast tidak aman saat membaca slide yang ada?**

Periksa tipe bentuk sebelum menggunakan anggota khusus picture frame. Pemeriksaan `instanceof` terhadap [IPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframe/) menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi picture frame.