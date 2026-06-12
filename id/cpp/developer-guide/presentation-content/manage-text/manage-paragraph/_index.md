---
title: Kelola Paragraf Teks PowerPoint dalam C++
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/cpp/manage-paragraph/
keywords:
- tambah teks
- tambah paragraf
- kelola teks
- kelola paragraf
- kelola bullet
- inden paragraf
- inden gantung
- bullet paragraf
- daftar bernomor
- daftar bullet
- properti paragraf
- impor HTML
- teks ke HTML
- paragraf ke HTML
- paragraf ke gambar
- teks ke gambar
- ekspor paragraf
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasi pemformatan paragraf dengan Aspose.Slides untuk C++—optimalkan perataan, spasi & gaya dalam presentasi PPT, PPTX, dan ODP di C++."
---
## **Pendahuluan**

Aspose.Slides menyediakan semua antarmuka dan kelas yang Anda perlukan untuk bekerja dengan teks PowerPoint, paragraf, dan bagian‑bagian (portions) dalam C++.

* Aspose.Slides menyediakan antarmuka [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) untuk memungkinkan Anda menambahkan objek yang mewakili sebuah paragraf. Sebuah objek `ITextFame` dapat memiliki satu atau beberapa paragraf (setiap paragraf dibuat melalui pengembalian karriage).
* Aspose.Slides menyediakan antarmuka [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/) untuk memungkinkan Anda menambahkan objek yang mewakili bagian‑bagian. Sebuah objek `IParagraph` dapat memiliki satu atau beberapa bagian (koleksi objek iPortions).
* Aspose.Slides menyediakan antarmuka [IPortion](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/) untuk memungkinkan Anda menambahkan objek yang mewakili teks dan properti formatnya. 

Sebuah objek `IParagraph` dapat menangani teks dengan properti format berbeda melalui objek `IPortion` yang mendasarinya.

## **Menambahkan Beberapa Paragraf yang Memuat Beberapa Bagian**

Langkah‑langkah berikut menunjukkan cara menambahkan sebuah text frame yang berisi 3 paragraf dan setiap paragraf berisi 3 bagian:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) persegi panjang ke slide.
4. Dapatkan ITextFrame yang terkait dengan [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/).
5. Buat dua objek [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/) dan tambahkan ke koleksi `IParagraphs` dari [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/).
6. Buat tiga objek [IPortion](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/) untuk setiap `IParagraph` baru (dua objek Portion untuk Paragraph default) dan tambahkan setiap objek `IPortion` ke koleksi IPortion masing‑masing `IParagraph`.
7. Tetapkan teks untuk setiap bagian.
8. Terapkan fitur format yang Anda inginkan ke setiap bagian menggunakan properti format yang disediakan oleh objek `IPortion`.
9. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini merupakan implementasi langkah‑langkah menambahkan paragraf yang memuat bagian‑bagian:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Muat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Akses slide pertama
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Tambahkan AutoShape tipe Persegi Panjang
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Tambahkan TextFrame ke Persegi Panjang
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Mengakses Paragraf pertama
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Menambahkan Paragraf kedua
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Menambahkan Paragraf ketiga
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Simpan PPTX ke Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Mengelola Bullet Paragraf**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf yang diberi bullet selalu lebih mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dari autoshape. 
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraph/).
7. Atur `Type` bullet untuk paragraf menjadi `Symbol` dan tentukan karakter bullet.
8. Atur `Text` paragraf.
9. Atur `Indent` paragraf untuk bullet.
10. Tetapkan warna untuk bullet.
11. Tetapkan tinggi bullet.
12. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
13. Tambahkan paragraf kedua dan ulangi proses pada langkah 7 sampai 13.
14. Simpan presentasi.

Kode C++ ini menunjukkan cara menambahkan bullet paragraf:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Muat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Akses slide pertama
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Tambahkan AutoShape tipe Persegi Panjang
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Tambahkan TextFrame ke Persegi Panjang
ashp->AddTextFrame(u"");

// Mengakses frame teks
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Buat objek Paragraph untuk frame teks
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Mengatur Teks
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Mengatur indent bullet
paragraph->get_ParagraphFormat()->set_Indent (25);

