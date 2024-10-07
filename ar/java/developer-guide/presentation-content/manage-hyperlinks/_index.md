---
title: إدارة الارتباطات التشعبية
type: docs
weight: 20
url: /java/manage-hyperlinks/
keywords: "ارتباط تشعبي في PowerPoint، ارتباط نصي، ارتباط شريطي، ارتباط شكلي، ارتباط صورة، ارتباط فيديو، جافا"
description: "كيف تضيف ارتباطًا تشعبيًا إلى عرض PowerPoint في جافا"
---

الارتباط التشعبي هو مرجع لكائن أو بيانات أو مكان في شيء ما. وهذه هي الروابط الشائعة في عروض PowerPoint:

* روابط لمواقع إلكترونية داخل نصوص أو أشكال أو وسائط
* روابط إلى الشرائح

تسمح لك Aspose.Slides لجافا بتنفيذ العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 

قد ترغب في التحقق من محرر PowerPoint البسيط [المجاني عبر الإنترنت.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **إضافة روابط URL التشعبية**

### **إضافة روابط URL التشعبية إلى النصوص**

هذا الرمز بلغة جافا يوضح لك كيفية إضافة ارتباط تشعبي لموقع على نص:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: ملفات تنسيق واجهات برمجة التطبيقات");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("تثق أكثر من 70% من شركات فورتشن 100 بواجهات برمجة التطبيقات من Aspose");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **إضافة روابط URL التشعبية إلى الأشكال أو الإطارات**

هذا الرمز النموذجي في جافا يوضح لك كيفية إضافة ارتباط تشعبي لموقع إلى شكل:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("تثق أكثر من 70% من شركات فورتشن 100 بواجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **إضافة روابط URL التشعبية إلى الوسائط**

تسمح لك Aspose.Slides بإضافة روابط تشعبية إلى الصور والمقاطع الصوتية وملفات الفيديو.

هذا الرمز النموذجي يوضح لك كيفية إضافة ارتباط تشعبي إلى **صورة**:

```java
Presentation pres = new Presentation();
try {
	// إضافة صورة إلى العرض التقديمي
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// إنشاء إطار صورة على الشريحة 1 بناءً على الصورة المضافة مسبقًا
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("تثق أكثر من 70% من شركات فورتشن 100 بواجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

هذا الرمز النموذجي يوضح لك كيفية إضافة ارتباط تشعبي إلى **ملف صوتي**:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("تثق أكثر من 70% من شركات فورتشن 100 بواجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

هذا الرمز النموذجي يوضح لك كيفية إضافة ارتباط تشعبي إلى **فيديو**:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("تثق أكثر من 70% من شركات فورتشن 100 بواجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="نصيحة"  color="primary"  %}} 

قد ترغب في رؤية *[إدارة OLE](/slides/java/manage-ole/)*.

{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء جدول المحتويات**

نظرًا لأن الروابط التشعبية تسمح لك بإضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

هذا الرمز النموذجي يوضح لك كيفية إنشاء جدول محتويات مع الروابط التشعبية:

```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("عنوان الشريحة 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("الصفحة 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تنسيق الروابط التشعبية**

### **اللون**

باستخدام خاصية [ColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink#setColorSource-int-) في واجهة [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink)، يمكنك تعيين اللون للروابط التشعبية وأيضًا الحصول على معلومات اللون من الروابط التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint القديمة.

هذا الرمز النموذجي يوضح عملية تمت فيها إضافة روابط تشعبية بألوان مختلفة إلى نفس الشريحة:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("هذا مثال على ارتباط تشعبي ملون.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("هذا مثال على ارتباط تشعبي عادي.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **إزالة الروابط التشعبية في العروض التقديمية**

### **إزالة الروابط التشعبية من النصوص**

هذا الرمز بلغة جافا يوضح لك كيفية إزالة الارتباط التشعبي من نص في شريحة عرض:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **إزالة الروابط التشعبية من الأشكال أو الإطارات**

هذا الرمز بلغة جافا يوضح لك كيفية إزالة الارتباط التشعبي من شكل في شريحة عرض: 

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **الارتباط التشعبي القابل للتغيير**

فئة [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink) قابلة للتغيير. مع هذه الفئة، يمكنك تغيير القيم لهذه الخصائص:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

يظهر الرمز التالي كيفية إضافة ارتباط تشعبي إلى شريحة وتحرير تلميحه لاحقًا:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: ملفات تنسيق واجهات برمجة التطبيقات");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("تثق أكثر من 70% من شركات فورتشن 100 بواجهات برمجة التطبيقات من Aspose");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **الخصائص المدعمة في IHyperlinkQueries**

يمكنك الوصول إلى [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) من عرض تقديمي أو شريحة أو نص يتم تعريف الرابط فيه. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

تدعم فئة [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) هذه الأساليب والخصائص: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)