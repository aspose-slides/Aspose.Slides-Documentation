---
title: Format Teks Presentasi dalam Python
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/python-net/text-formatting/
keywords:
- penyelarasan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- keluarga font
- rotasi teks
- sudut rotasi
- bingkai teks
- jarak baris
- properti autofit
- jangkar bingkai teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Format dan tata gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python melalui .NET. Artikel ini mencakup warna latar belakang, transparansi, jarak antar karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tab stop, dan pengaturan bahasa.

Kecuali dinyatakan lain, contoh menggunakan [sample.pptx](sample.pptx). Bentuk pertama pada slide pertama adalah kotak teks, dan paragraf pertamanya berisi teks yang ditampilkan di bawah. Indeks slide dan bentuk keduanya menggunakan basis nol. Contoh yang memilih bagian tebal menggunakan pemformatan efektif, termasuk pemformatan tebal yang diwariskan:

![Teks contoh](sample_text.png)

Untuk menemukan dan menyorot teks literal atau kecocokan ekspresi reguler, lihat [Cari dan Ganti Teks](/slides/id/python-net/search-and-replace-text/).

## **Atur Warna Latar Belakang Teks**

Gunakan [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) untuk mengatur warna sorotan default untuk sebuah paragraf, atau gunakan [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) untuk bagian teks individu.

Contoh berikut mengatur sorotan abu‑abu terang sebagai default untuk paragraf pertama. Warna sorotan eksplisit pada bagian individu memiliki prioritas lebih tinggi daripada default ini:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Atur warna sorotan untuk seluruh paragraf.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Paragraf abu-abu](gray_paragraph.png)

Contoh kode di bawah ini menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Atur warna sorotan untuk bagian teks.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bagian teks abu-abu](gray_text_portions.png)

## **Ratakan Paragraf Teks**

Gunakan [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) untuk mengatur perataan paragraf dalam bingkai teks. Nilainya dapat berupa tengah, rata kiri, rata kanan, rata kanan‑kiri, dan sebagainya.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Atur perataan paragraf ke tengah.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Paragraf yang diratakan](aligned_paragraph.png)

## **Ratakan Font Dalam Baris**

Gunakan [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) untuk meratakan secara vertikal bagian teks dengan ukuran font yang berbeda dalam satu baris. Pengaturan ini berlaku untuk seluruh paragraf dan mengontrol perataan dalam setiap barisnya.

Contoh mandiri berikut membuat empat kotak teks berlabel pada satu slide. Setiap paragraf berisi teks yang sama dengan ukuran 18, 36, dan 54 poin, dengan perataan font yang berbeda. Contoh ini menggunakan Arial, menonaktifkan autofit dan wrapping, serta menjaga bingkai teks cukup besar untuk satu baris.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Perbandingan perataan font Baseline, Atas, Tengah, dan Bawah dengan ukuran font campuran](font_alignment.png)

Perataan font menggunakan metrik font, sehingga tepi visual huruf individu tidak selalu berbaris secara tepat. Contoh ini mencakup huruf kapital dan huruf dengan descender untuk menunjukkan perbedaan antara perataan baseline dan bottom. Ketersediaan dan substitusi font, karakter yang digunakan, serta perbedaan ukuran font memengaruhi hasil. Dimensi bingkai, margin, jarak baris, wrapping, dan autofit juga memengaruhi tata letak; gunakan font dan pengaturan tata letak yang sama saat membandingkan mode.

Pengaturan ini berbeda dari [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), yang mengontrol perataan horizontal paragraf, dan [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), yang menempatkan blok teks secara vertikal di dalam bentuknya. Pemformatan superskrip dan subskrip melalui [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) menggeser bagian individu relatif terhadap baseline alih‑alih mengatur perataan font untuk baris paragraf.

## **Atur Transparansi untuk Teks**

