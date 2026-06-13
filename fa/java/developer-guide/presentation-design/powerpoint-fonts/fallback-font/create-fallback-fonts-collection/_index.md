---
title: پیکربندی مجموعه‌های قلم جایگزین در جاوا
linktitle: مجموعه قلم جایگزین
type: docs
weight: 20
url: /fa/java/create-fallback-fonts-collection/
keywords:
- قلم جایگزین
- قانون جایگزین
- مجموعه قلم
- پیکربندی قلم
- راه‌اندازی قلم
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یک مجموعه قلم‌های جایگزین را در Aspose.Slides برای جاوا تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument ثابت و واضح باقی بماند."
---
## **بررسی اجمالی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین قلم جایگزین برای یک ارائه را پیکربندی کنید. هر قانون جایگزین توسط کلاس `FontFallBackRule` نمایش داده می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود که اینترفیس `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید آن را به ویژگی `FontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` قلم‌ها را در سراسر ارائه کنترل می‌کند و هر نمونه `Presentation` دارای `FontsManager` خود است.

پس از اینکه `FontsManager` با مجموعه قلم‌های جایگزین مقداردهی اولیه شد، قلم‌های جایگزین مشخص شده در زمان رندر ارائه اعمال می‌شوند.

## **اعمال قوانین جایگزین**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRulesCollection) سازماندهی شوند که اینترفیس [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFontFallBackRulesCollection) را پیاده‌سازی می‌کند. امکان افزودن یا حذف قوانین از مجموعه وجود دارد.

سپس این مجموعه می‌تواند به متد [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRulesCollection) از کلاس [FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager) اختصاص یابد. FontsManager قلم‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) دارای متد [getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getFontsManager--) است که یک نمونه از کلاس [FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager) خود را دارد.

در اینجا یک مثال از چگونگی ایجاد مجموعه قوانین قلم‌های جایگزین و اختصاص آن به [FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getFontsManager--) یک ارائه خاص آمده است:  

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

پس از اینکه FontsManager با مجموعه قلم‌های جایگزین مقداردهی اولیه شد، قلم‌های جایگزین در زمان رندر ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
بیشتر بخوانید درباره [رندر ارائه با قلم جایگزین](/slides/fa/java/render-presentation-with-fallback-font/). 
{{% /alert %}}

## **سؤالات متداول**

**آیا قوانین جایگزین من در فایل PPTX تعبیه می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟**

خیر. قوانین جایگزین تنظیمات رندر زمان اجرا هستند؛ آنها در فایل PPTX سریال‌سازی نمی‌شوند و در رابط کاربری PowerPoint ظاهر نخواهند شد.

**آیا جایگزین بر متن داخل SmartArt، WordArt، نمودارها و جداول اعمال می‌شود؟**

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

**آیا Aspose هیچ قلمی را همراه با کتابخانه توزیع می‌کند؟**

خیر. شما قلم‌ها را به‌صورت محلی اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ خود شماست.

**آیا می‌توان جایگزینی/جایگزینی برای قلم‌های گم‌شده و جایگزین برای گلیف‌های گم‌شده را همزمان استفاده کرد؟**

بله. آنها مراحل مستقلی از همان خط لولهٔ حل فونت هستند: ابتدا موتور دسترسی به قلم‌ها را حل می‌کند ([جایگزینی](/slides/fa/java/font-replacement/)/[جایگزینی](/slides/fa/java/font-substitution/))، سپس جایگزین خلاهای گلیف‌های گم‌شده در قلم‌های موجود را پر می‌کند.