---
title: Android'de Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap grafiği
- sunburst grafiği
- hiyerarşik grafik
- veri noktası
- veri etiketi
- şube rengi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile Treemap ve Sunburst grafiklerde hiyerarşik veri oluşturmayı ve seviyeleri, etiketleri ve renkleri özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Treemap ve Sunburst grafikler aynı türde hiyerarşik verileri gösterir, ancak farklı düzenler kullanır. Bir Treemap, hiyerarşiyi yaprak değerlerini temsil eden alanlara sahip iç içe dikdörtgenler olarak çizer. Bir Sunburst ise bunu eş merkezli halkalar olarak çizer: üst düzey gruplar merkeze yakındır ve yaprak kategoriler dış halkada bulunur.

Aspose.Slides for Android via Java'da her sayısal değer bir [IChartDataPoint](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/). Bunun [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) yöntemi yaprağa ve onun üst grup(lar)ına erişim sağlar. Bu makale bu eşlemeyi açıklar ve aynı örnek veriden her iki grafik tipinin nasıl oluşturulup biçimlendirileceğini gösterir.

![Tüketici ve İş dallarıyla bir Treemap grafiği](treemap-hierarchy.png)

![Aynı Tüketici ve İş hiyerarşisiyle bir Sunburst grafiği](sunburst-hierarchy.png)

## **Kategorileri, Veri Noktalarını ve Seviyeleri Anlamak**

Aşağıda kullanılan örnek üç kategori seviyesine ve bir sayısal seriye sahiptir:

| Şube | Kök | Yaprak | Gelir |
| --- | --- | --- | ---: |
| Tüketici | Bilgisayarlar | Dizüstü Bilgisayarlar | 12 |
| Tüketici | Bilgisayarlar | Masaüstü Bilgisayarlar | 8 |
| Tüketici | Mobil | Telefonlar | 15 |
| Tüketici | Mobil | Tabletler | 6 |
| İş | Hizmetler | Danışmanlık | 10 |
| İş | Hizmetler | Destek | 7 |
| İş | Yazılım | Lisanslar | 11 |
| İş | Yazılım | Abonelikler | 14 |

Her satır bir yaprak kategorisi ve bir veri noktası oluşturur. Kategori gruplama seviyeleri, o yapraktan üst gruplara olan yolu tanımlar. İlk satır için yol `Consumer > Computers > Laptops` şeklindedir.

The indexes returned by [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) run from the leaf upward:

| `getDataPointLevels()` indeksi | Mantıksal seviye | Treemap temsil | Sunburst temsil |
| ---: | --- | --- | --- |
| `0` | Yaprak | Değer dikdörtgeni | Dış halka segmenti |
| `1` | Kök | Üst dikdörtgen veya başlık | Orta halka segmenti |
| `2` | Şube | Üst düzey dikdörtgen veya başlık | İç halka segmenti |

Bu sıralama, görsel düzenleri farklı olsa da her iki grafik tipi için de aynıdır. Bir üst segment birden fazla yaprak tarafından paylaşılır. Biçimlendirmek için, o gruptaki ilk veri noktasının ilgili seviyesini kullanın. Örneğin, `Consumer` şubesi `Laptops` noktasından başlarken, `Software` kökü `Licenses` noktasından başlar. Bu noktalara referans tutmak, `dataPoints.get_Item(0)` veya `dataPoints.get_Item(6)` gibi açıklanmamış ifadelerden daha anlaşılır ve güvenlidir.

## **Her iki Grafik Tipini Oluşturma ve Özelleştirme**

Aşağıdaki tam örnek ilk slaytta bir Treemap ve ikinci slaytta bir Sunburst oluşturur. Hiyerarşiyi kurar, `Tablets` değerini gösterir, seçili seviyelere sabit renkler uygular, bir şube etiketini biçimlendirir ve sunumu kaydeder.

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

        // Yaprak kategorilerini ekle. Bir grup öğesi yalnızca yeni bir grup başladığında ayarlanır;
        // Aşağıdaki kategoriler başka bir öğe ayarlanana kadar aynı grup içinde kalır.
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

        // Tablets yaprağında kategori ve değeri göster.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Tüketici şubesini, o şubedeki ilk yaprak aracılığıyla biçimlendir.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Yazılım kökünü, o kökteki ilk yaprak aracılığıyla biçimlendir.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout Treemap üst etiketlerini etkiler; Sunburst halka segmentlerini kullanır.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kategori hücreleri ve değer hücreleri aynı çalışma sayfası satırını kullanır, bu yüzden koleksiyon konumları hizalı kalır. Varolan bir grafik üzerinde çalışıyorsanız, önce kategori satırlarını inceleyin ve biçimlendirmeyi planladığınız veri noktalarına ve seviyelere isimli referanslar depolayın.

## **Davranış ve Pratik Hususlar**

### **Treemap ve Sunburst Farklılıkları**

