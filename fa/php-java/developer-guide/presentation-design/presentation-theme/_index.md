---
title: مدیریت تم‌های ارائه در PHP
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/php-java/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- فونت تم
- سبک تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "در Aspose.Slides برای PHP از طریق Java، تم‌های ارائه اصلی را برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان مدیریت کنید."
---
## **مقدمه**

یک تم ارائه ویژگی‌های عناصر طراحی را تعریف می‌کند. وقتی یک تم ارائه را انتخاب می‌کنید، در واقع مجموعه‌ای خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در PowerPoint، یک تم شامل رنگ‌ها، [فونت‌ها](/slides/fa/php-java/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/php-java/presentation-background/)، و افکت‌ها است.

![theme-constituents](theme-constituents.png)

## **تغییر رنگ تم**

یک تم PowerPoint برای عناصر مختلف در یک اسلاید مجموعه‌ای خاص از رنگ‌ها را به کار می‌برد. اگر از این رنگ‌ها راضی نیستید، می‌توانید با اعمال رنگ‌های جدید برای تم، آنها را تغییر دهید. برای این که بتوانید یک رنگ تم جدید را انتخاب کنید، Aspose.Slides مقادیر را تحت شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SchemeColor) ارائه می‌دهد.

این کد PHP نشان می‌دهد که چگونه رنگ تأکید را برای یک تم تغییر دهید:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

به این روش می‌توانید مقدار موثر رنگ حاصل را تعیین کنید:
```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

برای نشان دادن بیشتر عملیات تغییر رنگ، عنصر دیگری ایجاد می‌کنیم و رنگ تأکید (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ را در تم تغییر می‌دهیم:
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از یک پالت اضافی**

وقتی تبدیل‌های روشنایی را بر رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌هایی از پالت اضافی (2) تشکیل می‌شود. سپس می‌توانید این رنگ‌های تم را تنظیم و دریافت کنید.

![additional-palette-colors](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم  

**2** - رنگ‌های پالت اضافی.

این کد PHP عملیاتی را نشان می‌دهد که در آن رنگ‌های پالت اضافی از رنگ اصلی تم به دست می‌آیند و سپس در اشکال استفاده می‌شوند:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # اکسنت ۴
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # اکسنت ۴، روشن‌تر ۸۰٪
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # اکسنت ۴، روشن‌تر ۶۰٪
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # اکسنت ۴، روشن‌تر ۴۰٪
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # اکسنت ۴، تاریک‌تر ۲۵٪
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # اکسنت ۴، تاریک‌تر ۵۰٪
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **نقشه‌برداری `SchemeColor` به رنگ‌های `ColorScheme`**

هنگامی که با [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگ تم زیر است:
`Background1`, `Background2`, `Text1`, and `Text2`.

با این حال، `Presentation::getMasterTheme()::getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) را برمی‌گرداند که رنگ‌های متناظر را به صورت زیر ارائه می‌دهد:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

این تفاوت فقط در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگ تم اشاره می‌کنند و نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیلی پویا بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها صرفاً نام‌های جایگزین برای همان رنگ‌های تم هستند.

این تفاوت نام‌گذاری از اصطلاحات Microsoft Office ناشی می‌شود. نسخه‌های قدیمی Office از `Dark 1`, `Light 1`, `Dark 2`, و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به صورت `Text 1`, `Background 1`, `Text 2`, و `Background 2` نمایش می‌دهند.

## **تغییر فونت تم**

برای این که بتوانید فونت‌ها را برای تم‌ها و مقاصد دیگر انتخاب کنید، Aspose.Slides از این شناساگرهای خاص (مشابه آنچه در PowerPoint استفاده می‌شود) بهره می‌برد:

* **+mn-lt** - فونت بدنه لاتین (فونت لاتین کوچک)
* **+mj-lt** - فونت عنوان لاتین (فونت لاتین بزرگ)
* **+mn-ea** - فونت بدنه آسیای شرقی (فونت آسیای شرقی کوچک)
* **+mj-ea** - فونت بدنه آسیای شرقی (فونت آسیای شرقی بزرگ)

این کد PHP نشان می‌دهد که چگونه فونت لاتین را به یک عنصر تم اختصاص دهید:
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

این کد PHP نشان می‌دهد که چگونه فونت تم ارائه را تغییر دهید:
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

فونت در تمام جعبه‌های متن به‌روز خواهد شد.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید [فونت‌های PowerPoint](/slides/fa/php-java/powerpoint-fonts/) را مشاهده کنید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به‌طور پیش‌فرض، برنامه PowerPoint ۱۲ پس‌زمینه از پیش تعریف‌شده ارائه می‌دهد اما فقط ۳ تا از آن‌ها در یک ارائه معمولی ذخیره می‌شوند.

![todo:image_alt_text](presentation-design_8.png)

به‌عنوان مثال، پس از ذخیره یک ارائه در برنامه PowerPoint، می‌توانید این کد PHP را اجرا کنید تا تعداد پس‌زمینه‌های از پیش تعریف‌شده در ارائه را بفهمید:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FormatScheme) می‌توانید سبک پس‌زمینه را در یک تم PowerPoint اضافه یا دسترسی پیدا کنید.
{{% /alert %}} 

این کد PHP نشان می‌دهد که چگونه پس‌زمینه‌ای برای ارائه تنظیم کنید:
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**راهنمای اندیس**: مقدار ۰ برای بدون پر استفاده می‌شود. اندیس از ۱ شروع می‌شود.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید [پس‌زمینه PowerPoint](/slides/fa/php-java/presentation-background/) را مشاهده کنید.
{{% /alert %}}

## **تغییر افکت تم**

یک تم PowerPoint معمولاً ۳ مقدار برای هر آرایه سبک دارد. این آرایه‌ها به ۳ افکت زیر ترکیب می‌شوند: ظریف، متوسط و شدید. به عنوان مثال، این نتیجه‌ای است که وقتی افکت‌ها بر یک شکل خاص اعمال می‌شوند:

![todo:image_alt_text](presentation-design_10.png)

با استفاده از ۳ ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FormatScheme#getEffectStyles--)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FormatScheme) می‌توانید عناصر در یک تم را (حتی انعطاف‌پذیرتر از گزینه‌های PowerPoint) تغییر دهید.

این کد PHP نشان می‌دهد که چگونه یک افکت تم را با تغییر بخش‌های مختلف عنصر تغییر دهید:
```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

تغییرات حاصل در رنگ پر، نوع پر، افکت سایه و غیره:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**آیا می‌توانم یک تم را فقط بر روی یک اسلاید اعمال کنم بدون اینکه مستر تغییر کند؟**  
بله. Aspose.Slides از بازنویسی تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید یک تم محلی را فقط بر آن اسلاید اعمال کنید در حالی که تم مستر دست‌نخورده باقی می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidethememanager/)).

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**  
[Clone slides](/slides/fa/php-java/clone-slides/) را همراه با مسترشان به ارائه هدف منتقل کنید. این کار مستر، طرح‌بندی‌ها و تم مرتبط را حفظ می‌کند تا ظاهر یک‌دست باقی بماند.

**چگونه می‌توانم مقادیر «موثر» را پس از تمام وراثت‌ها و بازنویسی‌ها ببینم؟**  
از نمایه‌های ["effective"](/slides/fa/php-java/shape-effective-properties/) API برای تم/رنگ/فونت/افکت استفاده کنید. این‌ها ویژگی‌های نهایی حل‌وشده پس از اعمال مستر به‌علاوه هر بازنویسی محلی را برمی‌گردانند.