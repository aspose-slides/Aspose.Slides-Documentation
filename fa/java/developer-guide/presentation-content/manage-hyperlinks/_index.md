---
title: مدیریت ابرلینک‌های ارائه در Java
linktitle: مدیریت ابرلینک
type: docs
weight: 20
url: /fa/java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن ابرلینک
- ایجاد ابرلینک
- قالب‌بندی ابرلینک
- حذف ابرلینک
- بروزرسانی ابرلینک
- ابرلینک متن
- ابرلینک اسلاید
- ابرلینک شکل
- ابرلینک تصویر
- ابرلینک ویدئو
- ابرلینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به راحتی ابرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Java مدیریت کنید—تعامل و جریان کار را در عرض چند دقیقه ارتقا دهید."
---
## **مقدمه**

یک ابرلینک مرجع به یک شیء، داده یا مکانی در چیزی است. این‌ها ابرلینک‌های رایج در ارائه‌های پاورپوینت هستند:

* لینک به وب‌سایت‌ها درون متن‌ها، شکل‌ها یا رسانه‌ها
* لینک به اسلایدها

Aspose.Slides for Java به شما امکان انجام بسیاری از کارها با ابرلینک‌ها در ارائه‌ها را می‌دهد. 

{{% alert color="primary" %}} 
ممکن است بخواهید ویرایشگر آنلاین رایگان پاورپوینت Aspose را بررسی کنید.[ویرایشگر آنلاین رایگان پاورپوینت Aspose](https://products.aspose.app/slides/fa/editor)
{{% /alert %}} 

## **اضافه‌کردن ابرلینک‌های URL**

### **اضافه‌کردن ابرلینک URL به متن**

این کد جاوا نشان می‌دهد چگونه یک ابرلینک وب‌سایت به متن اضافه کنید:

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

### **اضافه‌کردن ابرلینک URL به اشکال یا فریم‌ها**

این نمونه کد در جاوا نشان می‌دهد چگونه یک ابرلینک وب‌سایت به یک شکل اضافه کنید:

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

### **اضافه‌کردن ابرلینک URL به رسانه‌ها**

Aspose.Slides به شما امکان اضافه‌کردن ابرلینک به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد. 

این نمونه کد نشان می‌دهد چگونه به یک **تصویر** ابرلینک اضافه کنید:

```java
Presentation pres = new Presentation();
try {
	// تصویر را به ارائه اضافه می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// قاب تصویر را بر روی اسلاید 1 ایجاد می‌کند بر پایه تصویری که قبلاً اضافه شده بود
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

این نمونه کد نشان می‌دهد چگونه به یک **فایل صوتی** ابرلینک اضافه کنید:

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

این نمونه کد نشان می‌دهد چگونه به یک **ویدئو** ابرلینک اضافه کنید:

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
ممکن است بخواهید *[مدیریت OLE](/slides/fa/java/manage-ole/)* را مشاهده کنید.
{{% /alert %}}

## **استفاده از ابرلینک‌ها برای ساخت فهرست مطالب**

از آنجا که ابرلینک‌ها به شما امکان اضافه‌کردن مرجع به اشیاء یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ساخت فهرست مطالب استفاده کنید. 

این نمونه کد نشان می‌دهد چگونه فهرست مطالب با ابرلینک‌ها ایجاد کنید:

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

## **قالب‌بندی ابرلینک‌ها**

### **رنگ**

با ویژگی [ColorSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Hyperlink#setColorSource-int-) در اینترفیس [IHyperlink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink) می‌توانید رنگ ابرلینک‌ها را تنظیم کنید و همچنین اطلاعات رنگ را از ابرلینک‌ها دریافت کنید. این ویژگی برای اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این ویژگی در نسخه‌های قبلی پاورپوینت اعمال نمی‌شود.

این نمونه کد عملیاتی را نشان می‌دهد که در آن ابرلینک‌های با رنگ‌های مختلف به همان اسلاید اضافه شدند:

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

## **حذف ابرلینک‌ها از ارائه‌ها**

### **حذف ابرلینک‌ها از متن**

این کد جاوا نشان می‌دهد چگونه ابرلینک را از یک متن در اسلاید ارائه حذف کنید:

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

### **حذف ابرلینک‌ها از اشکال یا فریم‌ها**

این کد جاوا نشان می‌دهد چگونه ابرلینک را از یک شکل در اسلاید ارائه حذف کنید: 

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

## **Hyperlink قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Hyperlink) قابل تغییر است. با این کلاس می‌توانید مقادیر ویژگی‌های زیر را تغییر دهید:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

این قطعه کد نشان می‌دهد چگونه یک ابرلینک به اسلاید اضافه کنید و بعداً tooltip آن را ویرایش کنید:

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

## **ویژگی‌های پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید از [IHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries) از طریق یک ارائه، اسلاید یا متن که ابرلینک در آن تعریف شده است، دسترسی پیدا کنید. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

کلاس [IHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries) این متدها و ویژگی‌ها را پشتیبانی می‌کند: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **سؤالات متداول**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید بلکه به «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروهی از اسلایدها هستند؛ ناوبری به‌صورت فنی به اسلاید خاصی هدف می‌گیرد. برای «ناوبری به یک بخش»، معمولاً به اولین اسلاید آن لینک می‌دهید.

**آیا می‌توانم ابرلینک را به عناصر اسلاید اصلی (master) متصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید اصلی و قالب‌های چیدمان از ابرلینک‌ها پشتیبانی می‌کنند. این لینک‌ها بر روی اسلایدهای فرزند ظاهر می‌شوند و در حین نمایش اسلاید قابل کلیک هستند.

**آیا ابرلینک‌ها هنگام خروجی گرفتن به PDF، HTML، تصویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/java/convert-powerpoint-to-html/) بله—لینک‌ها عموماً حفظ می‌شوند. هنگام خروجی به [تصاویر](/slides/fa/java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/java/convert-powerpoint-to-video/) قابلیت کلیک شدن به دلیل طبیعت این فرمت‌ها (فریم‌های رستر/ویدئو از ابرلینک پشتیبانی نمی‌کنند) حفظ نمی‌شود.