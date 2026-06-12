---
title: Kelola Latar Belakang Presentasi dengan Python
linktitle: Latar Belakang Slide
type: docs
weight: 20
url: /id/python-net/presentation-background/
keywords:
- latar belakang presentasi
- latar belakang slide
- warna solid
- warna gradasi
- latar belakang gambar
- transparansi latar belakang
- properti latar belakang
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengatur latar belakang dinamis dalam file PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET, dengan tips kode untuk meningkatkan presentasi Anda."
---
## **Pendahuluan**

Warna solid, gradasi, dan gambar biasanya digunakan sebagai latar belakang slide. Anda dapat mengatur latar belakang untuk **slide normal** (satu slide) atau **slide master** (berlaku untuk beberapa slide sekaligus).

![PowerPoint background](powerpoint-background.png)

## **Mengatur Latar Belakang dengan Warna Solid untuk Slide Normal**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide tertentu dalam presentasi—meskipun presentasi menggunakan slide master. Perubahan hanya berlaku pada slide yang dipilih.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/python-net/aspose.slides/backgroundtype/) slide ke `OWN_BACKGROUND`.
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) ke `SOLID`.
4. Gunakan properti `solid_fill_color` pada [FillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut menunjukkan cara mengatur warna solid biru sebagai latar belakang untuk slide normal:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Buat instance dari kelas Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Atur warna latar belakang slide menjadi biru.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Simpan presentasi ke disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Latar Belakang dengan Warna Solid untuk Slide Master**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide master dalam sebuah presentasi. Slide master berfungsi sebagai templat yang mengontrol format untuk semua slide, sehingga ketika Anda memilih warna solid untuk latar belakang slide master, itu berlaku untuk setiap slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/python-net/aspose.slides/backgroundtype/) (via `masters`) slide master ke `OWN_BACKGROUND`.
3. Setel latar belakang slide master [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) ke `SOLID`.
4. Gunakan properti `solid_fill_color` pada [FillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut menunjukkan cara mengatur warna solid (hijau hutan) sebagai latar belakang untuk slide master:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Buat instance dari kelas Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Atur warna latar belakang slide Master menjadi Hijau Hutan.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Simpan presentasi ke disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Latar Belakang Gradasi untuk Slide**

Gradasi adalah efek grafis yang dibuat oleh perubahan warna secara bertahap. Ketika digunakan sebagai latar belakang slide, gradasi dapat membuat presentasi terlihat lebih artistik dan profesional. Aspose.Slides memungkinkan Anda mengatur warna gradasi sebagai latar belakang untuk slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/python-net/aspose.slides/backgroundtype/) slide ke `OWN_BACKGROUND`.
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) ke `GRADIENT`.
4. Gunakan properti `gradient_format` pada [FillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/) untuk mengonfigurasi pengaturan gradasi yang diinginkan.
5. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut menunjukkan cara mengatur warna gradasi sebagai latar belakang untuk slide:

```python
import aspose.slides as slides

# Buat instance dari kelas Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Terapkan efek gradasi pada latar belakang.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Simpan presentasi ke disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Gambar sebagai Latar Belakang Slide**

Selain isi solid dan gradasi, Aspose.Slides memungkinkan Anda menggunakan gambar sebagai latar belakang slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Setel [BackgroundType](https://reference.aspose.com/slides/id/python-net/aspose.slides/backgroundtype/) slide ke `OWN_BACKGROUND`.
3. Setel latar belakang slide [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) ke `PICTURE`.
4. Muat gambar yang ingin Anda gunakan sebagai latar belakang slide.
5. Tambahkan gambar ke koleksi gambar presentasi.
6. Gunakan properti `picture_fill_format` pada [FillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/) untuk menetapkan gambar sebagai latar belakang.
7. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut menunjukkan cara mengatur gambar sebagai latar belakang untuk slide:

```python
import aspose.slides as slides

# Buat instance dari kelas Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Atur properti gambar latar belakang.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Muat gambar.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Tambahkan gambar ke koleksi gambar presentasi.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Simpan presentasi ke disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Contoh kode berikut menunjukkan cara mengatur tipe isi latar belakang menjadi gambar berulang (tiled) dan memodifikasi properti pengulangan:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Atur gambar yang digunakan untuk isi latar belakang.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Atur mode isi gambar menjadi Tile dan sesuaikan properti ubin.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Baca selengkapnya: [**Tile Picture As Texture**](/slides/id/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ubah Transparansi Gambar Latar Belakang**

Anda mungkin ingin menyesuaikan transparansi gambar latar belakang slide agar konten slide lebih menonjol. Kode Python berikut menunjukkan cara mengubah transparansi untuk gambar latar belakang slide:

```python
transparency_value = 30  # Misalnya.

# Dapatkan koleksi operasi transformasi gambar.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Temukan efek transparansi persentase tetap yang sudah ada.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Atur nilai transparansi baru.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Mendapatkan Nilai Latar Belakang Slide**

Aspose.Slides menyediakan kelas [IBackgroundEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ibackgroundeffectivedata/) untuk mengambil nilai latar belakang efektif sebuah slide. Kelas ini menampilkan [FillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/) dan [EffectFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/effectformat/) yang efektif.

Dengan menggunakan properti `background` pada kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/), Anda dapat memperoleh latar belakang efektif untuk sebuah slide.

Contoh Python berikut menunjukkan cara mendapatkan nilai latar belakang efektif slide:

```python
import aspose.slides as slides

# Buat instance dari kelas Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Ambil latar belakang efektif, memperhitungkan master, layout, dan tema.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Apakah saya dapat mengatur ulang latar belakang khusus dan mengembalikan latar belakang tema/layout?**

Ya. Hapus isian khusus slide, dan latar belakang akan kembali diwarisi dari slide [layout](/slides/id/python-net/slide-layout/)/[master](/slides/id/python-net/slide-master/) yang bersesuaian (yaitu [latar belakang tema](/slides/id/python-net/presentation-theme/)).

**Apa yang terjadi pada latar belakang jika saya mengubah tema presentasi nanti?**

Jika sebuah slide memiliki isian sendiri, maka tidak akan berubah. Jika latar belakang diwarisi dari [layout](/slides/id/python-net/slide-layout/)/[master](/slides/id/python-net/slide-master/), maka akan diperbarui untuk menyesuaikan dengan [tema baru](/slides/id/python-net/presentation-theme/).