---
title: Klon Slide Presentasi di Android
linktitle: Klon Slide
type: docs
weight: 35
url: /id/androidjava/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Duplikat slide PowerPoint dengan Aspose.Slides untuk Android. Ikuti contoh kode Java kami yang jelas untuk mengotomatisasi pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan atau replika yang persis dari sesuatu. Aspose.Slides for Android via Java juga memungkinkan membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang diklon tersebut ke presentasi saat ini atau presentasi lain yang terbuka. Proses pengklonan slide menciptakan slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengklon slide:

- Mengklon di Akhir dalam Presentasi.
- Mengklon di Posisi Lain dalam Presentasi.
- Mengklon di Akhir dalam Presentasi lain.
- Mengklon di Posisi Lain dalam Presentasi lain.
- Mengklon di posisi tertentu dalam Presentasi lain.

Di Aspose.Slides for Android via Java, (kumpulan objek [ISlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlide)) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) menyediakan metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) dan [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) untuk melakukan tipe pengklonan slide di atas

## **Klon Slide di Akhir Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) sesuai langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dengan merujuk pada koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Tulis file presentasi yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide (yang berada pada posisi pertama – indeks nol – dalam presentasi) ke akhir presentasi.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Tulis presentasi yang telah dimodifikasi ke disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon Slide ke Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-):

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Instansiasi kelas dengan merujuk pada koleksi **Slides** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon beserta indeks posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah mengklon slide (yang berada pada indeks 1 – posisi 2 – dalam presentasi) ke indeks 2 – Posisi 3 – dalam presentasi.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Dapatkan koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.getSlides();

    // Klon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Tulis presentasi yang telah dimodifikasi ke disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon Slide di Akhir Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi sumber slide yang akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection) dengan merujuk pada koleksi **Slides** yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Buat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Tulis presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon Slide ke Posisi Lain dalam Presentasi Lain**
Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dengan merujuk pada koleksi Slides yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) pada presentasi tujuan.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Buat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke indeks yang ditentukan dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Tulis presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon Slide di Posisi Tertentu dalam Presentasi Lain**
Jika Anda perlu mengklon slide dengan master slide dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian Anda harus menggunakan master slide tersebut untuk mengklon slide dengan master slide. Metode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi sumber tempat slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan diklon.
1. Akses slide yang akan diklon bersama dengan master slide.
1. Instansiasi kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterSlideCollection) dengan merujuk pada koleksi Masters yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yang diekspos oleh objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterSlideCollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dengan menetapkan referensi ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide dengan master (yang berada pada indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```java
import com.aspose.slides.*;

// Buat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Buat instance kelas Presentation untuk presentasi tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Buat instance ISlide dari koleksi slide dalam presentasi sumber bersama
        // slide master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klon slide master yang diinginkan dari presentasi sumber ke koleksi master dalam
        // presentasi tujuan
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        // koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Simpan presentasi tujuan ke disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon Slide di Akhir Seksi Tertentu**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi di bagian yang berbeda, gunakan metode [**addClone**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) yang diekspos oleh antarmuka [**ISlideCollection**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java memungkinkan mengklon slide dari bagian pertama dan kemudian menyisipkan slide yang diklon ke bagian kedua dari presentasi yang sama.

Snippet kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke seksi yang ditentukan.

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

Saat mengklon slide ke presentasi lain, pastikan presentasi tujuan memiliki ukuran slide yang sama dengan sumber. Jika ukuran slide berbeda, Aspose.Slides tidak secara otomatis mengubah skala bentuk yang diklon—koordinat dan dimensi asli mereka dipertahankan, yang dapat menyebabkan konten tampak tidak beraturan atau melampaui batas slide.

Anda dapat mengatur ukuran slide presentasi tujuan agar sesuai dengan sumber sebelum mengklon master dan slide:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Lakukan ini sebelum mengklon master dan slide.

## **FAQ**

**Apakah catatan pembicara dan komentar reviewer juga diklon?**

Ya. Halaman catatan dan komentar review termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/androidjava/presentation-notes/) setelah penyisipan.

**Bagaimana diagram dan sumber data mereka ditangani?**

Objek diagram, format, dan data tersemat disalin. Jika diagram terhubung ke sumber eksternal (misalnya, workbook tersemat OLE), tautan tersebut dipertahankan sebagai [objek OLE](/slides/id/androidjava/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Apakah saya dapat mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/androidjava/slide-section/) yang dipilih. Jika seksi target belum ada, buat terlebih dahulu lalu pindahkan slide ke dalamnya.