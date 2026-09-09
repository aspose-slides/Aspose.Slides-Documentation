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
- اضافه کردن متن
- اضافه کردن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت نقطه
- تورفتگی پاراگراف
- تورفتگی مشبک
- نقطه پاراگراف
- فهرست شماره‌دار
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
- پایتون
- جاوا
- Aspose.Slides
description: "یادگیری نحوه ایجاد و قالب‌بندی پاراگراف‌ها، بخش‌ها، نقطه‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف با Aspose.Slides برای Python از طریق Java."
---
## **مرور کلی**

Aspose.Slides برای Python از طریق Java متن را به عنوان یک سلسله‌مراتب از فریم‌های متنی، پاراگراف‌ها و بخش‌ها نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) متن را درون یک شکل نگه می‌دارد و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) یک پاراگراف در فریم متنی را نشان می‌دهد و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) یک بخش متن داخل یک پاراگراف را نشان می‌دهد. هر بخش می‌تواند متن و قالب‌بندی کاراکتری خاص خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را از طریق استفاده از چندین بخش داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک فریم متنی با سه پاراگراف، هر یک شامل سه بخش، ایجاد می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) دیگر به فریم متنی اضافه کنید.
6. به اندازه کافی شیء [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) اضافه کنید تا هر پاراگراف شامل سه بخش شود. پاراگراف پیش‌فرض از قبل یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی کاراکتری را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getPortionFormat) اعمال کنید.
9. ارائه (presentation) اصلاح‌شده را ذخیره کنید.

این مثال پایتون مراحل فوق را پیاده‌سازی می‌کند:

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

## **ایجاد فهرست‌های نقطه‌ای و شماره‌دار**

### **ایجاد یک فهرست نقطه‌ای یا شماره‌دار**

نقطه‌ها و شماره‌گذاری آیتم‌های مرتبط را برای اسکن آسان‌تر می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) برای نقطه نمادیک (symbol bullet) ایجاد کنید.
7. [BulletFormat.setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bulletformat/#setType) را روی [BulletType.Symbol](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bullettype/#Symbol) تنظیم کنید و کاراکتر نقطه را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ نقطه و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. پاراگراف دوم را ایجاد کرده و [BulletFormat.setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bulletformat/#setType) را روی [BulletType.Numbered](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bullettype/#Numbered) تنظیم کنید.
11. سبک نقطه شماره‌دار را پیکربندی کنید و پاراگراف را به فریم متنی اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال پایتون یک نقطه نمادیک و یک نقطه شماره‌دار ایجاد می‌کند:

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

نقطه‌های تصویری اجازه می‌دهند به جای نماد یا عدد از تصویر دلخواه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) اضافه کنید و به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
5. تصویر نقطه را بارگذاری کنید و به مجموعه تصویرهای ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) ایجاد کرده و متن آن را تنظیم کنید.
7. [BulletFormat.setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bulletformat/#setType) را روی [BulletType.Picture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bullettype/#Picture) تنظیم کنید.
8. تصویر را از طریق [BulletFormat.getPicture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bulletformat/#getPicture) اختصاص دهید و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

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

### **ایجاد فهرست چند سطحی**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setDepth) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالاتر عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و یک اسلاید را دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متنی آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای نقطه آن‌ها را پیکربندی کنید.
4. مقادیر [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setDepth) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کنید و ارائه را ذخیره کنید.

این مثال پایتون یک فهرست نقطه‌ای چهار سطحی ایجاد می‌کند:

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

### **شروع آیتم‌های فهرست شماره‌دار با مقادیر دلخواه**

از [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) برای تنظیم عدد اولیه نمایش‌داده‌شده برای پاراگراف شماره‌دار استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متنی شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. برای هر پاراگراف، [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کنید و ارائه را ذخیره کنید.

این مثال پایتون عدد شروع دلخواه را به هر پاراگراف اختصاص می‌دهد:

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

### **تنظیم تورفتگی خط اول**

از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) برای کنترل تورفتگی خط اول پاراگراف استفاده کنید. این روش فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده هم‌راستا با متن بدن پاراگراف می‌مانند.

از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setMarginLeft) وقتی نیاز دارید کل پاراگراف را جابه‌جا کنید استفاده کنید. از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) وقتی فقط خط اول را جابه‌جا می‌کنید استفاده کنید.

مثال زیر چند پاراگراف ایجاد کرده و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متنی اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف را تنظیم کنید:

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

### **تنظیم تورفتگی مشبک (Hanging Indent)**

