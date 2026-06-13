---
title: جاسازی فونت‌ها در ارائه‌ها با استفاده از PHP
linktitle: جاسازی فونت
type: docs
weight: 40
url: /fa/php-java/embedded-font/
keywords:
- اضافه کردن فونت
- جاسازی فونت
- جاسازی فونت
- دریافت فونت جاسازی‌شده
- اضافه کردن فونت جاسازی‌شده
- حذف فونت جاسازی‌شده
- فشرده‌سازی فونت جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای PHP از طریق Java، فونت‌های TrueType را در ارائه‌های PowerPoint و OpenDocument جاسازی کنید تا رندر دقیق در تمام پلتفرم‌ها تضمین شود."
---
## **مقدمه**

**فونت‌های جاسازی‌شده در PowerPoint** زمانی مفید هستند که می‌خواهید ارائه‌ی شما در هر سیستم یا دستگاهی به‌درستی نمایش داده شود. اگر به‌دلیل خلاقیت در کار خود از یک فونت شخص ثالث یا غیراستاندارد استفاده کرده‌اید، دلایل بیشتری برای جاسازی فونت دارید. در غیر این صورت (بدون فونت‌های جاسازی‌شده)، متن‌ها یا اعداد در اسلایدها، چینش، سبک‌بندی و غیره ممکن است تغییر کند یا به مستطیل‌های گیج‌کننده تبدیل شود.

کلاس [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontsManager)، کلاس [FontData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontdata/) و کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) شامل بیشتر روش‌هایی هستند که برای کار با فونت‌های جاسازی‌شده در ارائه‌های PowerPoint نیاز دارید.

## **دریافت و حذف فونت‌های جاسازی‌شده**

Aspose.Slides متد [getEmbeddedFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (که توسط کلاس [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontsManager) ارائه می‌شود) را برای دریافت (یا کشف) فونت‌های جاسازی‌شده در یک ارائه فراهم می‌کند. برای حذف فونت‌ها، از متد [removeEmbeddedFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (که توسط همان کلاس ارائه می‌شود) استفاده می‌شود.

این کد PHP به شما نشان می‌دهد چگونه فونت‌های جاسازی‌شده را از یک ارائه دریافت و حذف کنید:

```php
  # یک شیء Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # یک اسلاید حاوی فریم متنی که از فونت جاسازی‌شده "FunSized" استفاده می‌کند را رندر می‌کند
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # تصویر را به‌صورت JPEG روی دیسک ذخیره می‌کند
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # تمام فونت‌های جاسازی‌شده را دریافت می‌کند
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # فونت "Calibri" را پیدا می‌کند
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # فونت "Calibri" را حذف می‌کند
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # ارائه را رندر می‌کند؛ فونت "Calibri" با یک فونت موجود جایگزین می‌شود
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # تصویر را به‌صورت JPEG روی دیسک ذخیره می‌کند
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # ارائه را بدون فونت جاسازی‌شده "Calibri" روی دیسک ذخیره می‌کند
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اضافه کردن فونت‌های جاسازی‌شده**

با استفاده از کلاس [EmbedFontCharacters](https://reference.aspose.com/slides/fa/php-java/aspose.slides/embedfontcharacters/) و دو overload از متد [addEmbeddedFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#addEmbeddedFont)، می‌توانید قانون (جاسازی) مورد نظر خود را برای جاسازی فونت‌ها در یک ارائه انتخاب کنید. این کد PHP به شما نشان می‌دهد چگونه فونت‌ها را در یک ارائه جاسازی و اضافه کنید:

```php
  # ارائه را بارگذاری می‌کند
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **فشرده‌سازی فونت‌های جاسازی‌شده**

برای این‌که بتوانید فونت‌های جاسازی‌شده در یک ارائه را فشرده کنید و حجم فایل آن را کاهش دهید، Aspose.Slides متد [compressEmbeddedFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#compressEmbeddedFonts) (که توسط کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) ارائه می‌شود) را فراهم می‌کند.

این کد PHP به شما نشان می‌دهد چگونه فونت‌های جاسازی‌شده PowerPoint را فشرده کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**چگونه می‌توانم بفهمم که یک فونت خاص در ارائه حتی با وجود جاسازی هنگام رندر جایگزین می‌شود؟**

اطلاعات [جایگزینی](/slides/fa/php-java/font-substitution/) را در مدیر فونت‌ها و قوانین [پشتیبان/جایگزینی](/slides/fa/php-java/fallback-font/) بررسی کنید: اگر فونت در دسترس نباشد یا محدود باشد، یک فونت پشتیبان استفاده خواهد شد.

**آیا جاسازی فونت‌های «سیستمی» مانند Arial/Calibri ارزش دارد؟**

معمولاً نه—این فونت‌ها تقریباً همیشه در دسترس هستند. اما برای قابلیت حمل کامل در محیط‌های «کم‌حجم» (Docker، سرور لینوکسی بدون فونت‌های پیش‌نصب شده)، جاسازی فونت‌های سیستمی می‌تواند خطر جایگزینی‌های ناخواسته را از بین ببرد.