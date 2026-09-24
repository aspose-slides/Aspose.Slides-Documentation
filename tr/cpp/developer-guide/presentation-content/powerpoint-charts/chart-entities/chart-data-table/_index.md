---
title: C++ Kullanarak Sunumlarda Çizelge Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/cpp/chart-data-table/
keywords:
- çizelge verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında çizelge veri tablosu yazı tiplerini, kenarlıkları ve gösterge anahtarlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for C++ size bir çizelgenin veri tablosunu görüntülemenize ve metin biçimlendirmesini, kenarlıklarını ve gösterge anahtarlarını özelleştirmenize olanak tanır. Bu makale, tabloyu nasıl etkinleştireceğinizi, metnini nasıl biçimlendireceğinizi, her kenarlık tipini nasıl kontrol edeceğinizi ve gösterge anahtarlarını nasıl göstereceğinizi veya gizleyeceğinizi açıklar. Örnekler, yapılandırılmış çizelgeleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarla**

Bir çizelgenin veri tablosunu görüntülemek için `true` değerini [IChart::set_HasDataTable](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/set_hasdatatable/) metoduna geçirin. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [IChart::get_ChartDataTable](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/get_chartdatatable/) metodunu kullanın.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. İlk slayta bir kümelenmiş sütun çizelgesi ekleyin.
1. Çizelgenin veri tablosunu etkinleştirin.
1. [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_fontbold/) ile kalın metni etkinleştirin ve 20 punto metin için [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_fontheight/) metoduna `20` değerini geçirin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, çalışma dizininde en az bir slaytı olan `test.pptx` dosyasını gerektirir. Varsayılan verilerle (50, 50) konumunda, 600 puan genişliğinde ve 400 puan yüksekliğinde bir çizelge ekler. Kaydedilen `output.pptx` dosyası, veri tablosu etkinleştirilmiş ve belirtilen yazı tipi ayarları uygulanmış çizelgeyi içerir.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Veri Tablosu Kenarlıklarını Özelleştir**

Tabloyu [IChart::set_HasDataTable](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/set_hasdatatable/) ile etkinleştirin ve [IChart::get_ChartDataTable](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/get_chartdatatable/) aracılığıyla erişin. Üç kenarlık tipini bağımsız olarak kontrol edebilirsiniz:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) yatay hücre kenarlıklarını kontrol eder.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) dikey hücre kenarlıklarını kontrol eder.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) tablonun dış kenarlığını kontrol eder.

`true` değerini her ayarlayıcıya geçirerek kenarlıkları gösterebilir, `false` geçirerek gizleyebilirsiniz. Aşağıdaki örnek, varsayılan verilerle bir kümelenmiş sütun çizelgesi oluşturur, yatay kenarlıkları ve dış kenarlığı gösterir ve dikey kenarlıkları gizler. Giriş dosyası gerekmez. Çizelgenin konumu ve boyutu puan cinsinden belirtilir.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

Aşağıdaki karşılaştırma, aynı çizelge verilerini ve gösterge anahtarı ayarını tüm dört durumda kullanır. Tüm kenarlıklar etkinleştirilmiş olarak başlanır, kalan her varyant sadece bir kenarlık ayarını devre dışı bırakır. Sol-alt varyant örnekteki kenarlık ayarlarıyla eşleşir.

![Tüm kenarlıklar etkin, yatay kenarlık yok, dikey kenarlık yok ve dış kenarlık yok olan çizelge veri tabloları](data-table-borders.png)

## **Gösterge Anahtarlarını Göster veya Gizle**

Gösterge anahtarları, veri tablosundaki seri adlarının yanında bulunan küçük renkli işaretlerdir. Okuyucuların her tablo satırını bir çizelge serisiyle eşleştirmesine yardımcı olur. Bu işaretleri göstermek için [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) metoduna `true`, gizlemek için `false` değerini geçirin.

Çizelgenin ayrı gösterge kısmı, [IChart::set_HasLegend](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/set_haslegend/) ile kontrol edilir. Bu ayarlar birbirinden bağımsızdır: ayrı göstergeyi gizlemek veri tablosundaki anahtarları gizlemez ve tablo anahtarlarını gizlemek ayrı göstergeyi gizlemez.

Aşağıdaki örnek, varsayılan verilerle bir çizelge oluşturur, veri tablosunu etkinleştirir ve içinde gösterge anahtarlarını gösterirken ayrı göstergeyi gizler. Tüm tablo kenarlıkları açıkça etkinleştirilmiştir. Giriş sunumu gerekmez. Yalnızca tablonun anahtarlarını gizlemek için [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) metoduna `false` değerini geçirin.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

Aşağıdaki karşılaştırma, aynı tabloyu gösterge anahtarları etkin ve devre dışı durumda gösterir. Tüm kenarlıklar etkin kalır ve ayrı çizelge göstergesi her iki durumda da gizlenir.

![Sol tarafta gösterge anahtarları gösterilen, sağ tarafta gizlenen çizelge veri tabloları](data-table-legend-keys.png)

## **SSS**

**Bir çizelgenin veri tablosunda gösterge anahtarlarını gösterebilir miyim?**

Evet. Gösterge anahtarlarını görüntülemek için [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) metoduna `true`, gizlemek için `false` değerini geçirin.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**

Evet. Aspose.Slides, çizelgeyi ve görüntülenen veri tablosunu slaytın bir parçası olarak [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/), veya [images](/slides/tr/cpp/convert-powerpoint-to-png/) formatlarına dışa aktarırken işler.

**Şablondan yüklü bir çizelgede veri tabloları ile çalışabilir miyim?**

Evet. Mevcut bir sunumdan veya şablondan yüklü bir çizelge için, veri tablosunun görüntülenip görüntülenmediğini kontrol etmek üzere [IChart::get_HasDataTable](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/get_hasdatatable/) kullanın ve görünürlüğünü değiştirmek için [IChart::set_HasDataTable](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/set_hasdatatable/) metodunu kullanın.

**Veri tablosu etkin olan çizelgeler nasıl bulunur?**

Her slayttaki şekilleri döngüyle dolaşın, çizelgeleri belirleyin ve [IChart::get_HasDataTable](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/get_hasdatatable/) sonucunu kontrol edin. `true` değeri veri tablosunun etkin olduğunu gösterir.