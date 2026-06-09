---
title: JavaScript ile Sunum Grafiklerinin Çizim Alanlarını Özelleştirme
linktitle: Çizim Alanı
type: docs
url: /tr/nodejs-java/chart-plot-area/
keywords:
- grafik
- çizim alanı
- çizim alanı genişliği
- çizim alanı yüksekliği
- çizim alanı boyutu
- düzen modu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak PowerPoint sunumlarındaki grafik çizim alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir grafiğin çizim alanıyla (plot area) nasıl çalışılacağını gösterir. Grafiğin düzenini doğrulayarak ve ardından X, Y, genişlik ve yükseklik değerlerini okuyarak çizim alanının gerçek konum ve boyutunu nasıl alacağınızı açıklar.

Ayrıca, düzen manuel olarak ayarlandığında `LayoutTargetType` kullanarak çizim alanının iç bölgesi mi yoksa eksenler ve eksen etiketleriyle birlikte dış bölgesi mi üzerinden hesaplanacağını tanımlayarak çizim alanının düzen modunu nasıl yapılandıracağınızı gösterir.

## **Grafik Çizim Alanının Genişlik ve Yüksekliğini Alma**

Aspose.Slides for Node.js via Java, basit bir API sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Gerçek değerleri almak için [Chart.validateChartLayout()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart#validateChartLayout--) metodunu çağırın.
1. Grafiğin sol üst köşesine göre grafik öğesinin gerçek X konumunu (sol) alın.
1. Grafiğin sol üst köşesine göre grafik öğesinin gerçek üst konumunu alın.
1. Grafik öğesinin gerçek genişliğini alın.
1. Grafik öğesinin gerçek yüksekliğini alın.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafik Çizim Alanının Düzen Modunu Ayarlama**

Aspose.Slides for Node.js via Java, grafik çizim alanının düzen modunu ayarlamak için basit bir API sağlar. [**ChartPlotArea**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartPlotArea) sınıfına [**setLayoutTargetType**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) ve [**getLayoutTargetType**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) metodları eklenmiştir. Çizim alanının düzeni manuel olarak tanımlanmışsa, bu özellik, çizim alanının iç bölgesi (ekseni ve eksen etiketlerini içermeyen) mi yoksa dış bölgesi (ekseni ve eksen etiketlerini içeren) mi kullanılacağını belirtir. İki olası değer, [**LayoutTargetType**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/LayoutTargetType) enum'unda tanımlanmıştır.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/LayoutTargetType#Inner) - Çizim alanı boyutunun, tik işaretleri ve eksen etiketleri dışında, yalnızca çizim alanı boyutunu belirleyeceğini belirtir.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/LayoutTargetType#Outer) - Çizim alanı boyutunun, tik işaretleri ve eksen etiketleri dahil olmak üzere, çizim alanı boyutunu belirleyeceğini belirtir.

Aşağıda örnek kod verilmiştir.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Gerçek X, gerçek Y, gerçek Genişlik ve gerçek Yükseklik hangi birimlerde döndürülür?**

Puan (points) biriminde; 1 inç = 72 puan. Bunlar Aspose.Slides koordinat birimleridir.

**Çizim Alanı, İçerik açısından Grafik Alanından nasıl farklıdır?**

Çizim Alanı, veri çizim bölgesidir (seriler, ızgara çizgileri, eğri çizgileri vb.); Grafik Alanı ise çevresel öğeleri (başlık, lejand vb.) içerir. 3B grafiklerde Çizim Alanı ayrıca duvarları/kafesi ve eksenleri kapsar.

**Düzen manuel olduğunda Çizim Alanının X, Y, Genişlik ve Yükseklik değerleri nasıl yorumlanır?**

Grafiğin genel boyutunun kesirleri (0–1) olarak değerlendirilir; bu modda otomatik konumlandırma devre dışı bırakılır ve ayarladığınız kesirler kullanılır.

**Lejant eklendikten/taşındıktan sonra Çizim Alanının konumu neden değişti?**

Lejant, Çizim Alanının dışında grafik alanında yer alır ancak düzeni ve kullanılabilir alanı etkiler; bu nedenle otomatik konumlandırma etkinse Çizim Alanı kayabilir. (Bu, PowerPoint grafiklerinde standart bir davranıştır.)