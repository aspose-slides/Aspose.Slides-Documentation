---
title: Terapkan atau Ubah Layout Slide dalam JavaScript
linktitle: Layout Slide
type: docs
weight: 60
url: /id/nodejs-java/slide-layout/
keywords:
- layout slide
- layout konten
- placeholder
- desain presentasi
- desain slide
- layout yang tidak terpakai
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola dan sesuaikan layout slide dalam Aspose.Slides untuk Node.js. Jelajahi tipe layout, kontrol placeholder, dan visibilitas footer melalui contoh kode."
---
## **Pendahuluan**

Layout slide menentukan tata letak kotak placeholder dan pemformatan untuk konten pada sebuah slide. Ia mengontrol placeholder mana yang tersedia dan di mana mereka muncul. Layout slide membantu Anda merancang presentasi dengan cepat dan konsisten—baik saat membuat sesuatu yang sederhana maupun yang lebih kompleks. Beberapa layout slide yang paling umum di PowerPoint meliputi:

**Title Slide layout** – Menyertakan dua placeholder teks: satu untuk judul dan satu untuk subjudul.

**Title and Content layout** – Menampilkan placeholder judul yang lebih kecil di bagian atas dan yang lebih besar di bawahnya untuk konten utama (seperti teks, poin-poin, diagram, gambar, dan lainnya).

**Blank layout** – Tidak berisi placeholder, memberi Anda kontrol penuh untuk merancang slide dari awal.

Layout slide merupakan bagian dari master slide, yang merupakan slide tingkat atas yang menentukan gaya layout untuk presentasi. Anda dapat mengakses dan memodifikasi layout slide melalui master slide—baik berdasarkan tipe, nama, atau ID uniknya. Alternatifnya, Anda dapat menyunting layout slide tertentu langsung di dalam presentasi.

Untuk bekerja dengan layout slide di Aspose.Slides untuk Node.js, Anda dapat menggunakan:
- Metode seperti [getLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getLayoutSlides) dan [getMasters](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getMasters) pada kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/)
- Tipe seperti [LayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/), dan [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Untuk mempelajari lebih lanjut tentang bekerja dengan master slide, lihat artikel [Slide Master](/slides/id/nodejs-java/slide-master/).
{{% /alert %}}

## **Menambahkan Layout Slide ke Presentasi**

Untuk menyesuaikan tampilan dan struktur slide Anda, Anda mungkin perlu menambahkan layout slide baru ke sebuah presentasi. Aspose.Slides untuk Node.js memungkinkan Anda memeriksa apakah layout tertentu sudah ada, menambahkan yang baru jika diperlukan, dan menggunakannya untuk menyisipkan slide berdasarkan layout tersebut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
1. Akses [MasterLayoutSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Periksa apakah layout slide yang diinginkan sudah ada dalam koleksi. Jika tidak, tambahkan layout slide yang Anda butuhkan.
1. Tambahkan slide kosong berdasarkan layout slide baru.
1. Simpan presentasi.

Kode JavaScript berikut menunjukkan cara menambahkan layout slide ke presentasi PowerPoint:

```js
// Instansiasi kelas Presentation yang mewakili file PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Telusuri tipe layout slide untuk memilih sebuah layout slide.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Situasi di mana presentasi tidak berisi semua tipe layout.
        // File presentasi hanya berisi tipe layout Blank dan Custom.
        // Namun, layout slide dengan tipe custom mungkin memiliki nama yang dapat dikenali,
        // seperti "Title", "Title and Content", dll., yang dapat digunakan untuk pemilihan layout slide.
        // Anda juga dapat mengandalkan sekumpulan tipe bentuk placeholder.
        // Misalnya, slide Title seharusnya hanya memiliki tipe placeholder Title, dan sebagainya.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Tambahkan slide kosong menggunakan layout slide yang telah ditambahkan.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Simpan presentasi ke disk.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menghapus Layout Slide yang Tidak Digunakan**

Aspose.Slides menyediakan metode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) dari kelas [Compress](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/) untuk memungkinkan Anda menghapus layout slide yang tidak diinginkan dan tidak terpakai.

Kode JavaScript berikut menunjukkan cara menghapus layout slide dari presentasi PowerPoint:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menambahkan Placeholder ke Layout Slide**

Aspose.Slides menyediakan metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), yang memungkinkan Anda menambahkan placeholder baru ke layout slide.

Manajer ini berisi metode untuk tipe placeholder berikut:

| Placeholder PowerPoint              | Metode [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutplaceholdermanager/) |
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

Kode JavaScript berikut menunjukkan cara menambahkan bentuk placeholder baru ke layout slide Blank:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan layout slide Blank.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Dapatkan manajer placeholder dari layout slide.
    let placeholderManager = layout.getPlaceholderManager();

    // Tambahkan berbagai placeholder ke layout slide Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Tambahkan slide baru dengan layout Blank.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The placeholders on the layout slide](add_placeholders.png)

## **Mengatur Visibilitas Footer untuk Layout Slide**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat ditampilkan atau disembunyikan tergantung pada layout slide. Aspose.Slides untuk Node.js memungkinkan Anda mengontrol visibilitas placeholder footer ini. Hal ini berguna ketika Anda menginginkan layout tertentu menampilkan informasi footer sementara yang lainnya tetap bersih dan minimal.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
1. Dapatkan referensi layout slide berdasarkan indeksnya.
1. Setel placeholder footer slide menjadi terlihat.
1. Setel placeholder nomor slide menjadi terlihat.
1. Setel placeholder tanggal-waktu menjadi terlihat.
1. Simpan presentasi.

Kode JavaScript berikut menunjukkan cara mengatur visibilitas footer slide dan melakukan tugas terkait:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Mengatur Visibilitas Footer Anak untuk Slide**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat dikontrol pada tingkat master slide untuk memastikan konsistensi di semua layout slide. Aspose.Slides untuk Node.js memungkinkan Anda mengatur visibilitas dan konten placeholder footer ini pada master slide dan menyebarkan pengaturan tersebut ke semua layout slide anak. Pendekatan ini memastikan informasi footer yang seragam sepanjang presentasi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
1. Dapatkan referensi master slide berdasarkan indeksnya.
1. Setel placeholder footer master dan semua anak menjadi terlihat.
1. Setel placeholder nomor slide master dan semua anak menjadi terlihat.
1. Setel placeholder tanggal-waktu master dan semua anak menjadi terlihat.
1. Simpan presentasi.

Kode JavaScript berikut menunjukkan operasi ini:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa perbedaan antara master slide dan layout slide?**

Master slide menentukan tema keseluruhan dan pemformatan default, sementara layout slide menentukan susunan placeholder spesifik untuk berbagai jenis konten.

**Apakah saya dapat menyalin layout slide dari satu presentasi ke presentasi lain?**

Ya, Anda dapat menggandakan layout slide dari koleksi layout slide satu presentasi, yang dapat diakses melalui metode [getLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getLayoutSlides), dan menyisipkannya ke presentasi lain menggunakan metode `addClone`.

**Apa yang terjadi jika saya menghapus layout slide yang masih digunakan oleh slide lain?**

Jika Anda mencoba menghapus layout slide yang masih direferensikan oleh setidaknya satu slide dalam presentasi, Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/). Untuk menghindarinya, gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) yang secara aman menghapus hanya layout slide yang tidak digunakan.