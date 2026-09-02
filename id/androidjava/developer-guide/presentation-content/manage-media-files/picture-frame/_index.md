---
title: Kelola Bingkai Gambar dalam Presentasi di Android
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/androidjava/picture-frame/
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
- Android
- Java
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres bingkai gambar dalam presentasi dengan Aspose.Slides untuk Android melalui Java."
---
## **Gambaran Umum**

Bingkai gambar adalah bentuk slide yang menampilkan gambar. Di Aspose.Slides, sumber gambar dan bentuk yang menampilkannya adalah objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) memiliki sumber gambar tersemat melalui [IImageCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagecollection/), sementara sebuah [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) mengontrol posisi gambar, ukuran, pemformatan garis, rotasi, pemotongan, efek gambar, dan pengaturan level bingkai lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi sekali saja, simpan [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) yang dikembalikan, dan gunakan sumber gambar tersebut saat membuat bingkai gambar.

Bingkai gambar dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar tertaut alih‑alih menyimpan byte gambar dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, ekstraksi, dan perilaku ekspor, sehingga berguna untuk memutuskan bagaimana gambar harus disimpan sebelum menerapkan pemformatan atau optimisasi.

## **Menambahkan dan Memformat Gambar Tersemat**

Untuk gambar tersemat, tambahkan data gambar ke presentasi dan buat bingkai gambar dengan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri saat dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar JPEG, membuat bingkai dengan dimensi asli gambar, dan menerapkan pemformatan garis serta rotasi:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Bingkai gambar mengontrol geometri yang ditampilkan; mengubah ukuran bingkai tidak mengubah dimensi piksel asli yang disimpan dalam sumber gambar tersemat. Perbedaan ini menjadi penting saat memotong atau mengompresi gambar nantinya.

## **Gunakan Skala Relatif**

[IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) menyediakan skala lebar dan tinggi relatif untuk bingkai melalui [setRelativeScaleWidth](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) dan [setRelativeScaleHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Nilai `1.0` bersesuaian dengan 100 % ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu mempertahankan hubungan dengan ukuran sumber gambar alih‑alih menghitung dimensi akhir secara manual.

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

Skala relatif mengubah pengaturan skala bingkai; tidak melakukan resampling atau kompresi pada gambar tersemat.

## **Gambar Tersemat dan Tertaut**

Gambar tersemat menyimpan data gambar di dalam presentasi dan karenanya menjadi pilihan paling aman untuk portabilitas serta rendering yang dapat diprediksi. Gambar tertaut menyimpan lokasi eksternal melalui metode [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) alih‑alih menanamkan data gambar dengan cara yang sama.

Gambar tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi memperkenalkan ketergantungan eksternal. File tertaut harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, gambar tertaut mungkin tidak ditampilkan sebagaimana mestinya. Untuk presentasi yang harus dikirim lewat email, diarsipkan, atau dirender dalam lingkungan terisolasi, gambar tersemat biasanya lebih dapat diandalkan.

### **Menambahkan Gambar Tertaut**

Contoh berikut membuat bingkai gambar dan menunjukannya ke file gambar lokal. Contoh ini hanya menangani penautan gambar; penautan video merupakan alur kerja media terpisah dan sengaja tidak dicampur ke contoh ini.

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

## **Mengekstrak Gambar dari Bingkai Gambar**

Sebelum mengekstrak gambar dari presentasi yang ada, pastikan bentuk tersebut memang merupakan [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) dan mengandung gambar tersemat. Bingkai gambar tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) secara langsung dan tidak memerlukan pembungkus gambar Java lama. Contoh berikut menemukan gambar raster tersemat pertama pada slide dan menyimpannya sebagai PNG:

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

Menyimpan melalui [IImage.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) mengonversi gambar yang diekstrak ke format keluaran yang diminta. Jika Anda memerlukan byte yang dikodekan yang disimpan dalam presentasi alih‑alih file raster yang dikonversi, gunakan data biner sumber gambar tersebut.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) menyediakan objek [ISvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/). Hal ini memungkinkan Anda mengambil data SVG secara langsung alih‑alih merasterkan gambar terlebih dahulu.

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

