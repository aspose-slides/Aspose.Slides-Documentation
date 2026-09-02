---
title: Sesuaikan Titik Data pada Diagram Treemap dan Sunburst di C++
linktitle: Titik Data pada Diagram Treemap dan Sunburst
type: docs
url: /id/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- diagram treemap
- diagram sunburst
- diagram hierarki
- titik data
- label data
- warna cabang
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membuat data hierarki dan menyesuaikan tingkat, label, serta warna pada diagram Treemap dan Sunburst dengan Aspose.Slides untuk C++."
---
## **Ikhtisar**

Diagram Treemap dan Sunburst menampilkan jenis data hierarkis yang sama, tetapi menggunakan tata letak yang berbeda. Treemap menggambar hierarki sebagai persegi panjang bersarang yang area‑nya mewakili nilai daun. Sunburst menggambarnya sebagai cincin konsentrik: grup tingkat atas berada di dekat pusat, dan kategori daun berada pada cincin terluar.

Di Aspose.Slides untuk C++, setiap nilai numerik adalah sebuah [IChartDataPoint](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/). Metode [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)‑nya menyediakan akses ke daun dan grup induknya. Artikel ini menjelaskan pemetaan tersebut dan menunjukkan cara membuat serta memformat kedua jenis diagram dari data contoh yang sama.

![Diagram Treemap dengan cabang Consumer dan Business](treemap-hierarchy.png)

![Diagram Sunburst dengan hierarki Consumer dan Business yang sama](sunburst-hierarchy.png)

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

Indeks yang dikembalikan oleh [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) berjalan dari daun ke atas:

| Indeks `get_DataPointLevels()` | Tingkat logis | Representasi Treemap | Representasi Sunburst |
| ---: | --- | --- | --- |
| `0` | Daun | Persegi panjang nilai | Segmen cincin terluar |
| `1` | Batang | Persegi panjang atau header induk | Segmen cincin tengah |
| `2` | Cabang | Persegi panjang atau header tingkat atas | Segmen cincin dalam |

Urutan ini sama untuk kedua jenis diagram meskipun tata letak visualnya berbeda. Segmen induk dibagi oleh beberapa daun. Untuk memformatnya, gunakan tingkat yang sesuai dari titik data pertama dalam grup itu. Misalnya, cabang `Consumer` dimulai dengan titik `Laptops`, sedangkan batang `Software` dimulai dengan titik `Licenses`. Menyimpan referensi ke titik‑titik tersebut lebih jelas dan aman daripada menggunakan ekspresi yang tidak dijelaskan seperti `dataPoints->idx_get(0)` atau `dataPoints->idx_get(6)`.

## **Membuat dan Menyesuaikan Kedua Jenis Diagram**

Contoh lengkap berikut membuat Treemap pada slide pertama dan Sunburst pada slide kedua. Contoh ini membangun hierarki, menampilkan nilai untuk `Tablets`, menerapkan warna tetap pada tingkat yang dipilih, memformat label cabang, dan menyimpan presentasi.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Tambahkan kategori daun. Item pengelompokan diatur hanya ketika grup baru dimulai;
    // kategori berikut tetap berada dalam grup itu sampai item lain diatur.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Tampilkan kategori dan nilai pada daun Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Format cabang Consumer melalui daun pertama di cabang tersebut.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Format batang Software melalui daun pertama di batang tersebut.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout memengaruhi label induk pada Treemap; Sunburst menggunakan segmen cincin.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sel sel kategori dan sel nilai menggunakan baris worksheet yang sama, sehingga posisi koleksinya tetap selaras. Saat Anda bekerja dengan diagram yang sudah ada daripada membuat yang baru, periksa baris‑baris kategori terlebih dahulu dan simpan referensi bernama ke titik data serta tingkat yang ingin Anda format.

## **Perilaku dan Pertimbangan Praktis**

### **Perbedaan Treemap dan Sunburst**

