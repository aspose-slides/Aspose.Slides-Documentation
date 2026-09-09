---
title: Kelola Zoom Presentasi di Python via Java
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/python-java/manage-zoom/
keywords:
- zoom
- kerangka zoom
- zoom slide
- zoom bagian
- zoom ringkasan
- tambahkan zoom
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk Python via Java — lompat antara bagian, tambahkan thumbnail dan transisi di seluruh presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, serta bagian tertentu dari sebuah presentasi. Saat Anda menyajikan, kemampuan untuk menavigasi dengan cepat di seluruh konten ini dapat sangat berguna.

![overview_image](overview.png)

* Untuk meringkas seluruh presentasi pada satu slide, gunakan [Summary Zoom](#summary-zoom).
* Untuk menampilkan hanya slide terpilih, gunakan [Slide Zoom](#slide-zoom).
* Untuk menampilkan hanya satu bagian, gunakan [Section Zoom](#section-zoom).

## **Slide Zoom**
A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Zoom slide dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi secara bebas antara slide dalam urutan apa pun yang Anda pilih tanpa mengganggu alur presentasi. Zoom slide sangat cocok untuk presentasi singkat tanpa banyak bagian, namun Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Zoom slide membantu Anda menelusuri banyak potongan informasi sekaligus seolah-olah berada di satu kanvas.

![overview_image](slidezoomsel.png)

Untuk objek zoom slide, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomimagetype/) , kelas [ZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomframe/) , dan beberapa metode dalam kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/) .

### **Buat Bingkai Zoom**

Anda dapat menambahkan bingkai zoom pada slide dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru yang akan Anda tautkan dengan bingkai zoom.
3. Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4. Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara membuat bingkai zoom pada slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Membuat latar belakang untuk slide kedua
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Membuat kotak teks untuk slide kedua
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Membuat latar belakang untuk slide ketiga
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Membuat kotak teks untuk slide ketiga
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Menambahkan objek ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Buat Bingkai Zoom dengan Gambar Kustom**
Dengan Aspose.Slides untuk Python via Java, Anda dapat membuat bingkai zoom dengan gambar pratinjau slide yang berbeda dengan cara berikut:
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru yang akan Anda tautkan dengan bingkai zoom.
3. Tambahkan teks identifikasi dan latar belakang ke slide.
4. Buat objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi gambar yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
5. Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara membuat bingkai zoom dengan gambar yang berbeda:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Membuat latar belakang untuk slide kedua
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Membuat kotak teks untuk slide kedua
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Membuat gambar baru untuk objek zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Menambahkan objek ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Format Bingkai Zoom**
Dalam bagian sebelumnya, kami menunjukkan cara membuat bingkai zoom sederhana. Untuk membuat bingkai zoom yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada bingkai zoom.

Anda dapat mengontrol format bingkai zoom pada slide dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru yang akan Anda tautkan dengan bingkai zoom.
3. Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4. Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5. Buat objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi gambar yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
6. Setel gambar kustom untuk objek bingkai zoom pertama.
7. Ubah format garis untuk objek bingkai zoom kedua.
8. Hapus latar belakang dari gambar objek bingkai zoom kedua.
9. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara mengubah format bingkai zoom pada slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Membuat latar belakang untuk slide kedua
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Membuat kotak teks untuk slide kedua
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Membuat latar belakang untuk slide ketiga
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Membuat kotak teks untuk slide ketiga
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Menambahkan objek ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Membuat gambar baru untuk objek zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Menetapkan gambar kustom untuk objek first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Menetapkan format bingkai zoom untuk objek second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Pengaturan untuk tidak menampilkan latar belakang pada objek second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Section Zoom**

Zoom bagian adalah tautan ke sebuah bagian dalam presentasi Anda. Anda dapat menggunakan zoom bagian untuk kembali ke bagian yang ingin Anda tekankan. Atau Anda dapat menggunakannya untuk menyoroti bagaimana potongan tertentu dalam presentasi Anda terhubung.

![overview_image](seczoomsel.png)

Untuk objek zoom bagian, Aspose.Slides menyediakan kelas [SectionZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectionzoomframe/) dan beberapa metode dalam kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/) .

### **Buat Bingkai Zoom Bagian**

Anda dapat menambahkan bingkai zoom bagian ke slide dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru.
3. Tambahkan latar belakang yang khas ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan bingkai zoom.
5. Tambahkan bingkai zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara membuat bingkai zoom pada slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan Section baru ke presentasi
    presentation.getSections().addSection("Section 1", slide)

    #  Menambahkan objek SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Buat Bingkai Zoom Bagian dengan Gambar Kustom**

Menggunakan Aspose.Slides untuk Python via Java, Anda dapat membuat bingkai zoom bagian dengan gambar pratinjau slide yang berbeda dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru.
3. Tambahkan latar belakang yang khas ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan bingkai zoom.
5. Buat objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi gambar yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
6. Tambahkan bingkai zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara membuat bingkai zoom dengan gambar yang berbeda:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan Section baru ke presentasi
    presentation.getSections().addSection("Section 1", slide)

    #  Membuat gambar baru untuk objek zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Menambahkan objek SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Format Bingkai Zoom Bagian**

