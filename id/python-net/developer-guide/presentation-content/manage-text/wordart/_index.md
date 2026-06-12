---
title: Buat dan Terapkan Efek WordArt di Python
linktitle: WordArt
type: docs
weight: 110
url: /id/python-net/wordart/
keywords:
- WordArt
- buat WordArt
- templat WordArt
- efek WordArt
- efek bayangan
- efek tampilan
- efek cahaya
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan efek WordArt di Aspose.Slides untuk Python via .NET. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks yang bergaya dan profesional dalam Python."
---
## **Gambaran Umum**

Efek WordArt memungkinkan Anda menambahkan teks yang menarik secara visual dan bergaya ke presentasi PowerPoint Anda. Dengan Aspose.Slides, pengembang dapat secara programatis membuat, menyesuaikan, dan mengelola WordArt seperti di Microsoft PowerPoint—tanpa harus menginstal Office. Artikel ini memberikan gambaran tentang cara bekerja dengan WordArt, termasuk cara menerapkan transformasi teks, gaya isi, garis tepi, bayangan, dan opsi pemformatan lainnya untuk membuat konten presentasi Anda lebih ekspresif dan menarik. WordArt memungkinkan Anda memperlakukan teks sebagai objek grafis. Ini terdiri dari efek atau modifikasi khusus yang diterapkan pada teks agar lebih menarik atau mencolok.

**WordArt di Microsoft PowerPoint**

Untuk menggunakan WordArt di Microsoft PowerPoint, Anda harus memilih salah satu templat WordArt yang telah dipra‑definisikan. Sebuah templat WordArt adalah sekumpulan efek yang diterapkan pada teks atau bentuknya. 

**WordArt di Aspose.Slides**

Pada Aspose.Slides for Python via .NET 20.10, kami menambahkan dukungan untuk WordArt dan melakukan perbaikan pada fitur tersebut dalam rilis Aspose.Slides for Python via .NET selanjutnya. 

Dengan Aspose.Slides for Python via .NET, Anda dapat dengan mudah membuat templat WordArt Anda sendiri (satu efek atau kombinasi efek) dalam Python dan menerapkannya pada teks. 

## Membuat Templat WordArt Sederhana dan Menerapkannya pada Teks

**Menggunakan Aspose.Slides** 

Pertama, kami membuat teks sederhana menggunakan kode Python ini: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Sekarang, kami mengatur tinggi font teks menjadi nilai yang lebih besar agar efeknya lebih terlihat melalui kode berikut:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Menggunakan Microsoft PowerPoint**

Masuk ke menu efek WordArt di Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dari menu di sebelah kanan, Anda dapat memilih efek WordArt yang telah dipra‑definisikan. Dari menu di sebelah kiri, Anda dapat menentukan pengaturan untuk WordArt baru. 

Berikut beberapa parameter atau opsi yang tersedia:

![todo:image_alt_text](image-20200930114015-3.png)

**Menggunakan Aspose.Slides**

Di sini, kami menerapkan warna pola SmallGrid pada teks dan menambahkan batas teks hitam dengan lebar 1 menggunakan kode berikut:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Teks hasil:

![todo:image_alt_text](image-20200930114108-4.png)

## Menerapkan Efek WordArt Lainnya

**Menggunakan Microsoft PowerPoint**

Dari antarmuka program, Anda dapat menerapkan efek‑efek ini pada teks, blok teks, bentuk, atau elemen serupa:

![todo:image_alt_text](image-20200930114129-5.png)

Misalnya, efek Shadow, Reflection, dan Glow dapat diterapkan pada teks; efek 3D Format dan 3D Rotation dapat diterapkan pada blok teks; properti Soft Edges dapat diterapkan pada objek Shape (efeknya tetap ada meskipun properti 3D Format tidak diatur). 

### Menerapkan Efek Bayangan

Di sini, kami berniat mengatur properti yang berhubungan hanya dengan teks. Kami menerapkan efek bayangan pada teks menggunakan kode Python berikut:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

API Aspose.Slides mendukung tiga jenis bayangan: OuterShadow, InnerShadow, dan PresetShadow. 

Dengan PresetShadow, Anda dapat menerapkan bayangan pada teks (menggunakan nilai preset). 

**Menggunakan Microsoft PowerPoint**

Di PowerPoint, Anda dapat menggunakan satu jenis bayangan. Berikut contohnya:

![todo:image_alt_text](image-20200930114225-6.png)

**Menggunakan Aspose.Slides**

Pada Aspose.Slides sebenarnya Anda dapat menerapkan dua jenis bayangan secara bersamaan: InnerShadow dan PresetShadow.

**Catatan:**

- Ketika OuterShadow dan PresetShadow digunakan bersama, hanya efek OuterShadow yang diterapkan. 
- Jika OuterShadow dan InnerShadow digunakan secara bersamaan, efek yang dihasilkan atau diterapkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013, efeknya menjadi ganda. Namun di PowerPoint 2007, efek OuterShadow yang diterapkan. 

### Menerapkan Display pada Teks

Kami menambahkan display ke teks melalui contoh kode Python berikut:

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### Menerapkan Efek Glow pada Teks

Kami menerapkan efek glow pada teks agar bersinar atau menonjol menggunakan kode berikut:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Hasil operasi:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Anda dapat mengubah parameter untuk shadow, display, dan glow. Properti efek diatur pada setiap bagian teks secara terpisah. 
{{% /alert %}} 

