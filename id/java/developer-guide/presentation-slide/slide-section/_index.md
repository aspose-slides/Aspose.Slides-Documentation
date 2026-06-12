---
title: Kelola Bagian Slide dalam Presentasi Menggunakan Java
linktitle: Bagian Slide
type: docs
weight: 90
url: /id/java/slide-section/
keywords:
- buat bagian
- tambahkan bagian
- edit bagian
- ubah bagian
- nama bagian
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Menyederhanakan pengelolaan bagian slide di PowerPoint dan OpenDocument dengan Aspose.Slides untuk Java — memisah, mengganti nama, dan menyusun ulang untuk mengoptimalkan alur kerja PPTX dan ODP."
---
## **Pendahuluan**

Dengan Aspose.Slides for Java, Anda dapat mengatur Presentasi PowerPoint menjadi bagian-bagian. Anda dapat membuat bagian yang berisi slide tertentu. 

Anda mungkin ingin membuat bagian dan menggunakannya untuk mengatur atau membagi slide dalam sebuah presentasi menjadi bagian logis dalam situasi berikut:

- Ketika Anda bekerja pada presentasi besar bersama orang lain atau tim—dan Anda perlu menugaskan slide tertentu kepada rekan atau beberapa anggota tim. 
- Ketika Anda mengerjakan presentasi yang berisi banyak slide—dan Anda kesulitan mengelola atau mengedit semua isinya sekaligus.

Idealnya, Anda harus membuat sebuah bagian yang menampung slide yang serupa—slide memiliki kesamaan atau dapat dikelompokkan berdasarkan aturan—dan memberi nama bagian tersebut yang menggambarkan slide di dalamnya. 

## **Buat Bagian dalam Presentasi**

Untuk menambahkan sebuah bagian yang akan menampung slide dalam sebuah presentasi, Aspose.Slides for Java menyediakan metode [addSection()](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) yang memungkinkan Anda menentukan nama bagian yang ingin dibuat serta slide tempat bagian tersebut dimulai. 

Kode contoh ini menunjukkan cara membuat sebuah bagian dalam presentasi menggunakan Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 akan berakhir pada newSlide2 dan setelahnya section2 akan dimulai   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Nama Bagian**

Setelah Anda membuat sebuah bagian dalam presentasi PowerPoint, Anda mungkin memutuskan untuk mengubah namanya. 

Kode contoh ini menunjukkan cara mengubah nama sebuah bagian dalam presentasi menggunakan Java dengan Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tanya Jawab**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Bisakah seluruh bagian "disembunyikan"?**

Tidak. Hanya slide individu yang dapat disembunyikan. Sebuah bagian sebagai entitas tidak memiliki status "disembunyikan".

**Bisakah saya dengan cepat menemukan sebuah bagian melalui sebuah slide dan sebaliknya, slide pertama dari sebuah bagian?**

Ya. Sebuah bagian didefinisikan secara unik oleh slide awalnya; dengan sebuah slide Anda dapat menentukan bagian mana yang menjadi miliknya, dan untuk sebuah bagian Anda dapat mengakses slide pertamanya.