---
title: Format Bentuk PowerPoint dalam JavaScript
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/nodejs-java/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isian gradien
- isian pola
- isian gambar
- isian tekstur
- isian warna padat
- transparansi bentuk
- rendering bentuk hitam-putih
- rendering bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam JavaScript menggunakan Aspose.Slides—atur isian, garis, dan gaya efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Format bentuk dalam PowerPoint dengan menyesuaikan garis luar, isian, dan efeknya. Aspose.Slides untuk Node.js via Java memungkinkan Anda mengontrol pengaturan ini secara programatik, termasuk transparansi, rotasi, dan pemformatan 3D.

![Opsi pemformatan bentuk di PowerPoint](format-shape-powerpoint.png)

Aspose.Slides untuk Node.js via Java menyediakan kelas dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Gunakan [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) untuk mengontrol garis luar sebuah bentuk. Contoh ini membuat persegi panjang tanpa isian dengan garis luar biru, bergaris putus-putus. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) memilih garis gabungan tebal–tipis, sementara [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) mengatur lebarnya menjadi 7 poin dan [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) memilih pola putus-putus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

### **Atur Pola Garis Putus-Putus Kustom**

Gunakan [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) ketika gaya garis bawaan tidak menyediakan panjang dash dan jeda yang Anda perlukan, misalnya untuk garis luar bermerek atau diagram teknik. Menetapkan pola secara otomatis mengubah gaya dash garis menjadi [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

Entri array bergantian antara panjang dash dan jeda, dimulai dengan dash. Setiap nilai merupakan kelipatan lebar garis: `[4, 2]` pada lebar 3 poin menghasilkan dash 12 poin diikuti jeda 6 poin. Gunakan pasangan nilai hingga tak berhingga, tidak negatif untuk mendefinisikan segmen dash‑dan‑jeda lengkap. Contoh ini menggunakan nilai positif agar setiap dash dan jeda terlihat.

Contoh ini membuat lima garis biru dengan panjang yang sama dan cap datar. Tiga pertama membandingkan pola pada lebar 3 poin. Yang keempat mengulangi pola pertama dengan lebar dua kali lipat, menggandakan panjang dash dan jeda. Yang kelima beralih dari pola kustom ke garis padat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // Kembalikan garis terakhir ke gaya padat.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk kembali ke gaya dash bawaan, beri [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) ke [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). Gaya yang dipilih mengontrol tampilan garis.

Hasil di PowerPoint, dari atas ke bawah: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; dan **Solid, 3 pt**.

![Tiga pola dash kustom, garis lebih lebar menggunakan pola pertama, dan garis padat di PowerPoint](custom-dash-patterns.png)

### **Atur Cap Garis**

Gunakan [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) untuk mengatur ujung garis terbuka. Kelas [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) menyediakan tiga gaya cap eksplisit:

- `Flat`: Coretan berhenti pada titik akhir.
- `Round`: Cap setengah lingkaran melampaui titik akhir setengah lebar garis.
- `Square`: Cap persegi melampaui titik akhir setengah lebar garis.

Kelas ini juga mencakup `NotDefined`, yang berarti tidak ada gaya cap yang ditetapkan secara eksplisit.

Cap berbeda dari tanda panah, yang menambahkan simbol pada ujung garis, dan sambungan, yang mengontrol sudut antara segmen garis. Contoh ini menonaktifkan tanda panah melalui [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) dan [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) sehingga hanya bentuk cap yang dibandingkan.

Contoh berikut membuat tiga garis horizontal yang pada dasarnya identik, lebar 20 poin. Dari atas ke bawah, mereka menggunakan cap flat, round, dan square. Titik ujung mereka memiliki koordinat horizontal yang sama; cap round dan square melampaui 10 poin di setiap ujung.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint, dari atas ke bawah: **Flat**, **Round**, dan **Square**.

![Cap flat, round, dan square pada garis tebal identik di PowerPoint](line-caps.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk tampak seperti digambar tangan. Gunakan [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) untuk mengakses pengaturan garis, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) untuk mengakses pengaturan sketsa, dan [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) untuk memilih nilai dari kelas [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Kode JavaScript berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Nilai yang dikembalikan oleh [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective), panggil `getSketchFormat` pada objek yang dikembalikan, lalu panggil metode `getSketchType`‑nya. Nilai efektif mencerminkan pemformatan yang benar‑benar diterapkan setelah pewarisan selesai. Contoh ini memerlukan presentasi yang sudah ada dengan setidaknya satu bentuk pada slide pertama dan mencetak kedua nilai:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Format Gaya Sambungan**

Berikut tiga pilihan tipe sambungan:

* Round
* Miter
* Bevel

Gaya sambungan mengontrol bagaimana dua segmen garis luar bertemu di sudut. Gunakan **Round** untuk sudut melengkung, **Miter** untuk sudut tajam, atau **Bevel** untuk sudut rata.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Contoh ini membuat tiga persegi panjang hitam dengan garis luar biru lebar 15 poin. Ia menggunakan [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) untuk menerapkan nilai miter, bevel, dan round dari [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/), masing‑masing, untuk membandingkan cara sudut digambar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Batasi Sambungan Miter pada Sudut Tajam**

Gunakan [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) bersama [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) yang disetel ke [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) untuk membatasi seberapa jauh sudut tajam dapat memperpanjang.

Batas tersebut adalah rasio antara jarak sudut dalam dan luar sambungan terhadap lebar garis. Misalnya, nilai `8` memperbolehkan panjang miter hingga delapan kali lebar garis; nilai ini bukan ukuran dalam poin. Jika sudut melebihi batas, PowerPoint menggunakan sambungan bevel pada sudut itu. Batas yang lebih besar memungkinkan titik yang lebih tajam. Pengaturan ini memengaruhi hanya sambungan miter, dan mengubahnya tidak memberi efek terlihat bila sudut masih berada dalam kedua batas.

Contoh ini membuat dua segitiga tidak berisi identik dengan garis luar lebar 20 poin. Segitiga kiri menggunakan batas `2`, dan kanan menggunakan `8`. Setiap segitiga berukuran 80 poin lebar dan 160 poin tinggi, memberi rasio panjang miter‑ke‑lebar‑garis pada sudut atas kira‑kira `4.12`. Akibatnya, PowerPoint memberi bevel pada puncak kiri dan mempertahankan puncak kanan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint: **Miter limit 2** di kiri dan **miter limit 8** di kanan.

![Puncak bevel dengan miter limit 2 dan puncak tajam dengan miter limit 8 di PowerPoint](miter-limits.png)

## **Isian Gradien**

Isian gradien mencampur warna di seluruh sebuah bentuk. Contoh ini mengisi elips dengan gradien linier pada sudut 45 derajat dari merah ke ungu menggunakan [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). Metode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) menempatkan titik henti warna pada 0 dan 1, awal dan akhir gradien. Menghapus titik henti yang ada memastikan hanya dua warna ini yang digunakan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Elips dengan isian gradien](gradient-fill.png)

