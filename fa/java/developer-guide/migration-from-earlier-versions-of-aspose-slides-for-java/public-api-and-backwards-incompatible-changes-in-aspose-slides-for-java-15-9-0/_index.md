---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای Java 15.9.0
linktitle: Aspose.Slides برای Java 15.9.0
type: docs
weight: 170
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا بتوانید راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را به‌سادگی مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [اضافه شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) یا [حذف شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) هستند و سایر تغییراتی که با API Aspose.Slides for Java 15.8.0 معرفی شده‌اند را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **متدهای renderToGraphics به com.aspose.slides.ISlide، Slide اضافه شدند**
متدهای زیر اضافه شده‌اند:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
به اینترفیس com.aspose.slides.ISlide و کلاس com.aspose.slides.Slide اضافه شدند. این متدها امکان رندر اسلاید به شی Graphics2D مشخص را فراهم می‌کنند.

متدهای `renderToGraphics` از آن پس از API عمومی حذف شده‌اند. در نسخه‌های فعلی، برای رندر اسلاید از [ISlide.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) استفاده می‌شود، همان‌طور که مثال زیر نشان می‌دهد:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```