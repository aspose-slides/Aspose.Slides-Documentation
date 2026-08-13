---
title: پیکربندی مجموعه‌های فونت پشتیبان در .NET
linktitle: مجموعه فونت پشتیبان
type: docs
weight: 20
url: /fa/net/create-fallback-fonts-collection/
keywords:
- فونت پشتیبان
- قانون پشتیبان
- مجموعه فونت
- پیکربندی فونت
- راه‌اندازی فونت
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یک مجموعه فونت‌های پشتیبان را در Aspose.Slides برای .NET تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument ثابت و واضح باقی بماند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین فونت‌پشتیبان را برای یک ارائه پیکربندی کنید. هر قانون پشتیبان توسط کلاس `FontFallBackRule` نمایانده می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود، که اینترفیس `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید آن را به ویژگی `FontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونه `Presentation` مدیریت‌کننده فونت‌های خود را دارد.

زمانی که `FontsManager` با مجموعه فونت‌های پشتیبان مقداردهی اولیه شد، فونت‌های پشتیبان مشخص‌شده در طول رندر ارائه اعمال می‌شوند.

## **اعمال قوانین پشتیبان**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrulescollection) که اینترفیس [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontfallbackrulescollection) را پیاده‌سازی می‌کند سازماندهی شوند. امکان افزودن یا حذف قوانین از مجموعه وجود دارد.

سپس این مجموعه می‌تواند به ویژگی [FontFallBackRulesCollection ](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) از کلاس [FontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager) اختصاص داده شود. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) یک ویژگی [FontsManager ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/properties/fontsmanager) دارای نمونهٔ خود از کلاس `FontsManager` دارد.

در این‌جا یک مثال برای ایجاد مجموعه قوانین فونت‌های پشتیبان و اختصاص آن به `FontsManager` یک ارائهٔ خاص آمده است:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

پس از مقداردهی اولیه `FontsManager` با مجموعه فونت‌های پشتیبان، فونت‌های پشتیبان در طول رندر ارائه اعمال می‌شوند.

{{% alert color="info" %}} 
بیشتر بخوانید چگونگی [رندر ارائه با فونت پشتیبان](/slides/fa/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **سوالات متداول**

### آیا قوانین پشتیبان من در فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟

نه. قوانین پشتیبان تنظیمات رندر زمان اجرا هستند؛ آن‌ها در PPTX سریال‌سازی نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

### آیا پشتیبان برای متن داخل SmartArt، WordArt، نمودارها و جدول‌ها اعمال می‌شود؟

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

### آیا Aspose فونتی را همراه با کتابخانه توزیع می‌کند؟

نه. شما فونت‌ها را خودتان اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ شماست.

### آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گمشده و پشتیبان برای گلیف‌های گمشده را همزمان استفاده کرد؟

بله. این‌ها مراحل مستقل در همان خط لولهٔ حل فونت هستند: ابتدا موتور در دسترس بودن فونت را حل می‌کند ([replacement](/slides/fa/net/font-replacement/)/[substitution](/slides/fa/net/font-substitution/)) و سپس پشتیبان برای گلیف‌های گمشده در فونت‌های موجود پرتو می‌کند.