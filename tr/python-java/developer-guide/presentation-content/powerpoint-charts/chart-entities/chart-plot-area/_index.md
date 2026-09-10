---
title: Python'da Sunum Grafiklerinin Plot Alanlarını Özelleştirme
linktitle: Plot Alanı
type: docs
url: /tr/python-java/chart-plot-area/
keywords:
- grafik
- plot alanı
- plot alanı genişliği
- plot alanı yüksekliği
- plot alanı boyutu
- yerleşim modu
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarında grafik plot alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce iyileştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir grafiğin plot alanı ile nasıl çalışılacağını gösterir. Grafik yerleşimini doğrulayıp X, Y, genişlik ve yükseklik değerlerini okuyarak plot alanının gerçek konum ve boyutunu nasıl alacağınızı açıklar.

Ayrıca, yerleşim manuel olarak ayarlandığında plot alanının yerleşim modunu nasıl yapılandıracağınızı, plot alanının iç bölgeye mi yoksa eksenler ve eksen etiketleriyle birlikte dış bölgeye mi göre hesaplanacağını tanımlamak için [LayoutTargetType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layouttargettype/) kullanımını gösterir.

## **Bir Grafik Plot Alanının Genişliğini ve Yüksekliğini Almak**

Aspose.Slides for Python via Java, bir grafik plot alanının gerçek konum ve boyutunu okumak için basit bir API sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İlk slayta erişin.  
3. Varsayılan verilerle bir grafik ekleyin.  
4. Gerçek değerleri almadan önce [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#validateChartLayout) yöntemini çağırın.  
5. Grafiğin sol üst köşesine göre grafiğin gerçek X konumunu (sol) alın.  
6. Grafiğin sol üst köşesine göre grafiğin gerçek Y konumunu (üst) alın.  
7. Grafiğin gerçek genişliğini alın.  
8. Grafiğin gerçek yüksekliğini alın.  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Bir Grafik Plot Alanının Yerleşim Modunu Ayarlama**

Aspose.Slides for Python via Java, grafik plot alanının yerleşim modunu ayarlamak için basit bir API sunar. [ChartPlotArea](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/) sınıfında [setLayoutTargetType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) ve [getLayoutTargetType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) yöntemleri bulunur. Plot alanının yerleşimi manuel olarak tanımlanmışsa, bu ayar plot alanının iç (eksenler ve eksen etiketleri hariç) ya da dış (eksenler ve eksen etiketleri dahil) bölgeye göre düzenlenip düzenlenmeyeceğini belirtir. [LayoutTargetType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layouttargettype/) enumunda tanımlı iki olası değer vardır.

- [Inner](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layouttargettype/#Inner) plot alanının boyutunun tik işaretlerini ve eksen etiketlerini dışarıda bıraktığını belirtir.  
- [Outer](https://reference.aspose.com/slides/tr/python-java/aspose.slides/layouttargettype/#Outer) plot alanının boyutunun tik işaretlerini ve eksen etiketlerini içerdiğini belirtir.  

Aşağıda örnek kod verilmiştir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Gerçek X, gerçek Y, gerçek genişlik ve gerçek yükseklik hangi birimlerde döndürülür?**

Nokta (point) biriminde; 1 inç = 72 nokta. Bunlar Aspose.Slides koordinat birimleridir.

**İçerik açısından Plot Area grafik alanından nasıl farklıdır?**

Plot Area, veri çizim bölgesidir (seri, ızgara çizgileri, eğri çizgileri vb.); Chart Area çevresindeki öğeleri (başlık, lejant vb.) içerir. 3D grafiklerde Plot Area ayrıca duvarları/kavşakları ve eksenleri de kapsar.

**Yerleşim manuel olduğunda Plot Area’nın X, Y, genişlik ve yüksekliği nasıl yorumlanır?**

Bunlar grafiğin genel boyutunun (0–1) kesirleridir; bu modda otomatik konumlandırma devre dışı bırakılır ve ayarladığınız kesirler kullanılır.

**Lejant eklendikten veya taşındıktan sonra Plot Area konumu neden değişti?**

Lejant, Plot Area’nın dışındaki grafik alanında yer alır ancak yerleşimi ve kullanılabilir alanı etkiler; bu nedenle otomatik konumlandırma etkinken Plot Area kayabilir. (Bu, PowerPoint grafiklerinin standart davranışıdır.)