Transparansi teks dikontrol melalui komponen alfa dari warna yang ditetapkan pada [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Pada contoh di bawah, `alpha = 50` adalah nilai kanal alfa ARGB pada skala 0‑255, bukan persentase transparansi.

Contoh kode di bawah ini menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Atur isian hitam setengah transparan untuk teks.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **bagian teks dengan font tebal**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Atur transparansi bagian teks.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bagian teks transparan](transparent_text_portions.png)

## **Atur Jarak Karakter untuk Teks**

Gunakan [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) untuk memperluas atau memperkecil jarak antara karakter dalam kotak teks. Contoh‑contoh menambahkan 3 poin jarak; nilai negatif memperkecil teks.

Kode Python berikut menunjukkan cara memperluas jarak karakter dalam **seluruh paragraf**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Catatan: Gunakan nilai negatif untuk memperkecil jarak karakter.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Perluas jarak karakter.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Jarak karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode di bawah ini menunjukkan cara memperluas jarak karakter dalam **bagian teks dengan font tebal**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Catatan: Gunakan nilai negatif untuk memperkecil jarak karakter.
            portion.portion_format.spacing = 3  # Perluas jarak karakter.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Jarak karakter dalam bagian teks](character_spacing_in_text_portions.png)

### **Nonaktifkan Kerning untuk Font Tertentu**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides mungkin terlihat sedikit lebih rapat daripada teks yang sama di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan dalam pengaturan PowerPoint.

Untuk membuat output yang dirender lebih mendekati PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terdampak. Setel [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) ke nilai yang lebih besar daripada ukuran font sebenarnya. Contoh ini memerlukan “presentation.pptx” dengan kotak teks sebagai bentuk pertama pada slide pertama. Ia memeriksa nama font efektif, termasuk font yang diwariskan, dan menetapkan ambang 100 poin untuk bagian yang menggunakan Roboto. Ini menonaktifkan kerning untuk bagian yang cocok dengan ukuran font di bawah 100 poin:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Untuk teks yang cocok di bawah ambang, pengaturan ini mencegah kerning dan dapat membantu menyelaraskan hasil render Aspose.Slides dengan tampilan visual PowerPoint untuk font yang dipengaruhi perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada tingkat paragraf melalui [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) atau pada bagian individu melalui [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Contoh berikut mengatur font default paragraf pertama menjadi Times New Roman 12 poin dengan format tebal, miring, dan garis bawah titik. Pemformatan eksplisit pada bagian individu memiliki prioritas lebih tinggi daripada default ini.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Atur properti font untuk paragraf.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh berikut menerapkan Times New Roman 13 poin, format miring, dan garis bawah titik pada bagian yang pemformatannya efektif tebal:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Atur properti font untuk bagian teks.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Properti font untuk bagian teks](font_properties_for_text_portions.png)

## **Kontrol Normalisasi Tinggi Teks**

Gunakan [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) saat mereproduksi tipografi templat atau menyelidiki perbedaan tinggi karakter. Di PowerPoint, mengaktifkan normalisasi meregangkan atau memperkecil karakter secara vertikal agar memiliki tinggi visual yang seragam dalam bagian teks. Ini tidak menjamin tinggi teks yang sama pada font yang berbeda.

Setel properti ke [NullableBool.TRUE atau FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) untuk secara eksplisit mengaktifkan atau menonaktifkan normalisasi. `NullableBool.NOT_DEFINED` membiarkan pengaturan lokal tidak ditetapkan sehingga bagian tersebut mewarisi nilainya, misalnya dari [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) paragraf. Ini bukan berarti `False`. Gunakan [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) dan baca [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) untuk memperoleh nilai Boolean yang telah diselesaikan.

