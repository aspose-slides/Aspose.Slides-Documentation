---
title: مدیریت اتصال‌کننده‌ها در ارائه‌ها با استفاده از PHP
linktitle: اتصال‌کننده
type: docs
weight: 10
url: /fa/php-java/connector/
keywords:
- اتصال‌کننده
- نوع اتصال‌کننده
- نقطه اتصال‌کننده
- خط اتصال‌کننده
- زاویه اتصال‌کننده
- سایت اتصال
- نقطه تنظیم
- اتصال اشکال
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای PHP از طریق Java، اتصال‌کننده‌های مستقیم، خمیده و منحنی PowerPoint را اضافه، وصل، مسیر جدید بدهید، تنظیم کنید و بررسی کنید."
---
## **نمای کلی**

یک connector خطی است که می‌تواند هنگام حرکت هر یک از دو شکل، به هر دو شکل وصل بماند. انتهای آن به سایت‌های اتصال متصل می‌شود که در PowerPoint با نقاط سبز نمایش داده می‌شوند. برخی از connectorهای خمیده و منحنی همچنین نقاط تنظیمی (adjustment points) را نشان می‌دهند که با نقاط نارنجی مشخص می‌شوند و موقعیت بخش‌های مختلف connector را کنترل می‌کنند.

Aspose.Slides connectorها را با کلاس [Connector](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/) نشان می‌دهد. می‌توانید آن‌ها را ایجاد کنید، انتهایشان را به اشکال وصل کنید، سایت‌های اتصال را انتخاب کنید، مسیرشان را دوباره محاسبه کنید و هندسه connectorهای دارای نقاط تنظیم را اصلاح کنید.

## **انواع اتصال‌کننده**

کلاس [ShapeType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapetype/) شامل پیش‌تنظیمات connectorهای مستقیم، خمیده و منحنی است. جدول زیر هندسه‌های موجود connector و تعداد نقاط تنظیم تعریف‌شده برای هر پیش‌تنظیم را نشان می‌دهد.

| اتصال‌کننده | Image | تعداد نقاط تنظیم |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

تعداد و معنای نقاط تنظیم بخشی از پیش‌تنظیم connector انتخاب‌شده هستند. فرض نکنید که دو نوع connector متفاوت همانچندین طرح مجموعه را نشان می‌دهند.

## **اتصال دو شکل**

از [ShapeCollection::addConnector](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addconnector/) برای افزودن یک connector استفاده کنید و با [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/setstartshapeconnectedto/) و [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/setendshapeconnectedto/) انتهای آن را وصل کنید. پس از اتصال هر دو انتها، متد [Connector::reroute](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/reroute/) مسیر کوتاهی بین اشکال را انتخاب می‌کند.

مثال زیر یک بیضی و یک مستطیل را با یک connector خمیده متصل می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
فراخوانی `reroute` می‌تواند مقادیر [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) و [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) را تغییر دهد. پس از تغییر مسیر، در صورت نیاز به ثابت ماندن این سایت‌ها، آن‌ها را به‌صورت خاص اختصاص دهید.
{{% /alert %}}

## **انتخاب سایت اتصال**

هر شکل قابل اتصال تعداد سایت‌های خود را از طریق [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getconnectionsitecount/) گزارش می‌دهد. قبل از اختصاص یک ایندکس سایت صفر مبنا به انتهای connector، ایندکس معتبر را بررسی کنید؛ تعداد سایت‌ها بسته به هندسه شکل متفاوت است.

این مثال connector را زمانی که سایت خاصی در بیضی وجود دارد، به آن سایت متصل می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم نقطه اتصال‌کننده**

