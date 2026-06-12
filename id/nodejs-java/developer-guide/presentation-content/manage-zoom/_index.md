---
title: Kelola Zoom Presentasi dalam JavaScript
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/nodejs-java/manage-zoom/
keywords:
- zoom
- frame zoom
- slide zoom
- section zoom
- summary zoom
- tambahkan zoom
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk Node.js — lompat antar bagian, tambahkan thumbnail dan transisi pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, serta bagian tertentu dari presentasi. Saat Anda memberi presentasi, kemampuan menavigasi dengan cepat di antara konten ini dapat sangat membantu.

![overview_image](overview.png)

* Untuk merangkum seluruh presentasi dalam satu slide, gunakan [Summary Zoom](#Summary-Zoom).
* Untuk menampilkan slide tertentu saja, gunakan [Slide Zoom](#Slide-Zoom).
* Untuk menampilkan satu bagian saja, gunakan [Section Zoom](#Section-Zoom).

## **Slide Zoom**

Slide zoom dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi bebas antara slide dalam urutan apa pun yang Anda pilih tanpa mengganggu alur presentasi. Slide zoom sangat cocok untuk presentasi singkat tanpa banyak bagian, tetapi Anda masih dapat menggunakannya dalam berbagai skenario presentasi.

Slide zoom membantu Anda menelusuri banyak informasi sekaligus seolah‑olah Anda berada di satu kanvas.

![overview_image](slidezoomsel.png)

Untuk objek slide zoom, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ZoomImageType), kelas [ZoomFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ZoomFrame), dan beberapa metode di bawah kelas [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).

### **Membuat Zoom Frame**

Anda dapat menambahkan zoom frame pada slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru yang akan Anda tautkan dengan zoom frame.
3. Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4. Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara membuat zoom frame pada slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Membuat latar belakang untuk slide kedua
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Membuat kotak teks untuk slide kedua
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Membuat latar belakang untuk slide ketiga
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Membuat kotak teks untuk slide ketiga
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Menambahkan objek ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Zoom Frame dengan Gambar Kustom**

Dengan Aspose.Slides untuk Node.js via Java, Anda dapat membuat zoom frame dengan gambar pratinjau slide yang berbeda sebagai berikut:
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru yang akan Anda tautkan dengan zoom frame.
3. Tambahkan teks identifikasi dan latar belakang ke slide.
4. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
5. Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara membuat zoom frame dengan gambar berbeda:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Membuat latar belakang untuk slide kedua
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Membuat kotak teks untuk slide ketiga
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Membuat gambar baru untuk objek zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menambahkan objek ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Memformat Zoom Frame**

Di bagian sebelumnya, kami menunjukkan cara membuat zoom frame sederhana. Untuk membuat zoom frame yang lebih kompleks, Anda harus mengubah format frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada zoom frame.

Anda dapat mengontrol pemformatan zoom frame pada slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru yang akan ditautkan dengan zoom frame.
3. Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4. Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
6. Tetapkan gambar kustom untuk objek zoom frame pertama.
7. Ubah format garis untuk objek zoom frame kedua.
8. Hapus latar belakang dari gambar pada objek zoom frame kedua.
5. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara mengubah format zoom frame pada slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Membuat latar belakang untuk slide kedua
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Membuat kotak teks untuk slide kedua
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Membuat latar belakang untuk slide ketiga
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Membuat kotak teks untuk slide ketiga
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Menambahkan objek ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Membuat gambar baru untuk objek zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menetapkan gambar kustom untuk objek zoomFrame1
    zoomFrame1.setImage(picture);
    // Menetapkan format zoom frame untuk objek zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Pengaturan untuk tidak menampilkan latar belakang pada objek zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Section Zoom**

Section zoom adalah tautan ke sebuah bagian dalam presentasi Anda. Anda dapat menggunakan section zoom untuk kembali ke bagian yang ingin Anda tekankan. Atau Anda dapat menggunakannya untuk menyoroti bagaimana bagian‑bagian tertentu dalam presentasi Anda terhubung.

![overview_image](seczoomsel.png)

Untuk objek section zoom, Aspose.Slides menyediakan kelas [SectionZoomFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SectionZoomFrame) dan beberapa metode di bawah kelas [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).

### **Membuat Section Zoom Frame**

Anda dapat menambahkan section zoom frame ke slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru.
3. Tambahkan latar belakang identifikasi ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan zoom frame.
5. Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara membuat zoom frame pada slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);
    // Menambahkan objek SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Section Zoom Frame dengan Gambar Kustom**

Dengan Aspose.Slides untuk Node.js via Java, Anda dapat membuat section zoom frame dengan gambar pratinjau slide yang berbeda sebagai berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru.
3. Tambahkan latar belakang identifikasi ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan zoom frame.
5. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
5. Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara membuat zoom frame dengan gambar berbeda:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);
    // Membuat gambar baru untuk objek zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menambahkan objek SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Memformat Section Zoom Frame**