Jika gradien terlihat berbeda dalam gambar yang diekspor dibandingkan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah isian gradien yang disimpan dalam presentasi.

### **Atur Sudut Gradien Linier**

Gunakan [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) untuk mengontrol orientasi isian [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/). Sudut diukur dalam derajat dan bertambah searah jarum jam: `0` berjalan dari kiri ke kanan, `90` dari atas ke bawah, `180` dari kanan ke kiri, dan `270` dari bawah ke atas. Sudut pecahan didukung. Sudut berhingga di luar `[0, 360)` dinormalisasi menjadi satu revolusi; misalnya, `-45` menjadi `315` dan `360` menjadi `0`.

Contoh ini membuat enam persegi panjang dengan titik henti merah, hijau, dan biru yang identik pada posisi `0`, `0.5`, dan `1`. Skala dinonaktifkan sehingga sudut dapat dibandingkan terlepas dari proporsi persegi panjang. Sudut, dari kiri ke kanan, adalah `0`, `45`, dan `90` pada baris pertama, serta `135`, `180`, dan `270` pada baris kedua.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint:

![Gradien linier pada 0, 45, dan 90 derajat di baris atas, serta 135, 180, dan 270 derajat di baris bawah](linear-gradient-angles.png)

### **Skalakan Gradien Linier dengan Bentuk**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) menerima nilai [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/). Atur secara eksplisit ke `False` untuk menjaga sudut gradien geometris saat proporsi bentuk berubah, atau ke `True` untuk menskalakan gradien bersama lebar dan tinggi bentuk. Dengan skala aktif, sudut yang terlihat dapat berbeda dari sudut yang ditetapkan pada bentuk yang tidak persegi.

