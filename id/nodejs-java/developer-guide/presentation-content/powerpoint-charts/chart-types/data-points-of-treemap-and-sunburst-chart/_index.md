---
title: Sesuaikan Titik Data pada Diagram Treemap dan Sunburst dengan JavaScript
linktitle: Titik Data dalam Diagram Treemap dan Sunburst
type: docs
url: /id/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- diagram treemap
- diagram sunburst
- diagram hierarkis
- titik data
- label data
- warna cabang
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara membuat data hierarkis dan menyesuaikan tingkat, label, serta warna dalam diagram Treemap dan Sunburst dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Treemap dan Sunburst menampilkan jenis data hierarkis yang sama, tetapi menggunakan tata letak yang berbeda. Treemap menggambar hierarki sebagai persegi panjang bersarang yang area‑nya mewakili nilai daun. Sunburst menggambar sebagai cincin konsentris: grup tingkat atas berada di dekat pusat, dan kategori daun berada di cincin luar.

Di Aspose.Slides untuk Node.js via Java, setiap nilai numerik adalah sebuah [ChartDataPoint](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/). Metode [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) menyediakan akses ke daun dan grup induknya. Artikel ini menjelaskan pemetaan tersebut dan menunjukkan cara membuat serta memformat kedua jenis diagram dari data contoh yang sama.

![Diagram Treemap dengan cabang Consumer dan Business](treemap-hierarchy.png)

![Diagram Sunburst dengan hierarki Consumer dan Business yang sama](sunburst-hierarchy.png)

## **Pahami Kategori, Titik Data, dan Tingkat**

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

Indeks yang dikembalikan oleh [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) berjalan dari daun ke atas:

| `getDataPointLevels()` indeks | Tingkat logis | Representasi Treemap | Representasi Sunburst |
| ---: | --- | --- | --- |
| `0` | Daun | Persegi panjang nilai | Segmen cincin luar |
| `1` | Batang | Persegi panjang induk atau judul | Segmen cincin tengah |
| `2` | Cabang | Persegi panjang tingkat atas atau judul | Segmen cincin dalam |

Urutan ini sama untuk kedua jenis diagram meskipun tata letak visualnya berbeda. Segmen induk dibagi oleh beberapa daun. Untuk memformatnya, gunakan tingkat yang sesuai dari titik data pertama dalam grup tersebut. Misalnya, cabang `Consumer` dimulai dengan titik `Laptops`, sementara batang `Software` dimulai dengan titik `Licenses`. Menyimpan referensi ke titik‑titik itu lebih jelas dan lebih aman daripada menggunakan ekspresi yang tidak dijelaskan seperti `dataPoints.get_Item(0)` atau `dataPoints.get_Item(6)`.

## **Buat dan Sesuaikan Kedua Jenis Diagram**

Contoh lengkap berikut membuat Treemap pada slide pertama dan Sunburst pada slide kedua. Contoh ini membangun hierarki, menampilkan nilai untuk `Tablets`, menerapkan warna tetap pada tingkat yang dipilih, memformat label cabang, dan menyimpan presentasi.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Tambah kategori daun. Item pengelompokan hanya disetel ketika grup baru dimulai;
        // kategori berikut tetap dalam grup tersebut sampai item lain disetel.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Tampilkan kategori dan nilai pada daun Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Format cabang Consumer melalui daun pertama di cabang tersebut.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Format batang Software melalui daun pertama di batang tersebut.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout memengaruhi label induk Treemap; Sunburst menggunakan segmen cincin.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sel sel kategori dan sel nilai menggunakan baris worksheet yang sama, sehingga posisi koleksinya tetap selaras. Saat Anda bekerja dengan diagram yang sudah ada daripada membuat yang baru, periksa baris kategori terlebih dahulu dan simpan referensi bernama ke titik data serta tingkat yang ingin Anda format.

## **Perilaku dan Pertimbangan Praktis**

### **Perbedaan Treemap dan Sunburst**

- Treemap menggunakan area untuk menyampaikan nilai dan persegi panjang bersarang untuk menyampaikan hierarki. Metode [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) mengontrol tampilan label induk pada jenis diagram ini.
- Sunburst menggunakan sudut untuk menyampaikan nilai dan kedalaman cincin untuk menyampaikan hierarki. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) tidak mengontrol label cincinnya.
- Kedua jenis diagram menggunakan tingkat pengelompokan kategori yang sama dan urutan daun‑ke‑induk yang sama yang dikembalikan oleh [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), sehingga kode pembuatan data dan pemformatan tingkat dapat dipakai bersama.
- Nilai induk dihitung dari daun‑daun turunannya. Jangan menambahkan titik numerik terpisah untuk cabang atau batang.

