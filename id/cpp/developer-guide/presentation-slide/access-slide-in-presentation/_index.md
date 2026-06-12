---
title: Mengakses Slide Presentasi dalam C++
linktitle: Akses Slide
type: docs
weight: 20
url: /id/cpp/access-slide-in-presentation/
keywords:
- akses slide
- indeks slide
- id slide
- posisi slide
- ubah posisi
- properti slide
- nomor slide
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengakses dan mengelola slide dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++. Tingkatkan produktivitas dengan contoh kode."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengakses dan mengelola slide dalam sebuah presentasi menggunakan Aspose.Slides. Ini menunjukkan cara mengambil slide berdasarkan indeks berbasis nol dari koleksi slide dan cara mengakses slide menggunakan ID uniknya dengan metode `GetSlideById`.

Anda juga akan belajar cara mengubah posisi slide menggunakan metode `set_SlideNumber` dan cara menetapkan nomor slide awal untuk sebuah presentasi dengan metode `set_FirstSlideNumber`. Contoh-contoh tersebut menunjukkan cara memuat presentasi, mendapatkan referensi slide, memperbarui urutan atau penomoran slide, dan menyimpan presentasi yang telah dimodifikasi.

## **Akses Slide Berdasarkan Indeks**

Semua slide dalam sebuah presentasi diatur secara numerik berdasarkan posisi slide mulai dari 0. Slide pertama dapat diakses melalui indeks 0; slide kedua dapat diakses melalui indeks 1; dan seterusnya.

Kelas Presentation, yang mewakili file presentasi, mengekspose semua slide sebagai koleksi [ISlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/) (koleksi objek [ISlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/)). Kode C++ ini menunjukkan cara mengakses slide melalui indeksnya: 

```c++
	// Jalur ke direktori dokumen.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Membuat instance kelas Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Dapatkan referensi slide melalui indeksnya
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Akses Slide Berdasarkan ID**

Setiap slide dalam sebuah presentasi memiliki ID unik yang terkait dengannya. Anda dapat menggunakan metode [GetSlideById()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/getslidebyid/) (yang diekspos oleh kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/)) untuk menargetkan ID tersebut. Kode C++ ini menunjukkan cara memberikan ID slide yang valid dan mengakses slide tersebut melalui metode [GetSlideById()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Jalur ke direktori dokumen.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Membuat instance kelas Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Mendapatkan ID slide
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Mengakses slide melalui ID-nya
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Ubah Posisi Slide**

Aspose.Slides memungkinkan Anda mengubah posisi slide. Misalnya, Anda dapat menentukan bahwa slide pertama menjadi slide kedua.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide (yang posisinya ingin Anda ubah) melalui indeksnya
1. Tetapkan posisi baru untuk slide melalui properti [set_SlideNumber()](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/set_slidenumber/). 
1. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan operasi di mana slide pada posisi 1 dipindahkan ke posisi 2:

```c++
	// Jalur ke direktori dokumen.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Membuat instance kelas Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Mendapatkan slide yang posisinya akan diubah
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Menetapkan posisi baru untuk slide
	slide->set_SlideNumber(2);

	// Menyimpan presentasi yang telah dimodifikasi
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Slide pertama menjadi yang kedua; slide kedua menjadi yang pertama. Saat Anda mengubah posisi slide, slide lain secara otomatis disesuaikan.

## **Atur Nomor Slide**

Dengan menggunakan properti [set_FirstSlideNumber()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/set_firstslidenumber/) (yang diekspos oleh kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/)), Anda dapat menentukan nomor baru untuk slide pertama dalam sebuah presentasi. Operasi ini menyebabkan nomor slide lain dihitung ulang.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan nomor slide.
1. Tetapkan nomor slide.
1. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan operasi di mana nomor slide pertama diatur menjadi 10: 

```c++
	// Jalur ke direktori dokumen.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Membuat instance kelas Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Mendapatkan nomor slide
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Menetapkan nomor slide
	pres->set_FirstSlideNumber(2);
	
	// Menyimpan presentasi yang telah dimodifikasi
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Jika Anda lebih memilih untuk melewatkan slide pertama, Anda dapat memulai penomoran dari slide kedua (dan menyembunyikan penomoran untuk slide pertama) dengan cara berikut:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah nomor slide yang dilihat pengguna sesuai dengan indeks berbasis nol pada koleksi?**

Nomor yang ditampilkan pada slide dapat dimulai dari nilai sewenang-wenang (misalnya, 10) dan tidak harus sesuai dengan indeks; hubungan tersebut dikendalikan oleh pengaturan [nomor slide pertama](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/set_firstslidenumber/) pada presentasi.

**Apakah slide tersembunyi memengaruhi pengindeksan?**

Ya. Slide yang disembunyikan tetap berada dalam koleksi dan dihitung dalam pengindeksan; “disembunyikan” mengacu pada tampilan, bukan posisinya dalam koleksi.

**Apakah indeks slide berubah ketika slide lain ditambahkan atau dihapus?**

Ya. Indeks selalu mencerminkan urutan slide saat ini dan dihitung ulang saat operasi penyisipan, penghapusan, dan pemindahan.