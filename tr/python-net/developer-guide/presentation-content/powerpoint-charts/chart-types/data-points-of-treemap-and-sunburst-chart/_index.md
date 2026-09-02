---
title: Python'da Treemap ve Sunburst Grafiklerinde Veri Noktalarını Özelleştir
linktitle: Treemap ve Sunburst Grafiklerindeki Veri Noktaları
type: docs
url: /tr/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap grafiği
- sunburst grafiği
- hiyerarşik grafik
- veri noktası
- veri etiketi
- şube rengi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile Treemap ve Sunburst grafiklerinde hiyerarşik veri oluşturmayı ve seviyeleri, etiketleri ve renkleri özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Treemap ve Sunburst grafikler aynı türde hiyerarşik verileri gösterir, ancak farklı düzenler kullanır. Treemap, hiyerarşiyi yaprak değerlerini temsil eden alanlara sahip iç içe dikdörtgenler olarak çizer. Sunburst, bunu konsantrik halkalar olarak çizer: üst düzey gruplar merkeze yakın, yaprak kategoriler ise dış halkada yer alır.

Aspose.Slides for Python via .NET'de, her sayısal değer bir [ChartDataPoint](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/). Bu [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) koleksiyonu yaprağa ve onun üst grup'larına erişim sağlar. Bu makale bu eşlemeyi açıklar ve aynı örnek veriden her iki grafik tipinin nasıl oluşturulup biçimlendirileceğini gösterir.

![Consumer ve Business dallarını içeren bir Treemap grafiği](treemap-hierarchy.png)

![Aynı Consumer ve Business hiyerarşisini içeren bir Sunburst grafiği](sunburst-hierarchy.png)

## **Kategorileri, Veri Noktalarını ve Seviyeleri Anlamak**

Aşağıda kullanılan örnek üç kategori seviyesi ve bir sayısal seriye sahiptir:

| Şube | Gövde | Yaprak | Gelir |
| --- | --- | --- | ---: |
| Tüketici | Bilgisayarlar | Dizüstü Bilgisayarlar | 12 |
| Tüketici | Bilgisayarlar | Masaüstü Bilgisayarlar | 8 |
| Tüketici | Mobil | Telefonlar | 15 |
| Tüketici | Mobil | Tabletler | 6 |
| İş | Hizmetler | Danışmanlık | 10 |
| İş | Hizmetler | Destek | 7 |
| İş | Yazılım | Lisanslar | 11 |
| İş | Yazılım | Abonelikler | 14 |

Her satır bir yaprak kategorisi ve bir veri noktası oluşturur. Kategori grup seviyeleri bu yapraktan üst gruplarına olan yolu tanımlar. İlk satır için yol `Consumer > Computers > Laptops` şeklindedir.

[ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) içindeki indeksler yapraktan yukarı doğru çalışır:

| `data_point_levels` indeksi | Mantıksal seviye | Treemap temsili | Sunburst temsili |
| ---: | --- | --- | --- |
| `0` | Yaprak | Değer dikdörtgeni | Dış-halka segmenti |
| `1` | Gövde | Üst dikdörtgen ya da başlık | Orta-halka segmenti |
| `2` | Şube | Üst düzey dikdörtgen ya da başlık | İç-halka segmenti |

Bu sıralama her iki grafik tipi için de aynı olup görsel düzenleri farklıdır. Bir üst segment birkaç yaprak tarafından paylaşılır. Bunu biçimlendirmek için, o grubun ilk veri noktasının ilgili seviyesini kullanın. Örneğin, `Consumer` şubesi `Laptops` noktasından, `Software` gövdesi ise `Licenses` noktasından başlar. Bu noktalara referans tutmak, `data_points[0]` ya da `data_points[6]` gibi açıklanmamış ifadeler kullanmaktan daha net ve güvenlidir.

## **Her İki Grafik Tipini Oluşturma ve Özelleştirme**

İşte aşağıdaki tam örnek, ilk slaytta bir Treemap ve ikinci slaytta bir Sunburst oluşturur. Hiyerarşiyi oluşturur, `Tablets` değeri görüntüler, seçilen seviyelere sabit renkler uygular, bir şube etiketini biçimler ve sunumu kaydeder.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    #    Yaprak kategorileri ekleyin. Bir gruplama öğesi yalnızca yeni bir grup başladığında ayarlanır; sonraki kategoriler başka bir öğe ayarlanana kadar aynı grup içinde kalır.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    #    Tablets yaprağında kategori ve değeri göster.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    #    Consumer şubesini, o şubedeki ilk yaprak üzerinden biçimlendirin.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    #    Software gövdesini, o gövdedeki ilk yaprak üzerinden biçimlendirin.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    #    parent_label_layout Treemap üst etiketlerini etkiler; Sunburst halka segmentlerini kullanır.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Kategori hücreleri ve değer hücreleri aynı çalışma sayfası satırını kullanır, böylece koleksiyon konumları hizalı kalır. Varolan bir grafik ile çalışırken, bir grafik oluşturmaktan ziyade, önce kategori satırlarını inceleyin ve biçimlendirmeyi planladığınız veri noktaları ve seviyeler için adlandırılmış referansları depolayın.

## **Davranış ve Pratik Hususlar**

### **Treemap ve Sunburst Farkları**

