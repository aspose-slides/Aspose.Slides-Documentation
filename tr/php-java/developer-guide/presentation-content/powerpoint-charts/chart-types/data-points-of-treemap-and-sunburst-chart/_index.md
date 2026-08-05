---
title: Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap grafik
- sunburst grafik
- hiyerarşik grafik
- veri noktası
- veri etiketi
- şube rengi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile Treemap ve Sunburst grafiklerde hiyerarşik veri oluşturmayı ve seviyeleri, etiketleri ve renkleri nasıl özelleştireceğinizi öğrenin."
---
## **Genel Bakış**

Treemap ve Sunburst grafikler aynı türde hiyerarşik verileri gösterir, ancak farklı yerleşimler kullanır. Bir Treemap, hiyerarşiyi yaprak değerlerini temsil eden alanlara sahip iç içe dikdörtgenler olarak çizer. Bir Sunburst ise bunu konsantrik halkalar olarak gösterir: üst düzey gruplar merkeze yakın, yaprak kategoriler ise dış halkada bulunur.

Aspose.Slides for PHP via Java'da, her sayısal değer bir [ChartDataPoint](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/). [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) yöntemi yaprağa ve onun üst grup'larına erişim sağlar. Bu makale bu eşleşmeyi açıklar ve aynı örnek veriden her iki grafik tipinin nasıl oluşturulup biçimlendirileceğini gösterir.

![Tüketici ve İş dallarını içeren bir Treemap grafiği](treemap-hierarchy.png)

![Aynı Tüketici ve İş hiyerarşisini gösteren bir Sunburst grafiği](sunburst-hierarchy.png)

## **Kategorileri, Veri Noktalarını ve Seviyeleri Anlamak**

Aşağıda kullanılan örnek üç kategori seviyesi ve bir sayısal seriye sahiptir:

| Şube | Dal | Yaprak | Gelir |
| --- | --- | --- | ---: |
| Tüketici | Bilgisayarlar | Dizüstü Bilgisayarlar | 12 |
| Tüketici | Bilgisayarlar | Masaüstü Bilgisayarlar | 8 |
| Tüketici | Mobil | Telefonlar | 15 |
| Tüketici | Mobil | Tabletler | 6 |
| İş | Hizmetler | Danışmanlık | 10 |
| İş | Hizmetler | Destek | 7 |
| İş | Yazılım | Lisanslar | 11 |
| İş | Yazılım | Abonelikler | 14 |

Her satır bir yaprak kategorisi ve bir veri noktası oluşturur. Kategori gruplama seviyeleri, bu yapraktan üst gruplarına olan yolu tanımlar. İlk satır için yol `Tüketici > Bilgisayarlar > Dizüstü Bilgisayarlar` şeklindedir.

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) tarafından döndürülen indeksler yapraktan yukarı doğru çalışır:

| `getDataPointLevels()` indeksi | Mantıksal seviye | Treemap temsili | Sunburst temsili |
| ---: | --- | --- | --- |
| `0` | Yaprak | Değer dikdörtgeni | Dış halka segmenti |
| `1` | Dal | Üst dikdörtgen veya başlık | Orta halka segmenti |
| `2` | Şube | Üst düzey dikdörtgen veya başlık | İç halka segmenti |

Bu sıra, görsel yerleşimleri farklı olsa da her iki grafik tipi için de aynıdır. Bir üst segment birden fazla yaprak tarafından paylaşılır. Bunu biçimlendirmek için, o gruptaki ilk veri noktasının ilgili seviyesini kullanın. Örneğin, `Consumer` şubesi `Laptops` noktasından başlarken, `Software` dalı `Licenses` noktasından başlar. Bu noktalara başvuruların tutulması, `$dataPoints->get_Item(0)` veya `$dataPoints->get_Item(6)` gibi açıklanmamış ifadeleri kullanmaktan daha net ve güvenlidir.

## **Her İki Grafik Türünü Oluşturma ve Özelleştirme**

Aşağıdaki tam örnek, birinci slaytta bir Treemap ve ikinci slaytta bir Sunburst oluşturur. Hiyerarşiyi inşa eder, `Tablets` için değeri gösterir, seçili seviyelere sabit renkler uygular, bir şube etiketini biçimlendirir ve sunumu kaydeder.

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

        // Yaprak kategorilerini ekleyin. Bir gruplanma öğesi yalnızca yeni bir grup başladığında ayarlanır;
        // takip eden kategoriler başka bir öğe ayarlanana kadar aynı grup içinde kalır.
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

        // Tablets yaprağında kategori ve değeri göster.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Consumer şubesini o şubedeki ilk yaprak üzerinden biçimlendirin.
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

        // Software dalını o daldaki ilk yaprak üzerinden biçimlendirin.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout, Treemap üst etiketlerini etkiler; Sunburst halka segmentlerini kullanır.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kategori hücreleri ve değer hücreleri aynı çalışma sayfası satırını kullanır, bu yüzden koleksiyon konumları hizalı kalır. Var olan bir grafikle çalışırken yeni bir grafik oluşturmaktan ziyade önce kategori satırlarını inceleyin ve biçimlendirmeyi düşündüğünüz veri noktaları ve seviyeler için isimlendirilmiş referansları depolayın.

## **Davranış ve Pratik Hususlar**

### **Treemap ve Sunburst Farklılıkları**

