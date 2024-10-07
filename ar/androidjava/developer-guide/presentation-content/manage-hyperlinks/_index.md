---
title: إدارة الروابط التشعبية
type: docs
weight: 20
url: /androidjava/manage-hyperlinks/
keywords: "رابط تشعبي في PowerPoint، رابط نصي، رابط شريحة، رابط شكل، رابط صورة، رابط فيديو، جافا"
description: "كيفية إضافة رابط تشعبي إلى عرض PowerPoint في جافا"
---

الرابط التشعبي هو إشارة إلى كائن أو بيانات أو مكان في شيء ما. هذه هي الروابط التشعبية الشائعة في عروض PowerPoint:

* روابط لمواقع الويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

يسمح Aspose.Slides لنظام Android عبر جافا لك بأداء العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على محرر PowerPoint بسيط ومجاني عبر الإنترنت من Aspose. [محرر PowerPoint المجاني.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **إضافة روابط تشعبية URL**

### **إضافة روابط تشعبية URL إلى النصوص**

يوضح هذا الكود بلغة جافا كيفية إضافة رابط تشعبي لموقع الويب إلى نص:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: واجهات برمجة التطبيقات لتهيئة الملفات");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **إضافة روابط تشعبية URL إلى الأشكال أو الإطارات**

يوضح هذا الكود النموذجي بلغة جافا كيفية إضافة رابط تشعبي لموقع الويب إلى شكل:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **إضافة روابط تشعبية URL إلى الوسائط**

يسمح Aspose.Slides لك بإضافة روابط تشعبية إلى الصور والصوت وملفات الفيديو. 

يوضح هذا الكود النموذجي كيفية إضافة رابط إلى **صورة**:

```java
Presentation pres = new Presentation();
try {
	// إضافة صورة إلى العرض
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
	pictureFrame.getHyperlinkClick().setTooltip("أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

يوضح هذا الكود النموذجي كيفية إضافة رابط إلى **ملف صوتي**:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

يوضح هذا الكود النموذجي كيفية إضافة رابط إلى **فيديو**:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="نصيحة" color="primary" %}} 

قد ترغب في رؤية *[إدارة OLE](/slides/androidjava/manage-ole/)*.

{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

نظرًا لأن الروابط التشعبية تسمح لك بإضافة إشارات إلى الكائنات أو الأماكن، يمكنك استخدامها لإنشاء جدول محتويات. 

يوضح هذا الكود النموذجي كيفية إنشاء جدول محتويات باستخدام الروابط التشعبية:

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

مع خاصية [ColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) في واجهة [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink)، يمكنك تعيين اللون للروابط التشعبية وأيضًا الحصول على معلومات اللون من الروابط التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذلك لا تنطبق التغييرات المتعلقة بالخاصية على إصدارات PowerPoint القديمة.

يوضح هذا الكود النموذجي عملية حيث تمت إضافة روابط تشعبية بألوان مختلفة إلى نفس الشريحة:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("هذا عينة من الرابط التشعبي الملون.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("هذا عينة من الرابط التشعبي العادي.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **إزالة الروابط التشعبية من العروض التقديمية**

### **إزالة الروابط التشعبية من النصوص**

يوضح هذا الكود بلغة جافا كيفية إزالة الرابط التشعبي من نص في شريحة عرض:

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

يوضح هذا الكود بلغة جافا كيفية إزالة الرابط التشعبي من شكل في شريحة عرض: 

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

## **الرابط التشعبي القابل للتعديل**

فئة [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Hyperlink) قابلة للتعديل. باستخدام هذه الفئة، يمكنك تغيير القيم لهذه الخصائص:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

يوضح مقتطف الكود كيفية إضافة رابط تشعبي إلى شريحة وتحرير تلميحه لاحقًا:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: واجهات برمجة التطبيقات لتهيئة الملفات");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("أكثر من 70% من شركات Fortune 100 تثق في واجهات برمجة التطبيقات من Aspose");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) من عرض تقديمي أو شريحة أو نص تم تعريف الرابط التشعبي له.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

يدعم فئة [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries) هذه الطرق والخصائص:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)