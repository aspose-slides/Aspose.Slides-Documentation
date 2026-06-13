---
title: مدیریت کانکتورها در ارائه‌ها با پایتون
linktitle: کانکتور
type: docs
weight: 10
url: /fa/python-net/connector/
keywords:
- کانکتور
- نوع کانکتور
- نقطه کانکتور
- خط کانکتور
- زاویه کانکتور
- اتصال اشکال
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "به برنامه‌های پایتون توانایی رسم، اتصال و مسیربندی خودکار خطوط در اسلایدهای PowerPoint و OpenDocument را بدهید — کنترل کامل بر کانکتورهای مستقیم، زاویه‌دار و منحنی را به دست آورید."
---
## **مقدمه**

یک کانکتور پاورپوینت خطی تخصصی است که دو شکل را به هم متصل می‌کند و هنگام جابجایی یا تغییر موقعیت شکل‌ها بر روی اسلاید به آنها چسبیده می‌ماند. کانکتورها به **نقاط اتصال** (نقاط سبز) روی اشکال متصل می‌شوند. نقاط اتصال زمانی ظاهر می‌شوند که اشاره‌گر به آنها نزدیک می‌شود. **دسته‌های تنظیم** (نقاط زرد)، که در برخی کانکتورها موجود هستند، به شما امکان می‌دهند موقعیت و شکل کانکتور را تغییر دهید.

## **انواع کانکتور**

در پاورپوینت می‌توانید از سه نوع کانکتور استفاده کنید: مستقیم، آرشی (زاویه‌دار) و منحنی.

Aspose.Slides انواع زیر از کانکتورها را پشتیبانی می‌کند:

| نوع کانکتور                     | تصویر                                                     | تعداد نقاط تنظیم |
| ------------------------------- | --------------------------------------------------------- | ---------------- |
| `ShapeType.LINE`                | ![Line connector](shapetype-lineconnector.png)            | 0                |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Straight connector 1](shapetype-straightconnector1.png) | 0                |
| `ShapeType.BENT_CONNECTOR2`     | ![Bent connector 2](shapetype-bent-connector2.png)        | 0                |
| `ShapeType.BENT_CONNECTOR3`     | ![Bent connector 3](shapetype-bentconnector3.png)         | 1                |
| `ShapeType.BENT_CONNECTOR4`     | ![Bent connector 4](shapetype-bentconnector4.png)         | 2                |
| `ShapeType.BENT_CONNECTOR5`     | ![Bent connector 5](shapetype-bentconnector5.png)         | 3                |
| `ShapeType.CURVED_CONNECTOR2`   | ![Curved connector 2](shapetype-curvedconnector2.png)     | 0                |
| `ShapeType.CURVED_CONNECTOR3`   | ![Curved connector 3](shapetype-curvedconnector3.png)     | 1                |
| `ShapeType.CURVED_CONNECTOR4`   | ![Curved connector 4](shapetype-curvedconnector4.png)     | 2                |
| `ShapeType.CURVED_CONNECTOR5`   | ![Curved connector 5](shapetype.curvedconnector5.png)     | 3                |

## **اتصال اشکال با کانکتورها**

