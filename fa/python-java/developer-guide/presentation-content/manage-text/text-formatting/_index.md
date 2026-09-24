---
title: قالب‌بندی متن ارائه در Python از طریق Java
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-java/text-formatting/
keywords:
- ترازبندی پاراگراف
- سبک متن
- پس‌زمینهٔ متن
- شفافیت متن
- فاصلهٔ کاراکترها
- ویژگی‌های قلم
- خانوادهٔ قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصلهٔ خطوط
- ویژگی Autofit
- لنگر قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "قالب‌بندی و استایل متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java. قلم‌ها، رنگ‌ها، ترازبندی و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python via Java قالب‌بندی کنید. به رنگ پس‌زمینه، شفافیت، فاصلهٔ کاراکترها، ویژگی‌های قلم، چرخش، فاصلهٔ پاراگراف، رفتار Autofit، لنگر متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

در مثال‌های زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که یک جعبهٔ متن در اسلاید اول دارد و متن زیر را شامل می‌شود:

![Sample text](sample_text.png)

برای یافتن و برجسته‌سازی متن ثابت یا تطبیق‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینهٔ متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ پیش‌زمینهٔ پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متن منفرد از [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) بهره ببرید.

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینهٔ **تمام پاراگراف** را تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تنظیم رنگ برجسته برای تمام پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The gray paragraph](gray_paragraph.png)

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینهٔ **بخش‌های متنی با قلم تو پر** را تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # تنظیم رنگ برجسته برای بخش متن.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The gray text portions](gray_text_portions.png)

## **ترازبندی پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم ترازبندی پاراگراف داخل چارچوب متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و ... باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** ترازبندی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تنظیم ترازبندی پاراگراف به مرکز.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The aligned paragraph](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگ اختصاص داده شده به [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را به **تمام پاراگراف** اعمال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تنظیم رنگ پر شدن متن به رنگ شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The transparent paragraph](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت را به **بخش‌های متنی با قلم تو پر** اعمال کنید:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # تنظیم شفافیت بخش متن.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The transparent text portions](transparent_text_portions.png)

## **تنظیم فاصلهٔ کاراکترها برای متن**

از [PortionFormat.setSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) برای گسترش یا فشرده‌سازی فاصلهٔ بین کاراکترها در یک جعبهٔ متن استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصلهٔ کاراکترها را در **تمام پاراگراف** گسترش دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # نکته: برای فشرده‌سازی فاصلهٔ کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # گسترش فاصلهٔ کاراکتر.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصلهٔ کاراکترها را در **بخش‌های متنی با قلم تو پر** گسترش دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # نکته: برای فشرده‌سازی فاصلهٔ کاراکتر از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3) # گسترش فاصلهٔ کاراکتر.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم تحت‌تأثیر استفاده می‌کنند، غیرفعال کنید. مقدار [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) را به عددی به‌مراتب بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این تنظیم از اعمال کرنینگ بر روی بخش‌های متنی منطبق جلوگیری می‌کند و می‌تواند به همسویی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت‌تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا بر روی بخش‌های منفرد از طریق [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازهٔ قلم، تو پر، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman به تمام بخش‌های پاراگراف اعمال می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # تنظیم ویژگی‌های قلم برای پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The font properties for the paragraph](font_properties_for_paragraph.png)

کد زیر ویژگی‌های مشابه را به **بخش‌های متنی با قلم تو پر** اعمال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # تنظیم ویژگی‌های قلم برای بخش متن.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The font properties for text portions](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت پیش‌تعریف‌شدهٔ متن درون یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه پادساعت عقربه‌ها** می‌چرخاند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The text rotation](text_rotation.png)

## **تنظیم چرخش سفارشی برای چارچوب‌های متن**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویهٔ چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) استفاده کنید.

کد زیر چارچوب متن را 3 درجه ساعت‌گرد درون شکل می‌چرخاند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The custom text rotation](custom_text_rotation.png)

## **تنظیم فاصلهٔ خطوط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصلهٔ پاراگراف فراهم می‌کند. این ویژگی‌ها به صورت زیر استفاده می‌شوند:

* برای تعیین فاصلهٔ خط به‌عنوان درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای تعیین فاصلهٔ خط به‌صورت نقطه، مقدار منفی استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصلهٔ خط را درون پاراگراف مشخص کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The line spacing within the paragraph](line_spacing.png)

## **تنظیم نوع Autofit برای چارچوب‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند که متن هنگام عبور از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل این‌که متن کوچک شود، سرریز شود یا شکل به‌طور خودکار اندازه‌اش تغییر کند، استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای شمارش خطوط پس از بسته شدن خودکار و مشاهدهٔ اینکه چگونه عرض متن یا شکل تغییر می‌کند، به [شمارش خطوط رندر‌شده](/slides/fa/python-java/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشانگر سرریز شدن متن از محفظه نیست.

## **تنظیم لنگر چارچوب‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAnchoringType) تعیین می‌کند متن به‌صورت عمودی داخل شکل در کجا قرار گیرد، مثلاً در بالا، میانه یا پایین.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم تب‌گذاری متن**

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![The paragraph tabs](paragraph_tabs.png)

## **تنظیم زبان اصلاح‌کننده**

Aspose.Slides متد [PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) را فراهم می‌کند که به شما امکان می‌دهد زبان اصلاح‌کنندهٔ یک بخش متنی را تنظیم کنید. زبان اصلاح‌کننده تعیین می‌کند کدام زبان برای بررسی املاء و دستور زبان در PowerPoint استفاده شود.

کد زیر نشان می‌دهد چگونه زبان اصلاح‌کننده را برای یک بخش متنی تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # تنظیم شناسهٔ زبان تصحیح.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # یک شکل مستطیل با متن اضافه کنید.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # زبان اولین بخش متن را بررسی کنید.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **تنظیم استایل پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک قلم تو پر پیش‌فرض با اندازهٔ 14 pt برای تمام متن‌ها در اسلایدهای یک ارائهٔ جدید تنظیم شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # دریافت قالب پاراگراف سطح بالا.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر **All Caps** باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه دقیقاً همان متن ورودی را برمی‌گرداند. برای تطبیق با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `All` باشد، رشتهٔ برگردانده‌شده را به حروف بزرگ تبدیل کنید.

فرض کنیم جعبهٔ متن زیر را در اسلاید اول فایل sample2.pptx داریم.

![The All Caps effect](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن با اثر **All Caps** استخراج شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه متن را در جدول یک اسلاید ویرایش کنم؟**

برای ویرایش متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) استفاده کنید. در سلول‌ها تکرار کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف را از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#getParagraphFormat) به‌روز کنید.

**چگونه یک رنگ گرادیان به متن در اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) استفاده کنید. مقدار [FillFormat.setFillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#setFillType) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/#Gradient) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.