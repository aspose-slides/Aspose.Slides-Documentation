---
title: Kelola Header dan Footer Presentasi di Java
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, dan handout dengan Aspose.Slides untuk Java."
---
## **Gambaran Umum**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada jenis halaman. Aspose.Slides for Java memungkinkan Anda mengontrol teks dan visibilitas placeholder ini melalui antarmuka manajer header/footer.

Placeholder yang tersedia tergantung pada lingkup:

| Lingkup | Header | Footer | Tanggal/waktu | Nomor slide/halaman |
|---|---|---|---|---|
| Slide reguler | Tidak | Ya | Ya | Ya |
| Notes master | Ya | Ya | Ya | Ya |
| Notes slide | Ya | Ya | Ya | Ya |
| Handout master | Ya | Ya | Ya | Ya |

Slide presentasi reguler tidak memiliki placeholder header. Header tersedia pada halaman catatan dan handout. Untuk slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Lingkup perubahan tergantung pada manajer yang Anda gunakan. Antarmuka [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideheaderfootermanager/) mengontrol satu slide reguler. Antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/inotesslideheaderfootermanager/) mengontrol satu slide catatan. Manajer master dan layout juga dapat menyebarkan pengaturan ke slide yang bergantung, sedangkan antarmuka [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) mengontrol handout master.

## **Atur Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses manajer header/footer tiap slide, mengatur teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, jadi Anda hanya perlu mengontrol visibilitasnya.

Gunakan [`setFooterText`](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) dan [`setDateTimeText`](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) untuk mengatur teks, dan gunakan [`setFooterVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), dan [`setSlideNumberVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) untuk menampilkan placeholder yang bersangkutan.

Contoh end-to-end berikut menerapkan footer, teks tanggal/waktu, dan visibilitas nomor slide yang sama pada semua slide reguler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda perlu memperbarui hanya satu slide, akses slide tersebut langsung melalui metode [`getSlides`](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSlides--) alih-alih mengulangi seluruh koleksi.

## **Atur Header dan Footer pada Notes Master**

Notes master mendefinisikan pemformatan umum dan perilaku placeholder untuk halaman catatan. Gunakan antarmuka [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya notes master itu sendiri.

Contoh berikut mengatur teks header, footer, dan tanggal/waktu pada notes master serta membuat semua placeholder yang didukung terlihat pada master tersebut:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metode [`getMasterNotesSlide`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) mengembalikan `null` ketika presentasi tidak berisi notes master.

## **Terapkan Pengaturan Notes Master ke Slide Catatan Anak**

Notes master dapat menerapkan pengaturan header dan footer ke dirinya sendiri dan ke semua slide catatan yang tergantung. Gunakan metode propagasi khusus pada [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hierarki catatan.

Sebagai contoh, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) dan [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) memperbarui header notes master dan semua header anak. Metode setara tersedia untuk footer, tanggal/waktu, dan nomor slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metode propagasi yang digunakan di atas adalah [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), dan [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Atur Header dan Footer pada Slide Catatan Individu**

Slide catatan terkait dengan slide reguler tertentu. Gunakan antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/inotesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman catatan tersebut.

Metode [`addNotesSlide`](https://reference.aspose.com/slides/id/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) mengembalikan slide catatan untuk slide saat ini dan membuatnya jika belum ada. Contoh berikut mengkonfigurasi halaman catatan yang terkait dengan slide pertama dalam presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda pertama-tama menyebarkan pengaturan dari notes master dan kemudian mengubah slide catatan individu, pengaturan per-slide selanjutnya memungkinkan Anda menyesuaikan halaman catatan tersebut secara independen.

## **Atur Header dan Footer pada Handout Master**

Halaman handout menggunakan handout master untuk placeholder header, footer, tanggal/waktu, dan nomor halaman. Berbeda dengan halaman catatan, pengaturan handout dikelola melalui handout master bukan melalui slide handout individu.

Gunakan metode [`getMasterHandoutSlide`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) untuk mengakses handout master. Jika tidak ada, panggil [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) untuk membuat handout master default.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memahami Lingkup dan Pewarisan**

Pilih manajer header/footer yang cocok dengan lingkup yang ingin Anda ubah:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/islideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslideheaderfootermanager/) mengontrol slide tata letak dan dapat menyebarkan pengaturan yang didukung ke slide yang tergantung.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang tergantung.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslideheaderfootermanager/) mengontrol notes master dan dapat menyebarkan pengaturan ke semua slide catatan yang tergantung.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/inotesslideheaderfootermanager/) mengubah satu slide catatan dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) mengubah handout master dan mendukung keempat jenis placeholder.

Gunakan propagasi dari master atau layout ketika pengaturan yang sama harus berlaku di seluruh hierarki. Gunakan manajer slide individu atau notes-slide ketika Anda membutuhkan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header ke slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman catatan dan handout.

**Bagaimana jika placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan manajer header/footer yang bersangkutan untuk memeriksa visibilitasnya dan mengaktifkannya bila diperlukan. Misalnya, [`isFooterVisible`](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) melaporkan apakah placeholder footer ada, dan [`setFooterVisibility`](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Panggil metode [`setFirstSlideNumber`](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) pada presentasi. Placeholder nomor slide kemudian menggunakan urutan penomoran yang telah diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama dengan konten presentasi lainnya dalam format output. Penampilannya tergantung pada jenis halaman yang diekspor dan pengaturan visibilitas placeholder yang bersangkutan.