---
title: SmartArt
type: docs
weight: 140
url: /fa/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- افزودن SmartArt
- دسترسی به SmartArt
- حذف SmartArt
- چیدمان SmartArt
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ساخت و ویرایش SmartArt در Python با Aspose.Slides: افزودن گره‌ها، تغییر چیدمان‌ها و سبک‌ها، تبدیل دقیق به اشکال، و صادر کردن برای PPT، PPTX و ODP."
---
نشان می‌دهد چگونه گرافیک‌های SmartArt را اضافه، دسترسی پیدا کنید، حذف کنید و چیدمان‌ها را با استفاده از **Aspose.Slides for Python via .NET** تغییر دهید.

## **افزودن SmartArt**

یک گرافیک SmartArt را با استفاده از یکی از چیدمان‌های از پیش تعریف شده وارد کنید.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به SmartArt**

اولین شیء SmartArt را در یک اسلاید دریافت کنید.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین شکل SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **حذف SmartArt**

یک شکل SmartArt را از اسلاید حذف کنید.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم که اولین شکل یک شیء SmartArt است.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر چیدمان SmartArt**

نوع چیدمان یک گرافیک SmartArt موجود را به‌روز کنید.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم که اولین شکل یک شیء SmartArt است.
        smart_art = slide.shapes[0]

        # تغییر چیدمان SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```