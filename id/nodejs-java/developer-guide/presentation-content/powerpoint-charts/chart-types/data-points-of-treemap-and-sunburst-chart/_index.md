---
title: Sesuaikan Titik Data dalam Diagram Treemap dan Sunburst Menggunakan JavaScript
linktitle: Titik Data dalam Diagram Treemap dan Sunburst
type: docs
url: /id/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- diagram treemap
- diagram sunburst
- titik data
- warna label
- warna cabang
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelola titik data dalam diagram treemap dan sunburst dengan JavaScript dan Aspose.Slides untuk Node.js via Java, kompatibel dengan format PowerPoint."
---
## **Pendahuluan**

Di antara jenis diagram PowerPoint lainnya, ada dua jenis "hierarki" - **Treemap** dan **Sunburst** (juga dikenal sebagai Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph, atau Multi Level Pie Chart). Diagram ini menampilkan data hierarki yang diatur seperti pohon - dari daun hingga puncak cabang. Daun didefinisikan oleh titik data seri, dan setiap tingkat pengelompokan bersarang berikutnya didefinisikan oleh kategori yang bersangkutan. Aspose.Slides untuk Node.js via Java memungkinkan memformat titik data Sunburst Chart dan Treemap dalam JavaScript.

Berikut adalah Sunburst Chart, di mana data pada kolom Series1 mendefinisikan node daun, sementara kolom lainnya mendefinisikan datapoint hierarki:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Mulailah dengan menambahkan diagram Sunburst baru ke presentasi:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Lihat juga" %}} 
- [**Buat atau Perbarui Diagram Presentasi PowerPoint dalam JavaScript**](/slides/id/nodejs-java/create-chart/)
{{% /alert %}}

Jika perlu memformat titik data diagram, kita harus menggunakan yang berikut:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPointLevelsManager), [ChartDataPointLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPointLevel) kelas dan [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) metode menyediakan akses untuk memformat titik data Treemap dan Sunburst. [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPointLevelsManager) digunakan untuk mengakses kategori multi‑level ‑ ini merupakan kontainer dari [**ChartDataPointLevel**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPointLevel) objek. Pada dasarnya ini adalah pembungkus untuk [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartCategoryLevelsManager) dengan properti yang ditambahkan khusus untuk titik data. Kelas [**ChartDataPointLevel**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPointLevel) memiliki dua metode: [**getFormat**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) dan [**getDataLabel**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) yang menyediakan akses ke pengaturan yang bersangkutan.

## **Tampilkan Nilai Titik Data**

Tampilkan nilai titik data "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Atur Label dan Warna Titik Data**

Atur label data "Branch 1" agar menampilkan nama seri ("Series1") alih-alih nama kategori. Kemudian atur warna teks menjadi kuning:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Atur Warna Cabang Titik Data**

Ubah warna cabang "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Apakah saya dapat mengubah urutan (pengurutan) segmen dalam Sunburst/Treemap?**

Tidak. PowerPoint mengurutkan segmen secara otomatis (biasanya berdasarkan nilai menurun, searah jarum jam). Aspose.Slides meniru perilaku ini: Anda tidak dapat mengubah urutan secara langsung; Anda harus melakukannya dengan memproses data terlebih dahulu.

**Bagaimana tema presentasi memengaruhi warna segmen dan label?**

Warna diagram mewarisi [theme/palette](/slides/id/nodejs-java/presentation-theme/) presentasi kecuali Anda secara eksplisit mengatur isian/font. Untuk hasil yang konsisten, kunci isian solid dan format teks pada tingkat yang diperlukan.

**Apakah ekspor ke PDF/PNG mempertahankan warna cabang khusus dan pengaturan label?**

Ya. Saat mengekspor presentasi, pengaturan diagram (isi, label) dipertahankan dalam format output karena Aspose.Slides merender dengan format diagram yang diterapkan.

**Apakah saya dapat menghitung koordinat sebenarnya dari label/elemen untuk penempatan overlay khusus di atas diagram?**

Ya. Setelah tata letak diagram divalidasi, nilai X aktual dan Y aktual tersedia untuk elemen (misalnya, [DataLabel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datalabel/)), yang membantu penempatan overlay secara tepat.