Contoh berikut menggunakan sudut `45` derajat dan titik henti warna yang sama seperti perbandingan sudut. Kolom kiri menggunakan `False`; kolom kanan menggunakan `True`. Setiap kolom berisi persegi panjang lebar di atas persegi panjang tinggi. Kedua kolom dimulai dengan dimensi lebar yang sama; mengubah lebar dan tinggi persegi panjang kedua menunjukkan bagaimana isian merespons perubahan ukuran tanpa mengubah pengaturan gradien.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil di PowerPoint, dengan skala dinonaktifkan di kiri dan diaktifkan di kanan:

![Persegi panjang lebar dan tinggi dengan gradien 45 derajat, membandingkan LinearGradientScaled False di kiri dengan True di kanan](linear-gradient-scaling.png)

Dengan skala dinonaktifkan, pita warna diagonal tetap berorientasi sama di kedua persegi panjang. Dengan skala diaktifkan, pita meregang sesuai proporsi bentuk. Ini membantu mereproduksi gradien templat saat menyesuaikan bentuk ke ukuran berbeda. Pada bentuk persegi, mengaktifkan skala tidak mengubah tampilan gradien `45` derajat ini.

Baik sudut maupun pengaturan skala berlaku untuk gradien linier. Mereka tidak mengontrol isian [GradientShape.Radial atau GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/).

### **Gabungkan Sudut dengan Arah Gradien**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) memilih gaya gradien dari kelas [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/); ini bukan pengganti sudut numerik. Untuk gradien linier, gaya sudut dapat mengubah area distribusi warna tanpa mengubah sudut yang ditetapkan melalui [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle). Jaga arah tetap tidak berubah saat membandingkan sudut atau skala.

Contoh berikut menerapkan pengaturan yang sama dengan urutan terbalik. Kedua persegi panjang memiliki tampilan yang sama: menetapkan arah sebelum atau sesudah sudut tidak mengubah hasil.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Isian Pola**

Isian pola menerapkan desain dua warna, seperti titik, garis, atau kotak-kotak. Contoh ini menggunakan [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) untuk memilih pola trellis. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) menyediakan latar belakang abu‑abu muda, dan [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) menyediakan warna pola kuning.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Isian gambar menggunakan gambar di dalam bentuk. Contoh ini memerlukan gambar lokal dan menggunakan [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) untuk memuatnya ke dalam koleksi gambar presentasi. Menetapkan [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) ke mode ubin mengulang gambar di dalam persegi panjang. Gambar sumber yang digunakan ditampilkan di bawah:

![Gambar lotus](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk dengan isian gambar](picture-fill.png)

### **Ubin Gambar Sebagai Tekstur**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Menetapkan mode isian gambar—`Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Menentukan perataan ubin di dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Mendefinisikan skala horizontal ubin dalam persentase.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Mendefinisikan skala vertikal ubin dalam persentase.

Contoh ini memerlukan gambar lokal dan mengonfigurasi [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) untuk mengulangnya pada 50% ukuran aslinya. Offset ‑32 poin menggeser ubin secara horizontal dan vertikal; perataan kanan‑bawah dan pembalikan di kedua arah menentukan cara tekstur berulang disusun.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Opsi ubin](tile-options.png)

