---
title: Python via Java kullanarak Sunumlarda Doughnut Grafiklerini Özelleştirme
linktitle: Doughnut Grafik
type: docs
weight: 30
url: /tr/python-java/doughnut-chart/
keywords:
- doughnut grafik
- merkez boşluğu
- delik boyutu
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da dinamik sunumlar için PowerPoint formatlarını destekleyen doughnut grafiklerini oluşturmayı ve özelleştirmeyi keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta bir doughnut grafiği ile çalışmayı, grafiği bir slayta eklemeyi, merkez boşluğunun boyutunu ayarlamayı ve sunumu kaydetmeyi gösterir. [setDoughnutHoleSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) yöntemine odaklanır ve bu grafik türünü kod içinde özelleştirmek için gerekli temel adımları gösterir.

Ayrıca, birden fazla serinin birden çok halka oluşturmak için kullanılması, exploded doughnut grafikler ile çalışılması ve bir grafiğin raster görüntüsü veya SVG olarak dışa aktarılması gibi ilgili doughnut‑grafik senaryolarını kapsayan kısa bir SSS içerir.

## **Doughnut Grafiğinde Merkez Boşluğunu Belirleme**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java, bir doughnut grafiğindeki boşluğun boyutunu belirlemeyi destekler. Bu bölüm, bir örnekle boşluk boyutunun nasıl belirtileceğini gösterir.
{{% /alert %}}

Bir doughnut grafiğindeki boşluğun boyutunu belirlemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturun.  
1. Slayta bir doughnut grafik ekleyin.  
1. Doughnut grafiğindeki boşluğun boyutunu belirleyin.  
1. Sunumu diske yazın.  

Aşağıdaki örnek, bir doughnut grafiğindeki boşluğun boyutunu ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

    # Presentation sınıfının bir örneğini oluşturun.
    presentation = Presentation()
    try:
        chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
        chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

        # Sunumu diske yazın.
        presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **SSS**

**Çok katmanlı bir doughnut, birden fazla halka ile oluşturabilir miyim?**

Evet. Tek bir doughnut grafiğine birden çok seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyondaki sırasına göre belirlenir.

**"Patlamış" bir doughnut (ayırılmış dilimler) destekleniyor mu?**

Evet. Exploded Doughnut [grafik türü](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/) ve veri noktaları üzerinde bir patlama özelliği vardır; bireysel dilimleri ayırabilirsiniz.

**Rapor için bir doughnut grafiğinin (PNG/SVG) görüntüsünü nasıl alabilirim?**

Bir grafik bir [shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/)dır; onu bir [raster image](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) olarak render edebilir veya grafiği bir SVG görüntüsü olarak dışa aktarabilirsiniz.