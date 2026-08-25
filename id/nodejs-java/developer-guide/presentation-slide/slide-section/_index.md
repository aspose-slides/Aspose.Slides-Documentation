---
title: Kelola Bagian Slide dalam Presentasi dengan JavaScript
linktitle: Bagian Slide
type: docs
weight: 90
url: /id/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola bagian slide dengan Aspose.Slides untuk Node.js via Java: buat, ganti nama, susun ulang, ambil, dan proses slide bagian dalam presentasi PPTX."
---
## **Pendahuluan**

Bagian mengorganisir slide berurutan menjadi grup bernama tanpa mengubah konten slide. Dengan Aspose.Slides untuk Node.js via Java, Anda dapat membuat, menyusun ulang, mengganti nama, memeriksa, dan menghapus bagian melalui metode [Presentation.getSections](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSections).

Bagian sangat berguna ketika:

- presentasi besar perlu dibagi menjadi topik atau bab logis;
- kelompok slide yang berbeda ditugaskan kepada kolaborator yang berbeda;
- slide perlu diproses, dipindahkan, atau digabungkan sebagai grup.

Pilih nama bagian yang singkat dan menggambarkan tujuan slide yang dikelompokkan. Karena bagian merupakan bagian dari struktur presentasi, gunakan API bagian untuk menentukan keanggotaan alih-alih menurunkannya dari posisi slide.

## **Buat dan Kelola Bagian**

Gunakan [SectionCollection.addSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectioncollection/#addSection) untuk membuat sebuah bagian dengan menentukan namanya dan slide awal. Aspose.Slides menentukan slide mana yang termasuk dalam bagian tersebut dari struktur bagian presentasi saat ini.

[SectionCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectioncollection/) yang sama juga memungkinkan Anda:

- memindahkan sebuah bagian bersama dengan slide-nya dengan menggunakan [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- menghapus hanya definisi bagian dengan [SectionCollection.removeSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectioncollection/#removeSection), yang mempertahankan slide-nya;
- menghapus sebuah bagian dan slide-nya dengan [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- menambahkan sebuah bagian kosong di akhir dengan [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Contoh berikut membuat dua bagian, memindahkan salah satunya, menghapusnya bersama dengan slide-nya, dan menambahkan sebuah bagian kosong:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Setelah operasi ini, presentasi berisi bagian `Introduction` dengan slide-nya dan sebuah bagian `Appendix` yang kosong. Bagian `Results` dan slide-nya telah dihapus.

## **Ganti Nama Bagian**

Untuk mengganti nama sebuah bagian, panggil metode [Section.setName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#setName). Slide dan posisi bagian tetap tidak berubah.

Contoh berikut membuat sebuah bagian dan mengubah namanya:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Ambil Slide dari Bagian**

Metode [Presentation.getSections](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSections) mengembalikan sebuah [SectionCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectioncollection/) yang dapat Anda akses berdasarkan indeks. Untuk setiap [Section](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/), panggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getSlidesListOfSection) untuk memperoleh slide yang saat ini termasuk di dalamnya. Metode tersebut mengembalikan sebuah [SectionSlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectionslidecollection/), yang menyediakan jumlah dan akses berindeks.

Contoh berikut membuat dua bagian terisi dan satu bagian kosong, lalu mencetak [nama](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getSectionId), [slide mulai](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getStartedFromSlide), jumlah slide, dan nomor slide setiap bagian. Ia menggunakan [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) untuk membaca slide pertama dan setiap slide dalam koleksi. Untuk bagian kosong, koleksi yang dikembalikan berukuran nol, akses berindeks dilewati, dan loop tidak melakukan operasi apa pun.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Keanggotaan bagian ditentukan oleh struktur bagian presentasi. Jangan menghitung rentang sebuah bagian secara manual dari [Section.getStartedFromSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getStartedFromSlide), indeks slide, dan slide mulai bagian berikutnya.

Suntingan struktural dapat mengubah baik slide yang dikembalikan untuk sebuah bagian maupun nomor slide mereka. Ini termasuk menyusun ulang slide, menggandakan slide ke dalam sebuah bagian, memindahkan sebuah bagian bersama dengan slide-nya, menghapus slide, dan menghapus bagian. Contoh berikut memanggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getSlidesListOfSection) setelah setiap perubahan semacam itu alih-alih mempertahankan asumsi tentang batas sebelumnya.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Panggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getSlidesListOfSection) lagi setiap kali slide atau bagian disusun ulang, digandakan, dipindahkan, atau dihapus. Ini menjaga pemrosesan selanjutnya tetap selaras dengan struktur presentasi saat ini.

Format PPT (PowerPoint 97–2003) tidak menyimpan metadata bagian. Gunakan alur kerja ini dengan format yang mendukung bagian, seperti PPTX; mengonversi ke PPT menghapus struktur bagian yang diperlukan untuk iterasi selanjutnya.

## **FAQ**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Sebuah bagian tidak memiliki status visibilitas. Untuk menyembunyikan isinya, panggil [Slide.setHidden](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#setHidden) untuk setiap slide dalam bagian tersebut.

**Bagaimana saya dapat menemukan bagian yang berisi sebuah slide?**

Akses setiap bagian dalam koleksi yang dikembalikan oleh [Presentation.getSections](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSections), panggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getSlidesListOfSection) untuk setiap bagian, dan bandingkan slide yang dikembalikan dengan slide target. Untuk bagian yang tidak kosong, [Section.getStartedFromSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/section/#getStartedFromSlide) mengembalikan slide pertamanya; untuk bagian kosong, ia mengembalikan `null`.