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
- presentasi
- Python
- Aspose.Slides
description: "Kuasai tema presentasi di Aspose.Slides untuk Python via .NET untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan identitas merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi menentukan properti elemen desainnya. Saat Anda memilih tema, Anda memilih sekumpulan elemen visual yang terkoordinasi beserta propertinya.

Di PowerPoint, tema mencakup warna, [font](/slides/id/python-net/powerpoint-fonts/), [gaya latar belakang](/slides/id/python-net/presentation-background/), dan efek.

![theme-constituents](theme-constituents.png)

## **Ubah Warna Tema**

Tema PowerPoint menggunakan sekumpulan warna tertentu untuk elemen yang berbeda pada slide. Jika Anda tidak suka nilai default, Anda dapat mengubahnya dengan menerapkan warna tema baru. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai dalam enumerasi [SchemeColor](https://reference.aspose.com/slides/id/python-net/aspose.slides/schemecolor/).

Kode Python berikut menunjukkan cara mengubah warna aksen tema:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Anda dapat menentukan nilai efektif dari warna yang dihasilkan sebagai berikut:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Contoh output:
#
# ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Untuk lebih menunjukkan perubahan warna, kami membuat elemen lain, menetapkan warna aksen dari langkah awal, dan kemudian memperbarui warna tema.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Warna baru diterapkan secara otomatis ke kedua elemen.

### **Tetapkan Warna Tema dari Palet Tambahan**

Saat Anda menerapkan transformasi luminansi pada warna tema utama (1), warna dari palet tambahan (2) dihasilkan. Anda kemudian dapat menetapkan dan mengambil warna tema tersebut.

![additional-palette-colors](additional-palette-colors.png)

**1** — Warna tema utama  
**2** — Warna dari palet tambahan

Kode Python berikut menunjukkan bagaimana warna palet tambahan diturunkan dari warna tema utama dan kemudian digunakan pada bentuk:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aksen 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Aksen 4, Lebih Terang 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Aksen 4, Lebih Terang 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Aksen 4, Lebih Terang 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Aksen 4, Lebih Gelap 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Aksen 4, Lebih Gelap 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Pemetaan `SchemeColor` ke Warna `ColorScheme`**

Saat Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/python-net/aspose.slides/schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai warna tema berikut:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, dan `TEXT2`.

Namun, `Presentation.master_theme.color_scheme` mengembalikan [ColorScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/colorscheme/), yang menampilkan warna yang sesuai sebagai:

`dark1`, `dark2`, `light1`, dan `light2`.

Perbedaan ini hanya pada penamaan. Nilai-nilai ini merujuk pada slot warna tema yang sama dan pemetaan bersifat tetap:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Tidak ada konversi dinamis antara `TEXT`/`BACKGROUND` dan `dark`/`light`. Mereka hanya nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari terminologi Microsoft Office. Versi Office lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sementara versi UI yang lebih baru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Ubah Font Tema**

Untuk memungkinkan Anda memilih font untuk tema dan tujuan lainnya, Aspose.Slides menggunakan pengenal khusus ini (mirip dengan yang ada di PowerPoint):

- **+mn-lt** — Font Badan Latin (Minor Latin Font)
- **+mj-lt** — Font Judul Latin (Major Latin Font)
- **+mn-ea** — Font Badan Asia Timur (Minor East Asian Font)
- **+mj-ea** — Font Judul Asia Timur (Major East Asian Font)

Kode Python berikut menunjukkan cara menetapkan font Latin ke elemen tema:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Contoh Python berikut menunjukkan cara mengubah font tema presentasi:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Semua kotak teks akan diperbarui ke font baru.

{{% alert color="primary" title="TIP" %}}
Untuk informasi lebih lanjut, lihat [Master PowerPoint Fonts with Python](/slides/id/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Ubah Gaya Latar Belakang Tema**

Secara default, PowerPoint menyediakan 12 latar belakang yang telah ditentukan, tetapi presentasi tipikal hanya menyimpan 3 di antaranya.

![todo:image_alt_text](presentation-design_8.png)

Misalnya, setelah Anda menyimpan presentasi di PowerPoint, Anda dapat menjalankan kode Python berikut untuk menentukan berapa banyak latar belakang yang telah ditentukan yang dimilikinya:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Dengan menggunakan properti `background_fill_styles` dari kelas [FormatScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/), Anda dapat menambah atau mengakses gaya latar belakang dalam tema PowerPoint.
{{% /alert %}}

Contoh Python berikut menunjukkan cara menetapkan latar belakang presentasi:

```python
presentation.masters[0].background.style_index = 2  # 0 berarti tidak ada isian; indeks dimulai dari 1.
```

{{% alert color="primary" title="TIP" %}}
Untuk informasi lebih lanjut, lihat [Manage Presentation Backgrounds in Python](/slides/id/python-net/presentation-background/).
{{% /alert %}}

## **Ubah Efek Tema**

Tema PowerPoint biasanya mencakup tiga nilai di setiap array gaya. Array ini digabung menjadi tiga tingkat efek: halus, sedang, dan intens. Sebagai contoh, inilah hasil ketika efek tersebut diterapkan pada bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Dengan menggunakan tiga properti—`FillStyles`, `LineStyles`, dan `EffectStyles`—dari kelas [FormatScheme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/formatscheme/), Anda dapat memodifikasi elemen tema (bahkan lebih fleksibel dibandingkan di PowerPoint).

Kode Python berikut menunjukkan cara mengubah efek tema dengan memodifikasi bagian-bagian dari elemen tersebut:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Perubahan yang dihasilkan mencakup pembaruan warna isian, jenis isian, efek bayangan, dan properti lain:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Apakah saya dapat menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Aspose.Slides mendukung penimpaan tema pada tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide tersebut sementara tema master tetap tidak berubah (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/slidethememanager/)).

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

[Clone slides](/slides/id/python-net/clone-slides/) bersama dengan masternya ke dalam presentasi target. Ini mempertahankan master asli, tata letak, dan tema terkait sehingga tampilan tetap konsisten.

**Bagaimana saya dapat melihat nilai "effective" setelah semua pewarisan dan penimpaan?**

Gunakan tampilan ["effective"](/slides/id/python-net/shape-effective-properties/) API untuk tema/warna/font/efek. Tampilan ini mengembalikan properti akhir yang sudah diselesaikan setelah menerapkan master serta setiap penimpaan lokal.