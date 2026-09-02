---
title: Kelola Panduan Gambar dalam Presentasi di JavaScript
linktitle: Panduan Gambar
type: docs
weight: 85
url: /id/nodejs-java/drawing-guides/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Menambahkan, mengakses, dan menghapus panduan gambar horizontal serta vertikal dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Node.js via Java."
---
## **Ikhtisar**

Panduan gambar adalah garis horizontal dan vertikal yang dapat disesuaikan yang membantu pengguna menyelaraskan bentuk secara konsisten saat mengedit presentasi di PowerPoint. Mereka sangat berguna ketika sebuah aplikasi menghasilkan presentasi yang kemudian akan disempurnakan secara manual: aplikasi dapat menyimpan bantuan penyelarasan yang sama yang harus diikuti penulis saat menambahkan atau memindahkan konten.

Panduan gambar adalah bantuan pengeditan, bukan konten slide. Mereka tidak muncul dalam tampilan slide atau output yang dirender. Aspose.Slides untuk Node.js melalui Java memperkenalkannya melalui kelas [DrawingGuidesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguidescollection/). Sebuah panduan direpresentasikan oleh [DrawingGuide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguide/) dan memiliki orientasi, posisi, serta warna.

Posisi diukur dalam poin dari sudut kiri atas slide atau master yang bersangkutan. Panduan vertikal menggunakan koordinat horizontal, biasanya antara nol dan lebar slide. Panduan horizontal menggunakan koordinat vertikal, biasanya antara nol dan tinggi slide.

## **Menambahkan Panduan ke Tampilan Slide**

Gunakan [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) untuk mengelola panduan yang ditampilkan saat mengedit slide normal. Panggil [DrawingGuidesCollection.add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguidescollection/#add) dengan nilai [Orientation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/orientation/) dan posisi dalam poin.

Contoh berikut menambahkan satu panduan vertikal di sebelah kanan tengah slide dan satu panduan horizontal di bawahnya:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengakses Panduan Gambar**

Metode [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguidescollection/#getCount) dan [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) menyediakan akses ke panduan yang ada. Metode [DrawingGuide.getOrientation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguide/#getPosition), dan [DrawingGuide.getColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguide/#getColor) mengembalikan nilai yang juga dapat diubah melalui metode setter yang sesuai.

Contoh berikut membaca panduan tampilan slide dari presentasi yang dibuat di atas:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Menambahkan Panduan ke Slide Master dan Layout**

Sebuah slide master dan setiap slide layoutnya dapat memiliki koleksi panduan gambar masing-masing. Gunakan [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) untuk slide master dan [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) untuk slide layout.

Contoh berikut menambahkan satu panduan vertikal ke slide master pertama dan satu panduan horizontal ke slide layout pertama:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menambahkan Panduan ke Master Catatan dan Handout**

Master catatan dan master handout juga mendukung panduan gambar. Gunakan [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) dan [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) untuk mengakses koleksi mereka. Jika sebuah presentasi tidak berisi salah satu master ini, `MasterNotesSlideManager.setDefaultMasterNotesSlide` atau `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` akan membuat master default dan mengembalikannya.

Contoh berikut menambahkan satu panduan horizontal ke master catatan dan satu panduan vertikal ke master handout:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menghapus Panduan Gambar**

Panggil [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguidescollection/#clear) untuk menghapus semua panduan dari koleksi tertentu. Menghapus satu koleksi tidak memengaruhi panduan yang disimpan di ruang lain.

Contoh berikut menghapus panduan tampilan slide dan semua panduan pada slide master, slide layout, master catatan, dan master handout tanpa membuat master yang hilang:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah panduan gambar muncul dalam tampilan slide atau gambar yang diekspor?**

Tidak. Panduan gambar adalah bantuan penyelarasan untuk pengeditan dan tidak dirender sebagai konten presentasi.

**Apakah panduan gambar dapat ditambahkan langsung ke slide normal individual?**

Panduan pengeditan slide normal disimpan dalam properti tampilan slide presentasi. Koleksi panduan terpisah tersedia untuk slide master, slide layout, master catatan, dan master handout.

**Unit apa yang digunakan untuk posisi panduan?**

Posisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Posisi vertikal diukur dari tepi kiri, dan posisi horizontal diukur dari tepi atas.

**Apakah menghapus panduan gambar menghapus bentuk atau mengubah konten slide?**

Tidak. Metode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/drawingguidescollection/#clear) hanya menghapus panduan dalam koleksi yang dipilih. Bentuk dan konten slide lainnya tetap tidak berubah.