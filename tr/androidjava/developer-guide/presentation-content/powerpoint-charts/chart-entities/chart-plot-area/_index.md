---
title: Android'de Sunum Grafiklerinin Çizim Alanlarını Özelleştirme
linktitle: Çizim Alanı
type: docs
url: /tr/androidjava/chart-plot-area/
keywords:
- grafik
- çizim alanı
- çizim alanı genişliği
- çizim alanı yüksekliği
- çizim alanı boyutu
- düzen modu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint sunumlarındaki grafik çizim alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce iyileştirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'ta bir grafiğin çizim alanı ile nasıl çalışılacağını gösterir. Çizim alanının gerçek konum ve boyutunu grafik düzenini doğrulayıp ardından X, Y, genişlik ve yükseklik değerlerini okuyarak nasıl alacağınızı açıklar.

Ayrıca, düzen manuel olarak ayarlandığında çizim alanının düzen modunun nasıl yapılandırılacağını, `LayoutTargetType` kullanarak çizim alanının iç bölgesiyle mi yoksa eksenler ve eksen etiketleriyle birlikte dış bölgesiyle mi hesaplanacağını gösterir.

## **Çizim Alanının Genişlik ve Yüksekliğini Alma**
Aspose.Slides for Android via Java basit bir API sağlar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Gerçek değerleri almak için önce [IChart.validateChartLayout()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChart#validateChartLayout--) metodunu çağırın.
1. Grafik öğesinin sol üst köşeye göre gerçek X konumunu (sol) alır.
1. Grafik öğesinin sol üst köşeye göre gerçek üst konumunu alır.
1. Grafik öğesinin gerçek genişliğini alır.
1. Grafik öğesinin gerçek yüksekliğini alır.

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
Aspose.Slides for Android via Java, grafik çizim alanının düzen modunu ayarlamak için basit bir API sağlar. [**setLayoutTargetType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) ve [**getLayoutTargetType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) metotları [**ChartPlotArea**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartPlotArea) sınıfına ve [**IChartPlotArea**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartPlotArea) arayüzüne eklenmiştir. Çizim alanının düzeni manuel olarak tanımlanmışsa bu özellik, çizim alanının iç (eksen ve eksen etiketleri hariç) ya da dış (eksen ve eksen etiketleri dahil) bölümüyle mi düzenleneceğini belirler. İki olası değer, [**LayoutTargetType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LayoutTargetType) enum'ında tanımlanmıştır.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LayoutTargetType#Inner) – çizim alanı boyutunun, tik işaretleri ve eksen etiketleri dahil olmadan çizim alanının boyutunu belirleyeceğini belirtir.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LayoutTargetType#Outer) – çizim alanı boyutunun, çizim alanının, tik işaretlerinin ve eksen etiketlerinin boyutunu belirleyeceğini belirtir.

Aşağıda örnek kod verilmiştir.

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
Puan cinsindendir; 1 inç = 72 puandır. Bunlar Aspose.Slides koordinat birimleridir.

**İçerik açısından Çizim Alanı, Grafik Alanından nasıl farklıdır?**  
Çizim Alanı, veri çizim bölgesidir (seri, ızgara çizgileri, trend çizgileri vb.); Grafik Alanı çevresindeki öğeleri (başlık, lejand vb.) içerir. 3D grafiklerde Çizim Alanı ayrıca duvarları/kavşakları ve eksenleri de kapsar.

**Düzen manuel olduğunda Çizim Alanının x, y, genişlik ve yüksekliği nasıl yorumlanır?**  
Grafiğin genel boyutunun kesirleri (0–1) olarak değerlendirilir; bu modda otomatik konumlandırma devre dışı bırakılır ve belirlediğiniz kesirler kullanılır.

**Lejand eklenip/taşındıktan sonra Çizim Alanının konumu neden değişti?**  
Lejand, Çizim Alanı dışında grafik alanında yer alır ancak düzeni ve kullanılabilir alanı etkiler, bu nedenle otomatik konumlandırma etkili olduğunda Çizim Alanı kayabilir. (Bu, PowerPoint grafiklerinde standart bir davranıştır.)