---
title: "Sesuaikan Tabel Data Diagram dalam Presentasi Menggunakan Java"
linktitle: "Tabel Data"
type: docs
url: /id/java/chart-data-table/
keywords:
- "diagram data"
- "tabel data"
- "properti font"
- "PowerPoint"
- "presentasi"
- "Java"
- "Aspose.Slides"
description: "Sesuaikan tabel data diagram dalam Java untuk PPT dan PPTX dengan Aspose.Slides untuk meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan tabel data diagram di Aspose.Slides. Artikel ini menunjukkan cara menampilkan tabel data untuk diagram dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contohnya memperlihatkan cara memuat presentasi, menambahkan diagram, mengaktifkan tabel data diagram, menerapkan pengaturan font, dan menyimpan presentasi yang diperbarui.

Itu juga mencakup jawaban singkat untuk pertanyaan umum tentang menampilkan kunci legenda dalam tabel data diagram, mempertahankan tabel data saat mengekspor, bekerja dengan diagram yang dimuat dari presentasi atau templat yang ada, dan mengidentifikasi diagram di mana tabel data diaktifkan.

## **Mengatur Properti Font untuk Tabel Data Diagram**
Aspose.Slides untuk Java menyediakan dukungan untuk mengubah warna kategori dalam warna seri.  

1. Buat instance objek kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Atur tabel diagram.
1. Atur tinggi font.
1. Simpan presentasi yang telah dimodifikasi.

Berikut contoh sampel yang diberikan.  

```java
// Membuat presentasi kosong
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tanya Jawab**

**Apakah saya dapat menampilkan kunci legenda kecil di sebelah nilai dalam tabel data diagram?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), dan Anda dapat mengaktifkannya atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram sebagai bagian dari slide, sehingga [PDF](/slides/id/java/convert-powerpoint-to-pdf/)/[HTML](/slides/id/java/convert-powerpoint-to-html/)/[image](/slides/id/java/convert-powerpoint-to-png/) yang diekspor menyertakan diagram beserta tabel datanya.

**Apakah tabel data didukung untuk diagram yang berasal dari berkas templat?**

Ya. Untuk diagram apa pun yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/#hasDataTable--) menggunakan properti diagram.

**Bagaimana saya dapat dengan cepat menemukan diagram mana dalam berkas yang memiliki tabel data diaktifkan?**

Periksa properti setiap diagram yang menunjukkan apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/#hasDataTable--) dan iterasi melalui slide untuk mengidentifikasi diagram yang mengaktifkannya.