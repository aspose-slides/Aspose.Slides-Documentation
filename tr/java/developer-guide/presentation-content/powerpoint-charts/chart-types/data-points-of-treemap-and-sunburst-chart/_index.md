---
title: Java’da Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/java/data-points-of-treemap-and-sunburst-chart/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile Treemap ve Sunburst grafiklerde hiyerarşik veri oluşturmayı ve seviyeleri, etiketleri ve renkleri özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Treemap ve Sunburst grafikler aynı türde hiyerarşik verileri gösterir, ancak farklı düzenler kullanırlar. Bir Treemap, hiyerarşiyi yaprak değerlerini temsil eden alanlara sahip iç içe dikdörtgenler olarak çizer. Bir Sunburst ise bunu konsantrik halkalarla gösterir: üst‑seviye gruplar merkeze yakın, yaprak kategoriler ise dış halkada yer alır.

Aspose.Slides for Java’da her sayısal değer bir [IChartDataPoint](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/)dır. Bunun [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) yöntemi, yaprağın ve üst grup (lar)ın erişimini sağlar. Bu makale bu eşlemeyi açıklar ve aynı örnek veriden iki grafik tipinin nasıl oluşturulup biçimlendirileceğini gösterir.

![Tüketici ve İşletme dallarını içeren bir Treemap grafiği](treemap-hierarchy.png)

![Aynı Tüketici ve İşletme hiyerarşisini gösteren bir Sunburst grafiği](sunburst-hierarchy.png)

## **Kategorileri, Veri Noktalarını ve Seviyeleri Anlamak**

Aşağıda kullanılan örnek üç kategori seviyesi ve bir sayısal seriye sahiptir:

| Şube | Dal | Yaprak | Gelir |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Her satır bir yaprak kategori ve bir veri noktası oluşturur. Kategori gruplama seviyeleri, o yapraktan üst gruplarına giden yolu tanımlar. İlk satır için yol `Consumer > Computers > Laptops` şeklindedir.

[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) tarafından döndürülen indeksler yapraktan yukarı doğru çalışır:

| `getDataPointLevels()` indeksi | Mantıksal seviye | Treemap temsili | Sunburst temsili |
| ---: | --- | --- | --- |
| `0` | Yaprak | Değer dikdörtgeni | Dış halka bölümü |
| `1` | Dal | Üst grup dikdörtgeni veya üst bilgi | Orta halka bölümü |
| `2` | Şube | Üst‑seviye dikdörtgen veya üst bilgi | İç halka bölümü |

Bu sıralama, görsel düzenleri farklı olsa da her iki grafik tipi için de aynıdır. Bir üst segment birden çok yaprak tarafından paylaşılır. Bunu biçimlendirmek için o grup içindeki ilk veri noktasının ilgili seviyesini kullanın. Örneğin, `Consumer` şubesi `Laptops` noktasından, `Software` dalı ise `Licenses` noktasından başlar. Bu noktalara referans tutmak, `dataPoints.get_Item(0)` ya da `dataPoints.get_Item(6)` gibi açıklanmamış ifadelerden daha açıktır ve güvenlidir.

## **Her iki Grafik Türünü de Oluşturma ve Özelleştirme**

Aşağıdaki tam örnek, ilk slaytta bir Treemap, ikinci slaytta bir Sunburst oluşturur. Hiyerarşiyi kurar, `Tablets` için değeri gösterir, seçili seviyelere sabit renkler uygular, bir şube etiketi biçimlendirir ve sunumu kaydeder.

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
        // sonraki kategoriler başka bir öğe ayarlanana kadar o grup içinde kalır.
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

        // Consumer dalını o dalın ilk yaprağı üzerinden biçimlendir.
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

        // Software dalını o dalın ilk yaprağı üzerinden biçimlendir.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
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

Kategori hücreleri ve değer hücreleri aynı çalışma sayfası satırını kullanır; bu nedenle koleksiyon konumları hizalı kalır. Mevcut bir grafikle çalışırken, önce kategori satırlarını inceleyin ve biçimlendirmeyi planladığınız veri noktaları ve seviyeler için adlandırılmış referansları saklayın.

## **Davranış ve Pratik Hususlar**

### **Treemap ve Sunburst Farkları**

- Bir Treemap, değeri iletmek için alanı ve hiyerarşiyi iletmek için iç içe dikdörtgenleri kullanır. Bu grafik tipinde üst grup etiketlerinin nasıl görüneceğini kontrol eden yöntem **[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)**’dır.
- Bir Sunburst, değeri iletmek için açıyı ve hiyerarşiyi iletmek için halka derinliğini kullanır. **[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)** bu grafik tipinde halka etiketlerini kontrol etmez.
- Her iki grafik tipi de aynı kategori grup seviyelerini ve aynı `IChartDataPoint.getDataPointLevels` tarafından döndürülen yaprak‑üst sırasını kullanır; bu nedenle veri oluşturma ve seviye‑biçimlendirme kodu ortak kullanılabilir.
- Üst değerler, alt yapraklardan hesaplanır. Şubeler ya da dallar için ayrı sayısal noktalar eklemeyin.

