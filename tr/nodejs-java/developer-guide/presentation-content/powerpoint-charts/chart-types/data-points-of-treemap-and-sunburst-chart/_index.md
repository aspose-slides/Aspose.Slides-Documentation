---
title: JavaScript Kullanarak Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/nodejs-java/data-points-of-treemap-and-sunburst-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak Treemap ve Sunburst grafiklerde hiyerarşik veri oluşturmayı ve seviyeleri, etiketleri ve renkleri özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Treemap ve Sunburst grafikler aynı türde hiyerarşik verileri gösterir, ancak farklı düzenler kullanır. Bir Treemap, hiyerarşiyi yaprak değerlerini temsil eden alanlara sahip iç içe dikdörtgenler olarak çizer. Bir Sunburst ise bunu konsantrik halkalar olarak gösterir: üst düzey gruplar merkeze yakın, yaprak kategoriler ise dış halkada yer alır.

Aspose.Slides for Node.js via Java’da her sayısal değer bir [ChartDataPoint](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/)’dır. Bunun [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) yöntemi, yaprağa ve onun üst grup öğelerine erişim sağlar. Bu makale bu eşlemeyi açıklar ve aynı örnek veriden iki grafik türünün nasıl oluşturulup biçimlendirileceğini gösterir.

![Tüketici ve İş şubeleriyle bir Treemap grafiği](treemap-hierarchy.png)

![Aynı Tüketici ve İş hiyerarşisiyle bir Sunburst grafiği](sunburst-hierarchy.png)

## **Kategorileri, Veri Noktalarını ve Seviyeleri Anlamak**

Aşağıda kullanılan örnek üç kategori seviyesi ve bir sayısal seri içerir:

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

Her satır bir yaprak kategorisi ve bir veri noktası oluşturur. Kategori gruplama seviyeleri, o yapraktan üst öğelerine giden yolu tanımlar. İlk satır için yol `Consumer > Computers > Laptops` şeklindedir.

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) tarafından döndürülen indeksler yapraktan yukarı doğru ilerler:

| `getDataPointLevels()` indeksi | Mantıksal seviye | Treemap temsili | Sunburst temsili |
| ---: | --- | --- | --- |
| `0` | Yaprak | Değer dikdörtgeni | Dış halka segmenti |
| `1` | Dal | Üst rectangle veya başlık | Orta halka segmenti |
| `2` | Şube | Üst‑seviye rectangle veya başlık | İç halka segmenti |

Bu sıra her iki grafik türü için de aynıdır, görsel düzenleri farklı olsa da. Bir üst segment birkaç yaprak tarafından paylaşılır. Biçimlendirmek için, o gruptaki ilk veri noktasının ilgili seviyesini kullanın. Örneğin, `Consumer` şubesi `Laptops` noktasıyla başlarken, `Software` dalı `Licenses` noktasıyla başlar. Bu noktalara referans tutmak, `dataPoints.get_Item(0)` veya `dataPoints.get_Item(6)` gibi açıklanmamış ifadeler kullanmaktan daha nettir ve daha güvenlidir.

## **Treemap ve Sunburst Grafiklerini Oluşturma ve Özelleştirme**

Aşağıdaki tam örnek, ilk slaytta bir Treemap ve ikinci slaytta bir Sunburst oluşturur. Hiyerarşiyi kurar, `Tablets` değeri gösterilir, seçili seviyelere sabit renkler uygulanır, bir şube etiketi biçimlendirilir ve sunum kaydedilir.

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

        // Add the leaf categories. A grouping item is set only when a new group begins;
        // the following categories remain in that group until another item is set.
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

        // Show the category and value on the Tablets leaf.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Format the Consumer branch through the first leaf in that branch.
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

        // Format the Software stem through the first leaf in that stem.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kategori hücreleri ve değer hücreleri aynı çalışma sayfası satırını kullanır, böylece koleksiyon konumları hizalanmış kalır. Varolan bir grafikle çalışıyorsanız, önce kategori satırlarını inceleyin ve biçimlendirmeyi planladığınız veri noktaları ve seviyeler için adlandırılmış referanslar tutun.

## **Davranış ve Pratik Hususlar**

### **Treemap ve Sunburst Farklılıkları**

- Bir Treemap, değeri alanla, hiyerarşiyi iç içe dikdörtgenlerle iletir. Bu grafik tipinde üst etiketlerin nasıl görüneceğini kontrol eden yöntem [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout)’dur.
- Bir Sunburst, değeri açıyla, hiyerarşiyi halka derinliğiyle iletir. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) onun halka etiketlerini kontrol etmez.
- Her iki grafik tipi de aynı kategori gruplama seviyelerini ve [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) tarafından döndürülen aynı yaprak‑üst sırasını kullanır, bu yüzden veri oluşturma ve seviye‑biçimlendirme kodu paylaşılabilir.
- Üst değerler, alt yapraklardan hesaplanır. Şubeler veya dallar için ayrı sayısal noktalar eklemeyin.

