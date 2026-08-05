---
title: .NET'te Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap grafiği
- sunburst grafiği
- hiyerarşik grafik
- veri noktası
- veri etiketi
- şube rengi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile Treemap ve Sunburst grafiklerde hiyerarşik veri oluşturmayı ve seviyeleri, etiketleri ve renkleri özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Treemap ve Sunburst grafikler aynı tür hiyerarşik veriyi gösterir, ancak farklı düzenler kullanır. Bir Treemap hiyerarşiyi, alanları yaprak değerlerini temsil eden iç içe dikdörtgenler olarak çizer. Bir Sunburst ise bunu konsantrik halkalar şeklinde gösterir: üst düzey gruplar merkeze yakın, yaprak kategoriler ise dış halkada bulunur.

Aspose.Slides for .NET'te her sayısal değer bir [IChartDataPoint](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/) dir. Onun [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) koleksiyonu, yaprağa ve onun üst grup(lar)ına erişim sağlar. Bu makale bu eşlemeyi açıklar ve aynı örnek veriden iki grafik türünü nasıl oluşturup biçimlendireceğinizi gösterir.

![Tüketici ve İşletme dallarıyla bir Treemap grafiği](treemap-hierarchy.png)

![Aynı Tüketici ve İşletme hiyerarşisiyle bir Sunburst grafiği](sunburst-hierarchy.png)

## **Kategorileri, Veri Noktalarını ve Seviyeleri Anlamak**

Aşağıda kullanılan örnek üç kategori seviyesi ve bir sayısal seri içerir:

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

Her satır bir yaprak kategorisi ve bir veri noktası oluşturur. Kategori gruplama seviyeleri, o yapraktan üst gruplarına olan yolu tanımlar. İlk satır için yol `Consumer > Computers > Laptops` şeklindedir.

İndeksler, [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) içinde yapraktan yukarı doğru ilerler:

| `DataPointLevels` indeksi | Mantıksal Seviye | Treemap temsilciliği | Sunburst temsilciliği |
| ---: | --- | --- | --- |
| `0` | Yaprak | Değer dikdörtgeni | Dış halkası segmenti |
| `1` | Kök | Üst dikdörtgen veya başlık | Orta halkası segmenti |
| `2` | Şube | Üst düzey dikdörtgen veya başlık | İç halkası segmenti |

Bu sıralama, görsel düzenleri farklı olsa da, iki grafik türü için de aynıdır. Bir üst segment birden fazla yaprak tarafından paylaşılır. Bunu biçimlendirmek için, o gruptaki ilk veri noktasının ilgili seviyesini kullanın. Örneğin, `Consumer` şubesi `Laptops` noktasından başlarken, `Software` kökü `Licenses` noktasından başlar. Bu noktalara referans tutmak, `dataPoints[0]` veya `dataPoints[6]` gibi açıklanmamış ifadeler kullanmaktan daha net ve güvenlidir.

## **Her iki Grafik Türünü de Oluşturma ve Özelleştirme**

Aşağıdaki tam örnek, ilk slaytta bir Treemap ve ikinci slaytta bir Sunburst oluşturur. Hiyerarşiyi inşa eder, `Tablets` değerini gösterir, seçili seviyelere sabit renkler uygular, bir şube etiketini biçimlendirir ve sunumu kaydeder.

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

    // YAPRAK KATEGORİLERİNİ EKLEYİN. BİR GRUPLAMA ÖĞESİ YALNIZCA YENİ BİR GRUP BAŞLADIĞINDA AYARLANIR;
    // İZLEYEN KATEGORİLER, BAŞKA BİR ÖĞE AYARLANANA KADAR BU GRUP İÇİNDE KALIR.
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

    // TABLET YAPRAĞINDA KATEGORİ VE DEĞERİ GÖSTER.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // CONSUMER ŞUBESİNİ, O ŞUBEDEKİ İLK YAPRAK ÜZERİNDEN BİÇİMLENDİRİN.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // SOFTWARE KÖKÜNÜ, O KÖKTEDİKİ İLK YAPRAK ÜZERİNDEN BİÇİMLENDİRİN.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // PARENTLABELLAYOUT, TREEMAP ÜST ETİKETLERİNİ ETPİYOR; SUNBURST İSE HALKA SEGMENTLERİNİ KULLANIR.
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

Kategori hücreleri ve değer hücreleri aynı çalışma sayfası satırını kullanır, bu yüzden koleksiyon konumları hizalı kalır. Yeni bir grafik oluşturmak yerine mevcut bir grafik ile çalıştığınızda, önce kategori satırlarını inceleyin ve biçimlendirmek istediğiniz veri noktalarına ve seviyelere adlandırılmış referanslar depolayın.

## **Davranış ve Pratik Düşünceler**

### **Treemap ve Sunburst Farklılıkları**

