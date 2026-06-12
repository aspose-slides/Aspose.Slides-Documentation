---
title: Kelola Header dan Footer Presentasi di .NET
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/net/presentation-header-and-footer/
keywords:
- tajuk
- teks tajuk
- catatan kaki
- teks catatan kaki
- atur tajuk
- atur catatan kaki
- handout
- catatan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk .NET untuk menambahkan dan menyesuaikan header serta footer dalam presentasi PowerPoint dan OpenDocument agar tampilan lebih profesional."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola pengaturan header dan footer dalam presentasi PowerPoint. Header dan footer ditangani pada tingkat master presentasi, dan API menyediakan metode untuk mengatur teks footer, mengubah visibilitas footer, dan memperbarui teks header pada slide master catatan.

Anda juga dapat mengelola header dan footer untuk slide handout dan catatan. Ini termasuk mengubah visibilitas dan teks placeholder header, footer, nomor slide, dan tanggal‑waktu untuk master catatan, semua slide catatan anak, atau slide catatan individual.

## **Kelola Teks Header dan Footer**

Catatan pada slide tertentu dapat diperbarui seperti yang ditunjukkan pada contoh di bawah:

```c#
// Muat Presentasi
Presentation pres = new Presentation("headerTest.pptx");

// Menyetel Footer
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Akses dan Perbarui Header
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Simpan presentasi
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// Metode untuk mengatur Teks Header/Footer
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```

## **Kelola Header dan Footer pada Slide Handout dan Catatan**
Aspose.Slides untuk .NET mendukung Header dan Footer pada slide Handout dan catatan. Silakan ikuti langkah-langkah berikut:

- Muat sebuah [Presentation ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)yang berisi video.
- Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan.
- Setel placeholder Footer pada slide master catatan dan semua anak menjadi terlihat.
- Setel placeholder Tanggal dan waktu pada slide master catatan dan semua anak menjadi terlihat.
- Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama.
- Setel placeholder Header pada slide catatan menjadi terlihat.
- Atur teks pada placeholder Header slide catatan.
- Atur teks pada placeholder Tanggal‑waktu slide catatan.
- Tulis file presentasi yang telah dimodifikasi.

Potongan kode disediakan dalam Contoh di bawah.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // buat slide master catatan dan semua placeholder Footer anak menjadi terlihat
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // buat slide master catatan dan semua placeholder Header anak menjadi terlihat
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // buat slide master catatan dan semua placeholder SlideNumber anak menjadi terlihat
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // buat slide master catatan dan semua placeholder Tanggal dan waktu anak menjadi terlihat

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // setel teks ke slide master catatan dan semua placeholder Header anak
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // setel teks ke slide master catatan dan semua placeholder Footer anak
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // setel teks ke slide master catatan dan semua placeholder Tanggal dan waktu anak
	}

	// Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // buat placeholder Header slide catatan ini menjadi terlihat

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // buat placeholder Footer slide catatan ini menjadi terlihat

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // buat placeholder SlideNumber slide catatan ini menjadi terlihat

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // buat placeholder Date-time slide catatan ini menjadi terlihat

		headerFooterManager.SetHeaderText("New header text"); // setel teks ke placeholder Header slide catatan
		headerFooterManager.SetFooterText("New footer text"); // setel teks ke placeholder Footer slide catatan
		headerFooterManager.SetDateTimeText("New date and time text"); // setel teks ke placeholder Date-time slide catatan
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Apakah saya dapat menambahkan "header" pada slide reguler?**

Di PowerPoint, "Header" hanya ada untuk catatan dan handout; pada slide reguler, elemen yang didukung hanyalah footer, tanggal/waktu, dan nomor slide. Pada Aspose.Slides hal ini sama: header hanya untuk Catatan/Handout, dan pada slide—Footer/DateTime/SlideNumber.

**Bagaimana jika tata letak tidak memiliki area footer—apakah saya dapat "mengaktifkan" visibilitasnya?**

Ya. Periksa visibilitas melalui pengelola header/footer dan aktifkan jika diperlukan. Indikator dan metode API ini dirancang untuk situasi ketika placeholder tidak ada atau tersembunyi.

**Bagaimana cara membuat nomor slide mulai dari nilai selain 1?**

Atur [nomor slide pertama](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/firstslidenumber/); setelah itu, semua penomoran dihitung ulang. Misalnya, Anda dapat memulai dari 0 atau 10, dan menyembunyikan nomor pada slide judul.

**Apa yang terjadi pada header/footer saat mengekspor ke PDF/gambar/HTML?**

Mereka dirender sebagai elemen teks reguler dari presentasi. Artinya, jika elemen tersebut terlihat pada slide/halaman catatan, mereka juga akan muncul dalam format output bersama konten lainnya.