### **Sıralama ve Segment Sırası**

Grafik yerleşim motoru, dikdörtgenlerin ve halka segmentlerinin nihai konumunu belirler. İlgili kategori satırlarını eklemeden önce bir arada gruplayın, ancak belirli bir dikdörtgen konumuna ya da başlangıç açısına güvenmeyin. Sıralama anlam taşıyorsa, bunu etiketlerde belirtin ya da açık bir kategori ekseni sağlayan bir grafik türü kullanın.

### **Tema ve Sabit Renkler**

Biçimlendirilmemiş grafik seviyeleri, sunum temasından renk miras alır. Örnekte öngörülebilir çıktı için açıkça belirlenmiş RGB doldurmalar kullanılmıştır. Grafik temaya göre değişecekse, sabit RGB değerleri yerine şema renkleri kullanın ve her seviyeyi geçersiz kılmaktan kaçının. Bir şube ya da dal doldurması değiştirildiğinde etiket kontrastını da kontrol edin.

### **Etiketler ve Kullanılabilir Alan**

PowerPoint, bir segment çok küçük olduğunda etiketleri gizleyebilir ya da kırpabilir. Grafik boyutunu artırmak, kategori adlarını kısaltmak veya gösterilen etiket alanlarını azaltmak genellikle daha net bir sonuç verir. Bir etiket, [DataLabelFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datalabelformat/) aracılığıyla kategori adı, seri adı ve değeri birleştirebilir, ancak tüm alanları etkinleştirmek hiyerarşik grafikleri okunması zor hâle getirebilir.

### **Dışa Aktarma ve İşleme**

PPTX olarak kaydetmek grafiği düzenlenebilir tutar. Aspose.Slides sunumu PDF ya da görüntü olarak işlerken, desteklenen doldurmalar ve etiket ayarları grafikle birlikte işlenir. Yazı tipi ikamesi ve mevcut yerleşim alanındaki küçük farklılıklar satır kaydırma ya da etiket görünürlüğünü etkileyebilir; bu yüzden gerekli yazı tiplerini kurun ve önemli dışa aktarma hedeflerini doğrulayın.

## **SSS**

**Bir üst seviyenin değiştirilmesi neden birden çok yaprağı etkiler?**

Bir şube ya da dal, paylaşılan bir görsel segmenttir. Onun [ChartDataPointLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapointlevel/) öğesine bir alt yapraktan ulaşılabilir, ancak biçimlendirme yalnızca o yaprağa değil, paylaşılan üst segmente uygulanır.

**Bir veri etiketi neden eksik görünüyor?**

Önce etiketin [DataLabelFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datalabelformat/) nesnesinde gerekli alanları etkinleştirin. Ardından segmentin yeterli alana sahip olduğundan emin olun. Treemap üst‑etiket düzeni, grafik boyutları, etiket uzunluğu, yazı tipi boyutu ve etkin alan sayısı bir etiketin görüntülenip görüntülenmeyeceğini etkiler.

**Segmentlerin tam sırasını ya da koordinatlarını ayarlayabilir miyim?**

Kaynak‑satır sırasını kontrol edip her grubu ardışık tutabilirsiniz, ancak tam Treemap dikdörtgenlerini ya da Sunburst açılarını atayamazsınız. Grafik yerleşim motoru bunları hiyerarşi, değerler ve mevcut alan üzerinden hesaplar.

**Tema değiştiğinde renkler neden değişiyor?**

Tema‑tabanlı doldurmalar, sunum paletini takip edecek şekilde tasarlanmıştır. Sabit kalması gereken seviyelere açıkça RGB renkleri uygulayın veya yeni temaya uyum sağlamak istiyorsanız şema renklerini koruyun.

**Özel biçimlendirme PDF ve görüntü dışa aktarmalarında korunur mu?**

Evet, desteklenen grafik doldurmaları ve etiket ayarları işleme sırasında dahil edilir. Sistemler arası tutarlı sonuçlar elde etmek için gerekli yazı tiplerini sağlayın ve etiket oturumu yerleşime bağlı olduğundan nihai dışa aktarma boyutunu test edin.

## **İlgili Bağlantılar**

- [Treemap grafiklerini oluşturma](/slides/tr/nodejs-java/create-chart/#creating-tree-map-charts)
- [Sunburst grafiklerini oluşturma](/slides/tr/nodejs-java/create-chart/#creating-sunburst-charts)
- [Sunum grafiklerini dışa aktarma](/slides/tr/nodejs-java/export-chart/)
- [Sunum temalarını yönetme](/slides/tr/nodejs-java/presentation-theme/)