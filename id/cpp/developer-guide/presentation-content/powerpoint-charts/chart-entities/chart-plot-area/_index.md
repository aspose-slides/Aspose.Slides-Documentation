---
title: Sesuaikan Area Plot Grafik Presentasi di C++
linktitle: Area Plot
type: docs
url: /id/cpp/chart-plot-area/
keywords:
- grafik
- area plot
- lebar area plot
- tinggi area plot
- ukuran area plot
- mode tata letak
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Temukan cara menyesuaikan area plot grafik dalam presentasi PowerPoint dengan Aspose.Slides untuk C++. Tingkatkan visual slide Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan area plot grafik di Aspose.Slides. Artikel ini menjelaskan cara mendapatkan posisi dan ukuran sebenarnya dari area plot dengan memvalidasi tata letak grafik dan kemudian membaca nilai X, Y, lebar, dan tinggi.

Artikel ini juga mendemonstrasikan cara mengonfigurasi mode tata letak area plot ketika tata letak diatur secara manual, menggunakan `LayoutTargetType` untuk menentukan apakah area plot dihitung berdasarkan wilayah dalamnya atau wilayah luarnya bersama dengan sumbu dan label sumbu.

## **Dapatkan Lebar dan Tinggi Area Plot Grafik**
Aspose.Slides for C++ menyediakan API sederhana untuk .

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Akses slide pertama.
3. Tambahkan grafik dengan data default.
4. Panggil metode IChart::ValidateChartLayout() terlebih dahulu untuk mendapatkan nilai sebenarnya.
5. Mendapatkan lokasi X aktual (kiri) dari elemen grafik relatif terhadap sudut kiri atas grafik.
6. Mendapatkan posisi atas aktual elemen grafik relatif terhadap sudut kiri atas grafik.
7. Mendapatkan lebar aktual elemen grafik.
8. Mendapatkan tinggi aktual elemen grafik.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Simpan presentasi dengan grafik
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Atur Mode Tata Letak Area Plot Grafik**
Aspose.Slides for C++ menyediakan API sederhana untuk mengatur mode tata letak area plot grafik. Properti **LayoutTargetType** telah ditambahkan ke kelas **ChartPlotArea** dan **IChartPlotArea**. Jika tata letak area plot didefinisikan secara manual, properti ini menentukan apakah tata letak area plot berbasis bagian dalamnya (tidak termasuk sumbu dan label sumbu) atau bagian luarnya (termasuk sumbu dan label sumbu). Ada dua nilai yang mungkin yang didefinisikan dalam enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - menunjukkan bahwa ukuran area plot ditentukan oleh ukuran area plot, tidak termasuk tanda centang dan label sumbu.
- **LayoutTargetType.Outer** - menunjukkan bahwa ukuran area plot ditentukan oleh ukuran area plot, tanda centang, dan label sumbu.

Contoh kode diberikan di bawah.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**Dalam satuan apa ActualX, ActualY, ActualWidth, dan ActualHeight dikembalikan?**

Dalam poin; 1 inci = 72 poin. Ini adalah satuan koordinat Aspose.Slides.

**Bagaimana perbedaan Area Plot dengan Area Grafik dalam hal konten?**

Area Plot adalah wilayah menggambar data (seri, garis kisi, garis tren, dll.); Area Grafik mencakup elemen di sekitarnya (judul, legenda, dll.). Pada grafik 3D, Area Plot juga mencakup dinding/lantai dan sumbu.

**Bagaimana X, Y, Lebar, dan Tinggi Area Plot diinterpretasikan ketika tata letak manual?**

Mereka adalah fraksi (0–1) dari ukuran keseluruhan grafik; dalam mode ini, penempatan otomatis dinonaktifkan dan fraksi yang Anda tentukan digunakan.

**Mengapa posisi Area Plot berubah setelah menambahkan/memindahkan legenda?**

Legenda berada di area grafik di luar Area Plot namun memengaruhi tata letak dan ruang yang tersedia, sehingga Area Plot dapat bergeser ketika penempatan otomatis diaktifkan. (Ini adalah perilaku standar untuk grafik PowerPoint.)