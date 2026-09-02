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
- cari bentuk
- gandakan bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- menyelaraskan bentuk
- balikkan bentuk
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menggandakan, menghapus, menyembunyikan, menyusun ulang, mengekspor, meratakan, dan membalikkan bentuk presentasi dengan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Aspose.Slides untuk Android via Java merepresentasikan bentuk‑bentuk pada slide sebagai sebuah [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/) yang terurut. Koleksi ini sekaligus menjadi tempat Anda menemukan dan memodifikasi bentuk serta menjadi sumber urutan penumpukan mereka: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama artikel menjelaskan cara mengidentifikasi bentuk secara andal, kemudian menunjukkan cara menggandakan, menghapus, menyembunyikan, dan menyusun ulang bentuk. Bagian akhir mencakup pemformatan pada tingkat tata letak, ekspor SVG, penyelarasan, dan pengaturan pembalikan. Setiap contoh berdiri sendiri, sehingga Anda dapat menggunakan hanya operasi yang dibutuhkan alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi berguna saat memproses file yang sudah dikenal, tetapi bukan pengidentifikasi yang stabil. Menambah, menghapus, atau menyusun ulang sebuah bentuk dapat mengubah indeksnya. Pilih pengidentifikasi sesuai dengan cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getName--) berguna untuk templat yang dikendalikan pengembang dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan bila kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getAlternativeText--) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam menggunakan kembali teks aksesibilitas yang berarti sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) adalah pengidentifikasi hanya‑baca yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan saat berintegrasi dengan PowerPoint atau ketika Anda memerlukan referensi tak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat kembali adalah bentuk berbeda dan menerima IDnya sendiri.

Metode [getUniqueId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getUniqueId--) yang terkait mengembalikan pengidentifikasi dengan cakupan presentasi, tetapi pengidentifikasi tersebut ditujukan untuk add‑in dan dapat ditetapkan ulang. Jangan perlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan nama dengan perbandingan tepat dan melaporkan ID interop berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

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

Ketika suatu operasi khusus untuk tipe bentuk, periksa antarmuka sebelum menggunakan anggota spesifik tipe. Contoh ini memperbarui teks dan teks alternatif hanya jika objek bernama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/).

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

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan susun ulang beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Sebuah Bentuk**

[addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) membuat salinan independen dan menambahkannya ke akhir koleksi target. [insertClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) juga membuat salinan tetapi menempatkannya pada indeks urutan‑z yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukuran; overload dengan lebar dan tinggi dapat merubah ukuran juga.

Contoh membuat slide tujuan, menggandakan sebuah persegi panjang berlabel ke depan, dan menyisipkan klon kedua di belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

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

Menggandakan menyalin isi dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengidentifikasi logis baru pada klon ketika nilai‑nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, tetapi klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, iterasi dari akhir agar setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca bentuk pada indeks saat ini, bukan item koleksi tetap, dan tidak melakukan cast bentuk secara tidak perlu.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan pula konektor, animasi, dan fitur presentasi lain yang mungkin merujuk ke objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari tampilan slide.

### **Sembunyikan Sebuah Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) ke `true` menjaga bentuk tetap berada dalam koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan isinya tetap tersedia bagi kode, sehingga penyembunyian cocok untuk elemen opsional yang mungkin dipulihkan nanti.

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

Penyembunyian bukan penghapusan atau keamanan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, serta tetap menjadi bagian dari berkas presentasi.

### **Ubah Urutan‑Z**

Bentuk yang tumpang tindih digambar berdasarkan urutan koleksi. [reorder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `size() - 1` adalah depan.

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

Persegi panjang dibuat pertama dan pada awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan‑z setelah menambah atau menggandakan semua bentuk terkait, karena operasi‑operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Sebuah bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang diposisikan serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getFillFormat--) dan [LineFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getLineFormat--) pada bentuk tata letak tanpa mengasumsikan setiap bentuk adalah `AutoShape`.

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

Mengedit tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang memakai tata letak tersebut.

## **Ekspor Bentuk ke SVG**

[writeAsSvg](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) menulis konten terrender satu bentuk ke aliran. Hasilnya berisi bentuk saja, bukan latar belakang seluruh slide atau bentuk‑bentuk tetangga.

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

Biarkan presentasi tetap terbuka saat melakukan rendering. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide bukan bentuk individu. Pemanggil memiliki aliran dan harus menutupnya.

## **Ratakan Bentuk**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) memiliki overload yang meratakan semua bentuk atau indeks koleksi terpilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `alignToSlide` ke `true` untuk menggunakan tepi slide; atur ke `false` untuk meratakan bentuk terpilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan diubah menjadi indeksnya saat ini tepat sebelum penyelarasan.

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

Penyelarasan mengubah posisi, bukan urutan‑z. Penyelarasan relatif biasanya memerlukan setidaknya dua bentuk, sementara distribusi horisontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Sebuah Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `getFlipH` dan `getFlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak‑ditentukan/default.

Presentasi input di bawah ini berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan hanya mengganti dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) baru menggantikan seluruh frame.

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

Bentuk yang disimpan kini tercermin secara horizontal dan vertikal sambil tetap mempertahankan posisi, ukuran, dan rotasinya.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang terverifikasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan sebuah bentuk menghapusnya dari urutan‑z?**

Tidak. Bentuk tersembunyi tetap berada dalam koleksi pada indeks yang sama. Ia dapat ditemukan, disusun ulang, diedit, atau dibuat terlihat kembali.

**Mengapa sebuah bentuk yang digandakan muncul di depan bentuk lain?**

`addClone` menambahkan klon ke akhir koleksi, yang merupakan bagian depan urutan‑z. Gunakan `insertClone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.