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
description: "Kuasai tema presentasi di Aspose.Slides untuk Python via .NET untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan satu set terkoordinasi warna, font, gaya latar belakang, isian, garis, dan efek. Objek yang menyadari tema merujuk pada definisi bersama ini alih-alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema tingkat presentasi tersedia melalui properti [Presentation.master_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/master_theme/) . Presentasi juga dapat berisi penimpaan tema pada tingkat yang lebih rendah. Master dapat menimpa tema presentasi melalui [MasterThemeManager.override_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/masterthememanager/override_theme/), tata letak dapat menimpa tema yang diwariskan melalui [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), dan slide individual dapat melakukan hal yang sama. Secara praktik, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, penimpaan master, penimpaan tata letak, dan penimpaan slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan penimpaan diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/) mengekspos properti [color_scheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/font_scheme/), dan [format_scheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/mastertheme/format_scheme/) tema. Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti utama tema dan melaporkan berapa banyak gaya latar belakang, isian, garis, dan efek yang disimpan dalam tema:

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

Jika sebuah berkas menggunakan beberapa master, jangan menganggap bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema-efektif yang ditunjukkan nanti dalam artikel ini ketika penimpaan tata letak atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang menyadari tema dapat merujuk pada warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/python-net/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang sesuai dalam [ColorScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/colorscheme/) tema, semua objek yang masih merujuk ke warna tema tersebut akan diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak akan berubah oleh pembaruan warna tema.

Contoh end-to-end berikut membuat sebuah bentuk yang menggunakan `ACCENT4`, mengubah warna tema `accent4` menjadi merah, menyimpan presentasi, membuka kembali, dan mencetak warna isian efektif:

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

