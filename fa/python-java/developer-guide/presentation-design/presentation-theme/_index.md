---
title: مدیریت تم‌های ارائه در پایتون از طریق جاوا
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/python-java/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- تم خارجی
- THMX
- رنگ تم
- پالت اضافه
- قلم تم
- سبک تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای پایتون از طریق جاوا برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به جای ذخیرهٔ هر ویژگی بصری به صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، به‌طوری‌که تغییر تم می‌تواند بسیاری از اشیا را به‌صورت همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasterTheme) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم در سطوح پایین‌تر داشته باشد. یک مستربندی می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterthememanager/#getOverrideTheme) بازنویسی کند، در حالی که یک طرح‌بندی یا یک اسلاید تک‌تک می‌تواند تم ارث‌برده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیرهٔ ارث‌برداری حل می‌شود: تم ارائه، بازنویسی مستربندی، بازنویسی طرح‌بندی، و بازنویسی اسلاید.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

بخش‌های زیر رایج‌ترین کارهای مرتبط با تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روز رسانی سبک‌های پس‌زمینه و افکت‌ها، و خواندن مقادیر مؤثر پس از حل ارث‌برداری و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mastertheme/) طرح رنگ، طرح قلم و طرح فرمت تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mastertheme/#getColorScheme)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mastertheme/#getFontScheme) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/mastertheme/#getFormatScheme) در معرض نمایش می‌گذارد. بررسی این مجموعه‌ها قبل از تغییر آن‌ها به‌ویژه وقتی مفید است که ارائه‌ای از منبع خارجی باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر خصوصیات اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

اگر فایلی از چند مستربندی استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستربندی مرتبط با اسلاید را بررسی کنید و در زمانی که ممکن است بازنویسی‌های طرح‌بندی یا اسلاید وجود داشته باشد، از جریان کاری تم مؤثر که در ادامه مقاله نشان داده شده استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/schemecolor/) ارجاع دهند. هنگامی که ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/colorscheme/) را تغییر می‌دهید، تمام اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند، بر اساس مقدار جدید حل می‌شوند. اشیایی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

چون مستطیل همچنان به `Accent4` مرتبط است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز در می‌آید. اگر رنگ طرح را به‌صورت مستقیم روی شکل جایگزین کنید، تغییرات آیندهٔ `Accent4` دیگر بر آن پرکننده تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، نسخه‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - نسخه‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل مبتنی بر `Accent4` ایجاد می‌کند، برای پنج مورد از آن‌ها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌سازد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این نسخه‌ها بر پایهٔ رنگ تم باقی می‌مانند. اگر بعداً `Accent4` تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `ColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/colorscheme/) همان اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` نمایش می‌دهد. این نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها اسامی جایگزین برای همان اسلات‌های تم هستند؛ مقادیری نیستند که به‌صورت پویا از یک شکل به شکل دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعهٔ قلم اصلی برای سرعنوان‌ها و یک مجموعهٔ قلم فرعی برای متن بدنه است. روش‌های [FontScheme.getMajor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontscheme/#getMajor) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontscheme/#getMinor) این مجموعه‌ها را در معرض نمایش می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن مورد استفاده قرار گیرند:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

مثال زیر یک سرعنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند، ایجاد می‌کند. سپس قلم‌های تم را تغییر داده و نتیجه را ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

سرعنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که نام قلم صریحی به جای شناسهٔ تم داشته باشد، هنگام تغییر طرح قلم تم به‌صورت خودکار جابجا نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری خاص باشند، مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [Script‑Specific Theme Fonts](/slides/fa/python-java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="success" title="Tip" %}}
برای اطلاعات بیشتر دربارهٔ قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/python-java/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

جریان‌های کاری زیر مشکلات مختلف مربوط به تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به مستربندی**

از [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) زمانی استفاده کنید که یک فایل تم PowerPoint (`.thmx`) داشته باشید و بخواهید تمام اسلایدهایی که به یک مستربندی خاص وابسته‌اند، بازطراحی شوند. مستربندی را از مجموعهٔ [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) که توسط [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/) نمایان می‌شود، انتخاب کنید و مسیر فایل تم را به روش پاس دهید.

این روش عملیات زیر را انجام می‌دهد:

