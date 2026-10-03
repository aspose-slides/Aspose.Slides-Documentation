---
title: پیکربندی جایگزینی فونت در ارائه‌ها با استفاده از جاوا
linktitle: جایگزینی فونت
type: docs
weight: 70
url: /fa/java/font-substitution/
keywords:
- فونت
- فونت جایگزین
- جایگزینی فونت
- تعویض فونت
- جایگزینی فونت
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "قواعد جایگزینی فونت را پیکربندی کنید و فونت‌های جایگزین شده در Aspose.Slides برای Java را هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **مروری کلی**

جایگزینی فونت به Aspose.Slides اجازه می‌دهد که به جای فونتی که هنگام رندر یا تبدیل ارائه قابل دسترسی نیست، از یک فونت موجود استفاده کند. این جایگزینی بر خروجی رندر تأثیر می‌گذارد؛ ولی فونت اختصاص داده شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید فونتی که در صورت عدم دسترسی به یک فونت خاص استفاده شود را تعریف کنید و جایگزین‌هایی که Aspose.Slides هنگام رندر انجام می‌دهد را بررسی کنید. این کار به حفظ خروجی یکسان در محیط‌های مختلف با فونت‌های نصب‌شده متفاوت کمک می‌کند.

## **دریافت جایگزینی فونت‌ها**

از متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) برای تعیین اینکه کدام فونت‌ها هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این متد اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام فونت اصلی و فونت جایگزین را مشخص می‌کند.

مثال زیر به زبان Java تمام جایگزینی‌های فونت برای یک ارائه را فهرست می‌کند:

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

## **دریافت جایگزینی فونت‌ها برای اسلایدهای انتخابی**

با استفاده از overload متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) که آرگومان `int[] slides` می‌گیرد، می‌توانید تنها جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این کار زمانی مفید است که بخواهید بخشی از ارائه را رندر یا خروجی بگیرید، یک ارائه بزرگ را به‌صورت افزایشی بررسی کنید، اسلایدهایی که به فونت‌های غیرقابل دسترس وابسته‌اند پیدا کنید، یک بستهٔ فونت حداقلی برای سرور یا کانتینر آماده کنید یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل اندیس‌های اسلاید به‌صورت یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، متد دسترسی به مجموعهٔ [Presentation.getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) از اندیس‌گذاری صفرپایه استفاده می‌کند، بنابراین همان اسلاید به صورت `presentation.getSlides().get_Item(0)` دسترسی پیدا می‌کند. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطای یک‑اندیس دوری کنید.

دستگاه overload را از طریق متد [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getFontsManager--) فراخوانی کنید. این متد فقط جایگزینی‌های تعیین‌شده هنگام رندر اسلایدهای انتخابی را برمی‌گرداند. هر نتیجه یک شیٔ [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstitutioninfo/) است که نام فونت اصلی و فونت جایگزین را شامل می‌شود. نتیجه منعکس‌کنندهٔ محیط فونت جاری، قوانین پشتیبان پیکربندی‌شده و [فونت‌های بارگذاری شده خارجی](/slides/fa/java/custom-font/) است. قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsubstrulecollection/) هنگام رندر ارائه اعمال می‌شوند، اما نتیجه آن‌ها را فهرست نمی‌کند؛ به‌جای آن فونت‌های موجود در فایل خروجی را بررسی کنید.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخابی مورد نیاز باشد. هنگام ایجاد موجودی فونت یا گزارش پیش‌پرواز، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس لیستی مرتب‌شده از نگاشت‌های فونت منحصربه‌فرد ایجاد می‌کند:

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

رابط [IFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/) هر دو overload را ارائه می‌دهد. بسته به دامنهٔ عملیات رندر، یکی را انتخاب کنید:

| بارگذاری | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون آرگومان | زمانی که به جایگزینی برای کل ارائه نیاز دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با `int[] slides` | زمانی که به جایگزینی برای یک بازهٔ انتخابی، بررسی افزایشی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی فونت**

برای مشخص کردن فونتی که Aspose.Slides باید هنگام عدم دسترسی به فونت منبع از آن استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های فونت برای فونت منبع و فونت جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstcondition/) ایجاد کنید.
4. این قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) تعیین کنید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به زبان Java، هنگام عدم دسترسی به `SomeRareFont`، `Arial` را جایگزین می‌کند و سپس اسلاید اول را رندر می‌کند تا نتیجه را تأیید کند. فونت جایگزین باید برای Aspose.Slides در دسترس باشد.

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
برای تغییر بدون شرط فونت‌های استفاده‌شده در تمام ارائه، به [جایگزینی فونت](/slides/fa/java/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای فونت‌های معادلات ریاضی**

قوانین جایگزینی فونت بخشی از فرآیند استاندارد انتخاب فونت هستند که در هنگام رندر و تبدیل استفاده می‌شود. آن‌ها برای متن عادی کار می‌کنند وقتی Aspose.Slides می‌تواند فونت غیرقابل دسترسی را با فونت موجود تعیین‌شده توسط قانون جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر یک معادله از **Cambria Math** استفاده کند، Aspose.Slides ممکن است برای محاسبه و رندر چیدمان معادله به دقیقاً همان فونت نیاز داشته باشد. قانونی که یک فونت ریاضی دیگر مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را در این مورد جایگزین کند و رندر ممکن است هنوز گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم عامل نصب کنید یا به‌عنوان یک [فونت خارجی](/slides/fa/java/custom-font/) بارگذاری کنید.

این محدودیت فقط در چیدمان معادله اعمال می‌شود. قوانین جایگزینی توضیح داده شده در بالا همچنان برای متن عادی ارائه معتبر هستند.

## **سوالات متداول**

**تفاوت جایگزینی فونت با تعویض فونت چیست؟**

[جایگزینی فونت](/slides/fa/java/font-replacement/) عمداً یک فونت را در سراسر ارائه به فونت دیگری تغییر می‌دهد. جایگزینی فونت یک فونت برای خروجی رندر انتخاب می‌کند وقتی شرط پیکربندی‌شده برقرار باشد، مانند عدم دسترسی به فونت اصلی.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنبالهٔ انتخاب فونت](/slides/fa/java/font-selection-sequence/) هنگام رندر و تبدیل مشارکت می‌کنند. با `WhenInaccessible`، یک قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به فونت منبع دسترسی پیدا کند.

**اگر فونتی موجود نباشد و قانونی برای جایگزینی تنظیم نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین فونت موجود را بر اساس فرآیند انتخاب فونت خود انتخاب می‌کند. نتیجه به فونت‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم فونت‌های خارجی بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [فونت‌های خارجی را بارگذاری](/slides/fa/java/custom-font/) کنید تا Aspose.Slides در طول رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose فونت‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. فراهم کردن فونت‌ها و رعایت مجوزهای آن‌ها بر عهدهٔ شماست.

**آیا نتایج جایگزینی بین Windows، Linux و macOS متفاوت است؟**

بله. فونت‌های نصب‌شده و مکان‌های جستجوی فونت در سیستم عامل‌های مختلف متفاوت است، بنابراین فونتی که در یک ماشین موجود است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب فونت را در تبدیل‌های دسته‌ای یک‌پارچه کنم؟**

از همان فایل‌ها و نسخه‌های فونت در هر ماشین یا کانتینر استفاده کنید، [فونت‌های خارجی مورد نیاز را بارگذاری](/slides/fa/java/custom-font/) کنید و هنگام مجوز اجازه می‌دهد [فونت‌ها را جاسازی](/slides/fa/java/embedded-font/) کنید. همچنین می‌توانید پیش از خروجی گرفتن از [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) استفاده کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.