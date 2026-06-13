---
title: پیکربندی مجموعه‌های فونت جایگزین در JavaScript
linktitle: مجموعه فونت جایگزین
type: docs
weight: 20
url: /fa/nodejs-java/create-fallback-fonts-collection/
keywords:
- فونت جایگزین
- قاعده جایگزین
- مجموعه فونت
- پیکربندی فونت
- راه‌اندازی فونت
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یک مجموعه فونت‌های جایگزین را در JavaScript با Aspose.Slides برای Node.js تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument ثابت و واضح باشد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قواعد فونت جایگزین برای یک ارائه پیکربندی کنید. هر قاعده جایگزین توسط کلاس `FontFallBackRule` نمایش داده می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود.

پس از ایجاد مجموعه، می‌توانید آن را با استفاده از متد `setFontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در کل ارائه کنترل می‌کند و هر نمونهٔ `Presentation` دارای یک `FontsManager` اختصاصی است.

زمانی که `FontsManager` با مجموعهٔ فونت‌های جایگزین مقداردهی اولیه شد، فونت‌های جایگزین مشخص شده در هنگام رندر ارائه اعمال می‌شوند.

## **اعمال قواعد جایگزین**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRulesCollection) سازماندهی شوند که پیاده‌سازی کلاس [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRulesCollection) است. امکان اضافه یا حذف قواعد از مجموعه وجود دارد.

سپس این مجموعه می‌تواند به متد [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRulesCollection) کلاس [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontsManager) اختصاص داده شود. FontsManager فونت‌ها را در کل ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) یک متد [getFontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getFontsManager--) دارای یک نمونهٔ کلاس [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontsManager) است.

در ادامه نمونه‌ای از چگونگی ایجاد مجموعه قواعد فونت جایگزین و اختصاص آن به [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getFontsManager--) یک ارائهٔ خاص آورده شده است:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

پس از مقداردهی اولیه FontsManager با مجموعهٔ فونت‌های جایگزین، این فونت‌ها در هنگام رندر ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
برای اطلاعات بیشتر به مقالهٔ [Render Presentation with Fallback Font](/slides/fa/nodejs-java/render-presentation-with-fallback-font/) مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا قواعد جایگزین من به فایل PPTX تعبیه می‌شود و پس از ذخیره در PowerPoint قابل مشاهده است؟**

نه. قواعد جایگزین تنظیمات رندر زمان اجرا هستند؛ آن‌ها به فایل PPTX سریال‌سازی نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

**آیا جایگزینی به متن داخل SmartArt، WordArt، نمودارها و جدول‌ها اعمال می‌شود؟**

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

**آیا Aspose فونتی را همراه کتابخانه توزیع می‌کند؟**

نه. شما فونت‌ها را خودتان اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ خود شماست.

**آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گمشده و جایگزینی برای گلیف‌های مفقود را همزمان استفاده کرد؟**

بله. این‌ها مراحل مستقلی از یک خط لولهٔ حل فونت هستند: ابتدا موتور در دسترس بودن فونت را حل می‌کند ([replacement](/slides/fa/nodejs-java/font-replacement/)/[substitution](/slides/fa/nodejs-java/font-substitution/))، سپس جایگزینی فواصل گلیف‌های مفقود در فونت‌های موجود را پر می‌کند.