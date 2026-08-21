---
title: Kelola Panduan Gambar dalam Presentasi di Java
linktitle: Panduan Gambar
type: docs
weight: 85
url: /id/java/drawing-guides/
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
- Java
- Aspose.Slides
description: "Menambahkan, mengakses, dan menghapus panduan gambar horizontal dan vertikal dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Panduan gambar adalah garis horizontal dan vertikal yang dapat disesuaikan yang membantu pengguna menyelaraskan bentuk secara konsisten saat mengedit presentasi di PowerPoint. Mereka sangat berguna ketika sebuah aplikasi menghasilkan presentasi yang kemudian akan disempurnakan secara manual: aplikasi dapat menyimpan bantuan penyelarasan yang sama yang harus diikuti penulis saat menambahkan atau memindahkan konten.

Panduan gambar adalah bantuan penyuntingan, bukan konten slide. Mereka tidak muncul dalam tayangan slide atau output yang dirender. Aspose.Slides for Java mengeksposnya melalui antarmuka [IDrawingGuidesCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguidescollection/) . Sebuah panduan direpresentasikan oleh [IDrawingGuide](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguide/) dan memiliki orientasi, posisi, serta warna.

Posisi diukur dalam poin dari sudut kiri atas slide atau master yang relevan. Panduan vertikal menggunakan koordinat horizontal, biasanya antara nol dan lebar slide. Panduan horizontal menggunakan koordinat vertikal, biasanya antara nol dan tinggi slide.

## **Tambahkan Panduan ke Tampilan Slide**

Gunakan [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/id/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) untuk mengelola panduan yang ditampilkan saat mengedit slide normal. Panggil [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) dengan nilai [Orientation](https://reference.aspose.com/slides/id/java/com.aspose.slides/orientation/) dan posisi dalam poin.

Contoh berikut menambahkan satu panduan vertikal di sebelah kanan tengah slide dan satu panduan horizontal di bawahnya:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Akses Panduan Gambar**

Metode [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguidescollection/#getCount--) dan [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) menyediakan akses ke panduan yang ada. Metode [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguide/#getPosition--), dan [IDrawingGuide.getColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguide/#getColor--) mengembalikan nilai yang juga dapat diubah melalui metode setter yang bersesuaian.

Contoh berikut membaca panduan tampilan slide dari presentasi yang dibuat di atas:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Tambahkan Panduan ke Slide Master dan Layout**

Sebuah slide master dan setiap slide layoutnya dapat memiliki koleksi panduan gambar masing-masing. Gunakan [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/#getDrawingGuides--) untuk slide master dan [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) untuk slide layout.

Contoh berikut menambahkan panduan vertikal ke slide master pertama dan panduan horizontal ke slide layout pertama:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Panduan ke Master Catatan dan Handout**

Master catatan dan master handout juga mendukung panduan gambar. Gunakan [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) dan [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) untuk mengakses koleksinya. Jika sebuah presentasi tidak berisi salah satu master tersebut, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) atau [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) akan membuat master default dan mengembalikannya.

Contoh berikut menambahkan panduan horizontal ke master catatan dan panduan vertikal ke master handout:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hapus Panduan Gambar**

Panggil [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguidescollection/#clear--) untuk menghapus semua panduan dari koleksi tertentu. Menghapus satu koleksi tidak memengaruhi panduan yang disimpan dalam ruang lingkup lain.

Contoh berikut menghapus panduan tampilan slide serta semua panduan pada slide master, slide layout, master catatan, dan master handout tanpa membuat master yang hilang:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah panduan gambar muncul dalam tayangan slide atau gambar yang diekspor?**

Tidak. Panduan gambar adalah bantuan penyelarasan untuk penyuntingan dan tidak dirender sebagai konten presentasi.

**Apakah panduan gambar dapat ditambahkan langsung ke slide normal individu?**

Panduan penyuntingan slide normal disimpan dalam properti tampilan slide presentasi. Koleksi panduan terpisah tersedia untuk slide master, slide layout, master catatan, dan master handout.

**Unit apa yang digunakan untuk posisi panduan?**

Posisi ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Posisi vertikal diukur dari tepi kiri, dan posisi horizontal diukur dari tepi atas.

**Apakah menghapus panduan gambar menghilangkan bentuk atau mengubah konten slide?**

Tidak. Metode [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/idrawingguidescollection/#clear--) menghapus hanya panduan dalam koleksi yang dipilih. Bentuk dan konten slide lainnya tetap tidak berubah.