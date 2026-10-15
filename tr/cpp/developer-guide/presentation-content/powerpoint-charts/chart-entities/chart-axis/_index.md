---
title: C++ Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/cpp/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- ekseni özelleştir
- ekseni manipüle et
- ekseni yönet
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek üzere Aspose.Slides for C++ kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for C++ ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaret aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, görüntüleme birimleri ve logaritmik ölçeklemeyi kapsar.

## **Grafiklerde Dikey Eksende Maksimum Değerleri Almak**

[Sunum](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) oluşturun ve varsayılan veri ile bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafiğin düzeninin güncel olduğundan emin olmak için [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) çağırın.

Eksen sınırları için [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) ve [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) okuyun, işaret aralıkları için [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) ve [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) kullanın. Tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlamak için [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) ve [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) kullanılabilir. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Eksenler Arasındaki Verileri Değiştir**

Grafik verilerindeki seriler ve kategorilerin rollerini değiştirmek için [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) kullanın. Önceki her kategori bir seri, önceki her seri bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, varsayılan verileri `Sheet1!A1:D5` aralığına (başlık satırı ve kategori sütunu dahil) bağlamak için [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) kullanır, ardından satır ve sütunları değiştirir. Dört seri ve üç kategori içeren bir grafik kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Bir Eksenin Çizim Sırasını Tersine Çevir**

Kategori veya değer eksenini tersine çevirmek için [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) kullanın. Örneğin, yatay çubuk grafik, proje aşamalarını çalışma sayfasındaki aynı sırada (Planlama, Geliştirme, Test) üstten alta gösterebilir. Bir ekseni tersine çevirmek çizim yönünü değiştirir; çalışma sayfası verilerini sıralamaz veya yeniden düzenlemez. Bunun aksine, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) seriler ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafik oluşturur. Üç slayt kaydeder: normal sıra, tersine çevrilmiş kategoriler ve tersine çevrilmiş değerler. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// 2. slayt: ilk kategoriyi üstte göster.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Yatay değer eksenini altta tut.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// 3. slayt: yalnızca yatay sayısal ölçeği tersine çevir.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Bir ekseni tersine çevirmek, dik ekseni grafiğin karşı tarafına da taşıyabilir. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) diğer eksenin yapılandırılan ekseni nerede kestiğini kontrol eder. 2. slaytta, tersine çevrilmiş kategori ekseninde `Maximum` ayarı, yatay değer eksenini altta tutar. Belirli bir kesişim noktası için [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) kullanın. Yön değiştirirken kesişim ayarlarını kontrol edin, özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri getirmek için `false` ile `set_IsPlotOrderReversed` çağırın; kesişim ayarları ayrı tutulur.

