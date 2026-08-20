---
title: Kelola Frame Gambar dalam Presentasi Menggunakan JavaScript
linktitle: Frame Gambar
type: docs
weight: 10
url: /id/nodejs-java/picture-frame/
keywords:
- frame gambar
- tambahkan frame gambar
- buat frame gambar
- gambar tersemat
- gambar tertaut
- ekstrak gambar
- gambar raster
- gambar SVG
- potong gambar
- hapus area yang dipotong
- kompres gambar
- StretchOffset
- pemformatan frame gambar
- skala relatif
- efek gambar
- rasio aspek
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat, format, tautkan, potong, ekstrak, dan kompres frame gambar dalam presentasi dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Picture frame adalah bentuk slide yang menampilkan gambar. Di Aspose.Slides, sumber daya gambar dan bentuk yang menampilkannya merupakan objek terpisah: sebuah [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) memiliki sumber daya gambar tersemat melalui [ImageCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagecollection/), sementara [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) mengontrol posisi gambar, ukuran, format garis, rotasi, pemotongan, efek gambar, dan pengaturan tingkat frame lainnya.

Pemisahan ini berguna ketika gambar yang sama ditampilkan lebih dari satu kali. Tambahkan gambar ke presentasi sekali, simpan [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang dikembalikan, dan gunakan sumber daya gambar tersebut saat membuat picture frame.

Picture frame dapat berisi gambar raster seperti PNG atau JPEG serta gambar vektor SVG. Mereka juga dapat merujuk ke gambar terhubung alih‑alih menyimpan byte gambar di dalam presentasi. Pilihan ini memengaruhi portabilitas, ukuran file, proses ekstraksi, dan perilaku ekspor, sehingga penting menentukan cara penyimpanan gambar sebelum menerapkan pemformatan atau optimalisasi.

## **Menambahkan dan Memformat Gambar yang Disematkan**

Untuk gambar yang disematkan, tambahkan data gambar ke presentasi dan buat picture frame dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Gambar menjadi bagian dari paket presentasi, sehingga presentasi tetap mandiri saat dipindahkan ke komputer lain.

Contoh berikut menambahkan gambar PNG, membuat frame dengan dimensi asli gambar, dan menerapkan format garis serta rotasi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Picture frame mengontrol geometri yang ditampilkan; mengubah ukuran frame tidak mengubah dimensi piksel asli yang disimpan dalam sumber daya gambar yang disematkan. Perbedaan ini menjadi penting ketika memotong atau mengompresi gambar di kemudian hari.

## **Menggunakan Skala Relatif**

[PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) menyediakan skala lebar dan tinggi relatif untuk frame melalui [setRelativeScaleWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) dan [setRelativeScaleHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Nilai `1.0` berarti 100 % dari ukuran gambar asli. Skala relatif berguna ketika alur kerja perlu menjaga hubungan dengan ukuran gambar sumber alih‑alih menghitung dimensi akhir secara manual.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skala relatif mengubah pengaturan skala frame; ia tidak melakukan resampling atau kompresi pada gambar yang disematkan.

## **Gambar yang Disematkan dan Tertaut**

Gambar yang disematkan menyimpan data gambar di dalam presentasi dan oleh karenanya merupakan pilihan paling aman untuk portabilitas dan rendering yang dapat diprediksi. Gambar yang tertaut menyimpan lokasi eksternal melalui metode [Picture.setLinkPathLong](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) alih‑alih menanam data gambar dengan cara yang sama.

Gambar tertaut dapat mengurangi jumlah data gambar yang disimpan dalam PPTX, tetapi memperkenalkan dependensi eksternal. File tertaut harus tetap dapat diakses oleh aplikasi yang membuka atau merender presentasi. Jika jalur berubah, file dipindahkan, atau sumber tidak tersedia, gambar tertaut mungkin tidak ditampilkan seperti yang diharapkan. Untuk presentasi yang harus dikirim melalui email, diarsipkan, atau dirender di lingkungan terisolasi, gambar yang disematkan biasanya lebih dapat diandalkan.

### **Menambahkan Gambar Tertaut**

Contoh berikut membuat picture frame dan mengarahkannya ke file gambar lokal. Contoh ini hanya menangani tautan gambar; tautan video merupakan alur media terpisah dan memang tidak dicampur dalam contoh ini.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan tautan ketika manajemen file eksternal memang diinginkan. Jangan gunakan hanya sebagai pengganti kompresi: PPTX kecil dengan dependensi gambar yang rusak biasanya kurang berguna dibandingkan presentasi mandiri yang lebih besar.

## **Mengekstrak Gambar dari Picture Frame**

Sebelum mengekstrak gambar dari presentasi yang sudah ada, pastikan bahwa bentuk memang merupakan [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) dan bahwa ia berisi gambar yang disematkan. Picture frame tertaut mungkin tidak berisi byte gambar yang dapat diekstrak dengan cara yang sama.

### **Mengekstrak Gambar Raster**

API gambar modern menggunakan [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) secara langsung. Contoh berikut menemukan gambar raster yang pertama kali disematkan pada slide dan menyimpannya sebagai PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Menyimpan melalui [IImage.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/#save) mengubah gambar yang diekstrak ke format output yang diminta. Jika Anda memerlukan byte yang dikodekan yang disimpan dalam presentasi alih‑alih file raster yang telah dikonversi, gunakan data biner sumber daya gambar tersebut.

### **Mengekstrak Gambar SVG**

Untuk gambar SVG, [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) menyediakan objek [SvgImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/). Ini memungkinkan Anda mengambil data SVG secara langsung alih‑alih merasterkan gambar terlebih dahulu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Menyimpan konten SVG sebagai SVG mempertahankan sumber vektor di dalam presentasi. Ekspor raster seperti PNG atau JPEG memang harus merender konten vektor ke piksel. Ekspor slide ke PDF atau SVG juga merupakan operasi rendering, sehingga grafik yang diekspor tidak boleh dianggap sebagai salinan byte‑per‑byte dari SVG yang disematkan; gunakan data [SvgImage.getSvgData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/#getSvgData--) ketika sumber vektor asli diperlukan.

## **Memotong Gambar**

Pemotongan mengubah bagian gambar yang terlihat di dalam frame. Nilai pemotongan pada [PictureFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/) adalah persentase dari dimensi gambar sumber. Pemotongan tidak secara langsung menghapus piksel tersembunyi dari gambar yang disematkan; ia hanya mengubah wilayah yang terlihat.

Contoh berikut menemukan picture frame secara aman dan menerapkan nilai pemotongan:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Karena data gambar yang tersembunyi masih ada, pemotongan dapat diubah nanti tanpa kehilangan piksel asli. Jika ukuran file lebih penting daripada kemampuan memulihkan, wilayah yang dipotong dapat dihapus secara fisik seperti yang dijelaskan pada bagian berikutnya.

## **Menghapus Data Gambar yang Dipotong**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) menghapus data gambar di luar persegi panjang pemotongan saat ini dan mengembalikan sumber daya gambar yang dihasilkan. Ini dapat mengurangi ukuran file, tetapi merupakan optimalisasi destruktif: setelah presentasi disimpan, piksel yang dihapus tidak lagi tersedia untuk operasi un‑crop di kemudian hari.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Metode ini mungkin menambahkan sumber daya gambar baru ke presentasi. Jika gambar asli juga digunakan oleh picture frame lain, frame‑frame tersebut tetap memerlukan sumber daya yang ada, sehingga penghapusan area yang dipotong tidak selalu mengurangi total jumlah gambar. Memotong konten WMF atau EMF dengan metode ini merasterkan hasil yang dipotong menjadi PNG.

## **Mengompresi Gambar Raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) mengurangi resolusi gambar raster relatif terhadap ukuran saat gambar ditampilkan. Ia juga dapat menghapus wilayah yang dipotong dalam satu operasi. Metode mengembalikan `true` ketika gambar diubah ukurannya atau dipotong dan `false` jika tidak ada perubahan yang diperlukan.

Gunakan nilai [PicturesCompression](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturescompression/) yang telah ditentukan sebelumnya bila resolusi target standar sudah cukup:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Nilai DPI positif khusus dapat diberikan alih‑alih nilai yang telah ditentukan bila target spesifik diperlukan.

Kompresi ditujukan untuk gambar raster. Konten SVG dan metafile tidak berkurang oleh alur kerja kompresi raster ini. Ingat juga bahwa resolusi yang lebih rendah dan wilayah yang dihapus tidak dapat dipulihkan dari presentasi yang telah dioptimalkan. Pilih resolusi target berdasarkan ukuran terbesar di mana gambar akan benar‑benar dilihat atau diekspor, bukan menerapkan DPI terendah secara global.

## **Memeriksa Efek Gambar**

Efek gambar disimpan pada gambar yang digunakan oleh frame. Koleksi transformasi gambar dapat berisi efek seperti modulasi alfa tetap untuk transparansi dan luminansi untuk kecerahan serta kontras. Contoh di bawah ini membaca kedua jenis efek secara aman dari picture frame pertama pada slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efek‑efek ini mengubah cara gambar dirender dalam frame; mereka tidak menulis ulang byte gambar yang disematkan asli.

## **Mengunci Geometri Picture Frame**

Pengaturan [PictureFrameLock](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframelock/) mengontrol operasi penyuntingan mana yang dinonaktifkan untuk picture frame. Misalnya, [setAspectRatioLocked](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) menjaga proporsi bentuk saat ukuran diubah.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kunci ini berlaku pada shape picture frame. Ia tidak memaksa gambar sumber untuk di‑resample atau diubah secara permanen menjadi rasio aspek yang sama.

## **Menyesuaikan Nilai StretchOffset**

Ketika mode isian gambar berupa stretch, nilai stretch‑offset pada [PictureFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/) menentukan persegi panjang isian relatif terhadap bounding box picture frame. Persentase positif membuat inset dari tepi, sedangkan persentase negatif membuat outset.

Hal ini berbeda dari pemotongan. Nilai pemotongan memilih bagian gambar sumber yang terlihat; stretch offset mengubah persegi panjang tempat isian gambar yang terlihat diregangkan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gunakan stretch offset untuk penempatan isian. Gunakan properti crop ketika tujuan Anda adalah menyembunyikan tepi gambar sumber.

## **Penyimpanan, Ukuran File, dan Pertimbangan Ekspor**

Trade‑off utama menjadi lebih mudah dikelola ketika penyimpanan gambar dan pemformatan picture‑frame diperlakukan secara terpisah:

- **Gambar yang disematkan** membuat presentasi mandiri dan paling dapat diandalkan untuk berbagi serta rendering sisi server, tetapi gambar raster besar meningkatkan ukuran PPTX dan penggunaan memori.
- **Gambar yang tertaut** dapat membuat paket lebih kecil, tetapi presentasi bergantung pada file eksternal yang tetap tersedia pada jalur atau lokasi yang disimpan.
- **Pemotongan** pada awalnya non‑destruktif. Piksel tersembunyi tetap disematkan sampai area yang dipotong secara eksplisit dihapus atau dihapus selama kompresi.
- **Kompresi** dapat mengurangi ukuran file secara signifikan untuk gambar raster yang terlalu besar, tetapi mengorbankan resolusi sumber. Sebaiknya diterapkan setelah ukuran pada slide yang diinginkan diketahui.
- **Gambar SVG** sebaiknya tetap sebagai SVG ketika preservasi vektor penting. Ekstrak SVG yang disematkan secara langsung ketika Anda membutuhkan sumber vektor itu sendiri. Ekspor slide raster selalu mengonversi slide yang dirender ke piksel.
- **Gambar berulang** sebaiknya menggunakan kembali sumber daya [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang ada bila memungkinkan alih‑alih memuat file yang sama berulang‑ulang ke dalam alur kerja presentasi.

Untuk presentasi besar, optimalisasi gambar biasanya paling efektif bila dilakukan secara selektif: pertahankan logo dan diagram sebagai konten vektor, kompres foto sesuai ukuran tampilan sebenarnya, hapus piksel yang dipotong hanya bila penyuntingan di kemudian hari tidak diperlukan, dan hindari tautan eksternal kecuali manajemen dependensi merupakan bagian dari desain penyebaran.

## **FAQ**

**Apa perbedaan antara picture frame dan sumber daya gambar?**

[PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) mewakili sumber daya gambar yang terkait dengan presentasi. [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) adalah shape pada slide yang menampilkan gambar dan menyimpan geometri serta format tingkat frame seperti ukuran, rotasi, nilai crop, efek, dan kunci.

**Haruskah saya menyematkan atau menautkan gambar?**

Sebarkan gambar ketika presentasi harus portabel, diarsipkan, atau dirender tanpa akses ke sumber eksternal. Tautkan gambar hanya ketika menyimpan file gambar di luar PPTX memang diinginkan dan lokasi eksternal dapat dipelihara secara andal.

**Apakah pemotongan mengurangi ukuran file PPTX?**

Tidak secara otomatis. Pengaturan crop normal menyembunyikan bagian gambar sumber tetapi mempertahankan piksel di bawahnya. Gunakan [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) atau kompresi gambar dengan penghapusan area yang dipotong ketika piksel tersebut dapat dibuang secara permanen.

**Bisakah saya mengembalikan kualitas gambar setelah kompresi?**

Tidak. Kompresi dapat mengurangi resolusi raster yang disimpan, dan penghapusan area yang dipotong membuang data gambar. Simpan gambar sumber asli di luar presentasi jika penyuntingan beresolusi tinggi di kemudian hari mungkin diperlukan.

**Bagaimana seharusnya gambar SVG ditangani?**

Pertahankan konten SVG sebagai SVG ketika fidelitas vektor penting. [SvgImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/) yang disematkan dapat diekstrak secara langsung. Merender slide ke format raster seperti PNG atau JPEG akan merasterkan SVG sebagai bagian dari gambar slide.

**Bagaimana cara menghindari cast yang tidak aman saat membaca slide yang ada?**

Periksa tipe shape sebelum menggunakan anggota khusus picture‑frame. Pemeriksaan `java.instanceOf` terhadap [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) menghindari cast yang tidak valid dan memungkinkan kode menangani slide yang tidak berisi picture frame.