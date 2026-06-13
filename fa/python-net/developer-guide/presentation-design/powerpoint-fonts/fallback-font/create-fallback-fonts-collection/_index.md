---
title: پیکربندی مجموعه‌های قلم بازگردانی در پایتون
linktitle: مجموعه قلم بازگردانی
type: docs
weight: 20
url: /fa/python-net/create-fallback-fonts-collection/
keywords:
- قلم بازگردانی
- قانون بازگردانی
- مجموعه قلم
- پیکربندی قلم
- تنظیم قلم
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یک مجموعه قلم بازگردانی را در Aspose.Slides برای پایتون via .NET تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument ثابت و واضح باشد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین قلم بازگردانی را برای یک ارائه پیکربندی کنید. هر قانون بازگردانی توسط کلاس `FontFallBackRule` نمایانده می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود.

پس از ایجاد مجموعه، می‌توانید آن را به ویژگی `font_fall_back_rules_collection` از `fonts_manager` ارائه اختصاص دهید. `fonts_manager` قلم‌ها را در سراسر ارائه کنترل می‌کند و هر نمونه `Presentation` دارای یک `FontsManager` riêng خود است.

هنگامی که `FontsManager` با مجموعه قلم‌های بازگردانی مقداردهی اولیه شد، قلم‌های بازگردانی مشخص شده در طول رندر ارائه اعمال می‌شوند.

## **اعمال قوانین بازگردانی**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/python-net/aspose.slides/FontFallBackRule/) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontfallbackrulescollection/) سازماندهی شوند. می‌توان قوانین را به مجموعه اضافه یا از آن حذف کرد.

سپس این مجموعه می‌تواند به ویژگی [font_fall_back_rules_collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/) اختصاص یابد. FontsManager قلم‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دارای ویژگی [fonts_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/fonts_manager/) است که یک نمونه از کلاس FontsManager را در خود دارد.

در اینجا یک مثال از نحوه ایجاد مجموعه قوانین قلم‌های بازگردانی و اختصاص آن به FontsManager یک ارائه خاص آورده شده است:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

پس از مقداردهی اولیه FontsManager با مجموعه قلم‌های بازگردانی، قلم‌های بازگردانی در طول رندر ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
بیشتر بخوانید نحوهٔ [رندر ارائه با قلم بازگردانی](/slides/fa/python-net/render-presentation-with-fallback-font/). 
{{% /alert %}}

## **پرسش‌های متداول**

**آیا قوانین بازگردانی من در فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده هستند؟**

خیر. قوانین بازگردانی تنظیمات رندر زمان اجرا هستند؛ آن‌ها به فایل PPTX سریال‌سازی نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نخواهند شد.

**آیا بازگردانی برای متن داخل SmartArt، WordArt، نمودارها و جدول‌ها اعمال می‌شود؟**

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

**آیا Aspose هیچ قلمی را همراه کتابخانه توزیع می‌کند؟**

خیر. شما قلم‌ها را از سمت خود اضافه و استفاده می‌کنید و مسئولیت آن به عهده شماست.

**آیا می‌توان جایگزینی/جایگزینی فونت‌های گم‌شده و بازگردانی برای گلیف‌های گم‌شده را همزمان استفاده کرد؟**

بله. این‌ها مراحل مستقلی از همان لوله‌کشی حل فونت هستند: ابتدا موتور در دسترس بودن فونت‌ها را ([replacement](/slides/fa/python-net/font-replacement/)/[substitution](/slides/fa/python-net/font-substitution/)) حل می‌کند، سپس بازگردانی برای پر کردن فاصله‌های گلیف‌های گم‌شده در فونت‌های موجود استفاده می‌شود.