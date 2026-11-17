---
title: Kelola Efek Transformasi Gambar dalam Presentasi dengan Python
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/python-net/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- skala abu-abu
- duotone
- tint
- HSL
- penggantian warna
- kabur
- transparansi
- efek alfa
- rantai efek
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Terapkan, susun rantai, inspeksi, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk Python via .NET."
---
## **Ikhtisar**

Aspose.Slides mewakili penyesuaian gambar sebagai koleksi terurut dari operasi transformasi gambar. Untuk sebuah bingkai gambar, mulai dengan [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) dan akses properti [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, menelusuri, memeriksa, menghapus, dan membersihkan efek tanpa menulis kembali byte gambar asli.

Artikel ini menunjukkan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi putar balik PPTX.

## **Memahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sumber gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) milik isian gambar dan merujuk ke sumber gambar sambil menyimpan koleksi transformasi gambar.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) adalah bentuk slide yang memiliki isian gambar yang relevan, geometri, pengaturan pangkasan, dan format tingkat bingkai lainnya.

Oleh karena itu, operasi transformasi gambar tidak memodifikasi byte dalam [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Ketika [PPImage] yang sama diteruskan ke [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) lebih dari satu kali, setiap bingkai gambar baru menerima `Picture` miliknya sendiri dan koleksi transformasinya sendiri. Menerapkan grayscale pada satu bingkai tidak membuat bingkai lainnya menjadi grayscale, meskipun semuanya menggunakan kembali sumber gambar yang sama.

Model `Picture.image_transform` yang sama juga digunakan oleh isian gambar lain, seperti bentuk atau latar belakang slide. Contoh di bawah berfokus pada bingkai gambar.

## **Gunakan Rentang Parameter dan unit yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan unit berikut. Jaga nilai dalam rentang ini meskipun versi perpustakaan tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target mungkin menormalkan, mengabaikan, atau menolak data tidak valid saat menyimpan atau ketika PowerPoint membuka berkas.

| Operasi | Parameter | Rentang dan unit yang valid |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` sampai `100`, persen; `0` membiarkan komponen tidak berubah. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Tidak ada parameter numerik. Alpha tidak berubah. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Dua warna untuk piksel gelap dan terang. Saluran RGB dan alpha menggunakan `0` sampai `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue adalah `0` inklusif sampai `360` eksklusif, dalam derajat; amount adalah `-100` sampai `100`, persen. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue adalah `0` inklusif sampai `360` eksklusif, dalam derajat; saturation dan luminance adalah `-100` sampai `100`, persen. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Warna pengganti menggunakan nilai saluran dari `0` sampai `255`. Nilai alpha yang ada tidak berubah. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius tidak negatif dan diukur dalam poin; `grow` adalah Boolean yang mengontrol apakah konten blur dapat melampaui batas gambar asli. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Persen tidak negatif. Gunakan `0` sampai `100` untuk skala opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alpha yang ada. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` sampai `100`, persen opasitas. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` sampai `100`, persen ambang alpha. Nilai di bawahnya menjadi transparan; nilai pada atau di atasnya menjadi tidak transparan. |

Untuk modulasi alpha tetap, transparansi dan opasitas saling melengkapi. Misalnya, transparansi 35% bersesuaian dengan jumlah modulasi alpha sebesar 65%.

## **Terapkan Kecerahan dan Kontras**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) mengembalikan operasi [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). Pengaturan skalarnya diberikan saat operasi dibuat. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) mengembalikan nilai hanya-baca yang dihitung yang dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15% dan kontras sebesar 20%, lalu merender pratinjau tanpa mengubah gambar tertanam:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) adalah ekstensi efek gambar Office 2010 dan kurang portabel dibandingkan efek luminansi DrawingML standar. Ketika kecerahan dan kontras harus tetap dapat diedit setelah putar balik PPTX, gunakan [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) dan verifikasi hasil setelah membuka kembali berkas. Bagian batasan format menjelaskan perbedaan ini secara lebih detail.

## **Terapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada bingkai gambar yang berbeda yang menggunakan satu sumber gambar. Contoh berikut membuat lima bingkai dan menerapkan grayscale, duotone, tint, penyesuaian HSL, dan penggantian warna.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) berisi dua parameter warna yang dapat diedit secara independen: `color1` memetakan piksel gelap, sementara `color2` memetakan piksel terang. Ini menjadikannya contoh berguna untuk efek yang pengaturannya lebih kompleks daripada satu nilai skalar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) mengganti warna setiap piksel dengan satu warna tetap sambil mempertahankan alpha. Ini berbeda dari [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), yang memetakan satu warna sumber ke warna lain dan mengekspos format warna sumber dan target.

### **Terapkan Ambang Luminansi**

Ambang luminansi dapat membuat tanda samar pada halaman yang dipindai lebih mudah dibedakan dari latar belakang. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) mempertahankan nuansa abu-abu menengah. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) memetakan luminansi ke hitam atau putih, sementara [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) menerapkan ambang pada opasitas.