// Mengatur warna bullet
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// set IsBulletHardColor ke true untuk menggunakan warna bullet sendiri
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Mengatur Tinggi Bullet
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Menambahkan Paragraph ke frame teks
txtFrame->get_Paragraphs()->Add(paragraph);

// Membuat paragraf kedua
// Buat objek Paragraph untuk frame teks
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Mengatur Teks
paragraph2->set_Text(u"This is numbered bullet");

// Mengatur tipe dan gaya bullet paragraf
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Mengatur indent bullet
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Mengatur warna bullet
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// set IsBulletHardColor ke true untuk menggunakan warna bullet sendiri
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Mengatur Tinggi Bullet
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Menambahkan Paragraph ke frame teks
txtFrame->get_Paragraphs()->Add(paragraph2);


// Simpan PPTX ke Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Mengelola Bullet Gambar**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf gambar mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dari autoshape. 
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraph/).
7. Muat gambar ke dalam [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/).
8. Atur tipe bullet menjadi [Picture](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dan tetapkan gambar.
9. Atur `Text` Paragraph.
10. Atur `Indent` Paragraph untuk bullet.
11. Tetapkan warna untuk bullet.
12. Tetapkan tinggi bullet.
13. Tambahkan paragraf baru ke koleksi paragraf `TextFrame`.
14. Tambahkan paragraf kedua dan ulangi proses berdasarkan langkah‑langkah sebelumnya.
15. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara menambahkan dan mengelola bullet gambar:

```c++
// Membuat instance kelas Presentation yang mewakili file PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Mengakses slide pertama
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Membuat instance gambar untuk bullet
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Menambahkan dan mengakses Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Mengakses textframe autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Menghapus paragraf default
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Membuat paragraf baru
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Menetapkan gaya bullet paragraf dan gambar
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Menetapkan Tinggi bullet
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Menambahkan paragraf ke text frame
paragraphs->Add(paragraph);

// Menulis presentasi sebagai file PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Menulis presentasi sebagai file PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Mengelola Bullet Bertingkat (Multilevel)**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Bullet bertingkat mudah dibaca dan dipahami.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide baru.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dari autoshape. 
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraph/) dan atur kedalaman menjadi 0.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur kedalaman menjadi 1.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur kedalaman menjadi 2.
9. Buat instance paragraf keempat melalui kelas `Paragraph` dan atur kedalaman menjadi 3.
10. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame`.
11. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara menambahkan dan mengelola bullet bertingkat:

```c++
// Membuat instance kelas Presentation yang mewakili file PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Mengakses slide pertama
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Menambahkan dan mengakses Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Mengakses text frame autoshape yang dibuat
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Membersihkan paragraf default
text->get_Paragraphs()->Clear();

// Menambahkan paragraf pertama
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Menetapkan tingkat bullet
para1Format->set_Depth(0);

// Menambahkan paragraf kedua
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Menetapkan tingkat bullet
para2Format->set_Depth(1);

// Menambahkan paragraf ketiga
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Menetapkan tingkat bullet
para3Format->set_Depth(2);

// Menambahkan paragraf keempat
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Menetapkan tingkat bullet
para4Format->set_Depth(3);

// Menambahkan paragraf ke koleksi
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Menulis presentasi sebagai file PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Mengelola Paragraf dengan Daftar Nomor Kustom**

Antarmuka [IBulletFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/) menyediakan properti [NumberedBulletStartWith](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) dan lainnya yang memungkinkan Anda mengelola paragraf dengan penomoran atau format kustom.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses slide yang berisi paragraf tersebut.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dari autoshape. 
5. Hapus paragraf default di dalam `TextFrame`.
6. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraph/) dan atur [NumberedBulletStartWith](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) ke 2.
7. Buat instance paragraf kedua melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` ke 3.
8. Buat instance paragraf ketiga melalui kelas `Paragraph` dan atur `NumberedBulletStartWith` ke 7.
9. Tambahkan paragraf‑paragraf baru ke koleksi paragraf `TextFrame`.
10. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara menambahkan dan mengelola paragraf dengan penomoran atau format kustom:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Mengakses text frame dari autoshape yang dibuat
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Menghapus paragraf default yang ada
textFrame->get_Paragraphs()->RemoveAt(0);

// Daftar pertama
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **Mengatur Inden Baris Pertama untuk Paragraf**

Gunakan metode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_indent/) untuk mengontrol inden baris pertama sebuah paragraf. Metode ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris lain tetap sejajar dengan isi paragraf.

