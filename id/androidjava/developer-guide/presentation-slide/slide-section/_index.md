---
title: Kelola Bagian Slide dalam Presentasi di Android
linktitle: Bagian Slide
type: docs
weight: 90
url: /id/androidjava/slide-section/
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
- Android
- Java
- Aspose.Slides
description: "Kelola bagian slide dengan Aspose.Slides untuk Android via Java: buat, ganti nama, ubah urutan, ambil, dan proses slide bagian dalam presentasi PPTX."
---
## **Pendahuluan**

Bagian mengatur slide berurutan menjadi grup bernama tanpa mengubah konten slide. Dengan Aspose.Slides untuk Android via Java, Anda dapat membuat, mengubah urutan, mengganti nama, memeriksa, dan menghapus bagian melalui metode [Presentation.getSections](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSections--) .

Bagian sangat berguna ketika:

- sebuah presentasi besar perlu dibagi menjadi topik atau bab logis;
- grup slide yang berbeda ditugaskan kepada kolaborator yang berbeda;
- slide perlu diproses, dipindahkan, atau digabungkan sebagai grup.

Pilih nama bagian yang singkat yang menggambarkan tujuan slide yang dikelompokkan. Karena bagian merupakan bagian dari struktur presentasi, gunakan API bagian untuk menentukan keanggotaan alih-alih menurunkannya dari posisi slide.

## **Buat dan Kelola Bagian**

Gunakan [ISectionCollection.addSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) untuk membuat bagian dengan menentukan namanya dan slide awal. Aspose.Slides menentukan slide mana yang termasuk dalam bagian berdasarkan struktur bagian presentasi saat ini.

[ISectionCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectioncollection/) yang sama juga memungkinkan Anda:

- memindahkan sebuah bagian beserta slide-nya dengan menggunakan [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- menghapus hanya definisi bagian dengan [ISectionCollection.removeSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), yang mempertahankan slide-nya;
- menghapus sebuah bagian beserta slide-nya dengan [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- menambahkan bagian kosong di akhir dengan [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Contoh berikut membuat dua bagian, memindahkan salah satunya, menghapusnya bersama slide-nya, dan menambahkan sebuah bagian kosong:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Setelah operasi ini, presentasi berisi bagian `Introduction` dengan slide-nya dan bagian `Appendix` kosong. Bagian `Results` dan slide-nya telah dihapus.

## **Ganti Nama Bagian**

Untuk mengganti nama sebuah bagian, panggil metode [ISection.setName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) . Slide dan posisi bagian tetap tidak berubah.

Contoh berikut membuat sebuah bagian dan mengubah namanya:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Ambil Slide dari Bagian**

Metode [Presentation.getSections](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSections--) mengembalikan sebuah [ISectionCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectioncollection/) yang dapat Anda iterasi. Untuk setiap [ISection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/), panggil [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) untuk memperoleh slide yang saat ini termasuk di dalamnya. Metode ini mengembalikan sebuah [ISectionSlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectionslidecollection/), yang menyediakan jumlah, akses berindeks, dan iterasi.

Contoh berikut membuat dua bagian yang berisi slide dan satu bagian kosong, kemudian mencetak setiap [nama](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getSectionId--), [slide awal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), jumlah slide, dan nomor slide dari setiap bagian. Ia menggunakan [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) untuk membaca slide pertama dan pernyataan `for` yang ditingkatkan untuk memproses setiap slide. Untuk bagian kosong, koleksi yang dikembalikan berukuran nol, metode tidak dipanggil, dan iterasi tidak melakukan apa‑apa.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Keanggotaan bagian ditentukan oleh struktur bagian presentasi. Jangan menghitung rentang bagian secara manual dari [ISection.getStartedFromSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), indeks slide, dan slide awal bagian berikutnya.

Suntingan struktural dapat mengubah baik slide yang dikembalikan untuk sebuah bagian maupun nomor slide mereka. Ini termasuk mengubah urutan slide, mengkloning slide ke dalam sebuah bagian, memindahkan bagian bersama slide-nya, menghapus slide, dan menghapus bagian. Contoh berikut memanggil [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) setelah setiap perubahan semacam itu alih-alih mempertahankan asumsi tentang batas sebelumnya.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Panggil [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) lagi setiap kali slide atau bagian diubah urutannya, dikloning, dipindahkan, atau dihapus. Ini menjaga pemrosesan selanjutnya tetap selaras dengan struktur presentasi saat ini.

Format PPT (PowerPoint 97–2003) tidak menyimpan metadata bagian. Gunakan alur kerja ini dengan format yang mendukung bagian, seperti PPTX; mengonversi ke PPT menghapus struktur bagian yang diperlukan untuk iterasi selanjutnya.

## **FAQ**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat menyimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Sebuah bagian tidak memiliki status visibilitas. Untuk menyembunyikan isinya, panggil [ISlide.setHidden](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#setHidden-boolean-) untuk setiap slide dalam bagian tersebut.

**Bagaimana saya dapat menemukan bagian yang berisi sebuah slide?**

Iterasi koleksi yang dikembalikan oleh [Presentation.getSections](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSections--), panggil [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) untuk setiap bagian, dan bandingkan slide yang dikembalikan dengan slide target. Untuk bagian yang tidak kosong, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) mengembalikan slide pertamanya; untuk bagian kosong, ia mengembalikan `null`.