## **Isian Warna Padat**

Isian padat memberikan bentuk satu warna seragam. Contoh ini menggunakan [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) untuk memilih mode isian padat dan menetapkan warna kuning melalui [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor), lalu menyimpan persegi panjang dalam presentasi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk dengan isian warna padat](solid-color-fill.png)

### **Salin Warna Sambil Mempertahankan Referensi Tema**

Gunakan [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) untuk menyalin definisi warna, termasuk tipe warna, referensi tema, dan transformasinya. Ini berguna saat memindahkan warna isian antar bentuk yang harus tetap mengikuti tema presentasi. Metode ini hanya menyalin warna: tidak menyalin tipe isian, garis luar, atau pemformatan bentuk lainnya. Tetapkan tipe isian tujuan secara eksplisit dengan [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType).

Contoh ini membuat tiga persegi panjang, dari kiri ke kanan: sumber, salinan yang menyadari tema, dan salinan RGB tetap. Sumber menggunakan [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) untuk merujuk ke warna aksen pertama dan menambah tint melalui [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add). Salinan RGB menggunakan warna isian efektif sumber sehingga ketiganya awalnya tampak identik. Memanggil [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) menetapkan nilai RGB tetap dan menghapus setiap transformasi warna yang ada.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Referensi tema mengikuti warna aksen baru; nilai RGB tetap tidak mengikutinya.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sebelum perubahan tema, ketiga isian cocok:

![Sumber, tujuan copyFrom, dan tujuan RGB tetap dengan isian biru identik](color-copy-before.png)

Setelah perubahan tema, sumber dan salinan yang menyadari tema mengikuti warna aksen baru dan mempertahankan tintnya. Salinan RGB tetap biru:

![Sumber dan tujuan copyFrom dengan isian oranye, sementara tujuan RGB tetap biru](color-copy-after.png)

Definisi yang disalin bersifat independen dari sumber. Mengubah referensi tema sumber, menetapkan warna lain, atau menambah atau menghapus transformasinya tidak mengubah tujuan. Perubahan tema tetap memengaruhi kedua bentuk karena masing‑masing merujuk pada warna tema yang sama.

Menyimpan dan membuka kembali PPTX mempertahankan tipe warna yang disalin yang dikembalikan oleh [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType), referensi tema, dan koleksi transformasi yang dikembalikan oleh [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform); tidak mengubah definisi menjadi RGB.

Saat menyalin antara konteks tema yang berbeda, misalnya presentasi dengan palet aksen yang berbeda, referensi yang disalin akan diselesaikan terhadap tema tujuan. Referensi dan transformasi yang sama dapat menghasilkan warna terlihat yang berbeda. Lihat [Presentation Theme](/slides/id/nodejs-java/presentation-theme/) untuk info lebih lanjut tentang mengonfigurasi warna tema.

## **Gunakan Latar Belakang Slide sebagai Isian Bentuk**

Gunakan [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) ketika sebuah bentuk harus cocok dengan latar belakang slide, misalnya dalam templat presentasi. Tetapkan tipe isian dengan [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) ke [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) terlebih dahulu untuk menghapus isian eksplisit apa pun. Dengan kombinasi ini, bentuk menggunakan latar belakang slide alih-alih isian gaya sendiri. Mengaktifkan flag saja tidak menghapus isian eksplisit yang ada.

Ini berbeda dari [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): isian latar belakang menutupi objek di belakang bentuk dengan area latar belakang slide yang bersesuaian, sementara NoFill membiarkan objek tersebut terlihat. Gradien tetap selaras dengan slide alih-alih memulai ulang di dalam setiap bentuk.

