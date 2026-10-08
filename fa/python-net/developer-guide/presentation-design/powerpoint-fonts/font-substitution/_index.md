---
title: پیکربندی جایگزینی قلم در ارائه‌ها با پایتون
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/python-net/font-substitution/
keywords:
- قلم
- قلم جایگزین
- جایگزینی قلم
- جایگزینی قلم
- تعویض قلم
- قاعده جایگزینی
- قاعده تعویض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین شده را در Aspose.Slides برای پایتون از طریق .NET هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **بررسی کلی**

جایگزینی قلم به Aspose.Slides اجازه می‌دهد در هنگام رندر یا تبدیل یک ارائه، از یک قلم موجود به جای قلم‌ای که قابل دسترسی نیست استفاده کند. این جایگزینی فقط بر خروجی رندر شده تأثیر می‌گذارد؛ قلم اختصاصی محتوای ارائه تغییر نمی‌کند.

می‌توانید قلمی را که در صورت عدم دسترسی به قلم خاصی استفاده شود تعریف کنید و جایگزینی‌هایی را که Aspose.Slides هنگام رندر انجام می‌دهد بررسی کنید. این کار به حفظ یکدستی خروجی در محیط‌های مختلف با قلم‌های نصب شده متفاوت کمک می‌کند.

اگر قلمی موجود باشد اما وزن بولد اختصاصی نداشته باشد، به [پردازش فونت‌ها بدون قلم بولد اختصاصی](/slides/fa/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) مراجعه کنید. آن بخش توضیح می‌دهد چگونه متن تحت تأثیر را هنگام خروجی PDF رستر کنید و پیامدهای آن برای انتخاب متن، جستجو و مقیاس‌گذاری چیست.

## **دریافت جایگزینی‌های قلم**

از متد [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) برای تعیین این که چه قلم‌هایی هنگام رندر ارائه جایگزین می‌شوند استفاده کنید. این متد اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

مثال زیر به زبان Python تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخابی**

از [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) همراه با لیستی از ایندکس‌های اسلاید برای بررسی فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص استفاده کنید. این کار زمانی مفید است که بخواهید بخشی از یک ارائه را رندر یا خروجی بگیرید، یک ارائه بزرگ را به‌صورت افزایشی بررسی کنید، اسلایدهایی که به قلم‌های غیرقابل دسترس وابسته‌اند پیدا کنید، بسته قلمی حداقل را برای سرور یا کانتینر آماده کنید یا تفاوت‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

این لیست شامل ایندکس‌های اسلاید یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقایسه، مجموعه [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) صفرپایه است، بنابراین همان اسلاید به شکل `presentation.slides[0]` دسترسی می‌یابد. هنگام ساخت لیست این تفاوت را در ذهن داشته باشید تا خطای یک‑تایید نشود.

متد را از طریق ویژگی [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) فراخوانی کنید. این متد تنها جایگزینی‌های تعیین‌شده در زمان رندر اسلایدهای انتخابی را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) است که نام‌های قلم اصلی و جایگزین را شامل می‌شود. نتیجه بازتاب‌دهنده محیط قلمی فعلی، قوانین پیش‌فرض پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/) و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/python-net/custom-font/) است.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخابی نیاز باشد. هنگام ایجاد موجودی قلم یا گزارش پیش‌پرواز، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌دهد و سپس فهرستی مرتب‌شده از نگاشت‌های قلم منحصر به‌فرد ایجاد می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

کلاس [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) هر دو شکل متد را ارائه می‌دهد. بسته به زمینه عملیات رندر، یکی را انتخاب کنید:

| فراخوانی متد | زمان استفاده |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) بدون آرگومان | زمانی که به جایگزینی‌های کل ارائه نیاز دارید. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) با لیستی از ایندکس‌های اسلاید | زمانی که به جایگزینی‌های یک بازه انتخابی، بررسی افزایشی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید در صورت عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم‌های منبع و جایگزین ایجاد کنید.
3. یک شیء [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) با شرط [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را به ویژگی [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر در زبان Python، هنگام عدم دسترسی به `SomeRareFont`، `Arial` را به‌عنوان جایگزین استفاده می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را بررسی کند. قلم جایگزین باید برای Aspose.Slides قابل دسترس باشد.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
برای تغییر بدون شرط فونت‌های استفاده‌شده در کل ارائه، به [جایگزینی قلم](/slides/fa/python-net/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای فونت‌های معادلات ریاضی**

قوانین جایگزینی قلم بخشی از فرآیند استاندارد انتخاب قلم هستند که در طول رندر و تبدیل استفاده می‌شود. آن‌ها برای متن عادی کار می‌کنند وقتی Aspose.Slides می‌تواند یک قلم غیرقابل دسترس را با قلم موجود تعیین‌شده توسط قانون جایگزین کند.

معادلات Office Math نیازمند یک شرط اضافی هستند. اگر یک معادله از **Cambria Math** استفاده کند، Aspose.Slides ممکن است برای محاسبه و رندر طرح‌بندی معادله به دقیقاً همان قلم نیاز داشته باشد. قانونی که یک قلم ریاضی دیگر مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور جایگزین کند و ممکن است رندر همچنان گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را برای Aspose.Slides قابل دسترس کنید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/python-net/custom-font/) بارگذاری کنید.

این محدودیت به طرح‌بندی معادله اعمال می‌شود. قوانین جایگزینی توصیف‌شده در بالا هنوز برای متن معمولی ارائه اعمال می‌شوند.

## **سوالات متداول**

**تفاوت بین جایگزینی قلم و جایگزینی فونت چیست؟**

[جایگزینی قلم](/slides/fa/python-net/font-replacement/) به‌صورت عمدی یک قلم را در سرتاسر ارائه به قلم دیگری تغییر می‌دهد. جایگزینی قلم فقط برای خروجی رندر شده زمانی که شرط پیکربندی‌شده برآورده شود (مانند عدم دسترسی به قلم اصلی) یک قلم دیگر را انتخاب می‌کند.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در [دنباله انتخاب قلم](/slides/fa/python-net/font-selection-sequence/) در طول رندر و تبدیل شرکت می‌کنند. با شرط `WHEN_INACCESSIBLE`، قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی داشته باشد.

**وقتی قلمی موجود نباشد و قانونی برای جایگزینی تعریف نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه بستگی به قلم‌های موجود در محیط زمان اجرا دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری کنید](/slides/fa/python-net/custom-font/) تا Aspose.Slides بتواند در طول رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول تأمین قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی می‌توانند بین Windows، Linux و macOS متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم در سیستم‌عامل متفاوت است؛ بنابراین قلمی که در یک ماشین موجود است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای یکسان نگه دارم؟**

از همان فایل‌ها و نسخه‌های قلم در هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری کنید](/slides/fa/python-net/custom-font/) و در صورت امکان [قلم‌ها را جاسازی کنید](/slides/fa/python-net/embedded-font/). همچنین می‌توانید قبل از خروجی [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) را فراخوانی کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.