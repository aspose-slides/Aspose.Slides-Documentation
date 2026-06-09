---
title: C++ Kullanarak Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
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
description: "Aspose.Slides for C++ ile treemap ve sunburst grafiklerinde veri noktalarını yönetmeyi öğrenin; PowerPoint formatlarıyla uyumludur."
---
## **Giriş**

PowerPoint grafiklerinin diğer türlerinin yanı sıra iki adet “hiyerarşik” tür vardır - **Treemap** ve **Sunburst** grafiği (Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph veya Multi Level Pie Chart olarak da bilinir). Bu grafikler, yapraklardan dalın tepesine kadar bir ağaç olarak düzenlenen hiyerarşik verileri gösterir. Yapraklar seri veri noktalarıyla tanımlanır ve sonraki her iç içe gruplanma seviyesi ilgili kategoriyle tanımlanır. Aspose.Slides for C++ Sunburst Chart ve Treemap veri noktalarını C++ içinde biçimlendirmeye olanak tanır.

Aşağıda bir Sunburst Chart örneği var, Series1 sütunundaki veriler yaprak düğümleri tanımlarken, diğer sütunlar hiyerarşik veri noktalarını tanımlar:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Sunburst grafiğini sunuma ekleyerek başlayalım:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [**Sunburst Grafik Oluşturma**](/slides/tr/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Grafiğin veri noktalarını biçimlendirmek gerekirse aşağıdakileri kullanmalıyız:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/) sınıfları ve [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) metodu, Treemap ve Sunburst grafiklerinin veri noktalarını biçimlendirmeye erişim sağlar.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) çok seviyeli kategorilere erişmek için kullanılır - bu, [**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/) nesnelerinin kapsayıcısını temsil eder.  
Temelde bu, [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) için veri noktalarına özgü ek özellikler eklenmiş bir sarmalayıcıdır.  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/) sınıfı iki metoda sahiptir: [**get_Format()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) ve [**get_Label()**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) bu metodlar ilgili ayarlara erişim sağlar.

## **Bir Veri Noktasının Değerini Göster**

"Leaf 4" veri noktasının değerini göster:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Bir Veri Noktasının Etiketini ve Rengini Ayarla**

"Branch 1" veri etiketini kategori adı yerine seri adı ("Series1") gösterecek şekilde ayarlayın. Ardından metin rengini sarı olarak ayarlayın:

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

**Sunburst/Treemap dilimlerindeki sıralamayı (sıralamayı) değiştirebilir miyim?**  
Hayır. PowerPoint dilimleri otomatik olarak (genellikle azalan değerler, saat yönünde) sıralar. Aspose.Slides bu davranışı yansıtır: sıralamayı doğrudan değiştiremezsiniz; bunu verileri ön işleyerek elde edersiniz.

**Sunum teması, dilimlerin ve etiketlerin renklerini nasıl etkiler?**  
Grafik renkleri, doldurmaları/yazı tiplerini açıkça ayarlamazsanız, sunumun [theme/palette](/slides/tr/cpp/presentation-theme/) öğesini miras alır. Tutarlı sonuçlar için istenen seviyelerde katı dolgu ve metin formatlamasını kilitleyin.

**PDF/PNG olarak dışa aktarırken özel dal renkleri ve etiket ayarları korunur mu?**  
Evet. Sunumu dışa aktarırken, grafik ayarları (dolgu, etiketler) çıktıda korunur çünkü Aspose.Slides grafik biçimlendirmesi uygulanmış olarak render eder.

**Grafiğin üzerine özel bir bindirme yerleştirmek için bir etiket/elemanın gerçek koordinatlarını hesaplayabilir miyim?**  
Evet. Grafik düzeni doğrulandıktan sonra, elemanlar için gerçek X ve gerçek Y değerleri mevcuttur (örneğin, bir [DataLabel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/datalabel/)), bu da bindirmelerin hassas konumlandırılmasına yardımcı olur.