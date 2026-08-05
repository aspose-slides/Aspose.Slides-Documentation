---
title: "Sesuaikan Titik Data dalam Diagram Treemap dan Sunburst di PHP"
linktitle: "Titik Data dalam Diagram Treemap dan Sunburst"
type: docs
url: /id/php-java/data-points-of-treemap-and-sunburst-chart/
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
- PHP
- Aspose.Slides
description: "Pelajari cara membuat data hierarkis dan menyesuaikan tingkat, label, serta warna dalam diagram Treemap dan Sunburst dengan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

Treemap dan Sunburst menampilkan jenis data hierarkis yang sama, tetapi menggunakan tata letak yang berbeda. Treemap menggambar hierarki sebagai persegi panjang bersarang yang luasnya mewakili nilai daun. Sunburst menggambarnya sebagai cincin konsentris: grup tingkat atas berada di dekat pusat, dan kategori daun berada pada cincin luar.

Di Aspose.Slides untuk PHP via Java, setiap nilai numerik adalah sebuah [ChartDataPoint](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapoint/). Metode [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) menyediakan akses ke daun dan grup induknya. Artikel ini menjelaskan pemetaan tersebut dan menunjukkan cara membuat serta memformat kedua tipe diagram dari data contoh yang sama.

![Diagram Treemap dengan cabang Consumer dan Business](treemap-hierarchy.png)

![Diagram Sunburst dengan hierarki Consumer dan Business yang sama](sunburst-hierarchy.png)

## **Memahami Kategori, Titik Data, dan Tingkat**

Contoh yang digunakan di bawah memiliki tiga tingkat kategori dan satu seri numerik:

| Cabang | Stam | Daun | Pendapatan |
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

Indeks yang dikembalikan oleh [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) berjalan dari daun ke atas:

| `getDataPointLevels()` index | Tingkat logis | Representasi Treemap | Representasi Sunburst |
| ---: | --- | --- | --- |
| `0` | Daun | Persegi nilai | Segmen cincin luar |
| `1` | Stam | Persegi induk atau header | Segmen cincin tengah |
| `2` | Cabang | Persegi tingkat atas atau header | Segmen cincin dalam |

Urutan ini sama untuk kedua tipe diagram meskipun tata letak visualnya berbeda. Sebuah segmen induk dibagi oleh beberapa daun. Untuk memformatnya, gunakan tingkat yang sesuai dari titik data pertama dalam grup tersebut. Misalnya, cabang `Consumer` dimulai dengan titik `Laptops`, sedangkan stam `Software` dimulai dengan titik `Licenses`. Menyimpan referensi ke titik‑titik tersebut lebih jelas dan aman daripada menggunakan ekspresi yang tidak dijelaskan seperti `$dataPoints->get_Item(0)` atau `$dataPoints->get_Item(6)`.

## **Membuat dan Menyesuaikan Kedua Tipe Diagram**

Contoh lengkap berikut membuat Treemap pada slide pertama dan Sunburst pada slide kedua. Ia membangun hierarki, menampilkan nilai untuk `Tablets`, menerapkan warna tetap pada tingkat tertentu, memformat label cabang, dan menyimpan presentasi.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Tambahkan kategori daun. Item pengelompokan hanya disetel ketika grup baru dimulai;
        // kategori berikutnya tetap berada dalam grup itu sampai item lain disetel.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Tampilkan kategori dan nilai pada daun Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Format cabang Consumer melalui daun pertama dalam cabang tersebut.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Format stam Software melalui daun pertama dalam stam tersebut.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout memengaruhi label induk Treemap; Sunburst menggunakan segmen cincin.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sel sel kategori dan sel nilai menggunakan baris worksheet yang sama, sehingga posisi koleksinya tetap selaras. Saat Anda bekerja dengan diagram yang sudah ada alih‑alih membuat yang baru, periksa baris kategori terlebih dahulu dan simpan referensi bernama ke titik data serta tingkat yang ingin Anda format.

## **Perilaku dan Pertimbangan Praktis**

### **Perbedaan Treemap dan Sunburst**

