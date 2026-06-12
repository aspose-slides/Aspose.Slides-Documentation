---
title: Menerapkan Efek Bentuk dalam Presentasi di Android
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/androidjava/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek glow
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk Android melalui Java—buat slide yang menakjubkan dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk membuat sebuah bentuk menonjol, mereka berbeda dari [fills](/slides/id/androidjava/shape-formatting/#gradient-fill) atau outline. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

<img src="shape-effect.png" alt="efek-bentuk" style="zoom:50%;" />

* PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk. 

* Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint memiliki opsi di bawah **Preset**. Opsi Preset pada dasarnya merupakan kombinasi yang sudah terbukti tampak bagus dari dua atau lebih efek. Dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang baik.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/EffectFormat) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Terapkan Efek Bayangan**

Kode Java berikut menunjukkan cara menerapkan efek bayangan luar ([OuterShadowEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) pada sebuah persegi panjang:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Terapkan Efek Refleksi**

Kode Java berikut menunjukkan cara menerapkan efek refleksi pada sebuah bentuk:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Terapkan Efek Glow**

Kode Java berikut menunjukkan cara menerapkan efek glow pada sebuah bentuk:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Terapkan Efek Tepi Lembut**

Kode Java berikut menunjukkan cara menerapkan tepi lembut pada sebuah bentuk:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan glow, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, chart, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.