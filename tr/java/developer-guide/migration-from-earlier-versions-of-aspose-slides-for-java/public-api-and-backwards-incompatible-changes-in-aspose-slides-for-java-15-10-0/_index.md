---
title: Aspose.Slides for Java 15.10.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.10.0
type: docs
weight: 180
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 
Bu sayfa, Aspose.Slides for Java 15.10.0 API'sı ile tanıtılan eklenmiş veya kaldırılmış sınıflar, yöntemler, özellikler vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Public API Değişiklikleri**
#### **Chart serisi animasyon API'si ISequence'e eklendi**
Yeni 2 yöntem com.aspose.slides.ISequence arayüzüne eklenmiştir.

``` java

 IEffect addEffect(IChart chart, int type, int index, int effectType, int subtype, int triggerType);

IEffect addEffect(IChart chart, int type, int seriesIndex, int categoriesIndex, int effectType, int subtype, int triggerType);

```

Bu yöntemler, grafik öğelerinin animasyonlarını desteklemek amacıyla eklenmiştir:

by series
by categories
by series elements
by categories elements

Grafik öğelerinin animasyonu ile ilgili iki yeni enum olan EffectChartMajorGroupingType ve EffectChartMinorGroupingType tanıtıldı.

Grafiğe seri animasyonu eklemek için aşağıdaki kod kullanılabilir:

``` java

 Presentation pres = new Presentation(inFileName);

try {

	ISlide slide = pres.getSlides().get_Item(0);

	IShapeCollection shapes = slide.getShapes();

	IChart chart = (IChart) shapes.get_Item(0);

	slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,

		EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.BySeries, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.BySeries, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.BySeries, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.BySeries, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	pres.save(outFileName, SaveFormat.Pptx);

} finally {

	if(pres != null) pres.dispose();

}

```

Categories animation:

``` java

 Presentation pres = new Presentation(inFileName);

try

{

	ISlide slide = pres.getSlides().get_Item(0);

	IShapeCollection shapes = slide.getShapes();

	IChart chart = (IChart) shapes.get_Item(0);

	slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,

		EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.ByCategory, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.ByCategory, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.ByCategory, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMajorGroupingType.ByCategory, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	pres.save(outFileName, SaveFormat.Pptx);

} finally {

	if(pres != null) pres.dispose();

}

```

Series elements animation:

``` java

 Presentation pres = new Presentation(inFileName);

try

{

	ISlide slide = pres.getSlides().get_Item(0);

	IShapeCollection shapes = slide.getShapes();

	IChart chart = (IChart) shapes.get_Item(0);

	slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,

		EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 0, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 0, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 0, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 0, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 1, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 1, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 1, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 1, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 2, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 2, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 2, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInSeries, 2, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	pres.save(outFileName, SaveFormat.Pptx);

} finally {

	if(pres != null) pres.dispose();

}

```

Categories elements animation:

``` java

 Presentation pres = new Presentation(inFileName);

try

{

	ISlide slide = pres.getSlides().get_Item(0);

	IShapeCollection shapes = slide.getShapes();

	IChart chart = (IChart) shapes.get_Item(0);

	slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,

		EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 0, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 0, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 0, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 0, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 1, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 1, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 1, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 1, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 2, 0,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 2, 1,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 2, 2,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,

		EffectChartMinorGroupingType.ByElementInCategory, 2, 3,

		EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

	pres.save(outFileName, SaveFormat.Pptx);

} finally {

	if(pres != null) pres.dispose();

}

```
#### **HTML'ye medya dosyalarının dışa aktarımını desteklemek için yeni com.aspose.slides.VideoPlayerHtmlController eklendi**
Yeni public sınıf com.aspose.slides.VideoPlayerHtmlController eklendi. Bu sınıfın örneği kullanılarak video ve ses dosyaları HTML'ye dışa aktarılabilir.

VideoPlayerHtmlController yapıcıları aşağıdaki parametreleri kabul eder:

path: Video ve ses dosyalarının oluşturulacağı yol  
fileName: HTML dosyasının adı  
baseUri: Bağlantıları oluşturmak için kullanılacak temel URI

Kullanım örneği:

``` java

 Presentation pres = new Presentation("example.pptx");

try

{

	final String path = "path";

	final String fileName = "video.html";

	final String baseUri = "http://www.example.com/";

	VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

	HtmlOptions htmlOptions = new HtmlOptions(controller);

	SVGOptions svgOptions = new SVGOptions(controller);

	htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

	htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

	pres.save(path + fileName, SaveFormat.Html, htmlOptions);

} finally {

	if(pres != null) pres.dispose();

}

```