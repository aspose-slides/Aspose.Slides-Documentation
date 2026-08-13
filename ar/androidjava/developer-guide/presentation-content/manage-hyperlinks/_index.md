---
title: إدارة الروابط التشعبية للعرض التقديمي على Android
linktitle: إدارة الارتباط التشعبي
type: docs
weight: 20
url: /ar/androidjava/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي للنص
- ارتباط تشعبي للشرائح
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قم بإدارة الروابط التشعبية بسهولة في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للأندرويد عبر Java — عزّز التفاعلية وسير العمل في دقائق."
---
## **مقدمة**

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو مكان في شيء ما. هذه أمثلة على الارتباطات التشعبية الشائعة في عروض PowerPoint التقديمية:

* روابط إلى المواقع داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

Aspose.Slides for Android عبر Java يتيح لك تنفيذ العديد من المهام المتعلقة بالارتباطات التشعبية في العروض التقديمية.

{{% alert color="info" %}} 
قد ترغب في تجربة Aspose البسيط، [محرر PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/ar/editor)
{{% /alert %}} 

## **إضافة روابط URL**

### **إضافة روابط URL إلى النص**

يعرض لك هذا الكود Java كيفية إضافة ارتباط تشعبي لموقع ويب إلى نص:

```java
import com.aspose.slides.*;

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

يعرض لك هذا الكود النموذجي بلغة Java كيفية إضافة ارتباط تشعبي لموقع ويب إلى شكل:

```java
import com.aspose.slides.*;

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

يتيح لك Aspose.Slides إضافة ارتباطات تشعبية إلى ملفات الصور والصوت والفيديو.

يعرض لك هذا الكود النموذجي كيفية إضافة ارتباط تشعبي إلى **صورة**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// إضافة صورة إلى العرض التقديمي
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// إنشاء إطار صورة على الشريحة 1 بناءً على الصورة المضافة مسبقًا
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

يعرض لك هذا الكود النموذجي كيفية إضافة ارتباط تشعبي إلى **ملف صوتي**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

يعرض لك هذا الكود النموذجي كيفية إضافة ارتباط تشعبي إلى **فيديو**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

{{%  alert  title="Tip"  color="info"  %}} 
قد ترغب في الاطلاع على *[إدارة OLE](/slides/ar/androidjava/manage-ole/)*.
{{% /alert %}}

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

نظرًا لأن الارتباطات التشعبية تسمح لك بإضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

يعرض لك هذا الكود النموذجي كيفية إنشاء جدول محتويات باستخدام الارتباطات التشعبية:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **تنسيق الارتباطات التشعبية**

### **اللون**

باستخدام خاصية [ColorSource](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) في واجهة [IHyperlink](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlink)، يمكنك ضبط لون الارتباطات التشعبية وكذلك الحصول على معلومات اللون من الارتباطات. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint الأقدم.

يوضح لك هذا الكود النموذجي عملية إضافة ارتباطات تشعبية بألوان مختلفة إلى الشريحة نفسها:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **إزالة الارتباطات التشعبية من العروض التقديمية**

### **إزالة الارتباطات التشعبية من النص**

يعرض لك هذا الكود Java كيفية إزالة الارتباط التشعبي من نص في شريحة عرض تقديمي:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
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

### **إزالة الارتباطات التشعبية من الأشكال أو الإطارات**

يعرض لك هذا الكود Java كيفية إزالة الارتباط التشعبي من شكل في شريحة عرض تقديمي:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

## **الارتباط التشعبي القابل للتعديل**

الفئة [Hyperlink](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Hyperlink) قابلة للتعديل. باستخدام هذه الفئة، يمكنك تعديل القيم للخاصيات التالية:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

يعرض لك مقطع الشيفرة كيفية إضافة ارتباط تشعبي إلى شريحة وتعديل تلميحه اللاحقًا:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// يغيّر تلميح الارتباط التشعبي الذي تم إضافته مسبقًا
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى [IHyperlinkQueries](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlinkQueries) من عرض تقديمي أو شريحة أو نص تم تعريف الارتباط التشعبي له.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

تدعم الفئة [IHyperlinkQueries](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlinkQueries) هذه الأساليب والخصائص:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **الأسئلة الشائعة**

### كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى “قسم” أو إلى الشريحة الأولى في القسم؟

الأقسام في PowerPoint هي مجموعات من الشرائح؛ يتوجه التنقل تقنيًا إلى شريحة محددة. لل«انتقال إلى قسم»، عادةً ما تقوم بالربط إلى شريحته الأولى.

### هل يمكنني إرفاق ارتباط تشعبي بعناصر الشريحة الرئيسة بحيث يعمل على جميع الشرائح؟

نعم. تدعم عناصر الشريحة الرئيسة وتخطيطها الارتباطات التشعبية. تظهر هذه الروابط على الشرائح الفرعية ويمكن النقر عليها أثناء عرض الشرائح.

### هل سيتم الحفاظ على الارتباطات التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟

في [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) و [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، نعم — عادةً ما يتم الحفاظ على الروابط. عند التصدير إلى [images](/slides/ar/androidjava/convert-powerpoint-to-png/) و [video](/slides/ar/androidjava/convert-powerpoint-to-video/)، لن يتم نقل قابلية النقر بسبب طبيعة هذه الصيغ (الإطارات النقطية/الفيديو لا تدعم الارتباطات التشعبية).