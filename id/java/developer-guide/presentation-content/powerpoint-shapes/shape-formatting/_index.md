---
title: Format Bentuk PowerPoint di Java
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/java/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isian gradasi
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- rendering bentuk hitam-putih
- rendering bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint di Java menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pengantar**

Format bentuk di PowerPoint dengan menyesuaikan garis tepi, isian, dan efeknya. Aspose.Slides for Java memungkinkan Anda mengontrol pengaturan ini secara programatik, termasuk transparansi, rotasi, dan pemformatan 3D.

![Shape formatting options in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java menyediakan antarmuka dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Gunakan [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) untuk mengontrol garis tepi bentuk. Contoh ini membuat persegi panjang tanpa isi dengan garis tepi biru bergaris putus-putus. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) memilih garis gabungan tebal‑tipis, sementara [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) menetapkan lebarnya menjadi 7 poin dan [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) memilih pola dash.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The formatted lines in the presentation](formatted-lines.png)

### **Atur Pola Dash Garis Kustom**

Gunakan [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) ketika style garis yang telah ditentukan tidak menyediakan panjang dash dan celah yang Anda butuhkan, misalnya untuk garis tepi bermerek atau diagram teknis. Menetapkan pola secara otomatis mengubah gaya dash garis menjadi [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Entri array bergantian antara panjang dash dan celah, dimulai dengan dash. Setiap nilai merupakan kelipatan lebar garis: `{ 4, 2 }` dengan lebar 3 poin menghasilkan dash sebesar 12 poin diikuti celah 6 poin. Gunakan pasangan nilai hingga, tidak negatif untuk mendefinisikan segmen dash‑dan‑celah lengkap. Contoh ini menggunakan nilai positif agar setiap dash dan celah terlihat.

Contoh ini membuat lima garis biru dengan panjang yang sama dan ujung datar. Tiga pertama membandingkan pola pada lebar 3 poin. Yang keempat mengulangi pola pertama dengan lebar dua kali lipat, menggandakan panjang dash dan celah. Yang kelima beralih dari pola kustom ke garis padat.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Kembalikan garis terakhir ke gaya solid.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk kembali ke gaya dash yang telah ditentukan, berikan [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) ke [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Gaya yang dipilih mengontrol tampilan garis.

Hasil di PowerPoint, dari atas ke bawah: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; dan **Solid, 3 pt**.

![Three custom dash patterns, a wider line using the first pattern, and a solid line in PowerPoint](custom-dash-patterns.png)

### **Atur Ujung Garis**

Gunakan [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) untuk mengatur ujung garis terbuka. Kelas [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) menyediakan tiga gaya ujung eksplisit:

- `Flat`: Coretan berhenti pada titik akhir.
- `Round`: Ujung setengah lingkaran meluas melebihi titik akhir sebesar setengah lebar garis.
- `Square`: Ujung berbentuk kotak meluas melebihi titik akhir sebesar setengah lebar garis.

Kelas ini juga mencakup `NotDefined`, yang berarti tidak ada gaya ujung yang ditetapkan secara eksplisit.

Ujung berbeda dari kepala panah, yang menambahkan simbol pada ujung garis, dan sambungan, yang mengontrol sudut antara segmen garis. Contoh ini menonaktifkan kepala panah melalui [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) dan [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) sehingga hanya bentuk ujung yang dibandingkan.

Contoh berikut membuat tiga garis horizontal yang pada dasarnya identik, lebar 20 poin. Dari atas ke bawah, mereka menggunakan ujung flat, round, dan square. Titik akhir mereka memiliki koordinat horizontal yang sama; ujung round dan square meluas 10 poin di luar setiap titik akhir.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint, dari atas ke bawah: **Flat**, **Round**, dan **Square**.

![Flat, round, and square caps on identical thick lines in PowerPoint](line-caps.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) untuk mengakses pengaturan garis, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) untuk mengakses pengaturan sketsa, dan [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) untuk memilih nilai dari kelas [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Kode Java berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) , membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Nilai yang dikembalikan oleh [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, slide master, atau slide tata letak, gunakan [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) , akses [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) , dan baca [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--) . Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan. Contoh ini memerlukan presentasi yang ada dengan setidaknya satu bentuk pada slide pertama dan mencetak kedua nilai:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Gaya sambungan mengontrol bagaimana dua segmen garis tepi bertemu pada sudut. Gunakan **Round** untuk sudut melengkung, **Miter** untuk sudut tajam, atau **Bevel** untuk sudut yang diratakan.

![The join style in the presentation](join-style-powerpoint.png)

Contoh ini membuat tiga persegi panjang hitam dengan garis tepi biru lebar 15 poin. Ini menggunakan [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) untuk menetapkan nilai miter, bevel, dan round dari [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) , masing‑masing, untuk membandingkan bagaimana sudut digambar.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Batasi Sambungan Miter pada Sudut Tajam**

Gunakan [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) bersama [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) yang diatur ke [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) untuk membatasi sejauh mana sudut tajam dapat meluas.

Batas tersebut adalah rasio antara jarak antara sudut dalam dan luar sambungan terhadap lebar garis. Misalnya, nilai `8` memperbolehkan panjang miter hingga delapan kali lebar garis; bukan ukuran dalam poin. Jika sudut melebihi batas, PowerPoint menggunakan sambungan bevel pada sudut tersebut. Batas yang lebih besar memungkinkan titik yang lebih tajam. Pengaturan ini hanya memengaruhi sambungan miter, dan mengubahnya tidak memberi efek terlihat bila sudut tetap berada dalam kedua batas.

Contoh ini membuat dua segitiga identik tanpa isi, lebar garis 20 poin. Segitiga kiri menggunakan batas `2`, dan yang kanan menggunakan `8`. Setiap segitiga lebar 80 poin dan tinggi 160 poin, memberikan rasio panjang miter‑ke‑lebar garis sekitar `4.12` pada sudut atas. Akibatnya, PowerPoint memotong siku kiri dan mempertahankan siku kanan.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint: **Miter limit 2** di kiri dan **miter limit 8** di kanan.

![A beveled apex with miter limit 2 and a pointed apex with miter limit 8 in PowerPoint](miter-limits.png)

## **Isian Gradasi**

Isian gradasi mencampur warna di seluruh bentuk. Contoh ini mengisi elips dengan gradasi linear pada sudut 45 derajat dari merah ke ungu menggunakan [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). Metode [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) menempatkan titik warna pada 0 dan 1, awal dan akhir gradasi. Menghapus titik yang ada memastikan hanya dua warna ini yang digunakan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The ellipse with gradient fill](gradient-fill.png)

Jika gradasi terlihat berbeda dalam gambar yang diekspor dibandingkan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah isian gradasi yang disimpan dalam presentasi.

### **Atur Sudut Gradasi Linear**

Gunakan [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) untuk mengontrol orientasi isian [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). Sudut diukur dalam derajat dan meningkat searah jarum jam: `0` berjalan dari kiri ke kanan, `90` dari atas ke bawah, `180` dari kanan ke kiri, dan `270` dari bawah ke atas. Sudut pecahan didukung. Sudut terbatas di luar `[0, 360)` dinormalisasi menjadi satu revolusi; misalnya, `-45` menjadi `315` dan `360` menjadi `0`.

Contoh ini membuat enam persegi panjang dengan titik warna merah, hijau, dan biru identik pada posisi `0`, `0.5`, dan `1`. Skala dinonaktifkan sehingga sudut dapat dibandingkan terlepas dari proporsi persegi panjang. Sudut, dari kiri ke kanan, adalah `0`, `45`, dan `90` pada baris pertama, serta `135`, `180`, dan `270` pada baris kedua.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint:

![Linear gradients at 0, 45, and 90 degrees in the top row, and 135, 180, and 270 degrees in the bottom row](linear-gradient-angles.png)

### **Skalakan Gradasi Linear dengan Bentuk**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) menerima nilai [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Atur secara eksplisit ke `False` untuk mempertahankan sudut geometris gradasi saat proporsi bentuk berubah, atau ke `True` untuk menyesuaikan gradasi dengan lebar dan tinggi bentuk. Dengan skala diaktifkan, sudut yang terlihat dapat berbeda dari sudut yang ditetapkan pada bentuk yang tidak berbentuk kotak.

Contoh berikut menggunakan sudut `45` derajat dan titik warna yang sama seperti perbandingan sudut. Kolom kiri menggunakan `False`; kolom kanan menggunakan `True`. Setiap kolom berisi persegi panjang lebar di atas persegi panjang tinggi. Keduanya mulai dengan dimensi lebar yang sama; mengubah lebar dan tinggi persegi panjang kedua menunjukkan bagaimana isian merespons perubahan ukuran tanpa mengubah pengaturan gradasinya.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint, dengan skala dinonaktifkan di kiri dan diaktifkan di kanan:

![Wide and tall rectangles with a 45-degree gradient, comparing LinearGradientScaled False on the left with True on the right](linear-gradient-scaling.png)

Dengan skala dinonaktifkan, pita warna diagonal mempertahankan orientasi yang sama pada kedua persegi panjang. Dengan skala diaktifkan, pita memanjang bersama proporsi bentuk. Ini membantu mereproduksi gradasi template saat menyesuaikan bentuk ke ukuran berbeda. Pada bentuk kotak, mengaktifkan skala tidak mengubah tampilan gradasi `45` derajat ini.

Baik sudut maupun pengaturan skala berlaku untuk gradasi linear. Mereka tidak mengontrol isian [GradientShape.Radial atau GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Gabungkan Sudut dengan Arah Gradasi**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) memilih gaya gradasi dari kelas [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) ; itu bukan pengganti sudut numerik. Untuk gradasi linear, gaya sudut dapat mengubah area distribusi warna tanpa mengubah sudut yang ditetapkan melalui [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Jaga arah tetap tidak berubah saat membandingkan sudut atau skala.

Contoh berikut menerapkan pengaturan yang sama dengan urutan berlawanan. Kedua persegi panjang memiliki tampilan yang sama: menetapkan arah sebelum atau sesudah sudut tidak mengubah hasil.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Isian Pola**

Isian pola menerapkan desain dua warna, seperti titik, garis, atau kotak-kotak. Contoh ini menggunakan [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) untuk memilih pola trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) menyediakan latar belakang abu‑abu terang, dan [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) menyediakan warna kuning untuk pola.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The rectangle with pattern fill](pattern-fill.png)

