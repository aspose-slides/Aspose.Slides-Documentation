---
title: Sesuaikan Titik Data pada Bagan Treemap dan Sunburst di Java
linktitle: Titik Data dalam Bagan Treemap dan Sunburst
type: docs
url: /id/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- bagan treemap
- bagan sunburst
- bagan hierarki
- titik data
- label data
- warna cabang
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara membuat data hierarkis dan menyesuaikan tingkat, label, serta warna pada bagan Treemap dan Sunburst dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Bagan Treemap dan Sunburst menampilkan jenis data hierarki yang sama, tetapi menggunakan tata letak yang berbeda. Treemap menggambar hierarki sebagai persegi panjang bersarang yang area‑nya mewakili nilai daun. Sunburst menggambarnya sebagai cincin konsentrik: grup tingkat atas berada di dekat pusat, dan kategori daun berada pada cincin terluar.

Di Aspose.Slides untuk Java, setiap nilai numerik adalah sebuah [IChartDataPoint](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/). Metode [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) menyediakan akses ke daun dan grup induknya. Artikel ini menjelaskan pemetaan tersebut dan menunjukkan cara membuat serta memformat kedua tipe bagan dari data contoh yang sama.

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

Setiap baris membuat satu kategori daun dan satu titik data. Tingkat pengelompokan kategori menggambarkan jalur dari daun tersebut ke induknya. Untuk baris pertama, jalurnya adalah `Consumer > Computers > Laptops`.

Indeks yang dikembalikan oleh [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) berjalan dari daun ke atas:

| Indeks `getDataPointLevels()` | Tingkat logis | Representasi Treemap | Representasi Sunburst |
| ---: | --- | --- | --- |
| `0` | Daun | Persegi nilai | Segmen cincin terluar |
| `1` | Batang | Persegi induk atau header | Segmen cincin tengah |
| `2` | Cabang | Persegi tingkat atas atau header | Segmen cincin dalam |

Urutan ini sama untuk kedua tipe bagan meskipun tata letak visualnya berbeda. Sebuah segmen induk dibagi oleh beberapa daun. Untuk memformatnya, gunakan tingkat yang sesuai dari titik data pertama pada grup tersebut. Misalnya, cabang `Consumer` dimulai dengan titik `Laptops`, sementara batang `Software` dimulai dengan titik `Licenses`. Menyimpan referensi ke titik‑titik tersebut lebih jelas dan lebih aman dibandingkan menggunakan ekspresi yang tidak dijelaskan seperti `dataPoints.get_Item(0)` atau `dataPoints.get_Item(6)`.

## **Membuat dan Menyesuaikan Kedua Tipe Bagan**

Contoh lengkap berikut membuat Treemap pada slide pertama dan Sunburst pada slide kedua. Contoh ini membangun hierarki, menampilkan nilai untuk `Tablets`, menerapkan warna tetap pada tingkat yang dipilih, memformat label cabang, dan menyimpan presentasi.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Tambahkan kategori daun. Item pengelompokan hanya diatur ketika grup baru dimulai;
        // kategori berikut tetap dalam grup tersebut hingga item lain diatur.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Tampilkan kategori dan nilai pada daun Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Format cabang Consumer lewat daun pertama dalam cabang tersebut.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Format batang Software lewat daun pertama dalam batang tersebut.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout memengaruhi label induk pada Treemap; Sunburst menggunakan segmen cincin.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sel sel kategori dan sel nilai menggunakan baris worksheet yang sama, sehingga posisi koleksi mereka tetap selaras. Ketika Anda bekerja dengan bagan yang sudah ada alih‑alih membuat yang baru, periksa baris‑baris kategori terlebih dahulu dan simpan referensi bernama ke titik data serta tingkat yang ingin Anda format.

## **Perilaku dan Pertimbangan Praktis**

### **Perbedaan Treemap dan Sunburst**

