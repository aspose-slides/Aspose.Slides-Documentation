---
title: Terapkan Efek Bentuk dalam Presentasi Menggunakan PHP
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/php-java/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek glow
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk PHP via Java—buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, ia berbeda dari [fills](/slides/id/php-java/shape-formatting/#gradient-fill) atau outline. Dengan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan glow pada bentuk, dll.

![Shape effect](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint menyediakan opsi di bawah **Preset**. Opsi Preset adalah kombinasi dua atau lebih efek yang diketahui menghasilkan tampilan yang baik. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang bagus.

Aspose.Slides menyediakan properti dan metode di kelas [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Aspose.Slides untuk PHP via Java mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur-nya agar cocok dengan desain presentasi Anda.

### **Menerapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol di latar belakang slide. Bayangan ini meluas di luar tepi bentuk, menciptakan kesan bahwa bentuk terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur-nya agar cocok dengan pencahayaan dan gaya templat Anda.

Kode PHP berikut menunjukkan cara menerapkan [outer shadow effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) pada sebuah persegi panjang:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Shadow effect](shadow_effect.png)

### **Menerapkan Bayangan Dalam**

Saat meniru gaya visual templat, gunakan bayangan dalam untuk memberi kartu atau panel tampilan terukir. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sedangkan bayangan dalam memberi bayangan pada sisi dalam tepinya.

Panggil [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), lalu konfigurasikan bayangan yang dikembalikan oleh [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Nilai radius blur yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh PHP berikut membuat kartu biru muda dengan bayangan dalam abu‑abu gelap dan menyimpannya sebagai file PPTX. Arah bayangan 225 derajat, jaraknya 7 poin, dan radius blur‑nya 6 poin:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) pada format efek bentuk.

## **Menerapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides untuk PHP via Java, Anda dapat menambahkan refleksi mirip cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberi bentuk tampilan yang lebih halus dan canggih. Mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode PHP berikut menunjukkan cara menerapkan [reflection effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) pada sebuah bentuk:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Reflection effect](reflection_effect.png)

## **Menerapkan Efek Glow**

Untuk menerapkan efek glow pada sebuah bentuk di Aspose.Slides untuk PHP via Java, Anda dapat menambahkan aura lembut yang bersinar di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu bentuk menonjol dan menambahkan elemen visual yang menarik pada presentasi Anda. Mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode PHP berikut menunjukkan cara menerapkan [glow effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) pada sebuah bentuk:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Glow effect](glow_effect.png)

## **Menerapkan Efek Soft Edges**

Untuk menerapkan efek soft edges di Aspose.Slides untuk PHP via Java, Anda dapat membuat transisi halus dan kabur di sekitar tepi bentuk. Efek ini menambahkan tampilan yang lebih subtil dan halus, cocok untuk desain yang memerlukan penampilan lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode PHP berikut menunjukkan cara menerapkan [soft edges effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) pada sebuah bentuk:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **Menerapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isian dan outline bentuk sambil tetap menjaga bentuk dapat diedit. Panggil [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai non‑negatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah tampilan.

Pengaturan [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) mengontrol batas tampak efek. Dengan `false`, blur dipotong pada batas terlukis asli, termasuk outline. Dengan `true`, blur dapat meluas di luar batas tersebut. Tidak ada pengaturan yang mengubah posisi atau dimensi bentuk.

Perbandingan di bawah menggunakan isian, outline, dan dimensi bentuk yang sama sepanjang contoh. Baris atas menggunakan `grow = false`; baris bawah menggunakan `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Contoh PHP ini membuat persegi panjang oranye dengan outline biru gelap, menerapkan blur 5 poin, lalu memperbaruinya menjadi blur 15 poin dengan memanggil [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) lagi. Ia menyimpan kedua kondisi blur, kemudian memanggil [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) dan menyimpan bentuk tanpa blur.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Blur bentuk memengaruhi isian dan outline secara bersamaan. Efek soft edges mengaburkan tepi bentuk, sementara blur bayangan hanya melunakkan bayangan. Efek transformasi gambar bekerja pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengubah bentuk menjadi gambar.

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan efek berbeda, seperti bayangan, refleksi, dan glow, pada satu bentuk untuk menghasilkan tampilan yang lebih dinamis.

**Bentuk apa saja yang dapat saya beri efek?**

Anda dapat memberi efek pada berbagai bentuk, termasuk autoshape, chart, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek akan diterapkan pada seluruh grup.