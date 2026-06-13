---
title: رندر ارائه‌ها با فونت‌های جایگزین در PHP
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/php-java/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر PowerPoint
- رندر ارائه
- رندر اسلاید
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های جایگزین در Aspose.Slides برای PHP از طریق Java – حفظ سازگاری متن در قالب‌های PPT، PPTX و ODP با نمونه‌های کد گام‌به‌گام."
---
## **بررسی کلی**

Aspose.Slides به شما امکان رندر ارائه‌ها را با استفاده از قوانین فونت جایگزین می‌دهد. این مقاله نشان می‌دهد چگونه یک مجموعهٔ قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا اضافه کردن فونت‌های جایگزین تغییر دهید و مجموعه را به متد `FontsManager::setFontFallBackRulesCollection` اختصاص دهید.

پس از اختصاص مجموعهٔ قوانین فونت جایگزین به `FontsManager` ارائه، این قوانین در طول عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نحوه استفاده از قوانین پیکربندی‌شده هنگام رندر تصویر کوچک یک اسلاید و ذخیره آن به صورت تصویر PNG را نشان می‌دهد.

## **رندر یک اسلاید با استفاده از قوانین فونت جایگزین**

مثال زیر شامل این مراحل است:

1. ما [مجموعهٔ قوانین فونت جایگزین را ایجاد می‌کنیم](/slides/fa/php-java/create-fallback-fonts-collection/).
1. یک قانون فونت جایگزین را [حذف]((https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-)) کنید و [addFallBackFonts]((https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)) را به قانون دیگر اضافه کنید.
1. مجموعهٔ قوانین را به متد [getFontsManager]((https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#getFontsManager--)).[getFontFallBackRulesCollection]((https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)) اختصاص دهید.
1. با استفاده از متد [Presentation.save]((https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#save-java.lang.String-int-)) می‌توانیم ارائه را در همان قالب ذخیره کنیم یا در قالب دیگری ذخیره کنیم. پس از تنظیم مجموعهٔ قوانین فونت جایگزین در [FontsManager]((https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontsManager))، این قوانین در هر عملیات روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```php
  # ایجاد یک نمونهٔ جدید از مجموعهٔ قوانین
  $rulesList = new FontFallBackRulesCollection();
  # ایجاد چندین قانون
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # تلاش برای حذف فونت جایگزین "Tahoma" از قوانین بارگذاری شده
    $fallBackRule->remove("Tahoma");
    # و به‌روزرسانی قوانین برای بازهٔ مشخص شده
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # همچنین می‌توانیم هر قانون موجود را از لیست حذف کنیم
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # اختصاص یک لیست قوانین آماده برای استفاده
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # رندر تصویر بندانگشتی با استفاده از مجموعهٔ قوانین اولیه و ذخیره به فرم JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # ذخیره تصویر بر روی دیسک با فرمت JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
برای اطلاعات بیشتر دربارهٔ نحوهٔ [تبدیل PPT و PPTX به JPG در PHP](/slides/fa/php-java/convert-powerpoint-to-jpg/) مطالعه کنید.
{{% /alert %}}