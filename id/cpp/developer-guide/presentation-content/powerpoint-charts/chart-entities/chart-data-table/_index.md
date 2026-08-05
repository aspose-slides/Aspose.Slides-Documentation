---
title: Sesuaikan Tabel Data Grafik dalam Presentasi Menggunakan C++
linktitle: Tabel Data
type: docs
url: /id/cpp/chart-data-table/
keywords:
- data grafik
- tabel data
- properti font
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Sesuaikan tabel data grafik dalam C++ untuk PPT dan PPTX dengan Aspose.Slides untuk meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan tabel data grafik di Aspose.Slides. Artikel ini menunjukkan cara menampilkan tabel data untuk sebuah grafik dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contoh ini mendemonstrasikan memuat presentasi, menambahkan grafik, mengaktifkan tabel data grafik, menerapkan pengaturan font, dan menyimpan presentasi yang diperbarui.

## **Atur Properti Font untuk Tabel Data Grafik**
Aspose.Slides untuk C++ memungkinkan mengubah properti font untuk tabel data grafik. 

1. Instansiasi objek kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
1. Tambahkan grafik pada slide.
1. Atur tabel grafik.
1. Atur tinggi font.
1. Simpan presentasi yang dimodifikasi.

Contoh sampel berikut diberikan. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Bisakah saya menampilkan kunci legenda kecil di sebelah nilai dalam tabel data grafik?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/datatable/set_showlegendkey/), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender grafik sebagai bagian dari slide, sehingga [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/id/cpp/convert-powerpoint-to-html/)/[image](/slides/id/cpp/convert-powerpoint-to-png/) yang diekspor mencakup grafik beserta tabel datanya.

**Apakah tabel data didukung untuk grafik yang berasal dari file templat?**

Ya. Untuk grafik apa pun yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [is shown](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/set_hasdatatable/) menggunakan properti grafik tersebut.

**Bagaimana cara saya dengan cepat menemukan grafik mana dalam file yang memiliki tabel data diaktifkan?**

Periksa properti setiap grafik yang menunjukkan apakah tabel data [is shown](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/get_hasdatatable/) dan iterasi melalui slide untuk mengidentifikasi grafik di mana tabel data diaktifkan.