Contoh mandiri berikut memerlukan **Arial** terpasang. Ia membuat dua blok teks yang berisi huruf kapital, huruf kecil, descender, dan karakter beraksen yang sama pada 54 poin. Kedua paragraf mengaktifkan normalisasi secara default. Bagian atas secara eksplisit menonaktifkannya; bagian bawah mewarisinya. Ukuran bingkai, margin, dan jarak paragraf identik, dengan wrapping dan autofit dinonaktifkan untuk menjaga perbandingan konsisten. Contoh mencetak `FALSE: False` dan `NOT_DEFINED: True`, lalu menyimpan “text_height_normalization.pptx”.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Perbandingan di bawah diekspor dari presentasi yang disimpan. Baris atas memiliki normalisasi dinonaktifkan (`FALSE`); baris bawah mewarisi pengaturan yang diaktifkan (`NOT_DEFINED` → `True`). Pastikan Arial terpasang untuk mereproduksi tampilan ini.

![Arial 54‑poin teks dengan normalisasi dinonaktifkan di atas dan normalisasi yang diwariskan di bawah](text_height_normalization.png)

Normalisasi mengubah tinggi karakter tanpa mengubah nilai [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) yang ditetapkan, yang menentukan ukuran font dalam poin. [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) paragraf mengontrol jarak baris, sementara [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) bingkai teks mengontrol cara teks atau kontainernya menyesuaikan diri. Pengaturan ini memiliki tujuan berbeda dan dapat memengaruhi tata letak keseluruhan secara independen. Untuk informasi lebih lanjut tentang pemformatan paragraf dan pewarisan, lihat [Kelola Paragraf](/slides/id/python-net/manage-paragraph/).

## **Terapkan dan Hapus Garis Coret**

Gunakan [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) pada bagian teks untuk menampilkan koreksi, istilah yang dibatalkan, atau harga sebelumnya tanpa menghapus teks asli. Setel ke [TextStrikethroughType.SINGLE atau DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) untuk satu atau dua garis melintasi teks.

Untuk menghapus garis coret, tetapkan `TextStrikethroughType.NONE`. Ini secara eksplisit menonaktifkan efek tersebut, bahkan jika pemformatan sekitarnya menentukan garis coret. Sebaliknya, `TextStrikethroughType.NOT_DEFINED` membiarkan pengaturan lokal tidak ditetapkan, memungkinkan bagian tersebut mewarisi pemformatan, misalnya dari paragraf. Ini tidak menjamin garis coret dihapus. Gunakan [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) untuk membaca pemformatan hasil, termasuk nilai yang diwariskan.

Contoh mandiri berikut membuat tiga perbandingan harga. Setiap paragraf memiliki bagian terpisah untuk label, harga sebelumnya, dan harga saat ini, sehingga hanya harga sebelumnya yang terpengaruh. Baris pertama menerapkan lalu menghapus garis coret; baris lainnya mempertahankan garis coret tunggal dan ganda. Mengubah properti ini mempertahankan teks dan pemformatan lainnya, termasuk harga sebelumnya yang tebal.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Terapkan garis coret, lalu hapus secara eksplisit dari harga sebelumnya pertama.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Hasil, dari atas ke bawah: tanpa garis coret, garis coret tunggal, dan garis coret ganda.

![Harga sebelumnya tanpa garis coret, dengan garis coret tunggal, dan dengan garis coret ganda](strikethrough.png)

## **Atur Rotasi Teks**

Gunakan [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) untuk menetapkan orientasi teks yang sudah ditentukan dalam sebuah bentuk.

Contoh kode berikut menetapkan orientasi teks dalam bentuk ke [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), yang memutar teks **90 derajat berlawanan arah jarum jam**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Rotasi teks](text_rotation.png)

## **Atur Rotasi Kustom untuk Bingkai Teks**

Gunakan [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) untuk menetapkan sudut rotasi kustom untuk sebuah [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Contoh kode di bawah ini memutar bingkai teks sebesar 3 derajat searah jarum jam dalam bentuk:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Rotasi teks kustom](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), dan [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) untuk mengontrol jarak paragraf. Properti‑properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh berikut mengatur jarak dalam paragraf pertama menjadi 200 % dari tinggi baris (jarak ganda):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Jarak baris dalam paragraf](line_spacing.png)

## **Kontrol Pemutusan Baris**