- Treemap, değeri iletişimde alanı ve hiyerarşiyi iletişimde iç içe dikdörtgenleri kullanır. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/parent_label_layout/) özelliği bu grafik tipinde üst etiketlerin nasıl görüneceğini denetler.
- Sunburst, değeri iletişimde açıyı ve hiyerarşiyi iletişimde halka derinliğini kullanır. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/parent_label_layout/) halka etiketlerini kontrol etmez.
- Her iki grafik tipi de aynı kategori gruplama seviyelerini ve `data_point_levels` içinde aynı yapraktan üst seviyeye doğru sıralamayı kullanır, bu nedenle veri oluşturma ve seviye biçimlendirme kodu paylaşılabilir.
- Üst değerler, alt yapraklardan hesaplanır. Şubeler veya gövdeler için ayrı sayısal noktalar eklemeyin.

### **Sıralama ve Segment Sırası**

Grafik yerleşim motoru, dikdörtgenlerin ve halka segmentlerinin nihai konumlarını belirler. İlgili kategori satırlarını eklemeden önce bir arada düzenleyin, ancak belirli bir dikdörtgen konumu ya da başlangıç açısına güvenmeyin. Eğer sıra bir anlam taşıyorsa, bunu etiketlerde belirtin ya da açık bir kategori ekseni olan bir grafik tipi kullanın.

### **Tema ve Sabit Renkler**

Biçimlendirilmemiş grafik seviyeleri, sunum temasından renkleri devralır. Örnek, öngörülebilir çıktı için açık RGB doldurmaları kullanır. Grafik temaya göre değişecekse, sabit RGB değerleri yerine şema renklerini kullanın ve her seviyeyi geçersiz kılmaktan kaçının. Ayrıca bir şube veya gövde doldurması değiştirildikten sonra etiket kontrastını kontrol edin.

### **Etiketler ve Kullanılabilir Alan**

PowerPoint, bir segment çok küçük olduğunda etiketleri gizleyebilir veya kesebilir. Grafik boyutunu artırmak, kategori adlarını kısaltmak veya daha az etiket alanı göstermek genellikle daha net bir sonuç verir. Bir etiket, kategori adı, seri adı ve değeri [DataLabelFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/) aracılığıyla birleştirebilir, ancak tüm alanları etkinleştirmek genellikle hiyerarşik grafiklerin okunmasını zorlaştırır.

### **Dışa Aktarma ve Oluşturma**

PPTX olarak kaydetmek, grafiği düzenlenebilir tutar. Aspose.Slides sunumu PDF veya görüntü olarak oluşturduğunda, desteklenen doldurmalar ve etiket ayarları grafik ile birlikte işlenir. Yazı tipi ikamesi ve kullanılabilir yerleşim alanındaki küçük farklılıklar satır kaydırmayı veya etiket görünürlüğünü değiştirebilir; bu yüzden gerekli yazı tiplerini kurun ve önemli dışa aktarma hedeflerini doğrulayın.

## **SSS**

**Neden bir üst seviyesi değiştirmek birden fazla yaprağı etkiler?**

Bir şube veya gövde, paylaşılan bir görsel segmenttir. Onun [ChartDataPointLevel](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointlevel/) bir alt yapraktan erişilebilir, ancak biçimlendirme sadece o yaprağa değil, paylaşılan üst segmente aittir.

**Neden bir veri etiketi eksik?**

İlk olarak, etiketin [DataLabelFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/) nesnesinde gerekli alanları etkinleştirin. Ardından segmentin yeterli alana sahip olup olmadığını kontrol edin. Treemap üst-etiket düzeni, grafik boyutları, etiket uzunluğu, yazı tipi boyutu ve etkin alan sayısı, bir etiketin görüntülenip görüntülenemeyeceğini etkiler.

**Segmentlerin kesin sırasını veya koordinatlarını ayarlayabilir miyim?**

Kaynak satır sırasını kontrol edebilir ve her grubu ardışık tutabilirsiniz, ancak kesin Treemap dikdörtgenlerini veya Sunburst açılarını atayamazsınız. Grafik yerleşim motoru bunları hiyerarşi, değerler ve kullanılabilir alandan hesaplar.

**Sunum teması değiştiğinde renkler neden değişir?**

Tema temelli doldurmalar, sunum paletini takip edecek şekilde tasarlanır. Sabit kalması gereken seviyelere açık RGB renkleri uygulayın veya yeni bir temaya uyum sağlanırken şema renklerini koruyun.

**Özel biçimlendirme PDF ve görüntü dışa aktarmalarında korunur mu?**

Evet, desteklenen grafik doldurmaları ve etiket ayarları oluşturma sırasında dahil edilir. Sistemler arasında tutarlı sonuçlar için gerekli yazı tiplerini temin edin ve etiket yerleşiminin bağımlı olduğu son dışa aktarma boyutunu test edin.

## **İlgili Bağlantılar**

- [Treemap grafikleri oluşturma](/slides/tr/python-net/create-chart/#create-tree-map-charts)
- [Sunburst grafikleri oluşturma](/slides/tr/python-net/create-chart/#create-sunburst-charts)
- [Sunum grafiklerini dışa aktar](/slides/tr/python-net/export-chart/)
- [Sunum temalarını yönet](/slides/tr/python-net/presentation-theme/)