---
title: بهبود ارائه‌های شما با AutoFit در Java
linktitle: تنظیمات Autofit
type: docs
weight: 30
url: /fa/java/manage-autofit-settings/
keywords:
- جعبه‌متن
- AutoFit
- عدم AutoFit
- جای‌گذاری متن
- کاهش متن
- پیچاندن متن
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه تنظیمات AutoFit را در Aspose.Slides برای Java مدیریت کنید تا نمایش متن را در ارائه‌های PowerPoint و OpenDocument بهینه‌سازی کنید و خوانایی محتوای شما را بهبود بخشید."
---
## **معرفی**

به‌طور پیش‌فرض، وقتی یک جعبه متن اضافه می‌کنید، Microsoft PowerPoint از تنظیم **Resize shape to fix text** برای جعبه متن استفاده می‌کند—به‌صورت خودکار اندازه جعبه متن را تغییر می‌دهد تا متن آن همیشه داخل آن جا بگیرد. 

![جعبه‌متن در پاورپوینت](textbox-in-powerpoint.png)

* وقتی متن داخل جعبه متن طولانی‌تر یا بزرگ‌تر شود، PowerPoint به‌طور خودکار جعبه متن را بزرگ می‌کند—ارتفاع آن را افزایش می‌دهد—تا متن بیشتری را در خود جای دهد. 
* وقتی متن داخل جعبه متن کوتاه‌تر یا کوچک‌تر شود، PowerPoint به‌طور خودکار جعبه متن را کوچک می‌کند—ارتفاع آن را کاهش می‌دهد—تا فضای اضافی حذف شود. 

در PowerPoint، اینها ۴ پارامتر یا گزینه مهم هستند که رفتار خودکار تنظیم اندازه (autofit) برای جعبه متن را کنترل می‌کنند: 

* **عدم خودکار تنظیم**
* **کاهش متن در حالت سرریز**
* **تغییر اندازه شکل برای جا دادن متن**
* **پیچیدن متن در شکل.**

![گزینه‌های autofit در پاورپوینت](autofit-options-powerpoint.png)

Aspose.Slides for Java گزینه‌های مشابهی را ارائه می‌دهد—برخی از ویژگی‌ها در کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat) — که به شما امکان کنترل رفتار autofit برای جعبه‌های متن در ارائه‌ها را می‌دهد. 

## **تغییر اندازه یک شکل برای جا دادن متن**

اگر می‌خواهید متن داخل یک جعبه همیشه در همان جعبه جا بگیرد پس از تغییرات، باید از گزینه **Resize shape to fix text** استفاده کنید. برای تعیین این تنظیم، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat)) را به مقدار `Shape` تنظیم کنید. 

![تنظیم alwaysfit در پاورپوینت](alwaysfit-setting-powerpoint.png)

این کد Java نشان می‌دهد چگونه مشخص کنید که یک متن همیشه باید در جعبه خود در یک ارائه PowerPoint جا بگیرد:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

اگر متن طولانی‌تر یا بزرگ‌تر شود، جعبه متن به‌طور خودکار اندازه‌اش تغییر می‌یابد (ارتفاع افزایش می‌یابد) تا تمام متن در آن جا بگیرد. اگر متن کوتاه‌تر شود، عکس العمل مخالف رخ می‌دهد. 

## **عدم Autofit**

اگر می‌خواهید یک جعبه متن یا شکل ابعاد خود را صرف‌نظر از تغییرات متن داخل آن حفظ کند، باید از گزینه **Do not Autofit** استفاده کنید. برای تعیین این تنظیم، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat#getAutofitType--) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat) به مقدار `None` تنظیم کنید. 

![تنظیم عدم Autofit در پاورپوینت](donotautofit-setting-powerpoint.png)

این کد Java نشان می‌دهد چگونه مشخص کنید که یک جعبه متن همیشه ابعاد خود را در یک ارائه PowerPoint حفظ کند:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

وقتی متن برای جعبه‌اش بیش از حد طولانی شود، بیرون می‌ریزد. 

## **کاهش متن در حالت سرریز**

اگر متنی برای جعبه‌اش بیش از حد طولانی شود، با استفاده از گزینه **Shrink text on overflow** می‌توانید تعیین کنید که اندازه و فاصله متن باید کاهش یابد تا در جعبه جا بگیرد. برای تنظیم این گزینه، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat#getAutofitType--) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat) به مقدار `Normal` تنظیم کنید. 

![تنظیم shrinktextonoverflow در پاورپوینت](shrinktextonoverflow-setting-powerpoint.png)

این کد Java نشان می‌دهد چگونه مشخص کنید که متن در حالت سرریز باید کوچک شود در یک ارائه PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
زمانی که گزینه **Shrink text on overflow** استفاده می‌شود، تنظیم فقط زمانی اعمال می‌شود که متن برای جعبه‌اش بیش از حد طولانی شود.
{{% /alert %}}

## **پیچیدن متن**

اگر می‌خواهید متن داخل یک شکل در همان شکل پیچیده شود وقتی متن از مرز (فقط عرض) شکل عبور کند، باید از پارامتر **Wrap text in shape** استفاده کنید. برای تعیین این تنظیم، باید ویژگی [WrapText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat#getWrapText--) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat) به مقدار `true` تنظیم کنید. 

این کد Java نشان می‌دهد چگونه تنظیم Wrap Text را در یک ارائه PowerPoint استفاده کنید:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
اگر ویژگی `WrapText` را برای یک شکل به `False` تنظیم کنید، وقتی متن داخل شکل از عرض شکل طولانی‌تر شود، متن در یک خط به خارج از مرزهای شکل ادامه می‌یابد. 
{{% /alert %}}

## **سوالات متداول**

**آیا حاشیه‌های داخلی فریم متن بر AutoFit تأثیر می‌گذارند؟**

بله. Padding (حاشیه‌های داخلی) فضای قابل استفاده برای متن را کاهش می‌دهد، بنابراین AutoFit زودتر فعال می‌شود—فونت را کوچکتر می‌کند یا شکل را زودتر تغییر اندازه می‌دهد. قبل از تنظیم AutoFit حاشیه‌ها را بررسی و تنظیم کنید.

**AutoFit چگونه با شکست‌خط‌های دستی و نرم تعامل می‌کند؟**

شکست‌خط‌های اجباری در جای خود می‌مانند و AutoFit اندازه فونت و فاصله‌ها را اطراف آن‌ها تنظیم می‌کند. حذف شکست‌خط‌های غیرضروری اغلب میزان فشرده‌سازی متن توسط AutoFit را کاهش می‌دهد.

**آیا تغییر فونت تم یا اعمال جایگزینی فونت بر نتایج AutoFit تأثیر دارد؟**

بله. جایگزینی به فونتی با معیارهای گلیف متفاوت، عرض/ارتفاع متن را تغییر می‌دهد که می‌تواند اندازه نهایی فونت و پیچیدن خطوط را تحت تأثیر قرار دهد. پس از هر تغییر یا جایگزینی فونت، اسلایدها را دوباره بررسی کنید.