---
title: Klon Slide Presentasi di Java
linktitle: Klon Slide
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

Kloning adalah proses membuat salinan atau replika yang persis dari sesuatu. Aspose.Slides untuk Java juga memungkinkan membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang diklon tersebut ke presentasi saat ini atau presentasi lain yang terbuka. Proses kloning slide menciptakan slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengklon slide:

- Klon di Akhir dalam sebuah Presentasi.
- Klon di Posisi Lain dalam Presentasi.
- Klon di Akhir dalam Presentasi lain.
- Klon di Posisi Lain dalam Presentasi lain.
- Klon di posisi tertentu dalam Presentasi lain.

Di Aspose.Slides untuk Java, (sebuah koleksi objek [ISlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlide)) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) menyediakan metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) dan [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) untuk melakukan tipe kloning slide di atas.

## **Klon Slide di Akhir Presentasi**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) menurut langkah‑langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Tulis file presentasi yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide (yang berada pada posisi pertama – indeks nol – presentasi) ke akhir presentasi.

```java
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
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Instansiasi kelas dengan merujuk ke koleksi [**Slides**](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon bersama dengan indeks untuk posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah mengklon slide (yang berada pada indeks nol – posisi 1 – presentasi) ke indeks 1 – Posisi 2 – presentasi.

```java
// Buat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
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

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection) dengan merujuk ke koleksi [**Slides**](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

```java
// Buat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Buat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
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

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber bersama dengan posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) presentasi tujuan.

```java
// Buat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Buat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Klon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

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
Jika Anda perlu mengklon slide dengan master slide dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian gunakan master slide tersebut untuk mengklon slide dengan master slide. Metode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi sumber slide.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi presentasi tujuan slide akan diklon ke.
1. Akses slide yang akan diklon beserta master slide‑nya.
1. Instansiasi kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMasterSlideCollection) dengan merujuk ke koleksi Masters yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspos oleh objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IMasterSlideCollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dengan mengatur referensi ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah ini, kami telah mengklon slide dengan master (yang berada pada indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```java
// Buat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Buat instance kelas Presentation untuk presentasi tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Instansiasi ISlide dari koleksi slide dalam presentasi sumber beserta
        // Master slide
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
        // presentasi Tujuan
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
        // presentasi Tujuan
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

## **Klon Slide di Akhir Seksi yang Ditentukan**
Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada seksi yang berbeda, gunakan metode [**addClone**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) yang diekspos oleh antarmuka [**ISlideCollection**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISlideCollection). Aspose.Slides untuk Java memungkinkan mengklon slide dari seksi pertama dan kemudian menyisipkan slide yang diklon ke seksi kedua dari presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke seksi yang ditentukan.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Simpan presentasi tujuan ke disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Apakah catatan pembicara dan komentar peninjau ikut diklon?**

Ya. Halaman catatan dan komentar peninjau termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/java/presentation-notes/) setelah penyisipan.

**Bagaimana grafik dan sumber data mereka ditangani?**

Objek grafik, pemformatan, dan data yang disematkan disalin. Jika grafik terhubung ke sumber eksternal (misalnya, workbook yang disematkan OLE), tautan tersebut dipertahankan sebagai [objek OLE](/slides/id/java/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Apakah saya dapat mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/java/slide-section/) yang dipilih. Jika seksi target belum ada, buat terlebih dahulu lalu pindahkan slide ke dalamnya.