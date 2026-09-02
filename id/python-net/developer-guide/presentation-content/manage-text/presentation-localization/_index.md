---
title: Otomatisasi Lokalisasi Presentasi dengan Python
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/python-net/presentation-localization/
keywords:
- ubah bahasa
- periksa ejaan
- nonaktifkan pemeriksaan ejaan
- bahasa proofing
- id bahasa
- teks multibahasa
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Tetapkan bahasa proofing untuk teks presentasi PowerPoint dan OpenDocument di Python dengan Aspose.Slides, termasuk default dan paragraf multibahasa."
---
## **Gambaran Umum**

Aspose.Slides untuk Python melalui .NET memungkinkan Anda mengonfigurasi metadata proofing untuk bagian teks individu. Gunakan [BasePortionFormat.language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/language_id/) untuk mengidentifikasi bahasa proofing, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/spell_check/) untuk mengizinkan atau menonaktifkan pemeriksaan ejaan, dan [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/proof_disabled/) untuk mengontrol status no‑proof yang lebih luas. Karena pengaturan ini diterapkan pada tingkat bagian, satu paragraf dapat berisi beberapa bahasa dan aturan proofing yang berbeda.

Artikel ini menjelaskan cara menetapkan bahasa ke teks tertentu, mengatur bahasa default untuk teks baru dengan [LoadOptions.default_text_language](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/default_text_language/), membuat paragraf multibahasa, memilih antara `spell_check` dan `proof_disabled`, serta mempertahankan pengaturan yang dimaksud saat menggunakan [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Properti ini menyimpan metadata untuk aplikasi presentasi; mereka tidak menerjemahkan teks, melakukan pemeriksaan ejaan berbasis kamus, atau mengembalikan kata yang salah eja.

## **Tetapkan Bahasa Proofing untuk Teks**

Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/), akses bagian teks yang diperlukan melalui [Portion.portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/portion_format/), dan tetapkan pengenal bahasa-nya. Contoh berikut membuat sebuah shape, mengatur bahasa Inggris Britania sebagai bahasa proofing, dan menyimpan hasilnya dengan [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Tetapkan Bahasa Default untuk Teks Baru**

Gunakan [LoadOptions.default_text_language](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/default_text_language/) untuk menentukan bahasa proofing yang akan diberikan Aspose.Slides ke teks yang baru dibuat. Pengaturan ini berguna ketika sebagian besar atau seluruh teks baru dalam presentasi menggunakan bahasa yang sama. Ini tidak mengubah metadata bahasa pada teks yang sudah memiliki bahasa eksplisit.

Contoh berikut membuat sebuah presentasi di mana teks baru menggunakan aturan proofing bahasa Jerman:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Gunakan Beberapa Bahasa dalam Satu Paragraf**

Sebuah [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) berisi kumpulan bagian teks. Buat [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) terpisah untuk setiap bahasa dan atur `language_id`-nya secara independen.

Contoh ini membuat satu paragraf dengan bagian bahasa Inggris dan Prancis:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktifkan atau Nonaktifkan Pemeriksaan Eja untuk Bagian Individu**

[PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/) mewarisi properti teks umum yang didefinisikan oleh [BasePortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/). Akses format bagian melalui [Portion.portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/portion_format/) dan atur [BasePortionFormat.spell_check](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/spell_check/) untuk mengontrol apakah aplikasi presentasi boleh memeriksa ejaan untuk bagian tersebut. Nilai default adalah `False`: `True` memperbolehkan pemeriksaan ejaan, sedangkan `False` menonaktifkannya.

Pengaturan ini berlaku untuk bagian teks individu. Bagian yang berbeda dalam paragraf yang sama dapat menggunakan nilai yang berbeda. [BasePortionFormat.language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/language_id/) dan `spell_check` melayani tujuan yang komplementer: `language_id` mengidentifikasi bahasa proofing, sementara `spell_check` menentukan apakah pemeriksaan ejaan diizinkan untuk bagian tersebut.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/proof_disabled/) juga mengontrol proofing, tetapi mewakili status “tidak proof” yang lebih luas sebagai [NullableBool](https://reference.aspose.com/slides/id/python-net/aspose.slides/nullablebool/). Gunakan `spell_check` ketika Anda memerlukan saklar Boolean langsung khusus untuk pemeriksaan ejaan. Gunakan `proof_disabled` ketika Anda perlu mempertahankan atau secara eksplisit mengontrol metadata no‑proof presentasi, termasuk status `NOT_DEFINED`‑nya. Jika Anda mengatur kedua properti, jaga nilai keduanya konsisten; jangan menggabungkan `spell_check = True` dengan `proof_disabled = slides.NullableBool.TRUE`.

Properti ini mengonfigurasi metadata proofing yang digunakan oleh PowerPoint dan aplikasi presentasi lainnya. Aspose.Slides tidak menggunakan properti ini untuk menjalankan pemeriksaan ejaan berbasis kamus atau mengembalikan daftar kata yang salah eja.

Contoh lengkap berikut membuat sebuah presentasi input, memuatnya, menetapkan pengaturan pemeriksaan ejaan dan bahasa proofing yang berbeda ke dua bagian dalam paragraf yang sama, menyimpan hasilnya, membukanya kembali, dan memverifikasi nilai yang disimpan:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) menggabungkan bagian yang berdekatan yang memiliki format yang sama. Perbedaan pada `spell_check` saja tidak membuat bagian tetap terpisah; setelah digabung, bagian hasil mempertahankan nilai `spell_check` dari bagian pertama. Jika bagian memerlukan pengaturan pemeriksaan ejaan yang berbeda, panggil `join_portions_with_same_formatting` sebelum menetapkan pengaturan tersebut, atau periksa batas bagian yang dihasilkan dan terapkan kembali pengaturan setelahnya. Bagian dengan nilai `language_id` yang berbeda tetap terpisah karena format bahasa proofing mereka berbeda.

## **FAQ**

**Apakah ID bahasa menerjemahkan teks?**

Tidak. [BasePortionFormat.language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/language_id/) menyimpan metadata proofing untuk ejaan dan tata bahasa; ia tidak mengubah isi teks. Terjemahkan teks secara terpisah, kemudian tetapkan pengenal bahasa yang sesuai untuk setiap bagian yang telah diterjemahkan.

**Apakah bahasa proofing mengontrol jenis huruf, hyphenation, atau pembungkus baris?**

Tidak. Pengidentifikasi bahasa hanya untuk proofing. Rendering teks dan tata letak terutama bergantung pada [fonts](/slides/id/python-net/powerpoint-fonts/) yang tersedia, sistem penulisan, dan pengaturan bingkai teks. Untuk rendering yang dapat diandalkan, sediakan jenis huruf yang diperlukan, konfigurasikan [font substitution](/slides/id/python-net/font-substitution/), atau [embed fonts](/slides/id/python-net/embedded-font/) dalam presentasi.

**Bisakah satu paragraf menggunakan beberapa bahasa proofing?**

Ya. Tetapkan setiap bahasa ke bagian terpisah, seperti yang ditunjukkan dalam contoh paragraf multibahasa.

**Haruskah saya menggunakan `default_text_language` atau `language_id`?**

Gunakan [LoadOptions.default_text_language](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/default_text_language/) ketika Anda menginginkan bahasa default untuk teks yang baru dibuat. Gunakan [BasePortionFormat.language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/language_id/) ketika sebuah bagian tertentu memerlukan bahasa proofing eksplisit atau ketika sebuah paragraf berisi beberapa bahasa.