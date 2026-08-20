---
title: Kelola Bentuk Presentasi dalam JavaScript
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/nodejs-java/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- temukan bentuk
- salin bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- rapikan bentuk
- balikkan bentuk
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyalin, menghapus, menyembunyikan, mengubah urutan, mengekspor, merapikan, dan membalik bentuk presentasi dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java merepresentasikan bentuk-bentuk pada slide sebagai sebuah [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/) yang terurut. Koleksi ini sekaligus merupakan tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukannya: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal, kemudian ditunjukkan cara menyalin, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan tingkat layout, ekspor SVG, perataan, dan pengaturan pembalikan. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Mengidentifikasi dan Menemukan Bentuk**

Indeks koleksi berguna saat memproses file yang sudah diketahui, tetapi bukan pengidentifikasi yang stabil. Penambahan, penghapusan, atau pengubahan urutan bentuk dapat mengubah indeksnya. Pilih pengidentifikasi berdasarkan cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getname/) berguna untuk templat yang dikendalikan pengembang dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan bila kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getalternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan secara diam-diam memanfaatkan teks aksesibilitas yang bermakna sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) adalah pengidentifikasi read‑only yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ini saat berintegrasi dengan PowerPoint atau ketika Anda memerlukan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang disalin atau dibuat ulang adalah bentuk yang berbeda dan menerima ID-nya sendiri.

Metode terkait [getUniqueId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getuniqueid/) mengembalikan pengidentifikasi dengan cakupan presentasi, tetapi pengidentifikasi ini ditujukan untuk add‑in dan dapat dipindahtangankan. Jangan memperlakukannya sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan verifikasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Ketika sebuah operasi spesifik untuk tipe bentuk tertentu, periksa kelas runtime sebelum menggunakan anggota khusus tipe. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Memodifikasi Koleksi Bentuk**

Metode penambahan, penyalinan, penghapusan, dan pengubahan urutan bekerja pada koleksi secara langsung. Jika sebuah operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Menyalin Bentuk**

[addClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/addclone/) membuat salinan independen dan menambahkannya ke akhir koleksi target. [insertClone](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan salinan tanpa mengubah ukuran; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh membuat slide tujuan, menyalin sebuah persegi panjang berlabel ke depan, dan menyisipkan salinan kedua ke belakang. Perubahan pada salah satu salinan tidak memodifikasi bentuk sumber.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Penyalinan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengidentifikasi logis baru pada salinan bila nilai‑nilai tersebut harus unik. Sumber daya yang digunakan oleh bentuk kompleks ditangani oleh presentasi, tetapi salinan tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Menghapus Bentuk**

[remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, lakukan penelusuran dari akhir agar setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca bentuk pada indeks saat ini dan tidak mengasumsikan tipe bentuk tertentu.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan pula konektor, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Menyembunyikan Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/sethidden/) ke `true` menjaga bentuk tetap berada dalam koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang dapat dipulihkan kemudian.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Menyembunyikan bukanlah penghapusan atau keamanan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari file presentasi.

### **Mengubah Z‑Order**

Bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. [reorder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/reorder/) memindahkan bentuk yang sudah ada ke indeks target tanpa menyalinnya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Persegi panjang dibuat terlebih dahulu dan pada awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Finalisasi z‑order setelah menambahkan atau menyalin semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah susunan yang diinginkan.

## **Memeriksa Bentuk pada Slide Layout**

Slide normal, slide layout, dan slide master memiliki koleksi bentuk yang terpisah. Sebuah bentuk dalam koleksi layout bukan objek yang sama dengan bentuk yang posisinya serupa pada slide normal. Periksa bentuk layout ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh layout.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getfillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getlineformat/) dari bentuk layout tanpa mengasumsikan bahwa setiap bentuk adalah `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Mengedit layout dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk layout, tentukan apakah slide normal mewarisi objek tersebut atau memiliki penimpaan lokal, dan uji setiap slide yang memakai layout itu.

## **Mengekspor Bentuk ke SVG**

[writeAsSvg](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/) menulis konten yang dirender dari satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang slide secara keseluruhan atau bentuk‑bentuk di sekitarnya.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Biarkan presentasi tetap terbuka selama proses rendering. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide alih‑alih bentuk individual. Pemanggil bertanggung jawab atas aliran dan harus menutupnya.

## **Merapikan Bentuk**

Overload [SlideUtil.alignShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideutil/alignshapes/) merapikan baik semua bentuk maupun indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk menggunakan tepi slide; atur ke `false` untuk merapikan bentuk yang dipilih relatif satu sama lain.

Contoh ini merapikan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan diubah menjadi indeksnya saat ini tepat sebelum perapihan.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perapihan mengubah posisi, bukan z‑order. Perapihan relatif biasanya membutuhkan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Membalik Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi masukan di bawah ini berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan hanya mengganti dua pengaturan flip. Hal ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/setframe/) baru menggantikan seluruh frame.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bentuk yang disimpan tercermin secara horizontal dan vertikal sekaligus mempertahankan posisi, ukuran, dan rotasinya.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan jangka pendek ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang divalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan sebuah bentuk menghapusnya dari z‑order?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Ia dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang disalin muncul di depan bentuk lain?**

`addClone` menambahkan salinan ke akhir koleksi, yang merupakan bagian depan z‑order. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.