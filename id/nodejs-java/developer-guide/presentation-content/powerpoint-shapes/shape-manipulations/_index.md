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
- Temukan bentuk
- Gandakan bentuk
- Hapus bentuk
- Sembunyikan bentuk
- Ubah urutan bentuk
- Dapatkan ID bentuk interop
- Teks alternatif bentuk
- Titik penyesuaian bentuk
- Penyesuaian bentuk preset
- Geometri bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Selaraskan bentuk
- Balikkan bentuk
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, menyelaraskan, dan membalik bentuk presentasi dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java merepresentasikan bentuk-bentuk pada slide sebagai sebuah [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/) yang terurut. Koleksi tersebut sekaligus menjadi tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukan mereka: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk preset, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan level tata letak, ekspor SVG, penyelarasan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Mengidentifikasi dan Menemukan Bentuk**

Indeks dalam koleksi memang nyaman saat memproses file yang sudah diketahui, tetapi bukanlah pengenal yang stabil. Penambahan, penghapusan, atau pengubahan urutan sebuah bentuk dapat mengubah indeksnya. Pilih pengenal sesuai cara presentasi dibuat dan dipelihara:

- `[Name]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getname/) berguna untuk templat yang dikendalikan pengembang dan mudah dilihat di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, sehingga tetapkan konvensi penamaan bila kode bergantung padanya.
- `[AlternativeText]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getalternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam memanfaatkan teks aksesibilitas yang bermakna sebagai kunci basis data.
- `[OfficeInteropShapeId]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) adalah pengenal read‑only yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ini saat berintegrasi dengan PowerPoint atau ketika Anda memerlukan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang merupakan bentuk yang berbeda dan menerima ID tersendiri.

Metode terkait `[getUniqueId]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getuniqueid/) mengembalikan pengenal dengan ruang lingkup presentasi, tetapi pengenal tersebut ditujukan untuk add‑in dan dapat dipindahtugaskan. Jangan perlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop yang berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil itu alih‑alih melanjutkan dengan objek yang salah.

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

Ketika sebuah operasi spesifik untuk tipe bentuk tertentu, periksa kelas runtime sebelum memakai anggota khusus tipe. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama adalah sebuah `[AutoShape]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).

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

## **Mengidentifikasi dan Memodifikasi Penyesuaian Bentuk Preset**

Bentuk geometri preset dapat mengekspos titik penyesuaian yang mengendalikan fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses mereka melalui koleksi read‑only `[GeometryShape.getAdjustments]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/geometryshape/). Koleksi itu sendiri disediakan oleh bentuk, tetapi setiap `[AdjustValue]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/) berisi nilai yang dapat diubah.

Jangan hanya mengandalkan indeks koleksi tetap. Iterasi melalui penyesuaian dan inspeksi metode read‑only `[getType]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/) yang nilai `[ShapeAdjustmentType]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikendalikan penyesuaian tersebut. Metode read‑only `[getName]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/getname/) memberikan informasi identifikasi tambahan dan sangat berguna ketika sebuah preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan metode nilai yang sesuai dengan makna penyesuaian:

