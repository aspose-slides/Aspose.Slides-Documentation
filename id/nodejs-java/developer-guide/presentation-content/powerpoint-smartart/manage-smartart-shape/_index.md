---
title: Kelola Grafik SmartArt dalam Presentasi Menggunakan JavaScript
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/nodejs-java/manage-smartart-shape/
keywords:
- objek SmartArt
- grafik SmartArt
- gaya SmartArt
- warna SmartArt
- buat SmartArt
- tambahkan SmartArt
- sunting SmartArt
- ubah SmartArt
- akses SmartArt
- tipe tata letak SmartArt
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Otomatisasi pembuatan, penyuntingan, dan penataan SmartArt PowerPoint dalam JavaScript menggunakan Aspose.Slides, dengan contoh kode singkat dan panduan berfokus pada kinerja."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatis. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang ada, menemukan SmartArt berdasarkan tipe tata letak tertentu, dan memperbarui penampilannya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk slide presentasi, memeriksa apakah sebuah bentuk adalah SmartArt, kemudian memodifikasi atau memeriksa propertinya.

## **Buat Bentuk SmartArt**
Aspose.Slides for Node.js via Java telah menyediakan API untuk membuat bentuk SmartArt. Untuk membuat bentuk SmartArt dalam slide, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan Index‑nya.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) dengan mengatur [LayoutType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArtLayoutType).
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```javascript
// Instansiasi Kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ambil slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Tambahkan Bentuk Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Menyimpan presentasi
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt ditambahkan ke slide**|

## **Akses Bentuk SmartArt di Slide**
Kode berikut akan digunakan untuk mengakses bentuk SmartArt yang ditambahkan dalam slide presentasi. Dalam contoh kode kami akan menelusuri setiap bentuk di dalam slide dan memeriksa apakah itu berupa bentuk [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt). Jika bentuk tersebut bertipe SmartArt maka kami akan melakukan typecast ke instance [**SmartArt**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt).

```javascript
// Muat presentasi yang diinginkan
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Telusuri setiap bentuk di dalam slide pertama
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Periksa apakah bentuk bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast bentuk ke SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Akses Bentuk SmartArt dengan Tipe Tata Letak Tertentu**
Contoh kode berikut akan membantu mengakses bentuk [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dengan LayoutType tertentu. Perlu dicatat bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya ditetapkan ketika bentuk [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) ditambahkan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.
1. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
1. Telusuri setiap bentuk di dalam slide pertama.
1. Periksa apakah bentuk tersebut bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast ke SmartArt jika memang SmartArt.
1. Periksa bentuk SmartArt dengan LayoutType tertentu dan lakukan apa yang diperlukan setelahnya.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Telusuri setiap bentuk di dalam slide pertama
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Periksa apakah bentuk bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast bentuk ke SmartArtEx
            var smart = shape;
            // Memeriksa Tata Letak SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ubah Gaya Bentuk SmartArt**
Dalam contoh ini, kami akan mempelajari cara mengubah gaya cepat untuk bentuk SmartArt apa pun.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.
1. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
1. Telusuri setiap bentuk di dalam slide pertama.
1. Periksa apakah bentuk tersebut bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast ke SmartArt jika memang SmartArt.
1. Temukan bentuk SmartArt dengan Gaya tertentu.
1. Tetapkan Gaya baru untuk bentuk SmartArt.
1. Simpan Presentasi.

```javascript
// Instansiasi Kelas Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Ambil slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Telusuri setiap bentuk di dalam slide pertama
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Periksa apakah bentuk bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast bentuk ke SmartArtEx
            var smart = shape;
            // Memeriksa gaya SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Mengubah Gaya SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Menyimpan presentasi
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan Gaya yang diubah**|

## **Ubah Gaya Warna Bentuk SmartArt**
Dalam contoh ini, kami akan mempelajari cara mengubah gaya warna untuk bentuk SmartArt apa pun. Pada contoh kode berikut akan mengakses bentuk SmartArt dengan gaya warna tertentu dan mengubah gaya tersebut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.
1. Dapatkan referensi slide pertama dengan menggunakan Index‑nya.
1. Telusuri setiap bentuk di dalam slide pertama.
1. Periksa apakah bentuk tersebut bertipe [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SmartArt) dan lakukan typecast ke SmartArt jika memang SmartArt.
1. Temukan bentuk SmartArt dengan Gaya Warna tertentu.
1. Tetapkan Gaya Warna baru untuk bentuk SmartArt.
1. Simpan Presentasi.

```javascript
// Instansiasi Kelas Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Ambil slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Telusuri setiap bentuk di dalam slide pertama
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Periksa apakah bentuk bertipe SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Lakukan typecast bentuk ke SmartArtEx
            var smart = shape;
            // Memeriksa tipe warna SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Mengubah tipe warna SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Menyimpan presentasi
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan Gaya Warna yang diubah**|

## **Tanya Jawab**

**Apakah saya dapat menganimasikan SmartArt sebagai satu objek?**

Ya. SmartArt adalah bentuk, sehingga Anda dapat menerapkan [animasi standar](/slides/id/nodejs-java/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerak) seperti pada bentuk lainnya.

**Bagaimana cara menemukan SmartArt tertentu pada slide jika saya tidak mengetahui ID internalnya?**

Atur dan gunakan Teks Alternatif (AltText) serta cari bentuk berdasarkan nilai tersebut—ini adalah cara yang disarankan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [memanipulasi grup](/slides/id/nodejs-java/group/).

**Bagaimana cara mendapatkan gambar SmartArt tertentu (misalnya untuk pratinjau atau laporan)?**

Ekspor thumbnail/gambar bentuk; perpustakaan dapat [merender bentuk individual](/slides/id/nodejs-java/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan tetap terjaga saat mengonversi seluruh presentasi ke PDF?**

Ya. Mesin rendering menargetkan fidelitas tinggi untuk [ekspor PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), dengan berbagai opsi kualitas dan kompatibilitas.