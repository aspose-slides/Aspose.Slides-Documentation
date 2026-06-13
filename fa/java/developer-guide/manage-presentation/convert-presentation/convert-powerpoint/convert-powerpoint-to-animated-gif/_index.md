---
title: تبدیل ارائه‌های PowerPoint به GIF‌های انیمیشنی در Java
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/java/convert-powerpoint-to-animated-gif/
keywords:
- GIF انیمیشنی
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
description: "به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) را به GIF‌های انیمیشنی با Aspose.Slides برای Java تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به فایل‌های GIF انیمیشنی با تنها چند خط کد تبدیل کنید. این زمانی مفید است که نیاز به اشتراک‌گذاری محتوای اسلایدها در قالبی سبک، به‌طور گسترده پشتیبانی‌شده و انیمیشنی دارید که می‌تواند در صفحات وب، پیام‌رسان‌ها یا مستندات تعبیه شود. این مقاله توضیح می‌دهد چگونه یک ارائه را به GIF صادر کنید با تنظیمات پیش‌فرض و چگونه خروجی را با پیکربندی گزینه‌هایی مانند اندازه فریم، تأخیر اسلاید و نرخ فریم انتقال از طریق [GifOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/gifoptions/) تنظیم کنید.

## **تبدیل ارائه‌ها به GIF انیمیشنی با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در Java نشان می‌دهد چگونه یک ارائه را به GIF انیمیشنی با استفاده از تنظیمات استاندارد تبدیل کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

فایل GIF انیمیشنی با پارامترهای پیش‌فرض ایجاد خواهد شد. 

{{%  alert  title="TIP"  color="primary"  %}} 
اگر مایل به سفارشی‌سازی پارامترهای GIF هستید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GifOptions) استفاده کنید. کد نمونه زیر را ببینید. 
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF انیمیشنی با تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را به GIF انیمیشنی با تنظیمات سفارشی در Java تبدیل کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // اندازه GIF حاصل شده  
	gifOptions.setDefaultDelay(2000); // مدت زمان نمایش هر اسلاید تا قبل از تعویض به اسلاید بعدی
	gifOptions.setTransitionFps(35); // FPS را افزایش دهید تا کیفیت انیمیشن انتقال بهبود یابد
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
ممکن است بخواهید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) را که توسط Aspose توسعه یافته است بررسی کنید. 
{{% /alert %}}

## **سوالات متداول**

**اگر فونت‌های استفاده شده در ارائه بر روی سیستم نصب نشده باشند چه می‌شود؟**

فونت‌های گمشده را نصب کنید یا [fallback fonts را پیکربندی کنید](/slides/fa/java/powerpoint-fonts/). Aspose.Slides آن‌ها را جایگزین می‌کند، اما ظاهر ممکن است متفاوت باشد. برای برندینگ، همیشه اطمینان حاصل کنید که فونت‌های مورد نیاز به‌طور صریح در دسترس باشند.

**آیا می‌توانم یک واترمارک روی فریم‌های GIF قرار دهم؟**

بله. می‌توانید یک [شیء/لوگو نیمه‌شفاف](/slides/fa/java/watermark/) را به اسلاید اصلی یا اسلایدهای جداگانه قبل از خروجی‌گیری اضافه کنید — واترمارک در هر فریم ظاهر خواهد شد.