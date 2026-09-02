---
title: مدیریت قلم‌های تم مخصوص اسکریپت در پایتون
linktitle: قلم‌های تم مخصوص اسکریپت
type: docs
weight: 15
url: /fa/python-net/script-specific-font-mappings/
keywords:
- قلم مخصوص اسکریپت
- نگاشت قلم تم
- ارائه چندزبانه
- سیستم نوشتاری
- قلم سیریلیک
- قلم عربی
- قلم ژاپنی
- قلم گرجی
- قلم ثانا
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "بررسی، افزودن، جایگزینی و حذف نگاشت‌های قلم مخصوص اسکریپت در تم‌های PowerPoint با Aspose.Slides برای پایتون از طریق .NET."
---
## **بررسی کلی**

یک تم ارائه می‌تواند خانواده‌های قلم متفاوتی را برای سیستم‌های نوشتاری مختلف انتخاب کند. این امکان به متن‌های چندزبانه که همچنان از قلم‌های تم استفاده می‌کنند، اجازه می‌دهد تا از یک طرح قلم هماهنگ پیروی کنند در حالی که برای سیریلیک، عربی، ژاپنی، گرجی، ثانا و سایر خط‌ها از قلم‌های مناسب استفاده می‌شود.

تم [FontScheme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/) شامل یک مجموعه قلم اصلی (معمولاً برای عناوین) و یک مجموعه قلم فرعی (معمولاً برای متن اصلی) است. علاوه بر ویژگی‌های قلم‌های لاتین و شرق آسیا، هر دو مجموعه نگاشت‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده قلم از طریق کلاس [Fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/) ارائه می‌دهند.

این مقاله نشان می‌دهد چگونه این نگاشت‌ها را در تم اصلی ارائه بررسی و اصلاح کنیم و اطمینان حاصل کنیم که تغییرات پس از ذخیره و بارگذاری مجدد حفظ می‌شوند.

## **درک برچسب‌های اسکریپت**

متدهای قلم اسکریپت از برچسب‌های فرعی چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقادیر رایج شامل:

| برچسب اسکریپت | سیستم نوشتاری |
|---|---|
| `Cyrl` | سیریلیک |
| `Arab` | عربی |
| `Hans` | چینی ساده‌شده |
| `Jpan` | ژاپنی |
| `Geor` | گرژی |
| `Thaa` | ثانا |

این نگاشت‌ها متعلق به طرح قلم تم هستند، نه به بخش‌های متنی جداگانه. یک ارائه می‌تواند برای مجموعه‌های اصلی و فرعی نگاشت‌های متفاوتی تعریف کند و ممکن است برای برخی اسکریپت‌ها نگاشت نداشته باشد.

## **دسترسی و بررسی نگاشت‌های قلم اسکریپت**

از [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) برای دسترسی به تم سطح ارائه استفاده کنید. ویژگی‌های [FontScheme.major](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/major/) و [FontScheme.minor](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/fontscheme/minor/) دو مجموعه [Fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/) را برمی‌گردانند.

با فراخوانی [Fonts.get_script_font_map](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/get_script_font_map/) تمام نگاشت‌های یک مجموعه بازیابی می‌شود. برای یافتن یک سیستم نوشتاری خاص، [Fonts.get_script_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/get_script_font/) را با برچسب اسکریپت مربوطه صدا بزنید. `get_script_font` وقتی که مجموعه درخواست‌شده آن نگاشت را تعریف نکرده باشد، `None` برمی‌گرداند.

## **تغییر نگاشت‌ها و تأیید پایداری**

از [Fonts.set_script_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/set_script_font/) برای ایجاد یا جایگزین کردن خانواده قلم فعلی استفاده کنید. از [Fonts.remove_script_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/remove_script_font/) برای حذف یک نگاشت بهره ببرید.

مثال انتها به انتها زیر همه نگاشت‌های اصلی و فرعی موجود را می‌خواند، قلم اصلی ژاپنی را جست‌وجو می‌کند، قلم اصلی سیریلیک را تغییر می‌دهد، نگاشت ثانا برای مجموعه فرعی را حذف می‌کند، ارائه را ذخیره و سپس باز می‌کند تا هر دو تغییر را تأیید کند. برای مستقل کردن گام حذف از تم اولیه، مثال فقط در صورتی که نگاشت ثانا قبلاً تعریف نشده باشد، آن را ایجاد می‌کند.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

تأییداز همان رفتار `None` مانند یک جست‌وجوی معمولی استفاده می‌کند: پس از ذخیره حذف، `get_script_font("Thaa")` برای مجموعه فرعی `None` برمی‌گرداند.

## **تمایز نگاشت‌های تم از سایر تنظیمات قلم**

نگاشت‌های تم مخصوص اسکریپت در انتخاب قلم مشارکت دارند، اما مشکلی متفاوت نسبت به قالب‌بندی مستقیم متن، جایگزینی و فالو بک حل می‌کنند:

