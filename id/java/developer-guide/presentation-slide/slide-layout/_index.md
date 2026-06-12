---
title: Terapkan atau Ubah Tata Letak Slide di Java
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/java/slide-layout/
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
- presentation
- Java
- Aspose.Slides
description: "Kelola dan sesuaikan tata letak slide di Aspose.Slides untuk Java. Jelajahi jenis tata letak, kontrol placeholder, dan visibilitas footer melalui contoh kode Java."
---
## **Pendahuluan**

Tata letak slide mendefinisikan susunan kotak placeholder dan pemformatan untuk konten pada slide. Tata letak ini mengontrol placeholder apa yang tersedia dan di mana mereka muncul. Tata letak slide membantu Anda merancang presentasi dengan cepat dan konsisten—baik saat membuat sesuatu yang sederhana maupun yang lebih kompleks. Beberapa tata letak slide yang paling umum di PowerPoint meliputi:

**Tata letak Slide Judul** – Menyertakan dua placeholder teks: satu untuk judul dan satu untuk subjudul.

**Tata letak Judul dan Konten** – Menampilkan placeholder judul yang lebih kecil di bagian atas dan yang lebih besar di bawahnya untuk konten utama (seperti teks, poin-poin, bagan, gambar, dan lainnya).

**Tata letak Kosong** – Tidak berisi placeholder, memberi Anda kebebasan penuh untuk merancang slide dari awal.

Tata letak slide merupakan bagian dari slide master, yang merupakan slide tingkat atas yang menentukan gaya tata letak untuk seluruh presentasi. Anda dapat mengakses dan memodifikasi slide tata letak melalui slide master—baik berdasarkan tipe, nama, atau ID unik. Atau, Anda dapat mengedit tata letak slide tertentu secara langsung di dalam presentasi.

Untuk bekerja dengan tata letak slide di Aspose.Slides for Java, Anda dapat menggunakan:

- Metode seperti [getLayoutSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getLayoutSlides--) dan [getMasters](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getMasters--) pada kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/)
- Tipe seperti [ILayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/), dan [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}Untuk mempelajari lebih lanjut tentang bekerja dengan slide master, lihat artikel [Slide Master](/slides/id/java/slide-master/).{{% /alert %}}

## **Menambahkan Tata Letak Slide ke Presentasi**

Untuk menyesuaikan tampilan dan struktur slide Anda, mungkin perlu menambahkan slide tata letak baru ke sebuah presentasi. Aspose.Slides for Java memungkinkan Anda memeriksa apakah sebuah tata letak tertentu sudah ada, menambahkan yang baru bila diperlukan, dan menggunakannya untuk menyisipkan slide berdasarkan tata letak tersebut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Akses [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Periksa apakah slide tata letak yang diinginkan sudah ada dalam koleksi. Jika belum, tambahkan slide tata letak yang diperlukan.
1. Tambahkan slide kosong berdasarkan tata letak baru tersebut.
1. Simpan presentasi.

Kode Java berikut memperlihatkan cara menambahkan tata letak slide ke sebuah presentasi PowerPoint:

```java
// Membuat instance kelas Presentation yang mewakili file PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Menelusuri tipe slide tata letak untuk memilih satu slide tata letak.
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
        // seperti "Title", "Title and Content", dll., yang dapat digunakan untuk seleksi slide tata letak.
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

    // Tambahkan slide kosong menggunakan slide tata letak yang ditambahkan.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Simpan presentasi ke disk.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menghapus Tata Letak Slide yang Tidak Digunakan**

Aspose.Slides menyediakan metode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) dari kelas [Compress](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/) untuk memungkinkan Anda menghapus tata letak slide yang tidak diinginkan dan tidak digunakan.

Kode Java berikut memperlihatkan cara menghapus tata letak slide dari sebuah presentasi PowerPoint:

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

Aspose.Slides menyediakan metode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) yang memungkinkan Anda menambahkan placeholder baru ke sebuah tata letak slide.

Pengelola ini memiliki metode untuk jenis placeholder berikut:

| Placeholder PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/) Metode |
| ---------------------- | ------------------------------------------------------------ |
| ![Konten](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Konten (Vertikal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Teks](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Teks (Vertikal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Gambar](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabel](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Gambar Daring](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Kode Java berikut memperlihatkan cara menambahkan bentuk placeholder baru ke tata letak Blank:

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

![Placeholder pada tata letak slide](add_placeholders.png)

## **Mengatur Visibilitas Footer untuk Tata Letak Slide**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat ditampilkan atau disembunyikan tergantung pada tata letak slide. Aspose.Slides for Java memungkinkan Anda mengontrol visibilitas placeholder footer ini. Hal ini berguna bila Anda menginginkan tata letak tertentu menampilkan informasi footer sementara tata letak lain tetap bersih dan minimal.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi tata letak slide berdasarkan indeksnya.
1. Atur placeholder footer slide menjadi tampak.
1. Atur placeholder nomor slide menjadi tampak.
1. Atur placeholder tanggal‑waktu menjadi tampak.
1. Simpan presentasi.

Kode Java berikut memperlihatkan cara mengatur visibilitas footer slide serta melakukan tugas terkait:

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

​Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat dikontrol pada tingkat slide master untuk memastikan konsistensi di semua tata letak slide. Aspose.Slides for Java memungkinkan Anda mengatur visibilitas dan konten placeholder footer pada slide master serta menyebarkan pengaturan ini ke semua tata letak anak. Pendekatan ini memastikan informasi footer yang seragam di seluruh presentasi.​

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide master berdasarkan indeksnya.
1. Atur semua placeholder footer master dan anak menjadi tampak.
1. Atur semua placeholder nomor slide master dan anak menjadi tampak.
1. Atur semua placeholder tanggal‑waktu master dan anak menjadi tampak.
1. Simpan presentasi.

Kode Java berikut memperlihatkan operasi ini:

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

Slide master mendefinisikan tema keseluruhan dan pemformatan default, sedangkan slide tata letak menentukan susunan spesifik placeholder untuk berbagai jenis konten.

**Apakah saya dapat menyalin slide tata letak dari satu presentasi ke presentasi lain?**

Ya, Anda dapat mengkloning slide tata letak dari koleksi slide tata letak sebuah presentasi, yang dapat diakses melalui metode [getLayoutSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getLayoutSlides--), dan menyisipkannya ke presentasi lain menggunakan metode `addClone`.

**Apa yang terjadi jika saya menghapus slide tata letak yang masih digunakan oleh slide lain?**

Jika Anda mencoba menghapus slide tata letak yang masih direferensikan oleh setidaknya satu slide dalam presentasi, Aspose.Slides akan melemparkan [PptxEditException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxeditexception/). Untuk menghindarinya, gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yang secara aman menghapus hanya tata letak slide yang tidak digunakan.