---
title: Aspose.Slides for Java 15.10.0 的公共 API 和不兼容更改
type: docs
weight: 180
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/
---

{{% alert color="primary" %}} 

此页面列出了 Aspose.Slides for Java 15.10.0 API 引入的所有 [新增](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) 或 [移除](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/) 的类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **图表系列动画 API 已添加到 ISequence**
新的 2 个方法已添加到 com.aspose.slides.ISequence 接口。

``` java

 IEffect addEffect(IChart chart, int type, int index, int effectType, int subtype, int triggerType);

IEffect addEffect(IChart chart, int type, int seriesIndex, int categoriesIndex, int effectType, int subtype, int triggerType);

```

这些方法旨在支持图表元素的动画：

按系列
按类别
按系列元素
按类别元素

引入了与图表元素动画相关的两个新枚举 EffectChartMajorGroupingType 和 EffectChartMinorGroupingType。

要为图表添加系列动画，可以使用以下代码：

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

类别动画：

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

系列元素动画：

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

类别元素动画：

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
#### **新增 com.aspose.slides.VideoPlayerHtmlController 支持将媒体文件导出为 HTML**
新增了公共类 com.aspose.slides.VideoPlayerHtmlController。使用此类的实例，用户可以将视频和音频文件导出为 HTML。

VideoPlayerHtmlController 构造函数接受以下参数：

path：生成视频和音频文件的路径
fileName：HTML 文件的名称
baseUri：用于生成链接的基本 URI

使用示例：

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