این بخش نحوهٔ اتصال اشکال با استفاده از کانکتورها در Aspose.Slides را نشان می‌دهد. شما یک کانکتور به اسلاید اضافه می‌کنید و ابتدای آن و انتهای آن را به اشکال هدف متصل می‌کنید. استفاده از نقاط اتصال تضمین می‌کند که کانکتور حتی هنگام جابجایی یا تغییر اندازهٔ اشکال «چسبانده» باقی بماند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از ایندکس، به اسلاید ارجاع بگیرید.  
1. دو شیء [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید با استفاده از متد `add_auto_shape` که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) در دسترس است.  
1. یک کانکتور با استفاده از متد `add_connector` که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) در دسترس است اضافه کنید و نوع کانکتور را مشخص کنید.  
1. اشکال را با کانکتور متصل کنید.  
1. متد `reroute` را فراخوانی کنید تا کوتاه‌ترین مسیر اتصال اعمال شود.  
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چطور یک کانکتور خمیده بین دو شکل (یک بیضی و یک مستطیل) اضافه شود:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید تا یک فایل PPTX ایجاد شود.
with slides.Presentation() as presentation:

    # دسترسی به مجموعه شکل‌ها برای اولین اسلاید.
    shapes = presentation.slides[0].shapes

    # یک AutoShape بیضی اضافه کنید.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # یک AutoShape مستطیل اضافه کنید.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # یک کانکتور به اسلاید اضافه کنید.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # اشکال را با کانکتور متصل کنید.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # متد reroute را فراخوانی کنید تا کوتاه‌ترین مسیر تنظیم شود.
    connector.reroute()

    # ارائه را ذخیره کنید.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
متد `connector.reroute` یک کانکتور را باز مسیر می‌دهد و آن را مجبور می‌کند کوتاه‌ترین مسیر ممکن بین اشکال را اتخاذ کند. برای این کار، ممکن است مقادیر `start_shape_connection_site_index` و `end_shape_connection_site_index` تغییر یابند.
{{% /alert %}}

## **مشخص کردن نقاط اتصال**

این بخش توضیح می‌دهد چطور یک کانکتور را به نقطهٔ اتصال خاصی روی یک شکل در Aspose.Slides متصل کنید. با هدف‌گذاری دقیق بر روی سایت‌های اتصال، می‌توانید مسیر و چینش کانکتور را کنترل کنید و نمودارهای تمیز و پیش‌بینی‌پذیری در ارائه‌های خود تولید کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از ایندکس، به اسلاید ارجاع بگیرید.  
1. دو شیء [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید با استفاده از متد `add_auto_shape` که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) در دسترس است.  
1. یک کانکتور با استفاده از متد `add_connector` بر روی شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) اضافه کنید و نوع کانکتور را مشخص کنید.  
1. اشکال را با کانکتور متصل کنید.  
1. نقاط اتصال دلخواه خود را روی اشکال تنظیم کنید.  
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چطور یک نقطهٔ اتصال دلخواه را مشخص کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید تا یک فایل PPTX ساخته شود.
with slides.Presentation() as presentation:

    # دسترسی به مجموعهٔ اشکال برای اولین اسلاید.
    shapes = presentation.slides[0].shapes

    # یک AutoShape بیضی اضافه کنید.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # یک AutoShape مستطیل اضافه کنید.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # یک کانکتور به مجموعهٔ اشکال اسلاید اضافه کنید.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # اشکال را با کانکتور متصل کنید.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # اندیس سایت اتصال ترجیحی را روی بیضی تنظیم کنید.
    site_index = 6

    # بررسی کنید که اندیس ترجیحی در تعداد سایت‌های موجود باشد.
    if  ellipse.connection_site_count > site_index:
        # سایت اتصال ترجیحی را بر روی AutoShape بیضی اختصاص دهید.
        connector.start_shape_connection_site_index = site_index

    # ارائه را ذخیره کنید.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم نقاط کانکتور**

