---
title: Format Bentuk PowerPoint di Android
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/androidjava/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isi gradien
- isi pola
- isi gambar
- isi tekstur
- isi warna solid
- transparansi bentuk
- rendering bentuk hitam-putih
- rendering bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint di Android menggunakan Aspose.Slides—atur gaya isi, garis, dan efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Format bentuk di PowerPoint dengan menyesuaikan garis tepinya, isian, dan efeknya. Aspose.Slides untuk Android via Java memungkinkan Anda mengontrol pengaturan ini secara programatik, termasuk transparansi, rotasi, dan pemformatan 3D.

![Opsi pemformatan bentuk di PowerPoint](format-shape-powerpoint.png)

Aspose.Slides untuk Android via Java menyediakan antarmuka dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Gunakan [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) untuk mengontrol garis tepi sebuah bentuk. Contoh ini membuat persegi panjang tanpa isi dengan garis luar biru bergaris putus-putus. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) memilih garis gabungan tebal‑tipis, sementara [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) mengatur lebarnya menjadi 7 poin dan [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) memilih pola garis putus‑putus.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

### **Atur Pola Garis Putus Kustom**

Gunakan [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) ketika gaya garis yang telah ditentukan tidak menyediakan panjang dash dan celah yang Anda butuhkan, misalnya untuk garis tepi bermerek atau diagram teknik. Menetapkan pola secara otomatis mengubah gaya dash garis menjadi [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Entri array bergantian antara panjang dash dan celah, dimulai dengan dash. Setiap nilai merupakan kelipatan lebar garis: `{ 4, 2 }` pada lebar 3 poin menghasilkan dash 12‑point diikuti celah 6‑point. Gunakan pasangan nilai terbatas, tidak negatif untuk mendefinisikan segmen dash‑dan‑celah lengkap. Contoh ini menggunakan nilai positif agar setiap dash dan celah terlihat.

Contoh ini membuat lima garis biru dengan panjang yang sama dan cap datar. Tiga pertama membandingkan pola pada lebar 3 poin. Yang keempat mengulang pola pertama dengan lebar dua kali lipat, menggandakan panjang dash dan celah. Yang kelima beralih dari pola kustom ke garis padat.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Kembalikan garis terakhir ke gaya padat.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk kembali ke gaya dash yang telah ditentukan, berikan [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) ke [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). Gaya yang dipilih mengontrol tampilan garis.

Hasilnya di PowerPoint, dari atas ke bawah: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; dan **Solid, 3 pt**.

![Tiga pola dash kustom, sebuah garis lebih lebar menggunakan pola pertama, dan garis padat di PowerPoint](custom-dash-patterns.png)

### **Atur Penutup Garis**

Gunakan [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) untuk mengatur ujung sebuah garis terbuka. Kelas [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) menyediakan tiga gaya cap eksplisit:

- `Flat`: Garis berhenti pada titik akhir.
- `Round`: Penutup setengah lingkaran melampaui titik akhir sejauh setengah lebar garis.
- `Square`: Penutup kotak melampaui titik akhir sejauh setengah lebar garis.

Kelas juga mencakup `NotDefined`, yang berarti tidak ada gaya cap yang secara eksplisit ditetapkan.

Cap berbeda dari kepala panah, yang menambahkan simbol pada ujung garis, dan sambungan, yang mengontrol sudut antara segmen garis. Contoh ini menonaktifkan kepala panah melalui [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) dan [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) sehingga hanya bentuk cap yang dibandingkan.

Contoh berikut membuat tiga garis horizontal yang pada dasarnya identik, lebar 20 poin. Dari atas ke bawah, mereka menggunakan cap flat, round, dan square. Titik akhir mereka memiliki koordinat horizontal yang sama; cap round dan square meluas 10 poin di luar setiap titik akhir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Hasilnya di PowerPoint, dari atas ke bawah: **Flat**, **Round**, dan **Square**.

![Flat, round, dan square caps pada garis tebal identik di PowerPoint](line-caps.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat digambar tangan. Gunakan [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) untuk mengakses pengaturan garis, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) untuk mengakses pengaturan sketsa, dan [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) untuk memilih nilai dari kelas [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Kode Java berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

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

Nilai yang dikembalikan oleh [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), akses [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), dan baca [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan. Contoh ini memerlukan presentasi yang sudah ada dengan setidaknya satu bentuk pada slide pertama dan mencetak kedua nilai:

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

Gaya sambungan mengontrol bagaimana dua segmen garis bertemu pada sudut. Gunakan **Round** untuk sudut melengkung, **Miter** untuk sudut tajam, atau **Bevel** untuk sudut rata.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Contoh ini membuat tiga persegi panjang hitam dengan garis luar biru lebar 15 poin. Ia menggunakan [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) untuk menerapkan nilai miter, bevel, dan round dari [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/), masing‑masing, untuk membandingkan bagaimana sudut digambar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Gunakan [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) bersama [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) yang diatur ke [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) untuk membatasi sejauh mana sudut tajam dapat memperluas.

Batas merupakan rasio jarak antara sudut dalam dan luar sambungan terhadap lebar garis. Misalnya, nilai `8` memungkinkan panjang miter hingga delapan kali lebar garis; itu bukan ukuran dalam poin. Jika sudut melampaui batas, PowerPoint menggunakan sambungan bevel pada sudut tersebut. Batas yang lebih besar memungkinkan titik lebih tajam. Pengaturan ini hanya memengaruhi sambungan miter, dan mengubahnya tidak menghasilkan efek terlihat ketika sudut tetap berada dalam kedua batas.

Contoh ini membuat dua segitiga tidak terisi identik dengan garis luar lebar 20 poin. Segitiga kiri menggunakan batas `2`, dan kanan menggunakan `8`. Setiap segitiga lebar 80 poin dan tinggi 160 poin, memberikan rasio panjang miter‑ke‑lebar‑garis pada sudut atas sekitar `4.12`. Akibatnya, PowerPoint memotong puncak kiri dan mempertahankan puncak kanan.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya di PowerPoint: **Batas miter 2** di kiri dan **batas miter 8** di kanan.

![Puncak bevel dengan batas miter 2 dan puncak runcing dengan batas miter 8 di PowerPoint](miter-limits.png)

## **Isi Gradien**

Gradien menggabungkan warna melintasi sebuah bentuk. Contoh ini mengisi elips dengan gradien linear pada sudut 45‑derajat dari merah ke ungu menggunakan [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). Metode [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) menempatkan warna berhenti pada 0 dan 1, awal dan akhir gradien. Menghapus berhenti yang ada memastikan hanya dua warna ini yang digunakan.

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

Hasilnya:

![Elips dengan isi gradien](gradient-fill.png)

Jika gradien terlihat berbeda pada gambar yang diekspor dibandingkan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah isi gradien yang disimpan dalam presentasi.

### **Atur Sudut Gradien Linear**

Gunakan [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) untuk mengontrol orientasi isi [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). Sudut diukur dalam derajat dan meningkat searah jarum jam: `0` berjalan dari kiri ke kanan, `90` dari atas ke bawah, `180` dari kanan ke kiri, dan `270` dari bawah ke atas. Sudut pecahan didukung. Sudut finitas di luar `[0, 360)` dinormalkan menjadi satu putaran; misalnya, `-45` menjadi `315` dan `360` menjadi `0`.

Contoh ini membuat enam persegi panjang dengan warna merah, hijau, dan biru identik pada posisi `0`, `0.5`, dan `1`. Skala dinonaktifkan agar sudut dapat dibandingkan terlepas dari proporsi persegi panjang. Sudut, dari kiri ke kanan, adalah `0`, `45`, dan `90` pada baris pertama, serta `135`, `180`, dan `270` pada baris kedua.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Hasilnya di PowerPoint:

![Gradien linear pada 0, 45, dan 90 derajat di baris atas, dan 135, 180, dan 270 derajat di baris bawah](linear-gradient-angles.png)

### **Skala Gradien Linear dengan Bentuk**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) menerima nilai [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Tetapkan secara eksplisit ke `False` agar sudut gradien geometris tetap sama saat proporsi bentuk berubah, atau ke `True` agar gradien berskala dengan lebar dan tinggi bentuk. Dengan skala diaktifkan, sudut yang terlihat dapat berbeda dari sudut yang ditetapkan pada bentuk yang tidak berbentuk persegi.

Contoh berikut menggunakan sudut `45`‑derajat dan warna berhenti yang sama seperti perbandingan sudut. Kolom kiri menggunakan `False`; kolom kanan menggunakan `True`. Setiap kolom berisi persegi panjang lebar di atas persegi panjang tinggi. Keduanya memulai dengan dimensi lebar yang sama; mengubah lebar dan tinggi persegi panjang kedua menunjukkan bagaimana isi merespons perubahan ukuran tanpa mengubah pengaturan gradien.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Hasilnya di PowerPoint, dengan skala dinonaktifkan di kiri dan diaktifkan di kanan:

![Persegi panjang lebar dan tinggi dengan gradien 45‑derajat, membandingkan LinearGradientScaled False di kiri dengan True di kanan](linear-gradient-scaling.png)

Dengan skala dinonaktifkan, pita warna diagonal tetap memiliki orientasi yang sama pada kedua persegi panjang. Dengan skala diaktifkan, pita tersebut meregang sesuai proporsi bentuk. Ini membantu mereproduksi gradien templat saat menyesuaikan bentuk ke ukuran berbeda. Pada bentuk persegi, mengaktifkan skala tidak mengubah tampilan gradien `45`‑derajat ini.

Baik sudut maupun pengaturan skala berlaku untuk gradien linear. Mereka tidak mengontrol isi [GradientShape.Radial atau GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **Gabungkan Sudut dengan Arah Gradien**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) memilih gaya gradien dari kelas [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/); itu bukan pengganti sudut numerik. Untuk gradien linear, gaya sudut dapat mengubah area distribusi warna tanpa mengubah sudut yang ditetapkan melalui [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Jaga arah tetap tidak berubah saat membandingkan sudut atau skala.

Contoh berikut menerapkan pengaturan yang sama dalam urutan berlawanan. Kedua persegi panjang memiliki tampilan yang sama: menetapkan arah sebelum atau sesudah sudut tidak mengubah hasil.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Isi Pola**

Isi pola menerapkan desain dua‑warna, seperti titik, garis, atau ceklis. Contoh ini menggunakan [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) untuk memilih pola trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) menyediakan latar belakang abu‑abu terang, dan [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) menyediakan warna pola kuning.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Persegi panjang dengan isi pola](pattern-fill.png)

## **Isi Gambar**

Isi gambar menggunakan gambar di dalam sebuah bentuk. Contoh ini memerlukan gambar lokal dan menggunakan [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) untuk memuatnya ke dalam koleksi gambar presentasi. Menetapkan [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) ke mode ubin mengulangi gambar di dalam persegi panjang. Gambar sumber yang digunakan ditampilkan di bawah:

![Gambar lotus](lotus.png)

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

Hasilnya:

![Bentuk dengan isi gambar](picture-fill.png)

### **Utile Gambar Sebagai Tekstur**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Menetapkan mode isi gambar — `Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Menentukan perataan ubin di dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Mendefinisikan skala horizontal ubin sebagai persentase.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Mendefinisikan skala vertikal ubin sebagai persentase.

Contoh ini memerlukan gambar lokal dan mengkonfigurasi [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) untuk mengulangnya pada 50 % ukuran aslinya. Offset −32 poin menggeser ubin secara horizontal dan vertikal; perataan kanan‑bawah dan pembalikan pada kedua arah menentukan bagaimana tekstur berulang diatur.

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

Hasilnya:

![Opsi ubin](tile-options.png)

## **Isi Warna Solid**

Isi solid memberikan bentuk satu warna seragam. Contoh ini menggunakan [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) untuk memilih mode isi solid dan menetapkan warna kuning melalui [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), lalu menyimpan persegi panjang dalam sebuah presentasi.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Hasilnya:

![Bentuk dengan isi warna solid](solid-color-fill.png)

### **Salin Warna Sambil Mempertahankan Referensi Tema**

Gunakan [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) untuk menyalin definisi warna, termasuk tipe warna, referensi tema, dan transformasi. Ini berguna saat mentransfer warna isi antara bentuk yang harus tetap mengikuti tema presentasi. Metode ini hanya menyalin warnanya: tidak menyalin tipe isi, garis luar, atau pemformatan bentuk lain. Tetapkan tipe isi tujuan secara eksplisit dengan [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-).

Contoh ini membuat tiga persegi panjang, dari kiri ke kanan: sumber, salinan sadar tema, dan salinan RGB tetap. Sumber menggunakan [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) untuk merujuk ke warna aksen pertama dan menambahkan tint melalui [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-). Salinan RGB menggunakan warna isi efektif sumber sehingga ketiganya pada awalnya tampak identik. Memanggil [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) menetapkan nilai RGB tetap dan menghapus semua transformasi warna yang ada.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

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

    // Referensi tema mengikuti warna aksen baru; nilai RGB tetap tidak berubah.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

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

Sebelum perubahan tema, ketiga isi cocok:

![Sumber, tujuan copyFrom, dan tujuan RGB tetap dengan isi biru identik](color-copy-before.png)

Setelah perubahan tema, sumber dan salinan sadar tema mengikuti warna aksen baru dan mempertahankan tintnya. Salinan RGB tetap biru:

![Sumber dan tujuan copyFrom dengan isi oranye, sementara tujuan RGB tetap biru](color-copy-after.png)

Definisi yang disalin bersifat independen dari sumber. Mengubah referensi tema sumber, menetapkan warna lain, atau menambah/menghapus transformasinya tidak mengubah tujuan. Perubahan tema tetap memengaruhi kedua bentuk karena masing‑masing tetap merujuk ke warna tema yang sama.

Menyimpan dan membuka kembali PPTX mempertahankan tipe warna yang disalin yang dikembalikan oleh [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--), referensi tema, dan koleksi transformasi yang dikembalikan oleh [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--); tidak mengubah definisi menjadi RGB.

Saat menyalin antar konteks tema yang berbeda, seperti presentasi dengan palet aksen berbeda, referensi yang disalin akan diselesaikan terhadap tema tujuan. Referensi dan transformasi yang sama dapat menghasilkan warna tampak yang berbeda. Lihat [Presentation Theme](/slides/id/androidjava/presentation-theme/) untuk informasi lebih lanjut tentang mengkonfigurasi warna tema.

## **Gunakan Latar Slide sebagai Isi Bentuk**

Gunakan [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) ketika sebuah bentuk harus mencocokkan latar slide, misalnya dalam templat presentasi. Tetapkan tipe isi dengan [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) ke [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) terlebih dahulu untuk menghapus isi eksplisit apa pun. Dengan kombinasi ini, bentuk menggunakan latar slide alih‑alih isi gaya. Mengaktifkan flag saja tidak menghapus isi eksplisit yang ada.

Ini berbeda dari [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): isi latar menutupi objek di belakang bentuk dengan area latar slide yang bersesuaian, sementara tanpa isi objek‑objek tersebut tetap terlihat. Gradien tetap selaras dengan slide bukan dimulai kembali di dalam setiap bentuk.

Contoh berikut membuat latar master yang diwarisi oleh slide dan menempatkan pita magenta di belakang tiga persegi panjang. Persegi panjang kiri menggunakan latar, persegi panjang tengah tidak memiliki isi, dan persegi panjang kanan beralih dari isi latar ke isi oranye eksplisit.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Warisi gradien dari master.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // Tambahkan objek ini terlebih dahulu supaya muncul di belakang persegi panjang.
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

    // Nonaktifkan isi latar sebelum menerapkan isi eksplisit.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya, dari kiri ke kanan: **isi latar**, **tanpa isi**, dan **isi eksplisit**. Pita magenta tersembunyi oleh persegi panjang kiri dan kanan tetapi tetap terlihat melalui persegi panjang tengah.

![Isi latar, tanpa isi, dan isi oranye eksplisit di atas pita magenta](background-fill.png)

Perilaku yang sama berlaku untuk latar yang didefinisikan langsung pada slide atau diwarisi dari layout. Bentuk menggunakan latar slide yang sudah diresolusikan; contoh ini membiarkan latar slide dan layout tidak didefinisikan sehingga master menyediakannya.

## **Atur Transparansi**

Untuk isi solid, komponen alfa warna mengontrol opasitas: 0 sepenuhnya transparan dan 255 sepenuhnya opaik. Contoh ini menggunakan nilai alfa 128 untuk persegi panjang kuning, menjadikannya kira‑kira 50 % transparan sehingga persegi panjang di bawahnya tetap terlihat. Warna ditetapkan melalui [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Gunakan [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) untuk memutar sebuah bentuk dalam bidang slide. Sudut diukur dalam derajat; contoh ini memutar persegi panjang 5 derajat searah jarum jam dan menyimpan presentasi.

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

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Gunakan [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) untuk memberikan kedalaman dan tepi bevel pada sebuah bentuk. Contoh ini membuat elips hijau dengan garis luar oranye, menggunakan [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) untuk mengatur kedalaman menjadi 4 poin, dan menerapkan bevel atas melingkar dengan lebar dan tinggi 6 poin melalui [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). Kamera ortografik menghadap depan dan pencahayaan tiga titik membuat bevel terlihat.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
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

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Tampilan 3D sebuah bentuk dikontrol oleh pengaturan kameranya. Contoh ini menggunakan [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) dengan sudut lintang, bujur, dan revolusi masing‑masing 40, 35, dan 20 derajat. Ia memilih kamera isometrik melalui [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) dan pencahayaan seimbang melalui [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), lalu menyimpan persegi panjang yang telah diformat.

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

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Kontrol Rendering Hitam-Putih untuk Bentuk**

Metode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) menentukan bagaimana sebuah bentuk dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isi, garis, atau pemformatan bentuk lain dalam mode warna normal.

Gunakan nilai dari kelas [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode pada tingkat bentuk yang ditetapkan.

Contoh ini membuat persegi panjang oranye dan menggunakan [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) untuk memilih warna abu‑abu. Bentuk yang disimpan mempertahankan isi oranye untuk tampilan warna normal dan meminta warna abu‑abu dari aplikasi yang menghormati pengaturan tampilan hitam‑putih:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dalam mode warna normal, persegi panjang tetap berisi oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan warna abu‑abu karena modenya disetel ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Atur Ulang Pemformatan**

Gunakan [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) untuk memulihkan posisi, ukuran, dan pemformatan placeholder slide dari placeholder layout yang bersesuaian. Contoh ini memerlukan presentasi yang sudah ada dengan placeholder yang terhubung ke layout dan mengatur ulang setiap slide sebelum menyimpan. Bentuk tanpa placeholder layout yang bersesuaian tidak diatur ulang.

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

Warna, gaya garis, dan pengaturan efek umumnya menambah data sedikit dibandingkan dengan gambar dan media yang disematkan. Isi gambar dapat meningkatkan ukuran file karena gambar disimpan dalam presentasi.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan kunci bentuk—isi, garis, dan pengaturan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan manajemen gaya selanjutnya.

**Bisakah saya menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan bentuk contoh dengan gaya yang diinginkan dalam deck slide templat atau file .POTX. Saat membuat presentasi baru, buka templat, klon bentuk bergaya yang Anda perlukan, dan terapkan kembali pemformatannya di mana diperlukan.