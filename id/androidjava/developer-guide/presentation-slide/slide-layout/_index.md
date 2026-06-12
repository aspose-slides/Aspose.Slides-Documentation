---
title: Terapkan atau Ubah Tata Letak Slide di Android
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/androidjava/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- header bagian
- dua konten
- perbandingan
- hanya judul
- tata letak kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola dan sesuaikan tata letak slide di Aspose.Slides untuk Android. Jelajahi jenis tata letak, kontrol placeholder, dan visibilitas footer melalui contoh kode Java."
---
## **Pendahuluan**

Sebuah tata letak slide mendefinisikan susunan kotak placeholder dan pemformatan untuk konten pada slide. Tata letak mengontrol placeholder yang tersedia dan lokasi penampilannya. Tata letak slide membantu Anda merancang presentasi dengan cepat dan konsisten—baik saat membuat sesuatu yang sederhana maupun yang lebih kompleks. Beberapa tata letak slide yang paling umum di PowerPoint meliputi:

**Title Slide layout** – Menyertakan dua placeholder teks: satu untuk judul dan satu untuk subjudul.

**Title and Content layout** – Menampilkan placeholder judul yang lebih kecil di bagian atas dan placeholder yang lebih besar di bawahnya untuk konten utama (seperti teks, poin-poin, bagan, gambar, dan lainnya).

**Blank layout** – Tidak berisi placeholder, memberi Anda kontrol penuh untuk merancang slide dari awal.

Tata letak slide merupakan bagian dari slide master, yaitu slide tingkat atas yang mendefinisikan gaya tata letak untuk keseluruhan presentasi. Anda dapat mengakses dan memodifikasi slide tata letak melalui slide master—baik berdasarkan tipe, nama, atau ID unik. Atau, Anda dapat menyunting slide tata letak tertentu secara langsung di dalam presentasi.

Untuk bekerja dengan tata letak slide di Aspose.Slides for Android, Anda dapat menggunakan:

- Metode seperti [getLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) dan [getMasters](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getMasters--) pada kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/)
- Tipe seperti [ILayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), dan [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Untuk mempelajari lebih lanjut tentang cara kerja slide master, lihat artikel [Slide Master](/slides/id/androidjava/slide-master/).
{{% /alert %}}

## **Menambahkan Tata Letak Slide ke Presentasi**

Untuk menyesuaikan tampilan dan struktur slide Anda, Anda mungkin perlu menambahkan slide tata letak baru ke sebuah presentasi. Aspose.Slides for Android memungkinkan Anda memeriksa apakah tata letak tertentu sudah ada, menambahkan yang baru bila diperlukan, dan menggunakannya untuk menyisipkan slide berdasarkan tata letak tersebut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Akses [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Periksa apakah slide tata letak yang diinginkan sudah ada dalam koleksi. Jika tidak, tambahkan slide tata letak yang diperlukan.
1. Tambahkan slide kosong berdasarkan slide tata letak baru.
1. Simpan presentasi.

Kode Java berikut menunjukkan cara menambahkan tata letak slide ke presentasi PowerPoint:

```java
// Membuat instance kelas Presentation yang mewakili file PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Menelusuri tipe slide tata letak untuk memilih slide tata letak.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Situasi di mana presentasi tidak berisi semua tipe tata letak.
        // File presentasi hanya berisi tipe tata letak Blank dan Custom.
        // Namun, slide tata letak dengan tipe khusus mungkin memiliki nama yang dapat dikenali,
        // seperti "Title", "Title and Content", dll., yang dapat digunakan untuk pemilihan slide tata letak.
        // Anda juga dapat mengandalkan sekumpulan tipe bentuk placeholder.
        // Misalnya, slide Title seharusnya hanya memiliki tipe placeholder Title, dan seterusnya.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Tambahkan slide kosong menggunakan slide tata letak yang telah ditambahkan.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Simpan presentasi ke disk.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menghapus Slide Tata Letak yang Tidak Digunakan**

Aspose.Slides menyediakan metode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) dari kelas [Compress](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/) untuk memungkinkan Anda menghapus slide tata letak yang tidak diinginkan dan tidak terpakai.

Kode Java berikut memperlihatkan cara menghapus slide tata letak dari presentasi PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menambahkan Placeholder ke Tata Letak Slide**

Aspose.Slides menyediakan metode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) yang memungkinkan Anda menambahkan placeholder baru ke sebuah slide tata letak.

Manajer ini berisi metode untuk tipe placeholder berikut:

| Placeholder PowerPoint              | Metode [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Kode Java berikut memperlihatkan cara menambahkan bentuk placeholder baru ke slide tata letak Blank:

```java
Presentation presentation = new Presentation();
try {
    // Dapatkan slide tata letak Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Dapatkan manajer placeholder dari slide tata letak.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Tambahkan berbagai placeholder ke slide tata letak Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Tambahkan slide baru dengan tata letak Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![The placeholders on the layout slide](add_placeholders.png)

## **Mengatur Visibilitas Footer untuk Slide Tata Letak**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat ditampilkan atau disembunyikan tergantung pada tata letak slide. Aspose.Slides for Android memungkinkan Anda mengontrol visibilitas placeholder footer ini. Ini berguna ketika Anda ingin tata letak tertentu menampilkan informasi footer sementara yang lain tetap bersih dan minimal.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan referensi slide tata letak berdasarkan indeksnya.
1. Atur placeholder footer slide menjadi terlihat.
1. Atur placeholder nomor slide menjadi terlihat.
1. Atur placeholder tanggal-waktu menjadi terlihat.
1. Simpan presentasi.

Kode Java berikut menunjukkan cara mengatur visibilitas footer slide dan melakukan tugas terkait:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Mengatur Visibilitas Footer Anak untuk Slide**

​Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat dikontrol pada tingkat slide master untuk memastikan konsistensi di semua slide tata letak. Aspose.Slides for Android memungkinkan Anda mengatur visibilitas dan konten placeholder footer pada slide master dan menyebarkan pengaturan ini ke semua slide tata letak anak. Pendekatan ini memastikan informasi footer yang seragam di seluruh presentasi.​

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide master berdasarkan indeksnya.
1. Atur semua placeholder footer pada master dan semua anak menjadi terlihat.
1. Atur semua placeholder nomor slide pada master dan semua anak menjadi terlihat.
1. Atur semua placeholder tanggal-waktu pada master dan semua anak menjadi terlihat.
1. Simpan presentasi.

Kode Java berikut memperlihatkan operasi tersebut:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa perbedaan antara slide master dan slide tata letak?**

Slide master mendefinisikan tema keseluruhan dan pemformatan default, sementara slide tata letak mendefinisikan susunan spesifik placeholder untuk berbagai jenis konten.

**Apakah saya dapat menyalin slide tata letak dari satu presentasi ke presentasi lain?**

Ya, Anda dapat mengkloning slide tata letak dari koleksi slide tata letak sebuah presentasi, yang dapat diakses melalui metode [getLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), dan menyisipkannya ke presentasi lain menggunakan metode `addClone`.

**Apa yang terjadi jika saya menghapus slide tata letak yang masih digunakan oleh slide lain?**

Jika Anda mencoba menghapus slide tata letak yang masih direferensikan oleh setidaknya satu slide dalam presentasi, Aspose.Slides akan melemparkan [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/). Untuk menghindarinya, gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yang secara aman menghapus hanya slide tata letak yang tidak digunakan.