---
title: پیکربندی جایگزینی قلم در ارائه‌ها با استفاده از پایتون از طریق جاوا
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/python-java/font-substitution/
keywords:
- قلم
- قلم جایگزین
- جایگزینی قلم
- تعویض قلم
- جایگزینی قلم
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "قواعد جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین شده را در Aspose.Slides برای پایتون از طریق جاوا هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **بررسی کلی**

جایگزینی قلم (Font substitution) به Aspose.Slides اجازه می‌دهد تا هنگام رندر یا تبدیل ارائه، از قلم موجود به جای قلم غیرقابل دسترسی استفاده کند. این جایگزینی تنها بر خروجی رندر شده تأثیر می‌گذارد؛ قلم اختصاص داده شده به محتوای ارائه تغییر نمی‌کند.

می‌توانید قلمی را که در صورت عدم دسترسی به یک قلم خاص باید استفاده شود تعریف کنید و جایگزینی‌هایی که Aspose.Slides هنگام رندر انجام می‌دهد را بررسی کنید. این کار به همگنی خروجی در محیط‌های دارای قلم‌های نصب‌شده متفاوت کمک می‌کند.

اگر قلمی موجود باشد اما وزن بولد ویژه‌ای نداشته باشد، به بخش [Handle Fonts Without a Dedicated Bold Typeface](/slides/fa/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) مراجعه کنید. آن بخش نحوه رستر کردن متن تحت تأثیر هنگام خروجی PDF و پیامدهای آن برای انتخاب متن، جستجو و مقیاس‌گذاری را توضیح می‌دهد.

## **دریافت جایگزینی‌های قلم**

از متد [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) برای تعیین اینکه هنگام رندر ارائه چه قلم‌هایی جایگزین می‌شوند، استفاده کنید. این متد اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) را بر می‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کنند.

مثال زیر به زبان Python تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخابی**

از overload متد [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) با آرایه‌ای از اعداد صحیح جاوا استفاده کنید تا تنها جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این روش هنگامی مفید است که بخشی از یک ارائه را رندر یا خروجی می‌گیرید، یک ارائه بزرگ را به صورت تدریجی بررسی می‌کنید، اسلایدهایی را که به قلم‌های غیرقابل دسترس وابسته‌اند شناسایی می‌کنید، بسته قلمی حداقلی برای سرور یا کانتینر آماده می‌کنید یا تفاوت‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص می‌دهید.

آرایه `slides` شامل شاخص‌های اسلاید به‑صورت یک‌پایه است: `1` اولین اسلاید را نشان می‌دهد. در مقابل، accessor مجموعه [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) از اندکس صفر‑پایه استفاده می‌کند، بنابراین همان اسلاید با `presentation.getSlides().get_Item(0)` دسترسی پیدا می‌کند. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطاهای یک‑به‑یک جلوگیری شود.

این overload را از طریق متد [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) فراخوانی کنید. این متد فقط جایگزینی‌هایی را برمی‌گرداند که هنگام رندر اسلایدهای انتخابی تعیین شده‌اند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) است که شامل نام‌های قلم اصلی و جایگزین می‌شود. نتیجه محیط قلم فعلی، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/python-java/custom-font/) را منعکس می‌کند.

یک جایگزینی می‌تواند برای بیش از یک اسلاید انتخابی لازم باشد. هنگام ایجاد موجودی قلم یا گزارش پیش‌پرواز، نتایج را از تکرار حذف کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس یک لیست مرتب‌شده از نگاشت‌های قلمی یکتا ایجاد می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

کلاس [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) هر دو overload را فراهم می‌کند. یکی را بسته به دامنه عملیات رندر انتخاب کنید:

| Overload | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) بدون آرگومان | زمانی که به جایگزینی‌های کل ارائه نیاز دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) با آرایه‌ای از اعداد صحیح جاوا | زمانی که به جایگزینی‌های یک بازه انتخابی، بررسی تدریجی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید در صورت عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعاریف قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) بسازید.
4. این قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به زبان Python، هنگام عدم دسترسی به `SomeRareFont`، `Arial` را به عنوان جایگزین تعریف می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
برای تغییر بدون شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به بخش [Font Replacement](/slides/fa/python-java/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم جزئی از فرآیند استاندارد انتخاب قلم هستند که در طول رندر و تبدیل استفاده می‌شوند. آن‌ها برای متن عادی کار می‌کنند وقتی Aspose.Slides می‌تواند قلم غیرقابل دسترس را با قلم موجود تعیین‌شده توسط قانون جایگزین کند.

معادلات Office Math نیاز خاصی دارند. اگر یک معادله از **Cambria Math** استفاده کند، ممکن است Aspose.Slides برای محاسبه و رندر چیدمان معادله به همان قلم دقیقاً نیاز داشته باشد. قانونی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور جابجا کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** مورد نیاز است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/python-java/custom-font/) بارگذاری کنید.

این محدودیت فقط بر چیدمان معادله اعمال می‌شود. قوانین جایگزینی توضیح‌داده‌شده در بالا همچنان برای متن عادی ارائه معتبر هستند.

## **سوالات متداول**

**تفاوت جایگزینی قلم با جایگزینی (replacement) قلم چیست؟**

[Font replacement](/slides/fa/python-java/font-replacement/) عمداً یک قلم را در تمام ارائه به قلم دیگری تغییر می‌دهد. جایگزینی قلم (font substitution) قلمی را برای خروجی رندر شده انتخاب می‌کند وقتی شرط پیکربندی‌شده برقرار باشد، مانند زمانی که قلم اصلی در دسترس نیست.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنباله انتخاب قلم](/slides/fa/python-java/font-selection-sequence/) هنگام رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و قانون جایگزینی تنظیم نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری شود؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری کنید](/slides/fa/python-java/custom-font/) تا Aspose.Slides بتواند در زمان رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

نه. شما مسئول تأمین قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی بین Windows، Linux و macOS می‌توانند متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم بسته به سیستم‌عامل متفاوت است، بنابراین قلمی که در یک دستگاه موجود است ممکن است در دستگاه دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توان انتخاب قلم را در تبدیل‌های دسته‌ای یکسان نگه داشت؟**

از همان فایل‌ها و نسخه‌های قلم در تمام ماشین‌ها یا کانتینرها استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری کنید](/slides/fa/python-java/custom-font/) و در صورت اجازهٔ مجوز، [قلم‌ها را جاسازی کنید](/slides/fa/python-java/embedded-font/). همچنین می‌توانید قبل از خروجی‌گیری از [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) استفاده کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.