Untuk membuat bingkai zoom bagian yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada bingkai zoom bagian.

Anda dapat mengontrol format bingkai zoom bagian pada slide dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru.
3. Tambahkan latar belakang yang khas ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan bingkai zoom.
5. Tambahkan bingkai zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Ubah ukuran dan posisi untuk objek zoom bagian yang dibuat.
7. Buat objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi gambar yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
8. Setel gambar kustom untuk objek bingkai zoom bagian yang dibuat.
9. Aktifkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*.
10. Hapus latar belakang dari gambar objek bingkai zoom bagian.
11. Ubah format garis untuk objek bingkai zoom bagian.
12. Ubah durasi transisi.
13. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara mengubah format bingkai zoom bagian:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan Section baru ke presentasi
    presentation.getSections().addSection("Section 1", slide)

    #  Menambahkan objek SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Pemformatan untuk SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Summary Zoom**

Summary zoom adalah seperti halaman landas di mana semua bagian presentasi Anda ditampilkan sekaligus. Saat Anda menyajikan, Anda dapat menggunakan zoom untuk berpindah dari satu tempat ke tempat lain dalam presentasi dengan urutan apa pun yang Anda suka. Anda dapat berkreasi, melompat ke depan, atau kembali ke bagian-bagian slide show tanpa mengganggu alur presentasi.

![overview_image](sumzoomsel.png)

Untuk objek summary zoom, Aspose.Slides menyediakan kelas [SummaryZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomsection/), dan [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomsectioncollection/) serta beberapa metode dalam kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/) .

### **Buat Summary Zoom**

Anda dapat menambahkan bingkai summary zoom ke slide dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru dengan latar belakang yang khas dan bagian baru untuk slide yang dibuat.
3. Tambahkan bingkai summary zoom ke slide pertama.
4. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara membuat bingkai summary zoom pada slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 1", slide)

    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 2", slide)

    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 3", slide)

    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 4", slide)

    #  Menambahkan objek SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tambahkan dan Hapus Bagian Summary Zoom**

Semua bagian dalam bingkai summary zoom direpresentasikan oleh objek [SummaryZoomSection](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomsection/) , yang disimpan dalam objek [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomsectioncollection/) . Anda dapat menambahkan atau menghapus objek bagian summary zoom melalui kelas [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomsectioncollection/) dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru dengan latar belakang yang khas dan bagian baru untuk slide yang dibuat.
3. Tambahkan bingkai summary zoom ke slide pertama.
4. Tambahkan slide dan bagian baru ke presentasi.
5. Tambahkan bagian yang dibuat ke bingkai summary zoom.
6. Hapus bagian pertama dari bingkai summary zoom.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menambahkan dan menghapus bagian dalam bingkai summary zoom:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 1", slide)

    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 2", slide)

    #  Menambahkan objek SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Menambahkan section ke Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Menghapus section dari Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Format Bagian Summary Zoom**

Untuk membuat objek bagian summary zoom yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada objek bagian summary zoom.

Anda dapat mengontrol format untuk objek bagian summary zoom dalam bingkai summary zoom dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Buat slide baru dengan latar belakang yang khas dan bagian baru untuk slide yang dibuat.
3. Tambahkan bingkai summary zoom ke slide pertama.
4. Dapatkan objek bagian summary zoom pertama dari [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomsectioncollection/) .
5. Buat objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi gambar yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
6. Setel gambar kustom untuk objek bagian summary zoom.
7. Aktifkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*.
8. Ubah format garis untuk objek bagian summary zoom.
9. Ubah durasi transisi.
10. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara mengubah format objek bagian summary zoom:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 1", slide)

    # Menambahkan slide baru ke presentasi
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Menambahkan section baru ke presentasi
    presentation.getSections().addSection("Section 2", slide)

    #  Menambahkan objek SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Mendapatkan objek SummaryZoomSection pertama
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Pemformatan untuk objek SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Menyimpan presentasi
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengontrol kembali ke slide 'induk' setelah menampilkan target?**

Ya. [ZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomframe/) atau [SectionZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectionzoomframe/) mendukung pengembalian ke slide asal melalui [setReturnToParent](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomobject/#setReturnToParent) , yang mengirim penonton kembali setelah mereka mengunjungi konten target ketika diaktifkan.

**Apakah saya dapat menyesuaikan 'kecepatan' atau durasi transisi Zoom?**

Ya. Zoom mendukung pengaturan durasi transisi dengan [setTransitionDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomobject/#setTransitionDuration) sehingga Anda dapat mengontrol berapa lama animasi lompatan berlangsung.

**Apakah ada batasan berapa banyak objek Zoom yang dapat dimiliki sebuah presentasi?**

Tidak ada batasan API keras yang didokumentasikan. Batas praktis tergantung pada kompleksitas presentasi secara keseluruhan dan kinerja penampil. Anda dapat menambahkan banyak bingkai Zoom, tetapi pertimbangkan ukuran file dan waktu render.