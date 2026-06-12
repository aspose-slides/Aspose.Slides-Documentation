---
title: Sesuaikan Legenda Grafik dalam Presentasi di Android
linktitle: Legenda Grafik
type: docs
url: /id/androidjava/chart-legend/
keywords:
- legenda grafik
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sesuaikan legenda grafik dengan Aspose.Slides untuk Android via Java untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides menyediakan opsi untuk menyesuaikan legenda grafik dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengatur ukuran legenda, menetapkan ukuran font untuk seluruh legenda, dan menerapkan pemformatan pada entri legenda individu.

Artikel ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non-overlay sehingga area plot memberi ruang untuk legenda, memungkinkan label legenda yang panjang untuk membungkus atau menggunakan jeda baris, dan membiarkan pemformatan legenda mewarisi dari tema presentasi ketika pengaturan teks dan isian eksplisit tidak diterapkan.

## **Penempatan Legenda**
Untuk mengatur properti legenda, ikuti langkah-langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Dapatkan referensi slide.
- Menambahkan grafik pada slide.
- Mengatur properti legenda.
- Simpan presentasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengatur posisi dan ukuran legenda grafik.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Dapatkan referensi slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tambahkan diagram kolom berkelompok pada slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Atur Properti Legenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Simpan presentasi ke disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Ukuran Font Legenda**
Aspose.Slides untuk Android via Java memungkinkan pengembang untuk mengatur ukuran font legenda. Ikuti langkah-langkah di bawah ini:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Membuat grafik default.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Simpan presentasi ke disk.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Ukuran Font Legenda Individu**
Aspose.Slides untuk Android via Java memungkinkan pengembang untuk mengatur ukuran font entri legenda individu. Ikuti langkah-langkah di bawah ini:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Membuat grafik default.
- Akses entri legenda.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Simpan presentasi ke disk.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan legenda sehingga grafik secara otomatis menyediakan ruang untuknya alih-alih menimpanya?**

Ya. Gunakan mode non-overlay ([setOverlay(false)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); dalam hal ini, area plot akan menyusut untuk menampung legenda.

**Apakah saya dapat membuat label legenda multi-baris?**

Ya. Label yang panjang akan otomatis membungkus ketika ruang tidak cukup; jeda baris paksa didukung melalui karakter baris baru dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan tetapkan warna/isian/font secara eksplisit untuk legenda atau teksnya. Mereka akan mewarisi dari tema dan memperbarui dengan benar saat desain berubah.