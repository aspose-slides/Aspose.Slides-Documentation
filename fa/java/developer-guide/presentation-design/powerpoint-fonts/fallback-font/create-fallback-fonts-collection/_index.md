---
title: پیکربندی مجموعه‌های فونت جایگزین در جاوا
linktitle: مجموعه فونت جایگزین
type: docs
weight: 20
url: /fa/java/create-fallback-fonts-collection/
keywords:
- فونت جایگزین
- قانون جایگزین
- مجموعه فونت
- پیکربندی فونت
- راه‌اندازی فونت
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یک مجموعه فونت‌های جایگزین را در Aspose.Slides برای جاوا تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument یکنواخت و واضح باشد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین فونت جایگزین برای یک ارائه پیکربندی کنید. هر قانون جایگزین توسط کلاس `FontFallBackRule` نشان داده می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود که اینترفیس `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید آن را به ویژگی `FontFallBackRulesCollection` در `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونهٔ `Presentation` دارای `FontsManager` خودش است.

به‌محض اینکه `FontsManager` با مجموعهٔ فونت‌های جایگزین مقداردهی اولیه شود، فونت‌های جایگزین مشخص‌شده در هنگام رندر ارائه اعمال می‌شوند.

## **اعمال قوانین جایگزین**

نمونه‌های کلاس[FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) می‌توانند در[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRulesCollection) سازماندهی شوند که اینترفیس[IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFontFallBackRulesCollection) را پیاده‌سازی می‌کند. می‌توان قوانین را به مجموعه اضافه یا از آن حذف کرد.

سپس این مجموعه می‌تواند به متد[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRulesCollection) در کلاس[FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager) اختصاص یابد. FontsManager فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر[Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) دارای متد[getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getFontsManager--) است که یک نمونهٔ مخصوص از کلاس[FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager) را باز می‌گرداند.

در زیر نمونه‌ای از چگونگی ایجاد مجموعه قوانین فونت جایگزین و اختصاص آن به[FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getFontsManager--) یک ارائهٔ خاص آورده شده است:  

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

پس از اینکه FontsManager با مجموعهٔ فونت‌های جایگزین مقداردهی اولیه شد، فونت‌های جایگزین در هنگام رندر ارائه اعمال می‌شوند.

{{% alert color="info" %}} 
برای اطلاعات بیشتر نحوهٔ[رندر ارائه با فونت جایگزین](/slides/fa/java/render-presentation-with-fallback-font/) را بخوانید.
{{% /alert %}}

## **سؤالات متداول**

### آیا قوانین جایگزین من در فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟

خیر. قوانین جایگزین تنظیمات رندر در زمان اجرا هستند؛ آن‌ها به‌صورت سریالی در PPTX ذخیره نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نخواهند شد.

### آیا جایگزین برای متن داخل SmartArt، WordArt، نمودارها و جداول اعمال می‌شود؟

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء به‌کار گرفته می‌شود.

### آیا Aspose هیچ فونتی با کتابخانه توزیع می‌کند؟

خیر. شما فونت‌ها را خودتان اضافه و استفاده می‌کنید و مسئولیت آن به عهدهٔ شماست.

### آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گمشده و جایگزین برای گلیف‌های گمشده را با هم استفاده کرد؟

بله. آن‌ها مراحل مستقل در همان مسیر حل فونت هستند: ابتدا موتور موجودیت فونت‌ها را حل می‌کند ([جایگزینی](/slides/fa/java/font-replacement/)/[جایگزینی](/slides/fa/java/font-substitution/))، سپس جایگزین خلاها را برای گلیف‌های گمشده در فونت‌های موجود پر می‌کند.