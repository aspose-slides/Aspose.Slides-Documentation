---
title: پیکربندی مجموعه‌های فونت جایگزین در PHP
linktitle: مجموعه فونت جایگزین
type: docs
weight: 20
url: /fa/php-java/create-fallback-fonts-collection/
keywords:
- فونت جایگزین
- قانون جایگزین
- مجموعه فونت
- پیکربندی فونت
- تنظیم فونت
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یک مجموعه فونت جایگزین را در Aspose.Slides برای PHP از طریق Java تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument یکنواخت و واضح باقی بماند."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین فونت جایگزین برای ارائه‌ پیکربندی کنید. هر قانون جایگزین توسط کلاس `FontFallBackRule` نماینده شده و می‌تواند به `FontFallBackRulesCollection` اضافه شود.

پس از ایجاد مجموعه، می‌توانید آن را با استفاده از متد `setFontFallBackRulesCollection` از `FontsManager` ارائه‌ اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونهٔ `Presentation` دارای `FontsManager` خود است.

هنگامی که `FontsManager` با مجموعهٔ فونت‌های جایگزین مقداردهی اولیه شد، فونت‌های جایگزین مشخص شده در هنگام رندر ارائه اعمال می‌شوند.

## **اعمال قواعد جایگزین**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRule) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRulesCollection) سازماندهی شوند. می‌توان قوانین را به مجموعه افزود یا از آن حذف کرد.

سپس این مجموعه می‌تواند به متد [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRulesCollection) از کلاس [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontsManager) اختصاص یابد. FontsManager فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) دارای متد [getFontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#getFontsManager) است که نمونهٔ خاص خود از کلاس [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontsManager) را فراهم می‌کند.

در اینجا نمونه‌ای از نحوهٔ ایجاد مجموعهٔ قوانین فونت‌های جایگزین و اختصاص آن به [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#getFontsManager) یک ارائهٔ خاص آورده شده است:

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

پس از مقداردهی اولیهٔ FontsManager با مجموعهٔ فونت‌های جایگزین، فونت‌های جایگزین در هنگام رندر ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
اطلاعات بیشتر دربارهٔ نحوهٔ [Render Presentation with Fallback Font](/slides/fa/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **سوالات متداول**

**آیا قوانین جایگزین من در فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟**

خیر. قوانین جایگزین تنظیمات رندر زمان اجرا هستند؛ آنها به صورت سریالی به PPTX نوشته نمی‌شوند و در رابط کاربری PowerPoint ظاهر نمی‌شوند.

**آیا جایگزین برای متن داخل SmartArt، WordArt، نمودارها و جداول اعمال می‌شود؟**

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

**آیا Aspose فونت‌هایی همراه با کتابخانه توزیع می‌کند؟**

خیر. شما فونت‌ها را به صورت محلی اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ خود شماست.

**آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گمشده و جایگزین برای گلیف‌های گمشده را همزمان استفاده کرد؟**

بله. آنها مراحل مستقل در همان خط لولهٔ حل‌وفصل فونت هستند: ابتدا موتور در دسترس بودن فونت‌ها را ([replacement](/slides/fa/php-java/font-replacement/)/[substitution](/slides/fa/php-java/font-substitution/)) حل می‌کند، سپس جایگزین خالی‌های گلیف‌های گمشده را در فونت‌های موجود پر می‌سازد.