---
title: Kelola Panduan Gambar dalam Presentasi di Python
linktitle: Panduan Gambar
type: docs
weight: 85
url: /id/python-net/drawing-guides/
keywords:
- panduan gambar
- panduan horizontal
- panduan vertikal
- panduan penyelarasan
- tampilan slide
- slide master
- slide tata letak
- master catatan
- master handout
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Menambahkan, mengakses, dan membersihkan panduan gambar horizontal dan vertikal dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Panduan gambar adalah garis horizontal dan vertikal yang dapat disesuaikan yang membantu pengguna menyelaraskan bentuk secara konsisten saat mengedit presentasi di PowerPoint. Panduan ini sangat berguna ketika sebuah aplikasi menghasilkan presentasi yang kemudian akan disempurnakan secara manual: aplikasi dapat menyimpan bantuan penyelarasan yang sama yang harus diikuti penulis saat menambahkan atau memindahkan konten.

Panduan gambar bukan konten slide. Mereka tidak muncul dalam slideshow atau output yang dirender. Aspose.Slides for Python via .NET memperlihatkannya melalui antarmuka [IDrawingGuidesCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguidescollection/). Sebuah panduan diwakili oleh [IDrawingGuide](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguide/) dan memiliki orientasi, posisi, serta warna.

Posisi diukur dalam point dari sudut kiri atas slide atau master yang relevan. Panduan vertikal menggunakan koordinat horizontal, biasanya antara nol dan lebar slide. Panduan horizontal menggunakan koordinat vertikal, biasanya antara nol dan tinggi slide.

## **Tambahkan Panduan ke Tampilan Slide**

Gunakan [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/id/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) untuk mengelola panduan yang ditampilkan saat mengedit slide normal. Panggil [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguidescollection/add/) dengan nilai [Orientation](https://reference.aspose.com/slides/id/python-net/aspose.slides/orientation/) dan posisi dalam point.

Contoh berikut menambahkan satu panduan vertikal di kanan pusat slide dan satu panduan horizontal di bawahnya:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Panduan Gambar**

Properti dan pengindeks [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguidescollection/count/) menyediakan akses ke panduan yang ada. Properti [IDrawingGuide.orientation](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguide/position/), dan [IDrawingGuide.color](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguide/color/) dapat dibaca atau diubah.

Contoh berikut membaca panduan tampilan slide dari presentasi yang dibuat di atas:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Tambahkan Panduan ke Slide Master dan Layout**

Slide master dan setiap slide layout‑nya dapat memiliki koleksi panduan gambar masing‑masing. Gunakan [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterslide/drawing_guides/) untuk slide master dan [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/id/python-net/aspose.slides/ilayoutslide/drawing_guides/) untuk slide layout.

Contoh berikut menambahkan satu panduan vertikal ke slide master pertama dan satu panduan horizontal ke slide layout pertama:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Panduan ke Master Catatan dan Handout**

Master catatan dan handout juga mendukung panduan gambar. Gunakan [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasternotesslide/drawing_guides/) dan [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) untuk mengakses koleksi mereka. Jika sebuah presentasi tidak berisi salah satu master tersebut, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) atau [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) akan membuat master default dan mengembalikannya.

Contoh berikut menambahkan satu panduan horizontal ke master catatan dan satu panduan vertikal ke master handout:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Bersihkan Panduan Gambar**

Panggil [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides/idrawingguidescollection/clear/) untuk menghapus setiap panduan dari koleksi tertentu. Membersihkan satu koleksi tidak memengaruhi panduan yang disimpan dalam ruang lingkup lain.

Contoh berikut membersihkan panduan tampilan slide dan semua panduan pada master slide, slide layout, master catatan, dan master handout tanpa membuat master yang hilang:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah panduan gambar muncul dalam slideshow atau gambar yang diekspor?**

Tidak. Panduan gambar adalah bantuan penyelarasan untuk mengedit dan tidak dirender sebagai konten presentasi.

**Apakah panduan gambar dapat ditambahkan langsung ke slide normal individu?**

Panduan pengeditan slide normal disimpan dalam properti tampilan slide presentasi. Koleksi panduan terpisah tersedia untuk master slide, slide layout, master catatan, dan master handout.

**Unit apa yang digunakan untuk posisi panduan?**

Posisi ditentukan dalam point, dimana 72 point sama dengan satu inci. Posisi vertikal diukur dari tepi kiri, dan posisi horizontal diukur dari tepi atas.

**Apakah membersihkan panduan gambar menghapus bentuk atau mengubah konten slide?**

Tidak. Metode `clear` hanya menghapus panduan dalam koleksi yang dipilih. Bentuk dan konten slide lainnya tetap tidak berubah.