### **Sıralama ve Segment Sırası**

Grafik düzen motoru, dikdörtgenlerin ve halka bölümlerinin nihai konumunu belirler. İlgili kategori satırlarını eklemeden önce bir arada tutun, ancak belirli bir dikdörtgen konumuna ya da başlangıç açısına güvenmeyin. Sıralamanın anlamı varsa, bunu etiketlerde belirtin ya da açık bir kategori ekseni sunan bir grafik tipi kullanın.

### **Tema ve Sabit Renkler**

Biçimlendirilmemiş grafik seviyeleri, sunum temasından renk miras alır. Örnekte öngörülebilir çıktı için RGB dolgu renkleri açıkça kullanılmıştır. Grafik temasına uyumlu olmasını istiyorsanız, sabit RGB değerler yerine şema renklerini kullanın ve her seviyeyi geçersiz kılmaktan kaçının. Ayrıca bir şube ya da dal dolgusunu değiştirdikten sonra etiket kontrastını kontrol edin.

### **Etiketler ve Kullanılabilir Alan**

PowerPoint, bir segment çok küçük olduğunda etiketleri gizleyebilir ya da kırpabilir. Grafik boyutunu artırmak, kategori adlarını kısaltmak veya gösterilen etiket alanlarını azaltmak genellikle daha net bir sonuç verir. Bir etiket, kategori adı, seri adı ve değeri **[IDataLabelFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatalabelformat/)** aracılığıyla birleştirebilir, fakat tüm alanları etkinleştirmek hiyerarşik grafiklerin okunmasını zorlaştırabilir.

### **Dışa Aktarım ve Oluşturma**

PPTX olarak kaydetmek grafik üzerinde düzenleme imkanı tanır. Aspose.Slides, sunumu PDF ya da görsele dönüştürdüğünde desteklenen dolgu ve etiket ayarları grafikle birlikte işlenir. Yazı tipi ikamesi ve mevcut düzen alanındaki küçük farklar satır kaydırma ya da etiket görünürlüğünü etkileyebilir; bu yüzden gerekli yazı tiplerini kurun ve önemli dışa aktarma hedeflerini doğrulayın.

## **SSS**

**Bir üst seviyenin değiştirilmesi birkaç yaprağı neden etkiler?**

Bir şube ya da dal, ortak bir görsel segmenttir. Bu segmentin **[IChartDataPointLevel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapointlevel/)** nesnesine bir alt yapraktan ulaşılabilir, ancak biçimlendirme yalnızca o yaprağa değil, paylaşılan üst segmente uygulanır.

**Neden bir veri etiketi eksik?**

İlk olarak etiketin **[IDataLabelFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatalabelformat/)** nesnesinde gerekli alanları etkinleştirin. Ardından segmentin yeterli alana sahip olup olmadığını kontrol edin. Treemap üst‑etiket düzeni, grafik boyutları, etiket uzunluğu, yazı tipi boyutu ve etkin alan sayısı, bir etiketin gösterilip gösterilmeyeceğini belirler.

**Segmentlerin kesin sırasını ya da konumlarını belirleyebilir miyim?**

Kaynak‑satır sırasını kontrol edip her grubu ardışık tutabilirsiniz, ancak kesin Treemap dikdörtgenlerini ya da Sunburst açılarını atayamazsınız. Bu değerler, hiyerarşi, sayılar ve mevcut alan temelinde düzen motoru tarafından hesaplanır.

**Tema değiştiğinde renkler neden değişiyor?**

Tema‑temelli dolgu renkleri, sunum paletine uyacak şekilde tasarlanmıştır. Sabit kalması gereken seviyelere açık RGB renkleri uygulayın ya da yeni temaya uyum sağlamak istediğinizde şema renklerini koruyun.

**PDF ve görsel dışa aktarımlarda özel biçimlendirme korunur mu?**

Evet, desteklenen grafik dolgu ve etiket ayarları oluşturma sırasında dahil edilir. Sistemler arası tutarlı sonuçlar için gerekli yazı tiplerini sağlayın ve etiket sığdırmanın düzene bağlı olduğunu göz önünde bulundurarak nihai dışa aktarma boyutunu test edin.

## **İlgili Bağlantılar**

- [Treemap grafikleri oluşturma](/slides/tr/java/create-chart/#create-tree-map-charts)
- [Sunburst grafikleri oluşturma](/slides/tr/java/create-chart/#create-sunburst-charts)
- [Sunum grafiklerini dışa aktarma](/slides/tr/java/export-chart/)
- [Sunum temalarını yönetme](/slides/tr/java/presentation-theme/)