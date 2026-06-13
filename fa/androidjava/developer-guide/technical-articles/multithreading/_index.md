---
title: پردازش چندرشته‌ای در Aspose.Slides برای Android با Java
linktitle: چندرشته‌ای
type: docs
weight: 310
url: /fa/androidjava/multithreading/
keywords:
- چندرشته‌ای
- رشته‌های متعدد
- کار موازی
- تبدیل اسلایدها
- اسلایدها به تصویر
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "پردازش چندرشته‌ای Aspose.Slides برای Android با Java، عملکرد پردازش PowerPoint و OpenDocument را بهبود می‌بخشد. بهترین روش‌ها را برای جریان‌های کاری مؤثر ارائه کشف کنید."
---
## **مقدمه**

در حالی که کار موازی با ارائه‌ها (به جز تجزیه/بارگذاری/کلون) امکان‌پذیر است و اکثر اوقات همه چیز به‌خوبی پیش می‌رود، اما احتمال کمی وجود دارد که هنگام استفاده از کتابخانه در چندین رشته نتایج نادرستی دریافت کنید.

ما به‌شدت توصیه می‌کنیم که **نکنید** یک شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) واحد در یک محیط چندرشته‌ای استفاده **نکنید** زیرا ممکن است منجر به خطاها یا شکست‌های پیش‌بینی‌نشده‌ای شود که به‌سادگی شناسایی نمی‌شوند.

در چندین رشته، بارگذاری، ذخیره‌سازی و/یا کلون کردن یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) **امن نیست**. چنین عملیاتی **پشتیبانی نمی‌شود**. اگر نیاز به انجام این کارها دارید، باید عملیات را به‌صورت موازی با استفاده از چندین پردازش تک‌رشته‌ای انجام دهید و هر یک از این پردازش‌ها باید از نمونهٔ ارائه خود استفاده کنند.

## **تبدیل اسلایدهای ارائه به تصاویر به صورت موازی**

فرض کنید می‌خواهیم تمام اسلایدهای یک ارائه PowerPoint را به تصاویر PNG به صورت موازی تبدیل کنیم. از آنجا که استفاده از یک نمونه `Presentation` در چندین رشته ایمن نیست، اسلایدهای ارائه را به ارائه‌های جداگانه تقسیم می‌کنیم و اسلایدها را به تصاویر به صورت موازی تبدیل می‌کنیم، به‌طوری‌که هر ارائه در یک رشتهٔ متفاوت استفاده شود. مثال کد زیر نشان می‌دهد چگونه این کار انجام شود.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// استخراج اسلاید i به یک ارائه جداگانه.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// تبدیل اسلاید به تصویر در یک وظیفهٔ جداگانه.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// صبر کنید تا همهٔ وظیفه‌ها تکمیل شوند.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **سوالات متداول**

**آیا نیاز است تنظیم لایسنس را در هر رشته فراخوانی کنم؟**

خیر. کافی است یک بار برای هر فرآیند/دامنهٔ برنامه قبل از شروع رشته‌ها انجام شود. اگر [license setup](/slides/fa/androidjava/licensing/) ممکن است همزمان فراخوانی شود (برای مثال، در زمان مقداردهی تنبل)، آن فراخوانی را همگام‌سازی کنید زیرا خود متد تنظیم لایسنس thread‑safe نیست.

**آیا می‌توانم اشیاء `Presentation` یا `Slide` را بین رشته‌ها انتقال دهم؟**

انتقال اشیاء «زنده» ارائه بین رشته‌ها توصیه نمی‌شود: برای هر رشته از نمونه‌های مستقل استفاده کنید یا پیش‌از پیش ارائه‌ها/محفظه‌های اسلاید جداگانه برای هر رشته ایجاد کنید. این رویکرد مطابق با توصیه کلی عدم اشتراک یک نمونهٔ ارائه بین رشته‌ها است.

**آیا ایمن است که خروجی به فرمت‌های مختلف (PDF، HTML، تصاویر) را به‌صورت موازی انجام دهیم به شرطی که هر رشته دارای نمونهٔ `Presentation` خود باشد؟**

بله. با نمونه‌های مستقل و مسیرهای خروجی جداگانه، چنین کارها معمولاً به‌صورت صحیح موازی می‌شوند؛ از هرگونه شیء ارائهٔ مشترک و جریان‌های I/O مشترک خودداری کنید.

**در حالت چندرشته‌ای چه باید با تنظیمات کلی فونت (پوشه‌ها، جایگزینی‌ها) انجام دهم؟**

تمام تنظیمات کلی [font settings](/slides/fa/androidjava/powerpoint-fonts/) را قبل از شروع رشته‌ها مقداردهی اولیه کنید و در حین کار موازی آن‌ها را تغییر ندهید. این کار رقابت‌های دسترسی به منابع فونت مشترک را از بین می‌برد.