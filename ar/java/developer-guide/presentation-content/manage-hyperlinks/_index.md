---
title: إدارة الروابط التشعبية للعرض التقديمي في جافا
linktitle: إدارة الرابط التشعبي
type: docs
weight: 20
url: /ar/java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة رابط تشعبي
- إنشاء رابط تشعبي
- تنسيق رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- رابط تشعبي للنص
- رابط تشعبي للشرائح
- رابط تشعبي للشكل
- رابط تشعبي للصورة
- رابط تشعبي للفيديو
- رابط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "بسهولة إدارة الروابط التشعبية في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides for Java—عزز التفاعل وسير العمل في دقائق."
---

الرابط التشعبي هو مرجع لكائن أو بيانات أو مكان في شيء ما. هذه هي الروابط التشعبية الشائعة في عروض PowerPoint التقديمية:

* روابط إلى مواقع الويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

Aspose.Slides for Java يسمح لك بأداء العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على أسبوز البسيط، [محرر PowerPoint المجاني على الإنترنت.](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **إضافة روابط URL**

### **إضافة روابط URL إلى النص**

يعرض لك هذا الكود Java كيفية إضافة رابط موقع ويب إلى نص:
```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```


### **إضافة روابط URL إلى الأشكال أو الإطارات**

يعرض لك هذا الكود النموذجي في Java كيفية إضافة رابط موقع ويب إلى شكل:
```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


### **إضافة روابط URL إلى الوسائط**

Aspose.Slides يسمح لك بإضافة روابط تشعبية إلى الصور وملفات الصوت والفيديو.

يعرض لك هذا الكود النموذجي كيفية إضافة رابط تشعبي إلى **صورة**:
```java
Presentation pres = new Presentation();
try {
	// يضيف صورة إلى العرض التقديمي
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// ينشئ إطار صورة على الشريحة 1 بناءً على الصورة المضافة مسبقًا
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


يعرض لك هذا الكود النموذجي كيفية إضافة رابط تشعبي إلى **ملف صوتي**:
```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


يعرض لك هذا الكود النموذجي كيفية إضافة رابط تشعبي إلى **فيديو**:
```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


{{%  alert  title="Tip"  color="primary"  %}} 
قد ترغب في الاطلاع على *[إدارة OLE](/slides/ar/java/manage-ole/)*.
{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

نظرًا لأن الروابط التشعبية تسمح لك بإضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

يعرض لك هذا الكود النموذجي كيفية إنشاء جدول محتويات باستخدام الروابط التشعبية:
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
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
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

باستخدام خاصية [ColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink#setColorSource-int-) في واجهة [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink)، يمكنك تعيين اللون للروابط التشعبية وكذلك الحصول على معلومات اللون من الروابط التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint القديمة.

يعرض لك هذا الكود النموذجي عملية تم فيها إضافة روابط تشعبية بألوان مختلفة إلى الشريحة نفسها:
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **إزالة الروابط التشعبية في العروض التقديمية**

### **إزالة الروابط التشعبية من النص**

يعرض لك هذا الكود Java كيفية إزالة الرابط التشعبي من نص في شريحة عرض تقديمي:
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

يعرض لك هذا الكود Java كيفية إزالة الرابط التشعبي من شكل في شريحة عرض تقديمي:
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

الفئة [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/Hyperlink) قابلة للتعديل. باستخدام هذه الفئة، يمكنك تغيير القيم لهذه الخصائص:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

يعرض لك مقطع الشيفرة كيفية إضافة رابط تشعبي إلى شريحة وتعديل تلميحه لاحقًا:
```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) من عرض تقديمي أو شريحة أو نص تم تعريف الرابط التشعبي له. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

The [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries) class supports these methods and properties: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **الأسئلة الشائعة**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى من قسم؟**

الأقسام في PowerPoint هي تجميعات للشرائح؛ التقنية تستهدف شريحة محددة. للتنقل إلى قسم، عادةً ما ترتبط بأول شريحة له.

**هل يمكنني إرفاق رابط تشعبي بعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والتخطيط الروابط التشعبية. تظهر هذه الروابط على الشرائح الفرعية وتكون قابلة للنقر أثناء عرض الشرائح.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

في [PDF](/slides/ar/java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/java/convert-powerpoint-to-html/)، نعم—عادةً ما يتم الحفاظ على الروابط. عند التصدير إلى [الصور](/slides/ar/java/convert-powerpoint-to-png/) و[الفيديو](/slides/ar/java/convert-powerpoint-to-video/)، لن يتم نقل القابلية للنقر بسبب طبيعة تلك الصيغ (الإطارات/الفيديو النقطية لا تدعم الروابط التشعبية).