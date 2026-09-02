---
title: "Klon Slide Presentasi di Java"
linktitle: "Klon Slide"
type: docs
weight: 35
url: /id/java/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Duplikat slide PowerPoint dengan cepat menggunakan Aspose.Slides untuk Java. Ikuti contoh kode kami yang jelas untuk mengotomatiskan pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan atau replika yang persis dari sesuatu. Aspose.Slides for Java juga memungkinkan membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang diklon tersebut ke presentasi saat ini atau presentasi lain yang terbuka. Proses mengkloning slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengkloning slide:

- Klon di akhir dalam sebuah Presentasi.
- Klon di posisi lain dalam Presentasi.
- Klon di akhir pada Presentasi lain.
- Klon di posisi lain pada Presentasi lain.
- Klon bersama master slide-nya ke Presentasi lain.

Di Aspose.Slides for Java, (koleksi [ISlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide) objects) yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) menyediakan metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) dan [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) untuk melakukan jenis-jenis kloning slide di atas.

## **Klon Slide di Akhir Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) sesuai langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspor oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Tuliskan file presentasi yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon sebuah slide (berada pada posisi pertama – indeks nol – dari presentasi) ke akhir presentasi.

```java
import com.aspose.slides.*;

// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Tuliskan presentasi yang telah dimodifikasi ke disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon Slide ke Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Instansiasi kelas dengan merujuk ke koleksi **Slides** yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yang diekspor oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon bersama indeks untuk posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah mengklon sebuah slide (berada pada indeks 1 – posisi 2 – dari presentasi) ke indeks 2 – posisi 3 – dari presentasi.

```java
import com.aspose.slides.*;

// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Dapatkan koleksi slide dalam presentasi
    ISlideCollection slds = pres.getSlides();

    // Klon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Tuliskan presentasi yang telah dimodifikasi ke disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon Slide di Akhir Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya di presentasi lain, di akhir slide yang ada:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection) dengan merujuk ke koleksi **Slides** yang diekspor oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspor oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon sebuah slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

```java
import com.aspose.slides.*;

// Instansiasi kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiasi kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Tuliskan presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon Slide ke Posisi Lain di Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya di presentasi lain, pada posisi tertentu:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspor oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yang diekspor oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon sebuah slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) pada presentasi tujuan.

```java
import com.aspose.slides.*;

// Instansiasi kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiasi kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke indeks yang ditentukan dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Tuliskan presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon Slide dengan Master Slide-nya ke Presentasi Lain**
Jika Anda perlu mengklon slide beserta master slide-nya dari satu presentasi dan menggunakannya di presentasi lain, Anda harus terlebih dahulu mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian Anda harus menggunakan master slide tersebut untuk mengklon slide dengan master slide. Metode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan diklon.
1. Akses slide yang akan diklon beserta master slide-nya.
1. Instansiasi kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMasterSlideCollection) dengan merujuk ke koleksi Masters yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspor oleh objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMasterSlideCollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dengan mengatur referensi ke koleksi Slides yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspor oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon sebuah slide dengan master (berada pada indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```java
import com.aspose.slides.*;

// Instansiasi kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instansiasi kelas Presentation untuk presentasi tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Instansiasi ISlide dari koleksi slide dalam presentasi sumber bersama
        // Slide master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
        // Presentasi tujuan
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Klon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        // Koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Simpan presentasi tujuan ke disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon Slide di Akhir Seksi yang Ditentukan**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada seksi yang berbeda, gunakan metode [**addClone**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) yang diekspor oleh antarmuka [**ISlideCollection**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java memungkinkan mengklon slide dari seksi pertama dan kemudian menyisipkan slide yang diklon ke seksi kedua dari presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke seksi yang ditentukan.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Simpan presentasi tujuan ke disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Pastikan Ukuran Slide Sesuai**

Saat mengklon slide ke presentasi lain, pastikan presentasi tujuan memiliki ukuran slide yang sama dengan sumber. Jika ukuran slide berbeda, Aspose.Slides tidak secara otomatis mengubah skala bentuk yang diklon—koordinat dan dimensi asli mereka tetap dipertahankan, yang dapat menyebabkan konten terlihat tidak rata atau melampaui batas slide.

Anda dapat mengatur ukuran slide presentasi tujuan agar cocok dengan sumber sebelum mengklon master dan slide:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Lakukan ini sebelum mengklon master dan slide.

## **FAQ**

**Apakah catatan pembicara dan komentar reviewer diklon?**

Ya. Halaman catatan dan komentar review termasuk dalam klon. Jika Anda tidak menginginkannya, [hapushmereka](/slides/id/java/presentation-notes/) setelah penyisipan.

**Bagaimana grafik dan sumber data mereka ditangani?**

Objek grafik, format, dan data yang tersemat disalin. Jika grafik terhubung ke sumber eksternal (misalnya, workbook yang disematkan OLE), tautan tersebut dipertahankan sebagai [objek OLE](/slides/id/java/manage-ole/). Setelah dipindahkan antar file, periksa ketersediaan data dan perilaku penyegaran.

**Apakah saya dapat mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/java/slide-section/) yang dipilih. Jika seksi tujuan belum ada, buat terlebih dahulu lalu pindahkan slide ke dalamnya.