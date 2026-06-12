---
title: Kelola Grafik SmartArt dalam Presentasi Menggunakan Java
linktitle: Grafik SmartArt
type: docs
weight: 20
url: /id/java/manage-smartart-shape/
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
- Java
- Aspose.Slides
description: "Otomatisasi pembuatan, penyuntingan, dan penataan SmartArt PowerPoint dalam Java menggunakan Aspose.Slides, menampilkan contoh kode ringkas dan panduan berfokus pada kinerja."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda membuat dan mengelola grafik SmartArt dalam presentasi PowerPoint secara programatik. Artikel ini menjelaskan cara menambahkan bentuk SmartArt ke slide, mengakses bentuk SmartArt yang ada, menemukan SmartArt berdasarkan tipe tata letak tertentu, dan memperbarui penampilan visualnya dengan mengubah gaya SmartArt atau gaya warna.

Contoh-contoh menunjukkan cara bekerja dengan bentuk SmartArt melalui koleksi bentuk slide presentasi, memeriksa apakah sebuah bentuk adalah SmartArt, dan kemudian memodifikasi atau memeriksa propertinya.

## **Buat Bentuk SmartArt**
Aspose.Slides for Java telah menyediakan API untuk membuat bentuk SmartArt. Untuk membuat bentuk SmartArt dalam slide, silakan ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide dengan menggunakan Index-nya.
3. [Tambahkan bentuk SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) dengan mengatur [LayoutType](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtLayoutType).
4. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Membuat Instance Kelas Presentation
Presentation pres = new Presentation();
try {
    // Ambil slide pertama
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
|**Gambar: Bentuk SmartArt ditambahkan ke slide**|

## **Akses Bentuk SmartArt pada Slide**
Kode berikut akan digunakan untuk mengakses bentuk SmartArt yang ditambahkan dalam slide presentasi. Dalam contoh kode, kami akan menelusuri setiap bentuk di dalam slide dan memeriksa apakah itu merupakan bentuk [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt). Jika bentuk tersebut berjenis SmartArt, maka kami akan mengkonversinya menjadi instance [**SmartArt**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt).

```java
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt)
        {
            // Ubah tipe bentuk menjadi SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Akses Bentuk SmartArt dengan Tipe Tata Letak Tertentu**
Contoh kode berikut akan membantu mengakses bentuk [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt) dengan LayoutType tertentu. Harap dicatat bahwa Anda tidak dapat mengubah LayoutType dari SmartArt karena bersifat read only dan hanya ditetapkan saat bentuk [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt) ditambahkan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index-nya.
3. Telusuri setiap bentuk di dalam slide pertama.
4. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt) dan ubah tipe bentuk yang dipilih menjadi SmartArt jika memang SmartArt.
5. Periksa bentuk SmartArt dengan LayoutType tertentu dan lakukan apa yang diperlukan setelahnya.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt)
        {
            // Ubah tipe bentuk menjadi SmartArtEx
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
Dalam contoh ini, kami akan mempelajari cara mengubah gaya cepat untuk bentuk SmartArt apa pun.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index-nya.
3. Telusuri setiap bentuk di dalam slide pertama.
4. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt) dan ubah tipe bentuk yang dipilih menjadi SmartArt jika memang SmartArt.
5. Temukan bentuk SmartArt dengan Gaya tertentu.
6. Tetapkan Gaya baru untuk bentuk SmartArt.
7. Simpan Presentasi.

```java
// Membuat Instance Kelas Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Ambil slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Ubah tipe bentuk menjadi SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Memeriksa gaya SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Mengubah Gaya SmartArt
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
|**Gambar: Bentuk SmartArt dengan Gaya yang diubah**|

## **Ubah Gaya Warna Bentuk SmartArt**
Dalam contoh ini, kami akan mempelajari cara mengubah gaya warna untuk bentuk SmartArt apa pun. Dalam contoh kode berikut, akan diakses bentuk SmartArt dengan gaya warna tertentu dan gaya tersebut akan diubah.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.
2. Dapatkan referensi slide pertama dengan menggunakan Index-nya.
3. Telusuri setiap bentuk di dalam slide pertama.
4. Periksa apakah bentuk tersebut berjenis [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt) dan ubah tipe bentuk yang dipilih menjadi SmartArt jika memang SmartArt.
5. Temukan bentuk SmartArt dengan Gaya Warna tertentu.
6. Tetapkan Gaya Warna baru untuk bentuk SmartArt.
7. Simpan Presentasi.

```java
// Membuat Instance Kelas Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Ambil slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Periksa apakah bentuk berjenis SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Ubah tipe bentuk menjadi SmartArtEx
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
|**Gambar: Bentuk SmartArt dengan Gaya Warna yang diubah**|

## **FAQ**

**Apakah saya dapat menganimasikan SmartArt sebagai satu objek?**

Ya. SmartArt adalah bentuk, jadi Anda dapat menerapkan [animasi standar](/slides/id/java/powerpoint-animation/) melalui API animasi (masuk, keluar, penekanan, jalur gerak) seperti pada bentuk lainnya.

**Bagaimana saya dapat menemukan SmartArt tertentu pada slide jika saya tidak mengetahui ID internalnya?**

Tetapkan dan gunakan Teks Alternatif (AltText) dan cari bentuk berdasarkan nilai tersebut—ini adalah cara yang disarankan untuk menemukan bentuk target.

**Apakah saya dapat mengelompokkan SmartArt dengan bentuk lain?**

Ya. Anda dapat mengelompokkan SmartArt dengan bentuk lain (gambar, tabel, dll.) dan kemudian [memanipulasi grup](/slides/id/java/group/).

**Bagaimana saya mendapatkan gambar dari SmartArt tertentu (mis., untuk pratinjau atau laporan)?**

Ekspor thumbnail/gambar dari bentuk; perpustakaan dapat [merender bentuk individual](/slides/id/java/create-shape-thumbnails/) ke file raster (PNG/JPG/TIFF).

**Apakah tampilan SmartArt akan dipertahankan saat mengonversi seluruh presentasi ke PDF?**

Ya. Mesin rendering menargetkan fidelitas tinggi untuk [ekspor PDF](/slides/id/java/convert-powerpoint-to-pdf/), dengan berbagai opsi kualitas dan kompatibilitas.