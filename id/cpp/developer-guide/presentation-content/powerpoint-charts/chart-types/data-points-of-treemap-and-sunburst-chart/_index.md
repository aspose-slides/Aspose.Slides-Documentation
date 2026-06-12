---
title: Kustomisasi Titik Data pada Diagram Treemap dan Sunburst Menggunakan C++
linktitle: Titik Data pada Diagram Treemap dan Sunburst
type: docs
url: /id/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- diagram treemap
- diagram sunburst
- titik data
- warna label
- warna cabang
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelola titik data pada diagram treemap dan sunburst dengan Aspose.Slides untuk C++, kompatibel dengan format PowerPoint."
---
## **Pendahuluan**

Di antara tipe diagram PowerPoint lainnya, ada dua tipe “hierarki” – **Treemap** dan **Sunburst** (juga dikenal sebagai Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph atau Multi Level Pie Chart). Diagram ini menampilkan data hierarki yang diatur sebagai pohon – dari daun hingga puncak cabang. Daun didefinisikan oleh titik data seri, dan setiap level pengelompokan bersarang berikutnya didefinisikan oleh kategori yang sesuai. Aspose.Slides for C++ memungkinkan memformat titik data Sunburst Chart dan Treemap dalam C++.

Berikut ini Sunburst Chart, di mana data pada kolom Series1 menentukan node daun, sementara kolom lain menentukan titik data hierarki:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Mari kita mulai dengan menambahkan Sunburst chart baru ke presentasi:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="See also" %}} 
- [**Membuat Sunburst Chart**](/slides/id/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Jika perlu memformat titik data pada diagram, kita harus menggunakan yang berikut:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevel/) kelas dan metode [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) menyediakan akses untuk memformat titik data pada diagram Treemap dan Sunburst.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) digunakan untuk mengakses kategori multi-level – ia merupakan wadah objek [**IChartDataPointLevel**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevel/). Pada dasarnya ini adalah wrapper untuk [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) dengan properti yang ditambahkan khusus untuk titik data. Kelas [**IChartDataPointLevel**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevel/) memiliki dua metode: [**get_Format()**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) dan [**get_Label()**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) yang menyediakan akses ke pengaturan yang sesuai.

## **Tampilkan Nilai Titik Data**
Tampilkan nilai titik data "Leaf 4":

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Atur Label dan Warna Titik Data**
Atur label data "Branch 1" agar menampilkan nama seri ("Series1") bukan nama kategori. Kemudian atur warna teks menjadi kuning:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Atur Warna Cabang Titik Data**
Ubah warna cabang "Stem 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Apakah saya dapat mengubah urutan (pengurutan) segmen di Sunburst/Treemap?**

Tidak. PowerPoint mengurutkan segmen secara otomatis (biasanya berdasarkan nilai turun, searah jarum jam). Aspose.Slides meniru perilaku ini: Anda tidak dapat mengubah urutan secara langsung; Anda harus melakukannya dengan memproses data terlebih dahulu.

**Bagaimana tema presentasi memengaruhi warna segmen dan label?**

Warna diagram mewarisi [tema/palet](/slides/id/cpp/presentation-theme/) presentasi kecuali Anda secara eksplisit mengatur isian/font. Untuk hasil yang konsisten, gunakan isian solid dan pemformatan teks pada level yang diperlukan.

**Apakah ekspor ke PDF/PNG akan mempertahankan warna cabang khusus dan pengaturan label?**

Ya. Saat mengekspor presentasi, pengaturan diagram (isi, label) dipertahankan dalam format output karena Aspose.Slides merender dengan format diagram yang diterapkan.

**Apakah saya dapat menghitung koordinat aktual label/elemen untuk penempatan overlay khusus di atas diagram?**

Ya. Setelah tata letak diagram divalidasi, nilai X sebenarnya dan Y sebenarnya tersedia untuk elemen (misalnya, sebuah [DataLabel](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/datalabel/)), yang membantu dalam penempatan overlay secara tepat.