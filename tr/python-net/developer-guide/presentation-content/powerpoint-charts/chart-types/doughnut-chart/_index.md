---
title: Python ile Sunumlarda Halka Grafiklerini Özelleştirme
linktitle: Halka Grafik
type: docs
weight: 30
url: /tr/python-net/doughnut-chart/
keywords:
- halka grafik
- merkez boşluğu
- delik boyutu
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak halka grafiklerini nasıl oluşturup özelleştirebileceğinizi keşfedin; PowerPoint ve OpenDocument formatlarını destekleyerek dinamik sunumlar oluşturun."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te bir halka grafik ile nasıl çalışılacağını, grafiği bir slayta ekleyerek, merkezindeki deliğin boyutunu ayarlayarak ve sunumu kaydederek gösterir. `doughnut_hole_size` ayarına odaklanır ve bu grafik türünü kod içinde özelleştirmek için gereken temel adımları gösterir.

Ayrıca çoklu seriler kullanarak birden çok halka oluşturma, patlamış halka grafikler üzerinde çalışma ve grafiği raster görüntü ya da SVG olarak dışa aktarma gibi ilgili halka grafik senaryolarını kapsayan kısa bir SSS içerir.

## **Halka Grafiğinde Merkez Boşluğunu Belirleme**
Halka grafiğindeki deliğin boyutunu belirlemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfını örnekleyin.
- Slayta halka grafik ekleyin.
- Halka grafiğindeki deliğin boyutunu belirtin.
- Sunumu diske yazın.

Aşağıdaki örnekte halka grafiğindeki deliğin boyutunu ayarladık.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Sunumu diske kaydet
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Birden fazla halka içeren çok seviyeli bir halka grafiği oluşturabilir miyim?**

Evet. Tek bir halka grafiğine birden fazla seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyondaki sırasına göre belirlenir.

**"Patlamış" bir halka (ayrılmış dilimler) destekleniyor mu?**

Evet. Patlamış Halka [chart type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/) ve veri noktalarında bir patlama özelliği vardır; tek tek dilimleri ayırabilirsiniz.

**Bir rapor için halka grafiğinin (PNG/SVG) görüntüsü nasıl alınır?**

Bir grafik bir şekildir; onu bir [raster image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/) olarak işleyebilir veya grafiği bir [SVG image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/write_as_svg/) olarak dışa aktarabilirsiniz.