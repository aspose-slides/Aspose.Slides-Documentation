---
title: Sesuaikan Titik Data pada Grafik Treemap dan Sunburst di .NET
linktitle: Titik Data pada Grafik Treemap dan Sunburst
type: docs
url: /id/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- grafik treemap
- grafik sunburst
- titik data
- warna label
- warna cabang
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelola titik data dalam grafik treemap dan sunburst dengan Aspose.Slides untuk .NET, kompatibel dengan format PowerPoint."
---
## **Pengenalan**

Di antara jenis grafik PowerPoint lainnya, ada dua jenis “hierarkis” – **Treemap** dan **Sunburst** (chart (juga dikenal sebagai Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph atau Multi Level Pie Chart)). Grafik ini menampilkan data hierarkis yang diorganisir sebagai pohon – dari daun ke puncak cabang. Daun didefinisikan oleh titik data seri, dan setiap tingkat pengelompokan bersarang berikutnya didefinisikan oleh kategori yang bersangkutan. Aspose.Slides untuk .NET memungkinkan memformat titik data Sunburst Chart dan Treemap dalam C#.

Berikut adalah Sunburst Chart, di mana data di kolom Series1 mendefinisikan node daun, sementara kolom lain mendefinisikan titik data hierarkis:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Mari mulai dengan menambahkan diagram Sunburst baru ke presentasi:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="See also" %}} 
- [**Membuat Sunburst Chart**](/slides/id/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Jika perlu memformat titik data grafik, kita harus menggunakan yang berikut:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointlevel) classes 
dan [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) property 
memberikan akses untuk memformat titik data pada grafik Treemap dan Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/IChartDataPointLevelsManager) 
digunakan untuk mengakses kategori multi‑tingkat – ia mewakili kontainer dari 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/IChartDataPointLevel) objek. 
Pada dasarnya ini merupakan pembungkus untuk 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/IChartCategoryLevelsManager) dengan 
properti yang ditambahkan khusus untuk titik data. 
Kelas [**IChartDataPointLevel**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/IChartDataPointLevel) memiliki dua properti: [**Format**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointlevel/properties/format) dan 
[**DataLabel**](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointlevel/properties/label) yang memberikan akses ke pengaturan yang bersangkutan.

## **Tampilkan Nilai Titik Data**
Tampilkan nilai titik data “Leaf 4”:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Atur Label dan Warna Titik Data**
Atur label data “Branch 1” sehingga menampilkan nama seri (“Series1”) alih‑alih nama kategori. Kemudian atur warna teks menjadi kuning:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Atur Warna Cabang Titik Data**
Ubah warna cabang “Stem 4”:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Apakah saya dapat mengubah urutan (penyortiran) segmen dalam Sunburst/Treemap?**

Tidak. PowerPoint secara otomatis menyortir segmen (biasanya berdasarkan nilai menurun, searah jarum jam). Aspose.Slides meniru perilaku ini: Anda tidak dapat mengubah urutan secara langsung; Anda harus melakukannya dengan pra‑pemrosesan data.

**Bagaimana tema presentasi memengaruhi warna segmen dan label?**

Warna grafik mewarisi [tema/palet](/slides/id/net/presentation-theme/) presentasi kecuali Anda secara eksplisit menetapkan isi/font. Untuk hasil yang konsisten, tetapkan isi padat dan format teks pada tingkat yang diperlukan.

**Apakah ekspor ke PDF/PNG mempertahankan warna cabang khusus dan pengaturan label?**

Ya. Saat mengekspor presentasi, pengaturan grafik (isi, label) dipertahankan dalam format output karena Aspose.Slides merender dengan format grafik yang diterapkan.

**Apakah saya dapat menghitung koordinat sebenarnya dari label/elemen untuk penempatan overlay khusus di atas grafik?**

Ya. Setelah tata letak grafik divalidasi, `ActualX`/`ActualY` tersedia untuk elemen (misalnya, sebuah [DataLabel](https://reference.aspose.com/slides/id/net/aspose.slides.charts/datalabel/)), yang membantu dalam penempatan overlay secara tepat.