### Menggunakan Transformasi di WordArt

Kami menggunakan properti Transform (yang melekat pada seluruh blok teks) melalui kode berikut:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Hasil:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Kedua Microsoft PowerPoint dan Aspose.Slides for Python via .NET menyediakan sejumlah tipe transformasi yang telah dipra‑definisikan. 
{{% /alert %}} 

**Menggunakan PowerPoint**

Untuk mengakses tipe transformasi yang dipra‑definisikan, pergi ke: **Format** -> **TextEffect** -> **Transform**

**Menggunakan Aspose.Slides**

Untuk memilih tipe transformasi, gunakan enum TextShapeType. 

### Menerapkan Efek 3D pada Teks dan Bentuk

Kami menetapkan efek 3D pada bentuk teks menggunakan contoh kode berikut:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Teks hasil dan bentuknya:

![todo:image_alt_text](image-20200930114816-9.png)

Kami menerapkan efek 3D pada teks dengan kode Python berikut:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Hasil operasi:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Penerapan efek 3D pada teks atau bentuknya serta interaksi antar efek didasarkan pada aturan tertentu.

Pertimbangkan sebuah scene untuk teks dan bentuk yang berisi teks tersebut. Efek 3D mencakup representasi objek 3D dan scene tempat objek tersebut ditempatkan.

- Ketika scene diatur untuk baik gambar maupun teks, scene gambar memiliki prioritas lebih tinggi—scene teks diabaikan.
- Ketika gambar tidak memiliki scene sendiri tetapi memiliki representasi 3D, scene teks yang digunakan.
- Jika tidak—ketika bentuk awalnya tidak memiliki efek 3D—bentuk tetap datar dan efek 3D hanya diterapkan pada teks.

Deskripsi tersebut terkait dengan properti [ThreeDFormat.LightRig](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/) dan [ThreeDFormat.Camera](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/). 
{{% /alert %}} 

## **Menerapkan Efek Outer Shadow pada Teks**
Aspose.Slides for Python via .NET menyediakan kelas [**IOuterShadow**](https://reference.aspose.com/slides/id/python-net/aspose.slides.effects/ioutershadow/) dan [**IInnerShadow**](https://reference.aspose.com/slides/id/python-net/aspose.slides.effects/iinnershadow/) yang memungkinkan Anda menerapkan efek bayangan pada teks yang berada dalam TextFrame. Ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). 
2. Dapatkan referensi slide dengan menggunakan indeksnya. 
3. Tambahkan AutoShape berjenis Rectangle ke slide. 
4. Akses TextFrame yang terkait dengan AutoShape. 
5. Set FillType AutoShape menjadi NoFill. 
6. Instansiasi kelas OuterShadow 
7. Set BlurRadius bayangan. 
8. Set Direction bayangan 
9. Set Distance bayangan. 
10. Set RectanglelAlign ke TopLeft. 
11. Set PresetColor bayangan menjadi Black. 
12. Simpan presentasi sebagai file PPTX. 

Contoh kode Python ini—implementasi dari langkah‑langkah di atas—menunjukkan cara menerapkan efek outer shadow pada teks:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Dapatkan referensi slide
    sld = pres.slides[0]

    # Tambahkan AutoShape tipe Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Tambahkan TextFrame ke Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Nonaktifkan isi bentuk jika ingin mendapatkan bayangan teks
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Tambahkan outer shadow dan set semua parameter yang diperlukan
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Tulis presentasi ke disk
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menerapkan Efek Inner Shadow pada Bentuk**
Ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/). 
2. Dapatkan referensi slide. 
3. Tambahkan AutoShape berjenis Rectangle. 
4. Aktifkan InnerShadowEffect. 
5. Set semua parameter yang diperlukan. 
6. Set ColorType menjadi Scheme. 
7. Set Scheme Color. 
8. Simpan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Contoh kode ini (berdasarkan langkah‑langkah di atas) menunjukkan cara menambahkan konektor di antara dua bentuk dalam Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Dapatkan referensi slide
    slide = presentation.slides[0]

    # Tambahkan AutoShape tipe Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Tambahkan TextFrame ke Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Aktifkan inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Atur semua parameter yang diperlukan
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Set ColorType menjadi Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Set Warna Skema
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Simpan Presentasi
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menggunakan efek WordArt dengan berbagai font atau skrip (misalnya Arab, Cina)?**

Ya, Aspose.Slides mendukung Unicode dan bekerja dengan semua font serta skrip utama. Efek WordArt seperti shadow, fill, dan outline dapat diterapkan terlepas dari bahasa, namun ketersediaan font dan rendering dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt pada elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt pada bentuk di master slide, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan yang dilakukan pada tata letak master akan tercermin pada semua slide yang terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**

Sedikit. Efek WordArt seperti shadow, glow, dan isian gradien dapat sedikit meningkatkan ukuran file karena penambahan metadata pemformatan, namun perbedaannya biasanya dapat diabaikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt menjadi gambar (mis., PNG, JPEG) menggunakan metode `get_image` dari kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) atau [Slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/). Hal ini memungkinkan Anda melihat pratinjau hasil di memori atau di layar sebelum menyimpan atau mengekspor seluruh presentasi.