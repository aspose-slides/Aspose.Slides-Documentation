---
title: مدیریت اتصال‌ها در ارائه‌ها با جاوا
linktitle: اتصال
type: docs
weight: 10
url: /fa/java/connector/
keywords:
- اتصال
- نوع اتصال
- نقطه اتصال
- خط اتصال
- زاویه اتصال
- محل اتصال
- نقطه تنظیم
- اتصال اشکال
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "بیاموزید چگونه با Aspose.Slides برای Java، اتصالات مستقیم، خمیده و منحنی PowerPoint را اضافه، متصل، مسیردهی مجدد، تنظیم و بررسی کنید."
---
## **نمای کلی**

یک اتصال (connector) خطی است که می‌تواند به دو شکل متصل بماند حتی زمانی که هر یک از این شکل‌ها حرکت می‌کند. انتهای آن به نقاط اتصال (connection sites) وصل می‌شود که در PowerPoint به صورت نقاط سبز نمایش داده می‌شوند. برخی از اتصالات خمیده و منحنی همچنین نقاط تنظیم (adjustment points) را نشان می‌دهند که به صورت نقاط نارنجی نمایش شده و موقعیت بخش‌های جداگانهٔ اتصال را کنترل می‌کنند.

Aspose.Slides اتصالات را از طریق رابط [IConnector](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnector/) نشان می‌دهد. می‌توانید آن‌ها را ایجاد کنید، انتهای آن‌ها را به شکل‌ها وصل کنید، نقاط اتصال را انتخاب کنید، مسیرشان را مجدداً تعیین (reroute) کنید و هندسهٔ اتصالاتی که نقاط تنظیم دارند را تغییر دهید.

## **انواع اتصال‌ها**

کلاس [ShapeType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapetype/) شامل پیش‌تنظیم‌های اتصال مستقیم، خمیده و منحنی است. جدول زیر هندسهٔ موجود برای هر پیش‌تنظیم و تعداد نقاط تنظیم تعریف‌شده توسط هر یک را نشان می‌دهد.

| اتصال | تصویر | تعداد نقاط تنظیم |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

تعداد و معنای نقاط تنظیم بخشی از پیش‌تنظیم انتخابی اتصال است. فرض نکنید که دو نوع اتصال متفاوت همان چیدمان مجموعه را نشان می‌دهند.

## **اتصال دو شکل**