- Bir Treemap, değeri iletmek için alan ve hiyerarşiyi iletmek için iç içe dikdörtgenler kullanır. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/parentlabellayout/) özelliği, bu grafik türünde üst etiketlerin nasıl görüneceğini kontrol eder.
- Bir Sunburst, değeri iletmek için açı ve hiyerarşiyi iletmek için halka derinliği kullanır. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/parentlabellayout/) bu halkanın etiketlerini kontrol etmez.
- Her iki grafik türü aynı kategori gruplama seviyelerini ve `DataPointLevels` içinde aynı yaprak‑üst sırasını kullanır; bu nedenle veri oluşturma ve seviye biçimlendirme kodu paylaşılabilir.
- Üst değerler, alt yapraklardan hesaplanır. Şubeler veya kökler için ayrı sayısal noktalar eklemeyin.

### **Sıralama ve Segment Sırası**

Grafik yerleşim motoru, dikdörtgenlerin ve halka segmentlerinin son konumunu belirler. İlgili kategori satırlarını eklemeden önce birlikte düzenleyin, ancak belirli bir dikdörtgen konumuna veya başlangıç açısına güvenmeyin. Eğer sıralama anlam taşıyorsa, bunu etiketlerde belirtin veya açık bir kategori ekseni olan bir grafik türü kullanın.

### **Tema ve Sabit Renkler**

Biçimlendirilmemiş grafik seviyeleri, sunum temasından renkleri devralır. Örnek, öngörülebilir çıktı için açık RGB doldurmalar kullanır. Grafik temasındaki değişiklikleri takip etmesi gerekiyorsa, sabit RGB değerleri yerine şema renkleri kullanın ve her seviyeyi geçersiz kılmaktan kaçının. Ayrıca bir şube veya kök dolgusunu değiştirdikten sonra etiket kontrastını kontrol edin.

### **Etiketler ve Mevcut Alan**

PowerPoint, bir segment çok küçük olduğunda etiketleri gizleyebilir veya kısaltabilir. Grafik boyutunu artırmak, kategori adlarını kısaltmak veya daha az etiket alanı göstermek genellikle daha net bir sonuç verir. Bir etiket, kategori adı, seri adı ve değeri [IDataLabelFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabelformat/) aracılığıyla birleştirebilir, ancak tüm alanların etkinleştirilmesi genellikle hiyerarşik grafiklerin okunmasını zorlaştırır.

### **Dışa Aktarım ve Oluşturma**

PPTX olarak kaydetmek, grafiği düzenlenebilir tutar. Aspose.Slides sunumu PDF veya görüntüye oluşturduğunda, desteklenen doldurmalar ve etiket ayarları grafikle birlikte işlenir. Yazı tipi ikamesi ve mevcut yerleşim alanındaki küçük farklılıklar satır kaydırmayı veya etiket görünürlüğünü değiştirebilir; bu yüzden gerekli yazı tiplerini kurun ve önemli dışa aktarım hedeflerini doğrulayın.

## **SSS**

**Neden bir üst seviyeyi değiştirmek birden fazla yaprağı etkiler?**

Bir şube veya kök, birden fazla yaprak tarafından paylaşılan görsel bir segmenttir. Onun [IChartDataPointLevel](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointlevel/) bir alt yapraktan ulaşılabilir, ancak biçimlendirme sadece o yaprağa değil, paylaşılan üst segmente uygulanır.

**Veri etiketi neden eksik?**

Önce etiketin [IDataLabelFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabelformat/) nesnesinde gerekli alanları etkinleştirin. Ardından segmentin yeterli alana sahip olup olmadığını kontrol edin. Treemap üst‑etiket düzeni, grafik boyutları, etiket uzunluğu, yazı tipi boyutu ve etkin alanların sayısı, bir etiketin gösterilip gösterilmeyeceğini etkiler.

**Segmentlerin tam sırasını veya koordinatlarını ayarlayabilir miyim?**

Satır‑kaynağı sırasını kontrol edebilir ve her grubu art arda tutabilirsiniz, ancak tam Treemap dikdörtgenlerini veya Sunburst açılarını belirleyemezsiniz. Bu değerler hiyerarşi, veri ve mevcut alandan layout motoru tarafından hesaplanır.

**Sunum teması değiştiğinde renkler neden değişir?**

Tema‑bazlı doldurmalar, sunum paletine uymak üzere tasarlanmıştır. Sabit kalması gereken seviyelere açık RGB renkleri uygulayın ya da yeni bir temaya uyum sağlamak istendiğinde şema renklerini koruyun.

**Özel biçimlendirme PDF ve görüntü dışa aktarımlarında korunur mu?**

Evet, desteklenen grafik doldurmaları ve etiket ayarları oluşturma sırasında dahil edilir. Tutarlı sonuçlar için gerekli yazı tiplerini sağlayın ve etiket sığdırmanın yerleşime bağlı olduğunu unutmayarak nihai dışa aktarım boyutunu test edin.

## **İlgili Bağlantılar**

- [Treemap grafikler oluştur](/slides/tr/net/create-chart/#create-tree-map-charts)
- [Sunburst grafikler oluştur](/slides/tr/net/create-chart/#create-sunburst-charts)
- [Sunum grafiklerini dışa aktar](/slides/tr/net/export-chart/)
- [Sunum temalarını yönet](/slides/tr/net/presentation-theme/)