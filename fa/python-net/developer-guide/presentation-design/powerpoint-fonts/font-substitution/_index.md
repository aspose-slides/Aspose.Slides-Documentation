---
title: پیکربندی جایگزینی قلم در ارائه‌ها با Python
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/python-net/font-substitution/
keywords:
- قلم
- جایگزینی قلم
- جایگزینی قلم
- تعویض قلم
- جایگزینی قلم
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "جایگزینی قلم بهینه را در Aspose.Slides برای Python از طریق .NET فعال کنید تا هنگام تبدیل ارائه‌های PowerPoint و OpenDocument به فرمت‌های فایل دیگر."
---
## **نمای کلی**

جایگزینی قلم به Aspose.Slides امکان استفاده از یک قلم دیگر را می‌دهد زمانی که قلم اصلی ارائه در هنگام رندر یا تبدیل در دسترس نباشد. می‌توانید با استفاده از متد `get_substitutions` در کلاس `FontsManager` بررسی کنید کدام قلم‌ها جایگزین شده‌اند.

Aspose.Slides همچنین اجازه می‌دهد قوانین جایگزینی قلم را تعریف کنید. به عنوان مثال می‌توانید مشخص کنید که یک قلم غیرقابل دسترسی باید با قلم دیگری که در دسترس است جایگزین شود و سپس این قوانین را از طریق مدیر قلم ارائه اعمال کنید.

## **تنظیم قوانین جایگزینی**

Aspose.Slides به شما امکان می‌دهد قوانین برای قلم‌ها تعیین کنید که در شرایط خاص چه کاری باید انجام شود (به عنوان مثال، وقتی قلم قابل دسترسی نیست) به این شکل:

1. ارائه مربوطه را بارگذاری کنید.
2. قلمی که باید جایگزین شود را بارگذاری کنید.
3. قلم جدید را بارگذاری کنید.
4. یک قانون برای جایگزینی اضافه کنید.
5. قانون را به مجموعه‌ی قوانین جایگزینی قلم ارائه اضافه کنید.
6. تصویر اسلاید را تولید کنید تا اثر را مشاهده کنید.

این کد پایتون فرآیند جایگزینی قلم را نشان می‌دهد:

```python
import aspose.slides as slides

# ارائه‌ای را بارگذاری می‌کند
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # قلم منبعی که جایگزین خواهد شد را بارگذاری می‌کند
    sourceFont = slides.FontData("SomeRareFont")

    # قلم جدید را بارگذاری می‌کند
    destFont = slides.FontData("Arial")

    # قانونی برای جایگزینی قلم اضافه می‌کند
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # قانون را به مجموعه قوانین جایگزینی قلم اضافه می‌کند
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # مجموعه قوانین قلم را به لیست قوانین اضافه می‌کند
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial فونت در جای SomeRareFont استفاده خواهد شد وقتی که این قلم قابل دسترسی نباشد
    with presentation.slides[0].get_image(1, 1) as bmp:
        # تصویر را در فرمت JPEG به دیسک ذخیره می‌کند
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
ممکن است مایل باشید به [**جایگزینی قلم**](/slides/fa/python-net/font-replacement/) مراجعه کنید. 
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم در فرآیند استاندارد انتخاب قلم که در هنگام رندر و تبدیل استفاده می‌شود شرکت می‌کنند. این قوانین برای موارد متن عادی مناسب هستند که در آن Aspose.Slides می‌تواند یک قلم غیرقابل دسترسی را با قلم دیگری که در دسترس است مطابق با قانون تنظیم شده جایگزین کند.

با این حال، معادلات ریاضی Office محدودیت مهمی دارند. اگر یک معادله با **Cambria Math** ساخته شده باشد، Aspose.Slides ممکن است هنوز برای محاسبه و رندر صحیح چیدمان معادله به قلم اصلی **Cambria Math** نیاز داشته باشد. به همین دلیل، جایگزینی **Cambria Math** با قلم ریاضی دیگر، مانند **STIX Two Math**، برای رندر معادله پشتیبانی نمی‌شود و ممکن است همچنان استثنایی نشان دهد که **Cambria Math** ضروری است.

برای تبدیل موفق این ارائه‌ها، اطمینان حاصل کنید که **Cambria Math** در زمان اجرا برای Aspose.Slides موجود باشد. می‌توانید این قلم را در سیستم‌عامل نصب کنید یا به عنوان یک [قلم خارجی](/slides/fa/python-net/custom-font/) فراهم کنید تا در فرآیند انتخاب قلم معمولی در هنگام رندر و تبدیل شرکت کند.

این محدودیت مختص رندر معادلات است. قوانین استاندارد جایگزینی قلم که در بالا شرح داده شد همچنان برای متن عادی ارائه هنگام عدم دسترسی به قلم اصلی اعمال می‌شوند.

## **سوالات متداول**

**What is the difference between font replacement and font substitution?**  
[جایگزینی](/slides/fa/python-net/font-replacement/) یک نادیده‌گیری اجباری یک قلم با قلم دیگر در سرتاسر ارائه است. جایگزینی (substitution) قانونی است که در شرایط خاصی فعال می‌شود، برای مثال وقتی قلم اصلی در دسترس نیست، و سپس یک قلم جایگزین تعیین‌شده استفاده می‌شود.

**When exactly are substitution rules applied?**  
قوانین در توالی استاندارد [انتخاب قلم](/slides/fa/python-net/font-selection-sequence/) که در زمان بارگذاری، رندر و تبدیل ارزیابی می‌شود، شرکت می‌کنند؛ اگر قلم انتخاب‌شده در دسترس نباشد، جایگزینی یا substitution اعمال می‌شود.

**What is the default behavior if neither replacement nor substitution is configured and the font is missing on the system?**  
کتابخانه سعی می‌کند نزدیک‌ترین قلم موجود در سیستم را انتخاب کند، مشابه رفتار PowerPoint.

**Can I attach custom external fonts at runtime to avoid substitution?**  
بله. می‌توانید [افزودن قلم‌های خارجی](/slides/fa/python-net/custom-font/) را در زمان اجرا انجام دهید تا کتابخانه آنها را برای انتخاب و رندر در نظر بگیرد، از جمله برای تبدیل‌های بعدی.

**Does Aspose distribute any fonts with the library?**  
خیر. Aspose قلم‌های پرداختی یا رایگانی را توزیع نمی‌کند؛ شما قلم‌ها را به اختیار و مسئولیت خود اضافه و استفاده می‌کنید.

**Are there differences in substitution behavior on Windows, Linux, and macOS?**  
بله. کشف قلم از دایرکتوری‌های قلم سیستم عامل شروع می‌شود. مجموعه قلم‌های پیش‌فرض موجود و مسیرهای جستجو در هر پلتفرم متفاوت است که بر دسترس بودن و نیاز به جایگزینی تاثیر می‌گذارد.

**How should I prepare the environment to minimize unexpected substitution during batch conversions?**  
مجموعه قلم‌ها را بین ماشین‌ها یا کانتینرها همگام‌سازی کنید، [افزودن قلم‌های خارجی](/slides/fa/python-net/custom-font/) مورد نیاز برای اسناد خروجی کنید، و در صورت امکان [قرار دادن قلم‌ها در فایل](/slides/fa/python-net/embedded-font/) در ارائه‌ها انجام دهید تا قلم‌های انتخاب‌شده در زمان رندر موجود باشند.