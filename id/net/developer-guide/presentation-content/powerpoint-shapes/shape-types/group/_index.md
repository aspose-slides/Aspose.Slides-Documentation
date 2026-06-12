---
title: Bentuk Presentasi Grup di .NET
linktitle: Grup Bentuk
type: docs
weight: 40
url: /id/net/group/
keywords:
- bentuk grup
- grup bentuk
- tambahkan grup
- teks alternatif
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelompokkan dan memisahkan bentuk dalam deck PowerPoint menggunakan Aspose.Slides untuk .NET—panduan cepat langkah demi langkah dengan kode C# gratis."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan bentuk grup di Aspose.Slides. Artikel ini menunjukkan cara menambahkan bentuk grup ke slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga mendemonstrasikan cara mengakses bentuk yang disimpan di dalam grup dan membaca nilai `AlternativeText`-nya. Selain itu, artikel ini secara singkat membahas kemampuan terkait bentuk grup seperti grup bersarang, z-order, dan opsi penguncian.

## **Menambahkan Bentuk Grup**
Aspose.Slides mendukung kerja dengan bentuk grup pada slide. Fitur ini membantu pengembang membuat presentasi yang lebih kaya. Aspose.Slides untuk .NET mendukung penambahan atau akses bentuk grup. Dimungkinkan untuk menambahkan bentuk ke dalam bentuk grup yang telah ditambahkan untuk mengisinya atau mengakses properti apa pun dari bentuk grup. Untuk menambahkan bentuk grup ke slide menggunakan Aspose.Slides untuk .NET:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan Index-nya
1. Tambahkan bentuk grup ke slide.
1. Tambahkan bentuk-bentuk ke dalam bentuk grup yang telah ditambahkan.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan bentuk grup ke slide.

```c#
// Membuat instance kelas Presentation 
using (Presentation pres = new Presentation())
{
    // Ambil slide pertama 
    ISlide sld = pres.Slides[0];

    // Mengakses koleksi shape slide 
    IShapeCollection slideShapes = sld.Shapes;

    // Menambahkan shape grup ke slide 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Menambahkan shape ke dalam grup yang ditambahkan 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Menambahkan frame shape grup 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Menulis file PPTX ke disk 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **Mengakses Properti AltText**
Topik ini menunjukkan langkah-langkah sederhana, lengkap dengan contoh kode, untuk menambahkan bentuk grup dan mengakses properti AltText dari bentuk grup pada slide. Untuk mengakses AltText dari bentuk grup di slide menggunakan Aspose.Slides untuk .NET:

1. Instansiasi kelas `Presentation` yang merepresentasikan file PPTX.
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Akses koleksi shape slide.
1. Akses bentuk grup.
1. Akses properti AltText.

Contoh di bawah mengakses teks alternatif dari bentuk grup.

```c#
// Membuat instance kelas Presentation yang merepresentasikan file PPTX
Presentation pres = new Presentation("AltText.pptx");

// Ambil slide pertama
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Mengakses koleksi shape slide
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Mengakses shape grup.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Mengakses properti AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**Apakah pengelompokan bersarang (grup di dalam grup) didukung?**

Ya. [GroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/groupshape/) memiliki properti [ParentGroup](https://reference.aspose.com/slides/id/net/aspose.slides/shape/parentgroup/), yang secara langsung menunjukkan dukungan hierarki (sebuah grup dapat menjadi anak dari grup lain).

**Bagaimana cara mengontrol z-order grup relatif terhadap objek lain pada slide?**

Gunakan properti [ZOrderPosition](https://reference.aspose.com/slides/id/net/aspose.slides/shape/zorderposition/) milik [GroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Apakah saya dapat mencegah pemindahan/pengeditan/pembongkaran grup?**

Ya. bagian kunci grup dapat diakses melalui [GroupShapeLock](https://reference.aspose.com/slides/id/net/aspose.slides/groupshape/groupshapelock/), yang memungkinkan Anda membatasi operasi pada objek tersebut.