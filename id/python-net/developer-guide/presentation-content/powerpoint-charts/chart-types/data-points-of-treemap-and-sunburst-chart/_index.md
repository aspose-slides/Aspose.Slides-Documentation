---
title: Sesuaikan Poin Data dalam Diagram Treemap dan Sunburst di Python
linktitle: Poin Data dalam Diagram Treemap dan Sunburst
type: docs
url: /id/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- diagram treemap
- diagram sunburst
- poin data
- warna label
- warna cabang
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelola poin data dalam diagram treemap dan sunburst dengan Aspose.Slides untuk Python via .NET, kompatibel dengan format PowerPoint dan OpenDocument."
---
## **Introduction**

Di antara tipe diagram PowerPoint lainnya, terdapat dua tipe hierarkis—**Treemap** dan **Sunburst** (juga dikenal sebagai Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph, atau Multi-Level Pie Chart). Diagram ini menampilkan data hierarkis yang diatur sebagai pohon—dari daun hingga puncak cabang. Daun didefinisikan oleh poin data seri, dan setiap tingkat pengelompokan bersarang berikutnya didefinisikan oleh kategori yang sesuai. Aspose.Slides for Python via .NET memungkinkan Anda memformat poin data diagram Sunburst dan Treemap dalam Python.

Berikut adalah diagram Sunburst dimana data pada kolom Series1 mendefinisikan node daun, sementara kolom lainnya mendefinisikan poin data hierarkis:

![Sunburst chart example](sunburst_example.png)

Mari kita mulai dengan menambahkan diagram Sunburst baru ke presentasi:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="See also" %}}
- [**Buat Diagram Sunburst**](/slides/id/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Jika Anda perlu memformat poin data diagram, gunakan API berikut:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointlevel/), dan properti [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Mereka memberikan akses untuk memformat poin data dalam diagram Treemap dan Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) digunakan untuk mengakses kategori multi‑tingkat; ia mewakili sebuah kontainer objek [ChartDataPointLevel]. Pada dasarnya ini adalah pembungkus di atas [ChartCategoryLevelsManager](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartcategorylevelsmanager/) dengan properti tambahan yang khusus untuk poin data. Tipe [ChartDataPointLevel](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointlevel/) mengekspos dua properti—[format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointlevel/format/) dan [label](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointlevel/label/)—yang menyediakan akses ke pengaturan yang bersangkutan.

## **Display Data Point Values**

Bagian ini menunjukkan cara menampilkan nilai untuk tiap poin data dalam diagram Treemap dan Sunburst. Anda akan melihat cara mengaktifkan label nilai untuk poin yang dipilih.

Tampilkan nilai dari poin data “Leaf 4”:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Set Labels and Colors for Data Points**

Bagian ini menunjukkan cara mengatur label dan warna khusus untuk tiap poin data dalam diagram Treemap dan Sunburst. Anda akan belajar cara mengakses poin data tertentu, menetapkan label, dan menerapkan isian padat untuk menyorot node penting.

Atur label data “Branch 1” agar menampilkan nama seri (“Series1”) alih‑alih nama kategori, lalu setel warna teks menjadi kuning:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Set Branch Colors for Data Points**

Gunakan warna cabang untuk mengontrol bagaimana node induk dan anak secara visual dikelompokkan dalam diagram Treemap dan Sunburst. Bagian ini menunjukkan cara mengatur warna cabang khusus untuk poin data tertentu sehingga Anda dapat menyorot subtree penting dan meningkatkan keterbacaan diagram.

Ubah warna cabang “Stem 4”:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **FAQ**

**Apakah saya dapat mengubah urutan (penyortiran) segmen dalam Sunburst/Treemap?**

Tidak. PowerPoint secara otomatis menyortir segmen (biasanya berdasarkan nilai menurun, searah jarum jam). Aspose.Slides meniru perilaku ini: Anda tidak dapat mengubah urutan secara langsung; Anda harus melakukannya dengan memproses data sebelumnya.

**Bagaimana tema presentasi memengaruhi warna segmen dan label?**

Warna diagram mewarisi [theme/palette](/slides/id/python-net/presentation-theme/) presentasi kecuali Anda secara eksplisit mengatur isian/font. Untuk hasil yang konsisten, kunci isian padat dan pemformatan teks pada tingkat yang diperlukan.

**Apakah ekspor ke PDF/PNG mempertahankan warna cabang khusus dan pengaturan label?**

Ya. Saat mengekspor presentasi, pengaturan diagram (isian, label) dipertahankan dalam format keluaran karena Aspose.Slides merender dengan format diagram yang diterapkan.

**Apakah saya dapat menghitung koordinat aktual label/elemen untuk penempatan overlay khusus di atas diagram?**

Ya. Setelah tata letak diagram divalidasi, `actual_x`/`actual_y` tersedia untuk elemen (misalnya, sebuah [DataLabel](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/)), yang membantu dalam penempatan overlay secara tepat.