connectorهایی که نقاط تنظیم دارند، این نقاط را از طریق [GeometryShape::getAdjustments](https://reference.aspose.com/slides/fa/php-java/aspose.slides/geometryshape/#getadjustments) در دسترس می‌گذارند. پیش از تغییر مقدار هر [AdjustValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/) نوع آن را با [AdjustValue::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/#gettype) بررسی کنید و سپس با [AdjustValue::setRawValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/setrawvalue/) مقدار جدید را تنظیم کنید. قوانین کلی شناسایی تنظیمات پیش‌تنظیم شکل در بخش [Shape Manipulation](/slides/fa/php-java/shape-manipulations/) توضیح داده شده‌اند.

تعداد، ترتیب، معنا و بازه مقادیر مجاز تنظیمات connector به پیش‌تنظیم آن وابسته است. نوع تنظیم فقط‑خواندنی است، در حالی که مقدار آن قابل نوشتن است. متد فقط‑خواندنی [AdjustValue::getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/getname/) اطلاعات اضافه‌ای برای شناسایی فراهم می‌کند وقتی connector بیش از یک تنظیم از نوع معنایی یکسان داشته باشد.

### **عبور از مانع**

در چیدمان زیر، connector `BentConnector5` بین دو شکل از طریق شکل سوم عبور می‌کند:

![connector-obstruction](connector-obstruction.png)

این کد connector مسدود شده را می‌سازد:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تغییر خم عمودی مسیر را طوری تغییر می‌دهد که connector مانع را دور بزند:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

به‌جای این‌که فرض کنید ایندکس مجموعه `1` همیشه نمایانگر خم عمودی است، این مثال به دنبال `ConnectorBendPositionY` می‌گردد و تنها زمانی که نوع معنایی مورد انتظار وجود داشته باشد، آن را تغییر می‌دهد:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

یک `BentConnector5` دو تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` دارد. اگر نوع مورد نیاز بیش از یک بار ظاهر شود، قبل از انتخاب آن، `getName` و هندسه شناخته‌شده پیش‌تنظیم را بررسی کنید. اگر تنظیمی مقدار `ShapeAdjustmentType::Custom` داشته باشد، معنای آن و بازه مقدار را به‌عنوان پیش‌تنظیم خاص درنظر بگیرید و تا زمانی که قرارداد آن مشخص شود، تغییر ندهید.

## **ربط مقادیر تنظیم به هندسه اتصال‌کننده**

برای connectorهای خمیده، مقادیر تنظیم می‌توانند برای تخمین موقعیت بخش‌های فردی استفاده شوند. این محاسبات به پیش‌تنظیم connector وابسته است:

- `BentConnector4` معمولاً یک تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` را نشان می‌دهد.
- برای این موقعیت‌های خم، تقسیم مقدار بازگردانده‌شده توسط `getRawValue` بر `100000` کسر عرض یا ارتفاع فریم connector را که در مثال‌های زیر استفاده می‌شود، تولید می‌کند.
- فریم connector می‌تواند چرخیده یا وارونه باشد، بنابراین مختصات فریم قبل از مقایسه با مختصات اسلاید باید تبدیل شوند.

مثال‌های زیر ابتدا با `getType` نوع تنظیمات را شناسایی می‌کنند. آن‌ها از ایندکس‌های مجموعه به‌عنوان شناسه‌های قابل حمل استفاده نمی‌کنند.

### **اتصال‌کننده بدون چرخش**

چیدمان اولیه شامل دو شکل متن است که توسط یک `BentConnector4` به هم متصل شده‌اند:

![connector-shape-complex](connector-shape-complex.png)

این مثال connector را بررسی کرده و تنظیمات خم افقی و عمودی آن را به دست می‌آورد:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

برای تغییر هر دو خم، هر نوع مورد انتظار را پیدا کنید و پس از یافتن هر دو، مقادیر را اصلاح کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

نتیجه یک connector است که بخش‌های افقی و عمودی آن جابجا شده‌اند:

![connector-adjusted-1](connector-adjusted-1.png)

پس از شناسایی انواع معنایی، می‌توان مقادیر را به مختصات فریم connector تبدیل کرد. این مثال یک مستطیل نازک را بر روی بخش عمودی که توسط دو تنظیم خم کنترل می‌شود، می‌کشد:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

شکل راهنما بخش محاسبه‌شده را علامت‌گذاری می‌کند:

![connector-adjusted-2](connector-adjusted-2.png)

### **اتصال‌کننده چرخیده یا وارونه**

وقتی هندسه همان connector به‌صورت عمودی چیده شود، مقدارهای [Shape::getFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getframe/)، [ShapeFrame::getFlipH](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapeframe/getfliph/) و [ShapeFrame::getFlipV](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapeframe/getflipv/) بر تبدیل مختصات فریم connector به مختصات اسلاید تأثیر می‌گذارند.

این مثال connector عمودی را می‌سازد و تنظیم می‌کند:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

connector تنظیم‌شده به‌صورت عمودی بین دو شکل ظاهر می‌شود:

![connector-adjusted-3](connector-adjusted-3.png)

برای زاویه چرخش دلخواه `alpha`، نقطه فریم connector `(x, y)` را به‌صورت دور مرکز فریم `(x0, y0)` می‌چرخانیم:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

کد زیر جهت 90 درجه مورد استفاده در این مثال را مدیریت می‌کند و یک راهنمای قرمز بر روی بخش مربوطه connector می‌کشد:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

راهنمای قرمز بخش محاسبه‌شده را پس از تبدیل مختصات نشان می‌دهد:

![connector-adjusted-4](connector-adjusted-4.png)

این فرمول‌ها پیش‌تنظیم‌های استفاده‌شده در مثال‌ها را توصیف می‌کنند، نه یک مدل عمومی connector. قبل از اعمال محاسبه مشابه به پیش‌تنظیم دیگر، انواع تنظیمات، جهت فریم و بازه مقادیر را اعتبارسنجی کنید.

## **یافتن زاویه جهت اتصال‌کننده**

جهت یک connector مستقیم می‌تواند از عرض و ارتفاع آن محاسبه شود، با در نظر گرفتن وارونگی‌های افقی و عمودی. مثال زیر زاویه ساعت‌گرد را نسبت به محور افقی مثبت در مختصات اسلاید گزارش می‌دهد:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم که یک connector می‌تواند به یک شکل متصل شود؟**

مقدار [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getconnectionsitecount/) شکل را بررسی کنید. مقدار مثبت نشان می‌دهد شکل سایت‌های اتصال ارائه می‌دهد. قبل از اختصاص سایت به هر انتهای connector، ایندکس سایت انتخاب‌شده را اعتبارسنجی کنید.

**آیا می‌توانم تنظیم یک connector را با ایندکس مجموعه شناسایی کنم؟**

ایندکس فقط برای پیش‌تنظیم connector شناخته‌شده و چینش مجموعه معنا دارد. قبل از تغییر مقدار، [AdjustValue::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/#gettype) را بررسی کنید و هنگام تکرار نوع معنایی، از [AdjustValue::getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/adjustvalue/getname/) به‌عنوان اطلاعات تکمیلی استفاده کنید.

**وقتی یک شکل متصل حذف شود چه اتفاقی می‌افتد؟**

سر مربوط به connector جدا می‌شود. connector در اسلاید باقی می‌ماند و می‌تواند حذف شود، به‌عنوان خط آزاد قرار گیرد یا به شکل دیگری متصل شود。

**آیا اتصالات connector هنگام کپی اسلاید حفظ می‌شوند؟**

به‌طور معمول، وقتی اشکال متصل همراه با اسلاید کپی می‌شوند، اتصالات حفظ می‌گردند. اگر connector بدون یکی از اشکال هدف کپی شود، سر تحت‌تاثیر باید مجدداً متصل شود.