از متد [IShapeCollection.addConnector](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) برای افزودن یک اتصال استفاده کنید و با متدهای [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) و [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) انتهای آن را به شکل‌ها متصل کنید. پس از اتصال هر دو انتها، متد [IConnector.reroute](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnector/#reroute--) مسیر کوتاهی بین شکل‌ها را انتخاب می‌کند.

مثال زیر یک بیضی و یک مستطیل را با یک اتصال خمیده (bent connector) مرتبط می‌سازد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
فراخوانی `reroute` می‌تواند مقادیر [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) و [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) را تغییر دهد. پس از تغییر مسیر، در صورت نیاز به ثابت ماندن این نقاط، مقادیر خاصی را به آن‌ها اختصاص دهید.
{{% /alert %}}

## **انتخاب یک نقطهٔ اتصال**

هر شکل قابل اتصال تعداد نقاط اتصال خود را از طریق متد [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getConnectionSiteCount--) گزارش می‌کند. پیش از اختصاص یک شاخص صفر‑پایه به انتهای اتصال، شاخص مورد نظر را اعتبارسنجی کنید؛ تعداد نقاط بسته به هندسهٔ شکل متفاوت است.

مثال زیر اتصال را به نقطهٔ خاصی از بیضی متصل می‌کند وقتی آن نقطه موجود باشد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم یک نقطهٔ اتصال**

اتصالاتی که نقاط تنظیم دارند، این نقاط را از طریق متد [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igeometryshape/#getAdjustments--) در دسترس قرار می‌دهند. پیش از تغییر هر [IAdjustValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/) مقدار [getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getType--) آن را بررسی کنید و با متد [setRawValue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) مقدار را تغییر دهید. قوانین کلی برای شناسایی تنظیمات پیش‌تنظیم شده شکل در بخش [Shape Manipulation](/slides/fa/java/shape-manipulations/) توضیح داده شده است.

تعداد، ترتیب، معنای و بازهٔ مقادیر معتبر تنظیمات اتصال بستگی به پیش‌تنظیم اتصال دارد. نوع تنظیم فقط‑خواندنی است، در حالی که مقدار آن قابل نوشتن است. متد فقط‑خواندنی [getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getName--) اطلاعات شناسایی بیشتری می‌دهد وقتی یک اتصال بیش از یک تنظیم از همان نوع معنایی داشته باشد.

### **مسیر دور موانع**

در چیدمان زیر، یک اتصال `BentConnector5` بین دو شکل از طریق شکل سومی عبور می‌کند:

![connector-obstruction](connector-obstruction.png)

این کد اتصال مسدود شده را می‌سازد:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

جابه‌جایی خم عمودی مسیر را طوری تغییر می‌دهد که اتصال از مانع عبور کند:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

به جای این که فرض کنید شاخص مجموعه `1` همیشه نمایانگر خم عمودی است، این مثال به دنبال `ConnectorBendPositionY` می‌گردد و فقط زمانی که نوع معنایی مورد انتظار موجود باشد، آن را تغییر می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

یک `BentConnector5` دو تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` دارد. اگر نوع مورد نیاز شما چند بار تکرار شده باشد، قبل از انتخاب یکی، `getName` و هندسهٔ شناخته‌شدهٔ آن پیش‌تنظیم را بررسی کنید. اگر یک تنظیم مقدار `ShapeAdjustmentType.Custom` برگرداند، معنای آن و بازهٔ مقادیر را به‌عنوان پیش‌تنظیم خاص در نظر بگیرید و تا زمانی که قرارداد آن روشن شود، تغییر ندهید.

## **ارتباط مقادیر تنظیم با هندسهٔ اتصال**

برای اتصالات خمیده، مقادیر تنظیم می‌توانند برای تخمین موقعیت بخش‌های جداگانهٔ اتصال استفاده شوند. این محاسبات به پیش‌تنظیم خاص اتصال وابسته است:

- `BentConnector4` معمولاً یک تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` را نشان می‌دهد.
- برای این موقعیت‌های خم، تقسیم مقدار برگشتی توسط `getRawValue` بر `100000f` کسری از عرض یا ارتفاع چارچوب اتصال را در مثال‌های زیر تولید می‌کند.
- چارچوب اتصال می‌تواند چرخش یا وارونگی داشته باشد، بنابراین مختصات چارچوب باید پیش از مقایسه با مختصات اسلاید تبدیل شوند.

مثال‌های زیر ابتدا با استفاده از `getType` تنظیمات را شناسایی می‌کنند. آن‌ها شاخص‌های مجموعه را به‌عنوان شناسهٔ قابل‌انتقال در نظر نمی‌گیرند.

### **اتصال بدون چرخش**

چیدمان اولیه شامل دو شکل متنی است که توسط یک `BentConnector4` به هم متصل شده‌اند:

![connector-shape-complex](connector-shape-complex.png)

این مثال اتصال را بررسی کرده و تنظیمات خم افقی و عمودی آن را دریافت می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

برای تغییر هر دو خم، هر نوع مورد انتظار را پیدا کنید و پس از یافتن هر دو مقدار را تغییر دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

نتیجه یک اتصال است که بخش‌های افقی و عمودی آن جابه‌جا شده‌اند:

![connector-adjusted-1](connector-adjusted-1.png)

پس از شناخت انواع معنایی، می‌توان مقادیر را به مختصات چارچوب اتصال تبدیل کرد. این مثال یک مستطیل نازک بر روی بخش عمودی که توسط دو تنظیم خم کنترل می‌شود می‌کشد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

شکل راهنما بخش محاسبه‌شده را نشان می‌دهد:

![connector-adjusted-2](connector-adjusted-2.png)

### **اتصال چرخیده یا وارونه**

زمانی که همان هندسهٔ اتصال به صورت عمودی قرار می‌گیرد، مقادیر [IShape.getFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getFrame--)، [ShapeFrame.getFlipH](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeframe/#getFlipH--) و [ShapeFrame.getFlipV](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeframe/#getFlipV--) بر تبدیل مختصات چارچوب اتصال به مختصات اسلاید تأثیر می‌گذارند.

این مثال اتصال عمودی را می‌سازد و تنظیم می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اتصال تنظیم‌شده به‌صورت عمودی بین شکل‌ها ظاهر می‌شود:

![connector-adjusted-3](connector-adjusted-3.png)

برای هر زاویهٔ چرخش دلخواه `alpha`، نقطهٔ چارچوب اتصال `(x, y)` را دور مرکز چارچوب `(x0, y0)` می‌چرخانیم:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

کد زیر وضعیت 90 درجهٔ استفاده‌شده در این مثال را مدیریت می‌کند و یک راهنمای قرمز بر روی بخش مربوطهٔ اتصال می‌کشد:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

راهنمای قرمز پس از تبدیل مختصات، بخش محاسبه‌شده را نشان می‌دهد:

![connector-adjusted-4](connector-adjusted-4.png)

این فرمول‌ها پیش‌تنظیم‌های استفاده‌شده در مثال‌ها را شرح می‌دهند، نه یک مدل کلی برای همهٔ اتصالات. پیش از اعمال همان محاسبه به پیش‌تنظیم دیگر، انواع تنظیمات، جهت‌گیری چارچوب و بازهٔ مقادیر را معتبرسازی کنید.

## **یافتن زاویهٔ جهت اتصال**

جهت یک اتصال مستقیم می‌تواند از عرض و ارتفاع آن، با در نظر گرفتن وارونگی‌های افقی و عمودی، محاسبه شود. مثال زیر زاویهٔ ساعتگرد نسبت به محور افقی مثبت در مختصات اسلاید را گزارش می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**چگونه تشخیص دهم که یک اتصال می‌تواند به شکل متصل شود؟**

مقدار [getConnectionSiteCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getConnectionSiteCount--) شکل را بررسی کنید. مقدار مثبت به این معنی است که شکل نقاط اتصال را ارائه می‌دهد. پیش از اختصاص شاخص نقطهٔ موردنظر، آن را اعتبارسنجی کنید.

**آیا می‌توانم تنظیمات یک اتصال را بر حسب شاخص مجموعه شناسایی کنم؟**

یک شاخص تنها برای پیش‌تنظیم شناخته‌شدهٔ اتصال و چیدمان مجموعه معنا دارد. پیش از تغییر مقدار، [IAdjustValue.getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getType--) را بررسی کنید و وقتی یک نوع معنایی چند بار ظاهر شد، از [IAdjustValue.getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iadjustvalue/#getName--) به‌عنوان اطلاعات تکمیلی استفاده کنید.

**وقتی شکلی که به آن متصل است حذف شود، چه اتفاقی می‌افتد؟**

سر مربوط به اتصال جدا می‌شود. اتصال همچنان در اسلاید باقی می‌ماند و می‌تواند حذف شود، به‌عنوان خط آزاد موقعیت یابد یا به شکل دیگری متصل شود.

**آیا پیوندهای اتصال هنگام کپی اسلاید حفظ می‌شوند؟**

در حالت کلی پیوندها هنگام کپی اسلاید همراه با شکل‌های متصل حفظ می‌شوند. اگر یک اتصال بدون یکی از شکل‌های هدف خود کپی شود، سر تحت‌اثر باید دوباره متصل گردد.