- Bir Treemap değerleri iletmek için alanı ve hiyerarşiyi iletmek için iç içe dikdörtgenleri kullanır. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#setParentLabelLayout) yöntemi bu grafik türünde üst etiketlerin nasıl görüneceğini kontrol eder.
- Bir Sunburst değerleri iletmek için açı ve hiyerarşiyi iletmek için halka derinliğini kullanır. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#setParentLabelLayout) halka etiketlerini kontrol etmez.
- Her iki grafik tipi de aynı kategori gruplama seviyelerini ve [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) tarafından döndürülen aynı yaprak‑üst sırasını kullanır, bu yüzden veri oluşturma ve seviye‑biçimlendirme kodu paylaşılabilir.
- Üst değerler, alt yapraklardan hesaplanır. Şubeler veya dallar için ayrı sayısal noktalar eklemeyin.

### **Sıralama ve Segment Sırası**

Grafik yerleşim motoru dikdörtgenlerin ve halka segmentlerinin son yerleşimini belirler. İlgili kategori satırlarını eklemeden önce birlikte gruplandırın, ancak belirli bir dikdörtgen konumuna ya da başlangıç açısına güvenmeyin. Eğer sıralama bir anlam taşıyorsa, bunu etiketlerde belirtin ya da açık bir kategori ekseni olan bir grafik tipi kullanın.

### **Tema ve Sabit Renkler**

Biçimlendirilmemiş grafik seviyeleri sunum temasından renkleri devralır. Örnek, öngörülebilir çıktı için açık RGB doldurmaları kullanır. Grafik temanın değişmesini istiyorsanız, sabit RGB değerleri yerine şema renkleri kullanın ve her seviyeyi geçersiz kılmaktan kaçının. Ayrıca bir şube veya dal doldurması değiştirildiğinde etiket kontrastını kontrol edin.

### **Etiketler ve Kullanılabilir Alan**

PowerPoint, bir segment çok küçük olduğunda etiketleri gizleyebilir ya da kesebilir. Grafik boyutunu artırmak, kategori adlarını kısaltmak veya gösterilen etiket alanlarını azaltmak genellikle daha net bir sonuç verir. Bir etiket, kategori adı, seri adı ve değeri [DataLabelFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datalabelformat/) aracılığıyla birleştirebilir, ancak tüm alanları etkinleştirmek hiyerarşik grafiklerin okunmasını zorlaştırabilir.

### **Dışa Aktarma ve İşleme**

PPTX olarak kaydetmek grafiği düzenlenebilir tutar. Aspose.Slides sunumu PDF ya da bir resme işlediğinde, desteklenen doldurmalar ve etiket ayarları grafikle birlikte işlenir. Yazı tipi ikamesi ve mevcut yerleşim alanındaki küçük farklar satır kaydırma ya da etiket görünürlüğünü değiştirebilir; bu yüzden gerekli yazı tiplerini kurun ve önemli dışa aktarma hedeflerini doğrulayın.

## **SSS**

**Neden bir üst seviyenin değiştirilmesi birden fazla yaprağı etkiler?**

Bir şube veya dal paylaşılan bir görsel segmenttir. Onun [ChartDataPointLevel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevel/) bir alt yapraktan erişilebilir, ancak biçimlendirme yalnızca o yaprağa değil, paylaşılan üst segmente uygulanır.

**Veri etiketi neden eksik?**

İlk olarak etiketin [DataLabelFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datalabelformat/) nesnesinde gerekli alanları etkinleştirin. Ardından segmentin yeterli alana sahip olup olmadığını kontrol edin. Treemap üst‑etiket yerleşimi, grafik boyutları, etiket uzunluğu, yazı tipi boyutu ve etkin alan sayısı bir etiketin görüntülenip görüntülenmeyeceğini belirler.

**Segmentlerin kesin sırasını veya koordinatlarını belirleyebilir miyim?**

Kaynak‑satır sırasını kontrol edebilir ve her grubu art arda tutabilirsiniz, ancak kesin Treemap dikdörtgenlerini veya Sunburst açılarını atayamazsınız. Grafik yerleşim motoru bunları hiyerarşi, değerler ve mevcut alana göre hesaplar.

**Sunum temasının değişmesinden sonra renkler neden değişiyor?**

Tema‑tabanlı doldurmalar sunum paletini takip edecek şekilde tasarlanmıştır. Sabit kalması gereken seviyelere açık RGB renkleri uygulayın veya yeni bir temaya uyum sağlarken şema renklerini koruyun.

**Özel biçimlendirme PDF ve resim dışa aktarımlarında korunacak mı?**

Evet, desteklenen grafik doldurmaları ve etiket ayarları işleme sırasında dahil edilir. Sistemler arasında tutarlı sonuçlar elde etmek için gerekli yazı tiplerini sağlamak ve etiket sığdırmanın yerleşime bağlı olduğunu göz önünde bulundurarak son dışa aktarma boyutunu test etmek önemlidir.

## **İlgili Bağlantılar**

- [Treemap grafik oluşturma](/slides/tr/php-java/create-chart/#create-tree-map-charts)
- [Sunburst grafik oluşturma](/slides/tr/php-java/create-chart/#create-sunburst-charts)
- [Sunum grafiklerini dışa aktarma](/slides/tr/php-java/export-chart/)
- [Sunum temalarını yönetme](/slides/tr/php-java/presentation-theme/)