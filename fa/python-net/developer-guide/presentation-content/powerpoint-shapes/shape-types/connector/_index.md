---
title: مدیریت اتصال‌کننده‌ها در ارائه‌ها با پایتون
linktitle: اتصال‌کننده
type: docs
weight: 10
url: /fa/python-net/connector/
keywords:
- اتصال‌کننده
- نوع اتصال‌کننده
- نقطهٔ اتصال‌کننده
- خط اتصال‌کننده
- زاویهٔ اتصال‌کننده
- نقطهٔ اتصال
- نقطهٔ تنظیم
- اتصال اشکال
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه اتصال‌کننده‌های مستقیم، خمیده و منحنی PowerPoint را با Aspose.Slides برای پایتون از طریق .NET اضافه، متصل، مسیردهی مجدد، تنظیم و بررسی کنید."
---
## **مرور کلی**

یک اتصال‌کننده خطی است که می‌تواند هنگام جابجایی هر دو شکل، به هر دو متصل بماند. انتهای آن به نقاط اتصال متصل می‌شود که در پاورپوینت با نقاط سبز نمایش داده می‌شوند. برخی از اتصال‌کننده‌های خمیده و منحنی نیز نقاط تنظیمی (نقاط نارنجی) دارند که موقعیت بخش‌های مختلف اتصال‌کننده را کنترل می‌کنند.

Aspose.Slides اتصال‌کننده‌ها را از طریق واسط [IConnector](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iconnector/) نمایش می‌دهد. می‌توانید آن‌ها را ایجاد کنید، انتهایشان را به شکل‌ها وصل کنید، نقاط اتصال را انتخاب کنید، مسیرشان را دوباره تنظیم کنید و هندسهٔ اتصال‌کننده‌های دارای نقاط تنظیم را تغییر دهید.

## **انواع اتصال‌کننده**

شمارشگر [ShapeType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapetype/) شامل پیش‌تنظیم‌های اتصال‌کنندهٔ مستقیم، خمیده و منحنی است. جدول زیر هندسهٔ دسترس‌پذیر هر پیش‌تنظیم و تعداد نقاط تنظیم تعریف‌شده برای هر یک را نشان می‌دهد.

| Connector | Image | Number of adjustment points |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

تعداد و معنی نقاط تنظیم بخشی از پیش‌تنظیم انتخاب‌شدهٔ اتصال‌کننده است. فرض نکنید دو نوع اتصال‌کنندهٔ مختلف، همان چیدمان مجموعه را ارائه می‌دهند.

## **اتصال دو شکل**

از [IShapeCollection.add_connector](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapecollection/add_connector/) برای افزودن یک اتصال‌کننده استفاده کنید و ویژگی‌های [start_shape_connected_to](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iconnector/start_shape_connected_to/) و [end_shape_connected_to](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iconnector/end_shape_connected_to/) را مقداردهی کنید. پس از وصل شدن هر دو انتها، متد [IConnector.reroute](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iconnector/reroute/) مسیر کوتاهی بین دو شکل انتخاب می‌کند.

مثال زیر یک بیضی و یک مستطیل را با یک اتصال‌کنندهٔ خمیده به هم وصل می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}

فراخوانی `reroute` می‌تواند مقادیر [start_shape_connection_site_index](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) و [end_shape_connection_site_index](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) را تغییر دهد. پس از تغییر مسیر، در صورت نیاز، نقاط اتصال خاص را دوباره اختصاص دهید تا ثابت بمانند.

{{% /alert %}}

## **انتخاب نقطه اتصال**

هر شکلی که قابلیت اتصال دارد، تعداد نقاط خود را از طریق [connection_site_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/igeometryshape/connection_site_count/) گزارش می‌کند. قبل از اختصاص یک اندیس صفر‑مبنایی به انتهای اتصال‌کننده، صحت آن را تأیید کنید؛ تعداد نقاط بسته به هندسهٔ شکل متفاوت است.

در مثال زیر اتصال‌کننده به نقطهٔ خاصی روی بیضی متصل می‌شود، در صورتی که آن نقطه موجود باشد:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم نقطهٔ اتصال‌کننده**