- Treemap menggunakan area untuk menyampaikan nilai dan persegi panjang bersarang untuk menyampaikan hierarki. Metode [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) mengendalikan bagaimana label induk muncul pada jenis diagram ini.
- Sunburst menggunakan sudut untuk menyampaikan nilai dan kedalaman cincin untuk menyampaikan hierarki. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) tidak mengendalikan label cincinnya.
- Kedua jenis diagram menggunakan tingkat pengelompokan kategori yang sama dan urutan daun‑ke‑induk yang sama yang dikembalikan oleh [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), sehingga kode pembuatan data dan pemformatan tingkat dapat dibagi.
- Nilai induk dihitung dari daun‑daun keturunannya. Jangan menambahkan titik numerik terpisah untuk cabang atau batang.

### **Pengurutan dan Urutan Segmen**

Mesin tata letak diagram menentukan penempatan akhir persegi panjang dan segmen cincin. Kelompokkan baris‑baris kategori yang terkait bersama sebelum menambahkannya, tetapi jangan mengandalkan posisi persegi panjang atau sudut awal yang spesifik. Jika urutan memiliki makna, sertakan dalam label atau gunakan jenis diagram dengan sumbu kategori eksplisit.

### **Tema dan Warna Tetap**

Tingkat diagram yang belum diformat mewarisi warna dari tema presentasi. Contoh ini menggunakan isian RGB eksplisit untuk output yang dapat diprediksi. Jika diagram harus mengikuti perubahan tema, gunakan warna skema alih‑alih nilai RGB tetap dan hindari menimpa setiap tingkat. Juga periksa kontras label setelah mengubah isian cabang atau batang.

### **Label dan Ruang yang Tersedia**

PowerPoint dapat menyembunyikan atau memotong label ketika segmen terlalu kecil. Memperbesar ukuran diagram, memendekkan nama kategori, atau menampilkan lebih sedikit bidang label biasanya menghasilkan hasil yang lebih jelas. Sebuah label dapat menggabungkan nama kategori, nama seri, dan nilai melalui [IDataLabelFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/idatalabelformat/), tetapi mengaktifkan semua bidang sering membuat diagram hierarkis sulit dibaca.

### **Ekspor dan Rendering**

Menyimpan ke PPTX menjaga diagram dapat diedit. Saat Aspose.Slides merender presentasi ke PDF atau gambar, isian dan pengaturan label yang didukung dirender bersama diagram. Substitusi font dan perbedaan kecil dalam ruang tata letak yang tersedia dapat mengubah pembungkusan baris atau visibilitas label, jadi pasang font yang diperlukan dan verifikasi target ekspor penting.

## **FAQ**

**Mengapa mengubah tingkat induk memengaruhi beberapa daun?**

Cabang atau batang adalah segmen visual yang berbagi. [IChartDataPointLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevel/)‑nya dapat diakses melalui daun keturunan, tetapi pemformatannya berlaku untuk segmen induk bersama, bukan hanya untuk daun tersebut.

**Mengapa label data hilang?**

Pertama aktifkan bidang yang diperlukan pada objek [IDataLabelFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/idatalabelformat/) label. Kemudian periksa apakah segmen memiliki cukup ruang. Tata letak label induk Treemap, dimensi diagram, panjang label, ukuran font, dan jumlah bidang yang diaktifkan semuanya memengaruhi apakah label dapat ditampilkan.

**Apakah saya dapat mengatur urutan atau koordinat tepat segmen?**

Anda dapat mengendalikan urutan baris sumber dan menjaga tiap grup tetap berurutan, tetapi tidak dapat menetapkan persegi panjang Treemap atau sudut Sunburst secara tepat. Mesin tata letak diagram menghitungnya dari hierarki, nilai, dan ruang yang tersedia.

**Mengapa warna berubah setelah tema presentasi berubah?**

Isian berbasis tema dirancang mengikuti palet presentasi. Terapkan warna RGB eksplisit pada tingkat yang harus tetap, atau pertahankan warna skema bila penyesuaian ke tema baru lebih diinginkan.

**Apakah pemformatan khusus akan dipertahankan dalam ekspor PDF dan gambar?**

Ya, isian diagram dan pengaturan label yang didukung disertakan selama proses rendering. Untuk hasil yang konsisten di berbagai sistem, sediakan font yang diperlukan dan uji ukuran ekspor akhir karena penyesuaian label bergantung pada tata letak.

## **Lihat Juga**

- [Create Treemap charts](/slides/id/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/id/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/id/cpp/export-chart/)
- [Manage presentation themes](/slides/id/cpp/presentation-theme/)