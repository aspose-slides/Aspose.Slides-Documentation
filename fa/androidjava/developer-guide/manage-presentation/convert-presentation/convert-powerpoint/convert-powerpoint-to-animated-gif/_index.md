---
title: تبدیل ارائه‌های پاورپوینت به GIFهای انیمیشن‌دار در اندروید
linktitle: پاورپوینت به GIF
type: docs
weight: 65
url: /fa/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- GIF انیمیشن‌دار
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به GIF
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
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "به‌راحتی ارائه‌های پاورپوینت (PPT، PPTX) را با Aspose.Slides برای اندروید از طریق جاوا به GIFهای انیمیشن‌دار تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **بررسی کلی**

Aspose.Slides به شما امکان تبدیل ارائه‌های PowerPoint به پرونده‌های GIF انیمیشنی را با تنها چند خط کد می‌دهد. این زمانی مفید است که نیاز به به‌اشتراک‌گذاری محتوای اسلایدها در قالب سبکی، پشتیبانی‌شده گسترده و انیمیشنی داشته باشید که می‌تواند در صفحات وب، پیام‌رسان‌ها یا اسناد جاسازی شود. این مقاله توضیح می‌دهد چگونه یک ارائه را به GIF صادر کنید با استفاده از تنظیمات پیش‌فرض و چگونه خروجی را با پیکربندی گزینه‌هایی مانند اندازه فریم، تأخیر اسلاید و نرخ فریم انتقال از طریق [GifOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/gifoptions/) سفارشی کنید.

## **تبدیل ارائه‌ها به GIF انیمیشنی با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در Java نشان می‌دهد چگونه یک ارائه را به GIF انیمیشنی با تنظیمات استاندارد تبدیل کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

GIF انیمیشنی با پارامترهای پیش‌فرض ایجاد خواهد شد.

{{%  alert  title="TIP"  color="primary"  %}} 
اگر مایل به سفارشی‌سازی پارامترهای GIF هستید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GifOptions) استفاده کنید. کد نمونه زیر را ببینید.
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF انیمیشنی با استفاده از تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را به GIF انیمیشنی با تنظیمات سفارشی در Java تبدیل کنید:

```java
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

{{% alert title="Info" color="info" %}}
ممکن است بخواهید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) تولید شده توسط Aspose را بررسی کنید.
{{% /alert %}}

## **سوالات متداول**

**اگر فونت‌های استفاده‌شده در ارائه بر روی سیستم نصب نشده باشند چه شود؟**

فونت‌های گمشده را نصب کنید یا [configure fallback fonts](/slides/fa/androidjava/powerpoint-fonts/). Aspose.Slides جایگزین می‌کند، اما ظاهر ممکن است متفاوت باشد. برای برندینگ، همیشه اطمینان حاصل کنید که قلم‌های مورد نیاز به‌ طور صریح در دسترس باشند.

**آیا می‌توانم یک واترمارک روی فریم‌های GIF اضافه کنم؟**

بله. می‌توانید یک شیء/لوگو نیمه‌شفاف را با استفاده از راهنمای [Add a semi-transparent object/logo](/slides/fa/androidjava/watermark/) به اسلاید مستر یا به اسلایدهای جداگانه قبل از خروجی اضافه کنید — واترمارک بر روی هر فریم ظاهر خواهد شد.