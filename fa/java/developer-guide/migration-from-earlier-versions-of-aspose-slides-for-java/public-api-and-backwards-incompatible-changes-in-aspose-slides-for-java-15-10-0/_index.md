---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای Java 15.10.0
linktitle: Aspose.Slides برای Java 15.10.0
type: docs
weight: 180
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا به‌صورت روان برنامه‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت کنید."
---
{{% alert color="primary" %}} 
این صفحه تمام کلاس‌ها، متدها، خصوصیات و غیره‌ای را که [اضافه شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) یا [حذف شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) هستند، و سایر تغییرات معرفی‌شده در API Aspose.Slides for Java 15.10.0 فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **API انیمیشن سری نمودار به ISequence افزوده شده است**
۲ متد جدید به رابط com.aspose.slides.ISequence اضافه شده‌اند.

``` java

 IEffect addEffect(IChart chart, int type, int index, int effectType, int subtype, int triggerType);

IEffect addEffect(IChart chart, int type, int seriesIndex, int categoriesIndex, int effectType, int subtype, int triggerType);

```

این متدها برای پشتیبانی از انیمیشن‌های عناصر نمودار طراحی شده‌اند:

by series
by categories
by series elements
by categories elements

دو enum جدید EffectChartMajorGroupingType و EffectChartMinorGroupingType مربوط به انیمیشن عناصر نمودار معرفی شدند.

برای افزودن انیمیشن سری به نمودار می‌توانید از کد زیر استفاده کنید:

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

انیمیشن دسته‌بندی‌ها:

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

انیمیشن عناصر سری:

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

انیمیشن عناصر دسته‌بندی‌ها:

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
#### **کلاس جدید com.aspose.slides.VideoPlayerHtmlController برای پشتیبانی از خروجی فایل‌های رسانه‌ای به HTML اضافه شده است**
کلاس عمومی جدید com.aspose.slides.VideoPlayerHtmlController اضافه شده است. با استفاده از یک نمونه از این کلاس، کاربر می‌تواند فایل‌های صوتی و ویدئویی را به HTML صادر کند.

سازندگان VideoPlayerHtmlController پارامترهای زیر را می‌پذیرند:

- path: مسیر که فایل‌های صوتی و ویدئویی در آن تولید می‌شوند
- fileName: نام فایل HTML
- baseUri: URI پایه‌ای که برای تولید لینک‌ها استفاده خواهد شد

مثال استفاده:

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