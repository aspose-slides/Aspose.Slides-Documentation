---
title: 公共 API 與不相容的變更（Aspose.Slides for Java 15.10.0）
linktitle: Aspose.Slides for Java 15.10.0
type: docs
weight: 180
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/
keywords:
- 移轉
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 投影片
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 投影片解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有已[新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/)或[移除](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-10-0/)的類別、方法、屬性等，及隨 Aspose.Slides for Java 15.10.0 API 所引入的其他變更。

{{% /alert %}} 
## **公共 API 變更**
#### **已在 ISequence 中新增圖表系列動畫 API**
已在 com.aspose.slides.ISequence 介面中新增了 2 個方法。

``` java

 IEffect addEffect(IChart chart, int type, int index, int effectType, int subtype, int triggerType);

IEffect addEffect(IChart chart, int type, int seriesIndex, int categoriesIndex, int effectType, int subtype, int triggerType);

```

這些方法旨在支援圖表元素的動畫：

依系列  
依類別  
依系列元素  
依類別元素  

已引入與圖表元素動畫相關的兩個新列舉 EffectChartMajorGroupingType 與 EffectChartMinorGroupingType。

若要為圖表新增系列動畫，可使用以下程式碼：

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

類別動畫：

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

系列元素動畫：

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

類別元素動畫：

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
#### **新增 com.aspose.slides.VideoPlayerHtmlController 以支援將媒體檔案匯出為 HTML**
已新增公共類別 com.aspose.slides.VideoPlayerHtmlController。使用此類別的實例，使用者可以將影片和音訊檔案匯出為 HTML。

VideoPlayerHtmlController 建構子接受以下參數：

path：產生影片與音訊檔案的路徑  
fileName：HTML 檔案的名稱  
baseUri：用於產生連結的基礎 URI  

使用範例：

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