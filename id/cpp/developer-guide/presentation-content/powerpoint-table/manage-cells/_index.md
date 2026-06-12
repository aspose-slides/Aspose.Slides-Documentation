---
title: Kelola Sel Tabel dalam Presentasi Menggunakan C++
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/cpp/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- hapus border
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola sel tabel di PowerPoint dengan Aspose.Slides untuk C++ secara mudah. Kuasai cara mengakses, memodifikasi, dan menata sel dengan cepat untuk otomatisasi slide yang mulus."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus border sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mengambil tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Identifikasi Sel yang Digabungkan**
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Ambil tabel dari slide pertama.
3. Iterasi melalui baris dan kolom tabel untuk menemukan sel yang digabungkan.
4. Cetak pesan ketika sel yang digabungkan ditemukan.

Kode C++ berikut menunjukkan cara mengidentifikasi sel tabel yang digabungkan dalam sebuah presentasi:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// mengasumsikan bahwa Slide#0.Shape#0 adalah tabel
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Hapus Border Sel Tabel**
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tentukan array kolom dengan lebar.
4. Tentukan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode `AddTable`.
6. Iterasi melalui setiap sel untuk menghapus border atas, bawah, kanan, dan kiri.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara menghapus border dari sel tabel:

``` cpp
// Membuat instance kelas Presentation yang mewakili file PPTX
auto pres = MakeObject<Presentation>();
// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Menambahkan bentuk tabel ke slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Mengatur format border untuk setiap sel
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Menulis file PPTX ke disk
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Penomoran dalam Sel yang Digabungkan**
Jika kita menggabungkan 2 pasang sel (1, 1) x (2, 1) dan (1, 2) x (2, 2), tabel yang dihasilkan akan memiliki penomoran. Kode C# berikut mendemonstrasikan prosesnya:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Memuat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Menambahkan bentuk tabel ke slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Mengatur format border untuk setiap sel
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}
// Menggabungkan sel (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Menggabungkan sel (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Menyimpan file PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Kemudian kami menggabungkan sel lebih lanjut dengan menggabungkan (1, 1) dan (1, 2). Hasilnya adalah tabel yang berisi sel besar yang digabungkan di tengahnya:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/MergeCells_out.pptx";

// Memuat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Menambahkan bentuk tabel ke slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Mengatur format border untuk setiap sel
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// Menggabungkan sel (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Menggabungkan sel (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Menyimpan file PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Penomoran dalam Sel yang Dipisah**
Dalam contoh sebelumnya, ketika sel tabel digabungkan, penomoran atau sistem nomor pada sel lain tidak berubah.

Kali ini, kami mengambil tabel biasa (tabel tanpa sel yang digabungkan) dan kemudian mencoba memisahkan sel (1,1) untuk mendapatkan tabel khusus. Anda mungkin ingin memperhatikan penomoran tabel ini, yang mungkin terasa aneh. Namun, itulah cara Microsoft PowerPoint menomori sel tabel dan Aspose.Slides melakukan hal yang sama.

Kode C++ berikut mendemonstrasikan proses yang kami jelaskan:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/CellSplit_out.pptx";

// Memuat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Menambahkan bentuk tabel ke slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Mengatur format border untuk setiap sel
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// Menggabungkan sel (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Menggabungkan sel (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// memisahkan sel (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Menyimpan file PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ubah Warna Latar Belakang Sel Tabel**

Kode C++ berikut menunjukkan cara mengubah warna latar belakang sel tabel:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// buat tabel baru
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// atur warna latar belakang untuk sel 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Tambahkan Gambar di Dalam Sel Tabel**
1. Buat instance kelas `Presentation`.
2. Dapatkan referensi slide melalui indeksnya.
3. Tentukan array kolom dengan lebar.
4. Tentukan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode `AddTable`.
6. Buat objek `Bitmap` untuk menampung file gambar.
7. Tambahkan gambar bitmap ke objek `IPPImage`.
8. Atur `FillFormat` untuk Sel Tabel menjadi `Picture`.
9. Tambahkan gambar ke sel pertama tabel.
10. Simpan presentasi yang dimodifikasi sebagai file PPTX

Kode C# berikut menunjukkan cara menempatkan gambar di dalam sel tabel saat membuat tabel:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Memuat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Menambahkan bentuk tabel ke slide
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Mengambil gambar
auto img = Images::FromFile(ImagePath);

// Menambahkan gambar ke koleksi gambar presentasi
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Menambahkan gambar ke sel tabel pertama
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Simpan file PPTX ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Border [top](https://reference.aspose.com/slides/id/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/id/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/id/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/id/cpp/aspose.slides/cellformat/get_borderright/) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda. Hal ini logis sesuai dengan kontrol border per sisi untuk sebuah sel yang ditunjukkan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilakunya tergantung pada [fill mode](https://reference.aspose.com/slides/id/cpp/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan diri dengan sel baru; dengan tile, ubin dihitung ulang. Artikel ini menyebutkan mode tampilan gambar dalam sel.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/cpp/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian tertentu atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/id/cpp/aspose.slides/portion/) (run) dengan format independen—familir font, gaya, ukuran, dan warna.