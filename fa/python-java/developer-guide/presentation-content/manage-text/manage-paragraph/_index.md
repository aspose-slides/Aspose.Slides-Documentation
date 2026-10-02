---
title: مدیریت پاراگراف‌های متن PowerPoint در Python از طریق Java
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت نقطه
- تورفتگی پاراگراف
- تورفتگی معلق
- نقطه پاراگراف
- فهرست عددی
- فهرست نقطه‌ای
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
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، نقطه‌ها، فهرست‌های عددی، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای Python از طریق Java ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides برای Python از طریق Java متن را به عنوان یک سلسله مراتب از فریم‌های متنی، پاراگراف‌ها و بخش‌ها نشان می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) نمایانگر مخزن متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) نمایانگر یک پاراگراف در فریم متن است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) نمایانگر یک بخش متن داخل یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با قلم‌ها، رنگ‌ها، اندازه‌ها و سایر قالب‌بندی‌های مختلف را با استفاده از چندین بخش داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک فریم متن با سه پاراگراف ایجاد می‌کند که هر یک شامل سه بخش هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) را به فریم متن اضافه کنید.
6. به اندازه کافی شیء [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) برای هر پاراگراف اضافه کنید تا شامل سه بخش باشد. پاراگراف پیش‌فرض قبلاً یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی سطح کاراکتر را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) اعمال کنید.
9. ارائه تغییر یافته را ذخیره کنید.

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

## **ایجاد فهرست‌های نقطه‌ای و عددی**

### **ایجاد فهرست نقطه‌ای یا عددی**

نقطه‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کنند. در Aspose.Slides، تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) تعریف می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) برای یک نقطه نماد ایجاد کنید.
7. متد [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) را به [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) تنظیم کنید و کاراکتر نماد نقطه را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ نقطه و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. پاراگراف دوم را ایجاد کنید و متد [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) را به [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered) تنظیم کنید.
11. سبک نقطه عددی را پیکربندی کنید و پاراگراف را به فریم متن اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال پایتون یک نقطه نماد و یک نقطه عددی ایجاد می‌کند:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

### **استفاده از نقطه‌های تصویری**

