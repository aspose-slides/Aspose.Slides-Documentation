---
title: C++ ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/cpp/chart-series/
keywords:
- grafik serileri
- seri örtüşmesi
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "C++ kullanarak sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/) bir ilişkili değer kümesini temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplanma değerlerini sağlar. Seri adı, kategoriler ve nokta değerleri bu nedenle yalnızca görüntü metni olarak saklanmaz, [IChartDataCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/) nesneleriyle ilişkilendirilir.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0’da seri adlarını, sütun 0’da kategori adlarını ve kalan hücrelerde seri değerlerini kullanır. [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviye ayarlar, örneğin [IChartSeries::get_Format](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_format/) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint::get_Format](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_format/) tek bir nokta için seri görünümünün üzerine yazar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, grup nesnesine [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) üzerinden erişin.

Açık bir nokta ya da seri dolgu ayarı yoksa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Seri Örtüşmesini Ayarlama**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_overlap/) 2D bir grafikte çubukların ya da sütunların ne kadar örtüştüğünü –%100 ile %‑100 arasında – raporlar. Bu, üst‑seri grubundaki ayarın salt okunur bir projeksiyonudur. Gruptaki her uyumlu seriyi güncellemek için [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) metodunu çağırın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleşik bir grafikte ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Yeni grafik örnek seriler, kategoriler ve değerler içerir.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![The series overlap](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan dolgu ayarlamak üzere [IChartSeries::get_Format](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_format/) kullanın. Bir nokta zaten açık bir dolguye sahipse, onun [IChartDataPoint::get_Format](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_format/) ayarı o nokta için serinin dolgusunun üzerine yazar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![The color of the series](series_color.png)

## **Seri Adını Değiştirme**

Seri adı, grafik veri çalışma kitabında depolanır ve genellikle lejende gösterilir. Kümeleme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki isimlendirilmiş sabitler bu yapıyı açıkça gösterir:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ayrıca [IChartSeries::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_name/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![The series name](series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgu açıkça tanımlanmamışsa kullanılan renktir. Metodu çağırmak yalnızca hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, varsayılan her seri için otomatik rengi yazdırır:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Tam renkler grafik stil ve temaya bağlıdır.

## **Bir Grafik Serisi İçin Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve balon serileri için, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, tersleme özelliğini etkinleştirin ve negatif değer rengini [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirmektedir. Çalışma sayfası satır 0 serinin adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![The inverted solid fill color](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılır ve yalnızca seçili nokta için etkinleştirilir. Etkiyi görmek için nokta negatif bir değer alır:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Belirli Bir Veri Noktası Değerini Temizleme**

Bir noktayı diğerlerini kaldırmadan boş bırakmak için, arka plan hücresini `nullptr` olarak ayarlayın. Sütun grafiği için, çizilen değer [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değeri boş olarak işler.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Saçılma grafikleri ayrı X ve Y hücreleri, balon grafikleri ise ek bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metodunu çağırmayın; bu metod koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal değeri temsil eder. Bir hücreyi boş hâle getirmek için [IChartDataCell::set_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_value/) metodunu `nullptr` ile çağırın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Boş hücrelerin grafik içinde nasıl gösterileceğini seçmek için [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/set_displayblanksas/) kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukları çizim sırasında doldurmaz, yalnızca boş hücreleri nasıl yorumlayacağını belirler.

Aşağıdaki bağımsız örnek, bir satır grafiği oluşturur, 3. Gün değerini temizler ve her bir mod için aynı grafiği kaydeder. Giriş dosyasına ihtiyaç yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/) çalışma sayfası 0, sütun 0 kategori etiketleri, sütun 1 değerler; satır 0 seri adını tutar. Nihai veri `10, 20, empty, 30, 40` şeklindedir.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// 3. günü gerçekten boş bırakırken kategori ve veri noktasını koru.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Her çıktı dosyası, kaydetmeden önce atanan modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu ayarlayıp sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Satır grafiği üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategoriye bağlanacak bir çizgi olmadığından `Span` yukarıdaki bağlayıcı segmanı üretemez; eksik bir sütun ile sıfır‑yükseklikte bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir saçılma grafiğinde de bağlayıcı çizgi yoktur. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tür için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluğu, çubuk veya sütun genişliğinin yüzdesi olarak ifade eder. Örtüşme gibi, bu da tek bir seriye değil, üst‑seri grubuna aittir. Grup için bir kez [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları sıklaştırır.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca nihai sunumu kaydeder:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![The gap width](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) enum’ı ile temsil edilen tüm grafik türleri veri kullanır, ancak serilerinin değer yapısı ve ayarları aynı değildir. Örneğin, kategori grafiklerinde kategori ve değerler, saçılma grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Seri türüne uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseriesgroup/) aynı grup‑seviye çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden fazla grup içerebilir; bir seriden erişilen grup ayarlarını değiştirmek, grafiğin tüm serilerini zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection::AddChart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce seri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücreleriyle nasıl ilişkilendirilir?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/) içinde bulunan hücrelere referans verir. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, kategori satırları ile seri‑değer satırlarının hizalı olmasına dikkat edin; böylece her nokta istediğiniz kategori altında çizilir.

**Bir bütün seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `nullptr` olarak ayarlayın; noktanın kategori konumu boş bir nokta olarak kalır. [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metodunu yalnızca serideki tüm noktaları kaldırmak istediğinizde çağırın. Kategorileri de kaldırıyorsanız, her serinin değerlerinin kategori koleksiyonuyle hizalı kalması için tüm serileri güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/get_displayblanksas/) ayarına bağlıdır. Desteklenen grafikler boşlukları boşluk (gap), sıfır (zero) ya da komşu noktaları bağlayarak (span) gösterebilir. Sunumunuzda eksik verinin anlamına uygun ayarı seçin. Ayrıntılı örnek ve görsel karşılaştırma için **Boş Hücrelerin Görüntülenmesini Kontrol Etme** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) metodunu çağırın ve rengi [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) ile ayarlayın. Tek bir nokta için davranışı [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) ile geçersiz kılabilirsiniz. Bu metodlar biçimlendirmeyi etkiler; saklanan sayısal değerler değişmez.

**Seri ve nokta aynı anda biçimlendirildiğinde hangisi kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, seri biçimlendirmesi açık ise onu, aksi takdirde otomatik grafik stili ve temasını kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviye biçimlendirme geçersiz kılmaz.

**Bir grafiğin içerebileceği seri sayısında bir limit var mı?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafiğin okunabilirliği faydalı bir limit belirler.

**Sütunlar çok yakışık ya da çok uzak olduğunda ne yapılmalı?**

Uygun üst‑seri grubunda [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri birbirine daha yakın hâle getirebilirsiniz.