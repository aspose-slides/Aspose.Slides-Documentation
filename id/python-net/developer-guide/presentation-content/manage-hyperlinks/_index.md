---
title: Kelola Hyperlink Presentasi dalam Python
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/python-net/manage-hyperlinks/
keywords:
- tambah URL
- tambah hyperlink
- buat hyperlink
- format hyperlink
- hapus hyperlink
- perbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Tambah, format, perbarui, dan hapus hyperlink dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET, dengan contoh Python."
---
## **Pendahuluan**

Hyperlink menghubungkan konten presentasi ke situs web atau ke lokasi di dalam presentasi. Di PowerPoint, hyperlink biasanya berfungsi untuk dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya dari tabel isi.

Aspose.Slides for Python via .NET memungkinkan Anda menambahkan tautan ini, mengontrol penampilan dan suaranya, memperbarui propertinya, dan menghapusnya. Contoh di bawah ini menunjukkan cara bekerja dengan hyperlink pada elemen individual serta cara mengakses hyperlink pada level presentasi, slide, atau bingkai teks.

{{% alert color="info" title="Note" %}}
Anda juga dapat mengedit presentasi dengan [editor Aspose PowerPoint online gratis](https://products.aspose.app/slides/id/editor).
{{% /alert %}}

## **Tambah Hyperlink URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen yang Anda beri hyperlink menentukan area yang dapat diklik: bagian teks menautkan teks yang dipilih, sementara bentuk atau bingkai menautkan objek slide.

### **Tambah Hyperlink URL ke Teks**

Untuk menautkan teks ke situs web, tetapkan sebuah [Hyperlink](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/) ke properti [hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/hyperlink_click/) pada bagian teks, seperti ditunjukkan di bawah. Hanya bagian teks tersebut yang menjadi dapat diklik.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Tambah Hyperlink URL ke Bentuk dan Bingkai Media**

Agar sebuah bentuk atau bingkai dapat diklik, atur properti [hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/hyperlink_click/) miliknya. Hyperlink tersebut menjadi milik objek itu sendiri, bukan bagian teks di dalamnya.

Pendekatan yang sama berlaku untuk bingkai gambar, audio, dan video: tetapkan hyperlink ke bingkai dan atur [tooltip](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/tooltip/) jika diperlukan.

Contoh berikut membuat sebuah persegi panjang dapat diklik:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Hyperlink internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [set_internal_hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) untuk menautkan teks “Page 2” pada slide pertama ke slide kedua.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Hyperlink**

### **Warna**

Properti [color_source](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/color_source/) dari [Hyperlink](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/) menentukan apakah hyperlink menggunakan warna hyperlink presentasi atau format bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkcolorsource/) dan atur warna isi bagian tersebut. Fitur ini diperkenalkan di PowerPoint 2019; versi lebih lama tidak menerapkan pengaturan ini.

Contoh berikut menambahkan dua hyperlink teks ke slide yang sama. Yang pertama menggunakan isi teks merah, sedangkan yang kedua mempertahankan warna hyperlink default.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Suara**

Sebuah hyperlink dapat memutar suara saat diaktifkan atau menghentikan suara yang sedang diputar. Gunakan properti berikut untuk mengonfigurasi perilaku ini:

- [Hyperlink.sound](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/sound/) menentukan audio yang terkait dengan hyperlink.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/stop_sound_on_click/) mengontrol apakah mengaktifkan hyperlink menghentikan suara sebelumnya.

#### **Tambahkan Suara Hyperlink**

