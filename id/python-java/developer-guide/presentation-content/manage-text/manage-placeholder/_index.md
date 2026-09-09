---
title: Kelola Placeholder Presentasi dalam Python
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/python-java/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- placeholder konten
- teks prompt
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk Python melalui Java."
---
## **Ringkasan**

Placeholder adalah bentuk yang menyimpan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, isi, gambar, diagram, dan placeholder konten umum. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides menyediakan informasi placeholder melalui metode [Shape.getPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getPlaceholder). Metode ini mengembalikan objek [Placeholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholder/) atau `None` untuk bentuk biasa. Gunakan [Placeholder.getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholder/#getType) untuk menentukan apa yang dimaksudkan untuk ditempatkan dalam placeholder.

Tipe bentuk tetap penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten yang kosong biasanya direpresentasikan oleh [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).
- Placeholder gambar yang sudah terisi dapat direpresentasikan oleh [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/).
- Placeholder diagram yang sudah terisi dapat direpresentasikan oleh [Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [Placeholder.getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholder/#getType) maupun tipe bentuk pada waktu berjalan alih‑alih mengasumsikan bahwa setiap placeholder adalah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholder/#getType) menjelaskan peran placeholder; hal ini tidak menjamin tipe bentuk pada waktu berjalan. Selalu lakukan pemeriksaan tipe sebelum mengakses anggota teks, gambar, diagram, tabel, atau media khusus.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide biasa dan dapat mewarisi dari master.
3. Slide biasa berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getBasePlaceholder) untuk naik satu tingkat dalam hierarki ini. Placeholder slide biasanya mengembalikan placeholder tata letaknya; placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `None` ketika bentuk tidak memiliki placeholder dasar.

Contoh berikut menampilkan placeholder pada slide pertama dan melaporkan placeholder dasarnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Mengedit placeholder pada slide biasa membuat atau mengubah penimpaan lokal untuk slide tersebut. Mengedit tata letak atau master terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan itu. Bentuk biasa lokal tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Mengubah Teks dalam Placeholder**

Placeholder judul, judul‑tengah, subjudul, isi, dan teks biasanya mendukung teks. Periksa apakah bentuk adalah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) sebelum menggunakan metode [getTextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#getTextFrame).

Contoh ini memperbarui placeholder judul pertama pada slide pertama dan menyimpan hasilnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pola ini menghindari memperlakukan placeholder gambar, diagram, tabel, atau media sebagai [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/). Ini juga mengidentifikasi placeholder berdasarkan tujuan alih‑alih mengandalkan indeks bentuk yang rapuh.

## **Menetapkan Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi desain‑waktu yang ditampilkan dalam placeholder kosong, seperti *Klik untuk menambah judul*. Tetapkan teks prompt khusus pada placeholder tata letak daripada mencoba mencapainya melalui koleksi bentuk slide biasa. Akses tata letak melalui [Slide.getLayoutSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getLayoutSlide) dan iterasi koleksi yang dikembalikan oleh [BaseSlide.getShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getShapes).

Contoh berikut mengubah prompt judul dan subjudul pada tata letak yang digunakan oleh slide pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Teks prompt bukan konten slide biasa. Itu ditujukan untuk placeholder kosong dalam aplikasi penyunting seperti PowerPoint. Setelah pengguna atau program menambahkan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang sudah ada pada slide yang menggunakan tata letak tersebut.

## **Memperbarui Placeholder Gambar**

Ada dua kasus yang harus ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/), ganti gambar melalui [PictureFillFormat.getPicture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#getPicture) dan [Picture.setImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#setImage).
- Jika masih berupa placeholder kosong, tambahkan bingkai gambar pada koordinat placeholder dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addPictureFrame) dan hapus placeholder kosong tersebut.

Contoh berikut mendukung kedua kasus dan menyimpan presentasi:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pengganti yang dibuat untuk placeholder kosong adalah bingkai gambar lokal, bukan placeholder baru, karena [Shape.getPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getPlaceholder) tidak menyediakan pengatur. Itu mempertahankan posisi yang dicadangkan tetapi tidak lagi mewarisi perilaku khusus placeholder. Jika mempertahankan hubungan placeholder penting, persiapkan dan isi placeholder di PowerPoint terlebih dahulu, lalu perbarui [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Manage Picture Frames](/slides/id/python-java/picture-frame/). Operasi tersebut termasuk dalam bingkai gambar atau pengisian gambar, bukan metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang terisi dapat direpresentasikan oleh [Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/). Contoh ini menemukan diagram tersebut dengan memeriksa baik tipe placeholder maupun tipe bentuk pada waktu berjalan, mengubah judulnya, dan menyimpan file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Placeholder konten umum biasanya memiliki [PlaceholderType.Object](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholdertype/#Object). Di PowerPoint ia berfungsi sebagai peluncur untuk beberapa tipe konten, termasuk diagram, tabel, diagram alur, gambar, dan media. Setelah diisi, periksa tipe bentuk sebenarnya untuk mengetahui apa yang terkandung di dalamnya. Tata letak khusus juga dapat mengekspos [PlaceholderType.Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholdertype/#Media), atau [PlaceholderType.Diagram](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides tidak mengubah placeholder [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) yang kosong menjadi [Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/) hanya dengan mengubah [Placeholder.getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholder/#getType); tipe tidak dapat diubah melalui API. Untuk mengisi area diagram atau konten kosong secara programatik, tambahkan objek yang diperlukan pada koordinat placeholder lalu hapus placeholder kosong. Contoh berikut melakukan hal itu untuk diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan artikel manajemen diagram khusus [chart management articles](/slides/id/python-java/powerpoint-charts/) ketika Anda perlu mengganti kategori, seri, atau data workbook‑nya.

## **Contoh Lengkap: Memperbarui Teks atau Konten Gambar**

Contoh end‑to‑end berikut membuka templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan hasilnya. Contoh ini sengaja menghindari asumsi indeks bentuk atau memperlakukan setiap placeholder sebagai tipe yang sama.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Apa itu placeholder dasar?**

Placeholder dasar adalah bentuk yang sesuai pada tata letak atau master dari mana placeholder lain mewarisi. Gunakan [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getBasePlaceholder) untuk mengambilnya. Bentuk lokal biasa mengembalikan `None` karena tidak termasuk dalam hierarki placeholder.

**Apakah saya dapat mengubah semua judul slide dengan mengedit placeholder tata letak?**

Anda dapat mengubah pemformatan atau teks prompt yang diwarisi melalui tata letak, tetapi konten judul yang ada disimpan pada slide biasa. Untuk mengganti teks judul sebenarnya di seluruh presentasi, iterasi semua slide dan perbarui masing‑masing placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor‑slide, header, dan footer?**

Gunakan pengelola header dan footer pada tingkat slide, tata letak, master, catatan, atau handout yang sesuai. Lihat [Manage Presentation Header and Footer](/slides/id/python-java/presentation-header-and-footer/) untuk contoh lengkap.