---
title: Kelola Bagian Slide dalam Presentasi Menggunakan C++
linktitle: Bagian Slide
type: docs
weight: 100
url: /id/cpp/slide-section/
keywords:
- buat bagian
- tambah bagian
- edit bagian
- ubah bagian
- nama bagian
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Menyederhanakan bagian slide di PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++ — memisah, mengganti nama, dan menyusun ulang untuk mengoptimalkan alur kerja PPTX dan ODP."
---
## **Introduction**

Dengan Aspose.Slides untuk C++, Anda dapat mengatur Presentasi PowerPoint menjadi bagian-bagian. Anda dapat membuat bagian yang berisi slide tertentu.

Anda mungkin ingin membuat bagian dan menggunakannya untuk mengatur atau membagi slide dalam presentasi menjadi bagian logis dalam situasi berikut:

- Saat Anda bekerja pada presentasi besar dengan orang lain atau tim—dan Anda perlu menugaskan slide tertentu kepada rekan atau beberapa anggota tim. 
- Saat Anda menangani presentasi yang berisi banyak slide—dan Anda kesulitan mengelola atau mengedit isinya sekaligus.

Idealnya, Anda harus membuat bagian yang berisi slide serupa—slide tersebut memiliki kesamaan atau dapat dikelompokkan berdasarkan aturan—dan memberi nama bagian yang menggambarkan slide di dalamnya. 

## **Create Sections in Presentations**

Untuk menambahkan bagian yang akan berisi slide dalam sebuah presentasi, Aspose.Slides untuk C++ menyediakan metode AddSection yang memungkinkan Anda menentukan nama bagian yang ingin dibuat dan slide tempat bagian tersebut dimulai. 

Kode contoh ini menunjukkan cara membuat bagian dalam presentasi menggunakan C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 akan diakhiri pada newSlide2 dan setelahnya section2 akan dimulai   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Change the Names of Sections**

Setelah Anda membuat bagian dalam presentasi PowerPoint, Anda mungkin memutuskan untuk mengubah namanya. 

Kode contoh ini menunjukkan cara mengubah nama bagian dalam presentasi menggunakan C++ dengan Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**Apakah bagian tetap terjaga saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Hanya slide individual yang dapat disembunyikan. Sebuah bagian sebagai entitas tidak memiliki status "disembunyikan".

**Apakah saya dapat dengan cepat menemukan sebuah bagian berdasarkan slide dan sebaliknya, slide pertama dari sebuah bagian?**

Ya. Sebuah bagian didefinisikan secara unik oleh slide awalnya; dengan sebuah slide Anda dapat menentukan bagian mana yang termasuk, dan untuk sebuah bagian Anda dapat mengakses slide pertamanya.