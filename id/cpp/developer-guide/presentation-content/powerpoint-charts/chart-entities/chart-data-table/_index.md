---
title: Sesuaikan Tabel Data Diagram dalam Presentasi Menggunakan С++
linktitle: Tabel Data
type: docs
url: /id/cpp/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- presentasi
- С++
- Aspose.Slides
description: "Sesuaikan tabel data diagram dalam С++ untuk PPT dan PPTX dengan Aspose.Slides untuk meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Ringkasan**

Artikel ini menjelaskan cara bekerja dengan tabel data diagram di Aspose.Slides. Ini menunjukkan cara menampilkan tabel data untuk sebuah diagram dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contoh ini mendemonstrasikan memuat presentasi, menambahkan diagram, mengaktifkan tabel data diagram, menerapkan pengaturan font, dan menyimpan presentasi yang diperbarui.

## **Mengatur Properti Font untuk Tabel Data Diagram**
Aspose.Slides untuk C++ memungkinkan mengubah properti font untuk tabel data diagram.

1. Instansiasi objek kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Tambahkan diagram pada slide.
3. Atur tabel diagram.
4. Atur tinggi font.
5. Simpan presentasi yang dimodifikasi.

Contoh kode berikut diberikan.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda kecil di samping nilai pada tabel data diagram?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/datatable/set_showlegendkey/), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram sebagai bagian dari slide, sehingga [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/id/cpp/convert-powerpoint-to-html/)/[image](/slides/id/cpp/convert-powerpoint-to-png/) yang diekspor mencakup diagram dengan tabel datanya.

**Apakah tabel data didukung untuk diagram yang berasal dari file templat?**

Ya. Untuk setiap diagram yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/set_hasdatatable/) menggunakan properti diagram.

**Bagaimana saya dapat dengan cepat menemukan diagram mana dalam file yang memiliki tabel data diaktifkan?**

Periksa properti masing-masing diagram yang menunjukkan apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/get_hasdatatable/) dan iterasi melalui slide untuk mengidentifikasi diagram yang mengaktifkannya.