Gunakan [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_marginleft/) bila Anda perlu memindahkan seluruh paragraf. Gunakan [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_indent/) bila Anda hanya perlu memindahkan baris pertama.

Contoh di bawah membuat beberapa paragraf dan menerapkan nilai `Indent` yang berbeda untuk mendemonstrasikan bagaimana inden baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/autoshape/) persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [Indent](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_indent/) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf‑paragraf ke text frame.
7. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur inden paragraf:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Mengatur Inden Gantung (Hanging Indent) untuk Paragraf**

Inden gantung adalah tata letak paragraf di mana baris pertama mulai lebih ke kiri daripada baris‑baris berikutnya. Di Aspose.Slides, Anda membuat efek ini dengan metode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_indent/). Atur inden ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap isi paragraf.

Secara praktis, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_marginleft/) menentukan posisi kiri isi paragraf, dan [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_indent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat inden gantung, atur nilai `MarginLeft` positif dan nilai `Indent` negatif.

Format ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris yang dibungkus harus sejajar di bawah isi paragraf bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/autoshape/) persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat paragraf‑paragraf dan atur nilai [MarginLeft](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_marginleft/) positif untuk masing‑masing.
6. Atur nilai [Indent](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_indent/) negatif untuk menciptakan efek inden gantung.
7. Tambahkan paragraf‑paragraf ke text frame.
8. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur inden gantung untuk paragraf:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Mengelola Properti End Paragraph Run**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide yang berisi paragraf melalui posisinya.
1. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) persegi panjang ke slide.
1. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dengan dua paragraf ke persegi panjang.
1. Atur `FontHeight` dan jenis Font untuk paragraf‑paragraf.
1. Atur properti End untuk paragraf‑paragraf.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C++ ini menunjukkan cara mengatur properti End untuk paragraf dalam PowerPoint:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Muat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Akses slide pertama
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Tambahkan AutoShape tipe Persegi Panjang
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Tambahkan TextFrame ke Persegi Panjang
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Menambahkan Paragraf pertama
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Menambahkan Paragraf kedua
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Simpan PPTX ke Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Mengimpor Teks HTML ke dalam Paragraf**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengimpor teks HTML ke dalam paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Akses referensi slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [autoshape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
4. Tambahkan dan akses `autoshape` [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) 
5. Hapus paragraf default di dalam `ITextFrame`.
6. Baca file HTML sumber dengan TextReader.
7. Buat instance paragraf pertama melalui kelas [Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraph/).
8. Tambahkan konten file HTML yang dibaca oleh TextReader ke [ParagraphCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraphcollection/) TextFrame.
9. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini merupakan implementasi langkah‑langkah mengimpor teks HTML ke dalam paragraf:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Jalur ke direktori dokumen.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Muat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Akses slide pertama
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Tambahkan AutoShape tipe Persegi Panjang
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Mengatur ulang warna isi default
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Tambahkan TextFrame ke Persegi Panjang
ashp->AddTextFrame(u" ");

// Mengakses text frame
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Dapatkan koleksi Paragraphs
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Menghapus semua paragraf di text frame yang ditambahkan
ParaCollection->Clear();

// Memuat file HTML menggunakan stream reader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Menambahkan teks dari stream reader HTML ke text frame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Buat objek Paragraph untuk text frame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Buat objek Portion untuk paragraf
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Dapatkan format portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Atur Font untuk Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Atur properti Bold pada Font
pf->set_FontBold(NullableBool::True);

// Atur properti Italic pada Font
pf->set_FontItalic(NullableBool::True);

// Atur properti Underline pada Font
pf->set_FontUnderline(TextUnderlineType::Single);

// Atur Tinggi Font
pf->set_FontHeight(25);

// Atur warna Font
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Simpan PPTX ke Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Mengekspor Teks Paragraf ke HTML**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengekspor teks (yang terdapat dalam paragraf) ke format HTML.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses referensi slide yang relevan melalui indeksnya.
3. Akses shape yang berisi teks yang akan diekspor ke HTML.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) shape.
5. Buat instance `StreamWriter` dan tambahkan file HTML baru.
6. Berikan indeks mulai ke StreamWriter dan ekspor paragraf‑paragraf yang Anda inginkan.

