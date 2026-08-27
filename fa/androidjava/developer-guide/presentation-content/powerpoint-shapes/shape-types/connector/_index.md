---
title: مدیریت اتصال‌گرها در ارائه‌ها بر روی اندروید
linktitle: اتصال‌گر
type: docs
weight: 10
url: /fa/androidjava/connector/
keywords:
- اتصال‌گر
- نوع اتصال‌گر
- نقطه اتصال‌گر
- خط اتصال‌گر
- زاویه اتصال‌گر
- نقطه اتصال
- نقطه تنظیم
- متصل‌کردن اشکال
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای اندروید از طریق Java، اتصال‌گرهای مستقیم، خمیده و منحنی PowerPoint را اضافه، متصل، مسیردهی مجدد، تنظیم و بررسی کنید."
---
## **بررسی کلی**

یک اتصال‌گر خطی است که می‌تواند به دو شکل متصل بماند وقتی که هر یک از شکل‌ها حرکت می‌کنند. سرهای آن به نقاط اتصال که با نقاط سبز در پاورپوینت نشان داده می‌شوند، متصل می‌شوند. برخی از اتصال‌گرهای خمیده و منحنی همچنین نقاط تنظیمی را که با نقاط نارنجی نشان داده می‌شوند، افشا می‌کنند که موقعیت بخش‌های جداگانه اتصال‌گر را کنترل می‌کنند.

Aspose.Slides اتصال‌گرها را از طریق رابط [IConnector](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iconnector/) نشان می‌دهد. شما می‌توانید آنها را ایجاد کنید، سرهایشان را به اشکال متصل کنید، نقاط اتصال را انتخاب کنید، مسیر آن‌ها را دوباره تعیین کنید، و هندسه اتصال‌گرهایی که نقاط تنظیمی دارند را تغییر دهید.

## **انواع اتصال‌گر**

کلاس [ShapeType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapetype/) شامل پیش‌ تنظیمات اتصال‌گرهای مستقیم، خمیده و منحنی است. جدول زیر هندسه‌های موجود اتصال‌گر و تعداد نقاط تنظیمی تعریف‌شده توسط هر پیش‌ تنظیم را نشان می‌دهد.

| اتصال‌گر | تصویر | تعداد نقاط تنظیمی |
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

تعداد و معنای نقاط تنظیمی بخشی از پیش‌ تنظیمات اتصال‌گر انتخاب‌شده است. فرض نکنید که دو نوع اتصال‌گر متفاوت همان طرح‌بندی مجموعه را افشا می‌کنند.

## **اتصال دو شکل**

