---
title: Otomatisasi Lokalisasi Presentasi dengan Python
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/python-net/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- id bahasa
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Otomatisasi lokalisasi slide PowerPoint dan OpenDocument dalam Python dengan Aspose.Slides, menggunakan contoh kode praktis dan tip untuk peluncuran global yang lebih cepat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengatur `language_id` untuk teks dalam presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuka presentasi, menambahkan bentuk dengan teks, menetapkan pengidentifikasi bahasa ke bagian teks, dan menyimpan hasilnya sebagai file PPTX.

## **Ubah Bahasa untuk Presentasi dan Teks Bentuk**
- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Rectangle ke slide.
- Tambahkan beberapa teks ke TextFrame.
- Mengatur Language Id pada teks.
- Tulis presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas diperlihatkan di bawah dalam contoh.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah language ID memicu terjemahan teks otomatis?**

Tidak. [language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/language_id/) di Aspose.Slides menyimpan bahasa untuk pemeriksaan ejaan dan tata bahasa, tetapi tidak menerjemahkan atau mengubah isi teks. Itu adalah metadata yang dipahami PowerPoint untuk pemeriksaan.

**Apakah language ID memengaruhi hyphenation dan pemotongan baris saat rendering?**

Di Aspose.Slides, [language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/language_id/) digunakan untuk proofing. Kualitas hyphenation dan pembungkusan baris terutama bergantung pada ketersediaan [font yang tepat](/slides/id/python-net/powerpoint-fonts/) serta pengaturan tata letak/pemotongan baris untuk sistem penulisan. Untuk memastikan rendering yang benar, sediakan font yang diperlukan, konfigurasikan [aturan substitusi font](/slides/id/python-net/font-substitution/), dan/atau [sematkan font](/slides/id/python-net/embedded-font/) ke dalam presentasi.

**Bisakah saya mengatur bahasa yang berbeda dalam satu paragraf?**

Ya. [language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/language_id/) diterapkan pada level bagian teks, sehingga satu paragraf dapat mencampur beberapa bahasa dengan pengaturan proofing yang berbeda.