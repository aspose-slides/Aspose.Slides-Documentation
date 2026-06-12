---
title: Optimalkan Perhitungan Bagan untuk Presentasi di C++
linktitle: Perhitungan Bagan
type: docs
weight: 50
url: /id/cpp/chart-calculations/
keywords:
- perhitungan bagan
- elemen bagan
- posisi elemen
- posisi aktual
- elemen anak
- elemen induk
- nilai bagan
- nilai aktual
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pahami perhitungan bagan, pembaruan data, dan kontrol presisi dalam Aspose.Slides untuk C++ untuk PPT dan PPTX, dengan contoh kode C++ yang praktis."
---
## **Gambaran Umum**

Aspose.Slides menyediakan API untuk bekerja dengan perhitungan bagan dan data tata letak dalam presentasi. Artikel ini menunjukkan cara mengambil nilai aktual elemen bagan, termasuk posisi dan ukuran sebenarnya dari elemen yang mengimplementasikan `IActualLayout` serta nilai aktual sumbu bagan. Artikel ini juga menjelaskan bahwa nilai‑nilai tersebut diisi setelah validasi tata letak bagan.

Selain itu, artikel ini menunjukkan cara mendapatkan posisi aktual elemen bagan induk dan cara menyembunyikan komponen bagan seperti judul, sumbu, legenda, dan garis kisi. Bersama-sama, contoh-contoh ini membantu Anda memeriksa informasi tata letak bagan dan mengontrol visibilitas elemen bagan dalam presentasi PowerPoint secara programatik.

## **Hitung Nilai Aktual Elemen Bagan**
Aspose.Slides for C++ menyediakan API sederhana untuk mendapatkan properti ini. Ini akan membantu Anda menghitung nilai aktual elemen bagan. Nilai aktual mencakup posisi elemen yang mengimplementasikan antarmuka IActualLayout (`IActualLayout::get_ActualX()`, `IActualLayout::get_ActualY()`, `IActualLayout::get_ActualWidth()`, `IActualLayout::get_ActualHeight()`) dan nilai aktual sumbu (`IAxis::get_ActualMaxValue()`, `IAxis::get_ActualMinValue()`, `IAxis::get_ActualMajorUnit()`, `IAxis::get_ActualMinorUnit()`, `IAxis::get_ActualMajorUnitScale()`, `IAxis::get_ActualMinorUnitScale()`).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Menyimpan presentasi
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Hitung Posisi Aktual Elemen Bagan Induk**
Aspose.Slides for C++ menyediakan API sederhana untuk mendapatkan properti ini. Metode IActualLayout menyediakan informasi tentang posisi aktual elemen bagan induk. Penting untuk memanggil metode `IChart::ValidateChartLayout()` terlebih dahulu agar properti terisi dengan nilai aktual.

``` cpp
// Membuat presentasi kosong
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Sembunyikan Elemen Bagan**
Topik ini membantu Anda memahami cara menyembunyikan informasi dari bagan. Dengan menggunakan Aspose.Slides for C++ Anda dapat menyembunyikan **Title, Vertical Axis, Horizontal Axis** dan **Grid Lines** dari bagan. Contoh kode di bawah ini menunjukkan cara menggunakan properti tersebut.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Atur Rentang Data untuk Bagan**
Aspose.Slides for C++ telah menyediakan API paling sederhana untuk mengatur rentang data bagan dengan cara termudah. Untuk mengatur rentang data bagan:

- Buka sebuah instance kelas Presentation yang berisi bagan.
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Telusuri semua shape untuk menemukan bagan yang diinginkan.
- Akses data bagan dan atur rentangnya.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Berikut contoh kode cara memperbarui bagan.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Apakah workbook Excel eksternal dapat berfungsi sebagai sumber data, dan bagaimana hal itu memengaruhi perhitungan ulang?**

Ya. Sebuah bagan dapat merujuk ke workbook eksternal: ketika Anda menghubungkan atau menyegarkan sumber eksternal, rumus dan nilai diambil dari workbook tersebut, dan bagan mencerminkan pembaruan selama operasi buka/edit. API memungkinkan Anda [specify the external workbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) path dan mengelola data tertaut.

**Bisakah saya menghitung dan menampilkan garis tren tanpa mengimplementasikan regresi sendiri?**

Ya. [Trendlines](/slides/id/cpp/trend-line/) (linear, exponential, dan lain‑lain) ditambahkan dan diperbarui oleh Aspose.Slides; parameternya dihitung ulang secara otomatis dari data seri, sehingga Anda tidak perlu mengimplementasikan perhitungan sendiri.

**Jika sebuah presentasi memiliki beberapa bagan dengan tautan eksternal, dapatkah saya mengontrol workbook mana yang digunakan setiap bagan untuk nilai yang dihitung?**

Ya. Setiap bagan dapat menunjuk ke [external workbook](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) masing‑masing, atau Anda dapat membuat/mengganti workbook eksternal per bagan secara independen dari yang lain.