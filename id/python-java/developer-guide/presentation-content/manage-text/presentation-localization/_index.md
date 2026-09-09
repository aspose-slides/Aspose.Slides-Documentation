---
title: Otomatisasi Lokalisasi Presentasi dalam Python via Java
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/python-java/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- nonaktifkan pemeriksaan ejaan
- bahasa proofing
- ID bahasa
- teks multibahasa
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Tetapkan bahasa proofing untuk teks presentasi PowerPoint dan OpenDocument dalam Python via Java dengan Aspose.Slides, termasuk bahasa default dan paragraf multibahasa."
---
## **Ikhtisar**

Aspose.Slides for Python via Java memungkinkan Anda mengonfigurasi metadata proofing untuk bagian teks individu. Gunakan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) untuk mengidentifikasi bahasa proofing, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) untuk mengizinkan atau menekan pemeriksaan ejaan, dan [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setProofDisabled) untuk mengontrol status “no‑proof” yang lebih luas. Karena pengaturan ini diterapkan pada tingkat bagian, satu paragraf dapat berisi beberapa bahasa dan aturan proofing yang berbeda.

Artikel ini menjelaskan cara menetapkan bahasa ke teks tertentu, menetapkan bahasa default untuk teks baru dengan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), membuat paragraf multibahasa, memilih antara [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) dan [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setProofDisabled), serta mempertahankan pengaturan yang dimaksud saat menggunakan [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Properti ini menyimpan metadata untuk aplikasi presentasi; mereka tidak menerjemahkan teks, melakukan pemeriksaan ejaan berbasis kamus, atau mengembalikan kata yang salah eja.

## **Menetapkan Bahasa Proofing untuk Teks**

Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), akses bagian teks yang diperlukan melalui [Portion.getPortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getPortionFormat), dan tetapkan pengenal bahasa-nya. Contoh berikut membuat sebuah shape, menetapkan Bahasa Inggris Britania sebagai bahasa proofing, dan menyimpan hasilnya dengan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menetapkan Bahasa Default untuk Teks Baru**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) untuk menentukan bahasa proofing yang akan diberikan Aspose.Slides ke teks yang baru dibuat. Pengaturan ini berguna ketika sebagian besar atau seluruh teks baru dalam presentasi menggunakan bahasa yang sama. Pengaturan ini tidak mengubah metadata bahasa teks yang sudah memiliki bahasa eksplisit.

Contoh berikut membuat sebuah presentasi yang teks barunya menggunakan aturan proofing Bahasa Jerman:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gunakan Beberapa Bahasa dalam Satu Paragraf**

Sebuah [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) berisi kumpulan bagian teks. Buat [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) terpisah untuk setiap bahasa dan tetapkan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) secara independen.

Contoh ini membuat satu paragraf dengan bagian Bahasa Inggris dan Prancis:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aktifkan atau Nonaktifkan Pemeriksaan Ejaan untuk Bagian Individual**

[PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/) mewarisi properti teks umum yang didefinisikan oleh [BasePortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/). Akses format bagian melalui [Portion.getPortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getPortionFormat) dan gunakan [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) untuk mengontrol apakah aplikasi presentasi boleh memeriksa ejaan untuk bagian tersebut. Nilai default adalah `False`: `True` mengizinkan pemeriksaan ejaan, sementara `False` menekannya.

Pengaturan ini berlaku untuk bagian teks individual. Bagian yang berbeda dalam paragraf yang sama dapat menggunakan nilai yang berbeda. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) dan [setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) memiliki tujuan yang saling melengkapi: [setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) mengidentifikasi bahasa proofing, sedangkan [setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) menentukan apakah pemeriksaan ejaan diizinkan untuk bagian tersebut.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setProofDisabled) juga mengontrol proofing, tetapi mewakili status “jangan proof” yang lebih luas sebagai [NullableBool](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/). Gunakan [setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) ketika Anda memerlukan saklar Boolean langsung khusus untuk pemeriksaan ejaan. Gunakan [setProofDisabled](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setProofDisabled) ketika Anda perlu mempertahankan atau secara eksplisit mengontrol metadata no‑proof presentasi, termasuk status [NullableBool.NotDefined](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/#NotDefined). Jika Anda mengatur kedua properti, pertahankan nilai mereka konsisten; jangan menggabungkan [setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) yang diset ke `True` dengan [setProofDisabled](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setProofDisabled) yang diset ke status [NullableBool.True](https://reference.aspose.com/slides/id/python-java/aspose.slides/nullablebool/#True).

Properti ini mengkonfigurasi metadata proofing yang digunakan oleh PowerPoint dan aplikasi presentasi lainnya. Aspose.Slides tidak menggunakan properti ini untuk menjalankan pemeriksaan ejaan berbasis kamus atau mengembalikan daftar kata yang salah eja.

Contoh lengkap berikut membuat sebuah presentasi input, memuatnya, menetapkan pengaturan pemeriksaan ejaan dan bahasa proofing yang berbeda ke dua bagian dalam paragraf yang sama, menyimpan hasilnya, membukanya kembali, dan memverifikasi nilai yang disimpan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) menggabungkan bagian‑bagian bersebelahan yang memiliki format yang sama. Perbedaan pada [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) saja tidak membuat bagian‑bagian tersebut tetap terpisah; setelah digabung, bagian yang dihasilkan mempertahankan nilai [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setSpellCheck) dari bagian pertama. Jika bagian‑bagian memerlukan pengaturan pemeriksaan ejaan yang berbeda, panggil [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) sebelum menetapkan pengaturan tersebut, atau periksa batas‑batas bagian yang dihasilkan dan terapkan ulang pengaturan setelahnya. Bagian‑bagian dengan nilai [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) yang berbeda tetap terpisah karena format bahasa proofing mereka berbeda.

## **FAQ**

**Apakah ID bahasa menerjemahkan teks?**

Tidak. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) menyimpan metadata proofing untuk ejaan dan tata bahasa; ia tidak mengubah isi teks. Terjemahkan teks secara terpisah, kemudian tetapkan pengenal bahasa yang tepat untuk setiap bagian yang telah diterjemahkan.

**Apakah bahasa proofing mengontrol font, pemenggalan, atau pembungkus baris?**

Tidak. Pengidentifikasi bahasa hanya untuk proofing. Rendering teks dan tata letak terutama bergantung pada [font](/slides/id/python-java/powerpoint-fonts/) yang tersedia, sistem tulisan, dan pengaturan bingkai teks. Untuk rendering yang dapat diandalkan, sediakan font yang dibutuhkan, konfigurasikan [penggantian font](/slides/id/python-java/font-substitution/), atau [sematkan font](/slides/id/python-java/embedded-font/) dalam presentasi.

**Apakah satu paragraf dapat menggunakan beberapa bahasa proofing?**

Ya. Tetapkan setiap bahasa ke bagian terpisah, seperti yang ditunjukkan pada contoh paragraf multibahasa.

**Haruskah saya menggunakan [setDefaultTextLanguage](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) atau [setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) ketika Anda menginginkan bahasa default untuk teks yang baru dibuat. Gunakan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) ketika sebuah bagian khusus membutuhkan bahasa proofing eksplisit atau ketika sebuah paragraf berisi beberapa bahasa.