---
title: مدیریت هایپرلینک‌های ارائه در اندروید
linktitle: مدیریت هایپرلینک
type: docs
weight: 20
url: /fa/androidjava/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن هایپرلینک
- ایجاد هایپرلینک
- قالب‌بندی هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- هایپرلینک متن
- هایپرلینک اسلاید
- هایپرلینک شکل
- هایپرلینک تصویر
- هایپرلینک ویدیو
- هایپرلینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "به‌راحتی هایپرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای اندروید از طریق Java مدیریت کنید—تعامل و جریان کار را در عرض چند دقیقه ارتقا دهید."
---
## **مقدمه**

یک هایپرلینک ارجاعی به یک شیء، داده یا مکانی در یک محتوا است. این‌ها هایپرلینک‌های رایج در ارائه‌های PowerPoint هستند:

* پیوند به وب‌سایت‌ها درون متن‌ها، اشکال یا رسانه‌ها
* پیوند به اسلایدها

Aspose.Slides برای Android از طریق Java به شما امکان انجام بسیاری از وظایف مرتبط با هایپرلینک‌ها در ارائه‌ها را می‌دهد.

{{% alert color="primary" %}} 
ممکن است بخواهید Aspose ساده، [ویرایشگر رایگان آنلاین PowerPoint](https://products.aspose.app/slides/fa/editor) را بررسی کنید.
{{% /alert %}} 

## **افزودن هایپرلینک‌های URL**

### **افزودن هایپرلینک‌های URL به متن**

این کد Java نشان می‌دهد چگونه یک هایپرلینک وب‌سایت را به متن اضافه کنید:

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

### **افزودن هایپرلینک‌های URL به اشکال یا فریم‌ها**

این کد نمونه در Java نشان می‌دهد چگونه یک هایپرلینک وب‌سایت را به یک شکل اضافه کنید:

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

### **افزودن هایپرلینک‌های URL به رسانه‌ها**

Aspose.Slides به شما امکان افزودن هایپرلینک‌ها به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد. 

این کد نمونه نشان می‌دهد چگونه یک هایپرلینک به **یک تصویر** اضافه کنید:

```java
Presentation pres = new Presentation();
try {
	// اضافه کردن تصویر به ارائه
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// ایجاد فریم تصویر در اسلاید 1 بر اساس تصویر قبلاً اضافه‌شده
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

این کد نمونه نشان می‌دهد چگونه یک هایپرلینک به **یک فایل صوتی** اضافه کنید:

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

این کد نمونه نشان می‌دهد چگونه یک هایپرلینک به **یک ویدیو** اضافه کنید:

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
ممکن است بخواهید *[مدیریت OLE](/slides/fa/androidjava/manage-ole/)* را ببینید.
{{% /alert %}}

## **استفاده از هایپرلینک‌ها برای ایجاد فهرست مطالب**

از آنجا که هایپرلینک‌ها به شما امکان افزودن ارجاع به اشیاء یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید. 

این کد نمونه نشان می‌دهد چگونه فهرست مطالبی با هایپرلینک‌ها ایجاد کنید:

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

## **قالب‌بندی هایپرلینک‌ها**

### **رنگ**

با استفاده از ویژگی [ColorSource](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) در رابط [IHyperlink](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlink)، می‌توانید رنگ هایپرلینک‌ها را تنظیم کرده و همچنین اطلاعات رنگ را از هایپرلینک‌ها دریافت کنید. این قابلیت اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این ویژگی در نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این کد نمونه عملیاتی را نشان می‌دهد که در آن هایپرلینک‌های با رنگ‌های مختلف به یک اسلاید اضافه شده‌اند:

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

## **حذف هایپرلینک‌ها از ارائه‌ها**

### **حذف هایپرلینک‌ها از متن**

این کد Java نشان می‌دهد چگونه هایپرلینک را از یک متن در اسلاید ارائه حذف کنید:

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

### **حذف هایپرلینک‌ها از اشکال یا فریم‌ها**

این کد Java نشان می‌دهد چگونه هایپرلینک را از یک شکل در اسلاید ارائه حذف کنید:

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

## **هایپرلینک تغییرپذیر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Hyperlink) قابل تغییر است. با استفاده از این کلاس می‌توانید مقادیر این ویژگی‌ها را تغییر دهید:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

این قطعه کد نشان می‌دهد چگونه یک هایپرلینک به یک اسلاید اضافه کرده و پس از آن tooltip آن را ویرایش کنید:

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

## **خواص پشتیبانی‌شده در IHyperlinkQueries**

شما می‌توانید از یک ارائه، اسلاید یا متن که برای آن هایپرلینک تعریف شده است، به [IHyperlinkQueries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlinkQueries) دسترسی پیدا کنید.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

کلاس [IHyperlinkQueries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlinkQueries) این متدها و خواص را پشتیبانی می‌کند:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید، بلکه به یک «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروهی از اسلایدها هستند؛ ناوبری به‌صورت فنی به یک اسلاید خاص اشاره می‌کند. برای «ناوبری به یک بخش»، معمولاً به اولین اسلاید آن بخش پیوند می‌زنید.

**آیا می‌توانم یک هایپرلینک را به عناصر اسلاید اصلی (master) وصل کنم تا در همه اسلایدها کار کند؟**

بله. عناصر اسلاید اصلی و طرح‌بندی از هایپرلینک‌ها پشتیبانی می‌کنند. این پیوندها در اسلایدهای فرزند ظاهر می‌شوند و در طول نمایش اسلاید قابل کلیک هستند.

**آیا هایپرلینک‌ها هنگام خروجی به PDF، HTML، تصاویر یا ویدیو حفظ می‌شوند؟**

در [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/) بله—لینک‌ها به‌طور کلی حفظ می‌شوند. هنگام خروجی به [images](/slides/fa/androidjava/convert-powerpoint-to-png/) و [video](/slides/fa/androidjava/convert-powerpoint-to-video/) قابلیت کلیک کردن انتقال نمی‌یابد به دلیل ماهیت آن فرمت‌ها (فریم‌های رستر/ویدیو از هایپرلینک‌ها پشتیبانی نمی‌کنند).