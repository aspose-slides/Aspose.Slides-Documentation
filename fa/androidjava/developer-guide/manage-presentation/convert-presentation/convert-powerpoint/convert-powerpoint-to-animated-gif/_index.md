---
title: تبدیل ارائه‌های PowerPoint به GIFهای متحرک در Android
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/androidjava/convert-powerpoint-to-animated-gif/
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
- ذخیره PPT به صورت GIF
- ذخیره PPTX به صورت GIF
- صادرات PPT به صورت GIF
- صادرات PPTX به صورت GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) را به GIFهای متحرک با Aspose.Slides برای Android از طریق Java تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به فایل‌های GIF متحرک تبدیل کنید تنها با چند خط کد. این قابلیت زمانی مفید است که بخواهید محتوای اسلایدها را در قالبی سبک، به‌راحتی پشتیبانی‌شده و متحرک به‌اشتراک بگذارید که می‌تواند در صفحات وب، پیام‌رسان‌ها یا مستندات جاسازی شود. این مقاله نحوهٔ خروجی گرفتن یک ارائه به‌صورت GIF با تنظیمات پیش‌فرض و همچنین چگونگی سفارشی‌سازی خروجی با پیکربندی گزینه‌هایی مانند اندازهٔ فریم، تاخیر اسلاید و نرخ فریم انتقال را از طریق [GifOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/gifoptions/) توضیح می‌دهد.

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات پیش‌فرض**

این کد نمونه در Java نشان می‌دهد چگونه یک ارائه را به GIF متحرک با تنظیمات استاندارد تبدیل کنید:

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

{{% alert title="نکته" color="info" %}} 
اگر مایل به سفارشی‌سازی پارامترهای GIF هستید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GifOptions) استفاده کنید. نمونهٔ کد زیر را ببینید.
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را به GIF متحرک با تنظیمات سفارشی در Java تبدیل کنید:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // اندازهٔ GIF تولید شده  
	gifOptions.setDefaultDelay(2000); // مدت زمانی که هر اسلاید نمایش داده می‌شود تا به اسلاید بعدی تغییر کند
	gifOptions.setTransitionFps(35); // افزایش FPS برای بهبود کیفیت انیمیشن انتقال
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="اطلاع" color="info" %}}
ممکن است بخواهید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) که توسط Aspose توسعه یافته است، بررسی کنید.
{{% /alert %}}

## **سوالات متداول**

### اگر فونت‌های استفاده‌شده در ارائه بر روی سیستم نصب نشده باشند چه می‌شود؟

فونت‌های گمشده را نصب کنید یا [configure fallback fonts](/slides/fa/androidjava/powerpoint-fonts/). Aspose.Slides جایگزین خواهد کرد، اما ظاهر ممکن است متفاوت باشد. برای حفظ هویت برند، همیشه اطمینان حاصل کنید که قلم‌های مورد نیاز به‌صورت صریح در دسترس باشند.

### آیا می‌توانم یک واترمارک را روی فریم‌های GIF قرار دهم؟

بله. [Add a semi-transparent object/logo](/slides/fa/androidjava/watermark/) را به اسلاید اصلی یا به اسلایدهای فردی قبل از خروجی اضافه کنید — واترمارک در هر فریم ظاهر خواهد شد.