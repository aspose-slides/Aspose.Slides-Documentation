---
title: پویانمایی متن PowerPoint در C++
linktitle: متن پویا
type: docs
weight: 60
url: /fa/cpp/animated-text/
keywords:
- متن پویا
- انیمیشن متن
- پاراگراف پویا
- انیمیشن پاراگراف
- اثر انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "متن پویا و دینامیک را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ ایجاد کنید، همراه با مثال‌های کد C++ بهینه و مبتنی بر راهنمایی گام به گام."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با متن‌های متحرک در Aspose.Slides کار کنیم با اعمال افکت‌های انیمیشن به پاراگراف‌های جداگانه و دریافت افکت‌هایی که قبلاً به پاراگراف‌ها در یک فریم متن اختصاص داده شده‌اند. تمرکز این مقاله بر روش‌های API برای افزودن انیمیشن در سطح پاراگراف و بررسی افکت‌های انیمیشن موجود برای پاراگراف‌ها در یک ارائه است.

## **افزودن افکت‌های انیمیشن به پاراگراف‌ها**

ما روش [**AddEffect()**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) را به کلاس‌های [**Sequence**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.sequence) و [**ISequence**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.i_sequence) اضافه کردیم. این روش به شما امکان می‌دهد افکت‌های انیمیشن را به یک پاراگراف اضافه کنید. این کد نمونه نشان می‌دهد چگونه یک افکت انیمیشن را به یک پاراگراف اضافه کنید:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// انتخاب پاراگراف برای افزودن افکت
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// افزودن افکت انیمیشن Fly به پاراگراف انتخاب شده
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **دریافت افکت‌های انیمیشن برای پاراگراف‌ها**

ممکن است بخواهید افکت‌های انیمیشن اضافه شده به یک پاراگراف را بیابید؛ برای مثال، در یک سناریو ممکن است بخواهید افکت‌های انیمیشن یک پاراگراف را دریافت کنید زیرا قصد دارید آن افکت‌ها را به پاراگراف یا شکل دیگری اعمال کنید.

Aspose.Slides برای C++ به شما امکان می‌دهد تمام افکت‌های انیمیشن اعمال شده به پاراگراف‌های موجود در یک فریم متن (شکل) را دریافت کنید. این کد نمونه نشان می‌دهد چگونه افکت‌های انیمیشن را در یک پاراگراف دریافت کنید:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **سوالات متداول**

**چگونه انیمیشن‌های متن با انتقال‌های اسلاید متفاوت هستند و آیا می‌توان آن‌ها را ترکیب کرد؟**

انیمیشن‌های متن رفتار شی را در طول زمان روی یک اسلاید کنترل می‌کنند، در حالی که [transitions](/slides/fa/cpp/slide-transition/) نحوه تغییر اسلایدها را مدیریت می‌کنند. این دو مستقل هستند و می‌توانند با هم استفاده شوند؛ ترتیب پخش توسط زمان‌بندی انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متن هنگام استخراج به PDF یا تصاویر حفظ می‌شوند؟**

خیر. PDF و تصاویر رستری ثابت هستند، بنابراین تنها یک حالت ثابت از اسلاید بدون حرکت مشاهده می‌کنید. برای حفظ حرکت، از استخراج [video](/slides/fa/cpp/convert-powerpoint-to-video/) یا [HTML](/slides/fa/cpp/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در چیدمان‌ها و اسلاید مستر کار می‌کنند؟**

افکت‌های اعمال شده به اشیاء چیدمان/مستر به اسلایدها ارث می‌رسند، اما زمان‌بندی آن‌ها و تعامل با انیمیشن‌های سطح اسلاید بستگی به ترتیب نهایی در اسلاید دارد.