- Treemap menggunakan luas untuk menyampaikan nilai dan persegi panjang bersarang untuk menyampaikan hierarki. Metode [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) mengontrol bagaimana label induk muncul pada tipe bagan ini.
- Sunburst menggunakan sudut untuk menyampaikan nilai dan kedalaman cincin untuk menyampaikan hierarki. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) tidak mengontrol label cincinnya.
- Kedua tipe bagan menggunakan tingkat pengelompokan kategori yang sama dan urutan daun‑ke‑induk yang sama yang dikembalikan oleh [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), sehingga kode pembuatan data dan pemformatan tingkat dapat digunakan bersama.
- Nilai induk dihitung dari daun‑daun keturunan mereka. Jangan menambahkan titik numerik terpisah untuk cabang atau batang.

### **Pengurutan dan Urutan Segmen**

Mesin tata letak bagan menentukan penempatan akhir persegi panjang dan segmen cincin. Kelompokkan baris‑baris kategori yang terkait bersama sebelum menambahkannya, tetapi jangan bergantung pada posisi persegi panjang atau sudut awal tertentu. Jika urutan memiliki makna, sertakan dalam label atau gunakan tipe bagan dengan sumbu kategori yang eksplisit.

### **Tema dan Warna Tetap**

Tingkat bagan yang belum diformat mewarisi warna dari tema presentasi. Contoh ini menggunakan isian RGB eksplisit untuk output yang dapat diprediksi. Jika bagan harus mengikuti perubahan tema, gunakan warna skema alih‑alih nilai RGB tetap dan hindari menimpa setiap tingkat. Juga periksa kontras label setelah mengubah isian cabang atau batang.

### **Label dan Ruang yang Tersedia**

PowerPoint dapat menyembunyikan atau memotong label ketika segmen terlalu kecil. Membesarkan ukuran bagan, memendekkan nama kategori, atau menampilkan lebih sedikit bidang label biasanya menghasilkan hasil yang lebih jelas. Sebuah label dapat menggabungkan nama kategori, nama seri, dan nilai melalui [IDataLabelFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabelformat/), tetapi mengaktifkan semua bidang sering membuat bagan hierarki sulit dibaca.

### **Ekspor dan Rendering**

Menyimpan ke PPTX membuat bagan dapat diedit. Ketika Aspose.Slides merender presentasi ke PDF atau gambar, isian dan pengaturan label yang didukung dirender bersama bagan. Substitusi font dan perbedaan kecil dalam ruang tata letak yang tersedia dapat mengubah pembungkusan baris atau visibilitas label, sehingga pasang font yang diperlukan dan verifikasi target ekspor penting.

## **FAQ**

**Mengapa mengubah tingkat induk memengaruhi beberapa daun?**

Sebuah cabang atau batang merupakan segmen visual yang dibagi. [IChartDataPointLevel](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapointlevel/) dapat diakses melalui daun keturunan, tetapi pemformatannya berlaku untuk segmen induk yang dibagi, bukan hanya pada daun itu saja.

**Mengapa sebuah label data tidak muncul?**

Pertama aktifkan bidang yang diperlukan pada objek [IDataLabelFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabelformat/) label. Kemudian periksa apakah segmen memiliki ruang yang cukup. Tata letak label induk Treemap, dimensi bagan, panjang label, ukuran font, dan jumlah bidang yang diaktifkan semuanya memengaruhi apakah label dapat ditampilkan.

**Apakah saya dapat menentukan urutan atau koordinat tepat segmen?**

Anda dapat mengontrol urutan baris sumber dan menjaga tiap grup tetap berurutan, tetapi Anda tidak dapat menetapkan persegi panjang Treemap atau sudut Sunburst secara tepat. Mesin tata letak bagan menghitungnya dari hierarki, nilai, dan ruang yang tersedia.

**Mengapa warna berubah setelah tema presentasi berubah?**

Isian berbasis tema dirancang mengikuti palet presentasi. Terapkan warna RGB eksplisit pada tingkat yang harus tetap, atau pertahankan warna skema ketika penyesuaian ke tema baru diinginkan.

**Apakah pemformatan khusus akan dipertahankan dalam ekspor PDF dan gambar?**

Ya, isian bagan dan pengaturan label yang didukung disertakan saat rendering. Untuk hasil yang konsisten di semua sistem, sediakan font yang diperlukan dan uji ukuran ekspor akhir karena penyesuaian label bergantung pada tata letak.

## **Lihat Juga**

- [Create Treemap charts](/slides/id/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/id/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/id/java/export-chart/)
- [Manage presentation themes](/slides/id/java/presentation-theme/)