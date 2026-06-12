---
title: "Kelola Bentuk Presentasi di .NET"
linktitle: "Manipulasi Bentuk"
type: docs
weight: 40
url: /id/net/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- temukan bentuk
- klon bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan Interop Shape ID
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- ratakan bentuk
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat, mengedit, dan mengoptimalkan bentuk dalam Aspose.Slides untuk .NET serta menyajikan presentasi PowerPoint berkinerja tinggi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan bentuk dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menemukan bentuk pada slide, mengklonnya, menghapusnya, menyembunyikannya, mengubah urutannya, mendapatkan Interop shape ID, dan menetapkan teks alternatif untuk identifikasi serta pemrosesan lebih lanjut.

Artikel ini juga mencakup cara mengakses format tata letak untuk bentuk, merender bentuk sebagai SVG, meratakan bentuk pada slide, dan menggunakan properti flip untuk pencerminan horizontal dan vertikal. Selain itu, artikel ini menyertakan FAQ singkat tentang kombinasi bentuk, urutan tumpukan, dan penguncian bentuk.

## **Temukan Bentuk pada Slide**
Topik ini akan menjelaskan teknik sederhana untuk mempermudah pengembang menemukan bentuk tertentu pada slide tanpa menggunakan Id internalnya. Penting untuk diketahui bahwa file Presentasi PowerPoint tidak memiliki cara untuk mengidentifikasi bentuk pada slide kecuali Id unik internal. Hal ini tampak sulit bagi pengembang untuk menemukan bentuk menggunakan Id unik internalnya. Semua bentuk yang ditambahkan ke slide memiliki teks alternatif. Kami menyarankan pengembang untuk menggunakan teks alternatif dalam menemukan bentuk tertentu. Anda dapat menggunakan MS PowerPoint untuk menentukan teks alternatif bagi objek yang akan Anda ubah di masa mendatang.

