---
title: جعبه متن
type: docs
weight: 40
url: /fa/python-net/examples/elements/text-box/
keywords:
- جعبه متن
- افزودن جعبه متن
- دسترسی به جعبه متن
- حذف جعبه متن
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "ایجاد و قالب‌بندی جعبه‌های متن در پایتون با Aspose.Slides: تنظیم قلم‌ها، تراز، بسته‌بندی، خود‌انطباق، و لینک‌ها برای بهبود اسلایدها در PowerPoint و OpenDocument."
---
در Aspose.Slides، یک **جعبه متن** توسط یک `AutoShape` نمایش داده می‌شود. تقریباً هر شکل می‌تواند متن داشته باشد، اما یک جعبه متن معمولی پر یا حاشیه ندارد و فقط متن را نمایش می‌دهد.

این راهنما نحوه افزودن، دسترسی و حذف جعبه‌های متن را به‌صورت برنامه‌نویسی توضیح می‌دهد.

## **افزودن یک جعبه متن**

یک جعبه متن در واقع یک `AutoShape` بدون پر یا حاشیه و دارای متنی قالب‌بندی شده است. در اینجا نحوه ایجاد آن را می‌بینید:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # یک شکل مستطیلی ایجاد کنید (به‌صورت پیش‌فرض پر شده با حاشیه و بدون متن).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # پر و حاشیه را حذف کنید تا شبیه یک جعبه متن معمولی به نظر برسد.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # تنظیم قالب‌بندی متن.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # اختصاص محتوای متنی واقعی.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نکته:** هر `AutoShape` که شامل یک `TextFrame` غیر خالی باشد می‌تواند به عنوان یک جعبه متن عمل کند.

## **دسترسی به جعبه‌های متن بر اساس محتوا**

برای یافتن تمام جعبه‌های متنی که شامل یک کلمه کلیدی خاص هستند (مثلاً «Slide»)، بر روی شکل‌ها پیمایش کنید و متن آنها را بررسی کنید:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # فقط AutoShapeها می‌توانند متن قابل ویرایش داشته باشند.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # کاری با جعبه متن مطابق انجام دهید.
                    pass
```

## **حذف جعبه‌های متن بر اساس محتوا**

این مثال تمام جعبه‌های متنی را در اولین اسلاید که شامل یک کلمه کلیدی خاص هستند پیدا کرده و حذف می‌کند:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # اشکالی که باید حذف شوند را پیدا کنید؛ AutoShapeهایی که شامل کلمه "Slide" هستند.
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # هر شکل مطابق را از اسلاید حذف کنید.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نکته:** همیشه قبل از تغییر مجموعه شکل‌ها در طول پیمایش، یک کپی از آن ایجاد کنید تا از خطاهای تغییر مجموعه جلوگیری شود.