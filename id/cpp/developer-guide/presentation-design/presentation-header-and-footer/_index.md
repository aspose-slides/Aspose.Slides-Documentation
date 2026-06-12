---
title: Kelola Header dan Footer Presentasi dalam C++
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/cpp/presentation-header-and-footer/
keywords:
- header
- teks header
- footer
- teks footer
- atur header
- atur footer
- handout
- catatan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk C++ untuk menambahkan dan menyesuaikan header serta footer di presentasi PowerPoint dan OpenDocument agar tampilan profesional."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengelola pengaturan header dan footer dalam presentasi PowerPoint. Header dan footer ditangani pada tingkat master presentasi, dan API menyediakan metode untuk mengatur teks footer, mengubah visibilitas footer, dan memperbarui teks header pada slide catatan master.

Anda juga dapat mengelola header dan footer untuk slide handout dan catatan. Ini mencakup mengubah visibilitas dan teks placeholder header, footer, nomor slide, dan tanggal-waktu untuk master catatan, semua slide catatan anak, atau slide catatan tunggal.

## **Kelola Teks Header dan Footer**

Catatan pada beberapa slide tertentu dapat diperbarui seperti yang ditunjukkan pada contoh di bawah ini:

``` cpp
// Fungsi untuk mengatur Teks Header/Footer
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Muat Presentasi
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Mengatur Footer
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Akses dan Perbarui Header
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Simpan presentasi
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Kelola Header dan Footer pada Slide Handout dan Catatan**
Aspose.Slides untuk C++ mendukung Header dan Footer pada slide Handout dan catatan. Silakan ikuti langkah-langkah di bawah ini:

- Muat sebuah [Presentation ](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation)yang berisi video.
- Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan.
- Jadikan placeholder Footer pada master catatan dan semua anaknya terlihat.
- Jadikan placeholder Tanggal dan waktu pada master catatan dan semua anaknya terlihat.
- Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama.
- Atur placeholder Header pada slide catatan menjadi terlihat.
- Atur teks pada placeholder Header slide catatan.
- Atur teks pada placeholder Tanggal-waktu slide catatan.
- Tulis file presentasi yang telah dimodifikasi.

Potongan kode disediakan pada Contoh di bawah ini.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// buat slide catatan master dan semua placeholder Footer anak terlihat
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// buat slide catatan master dan semua placeholder Header anak terlihat
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// buat slide catatan master dan semua placeholder NomorSlide anak terlihat
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// buat slide catatan master dan semua placeholder Tanggal dan waktu anak terlihat
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// setel teks ke slide catatan master dan semua placeholder Header anak
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// setel teks ke slide catatan master dan semua placeholder Footer anak
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// setel teks ke slide catatan master dan semua placeholder Tanggal dan waktu anak
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// buat placeholder Header slide catatan ini terlihat
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// buat placeholder Footer slide catatan ini terlihat
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// buat placeholder NomorSlide slide catatan ini terlihat
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// buat placeholder Tanggal-waktu slide catatan ini terlihat
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// setel teks ke placeholder Header slide catatan
	headerFooterManager->SetHeaderText(u"New header text");
	// setel teks ke placeholder Footer slide catatan
	headerFooterManager->SetFooterText(u"New footer text");
	// setel teks ke placeholder Tanggal-waktu slide catatan
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat menambahkan "header" pada slide reguler?**

Di PowerPoint, “Header” hanya ada untuk catatan dan handout; pada slide reguler, elemen yang didukung adalah footer, tanggal/waktu, dan nomor slide. Di Aspose.Slides hal ini memiliki batasan yang sama: header hanya untuk Notes/Handout, dan pada slide—Footer/DateTime/SlideNumber.

**Bagaimana jika tata letak tidak memiliki area footer—apakah saya dapat “mengaktifkan” visibilitasnya?**

Ya. Periksa visibilitas melalui manajer header/footer dan aktifkan jika diperlukan. Indikator dan metode API ini dirancang untuk situasi ketika placeholder tidak ada atau disembunyikan.

**Bagaimana cara membuat nomor slide dimulai dari nilai selain 1?**

Atur [nomor slide pertama](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/set_firstslidenumber/) pada presentasi; setelah itu, semua penomoran dihitung ulang. Misalnya, Anda dapat memulai dari 0 atau 10, dan menyembunyikan nomor pada slide judul.

**Apa yang terjadi pada header/footer saat mengekspor ke PDF/gambar/HTML?**

Mereka dirender sebagai elemen teks biasa dalam presentasi. Artinya, jika elemen tersebut terlihat pada slide/halaman catatan, mereka juga akan muncul dalam format output bersama konten lainnya.