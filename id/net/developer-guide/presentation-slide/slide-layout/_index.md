---
title: Terapkan atau Ubah Layout Slide di .NET
linktitle: Layout Slide
type: docs
weight: 60
url: /id/net/slide-layout/
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
- header bagian
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
- C#
- .NET
- Aspose.Slides
description: "Kelola dan sesuaikan layout slide di Aspose.Slides untuk .NET. Jelajahi jenis layout, kontrol placeholder, dan visibilitas footer melalui contoh kode C#."
---
## **Pendahuluan**

Layout slide mendefinisikan susunan kotak placeholder dan pemformatan untuk konten pada sebuah slide. Ini mengontrol placeholder mana yang tersedia dan di mana mereka muncul. Layout slide membantu Anda merancang presentasi dengan cepat dan konsisten—baik Anda membuat sesuatu yang sederhana maupun yang lebih kompleks. Beberapa layout slide yang paling umum di PowerPoint meliputi:

**Layout Slide Judul** – Menyertakan dua placeholder teks: satu untuk judul dan satu untuk subjudul.

**Layout Judul dan Konten** – Menampilkan placeholder judul yang lebih kecil di bagian atas dan yang lebih besar di bawahnya untuk konten utama (seperti teks, poin peluru, grafik, gambar, dan lainnya).

**Layout Kosong** – Tidak berisi placeholder, memberi Anda kontrol penuh untuk merancang slide dari awal.

Layout slide merupakan bagian dari slide master, yang merupakan slide tingkat atas yang mendefinisikan gaya layout untuk presentasi. Anda dapat mengakses dan memodifikasi layout slide melalui slide master—baik berdasarkan tipe, nama, atau ID uniknya. Sebagai alternatif, Anda dapat mengedit layout slide tertentu langsung dalam presentasi.

Untuk bekerja dengan layout slide di Aspose.Slides for .NET, Anda dapat menggunakan:

- Properti seperti [LayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/layoutslides/) dan [Masters](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/masters/) pada kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
- Tipe seperti [ILayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutplaceholdermanager/), dan [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Untuk mempelajari lebih lanjut tentang bekerja dengan slide master, lihat artikel [Slide Master](/slides/id/net/slide-master/).
{{% /alert %}}

## **Menambahkan Layout Slide ke Presentasi**

Untuk menyesuaikan tampilan dan struktur slide Anda, Anda mungkin perlu menambahkan layout slide baru ke sebuah presentasi. Aspose.Slides for .NET memungkinkan Anda memeriksa apakah layout tertentu sudah ada, menambahkan yang baru jika diperlukan, dan menggunakannya untuk menyisipkan slide berdasarkan layout tersebut.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Akses [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterlayoutslidecollection/).
1. Periksa apakah layout slide yang diinginkan sudah ada dalam koleksi. Jika tidak, tambahkan layout slide yang diperlukan.
1. Tambahkan slide kosong berdasarkan layout slide baru.
1. Simpan presentasi.

Kode C# berikut menunjukkan cara menambahkan layout slide ke presentasi PowerPoint:

```cs
// Membuat instance kelas Presentation yang mewakili file PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Telusuri tipe layout slide untuk memilih sebuah layout slide.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Situasi di mana presentasi tidak berisi semua tipe layout.
        // File presentasi hanya berisi tipe layout Kosong dan Kustom.
        // Namun, layout slide dengan tipe kustom mungkin memiliki nama yang dikenali,
        // seperti "Title", "Title and Content", dll, yang dapat digunakan untuk pemilihan layout slide.
        // Anda juga dapat mengandalkan sekumpulan tipe bentuk placeholder.
        // Misalnya, slide Judul harus hanya memiliki tipe placeholder Title, dan seterusnya.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Tambahkan slide kosong menggunakan layout slide yang ditambahkan.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Simpan presentasi ke disk.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Menghapus Layout Slide yang Tidak Digunakan**

Aspose.Slides menyediakan metode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) dari kelas [Compress](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/) untuk memungkinkan Anda menghapus layout slide yang tidak diinginkan dan tidak digunakan.

Kode C# berikut menunjukkan cara menghapus layout slide dari presentasi PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Placeholder ke Layout Slide**

Aspose.Slides menyediakan properti [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/placeholdermanager/), yang memungkinkan Anda menambahkan placeholder baru ke sebuah layout slide.

Manajer ini berisi metode untuk tipe placeholder berikut:

| Placeholder PowerPoint              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutplaceholdermanager/) Metode |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Konten](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Konten (Vertikal)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Teks](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Teks (Vertikal)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Gambar](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png)               | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabel](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Gambar Daring](onlineimage.png)  | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Kode C# berikut menunjukkan cara menambahkan bentuk placeholder baru ke layout slide Kosong:

```cs
using (var presentation = new Presentation())
{
    // Dapatkan layout slide Kosong.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Dapatkan manajer placeholder dari layout slide.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Tambahkan berbagai placeholder ke layout slide Kosong.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Tambahkan slide baru dengan layout Kosong.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Placeholder pada layout slide](add_placeholders.png)

## **Mengatur Visibilitas Footer untuk Layout Slide**

Pada presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat ditampilkan atau disembunyikan tergantung pada layout slide. Aspose.Slides for .NET memungkinkan Anda mengontrol visibilitas placeholder footer ini. Ini berguna ketika Anda ingin layout tertentu menampilkan informasi footer sementara yang lain tetap bersih dan minimal.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi layout slide berdasarkan indeksnya.
1. Setel placeholder footer slide menjadi terlihat.
1. Setel placeholder nomor slide menjadi terlihat.
1. Setel placeholder tanggal-waktu menjadi terlihat.
1. Simpan presentasi.

Kode C# berikut menunjukkan cara mengatur visibilitas footer slide dan melakukan tugas terkait:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Mengatur Visibilitas Footer Anak untuk Slide**

Pada presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat dikontrol pada tingkat slide master untuk memastikan konsistensi di semua layout slide. Aspose.Slides for .NET memungkinkan Anda mengatur visibilitas dan konten placeholder footer ini pada slide master dan menyebarkan pengaturan tersebut ke semua layout slide anak. Pendekatan ini memastikan informasi footer yang seragam di seluruh presentasi Anda.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide master berdasarkan indeksnya.
1. Setel placeholder footer master dan semua anak menjadi terlihat.
1. Setel placeholder nomor slide master dan semua anak menjadi terlihat.
1. Setel placeholder tanggal-waktu master dan semua anak menjadi terlihat.
1. Simpan presentasi.

Kode C# berikut menunjukkan operasi ini:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apa perbedaan antara slide master dan slide layout?**

Slide master mendefinisikan tema keseluruhan dan pemformatan default, sementara slide layout mendefinisikan susunan khusus placeholder untuk berbagai jenis konten.

**Apakah saya dapat menyalin slide layout dari satu presentasi ke presentasi lain?**

Ya, Anda dapat menggandakan slide layout dari koleksi [LayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/layoutslides/) sebuah presentasi dan menyisipkannya ke presentasi lain menggunakan metode `AddClone`.

**Apa yang terjadi jika saya menghapus slide layout yang masih digunakan oleh slide lain?**

Jika Anda mencoba menghapus slide layout yang masih direferensikan oleh setidaknya satu slide dalam presentasi, Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception/). Untuk menghindarinya, gunakan [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yang secara aman menghapus hanya layout slide yang tidak digunakan.