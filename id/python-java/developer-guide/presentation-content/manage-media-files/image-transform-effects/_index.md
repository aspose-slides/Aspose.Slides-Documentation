---
title: Kelola Efek Transformasi Gambar dalam Presentasi dengan Python
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/python-java/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- skala abu-abu
- duotone
- rona
- HSL
- penggantian warna
- kabur
- transparansi
- efek alfa
- rantai efek
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Terapkan, rangkai, inspeksi, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk Python via Java."
---
## **Ikhtisar**

Aspose.Slides merepresentasikan penyesuaian gambar sebagai koleksi berurutan dari operasi transformasi gambar. Untuk sebuah bingkai gambar, mulailah dengan [Picture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/) bingkai tersebut dan akses [Picture.getImageTransform](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#getImageTransform). [ImageTransformOperationCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, menelusuri, memeriksa, menghapus, dan membersihkan efek tanpa menulis ulang byte gambar asli.

Artikel ini memperlihatkan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi putar‑balik PPTX.

## **Memahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sebuah sumber gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [Picture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/) milik isian gambar dan merujuk ke sumber gambar sekaligus menyimpan koleksi transformasi gambar.
- [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) adalah bentuk slide yang memiliki isian gambar yang relevan, geometri, pengaturan pemotongan, dan format level bingkai lainnya.

Karena itu, operasi transformasi gambar tidak mengubah byte di dalam [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/). Ketika `PPImage` yang sama diberikan ke [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addPictureFrame) lebih dari satu kali, setiap bingkai gambar baru menerima `Picture` dan koleksi transformasinya masing‑masing. Menerapkan grayscale pada satu bingkai tidak membuat bingkai lain menjadi grayscale, meskipun semuanya menggunakan sumber gambar tersemat yang sama.

Model `Picture.getImageTransform` yang sama juga digunakan oleh isian gambar lainnya, seperti bentuk atau latar belakang slide. Contoh di bawah ini difokuskan pada bingkai gambar.

## **Gunakan Rentang Parameter dan Unit yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan unit berikut. Pertahankan nilai dalam rentang ini meskipun versi perpustakaan tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target dapat menormalkan, mengabaikan, atau menolak data tidak valid saat menyimpan atau ketika PowerPoint membuka berkas.

| Operasi | Parameter | Rentang dan unit yang valid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` hingga `100`, persen; `0` meninggalkan komponen tidak berubah. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Tidak ada parameter numerik. Alpha tidak berubah. |
| [addDuotoneEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Dua warna untuk piksel gelap dan terang. Kanal RGB dan alpha pada `java.awt.Color` menggunakan `0` hingga `255`. |
| [addTintEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Hue `0` inklusif hingga `360` eksklusif, dalam derajat; amount `-100` hingga `100`, persen. |
| [addHSLEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Hue `0` inklusif hingga `360` eksklusif, dalam derajat; saturation dan luminance `-100` hingga `100`, persen. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Warna pengganti menggunakan nilai kanal dari `0` hingga `255`. Nilai alpha yang ada tidak berubah. |
| [addBlurEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Radius tidak negatif dan diukur dalam poin; `grow` adalah Boolean yang mengontrol apakah konten blur dapat meluas di luar batas asli. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Persen tidak negatif. Gunakan `0` hingga `100` untuk skala opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alpha yang ada. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` hingga `100`, persen opasitas. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` hingga `100`, persen ambang alpha. Nilai di bawahnya menjadi transparan; nilai pada atau di atasnya menjadi opaque. |

Untuk modulasi alpha tetap, transparansi dan opasitas bersifat komplementer. Misalnya, transparansi 35 % bersesuaian dengan nilai modulasi alpha 65 %.

## **Terapkan Kecerahan dan Kontras**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) mengembalikan operasi [BrightnessContrast](https://reference.aspose.com/slides/id/python-java/aspose.slides/brightnesscontrast/). Pengaturan skalarnya diberikan saat operasi dibuat. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/brightnesscontrast/#getEffective) mengembalikan nilai hanya‑baca yang telah dihitung dan dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15 % dan kontras sebesar 20 %, lalu menampilkan pratinjau tanpa memodifikasi gambar tersemat:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/id/python-java/aspose.slides/brightnesscontrast/) merupakan ekstensi efek gambar Office 2010 dan kurang portabel daripada efek luminansi DrawingML standar. Ketika kecerahan dan kontras harus tetap dapat diedit setelah putar‑balik PPTX, gunakan [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) dan verifikasi hasilnya setelah membuka kembali berkas. Bagian keterbatasan format menjelaskan perbedaan ini secara lebih rinci.

## **Terapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada berbagai bingkai gambar yang menggunakan satu sumber gambar. Contoh berikut membuat lima bingkai dan menerapkan grayscale, duotone, tint, penyesuaian HSL, serta penggantian warna.

[Duotone](https://reference.aspose.com/slides/id/python-java/aspose.slides/duotone/) memiliki dua parameter warna yang dapat diedit secara terpisah: `color1` memetakan piksel gelap, sementara `color2` memetakan piksel terang. Inilah contoh yang berguna untuk efek dengan pengaturan yang lebih kompleks daripada nilai skalar tunggal.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) mengganti setiap warna piksel dengan satu warna tetap sambil mempertahankan alpha. Ini berbeda dari [addColorChangeEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), yang memetakan satu warna sumber ke warna target dan menampilkan format warna sumber serta target.

## **Tambahkan Blur, Transparansi, dan Efek Alpha**

[addBlurEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) memengaruhi semua kanal warna, termasuk alpha. Atur `grow` ke `True` bila tepi blur dapat meluas di luar batas gambar asli.

Untuk transparansi seragam, gunakan [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Ia mengalikan setiap nilai alpha yang ada, sehingga piksel semi‑transparan tetap proporsional berbeda. [addAlphaReplaceEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) malah menetapkan satu nilai alpha ke semua piksel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) mengubah alpha menjadi dua tingkat berdasarkan ambang.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Operasi alpha tanpa parameter lainnya meliputi [addAlphaCeilingEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), yang menjadikan setiap alpha non‑nol sepenuhnya opaque; [addAlphaFloorEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), yang menjadikan setiap alpha di bawah 100 % sepenuhnya transparan; dan [addAlphaInverseEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), yang mengubah alpha menjadi `100% - alpha`.

## **Bangun Rantai Efek Berurutan**

Setiap metode `add...Effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai pipeline berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Oleh karena itu, urutan operasi yang sama tetapi disusun berbeda dapat menghasilkan gambar yang berbeda.

Sebagai contoh, grayscale diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai kembali hasil luminansi. Tint diikuti grayscale menghilangkan tint kembali. Demikian pula, penggantian alpha dapat menimpa nilai alpha yang dihitung oleh operasi sebelumnya, sementara modulasi alpha mempertahankan perbedaan relatifnya.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa tipe operasi serta urutannya, dan menampilkan hasil yang dibuka kembali:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

Koleksi tidak memberlakukan matriks kompatibilitas yang memisahkan operasi warna, alpha, dan blur ke dalam rantai terpisah. Mereka dapat digabungkan, namun kombinasi tidak selalu berguna. Penggantian warna tetap menghilangkan variasi RGB yang dihasilkan oleh efek warna sebelumnya; grayscale setelah duotone menghapus kedua warna terpilih; dan operasi alpha ceiling, floor, replacement, atau bi‑level dapat mengabaikan detail alpha yang dibuat sebelumnya. Bangun rantai berdasarkan urutan pemrosesan piksel yang diinginkan, bukan memperlakukan elemennya sebagai flag format tidak berurutan.

## **Periksa Nilai yang Dapat Diedit dan Nilai Efektif**

Operasi yang dapat diedit adalah objek yang disimpan dalam `Picture.getImageTransform`. Tergantung pada efeknya, objek tersebut dapat menampilkan anggota yang dapat ditulis secara langsung. Misalnya, [Blur](https://reference.aspose.com/slides/id/python-java/aspose.slides/blur/) menampilkan nilai `radius` dan `grow` yang dapat ditulis, [AlphaModulateFixed](https://reference.aspose.com/slides/id/python-java/aspose.slides/alphamodulatefixed/) menampilkan `amount` yang dapat ditulis, dan [AlphaBiLevel](https://reference.aspose.com/slides/id/python-java/aspose.slides/alphabilevel/) menampilkan `threshold` yang dapat ditulis. Efek warna seperti [Duotone](https://reference.aspose.com/slides/id/python-java/aspose.slides/duotone/) menampilkan objek [ColorFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/colorformat/) yang dapat diubah.

Beberapa kelas operasi, termasuk [BrightnessContrast](https://reference.aspose.com/slides/id/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/id/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/id/python-java/aspose.slides/tint/), dan [AlphaReplace](https://reference.aspose.com/slides/id/python-java/aspose.slides/alphareplace/), tidak menampilkan skalar pembuatan mereka sebagai properti yang dapat ditulis. Untuk mengubah pengaturan tersebut, hapus operasi dan tambahkan pengganti pada posisi yang diperlukan.

Data efektif yang dikembalikan oleh `getEffective` dihitung dan hanya‑baca. Data ini berguna untuk menyelesaikan warna yang bergantung pada tema dan membaca nilai ternormalkan yang digunakan renderer, namun bukan permukaan penyuntingan lain. Contoh berikut menelusuri rantai dan memeriksa nilai efektif di mana API yang bersangkutan menyediakannya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Efek tanpa parameter seperti grayscale, alpha ceiling, dan alpha inverse tetap memiliki objek data‑efektif, namun tidak ada pengaturan skalar untuk dicetak. Keberadaan dan posisi mereka dalam koleksi adalah informasi penting.

## **Hapus atau Bersihkan Transformasi Gambar**

Gunakan [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah penelusuran. Gunakan [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#clear) untuk menghapus seluruh rantai.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Menghapus atau membersihkan transformasi hanya mengubah format gambar. Ia tidak menghapus, mengompres ulang, atau mengubah sumber daya [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) yang digunakan kembali.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format yang paling disarankan untuk mengedit rantai efek. Bahkan dengan PPTX, tidak setiap operasi memiliki portabilitas yang sama:

- Operasi DrawingML standar seperti luminance, grayscale, duotone, tint, HSL, blur, dan operasi alpha umum memiliki peluang terbaik untuk bertahan setelah putar‑balik PPTX. Selalu buka kembali berkas yang dihasilkan dan periksa koleksi bila preservasi menjadi keharusan.
- [BrightnessContrast](https://reference.aspose.com/slides/id/python-java/aspose.slides/brightnesscontrast/) adalah ekstensi Office 2010, bukan operasi luminance DrawingML standar. Ia dapat dipakai untuk rendering dalam memori, namun tidak dijamin tetap sebagai [BrightnessContrast](https://reference.aspose.com/slides/id/python-java/aspose.slides/brightnesscontrast/) yang dapat diedit setelah penyimpanan dan pembukaan kembali PPTX. Lebih disarankan menggunakan [addLuminanceEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) untuk penyesuaian kecerahan dan kontras yang persisten.
- Format PPT biner mendahului model efek DrawingML penuh. Menyimpan ke PPT dapat mengabaikan operasi yang tidak didukung, mengurangi rantai menjadi subset yang didukung, atau memperkirakan tampilan. Jangan gunakan PPT sebagai format verifikasi untuk rantai yang dapat diedit secara kompleks.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lainnya menerapkan rantai yang didukung pada tampilan yang dirender. Output tersebut tidak berisi `ImageTransformOperationCollection` yang dapat diedit; format raster meratakan hasil menjadi piksel, dan ekspor dokumen/vektor menyimpan representasi rendering mereka sendiri.
- Efek tidak membuat gambar terhubung menjadi mandiri. Rendering gambar yang ditautkan tetap bergantung pada sumber yang ditautkan tersedia saat presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, terutama ketika beberapa operasi alpha atau kuantisasi warna digabungkan. Untuk output yang kritis, uji kedua‑duanya: putar‑balik yang dapat diedit dan format ekspor akhir dengan versi Aspose.Slides yang sama seperti yang digunakan dalam produksi.

## **Tanya Jawab**

**Apakah efek transformasi gambar mengubah data gambar yang tersemat?**

Tidak. Operasi tersebut milik `Picture` yang digunakan oleh isian gambar. Byte `PPImage` yang mendasari tetap tidak berubah.

**Apakah dua bingkai gambar yang menggunakan gambar yang sama akan berbagi efeknya?**

Tidak. Menggunakan kembali `PPImage` menghindari duplikasi data gambar, namun setiap bingkai gambar biasanya memiliki `Picture` dan koleksi transformasi gambar yang terpisah.

**Apakah efek warna, blur, dan alpha dapat digabungkan?**

Ya. Koleksi menerima semuanya dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan setiap operasi pada output operasi sebelumnya karena operasi penggantian dan ambang dapat menghapus detail warna atau alpha sebelumnya.

**Mengapa nilai efektif bersifat hanya‑baca?**

Data efektif mewakili nilai yang dihitung untuk rendering, termasuk warna yang telah diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi bila ada anggota yang dapat ditulis; jika tidak, hapus dan tambahkan pengganti dengan parameter pembuatan baru.

**Format apa yang harus saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi berkas dengan membukanya kembali. PPT lama tidak dapat merepresentasikan model efek DrawingML penuh, dan format ekspor yang dirender hanya mempertahankan tampilan bukan operasi transformasi yang dapat diedit.