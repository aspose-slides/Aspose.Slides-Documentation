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
description: "Duplikat slide PowerPoint dengan Aspose.Slides untuk Android. Ikuti contoh kode Java kami yang jelas untuk mengotomatiskan pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan tepat atau replika sesuatu. Aspose.Slides for Android via Java juga memungkinkan membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang diklon tersebut ke presentasi saat ini atau presentasi lain yang terbuka. Proses pengklonan slide menciptakan slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengkloning slide:

- Mengklon di Akhir dalam sebuah Presentasi.
- Mengklon di Posisi lain dalam Presentasi.
- Mengklon di Akhir dalam Presentasi lain.
- Mengklon di Posisi lain dalam Presentasi lain.
- Mengklon di posisi tertentu dalam Presentasi lain.

Di Aspose.Slides for Android via Java, (sebuah koleksi objek [ISlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlide) ) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) menyediakan metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) dan [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) untuk melakukan jenis-jenis pengklonan slide di atas

## **Mengklon Slide di Akhir Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) sesuai langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Tulis file presentasi yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide (yang berada di posisi pertama – indeks nol – pada presentasi) ke akhir presentasi.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Menulis presentasi yang dimodifikasi ke disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Mengklon Slide ke Posisi Lain dalam Presentasi**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Instansiasi kelas dengan merujuk ke koleksi [**Slides**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide yang akan diklon bersama indeks untuk posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah, kami telah mengklon sebuah slide (yang berada di indeks nol – posisi 1 – pada presentasi) ke indeks 1 – Posisi 2 – dari presentasi.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.getSlides();

    // Mengklon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Menulis presentasi yang telah dimodifikasi ke disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Mengklon Slide di Akhir Presentasi Lain**
Jika Anda perlu mengklon sebuah slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi sumber slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection) dengan merujuk ke koleksi [**Slides**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

```java
// Membuat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Menulis presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Mengklon Slide ke Posisi Lain dalam Presentasi Lain**
Jika Anda perlu mengklon sebuah slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi sumber slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dengan merujuk ke koleksi Slides yang diekspos oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) dari presentasi tujuan.

```java
// Membuat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Menulis presentasi tujuan ke disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Mengklon Slide di Posisi Tertentu dalam Presentasi Lain**
Jika Anda perlu mengklon sebuah slide dengan slide master dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengklon slide master yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian gunakan slide master tersebut untuk mengklon slide dengan master. Metode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) mengharapkan slide master dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi sumber slide akan diklon.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang berisi presentasi tujuan slide akan diklon ke.
1. Akses slide yang akan diklon beserta slide master-nya.
1. Instansiasi kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterSlideCollection) dengan merujuk ke koleksi Masters yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yang diekspos oleh objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IMasterSlideCollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dengan mengatur referensi ke koleksi Slides yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yang diekspos oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getSlides--) dan berikan slide dari presentasi sumber yang akan diklon beserta slide master sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Tulis file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, kami telah mengklon sebuah slide dengan master (yang berada di indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```java
// Membuat instance kelas Presentation untuk memuat file presentasi sumber
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Membuat instance kelas Presentation untuk presentasi tujuan (tempat slide akan diklon)
    Presentation destPres = new Presentation();
    try {
        // Membuat ISlide dari koleksi slide dalam presentasi sumber bersama
        // slide master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Mengklon slide master yang diinginkan dari presentasi sumber ke koleksi master dalam
        // presentasi Tujuan
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Mengklon slide master yang diinginkan dari presentasi sumber ke koleksi master dalam
        // presentasi Tujuan
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Mengklon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        // Koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Menyimpan presentasi tujuan ke disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Mengklon Slide di Akhir Seksi yang Ditentukan**
Jika Anda ingin mengklon sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada seksi yang berbeda, gunakan metode [**addClone**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) yang diekspos oleh antarmuka [**ISlideCollection**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java memungkinkan mengklon slide dari seksi pertama kemudian menyisipkan slide yang diklon ke seksi kedua dari presentasi yang sama.

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

## **Tanya Jawab**

**Apakah catatan pembicara dan komentar peninjau juga diklon?**

Ya. Halaman catatan dan komentar peninjau termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/androidjava/presentation-notes/) setelah penyisipan.

**Bagaimana diagram dan sumber data mereka ditangani?**

Objek diagram, format, dan data yang tersemat disalin. Jika diagram terhubung ke sumber eksternal (misalnya, buku kerja yang disematkan OLE), tautan tersebut dipertahankan sebagai [objek OLE](/slides/id/androidjava/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Bisakah saya mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/androidjava/slide-section/) yang dipilih. Jika seksi target belum ada, buat terlebih dahulu kemudian pindahkan slide ke dalamnya.