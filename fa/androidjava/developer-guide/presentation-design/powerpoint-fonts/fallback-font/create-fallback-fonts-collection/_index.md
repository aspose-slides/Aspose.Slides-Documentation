---
title: پیکربندی مجموعه‌های فونت بازگشتی در Android
linktitle: مجموعه فونت بازگشتی
type: docs
weight: 20
url: /fa/androidjava/create-fallback-fonts-collection/
keywords:
- فونت بازگشتی
- قانون بازگشتی
- مجموعه فونت
- پیکربندی فونت
- تنظیم فونت
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یک مجموعه فونت‌های بازگشتی را در Aspose.Slides برای Android از طریق Java تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument ثابت و واضح باشد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان پیکربندی مجموعه‌ای از قوانین فونت بازگشتی برای یک ارائه را می‌دهد. هر قانون بازگشتی توسط کلاس `FontFallBackRule` نمایانده می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود که اینترفیس `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ساخت مجموعه، می‌توانید آن را به ویژگی `FontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونهٔ `Presentation` دارای `FontsManager` خود است.

زمانی که `FontsManager` با مجموعهٔ فونت‌های بازگشتی مقداردهی اولیه شود، فونت‌های بازگشتی مشخص‌شده در طول رندر ارائه اعمال می‌شوند.

## **اعمال قوانین بازگشتی**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRulesCollection) که اینترفیس [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IFontFallBackRulesCollection) را پیاده‌سازی می‌کند، سازماندهی شوند. امکان اضافه یا حذف قوانین از مجموعه وجود دارد.

سپس این مجموعه می‌تواند به متد [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRulesCollection) از کلاس [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager) اختصاص یابد. FontsManager فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) دارای متد [getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getFontsManager--) است که نمونهٔ خاص خود از کلاس [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager) را باز می‌گرداند.

در اینجا مثال‌هایی برای ایجاد مجموعهٔ قوانین فونت‌های بازگشتی و اختصاص آن به [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getFontsManager--) یک ارائهٔ خاص آورده شده است:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

پس از این‌که FontsManager با مجموعهٔ فونت‌های بازگشتی مقداردهی اولیه شد، فونت‌های بازگشتی در طول رندر ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
بیشتر بخوانید دربارهٔ نحوهٔ [Render Presentation with Fallback Font](/slides/fa/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **سوالات متداول**

**آیا قوانین بازگشتی من در فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟**

خیر. قوانین بازگشتی تنظیمات رندر در زمان اجرا هستند؛ آنها به صورت سریالایز در فایل PPTX ذخیره نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

**آیا بازگشت به فونت برای متن داخل SmartArt، WordArt، نمودارها و جدول‌ها اعمال می‌شود؟**

بله. همان سازوکار جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

**آیا Aspose فونت‌هایی همراه کتابخانه توزیع می‌کند؟**

خیر. شما خودتان فونت‌ها را اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ شماست.

**آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گمشده و بازگشت به فونت برای گلیف‌های گمشده را به‌طور همزمان استفاده کرد؟**

بله. این‌ها مراحل مستقلی از همان خط لولهٔ حل فونت هستند: ابتدا Engine در دسترس بودن فونت‌ها را با ([replacement](/slides/fa/androidjava/font-replacement/)/[substitution](/slides/fa/androidjava/font-substitution/)) حل می‌کند، سپس بازگشت به فونت خلایف گلیف‌های گمشده در فونت‌های موجود را پر می‌کند.