| Normal sıra (slayt 1) | Tersine çevrilmiş kategoriler (slayt 2) | Tersine çevrilmiş değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasına sahip yatay çubuk grafik](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafik](axis-order-categories-reversed.png) | ![Değer ekseni tersine çevrilmiş ve sıfır sağda olan yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru; değerler soldan sağa artar. | Planlama, Geliştirme ve Test, üstten alta doğru. Değerler ve çalışma sayfası satır sırası değişmemiştir. | Kategoriler normal sıralarını korur; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırak**

Dikey ekseni gizlemek için `false` ile [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) kullanın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve dik ekseni gizli olarak kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırak**

Yatay ekseni gizlemek için `false` ile [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) kullanın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Kategorik Ekseni Değiştir**

[Tarih veya metin kategorik eksen] seçmek için [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) kullanın. Bu örnek, birinci slayttaki ilk şekil olarak bir grafik içeren `ExistingChart.pptx` dosyasını gerektirir ve kategori hücrelerinin sayısal Excel tarih değerleri içerdiğini varsayar. Yatay ekseni tarih ekseni olarak değiştirir. [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) `1` ve [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) `months` ayarları, büyük işaretleri bir aylık aralıklarla yerleştirir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Kategori Ekseni Etiket Aralıklarını Kontrol Et**

Bir grafikte çok sayıda kategori olduğunda, kategori veya veri noktalarını kaldırmadan görünür eksen etiketi sayısını azaltın. [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) `false` yapın, ardından istediğiniz kategori aralığını belirlemek için [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) kullanın. Normal sıralarındaki metin kategorileri için sayım ilk kategoriden başlar:

| Aralık | Örnekte Görünen Etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunlar kaldırılmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi göstermeyebilir.

İşaret işaretlerinin ayrı kontrolleri vardır. [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) `false` yapın ve aralığını ayarlamak için [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) kullanın. Örneğin, `1` her kategori aralığında bir işaret işareti tutar, ancak etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ile [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) ayarlayarak sonucu görebilirsiniz. Otomatik boşluk özelliğini tekrar `true` yaparsanız grafik yeniden o aralığı seçer.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik boşluk, bağımsız etiket aralığı ve bağımsız işaret işaretleri, ve otomatik boşluğa geri dönüş. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını kolay görür.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// Slide 2: show every third label, but keep a tick mark for every category.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: let the chart choose both intervals again.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Otomatik boşluk (slayt 1):** Bu görüntüde her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi boşluğu](category-axis-automatic.png)

**Manuel boşluk (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaret işaretleri her kategori aralığında kalır. Etiketi olmayan tüm 24 sütun aynı değerlerle görünür. 3. slayt, yukarıdaki otomatik görünümü geri yükler.

![Üç aralıkla manuel kategori etiketi ve tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seç**

Metin kategori ekseni için bu kategori-sayısı aralığını kullanın; örneğin bir sütun, çizgi, alan veya çubuk grafiğinin kategori ekseni. Sütun grafiğinde yatay eksen olur. Yatay çubuk grafiğinde kategori ekseni dik olduğundan [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) üzerine uygulanmalıdır. İşaret işareti boşluğu, bir serinin eksenine sahip grafiklerde de geçerlidir.

Değer ekseninin sayısal ölçeğini kategori etiketi boşluğu ile ayarlamayın. Değer ekseninde, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) bir değer farkı belirler: örneğin `10` büyük birim, eksen sıfırdan başlıyorsa 0, 10, 20 … gibi işaretler üretir. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Değiştir bir Kategorik Ekseni](#change-a-category-axis) bölümünde anlatıldığı gibi zaman tabanlı büyük birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri İçin Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, birinci çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır. Tarih ekseni seçmek için [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) kullanın, kaynak ile bağlantılı biçimlendirmeyi [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) ile devre dışı bırakın ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört haneli yıl gösterecek şekilde `yyyy` değerini [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) ile atayın.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **Grafik Eksen Başlığı İçin Döndürme Açısı Ayarla**

Dikey eksen başlığını [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) ile etkinleştirin, başlık metnini sağlayın ve başlığı döndürmek için [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) kullanın. Açı derece cinsinden ölçülür; bu örnek, değer ekseni başlığı 90 derece döndürülmüş bir sütun grafiği kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarla**

Değer ekseninin kategori eksenini kategoriler arasındaki işaretlerde mi yoksa kategori işaretlerinde mi kesiştireceğini kontrol etmek için [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) kullanın. Bu özellik yalnızca kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` yapar ve sonucu kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Grafik Değer Ekseni Üzerinde Görüntüleme Birimini Ayarla**

Değer eksenindeki etiketleri temel verileri değiştirmeden ölçeklendirmek için [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) kullanın. [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) `Millions` olarak ayarlandığında 60 000 000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve dik eksenine milyon görüntüleme birimini uygular.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Logaritmik Değer Ekseni Yapılandır**

Pozitif değerler birkaç mertebe fark ediyorsa logaritmik değer ekseni yararlıdır. Örneğin bir hizmet beş dönem içinde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte, daha küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçekte, eşit mesafeler eşit oranları temsil eder, bu da göreli büyümeyi karşılaştırmayı kolaylaştırır.

Değer ekseninde `true` ile [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) çağırın ve tabanı seçmek için [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) kullanın. Bu, mevcut değerlerin nasıl gösterildiğini değiştirir; veriyi veya logaritmik bir trend çizgisini eklemez. Trend çizgisi, verideki ilişkiyi uydurur ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanını Seç**

Çizgi veya sütun grafiklerinde değer ekseni [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) olur. Yatay çubuk grafiklerinde [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) olur. Dağılım ve balon grafiklerde iki değer ekseni vardır; X değerleri için yatay, Y değerleri için düşey eksen veya ikisi de seçilebilir. Kategori eksenine logaritmik ölçekleme uygulamayın.

Varsayılan logaritmik taban `10` dır. PPTX grafiklerinde taban `2` ile `1000` arasında (dahil) olmalıdır; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanında 10, 100, 1 000, 10 000 gibi ardışık katlar eşit aralıklıdır.

### **Doğrusal ve Logaritmik Ölçeklemeyi Karşılaştır**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısı içeren bir çizgi grafik oluşturur, ardından bu slaytı çoğaltır ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// İlk slaytı doğrusal tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Doğrusal ölçek (slayt 1):** Eşit dik mesafeler, istek sayılarının eşit farklarını temsil eder. En büyük değer grafiği domine eder, küçük değerler ayırt edilmesi zorlaşır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dik mesafeler, eşit oranları temsil eder. Her dönem, bir önceki dönemden on kat fazla isteğe sahiptir; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Ekseni etiketleri hâlâ özgün istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısını taban‑10 logaritmik değer ekseninde gösteren grafik](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşle**

Logaritmik ölçek yalnızca kesinlikle pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçek kullanın veya ayrı olarak gösterin. Bu değerleri analiz için atlamak uygun ise, eksikliği açıklayın. Verileri küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak yapılandırılan minimum veya maksimum değerler de pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri nasıl ayarlarım (ekseni kesme)?**

Ekseni kesme davranışını seçmek için [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) kullanın. Sayısal bir kesişim değeri belirtmek için [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza izin verir.

**İşaret etiketlerini eksene göre nasıl konumlandırabilirim?**

[TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) değerlerinden birini kullanarak [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) ayarlayın: `Low`, `High`, `NextTo` veya `None`. İşaret işaretlerini kontrol etmek için [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) veya [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) kullanın; bunlar etiket konumlandırmadan ayrı özelliklerdir.