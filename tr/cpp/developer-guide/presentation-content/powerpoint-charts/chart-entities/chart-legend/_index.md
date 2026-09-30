---
title: C++ Kullanarak Sunumlarda Grafik Lejantlarını Özelleştirme
linktitle: Grafik Lejantı
type: docs
url: /tr/cpp/chart-legend/
keywords:
- grafik lejanti
- lejant konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "PowerPoint sunumlarını, özelleştirilmiş lejant biçimlendirmesiyle optimize etmek için Aspose.Slides for C++ ile grafik lejantlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for C++ PowerPoint sunumlarında grafik lejandlarını özelleştirme seçenekleri sunar. Bu makale, bir lejandın konumlandırılması ve boyutlandırılması, tüm lejand için yazı tipi boyutunun ayarlanması, tek bir lejand girişinin biçimlendirilmesi ve seçili girişlerin gizlenmesi veya geri yüklenmesi nasıl yapılır gösterir.

SSS, lejand için alan ayırma, çok satırlı etiket gösterimi ve lejandın sunum temasının biçimlendirmesini devralması gibi ilgili davranışları kapsar.

## **Lejant Konumlandırma**

Lejantın [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) ve [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) metodlarını kullanarak konumunu ve boyutunu grafiğin boyutlarının kesirleri olarak belirleyin.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan verilerle bir kümelenmiş sütun grafiği ekler. İstenen lejant ofsetlerini ve boyutlarını grafiğin genişliği ve yüksekliği ile bölmek, bunları göreceli değerlere dönüştürür: lejant, grafiğin sol üst köşesinden 50 nokta uzaklıkta ve 100 × 100 nokta boyutundadır.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Lejantın Yazı Tipi Boyutunu Ayarlama**

Lejantın [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) yöntemini kullanarak metin biçimlendirmesine erişin ve [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) ile yazı tipi boyutunu nokta olarak ayarlayın.

Bu örnek bir grafik oluşturur, varsayılan verileri kullanır ve lejant metnini 20 nokta olarak ayarlar. Ayrıca dikey eksen için otomatik sınırları devre dışı bırakır ve aralığı -5 ile 10 arasında ayarlar.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Tek Bir Lejant Girişinin Yazı Tipi Boyutunu Ayarlama**

Lejantın [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) yönteminin döndürdüğü koleksiyonu kullanarak belirli bir girişin biçimlendirmesine erişin. Giriş indeksleri sıfır‑tabanlıdır; dolayısıyla `1` indeksi ikinci girişi temsil eder.

Bu örnek, varsayılan verileri en az iki seri içeren bir kümelenmiş sütun grafiği oluşturur. İkinci lejant girişini kalın, italik ve 20 nokta mavi metin ile biçimlendirir.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Tek Tek Lejant Girişlerini Gizleme**

Bir yardımcı seriyi verileri görünür tutarken lejanttan çıkarmak için, [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) üzerinden [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) metodunu `true` ile çağırın. Bu yalnızca seçili lejant girişini gizler; seriyi veya veri noktalarını kaldırmaz. Bunun tersine, [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) metodunu `false` ile çağırmak, tüm lejanti gizler.

Aşağıdaki örnek, varsayılan verilerle birden fazla seri içeren bir kümelenmiş sütun grafiği oluşturur. İkinci serinin lejant girişini (indeks `1`) gizler ve sunumu kaydeder. Ardından `set_Hide` metodunu `false` ile çağırarak girişi geri yükler ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Aynı girişi grafik verilerini değiştirmeden geri yükle.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Aşağıdaki karşılaştırma, tüm girişlerin görüldüğü ve ikinci girişin gizlendiği aynı grafiği gösterir. İkinci serinin sütunları değişmeden kalır.

![Tüm lejant girişlerinin görüldüğü ve Serisi 2'nin lejanttan gizlendiği bir grafiğin karşılaştırması; tüm sütunlar görünür durumda.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerinde lejant girişleri serileri tanımlar. Pasta grafiklerinde ise bireysel veri noktalarını (dilimleri) tanımlar; bu nedenle seçili dilim üzerinde [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) kullanılmalıdır. API, `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` ve `BarOfPie` grafik tipleri için bu veri‑nokta yöntemini belgelemektedir. Bu yöntemin, listede yer almayan halka grafiklerinde geçerli olduğunu varsaymayın.

## **SSS**

**Grafik, lejanti üzerine bindirmek yerine onun için yer ayırabilir mi?**  
Evet. Lejanti grafiğin çizim alanı üzerine bindirmesine izin vermek yerine yer ayırmak için `false` ile [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) metodunu çağırın.

**Çok satırlı lejant etiketleri oluşturabilir miyim?**  
Evet. Genişlik yetersiz olduğunda uzun etiketler satır sonuna kaydırılır. Ayrıca seri adlarında yeni satır karakterleri ekleyerek satır sonları talep edebilirsiniz.

**Lejant, sunum temasının renk şemasını nasıl takip eder?**  
Lejantın renklerini, doldurmalarını ve yazı tiplerini ayarlamadan bırakın; böylece tema biçimlendirmesini devralır. Açıkça yapılan biçimlendirme, ilgili tema ayarlarını geçersiz kılar.