Ambang luminansi berkisar dari 0% hingga 100%, inklusif. Piksel di bawah ambang menjadi hitam. Piksel pada atau di atasnya menjadi putih. Menaikkan ambang membuat lebih banyak nuansa menjadi hitam karena lebih banyak di antaranya jatuh di bawah batas.

Unduh [grayscale-swatches.png](grayscale-swatches.png) ke direktori kerja. Setiap label memberi tingkat abu-abu asli pada skala 0 hingga 255. Contoh menempatkan gambar asli di samping dua salinan dan menyimpan ambang masing‑masing dalam presentasi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Buka presentasi output di PowerPoint untuk membandingkan tiga bingkai. Swatch yang berlabel 96 memiliki luminansi sekitar 38% (96 dari 255). Swatch ini menjadi putih pada ambang 20% dan menjadi hitam pada ambang 60%.

![Swatch grayscale asli berdampingan dengan hasil hitam‑putih pada ambang luminansi 20% dan 60%](luminance-threshold.png)

## **Tambahkan Blur, Transparansi, dan Efek Alpha**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) memengaruhi semua saluran warna, termasuk alpha. Atur `grow` ke `True` ketika tepi blur dapat melampaui batas gambar asli.

Untuk transparansi seragam, gunakan [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Itu mengalikan setiap nilai alpha yang ada, sehingga piksel yang sebagian transparan tetap berbeda secara proporsional. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) sebaliknya menetapkan satu nilai alpha ke semua piksel. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) mengonversi alpha menjadi dua tingkat berdasarkan ambang.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Operasi alpha tanpa parameter lain termasuk [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), yang menjadikan setiap alpha nonnol sepenuhnya tidak transparan; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), yang menjadikan setiap alpha di bawah 100% sepenuhnya transparan; dan [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), yang mengubah alpha menjadi `100% - alpha`.

## **Bangun Rantai Efek Berurutan**

