---
title: بهبود ارائه‌های شما با AutoFit در PHP
linktitle: تنظیمات Autofit
type: docs
weight: 30
url: /fa/php-java/manage-autofit-settings/
keywords:
- جعبه متن
- AutoFit
- عدم AutoFit
- منطبق‌سازی متن
- کوچک‌کردن متن
- شکست متن
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "تنظیمات AutoFit را در Aspose.Slides برای PHP مدیریت کنید تا نمایش متن در ارائه‌های PowerPoint و OpenDocument شما بهینه شود و قابلیت خوانایی محتوا بهبود یابد."
---
## **مقدمه**

به‌ طور پیش‌فرض، وقتی یک کادر متن اضافه می‌کنید، Microsoft PowerPoint از تنظیم **Resize shape to fix text** برای کادر متن استفاده می‌کند—به‌طور خودکار اندازه کادر متن را تغییر می‌دهد تا متن همیشه درون آن جا بگیرد.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* وقتی متن در کادر متن طولانی یا بزرگ‌تر می‌شود، PowerPoint به‌صورت خودکار کادر متن را بزرگ می‌کند—ارتفاع آن را افزایش می‌دهد—تا بتواند متن بیشتری را در خود جای دهد.  
* وقتی متن در کادر متن کوتاه یا کوچک‌تر می‌شود، PowerPoint به‌صورت خودکار کادر متن را کوچک می‌کند—ارتفاع آن را کاهش می‌دهد—تا فضای اضافه حذف شود.

در PowerPoint، ۴ پارامتر یا گزینه مهم وجود دارد که رفتار autofit برای یک کادر متن را کنترل می‌کند:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java گزینه‌های مشابهی ارائه می‌دهد—برخی ویژگی‌ها در کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat) که به شما امکان کنترل رفتار autofit برای کادرهای متن در ارائه‌ها را می‌دهد.

## **Resize a Shape to Fit Text**

اگر می‌خواهید متن در یک جعبه همیشه پس از تغییرات داخل متن در آن جعبه جا بگیرد، باید از گزینه **Resize shape to fix text** استفاده کنید. برای تعیین این تنظیم، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat)) را روی `Shape` تنظیم کنید.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

این کد PHP نشان می‌دهد که چگونه تنظیم کنید متن همیشه در جعبه خود در یک ارائه PowerPoint جا بگیرد:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

اگر متن طولانی یا بزرگ‌تر شود، کادر متن به‌صورت خودکار تغییر اندازه می‌دهد (ارتفاع افزایش می‌یابد) تا تمام متن درون آن جا بگیرد. اگر متن کوتاه‌تر شود، برعکس اتفاق می‌افتد.

## **Do Not Autofit**

اگر می‌خواهید یک کادر متن یا شکل ابعاد خود را صرف‌نظر از تغییرات متن حفظ کند، باید از گزینه **Do not Autofit** استفاده کنید. برای تعیین این تنظیم، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat#getAutofitType--) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat) روی `None` تنظیم کنید.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

این کد PHP نشان می‌دهد که چگونه تنظیم کنید یک کادر متن همیشه ابعاد خود را در یک ارائه PowerPoint حفظ کند:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

وقتی متن برای جعبه‌اش بیش از حد طولانی شود، از جعبه خارج می‌شود.

## **Shrink Text on Overflow**

اگر متنی برای جعبه‌اش بیش از حد طولانی باشد، با گزینه **Shrink text on overflow** می‌توانید مشخص کنید که اندازه و فاصله متن باید کاهش یابد تا در جعبه جا بگیرد. برای تعیین این تنظیم، ویژگی [AutofitType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat#getAutofitType--) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat) روی `Normal` تنظیم کنید.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

این کد PHP نشان می‌دهد که چگونه تنظیم کنید متن در هنگام سرریز کوچک شود در یک ارائه PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
وقتی گزینه **Shrink text on overflow** استفاده شود، تنظیم فقط زمانی اعمال می‌شود که متن برای جعبه‌اش بیش از حد طولانی شود.
{{% /alert %}}

## **Wrap Text**

اگر می‌خواهید متن داخل یک شکل وقتی بیش از حد عرض شکل شود، داخل همان شکل بسته‌بندی شود (فقط عرض)، باید از پارامتر **Wrap text in shape** استفاده کنید. برای تعیین این تنظیم، ویژگی [WrapText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat#getWrapText--) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrameFormat) روی `true` تنظیم کنید.

این کد PHP نشان می‌دهد که چگونه تنظیم Wrap Text را در یک ارائه PowerPoint استفاده کنید:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
اگر ویژگی `WrapText` را برای یک شکل روی `False` تنظیم کنید، وقتی متن داخل شکل طولانی‌تر از عرض شکل شود، متن در یک خط واحد به خارج از مرزهای شکل ادامه می‌یابد.
{{% /alert %}}

## **FAQ**

**آیا حاشیه‌های داخلی فریم متن بر AutoFit تأثیر می‌گذارد؟**

بله. Padding (حاشیه‌های داخلی) فضای قابل استفاده برای متن را کاهش می‌دهد، بنابراین AutoFit زودتر فعال می‌شود—اندازه قلم یا شکل را زودتر کوچک می‌کند. قبل از تنظیم AutoFit حاشیه‌ها را بررسی و تنظیم کنید.

**AutoFit چگونه با شکست‌های خط دستی و نرم تعامل دارد؟**

شکست‌های خط اجباری در مکان خود باقی می‌مانند و AutoFit اندازه قلم و فواصل را حول آن‌ها تنظیم می‌کند. حذف شکست‌های غیرضروری معمولاً نیاز AutoFit به کوچک‌سازی متن را کاهش می‌دهد.

**آیا تغییر فونت تم یا اعمال جایگزینی فونت بر نتایج AutoFit تأثیر دارد؟**

بله. جایگزینی به فونتی با متریک‌های گلیف متفاوت، عرض/ارتفاع متن را تغییر می‌دهد و می‌تواند اندازه نهایی قلم و بسته‌بندی خطوط را تحت تأثیر قرار دهد. پس از هر تغییر یا جایگزینی فونت، اسلایدها را مجدداً بررسی کنید.