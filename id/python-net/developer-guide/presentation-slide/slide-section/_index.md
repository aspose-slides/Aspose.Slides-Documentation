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
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Permudah pengelolaan bagian slide di PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python — bagi, ubah nama, dan urutkan kembali untuk mengoptimalkan alur kerja PPTX dan ODP."
---
## **Pendahuluan**

Dengan Aspose.Slides for Python, Anda dapat mengatur presentasi PowerPoint ke dalam bagian yang mengelompokkan slide tertentu.

Anda mungkin ingin membuat bagian untuk mengatur atau membagi presentasi menjadi bagian logis dalam situasi berikut:

- Saat Anda bekerja pada presentasi besar dengan tim dan perlu menugaskan slide tertentu kepada kolega tertentu.
- Saat Anda menangani presentasi yang berisi banyak slide dan merasa sulit mengelola atau mengedit semuanya sekaligus.

Idealnya, buatlah bagian yang mengelompokkan slide yang terkait—yang memiliki tema, topik, atau tujuan yang sama—dan beri setiap bagian nama yang jelas mencerminkan isinya. 

## **Buat Bagian dalam Presentasi**

Untuk menambahkan sebuah [Section](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/) yang mengelompokkan slide dalam sebuah presentasi, Aspose.Slides menyediakan metode [add_section](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectioncollection/add_section/). Metode ini memungkinkan Anda menentukan nama bagian dan slide tempat bagian tersebut dimulai.

Contoh Python berikut memperlihatkan cara membuat bagian dalam sebuah presentasi:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Bagian 1 berakhir pada slide2; Bagian 2 dimulai pada slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Ubah Nama Bagian**

Setelah membuat sebuah [Section](https://reference.aspose.com/slides/id/python-net/aspose.slides/section/) dalam presentasi PowerPoint, Anda mungkin memutuskan untuk mengubah namanya.

Contoh Python berikut memperlihatkan cara mengganti nama bagian dalam sebuah presentasi:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Apakah bagian tetap dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Hanya slide individu yang dapat disembunyikan. Sebuah bagian sebagai entitas tidak memiliki status "disembunyikan".

**Apakah saya dapat dengan cepat menemukan sebuah bagian berdasarkan slide dan, sebaliknya, slide pertama dari sebuah bagian?**

Ya. Sebuah bagian didefinisikan secara unik oleh slide awalnya; diberikan sebuah slide Anda dapat menentukan bagian mana yang menjadi miliknya, dan untuk sebuah bagian Anda dapat mengakses slide pertamanya.