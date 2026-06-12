---
title: Kelola Zoom Presentasi di Java
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/java/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom slide
- zoom bagian
- zoom rangkuman
- tambahkan zoom
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk Java — melompat antar bagian, menambahkan thumbnail dan transisi di seluruh presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, serta bagian tertentu dari presentasi. Saat Anda menyajikan, kemampuan untuk menavigasi dengan cepat melalui konten ini bisa sangat berguna. 

![overview_image](overview.png)

* Untuk merangkum seluruh presentasi dalam satu slide, gunakan [Summary Zoom](#Summary-Zoom).
* Untuk menampilkan slide tertentu saja, gunakan [Slide Zoom](#Slide-Zoom).
* Untuk menampilkan satu bagian saja, gunakan [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Zoom slide dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi bebas antara slide dalam urutan apa pun yang Anda pilih tanpa mengganggu alur presentasi. Zoom slide cocok untuk presentasi singkat tanpa banyak bagian, tetapi Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Zoom slide membantu Anda menelaah banyak potongan informasi sambil merasa berada pada satu kanvas tunggal. 

![overview_image](slidezoomsel.png)

Untuk objek zoom slide, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ZoomImageType), antarmuka [IZoomFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/IZoomFrame), serta beberapa metode pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).

### **Membuat Zoom Frame**

Anda dapat menambahkan zoom frame pada slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru yang akan Anda tautkan dengan zoom frame. 
3. Tambahkan teks identifikasi dan latar belakang pada slide yang dibuat.
4. Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat zoom frame pada slide:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Membuat latar belakang untuk slide kedua
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Membuat kotak teks untuk slide kedua
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Membuat latar belakang untuk slide ketiga
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Membuat kotak teks untuk slide ketiga
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Menambahkan objek ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Membuat Zoom Frame dengan Gambar Khusus**
Dengan Aspose.Slides untuk Java, Anda dapat membuat zoom frame dengan gambar preview slide yang berbeda sebagai berikut: 
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru yang akan Anda tautkan dengan zoom frame. 
3. Tambahkan teks identifikasi dan latar belakang pada slide.
4. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
5. Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat zoom frame dengan gambar yang berbeda:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //Membuat latar belakang untuk slide kedua
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //Membuat kotak teks untuk slide ketiga
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //Membuat gambar baru untuk objek zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Menambahkan objek ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    //Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Memformat Zoom Frame**
Pada bagian sebelumnya, kami menunjukkan cara membuat zoom frame sederhana. Untuk membuat zoom frame yang lebih rumit, Anda harus mengubah pemformatan frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada zoom frame. 

Anda dapat mengontrol pemformatan zoom frame pada slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru yang akan Anda tautkan dengan zoom frame. 
3. Tambahkan beberapa teks identifikasi dan latar belakang pada slide yang dibuat.
4. Tambahkan zoom frame (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
6. Atur gambar khusus untuk objek zoom frame pertama.
7. Ubah format garis untuk objek zoom frame kedua.
8. Hapus latar belakang dari gambar pada objek zoom frame kedua.
5. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengubah pemformatan zoom frame pada slide: 

``` java 
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Membuat latar belakang untuk slide kedua
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Membuat kotak teks untuk slide kedua
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Membuat latar belakang untuk slide ketiga
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Membuat kotak teks untuk slide ketiga
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Menambahkan objek ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Membuat gambar baru untuk objek zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Mengatur gambar khusus untuk objek zoomFrame1
    zoomFrame1.setImage(picture);

    // Mengatur format zoom frame untuk objek zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Pengaturan untuk tidak menampilkan latar belakang pada objek zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Section Zoom**

Section zoom adalah tautan ke sebuah bagian dalam presentasi Anda. Anda dapat menggunakan section zoom untuk kembali ke bagian yang ingin Anda tekankan. Atau Anda dapat menggunakannya untuk menyoroti cara bagian-bagian tertentu dalam presentasi Anda saling terhubung. 

![overview_image](seczoomsel.png)

Untuk objek section zoom, Aspose.Slides menyediakan antarmuka [ISectionZoomFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISectionZoomFrame) serta beberapa metode pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).

### **Membuat Section Zoom Frame**

Anda dapat menambahkan section zoom frame ke slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru. 
3. Tambahkan latar belakang identifikasi ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan zoom frame. 
5. Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat zoom frame pada slide:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    // Menambahkan objek SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Membuat Section Zoom Frame dengan Gambar Khusus**

Dengan Aspose.Slides untuk Java, Anda dapat membuat section zoom frame dengan gambar preview slide yang berbeda sebagai berikut: 

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru.
3. Tambahkan latar belakang identifikasi ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan zoom frame. 
5. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
5. Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat zoom frame dengan gambar yang berbeda:

``` java 
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    // Membuat gambar baru untuk objek zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Menambahkan objek SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Memformat Section Zoom Frame**

Untuk membuat section zoom frame yang lebih rumit, Anda harus mengubah pemformatan frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada section zoom frame. 

Anda dapat mengontrol pemformatan section zoom frame pada slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru.
3. Tambahkan latar belakang identifikasi ke slide yang dibuat.
4. Buat bagian baru yang akan Anda tautkan dengan zoom frame. 
5. Tambahkan section zoom frame (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6. Ubah ukuran dan posisi objek section zoom yang dibuat.
7. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
8. Atur gambar khusus untuk objek section zoom frame yang dibuat.
9. Atur kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
10. Hapus latar belakang dari gambar pada objek section zoom frame.
11. Ubah format garis untuk objek zoom frame kedua.
12. Ubah durasi transisi.
13. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengubah pemformatan section zoom frame:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    // Menambahkan objek SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Pemformatan untuk SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Summary Zoom**

Summary zoom berfungsi seperti halaman landing di mana semua bagian presentasi Anda ditampilkan sekaligus. Saat Anda menyajikan, Anda dapat menggunakan zoom untuk berpindah dari satu tempat ke tempat lain dalam presentasi dalam urutan apa pun yang Anda inginkan. Anda dapat berkreasi, melompat ke depan, atau kembali ke bagian-bagian slide show tanpa mengganggu alur presentasi.

![overview_image](sumzoomsel.png)

Untuk objek summary zoom, Aspose.Slides menyediakan antarmuka [ISummaryZoomFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISummaryZoomSection), dan [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISummaryZoomSectionCollection) serta beberapa metode pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).

### **Membuat Summary Zoom**

Anda dapat menambahkan summary zoom frame ke slide dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3. Tambahkan summary zoom frame ke slide pertama.
4. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat summary zoom frame pada slide:

``` java 
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 3", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 4", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Menambahkan dan Menghapus Summary Zoom Section**

Semua bagian dalam summary zoom frame direpresentasikan oleh objek [ISummaryZoomSection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISummaryZoomSection), yang disimpan dalam objek [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISummaryZoomSectionCollection). Anda dapat menambahkan atau menghapus objek summary zoom section melalui antarmuka [ISummaryZoomSectionCollection] dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3. Tambahkan summary zoom frame ke slide pertama.
4. Tambahkan slide dan bagian baru ke presentasi.
5. Tambahkan bagian yang dibuat ke summary zoom frame.
6. Hapus bagian pertama dari summary zoom frame.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara menambahkan dan menghapus bagian dalam summary zoom frame:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Menambahkan section ke Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Menghapus section dari Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Memformat Summary Zoom Section**

Untuk membuat objek summary zoom section yang lebih rumit, Anda harus mengubah pemformatan frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada objek summary zoom section. 

Anda dapat mengontrol pemformatan objek summary zoom section dalam summary zoom frame dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3. Tambahkan summary zoom frame ke slide pertama.
4. Dapatkan objek summary zoom section untuk objek pertama dari `ISummaryZoomSectionCollection`.
7. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
8. Atur gambar khusus untuk objek summary zoom section yang dibuat.
9. Atur kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
11. Ubah format garis untuk objek zoom frame kedua.
12. Ubah durasi transisi.
13. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengubah pemformatan objek summary zoom section:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan Section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Mendapatkan objek SummaryZoomSection pertama
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Pemformatan untuk objek SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengontrol kembali ke slide ‘induk’ setelah menampilkan target?**

Ya. [Zoom frame](https://reference.aspose.com/slides/id/java/com.aspose.slides/zoomframe/) atau [section](https://reference.aspose.com/slides/id/java/com.aspose.slides/sectionzoomframe/) memiliki perilaku `ReturnToParent` yang, bila diaktifkan, mengirim penonton kembali ke slide asal setelah mereka mengunjungi konten target.

**Apakah saya dapat menyesuaikan ‘kecepatan’ atau durasi transisi Zoom?**

Ya. Zoom mendukung pengaturan `TransitionDuration` sehingga Anda dapat mengontrol berapa lama animasi loncatan berlangsung.

**Apakah ada batasan jumlah objek Zoom yang dapat dimiliki sebuah presentasi?**

Tidak ada batasan API keras yang didokumentasikan. Batas praktis bergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak Zoom frame, namun pertimbangkan ukuran file dan waktu render.