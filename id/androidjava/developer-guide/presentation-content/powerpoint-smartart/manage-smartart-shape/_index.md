---
title: Kelola Grafik SmartArt dalam Presentasi di Android
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/androidjava/manage-smartart-shape/
keywords:
- objek SmartArt
- grafik SmartArt
- gaya SmartArt
- warna SmartArt
- buat SmartArt
- tambahkan SmartArt
- edit SmartArt
- ubah SmartArt
- akses SmartArt
- tipe tata letak SmartArt
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Otomatisasi pembuatan, penyuntingan, dan penataan SmartArt PowerPoint menggunakan Aspose.Slides untuk Android, dengan contoh kode Java yang ringkas dan panduan berfokus pada kinerja."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatis. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang ada, menemukan SmartArt berdasarkan tipe tata letak tertentu, dan memperbarui penampilannya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk pada slide presentasi, memeriksa apakah sebuah bentuk adalah SmartArt, dan kemudian memodifikasi atau memeriksa propertinya.

## **Buat Bentuk SmartArt**
Aspose.Slides for Android via Java menyediakan API untuk membuat bentuk SmartArt. Untuk membuat bentuk SmartArt dalam sebuah slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. [Tambahkan bentuk SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) dengan mengatur [LayoutType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Instansiasi Kelas Presentation
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tambahkan Bentuk Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Menyimpan presentasi
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt yang ditambahkan ke slide**|

## **Akses Bentuk SmartArt pada Slide**
Kode berikut akan digunakan untuk mengakses bentuk SmartArt yang ditambahkan dalam slide presentasi. Pada contoh kode, kami akan menelusuri setiap bentuk di dalam slide dan memeriksa apakah itu merupakan bentuk [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt). Jika bentuk tersebut berjenis SmartArt, maka kami akan melakukan typecast ke instance [**SmartArt**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt).

```java
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Jelajahi setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt)
        {
            // Lakukan typecast bentuk ke SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Akses Bentuk SmartArt dengan Tipe Layout Tertentu**
Contoh kode berikut akan membantu mengakses bentuk [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt) dengan LayoutType tertentu. Harap dicatat bahwa Anda tidak dapat mengubah LayoutType dari SmartArt karena bersifat read‑only dan hanya ditetapkan saat bentuk [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt) ditambahkan.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dan muat presentasi yang berisi Bentuk SmartArt.
1. Dapatkan referensi slide pertama dengan menggunakan indeksnya.
1. Telusuri setiap bentuk di dalam slide pertama.
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt) dan lakukan typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
1. Periksa bentuk SmartArt dengan LayoutType tertentu dan lakukan tindakan yang diperlukan setelahnya.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Jelajahi setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt)
        {
            // Lakukan typecast bentuk ke SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Memeriksa Tata Letak SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Gaya Bentuk SmartArt**
Dalam contoh ini, kita akan mempelajari cara mengubah gaya cepat untuk setiap bentuk SmartArt.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dan muat presentasi yang berisi Bentuk SmartArt.
1. Dapatkan referensi slide pertama dengan menggunakan indeksnya.
1. Telusuri setiap bentuk di dalam slide pertama.
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt) dan lakukan typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
1. Temukan bentuk SmartArt dengan Style tertentu.
1. Tetapkan Style baru untuk bentuk SmartArt.
1. Simpan Presentasi.

```java
// Instansiasi Kelas Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Jelajahi setiap bentuk di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast bentuk ke SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Memeriksa gaya SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Mengubah gaya SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Menyimpan presentasi
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan Style yang diubah**|

## **Ubah Gaya Warna Bentuk SmartArt**
Dalam contoh ini, kita akan mempelajari cara mengubah gaya warna untuk setiap bentuk SmartArt. Pada contoh kode berikut, kita akan mengakses bentuk SmartArt dengan gaya warna tertentu dan mengubah gayanya.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dan muat presentasi yang berisi Bentuk SmartArt.
1. Dapatkan referensi slide pertama dengan menggunakan indeksnya.
1. Telusuri setiap bentuk di dalam slide pertama.
1. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt) dan lakukan typecast pada bentuk yang dipilih ke SmartArt jika memang SmartArt.
1. Temukan bentuk SmartArt dengan Color Style tertentu.
1. Tetapkan Color Style baru untuk bentuk SmartArt.
1. Simpan Presentasi.

```java
// Instansiasi Kelas Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Jelajahi setiap bentuk di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast bentuk ke SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Memeriksa tipe warna SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Mengubah tipe warna SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Menyimpan presentasi
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Gambar: Bentuk SmartArt dengan Color Style yang diubah**|

## **FAQ**

**Apakah saya dapat memberi animasi pada SmartArt sebagai satu objek?**

Ya. SmartArt adalah sebuah bentuk, sehingga Anda dapat menerapkan [animasi standar](/slides/id/androidjava/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerak) seperti pada bentuk lainnya.

**Bagaimana saya dapat menemukan SmartArt tertentu pada slide jika saya tidak mengetahui ID internalnya?**

Tetapkan dan gunakan Teks Alternatif (AltText) serta cari bentuk berdasarkan nilai tersebut — ini adalah cara yang disarankan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [memanipulasi grup](/slides/id/androidjava/group/).

**Bagaimana cara memperoleh gambar dari SmartArt tertentu (misalnya untuk preview atau laporan)?**

Ekspor thumbnail/gambar dari bentuk; perpustakaan dapat [merender bentuk individual](/slides/id/androidjava/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi seluruh presentasi ke PDF?**

Ya. Mesin rendering menargetkan fidelitas tinggi untuk [ekspor PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), dengan berbagai opsi kualitas dan kompatibilitas.