اتصال‌کننده‌هایی که نقاط تنظیم دارند این نقاط را از طریق [IGeometryShape.adjustments](https://reference.aspose.com/slides/fa/python-net/aspose.slides/igeometryshape/adjustments/) در دسترس می‌گذارند. قبل از تغییر [raw_value](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iadjustvalue/raw_value/) هر [IAdjustValue](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iadjustvalue/)، نوع آن را با استفاده از [type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iadjustvalue/type/) بررسی کنید. برای دستکاری عمومی شکل‌ها، به صفحهٔ [Shape Manipulation](/slides/fa/python-net/shape-manipulations/) مراجعه کنید.

تعداد، ترتیب، معنی و بازهٔ مقادیر معتبر تنظیمات وابسته به پیش‌تنظیم اتصال‌کننده است. ویژگی `type` فقط‑خواندنی است، در حالی که مقدار تنظیم قابل نوشتن است. ویژگی فقط‑خواندنی [name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iadjustvalue/name/) برای شناسایی اضافی هنگامی که یک اتصال‌کننده بیش از یک تنظیم از همان نوع معنایی داشته باشد، مفید است.

### **مسیر دور مانع**

در چیدمان زیر، یک اتصال‌کنندهٔ `ShapeType.BENT_CONNECTOR5` بین دو شکل از وسط شکلٔ سوم می‌گذرد:

![connector-obstruction](connector-obstruction.png)

کد زیر اتصال‌کنندهٔ مسدودشده را می‌سازد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

حرکت خم عمودی مسیر را تغییر می‌دهد به‌طوری که اتصال‌کننده مانع را دور می‌زند:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

به جای این‌که فرض کنید اندیس مجموعهٔ `1` همیشه نمایانگر خم عمودی است، این مثال به دنبال `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` می‌گردد و فقط زمانی که نوع معنایی مورد انتظار حضور داشته باشد، آن را تغییر می‌دهد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

یک `ShapeType.BENT_CONNECTOR5` دو تنظیم `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` و یک تنظیم `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` دارد. اگر نوع مورد نیاز شما بیش از یک بار ظاهر شود، قبل از انتخاب، `name` و هندسهٔ شناخته‌شدهٔ آن پیش‌تنظیم را بررسی کنید. اگر یک تنظیم مقدار [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapeadjustmenttype/) گزارش دهد، معنی و بازهٔ آن را مخصوص پیش‌تنظیم درنظر بگیرید و تا زمانی که قرارداد آن مشخص نشود، تغییر ندهید.

## **ارتباط مقادیر تنظیم با هندسهٔ اتصال‌کننده**

برای اتصال‌کننده‌های خمیده، می‌توان از مقادیر تنظیم برای تخمین موقعیت بخش‌های جداگانه استفاده کرد. این محاسبات مخصوص پیش‌تنظیم اتصال‌کننده هستند:

- `ShapeType.BENT_CONNECTOR4` معمولاً یک تنظیم `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` و یک تنظیم `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` را ارائه می‌دهد.
- برای این موقعیت‌ها، `raw_value / 100000` کسر عرض یا ارتفاع چارچوب اتصال‌کننده را تولید می‌کند.
- چارچوب اتصال‌کننده می‌تواند چرخانده یا وارونه شود، بنابراین مختصات چارچوب باید قبل از مقایسه با مختصات اسلاید تبدیل شوند.

مثال‌های زیر ابتدا با استفاده از `type` تنظیمات را شناسایی می‌کند و از اندیس‌های مجموعه به عنوان شناسهٔ قابل‌انتقال استفاده نمی‌کند.

### **اتصال‌کننده بدون چرخش**

چیدمان اولیه شامل دو شکل متنی است که با یک `ShapeType.BENT_CONNECTOR4` متصل هستند:

![connector-shape-complex](connector-shape-complex.png)

این مثال اتصال‌کننده را بررسی می‌کند و تنظیمات خم افقی و عمودی را دریافت می‌کند:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

برای تغییر هر دو خم، هر نوع مورد انتظار را پیدا کنید و پس از یافتن هر دو مقدار را اصلاح کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه یک اتصال‌کننده است که بخش‌های افقی و عمودی آن جابه‌جا شده‌اند:

![connector-adjusted-1](connector-adjusted-1.png)

پس از شناخته شدن انواع معنایی، می‌توان مقادیر را به مختصات چارچوب اتصال‌کننده تبدیل کرد. این مثال یک مستطیل باریک روی بخش عمودی که توسط دو تنظیم خم کنترل می‌شود می‌کشد:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

شکل راهنمایی بخش محاسبه‌شده را نشان می‌دهد:

![connector-adjusted-2](connector-adjusted-2.png)

### **اتصال‌کننده چرخانده‌شده یا وارونه**

زمانی که همان هندسهٔ اتصال‌کننده به صورت عمودی تنظیم می‌شود، مقادیر [frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iconnector/frame/)، [flip_h](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapeframe/flip_h/) و [flip_v](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapeframe/flip_v/) بر تبدیل مختصات چارچوب به مختصات اسلاید تأثیر می‌گذارند.

این مثال اتصال‌کنندهٔ عمودی را می‌سازد و تنظیم می‌کند:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

اتصال‌کنندهٔ تنظیم‌شده به‌صورت عمودی بین دو شکل ظاهر می‌شود:

![connector-adjusted-3](connector-adjusted-3.png)

برای یک زاویهٔ چرخش دلخواه `alpha`، نقطهٔ چارچوب اتصال‌کننده `(x, y)` را حول مرکز چارچوب `(x0, y0)` می‌چرخانیم:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

کد زیر جهتٔ ۹۰ درجهٔ استفاده‌شده در این مثال را پردازش می‌کند و راهنمایی قرمز رنگ بر روی بخش متناظر اتصال‌کننده می‌کشد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

راهنمای قرمز بخش محاسبه‌شده پس از تبدیل مختصات را نشان می‌دهد:

![connector-adjusted-4](connector-adjusted-4.png)

این فرمول‌ها مربوط به پیش‌تنظیم‌های استفاده‌شده در مثال‌ها هستند و مدل جهانی برای اتصال‌کننده‌ها نیستند. قبل از اعمال محاسبهٔ مشابه به پیش‌تنظیم دیگر، انواع تنظیم، جهت چارچوب و بازهٔ مقادیر را تأیید کنید.

## **پیدا کردن زاویهٔ جهت اتصال‌کننده**

جهت یک اتصال‌کنندهٔ مستقیم می‌تواند از عرض و ارتفاع آن، با در نظر گرفتن وارونه‌های افقی و عمودی، محاسبه شود. مثال زیر زاویهٔ ساعتگرد از محور افقی مثبت در مختصات اسلاید را گزارش می‌کند:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **سؤالات متداول**

**چگونه می‌توانم بفهمم آیا یک اتصال‌کننده می‌تواند به یک شکل متصل شود؟**

تعداد نقاط اتصال شکل را با [connection_site_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/igeometryshape/connection_site_count/) بررسی کنید. مقدار مثبت نشان می‌دهد شکل نقاط اتصال دارد. قبل از اختصاص اندیس سایت انتخاب‌شده به هر انتهای اتصال‌کننده، آن را تأیید کنید.

**آیا می‌توانم یک تنظیم اتصال‌کننده را بر اساس اندیس مجموعه شناسایی کنم؟**

اندیس فقط برای پیش‌تنظیم شناخته‌شدهٔ اتصال‌کننده و چیدمان مجموعه معنی دارد. قبل از تغییر مقدار، [IAdjustValue.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iadjustvalue/type/) را بررسی کنید و برای مواردی که همان نوع معنایی چندین بار ظاهر می‌شود، از [IAdjustValue.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iadjustvalue/name/) به عنوان اطلاعات تکمیلی استفاده کنید.

**وقتی یک شکل متصل حذف شود چه اتفاقی می‌افتد؟**

انتهای مربوط به آن اتصال‌کننده جدا می‌شود. اتصال‌کننده بر روی اسلاید باقی می‌ماند و می‌توان آن را حذف کرد، به‌عنوان خط آزاد موقعیت داد یا به شکل دیگری متصل کرد.

**آیا اتصال‌های اتصال‌کننده هنگام کپی اسلاید حفظ می‌شوند؟**

به‌طور معمول، وقتی شکل‌های متصل با اسلاید کپی می‌شوند، اتصال‌ها حفظ می‌شوند. اگر یک اتصال‌کننده بدون یکی از شکل‌های هدفش کپی شود، انتهای متاثر باید دوباره متصل شود.