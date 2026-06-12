---
title: Kelola Bentuk Presentasi dalam C++
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/cpp/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- cari bentuk
- gandakan bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan Interop Shape ID
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- jajarkan bentuk
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membuat, mengedit, dan mengoptimalkan bentuk di Aspose.Slides untuk C++ serta menghasilkan presentasi PowerPoint berperforma tinggi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bentuk dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menemukan bentuk pada slide, menggandakannya, menghapusnya, menyembunyikannya, mengubah urutannya, mendapatkan Interop shape ID, dan menetapkan teks alternatif untuk identifikasi serta pemrosesan lebih lanjut.

Artikel ini juga membahas cara mengakses format tata letak untuk bentuk, merender bentuk sebagai SVG, menyelaraskan bentuk pada slide, dan menggunakan properti flip untuk pencerminan horizontal dan vertikal. Selain itu, artikel ini menyertakan FAQ singkat tentang penggabungan bentuk, urutan tumpukan, dan penguncian bentuk.

## **Temukan Bentuk pada Slide**
Topik ini akan menjelaskan teknik sederhana untuk memudahkan pengembang menemukan bentuk tertentu pada slide tanpa menggunakan Id internalnya. Penting untuk diketahui bahwa file Presentasi PowerPoint tidak memiliki cara lain untuk mengidentifikasi bentuk pada slide kecuali Id unik internal. Bagi pengembang, menemukan bentuk menggunakan Id unik internal dapat menjadi sulit. Semua bentuk yang ditambahkan ke slide memiliki beberapa Teks Alt. Kami menyarankan pengembang untuk menggunakan teks alternatif untuk menemukan bentuk tertentu. Anda dapat menggunakan MS PowerPoint untuk menentukan teks alternatif bagi objek yang akan Anda ubah di masa mendatang.

Setelah menetapkan teks alternatif pada bentuk yang diinginkan, Anda dapat membuka presentasi tersebut menggunakan Aspose.Slides untuk C++ dan menelusuri semua bentuk yang ditambahkan ke slide. Pada setiap iterasi, Anda dapat memeriksa teks alternatif bentuk tersebut dan bentuk dengan teks alternatif yang cocok akan menjadi bentuk yang Anda perlukan. Untuk mendemonstrasikan teknik ini dengan lebih baik, kami telah membuat metode [FindShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) yang melakukan pencarian bentuk tertentu dalam slide dan kemudian mengembalikan bentuk tersebut.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Gandakan Bentuk**
Untuk menggandakan bentuk ke slide menggunakan Aspose.Slides untuk C++:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Akses koleksi bentuk pada slide sumber.
4. Tambahkan slide baru ke presentasi.
5. Gandakan bentuk dari koleksi bentuk slide sumber ke slide baru.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan bentuk grup ke sebuah slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Hapus Bentuk**
Aspose.Slides untuk C++ memungkinkan pengembang menghapus bentuk apa pun. Untuk menghapus bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Akses slide pertama.
3. Temukan bentuk dengan AlternativeText tertentu.
4. Hapus bentuk tersebut.
5. Simpan file ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Sembunyikan Bentuk**
Aspose.Slides untuk C++ memungkinkan pengembang menyembunyikan bentuk apa pun. Untuk menyembunyikan bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Akses slide pertama.
3. Temukan bentuk dengan AlternativeText tertentu.
4. Sembunyikan bentuk tersebut.
5. Simpan file ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Ubah Urutan Bentuk**
Aspose.Slides untuk C++ memungkinkan pengembang mengubah urutan bentuk. Mengubah urutan bentuk menentukan bentuk mana yang berada di depan atau di belakang. Untuk mengubah urutan bentuk pada slide mana pun, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Akses slide pertama.
3. Tambahkan sebuah bentuk.
4. Tambahkan beberapa teks ke dalam frame teks bentuk tersebut.
5. Tambahkan bentuk lain dengan koordinat yang sama.
6. Ubah urutan bentuk-bentuk tersebut.
7. Simpan file ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Dapatkan Interop Shape ID**
Aspose.Slides untuk C++ memungkinkan pengembang mendapatkan pengidentifikasi bentuk unik dalam ruang lingkup slide, berbeda dengan properti UniqueId yang memberikan pengidentifikasi unik dalam ruang lingkup presentasi. Properti OfficeInteropShapeId ditambahkan ke antarmuka IShape dan kelas Shape. Nilai yang dikembalikan oleh properti OfficeInteropShapeId sesuai dengan nilai Id dari objek Microsoft.Office.Interop.PowerPoint.Shape. Berikut contoh kode yang diberikan.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Atur Properti AlternativeText**
Aspose.Slides untuk C++ memungkinkan pengembang mengatur AlternateText pada bentuk apa pun. Untuk mengatur AlternateText suatu bentuk, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Akses slide pertama.
3. Tambahkan bentuk apa pun ke slide.
4. Lakukan beberapa pekerjaan dengan bentuk yang baru ditambahkan.
5. Telusuri bentuk-bentuk untuk menemukan bentuk yang diinginkan.
6. Atur AlternativeText.
7. Simpan file ke disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Akses Format Tata Letak untuk Bentuk**
Aspose.Slides untuk C++ memungkinkan pengembang mengakses format tata letak untuk sebuah bentuk. Artikel ini menunjukkan cara mengakses properti **FillFormat** dan **LineFormat** untuk sebuah bentuk.

