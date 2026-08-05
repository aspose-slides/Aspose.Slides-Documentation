---
title: C++ Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/cpp/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- ekseni özelleştir
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih formatı
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek üzere Aspose.Slides for C++ nasıl kullanılacağını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini almayı, eksenler arasında veri takas etmeyi, çizgi grafiklerinde dikey veya yatay ekseni gizlemeyi, kategori eksen türünü değiştirmeyi, kategori eksen değerleri için tarih formatını ayarlamayı, bir eksen başlığını döndürmeyi, eksen konumunu ayarlamayı ve değer ekseninde bir birim etiketi göstermeyi gösterir.

## **Dikey Eksen Üzerindeki Azami Değerleri Al**

Aspose.Slides for C++ dikey bir eksende minimum ve maksimum değerleri elde etmenizi sağlar. Bu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan veri ile bir grafik ekleyin.
4. Eksen üzerindeki gerçek maksimum değeri alın.
5. Eksen üzerindeki gerçek minimum değeri alın.
6. Eksenin gerçek büyük birimini alın.
7. Eksenin gerçek küçük birimini alın.
8. Eksenin gerçek büyük birim ölçeğini alın.
9. Eksenin gerçek küçük birim ölçeğini alın.

Bu örnek kod—yukarıdaki adımların bir uygulaması—gerekli değerleri C++'ta nasıl alacağınızı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Sunumu kaydeder
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Eksenler Arasındaki Veriyi Değiştir**

Aspose.Slides, eksenler arasındaki veriyi hızlıca takas etmenizi sağlar—dikey eksende (y-ekseni) temsil edilen veri, yatay eksene (x-ekseni) ve tersine taşınır. 

Bu C++ kodu, bir grafikte eksenler arasındaki veri takasını nasıl yapacağınızı gösterir:

``` cpp
// Boş sunum oluşturur
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Satır ve sütunları değiştirir
chart->get_ChartData()->SwitchRowColumn();

// Sunumu kaydeder
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Çizgi Grafiklerinde Dikey Ekseni Devre Dışı Bırak**

Bu C++ kodu, bir çizgi grafiğinde dikey ekseni nasıl gizleyeceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Çizgi Grafiklerinde Yatay Ekseni Devre Dışı Bırak**

Bu kod, bir çizgi grafiğinde yatay ekseni nasıl gizleyeceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Bir Kategori Eksenini Değiştir**

**set_CategoryAxisType()** metodunu kullanarak tercih ettiğiniz kategori eksen türünü (**date** veya **text**) belirtebilirsiniz. Bu C++ kodu işlemi gösterir: 

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Kategori Eksen Değerleri İçin Tarih Formatını Ayarla**

Aspose.Slides for C++ bir kategori eksen değeri için tarih formatı ayarlamanıza izin verir. Bu işlem bu C++ kodunda gösterilmiştir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Bir Eksen Başlığı İçin Dönme Açısını Ayarla**

Aspose.Slides for C++ bir grafik eksen başlığı için dönme açısını ayarlamanıza izin verir. Bu C++ kodu işlemi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarla**

Aspose.Slides for C++ bir kategori veya değer ekseninde eksen konumunu ayarlamanıza izin verir. Bu C++ kodu görevi nasıl yerine getireceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Grafik Değer Ekseninde Birim Etiketini Görüntülemeyi Etkinleştir**

Aspose.Slides for C++ bir grafiği, değer ekseninde bir birim etiketi gösterecek şekilde yapılandırmanıza izin verir. Bu C++ kodu işlemi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişimini) nasıl ayarlarım?**

Eksenler bir [kesişme ayarı](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/axis/set_crosstype/) sağlar: sıfırda, maksimum kategori/değerde veya belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X-ekseni yukarı veya aşağı kaydırmak ya da bir temel çizgiyi vurgulamak için faydalıdır.

**Ölçüm etiketlerini eksene göre nasıl konumlandırabilirim (yan yana, dışarı, içeride)?**

[label position](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/axis/set_majortickmark/) ayarını "cross", "outside" veya "inside" olarak belirleyin. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.