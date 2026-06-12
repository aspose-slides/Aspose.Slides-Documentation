---
title: Kelola Zoom Presentasi pada Android
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/androidjava/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom slide
- zoom bagian
- zoom ringkasan
- tambahkan zoom
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk Android via Java — melompat antar bagian, menambahkan thumbnail dan transisi pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, dan potongan tertentu dari presentasi. Saat Anda menyajikan, kemampuan untuk menavigasi dengan cepat di seluruh konten ini dapat sangat berguna. 

![overview_image](overview.png)

* Untuk merangkum seluruh presentasi pada satu slide, gunakan [Summary Zoom](#Summary-Zoom).
* Untuk menampilkan hanya slide yang dipilih, gunakan [Slide Zoom](#Slide-Zoom).
* Untuk menampilkan hanya satu bagian, gunakan [Section Zoom](#Section-Zoom).

## **Zoom Slide**
Zoom slide dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi secara bebas antara slide dalam urutan apa pun yang Anda pilih tanpa mengganggu alur presentasi. Zoom slide sangat cocok untuk presentasi singkat tanpa banyak bagian, namun Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Zoom slide membantu Anda memperdalam banyak informasi sambil terasa seperti berada di satu kanvas. 

![overview_image](slidezoomsel.png)

Untuk objek zoom slide, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ZoomImageType), antarmuka [IZoomFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IZoomFrame), dan beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).

### **Membuat Frame Zoom**

Anda dapat menambahkan frame zoom pada slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru yang akan Anda hubungkan dengan frame zoom. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan frame zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat frame zoom pada slide:

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
### **Membuat Frame Zoom dengan Gambar Kustom**
Dengan Aspose.Slides untuk Android via Java, Anda dapat membuat frame zoom dengan gambar pratinjau slide yang berbeda sebagai berikut:
1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru yang akan Anda hubungkan dengan frame zoom. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide.
4.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
5.	Tambahkan frame zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat frame zoom dengan gambar yang berbeda:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Membuat latar belakang untuk slide kedua
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Membuat kotak teks untuk slide ketiga
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Membuat gambar baru untuk objek zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Menambahkan objek ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Memformat Frame Zoom**
Pada bagian sebelumnya, kami menunjukkan cara membuat frame zoom sederhana. Untuk membuat frame zoom yang lebih rumit, Anda harus mengubah format frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada frame zoom. 

Anda dapat mengontrol pemformatan frame zoom pada slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru yang akan Anda hubungkan dengan frame zoom. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan frame zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
6.	Tetapkan gambar kustom untuk objek frame zoom pertama.
7.	Ubah format garis untuk objek frame zoom kedua.
8.	Hapus latar belakang dari gambar objek frame zoom kedua.
5.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengubah pemformatan frame zoom pada slide: 

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
    // Menetapkan gambar kustom untuk objek zoomFrame1
    zoomFrame1.setImage(picture);

    // Menetapkan format frame zoom untuk objek zoomFrame2
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

## **Zoom Bagian**

Zoom bagian adalah tautan ke sebuah bagian dalam presentasi Anda. Anda dapat menggunakan zoom bagian untuk kembali ke bagian yang ingin Anda tekankan. Atau Anda dapat menggunakannya untuk menyoroti bagaimana bagian‑bagian tertentu dalam presentasi Anda saling terhubung. 

![overview_image](seczoomsel.png)

Untuk objek zoom bagian, Aspose.Slides menyediakan antarmuka [ISectionZoomFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISectionZoomFrame) dan beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).

### **Membuat Frame Zoom Bagian**

Anda dapat menambahkan frame zoom bagian ke slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru. 
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda hubungkan dengan frame zoom. 
5.	Tambahkan frame zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat frame zoom pada slide:

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
### **Membuat Frame Zoom Bagian dengan Gambar Kustom**

Menggunakan Aspose.Slides untuk Android via Java, Anda dapat membuat frame zoom bagian dengan gambar pratinjau slide yang berbeda sebagai berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda hubungkan dengan frame zoom. 
5.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
5.	Tambahkan frame zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat frame zoom dengan gambar yang berbeda:

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
### **Memformat Frame Zoom Bagian**

Untuk membuat frame zoom bagian yang lebih rumit, Anda harus mengubah format frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada frame zoom bagian. 

