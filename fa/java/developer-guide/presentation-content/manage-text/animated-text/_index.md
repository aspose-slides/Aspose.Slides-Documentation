---
title: انیمیشن متن پاورپوینت در جاوا
linktitle: متن متحرک
type: docs
weight: 60
url: /fa/java/animated-text/
keywords:
- متن انیمیشن‌دار
- انیمیشن متن
- پاراگراف انیمیشن‌دار
- انیمیشن پاراگراف
- اثر انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "متن پویا و انیمیشن‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java ایجاد کنید، همراه با مثال‌های کد Java بهینه‌ و آسان برای دنبال کردن."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با متن‌های متحرک در Aspose.Slides کار کنید با اعمال افکت‌های انیمیشن به پاراگراف‌های جداگانه و بازیابی افکت‌های قبلاً به پاراگراف‌ها در یک فریم متن اختصاص داده شده. این مقاله بر روش‌های API متمرکز است که برای افزودن انیمیشن در سطح پاراگراف و بررسی افکت‌های انیمیشن موجود در یک ارائه استفاده می‌شود.

## **افزودن افکت‌های انیمیشن به پاراگراف‌ها**

ما متد [**addEffect()**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) را به کلاس‌های [**Sequence**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Sequence) و [**ISequence**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISequence) افزودیم. این متد به شما اجازه می‌دهد تا افکت‌های انیمیشن را به یک پاراگراف واحد اضافه کنید. این کد نمونه نشان می‌دهد چگونه یک افکت انیمیشن را به یک پاراگراف اضافه کنید:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // پاراگراف را برای افزودن اثر انتخاب کنید
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // افزودن افکت انیمیشن Fly به پاراگراف انتخاب‌شده
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **دریافت افکت‌های انیمیشن پاراگراف‌ها**

ممکن است بخواهید افکت‌های انیمیشن اضافه شده به یک پاراگراف را کشف کنید — برای مثال، در یک سناریو می‌خواهید افکت‌های انیمیشن یک پاراگراف را به دست آورید زیرا قصد دارید این افکت‌ها را به پاراگراف یا شکل دیگری اعمال کنید.

Aspose.Slides برای Java به شما امکان می‌دهد تمام افکت‌های انیمیشن اعمال شده به پاراگراف‌های موجود در یک فریم متن (شکل) را دریافت کنید. این کد نمونه نشان می‌دهد چگونه افکت‌های انیمیشن را در یک پاراگراف دریافت کنید:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **سوالات متداول**

**انیمیشن‌های متن چگونه با انتقال اسلاید متفاوت هستند و آیا می‌توان آن‌ها را ترکیب کرد؟**

انیمیشن‌های متن رفتار اشیاء را در طول زمان روی یک اسلاید کنترل می‌کنند، در حالی که [transitions](/slides/fa/java/slide-transition/) نحوه تغییر اسلایدها را مدیریت می‌کنند. آن‌ها مستقل هستند و می‌توانند با هم استفاده شوند؛ ترتیب پخش توسط جدول زمان‌بندی انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متن هنگام صادرات به PDF یا تصاویر حفظ می‌شوند؟**

خیر. PDF و تصاویر رستری ثابت هستند، بنابراین فقط یک حالت ثابت از اسلاید بدون حرکت مشاهده می‌کنید. برای حفظ حرکت، از صادرات [video](/slides/fa/java/convert-powerpoint-to-video/) یا [HTML](/slides/fa/java/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در طرح‌بندی‌ها و اسلاید مستر کار می‌کنند؟**

افکت‌های اعمال شده به اشیاء طرح‌بندی/مستر به اسلایدها ارث‌بری می‌شوند، اما زمان‌بندی و تعامل آن‌ها با انیمیشن‌های سطح اسلاید بستگی به ترتیب نهایی در اسلاید دارد.