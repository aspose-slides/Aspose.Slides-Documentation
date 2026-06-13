---
title: "مدیریت کانکتورها در ارائه‌ها با استفاده از PHP"
linktitle: "کانکتور"
type: docs
weight: 10
url: /fa/php-java/connector/
keywords:
- کانکتور
- نوع کانکتور
- نقطه کانکتور
- خط کانکتور
- زاویه کانکتور
- اتصال اشکال
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "به برنامه‌های PHP امکان رسم، اتصال و مسیر‌یابی خودکار خطوط در اسلایدهای PowerPoint را بدهید — کنترل کامل بر کانکتورهای مستقیم، زاویه‌دار و منحنی."
---
## **مقدمه**

یک کانکتور پاورپوینت خط خاصی است که دو شکل را به هم متصل یا لینک می‌کند و حتی هنگام جابه‌جایی یا تغییر موقعیت شکل‌ها در اسلاید به آنها متصل می‌ماند.

کانکتورها معمولاً به *نقطه‌های اتصال* (نقطه‌های سبز) که به‌صورت پیش‌فرض در تمام شکل‌ها وجود دارند، متصل می‌شوند. نقطه‌های اتصال زمانی ظاهر می‌شوند که نشانگر به نزدیکی آنها برسد.

*نقاط تنظیم* (نقطه‌های نارنجی) که فقط در برخی از کانکتورها موجود هستند، برای تغییر موقعیت و شکل کانکتورها استفاده می‌شوند.

## **انواع کانکتورها**

در پاورپوینت می‌توانید از کانکتورهای مستقیم، زاویه‌دار (elbow) و منحنی استفاده کنید.

Aspose.Slides این کانکتورها را فراهم می‌کند:

| کانکتور | تصویر | تعداد نقاط تنظیم |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **اتصال اشکال با استفاده از کانکتورها**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
1. دو [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/AutoShape) را با استفاده از متد `addAutoShape` که توسط شیء `Shapes` ارائه شده است، به اسلاید اضافه کنید.
1. با استفاده از متد `addConnector` که توسط شیء `Shapes` ارائه شده است و نوع کانکتور را تعریف می‌کند، یک کانکتور اضافه کنید.
1. اشکال را با کانکتور متصل کنید.
1. متد `reroute` را فراخوانی کنید تا کوتاه‌ترین مسیر اتصال اعمال شود.
1. ارائه را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک کانکتور (یک کانکتور خمیده) بین دو شکل (یک بیضی و یک مستطیل) اضافه شود:

