---
title: پیکربندی مجموعه‌های فونت جایگزین در .NET
linktitle: مجموعه فونت جایگزین
type: docs
weight: 20
url: /fa/net/create-fallback-fonts-collection/
keywords:
- فونت جایگزین
- قانون جایگزین
- مجموعه فونت
- پیکربندی فونت
- راه‌اندازی فونت
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یک مجموعه فونت‌های جایگزین در Aspose.Slides برای .NET تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument یکنواخت و واضح بماند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین فونت جایگزین برای یک ارائه پیکربندی کنید. هر قانون جایگزین توسط کلاس `FontFallBackRule` نماینده می‌شود و می‌تواند به `FontFallBackRulesCollection` افزوده شود که رابط `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید آن را به ویژگی `FontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونه `Presentation` دارای `FontsManager` خود است.

هنگامی که `FontsManager` با مجموعه فونت‌های جایگزین مقداردهی اولیه شد، فونت‌های جایگزین مشخص‌شده در هنگام رندر ارائه اعمال می‌شوند.

## **اعمال قوانین جایگزین**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrulescollection) سازماندهی شوند که رابط [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontfallbackrulescollection) را پیاده‌سازی می‌کند. امکان افزودن یا حذف قوانین از مجموعه وجود دارد.

سپس این مجموعه می‌تواند به ویژگی [FontFallBackRulesCollection ](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)property از کلاس [FontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager) اختصاص داده شود. FontsManager فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) دارای ویژگی [FontsManager ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/properties/fontsmanager) است که نمونه خود از کلاس FontsManager را دارد.

در ادامه نمونه‌ای از نحوه ایجاد مجموعه قوانین فونت جایگزین و اختصاص آن به FontsManager یک ارائه خاص آورده شده است:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

پس از مقداردهی اولیه FontsManager با مجموعه فونت‌های جایگزین، فونت‌های جایگزین در هنگام رندر ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
برای اطلاعات بیشتر درباره نحوه [رندر ارائه با فونت جایگزین](/slides/fa/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **پرسش‌های متداول**

**آیا قوانین جایگزین من در فایل PPTX تعبیه می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟**

خیر. قوانین جایگزین تنظیمات رندر زمان اجرا هستند؛ آن‌ها به فایل PPTX سریالایز نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

**آیا جایگزین برای متنی که در SmartArt، WordArt، نمودارها و جداول قرار دارد اعمال می‌شود؟**

بله. همان مکانیزم تعویض گلایف برای هر متنی در این اشیا استفاده می‌شود.

**آیا Aspose هیچ فونتی به همراه کتابخانه توزیع می‌کند؟**

خیر. شما فونت‌ها را به‌صورت محلی اضافه و استفاده می‌کنید و مسئولیت آن بر عهده شماست.

**آیا می‌توان جایگزینی/تعویض برای فونت‌های گمشده و جایگزینی برای گلیف‌های ناقص را همزمان استفاده کرد؟**

بله. آن‌ها مراحل مستقل در یک خط لوله‌ی حل فونت هستند: ابتدا موتور در دسترس بودن فونت‌ها را با استفاده از ([replacement](/slides/fa/net/font-replacement/)/[substitution](/slides/fa/net/font-substitution/)) حل می‌کند، سپس جایگزین شکست‌های گلیف‌های گمشده را در فونت‌های موجود پر می‌کند.