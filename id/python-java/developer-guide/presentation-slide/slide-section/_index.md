---
title: Kelola Bagian Slide dalam Presentasi dengan Python via Java
linktitle: Bagian Slide
type: docs
weight: 90
url: /id/python-java/slide-section/
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
- Python
- Java
- Aspose.Slides
description: "Kelola bagian slide dengan Aspose.Slides untuk Python via Java: buat, ganti nama, susun ulang, ambil, dan proses slide bagian dalam presentasi PPTX."
---
## **Pendahuluan**

Bagian mengorganisir slide berurutan menjadi grup dengan nama tanpa mengubah konten slide. Dengan Aspose.Slides untuk Python via Java, Anda dapat membuat, menyusun ulang, mengganti nama, memeriksa, dan menghapus bagian melalui metode [Presentation.getSections](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSections).

Bagian sangat berguna terutama ketika:

- sebuah presentasi besar perlu dibagi menjadi topik atau bab logis;
- grup slide yang berbeda ditugaskan ke kolaborator yang berbeda;
- slide perlu diproses, dipindahkan, atau digabungkan sebagai grup.

Pilih nama bagian yang singkat dan menggambarkan tujuan slide yang dikelompokkan. Karena bagian merupakan bagian dari struktur presentasi, gunakan API bagian untuk menentukan keanggotaan alih‑alih menurunkannya dari posisi slide.

## **Buat dan Kelola Bagian**

Gunakan [SectionCollection.addSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectioncollection/#addSection) untuk membuat sebuah bagian dengan menentukan nama dan slide awalnya. Aspose.Slides menentukan slide mana yang termasuk dalam bagian berdasarkan struktur bagian presentasi saat ini.

[SectionCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectioncollection/) yang sama juga memungkinkan Anda untuk:

- memindahkan sebuah bagian bersama slide‑nya dengan menggunakan [reorderSectionWithSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- menghapus hanya definisi bagian dengan [removeSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectioncollection/#removeSection), yang mempertahankan slide‑nya;
- menghapus sebuah bagian beserta slide‑nya dengan [removeSectionWithSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- menambahkan bagian kosong di akhir dengan [appendEmptySection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Contoh berikut membuat dua bagian, memindahkan salah satunya, menghapusnya bersama slide‑nya, dan menambahkan bagian kosong:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Setelah operasi ini, presentasi berisi bagian `Introduction` dengan slide‑nya dan bagian kosong `Appendix`. Bagian `Results` serta slide‑nya telah dihapus.

## **Ganti Nama Bagian**

Untuk mengganti nama sebuah bagian, panggil metode [Section.setName](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#setName). Slide dan posisi bagian tetap tidak berubah.

Contoh berikut membuat sebuah bagian dan mengubah namanya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Ambil Slide dari Bagian**

Metode [Presentation.getSections](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSections) mengembalikan sebuah [SectionCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectioncollection/) yang dapat Anda iterasi. Untuk setiap [Section](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/), panggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getSlidesListOfSection) untuk memperoleh slide yang saat ini termasuk di dalamnya. Metode tersebut mengembalikan sebuah [SectionSlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectionslidecollection/), yang menyediakan jumlah, akses indeks, dan iterasi.

Contoh berikut membuat dua bagian terisi dan satu bagian kosong, lalu mencetak [nama](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getSectionId), [slide awal](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getStartedFromSlide), jumlah slide, dan nomor slide untuk setiap bagian. Ia menggunakan [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectionslidecollection/#get_Item) untuk membaca slide pertama dan pernyataan `for` untuk memproses setiap slide. Untuk bagian kosong, koleksi yang dikembalikan berukuran nol, metode tidak dipanggil, dan iterasi tidak melakukan apa‑apa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

Keanggotaan bagian ditentukan oleh struktur bagian presentasi. Jangan menghitung rentang bagian secara manual dari [Section.getStartedFromSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getStartedFromSlide), indeks slide, dan slide awal bagian berikutnya.

Edit struktural dapat mengubah baik slide yang dikembalikan untuk sebuah bagian maupun nomor slide mereka. Ini termasuk menyusun ulang slide, mengkloning slide ke dalam sebuah bagian, memindahkan bagian bersama slide‑nya, menghapus slide, dan menghapus bagian. Contoh berikut memanggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getSlidesListOfSection) setelah setiap perubahan tersebut alih‑alih menyimpan asumsi tentang batas sebelumnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Panggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getSlidesListOfSection) lagi setiap kali slide atau bagian disusun ulang, dikloning, dipindahkan, atau dihapus. Ini menjaga pemrosesan selanjutnya selaras dengan struktur presentasi saat ini.

Format PPT (PowerPoint 97–2003) tidak mempertahankan metadata bagian. Gunakan alur kerja ini dengan format yang mendukung bagian, seperti PPTX; mengonversi ke PPT menghapus struktur bagian yang diperlukan untuk iterasi selanjutnya.

## **FAQ**

**Apakah bagian tetap ada saat disimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat menyimpan ke .ppt.

**Apakah seluruh bagian dapat “disembunyikan”?**

Tidak. Sebuah bagian tidak memiliki status visibilitas. Untuk menyembunyikan isinya, panggil [Slide.setHidden](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#setHidden) untuk setiap slide dalam bagian tersebut.

**Bagaimana cara menemukan bagian yang berisi sebuah slide?**

Iterasikan koleksi yang dikembalikan oleh [Presentation.getSections](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSections), panggil [Section.getSlidesListOfSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getSlidesListOfSection) untuk setiap bagian, dan bandingkan slide yang dikembalikan dengan slide target. Untuk bagian yang tidak kosong, [Section.getStartedFromSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/section/#getStartedFromSlide) mengembalikan slide pertamanya; untuk bagian kosong, ia mengembalikan `None`.