Setelah menetapkan teks alternatif pada bentuk yang diinginkan, Anda dapat membuka presentasi tersebut menggunakan Aspose.Slides for .NET dan melakukan iterasi melalui semua bentuk yang ditambahkan ke slide. Pada setiap iterasi, Anda dapat memeriksa teks alternatif bentuk tersebut dan bentuk dengan teks alternatif yang cocok akan menjadi bentuk yang Anda butuhkan. Untuk mendemonstrasikan teknik ini dengan lebih baik, kami telah membuat metode, [FindShape](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/findshape/#findshape_1) yang melakukan hal tersebut untuk menemukan bentuk tertentu dalam slide dan kemudian mengembalikan bentuk itu.

```c#
public static void Run()
{
    // Membuat instance kelas Presentation yang mewakili file presentasi
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Teks alternatif dari bentuk yang akan dicari
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Implementasi metode untuk menemukan bentuk dalam slide menggunakan teks alternatifnya
public static IShape FindShape(ISlide slide, string alttext)
{
    // Mengiterasi semua bentuk di dalam slide
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Jika teks alternatif slide cocok dengan yang dibutuhkan maka
        // Kembalikan bentuk tersebut
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Klon Bentuk**
Untuk mengklon bentuk ke slide menggunakan Aspose.Slides for .NET:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Akses koleksi bentuk slide sumber.
1. Tambahkan slide baru ke presentasi.
1. Klon bentuk dari koleksi bentuk slide sumber ke slide baru.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan grup bentuk ke sebuah slide.

```c#
// Buat instance kelas Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Tulis file PPTX ke disk
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Hapus Bentuk**
Aspose.Slides for .NET memungkinkan pengembang menghapus bentuk apa pun. Untuk menghapus bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas `Presentation`.
1. Akses slide pertama.
1. Temukan bentuk dengan AlternativeText tertentu.
1. Hapus bentuk tersebut.
1. Simpan file ke disk.

```c#
// Buat objek Presentation
Presentation pres = new Presentation();

// Dapatkan slide pertama
ISlide sld = pres.Slides[0];

// Tambahkan autoshape tipe persegi panjang
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Simpan presentasi ke disk
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **Sembunyikan Bentuk**
Aspose.Slides for .NET memungkinkan pengembang menyembunyikan bentuk apa pun. Untuk menyembunyikan bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas `Presentation`.
1. Akses slide pertama.
1. Temukan bentuk dengan AlternativeText tertentu.
1. Sembunyikan bentuk tersebut.
1. Simpan file ke disk.

```c#
// Buat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();

// Dapatkan slide pertama
ISlide sld = pres.Slides[0];

// Tambahkan autoshape tipe persegi panjang
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Simpan presentasi ke disk
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **Ubah Urutan Bentuk**
Aspose.Slides for .NET memungkinkan pengembang mengubah urutan bentuk. Mengubah urutan bentuk menentukan bentuk mana yang berada di depan atau di belakang. Untuk mengubah urutan bentuk pada slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas `Presentation`.
1. Akses slide pertama.
1. Tambahkan sebuah bentuk.
1. Tambahkan teks ke dalam bingkai teks bentuk.
1. Tambahkan bentuk lain dengan koordinat yang sama.
1. Ubah urutan bentuk-bentuk tersebut.
1. Simpan file ke disk.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Dapatkan Interop Shape ID**
Aspose.Slides for .NET memungkinkan pengembang mendapatkan pengidentifikasi bentuk unik dalam lingkup slide, berbeda dengan properti UniqueId yang memberikan pengidentifikasi unik dalam lingkup presentasi. Properti OfficeInteropShapeId ditambahkan ke antarmuka IShape dan kelas Shape masing‑masing. Nilai yang dikembalikan oleh properti OfficeInteropShapeId sesuai dengan nilai Id dari objek Microsoft.Office.Interop.PowerPoint.Shape. Contoh kode diberikan di bawah.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Mendapatkan pengidentifikasi bentuk unik dalam lingkup slide
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **Tetapkan Teks Alternatif untuk Bentuk**
Aspose.Slides for .NET memungkinkan pengembang menetapkan AlternateText pada bentuk apa pun.  
Bentuk dalam presentasi dapat dibedakan melalui properti AlternativeText atau Shape Name.  
Properti AlternativeText dapat dibaca atau diatur menggunakan Aspose.Slides maupun Microsoft PowerPoint.  
Dengan menggunakan properti ini, Anda dapat menandai sebuah bentuk dan melakukan operasi berbeda seperti menghapus, menyembunyikan, atau mengubah urutan bentuk pada slide.  
Untuk menetapkan AlternateText pada sebuah bentuk, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas `Presentation`.
1. Akses slide pertama.
1. Tambahkan bentuk apa pun ke slide.
1. Lakukan pekerjaan dengan bentuk yang baru ditambahkan.
1. Travers bentuk‑bentuk untuk menemukan bentuk yang dimaksud.
1. Tetapkan AlternativeText.
1. Simpan file ke disk.

```c#
// Buat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();

// Dapatkan slide pertama
ISlide sld = pres.Slides[0];

// Tambahkan autoshape tipe persegi panjang
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Simpan presentasi ke disk
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Akses Format Tata Letak untuk Bentuk**
Aspose.Slides for .NET menyediakan API sederhana untuk mengakses format tata letak sebuah bentuk. Artikel ini mendemonstrasikan cara mengakses format tata letak.

Contoh kode diberikan di bawah.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Render Bentuk sebagai SVG**
Sekarang Aspose.Slides for .NET mendukung rendering bentuk sebagai SVG. Metode WriteAsSvg (serta overload‑nya) telah ditambahkan ke kelas Shape dan antarmuka IShape. Metode ini memungkinkan menyimpan konten bentuk sebagai file SVG. Potongan kode di bawah menunjukkan cara mengekspor bentuk slide ke file SVG.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **Ratakan Bentuk**

Melalui metode berlebih [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/methods/alignshapes/index), Anda dapat  

* meratakan bentuk relatif terhadap margin slide. Lihat Contoh 1.  
* meratakan bentuk relatif terhadap satu sama lain. Lihat Contoh 2.  

Enum [ShapesAlignmentType](https://reference.aspose.com/slides/id/net/aspose.slides/shapesalignmenttype) mendefinisikan opsi perataan yang tersedia.

**Contoh 1**

Kode C# ini menunjukkan cara meratakan bentuk dengan indeks 1,2, dan 4 sepanjang batas atas slide:
Kode sumber di bawah ini meratakan bentuk dengan indeks 1,2, dan 4 sepanjang batas atas slide.

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Contoh 2**

Kode C# ini menunjukkan cara meratakan seluruh koleksi bentuk relatif terhadap bentuk paling bawah dalam koleksi:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Properti Flip**

Di Aspose.Slides, kelas [ShapeFrame](https://reference.aspose.com/slides/id/net/aspose.slides/shapeframe/) menyediakan kontrol atas pencerminan horizontal dan vertikal bentuk melalui properti `FlipH` dan `FlipV`. Kedua properti bertipe [NullableBool](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/), memungkinkan nilai `True` untuk mengindikasikan flip, `False` untuk tidak flip, atau `NotDefined` untuk menggunakan perilaku default. Nilai‑nilai ini dapat diakses melalui [Frame](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/frame/) bentuk.

Untuk mengubah pengaturan flip, sebuah instance baru [ShapeFrame](https://reference.aspose.com/slides/id/net/aspose.slides/shapeframe/) dibangun dengan posisi dan ukuran saat ini dari bentuk, nilai yang diinginkan untuk `FlipH` dan `FlipV`, serta sudut rotasi. Menetapkan instance ini ke [Frame](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/frame/) bentuk dan menyimpan presentasi akan menerapkan transformasi cermin dan menuliskannya ke file output.

Misalkan kita memiliki file sample.pptx yang slide pertamanya berisi satu bentuk dengan pengaturan flip default, seperti ditunjukkan di bawah.

![The shape to be flipped](shape_to_be_flipped.png)

Contoh kode berikut mengambil properti flip bentuk saat ini dan membaliknya baik secara horizontal maupun vertikal.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Mengambil properti flip horizontal dari bentuk.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Mengambil properti flip vertikal dari bentuk.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Flip secara horizontal.
    NullableBool flipV = NullableBool.True; // Flip secara vertikal.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Bisakah saya menggabungkan bentuk (union/intersect/subtract) pada slide seperti di editor desktop?**

Tidak ada API operasi Boolean bawaan. Anda dapat mendekatinya dengan membangun outline yang diinginkan secara manual—misalnya menghitung geometri hasil (melalui [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath/)) dan membuat bentuk baru dengan kontur tersebut, serta opsional menghapus yang asli.

**Bagaimana saya dapat mengontrol urutan tumpukan (z-order) sehingga sebuah bentuk selalu berada di “atas”?**

Ubah urutan penyisipan/perpindahan dalam koleksi [shapes](https://reference.aspose.com/slides/id/net/aspose.slides/baseslide/shapes/) slide. Untuk hasil yang dapat diprediksi, finalisasi z-order setelah semua modifikasi slide lainnya selesai.

**Bisakah saya “mengunci” sebuah bentuk agar pengguna tidak dapat mengeditnya di PowerPoint?**

Ya. Tetapkan [flag perlindungan tingkat bentuk](/slides/id/net/applying-protection-to-presentation/) (misalnya kunci pemilihan, pergerakan, pengubahan ukuran, atau pengeditan teks). Jika diperlukan, terapkan pembatasan pada master atau tata letak. Perlu diketahui bahwa ini adalah perlindungan level UI, bukan fitur keamanan; untuk perlindungan yang lebih kuat, gabungkan dengan pembatasan level file seperti rekomendasi baca‑saja atau kata sandi [/slides/id/net/password-protected-presentation/](/slides/id/net/password-protected-presentation/).