Berikut contoh kode yang diberikan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Render Bentuk sebagai SVG**
Sekarang Aspose.Slides untuk C++ mendukung rendering bentuk sebagai SVG. Metode WriteAsSvg (dan overload‑nya) telah ditambahkan ke kelas Shape dan antarmuka IShape. Metode ini memungkinkan menyimpan konten bentuk sebagai file SVG. Potongan kode di bawah menunjukkan cara mengekspor bentuk slide ke file SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Penjajaran Bentuk**
Aspose.Slides memungkinkan penjajaran bentuk baik relatif terhadap margin slide maupun relatif terhadap satu sama lain. Untuk tujuan ini, metode overload [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) telah ditambahkan. Enumerasi [ShapesAlignmentType](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) mendefinisikan opsi penjajaran yang tersedia.

**Contoh 1**

Kode sumber di bawah ini menjajarkan bentuk dengan indeks 1, 2, dan 4 sepanjang batas atas slide.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Contoh 2**

Contoh di bawah ini menunjukkan cara menjajarkan seluruh koleksi bentuk relatif terhadap bentuk paling bawah dalam koleksi.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Properti Flip**

Di Aspose.Slides, kelas [ShapeFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapeframe/) menyediakan kontrol atas pencerminan horizontal dan vertikal bentuk melalui properti `flipH` dan `flipV`. Kedua properti tersebut bertipe [NullableBool](https://reference.aspose.com/slides/id/cpp/aspose.slides/nullablebool/), yang memungkinkan nilai `True` untuk menandakan pencerminan, `False` untuk tidak mencerminkan, atau `NotDefined` untuk menggunakan perilaku default. Nilai‑nilai ini dapat diakses dari [Frame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_frame/) bentuk.

Untuk mengubah pengaturan flip, sebuah instance baru [ShapeFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapeframe/) dibangun dengan posisi dan ukuran bentuk saat ini, nilai yang diinginkan untuk `flipH` dan `flipV`, serta sudut rotasi. Menetapkan instance ini ke [Frame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_frame/) bentuk dan menyimpan presentasi akan menerapkan transformasi cermin dan menyimpannya ke file output.

Misalkan kita memiliki file sample.pptx di mana slide pertama berisi satu bentuk dengan pengaturan flip default, seperti terlihat di bawah.

![Bentuk yang akan diputar](shape_to_be_flipped.png)

Contoh kode berikut mengambil properti flip bentuk saat ini dan membaliknya baik secara horizontal maupun vertikal.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Ambil properti flip horizontal dari bentuk.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Ambil properti flip vertikal dari bentuk.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Balik secara horizontal.
auto flipV = NullableBool::True; // Balik secara horizontal.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Bentuk yang diputar](flipped_shape.png)

## **FAQ**

**Apakah saya dapat menggabungkan bentuk (union/intersect/subtract) pada slide seperti di editor desktop?**

Tidak ada API operasi Boolean bawaan. Anda dapat mendekatinya dengan membangun kontur yang diinginkan secara manual—misalnya menghitung geometri hasil (via [GeometryPath](https://reference.aspose.com/slides/id/cpp/aspose.slides/geometrypath/)) dan membuat bentuk baru dengan kontur tersebut, opsional menghapus yang asli.

**Bagaimana cara mengontrol urutan tumpukan (z-order) sehingga sebuah bentuk selalu berada di “atas”?**

Ubah urutan penyisipan/perpindahan dalam koleksi [shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseslide/get_shapes/) slide. Untuk hasil yang dapat diprediksi, selesaikan z-order setelah semua modifikasi slide selesai.

**Bisakah saya “mengunci” sebuah bentuk agar pengguna tidak dapat mengeditnya di PowerPoint?**

Ya. Atur flag perlindungan tingkat bentuk [/slides/id/cpp/applying-protection-to-presentation/] (misalnya mengunci pemilihan, pergerakan, pengubahan ukuran, penyuntingan teks). Jika diperlukan, terapkan pembatasan serupa pada master atau layout. Perlu diketahui bahwa ini adalah perlindungan tingkat UI, bukan fitur keamanan; untuk perlindungan yang lebih kuat, kombinasikan dengan pembatasan tingkat file seperti rekomendasi baca‑saja atau kata sandi [/slides/id/cpp/password-protected-presentation/].