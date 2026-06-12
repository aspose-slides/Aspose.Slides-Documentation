---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint Menggunakan C++
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/cpp/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- gandakan baris
- gandakan kolom
- salin baris
- salin kolom
- hapus baris
- hapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola baris dan kolom tabel di PowerPoint dengan Aspose.Slides untuk C++ dan percepat penyuntingan presentasi serta pembaruan data."
---
## **Pendahuluan**

Untuk memungkinkan Anda mengelola baris dan kolom tabel dalam presentasi PowerPoint, Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/) , antarmuka [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) , dan banyak tipe lainnya. 

## **Menetapkan Baris Pertama sebagai Header**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi. 
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) dan setel ke null. 
4. Iterasi semua objek [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) untuk menemukan tabel yang relevan. 
5. Setel baris pertama tabel sebagai headernya. 

Kode C++ berikut menunjukkan cara menyetel baris pertama tabel sebagai headernya:

```c++
// Membuat instance kelas Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Menginisialisasi TableEx yang null
SharedPtr<ITable> tbl;

// Mengiterasi shape-shape dan menetapkan referensi ke tabel
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Menetapkan baris pertama tabel sebagai headernya 
tbl->set_FirstRow(true);
```

## **Menggandakan Baris atau Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array `columnWidth`. 
4. Definisikan array `rowHeight`. 
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) ke slide melalui metode [AddTable()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addtable/). 
6. Gandakan baris tabel. 
7. Gandakan kolom tabel. 
8. Simpan presentasi yang telah dimodifikasi. 

Kode C++ berikut menunjukkan cara menggandakan baris atau kolom tabel PowerPoint:

```c++
 // Jalur ke direktori dokumen.
const String outPath = u"../out/CloningInTable_out.pptx";

// Membuat instance kelas Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Menentukan kolom dengan lebar dan baris dengan tinggi
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Menambahkan shape tabel ke slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Menetapkan format border untuk setiap sel
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone menambahkan baris di akhir tabel
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone menambahkan baris pada posisi tertentu dalam tabel
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone menambahkan kolom di akhir tabel
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone menambahkan kolom pada posisi tertentu dalam tabel
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Menyimpan presentasi ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Menghapus Baris atau Kolom dari Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array `columnWidth`. 
4. Definisikan array `rowHeight`. 
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) ke slide melalui metode [AddTable()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addtable/). 
6. Hapus baris tabel. 
7. Hapus kolom tabel. 
8. Simpan presentasi yang telah dimodifikasi. 

Kode C++ berikut menunjukkan cara menghapus baris atau kolom dari tabel:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Membuat instance kelas Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Mengakses slide pertama
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Menentukan kolom dengan lebar dan baris dengan tinggi
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Menambahkan shape tabel ke slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Menggabungkan sel (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Menggabungkan sel (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Menyimpan presentasi ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Mengatur Pemformatan Teks pada Tingkat Baris Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) yang relevan dari slide. 
4. Setel [set_FontHeight()](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_fontheight/) pada sel baris pertama. 
5. Setel [set_Alignment()](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_alignment/) dan [set_MarginRight()](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_marginright/) pada sel baris pertama. 
6. Setel [set_TextVerticalType()](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframeformat/set_textverticaltype/) pada sel baris kedua. 
7. Simpan presentasi yang telah dimodifikasi. 

Kode C++ berikut mendemonstrasikan operasi tersebut.

```c++
// Membuat instance kelas Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Misalkan shape pertama pada slide pertama adalah tabel
// Menetapkan tinggi font sel baris pertama
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Menetapkan perataan teks dan margin kanan sel baris pertama
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Menetapkan tipe vertikal teks sel baris kedua
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Menyimpan presentasi ke disk
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Mengatur Pemformatan Teks pada Tingkat Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) yang relevan dari slide. 
4. Setel [set_FontHeight()](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_fontheight/) pada sel kolom pertama. 
5. Setel [set_Alignment()](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_alignment/) dan [set_MarginRight()](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_marginright/) pada sel kolom pertama. 
6. Setel [set_TextVerticalType()](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframeformat/set_textverticaltype/) pada sel kolom kedua. 
7. Simpan presentasi yang telah dimodifikasi. 

Kode C++ berikut mendemonstrasikan operasi tersebut: 

```c++
// Membuat instance kelas Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Misalkan shape pertama pada slide pertama adalah tabel

// Menetapkan tinggi font sel kolom pertama
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Menetapkan perataan teks dan margin kanan sel kolom pertama dalam satu panggilan
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Menetapkan tipe vertikal teks sel kolom kedua
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Mendapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut untuk tabel lain atau di tempat lain. Kode C++ berikut menunjukkan cara mendapatkan properti gaya dari gaya bawaan tabel:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda masih dapat menimpa isi, batas, dan warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, kemudian isi kembali baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom berpola (bergaris) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom berpola, lalu timpa sel tertentu dengan pemformatan lokal; pemformatan pada tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.