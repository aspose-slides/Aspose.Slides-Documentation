---
title: قالب‌بندی متن ارائه در Python از طریق Java
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-java/text-formatting/
keywords:
- هم‌ترازی پاراگراف
- سبک متن
- پس‌زمینهٔ متن
- شفافیت متن
- فاصله کاراکتر
- ویژگی‌های قلم
- خانوادهٔ قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصله خطوط
- ویژگی Autofit
- تکیهٔ قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java. سفارشی‌سازی قلم‌ها، رنگ‌ها، هم‌ترازی و موارد دیگر.
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java قالب‌بندی کنید. این راهنما شامل رنگ پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار autofit، تکیه متن، ایستگاه‌های تب، و تنظیمات زبان می‌شود.

مگر آنکه به‌صورت خاصی اشاره شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اسلاید اول یک جعبه متن است و اولین پاراگراف آن حاوی متن نشان‌داده‌شده در زیر است. هر دو شاخص اسلاید و شکل به صورت صفر‑مبنایی هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر، از جمله قالب‌بندی بولد ارث‌برده، استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا مطابقت‌های عبارت منظم، به [Search and Replace Text](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینهٔ متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#getHighlightColor) برای بخش‌های متنی جداگانه.

مثال زیر یک برجسته‌سازی خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح در بخش‌های فردی بر این پیش‌فرض اولویت دارند:

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

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

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
            # تنظیم رنگ برجسته برای بخش متنی.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **هم‌ترازی پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم هم‌ترازی پاراگراف داخل یک فریم متن استفاده کنید. مقدار می‌تواند مرکز، چپ، راست، هم‌تراز، و غیره باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** هم‌تراز کنید:

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

    # تنظیم تراز پاراگراف به مرکز.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف هم‌تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگی که به [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#getFillFormat) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس 0‑255 است، نه درصد شفافیت.

کد زیر نحوه اعمال شفافیت به **تمام پاراگراف** را نشان می‌دهد:

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

    # تنظیم رنگ پر کردن متن به رنگ شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال زیر شفافیت را به **بخش‌های متنی با قلم بولد** اعمال می‌کند:

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

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # تنظیم شفافیت بخش متنی.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکتر برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setSpacing) برای گسترش یا فشردن فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کند.

کد پایتون زیر نشان می‌دهد چگونه فاصله کاراکتر در **تمام پاراگراف** گسترش یابد:

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # توجه: برای فشرده‌کردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # گسترش فاصله کاراکتر.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله کاراکتر در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله کاراکتر در **بخش‌های متنی با قلم بولد** گسترش یابد:

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
            # توجه: برای فشرده‌کردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3) # گسترش فاصله کاراکتر.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله کاراکتر در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم تحت تأثیر استفاده می‌کنند، غیرفعال کنید. مقدار [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) را بزرگ‌تر از اندازه واقعی قلم تنظیم کنید. این مثال به "presentation.pptx" با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر، شامل قلم‌های ارث‌برده، بررسی می‌شود و برای بخش‌هایی که از Roboto استفاده می‌کنند، آستانهٔ 100 پوینت تنظیم می‌شود؛ این کار کرنینگ را برای بخش‌های مطابقت‌یافته با اندازه قلم زیر 100 پوینت غیرفعال می‌کند:

```python
import jpype
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
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای متن‌های مطابقت‌یافته که زیر آستانه هستند، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هم‌ترازی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با قالب بولد، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح در بخش‌های فردی بر این پیش‌فرض‌ها اولویت دارد:

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

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر 13 پوینت Times New Roman، قالب ایتالیک و زیرخط نقطه‌ای را به بخش‌هایی که قالب مؤثر آن‌ها بولد است، اعمال می‌کند:

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
            # تنظیم ویژگی‌های قلم برای بخش متنی.
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

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت پیش‌فرض متن داخل یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه پادساعتگرد** می‌چرخاند:

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

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویهٔ چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را به‌صورت ساعتگرد 3 درجه در داخل شکل می‌چرخاند:

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

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خط پاراگراف‌ها**

Aspose.Slides توابع [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصله پاراگراف فراهم می‌کند. این ویژگی‌ها به شکل زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به‌صورت درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط به‌صورت پوینت استفاده کنید.

مثال زیر فاصله داخل اولین پاراگراف را به 200٪ از ارتفاع خط (فاصله دو برابر) تنظیم می‌کند:

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

![فاصله خط داخل پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و متون آسیای شرقی ترکیب می‌شوند، مفید هستند. روش‌های زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/) هستند، بنابراین بر تمام پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) قواعد شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل شکست متن و نقطه‌گذاری آسیای شرقی را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) قواعد شکست خط آسیای شرقی را کنترل می‌کند، از جمله محدودیت‌های کاراکتر در ابتدای و انتهای خط.

این قواعد جایگزین [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setWrapText) که بسته‌بندی خودکار را در داخل فریم متن فعال می‌کند، نیستند؛ آن‌ها چیدمان را هنگام بسته‌بندی تحت تأثیر قرار می‌دهند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را در داخل پاراگراف به‌طور مستقل از عرض موجود ایجاد می‌کند.

مثال خودمختار زیر یک بلوک متنی باریک حاوی متن چینی و لاتین ایجاد می‌کند. هر دو گزینهٔ شکست خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قواعد، مقدار مربوطه را تغییر دهید و تنظیمات دیگر را ثابت نگه دارید. مثال از Arial 24 پوینت و SimSun با عرض فریم 160 پوینت و حاشیه‌های افقی صفر استفاده می‌کند. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAutofitType) با [TextAutofitType.None_](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد فریم ثابت بمانند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کنترل نقطه‌گذاری معلق**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) به نقطه‌گذاری‌های واجد شرایط اجازه می‌دهد تا فراتر از لبهٔ راست خط متن امتداد یابند به‌جای این که در خط بعدی قرار گیرند. این ویژگی برای تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودمختار زیر نقطه‌گذاری معلق را در فریم متنی با عرض 100 پوینت فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با Arial 24 پوینت و حاشیه‌های افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و فراتر از لبهٔ راست متن امتداد می‌یابد. مقدار ویژگی را به [NullableBool.False_](https://reference.aspose.com/slides/fa/python-java/aspose.slides/nullablebool/) تنظیم کنید تا مقایسه کنید: با این تنظیمات، نقطه در خط جداگانه‌ای قرار می‌گیرد. بسته‌بندی فعال است و autofit غیرفعال تا عرض موجود ثابت بماند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

همهٔ نقطه‌گذاری‌ها توان معلق شدن را ندارند. نتیجهٔ قابل مشاهده به دسترس بودن قلم و چینش بستگی دارد: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل این‌که آیا متن کوچک می‌شود، سرریز می‌شود یا شکل به‌صورت خودکار اندازه‌اش تغییر می‌کند، استفاده کنید. مثال زیر شکل را طوری پیکربندی می‌کند که برای متن خود تغییر اندازه دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند:

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

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/python-java/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشان‌دهندهٔ سرریز متن نیست.

## **تنظیم تکیه فریم‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAnchoringType) نحوهٔ موقعیت عمودی متن داخل یک شکل را تعریف می‌کند، مثلاً در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل تکیه می‌دهد و نتیجه را در «text_anchor.pptx» ذخیره می‌کند:

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

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی ایستگاه‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ تب پیش‌فرض را به 100 پوینت تنظیم می‌کند و یک ایستگاه تب چپ‌تراز را در 30 پوینت اضافه می‌کند. این تنظیمات بر متن حاوی کاراکترهای تب اثر می‌گذارند:

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

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان تصحیح املایی**

Aspose.Slides متد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح املایی برای یک بخش متنی را تنظیم کنید. زبان تصحیح املایی تعیین می‌کند کدام زبان برای بررسی املایی و دستورزبان در PowerPoint استفاده شود.

مثال زیر به «presentation.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید دارد و حداقل یک پاراگراف دارد، نیاز دارد. این مثال محتوای اولین پاراگراف را با «1。» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان تصحیح چینی ساده (`zh-CN`) را اختصاص می‌دهد. سپس نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    # تنظیم شناسهٔ زبان تصحیح املایی.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که در هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی آمریکایی ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متنی آن `en-US` چاپ می‌کند:

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

    # زبان اولین بخش را بررسی کنید.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **تنظیم استایل پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

مثال زیر قلم بولد 14 پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالای یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند:

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

در PowerPoint، اعمال اثر **All Caps** روی قلم باعث می‌شود متن روی اسلاید همگی به حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک تایپ شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `All` باشد، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. اولین بخش اولین پاراگراف آن شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده:

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

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

برای ویرایش متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) استفاده کنید. در سلول‌ها پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف را از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#getParagraphFormat) به‌روزرسانی کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. [FillFormat.setFillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#setFillType) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) تنظیم کنید و نقاط گرادیان، جهت و شفافیت را پیکربندی کنید.