1. یک مستربندی جدید بر پایهٔ مستربندی انتخاب شده ایجاد می‌کند.
1. تم خارجی را بر روی مستربندی جدید اعمال می‌کند.
1. مستربندی جدید را به تمام اسلایدهایی که قبلاً به مستربندی انتخاب شده وابسته بودند، اختصاص می‌دهد.
1. [MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) تازهٔ ایجادشده را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستربندی وابسته‌اند، اعمال می‌کند و ارائه را ذخیره می‌سازد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

یک تم نامعتبر، خراب یا پشتیبانی‑نشده می‌تواند منجر به [PptxReadException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxreadexception/) شود. مسیرهای ارائه‌شده توسط کاربر را اعتبارسنجی کنید، شکست‌های دسترسی به سیستم‌فایل را مدیریت کنید و پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

تنها اسلایدهایی که به مستربندی انتخاب شده وابسته بودند، بازتخصیص می‌یابند. اسلایدهای مرتبط با مستربندی‌های دیگر، مستربندی و تم‌های فعلی خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم در برابر تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و سایر فرمت‌های صریحی که به‌صورت مستقیم اختصاص داده شده‌اند، ممکن است بدون تغییر باقی بمانند. بازنویسی‌های سطح طرح‌بندی و اسلاید نیز می‌توانند بر مقادیر ارث‌برداری شده از مستربندی جدید تقدم داشته باشند.

تم می‌تواند به قلم‌هایی ارجاع دهد که در محیط زمان اجرای موجود نیستند. برای رندر ثابت و خروجی، قلم‌های مورد نیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/python-java/custom-font/) استفاده کنید یا [جایگزینی قلم](/slides/fa/python-java/font-substitution/) را پیکربندی کنید.

این یک جریان کاری مستقیم در سطح مستربندی است: این روش مسیر فایل `.thmx` را می‌گیرد و نیازی به ایجاد بازنویسی‌های تم در سطح اسلاید یا طرح‌بندی به‌صورت دستی ندارید.

### **اعمال تم‌های خارجی متفاوت در ارائهٔ چند‑مستربندی**

زمانی که مستربندی موردنظر از پیش شناخته نشده باشد، آن را از طریق یک اسلاید نماینده با استفاده از [Slide.getLayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getLayoutSlide) و [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getMasterSlide) به دست آورید. پیش از اعمال هر تمی، مراجع مستربندی اصلی را ذخیره کنید، زیرا هر فراخوانی یک مستربندی جدید در ارائه ایجاد می‌کند.

مثال زیر از اسلایدهای دو بخش برای یافتن مستربندی‌هایشان استفاده می‌کند و هر گروه تم خارجی متفاوتی اعمال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

فراخوانی اول فقط بر اسلایدهایی که به `first_group_master` وابسته‌اند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `second_group_master` وابسته‌اند. اسلایدهایی که به هر مستربندی دیگری تعلق دارند، بازطراحی نمی‌شوند.

### **حفظ تم منبع هنگام انتقال اسلایدها**

اگر می‌خواهید اسلایدی را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستربند منبع را با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#addClone) به ارائهٔ مقصد کلون کنید، سپس اسلاید را با استفاده از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) و مستربند کلون‌شده کلون کنید. این کار مستربند، طرح‌بندی‌های آن و تم مرتبط را همراه خود می‌برد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