### **Pengurutan dan Urutan Segmen**

Mesin tata letak diagram menentukan penempatan akhir persegi panjang dan segmen cincin. Kelompokkan baris kategori yang terkait bersama sebelum menambahkannya, tetapi jangan bergantung pada posisi persegi panjang atau sudut awal tertentu. Jika urutan memiliki makna, sertakan dalam label atau gunakan jenis diagram dengan sumbu kategori yang eksplisit.

### **Tema dan Warna Tetap**

Tingkat diagram yang tidak diformat mewarisi warna dari tema presentasi. Contoh menggunakan isian RGB eksplisit untuk output yang dapat diprediksi. Jika diagram harus mengikuti perubahan tema, gunakan warna skema alih‑alih nilai RGB tetap dan hindari menimpa setiap tingkat. Juga periksa kontras label setelah mengubah isian cabang atau batang.

### **Label dan Ruang Tersedia**

PowerPoint dapat menyembunyikan atau memotong label ketika segmen terlalu kecil. Memperbesar ukuran diagram, mempersingkat nama kategori, atau menampilkan lebih sedikit bidang label biasanya menghasilkan hasil yang lebih jelas. Sebuah label dapat menggabungkan nama kategori, nama seri, dan nilai melalui [DataLabelFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datalabelformat/), tetapi mengaktifkan semua bidang sering membuat diagram hierarkis sulit dibaca.

### **Ekspor dan Rendering**

Menyimpan ke PPTX menjaga diagram tetap dapat disunting. Saat Aspose.Slides merender presentasi ke PDF atau gambar, isian dan pengaturan label yang didukung dirender bersama diagram. Substitusi font dan perbedaan kecil dalam ruang tata letak yang tersedia dapat mengubah pembungkusan baris atau visibilitas label, jadi instal font yang diperlukan dan verifikasi target ekspor yang penting.

## **Tanya Jawab**

**Mengapa mengubah tingkat induk memengaruhi beberapa daun?**

Cabang atau batang adalah segmen visual yang dibagi. [ChartDataPointLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapointlevel/) dapat diakses melalui daun turunan, tetapi pemformatannya berlaku untuk segmen induk bersama, bukan hanya daun itu saja.

**Mengapa label data tidak muncul?**

Pertama, aktifkan bidang yang diperlukan pada objek [DataLabelFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datalabelformat/) label. Kemudian periksa apakah segmen memiliki ruang yang cukup. Tata letak label induk Treemap, dimensi diagram, panjang label, ukuran font, dan jumlah bidang yang diaktifkan semuanya memengaruhi apakah label dapat ditampilkan.

**Bisakah saya mengatur urutan atau koordinat tepat segmen?**

Anda dapat mengontrol urutan baris sumber dan menjaga tiap grup tetap berurutan, tetapi tidak dapat menetapkan persegi panjang Treemap atau sudut Sunburst secara tepat. Mesin tata letak diagram menghitungnya dari hierarki, nilai, dan ruang yang tersedia.

**Mengapa warna berubah setelah tema presentasi berubah?**

Isian berbasis tema dirancang untuk mengikuti palet presentasi. Terapkan warna RGB eksplisit pada tingkat yang harus tetap tetap, atau pertahankan warna skema ketika penyesuaian ke tema baru lebih diinginkan.

**Apakah pemformatan khusus akan dipertahankan dalam ekspor PDF dan gambar?**

Ya, isian diagram dan pengaturan label yang didukung disertakan selama proses rendering. Untuk hasil yang konsisten antar sistem, sediakan font yang diperlukan dan uji ukuran ekspor akhir karena penyesuaian label tergantung pada tata letak.

## **Lihat Juga**

- [Buat diagram Treemap](/slides/id/nodejs-java/create-chart/#creating-tree-map-charts)
- [Buat diagram Sunburst](/slides/id/nodejs-java/create-chart/#creating-sunburst-charts)
- [Ekspor diagram presentasi](/slides/id/nodejs-java/export-chart/)
- [Kelola tema presentasi](/slides/id/nodejs-java/presentation-theme/)