---
title: Terapkan Efek Bentuk dalam Presentasi di Android
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/androidjava/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek cahaya
- efek pinggiran lembut
- format efek
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk Android via Java—buat slide yang menawan dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Meskipun efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, efek tersebut berbeda dari [isian](/slides/id/androidjava/shape-formatting/#gradient-fill) atau garis tepi. Dengan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

![Efek bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint menyediakan opsi di bawah **Preset**. Opsi Preset adalah kombinasi dua atau lebih efek yang diketahui menghasilkan tampilan yang baik. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang bagus.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Aspose.Slides untuk Android via Java mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius keburaman agar sesuai dengan desain presentasi Anda.

### **Menerapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol dari latar belakang slide. Bayangan tersebut meluas di luar tepi bentuk, menciptakan kesan bahwa bentuk tersebut terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius keburaman agar cocok dengan pencahayaan dan gaya template Anda.

Kode Java berikut menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) pada sebuah persegi panjang:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek bayangan](shadow_effect.png)

### **Menerapkan Bayangan Dalam**

Saat mereproduksi gaya visual template, gunakan bayangan dalam untuk memberi kartu atau panel penampilan menjorok ke dalam. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sementara bayangan dalam memberi bayangan pada sisi dalam tepinya.

Panggil [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), lalu konfigurasikan bayangan yang dikembalikan oleh [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Nilai radius keburaman yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh Java ini membuat kartu biru muda dengan bayangan dalam abu‑abu gelap dan menyimpannya sebagai file PPTX. Arah bayangan adalah 225 derajat, jaraknya 7 poin, dan radius keburaman 6 poin:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) pada format efek bentuk.

## **Menerapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides untuk Android via Java, Anda dapat menambahkan refleksi seperti cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan elegan. Mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode Java berikut menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) pada sebuah bentuk:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek refleksi](reflection_effect.png)

## **Menerapkan Efek Cahaya (Glow)**

Untuk menerapkan efek cahaya pada sebuah bentuk di Aspose.Slides untuk Android via Java, Anda dapat menambahkan aura lembut yang bersinar di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu membuat bentuk menonjol dan menambahkan elemen visual yang menarik pada presentasi Anda. Mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode Java berikut menunjukkan cara menerapkan [efek cahaya](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) pada sebuah bentuk:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek cahaya](glow_effect.png)

## **Menerapkan Efek Pinggiran Lembut**

Untuk menerapkan efek pinggiran lembut di Aspose.Slides untuk Android via Java, Anda dapat membuat transisi halus dan kabur di sekitar pinggiran bentuk. Efek ini menambahkan tampilan yang lebih halus dan halus, cocok untuk desain yang memerlukan penampilan lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode Java berikut menunjukkan cara menerapkan [efek pinggiran lembut](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) pada sebuah bentuk:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek pinggiran lembut](soft_edges_effect.png)

## **Menerapkan Efek Keburaman**

Gunakan keburaman bentuk untuk melunakkan isian dan garis tepi bentuk sambil tetap mempertahankan kemampuan mengedit bentuk. Panggil [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai non‑negatif, dengan nilai yang lebih besar menghasilkan keburaman yang lebih kuat. Radius nol tidak mengubah penampilan.

Pengaturan [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) mengontrol batas tampak efek. Dengan `false`, keburaman dipotong pada batas yang semula dilukis, termasuk garis tepi. Dengan `true`, keburaman dapat meluas di luar batas tersebut. Tidak ada pengaturan yang mengubah posisi atau dimensi bentuk.

Perbandingan di bawah menggunakan isian, garis tepi, dan dimensi bentuk yang sama sepanjang proses. Baris atas menggunakan `grow = false`; baris bawah menggunakan `grow = true`.

![Persegi panjang asli dibandingkan dengan radius keburaman 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh Java ini membuat persegi panjang oranye dengan garis tepi biru tua, menerapkan keburaman 5 poin, lalu memperbaruinya menjadi keburaman 15 poin dengan memanggil [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) lagi. Kedua keadaan keburaman disimpan, kemudian memanggil [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) dan menyimpan bentuk tanpa keburaman.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Keburaman bentuk memengaruhi isian dan garis tepi secara bersamaan. Efek pinggiran lembut memudarkan pinggiran bentuk, sementara keburaman bayangan melunakkan hanya bayangan. Efek transformasi gambar beroperasi pada konten gambar; contoh ini menerapkan keburaman langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan efek yang berbeda, seperti bayangan, refleksi, dan cahaya, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa saja yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, diagram, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek akan diterapkan pada seluruh grup.