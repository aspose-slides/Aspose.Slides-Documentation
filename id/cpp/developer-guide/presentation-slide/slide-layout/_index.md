---
title: Terapkan atau Ubah Layout Slide di C++
linktitle: Layout Slide
type: docs
weight: 60
url: /id/cpp/slide-layout/
keywords:
- layout slide
- layout konten
- placeholder
- desain presentasi
- desain slide
- layout tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- header seksi
- dua konten
- perbandingan
- hanya judul
- layout kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kelola dan sesuaikan layout slide di Aspose.Slides untuk C++. Jelajahi jenis layout, kontrol placeholder, dan visibilitas footer melalui contoh kode C++."
---
## **Pendahuluan**

Layout slide mendefinisikan pengaturan kotak placeholder dan pemformatan untuk konten pada slide. Itu mengontrol placeholder mana yang tersedia dan di mana mereka muncul. Layout slide membantu Anda merancang presentasi dengan cepat dan konsisten—baik Anda membuat sesuatu yang sederhana maupun lebih kompleks. Beberapa layout slide paling umum di PowerPoint meliputi:

**Title Slide layout** – Menyertakan dua placeholder teks: satu untuk judul dan satu untuk subjudul.

**Title and Content layout** – Menampilkan placeholder judul yang lebih kecil di bagian atas dan yang lebih besar di bawahnya untuk konten utama (seperti teks, poin-poin, bagan, gambar, dan lainnya).

**Blank layout** – Tidak mengandung placeholder, memberi Anda kontrol penuh untuk merancang slide dari awal.

Layout slide merupakan bagian dari slide master, yang merupakan slide tingkat atas yang mendefinisikan gaya layout untuk presentasi. Anda dapat mengakses dan memodifikasi layout slide melalui slide master—baik berdasarkan tipe, nama, atau ID uniknya. Atau, Anda dapat mengedit layout slide tertentu langsung di dalam presentasi.

Untuk bekerja dengan layout slide di Aspose.Slides for Android, Anda dapat menggunakan:

- Metode seperti [get_LayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_layoutslides/) dan [get_Masters](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_masters/) di bawah kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) 
- Tipe seperti [ILayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutplaceholdermanager/), dan [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Untuk mempelajari lebih lanjut tentang bekerja dengan master slide, lihat artikel [Slide Master](/slides/id/cpp/slide-master/).
{{% /alert %}}

## **Menambahkan Layout Slide ke Presentasi**

Untuk menyesuaikan tampilan dan struktur slide Anda, mungkin Anda perlu menambahkan layout slide baru ke sebuah presentasi. Aspose.Slides for Android memungkinkan Anda memeriksa apakah layout tertentu sudah ada, menambahkan yang baru jika diperlukan, dan menggunakannya untuk menyisipkan slide berdasarkan layout tersebut.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Akses [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Periksa apakah layout slide yang diinginkan sudah ada dalam koleksi. Jika tidak, tambahkan layout slide yang Anda butuhkan.
1. Tambahkan slide kosong berdasarkan layout slide baru.
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara menambahkan layout slide ke presentasi PowerPoint:

```cpp
// Membuat instance kelas Presentation yang mewakili file PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Situasi di mana presentasi tidak berisi semua tipe layout.
    // File presentasi hanya berisi tipe layout Blank dan Custom.
    // Namun, layout slide dengan tipe khusus mungkin memiliki nama yang dapat dikenali,
    // seperti "Title", "Title and Content", dll., yang dapat digunakan untuk memilih layout slide.
    // Anda juga dapat mengandalkan sekumpulan tipe bentuk placeholder.
    // Misalnya, slide Title seharusnya hanya memiliki tipe placeholder Title, dan seterusnya.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Tambahkan slide kosong menggunakan layout slide yang ditambahkan.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Simpan presentasi ke disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Menghapus Layout Slide yang Tidak Digunakan**

Aspose.Slides menyediakan metode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) dari kelas [Compress](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/) untuk memungkinkan Anda menghapus layout slide yang tidak diinginkan dan tidak terpakai.

Kode C++ berikut menunjukkan cara menghapus layout slide dari presentasi PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Menambahkan Placeholder ke Layout Slide**

Aspose.Slides menyediakan metode [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) yang memungkinkan Anda menambahkan placeholder baru ke layout slide.

Manajer ini berisi metode untuk tipe placeholder berikut:

| Placeholder PowerPoint | [ILayoutPlaceholderManager] Metode |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Kode C++ berikut menunjukkan cara menambahkan bentuk placeholder baru ke layout slide Blank:

```cpp
auto presentation = MakeObject<Presentation>();

// Dapatkan layout slide Blank.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Get the placeholder manager of the layout slide.
auto placeholderManager = layout->get_PlaceholderManager();

// Add different placeholders to the Blank layout slide.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Placeholder pada layout slide](add_placeholders.png)

## **Mengatur Visibilitas Footer untuk Layout Slide**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat ditampilkan atau disembunyikan tergantung pada layout slide. Aspose.Slides for Android memungkinkan Anda mengontrol visibilitas placeholder footer ini. Hal ini berguna ketika Anda ingin layout tertentu menampilkan informasi footer sementara yang lain tetap bersih dan minimal.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi layout slide berdasarkan indeknya.
1. Setel placeholder footer slide menjadi terlihat.
1. Setel placeholder nomor slide menjadi terlihat.
1. Setel placeholder tanggal-waktu menjadi terlihat.
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara mengatur visibilitas footer slide dan melakukan tugas terkait:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengatur Visibilitas Footer Anak untuk Slide**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat dikontrol pada tingkat master slide untuk memastikan konsistensi di semua layout slide. Aspose.Slides for Android memungkinkan Anda menetapkan visibilitas dan konten placeholder footer ini pada master slide dan menyebarkan pengaturan tersebut ke semua layout slide anak. Pendekatan ini memastikan informasi footer yang seragam di seluruh presentasi Anda.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke master slide berdasarkan indeknya.
1. Setel placeholder footer master dan semua child menjadi terlihat.
1. Setel placeholder nomor slide master dan semua child menjadi terlihat.
1. Setel placeholder tanggal-waktu master dan semua child menjadi terlihat.
1. Simpan presentasi.

Kode C++ berikut menunjukkan operasi ini:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apa perbedaan antara master slide dan layout slide?**

Master slide mendefinisikan tema keseluruhan dan pemformatan default, sedangkan layout slide menentukan pengaturan spesifik placeholder untuk berbagai jenis konten.

**Apakah saya dapat menyalin layout slide dari satu presentasi ke yang lain?**

Ya, Anda dapat mengkloning layout slide dari koleksi layout slide sebuah presentasi, yang dapat diakses melalui metode [get_LayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_layoutslides/), dan menyisipkannya ke presentasi lain menggunakan metode `AddClone`.

**Apa yang terjadi jika saya menghapus layout slide yang masih digunakan oleh slide?**

Jika Anda mencoba menghapus layout slide yang masih direferensikan oleh setidaknya satu slide dalam presentasi, Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxeditexception/). Untuk menghindarinya, gunakan [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yang secara aman menghapus hanya layout slide yang tidak digunakan.