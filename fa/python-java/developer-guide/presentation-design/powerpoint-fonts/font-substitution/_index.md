---
title: پیکربندی جایگزینی قلم در ارائه‌ها با استفاده از Python از طریق Java
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/python-java/font-substitution/
keywords:
- قلم
- قلم جایگزین
- جایگزینی قلم
- جایگزینی قلم
- جایگزینی قلم
- قانون جایگزینی
- قانون جایگزینی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین‌شده را در Aspose.Slides برای Python از طریق Java هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **نمای کلی**

جایگزینی قلم به Aspose.Slides امکان می‌دهد هنگام رندر یا تبدیل یک ارائه، از قلم موجودی به‌جای قلم غیرقابل دسترس استفاده کند. این جایگزینی بر خروجی رندردهی تأثیر می‌گذارد؛ اما قلم اختصاص یافته به محتویات ارائه را تغییر نمی‌دهد.

شما می‌توانید قلمی را که در صورت عدم دسترسی به قلم خاصی استفاده می‌شود، تعریف کنید و جایگزینی‌هایی که Aspose.Slides در حین رندر اعمال می‌کند، بررسی کنید. این کار به حفظ یکپارچگی خروجی در محیط‌های متفاوت با قلم‌های نصب‌شده مختلف کمک می‌کند.

## **دریافت جایگزینی‌های قلم**

از متد [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getSubstitutions) برای تعیین قلم‌هایی که هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این متد اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

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

## **دریافت جایگزینی‌های قلم برای اسلایدهای منتخب**

از بارگذاری [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getSubstitutions) با آرایه‌ای از اعداد صحیح جاوا برای بررسی تنها جایگزینی‌های لازم برای رندر اسلایدهای خاص استفاده کنید. این کار هنگام رندر یا استخراج بخش یی از ارائه، بررسی تدریجی یک ارائه بزرگ، تعیین اسلایدهایی که به قلم‌های غیرقابل دسترس وابسته‌اند، تهیه بستهٔ قلمی حداقل برای سرور یا کانتینر، یا تشخیص اختلافات رندر بدون پردازش اسلایدهای نا مرتبط، مفید است.

آرایهٔ `slides` شامل ایندکس‌های اسلاید با شمارش یک‌پایه است: `1` اولین اسلاید را نشان می‌دهد. در مقابل، دسترسی به مجموعهٔ [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) از شمارش صفرپایه استفاده می‌کند، بنابراین همان اسلاید با `presentation.getSlides().get_Item(0)` قابل دسترسی است. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا خطای یک‑پایه‌نشدن رخ ندهد.

این بارگذاری را از طریق متد [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getFontsManager) فراخوانی کنید. این متد تنها جایگزینی‌های تعیین‌شده هنگام رندر اسلایدهای منتخب را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsubstitutioninfo/) است که نام‌های قلم اصلی و جایگزین را شامل می‌شود. نتیجه بازتاب‌دهندهٔ محیط قلمی کنونی، قوانین بازگردانی پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsubstrulecollection/)، و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/python-java/custom-font/) است.

همین جایگزینی می‌تواند توسط بیش از یک اسلاید منتخب نیاز باشد. هنگام ایجاد موجودی قلم یا گزارش پیش‌پرواز، نتایج را یکتا کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس لیست مرتب‌شده‌ای از نگاشت‌های قلمی منحصر به‌فرد ایجاد می‌کند:

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

کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) هر دو بارگذاری را فراهم می‌کند. یکی را بسته به دامنهٔ عملیات رندر انتخاب کنید:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | نیاز به جایگزینی برای کل ارائه دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | نیاز به جایگزینی برای یک بازهٔ منتخب، بررسی تدریجی یا استخراج جزئی دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید هنگام عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعاریف قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به زبان Python، `Arial` را به‌جای `SomeRareFont` وقتی `SomeRareFont` در دسترس نیست جایگزین می‌کند و سپس اولین اسلاید را رندر می‌نماید تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

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

برای تغییر بدون شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به [Font Replacement](/slides/fa/python-java/font-replacement/) مراجعه کنید.

{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم جزئی از فرآیند استاندارد انتخاب قلم در حین رندر و تبدیل هستند. آن‌ها برای متن معمولی کار می‌کنند زمانی که Aspose.Slides بتواند قلم غیرقابل دسترس را با قلم موجودی که در قانون مشخص شده، جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر معادله‌ای از **Cambria Math** استفاده کند، Aspose.Slides ممکن است برای محاسبه و رندر طرح‌بندی معادله به آن قلم دقیقاً نیاز داشته باشد. قانونی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور جایگزین کند و ممکن است رندر همچنان گزارش دهد که **Cambria Math** ضروری است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/python-java/custom-font/) بارگذاری کنید.

این محدودیت فقط به طرح‌بندی معادله مربوط می‌شود. قوانین جایگزینی توصیف‌شده در بالا همچنان برای متن معمولی ارائه اعمال می‌شوند.

## **سؤالات متداول**

**تفاوت بین جایگزینی قلم و تعویض قلم چیست؟**

[Font replacement](/slides/fa/python-java/font-replacement/) به‌صورت عمدی یک قلم را در سرتاسر ارائه به قلم دیگری تغییر می‌دهد. جایگزینی قلم برای خروجی رندردهی، زمانی که شرط پیکربندی‌شده برقرار باشد (مانند عدم دسترسی به قلم اصلی) یک قلم را انتخاب می‌کند.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنبالهٔ انتخاب قلم](/slides/fa/python-java/font-selection-sequence/) طی رندر و تبدیل مشارکت دارند. با `WhenInaccessible`، یک قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی مفقود باشد و هیچ قانون جایگزینی‌ای پیکربندی نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری شود؟**

بله. می‌توانید [قلم‌های خارجی](/slides/fa/python-java/custom-font/) را بارگذاری کنید تا Aspose.Slides در حین رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول تهیه قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی بین Windows، Linux و macOS می‌توانند متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم بسته به سیستم‌عامل متفاوت است، بنابراین قمی که در یک ماشین در دسترس است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای یکدست نگه دارم؟**

از همان فایل‌ها و نسخه‌های قلم در هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز](/slides/fa/python-java/custom-font/) را بارگذاری کنید و در صورت اجازهٔ مجوز، [قلم‌ها را embed](/slides/fa/python-java/embedded-font/) کنید. همچنین می‌توانید پیش از خروجی گرفتن، با فراخوانی [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getSubstitutions) جایگزینی‌های غیرمنتظره را شناسایی کنید.