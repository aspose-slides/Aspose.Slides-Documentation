---
title: C++ Kullanarak Treemap ve Sunburst Grafikleri İçin Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap grafiği
- sunburst grafiği
- veri noktası
- etiket rengi
- dal rengi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak treemap ve sunburst grafiklerde veri noktalarını nasıl yöneteceğinizi öğrenin; PowerPoint formatlarıyla uyumludur."
---
## **Giriş**

PowerPoint grafiklerinin diğer türleri arasında iki “hiyerarşik” tür vardır - **Treemap** ve **Sunburst** grafiği (Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ya da Multi Level Pie Chart olarak da bilinir). Bu grafikler, yapraklardan dalın tepesine kadar bir ağaç olarak düzenlenmiş hiyerarşik verileri gösterir. Yapraklar, seri veri noktalarıyla tanımlanır ve sonraki her bir iç içe gruplama seviyesi ilgili kategoriyle tanımlanır. Aspose.Slides for C++ , Sunburst Chart ve Treemap veri noktalarını C++ içinde biçimlendirmeye olanak tanır.

İşte bir Sunburst Chart, Series1 sütunundaki veriler yaprak düğümleri tanımlarken diğer sütunlar hiyerarşik veri noktalarını tanımlar:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Sunburst grafiğini sunuma ekleyerek başlayalım:



``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/tr/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}


Grafiğin veri noktalarını biçimlendirmeye ihtiyaç duyuluyorsa, aşağıdakileri kullanmalıyız:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/) sınıfları ve [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) yöntemi, Treemap ve Sunburst grafiklerinin veri noktalarını biçimlendirmeye erişim sağlar. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) çok seviyeli kategorilere erişim için kullanılır – [**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/) nesnelerinin kapsayıcısını temsil eder. 
Temelde, veri noktalarına özgü ek özellikler eklenmiş [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) için bir sarmalayıcıdır. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/) sınıfının iki yöntemi vardır: [**get_Format()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) ve [**get_Label()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/); bu yöntemler ilgili ayarlara erişim sağlar.

## **Bir Veri Noktası Değerini Göster**
"Leaf 4" veri noktasının değerini göster:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Bir Veri Noktası Etiketini ve Rengini Ayarla**
"Branch 1" veri etiketini kategori adı yerine seri adı ("Series1") gösterecek şekilde ayarlayın. Ardından metin rengini sarı yapın:



``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Veri Noktası Dal Rengini Ayarla**

"Stem 4" dalının rengini değiştirin:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **SSS**

**Sunburst/Treemap’de segmentlerin sırasını (sıralamasını) değiştirebilir miyim?**

Hayır. PowerPoint segmentleri otomatik olarak (genellikle azalan değerlerle, saat yönünde) sıralar. Aspose.Slides bu davranışı yansıtır: sıralamayı doğrudan değiştiremezsiniz; veriyi ön işleyerek elde edersiniz.

**Sunum teması segment ve etiket renklerini nasıl etkiler?**

Grafik renkleri, doldurma/​​yazı tiplerini açıkça ayarlamazsanız sunumun [theme/palette](/slides/tr/cpp/presentation-theme/) öğesini devralır. Tutarlı sonuçlar için gerekli seviyelerde katı doldurmalar ve metin biçimlendirmesi kullanın.

**PDF/PNG’ye dışa aktarırken özel dal renkleri ve etiket ayarları korunur mu?**

Evet. Sunumu dışa aktarırken, grafik ayarları (doldurmalar, etiketler) çıktı formatlarında korunur; çünkü Aspose.Slides, grafik biçimlendirmesi uygulanmış şekilde render eder.

**Grafiğin üzerine özel bir katman yerleştirmek için etiket/elemanın gerçek koordinatlarını hesaplayabilir miyim?**

Evet. Grafik yerleşimi doğrulandıktan sonra, elemanlar için gerçek X ve gerçek Y değerleri mevcuttur (örneğin bir [DataLabel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/datalabel/) için), bu da örtülerin hassas konumlandırılmasına yardımcı olur.