## **Isian Gambar**

Isian gambar menggunakan gambar di dalam bentuk. Contoh ini memerlukan gambar lokal dan menggunakan [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) untuk memuatnya ke dalam koleksi gambar presentasi. Menetapkan [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) ke mode ubin mengulangi gambar di dalam persegi panjang. Gambar sumber yang digunakan ditampilkan di bawah:

![The lotus picture](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The shape with picture fill](picture-fill.png)

### **Utile Gambar sebagai Tekstur**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Mengatur mode isian gambar—baik `Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Menentukan perataan ubin di dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Mengatur offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Mengatur offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Mendefinisikan skala horizontal ubin dalam persentase.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Mendefinisikan skala vertikal ubin dalam persentase.

Contoh ini memerlukan gambar lokal dan mengkonfigurasi [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) untuk mengulangnya pada 50 % ukuran aslinya. Offset −32 poin menggeser ubin secara horizontal dan vertikal; perataan kanan‑bawah dan pembalikan di kedua arah menentukan susunan tekstur berulang.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The tile options](tile-options.png)

## **Isian Warna Solid**

Isian solid memberi bentuk satu warna seragam. Contoh ini menggunakan [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) untuk mengatur mode isian solid dan menetapkan kuning melalui [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), lalu menyimpan persegi panjang dalam presentasi.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The shape with solid color fill](solid-color-fill.png)

