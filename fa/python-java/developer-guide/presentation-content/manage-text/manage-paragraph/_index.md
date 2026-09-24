---
title: مدیریت پاراگراف‌های متن پاورپوینت در Python از طریق Java
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/python-java/manage-paragraph/
aliases:
  - /python-java/پاراگراف/
  - /python-java/بخش/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت بولت
- تورفتگی پاراگراف
- تورفتگی آویزان
- بولت پاراگراف
- فهرست شماره‌دار
- فهرست بولت‌دار
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادرات پاراگراف
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، بولت‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای Python از طریق Java ایجاد و قالب‌بندی کنید."
---
## **مروری کلی**

Aspose.Slides for Python via Java متن را به عنوان یک سلسله‌مراتب از قاب‌های متن، پاراگراف‌ها و بخش‌ها نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) قاب متن را در یک شکل نمایش می‌دهد و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) یک پاراگراف در یک قاب متن را نشان می‌دهد و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) یک بخش متن درون یک پاراگراف را نمایان می‌کند. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

یک پاراگراف می‌تواند بنابراین متن با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از بخش‌های متعدد شامل شود.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک قاب متن با سه پاراگراف، هر کدام شامل سه بخش، ایجاد می‌کند:

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. از طریق اندیس، اسلاید مربوطه را دسترسی بگیرید.
3. یک AutoShape مستطیلی به اسلاید اضافه کنید.
4. قاب متن شکل را دسترسی بگیرید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء Paragraph دیگر به قاب متن اضافه کنید.
6. به اندازه کافی شیء Portion برای هر پاراگراف اضافه کنید تا شامل سه بخش باشد. پاراگراف پیش‌فرض هم‌اکنون یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی سطح کاراکتر را از طریق Portion.getPortionFormat اعمال کنید.
9. Presentation اصلاح‌شده را ذخیره کنید.

این مثال پایتون مراحل را پیاده‌سازی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ایجاد فهرست‌های بولت‌دار و شماره‌دار**

### **ایجاد فهرست بولت‌دار یا شماره‌دار**

نقاط و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کند. در Aspose.Slides، تنظیمات فهرست از طریق BulletFormat تعریف می‌شود.

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. از طریق اندیس، اسلاید مربوطه را دسترسی بگیرید.
3. یک AutoShape به اسلاید انتخاب‌شده اضافه کنید.
4. قاب متن شکل را دسترسی بگیرید.
5. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
6. یک Paragraph برای یک بولت نماد ایجاد کنید.
7. BulletFormat.setType را به BulletType.Symbol تنظیم کنید و کاراکتر بولت را مشخص کنید.
8. متن پاراگراف، تو رفتگی، رنگ بولت و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و BulletFormat.setType را به BulletType.Numbered تنظیم کنید.
11. استایل بولت شماره‌دار را پیکربندی کنید و پاراگراف را به قاب متن اضافه کنید.
12. Presentation را ذخیره کنید.

این مثال پایتون یک بولت نماد و یک بولت شماره‌دار ایجاد می‌کند:

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **استفاده از بولت‌های تصویری**

بولت‌های تصویری به شما امکان می‌دهند به جای یک نماد یا عدد، یک تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. از طریق اندیس، اسلاید مربوطه را دسترسی بگیرید.
3. یک AutoShape اضافه کنید و به TextFrame آن دسترسی بگیرید.
4. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
5. تصویر بولت را بارگذاری کنید و به مجموعه تصاویر ارائه به عنوان PPImage اضافه کنید.
6. یک Paragraph ایجاد کنید و متن آن را تنظیم کنید.
7. BulletFormat.setType را به BulletType.Picture تنظیم کنید.
8. تصویر را از طریق BulletFormat.getPicture انتساب دهید و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. Presentation اصلاح‌شده را ذخیره کنید.

این مثال پایتون یک بولت تصویری ایجاد می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **ایجاد فهرست چند‌سطحی**

ParagraphFormat.setDepth را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

1. یک Presentation ایجاد کنید و به اسلاید دسترسی بگیرید.
2. یک AutoShape اضافه کنید و پاراگراف پیش‌فرض را از قاب متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای بولت آنها را پیکربندی کنید.
4. مقدارهای ParagraphFormat.setDepth آنها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و Presentation را ذخیره کنید.

این مثال پایتون یک فهرست بولت‌دار چهار سطحی ایجاد می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **شروع موارد فهرست شماره‌دار با مقادیر سفارشی**

از BulletFormat.setNumberedBulletStartWith برای تنظیم عدد اولیه نمایش‌داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

1. یک Presentation ایجاد کنید و یک AutoShape به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از قاب متن شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. BulletFormat.setNumberedBulletStartWith را برای پاراگراف‌های مربوطه به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و Presentation را ذخیره کنید.