Contoh berikut memuat `sampleaudio.wav` dan mengaitkannya dengan tombol pada slide pertama. Mengklik tombol memutar suara dan menavigasi ke slide berikutnya. Bentuk kedua pada slide itu menghentikan suara sebelumnya ketika diklik, tanpa melakukan aksi navigasi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Ekstrak Suara Hyperlink**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio hyperlink bentuk pertama ke memori melalui [sound](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/sound/) dan [binary_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Pengaturan Tooltip dan Interaksi**

Anda dapat memperbarui properti [Hyperlink](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/) berikut setelah menetapkan hyperlink ke teks atau bentuk:

- [tooltip](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/tooltip/) menetapkan teks yang dapat ditampilkan penonton sebagai petunjuk untuk tautan.
- [target_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/target_frame/) menentukan bingkai target dalam frameset HTML induk, bila berlaku.
- [history](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/history/) mengontrol apakah mengaktifkan tautan menambahkan tujuan ke daftar hyperlink yang telah dilihat.
- [highlight_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/highlight_click/) mengontrol apakah hyperlink disorot saat diklik.

## **Hapus Hyperlink dari Presentasi**

Gunakan [get_any_hyperlinks](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) untuk mengumpulkan kontainer hyperlink, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua tipe aktivasi dari slide pertama. Untuk menghapus hanya satu tipe, panggil hanya [remove_hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) atau [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); menghapus aksi klik tidak menghapus pasangan mouse-over-nya.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Untuk penghapusan tanpa syarat, [remove_all_hyperlinks](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) menghapus kedua tipe aktivasi dalam lingkup yang dipilih dalam satu panggilan. Untuk pembersihan selektif dan mencakup masters, layout, dan catatan, lihat [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Buat Inventaris Hyperlink Lengkap**

Sebelum mendistribusikan presentasi, inventarisasi tindakan interaktif serta tautan webnya. [get_any_hyperlinks](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) mengembalikan objek [IHyperlinkContainer](https://reference.aspose.com/slides/id/python-net/aspose.slides/ihyperlinkcontainer/), bukan daftar datar string URL. Periksa baik [hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) maupun [hyperlink_mouse_over](https://reference.aspose.com/slides/id/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) pada setiap kontainer. Mereka bersifat independen: satu kontainer dapat memaparkan kedua aksi, sehingga laporan lengkap memerlukan hingga dua baris per kontainer.

Pemindaian hanya pada hyperlink tingkat bentuk dapat melewatkan tautan yang terlampir pada bagian teks. Kuery lingkup yang sesuai sebagai gantinya, dan simpan kontainer yang dikembalikan sehingga Anda dapat memperbarui atau menghapus aksinya nanti.

### **Kueri Ruang Lingkup Presentasi, Slide, dan Bingkai Teks**

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/) tersedia melalui [Presentation.hyperlink_queries](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/hyperlink_queries/), dan [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/hyperlink_queries/). Setiap lingkup mendukung kueri yang sama:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) mengembalikan kontainer dengan aksi klik.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) mengembalikan kontainer dengan aksi mouse-over.
- [get_any_hyperlinks](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) mengembalikan kontainer dengan salah satu atau kedua aksi.

Contoh berikut membuat `hyperlink-audit-input.pptx` dengan tautan klik eksternal, tautan mouse-over berkas, navigasi slide internal, tautan mouse-over teks, dan aksi makro. Ia tidak mengeksekusi aksi-aksi tersebut. Ketiga kueri bekerja pada setiap lingkup; hitungan menggambarkan kontainer, bukan total aksi. Lingkup bingkai teks mengecualikan tautan milik bentuk yang membungkusnya.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Untuk contoh ini, kueri presentasi dan slide masing‑masing melaporkan tiga kontainer klik, dua kontainer mouse-over, dan tiga kontainer dengan salah satu aksi. Kueri bingkai teks melaporkan satu kontainer di setiap kategori.

### **Klasifikasikan Tindakan dan Tujuan**

Gunakan [Hyperlink.action_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/action_type/) untuk menafsirkan suatu aksi sebelum menafsirkan tujuannya. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkactiontype/) mencakup lebih dari sekadar navigasi web:

| Nilai | Makna untuk audit |
| --- | --- |
| `HYPERLINK` | Hyperlink eksternal; periksa URL dan skemanya. |
| `JUMP_SPECIFIC_SLIDE` | Navigasi internal ke slide tertentu. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Navigasi bawaan slideshow, diselesaikan dalam konteks slideshow. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan kustom. |
| `START_MACRO` | Menjalankan makro. |
| `START_PROGRAM` | Meluncurkan program. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Membuka berkas atau presentasi lain; tinjau terpisah dari URL web. |
| `START_STOP_MEDIA` | Memulai atau menghentikan pemutaran media. |
| `NO_ACTION`, `UNKNOWN` | Tidak ada aksi navigasi, atau aksi tidak dikenali yang memerlukan tinjauan. |

Baca tujuan eksternal dari [external_url](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/external_url/) dan tujuan internal spesifik dari [target_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/target_slide/). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti kontainer tidak memiliki aksi. Pertahankan [external_url_original](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/external_url_original/) ketika berbeda dari URL ternormalize, dan sertakan [tooltip](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/tooltip/) bila tersedia.