Contoh berikut membuat latar belakang master yang diwarisi oleh slide dan menempatkan pita magenta di belakang tiga persegi panjang. Persegi panjang kiri menggunakan latar belakang, yang tengah tidak memiliki isian, dan yang kanan beralih dari isian latar belakang ke isian oranye eksplisit.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // Wariskan gradien dari master.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // Tambahkan objek ini terlebih dahulu sehingga muncul di belakang persegi panjang.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // Nonaktifkan isian latar belakang sebelum menerapkan isian eksplisit.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil, dari kiri ke kanan: **isian latar belakang**, **tanpa isian**, dan **isian eksplisit**. Pita magenta disembunyikan oleh persegi panjang kiri dan kanan tetapi tetap terlihat melalui persegi panjang tengah.

![Isian latar belakang, tanpa isian, dan isian oranye eksplisit di atas pita magenta](background-fill.png)

Perilaku yang sama berlaku untuk latar belakang yang didefinisikan langsung pada slide atau diwarisi dari layout. Bentuk menggunakan latar belakang slide yang telah di‑resolve; contoh ini membiarkan latar belakang slide dan layout tidak terdefinisi sehingga master menyediakannya.

## **Atur Transparansi**

Untuk isian padat, komponen alfa warna mengontrol opasitas: 0 sepenuhnya transparan dan 255 sepenuhnya buram. Contoh ini menggunakan nilai alfa 128 untuk persegi panjang kuning, menjadikannya kira‑kira 50 % transparan sehingga persegi panjang di bawahnya tetap terlihat. Warna ditetapkan melalui [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Gunakan [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) untuk memutar bentuk pada bidang slide. Sudut diukur dalam derajat; contoh ini memutar persegi panjang 5 derajat searah jarum jam dan menyimpan presentasi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) untuk memberi kedalaman dan tepi bevel pada bentuk. Contoh ini membuat elips hijau dengan garis luar oranye, menggunakan [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) untuk mengatur kedalaman menjadi 4 poin, dan menerapkan bevel atas melingkar dengan lebar dan tinggi 6 poin melalui [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop). Kamera ortografik menghadap depan dan pencahayaan tiga‑titik membuat bevel terlihat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Tampilan 3D sebuah bentuk dikendalikan oleh pengaturan kameranya. Contoh ini menggunakan [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) dengan sudut lintang, bujur, dan revolusi masing‑masing 40, 35, dan 20 derajat. Ia memilih kamera isometrik melalui [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) dan pencahayaan seimbang melalui [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType), lalu menyimpan persegi panjang yang diformat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Kontrol Rendering Hitam‑Putih untuk Bentuk**

Metode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) menentukan bagaimana bentuk individu dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isian, garis, atau pemformatan lain bentuk dalam mode warna normal.

Gunakan nilai dari kelas [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Contoh ini membuat persegi panjang oranye dan menggunakan [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) untuk memilih pewarnaan abu‑abu. Bentuk yang disimpan mempertahankan isian oranye untuk tampilan warna normal dan meminta pewarnaan abu‑abu dari aplikasi yang menghormati pengaturan tampilan hitam‑putih:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dalam mode warna normal, persegi panjang mempertahankan isian oranyenya. Dalam alur kerja tampilan hitam‑putih, ia menggunakan pewarnaan abu‑abu karena mode diatur ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil menentukan tampilan berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Setel Ulang Pemformatan**

Gunakan [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) untuk mengembalikan posisi, ukuran, dan pemformatan placeholder slide dari placeholder layout yang bersesuaian. Contoh ini memerlukan presentasi yang sudah ada dengan placeholder terkait layout dan mereset setiap slide sebelum menyimpan. Bentuk tanpa placeholder layout yang bersesuaian tidak direset.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Warna, gaya garis, dan pengaturan efek umumnya menambahkan data sedikit dibandingkan gambar dan media yang disematkan. Isian gambar dapat meningkatkan ukuran file karena gambar mereka disimpan dalam presentasi.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan kunci bentuk—isi, garis, dan pengaturan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan manajemen gaya di kemudian hari.

**Bisakah saya menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan ulang di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam templat slide deck atau file templat .POTX. Saat membuat presentasi baru, buka templat, kloning bentuk bergaya yang Anda butuhkan, dan terapkan kembali pemformatannya di mana diperlukan.