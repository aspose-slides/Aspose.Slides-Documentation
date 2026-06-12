---
title: Kelola Bagian Slide dalam Presentasi di .NET
linktitle: Bagian Slide
type: docs
weight: 100
url: /id/net/slide-section/
keywords:
- buat bagian
- tambahkan bagian
- sunting bagian
- ubah bagian
- nama bagian
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Menyederhanakan pengelolaan bagian slide di PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET — memisah, mengganti nama, dan mengatur ulang untuk mengoptimalkan alur kerja PPTX dan ODP."
---
## **Pendahuluan**

Dengan Aspose.Slides for .NET, Anda dapat mengatur Presentasi PowerPoint menjadi bagian-bagian. Anda dapat membuat bagian yang berisi slide tertentu. 

Anda mungkin ingin membuat bagian dan menggunakannya untuk mengatur atau membagi slide dalam sebuah presentasi menjadi bagian logis dalam situasi berikut:

- Ketika Anda bekerja pada presentasi yang besar dengan orang lain atau tim—dan Anda perlu menugaskan slide tertentu kepada rekan atau anggota tim. 
- Ketika Anda menangani presentasi yang berisi banyak slide—dan Anda kesulitan mengelola atau menyunting isinya sekaligus.

Idealnya, Anda harus membuat sebuah bagian yang menampung slide yang serupa—slide tersebut memiliki kesamaan atau dapat dikelompokkan berdasarkan aturan—dan memberikan nama pada bagian tersebut yang menggambarkan slide di dalamnya. 

## **Buat Bagian dalam Presentasi**

Untuk menambahkan bagian yang akan menampung slide dalam sebuah presentasi, Aspose.Slides for .NET menyediakan metode AddSection yang memungkinkan Anda menentukan nama bagian yang ingin dibuat dan slide tempat bagian tersebut dimulai. 

Kode contoh berikut menunjukkan cara membuat bagian dalam sebuah presentasi menggunakan C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 akan berakhir pada newSlide2 dan setelahnya section2 akan dimulai   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Ubah Nama Bagian**

Setelah Anda membuat sebuah bagian dalam presentasi PowerPoint, Anda dapat memutuskan untuk mengubah namanya. 

Kode contoh berikut menunjukkan cara mengubah nama sebuah bagian dalam presentasi menggunakan C# dengan Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Hanya slide individu yang dapat disembunyikan. Sebuah bagian sebagai entitas tidak memiliki status "disembunyikan".

**Bisakah saya dengan cepat menemukan sebuah bagian berdasarkan slide, dan sebaliknya, slide pertama dari sebuah bagian?**

Ya. Sebuah bagian didefinisikan secara unik oleh slide awalnya; dengan memberikan sebuah slide Anda dapat menentukan bagian mana yang menjadi miliknya, dan untuk sebuah bagian Anda dapat mengakses slide pertamanya.