نقطه‌های تصویری به شما امکان می‌دهند به جای نماد یا عدد از یک تصویر دلخواه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) اضافه کنید و به [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
5. تصویر نقطه را بارگذاری کنید و به مجموعه تصاویر ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. متد [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) را به [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) تنظیم کنید.
8. تصویر را از طریق [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) اختصاص دهید و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. ارائه تغییر یافته را ذخیره کنید.

این مثال پایتون یک نقطه تصویری ایجاد می‌کند:
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

### **ایجاد فهرست چندسطحی**

متد [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف یک فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای نقطه آنها را پیکربندی کنید.
4. مقدارهای [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) آنها را به `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کنید و ارائه را ذخیره کنید.

این مثال پایتون یک فهرست نقطه‌ای چهارسطحی ایجاد می‌کند:
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

### **شروع موارد فهرست عددی با مقادیر سفارشی**

از [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) برای تنظیم عدد اولیه نمایش داده شده برای یک پاراگراف عددی استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متن شکل پاک کنید.
3. سه پاراگراف عددی ایجاد کنید.
4. برای پاراگراف‌های مربوطه، [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) را به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کنید و ارائه را ذخیره کنید.

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

## **کنترل قالب‌بندی پاراگراف و ویژگی‌های انتهایی**

### **تنظیم تورفتگی خط اول**

از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابجا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف تراز می‌مانند.

هنگامی که نیاز به جابجایی کل پاراگراف دارید از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابجا کنید از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) استفاده نمایید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) را اعمال می‌کند تا نشان دهد تورفتگی خط اول چطور بر چیدمان پاراگراف‌ها تأثیر می‌گذارد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) را برای آنها تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی یک پاراگراف را تنظیم کنید:
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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
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
![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق یک قالب‌بندی پاراگراف است که در آن خط اول نسبت به خطوط باقی‌مانده به سمت چپ شروع می‌شود. در Aspose.Slides، این اثر را با [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) ایجاد می‌کنید. برای جابجایی خط اول به سمت چپ نسبت به بدنه پاراگراف، مقدار منفی وارد کنید.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) موقعیت خط اول را نسبت به آن حاشیه تعریف می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت به [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) و مقدار منفی به [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) بدهید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌ها مفید است که خطوط بسته‌بندی شده باید زیر بدنه پاراگراف تراز شوند نه زیر اولین کاراکتر خط اول.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و مقدار مثبت به [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) برای هر پاراگراف بدهید.
6. مقدار منفی به [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) بدهید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی معلق یک پاراگراف را تنظیم کنید:
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
![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و قلم لاتین را به علامت انتهای پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید و به اسلایدی دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آنها بخش‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) برای علامت انتهای پاراگراف دوم ایجاد کنید.
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) و [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) را تنظیم کنید.
6. قالب را با [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) اختصاص داده و ارائه را ذخیره کنید.

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

برای قوانین پاراگراف که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارد، به [Control Line Breaking](/slides/fa/python-java/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/python-java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) برای شمارش خطوطی که یک پاراگراف پس از چینش متن اشغال می‌کند، شامل بسته‌بندی خودکار، استفاده کنید. این برای بررسی طول متن و چینش در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح درون پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته‌بندی خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون درج شکست‌های خط صریح در متن. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، تعداد خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متن ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته‌ای کوتاه‌تر جایگزین می‌نماید. بسته‌بندی فعال و خودسازگاری غیرفعال است تا عرض شکل بسته‌بندی را کنترل کند بدون اینکه به‌صورت خودکار متن یا اندازه شکل تغییر کند. ابعاد شکل به نقطه است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و تعداد خطوط را در فریم متن جمع می‌زند.

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

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه تعداد را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن و جایگزینی قلم‌ها، اندازه قلم، حاشیه‌ها، تورفتگی، بسته‌بندی و تنظیمات خودسازگاری متفاوت باشد. هنگام بررسی یک قالب، از قلم‌ها و تنظیمات چیدمانی که برای محیط هدف در نظر گرفته شده‌اند، استفاده کنید.

تعداد خطوط به تنهایی تعیین نمی‌کند که آیا متن از محفظه‌اش بیش از حد حد می‌رود یا نه. ارتفاع موجود، ارتفاع خطوط، فاصله‌بندی پاراگراف و خطوط، و رفتار خودسازگاری نیز مهم هستند؛ حتی یک خط واحد می‌تواند عرض موجود را در صورت غیرفعال بودن بسته‌بندی تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متن استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید.
2. به یک اسلاید دسترسی پیدا کنید و یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) بدهید.
6. ارائه تغییر یافته را ذخیره کنید.

این مثال پایتون HTML را به یک فریم متن وارد می‌کند:
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

### **صادرات متن پاراگراف به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) برای صادرات یک بازه انتخابی از پاراگراف‌ها به شکل HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. به اسلاید دسترسی پیدا کنید و [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) حاوی متن را پیدا کنید.
3. به [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
4. متد [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) را با ایندکس پاراگراف شروع و تعداد پاراگراف‌های موردنظر فراخوانی کنید.
5. رشته HTML بازگشتی را در فایلی بنویسید.

این مثال پایتون تمام پاراگراف‌ها را از اولین شکل متنی صادر می‌کند:
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

### **رندر کردن پاراگراف به عنوان تصویر**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) یک پاراگراف جداگانه را مستقیماً رندر می‌کند و یک شیء تصویر باز می‌گرداند. نتیجه را با متد `save` آن در یک فایل یا جریان ذخیره کنید. نیازی به رندر کردن شکل حاوی یا بریدن دستی بیت‌مپ نیست.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) می‌تواند `None` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، حدهای رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگشتی را آزاد کنید.

#### **رندر کردن پاراگراف در مقیاس پیش‌فرض**

فرض کنیم فایلی به نام sample.pptx داریم که یک اسلاید دارد و اولین شکل آن یک جعبه متن شامل سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی معمولی در مقیاس پیش‌فرض رندر می‌کند و تصویر بازگشتی را در قالب PNG ذخیره می‌نماید. بلوک `finally` تضمین می‌کند که تصویر به‌درستی آزاد شود.

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

#### **رندر کردن پاراگراف در یک سلول جدول با مقیاس‌بندی**

از overload [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) که پارامترهای `scale_x` و `scale_y` را می‌پذیرد برای تنظیم عوامل مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به صورت تصویر PNG ذخیره می‌کند.

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

یک عامل مقیاس `1` آن محور را در اندازه پیش‌فرض پیکسل حفظ می‌کند. برای مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و به‌همین دلیل چهار برابر پیکسل دارد. عوامل بزرگتر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما همچنین مصرف حافظه و حجم فایل را افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر ایجاد می‌کنند. برای حفظ نسبت تصویر پاراگراف از عوامل مساوی استفاده کنید؛ عوامل افقی و عمودی متفاوت خروجی را به‌صورت مستقل کش می‌دهند.

رندر کردن یک شکل کامل با [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) مفید است وقتی خروجی باید شامل پر، حاشیه یا سایر زمینه‌های بصری شکل باشد. برای یک تصویر فقط پاراگراف، از [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم بسته‌بندی خطوط را داخل یک فریم متن به‌طور کامل غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) بسته‌بندی را غیرفعال کنید تا خطوط در لبه‌های فریم متن شکسته نشوند.

**چگونه می‌توانم حد دقیق پاراگراف خاصی روی اسلاید را به‌دست آورم؟**

از [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) برای دریافت مستطیل محدود کننده پاراگراف استفاده کنید. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) مرزهای یک بخش جداگانه را فراهم می‌آورد.

**کنترل تنظیم تراز پاراگراف (چپ، راست، وسط یا توجیه) کجا انجام می‌شود؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) یک تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود بدون توجه به قالب‌بندی قسمت‌های جداگانه.

برای تراز عمودی بخش‌هایی با اندازه قلم‌های متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/python-java/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان تصحیح متن را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های جداگانه [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) را تنظیم کنید تا یک پاراگراف شامل متنی به چند زبان باشد.