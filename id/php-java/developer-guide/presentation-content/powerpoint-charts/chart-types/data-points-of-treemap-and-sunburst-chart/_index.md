---
title: Sesuaikan Titik Data dalam Diagram Treemap dan Sunburst Menggunakan PHP
linktitle: Titik Data dalam Diagram Treemap dan Sunburst
type: docs
url: /id/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- diagram treemap
- diagram sunburst
- titik data
- warna label
- warna cabang
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengelola titik data dalam diagram treemap dan sunburst dengan Aspose.Slides untuk PHP via Java, kompatibel dengan format PowerPoint."
---
## **Pendahuluan**

Di antara jenis diagram PowerPoint lainnya, ada dua jenis “hierarkis” – **Treemap** dan **Sunburst** chart (juga dikenal sebagai Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph atau Multi Level Pie Chart). Diagram‑diagram ini menampilkan data hierarkis yang diatur seperti pohon – dari daun hingga puncak cabang. Daun didefinisikan oleh titik data seri, dan setiap tingkat pengelompokan bersarang berikutnya didefinisikan oleh kategori yang bersangkutan. Aspose.Slides for PHP via Java memungkinkan pemformatan titik data Sunburst Chart dan Treemap.

Berikut contoh Sunburst Chart, di mana data pada kolom Series1 mendefinisikan node daun, sementara kolom lain mendefinisikan titik data hierarkis:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Mari mulai dengan menambahkan diagram Sunburst baru ke presentasi:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Lihat juga" %}} 
- [**Create or Update PowerPoint Presentation Charts in PHP**](/slides/id/php-java/create-chart/)
{{% /alert %}}

Jika perlu memformat titik data diagram, gunakan hal‑hal berikut:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevel/) kelas 
dan [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) metode 
menyediakan akses untuk memformat titik data Treemap dan Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevelsmanager/)
digunakan untuk mengakses kategori multi‑tingkat – ia mewakili kontainer dari 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevel/) objek.  
Pada dasarnya ia merupakan wrapper untuk 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartcategorylevelsmanager/) dengan
properti‑properti tambahan khusus untuk titik data. 
Kelas [**ChartDataPointLevel**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevel/) memiliki
dua metode: [**getFormat**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevel/#getFormat) dan 
[**getDataLabel**](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevel/#getLabel) yang
menyediakan akses ke pengaturan yang bersesuaian.

## **Tampilkan Nilai Titik Data**
Tampilkan nilai titik data “Leaf 4”:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Atur Label dan Warna Titik Data**
Atur label data “Branch 1” agar menampilkan nama seri (“Series1”) alih‑alih nama kategori. Kemudian atur warna teks menjadi kuning:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Atur Warna Cabang Titik Data**
Ubah warna cabang “Steam 4”:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Apakah saya dapat mengubah urutan (penyortiran) segmen pada Sunburst/Treemap?**

Tidak. PowerPoint menyortir segmen secara otomatis (biasanya menurun, searah jarum jam). Aspose.Slides meniru perilaku ini: Anda tidak dapat mengubah urutan secara langsung; Anda melakukannya dengan memproses data terlebih dahulu.

**Bagaimana tema presentasi memengaruhi warna segmen dan label?**

Warna diagram mewarisi [tema/palet](/slides/id/php-java/presentation-theme/) presentasi kecuali Anda secara eksplisit mengatur isian/font. Untuk hasil yang konsisten, gunakan isian padat dan format teks pada tingkat yang diperlukan.

**Apakah ekspor ke PDF/PNG mempertahankan warna cabang khusus dan pengaturan label?**

Ya. Saat mengekspor presentasi, pengaturan diagram (isian, label) dipertahankan dalam format output karena Aspose.Slides merender dengan format diagram yang telah diterapkan.

**Bisakah saya menghitung koordinat sebenarnya dari label/elemen untuk penempatan overlay khusus di atas diagram?**

Ya. Setelah tata letak diagram divalidasi, nilai *x* aktual dan *y* aktual tersedia untuk elemen (misalnya, sebuah [DataLabel](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabel/)), yang membantu dalam penempatan overlay secara tepat.