Menjaga konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG harus merender konten vektor tersebut menjadi piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh diperlakukan sebagai salinan byte‑per‑byte dari SVG tersemat asli; gunakan data [ISvgImage.getSvgData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/#getSvgData--) ketika sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam bingkai. Nilai pemotongan pada [IPictureFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak secara langsung menghapus piksel tersembunyi dari gambar tersemat; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan bingkai gambar dengan aman dan menerapkan nilai pemotongan:

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

Karena data gambar tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan untuk mengembalikan, wilayah yang dipotong dapat dihapus secara fisik seperti yang dijelaskan pada bagian berikutnya.

## **Menghapus Data Gambar yang Dipotong**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) menghapus data gambar di luar persegi pemotongan saat ini dan mengembalikan sumber gambar yang dihasilkan. Ini dapat mengurangi ukuran file, tetapi merupakan optimisasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

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

Metode ini mungkin menambahkan sumber gambar baru ke presentasi. Jika gambar asli juga digunakan oleh bingkai gambar lain, bingkai‑bingkai tersebut tetap memerlukan sumber yang ada, sehingga menghapus wilayah yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompres Gambar Raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) mengurangi resolusi gambar raster relatif terhadap ukuran saat gambar ditampilkan. Metode ini juga dapat menghapus wilayah yang dipotong dalam satu operasi. Metode mengembalikan `true` ketika gambar diubah ukuran atau dipotong dan `false` ketika tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/picturescompression/) yang telah ditentukan sebelumnya ketika resolusi target standar sudah cukup:

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

Nilai DPI positif khusus dapat diberikan alih‑alih nilai yang telah ditentukan ketika target tertentu diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak berkurang oleh alur kerja kompresi raster ini. Ingat juga bahwa resolusi yang lebih rendah dan wilayah yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimalkan. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar akan benar‑benar dilihat atau diekspor, bukan dengan menerapkan DPI terendah secara global.

## **Mengelola Efek Transformasi Gambar**

Untuk alur kerja lengkap yang mencakup kecerahan, kontras, transformasi warna, blur, efek alfa, rantai berurutan, inspeksi, penghapusan, dan verifikasi siklus penuh, lihat [Image Transform Effects](/androidjava/image-transform-effects/).

## **Mengunci Geometri Bingkai Gambar**

Pengaturan [IPictureFrameLock](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk sebuah bingkai gambar. Misalnya, [setAspectRatioLocked](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) mempertahankan proporsi bentuk saat diubah ukuran.

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

Kunci ini berlaku pada bentuk bingkai gambar. Ia tidak memaksa gambar sumber untuk di‑resample atau secara permanen diubah menjadi rasio aspek yang sama.

## **Menyesuaikan Nilai StretchOffset**

Ketika mode isian gambar adalah stretch, nilai stretch‑offset pada [IPictureFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/) menentukan persegi isi relatif terhadap kotak pembatas bingkai gambar. Persentase positif membuat inset dari tepi, sementara persentase negatif membuat outset.

Ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi tempat isi gambar yang terlihat diregangkan.

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

Gunakan stretch offset untuk penempatan isi. Gunakan properti pemotongan ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Penyimpanan, Ukuran File, dan Pertimbangan Ekspor**

Trade‑off utama lebih mudah dikelola ketika penyimpanan gambar dan pemformatan bingkai gambar diperlakukan secara terpisah:

- **Gambar tersemat** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar tertaut** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia pada jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya non‑destruktif. Piksel tersembunyi tetap tersemat hingga wilayah yang dipotong secara eksplisit dihapus atau dihilangkan selama kompresi.
- **Kompresi** dapat mengurangi ukuran file secara signifikan untuk gambar raster berukuran berlebih, tetapi mengorbankan resolusi sumber. Kompresi sebaiknya diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap dalam format SVG ketika preservasi vektor penting. Ekstrak SVG tersemat secara langsung ketika Anda membutuhkan sumber vektor itu sendiri. Ekspor slide ke raster selalu mengonversi slide yang dirender menjadi piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) yang ada bila memungkinkan alih‑alih memuat file yang sama berulang‑ulang ke dalam alur kerja presentasi.

Untuk presentasi besar, optimisasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya ketika penyuntingan di masa mendatang tidak diperlukan, dan hindari tautan eksternal kecuali manajemen ketergantungan menjadi bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara bingkai gambar dan sumber gambar?**

[IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) mewakili sumber gambar yang terkait dengan presentasi. [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) adalah bentuk pada slide yang menampilkan gambar dan menyimpan geometri serta pemformatan level bingkai seperti ukuran, rotasi, nilai pemotongan, efek, dan kunci.

**Haruskah saya menanamkan atau menautkan gambar?**

Tanamkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang disengaja dan lokasi eksternal dapat dipertahankan secara andal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara langsung. Pengaturan pemotongan biasa menyembunyikan bagian gambar sumber tetapi mempertahankan piksel di bawahnya. Gunakan [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya mengembalikan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan penghapusan wilayah yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi jika penyuntingan beresolusi tinggi di kemudian hari mungkin diperlukan.

**Bagaimana sebaiknya gambar SVG ditangani?**

Pertahankan konten SVG sebagai SVG ketika keakuratan vektor penting. [ISvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/) yang tersemat dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana cara menghindari cast yang tidak aman saat membaca slide yang ada?**

Periksa tipe bentuk sebelum menggunakan anggota khusus bingkai gambar. Pemeriksaan `instanceof` terhadap [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi bingkai gambar.