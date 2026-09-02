---
title: Sesuaikan Titik Data pada Grafik Treemap dan Sunburst di .NET
linktitle: Titik Data pada Grafik Treemap dan Sunburst
type: docs
url: /id/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- grafik treemap
- grafik sunburst
- grafik hierarkis
- titik data
- label data
- warna cabang
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat data hierarkis dan menyesuaikan tingkat, label, serta warna pada grafik Treemap dan Sunburst dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Grafik Treemap dan Sunburst menampilkan jenis data hierarkis yang sama, tetapi menggunakan tata letak yang berbeda. Treemap menggambar hierarki sebagai persegi panjang bersarang yang area‑nya mewakili nilai daun. Sunburst menggambarnya sebagai cincin konsentris: grup tingkat atas berada di dekat pusat, dan kategori daun berada pada cincin terluar.

Di Aspose.Slides untuk .NET, setiap nilai numerik adalah sebuah [IChartDataPoint](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/). Koleksi [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) menyediakan akses ke daun dan grup orang tuanya. Artikel ini menjelaskan pemetaan tersebut dan menunjukkan cara membuat serta memformat kedua jenis grafik dari data contoh yang sama.

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **Memahami Kategori, Titik Data, dan Tingkat**

Contoh yang digunakan di bawah memiliki tiga tingkat kategori dan satu seri numerik:

| Cabang | Batang | Daun | Pendapatan |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Setiap baris membuat satu kategori daun dan satu titik data. Tingkat pengelompokan kategori menggambarkan jalur dari daun tersebut ke orang tuanya. Untuk baris pertama, jalurnya adalah `Consumer > Computers > Laptops`.

Indeks dalam [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) berjalan dari daun ke atas:

| Indeks `DataPointLevels` | Tingkat logis | Representasi Treemap | Representasi Sunburst |
| ---: | --- | --- | --- |
| `0` | Daun | Persegi panjang nilai | Segmen cincin terluar |
| `1` | Batang | Persegi panjang atau header orang tua | Segmen cincin tengah |
| `2` | Cabang | Persegi panjang atau header tingkat atas | Segmen cincin dalam |

Urutan ini sama untuk kedua jenis grafik meskipun tata letak visualnya berbeda. Segmen orang tua dibagi oleh beberapa daun. Untuk memformatnya, gunakan tingkat yang sesuai dari titik data pertama dalam grup tersebut. Misalnya, cabang `Consumer` dimulai dengan titik `Laptops`, sementara batang `Software` dimulai dengan titik `Licenses`. Menyimpan referensi ke titik‑titik itu lebih jelas dan lebih aman daripada menggunakan ekspresi yang tidak dijelaskan seperti `dataPoints[0]` atau `dataPoints[6]`.

## **Membuat dan Menyesuaikan Kedua Jenis Grafik**

Contoh lengkap berikut membuat Treemap pada slide pertama dan Sunburst pada slide kedua. Ia membangun hierarki, menampilkan nilai untuk `Tablets`, menerapkan warna tetap pada tingkat yang dipilih, memformat label cabang, dan menyimpan presentasi.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Tambahkan kategori daun. Item pengelompokan hanya diatur ketika grup baru dimulai;
    // kategori berikut tetap berada dalam grup tersebut sampai item lain diatur.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Tampilkan kategori dan nilai pada daun Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Format cabang Consumer melalui daun pertama dalam cabang tersebut.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Format batang Software melalui daun pertama dalam batang tersebut.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout memengaruhi label orang tua pada Treemap; Sunburst menggunakan segmen cincin.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Sel sel kategori dan sel nilai menggunakan baris lembar kerja yang sama, sehingga posisi koleksi mereka tetap selaras. Saat Anda bekerja dengan grafik yang sudah ada daripada membuat yang baru, periksa baris‑baris kategori terlebih dahulu dan simpan referensi bernama ke titik data serta tingkat yang ingin Anda format.

## **Perilaku dan Pertimbangan Praktis**

### **Perbedaan Treemap dan Sunburst**

- Treemap menggunakan area untuk mengkomunikasikan nilai dan persegi panjang bersarang untuk mengkomunikasikan hierarki. Properti [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/parentlabellayout/) mengontrol bagaimana label orang tua muncul pada jenis grafik ini.
- Sunburst menggunakan sudut untuk mengkomunikasikan nilai dan kedalaman cincin untuk mengkomunikasikan hierarki. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/parentlabellayout/) tidak mengontrol label cincinnya.
- Kedua jenis grafik menggunakan tingkat pengelompokan kategori yang sama dan urutan daun‑ke‑orang‑tua yang sama dalam `DataPointLevels`, sehingga kode pembuatan data dan pemformatan tingkat dapat dipakai bersama.
- Nilai orang tua dihitung dari daun‑daun turunannya. Jangan tambahkan titik numerik terpisah untuk cabang atau batang.

