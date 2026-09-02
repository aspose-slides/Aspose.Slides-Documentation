---
title: C++'ta Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap grafiği
- sunburst grafiği
- hiyerarşik grafik
- veri noktası
- veri etiketi
- dal rengi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: Aspose.Slides for C++ ile Treemap ve Sunburst grafiklerde hiyerarşik veri oluşturmayı ve seviyeleri, etiketleri ve renkleri özelleştirmeyi öğrenin.
---
## **Genel Bakış**

Treemap ve Sunburst grafikler aynı türde hiyerarşik verileri gösterir, ancak farklı yerleşimler kullanırlar. Bir Treemap, hiyerarşiyi alanları yaprak değerlerini temsil eden iç içe dikdörtgenler olarak çizer. Bir Sunburst ise hiyerarşiyi merkeze yakın üst‑seviye gruplar ve dış halkada yaprak kategoriler olarak gösteren konsantrik halkalarla çizer.

Aspose.Slides for C++ içinde her sayısal değer bir [IChartDataPoint](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/)dır. Bunun [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) yöntemi, yaprağa ve onun üst grup öğelerine erişim sağlar. Bu makale bu eşlemeyi açıklar ve aynı örnek veriden her iki grafik tipinin nasıl oluşturulup biçimlendirileceğini gösterir.

![Consumer ve Business dallarıyla bir Treemap grafiği](treemap-hierarchy.png)

![Aynı Consumer ve Business hiyerarşisiyle bir Sunburst grafiği](sunburst-hierarchy.png)

## **Kategorileri, Veri Noktalarını ve Seviyeleri Anlama**

Aşağıda kullanılan örnek üç kategori seviyesi ve bir sayısal seriye sahiptir:

| Branch | Stem | Leaf | Revenue |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Her satır bir yaprak kategorisi ve bir veri noktası oluşturur. Kategori gruplama seviyeleri, o yapraktan üst öğelerine giden yolu tanımlar. İlk satır için yol `Consumer > Computers > Laptops` şeklindedir.

[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) tarafından döndürülen indeksler yapraktan yukarı doğru gider:

| `get_DataPointLevels()` indeksi | Mantıksal seviye | Treemap temsili | Sunburst temsili |
| ---: | --- | --- | --- |
| `0` | Yaprak | Değer dikdörtgeni | Dış halkadaki parça |
| `1` | Stem | Üst grup dikdörtgeni veya başlık | Orta halkadaki parça |
| `2` | Branch | Üst‑seviye dikdörtgen veya başlık | İç halkadaki parça |

Bu sıralama, görsel yerleşimleri farklı olsa da her iki grafik tipi için de aynıdır. Bir üst grup parçası birden çok yaprak tarafından paylaşılır. Bunu biçimlendirmek için gruptaki ilk veri noktasının ilgili seviyesini kullanın. Örneğin, `Consumer` dalı `Laptops` noktasıyla başlarken, `Software` stemi `Licenses` noktasıyla başlar. Bu noktalara referans tutmak, `dataPoints->idx_get(0)` ya da `dataPoints->idx_get(6)` gibi açıklanmamış ifadeler kullanmaktan daha nettir ve daha güvenlidir.

## **Her İki Grafik Tipini Oluşturma ve Özelleştirme**

Aşağıdaki tam örnek, ilk slaytta bir Treemap ve ikinci slaytta bir Sunburst oluşturur. Hiyerarşiyi kurar, `Tablets` değeri görüntülenir, seçili seviyelere sabit renkler uygulanır, bir dal etiketi biçimlendirilir ve sunum kaydedilir.

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

    // Yaprak kategorileri ekleyin. Bir gruplama öğesi yalnızca yeni bir grup başladığında ayarlanır;
    // sonraki kategoriler, başka bir öğe ayarlanana kadar bu grup içinde kalır.
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

    // Tablets yaprağında kategori ve değeri göster.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Consumer dalını, o daldaki ilk yaprak aracılığıyla biçimlendirin.
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

    // Software stemini, o stemdeki ilk yaprak aracılığıyla biçimlendirin.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout, Treemap üst etiketlerini etkiler; Sunburst halka segmentlerini kullanır.
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

Kategori hücreleri ve değer hücreleri aynı çalışma sayfası satırını kullanır, bu yüzden koleksiyon konumları hizalı kalır. Varolan bir grafikle çalışıyorsanız, önce kategori satırlarını inceleyin ve biçimlendirmeyi planladığınız veri noktaları ve seviyeler için adlandırılmış referansları saklayın.

## **Davranış ve Pratik Hususlar**

### **Treemap ve Sunburst Farklılıkları**

