---
title: "Java'da Sunum Grafiklerinin Çizim Alanlarını Özelleştirme"
linktitle: "Çizim Alanı"
type: docs
url: /tr/java/chart-plot-area/
keywords:
- grafik
- çizim alanı
- çizim alanı genişliği
- çizim alanı yüksekliği
- çizim alanı boyutu
- düzen modu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarındaki grafik çizim alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce iyileştirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te bir grafiğin çizim alanıyla (plot area) nasıl çalışılacağını gösterir. Grafiğin düzenini doğrulayıp ardından X, Y, genişlik ve yükseklik değerlerini okuyarak çizim alanının gerçek konum ve boyutunu almayı açıklar.

Ayrıca, düzen manuel olarak ayarlandığında çizim alanının düzenleme modunu nasıl yapılandıracağınızı, `LayoutTargetType` kullanarak çizim alanının iç bölgesiyle mi yoksa eksenler ve eksen etiketleri dahil dış bölgesiyle mi hesaplanacağını tanımlamayı gösterir.

## **Bir Grafik Çizim Alanının Genişlik ve Yüksekliğini Almak**
Aspose.Slides for Java basit bir API sağlar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan verilerle bir grafik ekleyin.
4. Gerçek değerleri almadan önce [IChart.validateChartLayout()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChart#validateChartLayout--) metodunu çağırarak grafiğin düzenini doğrulayın.
5. Grafik öğesinin sol üst köşesine göre gerçek X konumunu (sol) alın.
6. Grafik öğesinin sol üst köşesine göre gerçek üst konumunu alın.
7. Grafik öğesinin gerçek genişliğini alın.
8. Grafik öğesinin gerçek yüksekliğini alın.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Grafik Çizim Alanının Düzen Modunu Ayarlama**
Aspose.Slides for Java, grafik çizim alanının düzen modunu ayarlamak için basit bir API sağlar. Metodlar [**setLayoutTargetType**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) ve [**getLayoutTargetType**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) [**ChartPlotArea**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ChartPlotArea) sınıfına ve [**IChartPlotArea**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartPlotArea) arabirimine eklenmiştir. Çizim alanının düzeni manuel olarak tanımlanmışsa bu özellik, çizim alanının iç (eksen ve eksen etiketleri dahil olmadan) veya dış (eksen ve eksen etiketleri dahil) olarak düzenlenip düzenlenmeyeceğini belirtir. İki olası değer [**LayoutTargetType**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LayoutTargetType) enum'unda tanımlanmıştır.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LayoutTargetType#Inner) - çizim alanı boyutunun, tik işaretleri ve eksen etiketleri dahil edilmeden, çizim alanının boyutunu belirleyeceğini belirtir.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LayoutTargetType#Outer) - çizim alanı boyutunun, tik işaretleri ve eksen etiketleri dahil edilerek, çizim alanının boyutunu belirleyeceğini belirtir.

Örnek kod aşağıda verilmiştir.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Gerçek x, gerçek y, gerçek genişlik ve gerçek yükseklik hangi birimlerde döndürülür?**

Nokta biriminde; 1 inç = 72 nokta. Bunlar Aspose.Slides koordinat birimleridir.

**Plot Area (çizim alanı) içeriği açısından Chart Area'dan (grafik alanı) nasıl farklıdır?**

Plot Area, veri çizim bölgesidir (seri, ızgara çizgileri, trend çizgileri vb.); Chart Area ise çevresel öğeleri içerir (başlık, lejant vb.). 3D grafiklerde Plot Area ayrıca duvarları/kabulü ve eksenleri de kapsar.

**Düzen manuel olduğunda Plot Area’nın x, y, genişlik ve yükseklik nasıl yorumlanır?**

Bunlar, grafiğin genel boyutunun (0–1) kesirleri olarak değerlendirilir; bu modda otomatik konumlandırma devre dışı bırakılır ve ayarladığınız kesirler kullanılır.

**Lejant eklendikten/taşındıktan sonra Plot Area konumu neden değişti?**

Lejant, Plot Area dışındaki grafik alanında bulunur ancak düzeni ve kullanılabilir alanı etkiler, bu yüzden otomatik konumlandırma etkin olduğunda Plot Area kayabilir. (Bu, PowerPoint grafikleri için standart bir davranıştır.)