### **Laporan, Sanitasi, dan Verifikasi Hyperlink**

Contoh Python berikut membaca presentasi yang sudah ada (gunakan berkas yang dibuat di atas), menulis `hyperlink-audit.json`, menerapkan kebijakan, menyimpan `hyperlink-sanitized.pptx`, dan membukanya kembali untuk memeriksa kembali kedua tipe aktivasi. Ia mengumpulkan kontainer sebelum mengubahnya dan mengkueri tiap lingkup slide sekali untuk menghindari pemrosesan ganda. Kueri presentasi mencakup slide biasa; untuk inventaris seluruh paket, contoh mengkueri slide biasa, master, layout, catatan, serta master catatan dan handout bila ada.

Laporan mencatat indeks slide berbasis satu dan [slide_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/slide_id/) bila tersedia. Pengumpul mempertahankan slide pemilik dan lingkup bersama tiap kontainer yang dikembalikan. Master, layout, dan catatan tidak memiliki indeks slide biasa dan diidentifikasi oleh lingkupnya. Kontainer bentuk dan kontainer format bagian teks diberi label terpisah; tipe kontainer lain mempertahankan nama tipe runtime mereka. Setiap kontainer mendapat ID laporan lokal sehingga dua aksinya dapat dikorelasikan.

Kebijakan aplikasi yang sengaja ketat ini hanya mengizinkan URL HTTPS absolut dan target slide internal yang valid. Ia menolak makro, program, aksi berkas, aksi slideshow lain, aksi tidak dikenal, serta skema URL lain. Penolakan ini adalah keputusan kebijakan, bukan penilaian keamanan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar putih host dan pemeriksaan lain untuk aplikasi Anda. Kedua URL eksternal, asli dan ternormalize, diperiksa. Contoh ini mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk perbaikan, [hyperlink_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) pada kontainer mendukung [set_external_hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/), dan [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Di sini, tautan klik eksternal yang dilarang diganti dengan halaman landas HTTPS tetap; klik dan mouse-over yang dilarang lainnya dihapus secara terpisah. Atur `replace_external_clicks` ke `False` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penyebaran.

Flag ekspor laporan menggunakan kebijakan peninjauan PDF yang konservatif: beri tanda pada aksi mouse-over dan apa pun selain tautan eksternal atau lompat slide spesifik sebagai potensial tidak didukung. Ini adalah petunjuk peninjauan, bukan tes kemampuan atau jaminan bahwa tautan yang tidak ditandai akan bertahan pada ekspor. Ekspor [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/python-net/convert-powerpoint-to-html/) yang didukung dapat mempertahankan hyperlink, tergantung pada aksi, opsi ekspor, dan penampil. Gambar raster [images](/slides/id/python-net/convert-powerpoint-to-png/) dan [video](/slides/id/python-net/convert-powerpoint-to-video/) tidak dapat mempertahankan hyperlink interaktif; beri tanda setiap aksi ketika mengaudit untuk output tersebut.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Kueri setiap lingkup slide sekali, mempertahankan pemiliknya dengan setiap kontainer.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Dengan input yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse-over berkas dan makro klik dihapus, sementara tautan HTTPS dan navigasi slide internal tetap. Verifikasi mencetak nol aksi yang dilarang. Input yang berisi URL klik eksternal yang dilarang juga menguji cabang penggantian. Kontainer dengan klik yang diizinkan dan mouse-over yang dilarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [remove_all_hyperlinks](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), yang menghapus kedua tipe aktivasi di seluruh lingkup terpilih tanpa mempedulikan kebijakan. Verifikasi di sini hanya memeriksa aksi hyperlink; ia tidak menghapus proyek VBA tersemat, objek OLE, atau konten aktif lainnya, dan tidak memvalidasi berkas PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana saya dapat menautkan ke sebuah seksi atau slide pertamanya?**

Seksi di PowerPoint mengelompokkan slide, tetapi hyperlink internal menargetkan slide individual. Untuk membuat navigasi ke sebuah seksi, tautkan ke slide pertama dalam seksi tersebut.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan pada elemen‑elemen ini tersedia selama pertunjukan slide pada slide yang menggunakan master atau layout yang bersangkutan.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung dapat mempertahankan hyperlink; gambar raster dan video tidak dapat. Lihat pertimbangan ekspor pada [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).