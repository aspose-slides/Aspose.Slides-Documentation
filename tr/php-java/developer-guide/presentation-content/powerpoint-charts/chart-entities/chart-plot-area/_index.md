---
title: PHP'de Sunum Grafiklerinin Çizim Alanlarını Özelleştirin
linktitle: Çizim Alanı
type: docs
url: /tr/php-java/chart-plot-area/
keywords:
- grafik
- çizim alanı
- çizim alanı genişliği
- çizim alanı yüksekliği
- çizim alanı boyutu
- düzen modu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarındaki grafik çizim alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce iyileştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir grafiğin plot area ile nasıl çalışılacağını gösterir. Plot area'nın gerçek konum ve boyutlarını, grafiğin düzenini doğrulayıp ardından X, Y, genişlik ve yükseklik değerlerini okuyarak almayı açıklar.

Ayrıca, düzen manuel olarak ayarlandığında plot area'nın düzen modunun nasıl yapılandırılacağını, `LayoutTargetType` kullanarak plot area'nın iç bölgeye göre mi yoksa eksenler ve eksen etiketleriyle birlikte dış bölgeye göre mi hesaplanacağını gösterir.

## **Grafik Çizim Alanının Genişliği ve Yüksekliğini Al**
Aspose.Slides for PHP via Java basit bir API sağlar.

1. Bir[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan veriyle bir grafik ekleyin.
4. Gerçek değerleri elde etmek için önceden[Chart.validateChartLayout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/validatechartlayout/) metodunu çağırın.
5. Grafik elemanının sol üst köşesine göre gerçek X konumunu (sol) alır.
6. Grafik elemanının sol üst köşesine göre gerçek üst konumunu alır.
7. Grafik elemanının gerçek genişliğini alır.
8. Grafik elemanının gerçek yüksekliğini alır.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Grafik Çizim Alanının Düzen Modunu Ayarla**
Aspose.Slides for PHP via Java, grafik çizim alanının düzen modunu ayarlamak için basit bir API sağlar. [**setLayoutTargetType**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) ve [**getLayoutTargetType**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) metodları [**ChartPlotArea**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartPlotArea) sınıfına eklenmiştir. Çizim alanının düzeni manuel olarak tanımlanmışsa, bu özellik, çizim alanının iç (eksen ve eksen etiketleri dahil değil) ya da dış (eksen ve eksen etiketleri dahil) bölgeye göre düzenlenip düzenlenmeyeceğini belirler. İki olası değer, [**LayoutTargetType**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LayoutTargetType) enumunda tanımlanmıştır.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LayoutTargetType#Inner) - çizim alanı boyutunun, çizim alanının boyutunu belirleyeceğini, işaretçileri ve eksen etiketlerini içermeyeceğini belirtir.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LayoutTargetType#Outer) - çizim alanı boyutunun, çizim alanının, işaretçilerin ve eksen etiketlerinin boyutunu belirleyeceğini belirtir.

Aşağıda örnek kod verilmiştir.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Gerçek x, gerçek y, gerçek genişlik ve gerçek yükseklik hangi birimlerde döndürülür?**

Puan (point) cinsindendir; 1 inç = 72 puan. Bunlar Aspose.Slides koordinat birimleridir.

**İçerik açısından Çizim Alanı, Grafik Alanından nasıl farklıdır?**

Çizim Alanı, veri çizim bölgesidir (seriler, ızgara çizgileri, trend çizgileri vb.); Grafik Alanı ise çevredeki öğeleri (başlık, lejand vb.) içerir. 3D grafiklerde, Çizim Alanı ayrıca duvarları/kafesi ve eksenleri de kapsar.

**Düzen manuel olduğunda Çizim Alanının x, y, genişlik ve yüksekliği nasıl yorumlanır?**

Bunlar, grafiğin genel boyutunun kesirleridir (0–1); bu modda otomatik konumlandırma devre dışı bırakılır ve ayarladığınız kesirler kullanılır.

**Lejand eklenip/taşındıktan sonra Çizim Alanının konumu neden değişti?**

Lejand, Çizim Alanının dışında grafik alanında yer alır ancak düzeni ve kullanılabilir alanı etkiler, bu nedenle otomatik konumlandırma etkin olduğunda Çizim Alanı kayabilir. (Bu, PowerPoint grafiklerinin standart davranışıdır.)