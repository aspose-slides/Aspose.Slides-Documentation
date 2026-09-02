---
title: Kelola Bagian Slide dalam Presentasi dengan Python
linktitle: Bagian Slide
type: docs
weight: 100
url: /id/python-net/slide-section/
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
- Aspose.Slides
description: "Kelola bagian slide dengan Aspose.Slides untuk Python via .NET: buat, ganti nama, susun ulang, ambil, dan proses slide bagian dalam presentasi PPTX."
---
## **Pendahuluan**

Sections mengatur slide berurutan menjadi grup bernama tanpa mengubah konten slide. Dengan Aspose.Slides for Python via .NET, Anda dapat membuat, menyusun ulang, mengganti nama, memeriksa, dan menghapus bagian melalui properti [Presentation.sections](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/sections/).

Bagian sangat berguna ketika:

- presentasi yang besar perlu dibagi menjadi topik atau bab logis;
- grup slide yang berbeda ditugaskan kepada kolaborator yang berbeda;
- slide perlu diproses, dipindahkan, atau digabungkan sebagai grup.

Pilih nama bagian yang singkat yang menggambarkan tujuan slide yang dikelompokkan. Karena bagian merupakan bagian dari struktur presentasi, gunakan API bagian untuk menentukan keanggotaan alih‑alih menurunkannya dari posisi slide.

## **Buat dan Kelola Bagian**

Gunakan [SectionCollection.add_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/add_section/) untuk membuat sebuah bagian dengan menentukan namanya dan slide awal. Aspose.Slides menentukan slide mana yang termasuk dalam bagian tersebut dari struktur bagian presentasi saat ini.

[SectionCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/) yang sama juga memungkinkan Anda:

- memindahkan sebuah bagian bersama slide‑nya dengan menggunakan [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- menghapus hanya definisi bagian dengan [SectionCollection.remove_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/remove_section/), yang mempertahankan slidennya;
- menghapus sebuah bagian beserta slide‑nya dengan [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- menambahkan bagian kosong di akhir dengan [SectionCollection.append_empty_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/append_empty_section/).

Contoh berikut membuat dua bagian, memindahkan salah satunya, menghapusnya bersama slide‑nya, dan menambahkan bagian kosong:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Setelah operasi ini, presentasi berisi bagian `Introduction` dengan slide‑nya dan bagian kosong `Appendix`. Bagian `Results` beserta slide‑nya telah dihapus.

## **Ganti Nama Bagian**

Untuk mengganti nama sebuah bagian, atur properti [Section.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/name/). Slide dan posisi bagian tetap tidak berubah.

Contoh berikut membuat sebuah bagian dan mengubah namanya:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Ambil Slide dari Bagian**

Properti [Presentation.sections](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/sections/) mengembalikan sebuah [SectionCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/) yang dapat Anda iterasi. Untuk setiap [Section](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/), panggil [Section.get_slides_list_of_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/get_slides_list_of_section/) untuk memperoleh slide yang saat ini termasuk di dalamnya. Metode tersebut mengembalikan sebuah [SectionSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectionslidecollection/), yang menyediakan jumlah, akses terindeks, dan iterasi.

Contoh berikut membuat dua bagian terisi dan satu bagian kosong, lalu mencetak setiap bagian [name](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/started_from_slide/), jumlah slide, dan nomor slide. Ia menggunakan akses terindeks untuk membaca slide pertama dan loop `for` untuk memproses setiap slide. Untuk bagian kosong, koleksi yang dikembalikan memiliki jumlah nol, indeks tidak diakses, dan iterasi tidak melakukan langkah apa pun.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

Keanggotaan bagian ditentukan oleh struktur bagian presentasi. Jangan menghitung rentang bagian secara manual dari [Section.started_from_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/started_from_slide/), indeks slide, dan slide awal bagian berikutnya.

Pengeditan struktural dapat mengubah baik slide yang dikembalikan untuk sebuah bagian maupun nomor slide mereka. Ini termasuk menyusun ulang slide, mengkloning slide ke dalam sebuah bagian, memindahkan bagian bersama slide‑nya, menghapus slide, dan menghapus bagian. Contoh berikut memanggil [Section.get_slides_list_of_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/get_slides_list_of_section/) setelah setiap perubahan semacam itu alih‑alih mempertahankan asumsi tentang batas sebelumnya.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Panggil [Section.get_slides_list_of_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/get_slides_list_of_section/) lagi setiap kali slide atau bagian disusun ulang, dikloning, dipindahkan, atau dihapus. Ini memastikan pemrosesan selanjutnya selaras dengan struktur presentasi saat ini.

Format PPT (PowerPoint 97–2003) tidak mempertahankan metadata bagian. Gunakan alur kerja ini dengan format yang mendukung bagian, seperti PPTX; mengonversi ke PPT menghapus struktur bagian yang diperlukan untuk iterasi selanjutnya.

## **FAQ**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Sebuah bagian tidak memiliki status visibilitas. Untuk menyembunyikan isinya, atur properti [Slide.hidden](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/hidden/) untuk setiap slide dalam bagian tersebut.

**Bagaimana cara menemukan bagian yang berisi sebuah slide?**

Iterasi melalui [Presentation.sections](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/sections/), panggil [Section.get_slides_list_of_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/get_slides_list_of_section/) untuk setiap bagian, dan bandingkan slide yang dikembalikan dengan slide target. Untuk bagian yang tidak kosong, [Section.started_from_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/started_from_slide/) mengembalikan slide pertamanya; untuk bagian kosong, ia mengembalikan `None`.