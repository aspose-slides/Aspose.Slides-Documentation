---
title: Klon Slide Presentasi di .NET
linktitle: Klon Slide
type: docs
weight: 40
url: /id/net/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Duplikat slide PowerPoint dengan cepat menggunakan Aspose.Slides untuk .NET. Ikuti contoh kode kami yang jelas untuk mengotomatiskan pembuatan PPT dalam hitungan detik dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan atau replika persis dari sesuatu. Aspose.Slides juga memungkinkan Anda menyalin (mengkloning) slide apa pun dan kemudian memasukkan slide yang dikloning ke dalam presentasi saat ini atau presentasi terbuka lainnya. Mengkloning slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa memengaruhi slide asli. Ada beberapa cara untuk mengkloning slide:

- Klon di akhir presentasi.
- Klon di posisi lain dalam presentasi.
- Klon di akhir presentasi lain.
- Klon di posisi lain dalam presentasi lain.
- Klon di posisi tertentu dalam presentasi lain.

Dalam Aspose.Slides untuk .NET, koleksi slide (koleksi objek [ISlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/) ) yang disajikan oleh objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) menyediakan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) dan [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/insertclone/) untuk melakukan operasi pengkloningan slide yang dijelaskan di atas.

## **Klon Slide di Akhir Presentasi**

Jika Anda ingin mengkloning sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) menurut langkah-langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan merujuk ke koleksi Slides yang disajikan oleh objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang disajikan oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide yang akan dikloning sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Tuliskan file presentasi yang telah dimodifikasi.

Dalam contoh di bawah, kami telah mengkloning sebuah slide (berada pada posisi pertama – indeks nol – dari presentasi) ke akhir presentasi.

```c#
// Instansiasi kelas Presentation yang merepresentasikan file presentasi
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Tuliskan presentasi yang telah dimodifikasi ke disk
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Klon Slide ke Posisi Lain dalam Presentasi**

Jika Anda ingin mengkloning sebuah slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi di posisi yang berbeda, gunakan metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
1. Instansiasi kelas dengan merujuk ke koleksi **Slides** yang disajikan oleh objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
1. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) yang disajikan oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide yang akan dikloning bersama indeks posisi baru sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, kami telah mengkloning sebuah slide (berada pada indeks nol – posisi 1 – dari presentasi) ke indeks 1 – Posisi 2 – dari presentasi.

```c#
// Instansiasi kelas Presentation yang merepresentasikan file presentasi
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.Slides;

    // Klon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    slds.InsertClone(2, pres.Slides[1]);

    // Tuliskan presentasi yang telah dimodifikasi ke disk
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Klon Slide di Akhir Presentasi Lain**

Jika Anda perlu mengkloning sebuah slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi sumber slide yang akan dikloning.
1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan merujuk ke koleksi **Slides** yang disajikan oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang disajikan oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide dari presentasi sumber sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah, kami telah mengkloning sebuah slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

```c#
// Instansiasi kelas Presentation untuk memuat file presentasi sumber
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instansiasi kelas Presentation untuk PPTX tujuan (tempat slide akan dikloning)
    using (Presentation destPres = new Presentation())
    {
        // Klon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Tuliskan presentasi tujuan ke disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klon Slide ke Posisi Lain dalam Presentasi Lain**

Jika Anda perlu mengkloning sebuah slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di posisi tertentu:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi sumber slide yang akan dikloning.
1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan merujuk ke koleksi Slides yang disajikan oleh objek Presentation dari presentasi tujuan.
1. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) yang disajikan oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah, kami telah mengkloning sebuah slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) dari presentasi tujuan.

```c#
// Instansiasi kelas Presentation untuk memuat file presentasi sumber
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instansiasi kelas Presentation untuk PPTX tujuan (tempat slide akan dikloning)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Tuliskan presentasi tujuan ke disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klon Slide di Posisi Tertentu dalam Presentasi Lain**

Jika Anda perlu mengkloning sebuah slide dengan slide master dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengkloning slide master yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian Anda harus menggunakan slide master tersebut untuk mengkloning slide dengan master. Metode **AddClone(ISlide, IMasterSlide)** mengharapkan slide master dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengkloning slide dengan master, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi sumber slide yang akan dikloning.
1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi tujuan slide akan dikloning ke.
1. Akses slide yang akan dikloning bersama master slide.
1. Instansiasi kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection) dengan merujuk ke koleksi Masters yang disajikan oleh objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang disajikan oleh objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection) dan berikan master dari PPTX sumber yang akan dikloning sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Instansiasi kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan mengatur referensi ke koleksi Slides yang disajikan oleh objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dari presentasi tujuan.
1. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang disajikan oleh objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide dari presentasi sumber yang akan dikloning serta master slide sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Dalam contoh di bawah, kami telah mengkloning sebuah slide dengan master (berada pada indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```c#
// Instansiasi kelas Presentation untuk memuat file presentasi sumber

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instansiasi kelas Presentation untuk presentasi tujuan (tempat slide akan dikloning)
    using (Presentation destPres = new Presentation())
    {

        // Instansiasi ISlide dari koleksi slide dalam presentasi sumber bersama
        // slide master
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
        // Presentasi tujuan
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
        // Presentasi tujuan
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        // Koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Klon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam // Presentasi tujuan
        // Simpan presentasi tujuan ke disk
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Klon Slide di Akhir Seksi yang Ditentukan**

Dengan Aspose.Slides untuk .NET, Anda dapat mengkloning slide dari satu seksi dalam presentasi dan menyisipkan slide tersebut ke seksi lain dalam presentasi yang sama. Dalam hal ini, Anda harus menggunakan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) dari antarmuka [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) .

Kode C# ini menunjukkan cara mengkloning slide dan menyisipkan slide yang dikloning ke seksi yang ditentukan:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // untuk dikloning
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah catatan presenter dan komentar peninjau diklon?**

Ya. Halaman catatan dan komentar tinjauan termasuk dalam klon. Jika Anda tidak menginginkannya, [remove them](/slides/id/net/presentation-notes/) setelah penyisipan.

**Bagaimana grafik dan sumber data mereka ditangani?**

Objek grafik, pemformatan, dan data tersemat disalin. Jika grafik tersebut terhubung ke sumber eksternal (mis., buku kerja OLE-embedded), tautan tersebut dipertahankan sebagai [OLE object](/slides/id/net/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Apakah saya dapat mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [section](/slides/id/net/slide-section/) yang dipilih. Jika seksi target tidak ada, buat terlebih dahulu lalu pindahkan slide ke dalamnya.