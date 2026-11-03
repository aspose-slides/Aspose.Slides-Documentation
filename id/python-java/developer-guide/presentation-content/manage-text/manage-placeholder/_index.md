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
description: "Pelajari cara memeriksa dan mengedit placeholder teks, gambar, diagram, dan konten serta memahami pewarisan placeholder dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Placeholder adalah bentuk yang memesan posisi untuk jenis konten tertentu dalam templat presentasi. Contoh umum meliputi placeholder judul, badan, gambar, diagram, dan placeholder konten serbaguna. Tidak seperti bentuk biasa, placeholder dapat mewarisi posisi, ukuran, pemformatan, dan pengaturan lainnya dari slide tata letak atau slide master.

Aspose.Slides mengekspose informasi placeholder melalui metode [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). Metode ini mengembalikan objek [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) atau `None` untuk bentuk normal. Gunakan [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) untuk menentukan apa yang dimaksudkan untuk diisi oleh placeholder.

Tipe bentuk masih penting setelah Anda mengetahui tipe placeholder:

- Placeholder teks, gambar, diagram, atau konten yang kosong biasanya direpresentasikan oleh sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Placeholder gambar yang sudah terisi dapat direpresentasikan oleh sebuah [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Placeholder diagram yang sudah terisi dapat direpresentasikan oleh sebuah [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Placeholder konten dapat berisi beberapa jenis konten. Periksa baik [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) maupun tipe bentuk runtime alih-alih mengasumsikan setiap placeholder adalah sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Peringatan" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) menjelaskan peran placeholder; itu tidak menjamin tipe runtime bentuk. Selalu lakukan pemeriksaan tipe sebelum mengakses anggota teks, gambar, diagram, tabel, atau media tertentu.
{{% /alert %}}

## **Memahami Pewarisan Placeholder**

Placeholder membentuk hierarki:

1. Slide master mendefinisikan gaya yang dapat digunakan kembali dan, dalam beberapa kasus, placeholder tingkat master.
2. Slide tata letak mendefinisikan susunan yang digunakan oleh satu atau lebih slide normal dan dapat mewarisi dari master.
3. Slide normal berisi placeholder untuk slide tersebut dan dapat mewarisi dari tata letaknya.

Panggil [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) untuk naik satu tingkat dalam hierarki ini. Sebuah placeholder slide biasanya mengembalikan placeholder tata letaknya; sebuah placeholder tata letak dapat mengembalikan placeholder masternya. Metode ini mengembalikan `None` ketika bentuk tidak memiliki placeholder dasar.

Contoh berikut mencantumkan placeholder pada slide pertama dan melaporkan placeholder dasarnya:
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

Mengedit placeholder pada slide normal membuat atau mengubah penimpaan lokal untuk slide tersebut. Mengedit tata letak atau master terkait dapat memengaruhi semua slide yang masih mewarisi pengaturan tersebut. Sebuah bentuk biasa lokal tidak memiliki placeholder dasar dan tidak mulai mewarisi hanya karena menempati koordinat yang sama.

## **Menghapus Status Placeholder**

Saat menyesuaikan templat, gunakan [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) untuk mempertahankan objek yang ada sebagai bentuk biasa. Metode [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder)‑nya mengembalikan `None`, tetapi bentuk tetap berada dalam koleksi slide. Sebaliknya, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) menghapus bentuk dari koleksi tersebut.

Contoh berikut memerlukan `template.pptx` dengan setidaknya satu slide dan placeholder teks yang tidak kosong pada slide pertama. Gunakan placeholder dengan pemformatan yang diwarisi dari tata letak atau master untuk melihat efek menghapus hubungan tersebut. Contoh memeriksa bahwa bentuk yang sama tetap ada, memanggil metode lagi pada bentuk yang kini biasa, dan menyimpan hasilnya.

{{% alert color="warning" title="Peringatan" %}}
Menghapus status placeholder tidak secara otomatis mempertahankan pengaturan tampilan yang diwarisi. Contoh di bawah sengaja membiarkan pengaturan tersebut tidak berubah, sehingga output mungkin terlihat berbeda. Sebuah bentuk yang posisinya dan ukurannya sepenuhnya diwarisi dapat memiliki koordinat dan dimensi nol setelah pemanggilan dan menjadi tidak terlihat meskipun tetap berada dalam koleksi.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Memanggil metode pada bentuk biasa tidak memberikan efek.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Untuk placeholder yang cocok, ketiga pemeriksaan mencetak `True`. Teks tetap, tetapi posisi, ukuran, rotasi, font, perataan paragraf, margin bingkai teks, penempatan vertikal, pengisian, dan pengaturan garis yang diwarisi dapat berubah ketika hubungan placeholder dihapus. Misalnya, pemformatan judul yang diwarisi dapat kembali ke pemformatan teks biasa. Lihat [Tata Letak Slide](/slides/id/python-java/slide-layout/) untuk informasi lebih lanjut tentang tata letak.

Untuk mempertahankan tampilan yang diinginkan, tangkap posisi, ukuran, dan rotasi yang sudah diselesaikan sebelum pemanggilan, dan salin nilai pemformatan efektif yang diperlukan ke variabel terpisah. Dapatkan nilai tersebut melalui [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective), dan [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Jangan bergantung hanya pada objek format‑efektif, karena nilai pemformatan teksnya dapat berubah setelah hubungan dihapus. Terapkan secara eksplisit nilai yang ditangkap ke bentuk biasa setelahnya, termasuk keluarga font, ukuran, gaya, warna, pengaturan paragraf, pengaturan bingkai teks, isi, dan garis yang digunakan oleh templat Anda.

Geometri bentuk yang diwarisi mungkin juga perlu ditetapkan secara eksplisit melalui [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Untuk placeholder teks persegi panjang, ini berarti menetapkan [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); mengembalikan hanya isi dan garis mungkin tidak mengembalikan persegi panjang yang terlihat. Templat dengan efek tambahan atau pemformatan yang lebih kompleks memerlukan pengaturan tersebut ditangani juga.

## **Mengubah Teks dalam Placeholder**

Placeholder judul, judul‑terpusat, subjudul, badan, dan teks biasanya mendukung teks. Periksa adanya [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) sebelum menggunakan metode [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame).

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

Pola ini menghindari memperlakukan placeholder gambar, diagram, tabel, atau media sebagai [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Ini juga mengidentifikasi placeholder berdasarkan tujuan alih‑alih mengandalkan indeks bentuk yang rapuh.

## **Menetapkan Teks Prompt pada Tata Letak**

Teks prompt adalah instruksi desain‑time yang ditampilkan dalam placeholder kosong, seperti *Click to add title*. Tetapkan teks prompt khusus pada placeholder tata letak daripada mencoba mengaksesnya melalui koleksi bentuk slide normal. Akses tata letak melalui [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) dan iterasi koleksi yang dikembalikan oleh [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

Contoh berikut mengubah prompt judul dan subjudul pada tata letak yang digunakan oleh slide pertama:
```python
import jpide
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

Teks prompt bukan konten slide normal. Itu dimaksudkan untuk placeholder kosong dalam aplikasi penyuntingan seperti PowerPoint. Setelah pengguna atau program memberikan konten nyata, prompt tidak lagi ditampilkan. Mengubah prompt juga tidak menggantikan teks yang sudah ada pada slide yang menggunakan tata letak tersebut.

## **Memperbarui Placeholder Gambar**

Ada dua kasus yang harus ditangani:

- Jika placeholder gambar sudah terisi dan direpresentasikan oleh sebuah [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), ganti gambar melalui [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) dan [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Jika masih merupakan placeholder kosong, tambahkan bingkai gambar pada koordinat placeholder dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) dan hapus placeholder kosong.

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

Penggantian yang dibuat untuk placeholder kosong adalah bingkai gambar lokal, bukan placeholder baru, karena [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) tidak menyediakan setter. Itu mempertahankan posisi yang dipesan tetapi tidak lagi mewarisi perilaku spesifik placeholder. Jika mempertahankan hubungan placeholder penting, siapkan dan isi placeholder di PowerPoint terlebih dahulu, kemudian perbarui [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) yang dihasilkan dengan Aspose.Slides.

Untuk transparansi gambar, pemotongan, dan efek khusus gambar lainnya, lihat [Kelola Bingkai Gambar](/slides/id/python-java/picture-frame/). Operasi tersebut berhubungan dengan bingkai gambar atau isi gambar, bukan dengan metadata placeholder.

## **Bekerja dengan Placeholder Diagram dan Konten**

Placeholder diagram yang terisi dapat direpresentasikan oleh sebuah [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Contoh ini menemukan diagram tersebut berdasarkan tipe placeholder dan tipe runtime, mengubah judulnya, dan menyimpan berkas:
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

Placeholder konten umum biasanya memiliki [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). Di PowerPoint ia berfungsi sebagai peluncur untuk beberapa jenis konten, termasuk diagram, tabel, diagram, gambar, dan media. Setelah terisi, periksa tipe bentuk sebenarnya untuk mengetahui apa yang dikandungnya. Tata letak khusus juga dapat menampilkan [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media), atau [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides tidak mengonversi placeholder [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) yang kosong menjadi [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) hanya dengan mengubah [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); tipe tidak dapat diubah melalui API. Untuk mengisi area diagram atau konten kosong secara programatik, tambahkan objek yang diperlukan pada koordinat placeholder dan kemudian hapus placeholder kosong. Contoh berikut melakukannya untuk sebuah diagram:
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

Diagram yang ditambahkan adalah diagram lokal biasa. Ia menempati area placeholder tetapi tidak mewarisi dari placeholder tata letak. Gunakan [artikel manajemen diagram](/slides/id/python-java/powerpoint-charts/) yang khusus ketika Anda perlu mengganti kategori, seri, atau data buku kerja diagram tersebut.

## **Contoh Lengkap: Memperbarui Konten Teks atau Gambar**

Contoh end‑to‑end berikut membuka sebuah templat, mencari slide pertama untuk placeholder judul atau gambar, memeriksa tipe placeholder dan bentuk, memperbarui konten yang sesuai, dan menyimpan output. Contoh ini sengaja menghindari asumsi indeks bentuk atau memperlakukan setiap placeholder sebagai tipe yang sama.
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

Placeholder dasar adalah bentuk yang sesuai pada tata letak atau master yang menjadi sumber pewarisan bagi placeholder lain. Gunakan [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) untuk mengambilnya. Sebuah bentuk lokal biasa mengembalikan `None` karena tidak termasuk dalam hierarki placeholder.

**Bisakah saya mengubah semua judul slide dengan mengedit placeholder tata letak?**

Anda dapat mengubah pemformatan yang diwarisi atau teks prompt melalui tata letak, tetapi konten judul yang ada disimpan pada slide normal. Untuk mengganti teks judul sebenarnya di seluruh presentasi, iterasikan slide‑slide dan perbarui setiap placeholder judul.

**Bagaimana cara mengelola placeholder tanggal, nomor‑slide, header, dan footer?**

Gunakan manajer header dan footer pada lingkup slide, tata letak, master, catatan, atau handout yang sesuai. Lihat [Kelola Header dan Footer Presentasi](/slides/id/python-java/presentation-header-and-footer/) untuk contoh lengkap.