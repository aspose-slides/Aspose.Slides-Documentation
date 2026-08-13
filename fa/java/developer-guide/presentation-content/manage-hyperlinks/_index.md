---
title: مدیریت پیوندهای ارائه در جاوا
linktitle: مدیریت پیوند
type: docs
weight: 20
url: /fa/java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- به‌روزرسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدئو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "به‌راحتی پیوندها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای جاوا مدیریت کنید—تعامل و جریان کار را در عرض چند دقیقه ارتقا دهید."
---
## **مقدمه**

یک پیوند ارجاعی به یک شی، داده یا مکانی در چیزی است. این‌ها پیوندهای رایج در ارائه‌های PowerPoint هستند:

* پیوندها به وب‌سایت‌ها داخل متن‌ها، اشکال یا رسانه‌ها
* پیوندها به اسلایدها

Aspose.Slides for Java به شما امکان می‌دهد بسیاری از وظایف مربوط به پیوندها در ارائه‌ها را انجام دهید. 

{{% alert color="info" %}} 

ممکن است بخواهید Aspose ساده، [ویرایشگر آنلاین رایگان PowerPoint](https://products.aspose.app/slides/fa/editor) را بررسی کنید.

{{% /alert %}} 

## **افزودن پیوندهای URL**

### **افزودن پیوندهای URL به متن**

این کد Java نشان می‌دهد چگونه یک پیوند وب‌سایت به متن اضافه کنید:

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

### **افزودن پیوندهای URL به اشکال یا فریم‌ها**

این نمونه کد در Java نشان می‌دهد چگونه یک پیوند وب‌سایت به یک شکل اضافه کنید:

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

### **افزودن پیوندهای URL به رسانه‌ها**

Aspose.Slides به شما امکان می‌دهد پیوندهایی به تصاویر، فایل‌های صوتی و ویدئو اضافه کنید. 

این نمونه کد نشان می‌دهد چگونه به یک **تصویر** پیوند اضافه کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// تصویر را به ارائه اضافه می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// ایجاد فریم تصویر در اسلاید 1 بر اساس تصویر اضافه‌شده قبلی
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

این نمونه کد نشان می‌دهد چگونه به یک **فایل صوتی** پیوند اضافه کنید:

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

این نمونه کد نشان می‌دهد چگونه به یک **ویدئو** پیوند اضافه کنید:

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

{{% alert title="Tip" color="info" %}} 

ممکن است بخواهید *[Manage OLE](/slides/fa/java/manage-ole/)* را مشاهده کنید.

{{% /alert %}}

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

از آنجا که پیوندها به شما امکان می‌دهند ارجاع به اشیاء یا مکان‌ها اضافه کنید، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید. 

این نمونه کد نشان می‌دهد چگونه فهرست مطالبی با پیوندها ایجاد کنید:

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

## **قالب‌بندی پیوندها**

### **رنگ**

با ویژگی [ColorSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Hyperlink#setColorSource-int-) در رابط [IHyperlink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink) می‌توانید رنگ پیوندها را تنظیم کنید و همچنین اطلاعات رنگ را از پیوندها دریافت کنید. این ویژگی اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این ویژگی برای نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این نمونه کد عملی را نشان می‌دهد که در آن پیوندهای با رنگ‌های مختلف به همان اسلاید اضافه شدند:

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

## **حذف پیوندها از ارائه‌ها**

### **حذف پیوندها از متن**

این کد Java نشان می‌دهد چگونه پیوند را از متن در یک اسلاید ارائه حذف کنید:

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

### **حذف پیوندها از اشکال یا فریم‌ها**

این کد Java نشان می‌دهد چگونه پیوند را از یک شکل در یک اسلاید ارائه حذف کنید: 

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

## **پیوند قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Hyperlink) قابل تغییر است. با استفاده از این کلاس می‌توانید مقادیر این ویژگی‌ها را تغییر دهید:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

این کد نمونه نشان می‌دهد چگونه پیوندی به اسلاید اضافه کنید و پس از آن tooltip آن را ویرایش کنید:

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

	// Tooltip پیوندی که قبلاً اضافه شده است را تغییر می‌دهد
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ویژگی‌های پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید از [IHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries) از یک ارائه، اسلاید یا متن که پیوند برای آن تعریف شده است، دسترسی پیدا کنید. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

کلاس [IHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries) این روش‌ها و ویژگی‌ها را پشتیبانی می‌کند: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **سوالات متداول**

### چگونه می‌توانم ناوبری داخلی ایجاد کنم که نه فقط به یک اسلاید، بلکه به یک «بخش» یا اولین اسلاید یک بخش اختصاص یابد؟

بخش‌ها در PowerPoint گروهی از اسلایدها هستند؛ ناوبری عملاً به یک اسلاید خاص هدف می‌گیرد. برای «ناوبری به یک بخش»، معمولاً به اولین اسلاید آن بخش پیوند می‌دهید.

### آیا می‌توانم پیوند را به عناصر اسلاید اصلی (master) پیوست کنم تا در تمام اسلایدها کار کند؟

بله. عناصر اسلاید اصلی و چیدمان‌ها از پیوندها پشتیبانی می‌کنند. چنین پیوندهایی در اسلایدهای فرعی ظاهر می‌شوند و در حین نمایش اسلاید قابل کلیک هستند.

### آیا پیوندها هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟

در [PDF](/slides/fa/java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/java/convert-powerpoint-to-html/) بله—پیوندها عموماً حفظ می‌شوند. هنگام خروجی به [images](/slides/fa/java/convert-powerpoint-to-png/) و [video](/slides/fa/java/convert-powerpoint-to-video/) قابلیت کلیک‌پذیری منتقل نمی‌شود زیرا این فرمت‌ها (فریم‌های رستر/ویدئو) از پیوندها پشتیبانی نمی‌کنند.