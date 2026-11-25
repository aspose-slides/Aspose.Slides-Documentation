---
title: Sesuaikan Grafik 3D dalam Presentasi Menggunakan C++
linktitle: Grafik 3D
type: docs
url: /id/cpp/3d-chart/
keywords:
- grafik 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat grafik 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk C++. Sesuaikan rotasi, proporsi tinggi, kedalaman grafik, dan jarak antar seri dengan contoh C++."
---
## **Gambaran Umum**

Aspose.Slides for C++ memungkinkan Anda menyesuaikan tampilan grafik 3D melalui [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Artikel ini menunjukkan cara mengatur rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Atur Rotasi dan Kedalaman Grafik 3D**

Contoh di bawah membuat sebuah [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) dan menggunakan [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) untuk menambahkan grafik kolom 3D bertumpuk ke slide pertamanya. Ini menggantikan seri dan kategori default dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` mengidentifikasi lembar data pertama grafik; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Metode [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) dan [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) mengatur rotasi grafik menjadi 40 dan 270 derajat masing‑masing. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) menetapkan kedalaman menjadi 150 % dari lebar, sementara [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) mengaktifkan sumbu sudut kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi grafik yang telah diisi dengan pengaturan tampilan 3D ini.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Terapkan Isian Gambar pada Permukaan Grafik 3D**

Anda dapat mengisi [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/), dan [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) grafik 3D secara terpisah. Atur [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) permukaan menjadi `Picture` dan tetapkan gambar. Agar satu salinan gambar menutupi seluruh permukaan, atur baik [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) maupun [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) menjadi `Stretch`.

Simpan [arrow.png](arrow.png) di direktori kerja. Contoh ini memutar grafik dan menaikkan nilai maksimum pada sumbu vertikal sehingga lantai terlihat di antara kolom. Kemudian contoh menyalin slide dua kali dan menerapkan panah pada permukaan yang berbeda di setiap slide. Semua tiga grafik mempertahankan data, sudut pandang, dan latar belakang yang sama.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Microsoft PowerPoint menampilkan tiga slide sebagai berikut.

| Dinding samping | Dinding belakang | Lantai |
| --- | --- | --- |
| ![Panah menunjuk ke dalam grafik di sepanjang dinding samping](side-wall.png) | ![Panah menunjuk ke kanan melintasi dinding belakang](back-wall.png) | ![Panah menunjuk ke kanan melintasi lantai antara kolom](floor.png) |

## **Atur Proporsi Tinggi Grafik 3D**

Gunakan [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) untuk mengatur tinggi grafik 3D sebagai persentase lebar. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek grafik pada slide.

Contoh berikut membuat grafik [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) dengan data default: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi grafik tetap tetap. Data, rotasi, kedalaman, jarak seri, dan format tetap identik pada ketiga berkas; hanya persentase tinggi yang berubah.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Gambar‑gambar berikut dari contoh .NET setara diekspor menggunakan Microsoft PowerPoint dan menggambarkan pengaturan tinggi yang sama. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sementara persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek grafik yang sama. PowerPoint juga dapat menyesuaikan interval tanda sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![Grafik kolom 3D dengan tinggi diatur ke 50 persen dari lebarnya](height_percent_50.png) | ![Grafik kolom 3D dengan tinggi diatur ke 100 persen dari lebarnya](height_percent_100.png) | ![Grafik kolom 3D dengan tinggi diatur ke 200 persen dari lebarnya](height_percent_200.png) |

Metode‑metode berikut mengontrol aspek yang berbeda dari grafik:

| Metode | Efek |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Tinggi adegan 3D sebagai persentase dari lebarnya. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Tinggi objek grafik pada slide, dalam poin. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Kedalaman adegan 3D sebagai persentase dari lebarnya. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi grafik kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta grafik 3D garis, area, pai, dan permukaan. Perbandingan di atas menggunakan tipe `Column3D` yang telah diverifikasi. Pengaturan ini tidak mengubah tampilan grafik 2D `ClusteredColumn` atau grafik `BubbleWith3D`; nama‑nama tersebut merupakan anggota enumerasi [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Untuk pengaturan tampilan grafik lainnya, lihat [Pemformatan Grafik](/slides/id/cpp/chart-formatting/).

## **Atur Celah Antara Seri**

Gunakan [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) untuk mengontrol jarak antar seri data sepanjang sumbu kedalaman grafik 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai dari **0 hingga 500**, inklusif: `0` menghilangkan celah, sedangkan nilai yang lebih besar meningkatkan jarak. Dengan kedalaman grafik yang tetap, meningkatkan celah membuat penanda menjadi lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) mengembalikan pengaturan grup induk.

Pengaturan ini memengaruhi grafik kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta grafik 3D garis dan area. Penampilan tergantung pada apakah seri disusun dalam kedalaman, berkelompok, atau ditumpuk. Untuk perbandingan jelas celah antar seri terpisah, gunakan `ChartType::Column3D` dari enumerasi [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Metode‑metode berikut mengontrol aspek yang berbeda dari grafik:

| Metode | Efek |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Jarak antara kelompok batang atau kolom yang berdekatan, sebagai persentase lebar batang atau kolom. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Kedalaman keseluruhan grafik, sebagai persentase lebar grafik. |

Contoh mandiri berikut menggunakan data grafik default, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman grafik yang identik; hanya kedalaman celah yang berubah.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Gambar‑gambar berikut dari contoh .NET setara diekspor menggunakan Microsoft PowerPoint dan menggambarkan pengaturan kedalaman celah yang sama.

| Kedalaman celah: 0% | Kedalaman celah: 500% |
| --- | --- |
| ![Grafik kolom 3D tanpa celah antara seri sepanjang sumbu kedalaman](gap_depth_0.png) | ![Grafik kolom 3D dengan celah 500 persen antara seri sepanjang sumbu kedalaman](gap_depth_500.png) |

## **Ubah Tipe Seri 3D dan Bentuk Batang**

Dalam grafik silinder berkelompok, seri pertama dimulai dengan batang silinder. Contoh membaca [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) dan [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) sebelum dan sesudah setiap perubahan.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Ubah pada seri pertama | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Buat grafik | `ClusteredCylinder` | `Cylinder` |
| Panggil [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) dengan `ClusteredCone` | `ClusteredCone` | `Cone` |
| Panggil [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) dengan `Box` | `ClusteredColumn3D` | `Box` |

Mengatur bentuk menjadi `Box` juga mengubah tipe seri menjadi `ClusteredColumn3D`. Jika kode Anda memiliki percabangan berdasarkan tipe seri, panggil `series->get_Type()` setelah mengubah bentuk. Nilai yang disimpan sebelum perubahan masih akan memilih percabangan `ClusteredCone`.

![Perbandingan PowerPoint yang menampilkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Jenis grafik apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari grafik kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe 3D terkait yang tersedia melalui enumerasi [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terkini, periksa anggota [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari grafik 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor grafik ke gambar dengan [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) atau [render seluruh slide](/slides/id/cpp/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna bila Anda memerlukan pratinjau raster atau ingin menyisipkan grafik ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan perenderan grafik 3D besar?**

Kinerja bergantung pada volume data dan kompleksitas visual. Untuk hasil optimal, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke ukuran output yang sesuai (resolusi dan dimensi) untuk memenuhi kebutuhan tampilan atau cetak.