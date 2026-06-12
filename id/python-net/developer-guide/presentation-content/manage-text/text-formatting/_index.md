---
title: Format Teks Presentasi di Python
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/python-net/text-formatting/
keywords:
- menyorot teks
- ekspresi reguler
- meratakan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- famili font
- rotasi teks
- sudut rotasi
- bingkai teks
- jarak baris
- properti autofit
- penopang bingkai teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Format dan gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python melalui .NET. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python melalui .NET. Artikel ini mencakup penyorotan, warna latar belakang, transparansi, spasi karakter, properti font, rotasi, spasi paragraf, perilaku autofit, penempatan teks, tab stop, dan pengaturan bahasa.

Dalam contoh di bawah ini, kami akan menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Sorot Teks**

Gunakan metode [TextFrame.highlight_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_text/) ketika Anda perlu menyorot teks yang cocok dengan contoh tertentu dalam sebuah text frame. Metode ini menerapkan warna sorotan pada fragmen teks yang cocok dan dapat digunakan bersama [TextSearchOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/textsearchoptions/) untuk mengontrol cara pencarian dilakukan, misalnya, untuk mencocokkan hanya kata penuh.

Contoh kode di bawah ini menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Dapatkan shape pertama dari slide pertama.
    shape = presentation.slides[0].shapes[0]

    # Sorot kata "try" pada shape.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # Sorot kata "to" pada shape.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [TextFrame.highlight_regex](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/highlight_regex/) menyorot kecocokan teks yang ditemukan oleh sebuah ekspresi reguler. Dalam Python, API ini tersedia pada [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).

Contoh kode di bawah ini menyorot semua kata yang mengandung **tujuh atau lebih karakter**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Sorot semua kata dengan tujuh atau lebih karakter.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Atur Warna Latar Belakang Teks**

Gunakan [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/default_portion_format/) untuk mengatur warna sorotan default untuk sebuah paragraf, atau gunakan [PortionFormat.highlight_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/highlight_color/) untuk bagian teks individual.

Contoh kode berikut menunjukkan cara mengatur warna latar belakang untuk **seluruh paragraf**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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
    auto_shape = presentation.slides[0].shapes[0]
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

Gunakan [ParagraphFormat.alignment](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/alignment/) untuk mengatur perataan paragraf dalam sebuah text frame. Nilainya dapat berupa centered, left-aligned, right-aligned, justified, dan sebagainya.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Atur perataan paragraf ke tengah.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Paragraf yang diratakan](aligned_paragraph.png)

## **Atur Transparansi untuk Teks**

Transparansi teks diatur melalui komponen alfa dari warna yang ditetapkan pada [PortionFormat.fill_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/fill_format/). Dalam contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0-255, bukan persentase transparansi.

Contoh kode di bawah ini menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Atur warna isi teks menjadi warna transparan.
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
    auto_shape = presentation.slides[0].shapes[0]
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

Gunakan [BasePortionFormat.spacing](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/spacing/) untuk memperluas atau memperkecil jarak antar karakter dalam sebuah kotak teks.

Kode Python berikut menunjukkan cara memperluas jarak karakter dalam **seluruh paragraf**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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
    auto_shape = presentation.slides[0].shapes[0]
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

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides mungkin terlihat sedikit lebih rapat dibandingkan teks yang sama di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan dalam pengaturan PowerPoint.

Untuk menghasilkan output yang lebih mirip dengan PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terkena. Atur [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) ke nilai yang jauh lebih besar daripada ukuran font sebenarnya:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Pengaturan ini mencegah kerning diterapkan pada bagian teks yang cocok dan dapat membantu menyelaraskan render Aspose.Slides dengan output visual PowerPoint untuk font yang dipengaruhi oleh perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada level paragraf melalui [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/default_portion_format/) atau pada masing‑masing bagian melalui [PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/).

