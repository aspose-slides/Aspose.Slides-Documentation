---
title: Kelola Header dan Footer Presentasi pada Android
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, dan handout dengan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada jenis halaman. Aspose.Slides untuk Android via Java memungkinkan Anda mengontrol teks dan visibilitas placeholder ini melalui antarmuka manajer header/footer.

Placeholder yang tersedia tergantung pada ruang lingkup:

| Ruang Lingkup | Header | Footer | Tanggal/waktu | Nomor slide/halaman |
|---|---|---|---|---|
| Regular slide | Tidak | Ya | Ya | Ya |
| Notes master | Ya | Ya | Ya | Ya |
| Notes slide | Ya | Ya | Ya | Ya |
| Handout master | Ya | Ya | Ya | Ya |

Slide presentasi biasa tidak memiliki placeholder header. Header tersedia pada halaman notes dan handout. Untuk slide biasa, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Ruang lingkup perubahan tergantung pada manajer yang Anda gunakan. Antarmuka [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islideheaderfootermanager/) mengontrol satu slide reguler. Antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) mengontrol satu slide notes. Manajer master dan layout juga dapat menyebarkan pengaturan ke slide yang bergantung, sementara antarmuka [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) mengontrol handout master.

## **Menetapkan Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses manajer header/footer tiap slide, menetapkan teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, jadi Anda hanya perlu mengontrol visibilitasnya.

Gunakan [`setFooterText`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) dan [`setDateTimeText`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) untuk menetapkan teks, serta [`setFooterVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), dan [`setSlideNumberVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) untuk menampilkan placeholder yang bersangkutan.

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

Jika Anda perlu memperbarui hanya satu slide, akses slide tersebut secara langsung melalui metode [`getSlides`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSlides--) alih-alih iterasi melalui seluruh koleksi.

## **Menetapkan Header dan Footer pada Notes Master**

Notes master mendefinisikan format umum dan perilaku placeholder untuk halaman notes. Gunakan antarmuka [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya notes master itu sendiri.

Contoh berikut menetapkan header, footer, dan teks tanggal/waktu pada notes master serta membuat semua placeholder yang didukung terlihat pada master tersebut:

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

Metode [`getMasterNotesSlide`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) mengembalikan `null` ketika presentasi tidak berisi notes master.

## **Menerapkan Pengaturan Notes Master ke Slide Notes Anak**

Notes master dapat menerapkan pengaturan header dan footer ke dirinya sendiri dan ke semua slide notes yang bergantung. Gunakan metode propagasi khusus pada [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hierarki notes.

Sebagai contoh, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) dan [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) memperbarui header notes master dan semua header anak. Metode serupa tersedia untuk footer, tanggal/waktu, dan nomor slide.

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

Metode propagasi yang digunakan di atas meliputi [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), dan [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Menetapkan Header dan Footer pada Slide Notes Individual**

Sebuah slide notes terkait dengan slide reguler tertentu. Gunakan antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman notes tersebut.

Metode [`addNotesSlide`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) mengembalikan slide notes untuk slide saat ini dan membuatnya bila belum ada. Contoh berikut mengonfigurasi halaman notes yang terkait dengan slide presentasi pertama:

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

Jika Anda pertama kali menyebarkan pengaturan dari notes master lalu mengubah slide notes individual, pengaturan per-slide kemudian memungkinkan Anda menyesuaikan halaman notes tersebut secara independen.

## **Menetapkan Header dan Footer pada Handout Master**

Halaman handout menggunakan handout master untuk placeholder header, footer, tanggal/waktu, dan nomor halaman. Tidak seperti halaman notes, pengaturan handout dikelola melalui handout master, bukan melalui slide handout individual.

Gunakan metode [`getMasterHandoutSlide`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) untuk mengakses handout master. Jika tidak ada, panggil [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) untuk membuat handout master default.

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

## **Memahami Ruang Lingkup dan Pewarisan**

Pilih manajer header/footer yang sesuai dengan ruang lingkup yang ingin Anda ubah:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) mengontrol slide layout dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) mengontrol notes master dan dapat menyebarkan pengaturan ke semua slide notes yang bergantung.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) mengubah satu slide notes dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) mengubah handout master dan mendukung keempat jenis placeholder.

Gunakan propagasi dari master atau layout ketika pengaturan yang sama harus diterapkan di seluruh hierarki. Gunakan manajer slide individual atau notes-slide ketika Anda memerlukan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header ke slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman notes dan handout.

**Bagaimana jika placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan manajer header/footer yang bersangkutan untuk memeriksa visibilitasnya dan mengaktifkannya bila diperlukan. Misalnya, [`isFooterVisible`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) melaporkan apakah placeholder footer ada, dan [`setFooterVisibility`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Panggil metode [`setFirstSlideNumber`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) pada presentasi. Placeholder nomor slide kemudian menggunakan urutan penomoran yang diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama konten presentasi lainnya dalam format output. Penampilannya tergantung pada jenis halaman yang diekspor dan pengaturan visibilitas placeholder yang relevan.