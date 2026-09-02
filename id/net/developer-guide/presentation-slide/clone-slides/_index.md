---
title: Mengklon Slide Presentasi di .NET
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

Kloning adalah proses membuat salinan atau tiruan yang persis dari sesuatu. Aspose.Slides juga memungkinkan Anda menyalin (mengkloning) slide apa pun dan kemudian menyisipkan slide yang diklon ke dalam presentasi saat ini atau presentasi terbuka lainnya. Kloning slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa memengaruhi slide asli. Ada beberapa cara untuk mengkloning slide:

- Kloning di akhir presentasi.
- Kloning pada posisi lain dalam presentasi.
- Kloning di akhir presentasi lain.
- Kloning pada posisi lain di presentasi lain.
- Kloning bersama slide masternya ke dalam presentasi lain.

Di Aspose.Slides untuk .NET, koleksi slide (sebuah koleksi objek [ISlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/) ) yang tersedia melalui objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) menyediakan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/addclone/) dan [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/insertclone/) untuk melakukan operasi kloning slide yang dijelaskan di atas.

## **Kloning Slide di Akhir Presentasi**

Jika Anda ingin mengkloning slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) sesuai langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
2. Instansiasikan kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan merujuk ke koleksi Slides yang tersedia melalui objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
3. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang tersedia pada objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide yang akan diklon sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
4. Tuliskan file presentasi yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengkloning slide (yang berada pada posisi pertama – indeks nol – dalam presentasi) ke akhir presentasi.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Membuat instance kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Klon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Menulis presentasi yang telah dimodifikasi ke disk
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Kloning Slide ke Posisi Lain dalam Presentasi**

Jika Anda ingin mengkloning slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi pada posisi yang berbeda, gunakan metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
2. Instansiasikan kelas dengan merujuk ke koleksi **Slides** yang tersedia melalui objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) .
3. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) yang tersedia pada objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide yang akan diklon bersama dengan indeks posisi baru sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) .
4. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengkloning slide (yang berada pada indeks 1 – posisi 2 – dalam presentasi) ke indeks 2 – posisi 3 – dalam presentasi.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Membuat instance kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    ISlideCollection slds = pres.Slides;

    // Mengklon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    slds.InsertClone(2, pres.Slides[1]);

    // Menulis presentasi yang telah dimodifikasi ke disk
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Kloning Slide di Akhir Presentasi Lain**

Jika Anda perlu mengkloning slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi tempat slide akan diklon .
2. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi tujuan tempat slide akan ditambahkan .
3. Instansiasikan kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan merujuk ke koleksi **Slides** yang tersedia melalui objek Presentation pada presentasi tujuan .
4. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang tersedia pada objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide dari presentasi sumber sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
5. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengkloning slide (dari indeks pertama presentasi sumber) ke akhir presentasi tujuan.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Membuat instance kelas Presentation untuk memuat file presentasi sumber
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Membuat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    using (Presentation destPres = new Presentation())
    {
        // Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Menulis presentasi tujuan ke disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Kloning Slide ke Posisi Lain dalam Presentasi Lain**

Jika Anda perlu mengkloning slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi sumber tempat slide akan diklon .
2. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi tempat slide akan ditambahkan .
3. Instansiasikan kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan merujuk ke koleksi Slides yang tersedia melalui objek Presentation pada presentasi tujuan .
4. Panggil metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) yang tersedia pada objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide dari presentasi sumber bersama dengan posisi yang diinginkan sebagai parameter ke metode [InsertClone](https://reference.aspose.com/slides/id/net/aspose.slides.ishapecollection/insertclone/methods/1) .
5. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengkloning slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) pada presentasi tujuan.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Membuat instance kelas Presentation untuk memuat file presentasi sumber
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Membuat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Menulis presentasi tujuan ke disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Kloning Slide dengan Slide Master ke Presentasi Lain**

Jika Anda perlu mengkloning slide beserta slide masternya dari satu presentasi dan menggunakannya dalam presentasi lain, Anda harus terlebih dahulu mengkloning slide master yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian Anda harus menggunakan slide master tersebut untuk mengkloning slide dengan master. Metode **AddClone(ISlide, IMasterSlide)** mengharapkan slide master dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengkloning slide dengan master, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi sumber tempat slide akan diklon .
2. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi presentasi tujuan tempat slide akan diklon .
3. Akses slide yang akan diklon bersama dengan slide masternya .
4. Instansiasikan kelas [IMasterSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection) dengan merujuk ke koleksi Masters yang tersedia melalui objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) pada presentasi tujuan .
5. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang tersedia pada objek [IMasterSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslidecollection) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
6. Instansiasikan kelas [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dengan mengatur referensi ke koleksi Slides yang tersedia melalui objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) pada presentasi tujuan .
7. Panggil metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) yang tersedia pada objek [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) dan berikan slide dari presentasi sumber yang akan diklon serta slide master sebagai parameter ke metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) .
8. Tuliskan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami telah mengkloning slide dengan master (yang berada pada indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master dari slide sumber.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Membuat instance kelas Presentation untuk memuat file presentasi sumber

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Membuat instance kelas Presentation untuk presentasi tujuan (di mana slide akan diklon)
    using (Presentation destPres = new Presentation())
    {

        // Membuat instance ISlide dari koleksi slide dalam presentasi sumber bersama dengan
        // Slide master
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Mengklon slide master yang diinginkan dari presentasi sumber ke koleksi master di
        // presentasi tujuan
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Mengklon slide master yang diinginkan dari presentasi sumber ke koleksi master di
        // presentasi tujuan
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Mengklon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        // koleksi slide dalam presentasi tujuan
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Mengklon slide master yang diinginkan dari presentasi sumber ke koleksi master di // presentasi tujuan
        // Simpan presentasi tujuan ke disk
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Kloning Slide di Akhir Seksi yang Ditentukan**

Dengan Aspose.Slides untuk .NET, Anda dapat mengkloning slide dari satu seksi dalam presentasi dan menyisipkan slide tersebut ke seksi lain dalam presentasi yang sama. Dalam kasus ini, Anda harus menggunakan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection/methods/addclone/index) dari antarmuka [ISlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/islidecollection) .

Kode C# berikut menunjukkan cara mengkloning slide dan menyisipkan slide yang diklon ke dalam seksi yang ditentukan:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // untuk diklon
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Pastikan Ukuran Slide Sesuai**

Saat mengkloning slide ke presentasi lain, pastikan presentasi tujuan memiliki ukuran slide yang sama dengan sumber. Jika ukuran slide berbeda, Aspose.Slides tidak secara otomatis mengubah skala bentuk yang diklon—koordinat dan dimensi aslinya dipertahankan, yang dapat menyebabkan konten tampak tidak sejajar atau melampaui batas slide.

Anda dapat mengatur ukuran slide presentasi tujuan agar cocok dengan sumber sebelum mengkloning master dan slide:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Lakukan ini sebelum mengkloning master dan slide.

## **FAQ**

**Apakah catatan presenter dan komentar reviewer juga diklon?**

Ya. Halaman catatan dan komentar review termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/net/presentation-notes/) setelah penyisipan.

**Bagaimana chart dan sumber data mereka ditangani?**

Objek chart, pemformatan, dan data yang disematkan disalin. Jika chart terhubung ke sumber eksternal (mis., workbook yang disematkan OLE), kaitan tersebut dipertahankan sebagai [OLE object](/slides/id/net/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Bisakah saya mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [section](/slides/id/net/slide-section/) yang dipilih. Jika seksi tujuan belum ada, buat terlebih dahulu lalu pindahkan slide ke dalamnya.