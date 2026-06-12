---
title: Sesuaikan Legenda Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Legenda Diagram
type: docs
url: /id/nodejs-java/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan JavaScript dan Aspose.Slides untuk Node.js guna mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, dan menerapkan pemformatan pada entri legenda individu.

Artikel ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non-overlay sehingga area plot memberi ruang untuk legenda, memungkinkan label legenda yang panjang membungkus atau menggunakan pemisah baris, dan membiarkan pemformatan legenda mewarisi dari tema presentasi ketika pengaturan teks dan isi eksplisit tidak diterapkan.

## **Penempatan Legenda**

Untuk mengatur properti legenda, ikuti langkah-langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Dapatkan referensi slide.
- Tambahkan diagram pada slide.
- Atur properti legenda.
- Tuliskan presentasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengatur posisi dan ukuran legenda Diagram.

```javascript
// Buat sebuah instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan referensi slide
    var slide = pres.getSlides().get_Item(0);
    // Tambahkan diagram kolom berkelompok pada slide
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Atur Properti Legenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Tuliskan presentasi ke disk
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengatur Ukuran Font Legenda**

Aspose.Slides untuk Node.js via Java memungkinkan pengembang mengatur ukuran font legenda. Ikuti langkah-langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Buat diagram default.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Tuliskan presentasi ke disk.

```javascript
// Buat sebuah instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengatur Ukuran Font Legenda Individual**

Aspose.Slides untuk Node.js via Java memungkinkan pengembang mengatur ukuran font entri legenda individual. Ikuti langkah-langkah berikut:

- Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Buat diagram default.
- Akses entri legenda.
- Atur Ukuran Font.
- Atur nilai minimum sumbu.
- Atur nilai maksimum sumbu.
- Tuliskan presentasi ke disk.

```javascript
// Buat sebuah instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan legenda sehingga diagram secara otomatis menyediakan ruang untuknya alih-alih menimpanya?**

Ya. Gunakan mode non-overlay ([setOverlay(false)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/legend/setoverlay/)); dalam hal ini, area plot akan menyusut untuk mengakomodasi legenda.

**Apakah saya dapat membuat label legenda berbaris ganda?**

Ya. Label yang panjang akan membungkus secara otomatis ketika ruang tidak cukup; pemisah baris paksa didukung melalui karakter baris baru dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan mengatur warna/isi/font secara eksplisit untuk legenda atau teksnya. Mereka akan mewarisi dari tema dan memperbarui dengan benar ketika desain berubah.