Kode berikut mengatur font dan gaya teks untuk seluruh paragraf: ia menerapkan ukuran font, tebal, miring, underline titik, dan font Times New Roman ke semua bagian dalam paragraf.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Atur properti font untuk paragraf.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh kode di bawah ini menerapkan properti serupa pada **bagian teks dengan font tebal**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **Atur Rotasi Teks**

Gunakan [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/text_vertical_type/) untuk mengatur orientasi teks yang telah ditentukan sebelumnya dalam sebuah shape.

Contoh kode berikut mengatur orientasi teks dalam shape ke `VERTICAL270`, yang memutar teks **90 derajat berlawanan arah jarum jam**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Rotasi teks](text_rotation.png)

## **Atur Rotasi Kustom untuk Frame Teks**

Gunakan [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/rotation_angle/) untuk mengatur sudut rotasi kustom untuk sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).

Contoh kode di bawah ini memutar frame teks sebesar 3 derajat searah jarum jam dalam shape:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Rotasi teks kustom](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan [ParagraphFormat.space_after](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/space_before/), dan [ParagraphFormat.space_within](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/space_within/) untuk mengontrol jarak paragraf. Properti‑properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh kode berikut menunjukkan cara menentukan jarak baris dalam paragraf:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Jarak baris dalam paragraf](line_spacing.png)

## **Atur Tipe Autofit untuk Frame Teks**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/autofit_type/) menentukan bagaimana teks berperilaku ketika melebihi batas kontainernya. Gunakan untuk mengontrol apakah teks menyusut, meluap, atau mengubah ukuran shape secara otomatis.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Penopang (Anchor) Frame Teks**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/anchoring_type/) menentukan bagaimana teks diposisikan secara vertikal di dalam shape, misalnya di bagian atas, tengah, atau bawah.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Tabulasi Teks**

Gunakan [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/default_tab_size/) dan [ParagraphFormat.tabs](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/tabs/) untuk mengonfigurasi tab stop dalam sebuah paragraf.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Tab paragraf](paragraph_tabs.png)

## **Atur Bahasa Pemeriksaan**

Aspose.Slides menyediakan [PortionFormat.language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/language_id/), yang memungkinkan Anda mengatur bahasa pemeriksaan untuk sebuah bagian teks. Bahasa pemeriksaan menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh kode berikut menunjukkan cara mengatur bahasa pemeriksaan untuk sebuah bagian teks:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Atur Id bahasa pemeriksaan.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Bahasa Default**

Gunakan [LoadOptions.default_text_language](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/default_text_language/) untuk mendefinisikan bahasa default untuk teks yang dibuat saat memuat atau membuat presentasi.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Tambah bentuk persegi panjang baru dengan teks.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Periksa bahasa bagian pertama.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Atur Gaya Teks Default**

Untuk menerapkan format teks default pada tingkat presentasi, gunakan [Presentation.default_text_style](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/default_text_style/).

Contoh kode berikut menunjukkan cara mengatur font tebal default dengan ukuran 14 pt untuk semua teks di seluruh slide dalam sebuah presentasi baru.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Dapatkan format paragraf level atas.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Ekstrak Teks dengan Efek Semua Huruf Kapital**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf besar di slide meskipun awalnya ditulis dengan huruf kecil. Ketika Anda mengambil bagian teks tersebut dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/python-net/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf besar ketika nilainya `ALL`.

Misalkan kita memiliki kotak teks berikut pada slide pertama file sample2.pptx.

![Efek All Caps](all_caps_effect.png)

Contoh kode di bawah ini menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Keluaran:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara memodifikasi teks dalam tabel pada slide?**

Untuk memodifikasi teks dalam tabel pada slide, gunakan [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/). Iterasi sel‑sel dan perbarui setiap sel melalui [Cell.text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/text_frame/) serta format paragraf melalui [Paragraph.paragraph_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/paragraph_format/).

**Bagaimana cara menerapkan warna gradien pada teks di slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [PortionFormat.fill_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/fill_format/). Atur [FillFormat.fill_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/fill_type/) ke [FillType.GRADIENT](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) dan konfigurasikan titik‑titik gradien, arah, serta transparansi.