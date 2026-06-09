---
title: Sunumlarda Grafik Veri Serilerini С++ ile Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/cpp/chart-series/
keywords:
- grafik serisi
- seri çakışması
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) için С++'da grafik serilerini nasıl yöneteceğinizi, pratik kod örnekleri ve en iyi uygulamalarla veri sunumlarınızı geliştirecek şekilde öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'da [ChartSeries](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts.chartseries/) rolünü, verilerin sunumlar içinde nasıl yapılandırıldığını ve görselleştirildiğini odaklanarak açıklar. Bu nesneler, bir grafikteki bireysel veri noktası kümelerini, kategorileri ve görünüm parametrelerini tanımlayan temel öğeleri sağlar. [ChartSeries](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts.chartseries/) ile çalışarak, geliştiriciler temel veri kaynaklarını sorunsuz bir şekilde entegre edebilir ve bilgilerin nasıl gösterileceği üzerinde tam kontrol sağlayabilir, böylece içgörüleri ve analizleri net bir şekilde ileten dinamik, veri odaklı sunumlar elde eder.

Bir seri, bir grafikte çizilen sayıların satırı veya sütunudur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Veri Serisi Çakışmasını Ayarla**

[ IChartSeries::get_Overlap()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) yöntemiyle, çubukların ve sütunların 2D bir grafikte ne kadar çakışması gerektiğini belirtebilirsiniz (aralık: -100 ile 100). Bu özellik, üst seriler grubunun tüm serilerine uygulanır: bu, ilgili grup özelliğinin bir yansımasıdır.

İstediğiniz `Overlap` değerini ayarlamak için `get_ParentSeriesGroup()::set_Overlap()` yöntemini kullanın. 

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
1. Bir slayda küme sütun grafiği ekleyin.
1. İlk grafik serisine erişin.
1. Grafik serisinin `ParentSeriesGroup` özelliğine erişin ve seri için istediğiniz çakışma değerini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu C++ kodu, bir grafik serisinin çakışmasını nasıl ayarlayacağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Grafik ekler
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Serinin çakışmasını ayarlar
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Sunum dosyasını diske yazar
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Veri Serisi Rengini Değiştir**
Aspose.Slides for C++ bir serinin rengini şu şekilde değiştirmenizi sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
1. Slayta bir grafik ekleyin.
1. Rengini değiştirmek istediğiniz seriye erişin. 
1. İstediğiniz dolgu tipini ve dolgu rengini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, bir serinin rengini nasıl değiştireceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Veri Serisi Kategorisinin Rengini Değiştir**
Aspose.Slides for C++ bir seri kategorisinin rengini şu şekilde değiştirmenizi sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
1. Slayta bir grafik ekleyin.
1. Rengini değiştirmek istediğiniz seri kategorisine erişin.
1. İstediğiniz dolgu tipini ve dolgu rengini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, bir seri kategorisinin rengini nasıl değiştireceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Veri Serisi Adını Değiştir** 

Varsayılan olarak, bir grafiğin açıklama adları, her sütun veya satırın üzerindeki hücrelerin içeriğidir. 

Örneğimizde (örnek görüntü), 

* sütunlar *Series 1, Series 2,* ve *Series 3*;
* satırlar *Category 1, Category 2, Category 3,* ve *Category 4.* 

Aspose.Slides for C++ bir serinin adını grafik verisinde ve açıklamasında güncellemenize veya değiştirmenize olanak tanır. 

Bu C++ kodu, `ChartDataWorkbook` içindeki bir serinin adını nasıl değiştireceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Bu C++ kodu, `Series` aracılığıyla bir serinin adını açıklamasında nasıl değiştireceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Veri Serisi Dolgu Rengini Ayarla**

Aspose.Slides for C++ bir plot alanı içinde grafik serileri için otomatik dolgu rengini şu şekilde ayarlamanızı sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType::ClusteredColumn` kullandık) varsayılan veriyle bir grafik ekleyin.
1. Grafik serisine erişin ve dolgu rengini Automatic olarak ayarlayın.
1. Sunumu bir PPTX dosyasına kaydedin.

Bu C++ kodu, bir grafik serisinin otomatik dolgu rengini nasıl ayarlayacağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Küme sütun grafiği oluşturur
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Seri dolgu formatını otomatik olarak ayarlar
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Sunum dosyasını diske yazar
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Veri Serisi Ters Dolgu Renklerini Ayarla**
Aspose.Slides bir plot alanı içinde grafik serileri için ters dolgu rengini şu şekilde ayarlamanızı sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType::ClusteredColumn` kullandık) varsayılan veriyle bir grafik ekleyin.
1. Grafik serisine erişin ve dolgu rengini invert olarak ayarlayın.
1. Sunumu bir PPTX dosyasına kaydedin.

Bu C++ kodu işlemi göstermektedir:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Bir Grafik Serisi İçin Ters Dolgu Rengini Ayarla**
Aspose.Slides, `IChartDataPoint::set_InvertIfNegative()` ve `ChartDataPoint.set_InvertIfNegative()` yöntemleri aracılığıyla ters ayarlamanıza izin verir. Bu yöntemlerle ters ayarlandığında, veri noktası negatif bir değer aldığında renklerini tersine çevirir. 

Bu C++ kodu işlemi göstermektedir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Belirli Veri Noktası Değerlerini Temizle**
Aspose.Slides for C++ bir grafik serisi için `DataPoints` verisini şu şekilde temizlemenizi sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeksine göre alın.
3. Bir grafiğin referansını indeksine göre alın.
4. Tüm grafik `DataPoints` öğelerini yineleyin ve `XValue` ve `YValue` değerlerini null olarak ayarlayın.
5. Belirli bir grafik serisi için tüm `DataPoints` öğelerini temizleyin.
6. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu C++ kodu işlemi göstermektedir:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Veri Serisi Boşluk Genişliğini Ayarla**
Aspose.Slides for C++ bir serinin Boşluk Genişliğini **`set_GapWidth()`** yöntemiyle şu şekilde ayarlamanızı sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan veriyle bir grafik ekleyin.
1. Herhangi bir grafik serisine erişin.
1. `GapWidth` özelliğini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu C++ kodu, bir serinin Boşluk Genişliğini nasıl ayarlayacağınızı gösterir:

```cpp
// Boş sunum oluşturur 
auto presentation = System::MakeObject<Presentation>();

// Sunumun ilk slaytına erişir
auto slide = presentation->get_Slides()->idx_get(0);

// Varsayılan veriyle bir grafik ekler
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Grafik veri sayfasının indeksini ayarlar
int32_t worksheetIndex = 0;

// Grafik veri çalışma sayfasını alır
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Serileri ekler
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Kategorileri ekler
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// İkinci grafik serisini alır
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Seri verilerini doldurur
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// GapWidth değerini ayarlar
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Sunumu diske kaydeder
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Bir grafiğin içerebileceği seri sayısı için bir sınırlama var mı?**

Aspose.Slides eklediğiniz seri sayısı için sabit bir üst sınır koymaz. Pratikteki en yüksek sayı, grafiğin okunabilirliği ve uygulamanızın sahip olduğu bellekle sınırlıdır.

**Bir küme içindeki sütunlar çok yakın ya da çok uzak olursa ne olur?**

O seri (veya üst seri grubu) için boşluk genişliği ayarını değiştirin. Değeri artırmak, sütunlar arasındaki boşluğu genişletir, azaltmak ise onları birbirine yaklaştırır.