این جریان کاری ترجیحی است هنگامی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. ساده‌وار کلون کردن محتوا بر روی یک مستربند مقصد نامربط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستربند و طرح‌بندی فعلی خود بماند، یک بازنویسی سطح اسلایدی از تم منبع مقداردهی اولیه کنید. روش‌های [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌برده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌برداری، [OverrideTheme.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/overridetheme/#clear) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک طرح‌بندی**

بازنویسی سطح طرح‌بندی بر اسلایدهایی که از آن طرح‌بندی استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خود را داشته باشد. همان روش‌های مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslidethememanager/) استفاده شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

هنگامی که بسیاری از طرح‌بندی‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، از تم سطح مستربند یا ارائه استفاده کنید؛ برای یک خانوادهٔ طرح‌بندی که نیاز به سبک متفاوت دارد، از بازنویسی طرح‌بندی استفاده کنید و برای استثناهای واقعی فقط از بازنویسی اسلاید بهره ببرید. بازنویسی‌های بیش از حد سطح اسلاید باعث می‌شود تغییرات تم سراسری بعدی پیش‌بینی‌پذیر نباشند.

## **به‌روز رسانی سبک‌های پس‌زمینهٔ تم**

پرکننده‌های پس‌زمینهٔ تم در [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینهٔ بیشتری را در رابط کاربری خود ارائه دهد نسبت به تعداد تعریف‌های پرکننده‌ای که به‌صورت فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر مراجع سبک ترکیب کند.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و [Background.getStyleIndex](https://reference.aspose.com/slides/fa/python-java/aspose.slides/background/#getStyleIndex) فعلی را بررسی کنید. یک شاخص سبک برابر با `0` به معنی عدم وجود پرکنندهٔ تم است؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینهٔ تم هستند. این با ایندکس‌گذاری مستقیم مجموعه متفاوت است؛ در این حالت `get_Item(0)` به اولین مورد ذخیره‌شده اشاره دارد. فرض نکنید که هر ارائهٔ تعداد یکسانی از سبک‌های پرکنندهٔ پس‌زمینه دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینهٔ موجود را گزارش می‌کند، یک ارجاع پس‌زمینهٔ تم به اولین مستربندی اختصاص می‌دهد و ارائه را ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجهٔ قابل مشاهده به ورودی تم ارجاع‌شده توسط مستربندی و به هر بازنویسی پس‌زمینه‌ای در سطح طرح‌بندی یا اسلاید وابسته است. اگر اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر تنها پس‌زمینهٔ مستربندی ممکن است آن اسلاید را تغییر ندهد. هنگامی که نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌برداری دارید، از [Background.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/background/#getEffective) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
شاخص سبک را به‌عنوان یک شاخص صفر‑مبنا برای مجموعه در نظر نگیرید. همچنین از کدنویسی سخت‌گیرانهٔ یک شمارهٔ سبک از یک فایل و انتظار داشتن ظاهر مشابه در فایل دیگر خودداری کنید؛ تعریف‌های سبک تم به‌صورت خاص برای هر ارائه‌اند.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
برای فرمت‌بندی مستقیم پس‌زمینه و ارث‌برداری پس‌زمینه، به [Presentation Background](/slides/fa/python-java/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روز رسانی افکت‌های تم**

یک طرح فرمت تم شامل مجموعه‌های جداگانهٔ پرکننده، خط و افکت است که از طریق [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/python-java/aspose.slides/formatscheme/#getFillStyles)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/python-java/aspose.slides/formatscheme/#getLineStyles) و [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/python-java/aspose.slides/formatscheme/#getEffectStyles) در دسترس هستند. تم‌های معمولی Office اغلب سه ورودی اصلی سبک دارند که به‌صورت بصری به ترتیب به سبک‌های ظریف، متوسط و پرقدرت متناظرند، اما کد باید هر مجموعه را به‌جای فرض تعداد ثابت بررسی کند.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در Python از طریق Java دسترسی می‌یابید، ایندکس مجموعه صفر‑مبنا است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین سبک است. ایندکس‌های مرجع‑سبک یک شکل مفهوم جداگانه‌ای است که از طریق [ShapeStyle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapestyle/) در دسترس است. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که فرمت‌بندی مستقیم دارند ممکن است تغییری نکنند.

مثال زیر بررسی می‌کند که ورودی‌های سبک موردنیاز وجود داشته باشند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای شکل‌هایی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم به رنگ قرمز تبدیل می‌شود، سومین سبک پرکننده تم به رنگ سبز جنگلی جامد تغییر می‌یابد و سومین سبک افکت یک سایهٔ بیرونی با فاصلهٔ 10 پوینت به‌دست می‌آورد. نتیجهٔ بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا فرمت‌بندی مستقیم آن را بازنویسی می‌کند یا نه.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **تعیین اینکه آیا یک پرکنندهٔ ثابت مؤثر از رنگ تم استفاده می‌کند**

یک پرکننده می‌تواند به‌صورت مستقیم روی شیء ذخیره شود یا از یک پاراگراف، طرح‌بندی، مستربند، سبک تم یا سطح فرمت دیگر ارث‌برداری شود. برای حل این سلسله مراتب به دادهٔ پرکنندهٔ مؤثر غیرقابل تغییر، [FillFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getEffective) را فراخوانی کنید. ابتدا `getFillType` را روی شیء دادهٔ مؤثر بررسی کنید. تنها زمانی که مقدار `FillType.Solid` باشد، باید ویژگی‌های پرکنندهٔ ثابت را بخوانید.

برای یک پرکنندهٔ ثابت، `getSolidFillColor` مقدار نهایی RGB پس از اعمال ارث‌برداری، جستجوی تم و تبدیلات رنگ را برمی‌گرداند. `getSolidFillSchemeColor` اسلات منطقی مربوط به [SchemeColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/schemecolor/) را برمی‌گرداند، مانند `Text1` یا `Accent6`. مقدار `SchemeColor.NotDefined` به این معناست که پرکنندهٔ ثابت مؤثر بر پایهٔ رنگ طرح نیست. در یک جریان کاری که پرکننده‌ها یا رنگ‌های تم هستند یا رنگ‌های RGB مستقیم، این مقدار یک پرکنندهٔ RGB مستقیم را شناسایی می‌کند.

از مقدار محلی [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/colorformat/#getSchemeColor) به‌تنهایی برای طبقه‌بندی پرکننده استفاده نکنید. برای مثال، بخشی از متن ممکن است رنگ طرح محلی نداشته باشد، بنابراین مقدار محلی آن `NotDefined` است، در حالی که پرکنندهٔ مؤثر آن از یک رنگ تم ارث‌برداری می‌شود و به `Text1` یا `Accent6` حل می‌گردد. برعکس، `getSolidFillSchemeColor` مشخص می‌کند کدام اسلات منطقی تم رنگ نهایی را تولید کرده است، اما نمی‌گوید آن اسلات از شی، پاراگراف، طرح‌بندی، مستربند یا سطح دیگری از سلسله مراتب فرمت آمده است.

مثال زیر یک ارائه را بارگیری می‌کند، هر دو پرکنندهٔ شکل و پرکنندهٔ بخش متن را بررسی می‌کند، هر مقدار نهایی RGB و رنگ طرح مرتبط را چاپ می‌کند و پرکننده‌های ثابت را که با تغییرات رنگ تم هماهنگ نخواهند شد، علامت‌گذاری می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

شاخهٔ `NotDefined` فهرستی از پرکننده‌های ثابت ارائه می‌دهد که به تغییرات اسلات‌های رنگ تم پاسخ نمی‌دهند. این اشیا را زمانی که ارائه باید با پالت برند جدید مطابقت داشته باشد، مرور کنید. مقدار RGB گزارش‌شده هنوز ظاهر فعلی را نشان می‌دهد، در حالی که مقدار طرح توضیح می‌دهد آیا آن ظاهر به تم وصل است یا خیر.

اشیای مؤثر‑فرمت یک تصویر لحظه‌ای هستند. پس از تغییر تم ارائه، یک بازنویسی تم یا هر فرمت ارث‌برداری‌شده‌ای، دوباره `getEffective` را فراخوانی کنید و یک شیء دادهٔ پرکنندهٔ مؤثر جدید بخوانید قبل از مقایسه یا گزارش رنگ‌ها.

## **خواندن مقادیر مؤثر تم**

اشیای تم خام نشان می‌دهند که در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر نشان می‌دهند یک اسلاید یا شکل پس از حل ارث‌برداری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) را فراخوانی کنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/background/#getEffective) و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getEffective) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط به [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasterTheme) نگاهی بیندازید، ممکن است یک بازنویسی مستربند، طرح‌بندی، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **پرسش‌های متداول**

**آیا اعمال یک تم خارجی بر همهٔ اسلایدهای ارائه تأثیر می‌گذارد؟**

نه. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) تنها اسلایدهایی را که به مستربند انتخابی وابسته‌اند، بازتخصیص می‌دهد. اسلایدهایی که از مستربندهای دیگر استفاده می‌کنند، تم‌های فعلی خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط به یک اسلاید اعمال کنم بدون تغییر مستربند؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی کنید. تغییر به‌صورت محلی به آن اسلاید محدود می‌شود؛ اسلایدهای دیگر همچنان تم‌های موجود خود را ارث‌برداری می‌کنند.

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگامی که اسلایدی را منتقل می‌کنید و می‌خواهید ظاهر منبع را حفظ کنید، مستربند منبع را به مقصد کلون کنید و سپس اسلاید را با همان مستربند با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#addClone) و [SlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) کلون کنید. این کار مستربند، طرح‌بندی‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌برداری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) برای یک اسلاید یا تم طرح‌بندی و روش‌های دادهٔ مؤثر مربوطه برای اشیای فرمت مانند [Background.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/background/#getEffective) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getEffective) استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌برداری و بازنویسی‌ها را برمی‌گردانند.