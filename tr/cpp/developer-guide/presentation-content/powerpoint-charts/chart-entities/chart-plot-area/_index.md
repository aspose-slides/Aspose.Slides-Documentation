---
title: С++ Sunum Grafiklerinin Çizim Alanlarını Özelleştirme
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
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ ile PowerPoint sunumlarındaki grafik çizim alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te bir grafiğin çizim alanı (plot area) ile nasıl çalışılacağını gösterir. Grafiğin düzenini doğrulayıp X, Y, genişlik ve yükseklik değerlerini okuyarak çizim alanının gerçek konum ve boyutunu elde etmeyi açıklar.

Ayrıca, düzen manuel olarak ayarlandığında çizim alanının düzenleme modunu nasıl yapılandıracağınızı, çizim alanının iç bölgesi mi yoksa eksenler ve eksen etiketleriyle birlikte dış bölgesi mi kullanılacağını belirlemek için `LayoutTargetType` kullanarak gösterir.

## **Bir Grafik Çizim Alanının Genişlik ve Yüksekliğini Alma**
Aspose.Slides for C++ basit bir API sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan veri ile bir grafik ekleyin.
4. Gerçek değerleri almak için IChart::ValidateChartLayout() metodunu çağırın.
5. Grafik elemanının sol üst köşeye göre gerçek X konumunu (sol) alın.
6. Grafik elemanının sol üst köşeye göre gerçek üst konumunu alın.
7. Grafik elemanının gerçek genişliğini alın.
8. Grafik elemanının gerçek yüksekliğini alın.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Grafiği içeren sunumu kaydet
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Bir Grafik Çizim Alanının Düzen Modunu Ayarlama**
Aspose.Slides for C++ grafik çizim alanının düzen modunu ayarlamak için basit bir API sağlar. **LayoutTargetType** özelliği **ChartPlotArea** ve **IChartPlotArea** sınıflarına eklenmiştir. Çizim alanının düzeni manuel olarak tanımlanmışsa bu özellik, çizim alanının iç (eksen ve eksen etiketleri dahil olmadan) veya dış (eksen ve eksen etiketleri dahil) bölgeye göre düzenlenip düzenlenmeyeceğini belirtir. **LayoutTargetType** enum'unda tanımlı iki olası değer vardır.

- **LayoutTargetType.Inner** – çizim alanının boyutunun, işaretçileri ve eksen etiketlerini içermeyen çizim alanı boyutunu belirleyeceğini belirtir.
- **LayoutTargetType.Outer** – çizim alanının boyutunun, işaretçileri ve eksen etiketlerini de içeren çizim alanı boyutunu belirleyeceğini belirtir.

Aşağıda örnek kod verilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **SSS**

**ActualX, ActualY, ActualWidth ve ActualHeight hangi birimlerde döndürülür?**

Puan cinsinden; 1 inç = 72 puan. Bunlar Aspose.Slides koordinat birimleridir.

**Plot Area ile Chart Area içerik bakımından nasıl farklılık gösterir?**

Plot Area, veri çizim bölgesidir (seri, ızgara çizgileri, trend çizgileri vb.); Chart Area ise çevredeki öğeleri (başlık, lejand vb.) içerir. 3B grafiklerde Plot Area ayrıca duvarları/kıtayı ve eksenleri de kapsar.

**Düzen manuel olduğunda Plot Area’nın X, Y, Width ve Height değerleri nasıl yorumlanır?**

Grafiğin toplam boyutunun kesirleri (0–1) olarak alınır; bu modda otomatik konumlandırma devre dışı bırakılır ve belirlediğiniz kesirler kullanılır.

**Lejand eklenip/taşındıktan sonra Plot Area konumu neden değişti?**

Lejand, Plot Area’nın dışında grafik alanında yer alır ancak düzeni ve kullanılabilir alanı etkiler, bu yüzden otomatik konumlandırma etkili olduğunda Plot Area kayabilir. (Bu, PowerPoint grafiklerinin standart davranışıdır.)