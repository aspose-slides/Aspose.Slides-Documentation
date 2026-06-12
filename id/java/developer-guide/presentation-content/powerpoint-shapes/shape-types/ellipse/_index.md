---
title: Menambahkan Elips ke Presentasi dengan Java
linktitle: Elips
type: docs
weight: 30
url: /id/java/ellipse/
keywords:
- elips
- bentuk
- tambahkan elips
- buat elips
- gambar elips
- elips yang diformat
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips di Aspose.Slides untuk Java pada presentasi PPT dan PPTX—contoh kode Java disertakan."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan elips sederhana, pembuatan elips yang diformat, dan menyimpan presentasi yang telah diperbarui sebagai file PPTX. Artikel ini juga menyentuh pertanyaan terkait seperti bekerja dengan posisi dan ukuran elips, mengontrol urutan tumpukan, dan menerapkan efek animasi.

## **Buat Ellipse**
Untuk menambahkan elips sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang tersedia pada objek [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan sebuah elips ke slide pertama

```java
// Buat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Ambil slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tambahkan AutoShape tipe elips
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Tulis file PPTX ke disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Buat Ellipse yang Diformat**
Untuk menambahkan elips yang diformat dengan lebih baik ke slide, ikuti langkah‑langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang tersedia pada objek [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).
- Atur Fill Type elips menjadi Solid.
- Atur Warna elips menggunakan properti SolidFillColor.Color yang tersedia pada objek [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/IFillFormat) yang terkait dengan objek [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape).
- Atur Warna garis elips.
- Atur Lebar garis elips.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan elips yang diformat ke slide pertama presentasi.

```java
// Buat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Ambil slide pertama
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

**Bagaimana cara mengatur posisi dan ukuran tepat sebuah elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya ditentukan **dalam poin**. Untuk hasil yang dapat diprediksi, lakukan perhitungan berdasarkan ukuran slide dan konversikan milimeter atau inci yang diperlukan ke poin sebelum menetapkan nilainya.

**Bagaimana saya dapat menempatkan elips di atas atau di bawah objek lain (mengontrol urutan tumpukan)?**

Sesuaikan urutan gambar objek dengan membawanya ke depan atau mengirimnya ke belakang. Ini memungkinkan elips menutupi objek lain atau memperlihatkan yang berada di bawahnya.

**Bagaimana cara memberi animasi pada tampilan atau penekanan sebuah elips?**

[Apply](/slides/id/java/shape-animation/) efek masuk, penekanan, atau keluar pada shape, dan atur pemicu serta waktu untuk mengatur kapan dan bagaimana animasi dijalankan.