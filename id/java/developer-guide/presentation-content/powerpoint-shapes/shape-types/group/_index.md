---
title: Bentuk Presentasi Grup dalam Java
linktitle: Grup Bentuk
type: docs
weight: 40
url: /id/java/group/
keywords:
- bentuk grup
- grup bentuk
- menambah grup
- teks alternatif
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengelompokkan dan memisahkan bentuk dalam dek PowerPoint menggunakan Aspose.Slides untuk Java—panduan cepat langkah demi langkah dengan kode Java gratis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bentuk grup di Aspose.Slides. Artikel ini menunjukkan cara menambahkan bentuk grup ke slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang diperbarui. Artikel ini juga mendemonstrasikan cara mengakses bentuk yang disimpan di dalam grup dan membaca nilai `AlternativeText`-nya. Selain itu, artikel ini secara singkat membahas kemampuan terkait bentuk grup seperti grup bersarang, urutan‑z, dan opsi penguncian.

## **Menambahkan Bentuk Grup**
Aspose.Slides mendukung kerja dengan bentuk grup pada slide. Fitur ini membantu pengembang membuat presentasi yang lebih kaya. Aspose.Slides untuk Java mendukung penambahan atau pengaksesan bentuk grup. Dimungkinkan untuk menambahkan bentuk ke bentuk grup yang telah ditambahkan untuk mengisinya atau mengakses properti apa pun dari bentuk grup. Untuk menambahkan bentuk grup ke slide menggunakan Aspose.Slides untuk Java:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan Indeks‑nya
1. Tambahkan bentuk grup ke slide.
1. Tambahkan bentuk‑bentuk ke grup yang telah ditambahkan.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan bentuk grup ke slide.

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mengakses koleksi bentuk slide
    IShapeCollection slideShapes = sld.getShapes();

    // Menambahkan bentuk grup ke slide
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Menambahkan bentuk di dalam grup yang ditambahkan
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Menambahkan bingkai bentuk grup
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Menulis file PPTX ke disk
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengakses Properti AltText**
Topik ini menunjukkan langkah‑langkah sederhana, lengkap dengan contoh kode, untuk menambahkan bentuk grup dan mengakses properti AltText dari bentuk grup pada slide. Untuk mengakses AltText dari bentuk grup dalam slide menggunakan Aspose.Slides untuk Java:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang mewakili file PPTX.
1. Dapatkan referensi slide dengan menggunakan Indeks‑nya.
1. Mengakses koleksi bentuk pada slide.
1. Mengakses bentuk grup.
1. Mengakses properti [AlternativeText](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape#getAlternativeText--) .

Contoh di bawah mengakses teks alternatif dari bentuk grup.

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Mengakses koleksi bentuk slide
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Mengakses bentuk grup.
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

Ya. [GroupShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/groupshape/) memiliki metode [getParentGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getParentGroup--) yang secara langsung menunjukkan dukungan hirarki (sebuah grup dapat menjadi anak dari grup lain).

**Bagaimana cara mengontrol urutan‑z grup relatif terhadap objek lain pada slide?**

Gunakan metode [getZOrderPosition](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getZOrderPosition--) milik [GroupShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Bisakah saya mencegah pemindahan/pengeditan/penghapusan grup?**

Ya. Bagian kunci grup diekspos melalui [GroupShapeLock](https://reference.aspose.com/slides/id/java/com.aspose.slides/groupshape/#getGroupShapeLock--), yang memungkinkan Anda membatasi operasi pada objek.