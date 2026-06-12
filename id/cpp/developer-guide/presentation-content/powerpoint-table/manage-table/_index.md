---
title: "Mengelola Tabel Presentasi dalam C++"
linktitle: "Kelola Tabel"
type: docs
weight: 10
url: /id/cpp/manage-table/
keywords:
- "menambahkan tabel"
- "membuat tabel"
- "akses tabel"
- "rasio aspek"
- "menyelaraskan teks"
- "pemformatan teks"
- "gaya tabel"
- "PowerPoint"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk C++. Temukan contoh kode sederhana untuk menyederhanakan alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint merupakan cara yang efisien untuk menampilkan dan menggambarkan informasi. Informasi dalam kisi sel (disusun dalam baris dan kolom) bersifat langsung dan mudah dipahami.

Aspose.Slides menyediakan kelas [Tabel](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/), antarmuka [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/), kelas [Cell](https://reference.aspose.com/slides/id/cpp/aspose.slides/cell/), antarmuka [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/) , dan tipe lain untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam berbagai presentasi. 

## **Membuat Tabel dari Awal**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Definisikan array `columnWidth`.  
4. Definisikan array `rowHeight`.  
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) ke slide melalui metode [AddTable()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addtable/).  
6. Iterasi melalui setiap [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/) untuk menerapkan format pada batas atas, bawah, kanan, dan kiri.  
7. Gabungkan dua sel pertama pada baris pertama tabel.  
8. Akses [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/) milik sebuah [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/).  
9. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/).  
10. Simpan presentasi yang telah dimodifikasi.

Kode C++ berikut menunjukkan cara membuat tabel dalam presentasi:

```c++
// Membuat instance kelas Presentation yang mewakili file PPTX
auto pres = System::MakeObject<Presentation>();

// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Menambahkan shape tabel ke slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Mengatur format batas untuk setiap sel
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// Menggabungkan sel 1 dan 2 pada baris 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Menambahkan teks ke sel yang digabungkan
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Menyimpan presentasi ke disk
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, penomoran sel bersifat langsung dan dimulai dari nol. Sel pertama dalam tabel diindeks sebagai 0,0 (kolom 0, baris 0). 

Sebagai contoh, sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor seperti berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode C++ berikut menunjukkan cara menentukan penomoran untuk sel dalam tabel:

```c++
// Membuat instance kelas Presentation yang mewakili file PPTX
auto pres = System::MakeObject<Presentation>();

// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Menambahkan shape tabel ke slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Mengatur format batas untuk setiap sel
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// Menyimpan presentasi ke disk
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Mengakses Tabel yang Sudah Ada**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).  

2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya.  

3. Buat objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) dan atur menjadi null.  

4. Iterasi melalui semua objek [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) hingga tabel ditemukan.  

   Jika Anda menduga slide yang sedang Anda tangani hanya berisi satu tabel, Anda dapat memeriksa semua bentuk yang ada di dalamnya. Ketika sebuah bentuk diidentifikasi sebagai tabel, Anda dapat melakukan typecast menjadi objek [Table](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/). Namun jika slide tersebut berisi beberapa tabel, sebaiknya cari tabel yang Anda perlukan melalui metode [set_AlternativeText()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_alternativetext/).  

5. Gunakan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) untuk bekerja dengan tabel. Pada contoh di bawah, kami menambahkan baris baru ke tabel.  

6. Simpan presentasi yang telah dimodifikasi.  

Kode C++ berikut menunjukkan cara mengakses dan bekerja dengan tabel yang sudah ada:

```c++
// Membuat instance kelas Presentation yang mewakili file PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Menginisialisasi Table null
System::SharedPtr<ITable> tbl;

// Mengiterasi bentuk-bentuk dan menetapkan referensi ke tabel yang ditemukan
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Mengatur teks untuk kolom pertama baris kedua
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Menyimpan presentasi yang telah dimodifikasi ke disk
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Menyelaraskan Teks dalam Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) ke slide.  
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dari tabel.  
5. Akses [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/) milik [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/).  
6. Selaraskan teks secara vertikal.  
7. Simpan presentasi yang telah dimodifikasi.  

Kode C++ berikut menunjukkan cara menyelaraskan teks dalam tabel:

```c++
// Membuat instance kelas Presentation
auto presentation = System::MakeObject<Presentation>();

// Mendapatkan slide pertama 
auto slide = presentation->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Menambahkan shape tabel ke slide
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Mengakses text frame
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Membuat objek Paragraph untuk text frame
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Membuat objek Portion untuk paragraf
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Menyelaraskan teks secara vertikal
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Menyimpan Presentation ke disk
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```


## **Menerapkan Pemformatan Teks pada Tingkat Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) dari slide.  
4. Atur [set_FontHeight()](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_fontheight/) untuk teks.  
5. Atur [set_Alignment()](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_alignment/) dan [set_MarginRight()](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_marginright/).  
6. Atur [set_TextVerticalType()](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframeformat/set_textverticaltype/).  
7. Simpan presentasi yang telah dimodifikasi.  

Kode C++ berikut menunjukkan cara menerapkan opsi pemformatan pilihan Anda pada teks dalam tabel:

```c++
// Membuat instance kelas Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Asumsikan bahwa shape pertama pada slide pertama adalah tabel
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Mengatur tinggi font sel tabel
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Mengatur perataan teks sel tabel dan margin kanan dalam satu panggilan
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Mengatur tipe vertikal teks sel tabel
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Mendapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga dapat digunakan pada tabel lain atau di tempat lain. Kode C++ berikut menunjukkan cara mendapatkan properti gaya dari gaya tabel preset:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Mengunci Rasio Aspek Tabel**

Rasio aspek sebuah bentuk geometris adalah perbandingan ukuran dalam dimensi yang berbeda. Aspose.Slides menyediakan properti `AspectRatioLocked()` untuk memungkinkan Anda mengunci pengaturan rasio aspek pada tabel dan bentuk lainnya. 

Kode C++ berikut menunjukkan cara mengunci rasio aspek untuk sebuah tabel:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks di dalam selnya?**

Ya. Tabel menyediakan metode [set_RightToLeft](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/set_righttoleft/), dan paragraf memiliki [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraphformat/set_righttoleft/). Menggunakan keduanya memastikan urutan RTL yang tepat serta rendering di dalam sel.

**Bagaimana cara mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](/slides/id/cpp/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku pada tabel.

**Apakah penyisipan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/cpp/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).