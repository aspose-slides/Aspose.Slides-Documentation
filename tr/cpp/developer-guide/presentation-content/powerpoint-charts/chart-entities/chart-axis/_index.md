---
title: Sunumlarda С++ Kullanarak Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/cpp/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştir
- eksen manipüle et
- eksen yönet
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih formatı
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ kullanarak raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini nasıl özelleştireceğinizi keşfedin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik eksenlerini özelleştirmenin nasıl yapılacağını açıklar. Gerçek eksen değerlerini alma, eksenler arasında veri takası, çizgi grafiklerinde dikey veya yatay ekseni gizleme, kategori ekseni türünü değiştirme, kategori ekseni değerleri için tarih formatını ayarlama, eksen başlığını döndürme, eksen konumunu ayarlama ve değer ekseninde bir birim etiketi görüntüleme gibi konuları gösterir.

## **Dikey Eksende Maksimum Değerleri Almak**
Aspose.Slides for C++ size dikey bir eksende minimum ve maksimum değerleri elde etme imkanı verir. Bu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Eksen üzerindeki gerçek maksimum değeri alın.
1. Eksen üzerindeki gerçek minimum değeri alın.
1. Eksenin gerçek ana birimini alın.
1. Eksenin gerçek yan birimini alın.
1. Eksenin gerçek ana birim ölçeğini alın.
1. Eksenin gerçek yan birim ölçeğini alın.

Bu örnek kod—yukarıdaki adımların bir uygulaması—gereken değerleri C++'ta nasıl alacağınızı gösterir:

```cpp
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

## **Eksenler Arasında Veriyi Değiştir**
Aspose.Slides eksenler arasında veriyi hızlıca değiştirmenizi sağlar—dikey eksende (y-ekseninde) temsil edilen veri, yatay eksene (x-eksenine) ve tersine taşınır. 

Bu C++ kodu, bir grafikte eksenler arasında veri değişimi görevini nasıl gerçekleştireceğinizi gösterir:

```cpp
// Boş bir sunum oluşturur
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Satır ve sütunları değiştirir
chart->get_ChartData()->SwitchRowColumn();

// Sunumu kaydeder
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırak**

Bu C++ kodu, bir çizgi grafiği için dikey ekseni nasıl gizleyeceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırak**

Bu kod, bir çizgi grafiği için yatay ekseni nasıl gizleyeceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Kategori Eksenini Değiştir**

**set_CategoryAxisType()** yöntemini kullanarak tercih ettiğiniz kategori ekseni türünü (**date** veya **text**) belirtebilirsiniz. Bu C++ kodu, işlemi göstermektedir: 

```cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarla**
Aspose.Slides for C++ bir kategori ekseni değeri için tarih biçimini ayarlamanıza olanak tanır. Bu işlem, bu C++ kodunda gösterilmektedir:

```cpp
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

## **Eksen Başlığı için Döndürme Açısını Ayarla**
Aspose.Slides for C++ bir grafik eksen başlığı için döndürme açısını ayarlamanızı sağlar. Bu C++ kodu işlemi göstermektedir:

```cpp
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

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Grafik Değer Ekseninde Birim Etiketinin Görüntülenmesini Etkinleştir**
Aspose.Slides for C++ bir grafiği, değer ekseninde bir birim etiketi gösterecek şekilde yapılandırmanıza olanak tanır. Bu C++ kodu işlemi göstermektedir:

```cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir eksenin diğerini kestiği (ekseni kesişim) değeri nasıl ayarlarım?**

Eksenler bir [kesişme ayarı](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/axis/set_crosstype/) sunar: sıfırda, maksimum kategori/değerde ya da belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X eksenini yukarı ya da aşağı kaydırmak veya bir temel çizgiyi vurgulamak için faydalıdır.

**Çizgi etiketlerini eksene göre (yan tarafta, dışta, içinde) nasıl konumlandırabilirim?**

Etiket konumunu [label position](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/axis/set_majortickmark/) "cross", "outside" veya "inside" olarak ayarlayın. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.