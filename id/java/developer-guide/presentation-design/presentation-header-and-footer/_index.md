---
title: Kelola Header dan Footer Presentasi di Java
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/java/presentation-header-and-footer/
keywords:
- kepala
- teks header
- kaki
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
description: "Gunakan Aspose.Slides untuk Java untuk menambahkan dan menyesuaikan header serta footer dalam presentasi PowerPoint dan OpenDocument agar tampilan lebih profesional."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola pengaturan header dan footer pada presentasi PowerPoint. Header dan footer ditangani pada tingkat master presentasi, dan API menyediakan metode untuk mengatur teks footer, mengubah visibilitas footer, serta memperbarui teks header pada slide master catatan.

Anda juga dapat mengelola header dan footer untuk slide handout dan catatan. Ini mencakup mengubah visibilitas dan teks placeholder header, footer, nomor slide, dan tanggal‑waktu untuk master catatan, semua slide catatan anak, atau slide catatan individu.

## **Kelola Header dan Footer dalam Presentasi**
Catatan pada beberapa slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah:

```java
// Muat Presentasi
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Mengatur Footer
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Mengakses dan Memperbarui Header
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Simpan presentasi
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Metode untuk mengatur Teks Header/Footer
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Kelola Header dan Footer pada Slide Handout dan Catatan**
Aspose.Slides for Java mendukung Header dan Footer pada slide Handout dan catatan. Ikuti langkah‑langkah berikut:

- Muat sebuah [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi video.
- Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan.
- Atur placeholder Footer pada master catatan dan semua anak menjadi terlihat.
- Atur placeholder Tanggal dan waktu pada master catatan dan semua anak menjadi terlihat.
- Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama.
- Atur placeholder Header pada slide catatan menjadi terlihat.
- Setel teks ke placeholder Header pada slide catatan.
- Setel teks ke placeholder Tanggal‑waktu pada slide catatan.
- Tulis file presentasi yang telah dimodifikasi.

Cuplikan kode disediakan pada Contoh di bawah.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // buat slide catatan master dan semua placeholder Footer anak terlihat
        headerFooterManager.setFooterAndChildFootersVisibility(true); // buat slide catatan master dan semua placeholder Header anak terlihat
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // buat slide catatan master dan semua placeholder NomorSlide anak terlihat
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // buat slide catatan master dan semua placeholder Tanggal dan waktu anak terlihat

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // setel teks pada slide catatan master dan semua placeholder Header anak
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // setel teks pada slide catatan master dan semua placeholder Footer anak
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // setel teks pada slide catatan master dan semua placeholder Tanggal dan waktu anak
    }

    // Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // buat placeholder Header slide catatan ini terlihat

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // buat placeholder Footer slide catatan ini terlihat

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // buat placeholder NomorSlide slide catatan ini terlihat

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // buat placeholder Date-time slide catatan ini terlihat

        headerFooterManager.setHeaderText("New header text"); // setel teks pada placeholder Header slide catatan
        headerFooterManager.setFooterText("New footer text"); // setel teks pada placeholder Footer slide catatan
        headerFooterManager.setDateTimeText("New date and time text"); // setel teks pada placeholder Date-time slide catatan
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bisakah saya menambahkan “header” pada slide reguler?**

Di PowerPoint, “Header” hanya ada untuk catatan dan handout; pada slide reguler, elemen yang didukung adalah footer, tanggal/waktu, dan nomor slide. Pada Aspose.Slides hal ini memiliki batasan yang sama: header hanya untuk Catatan/Handout, dan pada slide—Footer/TanggalWaktu/NomorSlide.

**Bagaimana jika tata letak tidak memiliki area footer—apakah saya dapat “menyalakan” visibilitasnya?**

Ya. Periksa visibilitas melalui manajer header/footer dan aktifkan bila diperlukan. Indikator dan metode API ini dirancang untuk kasus ketika placeholder tidak ada atau tersembunyi.

**Bagaimana cara membuat nomor slide dimulai dari nilai selain 1?**

Setel [first slide number](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) pada presentasi; setelah itu, semua penomoran dihitung ulang. Misalnya, Anda dapat memulai dari 0 atau 10, dan menyembunyikan nomor pada slide judul.

**Apa yang terjadi pada header/footer saat mengekspor ke PDF/gambar/HTML?**

Header/footer dirender sebagai elemen teks biasa pada presentasi. Artinya, jika elemen‑elemen tersebut terlihat pada slide/halaman catatan, mereka juga akan muncul dalam format output bersama konten lainnya.