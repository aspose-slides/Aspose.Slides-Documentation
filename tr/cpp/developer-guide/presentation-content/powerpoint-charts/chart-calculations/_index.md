---
title: Sunumlarda C++ ile Grafik Hesaplamalarını Optimize Etme
linktitle: Grafik Hesaplamaları
type: docs
weight: 50
url: /tr/cpp/chart-calculations/
keywords:
- grafik hesaplamaları
- grafik öğeleri
- öğe konumu
- gerçek konum
- alt öğe
- üst öğe
- grafik değerleri
- gerçek değer
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'de PPT ve PPTX için grafik hesaplamalarını, veri güncellemelerini ve hassasiyet kontrolünü anlayın, pratik C++ kod örnekleriyle."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda grafik hesaplamaları ve düzen verileriyle çalışmak için API'ler sağlar. Bu makale, `IActualLayout` arayüzünü uygulayan öğelerin gerçek konumu ve boyutu ile grafik eksenlerinin gerçek değerleri dahil olmak üzere grafik öğelerinin gerçek değerlerini nasıl alacağınızı gösterir. Ayrıca bu değerlerin grafik düzen doğrulamasından sonra doldurulduğunu açıklar.

Ek olarak, makale üst grafik öğelerinin gerçek konumunu nasıl alacağınızı ve başlık, eksenler, lejand ve ızgara çizgileri gibi grafik bileşenlerini nasıl gizleyeceğinizi gösterir. Bu örnekler, grafik düzen bilgilerini incelemenize ve PowerPoint sunumlarında grafik öğelerinin görünürlüğünü programlı olarak kontrol etmenize yardımcı olur.

## **Grafik Öğelerinin Gerçek Değerlerini Hesapla**
Aspose.Slides for C++ bu özellikleri almak için basit bir API sağlar. Bu, grafik öğelerinin gerçek değerlerini hesaplamanıza yardımcı olacaktır. Gerçek değerler, IActualLayout arayüzünü uygulayan öğelerin konumunu (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) ve gerçek eksen değerlerini (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()) içerir.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Sunumu kaydet
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Üst Grafik Öğelerinin Gerçek Konumunu Hesapla**
Aspose.Slides for C++ bu özellikleri almak için basit bir API sağlar. IActualLayout yöntemleri, üst grafik öğesinin gerçek konumu hakkında bilgi verir. Özelliklerin gerçek değerlerle doldurulması için önce IChart::ValidateChartLayout() yönteminin çağrılması gerekir.

``` cpp
// Boş sunum oluşturma
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Grafik Öğelerini Gizle**
Bu konu, grafikten bilgiyi nasıl gizleyeceğinizi anlamanıza yardımcı olur. Aspose.Slides for C++ kullanarak grafikten **Başlığı, Dikey Eksen, Yatay Eksen** ve **Izgara Çizgilerini** gizleyebilirsiniz. Aşağıdaki kod örneği bu özelliklerin nasıl kullanılacağını gösterir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Bir Grafik İçin Veri Aralığını Ayarla**
Aspose.Slides for C++, grafik için veri aralığını en kolay şekilde ayarlamak için en basit API'yi sağlamıştır. Grafik için veri aralığını ayarlamak:

- Grafiği içeren Presentation sınıfının bir örneğini açın.
- Kaydırmanın indeksini kullanarak bir slayt referansı alın.
- İstenen grafiği bulmak için tüm şekillerde gezin.
- Grafik verilerine erişin ve aralığı ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod örnekleri bir grafiği nasıl güncelleyeceğinizi gösterir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **SSS**

**Harici Excel çalışma kitapları veri kaynağı olarak çalışıyor mu ve bu yeniden hesaplamayı nasıl etkiler?**

Evet. Bir grafik harici bir çalışma kitabına referans verebilir: harici kaynağa bağlandığınızda veya yenilediğinizde, formüller ve değerler o çalışma kitabından alınır ve grafik, açma/düzenleme işlemleri sırasında güncellemeleri yansıtır. API, harici çalışma kitabının yolunu [belirtmenizi](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) ve bağlanmış verileri yönetmenizi sağlar.

**Regresyonu kendim uygulamadan eğilim çizgilerini hesaplayıp görüntüleyebilir miyim?**

Evet. [Trendlines](/slides/tr/cpp/trend-line/) (lineer, üstel ve diğerleri) Aspose.Slides tarafından eklenir ve güncellenir; parametreleri seri verilerinden otomatik olarak yeniden hesaplanır, böylece kendi hesaplamalarınızı uygulamanıza gerek kalmaz.

**Bir sunumda birden fazla grafik harici bağlantılara sahipse, her bir grafiğin hesaplanan değerler için hangi çalışma kitabını kullandığını kontrol edebilir miyim?**

Evet. Her bir grafik, kendi [harici çalışma kitabına](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) işaret edebilir veya diğerlerinden bağımsız olarak grafik başına bir harici çalışma kitabı oluşturup/yerine koyabilirsiniz.