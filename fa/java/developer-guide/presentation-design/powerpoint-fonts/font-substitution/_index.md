---
title: پیکربندی جایگزینی قلم در ارائه‌ها با استفاده از جاوا
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/java/font-substitution/
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
- Java
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین‌شده را در Aspose.Slides برای جاوا هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **نمای کلی**

جایگزینی قلم به Aspose.Slides اجازه می‌دهد تا در هنگام رندر یا تبدیل ارائه، از یک قلم موجود به جای قلم غیرقابل دسترسی استفاده کند. این جایگزینی بر خروجی رندر شده تأثیر می‌گذارد؛ اما قلم اختصاص داده شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید قلمی را که در صورت عدم دسترسی به یک قلم خاص استفاده شود، تعریف کنید و جایگزینی‌هایی که Aspose.Slides در حین رندر انجام می‌دهد را بررسی کنید. این کار به حفظ سازگاری خروجی در محیط‌های مختلف با قلم‌های نصب شده متفاوت کمک می‌کند.

اگر قلمی موجود است اما وزن **Bold** جداگانه‌ای ندارد، به بخش [رویارویی با قلم‌هایی که وزن برجسته جداگانه ندارند](/slides/fa/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) مراجعه کنید. آن بخش توضیح می‌دهد چگونه متن تحت‌تأثیر را در هنگام خروجی PDF رسترایز کرده و پیامدهای انتخاب متن، جستجو و مقیاس‌گذاری را بررسی می‌کند.

## **دریافت جایگزینی‌های قلم**

از روش [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) برای تعیین قلم‌هایی که هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این روش اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام قلم اصلی و قلم جایگزین را شناسایی می‌کنند.

مثال زیر به زبان جاوا تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخابی**

از overload متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با آرگومان `int[] slides` استفاده کنید تا فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این روش زمانی مفید است که بخواهید بخشی از یک ارائه را رندر یا خروجی بگیرید، ارائه بزرگ را به‌صورت افزایشی بررسی کنید، اسلایدهایی که به قلم‌های غیرقابل دسترسی وابسته‌اند را پیدا کنید، بسته قلمی حداقلی برای سرور یا کانتینر آماده کنید، یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل شاخص‌های اسلاید به‌صورت یک‑مبنا است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، accessor مجموعه [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) از شاخص صفر‑مبنا استفاده می‌کند، بنابراین همان اسلاید با `presentation.getSlides().get_Item(0)` دسترسی‌پذیر است. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطای یک‑واحد دوری کنید.

این overload را از طریق متد [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) فراخوانی کنید. این متد فقط جایگزینی‌های تعیین‌شده هنگام رندر اسلایدهای انتخابی را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) است که نام قلم اصلی و قلم جایگزین را شامل می‌شود. نتیجه محیط قلم فعلی، قوانین fallback پیکربندی‌شده و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/java/custom-font/) را منعکس می‌کند. قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) هنگام رندر ارائه اعمال می‌شوند، اما نتیجه آن‌ها را فهرست نمی‌کند؛ به جایش قلم‌های موجود در فایل خروجی را بررسی کنید.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخابی مورد نیاز باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش preflight، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی برگشتی را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلم منحصربه‌فرد ایجاد می‌کند:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

رابط [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) هر دو overload را فراهم می‌کند. بسته به دامنه عملیات رندر، یکی را انتخاب کنید:

| Overload | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون آرگومان | زمانی که به جایگزینی‌ها برای کل ارائه نیاز دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با `int[] slides` | زمانی که به جایگزینی‌ها برای بازه‌ای انتخابی، بررسی افزایشی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید وقتی قلم منبع در دسترس نیست، استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعاریف قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) تعیین کنید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به زبان جاوا، هنگام عدم دسترسی به `SomeRareFont`، `Arial` را به‌جای آن جایگزین می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
برای تغییر بی‌قید و شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به بخش [جایگزینی قلم](/slides/fa/java/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم جزئی از فرآیند استاندارد انتخاب قلم هستند که هنگام رندر و تبدیل استفاده می‌شوند. آن‌ها برای متن عادی کار می‌کنند زمانی که Aspose.Slides بتواند قلم غیرقابل دسترسی را با قلم موجود مشخص‌شده توسط قانون جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر معادله‌ای از **Cambria Math** استفاده کند، Aspose.Slides ممکن است به دقیقاً همان قلم برای محاسبه و رندر طرح معادله نیاز داشته باشد. قانونی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین کند، نمی‌تواند **Cambria Math** را در این منظور جایگزین کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** ضروری است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/java/custom-font/) بارگذاری کنید.

این محدودیت به طرح معادله مربوط می‌شود. قوانین جایگزینی توضیح داده‌شده در بالا همچنان برای متن عادی ارائه اعمال می‌شوند.

## **پرسش‌های متداول**

**تفاوت جایگزینی قلم با جایگزینی قلم (Font Replacement) چیست؟**

[جایگزینی قلم](/slides/fa/java/font-replacement/) به‌صورت عمدی یک قلم را با قلم دیگر در تمام ارائه تغییر می‌دهد. جایگزینی قلم قلمی را برای خروجی رندر شده زمانی که شرط پیکربندی‌شده برآورده شود (مثلاً قلم اصلی در دسترس نیست) انتخاب می‌کند.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنباله انتخاب قلم](/slides/fa/java/font-selection-sequence/) هنگام رندر و تبدیل مشارکت دارند. با شرط `WhenInaccessible`، قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و قانون جایگزینی تنظیم نشده باشد، چه اتفاقی می‌افتد؟**

Aspose.Slides نزدیک‌ترین قلم موجود را براساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا وابسته است.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری](/slides/fa/java/custom-font/) کنید تا Aspose.Slides در حین رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول تأمین قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی بین ویندوز، لینوکس و macOS می‌تواند متفاوت باشد؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم در هر سیستم‌عامل متفاوت است، بنابراین قلمی که در یک ماشین در دسترس است ممکن است در ماشین دیگری نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای یک‌دست نگه دارم؟**

از همان فایل‌های قلم و نسخه‌ها در هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی موردنیاز را بارگذاری](/slides/fa/java/custom-font/) کنید و در صورت اجازه‌دار بودن، [قلم‌ها را جاسازی](/slides/fa/java/embedded-font/) کنید. همچنین می‌توانید قبل از خروجی‌گیری از متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) استفاده کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.