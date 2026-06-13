---
title: "بهبود ارائه‌های شما با AutoFit در اندروید"
linktitle: "تنظیمات Autofit"
type: docs
weight: 30
url: /fa/androidjava/manage-autofit-settings/
keywords:
- جعبه متن
- تنظیم خودکار
- عدم تنظیم خودکار
- متن مناسب
- متن کوچک‌شده
- پیچاندن متن
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "تنظیمات AutoFit را در Aspose.Slides برای اندروید از طریق جاوا مدیریت کنید تا نمایش متن در ارائه‌های PowerPoint و OpenDocument شما بهینه شود و خوانایی محتوا بهبود یابد."
---
## **معرفی**

به طور پیش‌فرض، وقتی یک جعبه متن اضافه می‌کنید، Microsoft PowerPoint از تنظیم **Resize shape to fix text** برای جعبه متن استفاده می‌کند—به‌صورت خودکار اندازه جعبه متن را تغییر می‌دهد تا متن آن همیشه داخل آن جا بگیرد.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* وقتی متن در جعبه متن طولانی‌تر یا بزرگ‌تر می‌شود، PowerPoint به‌صورت خودکار جعبه متن را بزرگ می‌کند—ارتفاع آن را افزایش می‌دهد—تا بتواند متن بیشتری را در خود نگه دارد.  
* وقتی متن در جعبه متن کوتاه‌تر یا کوچک‌تر می‌شود، PowerPoint به‌صورت خودکار جعبه متن را کوچک می‌کند—ارتفاع آن را کاهش می‌دهد—تا فضای اضافه را حذف کند.  

در PowerPoint، این چهار پارامتر یا گزینه مهم هستند که رفتار autofit را برای یک جعبه متن کنترل می‌کنند:

* **عدم تنظیم خودکار**
* **کاهش متن در سرریز**
* **تغییر اندازه شکل برای متن**
* **پیچاندن متن در شکل.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java گزینه‌های مشابهی ارائه می‌دهد—برخی ویژگی‌ها در کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat) که به شما امکان کنترل رفتار autofit برای جعبه‌های متن در ارائه‌ها را می‌دهد.

## **تغییر شکل برای متناسب کردن متن**

اگر می‌خواهید متن داخل یک جعبه همیشه داخل همان جعبه بگنجد، باید از گزینه **Resize shape to fix text** استفاده کنید. برای تنظیم این ویژگی، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat)) را به `Shape` تنظیم کنید.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

این کد Java نشان می‌دهد که چگونه می‌توانید تعیین کنید متن همیشه داخل جعبه‌اش در یک ارائه PowerPoint متناسب شود:

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

اگر متن طولانی‌تر یا بزرگ‌تر شود، جعبه متن به‌صورت خودکار (ارتفاعش افزایش می‌یابد) تا تمام متن داخل آن جا بگیرد. اگر متن کوتاه‌تر شود، برعکس آن رخ می‌دهد.

## **عدم تنظیم خودکار**

اگر می‌خواهید یک جعبه متن یا شکل ابعاد خود را صرف‌نظر از تغییرات متن حفظ کند، باید از گزینه **Do not Autofit** استفاده کنید. برای تنظیم این ویژگی، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat)) را به `None` تنظیم کنید.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

این کد Java نشان می‌دهد که چگونه می‌توانید تعیین کنید جعبه متن ابعاد خود را در یک ارائه PowerPoint حفظ کند:

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

زمانی که متن بیش از حد طولانی شود، از جعبه خارج می‌شود.

## **کاهش متن در سرریز**

اگر متنی بیش از حد طولانی شود، با استفاده از گزینه **Shrink text on overflow** می‌توانید تعیین کنید اندازه و فاصلهٔ حروف کاهش یابند تا متن داخل جعبه بگنجد. برای تنظیم این ویژگی، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat)) را به `Normal` تنظیم کنید.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

این کد Java نشان می‌دهد که چگونه می‌توانید تعیین کنید متن در سرریز کوچک شود در یک ارائه PowerPoint:

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
هنگام استفاده از گزینه **Shrink text on overflow**، تنظیم فقط وقتی اعمال می‌شود که متن بیش از حد طولانی برای جعبهٔ خود شود.
{{% /alert %}}

## **پیچاندن متن**

اگر می‌خواهید متن داخل یک شکل زمانی که از مرزهای عرض شکل فراتر رود، درون همان شکل پیچیده شود، باید از پارامتر **Wrap text in shape** استفاده کنید. برای تنظیم این ویژگی، باید ویژگی [WrapText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat)) را به `true` تنظیم کنید.

این کد Java نشان می‌دهد چگونه می‌توانید تنظیم Wrap Text را در یک ارائه PowerPoint به کار ببرید:

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
اگر ویژگی `WrapText` را برای یک شکل به `False` تنظیم کنید، وقتی متن داخل شکل طولانی‌تر از عرض شکل شود، متن به‌صورت یک خط واحد از مرزهای شکل فراتر می‌رود. 
{{% /alert %}}

## **سوالات متداول**

**آیا حاشیه‌های داخلی فریم متن بر AutoFit تأثیر می‌گذارند؟**  
بله. Padding (حاشیه‌های داخلی) فضای قابل استفاده برای متن را کاهش می‌دهد، بنابراین AutoFit زودتر فعال می‌شود—فونت را کوچک‌تر یا شکل را زودتر تغییر اندازه می‌دهد. قبل از تنظیم AutoFit حاشیه‌ها را بررسی و تنظیم کنید.

**AutoFit چگونه با شکست خط‌های دستی و نرم تعامل دارد؟**  
شکست‌های اجباری در جای خود باقی می‌مانند و AutoFit اندازه فونت و فواصل را دور آن‌ها تنظیم می‌کند. حذف شکست‌های غیرضروری معمولاً نیاز AutoFit به کوچک‌کردن متن را کاهش می‌دهد.

**آیا تغییر فونت تم یا جایگزینی فونت بر نتایج AutoFit تأثیر دارد؟**  
بله. جایگزینی به فونتی با متریک‌های متفاوت عرض/ارتفاع گلیف‌ها را تغییر می‌دهد که می‌تواند عرض/ارتفاع متن را تغییر دهد و در نتیجه اندازه نهایی فونت و پیچاندن خطوط را تحت‌تاثیر قرار دهد. پس از هر تغییر یا جایگزینی فونت، اسلایدها را دوباره بررسی کنید.