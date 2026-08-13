---
title: پیکربندی مجموعه‌های فونت فالبیک در اندروید
linktitle: مجموعه فونت فالبیک
type: docs
weight: 20
url: /fa/androidjava/create-fallback-fonts-collection/
keywords:
- فونت فالبیک
- قانون فالبیک
- مجموعه فونت
- پیکربندی فونت
- راه‌اندازی فونت
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یک مجموعه فونت فالبیک را در Aspose.Slides برای اندروید با استفاده از جاوا راه‌اندازی کنید تا متن در ارائه‌های PowerPoint و OpenDocument یکنواخت و واضح باقی بماند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قواعد فونت فالبیک برای یک ارائه پیکربندی کنید. هر قانون فالبیک توسط کلاس `FontFallBackRule` نمایش داده می‌شود و می‌تواند به `FontFallBackRulesCollection` افزوده شود که رابط `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید آن را به ویژگی `FontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر شیء `Presentation` دارای یک `FontsManager` اختصاصی است.

به محض این که `FontsManager` با مجموعه فونت فالبیک مقداردهی اولیه شود، فونت‌های فالبیک مشخص‌شده در حین رندر ارائه اعمال می‌گردند.

## **اعمال قوانین فالبیک**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRulesCollection) سازماندهی شوند که رابط [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IFontFallBackRulesCollection) را پیاده‌سازی می‌کند. امکان افزودن یا حذف قوانین از این مجموعه وجود دارد.

سپس این مجموعه می‌تواند به متد [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRulesCollection) کلاس [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager) واگذار شود. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) دارای متد [getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getFontsManager--) با یک نمونهٔ اختصاصی از کلاس [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager) است.

در اینجا یک مثال برای ایجاد مجموعه قوانین فونت فالبیک و اختصاص آن به [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getFontsManager--) یک ارائهٔ خاص آورده شده است:

```java
import com.aspose.slides.*;

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

پس از مقداردهی اولیه `FontsManager` با مجموعه فونت فالبیک، فونت‌های فالبیک در حین رندر ارائه اعمال می‌شوند.

{{% alert color="info" %}} 
اطلاعات بیشتر دربارهٔ نحوهٔ رندر ارائه با فونت فالبیک را در [Render Presentation with Fallback Font](/slides/fa/androidjava/render-presentation-with-fallback-font/) بخوانید.
{{% /alert %}}

## **سوالات متداول**

### آیا قوانین فالبیک من در فایل PPTX جاسازی می‌شوند و پس از ذخیره‌سازی در PowerPoint قابل مشاهده خواهند بود؟

خیر. قوانین فالبیک تنظیمات رندر در زمان اجرا هستند؛ آن‌ها به صورت سریالایز در PPTX ذخیره نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

### آیا فالبیک برای متن داخل SmartArt، WordArt، نمودارها و جدول‌ها اعمال می‌شود؟

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

### آیا Aspose همراه با کتابخانه فونتی توزیع می‌کند؟

خیر. شما فونت‌ها را به‌صورت محلی اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ شماست.

### آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گمشده و فالبیک برای گلیف‌های گمشده را همزمان استفاده کرد؟

بله. این دو مرحله مستقل در همان مسیر حل فونت هستند: ابتدا موتور در دسترس بودن فونت‌ها را حل می‌کند ([replacement](/slides/fa/androidjava/font-replacement/)/[substitution](/slides/fa/androidjava/font-substitution/))، سپس فالبیک شکاف‌های گلیف‌های گمشده را در فونت‌های موجود پر می‌کند.