از [IShapeCollection.addConnector](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) برای افزودن یک اتصال‌گر استفاده کنید، و از [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) و [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) برای متصل کردن سرهای آن به اشکال استفاده کنید. پس از متصل شدن هر دو سر، [IConnector.reroute](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iconnector/#reroute--) مسیر کوتاهی بین اشکال انتخاب می‌کند.

مثال زیر یک بیضی و یک مستطیل را با یک اتصال‌گر خمیده متصل می‌کند:

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
فراخوانی `reroute` می‌تواند مقادیر [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) و [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) را تغییر دهد. پس از تغییر مسیر، در صورت نیاز به ثابت ماندن آن نقاط، سایت‌های خاص را دوباره اختصاص دهید.
{{% /alert %}}

## **انتخاب نقطه اتصال**

هر شکلی که قابلیت اتصال دارد تعداد سایت‌های خود را از طریق [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) گزارش می‌کند. قبل از اختصاص یک ایندکس سایت صفر مبنا به سر اتصال‌گر، مقدار آن را اعتبارسنجی کنید؛ تعداد سایت‌ها بسته به هندسه شکل متفاوت است.

این مثال اتصال‌گر را زمانی که سایت خاصی بر روی بیضی وجود داشته باشد، به آن سایت متصل می‌کند:

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

## **تنظیم نقطه اتصال‌گر**

اتصال‌گرهایی که نقاط تنظیمی دارند این نقاط را از طریق [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) افشا می‌کنند. قبل از تغییر مقدار هر [IAdjustValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/)، نوع آن را با فراخوانی [getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getType--) بررسی کنید و سپس با [setRawValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) مقدار را تغییر دهید. قوانین کلی شناسایی تنظیمات پیش‌ تنظیم شده شکل در بخش [Shape Manipulation](/slides/fa/androidjava/shape-manipulations/) توضیح داده شده است.

تعداد، ترتیب، معنی و دامنه مقدار معتبر تنظیمات اتصال‌گر بسته به پیش‌ تنظیم اتصال‌گر متفاوت است. نوع تنظیم فقط‑خواندنی است، در حالی که مقدار تنظیم قابل نوشتن است. متد فقط‑خواندنی [getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getName--) اطلاعات شناسایی بیشتری فراهم می‌کند وقتی یک اتصال‌گر بیش از یک تنظیم از همان نوع معنایی داشته باشد.

### **مسیر دور موانع**

در طرح زیر، یک اتصال‌گر `BentConnector5` بین دو شکل از شکل سوم عبور می‌کند:

![connector-obstruction](connector-obstruction.png)

این کد اتصال‌گر مسدود شده را ایجاد می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

جابه‌جایی خم عمودی مسیر را تغییر می‌دهد به‌طوری‌که اتصال‌گر مانع را دور می‌زند:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

به‌جای فرض اینکه ایندکس مجموعه `1` همیشه نشانگر خم عمودی باشد، این مثال به‌دنبال `ConnectorBendPositionY` می‌گردد و فقط زمانی که نوع معنایی مورد انتظار موجود باشد، آن را تغییر می‌دهد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

یک `BentConnector5` دو تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` دارد. اگر نوع مورد نیاز شما بیش از یک بار ظاهر شود، قبل از انتخاب یکی، `getName` و هندسه شناخته‑شدهٔ آن پیش‌ تنظیم را بررسی کنید. اگر یک تنظیم `ShapeAdjustmentType.Custom` گزارش شود، معنی و دامنهٔ آن را مخصوص پیش‌ تنظیم در نظر بگیرید و تا زمان آگاهی از قرارداد آن، تغییر ندهید.

## **ارتباط مقادیر تنظیمی با هندسه اتصال‌گر**

برای اتصال‌گرهای خمیده، مقادیر تنظیمی می‌توانند برای برآورد موقعیت بخش‌های جداگانه استفاده شوند. این محاسبات مخصوص پیش‌ تنظیم اتصال‌گر هستند:

- `BentConnector4` معمولاً یک تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` را در اختیار می‌گذارد.
- برای این موقعیت‌های خم، تقسیم مقدار بازگشتی از `getRawValue` بر `100000f` کسر عرض یا ارتفاع قاب اتصال‌گر را برای مثال‌های زیر تولید می‌کند.
- قاب اتصال‌گر می‌تواند چرخیده یا معکوس شود، بنابراین مختصات قاب باید قبل از مقایسه با مختصات اسلاید تبدیل شوند.

مثال‌های زیر ابتدا با استفاده از `getType` تنظیمات را شناسایی می‌کنند. آنها ایندکس‌های مجموعه را به‌عنوان شناسه‌های قابل‌انتقال در نظر نمی‌گیرند.

### **اتصال‌گر بدون چرخش**

طرح اولیه شامل دو شکل متنی است که توسط یک `BentConnector4` به هم متصل شده‌اند:

![connector-shape-complex](connector-shape-complex.png)

این مثال اتصال‌گر را بررسی می‌کند و تنظیمات خم افقی و عمودی آن را به‌دست می‌آورد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

برای تغییر هر دو خم، هر نوع مورد انتظار را پیدا کنید و مقادیر را فقط پس از یافتن هر دو تغییر دهید:

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

نتیجه یک اتصال‌گر است که بخش‌های افقی و عمودی آن جابه‌جا شده‌اند:

![connector-adjusted-1](connector-adjusted-1.png)

پس از شناخته شدن انواع معنایی، می‌توان مقادیر را به مختصات قاب اتصال‌گر تبدیل کرد. این مثال یک مستطیل نازک بر روی بخش عمودی که توسط دو تنظیم خم کنترل می‌شود می‌کشد:

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

### **اتصال‌گر چرخیده یا معکوس شده**

زمانی که همان هندسه اتصال‌گر به صورت عمودی جهت‌دار شود، مقادیر [IShape.getFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getFrame--)، [ShapeFrame.getFlipH](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeframe/#getFlipH--) و [ShapeFrame.getFlipV](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeframe/#getFlipV--) بر تبدیل از مختصات قاب اتصال‌گر به مختصات اسلاید تأثیر می‌گذارند.

این مثال اتصال‌گر عمودی‌جهت‌دار را ایجاد و تنظیم می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
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

اتصال‌گر تنظیم‌شده به‌صورت عمودی بین اشکال ظاهر می‌شود:

![connector-adjusted-3](connector-adjusted-3.png)

برای یک زاویهٔ چرخش دلخواه `alpha`، نقطهٔ `(x, y)` در قاب اتصال‌گر را به دور مرکز قاب `(x0, y0)` می‌چرخانیم:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

کد زیر جهت ۹۰ درجه استفاده‌شده در این مثال را مدیریت می‌کند و یک راهنمای قرمز بر روی بخش مربوط به اتصال‌گر می‌کشد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

این فرمول‌ها پیش‌ تنظیمات استفاده‌شده در مثال‌ها را توصیف می‌کنند، نه یک مدل کلی برای تمام اتصال‌گرها. پیش‌ تنظیمات نوع، جهت قاب و دامنه مقادیر را قبل از اعمال همان محاسبه به پیش‌ تنظیم دیگر اعتبارسنجی کنید.

## **یافتن زاویه جهت اتصال‌گر**

جهت یک اتصال‌گر مستقیم می‌تواند از عرض و ارتفاع آن، به‌همراه اعمال چرخش‌های افقی و عمودی، محاسبه شود. مثال زیر زاویه ساعت‌گرد نسبت به محور افقی مثبت در مختصات اسلاید را گزارش می‌کند:

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

**چگونه می‌توانم تشخیص دهم یک اتصال‌گر می‌تواند به یک شکل متصل شود؟**

مقدار [getConnectionSiteCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) شکل را بررسی کنید. مقدار مثبت به این معنی است که شکل نقاط اتصال را افشا می‌کند. قبل از اختصاص ایندکس سایت منتخب به هر سر اتصال‌گر، آن را اعتبارسنجی کنید.

**آیا می‌توانم تنظیمات یک اتصال‌گر را با ایندکس مجموعه‌اش شناسایی کنم؟**

یک ایندکس تنها برای پیش‌ تنظیم شناخته‌شدهٔ اتصال‌گر و طرح‌بندی مجموعه معنی دارد. قبل از تغییر مقدار، [IAdjustValue.getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getType--) را بررسی کنید و در صورتی که یک نوع معنایی بیش از یک بار ظاهر می‌شود، از [IAdjustValue.getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iadjustvalue/#getName--) به‌عنوان اطلاعات تکمیلی استفاده کنید.

**وقتی شکل متصل حذف شود چه اتفاقی می‌افتد؟**

سر مربوط به آن شکل منفصل می‌شود. اتصال‌گر در اسلاید باقی می‌ماند و می‌تواند حذف شود، به صورت خط آزاد موقعیت یابد یا به شکل دیگری متصل شود.

**آیا اتصال‌گرها هنگام کپی اسلاید حفظ می‌شوند؟**

به‌طور کلی، وقتی اشکال متصل همراه با اسلاید کپی شوند، ارتباطات حفظ می‌شوند. اگر یک اتصال‌گر بدون یکی از اشکال هدف کپی شود، سر تحت‌اثر باید دوباره متصل شود.