Aturan pemutusan baris paragraf berguna dalam blok teks sempit dan presentasi yang mencampur teks Latin dan Asia Timur. Properti‑properti berikut milik [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), sehingga berlaku untuk seluruh paragraf:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) mengontrol aturan pemutusan baris Latin. Pada teks campuran, mengubahnya juga dapat mengubah tempat teks Asia Timur dan tanda baca yang berdekatan terbungkus.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) mengontrol aturan pemutusan baris Asia Timur, termasuk pembatasan pada karakter di awal dan akhir baris.

Aturan‑aturan ini tidak menggantikan [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), yang mengaktifkan pembungkusan otomatis dalam bingkai teks. Mereka memengaruhi tata letak ketika pembungkusan terjadi; mereka tidak menyisipkan karakter pemutusan baris. Pemutusan baris eksplisit memaksa baris baru dalam paragraf terlepas dari lebar yang tersedia.

Contoh mandiri berikut membuat blok teks sempit yang berisi teks Cina dan Latin. Ia secara eksplisit menetapkan kedua properti pemutusan baris dan menyimpan “line_breaking.pptx”. Untuk bereksperimen dengan salah satu aturan, ubah nilai properti tersebut sambil membiarkan pengaturan lainnya tetap. Contoh ini menggunakan Arial 24 poin dan SimSun dengan lebar bingkai 160 poin serta margin horizontal bingkai teks nol. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) diset ke [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) sehingga ukuran teks dan dimensi bingkai tetap tetap.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrol Tanda Baca Menggantung**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) memungkinkan tanda baca yang memenuhi syarat menjorok keluar melewati tepi kanan baris teks alih‑alih menempati baris berikutnya. Ini berlaku untuk seluruh paragraf dan berbeda dari indent menggantung.

Contoh mandiri berikut mengaktifkan tanda baca menggantung dalam bingkai teks lebar 100 poin dan menyimpan “hanging_punctuation.pptx”. Dengan Arial 24 poin dan margin horizontal bingkai teks nol, titik akhir akhir tetap setelah “sentence” dan menjorok melewati tepi kanan teks. Setel properti ke [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) untuk membandingkan: dengan pengaturan ini, titik berada pada baris terpisah. Wrapping diaktifkan dan autofit dinonaktifkan untuk menjaga lebar yang tersedia tetap.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Tidak setiap tanda baca dapat menggantung. Hasil visual tergantung pada [kondisi font dan tata letak](#control-line-breaking): mengubah font, lebar yang tersedia, margin, atau pengaturan autofit dapat menghilangkan perbedaan visual.

## **Atur Tipe Autofit untuk Bingkai Teks**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) menentukan bagaimana teks berperilaku ketika melebihi batas wadahnya. Gunakan untuk mengontrol apakah teks menyusut, meluap, atau mengubah ukuran bentuk secara otomatis. Contoh berikut mengkonfigurasi bentuk untuk mengubah ukuran agar sesuai dengan teksnya dan menyimpan hasil ke “autofit_type.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Untuk menghitung baris setelah pembungkusan otomatis dan melihat bagaimana lebar teks atau bentuk mengubah hasil, lihat [Hitung Baris yang Dirender](/slides/id/python-net/manage-paragraph/). Jumlah baris saja tidak menunjukkan apakah teks meluap dari wadahnya.

## **Atur Penambat Bingkai Teks**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) menentukan bagaimana teks diposisikan secara vertikal di dalam bentuk, misalnya di atas, tengah, atau bawah. Contoh berikut menambatkan teks ke bagian bawah bentuk pertama dan menyimpan hasil ke “text_anchor.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Tabulasi Teks**

Gunakan [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) dan [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) untuk mengkonfigurasi tab stop dalam sebuah paragraf. Contoh berikut menetapkan interval tab default menjadi 100 poin dan menambahkan tab stop rata kiri pada 30 poin. Pengaturan ini memengaruhi teks yang mengandung karakter tab.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Tab paragraf](paragraph_tabs.png)

