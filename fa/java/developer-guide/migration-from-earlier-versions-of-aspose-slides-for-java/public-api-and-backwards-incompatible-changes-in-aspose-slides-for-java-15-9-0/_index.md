---
title: API عمومی و تغییرات ناسازگار با عقب‌گرد در Aspose.Slides برای Java 15.9.0
linktitle: Aspose.Slides برای Java 15.9.0
type: docs
weight: 170
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را مرور کنید تا بتوانید به‌صورت روان ارائه‌های PowerPoint (PPT, PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام [اضافه‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) یا [حذف‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) کلاس‌ها، متدها، خصوصیات و غیره، و سایر تغییرات معرفی‌شده با Aspose.Slides for Java 15.8.0 API را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **متدهای renderToGraphics به com.aspose.slides.ISlide، Slide اضافه شدند**
متدهای زیر اضافه شده‌اند:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
به اینترفیس com.aspose.slides.ISlide و کلاس com.aspose.slides.Slide اضافه شدند. این متدها امکان رندر کردن یک اسلاید به شی Graphics2D مشخص را فراهم می‌کنند.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```