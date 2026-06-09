---
title: Sunum Çizelgelerini Python ile Dışa Aktarma
linktitle: Çizelgeyi Dışa Aktar
type: docs
weight: 90
url: /tr/python-net/export-chart/
keywords:
- çizelge
- çizelge görsele
- çizelge görsel olarak
- çizelge görselini çıkar
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunum çizelgelerini dışa aktarmayı öğrenin, PPT, PPTX ve ODP formatlarını destekler ve raporlamayı herhangi bir iş akışına entegre eder."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan bir çizelgeyi resim olarak dışa aktarmanıza olanak tanır. Bu makale, bir çizelgeden resim alıp kaydetmenin nasıl yapılacağını gösterir; bu, çizelge görsellerini bir PowerPoint sunumu dışında yeniden kullanmanız gerektiğinde faydalıdır.

## **Çizelge Resmi Al**
Aspose.Slides for Python via .NET, belirli bir çizelgenin resmini çıkarmayı destekler. Aşağıda örnek bir kod verilmiştir.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **SSS**

**Bir çizelgeyi raster resim yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir çizelge bir şekildir ve içeriği, [şekli SVG olarak kaydetme yöntemi](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/write_as_svg/) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan çizelgenin piksel cinsinden tam boyutunu nasıl belirleyebilirim?**

Boyut veya ölçek belirtebilen image-rendering aşırı yüklemelerini kullanın—kütüphane, verilen boyut/ölçekle nesneleri renderlemeyi destekler.

**Etiketlerde ve lejanda kullanılan yazı tipleri dışa aktarıldıktan sonra yanlış görünüyor, ne yapmalıyım?**

[İhtiyaç duyulan yazı tiplerini](/slides/tr/python-net/custom-font/) [FontsLoader](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsloader/) aracılığıyla yükleyin, böylece çizelge renderlaması metrikleri ve metin görünümünü korur.

**Dışa aktarma PowerPoint temasını, stillerini ve efektlerini göz önünde bulunduruyor mu?**

Evet. Aspose.Slides’ın renderlayıcısı, sunumun biçimlendirmesini (temalar, stiller, dolgular, efektler) izler, bu nedenle çizelgenin görünümü korunur.

**Çizelge resimlerinin ötesinde mevcut render/dışa aktarım yeteneklerini nereden bulabilirim?**

Çıktı hedefleri ([PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/tr/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/python-net/convert-powerpoint-to-xps/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/), vb.) ve ilgili renderlama seçenekleri için [API](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/)/[belgelendirme](/slides/tr/python-net/convert-powerpoint/) kısmındaki dışa aktarma bölümüne bakın.