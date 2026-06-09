---
title: Python'da Treemap ve Sunburst Grafiklerinde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap grafiği
- sunburst grafiği
- veri noktası
- etiket rengi
- dal rengi
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile treemap ve sunburst grafiklerindeki veri noktalarını nasıl yöneteceğinizi öğrenin; PowerPoint ve OpenDocument formatlarıyla uyumludur."
---
## **Giriş**

Diğer PowerPoint grafik türleri arasında, iki hiyerarşik grafik vardır—**Treemap** ve **Sunburst** (Sunburst Grafiği, Sunburst Diyagramı, Radial Grafik, Radial Çizim veya Çok Katmanlı Pasta Grafiği olarak da bilinir). Bu grafikler, yapraklardan dalın tepesine kadar bir ağaç şeklinde düzenlenmiş hiyerarşik verileri gösterir. Yapraklar, seri veri noktalarıyla tanımlanır ve sonraki her iç içe grup seviyesi ilgili kategoriyle tanımlanır. Aspose.Slides for Python via .NET, Python’da Sunburst grafikleri ve Treemap’lerin veri noktalarını biçimlendirmenize olanak tanır.

Aşağıda, Series1 sütunundaki verilerin yaprak düğümleri, diğer sütunların ise hiyerarşik veri noktalarını tanımladığı bir Sunburst grafiği gösterilmektedir:

![Sunburst grafik örneği](sunburst_example.png)

Yeni bir Sunburst grafiği ekleyerek başlayalım:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Ayrıca bakınız" %}}
- [**Sunburst Grafikler Oluştur**](/slides/tr/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Grafik veri noktalarını biçimlendirmeniz gerekiyorsa, aşağıdaki API'leri kullanın:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointlevel/), ve [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) özelliği. Bu API'ler Treemap ve Sunburst grafiklerinde veri noktalarını biçimlendirmeye erişim sağlar. [ChartDataPointLevelsManager], çok seviyeli kategorilere erişmek için kullanılır; [ChartDataPointLevel] nesnelerinin bir kapsayıcısını temsil eder. Temelde, veri noktalarına özgü ek özelliklere sahip bir [ChartCategoryLevelsManager] sarmalayıcısıdır. [ChartDataPointLevel] türü iki özelliği ortaya koyar—[format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointlevel/format/) ve [label](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointlevel/label/)—ve bu özellikler ilgili ayarlara erişim sağlar.

## **Veri Noktası Değerlerini Görüntüleme**

Bu bölüm, Treemap ve Sunburst grafiklerinde tek tek veri noktalarının değerlerini nasıl görüntüleyeceğinizi gösterir. Seçili noktalar için değer etiketlerini nasıl etkinleştireceğinizi göreceksiniz.

"Leaf 4" veri noktasının değerini görüntüleyin:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Veri noktası değeri](data_point_value.png)

## **Veri Noktaları için Etiket ve Renkleri Ayarlama**

Bu bölüm, Treemap ve Sunburst grafiklerinde tek tek veri noktaları için özel etiketler ve renkler nasıl ayarlanır gösterir. Belirli bir veri noktasına nasıl erişileceğini, bir etiket atamayı ve önemli düğümleri vurgulamak için katı bir dolgu uygulamayı öğreneceksiniz.

"Branch 1" veri etiketini kategori adı yerine seri adı ("Series1") gösterecek şekilde ayarlayın ve ardından metin rengini sarı olarak belirleyin:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Veri noktasının etiketi ve rengi](data_point_color.png)

## **Veri Noktaları için Dal Renklerini Ayarlama**

Dal renklerini kullanarak, Treemap ve Sunburst grafiklerinde üst ve alt düğümlerin görsel olarak nasıl gruplandığını kontrol edin. Bu bölüm, belirli bir veri noktası için özel bir dal rengi ayarlamayı gösterir; böylece önemli alt ağaçları vurgulayabilir ve grafiğin okunabilirliğini artırabilirsiniz.

"Stem 4" dalının rengini değiştirin:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Dal rengi](branch_color.png)

## **SSS**

**Sunburst/Treemap'teki segmentlerin sırasını (sıralamasını) değiştirebilir miyim?**

Hayır. PowerPoint segmentleri otomatik olarak (genellikle azalan değerler ve saat yönünde) sıralar. Aspose.Slides bu davranışı yansıtır: sırayı doğrudan değiştiremezsiniz; bunu verileri ön işlemden geçirerek elde edersiniz.

**Sunum teması segment ve etiket renklerini nasıl etkiler?**

Grafik renkleri, dolgu/çevreleri (fill/font) açıkça ayarlamazsanız, sunumun [theme/palette](/slides/tr/python-net/presentation-theme/) öğesinden devralınır. Tutarlı sonuçlar için, gerekli seviyelerde katı dolgu ve metin biçimlendirmesini sabitleyin.

**PDF/PNG'ye dışa aktarma özel dal renklerini ve etiket ayarlarını korur mu?**

Evet. Sunumu dışa aktarırken, grafik ayarları (dolgu, etiketler) çıktı formatlarında korunur çünkü Aspose.Slides, grafiğin biçimlendirilmiş haliyle oluşturur.

**Grafiğin üzerine özel bindirme yerleştirmek için bir etiket/elemanın gerçek koordinatlarını hesaplayabilir miyim?**

Evet. Grafik yerleşimi doğrulandıktan sonra, öğeler için `actual_x`/`actual_y` değerleri (örneğin bir [DataLabel](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/)) kullanılabilir; bu, bindirmelerin hassas konumlandırılmasına yardımcı olur.