### **Salin Warna Sambil Mempertahankan Referensi Tema**

Gunakan [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) untuk menyalin definisi warna, termasuk tipe warna, referensi tema, dan transformasi. Ini berguna saat memindahkan warna isian antara bentuk yang harus tetap mengikuti tema presentasi. Metode ini menyalin hanya warna: tidak menyalin tipe isian, garis tepi, atau pemformatan bentuk lainnya. Tetapkan tipe isian tujuan secara eksplisit dengan [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-).

Contoh ini membuat tiga persegi panjang, dari kiri ke kanan: sumber, salinan yang menyadari tema, dan salinan RGB tetap. Sumber menggunakan [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) untuk merujuk pada warna aksen pertama dan menambahkan tint melalui [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-). Salinan RGB menggunakan warna isian efektif sumber sehingga ketiganya awalnya tampak identik. Memanggil [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) menetapkan nilai RGB tetap dan menghapus semua transformasi warna yang ada.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Referensi tema mengikuti warna aksen baru; nilai RGB tetap tidak mengikutinya.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sebelum perubahan tema, ketiga isian cocok:

![Source, copyFrom destination, and fixed RGB destination with identical blue fills](color-copy-before.png)

Setelah perubahan tema, sumber dan salinan yang menyadari tema mengikuti warna aksen baru dan mempertahankan tintnya. Salinan RGB tetap biru:

![Source and copyFrom destination with orange fills, while the fixed RGB destination remains blue](color-copy-after.png)

Definisi yang disalin bersifat independen dari sumber. Mengubah referensi tema sumber, menetapkan warna lain, atau menambah/menghapus transformasinya tidak mengubah tujuan. Perubahan tema tetap memengaruhi kedua bentuk karena masing‑masing merujuk secara independen ke warna tema yang sama.

Menyimpan dan membuka kembali PPTX mempertahankan tipe warna yang disalin yang dikembalikan oleh [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--) , referensi tema, dan koleksi transformasi yang dikembalikan oleh [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--) ; tidak meratakan definisi ke RGB.

Saat menyalin antar konteks tema yang berbeda, misalnya presentasi dengan palet aksen yang berbeda, referensi yang disalin akan diselesaikan terhadap tema tujuan. Referensi dan transformasi yang sama dapat menghasilkan warna tampak yang berbeda. Lihat [Presentation Theme](/slides/id/java/presentation-theme/) untuk lebih lanjut tentang mengonfigurasi warna tema.

## **Gunakan Latar Belakang Slide sebagai Isian Bentuk**

Gunakan [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) ketika bentuk harus cocok dengan latar belakang slide, misalnya dalam template presentasi. Tetapkan tipe isian dengan [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) ke [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) terlebih dahulu untuk menghapus isian eksplisit apa pun. Dengan kombinasi ini, bentuk menggunakan latar belakang slide alih‑alih isian gaya. Mengaktifkan flag saja tidak menghapus isian eksplisit yang ada.

Ini berbeda dari [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) : isian latar belakang menutupi objek di belakang bentuk dengan area latar belakang slide yang sesuai, sementara NoFill membiarkan objek tersebut terlihat. Gradasi tetap selaras dengan slide alih‑alih memulai ulang di dalam setiap bentuk.

Contoh berikut membuat latar belakang master yang diwarisi oleh slide dan menempatkan pita magenta di belakang tiga persegi panjang. Persegi panjang kiri menggunakan latar belakang, persegi panjang tengah tidak memiliki isian, dan persegi panjang kanan beralih dari isian latar belakang ke isian oranye eksplisit.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Warisi gradasi dari master.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Tambahkan objek ini terlebih dahulu agar muncul di belakang persegi panjang.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Nonaktifkan isian latar belakang sebelum menerapkan isian eksplisit.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil, dari kiri ke kanan: **background fill**, **no fill**, dan **explicit fill**. Pita magenta tersembunyi oleh persegi panjang kiri dan kanan tetapi tetap terlihat melalui persegi panjang tengah.

