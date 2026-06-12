---
title: Kelola Header dan Footer Presentasi di Android
linktitle: Header & Footer
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
description: "Gunakan Aspose.Slides untuk Android via Java untuk menambahkan dan menyesuaikan header serta footer pada presentasi PowerPoint dan OpenDocument agar tampilan profesional."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola pengaturan header dan footer dalam presentasi PowerPoint. Header dan footer dikelola pada tingkat master presentasi, dan API menyediakan metode untuk mengatur teks footer, mengubah visibilitas footer, serta memperbarui teks header pada slide master catatan.

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

    // Akses dan Perbarui Header
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

Aspose.Slides untuk Android via Java mendukung Header dan Footer pada slide Handout dan catatan. Silakan ikuti langkah-langkah di bawah ini:

- Muat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi video.
- Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan.
- Atur placeholder Footer pada slide master catatan dan semua child menjadi terlihat.
- Atur placeholder Date and Time pada slide master catatan dan semua child menjadi terlihat.
- Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama.
- Atur placeholder Header pada slide catatan menjadi terlihat.
- Setel teks pada placeholder Header slide catatan.
- Setel teks pada placeholder Date-time slide catatan.
- Tuliskan file presentasi yang telah dimodifikasi.

Cuplikan kode disediakan dalam Contoh di bawah.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // buat slide master catatan dan semua placeholder Footer anak menjadi terlihat
        headerFooterManager.setFooterAndChildFootersVisibility(true); // buat slide master catatan dan semua placeholder Header anak menjadi terlihat
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // buat slide master catatan dan semua placeholder SlideNumber anak menjadi terlihat
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // buat slide master catatan dan semua placeholder Date and time anak menjadi terlihat

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // setel teks ke slide master catatan dan semua placeholder Header anak
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // setel teks ke slide master catatan dan semua placeholder Footer anak
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // setel teks ke slide master catatan dan semua placeholder Date and time anak
    }

    // Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // buat placeholder Header slide catatan ini menjadi terlihat

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // buat placeholder Footer slide catatan ini menjadi terlihat

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // buat placeholder SlideNumber slide catatan ini menjadi terlihat

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // buat placeholder Date-time slide catatan ini menjadi terlihat

        headerFooterManager.setHeaderText("New header text"); // setel teks ke placeholder Header slide catatan
        headerFooterManager.setFooterText("New footer text"); // setel teks ke placeholder Footer slide catatan
        headerFooterManager.setDateTimeText("New date and time text"); // setel teks ke placeholder Date-time slide catatan
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menambahkan "header" ke slide biasa?**

Di PowerPoint, "Header" hanya ada untuk catatan dan handout; pada slide biasa, elemen yang didukung adalah footer, tanggal/waktu, dan nomor slide. Pada Aspose.Slides hal ini memiliki batasan yang sama: header hanya untuk Notes/Handout, dan pada slide—Footer/DateTime/SlideNumber.

**Bagaimana jika tata letak tidak memiliki area footer—apakah saya dapat "mengaktifkan" visibilitasnya?**

Ya. Periksa visibilitas melalui pengelola header/footer dan aktifkan bila diperlukan. Indikator dan metode API ini dirancang untuk kasus ketika placeholder tidak ada atau disembunyikan.

**Bagaimana cara membuat nomor slide dimulai dari nilai selain 1?**

Atur [first slide number](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) pada presentasi; setelah itu, semua penomoran akan dihitung ulang. Misalnya, Anda dapat memulai dari 0 atau 10, dan menyembunyikan nomor pada slide judul.

**Apa yang terjadi pada header/footer saat mengekspor ke PDF/gambar/HTML?**

Mereka dirender sebagai elemen teks biasa dalam presentasi. Artinya, jika elemen tersebut terlihat pada slide/halaman catatan, mereka juga akan muncul dalam format output bersama konten lainnya.