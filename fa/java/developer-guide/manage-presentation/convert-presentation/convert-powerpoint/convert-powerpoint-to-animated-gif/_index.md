---
title: تبدیل ارائه‌های PowerPoint به GIFهای متحرک در Java
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/java/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرک
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به GIF
- ارائه به GIF
- اسلاید به GIF
- PPT به GIF
- PPTX به GIF
- ذخیره PPT به عنوان GIF
- ذخیره PPTX به عنوان GIF
- صدور PPT به عنوان GIF
- صدور PPTX به عنوان GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به GIFهای متحرک با Aspose.Slides برای Java تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا ارائه‌های PowerPoint را به فایل‌های GIF متحرک فقط با چند خط کد تبدیل کنید. این زمانی مفید است که نیاز دارید محتوای اسلایدها را در قالبی سبک، با پشتیبانی گسترده و متحرک به اشتراک بگذارید که می‌تواند در صفحات وب، پیام‌رسان‌ها یا مستندات جاسازی شود. این مقاله توضیح می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به GIF خروجی بگیرید و چگونه با پیکربندی گزینه‌هایی مانند اندازه فریم، задержка اسلاید و نرخ فریم انتقال، خروجی را سفارشی کنید از طریق [GifOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/gifoptions/).

## **تبدیل ارائه‌ها به GIF متحرک با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در Java نشان می‌دهد چگونه یک ارائه را با استفاده از تنظیمات استاندارد به GIF متحرک تبدیل کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

GIF متحرک با پارامترهای پیش‌فرض ایجاد خواهد شد.

{{%  alert  title="TIP"  color="info"  %}} 
اگر مایل به سفارشی‌سازی پارامترهای GIF باشید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GifOptions) استفاده کنید. کد نمونه زیر را ببینید. 
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF متحرک با استفاده از تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در Java به GIF متحرک تبدیل کنید:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // اندازه GIF حاصل
	gifOptions.setDefaultDelay(2000); // طول مدت نمایش هر اسلاید تا زمانی که به اسلاید بعدی تغییر کند
	gifOptions.setTransitionFps(35); // افزایش FPS برای کیفیت بهتر انیمیشن انتقال
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
ممکن است بخواهید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) که توسط Aspose توسعه یافته است، بررسی کنید. 
{{% /alert %}}

## **سوالات متداول**

### اگر قلم‌های استفاده‌شده در ارائه بر روی سیستم نصب نشده باشند چه می‌شود؟

قلم‌های گمشده را نصب کنید یا [configure fallback fonts](/slides/fa/java/powerpoint-fonts/). Aspose.Slides جایگزین خواهد کرد، اما ظاهر ممکن است متفاوت باشد. برای برندینگ، همیشه اطمینان حاصل کنید که قلم‌های مورد نیاز صراحتاً در دسترس باشند.

### آیا می‌توانم یک واترمارک روی فریم‌های GIF اضافه کنم؟

بله. [Add a semi-transparent object/logo](/slides/fa/java/watermark/) را به اسلاید اصلی یا به اسلایدهای جداگانه قبل از خروجی اضافه کنید — واترمارک در هر فریم ظاهر خواهد شد.