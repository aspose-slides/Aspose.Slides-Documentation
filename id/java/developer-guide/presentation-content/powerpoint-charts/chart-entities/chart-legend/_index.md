---
title: Sesuaikan Legenda Diagram dalam Presentasi Menggunakan Java
linktitle: Legenda Diagram
type: docs
url: /id/java/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk Java guna mengoptimalkan presentasi PowerPoint dengan format legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, dan menerapkan pemformatan pada entri legenda individu.

Artikel ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non-overlay sehingga area plot memberi ruang untuk legenda, memungkinkan label legenda panjang dibungkus atau menggunakan pemisah baris, serta membiarkan format legenda mewarisi dari tema presentasi ketika pengaturan teks dan isi tidak diterapkan secara eksplisit.

## **Penempatan Legenda**
Untuk mengatur properti legenda, ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Dapatkan referensi slide.
- Menambahkan bagan pada slide.
- Menetapkan properti legenda.
- Tuliskan presentasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah mengatur posisi dan ukuran legenda Bagan.

```java
// Buat instance dari kelas Presentation
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
    
    // Tulis presentasi ke disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Ukuran Font Legenda**
Aspose.Slides untuk Java memungkinkan pengembang mengatur ukuran font legenda. Ikuti langkah-langkah di bawah ini:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Membuat bagan default.
- Atur Ukuran Font.
- Atur nilai sumbu minimum.
- Atur nilai sumbu maksimum.
- Tuliskan presentasi ke disk.

```java
// Buat instance dari kelas Presentation
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

## **Atur Ukuran Font Legenda Individual**
Aspose.Slides untuk Java memungkinkan pengembang mengatur ukuran font entri legenda individual. Ikuti langkah-langkah di bawah ini:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Membuat bagan default.
- Akses entri legenda.
- Atur Ukuran Font.
- Atur nilai sumbu minimum.
- Atur nilai sumbu maksimum.
- Tuliskan presentasi ke disk.

```java
// Buat instance dari kelas Presentation
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

**Apakah saya dapat mengaktifkan legenda sehingga bagan secara otomatis menyediakan ruang untuknya alih-alih menimpanya?**

Ya. Gunakan mode non-overlay ([setOverlay(false)](https://reference.aspose.com/slides/id/java/com.aspose.slides/legend/#setOverlay-boolean-)); dalam hal ini, area plot akan menyusut untuk menampung legenda.

**Apakah saya dapat membuat label legenda multi-baris?**

Ya. Label yang panjang akan otomatis dibungkus ketika ruang tidak cukup; pemisahan baris paksa didukung melalui karakter newline dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan menetapkan warna/pengisian/font secara eksplisit untuk legenda atau teksnya. Mereka akan mewarisi dari tema dan akan diperbarui dengan benar ketika desain berubah.