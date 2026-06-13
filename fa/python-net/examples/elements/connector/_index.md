---
title: کانکتور
type: docs
weight: 190
url: /fa/python-net/examples/elements/connector/
keywords:
- کانکتور
- افزودن کانکتور
- دسترسی به کانکتور
- حذف کانکتور
- اتصال مجدد اشکال
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کشیدن و کنترل کانکتورها در Python با Aspose.Slides: اضافه کردن، مسیردهی، مسیردوباره، تنظیم نقاط اتصال، پیکان‌ها و سبک‌ها برای لینک کردن اشکال در PPT، PPTX و ODP."
---
نحوه اتصال اشکال با کانکتورها و تغییر هدف‌های آن‌ها را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد.

## **افزودن یک کانکتور**

یک شکل کانکتور را بین دو نقطه در اسلاید وارد کنید.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # اضافه کردن یک شکل کانکتور خمیده.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به یک کانکتور**

اولین شکل کانکتور افزوده شده به یک اسلاید را بازیابی کنید.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین کانکتور در اسلاید.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **حذف یک کانکتور**

یک کانکتور را از اسلاید حذف کنید.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض کنید شکل اول یک کانکتور است.
        connector = slide.shapes[0]

        # حذف کانکتور.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **اتصال مجدد اشکال**

یک کانکتور را به دو شکل متصل کنید با اختصاص هدف‌های شروع و پایان.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # افزودن اولین شکل مستطیل.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # افزودن دومین شکل مستطیل.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # افزودن یک شکل کانکتور خمیده.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # اتصال نقطه شروع کانکتور به اولین شکل.
        connector.start_shape_connected_to = shape1
        # اتصال نقطه پایان کانکتور به دومین شکل.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```