| مکانیزم | هدف | اثر تغییر نگاشت تم |
|---|---|---|
| نگاشت تم مخصوص اسکریپت | انتخاب قلم اصلی یا فرعی تم برای یک سیستم نوشتاری. | متنی که هنوز از قلم تم مربوطه استفاده می‌کند می‌تواند به خانواده قلم جدید تبدیل شود. |
| قلم اختصاصی به یک بخش متنی | ثابت کردن خانواده قلم مورد درخواست بر روی آن بخش به‌جای اتکا به تم. | ممکن است بخش تغییر نکند چون قالب‌بندی مستقیم آن، انتخاب تم را نادیده می‌گیرد. |
| جایگزینی قلم | وقتی قلم درخواست‌شده در دسترس نیست یا قاعده‌ای برای جایگزینی اعمال می‌شود، قلم دیگری استفاده می‌شود. | پس از درخواست قلم انجام می‌شود؛ نگاشت اسکریپت تم را بازتعریف نمی‌کند. |
| فالو بک قلم | گلیف‌های غایب در قلم انتخاب‌شده را برای بازه‌های یونیکد خاص فراهم می‌کند. | پوشش گلیف‌های گمشده را تکمیل می‌کند؛ نگاشت تم ذخیره‌شده را تغییر نمی‌دهد. |

برای اطلاعات بیشتر درباره دو مکانیزم آخر، به [Font Substitution](/slides/fa/python-net/font-substitution/) و [Fallback Fonts](/slides/fa/python-net/fallback-font/) مراجعه کنید.

تغییر یک نگاشت در [Presentation.master_theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/master_theme/) فقط بر محتوایی که قالب‌بندی مؤثر آن هنوز به آن تم وابسته است، تأثیر می‌گذارد. متن می‌تواند به‌جای آن از یک بازنویسی تم در مستر، لایه یا اسلاید ارث‌بری کند، یا از قلم اختصاصی استفاده نماید. وقتی نتیجهٔ نمایشی با نگاشت سطح ارائه تطابق ندارد، سطوح دیگر را بررسی کنید.

## **در دسترس قرار دادن فونت‌های نگاشته‌شده و اعتبارسنجی نتایج**

یک نگاشت اسکریپت فقط نام خانواده قلم را ذخیره می‌کند؛ قلم مربوطه را نصب یا بارگذاری نمی‌کند. برای رندر یکنواخت و خروجی، هر قلم نگاشته‌شده باید در محیط نصب شده باشد یا از طریق منبع سفارشی مانند [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/load_external_fonts/) یا [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/document_level_font_sources/) به Aspose.Slides ارائه شود. گزینه‌های بارگذاری موجود در [Custom Fonts](/slides/fa/python-net/custom-font/) را ببینید.

تأیید نگاشت ذخیره‌شده فقط نشان می‌دهد تعریف تم حفظ شده است. این تأیید نمی‌کند که قلم در دسترس است، تمام گلیف‌های لازم را دارد یا چینش موردنظر را تولید می‌کند. برای هر سیستم نوشتاری موردنیاز متن نمایشی را به‌صورت تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این کار قلم‌های مفقود، پوشش ناقص گلیف، رفتار فالو بک و تغییرات چینش را پیش از توزیع ارائه شناسایی می‌کند. برای مثال‌های رندر و خروجی به [Convert PowerPoint Presentations](/slides/fa/python-net/convert-powerpoint/) مراجعه کنید.

## **سوالات متداول**

**`get_script_font` وقتی اسکریپت نگاشت نشده باشد، چه مقدار بازمی‌گرداند؟**

[Fonts.get_script_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/get_script_font/) وقتی نگاشت اسکریپت درخواست‌شده در آن مجموعه اصلی یا فرعی تعریف نشده باشد، `None` بازمی‌گرداند.

**آیا `set_script_font` وقتی اسکریپت موجود است، نگاشت دوم ایجاد می‌کند؟**

نه. [Fonts.set_script_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fonts/set_script_font/) وقتی نگاشت غیرفعال باشد آن را ایجاد می‌کند و وقتی همان برچسب اسکریپت قبلاً حضور دارد، خانواده قلم نگاشت‌شده را جایگزین می‌کند.

**چرا تغییر نگاشت تم برخی متن‌ها را تحت تأثیر قرار نداد؟**

متن ممکن است قلمی به‌صورت صریح اختصاص یافته داشته باشد، از تم متفاوتی به‌وسیلهٔ بازنویسی ارث‌بری کند، یا در هنگام رندر تحت تأثیر جایگزینی یا فالو بک باشد. نگاشت اسکریپت در سطح ارائه فقط متنی را کنترل می‌کند که قالب‌بندی مؤثر آن هنوز به آن مجموعه قلم تم ارجاع می‌دهد.

**آیا ذخیره و بازکردن کافی است تا خروجی چندزبانه را اعتبارسنجی کنیم؟**

نه. باز کردن مجدد فقط پایداری داده‌های تم را تأیید می‌کند. همچنین باید متن نمایشی هر سیستم نوشتاری موردنیاز را رندر کنید تا بفرمایید قلم‌های نگاشت‌شده در دسترس هستند و گلیف‌های لازم را شامل می‌شوند.