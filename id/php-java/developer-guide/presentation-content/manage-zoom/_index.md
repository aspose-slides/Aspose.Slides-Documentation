---
title: Kelola Zoom Presentasi di PHP
linktitle: Kelola Zoom
type: docs
weight: 60
url: /id/php-java/manage-zoom/
keywords:
- zoom
- bingkai zoom
- zoom slide
- zoom bagian
- zoom ringkasan
- tambahkan zoom
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk PHP via Java — lompat antar bagian, tambahkan thumbnail dan transisi pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, serta bagian-bagian tertentu dari presentasi. Saat Anda melakukan presentasi, kemampuan ini untuk menavigasi dengan cepat ke seluruh konten dapat sangat berguna. 

![overview_image](overview.png)

* Untuk merangkum seluruh presentasi dalam satu slide, gunakan [Summary Zoom](#Summary-Zoom).
* Untuk menampilkan slide tertentu saja, gunakan [Slide Zoom](#Slide-Zoom).
* Untuk menampilkan satu bagian saja, gunakan [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Slide zoom dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi secara bebas antara slide dalam urutan apa pun yang Anda pilih tanpa mengganggu alur presentasi. Slide zoom sangat cocok untuk presentasi singkat tanpa banyak bagian, namun Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Slide zoom membantu Anda menelusuri banyak informasi sekaligus sambil terasa seolah berada pada satu kanvas. 

![overview_image](slidezoomsel.png)

Untuk objek slide zoom, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/php-java/aspose.slides/zoomimagetype/) , kelas [ZoomFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/zoomframe/) , dan beberapa metode di bawah kelas [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) .

### **Buat Bingkai Zoom**

Anda dapat menambahkan bingkai zoom pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru yang akan Anda tautkan dengan bingkai zoom. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to create a zoom frame on a slide:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Membuat latar belakang untuk slide kedua
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Membuat kotak teks untuk slide kedua
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Membuat latar belakang untuk slide ketiga
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Membuat kotak teks untuk slide ketiga
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Menambahkan objek ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Buat Bingkai Zoom dengan Gambar Kustom**
Dengan Aspose.Slides untuk PHP via Java, Anda dapat membuat bingkai zoom dengan gambar pratinjau slide yang berbeda dengan cara berikut:
1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru yang akan Anda tautkan dengan bingkai zoom. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide.
4.	Buat sebuah objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) , yang akan digunakan untuk mengisi bingkai.
5.	Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to create a zoom frame with a different image:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Membuat latar belakang untuk slide kedua
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Membuat kotak teks untuk slide ketiga
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Membuat gambar baru untuk objek zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Menambahkan objek ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Format Bingkai Zoom**
Pada bagian sebelumnya, kami menunjukkan cara membuat bingkai zoom sederhana. Untuk membuat bingkai zoom yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada bingkai zoom. 

Anda dapat mengontrol format bingkai zoom pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru yang akan Anda tautkan dengan bingkai zoom. 
3.	Tambahkan beberapa teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Buat sebuah objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
6.	Tetapkan gambar kustom untuk objek bingkai zoom pertama.
7.	Ubah format garis untuk objek bingkai zoom kedua.
8.	Hapus latar belakang dari gambar objek bingkai zoom kedua.
5.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to change a zoom frame's formatting on a slide:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Membuat latar belakang untuk slide kedua
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Membuat kotak teks untuk slide kedua
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Membuat latar belakang untuk slide ketiga
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Membuat kotak teks untuk slide ketiga
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Menambahkan objek ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Membuat gambar baru untuk objek zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Menetapkan gambar kustom untuk objek zoomFrame1
    $zoomFrame1->setImage($picture);
    # Menetapkan format bingkai zoom untuk objek zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Pengaturan untuk tidak menampilkan latar belakang pada objek zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Section Zoom**

Section zoom adalah tautan ke bagian dalam presentasi Anda. Anda dapat menggunakan section zoom untuk kembali ke bagian yang ingin Anda tekankan secara khusus. Atau Anda dapat menggunakannya untuk menyoroti bagaimana potongan tertentu dari presentasi Anda terhubung. 

![overview_image](seczoomsel.png)

Untuk objek section zoom, Aspose.Slides menyediakan kelas [SectionZoomFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/sectionzoomframe/) dan beberapa metode di bawah kelas [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) .

### **Buat Bingkai Section Zoom**

Anda dapat menambahkan bingkai section zoom ke slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru. 
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan dengan bingkai zoom. 
5.	Tambahkan bingkai section zoom (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to create a zoom frame on a slide:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan Section baru ke presentasi
    $pres->getSections()->addSection("Section 1", $slide);
    # Menambahkan objek SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Buat Bingkai Section Zoom dengan Gambar Kustom**

Dengan Aspose.Slides untuk PHP via Java, Anda dapat membuat bingkai section zoom dengan gambar pratinjau slide yang berbeda dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan dengan bingkai zoom. 
5.	Buat sebuah objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
5.	Tambahkan bingkai section zoom (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to create a zoom frame with a different image:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan Section baru ke presentasi
    $pres->getSections()->addSection("Section 1", $slide);
    # Membuat gambar baru untuk objek zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Menambahkan objek SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Format Bingkai Section Zoom**

Untuk membuat bingkai section zoom yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada bingkai section zoom. 

Anda dapat mengontrol format bingkai section zoom pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan dengan bingkai zoom. 
5.	Tambahkan bingkai section zoom (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Ubah ukuran dan posisi objek section zoom yang dibuat.
7.	Buat sebuah objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
8.	Tetapkan gambar kustom untuk objek bingkai section zoom yang dibuat.
9.	Atur kemampuan *kembali ke slide asli dari bagian yang ditautkan*.
10.	Hapus latar belakang dari gambar objek bingkai section zoom.
11.	Ubah format garis untuk objek bingkai zoom kedua.
12.	Ubah durasi transisi.
13.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to change a section zoom frame's formatting:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan Section baru ke presentasi
    $pres->getSections()->addSection("Section 1", $slide);
    # Menambahkan objek SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Pemformatan untuk SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Summary Zoom**

Summary zoom seperti halaman arahan di mana semua bagian presentasi Anda ditampilkan sekaligus. Saat Anda mempresentasikan, Anda dapat menggunakan zoom untuk berpindah dari satu tempat ke tempat lain dalam presentasi dengan urutan apa pun yang Anda suka. Anda dapat berkreasi, melompati bagian, atau mengunjungi kembali bagian-bagian slide show tanpa mengganggu alur presentasi.

![overview_image](sumzoomsel.png)

Untuk objek summary zoom, Aspose.Slides menyediakan kelas [SummaryZoomFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/summaryzoomframe/) , [SummaryZoomSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/summaryzoomsection/) , dan [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/summaryzoomsectioncollection/) serta beberapa metode di bawah kelas [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/) .

### **Buat Summary Zoom**

Anda dapat menambahkan bingkai summary zoom ke slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan bingkai summary zoom ke slide pertama.
4.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to create a summary zoom frame on a slide:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 1", $slide);
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 2", $slide);
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 3", $slide);
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 4", $slide);
    # Menambahkan objek SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tambah dan Hapus Section Summary Zoom**

Semua bagian dalam bingkai summary zoom direpresentasikan oleh objek [SummaryZoomSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/summaryzoomsection/) , yang disimpan dalam objek [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/summaryzoomsectioncollection/) . Anda dapat menambah atau menghapus objek section summary zoom melalui kelas [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/summaryzoomsectioncollection/) dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan bingkai summary zoom ke slide pertama.
4.	Tambahkan slide dan bagian baru ke presentasi.
5.	Tambahkan bagian yang dibuat ke bingkai summary zoom.
6.	Hapus bagian pertama dari bingkai summary zoom.
7.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to add and remove sections in a summary zoom frame:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 1", $slide);
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 2", $slide);
    # Menambahkan objek SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Menambahkan section ke Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Menghapus section dari Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Format Section Summary Zoom**

Untuk membuat objek section summary zoom yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada objek section summary zoom. 

Anda dapat mengontrol format objek section summary zoom dalam bingkai summary zoom dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) .
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan bingkai summary zoom ke slide pertama.
4.	Dapatkan objek summary zoom section untuk objek pertama dari `SummaryZoomSectionCollection` .
7.	Buat sebuah objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
8.	Tetapkan gambar kustom untuk objek bingkai section zoom yang dibuat.
9.	Atur kemampuan *kembali ke slide asli dari bagian yang ditautkan*.
11.	Ubah format garis untuk objek bingkai zoom kedua.
12.	Ubah durasi transisi.
13.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

This PHP code shows you how to change the formatting for a summary zoom section object:

```php
  $pres = new Presentation();
  try {
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 1", $slide);
    # Menambahkan slide baru ke presentasi
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Menambahkan section baru ke presentasi
    $pres->getSections()->addSection("Section 2", $slide);
    # Menambahkan objek SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Mengambil objek SummaryZoomSection pertama
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Pemformatan untuk objek SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Menyimpan presentasi
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bisakah saya mengontrol kembali ke slide 'induk' setelah menampilkan target?**

Ya. Bingkai [Zoom](https://reference.aspose.com/slides/id/php-java/aspose.slides/zoomframe/) atau [section](https://reference.aspose.com/slides/id/php-java/aspose.slides/sectionzoomframe/) memiliki perilaku `ReturnToParent` yang, bila diaktifkan, mengirim penonton kembali ke slide asal setelah mereka mengunjungi konten target.

**Bisakah saya mengatur 'kecepatan' atau durasi transisi Zoom?**

Ya. Zoom mendukung pengaturan `TransitionDuration` sehingga Anda dapat mengontrol berapa lama animasi lompatan berlangsung.

**Apakah ada batasan berapa banyak objek Zoom yang dapat dimiliki sebuah presentasi?**

Tidak ada batasan API keras yang didokumentasikan. Batas praktis tergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak bingkai Zoom, namun pertimbangkan ukuran file dan waktu rendering.