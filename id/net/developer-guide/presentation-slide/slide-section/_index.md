---
title: Kelola Bagian Slide dalam Presentasi di .NET
linktitle: Bagian Slide
type: docs
weight: 100
url: /id/net/slide-section/
keywords:
- buat bagian
- tambahkan bagian
- edit bagian
- ubah bagian
- nama bagian
- ambil slide bagian
- proses slide bagian
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola bagian slide dengan Aspose.Slides untuk .NET: buat, ganti nama, susun ulang, ambil, dan proses slide bagian dalam presentasi PPTX."
---
## **Pendahuluan**

Bagian mengatur slide berurutan menjadi grup yang dinamai tanpa mengubah konten slide. Dengan Aspose.Slides untuk .NET, Anda dapat membuat, menyusun ulang, mengganti nama, memeriksa, dan menghapus bagian melalui properti [Presentation.Sections](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sections/).

Bagian sangat berguna ketika:

- presentasi besar perlu dibagi menjadi topik atau bab logis;
- grup slide yang berbeda ditugaskan ke kolaborator yang berbeda;
- slide perlu diproses, dipindahkan, atau digabungkan sebagai grup.

Pilih nama bagian yang singkat dan menggambarkan tujuan slide yang dikelompokkan. Karena bagian merupakan bagian dari struktur presentasi, gunakan API bagian untuk menentukan keanggotaan alih-alih menurunkannya dari posisi slide.

## **Buat dan Kelola Bagian**

Gunakan [ISectionCollection.AddSection](https://reference.aspose.com/slides/id/net/aspose.slides/sectioncollection/addsection/) untuk membuat bagian dengan menentukan namanya dan slide awal. Aspose.Slides menentukan slide mana yang termasuk dalam bagian dari struktur bagian presentasi saat ini.

[ISectionCollection](https://reference.aspose.com/slides/id/net/aspose.slides/isectioncollection/) yang sama juga memungkinkan Anda untuk:

- memindahkan sebuah bagian bersama slide-nya dengan menggunakan [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/id/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- menghapus hanya definisi bagian dengan [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/id/net/aspose.slides/sectioncollection/removesection/), yang mempertahankan slide-nya;
- menghapus sebuah bagian beserta slide-nya dengan [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/id/net/aspose.slides/sectioncollection/removesectionwithslides/);
- menambahkan bagian kosong di akhir dengan [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/id/net/aspose.slides/sectioncollection/appendemptysection/).

Contoh berikut membuat dua bagian, memindahkan salah satunya, menghapusnya bersama slide-nya, dan menambahkan bagian kosong di akhir:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Setelah operasi tersebut, presentasi berisi bagian `Introduction` dengan slide-nya serta bagian kosong `Appendix`. Bagian `Results` dan slide-nya telah dihapus.

## **Ganti Nama Bagian**

Untuk mengganti nama sebuah bagian, atur properti [ISection.Name](https://reference.aspose.com/slides/id/net/aspose.slides/isection/name/). Slide dan posisi bagian tetap tidak berubah.

Contoh berikut membuat sebuah bagian dan mengubah namanya:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Dapatkan Slide dari Bagian**

Properti [Presentation.Sections](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sections/) mengembalikan sebuah [ISectionCollection](https://reference.aspose.com/slides/id/net/aspose.slides/isectioncollection/) yang dapat Anda iterasi. Untuk setiap [ISection](https://reference.aspose.com/slides/id/net/aspose.slides/isection/), panggil [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/id/net/aspose.slides/isection/getslideslistofsection/) untuk memperoleh slide yang saat ini termasuk di dalamnya. Metode tersebut mengembalikan sebuah [ISectionSlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/isectionslidecollection/), yang menyediakan jumlah, akses indeks, dan iterasi.

Contoh berikut membuat dua bagian terisi dan satu bagian kosong, kemudian mencetak setiap [nama](https://reference.aspose.com/slides/id/net/aspose.slides/isection/name/), [identifier](https://reference.aspose.com/slides/id/net/aspose.slides/isection/sectionid/), [slide awal](https://reference.aspose.com/slides/id/net/aspose.slides/isection/startedfromslide/), jumlah slide, dan nomor slide masing‑masing. Ia menggunakan indeks koleksi untuk membaca slide pertama dan `foreach` untuk memproses setiap slide. Untuk bagian kosong, koleksi yang dikembalikan memiliki hitungan nol, indeks tidak diakses, dan iterasi tidak melakukan iterasi apa pun.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Keanggotaan bagian ditentukan oleh struktur bagian presentasi. Jangan menghitung rentang bagian secara manual dari [ISection.StartedFromSlide](https://reference.aspose.com/slides/id/net/aspose.slides/isection/startedfromslide/), indeks slide, dan slide awal bagian berikutnya.

Pengeditan struktural dapat mengubah baik slide yang dikembalikan untuk sebuah bagian maupun nomor slide mereka. Ini termasuk menyusun ulang slide, mengkloning slide ke dalam sebuah bagian, memindahkan bagian bersama slide-nya, menghapus slide, dan menghapus bagian. Contoh berikut memanggil [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/id/net/aspose.slides/isection/getslideslistofsection/) setelah setiap perubahan tersebut alih‑alih mempertahankan asumsi tentang batas sebelumnya.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Panggil [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/id/net/aspose.slides/isection/getslideslistofsection/) lagi setiap kali slide atau bagian disusun ulang, dikloning, dipindahkan, atau dihapus. Ini menjaga pemrosesan selanjutnya selaras dengan struktur presentasi saat ini.

Format PPT (PowerPoint 97–2003) tidak mempertahankan metadata bagian. Gunakan alur kerja ini dengan format yang mendukung bagian, seperti PPTX; mengonversi ke PPT menghapus struktur bagian yang diperlukan untuk enumerasi selanjutnya.

## **FAQ**

**Apakah bagian dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, jadi pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat “disembunyikan”?**

Tidak. Sebuah bagian tidak memiliki status visibilitas. Untuk menyembunyikan isinya, atur properti [ISlide.Hidden](https://reference.aspose.com/slides/id/net/aspose.slides/islide/hidden/) untuk setiap slide dalam bagian tersebut.

**Bagaimana saya dapat menemukan bagian yang berisi sebuah slide?**

Iterasi [Presentation.Sections](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/sections/), panggil [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/id/net/aspose.slides/isection/getslideslistofsection/) untuk setiap bagian, dan bandingkan slide yang dikembalikan dengan slide target. Untuk bagian yang tidak kosong, [ISection.StartedFromSlide](https://reference.aspose.com/slides/id/net/aspose.slides/isection/startedfromslide/) mengembalikan slide pertamanya; untuk bagian kosong, ia mengembalikan `null`.