```php
// یک کلاس Presentation را که فایل PPTX را نمایان می‌کند، ایجاد می‌کند
  $pres = new Presentation();
  try {
    # دسترسی به مجموعهٔ اشکال یک اسلاید خاص
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # یک شکل خودکار بیضی اضافه می‌کند
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # یک شکل خودکار مستطیل اضافه می‌کند
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # یک شکل کانکتور را به مجموعهٔ اشکال اسلاید اضافه می‌کند
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # اشکال را با استفاده از کانکتور به هم متصل می‌کند
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # متد reroute را فراخوانی می‌کند که کوتاه‌ترین مسیر خودکار بین اشکال را تنظیم می‌کند
    $connector->reroute();
    # ارائه را ذخیره می‌کند
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

متد `Connector.reroute` یک کانکتور را دوباره مسیر می‌دهد و آن را مجبور می‌کند کوتاه‌ترین مسیر ممکن بین اشکال را بگیرد. برای رسیدن به این هدف، ممکن است نقاط `setStartShapeConnectionSiteIndex` و `setEndShapeConnectionSiteIndex` را تغییر دهد. 

{{% /alert %}} 

## **مشخص کردن نقطه اتصال**

اگر می‌خواهید یک کانکتور دو شکل را با استفاده از نقطه‌های خاصی در اشکال متصل کند، باید نقاط اتصال مورد نظر خود را به این شکل مشخص کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
1. دو [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/AutoShape) را با استفاده از متد `addAutoShape` که توسط شیء `Shapes` ارائه شده است، به اسلاید اضافه کنید.
1. با استفاده از متد `addConnector` که توسط شیء `Shapes` ارائه شده است و نوع کانکتور را تعریف می‌کند، یک کانکتور اضافه کنید.
1. اشکال را با کانکتور متصل کنید.
1. نقاط اتصال مورد نظر خود را بر روی اشکال تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد PHP عملی را نشان می‌دهد که در آن یک نقطه اتصال دلخواه مشخص می‌شود:

```php
  # یک کلاس Presentation را که نمایانگر یک فایل PPTX است، نمونه‌سازی می‌کند
  $pres = new Presentation();
  try {
    # دسترسی به مجموعهٔ اشکال یک اسلاید خاص
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # یک شکل خودکار بیضی اضافه می‌کند
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # یک شکل خودکار مستطیل اضافه می‌کند
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # یک شکل کانکتور را به مجموعهٔ اشکال اسلاید اضافه می‌کند
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # اشکال را با استفاده از کانکتور متصل می‌کند
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # شاخص نقطهٔ اتصال دلخواه را روی شکل بیضی تنظیم می‌کند
    $wantedIndex = 6;
    # بررسی می‌کند که آیا شاخص دلخواه کمتر از حداکثر تعداد سایت‌ها است یا خیر
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # نقطهٔ اتصال دلخواه را روی شکل خودکار بیضی تنظیم می‌کند
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # ارائه را ذخیره می‌کند
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم نقطهٔ کانکتور**

می‌توانید یک کانکتور موجود را از طریق نقاط تنظیم آن تنظیم کنید. فقط کانکتورهایی که نقاط تنظیم دارند می‌توانند به این روش تغییر یابند. جدول زیر را در بخش **[Types of connectors.](/slides/fa/php-java/connector/#types-of-connectors)** مشاهده کنید.

### **مورد ساده**

یک مورد را در نظر بگیرید که در آن یک کانکتور بین دو شکل (A و B) از طریق یک شکل سوم (C) عبور می‌کند:

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

برای جلوگیری یا دور زدن شکل سوم، می‌توانیم کانکتور را با جابه‌جایی خط عمودی آن به سمت چپ این‌گونه تنظیم کنیم:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);
```

### **موارد پیچیده** 

برای انجام تنظیمات پیچیده‌تر، باید موارد زیر را در نظر بگیرید:

* نقطهٔ قابل تنظیم یک کانکتور به‌ شدت به فرمولی که موقعیت آن را محاسبه می‌کند وابسته است. بنابراین تغییر مکان نقطه ممکن است شکل کانکتور را تغییر دهد.
* نقاط تنظیم یک کانکتور به ترتیب مشخصی در یک آرایه تعریف می‌شوند. نقاط تنظیم از نقطهٔ شروع کانکتور تا نقطهٔ پایان شماره‌گذاری می‌شوند.
* مقادیر نقاط تنظیم درصد عرض/ارتفاع شکل کانکتور را بازتاب می‌دهند. 
  * شکل توسط نقاط شروع و پایان کانکتور ضربدر 1000 محدود می‌شود. 
  * نقطهٔ اول، دوم و سوم به ترتیب درصد از عرض، درصد از ارتفاع و دوباره درصد از عرض را تعریف می‌کنند.
* برای محاسبهٔ مختصات نقاط تنظیم کانکتور، باید چرخش کانکتور و انعکاس آن را در نظر بگیرید. **توجه** داشته باشید که زاویهٔ چرخش برای تمام کانکتورهای نشان داده‌شده در **[Types of connectors](/slides/fa/php-java/connector/#types-of-connectors)** برابر 0 است.

#### **مورد 1**

یک مورد را در نظر بگیرید که دو شیء چارچوب متن از طریق یک کانکتور به هم متصل هستند:

![connector-shape-complex](connector-shape-complex.png)

```php
  # یک کلاس Presentation را که نمایانگر یک فایل PPTX است، نمونه‌سازی می‌کند
  $pres = new Presentation();
  try {
    # اسلاید اول ارائه را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # اشکالی را اضافه می‌کند که از طریق یک کانکتور به هم وصل می‌شوند
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # یک کانکتور اضافه می‌کند
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # جهت کانکتور را مشخص می‌کند
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # رنگ کانکتور را مشخص می‌کند
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # ضخامت خط کانکتور را مشخص می‌کند
    $connector->getLineFormat()->setWidth(3);
    # اشکال را با استفاده از کانکتور به هم متصل می‌کند
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # نقاط تنظیم کانکتور را دریافت می‌کند
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**تنظیم**

می‌توانیم مقادیر نقاط تنظیم کانکتور را با افزایش درصد عرض و ارتفاع مربوطه به ترتیب 20٪ و 200٪ تغییر دهیم:

```php
  # مقادیر نقاط تنظیم را تغییر می‌دهد
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

نتیجه:

![connector-adjusted-1](connector-adjusted-1.png)

برای تعریف مدلی که به ما امکان تعیین مختصات و شکل بخش‌های منفرد کانکتور را بدهد، بیایید یک شکل ایجاد کنیم که به مؤلفهٔ افقی کانکتور در نقطهٔ `connector.getAdjustments().get_Item(0)` مربوط باشد:

```php
  # رسم مؤلفه عمودی کانکتور
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

نتیجه:

![connector-adjusted-2](connector-adjusted-2.png)

#### **مورد 2**

در **مورد 1**، یک عملیات تنظیم ساده کانکتور با اصول پایه‌ای را نشان دادیم. در شرایط معمول، باید چرخش کانکتور و نمایش آن (که توسط `connector.getRotation()`, `connector.getFrame().getFlipH()`, و `connector.getFrame().getFlipV()` تنظیم می‌شوند) را در نظر بگیرید. اکنون فرآیند را نشان می‌دهیم.

ابتدا، یک شیء چارچوب متن جدید (**To 1**) را به اسلاید (برای اهداف اتصال) اضافه می‌کنیم و یک کانکتور (سبز) جدید می‌سازیم که آن را به اشیائی که قبلاً ساخته‌ایم متصل می‌کند.

```php
  # یک شی بایندینگ جدید ایجاد می‌کند
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # یک کانکتور جدید ایجاد می‌کند
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # اشیاء را با استفاده از کانکتور تازه ایجاد شده متصل می‌کند
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # نقاط تنظیم کانکتور را دریافت می‌کند
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # مقادیر نقاط تنظیم را تغییر می‌دهد
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

نتیجه:

![connector-adjusted-3](connector-adjusted-3.png)

سپس، یک شکلی ایجاد می‌کنیم که به مؤلفهٔ افقی کانکتور که از طریق نقطهٔ تنظیم جدید `connector.getAdjustments().get_Item(0)` می‌گذرد، مربوط باشد. ما از مقادیر دادهٔ کانکتور برای `connector.getRotation()`, `connector.getFrame().getFlipH()`, و `connector.getFrame().getFlipV()` استفاده می‌کنیم و فرمول تبدیل مختصات معروف برای چرخش حول یک نقطهٔ داده‌شده x0 را اعمال می‌کنیم:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

در مورد ما، زاویهٔ چرخش شیء 90 درجه است و کانکتور به‌صورت عمودی نمایش داده می‌شود، بنابراین کد مربوطه به این شکل است:

```php
  # مختصات کانکتور را ذخیره می‌کند
  $x = $connector->getX();
  $y = $connector->getY();
  # مختصات کانکتور را در صورت نیاز اصلاح می‌کند
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # مقدار نقطه تنظیم را به عنوان مختصات می‌گیرد
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # مختصات را تبدیل می‌کند زیرا Sin(90) = 1 و Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # عرض مؤلفه افقی را با استفاده از مقدار نقطه تنظیم دوم تعیین می‌کند
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

نتیجه:

![connector-adjusted-4](connector-adjusted-4.png)

ما محاسبات مرتبط با تنظیمات ساده و نقاط تنظیم پیچیده (نقاط تنظیم با زوایای چرخش) را نشان دادیم. با استفاده از این دانش می‌توانید مدل خود را توسعه دهید (یا کدی بنویسید) تا یک شیء `GraphicsPath` دریافت کنید یا حتی مقادیر نقاط تنظیم یک کانکتور را بر اساس مختصات خاص اسلاید تنظیم کنید.

## **یافتن زاویه خطوط کانکتور**

1. یک نمونه از کلاس ایجاد کنید.
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
1. به شکل خط کانکتور دسترسی پیدا کنید.
1. از عرض، ارتفاع، ارتفاع قاب شکل و عرض قاب شکل برای محاسبهٔ زاویه استفاده کنید.

این کد PHP عمل محاسبهٔ زاویه برای یک شکل خط کانکتور را نشان می‌دهد:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**چگونه می‌توانم بفهمم یک کانکتور می‌تواند به یک شکل خاص «چسبانده» شود؟**

بررسی کنید که شکل [نقاط اتصال](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getconnectionsitecount/) را ارائه می‌دهد یا نه. اگر هیچ‌کدام وجود نداشته باشند یا تعداد آنها صفر باشد، چسباندن در دسترس نیست؛ در این صورت از نقاط انتهایی آزاد استفاده کنید و آن‌ها را به‌صورت دستی موقعیت‌دهی کنید. منطقی است قبل از الصاق، تعداد نقاط را بررسی کنید.

**اگر یکی از اشکال متصل‌شده را حذف کنم، چه اتفاقی برای کانکتور می‌افتد؟**

سرها جدا می‌شوند؛ کانکتور به‌عنوان یک خط عادی با نقاط شروع/پایان آزاد بر روی اسلاید باقی می‌ماند. می‌توانید آن را حذف کنید یا ارتباطات را دوباره اختصاص داده و در صورت نیاز، [reroute](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/reroute/) کنید.

**آیا پیوندهای کانکتور هنگام کپی اسلاید به ارائهٔ دیگری حفظ می‌شوند؟**

به‌طور کلی بله، به‌شرط آن‌که اشکال هدف نیز کپی شوند. اگر اسلاید بدون اشکال متصل به فایل دیگری وارد شود، سرها آزاد می‌شوند و باید دوباره متصل شوند.