Setiap metode `add_..._effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai pipa berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Akibatnya, operasi yang sama dalam urutan berbeda dapat menghasilkan gambar yang berbeda.

Misalnya, grayscale diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai kembali hasil luminansi. Tint diikuti grayscale menghapus tint lagi. Demikian pula, penggantian alpha dapat mengganti nilai alpha yang dihitung oleh operasi sebelumnya, sementara modulasi alpha mempertahankan perbedaan relatifnya.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa baik tipe operasi maupun urutannya, dan merender hasil yang dibuka kembali:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

Koleksi tidak memberlakukan matriks kompatibilitas yang membatasi operasi warna, alpha, dan blur ke rantai terpisah. Mereka dapat digabungkan, tetapi kombinasi tidak selalu berguna. Penggantian warna tetap menghapus variasi RGB yang dihasilkan oleh efek warna sebelumnya; grayscale setelah duotone menghapus dua warna yang dipilih; dan operasi alpha ceiling, floor, replacement, atau bi‑level dapat membuang detail alpha yang dibuat sebelumnya. Bangun rantai sesuai urutan pemrosesan piksel yang diinginkan alih‑alih memperlakukan itemnya sebagai bendera format yang tidak berurutan.

<!-- visual-explanation:image-transform-effects:start -->
[![Gambar yang sama melewati grayscale lalu tint, dan tint lalu grayscale. Dua gambar grayscale akhir memiliki nada yang berbeda.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
<!-- visual-explanation:image-transform-effects:end -->

## **Periksa Nilai yang Dapat Diedit dan Efektif**

Operasi yang dapat diedit adalah objek yang disimpan dalam `Picture.image_transform`. Tergantung pada efeknya, objek tersebut dapat mengekspos anggota yang dapat ditulis secara langsung. Misalnya, [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) mengekspos properti `radius` dan `grow` yang dapat ditulis, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) mengekspos properti `amount` yang dapat ditulis, dan [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) mengekspos properti `threshold` yang dapat ditulis. Efek warna seperti [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) mengekspos objek [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) yang dapat diubah.

Beberapa operasi, termasuk [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), dan [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), tidak mengekspos skalar pembuatannya sebagai properti yang dapat ditulis. Untuk mengubah pengaturan tersebut, hapus operasi dan tambahkan pengganti pada posisi yang diperlukan.

Data efektif yang dikembalikan oleh `get_effective()` dihitung dan hanya‑baca. Data ini berguna untuk memecahkan warna yang bergantung pada tema dan membaca nilai normalisasi yang digunakan renderer, tetapi bukan permukaan penyuntingan lain. Contoh berikut menelusuri rantai dan memeriksa nilai efektif di mana API yang bersangkutan menyediakannya:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Efek tanpa parameter seperti grayscale, alpha ceiling, dan alpha inverse tetap memiliki objek data‑efektif, tetapi tidak ada pengaturan skalar untuk dicetak. Keberadaan dan posisi mereka dalam koleksi adalah informasi penting.

## **Hapus atau Bersihkan Transformasi Gambar**

Gunakan [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah penelusuran. Gunakan `clear()` untuk menghapus seluruh rantai.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Menghapus atau membersihkan transformasi hanya mengubah pemformatan gambar. Itu tidak menghapus, mengompres ulang, atau mengubah sumber [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) yang digunakan kembali.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format yang dapat diedit paling disarankan untuk rantai efek. Bahkan dengan PPTX, tidak setiap operasi memiliki portabilitas yang sama:

- Operasi DrawingML standar seperti luminansi, grayscale, duotone, tint, HSL, blur, dan operasi alpha umum memiliki peluang terbaik untuk bertahan setelah putar balik PPTX. Selalu buka kembali berkas yang dihasilkan dan periksa koleksi ketika preservasi menjadi keharusan.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) adalah ekstensi Office 2010, bukan operasi luminansi DrawingML standar. Itu dapat digunakan untuk rendering dalam memori, tetapi tidak dijamin tetap sebagai operasi `BrightnessContrast` yang dapat diedit setelah menyimpan dan membuka kembali PPTX. Lebih baik gunakan [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) untuk penyesuaian kecerahan dan kontras yang persisten.
- Format PPT biner lebih tua daripada model efek DrawingML lengkap. Menyimpan ke PPT dapat mengabaikan operasi yang tidak didukung, mengurangi rantai menjadi subset yang didukung, atau memperkirakan tampilan. Jangan gunakan PPT sebagai format verifikasi untuk rantai yang dapat diedit secara kompleks.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lain menerapkan rantai yang didukung ke tampilan yang dirender. Output tersebut tidak berisi `ImageTransformOperationCollection` yang dapat diedit; format raster meratakan hasil menjadi piksel, dan ekspor dokumen atau vektor menyimpan representasi rendering mereka sendiri.
- Efek tidak menjadikan gambar tertaut menjadi mandiri. Rendering gambar tertaut tetap bergantung pada sumber tertaut yang tersedia saat presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, terutama ketika beberapa operasi alpha atau kuantisasi warna digabungkan. Untuk output yang kritis, uji kedua putar balik yang dapat diedit dan format ekspor akhir dengan versi Aspose.Slides yang sama seperti yang digunakan dalam produksi.

## **FAQ**

**Apakah efek transformasi gambar mengubah data gambar yang tertanam?**

Tidak. Operasi tersebut merupakan milik `Picture` yang dipakai oleh isian gambar. Byte `PPImage` yang mendasari tetap tidak berubah.

**Apakah dua bingkai gambar yang menggunakan kembali gambar yang sama akan berbagi efeknya?**

Tidak. Menggunakan kembali `PPImage` menghindari duplikasi data gambar, tetapi setiap bingkai gambar biasanya memiliki `Picture` terpisah dan koleksi transformasi gambar masing‑masing.

**Dapatkah efek warna, blur, dan alpha digabungkan?**

Ya. Koleksi menerima mereka dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan setiap operasi pada output operasi sebelumnya karena operasi penggantian dan ambang dapat membuang detail warna atau alpha sebelumnya.

**Mengapa nilai efektif hanya dapat dibaca?**

Data efektif mewakili nilai yang dihitung untuk rendering, termasuk warna yang telah diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi di mana anggota yang dapat ditulis ada; jika tidak, hapus dan tambahkan pengganti dengan parameter pembuatan baru.

**Format apa yang harus saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi berkas dengan membukanya kembali. PPT lama tidak dapat merepresentasikan model efek DrawingML lengkap, dan format ekspor yang dirender hanya mempertahankan tampilan bukan operasi transformasi yang dapat diedit.