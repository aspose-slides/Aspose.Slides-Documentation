---
title: Sesuaikan Titik Data dalam Diagram Treemap dan Sunburst di Android
linktitle: Titik Data dalam Diagram Treemap dan Sunburst
type: docs
url: /id/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- diagram treemap
- diagram sunburst
- titik data
- warna label
- warna cabang
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengelola titik data dalam diagram treemap dan sunburst dengan Aspose.Slides untuk Android via Java, kompatibel dengan format PowerPoint."
---
## **Pendahuluan**

Di antara tipe diagram PowerPoint lainnya, ada dua tipe “hierarkis” – **Treemap** dan **Sunburst** chart (juga dikenal sebagai Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph atau Multi Level Pie Chart). Diagram ini menampilkan data hierarkis yang diorganisir sebagai pohon – dari daun hingga puncak cabang. Daun didefinisikan oleh titik data seri, dan setiap tingkat pengelompokan bersarang berikutnya didefinisikan oleh kategori yang bersangkutan. Aspose.Slides for Android via Java memungkinkan pemformatan titik data Sunburst Chart dan Treemap dalam Java.

Berikut adalah Sunburst Chart, di mana data pada kolom Series1 mendefinisikan node daun, sementara kolom lain mendefinisikan titik data hierarkis:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Mari kita mulai dengan menambahkan diagram Sunburst baru ke presentasi:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="See also" %}} 
- [**Buat atau Perbarui Diagram Presentasi PowerPoint di Android**](/slides/id/androidjava/create-chart/)
{{% /alert %}}

Jika perlu memformat titik data diagram, gunakan hal berikut:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPointLevel) classes 
dan [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
menyediakan akses untuk memformat titik data Treemap dan Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
digunakan untuk mengakses kategori multi‑level – ia mewakili kontainer dari 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPointLevel) objects. 
Pada dasarnya ini adalah wrapper untuk 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartCategoryLevelsManager) dengan properti yang ditambahkan khusus untuk titik data. 
Kelas [**IChartDataPointLevel**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPointLevel) memiliki dua metode: [**getFormat**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) dan 
[**getDataLabel**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) yang menyediakan akses ke pengaturan yang bersangkutan.

## **Tampilkan Nilai Titik Data**
Tampilkan nilai titik data “Leaf 4”:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Atur Label dan Warna Titik Data**
Atur label data “Branch 1” untuk menampilkan nama seri (“Series1”) alih‑alih nama kategori. Kemudian atur warna teks menjadi kuning:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Atur Warna Cabang Titik Data**
Ubah warna cabang “Steam 4”:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Apakah saya dapat mengubah urutan (pengurutan) segmen dalam Sunburst/Treemap?**

Tidak. PowerPoint mengurutkan segmen secara otomatis (biasanya menurun, berlawanan arah jarum jam). Aspose.Slides meniru perilaku ini: Anda tidak dapat mengubah urutan secara langsung; Anda melakukannya dengan memproses data sebelumnya.

**Bagaimana tema presentasi memengaruhi warna segmen dan label?**

Warna diagram mewarisi [tema/palet](/slides/id/androidjava/presentation-theme/) presentasi kecuali Anda secara eksplisit mengatur isian/font. Untuk hasil yang konsisten, tentukan isian solid dan pemformatan teks pada tingkat yang diperlukan.

**Apakah ekspor ke PDF/PNG mempertahankan warna cabang khusus dan pengaturan label?**

Ya. Saat mengekspor presentasi, pengaturan diagram (isi, label) dipertahankan dalam format output karena Aspose.Slides merender dengan pemformatan diagram yang diterapkan.

**Bisakah saya menghitung koordinat sebenarnya dari label/elemen untuk penempatan overlay khusus di atas diagram?**

Ya. Setelah tata letak diagram divalidasi, nilai *x* aktual dan *y* aktual tersedia untuk elemen (misalnya, sebuah [DataLabel](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/datalabel/)), yang membantu dalam penempatan overlay secara tepat.