این مثال پایتون عدد شروع سفارشی را به هر پاراگراف اختصاص می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهایی**

### **تنظیم تو رفتگی خط اول**

از ParagraphFormat.setIndent برای کنترل تو رفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف هم‌تراز می‌مانند.

در مواقعی که نیاز به جابجایی کل پاراگراف دارید، از ParagraphFormat.setMarginLeft استفاده کنید. وقتی تنها خط اول را می‌خواهید جابجا کنید، از ParagraphFormat.setIndent استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر متفاوت ParagraphFormat.setIndent را اعمال می‌نماید تا نشان دهد تو رفتگی خط اول چگونه بر چیدمان پاراگراف تأثیر می‌گذارد.

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. به اسلاید هدف دسترسی بگیرید.
3. یک AutoShape مستطیلی به اسلاید اضافه کنید.
4. قاب متن شکل را دسترسی بگیرید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر متفاوت ParagraphFormat.setIndent را برای آنها تنظیم کنید.
6. پاراگراف‌ها را به قاب متن اضافه کنید.
7. Presentation اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه یک تو رفتگی پاراگراف تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![تو رفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تو رفتگی آویزان**

تو رفتگی آویزان یک چیدمان پاراگراف است که در آن خط اول نسبت به خطوط باقی‌مانده به سمت چپ شروع می‌شود. در Aspose.Slides، می‌توانید این اثر را با ParagraphFormat.setIndent ایجاد کنید. برای جابه‌جایی خط اول به سمت چپ نسبت به بدنه پاراگراف، مقدار منفی بدهید.

در عمل، ParagraphFormat.setMarginLeft موقعیت چپ بدنه پاراگراف را تعریف می‌کند و ParagraphFormat.setIndent موقعیت خط اول نسبت به آن حاشیه را تعیین می‌کند. برای ایجاد تو رفتگی آویزان، مقدار مثبت به ParagraphFormat.setMarginLeft و مقدار منفی به ParagraphFormat.setIndent بدهید.

این قالب‌بندی برای کتاب‌نامه‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌ها مفید است که در آن خطوط بسته‌شده باید زیر بدنه پاراگراف و نه زیر اولین کاراکتر خط اول هم‌تراز شوند.

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. به اسلاید هدف دسترسی بگیرید.
3. یک AutoShape مستطیلی به اسلاید اضافه کنید.
4. قاب متن شکل را دسترسی بگیرید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر پاراگراف مقدار مثبت به ParagraphFormat.setMarginLeft بدهید.
6. مقدار منفی به ParagraphFormat.setIndent بدهید تا اثر تو رفتگی آویزان ایجاد شود.
7. پاراگراف‌ها را به قاب متن اضافه کنید.
8. Presentation اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تو رفتگی آویزان برای یک پاراگراف تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![تو رفتگی آویزان پاراگراف‌ها](hanging_indent.png)

### **تنظیم خصوصیات انتهایی اجرای پاراگراف**

[Paragraph.setEndParagraphPortionFormat] قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و فونت لاتین را به علامت انتهای پاراگراف دوم اختصاص می‌دهد:

1. یک Presentation بارگذاری کنید و به اسلاید دسترسی بگیرید.
2. یک AutoShape اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و بخش‌های متنی به آنها اضافه کنید.
4. یک PortionFormat برای علامت انتهای پاراگراف دوم ایجاد کنید.
5. BasePortionFormat.setFontHeight و BasePortionFormat.setLatinFont را تنظیم کنید.
6. قالب را با Paragraph.setEndParagraphPortionFormat انتساب دهید و Presentation را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **شمارش خطوط رندر شده**

از Paragraph.getLinesCount برای شمارش خطوط اشغالی یک پاراگراف پس از چیدمان متن، شامل بسته‌بازی خودکار، استفاده کنید. این برای بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در TextFrame.getParagraphs است و می‌تواند چندین خط رندر شده اشغال کند. شکست خط صریح داخل پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته‌بازی خودکار خطوط را بر پایه عرض موجود ایجاد می‌کند بدون اینکه شکست خط صریح به متن اضافه کند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته‌ای کوتاه‌تر جایگزین می‌نماید. بسته‌بازی فعال است و اتوفیت غیرفعال است تا عرض شکل بسته‌بازی را کنترل کند بدون اینکه متن به‌صورت خودکار کوچک یا شکل تغییر اندازه دهد. ابعاد شکل بر حسب پوینت است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و مجموع شمارش خطوط را در سراسر قاب متن محاسبه می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه تعداد را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن و جایگزینی فونت، اندازه قلم، حاشیه‌ها، تو رفتگی، بسته‌بازی و تنظیمات اتوفیت متفاوت باشد. هنگام بررسی یک قالب، از فونت‌ها و تنظیمات چیدمان مورد نظر برای محیط هدف استفاده کنید.

تنها شمارش خطوط تعیین‌کننده این نیست که آیا متن از محفظه‌اش سرریز می‌شود یا خیر. ارتفاع موجود، ارتفاع خطوط، فاصله بین پاراگراف‌ها و خطوط، و رفتار اتوفیت نیز مهم‌اند؛ حتی یک خط واحد می‌تواند عرض موجود را هنگام غیرفعال بودن بسته‌بازی تجاوز کند.

## **ورود و خروج محتواهای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از ParagraphCollection.addFromHtml برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک قاب متن استفاده کنید.

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. به اسلاید دسترسی بگیرید و یک AutoShape اضافه کنید.
3. قاب متن شکل را دسترسی بگیرید و پاراگراف پیش‌فرض آن را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به ParagraphCollection.addFromHtml منتقل کنید.
6. Presentation اصلاح‌شده را ذخیره کنید.

این مثال پایتون HTML را به یک قاب متن وارد می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **خروجی متن پاراگراف به HTML**

از ParagraphCollection.exportToHtml برای خروجی گرفتن یک بازه انتخابی از پاراگراف‌ها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس Presentation ایجاد کنید و ارائه مورد نظر را بارگذاری کنید.
2. به اسلاید دسترسی بگیرید و AutoShape حاوی متن را پیدا کنید.
3. قاب متن شکل را دسترسی بگیرید.
4. متد ParagraphCollection.exportToHtml را با اندیس پاراگراف شروع و تعداد پاراگراف‌های خروجی صدا بزنید.
5. رشته HTML برگشتی را در فایلی بنویسید.

این مثال پایتون تمام پاراگراف‌ها را از اولین شکل متنی خروجی می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **رندرسازی یک پاراگراف به صورت تصویر**

[Paragraph.getImage] یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک شیء تصویر برمی‌گرداند. نتیجه را با متد `save` به یک فایل یا جریان ذخیره کنید. نیازی به رندر کردن شکل حاوی یا برش دستی بیت‌مپ نیست.

[Paragraph.getImage] می‌تواند `None` برگرداند اگر پاراگراف در مجموعه والد خود یافت نشود، حد مرزی رندر معتبری نداشته باشد یا نتواند رندر شود. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر برگردانده شده را آزاد (dispose) کنید.

#### **رندرسازی یک پاراگراف با مقیاس پیش‌فرض**

فرض کنید یک فایل ارائه به نام sample.pptx داریم که یک اسلاید دارد و اولین شکل آن یک جعبه متن حاوی سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی معمولی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگردانده شده را با فرمت PNG ذخیره می‌نماید. بلوک `finally` تضمین می‌کند که تصویر به‌درستی آزاد شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

#### **رندرسازی یک پاراگراف در سلول جدول با مقیاس‌بندی**

از overload متد Paragraph.getImage که پارامترهای `scale_x` و `scale_y` را می‌پذیرد برای تنظیم عوامل مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

یک عامل مقیاس `1` آن محور را در اندازه پیکسل پیش‌فرض نگه می‌دارد. برای مثال، `2` برای هر دو عامل، تصویری با عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض تولید می‌کند که چهار برابر پیکسل دارد. عوامل بزرگتر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا می‌سازند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچک‌تری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت ابعاد پاراگراف از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت خروجی را به‌صورت مستقل کش می‌دهند.

رندرسازی یک شکل کامل با Shape.getImage زمانی مفید است که خروجی باید پرکردن، حاشیه یا سایر زمینه‌های بصری شکل را شامل شود. برای تصویر فقط پاراگراف، از Paragraph.getImage استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم بسته‌بازی خطوط داخل یک قاب متن را به‌طور کامل غیرفعال کنم؟**

بله. TextFrameFormat.setWrapText را به‌گونه‌ای تنظیم کنید که بسته‌بازی غیرفعال شود تا خطوط در لبه‌های قاب متن شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق یک پاراگراف خاص را روی اسلاید به‌دست آورم؟**

از Paragraph.getRect برای دریافت مستطیل محصورکننده پاراگراف استفاده کنید. Portion.getRect مرزهای یک بخش منفرد را فراهم می‌کند.

**محل کنترل تراز پاراگراف (چپ، راست، مرکز یا توزیع) کجاست؟**

ParagraphFormat.setAlignment یک تنظیم سطح پاراگراف است و به کل پاراگراف اعمال می‌شود بدون در نظر گرفتن قالب‌بندی بخش‌های منفرد.

**آیا می‌توانم زبان اصلاح برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. BasePortionFormat.setLanguageId را برای بخش‌های منفرد تنظیم کنید، به طوری که یک پاراگراف بتواند متنی با زبان‌های مختلف داشته باشد.