### **Pengurutan dan Urutan Segmen**

Mesin tata letak grafik menentukan penempatan akhir persegi panjang dan segmen cincin. Kelompokkan baris‑baris kategori yang terkait bersama sebelum menambahkannya, tetapi jangan bergantung pada posisi persegi panjang atau sudut awal tertentu. Jika urutan memiliki arti, cantumkan dalam label atau gunakan tipe grafik dengan sumbu kategori eksplisit.

### **Tema dan Warna Tetap**

Tingkat grafik yang belum diformat mewarisi warna dari tema presentasi. Contoh ini menggunakan isian RGB eksplisit untuk hasil yang dapat diprediksi. Jika grafik harus mengikuti perubahan tema, gunakan warna skema alih‑alih nilai RGB tetap dan hindari menimpa setiap tingkat. Juga periksa kontras label setelah mengubah isian cabang atau batang.

### **Label dan Ruang yang Tersedia**

PowerPoint dapat menyembunyikan atau memotong label ketika segmen terlalu kecil. Memperbesar ukuran grafik, memendekkan nama kategori, atau menampilkan lebih sedikit bidang label biasanya menghasilkan tampilan yang lebih jelas. Sebuah label dapat menggabungkan nama kategori, nama seri, dan nilai melalui [IDataLabelFormat](https://reference.aspose.com/slides/id/net/aspose.slides.charts/idatalabelformat/), tetapi mengaktifkan semua bidang sering membuat grafik hierarki sulit dibaca.

### **Ekspor dan Rendering**

Menyimpan ke PPTX menjaga grafik tetap dapat diedit. Ketika Aspose.Slides merender presentasi ke PDF atau gambar, isian dan pengaturan label yang didukung dirender bersama grafik. Substitusi font dan perbedaan kecil dalam ruang tata letak yang tersedia dapat mengubah pembungkus baris atau visibilitas label, jadi pasang font yang diperlukan dan verifikasi tujuan ekspor yang penting.

## **FAQ**

**Mengapa mengubah tingkat orang tua memengaruhi beberapa daun?**

Cabang atau batang merupakan segmen visual yang dibagi. [IChartDataPointLevel](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointlevel/) dapat diakses melalui daun turunannya, tetapi pemformatan berlaku pada segmen orang tua yang dibagi, bukan hanya pada daun tersebut.

**Mengapa label data tidak muncul?**

Pertama aktifkan bidang yang diperlukan pada objek [IDataLabelFormat](https://reference.aspose.com/slides/id/net/aspose.slides.charts/idatalabelformat/) label. Kemudian periksa apakah segmen memiliki ruang yang cukup. Tata letak label orang tua Treemap, dimensi grafik, panjang label, ukuran font, dan jumlah bidang yang diaktifkan semuanya memengaruhi apakah label dapat ditampilkan.

**Bisakah saya mengatur urutan atau koordinat tepat segmen?**

Anda dapat mengontrol urutan baris sumber dan menjaga setiap grup tetap berurutan, tetapi Anda tidak dapat menetapkan persegi panjang Treemap atau sudut Sunburst secara tepat. Mesin tata letak grafik menghitungnya dari hierarki, nilai, dan ruang yang tersedia.

**Mengapa warna berubah setelah tema presentasi berubah?**

Isian berbasis tema dirancang untuk mengikuti palet presentasi. Terapkan warna RGB eksplisit pada tingkat yang harus tetap, atau pertahankan warna skema ketika menyesuaikan dengan tema baru lebih disukai.

**Apakah pemformatan khusus akan dipertahankan dalam ekspor PDF dan gambar?**

Ya, isian grafik dan pengaturan label yang didukung disertakan saat rendering. Untuk hasil yang konsisten di seluruh sistem, sediakan font yang diperlukan dan uji ukuran ekspor akhir karena penyesuaian label bergantung pada tata letak.

## **Lihat Juga**

- [Create Treemap charts](/slides/id/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/id/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/id/net/export-chart/)
- [Manage presentation themes](/slides/id/net/presentation-theme/)