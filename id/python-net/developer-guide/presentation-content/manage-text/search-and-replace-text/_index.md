---
title: Cari dan Ganti Teks dalam Presentasi PowerPoint di Python
linktitle: Cari dan Ganti Teks
type: docs
weight: 55
url: /id/python-net/search-and-replace-text/
keywords:
- cari teks
- sorot teks
- ganti teks
- ekspresi reguler
- frame teks
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Cari, sorot, dan ganti teks dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET dapat mencari, menyorot, dan mengganti teks dalam satu frame teks atau di seluruh presentasi. Kemampuan ini berguna untuk peninjauan, penyensoran, pemeriksaan terminologi, pembersihan templat, dan alur kerja pemrosesan dokumen otomatis lainnya.

Pada contoh pertama di bawah ini, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) untuk membatasi operasi pada satu frame teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk memproses semua teks yang relevan dalam presentasi.

| Operasi | Satu frame teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [TextFrame.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_text/) |
| Sorot kecocokan ekspresi reguler | [TextFrame.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_regex/) |
| Ganti teks literal | [TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/replace_text/) |
| Ganti kecocokan ekspresi reguler | [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/replace_regex/) |

## **Konfigurasi Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/) untuk mengontrol pencocokan:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/whole_words_only/) membatasi kecocokan hanya pada kata lengkap.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/case_sensitive/) mengontrol apakah huruf besar/kecil harus cocok.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/include_notes/) menyertakan catatan slide dalam operasi pencarian, penggantian, dan penyorotan pada tingkat presentasi.

Operasi ekspresi reguler menggunakan string pola, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh ekspresi tersebut.

## **Identifikasi Pemilik Frame Teks**

Alur kerja pemrosesan teks umum sering menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) saat mencari, mengganti, memvalidasi, atau mengekspor teks. Gunakan [TextFrame.parent_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_shape/) dan [TextFrame.parent_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_cell/) untuk menentukan objek presentasi mana yang memiliki frame teks tersebut.

Nilai yang diharapkan tergantung pada pemilik:

| Pemilik frame teks | `parent_shape` | `parent_cell` |
|---|---|---|
| Sebuah AutoShape atau bentuk lain yang berisi teks | pemilik [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) | `None` |
| Sebuah sel tabel | `None` | pemilik [Cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/) |

Kedua properti tersebut adalah properti navigasi baca-saja. Membacanya tidak memindahkan frame teks atau mengubah pemiliknya. Kode umum harus memeriksa kedua nilai untuk `None` dan menangani kemungkinan bahwa tidak ada pemilik yang tersedia.

Contoh berikut menggunakan [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/get_all_text_frames/) untuk mengiterasi frame teks dalam sebuah presentasi. Untuk shape, contoh ini melaporkan nama shape, tipe runtime Python, dan slide yang memuatnya. Untuk sel tabel, contoh ini melaporkan koordinat kolom dan baris berbasis nol serta slide yang memuatnya.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Untuk konten SmartArt, iterasi shape dalam [SmartArtNode.shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartartnode/shapes/) dan akses tiap [ISmartArtShape.text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Frame teks dapat ditelusuri ke shape terkait melalui [TextFrame.parent_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_shape/), sementara [TextFrame.parent_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_cell/) bernilai `None`. Oleh karena itu, cabang shape dalam contoh juga menangani teks dari node SmartArt.

## **Sorot Teks**

Gunakan metode [TextFrame.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_text/) untuk menyorot kecocokan teks literal dalam sebuah frame teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/) untuk mengontrol pencarian.

Contoh kode di bawah ini menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Sorot setiap kemunculan "try" dalam frame teks.
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

Metode [TextFrame.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_regex/) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah frame teks.

Kode berikut menyorot semua kata yang mengandung tujuh karakter atau lebih:

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

Gunakan [Presentation.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_text/) dan [Presentation.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/highlight_regex/) untuk mencari semua frame teks yang relevan dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email:

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

## **Ganti Teks dalam Frame Teks**

Gunakan [TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/) untuk teks literal dan [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) untuk penggantian berbasis pola. Metode ini memperbarui teks yang cocok dalam frame teks yang ada, yang mempertahankan format bagian sekitarnya alih-alih membangun kembali frame teks dari string biasa.

Contoh berikut menstandarisasi varian ejaan dan kemudian mengganti label versi:

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

Jika satu kecocokan melintasi bagian dengan format berbeda, tinjau output untuk mengonfirmasi format mana yang harus diterapkan pada teks pengganti.

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

Dapatkan frame teks shape dan panggil [TextFrame.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/), atau [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) pada frame teks tersebut. Metode tingkat presentasi memproses semua frame teks yang relevan sebagai gantinya.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Setel [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/whole_words_only/) dan [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/case_sensitive/) ke `True`, dan berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam pola itu sendiri.

**Apakah pencarian dan penggantian dapat mencakup teks dalam catatan slide?**

Ya. Setel [TextSearchOptions.include_notes](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/include_notes/) ke `True` saat menggunakan operasi teks literal tingkat presentasi.

**Apakah mengganti teks mempertahankan formatnya?**

[TextFrame.replace_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_text/) dan [TextFrame.replace_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/replace_regex/) memodifikasi teks yang cocok dalam frame teks yang ada dan mempertahankan format bagian sekitarnya. Jika satu kecocokan melintasi bagian dengan format berbeda, periksa hasilnya untuk memastikan pengganti menggunakan gaya yang diinginkan.