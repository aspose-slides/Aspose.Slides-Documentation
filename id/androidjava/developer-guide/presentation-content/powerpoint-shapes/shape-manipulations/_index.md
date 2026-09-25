---
title: Kelola Bentuk Presentasi di Android
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/androidjava/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- Menemukan bentuk
- Menggandakan bentuk
- Menghapus bentuk
- Menyembunyikan bentuk
- Mengubah urutan bentuk
- Mendapatkan ID bentuk interop
- Teks alternatif bentuk
- Titik penyesuaian bentuk
- Penyesuaian bentuk preset
- Geometri bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Menyelaraskan bentuk
- Membalikkan bentuk
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, menyelaraskan, dan membalikkan bentuk presentasi dengan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java merepresentasikan bentuk pada slide sebagai sebuah [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/) yang terurut. Koleksi ini sekaligus merupakan tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukan mereka: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk yang telah ditetapkan, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian terakhir mencakup pemformatan tingkat tata letak, ekspor SVG, penyelarasan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi memang praktis saat memproses file yang sudah diketahui, tetapi bukan pengidentifikasi yang stabil. Penambahan, penghapusan, atau pengubahan urutan bentuk dapat mengubah indeksnya. Pilih pengidentifikasi sesuai cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getName--) berguna untuk templat yang dikendalikan pengembang dan mudah dilihat di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, sehingga tetapkan konvensi penamaan jika kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getAlternativeText--) berguna ketika deskripsi aksesibilitas atau tag yang disediakan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam memanfaatkan teks aksesibilitas bermakna sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) adalah pengidentifikasi hanya‑baca yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ini saat berintegrasi dengan PowerPoint atau ketika Anda membutuhkan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang merupakan bentuk yang berbeda dan memperoleh ID sendiri.

Metode [getUniqueId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getUniqueId--) yang terkait mengembalikan pengidentifikasi dengan lingkup presentasi, tetapi pengidentifikasi tersebut ditujukan untuk add‑in dan dapat dipertukarkan kembali. Ia tidak boleh diperlakukan sebagai kunci eksternal yang permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Untuk contoh praktis membaca dan memperbarui judul serta deskripsi teks alternatif, lihat [Manage Alternative Text Titles and Descriptions](/slides/id/androidjava/presentation-accessibility/). Gunakan teks alternatif untuk menjelaskan makna visual kepada pembaca, dan pisahkan dari nama bentuk yang digunakan kode untuk menemukan bentuk.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop yang berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Ketika suatu operasi khusus untuk tipe bentuk, periksa antarmuka sebelum memakai anggota tipe‑spesifik. Contoh ini memperbarui teks dan teks alternatif hanya jika objek bernama merupakan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identifikasi dan Modifikasi Penyesuaian Bentuk yang Telah Ditentukan**

Bentuk geometri yang telah ditentukan dapat mengekspos titik penyesuaian yang mengendalikan fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses melalui koleksi baca‑saja [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Koleksi tersebut disediakan oleh bentuk, tetapi setiap [IAdjustValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iadjustvalue/) berisi nilai yang dapat diubah.

Jangan hanya mengandalkan indeks koleksi tetap. Iterasi melalui penyesuaian dan periksa metode baca‑saja [getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iadjustvalue/#getType--) , yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikendalikan penyesuaian tersebut. Metode baca‑saja [getName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iadjustvalue/#getName--) memberikan informasi identifikasi tambahan dan sangat berguna ketika preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan metode nilai yang sesuai dengan makna penyesuaian:

| Tipe Penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| `CornerSize` | Ukuran sudut melengkung | [setRawValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Ketebalan ekor panah | `setRawValue` |
| `ArrowheadLength` | Panjang ujung panah | `setRawValue` |
| `ArrowheadWidth` | Lebar ujung panah | `setRawValue` |
| `StartAngle` | Sudut awal pai atau busur | [setAngleValue](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Sudut akhir pai atau busur | `setAngleValue` |

`getType` dan `getName` mengembalikan informasi baca‑saja. `getRawValue` dan `setRawValue` bekerja dengan integer dalam satuan geometri asli preset, sementara `getAngleValue` dan `setAngleValue` bekerja dengan sudut dalam derajat. Jumlah, urutan, makna, dan rentang nilai yang valid bergantung pada preset [ShapeType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) . Nilai yang valid untuk satu preset mungkin tidak valid atau menghasilkan efek berbeda untuk preset lain.

Ketika `getType` mengembalikan `ShapeAdjustmentType.Custom`, API tidak mengenali makna semantik standar. Periksa `getName`, tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari satu kali sebelum memilih nilai. Artikel [Connector](/slides/id/androidjava/connector/) menunjukkan situasi ini dengan penyesuaian belokan connector.

Contoh lengkap berikut membuat versi standar dan dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan nama dan tipe, mengubah nilai terkait ukuran melalui `setRawValue`, mengubah sudut melalui `setAngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri standar; kolom kanan menampilkan persegi panjang melengkung yang disesuaikan, panah empat‑arah, dan pai.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Menambahkan header untuk kolom bentuk default dan yang disesuaikan.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit mengenai maksudnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki makna yang sama pada bentuk preset yang berbeda.

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Sebuah Bentuk**

[addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) membuat salinan independen dan menambahkannya ke koleksi target. [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukuran; overload dengan lebar dan tinggi dapat meresize juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan klon kedua ke belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengidentifikasi logis baru pada klon ketika nilai‑nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, namun klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi indeks, telusuri dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca bentuk pada indeks saat ini, bukan item koleksi tetap, dan tidak melakukan cast yang tidak perlu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Setelah penghapusan, jumlah bentuk dan indeks bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga connector, animasi, dan fitur presentasi lain yang mungkin merujuk ke objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari tampilan slide.

### **Sembunyikan Sebuah Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) ke `true` menjaga bentuk tetap berada di koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Menyembunyikan bukan menghapus atau mengamankan. Objekt dapat tetap ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari file presentasi.

### **Ubah Z‑Order**

Bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. [reorder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Persegi panjang dibuat terlebih dahulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan z setelah menambah atau menggandakan semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang posisinya serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getFillFormat--) dan [LineFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getLineFormat--) bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Mengedit tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau memiliki override lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[writeAsSvg](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) menulis konten ter‑render satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang seluruh slide atau bentuk tetangganya.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Biarkan presentasi tetap terbuka saat merender. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide alih‑alih bentuk individu. Pemanggil memiliki aliran dan harus menutupnya.

## **Ratakan Bentuk**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) memiliki overload yang meratakan semua bentuk atau indeks koleksi terpilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Setel `alignToSlide` ke `true` untuk menggunakan tepi slide; setel ke `false` untuk meratakan bentuk terpilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan dikonversi ke indeksnya saat ini tepat sebelum penyelarasan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Penyelarasan mengubah posisi, bukan z‑order. Penyelarasan relatif biasanya memerlukan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal membutuhkan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/nullablebool/) : `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah ini berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lain dan mengganti hanya dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) baru menggantikan seluruh frame.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bentuk yang disimpan tercermin secara horizontal dan vertikal sambil mempertahankan posisi, ukuran, dan rotasinya.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik memakai konvensi `Name` atau `AlternativeText` yang tervalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari z‑order?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Itu dapat ditemukan, diubah urutannya, diedit, atau ditampilkan kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`addClone` menambahkan klon ke akhir koleksi, yang merupakan depan z‑order. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.

**Dapatkah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasi melalui `IGeometryShape.getAdjustments` dan periksa `IAdjustValue.getType`; gunakan `IAdjustValue.getName` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari satu kali.