![Background fill, no fill, and explicit orange fill over a magenta band](background-fill.png)

Perilaku yang sama berlaku untuk latar belakang yang didefinisikan langsung pada slide atau diwarisi dari tata letak. Bentuk menggunakan latar belakang slide yang telah diselesaikan; contoh ini membiarkan latar belakang slide dan tata letak tidak ditetapkan sehingga master menyediakannya.

## **Atur Transparansi**

Untuk isian solid, komponen alfa warna mengontrol opasitas: 0 sepenuhnya transparan dan 255 sepenuhnya tidak transparan. Contoh ini menggunakan nilai alfa 128 untuk persegi panjang kuning, membuatnya kira‑kira 50 % transparan sehingga persegi panjang di bawahnya tetap terlihat. Warna ditetapkan melalui [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The transparent shape](shape-transparency.png)

## **Putar Bentuk**

Gunakan [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) untuk memutar bentuk pada bidang slide. Sudut diukur dalam derajat; contoh ini memutar persegi panjang 5 derajat searah jarum jam dan menyimpan presentasi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The shape rotation](shape-rotation.png)

## **Tambah Efek Bevel 3D**

Gunakan [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) untuk memberi bentuk kedalaman dan tepi bevel. Contoh ini membuat elips hijau dengan garis tepi oranye, menggunakan [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) untuk menetapkan kedalaman 4 poin, dan menerapkan bevel atas melingkar dengan lebar dan tinggi 6 poin melalui [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) . Kamera ortografik menghadap depan dan pencahayaan tiga titik membuat bevel terlihat.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The 3D bevel effect](3D-bevel-effect.png)

## **Tambah Efek Rotasi 3D**

Tampilan 3D bentuk dikendalikan oleh pengaturan kamera. Contoh ini menggunakan [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) dengan sudut lintang, bujur, dan revolusi masing‑masing 40, 35, dan 20 derajat. Ini memilih kamera isometrik melalui [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) dan pencahayaan seimbang melalui [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), lalu menyimpan persegi panjang yang diformat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![The 3D rotation effect](3D-rotation-effect.png)

## **Kontrol Rendering Hitam‑Putih untuk Bentuk**

Metode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) menentukan bagaimana bentuk individual dirender saat presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isian, garis, atau pemformatan lain bentuk dalam mode warna normal.

Gunakan nilai dari kelas [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` menggunakan hanya hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Contoh ini membuat persegi panjang oranye dan menggunakan [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) untuk menetapkan mode ke abu‑abu. Bentuk yang disimpan tetap berisi oranye untuk tampilan warna normal dan meminta pewarnaan abu‑abu dari aplikasi yang menghormati pengaturan tampilan hitam‑putih:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dalam mode warna normal, persegi panjang tetap berisi oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan pewarnaan abu‑abu karena berhasilannya diatur ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Setel Ulang Pemformatan**

Gunakan [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) untuk mengembalikan posisi, ukuran, dan pemformatan placeholder slide dari placeholder tata letak yang bersesuaian. Contoh ini memerlukan presentasi yang ada dengan placeholder yang ditautkan ke tata letak dan mereset setiap slide sebelum menyimpan. Bentuk tanpa placeholder tata letak yang bersesuaian tidak direset.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Warna, style garis, dan pengaturan efek umumnya menambah sedikit data dibandingkan gambar dan media yang disematkan. Isian gambar dapat meningkatkan ukuran file karena gambarnya disimpan dalam presentasi.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan kunci bentuk — isian, garis, dan pengaturan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk tersebut secara logis, yang mempermudah manajemen gaya kemudian.

**Bisakah saya menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam dek slide template atau file template .POTX. Saat membuat presentasi baru, buka template, kloning bentuk bergaya yang Anda perlukan, dan terapkan kembali pemformatannya di mana pun diperlukan.