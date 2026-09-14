---
title: Mengelola Garis Panduan dalam Presentasi di Python
linktitle: Garis Panduan
type: docs
weight: 85
url: /id/python-java/drawing-guides/
keywords:
- garis panduan
- garis panduan horizontal
- garis panduan vertikal
- garis panduan penyelarasan
- tampilan slide
- slide master
- slide layout
- master catatan
- master handout
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Tambah, akses, dan hapus garis panduan horizontal serta vertikal dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Garis panduan adalah garis horizontal dan vertikal yang dapat disesuaikan yang membantu pengguna menyelaraskan bentuk secara konsisten saat mengedit presentasi di PowerPoint. Garis ini sangat berguna ketika sebuah aplikasi menghasilkan presentasi yang kemudian akan disempurnakan secara manual: aplikasi dapat menyimpan bantuan penyelarasan yang sama sehingga penulis harus mengikutinya saat menambahkan atau memindahkan konten.

Garis panduan adalah bantuan pengeditan, bukan konten slide. Mereka tidak muncul dalam tampilan slide atau output yang dirender. Aspose.Slides for Python via Java mengeksposnya melalui kelas [DrawingGuidesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguidescollection/). Sebuah panduan direpresentasikan oleh [DrawingGuide](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguide/) dan memiliki orientasi, posisi, serta warna.

Posisi diukur dalam poin dari sudut kiri‑atas slide atau master yang relevan. Panduan vertikal menggunakan koordinat horizontal, biasanya antara nol dan lebar slide. Panduan horizontal menggunakan koordinat vertikal, biasanya antara nol dan tinggi slide.

## **Tambahkan Garis Panduan ke Tampilan Slide**

Gunakan [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/id/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) untuk mengelola panduan yang ditampilkan saat mengedit slide biasa. Panggil [DrawingGuidesCollection.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguidescollection/#add) dengan nilai [Orientation](https://reference.aspose.com/slides/id/python-java/aspose.slides/orientation/) dan posisi dalam poin.

Contoh berikut menambahkan satu panduan vertikal di sebelah kanan tengah slide dan satu panduan horizontal di bawahnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Akses Garis Panduan**

Metode [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguidescollection/#getCount) dan [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguidescollection/#get_Item) memberikan akses ke panduan yang ada. Metode [DrawingGuide.getOrientation](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguide/#getPosition), dan [DrawingGuide.getColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguide/#getColor) mengembalikan nilai yang juga dapat diubah melalui metode setter yang bersesuaian.

Contoh berikut membaca panduan tampilan slide dari presentasi yang dibuat di atas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Tambahkan Garis Panduan ke Slide Master dan Layout**

Sebuah slide master dan tiap slide layout‑nya dapat memiliki koleksi garis panduan masing‑masing. Gunakan [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/#getDrawingGuides) untuk slide master dan [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getDrawingGuides) untuk slide layout.

Contoh berikut menambahkan satu panduan vertikal ke slide master pertama dan satu panduan horizontal ke slide layout pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tambahkan Garis Panduan ke Master Catatan dan Handout**

Master catatan dan master handout juga mendukung garis panduan. Gunakan [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslide/#getDrawingGuides) dan [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) untuk mengakses koleksi mereka. Jika sebuah presentasi tidak berisi salah satu master ini, `MasterNotesSlideManager.setDefaultMasterNotesSlide` atau `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` membuat master default dan mengembalikannya.

Contoh berikut menambahkan satu panduan horizontal ke master catatan dan satu panduan vertikal ke master handout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hapus Garis Panduan**

Panggil [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguidescollection/#clear) untuk menghapus semua panduan dari koleksi tertentu. Menghapus satu koleksi tidak memengaruhi panduan yang disimpan dalam lingkup lain.

Contoh berikut menghapus panduan tampilan slide serta semua panduan pada slide master, slide layout, master catatan, dan master handout tanpa membuat master yang hilang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah garis panduan muncul dalam tampilan slide atau gambar yang diekspor?**

Tidak. Garis panduan merupakan bantuan penyelarasan untuk pengeditan dan tidak dirender sebagai konten presentasi.

**Apakah garis panduan dapat ditambahkan langsung ke slide normal individu?**

Panduan pengeditan slide normal disimpan dalam properti tampilan slide presentasi. Koleksi panduan terpisah tersedia untuk slide master, slide layout, master catatan, dan master handout.

**Unit apa yang digunakan untuk posisi garis panduan?**

Posisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Posisi vertikal diukur dari tepi kiri, dan posisi horizontal diukur dari tepi atas.

**Apakah menghapus garis panduan menghilangkan bentuk atau mengubah konten slide?**

Tidak. Metode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/drawingguidescollection/#clear) menghapus hanya panduan dalam koleksi yang dipilih. Bentuk dan konten slide lainnya tetap tidak berubah.