| Tipe Penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| `CornerSize` | Ukuran sudut melengkung | [setRawValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Ketebalan ekor panah | `setRawValue` |
| `ArrowheadLength` | Panjang ujung panah | `setRawValue` |
| `ArrowheadWidth` | Lebar ujung panah | `setRawValue` |
| `StartAngle` | Sudut awal pie atau busur | [setAngleValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Sudut akhir pie atau busur | `setAngleValue` |

`getType` dan `getName` mengembalikan informasi read‑only. `getRawValue` dan `setRawValue` bekerja dengan bilangan bulat dalam satuan geometri native preset, sementara `getAngleValue` dan `setAngleValue` bekerja dengan sudut dalam derajat. Jumlah, urutan, makna, dan rentang nilai yang sah dari penyesuaian bergantung pada preset `[GeometryShape.getShapeType]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/geometryshape/). Nilai yang valid untuk satu preset mungkin tidak valid atau memiliki efek berbeda untuk preset lain.

Ketika `getType` mengembalikan `ShapeAdjustmentType.Custom`, API tidak mengenali makna semantik standar. Periksa `getName`, tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari sekali sebelum memilih nilai. Artikel `[Connector]`(/slides/id/nodejs-java/connector/) menunjukkan situasi ini dengan penyesuaian belokan penghubung.

Contoh lengkap berikut membuat versi default dan dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan nama dan tipe, mengubah nilai terkait ukuran melalui `setRawValue`, mengubah sudut melalui `setAngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menampilkan persegi panjang bersudut bulat, panah empat arah, dan pie yang telah disesuaikan.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Menambahkan header untuk kolom bentuk default dan kolom bentuk yang disesuaikan.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Memeriksa tipe semantik sebelum mengubah nilai membuat kode menjadi eksplisit mengenai maksudnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki makna yang sama pada bentuk preset yang berbeda.

## **Memodifikasi Koleksi Bentuk**

Metode penambahan, penggandaan, penghapusan, dan pengubahan urutan beroperasi langsung pada koleksi. Jika sebuah operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Menggandakan Bentuk**

`[addClone]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. `[insertClone]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks urutan‑z tertentu. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan klon kedua di belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

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

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengenal logis baru untuk klon bila nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, namun klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Menghapus Bentuk**

`[remove]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi indeks, lakukan penelusuran dari akhir sehingga setiap indeks yang tersisa tetap valid.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk yang berada setelahnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga penghubung, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Menyembunyikan Bentuk**

Menetapkan `[Hidden]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/sethidden/) ke `true` menjaga bentuk tetap berada dalam koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

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

Menyembunyikan bukan berarti menghapus atau mengamankan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Mengubah Urutan Z**

Bentuk‑bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. `[reorder]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

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

Persegi panjang dibuat terlebih dahulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan‑z setelah menambahkan atau menggandakan semua bentuk terkait, karena operasi‑operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Mengecek Bentuk pada Slide Layout**

Slide normal, slide layout, dan slide master memiliki koleksi bentuk yang terpisah. Sebuah bentuk dalam koleksi layout bukanlah objek yang sama dengan bentuk yang posisinya serupa pada slide normal. Periksa bentuk layout ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh layout.

Contoh berikut membaca setiap `[FillFormat]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getfillformat/) dan `[LineFormat]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getlineformat/) pada bentuk layout tanpa mengasumsikan bahwa setiap bentuk adalah sebuah `AutoShape`.

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

`[writeAsSvg]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/) menulis konten ter‑render satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang seluruh slide atau bentuk‑bentuk tetangganya.

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

Biarkan presentasi tetap terbuka selama proses rendering. Output tergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide alih‑alih bentuk tunggal. Pemanggil memiliki aliran dan harus menutupnya.

## **Menyelaraskan Bentuk**

`[SlideUtil.alignShapes]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideutil/alignshapes/) memiliki overload yang menyelaraskan semua bentuk atau indeks koleksi yang dipilih. `[ShapesAlignmentType]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk menggunakan tepi slide; atur ke `false` untuk menyelaraskan bentuk yang dipilih relatif satu sama lain.

Contoh ini menyelaraskan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan dikonversi ke indeks saat ini tepat sebelum penyelarasan.

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

Penyelarasan mengubah posisi, bukan urutan‑z. Penyelarasan relatif biasanya membutuhkan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal membutuhkan cukup bentuk untuk menentukan jarak. Hitung ulang indeks bila Anda memodifikasi koleksi sebelum memanggil metode.

## **Membalik Bentuk**

Kelas `[ShapeFrame]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV` menggunakan `[NullableBool]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tidak ditentukan/default.

Presentasi masukan di bawah ini berisi satu bentuk yang tidak dibalik.

![Bentuk sebelum diputar](shape_to_be_flipped.png)

Contoh ini mempertahankan setiap nilai frame lainnya dan hanya mengganti dua pengaturan flip. Hal ini penting karena menetapkan `[Frame]`(https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/setframe/) yang baru menggantikan seluruh frame.

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

Bentuk yang disimpan tercermin secara horizontal dan vertikal sementara posisi, ukuran, dan rotasinya tetap.

![Bentuk setelah diputar](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengenal bentuk?**

Hanya untuk pemrosesan jangka pendek ketika koleksi tidak akan berubah sebelum indeks digunakan. Utamakan konvensi `Name` atau `AlternativeText` yang terverifikasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk mengeluarkannya dari urutan‑z?**

Tidak. Bentuk yang disembunyikan tetap berada dalam koleksi pada indeks yang sama. Bentuk tersebut dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`addClone` menambahkan klon ke akhir koleksi, yang merupakan bagian depan urutan‑z. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.

**Bisakah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasi melalui `GeometryShape.getAdjustments` dan memeriksa `AdjustValue.getType`; gunakan `AdjustValue.getName` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari sekali.