---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.10.0
type: docs
weight: 180
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع [الإضافات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) أو [الإزاليات](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) من الفئات، والطرق، والخصائص، وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.10.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة واجهة برمجة تطبيقات تحريك سلسلة الرسوم البيانية إلى ISequence**
تمت إضافة طريقتين جديدتين إلى واجهة com.aspose.slides.ISequence.

``` java

 IEffect addEffect(IChart chart, int type, int index, int effectType, int subtype, int triggerType);

IEffect addEffect(IChart chart, int type, int seriesIndex, int categoriesIndex, int effectType, int subtype, int triggerType);

```

تُستخدم هذه الطريقتان لدعم تحريك عناصر الرسم البياني:

حسب السلاسل
حسب الفئات
حسب عناصر السلسلة
حسب عناصر الفئة

تم تقديم عددين جديدين من القيم EffectChartMajorGroupingType و EffectChartMinorGroupingType المتعلقة بتحريك عناصر الرسم البياني.

لإضافة تحريك سلسلة إلى الرسم البياني، يمكن استخدام الشيفرة التالية:

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

تحريك الفئات:

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

تحريك عناصر السلسلة:

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

تحريك عناصر الفئة:

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
#### **تمت إضافة com.aspose.slides.VideoPlayerHtmlController الجديد لدعم تصدير ملفات الوسائط إلى HTML**
تمت إضافة الفئة العامة الجديدة com.aspose.slides.VideoPlayerHtmlController. باستخدام مثيل من هذه الفئة، يمكن للمستخدم تصدير ملفات الفيديو والصوت إلى HTML.

تستقبل منشئات VideoPlayerHtmlController المعلمات التالية:

path: المسار الذي سيتم فيه إنشاء ملفات الفيديو والصوت
fileName: اسم ملف HTML
baseUri: URI الأساسي الذي سيُستخدم لإنشاء الروابط

مثال على الاستخدام:

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