- Bir Treemap, değeri iletmek için alanı ve hiyerarşiyi iletmek için iç içe dikdörtgenleri kullanır. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) yöntemi, bu grafik tipinde üst etiketlerin nasıl görüneceğini kontrol eder.
- Bir Sunburst, değeri iletmek için açıyı ve hiyerarşiyi iletmek için halka derinliğini kullanır. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) halkalarının etiketlerini kontrol etmez.
- Her iki grafik tipi aynı kategori gruplama seviyelerini ve [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) tarafından döndürülen aynı yaprak‑üst sırasını kullanır, bu yüzden veri oluşturma ve seviye‑biçimlendirme kodu paylaşılabilir.
- Üst değerler alt yapraklardan hesaplanır. Şubeler veya kökler için ayrı sayısal noktalar eklemeyin.

### **Sıralama ve Segment Sırası**

Grafik yerleşim motoru dikdörtgenlerin ve halka segmentlerinin nihai konumlarını belirler. Satırları eklemeden önce ilgili kategori satırlarını bir arada tutun, ancak belirli bir dikdörtgen konumuna veya başlangıç açısına güvenmeyin. Eğer sıralama anlam taşıyorsa, bunu etiketlerde belirtin veya açık bir kategori ekseni olan bir grafik tipi kullanın.

### **Tema ve Sabit Renkler**

Biçimlendirilmemiş grafik seviyeleri sunum temasından renkleri devralır. Örnek, öngörülebilir çıktı için açık RGB doldurmaları kullanır. Grafik temaya göre renk değiştirmeli ise, sabit RGB değerleri yerine şema renkleri kullanın ve tüm seviyeleri geçersiz kılmaktan kaçının. Ayrıca bir şube veya kök doldurmasını değiştirdikten sonra etiket kontrastını da kontrol edin.

### **Etiketler ve Kullanılabilir Alan**

PowerPoint, bir segment çok küçük olduğunda etiketleri gizleyebilir veya kırpabilir. Grafik boyutunu artırmak, kategori adlarını kısaltmak veya daha az etiket alanı göstermek genellikle daha net sonuç verir. Bir etiket, kategori adı, seri adı ve değeri [IDataLabelFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idatalabelformat/) aracılığıyla birleştirebilir, ancak her alanı etkinleştirmek hiyerarşik grafiklerin okunmasını zorlaştırabilir.

### **Dışa Aktarma ve Oluşturma**

PPTX olarak kaydetmek grafik üzerinde düzenlemeyi korur. Aspose.Slides sunumu PDF ya da görüntüye dönüştürdüğünde, desteklenen doldurmalar ve etiket ayarları grafikle birlikte işlenir. Yazı tipi ikamesi ve mevcut yerleşim alanındaki küçük farklar satır kırılmasını veya etiket görünürlüğünü etkileyebilir; bu yüzden gereken yazı tiplerini kurun ve önemli dışa aktarma hedeflerini doğrulayın.

## **SSS**

**Bir üst seviyenin değiştirilmesi neden birkaç yaprağı etkiler?**

Bir şube ya da kök ortak bir görsel segmenttir. Onun [IChartDataPointLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapointlevel/) bir alt yapraktan erişilebilir, ancak biçimlendirme yalnızca o yaprağa değil, paylaşılan üst segmente uygulanır.

**Bir veri etiketi neden eksik?**

Önce etiketin [IDataLabelFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idatalabelformat/) nesnesinde gerekli alanları etkinleştirin. Ardından segmentin yeterli alanı olup olmadığını kontrol edin. Treemap üst‑etiket yerleşimi, grafik boyutları, etiket uzunluğu, yazı tipi boyutu ve etkin alan sayısı etiketin gösterilip gösterilmeyeceğini etkiler.

**Segmentlerin kesin sırasını ya da koordinatlarını ayarlayabilir miyim?**

Satır‑kaynak sırasını kontrol edebilir ve her grubu bitişik tutabilirsiniz, ancak kesin Treemap dikdörtgenlerini ya da Sunburst açılarını atayamazsınız. Grafik yerleşim motoru bunları hiyerarşi, değerler ve mevcut alan üzerinden hesaplar.

**Sunum teması değiştiğinde renkler neden değişir?**

Tema‑tabanlı doldurmalar sunum paletine uymak için tasarlanmıştır. Sabit kalması gereken seviyelere açık RGB renkleri uygulayın veya yeni temaya uyum sağlamak istiyorsanız şema renklerini koruyun.

**Özel biçimlendirme PDF ve görüntü dışa aktarmalarında korunur mu?**

Evet, desteklenen grafik doldurmaları ve etiket ayarları oluşturma sırasında dahil edilir. Tutarlı sonuçlar için gerekli yazı tiplerini sağlayın ve etiket sığdırmanın yerleşime bağlı olduğunu unutmayın; bu nedenle son dışa aktarma boyutunu test edin.

## **İlgili Bağlantılar**

- [Treemap grafiklerini oluştur](/slides/tr/androidjava/create-chart/#create-tree-map-charts)
- [Sunburst grafiklerini oluştur](/slides/tr/androidjava/create-chart/#create-sunburst-charts)
- [Sunum grafiklerini dışa aktar](/slides/tr/androidjava/export-chart/)
- [Sunum temalarını yönet](/slides/tr/androidjava/presentation-theme/)