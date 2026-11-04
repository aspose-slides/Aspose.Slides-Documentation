---
title: Menerapkan Efek Bentuk dalam Presentasi Menggunakan Java
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/java/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek cahaya
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk tingkat lanjut menggunakan Aspose.Slides untuk Java—buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk membuat sebuah bentuk menonjol, mereka berbeda dari [isi](/slides/id/java/shape-formatting/#gradient-fill) atau garis tepi. Dengan menggunakan efek PowerPoint, Anda dapat membuat pantulan yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

![Efek bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Untuk alasan ini, PowerPoint menyediakan opsi di bawah **Preset**. Opsi Preset adalah kombinasi dua atau lebih efek yang diketahui terlihat bagus. Dengan cara ini, dengan memilih preset, Anda tidak perlu menghabiskan waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang bagus.

Aspose.Slides menyediakan properti dan metode pada kelas [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Terapkan Efek Bayangan**

Aspose.Slides for Java mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur mereka agar sesuai dengan desain presentasi Anda.

### **Terapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol di atas latar belakang slide. Bayangan memperluas melewati tepi bentuk, menciptakan kesan bahwa bentuk terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur untuk cocok dengan pencahayaan dan gaya templat Anda.

Kode Java ini memperlihatkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) pada sebuah persegi panjang:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efek bayangan](shadow_effect.png)

### **Terapkan Bayangan Dalam**

Saat meniru gaya visual templat, gunakan bayangan dalam untuk memberikan kartu atau panel tampilan terukir. Bayangan luar memperluas ke luar bentuk dan membuatnya tampak terangkat, sedangkan bayangan dalam memberikan bayangan pada bagian dalam tepinya.

Panggil [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), lalu konfigurasikan bayangan yang dikembalikan oleh [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Nilai radius blur yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh Java ini membuat kartu biru muda dengan bayangan dalam abu-abu gelap dan menyimpannya sebagai file PPTX. Arah bayangan adalah 225 derajat, jaraknya 7 poin, dan radius blurnya 6 poin:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) pada format efek bentuk.

## **Terapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides for Java, Anda dapat menambahkan refleksi seperti cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberi bentuk tampilan yang lebih halus dan canggih. Mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode Java ini memperlihatkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) pada sebuah bentuk:

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

## **Terapkan Efek Cahaya**

Untuk menerapkan efek cahaya pada bentuk di Aspose.Slides for Java, Anda dapat menambahkan aura lembut dan bercahaya di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu membuat bentuk menonjol dan menambahkan elemen visual yang menarik dan memikat pada presentasi Anda. Mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode Java ini memperlihatkan cara menerapkan [efek cahaya](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) pada sebuah bentuk:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Terapkan Efek Tepi Lembut**

Untuk menerapkan efek tepi lembut di Aspose.Slides for Java, Anda dapat membuat transisi halus dan buram di sekitar tepi sebuah bentuk. Efek ini menambah tampilan yang lebih halus dan terperinci, cocok untuk desain yang membutuhkan penampilan lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode Java ini memperlihatkan cara menerapkan [efek tepi lembut](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) pada sebuah bentuk:

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

![Efek tepi lembut](soft_edges_effect.png)

## **Terapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isi dan garis tepi bentuk sambil mempertahankan bentuk tetap dapat diedit. Panggil [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai non-negatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah tampilan.

Pengaturan [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) mengontrol batas tampak efek. Dengan `false`, blur dipotong sesuai batas yang sudah digambar, termasuk garis tepi. Dengan `true`, blur dapat melampaui batas tersebut. Kedua pengaturan tidak mengubah posisi atau dimensi bentuk.

Perbandingan di bawah menggunakan isi, garis tepi, dan dimensi bentuk yang sama sepanjangnya. Baris atas menggunakan `grow = false`; baris bawah menggunakan `grow = true`.

![Persegi panjang asli dibandingkan dengan radius blur 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh Java ini membuat persegi panjang oranye dengan garis tepi biru tua, menerapkan blur 5 poin, lalu memperbaruinya menjadi blur 15 poin dengan memanggil [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) lagi. Ia menyimpan kedua keadaan blur, kemudian memanggil [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) dan menyimpan bentuk tanpa blur.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

Blur bentuk memengaruhi isi dan garis tepi secara bersamaan. Efek tepi lembut memudarkan tepi bentuk, sedangkan blur bayangan hanya melunakkan bayangan. Efek transformasi gambar bekerja pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **Tanya Jawab**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan cahaya, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, diagram, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek akan diterapkan pada seluruh grup.