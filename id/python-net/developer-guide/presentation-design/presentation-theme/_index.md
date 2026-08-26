---
title: Kelola Tema Presentasi PowerPoint di Python
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/python-net/presentation-theme/
keywords:
- Tema PowerPoint
- Tema presentasi
- Tema slide
- Atur tema
- Ubah tema
- Kelola tema
- Tema eksternal
- THMX
- Warna tema
- Palet tambahan
- Font tema
- Gaya tema
- Efek tema
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kuasai tema presentasi di Aspose.Slides untuk Python via .NET untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan branding yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan satu set terkoordinasi warna, font, gaya latar belakang, isian, garis, dan efek. Objek yang sadar tema merujuk pada definisi bersama ini alih-alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui properti [Presentation.master_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/master_theme/). Sebuah presentasi juga dapat berisi penimpaan tema pada level yang lebih rendah. Sebuah master dapat menimpa tema presentasi melalui [MasterThemeManager.override_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/masterthememanager/override_theme/), sebuah tata letak dapat menimpa tema yang diwarisi melalui [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), dan sebuah slide individu dapat melakukan hal yang sama. Pada praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan tata letak, dan penimpaan slide.

![Komponen tema: warna, font, gaya latar belakang, dan efek](theme-constituents.png)

Bagian di bawah ini memperlihatkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/) menampilkan properti [color_scheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/font_scheme/), dan [format_scheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/format_scheme/) tema. Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika sebuah presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti tema utama dan melaporkan berapa banyak gaya latar belakang, isian, garis, dan efek yang disimpan dalam tema:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Jika sebuah file menggunakan beberapa master, jangan mengasumsikan bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema-efektif yang ditunjukkan nanti dalam artikel ini ketika penimpaan tata letak atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang sadar tema dapat merujuk pada warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/python-net/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang sesuai dalam [ColorScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/colorscheme/) tema, semua objek yang masih merujuk ke warna tema tersebut diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak diubah oleh pembaruan warna tema.

Contoh end-to-end berikut membuat sebuah shape yang menggunakan `ACCENT4`, mengubah warna tema `accent4` menjadi merah, menyimpan presentasi, membukanya kembali, dan mencetak warna isian efektif:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Karena persegi panjang tetap terhubung ke `ACCENT4`, warnanya menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada shape, perubahan selanjutnya pada `accent4` tidak akan memengaruhi isian tersebut lagi.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspose transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/id/python-net/aspose.slides/colortransformoperation/).

![Warna tema utama serta warna lebih terang dan lebih gelap yang dihasilkan dari palet tambahan](additional-palette-colors.png)

**1** - Warna tema utama.

**2** - Varian lebih terang dan lebih gelap yang dihasilkan dari warna tema utama.

Contoh berikut membuat enam persegi panjang berdasarkan `ACCENT4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Varian ini tetap berbasis pada warna tema. Jika `accent4` berubah kemudian, warna yang ditransformasi akan dihitung ulang dari nilai `accent4` yang baru.

### **Pemetaan Nilai `SchemeColor` ke Slot `ColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/python-net/aspose.slides/schemecolor/) menggunakan `TEXT1`, `BACKGROUND1`, `TEXT2`, dan `BACKGROUND2`, sementara [ColorScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/colorscheme/) menampilkan slot tema yang sama sebagai `dark1`, `light1`, `dark2`, dan `light2`. Pemetaan bersifat tetap:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ini adalah nama alternatif untuk slot tema yang sama; mereka bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lain.

## **Mengubah Font Tema**

Skema font tema berisi set font utama untuk judul dan set font minor untuk teks tubuh. Properti [FontScheme.major](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/fontscheme/major/) dan [FontScheme.minor](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/fontscheme/minor/) menampilkan set tersebut.

Pengidentifikasi font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Contoh berikut membuat satu judul yang menggunakan font Latin mayor tema dan satu baris tubuh yang menggunakan font Latin minor tema. Kemudian mengubah font tema dan menyimpan hasilnya:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Judul mengikuti font mayor dan teks tubuh mengikuti font minor. Teks yang memiliki nama font eksplisit alih-alih pengidentifikasi tema tidak akan beralih secara otomatis ketika skema font tema berubah.

Koleksi font mayor dan minor juga dapat berisi pemetaan font untuk sistem penulisan individu, seperti Cyrillic, Arab, Jepang, Georgian, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan ini, lihat [Script-Specific Theme Fonts](/slides/id/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini menyelesaikan berbagai masalah terkait tema.

### **Menerapkan Tema Eksternal ke Slide yang Bergantung pada Master**

Gunakan [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) ketika Anda memiliki file tema PowerPoint (`.thmx`) dan ingin mengubah gaya semua slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation.masters](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/masters/), yang mengimplementasikan [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/), dan berikan jalur file tema ke metode tersebut.

Metode ini melakukan operasi berikut:

1. Membuat master slide baru berdasarkan master yang dipilih.
1. Menerapkan tema eksternal ke master baru.
1. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master yang dipilih.
1. Mengembalikan [IMasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterslide/) yang baru dibuat.

Contoh berikut menerapkan tema eksternal ke slide yang bergantung pada master pertama dan menyimpan presentasi:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Tema yang tidak valid, rusak, atau tidak didukung dapat menyebabkan [PptxException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxexception/) atau salah satu subclass terkait formatnya. Validasi jalur yang diberikan pengguna, tangani kegagalan akses sistem file, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide yang bergantung pada master yang dipilih yang dipindahkan. Slide yang terkait dengan master lain tetap mempertahankan master dan tema mereka yang ada. Warna, font, isian, garis, latar belakang, dan efek yang sadar tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan langsung mungkin tetap tidak berubah. Penimpaan pada level tata letak dan slide juga dapat memiliki prioritas atas nilai yang diwarisi dari master baru.

