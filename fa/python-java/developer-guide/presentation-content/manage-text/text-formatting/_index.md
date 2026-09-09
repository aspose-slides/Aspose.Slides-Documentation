---
title: قالب‌بندی متن ارائه در پایتون از طریق جاوا
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/python-java/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله‌گذاری حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله‌گذاری خطوط
- ویژگی autofit
- تکیه‌گاه قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "متن را در ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق جاوا قالب‌بندی و استایل کنید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java قالب‌بندی کرد. این مقاله به رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری بین حروف، ویژگی‌های قلم، چرخش، فاصله‌گذاری پاراگراف، رفتار Autofit، تکیه‌گاه متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

در مثال‌های زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که شامل یک جعبه متن‌ واحد در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا مطابقت‌های regular‑expression، به [جستجو و جایگزینی متن](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) برای بخش‌های متن جداگانه.

کد مثال زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **کل پاراگراف** تنظیم شود:

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

    # رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** تنظیم شود:

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
            # رنگ برجسته را برای بخش متن تنظیم کنید.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متن خاکستری](gray_text_portions.png)

## **هم‌ترازی پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم هم‌ترازی پاراگراف داخل یک قاب متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

کد مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** هم‌تراز کنیم:

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

    # هم‌ترازی پاراگراف را به مرکز تنظیم کنید.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف هم‌تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگی که به [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار آلفا در مقیاس 0–255 است، نه درصد شفافیت.

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **کل پاراگراف** اعمال کنیم:

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

    # رنگ پر کردن متن را به رنگ شفاف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با قلم بولد** اعمال کنیم:

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
            # شفافیت بخش متن را تنظیم کنید.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله‌گذاری حروف برای متن**

از [PortionFormat.setSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) برای گسترش یا فشردن فاصله بین حروف در یک جعبه متن استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه فاصله‌گذاری حروف در **کل پاراگراف** گسترش یابد:

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

    # توجه: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # فاصله حروف را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله‌گذاری حروف در پاراگراف](character_spacing_in_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه فاصله‌گذاری حروف در **بخش‌های متنی با قلم بولد** گسترش یابد:

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
            # توجه: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3) # فاصله حروف را گسترش دهید.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فاصله‌گذاری حروف در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی Kerning برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات kerning معتبر باشد و kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر به PowerPoint در این شرایط، می‌توانید kerning را برای بخش‌های متنی که از قلم مورد اثر استفاده می‌کنند، غیرفعال کنید. مقدار [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) را به مقدار قابل‌توجهی بزرگ‌تر از اندازه واقعی قلم تنظیم کنید:

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این تنظیم از اعمال kerning بر بخش‌های متن مطابق جلوگیری می‌کند و می‌تواند به سازگاری رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **کل پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman را برای تمام بخش‌های پاراگراف اعمال می‌کند.

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

    # ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
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

کد مثال زیر ویژگی‌های مشابه را برای **بخش‌های متنی با قلم بولد** اعمال می‌کند:

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
            # ویژگی‌های قلم را برای بخش متن تنظیم کنید.
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

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت پیش‌فرض متن درون یک شکل استفاده کنید.

کد مثال زیر جهت متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه به سمت ساعتگرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) استفاده کنید.

کد مثال زیر قاب متن را به میزان ۳ درجه ساعتگرد درون شکل می‌چرخاند:

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

## **تنظیم فاصله‌گذاری خطوط پاراگراف‌ها**

Aspose.Slides توابع [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setSpaceWithin) را برای کنترل فاصله‌گذاری پاراگراف‌ها فراهم می‌کند. این ویژگی‌ها به صورت زیر استفاده می‌شوند:

* برای مشخص کردن فاصله‌گذاری به‌عنوان درصدی از ارتفاع خط، از مقدار مثبت استفاده کنید.
* برای مشخص کردن فاصله‌گذاری به‌صورت نقاط، از مقدار منفی استفاده کنید.

کد مثال زیر نشان می‌دهد چگونه فاصله‌گذاری خط را درون پاراگراف مشخص کنیم:

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

![فاصله‌گذاری خط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای قاب‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند که متن هنگام تجاوز از مرزهای محفظه خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، از بین برود یا به‌صورت خودکار شکل را تغییر اندازه دهد، استفاده کنید.

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

## **تنظیم تکیه‌گاه قاب‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAnchoringType) مشخص می‌کند که متن به صورت عمودی داخل یک شکل چگونه موقعیت یابد، برای مثال در بالا، وسط یا پایین.

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

## **تنظیم تب‌بندی متن**

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

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان اصلاح نویسنده**

Aspose.Slides متد [PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) را فراهم می‌کند که به شما امکان می‌دهد زبان اصلاح نویسنده را برای یک بخش متن تعیین کنید. زبان اصلاح نویسنده زبان مورد استفاده برای بررسی املایی و گرامری در PowerPoint را تعیین می‌کند.

کد مثال زیر نشان می‌دهد چگونه زبان اصلاح نویسنده را برای یک بخش متن تنظیم کنیم:

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

    # شناسه زبان اصلاح نویسنده را تنظیم کنید.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه تولید می‌شود، استفاده کنید.

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

    # یک شکل مستطیلی با متن اضافه کنید.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # زبان اولین بخش متن را بررسی کنید.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **تنظیم استایل متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

کد مثال زیر نشان می‌دهد چگونه یک قلم بولد پیش‌فرض با اندازه ۱۴ pt برای تمام متن‌ها در تمام اسلایدها در یک ارائه جدید تنظیم شود.

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

## **استخراج متن با افکت تمام حروف بزرگ**

در PowerPoint، اعمال افکت **All Caps** باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر اصلیاً با حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides دریافت می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textcaptype/) را بررسی کنید و هنگام مقدار `All`، رشته برگشتی را به حروف بزرگ تبدیل کنید.

بیایید فرض کنیم در اسلاید اول فایل sample2.pptx یک جعبه متن به شکل زیر داریم.

![افکت تمام حروف بزرگ](all_caps_effect.png)

کد مثال زیر نشان می‌دهد چگونه متن را با افکت **All Caps** استخراج کنیم:

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

**چگونه متن در یک جدول روی اسلاید را ویرایش کنم؟**

برای ویرایش متن در یک جدول روی اسلاید، از [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف‌ها از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#getParagraphFormat) به‌روز کنید.

**چگونه می‌توانم رنگ گرادیان را بر روی متن در اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان بر روی متن، از [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) استفاده کنید. [FillFormat.setFillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#setFillType) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/#Gradient) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.