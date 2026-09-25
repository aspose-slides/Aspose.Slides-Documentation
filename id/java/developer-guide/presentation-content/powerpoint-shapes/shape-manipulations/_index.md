---
title: Kelola Bentuk Presentasi di Java
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/java/shape-manipulations/
keywords:
  - Bentuk PowerPoint
  - Bentuk presentasi
  - Bentuk pada slide
  - cari bentuk
  - gandakan bentuk
  - hapus bentuk
  - sembunyikan bentuk
  - ubah urutan bentuk
  - dapatkan ID bentuk interop
  - teks alternatif bentuk
  - titik penyesuaian bentuk
  - penyesuaian bentuk praset
  - geometri bentuk
  - format tata letak bentuk
  - bentuk sebagai SVG
  - bentuk ke SVG
  - rata bentuk
  - balikkan bentuk
  - PowerPoint
  - presentasi
  - Java
  - Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, meratakan, dan membalik bentuk presentasi dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Aspose.Slides for Java merepresentasikan bentuk‑bentuk pada sebuah slide sebagai [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/) yang terurut. Koleksi ini sekaligus menjadi tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan penumpukannya: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk yang telah ditetapkan, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, perataan, dan pengaturan flip. Setiap contoh berdiri sendiri, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi nyaman saat memproses file yang sudah diketahui, tetapi bukan pengidentifikasi yang stabil. Menambahkan, menghapus, atau mengubah urutan bentuk dapat mengubah indeksnya. Pilih pengidentifikasi sesuai cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getName--) berguna untuk templat yang dikontrol pengembang dan mudah diperiksa di Panel Pilihan PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan bila kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getAlternativeText--) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam memakai teks aksesibilitas yang bermakna sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) adalah pengidentifikasi hanya‑baca yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ini saat mengintegrasikan dengan PowerPoint atau ketika Anda memerlukan referensi yang jelas selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang adalah bentuk yang berbeda dan menerima ID‑nya sendiri.

Metode [getUniqueId](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getUniqueId--) yang terkait mengembalikan pengidentifikasi dengan ruang lingkup presentasi, tetapi pengidentifikasi itu dimaksudkan untuk add‑in dan dapat dipindahkan kembali. Jangan memperlakukannya sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Untuk contoh praktis membaca dan memperbarui judul serta deskripsi teks alternatif, lihat [Manage Alternative Text Titles and Descriptions](/slides/id/java/presentation-accessibility/). Gunakan teks alternatif untuk menjelaskan arti visual kepada pembaca, dan pisahkan dari nama bentuk yang dipakai kode untuk menemukan bentuk.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop yang berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil itu alih‑alih melanjutkan dengan objek yang salah.

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

Ketika operasi spesifik untuk tipe bentuk tertentu, periksa antarmuka sebelum memakai anggota khusus tipe. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama merupakan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/).

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

## **Identifikasi dan Modifikasi Penyesuaian Bentuk Praset**