Tema dapat merujuk pada font yang tidak tersedia di lingkungan runtime. Untuk memastikan render dan ekspor konsisten, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/python-net/custom-font/), atau konfigurasikan [font substitution](/slides/id/python-net/font-substitution/).

Ini adalah alur kerja langsung pada level master: metode menerima jalur file `.thmx` dan tidak memerlukan pembuatan manual penimpaan tema pada level slide atau tata letak.

### **Menerapkan Tema Eksternal Berbeda dalam Presentasi Multi-Master**

Ketika master yang relevan tidak diketahui sebelumnya, dapatkan dari slide perwakilan melalui [Slide.layout_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/layout_slide/) dan [LayoutSlide.master_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/master_slide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap panggilan membuat master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua bagian untuk menemukan master mereka dan menerapkan tema eksternal yang berbeda ke masing‑masing grup:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Panggilan pertama memengaruhi hanya slide yang bergantung pada `first_group_master`, dan panggilan kedua memengaruhi hanya slide yang bergantung pada `second_group_master`. Slide yang termasuk dalam master lain tidak diubah gayanya.

### **Mempertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke dalam presentasi target dengan [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/add_clone/), kemudian kloning slide dengan [SlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/add_clone/) dan master yang dikloning. Ini membawa master, tata letaknya, dan tema terkait bersama‑sama.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Ini adalah alur kerja yang disarankan ketika slide sumber harus terlihat sama di tujuan. Hanya mengkloning konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang dipicu tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan tata letak saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), dan [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) menyalin tiga komponen tema utama ke dalam penimpaan.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwarisi, panggil [OverrideTheme.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/clear/).

### **Menerapkan Penimpaan Tema ke Tata Letak**

Penimpaan tingkat tata letak berlaku untuk slide yang menggunakan tata letak tersebut, kecuali slide tertentu memiliki penimpaan sendiri. Metode inisialisasi yang sama dapat digunakan melalui [LayoutSlideThemeManager](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/layoutslidethememanager/) tata letak:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Gunakan tema master atau tingkat presentasi ketika banyak tata letak dan slide harus berbagi desain dasar yang sama, penimpaan tata letak ketika satu keluarga tata letak memerlukan gaya yang berbeda, dan penimpaan slide hanya untuk pengecualian nyata. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari menjadi lebih sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI-nya dibandingkan jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lain.

![Galeri gaya latar belakang PowerPoint untuk tema presentasi](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background.style_index](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/style_index/) saat ini. `style_index` menggunakan `0` untuk tidak ada isian bertema; nilai positif adalah referensi gaya latar belakang tema. Ini berbeda dari mengindeks koleksi Python secara langsung, di mana `[0]` berarti item pertama yang disimpan. Jangan mengasumsikan setiap presentasi memiliki jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang bertema ke master pertama, dan menyimpan presentasi:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Hasil yang terlihat bergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar belakang di tingkat tata letak atau slide. Jika slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/get_effective/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan `style_index` sebagai indeks koleksi berbasis nol. Hindari juga mengodekan nomor gaya dari satu file dan mengasumsikan tampilannya sama di file lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/python-net/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi terpisah [FormatScheme.fill_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/line_styles/), dan [FormatScheme.effect_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/effect_styles/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual berkorespondensi dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih-alih mengasumsikan jumlah tetap.

![Efek tema halus, sedang, dan intens yang diterapkan pada shape yang sama](presentation-design_10.png)

Saat mengakses koleksi ini di Python, indeks koleksi berbasis nol: `[0]` adalah gaya pertama yang disimpan dan `[2]` adalah yang ketiga. Indeks referensi gaya shape adalah konsep terpisah, diekspos melalui [IShapeStyle](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapestyle/). Memodifikasi gaya tema memengaruhi shape yang merujuk ke gaya tema tersebut; shape dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa keberadaan entri gaya yang diperlukan, mengubah gaya garis pertama, mengubah gaya isian ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Untuk shape yang merujuk ke slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan solid, dan gaya efek ketiga memperoleh bayangan luar dengan jarak 10 poin. Hasil visual tepat tetap bergantung pada slot gaya yang dirujuk setiap shape dan apakah pemformatan langsung menimpa tema.

![Gaya efek tema setelah mengubah garis, isian, dan pengaturan bayangan](presentation-design_11.png)

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu apa yang didefinisikan pada level tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau shape setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Untuk latar belakang, gunakan [Background.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/get_effective/), dan untuk isian, gunakan [FillFormat.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/get_effective/).

Contoh berikut membaca tema efektif, latar belakang, dan isian shape pertama dari sebuah slide:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Gunakan data efektif untuk diagnostik render, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.master_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/master_theme/), Anda dapat melewatkan penimpaan master, tata letak, slide, atau shape yang mengubah tampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) hanya menugaskan ulang slide yang bergantung pada master yang dipilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/slidethememanager/) slide dan inisialisasi tema penimpaan. Perubahan tetap lokal pada slide tersebut; slide lain terus mewarisi tema mereka yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumber, klon master sumber ke tujuan dan klon slide dengan master tersebut menggunakan [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/add_clone/) dan [SlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/add_clone/). Ini menjaga master, tata letak, dan tema tetap bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) untuk tema slide atau tata letak serta metode data‑efektif yang sesuai untuk objek format seperti [Background.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/get_effective/) dan [FillFormat.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/get_effective/). API‑API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan penimpaan diterapkan.