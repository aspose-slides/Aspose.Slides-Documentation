---
title: Tambah Elips ke Presentasi di Android
linktitle: Elips
type: docs
weight: 30
url: /id/androidjava/ellipse/
keywords:
- elips
- bentuk
- tambahkan elips
- buat elips
- gambar elips
- elips terformat
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips dalam Aspose.Slides untuk Android pada presentasi PPT dan PPTX—contoh kode Java disertakan."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan elips sederhana, pembuatan elips yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX. Artikel ini juga membahas pertanyaan terkait seperti mengatur posisi dan ukuran elips, mengontrol urutan tumpukan, serta menerapkan efek animasi.

## **Membuat Elips**
Untuk menambahkan elips sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan elips ke slide pertama

```java
// Buat instance kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tambahkan AutoShape tipe elips
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Tulis file PPTX ke disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Membuat Elips yang Diformat**
Untuk menambahkan elips yang lebih terformat ke slide, ikuti langkah-langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).
- Atur Fill Type elips menjadi Solid.
- Atur Warna elips menggunakan properti SolidFillColor.Color yang disediakan oleh objek [FillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IFillFormat) yang terkait dengan objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape).
- Atur Warna garis elips.
- Atur Lebar garis elips.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan elips yang diformat ke slide pertama presentasi.

```java
// Buat instance kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe elips
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Terapkan beberapa format pada bentuk elips
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Terapkan beberapa format pada garis elips
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Tulis file PPTX ke disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana cara mengatur posisi dan ukuran tepat elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya **dalam poin**. Untuk hasil yang dapat diprediksi, dasar perhitungan Anda pada ukuran slide dan konversikan milimeter atau inci yang diperlukan ke poin sebelum menetapkan nilai.

**Bagaimana saya dapat menempatkan elips di atas atau di bawah objek lain (mengontrol urutan tumpukan)?**

Sesuaikan urutan gambar objek dengan membawanya ke depan atau mengirimnya ke belakang. Ini memungkinkan elips menutupi objek lain atau mengungkapkan yang berada di bawahnya.

**Bagaimana cara menganimasi kemunculan atau penekanan elips?**

[Terapkan](/slides/id/androidjava/shape-animation/) efek masuk, penekanan, atau keluar pada bentuk, dan atur pemicu serta timing untuk mengatur kapan dan bagaimana animasi diputar.