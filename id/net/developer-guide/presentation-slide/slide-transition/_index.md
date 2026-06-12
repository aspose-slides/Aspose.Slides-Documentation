---
title: Kelola Transisi Slide dalam Presentasi di .NET
linktitle: Transisi Slide
type: docs
weight: 90
url: /id/net/slide-transition/
keywords:
- transisi slide
- tambahkan transisi slide
- terapkan transisi slide
- transisi slide lanjutan
- transisi morph
- jenis transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan cara menyesuaikan transisi slide di Aspose.Slides untuk .NET, dengan panduan langkah demi langkah untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola transisi slide dalam presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menerapkan jenis transisi pada slide, mengonfigurasi perilaku transisi seperti maju pada klik atau setelah waktu tertentu, memeriksa dan menonaktifkan kemajuan otomatis, menggunakan transisi Morph dan jenis-jenisnya, serta mengatur opsi efek transisi. Contoh-contoh menunjukkan cara memuat atau membuat presentasi, memodifikasi pengaturan transisi untuk slide yang dipilih, dan menyimpan hasilnya sebagai file PPTX. Artikel ini juga menjawab pertanyaan umum tentang kecepatan transisi, suara transisi, menerapkan transisi yang sama ke beberapa slide, dan memeriksa transisi yang saat ini diatur pada slide.

## **Menambahkan Transisi Slide**
Untuk mempermudah pemahaman, kami telah mendemonstrasikan penggunaan Aspose.Slides untuk .NET dalam mengelola transisi slide sederhana. Pengembang tidak hanya dapat menerapkan efek transisi slide yang berbeda pada slide tetapi juga menyesuaikan perilaku efek transisi tersebut. Untuk membuat efek transisi slide sederhana, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang ditawarkan oleh Aspose.Slides untuk .NET melalui enum TransitionType
1. Tulis file presentasi yang telah dimodifikasi.

```c#
// Membuat instance kelas Presentation untuk memuat file presentasi sumber
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Terapkan transisi tipe lingkaran pada slide 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Terapkan transisi tipe sisir pada slide 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Simpan presentasi ke disk
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Menambahkan Transisi Slide Lanjutan**
Pada bagian di atas, kami hanya menerapkan efek transisi sederhana pada slide. Sekarang, untuk membuat efek transisi sederhana tersebut lebih baik dan terkendali, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang ditawarkan oleh Aspose.Slides untuk .NET
1. Anda juga dapat mengatur transisi menjadi Advance On Click, setelah periode waktu tertentu, atau keduanya.
1. Jika transisi slide diaktifkan untuk Advance On Click, transisi hanya akan maju ketika seseorang mengklik mouse. Selain itu, jika properti Advance After Time diatur, transisi akan maju secara otomatis setelah waktu yang ditentukan berlalu.
1. Tulis presentasi yang telah dimodifikasi sebagai file presentasi.

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Terapkan transisi tipe lingkaran pada slide 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Atur waktu transisi selama 3 detik
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Terapkan transisi tipe sisir pada slide 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Atur waktu transisi selama 5 detik
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Terapkan transisi tipe zoom pada slide 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Atur waktu transisi selama 7 detik
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Simpan presentasi ke disk
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Selain itu, dengan menggunakan properti [AdvanceAfter](https://reference.aspose.com/slides/id/net/aspose.slides/islideshowtransition/advanceafter/), Anda dapat memeriksa apakah transisi slide telah dikonfigurasi untuk berpindah ke slide berikutnya atau menonaktifkan pengaturannya.

Kode C# berikut mendemonstrasikan operasi tersebut:

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Mendapatkan transisi slide
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Memeriksa apakah pengaturan Advance After Time diaktifkan
        if (slideTransition.AdvanceAfter)
        {
            // Mencetak nilai Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Menonaktifkan transisi setelah waktu tertentu jika nilai AdvanceAfterTime lebih besar dari 2 detik
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Transisi Morph**
Aspose.Slides untuk .NET kini mendukung [Morph Transition](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/imorphtransition). Ini merupakan transisi morph baru yang diperkenalkan di PowerPoint 2019. Transisi Morph memungkinkan Anda menganimasikan pergerakan halus dari satu slide ke slide berikutnya. Artikel ini menjelaskan konsep dan cara menggunakan transisi Morph. Untuk menggunakan transisi Morph secara efektif, Anda memerlukan dua slide dengan setidaknya satu objek yang sama. Cara termudah adalah menggandakan slide dan kemudian memindahkan objek pada slide kedua ke tempat lain.

Potongan kode berikut menunjukkan cara menambahkan klon slide dengan beberapa teks ke presentasi dan mengatur transisi menjadi [morph type](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) pada slide kedua.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Jenis Transisi Morph**
Enum baru [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionmorphtype) telah ditambahkan. Enum ini mewakili berbagai jenis transisi slide Morph.

Enum TransitionMorphType memiliki tiga anggota:

- ByObject: Transisi Morph akan dilakukan dengan mempertimbangkan bentuk sebagai objek yang tidak dapat dibagi.
- ByWord: Transisi Morph akan dilakukan dengan mentransfer teks per kata bila memungkinkan.
- ByChar: Transisi Morph akan dilakukan dengan mentransfer teks per karakter bila memungkinkan.

Potongan kode berikut menunjukkan cara mengatur transisi morph pada slide dan mengubah jenis morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Mengatur Efek Transisi**
Aspose.Slides untuk .NET mendukung pengaturan efek transisi seperti from black, from left, from right, dll. Untuk mengatur Efek Transisi, ikuti langkah-langkah berikut:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
- Dapatkan referensi slide.
- Atur efek transisi.
- Tulis presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Pada contoh di bawah ini, kami telah mengatur efek transisi.

```c#
// Membuat instance kelas Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Atur efek
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Simpan presentasi ke disk
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Atur [Speed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/speed/) transisi dengan menggunakan pengaturan [TransitionSpeed](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/transitionspeed/) (mis., slow/medium/fast).

**Apakah saya dapat melampirkan audio ke transisi dan membuatnya berulang?**

Ya. Anda dapat menyematkan suara untuk transisi dan mengontrol perilakunya melalui pengaturan seperti mode suara dan pengulangan (mis., [Sound](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/soundloop/), serta metadata seperti [SoundIsBuiltIn](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) dan [SoundName](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Apa cara tercepat untuk menerapkan transisi yang sama ke setiap slide?**

Konfigurasikan jenis transisi yang diinginkan pada pengaturan transisi setiap slide; transisi disimpan per slide, sehingga menerapkan jenis yang sama pada semua slide menghasilkan hasil yang konsisten.

**Bagaimana cara memeriksa transisi mana yang saat ini diatur pada slide?**

Periksa [pengaturan transisi](https://reference.aspose.com/slides/id/net/aspose.slides/baseslide/slideshowtransition/) slide dan baca [jenis transisinya](https://reference.aspose.com/slides/id/net/aspose.slides.slideshow/slideshowtransition/type/); nilai tersebut memberi tahu Anda secara tepat efek apa yang diterapkan.