## **Atur Bahasa Pemeriksaan Ejaan**

Aspose.Slides menyediakan [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), yang memungkinkan Anda menetapkan bahasa pemeriksaan ejaan untuk sebuah bagian teks. Bahasa pemeriksaan menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh berikut memerlukan “presentation.pptx” dengan kotak teks sebagai bentuk pertama pada slide pertama dan setidaknya satu paragraf. Ia mengganti isi paragraf pertama dengan “1。”, menetapkan SimSun sebagai fontnya, dan menetapkan bahasa pemeriksaan Simplified Chinese (`zh-CN`). Ia menyimpan hasil ke “proofing_language.pptx”:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Atur bahasa pemeriksaan ke Bahasa Mandarin Sederhana.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Salin Metadata Bahasa**

Saat menyalin teks multibahasa dari sebuah templat, pertahankan baik [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) maupun [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Contoh mandiri berikut membuat bagian sumber dengan bahasa Inggris AS sebagai bahasa utama dan Prancis sebagai bahasa alternatif, lalu menyalin teks dan pengidentifikasi ke bagian dalam presentasi baru.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Jika sumber tidak memiliki bahasa alternatif, None menghapus nilai tujuan.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Untuk mencoba sumber tanpa bahasa alternatif, hapus penetapan `"fr-FR"`. Pengidentifikasi alternatif kemudian menjadi `None`, dan pernyataan salin yang sama mempertahankan ketidakhadirannya tanpa memperkenalkan nilai default, bahkan jika tujuan sebelumnya memiliki bahasa alternatif yang ditetapkan.

Pengidentifikasi‑pengidentifikasi ini menyimpan metadata bahasa. Mempertahankannya tidak menetapkan kamus mana yang dipilih PowerPoint untuk pemeriksaan ejaan atau tata bahasa.

## **Atur Bahasa Default**

Gunakan [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) untuk menentukan bahasa default untuk teks yang dibuat saat memuat atau membuat presentasi. Contoh berikut membuat presentasi dengan bahasa teks default Bahasa Inggris AS, menambahkan kotak teks, dan mencetak `en-US` untuk bagian teks pertamanya.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Tambahkan bentuk persegi panjang baru dengan teks.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Periksa bahasa bagian pertama.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Atur Gaya Teks Default**

Untuk menerapkan pemformatan teks default pada tingkat presentasi, gunakan [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Contoh berikut menetapkan font tebal 14 poin sebagai default untuk paragraf tingkat atas dalam presentasi baru dan menyimpannya ke “default_text_style.pptx”. Teks dapat mewarisi default ini kecuali pemformatan yang lebih spesifik menggantikannya.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Dapatkan format paragraf tingkat atas.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Ekstrak Teks dengan Efek Semua Huruf Besar**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks tampil dalam huruf kapital pada slide meskipun awalnya diketik dengan huruf kecil. Saat Anda mengambil bagian teks tersebut dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf kapital ketika nilainya `ALL`.

Contoh ini memerlukan “sample2.pptx” dengan kotak teks sebagai bentuk pertama pada slide pertama. Bagian pertama paragraf pertamanya berisi “Hello, Aspose!” dengan efek All Caps diterapkan, seperti ditampilkan di bawah.

![Efek All Caps](all_caps_effect.png)

Contoh kode di bawah ini menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara memodifikasi teks dalam tabel pada slide?**

Untuk memodifikasi teks dalam tabel pada slide, gunakan [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Iterasi melalui sel‑sel dan perbarui setiap sel melalui [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) serta pemformatan paragraf melalui [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Bagaimana cara menerapkan warna gradasi pada teks di slide PowerPoint?**

Untuk menerapkan warna gradasi pada teks, gunakan [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Setel [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) ke [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) dan konfigurasikan titik‑titik gradasi, arah, serta transparansi.

Fitur terkait: [Format teks dalam slide](/slides/id/features/text-formatting/).