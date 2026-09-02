---
title: Mencari dan Mengganti Teks dalam Presentasi PowerPoint di Python
linktitle: Mencari dan Mengganti Teks
type: docs
weight: 55
url: /id/python-net/search-and-replace-text/
keywords:
- pencarian teks
- menyorot teks
- ganti teks
- ekspresi reguler
- bingkai teks
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Mencari, menyorot, dan mengganti teks dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Aspose.Slides untuk Python via .NET dapat mencari, menyorot, dan mengganti teks dalam satu bingkai teks individu atau di seluruh presentasi. Kemampuan ini berguna untuk peninjauan, penyensoran, pemeriksaan terminologi, pembersihan templat, dan alur kerja pemrosesan dokumen otomatis lainnya.

Dalam contoh pertama di bawah ini, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) untuk membatasi operasi ke satu bingkai teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk memproses semua teks yang relevan dalam presentasi.

| Operasi | Satu bingkai teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [TextFrame.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_text/) |
| Sorot kecocokan ekspresi reguler | [TextFrame.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_regex/) |
| Ganti teks literal | [TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/replace_text/) |
| Ganti kecocokan ekspresi reguler | [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/replace_regex/) |

## **Konfigurasikan Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/) untuk mengontrol pencocokan:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/whole_words_only/) membatasi pencocokan hanya pada kata lengkap.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/case_sensitive/) mengontrol apakah huruf harus cocok.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/include_notes/) menyertakan catatan slide dalam pencarian, penggantian, dan operasi penyorotan tingkat presentasi.

Operasi ekspresi reguler menggunakan string pola, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh ekspresi tersebut.

## **Sorot Teks**

Gunakan metode [TextFrame.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_text/) untuk menyorot kecocokan teks literal dalam sebuah bingkai teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/) untuk mengontrol pencarian.

Contoh kode di bawah ini menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Sorot setiap kemunculan "try" dalam bingkai teks.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Sorot hanya kata lengkap "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [TextFrame.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_regex/) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah bingkai teks.

Kode berikut menyorot semua kata yang mengandung tujuh atau lebih karakter:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Hasilnya:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [Presentation.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_text/) dan [Presentation.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_regex/) untuk mencari semua bingkai teks yang relevan dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Ganti Teks dalam Bingkai Teks**

Gunakan [TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/) untuk teks literal dan [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) untuk penggantian berbasis pola. Metode ini memperbarui teks yang cocok di dalam bingkai teks yang ada, mempertahankan pemformatan bagian sekitarnya alih-alih membangun kembali bingkai teks dari string biasa.

Contoh berikut menstandarkan varian ejaan dan kemudian mengganti label versi:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Jika satu kecocokan meliputi bagian dengan pemformatan berbeda, tinjau output untuk memastikan pemformatan mana yang harus diterapkan pada teks pengganti.

## **Ganti Teks di Seluruh Presentasi**

Gunakan [Presentation.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/replace_text/) dan [Presentation.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/replace_regex/) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan penyensoran.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**Bagaimana saya dapat mencari hanya satu kotak teks alih-alih seluruh presentasi?**

Dapatkan bingkai teks dari shape dan panggil [TextFrame.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/), atau [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) pada bingkai teks tersebut. Metode tingkat presentasi memproses semua bingkai teks yang relevan.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Setel [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/whole_words_only/) dan [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/case_sensitive/) ke `True`, dan berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam pola itu sendiri.

**Apakah pencarian dan penggantian dapat menyertakan teks dalam catatan slide?**

Ya. Setel [TextSearchOptions.include_notes](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/include_notes/) ke `True` saat menggunakan operasi teks literal tingkat presentasi.

**Apakah mengganti teks mempertahankan formatnya?**

[TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/) dan [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) memodifikasi teks yang cocok di dalam bingkai teks yang ada dan mempertahankan pemformatan bagian sekitarnya. Jika satu kecocokan meliputi bagian dengan pemformatan berbeda, periksa hasilnya untuk memastikan penggantian menggunakan gaya yang diinginkan.