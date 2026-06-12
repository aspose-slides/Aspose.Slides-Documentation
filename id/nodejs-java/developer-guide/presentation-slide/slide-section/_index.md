---
title: Kelola Bagian Slide dalam Presentasi Menggunakan JavaScript
linktitle: Bagian Slide
type: docs
weight: 90
url: /id/nodejs-java/slide-section/
keywords:
- membuat bagian
- menambahkan bagian
- mengedit bagian
- mengubah bagian
- nama bagian
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Permudah pengelolaan bagian slide dalam PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js — memisah, mengganti nama, dan menyusun ulang untuk mengoptimalkan alur kerja PPTX dan ODP."
---
## **Introduction**

Dengan Aspose.Slides untuk Node.js via Java, Anda dapat mengatur Presentasi PowerPoint menjadi bagian-bagian. Anda dapat membuat bagian yang berisi slide tertentu.

Anda mungkin ingin membuat bagian dan menggunakannya untuk mengatur atau membagi slide dalam sebuah presentasi menjadi bagian logis dalam situasi berikut:

- Ketika Anda bekerja pada presentasi besar bersama orang lain atau tim—dan Anda perlu menugaskan slide tertentu kepada rekan atau anggota tim. 
- Ketika Anda menangani presentasi yang berisi banyak slide—dan Anda kesulitan mengelola atau mengedit isinya sekaligus.

Idealnya, Anda harus membuat sebuah bagian yang menampung slide serupa—slide tersebut memiliki kesamaan atau dapat berada dalam satu grup berdasarkan aturan—dan memberikan nama pada bagian tersebut yang menggambarkan slide di dalamnya. 

## **Membuat Bagian dalam Presentasi**

Untuk menambahkan sebuah bagian yang akan menampung slide dalam presentasi, Aspose.Slides untuk Node.js via Java menyediakan metode [addSection()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) yang memungkinkan Anda menentukan nama bagian yang ingin dibuat serta slide tempat bagian tersebut dimulai.

Kode contoh ini menunjukkan cara membuat bagian dalam sebuah presentasi menggunakan JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 akan berakhir pada newSlide2 dan setelahnya section2 akan dimulai
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengubah Nama Bagian**

Setelah Anda membuat sebuah bagian dalam presentasi PowerPoint, Anda mungkin ingin mengubah namanya. 

Kode contoh ini menunjukkan cara mengubah nama sebuah bagian dalam presentasi menggunakan JavaScript dengan Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat “disembunyikan”?**

Tidak. Hanya slide individu yang dapat disembunyikan. Sebuah bagian sebagai entitas tidak memiliki status “disembunyikan”.

**Apakah saya dapat dengan cepat menemukan sebuah bagian berdasarkan slide, dan sebaliknya, slide pertama dari sebuah bagian?**

Ya. Sebuah bagian didefinisikan secara unik oleh slide awalnya; dengan sebuah slide Anda dapat menentukan bagian mana yang dimilikinya, dan untuk sebuah bagian Anda dapat mengakses slide pertamanya.