Anda dapat mengontrol pemformatan frame zoom bagian pada slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda hubungkan dengan frame zoom. 
5.	Tambahkan frame zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Ubah ukuran dan posisi untuk objek zoom bagian yang dibuat.
7.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
8.	Tetapkan gambar kustom untuk objek frame zoom bagian yang dibuat.
9.	Tetapkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
10.	Hapus latar belakang dari gambar objek frame zoom bagian.
11.	Ubah format garis untuk objek frame zoom kedua.
12.	Ubah durasi transisi.
13.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengubah pemformatan frame zoom bagian:

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


## **Zoom Ringkasan**

Zoom ringkasan seperti halaman landing di mana semua komponen presentasi Anda ditampilkan sekaligus. Saat Anda menyajikan, Anda dapat menggunakan zoom untuk berpindah dari satu tempat ke tempat lain dalam presentasi dalam urutan apa pun yang Anda inginkan. Anda dapat berkreasi, melompat maju, atau kembali ke bagian‑bagian slide show tanpa mengganggu alur presentasi.

![overview_image](sumzoomsel.png)

Untuk objek zoom ringkasan, Aspose.Slides menyediakan antarmuka [ISummaryZoomFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISummaryZoomSection), dan [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) serta beberapa metode di bawah antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).

### **Membuat Zoom Ringkasan**

Anda dapat menambahkan frame zoom ringkasan ke slide dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan frame zoom ringkasan ke slide pertama.
4.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat frame zoom ringkasan pada slide:

``` java 
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 3", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 4", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Menambah dan Menghapus Seksi Zoom Ringkasan**

Semua seksi dalam frame zoom ringkasan direpresentasikan oleh objek [ISummaryZoomSection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISummaryZoomSection), yang disimpan dalam objek [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Anda dapat menambah atau menghapus objek seksi zoom ringkasan melalui antarmuka [ISummaryZoomSectionCollection] dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan frame zoom ringkasan ke slide pertama.
4.	Tambahkan slide dan seksi baru ke presentasi.
5.	Tambahkan seksi yang dibuat ke frame zoom ringkasan.
6.	Hapus seksi pertama dari frame zoom ringkasan.
7.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara menambah dan menghapus seksi dalam frame zoom ringkasan:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);

    // Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Menambahkan section baru ke presentasi
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

### **Memformat Seksi Zoom Ringkasan**

Untuk membuat objek seksi zoom ringkasan yang lebih rumit, Anda harus mengubah format frame sederhana. Ada beberapa opsi pemformatan yang dapat Anda terapkan pada objek seksi zoom ringkasan. 

Anda dapat mengontrol pemformatan objek seksi zoom ringkasan dalam frame zoom ringkasan dengan cara berikut:

1.	Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan frame zoom ringkasan ke slide pertama.
4.	Dapatkan objek seksi zoom ringkasan untuk objek pertama dari `ISummaryZoomSectionCollection`.
7.	Buat objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPPImage) dengan menambahkan gambar ke koleksi images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) yang akan digunakan untuk mengisi frame.
8.	Tetapkan gambar kustom untuk objek frame zoom seksi yang dibuat.
9.	Tetapkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
11.	Ubah format garis untuk objek frame zoom kedua.
12.	Ubah durasi transisi.
13.	Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengubah pemformatan objek seksi zoom ringkasan:

``` java
Presentation pres = new Presentation();
try {
    //Menambahkan slide baru ke presentasi
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 1", slide);

    //Menambahkan slide baru ke presentasi
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Menambahkan section baru ke presentasi
    pres.getSections().addSection("Section 2", slide);

    //Menambahkan objek SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Mendapatkan objek SummaryZoomSection pertama
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    //Pemformatan untuk objek SummaryZoomSection
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

    //Menyimpan presentasi
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengontrol kembali ke slide “parent” setelah menampilkan target?**

Ya. [Zoom frame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zoomframe/) atau [section](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/sectionzoomframe/) memiliki perilaku kembali-ke‑parent yang, ketika diaktifkan, mengirim penonton kembali ke slide asal setelah mereka mengunjungi konten target.

**Apakah saya dapat menyesuaikan “kecepatan” atau durasi transisi Zoom?**

Ya. Zoom mendukung pengaturan durasi transisi sehingga Anda dapat mengontrol berapa lama animasi lompatan berlangsung.

**Apakah ada batasan berapa banyak objek Zoom yang dapat dimuat dalam satu presentasi?**

Tidak ada batas API keras yang didokumentasikan. Batas praktis bergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak frame Zoom, tetapi pertimbangkan ukuran file dan waktu render.