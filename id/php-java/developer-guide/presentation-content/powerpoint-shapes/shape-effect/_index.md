---
title: Menerapkan Efek Bentuk dalam Presentasi Menggunakan PHP
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/php-java/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek pantulan
- efek cahaya
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk PHP via Java — buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan suatu bentuk, efek tersebut berbeda dari [isian](/slides/id/php-java/shape-formatting/#gradient-fill) atau kontur. Dengan menggunakan efek PowerPoint, Anda dapat membuat pantulan yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk. 

* Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Untuk alasan ini, terdapat pilihan **Preset** di PowerPoint. Opsi Preset pada dasarnya adalah kombinasi dua atau lebih efek yang sudah terbukti terlihat baik. Dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang tepat.

Aspose.Slides menyediakan properti dan metode pada kelas [EffectFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/EffectFormat) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Kode PHP berikut menunjukkan cara menerapkan efek bayangan luar ([OuterShadowEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) pada sebuah persegi panjang:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menerapkan Efek Pantulan**

Kode PHP berikut menunjukkan cara menerapkan efek pantulan pada sebuah bentuk:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menerapkan Efek Cahaya**

Kode PHP berikut menunjukkan cara menerapkan efek cahaya pada sebuah bentuk:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menerapkan Efek Tepi Lembut**

Kode PHP berikut menunjukkan cara menerapkan efek tepi lembut pada sebuah bentuk:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, pantulan, dan cahaya, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa saja yang dapat saya beri efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, grafik, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.