---
title: Kelola Zoom Presentasi di Python via Java
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/python-java/manage-zoom/
keywords:
- zoom
- bingkai zoom
- zoom slide
- zoom bagian
- zoom rangkuman
- tambahkan zoom
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk Python via Java — lompat antar bagian, tambahkan thumbnail dan transisi dalam presentasi PowerPoint."
---
## **Pendahuluan**

Zoom PowerPoint memungkinkan Anda menavigasi antara slide dan bagian tertentu selama pertunjukan slide. Dengan Aspose.Slides untuk Python via Java, Anda dapat membuat zoom slide, zoom bagian, dan zoom rangkuman serta menyesuaikan pratinjau, batas, dan transisinya.

![Ikhtisar zoom PowerPoint](overview.png)

* Untuk merangkum seluruh presentasi pada satu slide, gunakan [Zoom Rangkuman](#summary-zoom).
* Untuk menampilkan hanya slide tertentu, gunakan [Zoom Slide](#slide-zoom).
* Untuk menampilkan hanya satu bagian, gunakan [Zoom Bagian](#section-zoom).

## **Zoom Slide**

Zoom slide dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi bebas antara slide dalam urutan apa pun yang Anda pilih tanpa mengganggu alur presentasi. Zoom slide sangat cocok untuk presentasi singkat tanpa banyak bagian, tetapi Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Zoom slide memungkinkan Anda menjelajahi informasi terkait dari satu slide ikhtisar.

![Memilih slide untuk zoom slide](slidezoomsel.png)

Untuk objek zoom slide, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/), kelas [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/), dan metode pada kelas [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Buat Bingkai Zoom**

Gunakan [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) untuk menempatkan tautan ke slide individu pada slide ikhtisar. Contoh ini membuat dua slide target dengan latar belakang dan label yang berbeda, lalu menambahkan pratinjau masing‑masing ke slide pertama dan menyimpan presentasi sebagai PPTX. Posisi dan dimensi bingkai ditentukan dalam poin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Bingkai Zoom dengan Gambar Kustom**

Berikan gambar kustom ke [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) untuk mengganti pratinjau default slide target. Contoh ini memerlukan gambar lokal, memuatnya dengan [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), dan menambahkannya ke presentasi menggunakan [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Bingkai yang dihasilkan menampilkan gambar tersebut sekaligus tetap menautkan ke slide kedua.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Format Bingkai Zoom**

Contoh ini menyesuaikan dua bingkai zoom slide. Ia menetapkan gambar lokal ke bingkai pertama melalui [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), dan memberikan bingkai kedua batas merah muda dash‑dot setebal lima poin melalui [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat). Menetapkan `False` pada [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) menyembunyikan latar belakang bingkai kedua. Gambar lokal diperlukan untuk pratinjau kustom; kedua bingkai tetap mempertahankan target slide mereka dalam PPTX yang disimpan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom Bagian**

Zoom bagian menautkan ke sebuah bagian dalam presentasi Anda. Gunakan untuk mengunjungi kembali topik atau menunjukkan bagaimana bagian‑bagian berbeda dari presentasi saling terhubung.

![Memilih bagian untuk zoom bagian](seczoomsel.png)

Untuk objek zoom bagian, Aspose.Slides menyediakan kelas [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) dan metode pada kelas [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Buat Bingkai Zoom Bagian**

Buat bagian dengan [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection), lalu berikan bagian yang dikembalikan ke [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame). Contoh ini menempatkan zoom bagian pada slide pertama dan menautkannya ke bagian yang dimulai dengan slide berwarna. Posisi dan dimensi bingkai ditentukan dalam poin, dan presentasi disimpan sebagai PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Buat Bingkai Zoom Bagian dengan Gambar Kustom**

Overload gambar dari [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) memungkinkan Anda menampilkan pratinjau kustom tanpa mengubah bagian tujuan. Contoh ini memerlukan gambar lokal, yang dimuat dengan [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) dan ditambahkan melalui [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Presentasi yang disimpan berisi zoom bagian pada slide pertama yang ditautkan ke bagian yang baru dibuat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ubah Bagian Target Zoom Bagian**

Gunakan [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) untuk mengarahkan ulang zoom bagian yang sudah ada tanpa membuatnya kembali. Pilih sebuah bagian yang sudah terisi dari koleksi [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) presentasi yang sama. Menetapkan bagian kosong tidak mengubah target saat ini, jadi periksa [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) sebelum menentukannya. Lihat [Kelola Bagian Slide](/slides/id/python-java/slide-section/) untuk informasi lebih lanjut tentang bagian.

Contoh berikut memuat file presentasi, yang harus berisi beberapa bagian terisi, sebuah zoom bagian yang ada bernama `Section navigation`, dan sebuah bagian dengan nama unik `Results`. Ia mencari semua slide untuk zoom tersebut dan menemukan tujuan berdasarkan nama bukan indeks koleksi yang dapat berubah ketika bagian diurutkan ulang. Jika nama tidak unik, gunakan [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) untuk mengidentifikasi tujuan sebagai gantinya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Format Bingkai Zoom Bagian**

Contoh ini memindahkan dan mengubah ukuran zoom bagian menjadi 100 x 75 poin, menetapkan gambar lokal melalui [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), dan menerapkan batas coklat dash‑dot setebal 2,5 poin. Ia mengaktifkan [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) untuk kembali ke slide asal setelah bagian, menonaktifkan [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground), dan menetapkan [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) ke 1,5 detik. Gambar lokal diperlukan untuk pratinjau kustom.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom Rangkuman**

Zoom rangkuman menyediakan ikhtisar bagian‑bagian presentasi. Selama pertunjukan slide, Anda dapat menggunakannya untuk melompat ke sebuah bagian, melewatkan ke depan, atau mengunjungi kembali topik tanpa mengikuti urutan slide.

![Memilih bagian untuk zoom rangkuman](sumzoomsel.png)

Untuk objek zoom rangkuman, Aspose.Slides menyediakan kelas [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/), dan [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) serta metode pada kelas [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/).

### **Buat Zoom Rangkuman**

Gunakan [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) untuk membuat ikhtisar bagian‑bagian presentasi. Contoh ini membuat empat bagian dengan latar belakang slide yang berbeda dan menambahkan zoom rangkuman ke slide pertama. Posisi dan dimensi bingkai ditentukan dalam poin, dan ikhtisar yang dihasilkan disimpan dalam presentasi PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tambah dan Hapus Seksi Zoom Rangkuman**

Zoom rangkuman menyimpan objek [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) dalam [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Contoh ini membuat ikhtisar dua bagian, menambahkan bagian ketiga menggunakan [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection), dan menghapus entri bagian pertama menggunakan [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Menghapus entri meninggalkan bagian presentasi dan slide‑nya tetap utuh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Format Seksi Zoom Rangkuman**

Contoh ini memformat entri pertama dalam [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), menggunakan indeks berbasis nol `0`. Ia memerlukan gambar lokal untuk [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), menerapkan batas hitam dash‑dot setebal 1,5 poin, dan menetapkan [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) ke 1,5 detik. Menetapkan `False` pada [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) menonaktifkan pengembalian otomatis ke slide rangkuman untuk entri ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tanya Jawab**

**Apakah saya dapat mengontrol pengembalian ke slide 'induk' setelah menampilkan target?**

Ya. Panggil [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) dengan `True` untuk kembali ke slide asal setelah konten target ditampilkan.

**Apakah saya dapat menyesuaikan 'kecepatan' atau durasi transisi Zoom?**

Ya. Gunakan [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) untuk mengontrol durasi transisi dalam detik.

**Apakah ada batas berapa banyak objek Zoom yang dapat dimiliki presentasi?**

Tidak ada batas API keras yang didokumentasikan. Batas praktis bergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak bingkai Zoom, tetapi pertimbangkan ukuran file dan waktu rendering.