تورفتگی مشبک نوعی چیدمان پاراگراف است که در آن خط اول به سمت چپ خطوط باقی‌مانده می‌آید. در Aspose.Slides این اثر را با [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) ایجاد می‌کنید. مقدار منفی به خط اول اجازه می‌دهد نسبت به بدن پاراگراف به سمت چپ حرکت کند.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setMarginLeft) موقعیت چپ بدن پاراگراف را تعریف می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی مشبک، مقدار مثبت به [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setMarginLeft) بدهید و مقدار منفی به [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) بدهید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدن پاراگراف هم‌راستا شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت به [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setMarginLeft) بدهید.
6. مقدار منفی به [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setIndent) بدهید تا اثر تورفتگی مشبک ایجاد شود.
7. پاراگراف‌ها را به فریم متنی اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی مشبک را برای یک پاراگراف تنظیم کنید:

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

![تورفتگی مشبک پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف (End Paragraph Run Properties)**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و قلم لاتین را به علامت پایان پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگیری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) برای علامت پایان پاراگراف دوم ایجاد کنید.
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setFontHeight) و [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLatinFont) را تنظیم کنید.
6. قالب را با [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) اختصاص دهید و ارائه را ذخیره کنید.

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

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphcollection/#addFromHtml) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید را دسترسی پیدا کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphcollection/#addFromHtml) پاس دهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال پایتون HTML را به یک فریم متنی وارد می‌کند:

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

### **صادر کردن متن پاراگراف به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphcollection/#exportToHtml) برای صدور یک بازه انتخاب‌شده از پاراگراف‌ها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه مورد نظر را بارگیری کنید.
2. اسلاید را دسترسی پیدا کنید و [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) حاوی متن را پیدا کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
4. با استفاده از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphcollection/#exportToHtml) اندیس پاراگراف شروع و تعداد پاراگراف‌های مورد نظر برای صادرات را مشخص کنید.
5. رشته HTML برگشتی را در یک فایل بنویسید.

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

### **رندر کردن یک پاراگراف به عنوان تصویر**

[Paragraph.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) یک پاراگراف منفرد را مستقیماً رندر می‌کند و شیء تصویر را بازمی‌گرداند. نتیجه را با متد `save` در یک فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی آن یا برش دستی bitmap نیست.

[Paragraph.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) می‌تواند `None` برگرداند اگر پاراگراف در مجموعه والد پیدا نشود، مرزهای رندر معتبر نداشته باشد یا نتواند رندر شود. قبل از ذخیره نتیجه را بررسی کنید و پس از استفاده تصویر برگشتی را آزاد کنید.

#### **رندر کردن یک پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به نام sample.pptx داریم که یک اسلاید دارد و اولین شکل آن یک جعبه متنی شامل سه پاراگراف است.

![جعبه متنی با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگشتی را در قالب PNG ذخیره می‌کند. بلوک `finally` تضمین می‌کند که تصویر به‌درستی آزاد شود.

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

#### **رندر کردن یک پاراگراف در یک سلول جدول با مقیاس‌دهی**

از overload [Paragraph.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) که پارامترهای `scale_x` و `scale_y` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دوبرابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به عنوان تصویر PNG ذخیره می‌کند.

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

فاکتور مقیاس `1` اندازه محور مربوطه را در اندازه پیکسل پیش‌فرض نگه می‌دارد. به‌عنوان مثال، `2` برای هر دو فاکتور تصویری ایجاد می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و چهار برابر پیکسل دارد. فاکتورهای بزرگتر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. فاکتورهایی زیر `1` تصاویر کوچک‌تری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت طول و عرض پاراگراف از فاکتورهای مساوی استفاده کنید؛ فاکتورهای متفاوت افقی و عمودی خروجی را به‌طور مستقل کش می‌دهند.

رندر کل شکل با [Shape.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) زمانی مفید است که خروجی باید پر کردن، حد یا سایر زمینه‌های بصری شکل را شامل شود. برای تصویر تنها پاراگراف، از [Paragraph.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم به‌طور کامل بسته‌بندی خط در داخل فریم متنی را غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setWrapText) بسته‌بندی را غیرفعال کنید تا خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم حدود دقیق روی اسلاید یک پاراگراف خاص را به‌دست آورم؟**

از [Paragraph.getRect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#getRect) برای دریافت مستطیل مرزی پاراگراف استفاده کنید. [Portion.getRect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getRect) مرزهای یک بخش منفرد را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، مرکز یا توزیع) در کجا انجام می‌شود؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setAlignment) تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر بخش.

**آیا می‌توانم زبان proofing را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های منفرد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) را تنظیم کنید تا یک پاراگراف بتواند متن‌های چند زبانی داشته باشد.