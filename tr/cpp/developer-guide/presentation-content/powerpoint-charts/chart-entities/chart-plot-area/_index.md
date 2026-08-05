---
title: C++'ta Sunum Grafiklerinin Çizim Alanlarını Özelleştirme
linktitle: Çizim Alanı
type: docs
url: /tr/cpp/chart-plot-area/
keywords:
- grafik
- çizim alanı
- çizim alanı genişliği
- çizim alanı yüksekliği
- çizim alanı boyutu
- düzen modu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarındaki grafik çizim alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce iyileştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides’de bir grafiğin çizim alanı (plot area) ile nasıl çalışılacağını gösterir. Grafiğin düzenini doğrulayıp X, Y, genişlik ve yükseklik değerlerini okuyarak çizim alanının gerçek konum ve boyutlarını nasıl alacağınızı açıklar.

Ayrıca, düzen manuel olarak ayarlandığında çizim alanının düzen kipini nasıl yapılandıracağınızı, `LayoutTargetType` kullanarak çizim alanının iç bölgesiyle mi yoksa eksenler ve eksen etiketleriyle birlikte dış bölgesiyle mi hesaplanacağını nasıl tanımlayacağınızı gösterir.

## **Bir Grafik Çizim Alanının Genişlik ve Yüksekliğini Alın**
Aspose.Slides for C++ basit bir API sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. İlk slayta erişin.  
3. Varsayılan veriyle bir grafik ekleyin.  
4. Gerçek değerleri almak için IChart::ValidateChartLayout() metodunu çağırın.  
5. Grafik öğesinin sol üst köşesine göre gerçek X konumunu (sol) alın.  
6. Grafik öğesinin sol üst köşesine göre gerçek üst konumunu alın.  
7. Grafik öğesinin gerçek genişliğini alın.  
8. Grafik öğesinin gerçek yüksekliğini alın.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Sunumu grafik ile kaydet
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Bir Grafik Çizim Alanının Düzen Modunu Ayarlama**
Aspose.Slides for C++ grafik çizim alanının düzen modunu ayarlamak için basit bir API sağlar. **LayoutTargetType** özelliği **ChartPlotArea** ve **IChartPlotArea** sınıflarına eklenmiştir. Çizim alanının düzeni manuel olarak tanımlanmışsa bu özellik, çizim alanının iç (eksen ve eksen etiketleri dahil değil) ya da dış (eksen ve eksen etiketleri dahil) bölgeye göre düzenlenip düzenlenmeyeceğini belirtir. **LayoutTargetType** enumunda tanımlı iki olası değer vardır.

- **LayoutTargetType.Inner** – çizim alanı boyutunun, tick işaretleri ve eksen etiketleri hariç çizim alanının boyutunu belirleyeceğini belirtir.  
- **LayoutTargetType.Outer** – çizim alanı boyutunun, tick işaretleri ve eksen etiketleri dahil çizim alanının boyutunu belirleyeceğini belirtir.

Aşağıda örnek kod verilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **SSS**

**ActualX, ActualY, ActualWidth ve ActualHeight hangi birimlerde döndürülür?**

Puan (point) birimindedir; 1 inç = 72 puan. Bunlar Aspose.Slides koordinat birimleridir.

**Çizim Alanı (Plot Area) İçerik açısından Grafik Alanından (Chart Area) nasıl farklıdır?**

Çizim Alanı, veri çizim bölgesidir (seri, ızgara çizgileri, trend çizgileri vb.); Grafik Alanı ise çevre öğeleri (başlık, gösterge, vb.) içerir. 3B grafiklerde Çizim Alanı aynı zamanda duvarları/kavşakları ve eksenleri de kapsar.

**Düzen manuel olduğunda Çizim Alanının X, Y, Genişlik ve Yükseklik değerleri nasıl yorumlanır?**

Grafiğin toplam boyutunun kesirleri (0–1) olarak kabul edilir; bu kipte otomatik konumlandırma devre dışı bırakılır ve ayarladığınız kesirler kullanılır.

**Gösterge eklenip/taşındıktan sonra Çizim Alanının konumu neden değişti?**

Gösterge, Çizim Alanının dışındaki grafik alanında yer alır ancak düzeni ve kullanılabilir alanı etkiler; bu nedenle otomatik konumlandırma etkiliyken Çizim Alanı kayabilir. (Bu, PowerPoint grafiklerinde standart bir davranıştır.)