---
title: جدول
type: docs
weight: 120
url: /fa/python-net/examples/elements/table/
keywords:
- جدول
- افزودن جدول
- دسترسی به جدول
- حذف جدول
- ادغام سلول‌ها
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و قالب‌بندی جدول‌ها در Python با Aspose.Slides: وارد کردن داده‌ها، ادغام سلول‌ها، استایل‌گذاری مرزها، تراز کردن محتوا و وارد/صادر کردن برای PPT، PPTX و ODP."
---
مثال‌هایی برای افزودن جدول‌ها، دسترسی به آن‌ها، حذف آن‌ها و ادغام سلول‌ها با استفاده از **Aspose.Slides for Python via .NET**.

## **افزودن جدول**
یک جدول ساده با دو ردیف و دو ستون ایجاد کنید.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # اندازه ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
        widths = [80, 80]
        heights = [30, 30]

        # یک شکل جدول به اسلاید اضافه کنید.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به جدول**
شکل جدول اول را در اسلاید دریافت کنید.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین جدول در اسلاید.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **حذف جدول**
یک جدول را از اسلاید حذف کنید.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم اولین شکل یک جدول است.
        table = slide.shapes[0]

        # جدول را از اسلاید حذف کنید.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ادغام سلول‌های جدول**
سلول‌های مجاور یک جدول را در یک سلول ترکیب کنید.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم اولین شکل یک جدول است.
        table = slide.shapes[0]

        # سلول‌ها را ادغام کنید.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```