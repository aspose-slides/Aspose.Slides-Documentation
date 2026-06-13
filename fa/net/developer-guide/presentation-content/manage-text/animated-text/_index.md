---
title: انیمیشن متن PowerPoint در .NET
linktitle: متن انیمیشن شده
type: docs
weight: 60
url: /fa/net/animated-text/
keywords:
- متن انیمیشن شده
- انیمیشن متن
- پاراگراف انیمیشن شده
- انیمیشن پاراگراف
- افکت انیمیشن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "متن‌های دینامیک انیمیشن‌شده را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET ایجاد کنید، به همراه مثال‌های کد C# به‌صورت آسان و بهینه."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان با متن‌های متحرک در Aspose.Slides کار کرد، با اعمال افکت‌های انیمیشن به پاراگراف‌های جداگانه و بازیابی افکت‌هایی که قبلاً به پاراگراف‌های موجود در یک فریم متن اختصاص یافته‌اند. تمرکز این مقاله بر روش‌های API است که برای افزودن انیمیشن در سطح پاراگراف و بررسی افکت‌های انیمیشن موجود در یک ارائه استفاده می‌شوند.

## **افکت‌های انیمیشن را به پاراگراف‌ها اضافه کنید**

ما متد [**AddEffect()**](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/sequence/methods/addeffect/index) را به کلاس‌های [**Sequence**](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/sequence) و [**ISequence**](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence) اضافه کردیم. این متد به شما امکان می‌دهد تا افکت‌های انیمیشن را به یک پاراگراف واحد اضافه کنید. این کد نمونه نشان می‌دهد چگونه یک افکت انیمیشن را به یک پاراگراف اضافه کنید:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // پاراگراف را برای افزودن افکت انتخاب کنید
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // افکت انیمیشن Fly را به پاراگراف انتخاب شده اضافه کنید
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **دریافت افکت‌های انیمیشن برای پاراگراف‌ها**

ممکن است بخواهید افکت‌های انیمیشنی که به یک پاراگراف اضافه شده‌اند را پیدا کنید—به عنوان مثال، در یک سناریو می‌خواهید افکت‌های انیمیشن یک پاراگراف را دریافت کنید زیرا قصد دارید این افکت‌ها را به پاراگراف یا شکلی دیگر اعمال کنید.

Aspose.Slides برای .NET به شما امکان می‌دهد تمام افکت‌های انیمیشنی که به پاراگراف‌های موجود در یک فریم متن (شکل) اعمال شده‌اند را دریافت کنید. این کد نمونه نشان می‌دهد چگونه افکت‌های انیمیشن را در یک پاراگراف دریافت کنید:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **سوالات متداول**

**انیمیشن‌های متن چگونه با انتقالات اسلاید متفاوت هستند و آیا می‌توان آن‌ها را ترکیب کرد؟**

انیمیشن‌های متن رفتار اشیا را در طول زمان روی یک اسلاید کنترل می‌کنند، در حالی که [انتقالات](/slides/fa/net/slide-transition/) نحوه تغییر اسلایدها را کنترل می‌کنند. این دو مستقل هستند و می‌توانند با هم استفاده شوند؛ ترتیب پخش توسط زمان‌بندی انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متن هنگام خروجی به PDF یا تصویر حفظ می‌شوند؟**

خیر. PDF و تصاویر رستر ثابت هستند، بنابراین تنها یک حالت از اسلاید بدون حرکت نمایش داده می‌شود. برای حفظ حرکت، از خروجی [ویدیو](/slides/fa/net/convert-powerpoint-to-video/) یا [HTML](/slides/fa/net/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در چیدمان‌ها و اسلاید مستر کار می‌کنند؟**

افکت‌های اعمال شده به اشیای چیدمان/مستر به اسلایدها ارث می‌رسند، اما زمان‌بندی آن‌ها و تعاملشان با انیمیشن‌های سطح اسلاید به توالی نهایی در اسلاید بستگی دارد.