Untuk membuat section zoom frame yang lebih rumit, Anda harus mengubah format frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada section zoom frame.

Anda dapat mengontrol pemformatan section zoom frame pada slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru.
3. Tambahkan latar belakang identifikasi ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan zoom frame.
5. Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Ubah ukuran dan posisi objek section zoom yang dibuat.
7. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
8. Tetapkan gambar kustom untuk objek section zoom frame yang dibuat.
9. Aktifkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*.
10. Hapus latar belakang dari gambar pada objek section zoom frame.
11. Ubah format garis untuk objek zoom frame kedua.
12. Ubah durasi transisi.
13. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara mengubah format section zoom frame:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);
    // Menambahkan objek SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Pemformatan untuk SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Summary Zoom**

Summary zoom seperti halaman arahan di mana semua bagian presentasi Anda ditampilkan sekaligus. Saat Anda memberi presentasi, Anda dapat menggunakan zoom untuk berpindah dari satu tempat ke tempat lain dalam urutan apa pun yang Anda inginkan. Anda dapat berkreasi, melompati bagian, atau mengunjungi kembali bagian‑bagian slide show tanpa mengganggu alur presentasi.

![overview_image](sumzoomsel.png)

Untuk objek summary zoom, Aspose.Slides menyediakan kelas [SummaryZoomFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SummaryZoomSection), dan [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SummaryZoomSectionCollection) serta beberapa metode di bawah kelas [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).

### **Membuat Summary Zoom**

Anda dapat menambahkan summary zoom frame ke slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3. Tambahkan summary zoom frame ke slide pertama.
4. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara membuat summary zoom frame pada slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);
    // Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);
    // Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 3", slide);
    // Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 4", slide);
    // Menambahkan objek SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Menambahkan dan Menghapus Summary Zoom Section**

Semua bagian dalam summary zoom frame direpresentasikan oleh objek [SummaryZoomSection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SummaryZoomSection), yang disimpan dalam objek [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Anda dapat menambahkan atau menghapus objek summary zoom section melalui kelas [SummaryZoomSectionCollection] dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3. Tambahkan summary zoom frame ke slide pertama.
4. Tambahkan slide dan bagian baru ke presentasi.
5. Tambahkan bagian yang dibuat ke summary zoom frame.
6. Hapus bagian pertama dari summary zoom frame.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara menambahkan dan menghapus bagian dalam summary zoom frame:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);
    // Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);
    // Menambahkan objek SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Menambahkan section ke Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Menghapus section dari Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Memformat Summary Zoom Section**

Untuk membuat objek summary zoom section yang lebih kompleks, Anda harus mengubah format frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada objek summary zoom section.

Anda dapat mengontrol pemformatan objek summary zoom section dalam summary zoom frame dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3. Tambahkan summary zoom frame ke slide pertama.
4. Dapatkan objek summary zoom section untuk objek pertama dari `ISummaryZoomSectionCollection`.
7. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke koleksi images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
8. Tetapkan gambar kustom untuk objek section zoom yang dibuat.
9. Aktifkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*.
11. Ubah format garis untuk objek zoom frame kedua.
12. Ubah durasi transisi.
13. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara mengubah pemformatan objek summary zoom section:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan slide baru ke presentasi
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);
    // Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);
    // Menambahkan objek SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Mengambil objek SummaryZoomSection pertama
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Pemformatan untuk objek SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Menyimpan presentasi
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat mengontrol pengembalian ke slide “induk” setelah menampilkan target?**

Ya. [Zoom frame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zoomframe/) atau [section](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectionzoomframe/) memiliki metode `setReturnToParent` yang, ketika diaktifkan, mengirim penonton kembali ke slide asal setelah mereka mengunjungi konten target.

**Apakah saya dapat mengatur “kecepatan” atau durasi transisi Zoom?**

Ya. Zoom menyediakan metode `setTransitionDuration` sehingga Anda dapat mengontrol berapa lama animasi lompatan berlangsung.

**Apakah ada batasan jumlah objek Zoom yang dapat dimuat dalam sebuah presentasi?**

Tidak ada batasan API keras yang didokumentasikan. Batas praktis bergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak Zoom frame, tetapi perhatikan ukuran file dan waktu render.