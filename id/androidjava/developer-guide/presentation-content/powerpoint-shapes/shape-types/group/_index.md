---
title: Grup Bentuk Presentasi di Android
linktitle: Grup Bentuk
type: docs
weight: 40
url: /id/androidjava/group/
keywords:
- grup bentuk
- bentuk grup
- tambah grup
- teks alternatif
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengelompokkan dan memisahkan bentuk dalam deck PowerPoint menggunakan Aspose.Slides untuk Android—panduan cepat langkah demi langkah dengan kode Java gratis."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan grup bentuk di Aspose.Slides. Artikel ini menunjukkan cara menambahkan grup bentuk ke slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang diperbarui. Artikel ini juga mendemonstrasikan cara mengakses bentuk yang disimpan di dalam grup dan membaca nilai `AlternativeText`-nya. Selain itu, artikel ini secara singkat mencakup kemampuan grup-bentuk terkait seperti grup bersarang, urutan z, dan opsi penguncian.

## **Menambahkan Grup Bentuk**
Aspose.Slides mendukung pekerjaan dengan grup bentuk pada slide. Fitur ini membantu pengembang membuat presentasi yang lebih kaya. Aspose.Slides untuk Android via Java mendukung penambahan atau akses grup bentuk. Dimungkinkan untuk menambahkan bentuk ke grup bentuk yang telah ditambahkan untuk mengisinya atau mengakses properti apa pun dari grup bentuk. Untuk menambahkan grup bentuk ke slide menggunakan Aspose.Slides untuk Android via Java:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan Indeksnya
1. Tambahkan grup bentuk ke slide.
1. Tambahkan bentuk ke grup bentuk yang telah ditambahkan.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan grup bentuk ke slide.

```java
// Instansiasi kelas Presentation
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mengakses koleksi bentuk pada slide
    IShapeCollection slideShapes = sld.getShapes();

    // Menambahkan grup bentuk ke slide
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Menambahkan bentuk di dalam grup bentuk yang ditambahkan
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Menambahkan bingkai grup bentuk
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Menulis file PPTX ke disk
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengakses Properti AltText**
Topik ini menunjukkan langkah-langkah sederhana, lengkap dengan contoh kode, untuk menambahkan grup bentuk dan mengakses properti AltText dari grup bentuk pada slide. Untuk mengakses AltText dari grup bentuk di slide menggunakan Aspose.Slides untuk Android via Java:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang mewakili file PPTX.
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Mengakses koleksi bentuk pada slide.
1. Mengakses grup bentuk.
1. Mengakses properti [AlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getAlternativeText--).

Contoh di bawah mengakses teks alternatif dari grup bentuk.

```java
// Instansiasi kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Mengakses koleksi bentuk pada slide
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Mengakses grup bentuk.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Mengakses properti AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah pengelompokan bersarang (grup di dalam grup) didukung?**

Ya. [GroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/groupshape/) memiliki metode [getParentGroup](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getParentGroup--) yang secara langsung menunjukkan dukungan hierarki (sebuah grup dapat menjadi anak dari grup lain).

**Bagaimana cara mengontrol urutan z grup relatif terhadap objek lain pada slide?**

Gunakan metode [getZOrderPosition](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getZOrderPosition--) milik [GroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Bisakah saya mencegah pemindahan/pengeditan/pembongkaran grup?**

Ya. Bagian kunci grup dapat diakses melalui [getGroupShapeLock](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) yang memungkinkan Anda membatasi operasi pada objek.