- Treemap menggunakan area untuk menyampaikan nilai dan persegi panjang bersarang untuk menyampaikan hierarki. Metode [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/#setParentLabelLayout) mengontrol bagaimana label induk muncul pada tipe diagram ini.
- Sunburst menggunakan sudut untuk menyampaikan nilai dan kedalaman cincin untuk menyampaikan hierarki. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartseries/#setParentLabelLayout) tidak mengontrol label cincinnya.
- Kedua tipe diagram menggunakan tingkat pengelompokan kategori yang sama dan urutan daun‑ke‑induk yang sama yang dikembalikan oleh [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), sehingga kode pembuatan data dan pemformatan tingkat dapat dipakai bersama.
- Nilai induk dihitung dari daun‑daun turunannya. Jangan menambahkan titik numerik terpisah untuk cabang atau stam.

### **Pengurutan dan Urutan Segmen**

Mesin tata letak diagram menentukan penempatan akhir persegi panjang dan segmen cincin. Susun baris kategori yang terkait bersama sebelum menambahkannya, tetapi jangan bergantung pada posisi persegi panjang atau sudut mulai tertentu. Jika urutan memiliki arti, sertakan dalam label atau gunakan tipe diagram dengan sumbu kategori yang eksplisit.

### **Tema dan Warna Tetap**

Tingkat diagram yang tidak diformat mewarisi warna dari tema presentasi. Contoh ini menggunakan isian RGB eksplisit untuk output yang dapat diprediksi. Jika diagram harus mengikuti perubahan tema, gunakan warna skema alih‑alih nilai RGB tetap dan hindari menimpa setiap tingkat. Periksa kontras label setelah mengubah isian cabang atau stam.

### **Label dan Ruang Tersedia**

PowerPoint dapat menyembunyikan atau memotong label ketika segmen terlalu kecil. Membesarkan ukuran diagram, memendekkan nama kategori, atau menampilkan lebih sedikit bidang label biasanya menghasilkan hasil yang lebih jelas. Sebuah label dapat menggabungkan nama kategori, nama seri, dan nilai melalui [DataLabelFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/), tetapi mengaktifkan semua bidang sering membuat diagram hierarki sulit dibaca.

### **Ekspor dan Rendering**

Menyimpan ke PPTX menjaga diagram tetap dapat diedit. Ketika Aspose.Slides merender presentasi ke PDF atau gambar, isian dan pengaturan label yang didukung dirender bersama diagram. Substitusi font dan perbedaan kecil dalam ruang tata letak yang tersedia dapat mengubah pembungkusan baris atau visibilitas label, jadi pasang font yang diperlukan dan verifikasi target ekspor penting.

## **FAQ**

**Mengapa mengubah tingkat induk memengaruhi beberapa daun?**

Sebuah cabang atau stam adalah segmen visual yang dibagi. [ChartDataPointLevel](https://reference.aspose.com/slides/id/php-java/aspose.slides/chartdatapointlevel/) dapat diakses melalui daun turunan, tetapi pemformatannya berlaku untuk segmen induk yang dibagi, bukan hanya pada daun tersebut.

**Mengapa label data tidak muncul?**

Pertama aktifkan bidang yang diperlukan pada objek [DataLabelFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/datalabelformat/) label. Kemudian periksa apakah segmen memiliki ruang yang cukup. Tata letak label induk Treemap, dimensi diagram, panjang label, ukuran font, dan jumlah bidang yang diaktifkan semuanya memengaruhi apakah label dapat ditampilkan.

**Bisakah saya menentukan urutan atau koordinat tepat segmen?**

Anda dapat mengontrol urutan baris sumber dan menjaga setiap grup tetap berurutan, tetapi tidak dapat menetapkan persegi panjang Treemap atau sudut Sunburst secara eksak. Mesin tata letak diagram menghitungnya dari hierarki, nilai, dan ruang yang tersedia.

**Mengapa warna berubah setelah tema presentasi diubah?**

Isian berbasis tema dirancang untuk mengikuti palet presentasi. Terapkan warna RGB eksplisit pada tingkat yang harus tetap tetap, atau pertahankan warna skema ketika menyesuaikan ke tema baru lebih diutamakan.

**Apakah format khusus akan dipertahankan dalam ekspor PDF dan gambar?**

Ya, isian diagram dan pengaturan label yang didukung disertakan saat rendering. Untuk hasil yang konsisten di berbagai sistem, sediakan font yang diperlukan dan uji ukuran ekspor akhir karena penyesuaian label bergantung pada tata letak.

## **Lihat Juga**

- [Buat diagram Treemap](/slides/id/php-java/create-chart/#create-tree-map-charts)
- [Buat diagram Sunburst](/slides/id/php-java/create-chart/#create-sunburst-charts)
- [Ekspor diagram presentasi](/slides/id/php-java/export-chart/)
- [Kelola tema presentasi](/slides/id/php-java/presentation-theme/)