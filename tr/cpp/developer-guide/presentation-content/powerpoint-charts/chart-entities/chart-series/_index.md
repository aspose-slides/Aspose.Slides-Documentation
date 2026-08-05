---
title: C++ ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serisi
type: docs
url: /tr/cpp/chart-series/
keywords:
- grafik serisi
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
description: "PowerPoint (PPT/PPTX) için C++'da grafik serilerini nasıl yöneteceğinizi, pratik kod örnekleri ve veri sunumlarınızı geliştirmek için en iyi uygulamalarla öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde [ChartSeries](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartseries/) rolünü, verilerin sunumlarda nasıl yapılandırıldığını ve görselleştirildiğini açıklamaktadır. Bu nesneler, bir grafikte ayrı veri noktaları, kategoriler ve görünüm parametreleri tanımlayan temel öğeleri sağlar. [ChartSeries](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartseries/) ile çalışarak geliştiriciler, temel veri kaynaklarını sorunsuz bir şekilde entegre edebilir ve bilgilerin nasıl gösterileceği üzerinde tam kontrol sağlayabilir; böylece içgörü ve analizi net bir şekilde ileten dinamik, veri odaklı sunumlar oluşturabilir.

Bir seri, bir grafikte çizilen sayıların satırı veya sütunudur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Veri Serisi Örtüşmesini Ayarla**

[IChartSeries::get_Overlap()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) yöntemi ile 2D bir grafikte çubukların ve sütunların ne kadar örtüşeceğini (aralık: -100 ila 100) belirtebilirsiniz. Bu özellik, üst serisi grubunun tüm serilerine uygulanır: bu, ilgili grup özelliğinin bir yansımasıdır.

`get_ParentSeriesGroup()::set_Overlap()` yöntemini kullanarak `Overlap` için istediğiniz değeri ayarlayın. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.
1. Bir slayta kümeleme sütun grafiği ekleyin.
1. İlk grafik serisine erişin.
1. Grafik serisinin `ParentSeriesGroup` özelliğine erişin ve serinin tercih ettiğiniz örtüşme değerini ayarlayın. 
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu C++ kodu, bir grafik serisinin örtüşmesini nasıl ayarlayacağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Seri örtüşmesini ayarlar
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Sunum dosyasını diske yazar
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Veri Serisi Rengini Değiştir**

Aspose.Slides for C++ bir serinin rengini şu şekilde değiştirmenize olanak tanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.
1. Slayta bir grafik ekleyin.
1. Rengini değiştirmek istediğiniz seriye erişin. 
1. Tercih ettiğiniz dolgu tipini ve dolgu rengini ayarlayın.
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

## **Bir Veri Serisi Kategorisinin Rengini Değiştir**

Aspose.Slides for C++ bir serinin kategorisinin rengini şu şekilde değiştirmenize olanak tanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.
1. Slayta bir grafik ekleyin.
1. Rengini değiştirmek istediğiniz seri kategorisine erişin.
1. Tercih ettiğiniz dolgu tipini ve dolgu rengini ayarlayın.
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

Varsayılan olarak, bir grafiğin lejand adları her sütun veya satırın üzerindeki hücrelerin içeriğidir. 

Örnek görüntümüzde, 

* sütunlar *Series 1, Series 2,* ve *Series 3*;  
* satırlar *Category 1, Category 2, Category 3,* ve *Category 4* olarak adlandırılmıştır. 

Aspose.Slides for C++ serinin adını grafik verisinde ve lejandında güncellemenize veya değiştirmenize olanak tanır. 

Bu C++ kodu, `ChartDataWorkbook` içinde bir serinin adını nasıl değiştireceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Bu C++ kodu, `Series` aracılığıyla lejand içindeki bir serinin adını nasıl değiştireceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Veri Serisi Dolgu Rengini Ayarla**

Aspose.Slides for C++ grafik serileri için otomatik dolgu rengini grafik alanı içinde şu şekilde ayarlamanıza olanak tanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.
1. İndeksiyle bir slayt referansı alın.
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType::ClusteredColumn` kullandık) varsayılan verilerle bir grafik ekleyin.
1. Grafik serisine erişin ve dolgu rengini Automatic olarak ayarlayın.
1. Sunumu bir PPTX dosyasına kaydedin.

Bu C++ kodu, bir grafik serisinin otomatik dolgu rengini nasıl ayarlayacağınızı gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Kümelenmiş sütun grafiği oluşturur
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Seri dolgu biçimini otomatik olarak ayarlar
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Sunum dosyasını diske yazar
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Veri Serisi Ters Dolgu Renklerini Ayarla**

Aspose.Slides grafik serileri için ters dolgu rengini grafik alanı içinde şu şekilde ayarlamanıza olanak tanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.
1. İndeksiyle bir slayt referansı alın.
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType::ClusteredColumn` kullandık) varsayılan verilerle bir grafik ekleyin.
1. Grafik serisine erişin ve dolgu rengini invert (ters) olarak ayarlayın.
1. Sunumu bir PPTX dosyasına kaydedin.

Bu C++ kodu işlemi gösterir:

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

Aspose.Slides `IChartDataPoint::set_InvertIfNegative()` ve `ChartDataPoint.set_InvertIfNegative()` yöntemleri aracılığıyla ters ayarları yapmanıza izin verir. Bu yöntemlerle bir ters ayar yapıldığında, veri noktası negatif bir değer aldığında renkleri tersine döner. 

Bu C++ kodu işlemi gösterir:

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

Aspose.Slides for C++ belirli bir grafik serisi için `DataPoints` verilerini şu şekilde temizlemenize olanak tanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.
2. İndeksiyle bir slayt referansı alın.
3. İndeksiyle bir grafik referansı alın.
4. Tüm grafik `DataPoints` öğelerini döngüye alıp `XValue` ve `YValue` değerlerini null olarak ayarlayın.
5. Belirli grafik serisi için tüm `DataPoints` öğelerini temizleyin.
6. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu C++ kodu işlemi gösterir:

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

Aspose.Slides for C++ bir serinin Boşluk Genişliğini **`set_GapWidth()`** yöntemi aracılığıyla şu şekilde ayarlamanıza olanak tanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. İstediğiniz bir grafik serisine erişin.
1. `GapWidth` özelliğini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu C++ kodu, bir serinin Boşluk Genişliğini nasıl ayarlayacağınızı gösterir:

```cpp
// Boş sunum oluşturur 
auto presentation = System::MakeObject<Presentation>();

// Sunumun ilk slaytına erişir
auto slide = presentation->get_Slides()->idx_get(0);

// Varsayılan verilerle bir grafik ekler
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Grafik veri sayfasının indeksini ayarlar
int32_t worksheetIndex = 0;

// Grafik veri çalışma sayfasını alır
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Seriler ekler
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Kategoriler ekler
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

## **SSS**

**Tek bir grafiğin içerebileceği seri sayısında bir sınır var mı?**  
Aspose.Slides eklediğiniz seri sayısı için sabit bir üst limit koymaz. Pratik sınır, grafiğin okunabilirliği ve uygulamanızın kullandığı bellek miktarıyla belirlenir.

**Küme içindeki sütunlar çok yakın veya çok uzak olduğunda ne yapılmalı?**  
İlgili serinin (veya üst serisi grubunun) boşluk genişliği ayarını değiştirin. Değeri artırmak sütunlar arasındaki boşluğu genişletirken, azaltmak onları birbirine yaklaştırır.