Kode C++ ini menunjukkan cara mengekspor teks paragraf PowerPoint ke HTML:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Jalur ke direktori dokumen.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Muat presentasi yang diinginkan
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Akses slide pertama default dari presentasi
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Indeks yang diinginkan
int index = 0;

// Mengakses shape yang ditambahkan
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Mengekstrak paragraf pertama sebagai HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Menulis data Paragraf ke HTML dengan memberikan indeks awal paragraf, total paragraf yang akan disalin
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Menyimpan Paragraf sebagai Gambar**

Di bagian ini, kami akan mengeksplorasi dua contoh yang menunjukkan cara menyimpan sebuah paragraf teks, yang direpresentasikan oleh antarmuka [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/), sebagai gambar. Kedua contoh mencakup memperoleh gambar shape yang berisi paragraf menggunakan metode `GetImage` dari antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/), menghitung batas paragraf di dalam shape, dan mengekspornya sebagai gambar bitmap. Pendekatan ini memungkinkan Anda mengekstrak bagian‑bagian tertentu dari teks dalam presentasi PowerPoint dan menyimpannya sebagai gambar terpisah, yang berguna untuk berbagai skenario.

Misalkan kita memiliki file presentasi bernama **sample.pptx** dengan satu slide, di mana shape pertama adalah sebuah text box yang berisi tiga paragraf.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Contoh 1**

Dalam contoh ini, kami memperoleh paragraf kedua sebagai gambar. Untuk melakukannya, kami mengekstrak gambar shape dari slide pertama presentasi, lalu menghitung batas paragraf kedua dalam text frame shape tersebut. Paragraf kemudian digambar ulang pada bitmap baru, yang disimpan dalam format PNG. Metode ini sangat berguna ketika Anda perlu menyimpan paragraf tertentu sebagai gambar terpisah sambil mempertahankan dimensi dan format teks yang tepat.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Simpan shape di memori sebagai bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Hasilnya:

![The paragraph image](paragraph_to_image_output.png)

**Contoh 2**

Dalam contoh ini, kami memperluas pendekatan sebelumnya dengan menambahkan faktor skala pada gambar paragraf. Shape diekstrak dari presentasi dan disimpan sebagai gambar dengan faktor skala `2`. Hal ini memungkinkan output resolusi lebih tinggi saat mengekspor paragraf. Batas paragraf kemudian dihitung dengan mempertimbangkan skala. Skala dapat sangat berguna ketika diperlukan gambar yang lebih detail, misalnya untuk materi cetak berkualitas tinggi.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Simpan shape di memori sebagai bitmap dengan skala.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Buat bitmap shape dari memori.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Hitung batas paragraf kedua.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Hitung ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Siapkan bitmap untuk paragraf.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Gambar ulang paragraf dari bitmap shape ke bitmap paragraf.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**Apakah saya dapat menonaktifkan pembungkusan baris secara keseluruhan di dalam text frame?**

Ya. Gunakan metode pembungkusan text frame ([set_WrapText](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframeformat/set_wraptext/)) untuk mematikan pembungkusan sehingga baris tidak terputus di tepi frame.

**Bagaimana cara mendapatkan batas tepat di slide untuk paragraf tertentu?**

Anda dapat mengambil persegi panjang batas paragraf (bahkan untuk satu portion) untuk mengetahui posisi dan ukuran tepatnya pada slide.

**Di mana pengaturan perataan paragraf (kiri/kanan/tengah/justify) dikontrol?**

[Alignment](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraphformat/set_alignment/) adalah pengaturan tingkat paragraf di [ParagraphFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraphformat/); ia berlaku untuk seluruh paragraf terlepas dari format portion individu.

**Apakah saya dapat mengatur bahasa pemeriksa ejaan hanya untuk bagian tertentu dari paragraf (misalnya satu kata)?**

Ya. Bahasa diatur pada tingkat portion menggunakan ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_languageid/)), sehingga beberapa bahasa dapat hidup berdampingan dalam satu paragraf.