- Treemap, değeri alanla, hiyerarşiyi iç içe dikdörtgenlerle iletir. Bu grafik tipinde üst‑grup etiketlerinin nasıl görüneceğini [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) yöntemi kontrol eder.
- Sunburst, değeri açıyla, hiyerarşiyi halka derinliğiyle iletir. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) onun halka etiketlerini kontrol etmez.
- Her iki grafik tipi de aynı kategori grup seviyelerini ve [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) tarafından döndürülen aynı yaprak‑üst‑öğe sırasını kullanır, bu yüzden veri oluşturma ve seviye‑biçimlendirme kodu paylaşılabilir.
- Üst‑grup değerleri, alt yapraklardan hesaplanır. Dallara veya stemlere ayrı sayısal noktalar eklemeyin.

### **Sıralama ve Parça Düzeni**

Grafik yerleşim motoru, dikdörtgenlerin ve halka parçalarının nihai konumunu belirler. İlgili kategori satırlarını eklemeden önce bir arada gruplayın, ancak belirli bir dikdörtgen konumuna ya da başlangıç açısına güvenmeyin. Sıralama anlam taşıyorsa, bunu etiketlerde gösterin ya da açık bir kategori ekseni olan bir grafik tipi kullanın.

### **Tema ve Sabit Renkler**

Biçimlendirilmemiş grafik seviyeleri, sunum temasından renkler devralır. Örnekte öngörülebilir çıktı için açık RGB doldurmalar kullanılmıştır. Grafik temayı takip etmesi isteniyorsa, sabit RGB değerler yerine şema renkleri kullanın ve her seviyeyi geçersiz kılmaktan kaçının. Bir dal ya da stem doldurması değiştirildiğinde etiket karşıtlığını kontrol edin.

### **Etiketler ve Kullanılabilir Alan**

PowerPoint, bir parça çok küçük olduğunda etiketleri gizleyebilir ya da kısaltabilir. Grafik boyutunu artırmak, kategori adlarını kısaltmak veya gösterilen etiket alanlarını azaltmak genellikle daha net sonuç verir. [IDataLabelFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatalabelformat/) aracılığıyla kategori adı, seri adı ve değeri birleştirebilirsiniz, ancak tüm alanları etkinleştirmek hiyerarşik grafiklerin okunmasını zorlaştırabilir.

### **Dışa Aktarım ve İşleme**

PPTX olarak kaydetmek, grafiği düzenlenebilir tutar. Aspose.Slides sunumu PDF ya da görüntüye işlediğinde, desteklenen doldurmalar ve etiket ayarları grafikle birlikte işlenir. Yazı tipi ikamesi ve mevcut yerleşim alanındaki küçük farklar satır kaydırma ya da etiket görünürlüğünü etkileyebilir; bu yüzden gerekli yazı tiplerini kurun ve önemli dışa aktarım hedeflerini doğrulayın.

## **SSS**

**Bir üst‑seviye değiştirildiğinde birkaç yaprak neden etkilenir?**

Bir dal ya da stem, ortak bir görsel parçadır. Onun [IChartDataPointLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/) nesnesine bir alt yapraktan ulaşılabilir, ancak biçimlendirme yalnızca o yaprağa değil, paylaşılan üst‑grup parçasına uygulanır.

**Bir veri etiketi neden eksik?**

Önce etiketin [IDataLabelFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatalabelformat/) nesnesinde gerekli alanları etkinleştirin. Ardından parçanın yeterli alana sahip olduğundan emin olun. Treemap üst‑etiket yerleşimi, grafik boyutları, etiket uzunluğu, yazı tipi boyutu ve etkin alan sayısı, bir etiketin gösterilip gösterilmeyeceğini belirler.

**Parçaların tam sırasını ya da koordinatlarını ayarlayabilir miyim?**

Kaynak‑satır sırasını kontrol edip her grubu arka arkaya tutabilirsiniz, ancak kesin Treemap dikdörtgenlerini ya da Sunburst açılarını atayamazsınız. Yerleşim motoru bunları hiyerarşi, değerler ve mevcut alandan hesaplar.

**Tema değiştiğinde renkler neden değişir?**

Tema‑tabanlı doldurmalar, sunum paletini izlemek üzere tasarlanmıştır. Sabit kalması gereken seviyelere açık RGB renkleri uygulayın veya yeni temaya uyum sağlamak isteniyorsa şema renklerini koruyun.

**Özel biçimlendirme PDF ve görüntü dışa aktarmalarında korunur mu?**

Evet, desteklenen grafik doldurmaları ve etiket ayarları işleme sırasında dahil edilir. Sistemler arası tutarlılık için gerekli yazı tiplerini sağlayın ve etiket sığmasının yerleşime bağlı olduğunu unutmayarak son dışa aktarım boyutunu test edin.

## **İlgili Bağlantılar**

- [Create Treemap charts](/slides/tr/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/tr/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/tr/cpp/export-chart/)
- [Manage presentation themes](/slides/tr/cpp/presentation-theme/)