Karena persegi tetap terhubung ke `ACCENT4`, warna yang terlihat menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada bentuk, perubahan selanjutnya pada `accent4` tidak lagi memengaruhi isian tersebut.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspos transformasi ini melalui enumerasi [ColorTransformOperation](https://reference.aspose.com/slides/id/python-net/aspose.slides/colortransformoperation/) .

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Warna utama tema.

**2** - Varian lebih terang dan lebih gelap yang dihasilkan dari warna utama tema.

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

Varian ini tetap berbasis pada warna tema. Jika `accent4` berubah nanti, warna yang ditransformasikan akan dihitung ulang dari nilai `accent4` yang baru.

### **Pemetaan Nilai `SchemeColor` ke Slot `ColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/python-net/aspose.slides/schemecolor/) menggunakan `TEXT1`, `BACKGROUND1`, `TEXT2`, dan `BACKGROUND2`, sementara [ColorScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/colorscheme/) mengekspos slot tema yang sama sebagai `dark1`, `light1`, `dark2`, dan `light2`. Pemetaan ini tetap:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lain.

## **Mengubah Font Tema**

Skema font tema berisi satu set font utama untuk judul dan satu set font minor untuk teks tubuh. Properti [FontScheme.major](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/fontscheme/major/) dan [FontScheme.minor](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/fontscheme/minor/) mengekspos set tersebut.

Pengidentifikasi font tema yang kompatibel PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` - Font Tubuh Latin (Minor Latin Font)
* `+mj-lt` - Font Judul Latin (Major Latin Font)
* `+mn-ea` - Font Tubuh Asia Timur (Minor East Asian Font)
* `+mj-ea` - Font Judul Asia Timur (Major East Asian Font)

Contoh berikut membuat satu judul yang menggunakan font Latin utama tema dan satu baris tubuh yang menggunakan font Latin minor tema. Kemudian mengubah font tema dan menyimpan hasilnya:

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

Judul mengikuti font utama dan teks tubuh mengikuti font minor. Teks yang memiliki nama font eksplisit alih-alih pengidentifikasi tema tidak akan beralih secara otomatis ketika skema font tema berubah.

Koleksi font utama dan minor juga dapat berisi pemetaan font untuk sistem penulisan individual, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan ini, lihat [Script-Specific Theme Fonts](/slides/id/python-net/script-specific-font-mappings/) .

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/python-net/powerpoint-fonts/) .
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Ada dua alur kerja umum, dan keduanya menyelesaikan masalah yang berbeda.

### **Mempertahankan Tema Sumber Saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, klon master sumber ke dalam presentasi target dengan [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/add_clone/) , kemudian klon slide dengan [SlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/add_clone/) dan master yang diklon. Ini membawa master, tata letaknya, dan tema terkait bersama-sama.

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

Ini adalah alur kerja yang disarankan ketika slide sumber harus terlihat sama di tujuan. Hanya mengklon konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang didorong tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan tata letak saat ini, inisialisasi penimpaan tingkat slide dari tema sumber. Metode [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), dan [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) menyalin tiga komponen utama tema ke dalam penimpaan.

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

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus penimpaan lokal dan kembali ke nilai yang diwarisi, panggil [OverrideTheme.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/overridetheme/clear/) .

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

Gunakan tema tingkat master atau presentasi ketika banyak tata letak dan slide harus berbagi desain dasar yang sama, penimpaan tata letak ketika satu keluarga tata letak membutuhkan gaya yang berbeda, dan penimpaan slide hanya untuk pengecualian sejati. Penimpaan tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari lebih sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) . PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI dibandingkan jumlah definisi isian yang secara fisik disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lainnya.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background.style_index](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/style_index/) saat ini. `style_index` menggunakan `0` untuk tidak ada isian tema; nilai positif adalah referensi gaya latar belakang tema. Ini berbeda dari mengindeks koleksi Python secara langsung, dimana `[0]` berarti item pertama yang disimpan. Jangan menganggap setiap presentasi memiliki jumlah gaya isian latar belakang yang sama.

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

Hasil yang terlihat bergantung pada entri tema yang dirujuk oleh master dan pada penimpaan latar belakang di tingkat tata letak atau slide. Jika sebuah slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/get_effective/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan `style_index` sebagai indeks koleksi berbasis nol. Hindari juga mengkodekan nomor gaya dari satu berkas dan menganggap tampilannya sama di berkas lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/python-net/presentation-background/) .
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi terpisah [FormatScheme.fill_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/line_styles/), dan [FormatScheme.effect_styles](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/effect_styles/) . Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual berkorespondensi dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih-alih mengasumsikan jumlah tetap.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Ketika Anda mengakses koleksi ini di Python, indeks koleksi berbasis nol: `[0]` adalah gaya pertama yang disimpan dan `[2]` adalah yang ketiga. Indeks referensi gaya pada bentuk adalah konsep terpisah, diekspos melalui [IShapeStyle](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapestyle/) . Memodifikasi gaya tema memengaruhi bentuk yang merujuk gaya tema tersebut; bentuk dengan pemformatan langsung mungkin tetap tidak berubah.

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

Untuk bentuk yang merujuk slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan padat, dan gaya efek ketiga memperoleh bayangan luar dengan jarak 10 poin. Hasil visual tepat masih bergantung pada slot gaya yang dirujuk masing‑masing bentuk dan apakah pemformatan langsung menimpa tema.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu Anda apa yang didefinisikan pada tingkat tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan slide atau bentuk setelah pewarisan dan penimpaan lokal diselesaikan. Untuk slide, panggil [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) . Untuk latar belakang, gunakan [Background.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/get_effective/) , dan untuk isian, gunakan [FillFormat.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/get_effective/) .

Contoh berikut membaca tema efektif, latar belakang, dan isian bentuk pertama dari sebuah slide:

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

Gunakan data efektif untuk diagnostik rendering, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation.master_theme](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/master_theme/) , Anda bisa melewatkan master, tata letak, slide, atau penimpaan bentuk yang mengubah tampilan akhir.

## **FAQ**

**Apakah saya dapat menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [SlideThemeManager](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/slidethememanager/) slide dan inisialisasi tema penimpaanannya. Perubahan tetap lokal pada slide tersebut; slide lain tetap mewarisi tema mereka yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Ketika memindahkan slide dan mempertahankan tampilannya yang asli, klon master sumber ke dalam tujuan dan klon slide dengan master tersebut menggunakan [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/add_clone/) dan [SlideCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/add_clone/) . Ini menjaga master, tata letak, dan tema bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan penimpaan?**

Gunakan [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) untuk tema slide atau tata letak serta metode data‑efektif yang bersesuaian untuk objek format seperti [Background.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/background/get_effective/) dan [FillFormat.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/get_effective/) . API ini mengembalikan nilai yang telah diselesaikan setelah pewarisan dan penimpaan diterapkan.