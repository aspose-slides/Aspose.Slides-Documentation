---
title: Menerapkan Efek Bentuk dalam Presentasi Menggunakan JavaScript
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/nodejs-java/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek kilau
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk canggih menggunakan JavaScript dan Aspose.Slides untuk Node.js—buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk membuat sebuah bentuk menonjol, mereka berbeda dari [isi](/slides/id/nodejs-java/shape-formatting/#gradient-fill) atau outline. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

![Efek Bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint menyediakan opsi di bawah **Preset**. Opsi Preset adalah kombinasi dua atau lebih efek yang diketahui terlihat bagus. Dengan cara ini, dengan memilih sebuah preset, Anda tidak perlu membuang waktu untuk menguji atau menggabungkan efek berbeda guna menemukan kombinasi yang bagus.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Terapkan Efek Bayangan**

Aspose.Slides untuk Node.js via Java mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan jari-jari blur mereka agar sesuai dengan desain presentasi Anda.

### **Terapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol pada latar belakang slide. Bayangan meluas di luar tepi bentuk, menciptakan kesan bahwa bentuk tersebut terangkat di atas slide. Sesuaikan warna, arah, jarak, dan jari-jari blur-nya agar cocok dengan pencahayaan dan gaya templat Anda.

Kode JavaScript ini menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) pada sebuah persegi panjang:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek Bayangan](shadow_effect.png)

### **Terapkan Bayangan Dalam**

Saat mereproduksi gaya visual templat, gunakan bayangan dalam untuk memberikan kartu atau panel tampilan yang tertekan. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sedangkan bayangan dalam memberi bayangan pada bagian dalam tepinya.

Panggil [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), kemudian atur bayangan yang dikembalikan oleh [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Nilai jari-jari blur yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh JavaScript ini membuat kartu biru muda dengan bayangan dalam abu-abu gelap dan menyimpannya sebagai file PPTX. Arah bayangan adalah 225 derajat, jaraknya 7 poin, dan jari-jari blur-nya 6 poin:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) pada format efek bentuk.

## **Terapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides untuk Node.js via Java, Anda dapat menambahkan refleksi seperti cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan canggih. Mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode JavaScript ini menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) pada sebuah bentuk:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek Refleksi](reflection_effect.png)

## **Terapkan Efek Kilau**

Untuk menerapkan efek kilau pada sebuah bentuk di Aspose.Slides untuk Node.js via Java, Anda dapat menambahkan aura lembut dan bercahaya di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu membuat bentuk menonjol dan menambahkan elemen visual yang menarik dan mencolok pada presentasi Anda. Mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode JavaScript ini menunjukkan cara menerapkan [efek kilau](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) pada sebuah bentuk:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek Kilau](glow_effect.png)

## **Terapkan Efek Tepian Lembut**

Untuk menerapkan efek tepi lembut di Aspose.Slides untuk Node.js via Java, Anda dapat menciptakan transisi halus dan kabur di sekitar tepi sebuah bentuk. Efek ini menambahkan tampilan yang lebih halus dan halus, cocok untuk desain yang membutuhkan penampilan lembut dan menenangkan. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode JavaScript ini menunjukkan cara menerapkan [efek tepi lembut](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) pada sebuah bentuk:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek Tepi Lembut](soft_edges_effect.png)

## **Terapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isi dan garis tepi bentuk sekaligus tetap dapat diedit. Panggil [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai non-negatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah tampilan.

Pengaturan [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) mengontrol batas tampak efek. Dengan `false`, blur dipotong pada batas asli yang digambar, termasuk outline. Dengan `true`, blur dapat meluas melampaui batas tersebut. Kedua pengaturan tidak mengubah posisi atau dimensi bentuk.

Perbandingan di bawah menggunakan isi, outline, dan dimensi bentuk yang sama sepanjang waktu. Baris atas menggunakan `grow = false`; baris bawah menggunakan `grow = true`.

![Persegi panjang asli dibandingkan dengan radius blur 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh JavaScript ini membuat persegi panjang oranye dengan outline biru gelap, menerapkan blur 5 poin, kemudian memperbaruinya menjadi blur 15 poin dengan memanggil [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) lagi. Ia menyimpan kedua keadaan blur, kemudian memanggil [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) dan menyimpan bentuk tanpa blur.
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Blur bentuk memengaruhi isi dan outline secara bersamaan. Efek tepi lembut memudarkan tepi bentuk, sementara blur bayangan melunakkan hanya bayangan. Efek transformasi gambar beroperasi pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan efek berbeda, seperti bayangan, refleksi, dan kilau, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, diagram, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.