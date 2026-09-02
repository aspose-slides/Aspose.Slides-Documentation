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
- Temukan bentuk
- Gandakan bentuk
- Hapus bentuk
- Sembunyikan bentuk
- Ubah urutan bentuk
- Dapatkan ID bentuk interop
- Teks alternatif bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Selaraskan bentuk
- Balikkan bentuk
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, menyelaraskan, dan membalikkan bentuk presentasi dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Aspose.Slides for Java merepresentasikan bentuk‑bentuk pada sebuah slide sebagai sebuah [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/) yang berurutan. Koleksi ini sekaligus menjadi tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan penumpukan mereka: indeks `0` adalah bentuk paling belakang, sedangkan indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi sebuah bentuk secara andal, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan pada tingkat tata letak, ekspor SVG, penyelarasan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang dibutuhkan oleh alur kerja Anda.

## **Mengidentifikasi dan Menemukan Bentuk**

Indeks koleksi memang praktis saat memproses file yang sudah diketahui, tetapi mereka bukan pengenal yang stabil. Penambahan, penghapusan, atau pengubahan urutan sebuah bentuk dapat mengubah indeksnya. Pilih pengenal sesuai dengan cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getName--) berguna untuk templat yang dikontrol developer dan mudah diperiksa pada Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan jika kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getAlternativeText--) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam mengubah teks aksesibilitas yang bermakna menjadi kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) adalah pengenal baca‑saja yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ketika berintegrasi dengan PowerPoint atau ketika Anda membutuhkan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang merupakan bentuk yang berbeda dan menerima ID-nya sendiri.

Metode [getUniqueId](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getUniqueId--) yang terkait mengembalikan pengenal dengan ruang lingkup presentasi, tetapi pengenal tersebut ditujukan untuk add‑in dan dapat dipetakan ulang. Jangan memperlakukannya sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

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

Ketika operasi spesifik untuk tipe bentuk, periksa antarmuka sebelum menggunakan anggota yang spesifik tipe. Contoh ini memperbarui teks dan teks alternatif hanya jika objek bernama tersebut merupakan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/).

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

## **Memodifikasi Koleksi Bentuk**

Metode penambahan, penggandaan, penghapusan, dan pengubahan urutan beroperasi pada koleksi secara langsung. Jika sebuah operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Menggandakan Bentuk**

[addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) membuat salinan independen dan menambahkannya ke akhir koleksi target. [insertClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) juga membuat salinan tetapi menempatkannya pada indeks urutan‑z yang ditentukan. Overload yang menerima koordinat memindahkan salinan tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan salinan kedua di belakang. Perubahan pada salah satu salinan tidak memodifikasi bentuk sumber.

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

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengenal logis baru untuk salinan ketika nilai‑nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, tetapi salinan tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Menghapus Bentuk**

[remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, lakukan penelusuran dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca bentuk pada indeks saat ini, bukan item koleksi tetap, dan tidak melakukan cast pada bentuk secara tidak perlu.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk setelahnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan pula penyambung, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Menyembunyikan Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#setHidden-boolean-) ke `true` tetap mempertahankan bentuk dalam koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga penyembunyian cocok untuk elemen opsional yang mungkin dipulihkan kemudian.

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

Penyembunyian bukanlah penghapusan atau keamanan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari file presentasi.

### **Mengubah Urutan Z**

Bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. [reorder](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) memindahkan bentuk yang sudah ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

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

Persegi panjang dibuat terlebih dahulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Finalisasikan urutan‑z setelah menambahkan atau menggandakan semua bentuk terkait, karena operasi‑operasi tersebut menambahkan atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Memeriksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk yang terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang diposisikan serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca masing‑masing [FillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getFillFormat--) dan [LineFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getLineFormat--) pada bentuk tata letak tanpa mengasumsikan setiap bentuk adalah `AutoShape`.

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

Menyunting tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang memakai tata letak tersebut.

## **Mengekspor Bentuk ke SVG**

[writeAsSvg](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) menulis konten ter-render satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang slide secara keseluruhan atau bentuk‑bentuk tetangga.

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

Biarkan presentasi tetap terbuka saat merender. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda membutuhkan seluruh komposisi, ekspor slide alih‑alih bentuk individu. Pemanggil memiliki aliran dan harus menutupnya.

## **Menyelaraskan Bentuk**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) memiliki overload yang menyelaraskan semua bentuk atau indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk menggunakan tepi slide; atur ke `false` untuk menyelaraskan bentuk yang dipilih relatif satu sama lain.

Contoh ini menyelaraskan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan dikonversi ke indeksnya yang saat ini tepat sebelum penyelarasan.

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

Penyelarasan mengubah posisi, bukan urutan‑z. Penyelarasan relatif biasanya membutuhkan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung kembali indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Membalik Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV`‑nya memakai [NullableBool](https://reference.aspose.com/slides/id/java/com.aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah ini berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan setiap nilai bingkai lainnya dan hanya mengganti dua pengaturan flip. Hal ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) baru menggantikan seluruh bingkai.

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

Bentuk yang disimpan dipantulkan secara horizontal dan vertikal sambil tetap mempertahankan posisi, ukuran, dan rotasinya.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengenal bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang divalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari urutan‑z?**

Tidak. Bentuk tersembunyi tetap berada dalam koleksi pada indeks yang sama. Bentuk tersebut dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`addClone` menambahkan salinan ke akhir koleksi, yang merupakan bagian depan urutan‑z. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.