Bentuk geometri praset dapat mengekspos titik penyesuaian yang mengendalikan fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses mereka melalui koleksi baca‑saja [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/id/java/com.aspose.slides/igeometryshape/#getAdjustments--) . Koleksi tersebut disediakan oleh bentuk, tetapi setiap [IAdjustValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/) berisi nilai yang dapat diubah.

Jangan hanya mengandalkan indeks koleksi tetap. Iterasi melalui penyesuaian dan periksa metode baca‑saja [getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#getType--) , yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikendalikan penyesuaian. Metode baca‑saja [getName](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#getName--) memberikan informasi identifikasi tambahan dan sangat berguna ketika sebuah praset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan metode nilai yang cocok dengan makna penyesuaian:

| Tipe penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| `CornerSize` | Ukuran sudut melengkung | [setRawValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Ketebalan ekor panah | `setRawValue` |
| `ArrowheadLength` | Panjang kepala panah | `setRawValue` |
| `ArrowheadWidth` | Lebar kepala panah | `setRawValue` |
| `StartAngle` | Sudut awal irisan atau busur | [setAngleValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Sudut akhir irisan atau busur | `setAngleValue` |

`getType` dan `getName` mengembalikan informasi baca‑saja. `getRawValue` dan `setRawValue` bekerja dengan bilangan bulat dalam satuan geometri asli praset, sementara `getAngleValue` dan `setAngleValue` bekerja dengan sudut dalam derajat. Jumlah, urutan, makna, dan rentang nilai yang valid tergantung pada [ShapeType](https://reference.aspose.com/slides/id/java/com.aspose.slides/igeometryshape/#getShapeType--) praset. Nilai yang valid untuk satu praset mungkin tidak valid atau menghasilkan efek berbeda untuk praset lain.

Ketika `getType` mengembalikan `ShapeAdjustmentType.Custom`, API tidak mengenali makna semantik standar. Periksa `getName`, tipe praset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari satu kali sebelum memilih nilai. Artikel [Connector](/slides/id/java/connector/) menunjukkan situasi ini dengan penyesuaian belokan konektor.

Contoh lengkap berikut membuat versi default dan dimodifikasi dari tiga bentuk praset. Ia mengiterasi setiap penyesuaian, melaporkan nama dan tipe, mengubah nilai terkait ukuran lewat `setRawValue`, mengubah sudut lewat `setAngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menampilkan persegi panjang melengkung, panah empat arah, dan irisan yang telah disesuaikan.

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

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit tentang maksudnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki makna yang sama pada berbagai bentuk praset.

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Bentuk**

[addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) membuat salinan independen dan menambahkannya ke koleksi target. [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh ini membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan klon kedua di belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

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

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengidentifikasi logis baru ke klon ketika nilai‑nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, tetapi klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus banyak kecocokan selama iterasi terindeks, iterasi dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditetapkan. Ia membaca bentuk pada indeks saat ini, bukan item koleksi tetap, dan tidak melakukan casting bentuk secara tidak perlu.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga konektor, animasi, dan fitur presentasi lain yang mungkin merujuk ke objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari tampilan slide.

### **Sembunyikan Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#setHidden-boolean-) ke `true` menjaga bentuk tetap berada di koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

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

Menyembunyikan bukan penghapusan atau keamanan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Ubah Urutan Z**

Bentuk yang saling menumpuk digambar menurut urutan koleksi. [reorder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Persegi panjang dibuat pertama dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan z setelah menambah atau menggandakan semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang dimaksud.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang diposisikan serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getFillFormat--) dan [LineFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getLineFormat--) bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah `AutoShape`.

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

Menyunting tata letak dapat mempengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[writeAsSvg](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) menulis konten ter-render satu bentuk ke aliran. Hasilnya berisi bentuk, bukan latar belakang slide keseluruhan atau bentuk‑bentuk tetangga.

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

Pertahankan presentasi terbuka selama proses render. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide bukan bentuk individual. Pemanggil memiliki aliran dan harus menutupnya.

## **Ratakan Bentuk**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) memiliki overload yang meratakan semua bentuk atau indeks koleksi terpilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk menggunakan tepi slide; atur ke `false` untuk meratakan bentuk terpilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan dikonversi ke indeksnya saat ini tepat sebelum perataan.

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

Perataan mengubah posisi, bukan urutan z. Perataan relatif biasanya memerlukan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/java/com.aspose.slides/nullablebool/) : `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak‑ditentukan/default.

Presentasi masukan di bawah ini berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan mengganti hanya dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) baru menggantikan seluruh frame.

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

Bentuk yang disimpan tercermin secara horizontal dan vertikal sambil menjaga posisi, ukuran, dan rotasinya.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang divalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari urutan z?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Itu dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`addClone` menambahkan klon ke akhir koleksi, yang merupakan depan urutan z. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.

**Bisakah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk praset?**

Hanya setelah memvalidasi praset dan tata letak koleksi yang tepat. Lebih baik iterasi melalui `IGeometryShape.getAdjustments` dan periksa `IAdjustValue.getType`; gunakan `IAdjustValue.getName` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari satu kali.