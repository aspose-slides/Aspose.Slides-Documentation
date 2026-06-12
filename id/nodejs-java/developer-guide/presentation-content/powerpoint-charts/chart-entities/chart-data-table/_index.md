---
title: Sesuaikan Tabel Data Bagan dalam Presentasi Menggunakan JavaScript
linktitle: Tabel Data
type: docs
url: /id/nodejs-java/chart-data-table/
keywords:
- data bagan
- tabel data
- properti font
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan tabel data bagan dalam JavaScript untuk PPT dan PPTX dengan Aspose.Slides untuk Node.js melalui Java untuk meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan tabel data bagan di Aspose.Slides. Artikel ini menunjukkan cara menampilkan tabel data untuk sebuah bagan dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contoh ini mendemonstrasikan memuat presentasi, menambahkan bagan, mengaktifkan tabel data bagan, menerapkan pengaturan font, dan menyimpan presentasi yang telah diperbarui.

Artikel ini juga menyertakan jawaban singkat untuk pertanyaan umum tentang menampilkan kunci legenda di tabel data bagan, mempertahankan tabel data saat mengekspor, bekerja dengan bagan yang dimuat dari presentasi atau templat yang ada, serta mengidentifikasi bagan yang tabel datanya diaktifkan.

## **Atur Properti Font untuk Tabel Data Bagan**

Aspose.Slides for Node.js via Java menyediakan dukungan untuk mengubah warna kategori dalam warna seri. 

1. Buat objek kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Tambahkan bagan pada slide.
1. Atur tabel bagan.
1. Atur tinggi font.
1. Simpan presentasi yang telah dimodifikasi.

 Contoh sampel diberikan di bawah. 

```javascript
// Membuat presentasi kosong
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda kecil di samping nilai dalam tabel data bagan?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datatable/setshowlegendkey/), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender bagan sebagai bagian dari slide, sehingga [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/id/nodejs-java/convert-powerpoint-to-png/) yang diekspor menyertakan bagan beserta tabel datanya.

**Apakah tabel data didukung untuk bagan yang berasal dari file templat?**

Ya. Untuk setiap bagan yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [is shown](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/hasdatatable/) menggunakan properti bagan.

**Bagaimana cara cepat menemukan bagan mana dalam file yang memiliki tabel data diaktifkan?**

Periksa properti setiap bagan yang menunjukkan apakah tabel data [is shown](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/hasdatatable/) dan iterasi melalui slide untuk mengidentifikasi bagan yang tabel datanya diaktifkan.