می‌توانید با استفاده از نقاط تنظیم، کانکتورها را تغییر دهید. فقط کانکتورهایی که نقاط تنظیم را افشا می‌کنند می‌توانند به این شکل ویرایش شوند. برای جزئیات دربارهٔ اینکه کدام کانکتورها از تنظیمات پشتیبانی می‌کنند، به جدول زیر در بخش [Connector Types](/slides/fa/python-net/connector/#connector-types) مراجعه کنید.

### **مورد ساده**

در نظر بگیرید یک کانکتور بین دو شکل (A و B) با یک شکل سوم (C) تداخل دارد:

![Connector obstruction](connector-obstruction.png)

نمونه کد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

برای دور زدن شکل سوم، کانکتور را با جابه‌جایی قطعهٔ عمودی به سمت چپ تنظیم کنید:

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **موارد پیچیده**

برای تنظیمات پیشرفته‌تر، موارد زیر را در نظر بگیرید:

- نقطهٔ تنظیم‌پذیر یک کانکتور توسط فرمولی که موقعیت آن را تعیین می‌کند، حاکم است. تغییر این نقطه می‌تواند شکل کلی کانکتور را تغییر دهد.  
- نقاط تنظیم یک کانکتور در یک آرایهٔ به‌صورت مرتبی ذخیره می‌شود که از ابتدای کانکتور تا انتهای آن شماره‌گذاری شده است.  
- مقادیر نقاط تنظیم به صورت درصدی از عرض/ارتفاع شکل کانکتور هستند.  
  - شکل توسط نقاط شروع و پایان کانکتور محدود می‌شود و به‌صورت ۱۰۰۰ مقیاس می‌شود.  
  - اولین، دومین و سومین نقاط تنظیم به ترتیب: درصد عرض، درصد ارتفاع و دوباره درصد عرض را نشان می‌دهند.  
- هنگام محاسبهٔ مختصات نقاط تنظیم، چرخش و بازتاب کانکتور را در نظر بگیرید. **نکته:** برای تمام کانکتورهای فهرست‌شده در بخش [Connector Types](/slides/fa/python-net/connector/#connector-types)، زاویهٔ چرخش برابر ۰ است.

#### **مورد 1**

در نظر بگیرید دو شیء فریم متنی با یک کانکتور به‌هم متصل هستند:

![Linked shapes](connector-shape-complex.png)

نمونه کد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation ایجاد کنید تا یک فایل PPTX ساخته شود.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # دریافت اولین اسلاید.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # یک کانکتور اضافه کنید.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # جهت کانکتور را تنظیم کنید.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # رنگ کانکتور را تنظیم کنید.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # ضخامت خط کانکتور را تنظیم کنید.
    connector.line_format.width = 3

    # اشکال را با کانکتور متصل کنید.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # نقاط تنظیم کانکتور را دریافت کنید.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**تنظیم**

مقدارهای نقاط تنظیم کانکتور را با افزایش ۲۰٪ درصد عرض و ۲۰۰٪ درصد ارتفاع به ترتیب تغییر دهید:

```python
    # مقادیر نقاط تنظیم را تغییر دهید.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

نتیجه:

![Connector adjustment 1](connector-adjusted-1.png)

برای تعریف مدلی که بتواند مختصات و شکل قطعات کانکتور را تعیین کند، شکلی بسازید که به مؤلفهٔ عمودی کانکتور در `connector.adjustments[0]` متناظر باشد:

```python
    # جزء عمودی کانکتور را رسم کنید.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

نتیجه:

![Connector adjustment 2](connector-adjusted-2.png)

#### **مورد 2**

در **Case 1**، یک تنظیم سادهٔ کانکتور را با اصول پایه نشان دادیم. در سناریوهای معمول، باید چرخش کانکتور و تنظیمات نمایش آن (که توسط `connector.rotation`، `connector.frame.flip_h` و `connector.frame.flip_v` کنترل می‌شود) را در نظر بگیرید. در ادامه نحوهٔ انجام این کار شرح داده می‌شود.

ابتدا یک شیء فریم متنی جدید (**To 1**) به اسلاید (برای اتصال) اضافه کنید و یک کانکتور سبز جدید بسازید که آن را به اشیای موجود متصل کند.

```python
    # یک شیء هدف جدید ایجاد کنید.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # یک کانکتور جدید ایجاد کنید.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # اشیاء را با استفاده از کانکتور تازه ایجاد شده متصل کنید.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # نقاط تنظیم کانکتور را دریافت کنید.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # مقادیر نقاط تنظیم را تغییر دهید.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

نتیجه:

![Connector adjustment 3](connector-adjusted-3.png)

سپس شکلی بسازید که به بخش **افقی** کانکتور که از نقطهٔ تنظیم جدید `connector.adjustments[0]` عبور می‌کند، متناظر باشد. از مقادیر `connector.rotation`، `connector.frame.flip_h` و `connector.frame.flip_v` استفاده کنید و فرمول تبدیل مختصات استاندارد برای چرخش حول نقطهٔ داده‌شدهٔ `x0` را اعمال نمایید:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

در مثال ما زاویهٔ چرخش شیء ۹۰ درجه است و کانکتور به‌صورت عمودی نمایش داده می‌شود، بنابراین کد مربوطه به شکل زیر است:

```python
    # مختصات کانکتور را ذخیره کنید.
    x = connector.x
    y = connector.y
    
    # اگر کانکتور معکوس شده باشد، مختصات را تصحیح کنید.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # مقدار نقطه تنظیم را به عنوان مختصات استفاده کنید.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # مختصات را تبدیل کنید چون sin(90°) = 1 و cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # عرض قطعه افقی را با استفاده از مقدار نقطه تنظیم دوم تعیین کنید.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

نتیجه:

![Connector adjustment 4](connector-adjusted-4.png)

ما محاسبات مربوط به تنظیمات ساده و نقاط تنظیم پیچیده‌تر (آنهایی که چرخش را درنظر می‌گیرند) را نشان دادیم. با استفاده از این دانش می‌توانید مدل خود را توسعه دهید—یا کدی بنویسید—تا یک شیء `GraphicsPath` دریافت کنید یا حتی مقادیر نقاط تنظیم یک کانکتور را بر اساس مختصات خاصی در اسلاید تنظیم کنید.

## **یافتن زاویه خطوط کانکتور**

از مثال زیر برای تعیین زاویهٔ خطوط کانکتور روی اسلاید با Aspose.Slides استفاده کنید. خواهید آموخت چگونه نقاط انتهایی یک کانکتور را بخوانید و جهت آن را محاسبه کنید تا بتوانید پیکان‌ها، برچسب‌ها و سایر اشکال را به‌دقت هم‌راستا کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. به اسلاید از طریق ایندکس دسترسی پیدا کنید.  
1. به شکل خطی کانکتور دسترسی پیدا کنید.  
1. از عرض و ارتفاع خط، و همچنین عرض و ارتفاع فریم شکل، برای محاسبهٔ زاویه استفاده کنید.

کد پایتون زیر نحوهٔ محاسبهٔ زاویه برای یک شکل خطی کانکتور را نشان می‌دهد:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک کانکتور می‌تواند به شکل خاصی «چسبانده» شود؟**  
اطمینان حاصل کنید که شکل [نقاط اتصال](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/connection_site_count/) را افشا می‌کند. اگر هیچ‌کدام وجود نداشته باشد یا شمارش صفر باشد، قابلیت چسباندن در دسترس نیست؛ در این حالت از نقاط انتهایی آزاد استفاده کنید و آنها را به‌صورت دستی موقعیت‌دهی کنید. بهتر است قبل از اتصال، شمارش سایت‌ها را بررسی کنید.

**چه اتفاقی برای یک کانکتور می‌افتد اگر یکی از اشکال متصل را حذف کنم؟**  
سرهای آن جدا می‌شوند؛ کانکتور به‌عنوان یک خط عادی با نقاط شروع/پایان آزاد بر روی اسلاید باقی می‌ماند. می‌توانید آن را حذف کنید یا اتصالات را دوباره اختصاص دهید و در صورت نیاز، [reroute](https://reference.aspose.com/slides/fa/python-net/aspose.slides/connector/reroute/) کنید.

**آیا پیوندهای کانکتور هنگام کپی اسلاید به ارائهٔ دیگری حفظ می‌شوند؟**  
عموماً بله، به شرطی که اشکال هدف نیز کپی شوند. اگر اسلاید بدون اشکال متصل به‌فایل دیگر وارد شود، سرها آزاد می‌شوند و باید دوباره متصل شوند.