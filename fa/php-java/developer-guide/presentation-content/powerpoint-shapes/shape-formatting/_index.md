---
title: قالب‌بندی اشکال PowerPoint در PHP
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/php-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط اسکیچ شکل
- قالب‌بندی سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ یک‌دست
- شفافیت شکل
- رندر سیاه‑سفت شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت برجسته‌سازی سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در PHP با استفاده از Aspose.Slides قالب‌بندی کنید—پرکردن، خط و سبک‌های افکت را برای فایل‌های PPT و PPTX دقیقاً و با کنترل کامل تنظیم کنید."
---
## **معرفی**

شکل‌ها را در PowerPoint با تنظیم خطوط بیرونی، پرکردن‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی سه‌بعدی.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای PHP از طریق Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با همان گزینه‌هایی که در PowerPoint موجود است، قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) برای کنترل خطوط بیرونی یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکردن با خطوط بیرونی آبی و خط‌چین ایجاد می‌کند. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) یک خط ترکیبی ضخیم-نازک را انتخاب می‌کند، در حالی که [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) عرض آن را به ۷ پوینت تنظیم می‌کند و [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) الگوی خط‌چین را انتخاب می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای سفارشی خط‌چین**

هنگامی که سبک‌های پیش‌تعریف‌شده خط‌چین، طول‌ها و فواصل دلخواه شما را فراهم نمی‌کنند، از [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) استفاده کنید؛ برای مثال برای خطوط برند یا نمودارهای فنی. انتساب یک الگو به‌طور خودکار سبک خط‌چین را به [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به‌صورت متناوب بین طول خط و فاصله تعویض می‌شوند، با یک خط شروع می‌شود. هر مقدار مضربی از عرض خط است: `[4, 2]` با عرض ۳ پوینت یک خط ۱۲‑پوینت و فاصله ۶‑پوینت تولید می‌کند. برای تعریف بخش‌های کامل خط‑چین از جفت مقادیر متناهی و غیرمنفی استفاده کنید. این مثال از مقادیر مثبت برای نمایش واضح هر خط و فاصله استفاده می‌کند.

این مثال پنج خط آبی با طول یکسان و انتهای صاف ایجاد می‌کند. سه خط اول الگوها را در عرض ۳ پوینت مقایسه می‌کنند. خط چهارم الگوی اول را با دو برابر عرض، یعنی دو برابر طول خط و فاصله، تکرار می‌کند. خط پنجم از الگوی سفارشی به خط یک‌دست سوئچ می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // خط آخر را به سبک یکدست بازگردانید.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای بازگشت به یک سبک پیش‌تعریف‌شده خط‌چین، به‌جای آن، [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) را به [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) پاس دهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به‌پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی سفارشی خط‌چین، یک خط پهن‌تر با استفاده از الگوی اول، و یک خط یک‌دست در PowerPoint](custom-dash-patterns.png)

### **تنظیم انتهای خط**

از [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) سه سبک صریح انتها را ارائه می‌دهد:

- `Flat`: خط در نقطه انتها متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای به اندازه نصف عرض خط فراتر از نقطه انتها extends می‌شود.
- `Square`: یک سر مربع به اندازه نصف عرض خط فراتر از نقطه انتها extends می‌شود.

کلاس همچنین شامل `NotDefined` است که به معنای عدم اختصاص صریح سبک انتها می‌باشد.

سرهای خط با سرهای پیکان متفاوت هستند؛ سرهای پیکان نمادهایی را به انتهای خط اضافه می‌کنند و اتصالات (joins) گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرهای پیکان را با استفاده از [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) غیرفعال می‌کند تا فقط شکلهای انتها مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان به عرض ۲۰ پوینت ایجاد می‌کند. از بالا به‌پایین، انتهای صاف، گرد و مربع استفاده می‌کنند. نقاط انتهایی آنها همان مختصات افقی را دارند؛ سرهای گرد و مربع ۱۰ پوینت فراتر از هر نقطه انتها伸 می‌شوند.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه در PowerPoint، از بالا به‌پایین: **Flat**, **Round**, و **Square**.

![سرهای صاف، گرد و مربع روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های اسکیچ به خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط شکل دست‌نویس به‌نظر برسد. از [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) برای دسترسی به تنظیمات خط، [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) برای دسترسی به تنظیمات اسکیچ، و [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) برای انتخاب مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) استفاده کنید.

کد PHP زیر نشان می‌دهد چگونه یک افکت [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) اعمال شود، مقدار به‌وضوح انتساب‑شده خوانده شود، و با [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) حذف شود:

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

مقداری که توسط [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) بازگردانده می‌شود، تنظیمی است که مستقیم به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از تم، اسلاید مادر یا اسلاید چیدمان به ارث برده شود، از [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective) استفاده کنید، متد `getSketchFormat` شیء بازگردانده‌شده را فراخوانی کنید و مقدار `getSketchType` آن را بخوانید. مقدار مؤثر، قالب‌بندی واقعی پس از حل ارث‌بری را نشان می‌دهد. این مثال به یک ارائه موجود با حداقل یک شکل در اسلاید اول نیاز دارد و هر دو مقدار را چاپ می‌کند:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **قالب‌بندی سبک‌های اتصال**

سه گزینه نوع اتصال وجود دارد:

* Round
* Miter
* Bevel

سبک اتصال نحوهٔ تماس دو بخش خارجی را در گوشه کنترل می‌کند. برای گوشه‌های گرد، **Round** را استفاده کنید؛ برای گوشه‌های تیز، **Miter**؛ یا برای گوشه‌های مسطح، **Bevel**.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط بیرونی آبی به عرض ۱۵ پوینت ایجاد می‌کند. از [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) برای تنظیم به مقادیر miter، bevel و round کلاس [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) به ترتیب استفاده می‌کند تا ببینید گوشه‌ها چگونه رسم می‌شوند.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **محدود کردن اتصالات Miter در گوشه‌های تیز**

از [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) همراه با [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) که بر روی [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) تنظیم شده، برای محدود کردن میزان گسترش گوشهٔ تیز استفاده کنید.

محدودیت نسبت فاصله بین گوشه‌های داخلی و خارجی اتصال به عرض خط است. برای مثال مقدار `8` اجازه می‌دهد طول miter تا هشت برابر عرض خط باشد؛ این یک اندازه در پوینت نیست. اگر گوشه از این مقدار فراتر رود، PowerPoint به‌جای آن از اتصال bevel استفاده می‌کند. مقدار بزرگ‌تر نقاط تیزتری می‌دهد. این تنظیم فقط بر اتصالات miter تأثیر می‌گذارد و در صورتی که گوشه در هر دو محدودیت باقی بماند، تغییری قابل مشاهده ندارند.

این مثال دو مثلث بدون پرکردن با خطوط بیرونی به عرض ۲۰ پوینت ایجاد می‌کند. مثلث چپ از مقدار `2` استفاده می‌کند و سمت راست از `8`. هر مثلث ۸۰ پوینت پهن و ۱۶۰ پوینت بلند است و نسبت طول miter به عرض خط در گوشه بالایی تقریباً `4.12` است. در نتیجه PowerPoint گوشهٔ چپ را bevel می‌کند و گوشهٔ راست را حفظ می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![یک نوک bevel با محدودیت miter 2 و یک نوک تیز با محدودیت miter 8 در PowerPoint](miter-limits.png)

## **پرکردن گرادیان**

یک پرکردن گرادیان رنگ‌ها را در یک شکل ترکیب می‌کند. این مثال یک بیضی را با گرادیان خطی به زاویهٔ ۴۵ درجه از قرمز به بنفش با استفاده از [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) پر می‌کند. متد [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) نقاط رنگی را در ۰ و ۱، یعنی ابتدا و انتهای گرادیان، قرار می‌دهد. پاک کردن نقاط رنگی موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادرشده متفاوت از آنچه در PowerPoint نشان می‌دهد باشد، به مقالهٔ [Choose a Gradient Rendering Style](/slides/fa/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید سبک رندر را بدون تغییر گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویهٔ گرادیان خطی**

از [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) برای کنترل جهت یک پرکردن [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعتگرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زاویه‌های کسری نیز پشتیبانی می‌شوند. زاویه‌های متناهی خارج از بازهٔ `[0, 360)` به یک دور کامل نرمال می‌شوند؛ برای مثال `-45` می‌شود `315` و `360` می‌شود `0`.

این مثال شش مستطیل با نقاط رنگی قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌سازی غیرفعال است تا زاویه به‌صورت مستقل از نسبت‌های شکل مقایسه شود. زاویه‌ها، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه در PowerPoint:

![گرادیان‌های خطی در ۰، ۴۵ و ۹۰ درجه در ردیف بالا، و ۱۳۵، ۱۸۰ و ۲۷۰ درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری یک گرادیان خطی با شکل**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) یک مقدار از نوع [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) می‌پذیرد. به‌صورت صریح به `False` تنظیم کنید تا زاویهٔ هندسی گرادیان هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌گذاری شود. با فعال‌سازی مقیاس‌گذاری، زاویهٔ قابل مشاهده می‌تواند در یک شکل غیر مربعی متفاوت از زاویهٔ انتسابی باشد.

مثال زیر از زاویهٔ `45` درجه و همان نقاط رنگی مثال قبلی استفاده می‌کند. ستون چپ `False` و ستون راست `True` دارد. هر ستون شامل یک مستطیل پهن بر بالای یک مستطیل بلند است. هر دو با ابعاد پهن یکسان شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد که پرکردن چگونه بدون تغییر تنظیمات گرادیان به تغییر اندازه واکنش نشان می‌دهد.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های پهن و بلند با یک گرادیان ۴۵ درجه، مقایسه LinearGradientScaled False در سمت چپ با True در سمت راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌گذاری، نوارهای رنگی قطری جهت یکسانی را در هر دو مستطیل حفظ می‌کنند. با فعال بودن مقیاس‌گذاری، نوارها با نسبت‌های شکل کشیده می‌شوند. این به بازتولید گرادیان یک الگو هنگام تغییر اندازهٔ شکل کمک می‌کند. در یک مربع، فعال‌سازی مقیاس‌گذاری تغییری در ظاهر این گرادیان `45` درجه ایجاد نمی‌کند.

هر دو تنظیم زاویه و مقیاس فقط بر گرادیان‌های خطی اعمال می‌شوند. آن‌ها برای پرکردن‌های [GradientShape::Radial یا GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) مؤثر نیستند.

### **ترکیب زاویه با جهت گرادیان**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزینی برای زاویهٔ عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیهٔ توزیع رنگ‌ها را بدون تغییر زاویهٔ تنظیم‌شده توسط [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) تغییر دهند. هنگام مقایسهٔ زاویه‌ها یا مقیاس‌گذاری، جهت را ثابت نگه دارید.

مثال زیر همان تنظیمات را به ترتیب معکوس اعمال می‌کند. دو مستطیل همان ظاهر را دارند: اختصاص جهت قبل یا بعد از زاویه تغییری در نتیجه ایجاد نمی‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرکردن الگو**

یک پرکردن الگو یک طرح دو رنگی مانند نقطه‌ها، خطوط یا شطرنجی‌ها را اعمال می‌کند. این مثال از [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) برای انتخاب یک الگوی Trellis استفاده می‌کند. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) رنگ زرد الگو را تامین می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

یک پرکردن تصویر از یک تصویر داخل شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و با استفاده از [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) آن را به مجموعهٔ تصاویر ارائه بارگذاری می‌کند. تنظیم [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) به حالت کاشی‌ای تصویر را در داخل مستطیل تکرار می‌کند. تصویر منبع در زیر نشان داده شده است:

![عکس لوتوس](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل با پرکردن تصویر](picture-fill.png)

### **کاشی تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پرکردن تصویر را تنظیم می‌کند — `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): تراز کاشی‌ها درون شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): تعیین می‌کند که کاشی به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): جابجایی افقی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): جابجایی عمودی کاشی (به پوینت) را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) را طوری تنظیم می‌کند که تصویر را با ۵۰٪ اندازهٔ اصلی تکرار کند. افست‌های −32 پوینت کاشی‌ها را افقی و عمودی جابجا می‌کند؛ تراز پایین‑راست و وارونگی در هر دو جهت تعیین می‌کند که بافت تکراری چگونه چیدمان شود.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پرکردن رنگ یک‌دست**

یک پرکردن یک‌دست رنگ یک‌سانی به شکل می‌دهد. این مثال [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) را به حالت پرکردن یک‌دست تنظیم و با استفاده از [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) رنگ زرد را اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل با پرکردن رنگ یک‌دست](solid-color-fill.png)

### **کپی رنگ‌ها با حفظ ارجاع به تم**

از [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) برای کپی یک تعریف رنگ، شامل نوع رنگ، ارجاع به تم و تبدیلات استفاده کنید. این کار زمانی مفید است که می‌خواهید یک رنگ پرکردن بین شکل‌هایی که باید با تم ارائه هماهنگ بمانند، انتقال دهید. این متد فقط رنگ را کپی می‌کند؛ نوع پرکردن، خطوط بیرونی یا سایر قالب‌بندی‌های شکل را کپی نمی‌کند. نوع پرکردن مقصد را به‌صورت صریح با [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) تنظیم کنید.

این مثال سه مستطیل، از چپ به راست: منبع، کپی‌دارندهٔ تم و کپی ثابت RGB ایجاد می‌کند. منبع با استفاده از [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) به اولین رنگ Accent ارجاع می‌دهد و با [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add) یک تنک اضافه می‌کند. کپی RGB از رنگ پرکردن مؤثر منبع استفاده می‌کند تا هر سه در ابتدا یک‌سان به‌نظر برسند. فراخوانی [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) مقدار RGB ثابت را تنظیم و هر تبدیلات رنگ موجود را پاک می‌کند.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // ارجاع‌های تم به رنگ Accent جدید پیوسته‌اند؛ مقدار RGB ثابت این‌کار را نمی‌کند.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

قبل از تغییر تم، هر سه پرکردن یکسان هستند:

![منبع، مقصد copyFrom و مقصد ثابت RGB با پرکردن آبی یکسان](color-copy-before.png)

پس از تغییر تم، منبع و کپی‌دارندهٔ تم به رنگ Accent جدید و تنک خود ادامه می‌دهند. کپی ثابت RGB همچنان آبی می‌ماند:

![منبع و مقصد copyFrom با پرکردن نارنجی، در حالی که مقصد ثابت RGB آبی می‌ماند](color-copy-after.png)

تعریف کپی‌شده مستقل از منبع است. تغییر ارجاع تم منبع، انتساب رنگ دیگر یا افزودن/حذف تبدیلات آن، مقصد را تغییر نمی‌دهد. تغییر تم همچنان هر دو شکل را تحت تأثیر قرار می‌دهد چون هر کدام به طور مستقل به همان رنگ تم ارجاع می‌دهند.

ذخیره و بازگشایی PPTX نوع رنگ کپی‌شده را که توسط [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType) بازگردانده می‌شود، ارجاع تم و مجموعهٔ تبدیلاتی که توسط [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform) بازگردانده می‌شود، حفظ می‌کند؛ این اطلاعات به RGB مسطح نمی‌شود.

هنگام کپی بین زمینه‌های تم مختلف، مانند ارائه‌هایی با پالت Accent متفاوت، ارجاع کپی‌شده نسبت به تم مقصد حل می‌شود. بنابراین همان ارجاع و تبدیلات می‌توانند رنگ قابل مشاهده متفاوتی تولید کنند. برای اطلاعات بیشتر درباره پیکربندی رنگ‌های تم، به [Presentation Theme](/slides/fa/php-java/presentation-theme/) مراجعه کنید.

## **استفاده از پس‌زمینهٔ اسلاید به‌عنوان پرکردن شکل**

زمانی که یک شکل باید با پس‌زمینهٔ اسلاید منطبق باشد، مثلاً در یک قالب ارائه، از [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) استفاده کنید. ابتدا نوع پرکردن را با [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) به [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) تنظیم کنید تا هر پرکردن صریحی حذف شود. با این ترکیب، شکل از پس‌زمینهٔ اسلاید به‌جای پرکردن سبک خود استفاده می‌کند. فعال‌سازی فقط این پرچم به‌تنهایی پرکردن صریح موجود را حذف نمی‌کند.

این متفاوت از [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) است: پرکردن پس‌زمینه اشیائی که پشت شکل قرار دارند را با ناحیهٔ مربوط به پس‌زمینهٔ اسلاید می‌پوشاند، در حالی که NoFill آن اشیاء را قابل مشاهده می‌گذارد. یک گرادیان همچنان نسبت به اسلاید هم‌راستا می‌ماند نه اینکه در هر شکل از نو شروع شود.

مثال زیر یک پس‌زمینهٔ اصلی که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و یک نوار صورتی را پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی بدون پرکردن است و مستطیل راست از پرکردن پس‌زمینه به پرکردن صریح نارنجی سوئیچ می‌کند.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // گرادیان را از مستر به ارث می‌برد.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // این شیء را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // پر کردن پس‌زمینه را قبل از اعمال پر کردن صریح غیرفعال کنید.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه، از چپ به راست: **background fill**, **no fill**, و **explicit fill**. نوار صورتی توسط مستطیل‌های چپ و راست پنهان می‌شود ولی از طریق مستطیل میانی قابل مشاهده است.

![پرکردن پس‌زمینه، بدون پرکردن و پرکردن صریح نارنجی روی نوار صورتی](background-fill.png)

رفتار مشابه برای پس‌زمینه‌ای که مستقیماً بر روی اسلاید تعریف شده یا از یک چیدمان ارث برده می‌شود، اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و چیدمان را تعریف نشده می‌گذارد تا اصلی آنها را ارث ببرد.

## **تنظیم شفافیت**

برای یک پرکردن یک‌دست، مؤلفهٔ آلفای رنگ، شفافیت را کنترل می‌کند: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند تا تقریباً ۵۰٪ شفاف باشد، به‌طوری که مستطیل زیرین قابل مشاهده بماند. رنگ از طریق [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص یافته است.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخش شکل‌ها**

از [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعتگرد می‌چرخاند و ارائه را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **اضافه کردن افکت‌های برجستهٔ سه‌بعدی**

از [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) برای افزودن عمق و لبه‌های برجسته به یک شکل استفاده کنید. این مثال یک بیضی سبز با خطوط بیرونی نارنجی ایجاد می‌کند، [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) را به ۴ پوینت تنظیم می‌کند و با استفاده از [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) یک برجستهٔ بالا Circular با عرض و ارتفاع ۶ پوینت اعمال می‌کند. یک دوربین ارتوغرافیک رو به جلو و نور سه‌نقطه‌ای برجسته را قابل مشاهده می‌کند.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![افکت برجستهٔ سه‌بعدی](3D-bevel-effect.png)

## **اضافه کردن افکت‌های چرخش سه‌بعدی**

نمای سه‌بعدی یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) با زاویه‌های latitude، longitude و revolution به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. یک دوربین ایزومتریک را از طریق [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) و نورپردازی متعادل را از طریق [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) انتخاب می‌کند، سپس مستطیل قالب‌بندی‌شده را ذخیره می‌کند.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![افکت چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفت برای شکل‌ها**

متد [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) مشخص می‌کند که یک شکل منفرد چگونه هنگام مشاهده یا پردازش ارائه در حالت سیاه‑سفت رندر شود. این خود به‌تنهایی حالت سیاه‑سفت را فعال نمی‌کند و در حالت رنگ عادی، پرکردن، خط یا قالب‌بندی دیگر شکل را تغییر نمی‌دهد.

مقداری از کلاس [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) را برای انتخاب رفتار موردنظر استفاده کنید. به‌عنوان مثال `Automatic` اجازه می‌دهد برنامهٔ رندر تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفت حذف می‌کند. `NotDefined` به معنای عدم اختصاص حالت به سطح شکل است.

این مثال یک مستطیل نارنجی ایجاد کرده و [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) را به `Gray` تنظیم می‌کند. شکل ذخیره‌شده در حالت رنگ عادی پرکردن نارنجی خود را حفظ می‌کند و در ورک‌فلوهای نمایش سیاه‑سفت، رنگ خاکستری درخواست می‌کند:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

در حالت رنگ عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک ورک‌فلو نمایش سیاه‑سفت، به‌دلیل تنظیم حالت روی `Gray`، رنگ خاکستری استفاده می‌شود. این امکان را می‌دهد تا اسلاید رنگی کامل را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر ورک‌فلوهایی که تنظیمات نمایش سیاه‑سفت ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) برای بازگرداندن موقعیت، اندازه و قالب‌بندی محل‌نگهدارهای اسلاید از محل‌نگهدارهای متناظر در چیدمان استفاده کنید. این مثال به یک ارائه موجود با محل‌نگهدارهای مرتبط به چیدمان نیاز دارد و قبل از ذخیره، تمام اسلایدها را بازنشانی می‌کند. شکل‌هایی که محل‌نگهدار متناظر در چیدمان ندارند، بازنشانی نمی‌شوند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سؤالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت معمولاً داده کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پرکردن‌های تصویری می‌توانند حجم فایل را افزایش دهند زیرا تصاویر آن‌ها در ارائه ذخیره می‌شوند.

**چگونه می‌توانم اشکالی را که در یک اسلاید قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

هر پراستیت‌های کلیدی شکل—پرکردن، خط و تنظیمات افکت—را مقایسه کنید. اگر همه مقادیر متناظر مطابقت داشته باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقی آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در آینده ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. شکل‌های نمونه با سبک‌های موردنظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را هر جا که لازم است دوباره اعمال کنید.