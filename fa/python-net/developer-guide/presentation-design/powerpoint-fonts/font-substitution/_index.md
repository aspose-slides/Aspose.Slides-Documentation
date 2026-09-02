---
title: پیکربندی جایگزینی فونت در ارائه‌ها با Python
linktitle: جایگزینی فونت
type: docs
weight: 70
url: /fa/python-net/font-substitution/
keywords:
- فونت
- جایگزینی فونت
- جایگزینی فونت
- جایگزینی فونت
- جایگزینی فونت
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قوانین جایگزینی فونت را پیکربندی کنید و فونت‌های جایگزین‌شده را در Aspose.Slides برای Python از طریق .NET هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **مرور کلی**

جایگزینی فونت به Aspose.Slides این امکان را می‌دهد که هنگام رندر یا تبدیل یک ارائه، به جای فونتی که قابل دسترسی نیست، از فونت موجود استفاده کند. این جایگزینی بر خروجی رندر تأثیر می‌گذارد؛ اما فونت اختصاص داده شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید فونتی را که هنگام عدم موجودی یک فونت خاص باید استفاده شود تعریف کنید و می‌توانید جایگزینی‌هایی را که Aspose.Slides در طول رندر انجام می‌دهد بررسی کنید. این کار به حفظ یکسانی خروجی در محیط‌های مختلف با فونت‌های نصب شده متفاوت کمک می‌کند.

## **دریافت جایگزینی‌های فونت**

از متد [FontsManager.get_substitutions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_substitutions/) برای تعیین این که هنگام رندر ارائه کدام فونت‌ها جایگزین می‌شوند، استفاده کنید. این متد اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های فونت اصلی و جایگزین را شناسایی می‌کند.

مثال زیر به زبان Python تمام جایگزینی‌های فونت را برای یک ارائه فهرست می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **دریافت جایگزینی‌های فونت برای اسلایدهای انتخابی**

از [FontsManager.get_substitutions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_substitutions/) همراه با فهرست ایندکس‌های اسلاید برای بررسی فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص استفاده کنید. این کار زمانی مفید است که شما بخواهید بخشی از یک ارائه را رندر یا صادرات کنید، یک ارائه بزرگ را به‌صورت افزایشی بررسی کنید، اسلایدهایی که به فونت‌های غیرقابل دسترس وابسته‌اند را پیدا کنید، یک بسته فونت حداقل برای سرور یا کانتینر تهیه کنید، یا تفاوت‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

فهرست شامل ایندکس‌های اسلاید به صورت یک‌پایه است: `1` اولین اسلاید را مشخص می‌کند. در مقابل، مجموعه [Presentation.slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) به صورت صفرپایه است، بنابراین همان اسلاید با `presentation.slides[0]` دسترسی می‌یابد. هنگام ساخت فهرست این تفاوت را در نظر بگیرید تا از خطای یک‑ایندکس جلوگیری کنید.

متد را از طریق ویژگی [Presentation.fonts_manager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/fonts_manager/) فراخوانی کنید. این متد فقط جایگزینی‌های تعیین شده حین رندر اسلایدهای انتخاب‌شده را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsubstitutioninfo/) است که شامل نام‌های فونت اصلی و جایگزین می‌شود. نتیجه منعکس‌کنندهٔ محیط فونت جاری، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ifontsubstrulecollection/)، و [فونت‌های بارگذاری‌شده به صورت خارجی](/slides/fa/python-net/custom-font/) است.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخاب‌شده مورد نیاز باشد. هنگام ایجاد موجودی فونت یا گزارش پیش‌پرواز، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی بازگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های فونت یکتا می‌سازد:

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

کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/) هر دو شکل متد را فراهم می‌کند. یکی را بر اساس دامنه عملیات رندر انتخاب کنید:

| فراخوانی متد | کی استفاده شود |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_substitutions/) بدون آرگومان | وقتی به جایگزینی برای کل ارائه نیاز دارید. |
| [get_substitutions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_substitutions/) با فهرست ایندکس‌های اسلاید | وقتی به جایگزینی برای محدوده‌ای انتخابی، بررسی افزایشی یا صادرات جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی فونت**

برای مشخص کردن فونتی که Aspose.Slides باید هنگام عدم دسترسی به فونت منبع استفاده کند:

1. ارائه را بارگذاری کنید.  
2. تعاریف فونت برای فونت منبع و جایگزین ایجاد کنید.  
3. یک [FontSubstRule](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsubstrule/) با شرط [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsubstcondition/) ایجاد کنید.  
4. این قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsubstrulecollection/) اضافه کنید.  
5. مجموعه را به ویژگی [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) اختصاص دهید.  
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به زبان Python، زمانی که `SomeRareFont` در دسترس نباشد، `Arial` را به‌جای آن جایگزین می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را بررسی کند. فونت جایگزین باید برای Aspose.Slides در دسترس باشد.

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
برای تغییر بدون شرط فونت‌های استفاده‌شده در سراسر یک ارائه، به [Font Replacement](/slides/fa/python-net/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای فونت‌های معادلات ریاضی**

قواعد جایگزینی فونت بخشی از فرآیند استاندارد انتخاب فونت است که در هنگام رندر و تبدیل استفاده می‌شود. این قواعد برای متن معمولی کار می‌کنند وقتی Aspose.Slides می‌تواند یک فونت دسترسی‌ناپذیر را با فونت موجود تعیین‌شده توسط قانون جایگزین کند.

معادلات Office Math یک نیاز اضافی دارند. اگر یک معادله از **Cambria Math** استفاده کند، ممکن است Aspose.Slides برای محاسبه و رندر چیدمان معادله به همان فونت دقیق نیاز داشته باشد. قانونی که یک فونت ریاضی دیگر مانند **STIX Two Math** را جایگزین **Cambria Math** می‌کند، نمی‌تواند این نیاز را برآورده کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** مورد نیاز است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [فونت خارجی](/slides/fa/python-net/custom-font/) بارگذاری کنید.

این محدودیت به چیدمان معادله اعمال می‌شود. قواعد جایگزینی که در بالا توصیف شد همچنان برای متن معمولی ارائه اعمال می‌شوند.

## **سوالات متداول**

**تفاوت جایگزینی فونت با تعویض فونت چیست؟**

جایگزینی فونت [Font replacement](/slides/fa/python-net/font-replacement/) به‌صورتی عمدی یک فونت را در سراسر ارائه به فونت دیگری تغییر می‌دهد. جایگزینی فونت (font substitution) فونتی را برای خروجی رندر انتخاب می‌کند وقتی شرط پیکربندی‌شده برقرار باشد، همان‌طور که فونت اصلی در دسترس نیست.

**قواعد جایگزینی چه زمانی اعمال می‌شوند؟**

قواعد در [دنباله انتخاب فونت](/slides/fa/python-net/font-selection-sequence/) هنگام رندر و تبدیل شرکت می‌کنند. با شرط `WHEN_INACCESSIBLE`، یک قانون فقط وقتی استفاده می‌شود که Aspose.Slides نتواند به فونت منبع دسترسی پیدا کند.

**اگر یک فونت موجود نباشد و قانونی برای جایگزینی پیکربندی نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین فونت موجود را بر اساس فرآیند انتخاب فونت خود انتخاب می‌کند. نتیجه به فونت‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم فونت‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری شود؟**

بله. می‌توانید [فونت‌های خارجی را بارگذاری](/slides/fa/python-net/custom-font/) کنید تا Aspose.Slides در زمان رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose فونت‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول فراهم کردن فونت‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی بین Windows، Linux و macOS می‌تواند متفاوت باشد؟**

بله. فونت‌های نصب شده و مسیرهای جستجوی فونت در هر سیستم عامل متفاوت است، بنابراین فونتی که در یک دستگاه موجود است ممکن است در دستگاه دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب فونت را در تبدیل‌های دسته‌ای یکسان نگه دارم؟**

از همان فایل‌ها و نسخه‌های فونت روی هر ماشین یا کانتینر استفاده کنید، [فونت‌های خارجی مورد نیاز را بارگذاری](/slides/fa/python-net/custom-font/) کنید، و وقتی مجوز اجازه می‌دهد [فونت‌ها را جاسازی](/slides/fa/python-net/embedded-font/) کنید. همچنین می‌توانید قبل از خروجی گرفتن، متد [FontsManager.get_substitutions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/get_substitutions/) را فراخوانی کنید تا جایگزینی‌های ناخواسته را شناسایی کنید.