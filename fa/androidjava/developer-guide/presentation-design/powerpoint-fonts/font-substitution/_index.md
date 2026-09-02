---
title: "پیکربندی جایگزینی قلم در ارائه‌ها روی Android"
linktitle: "جایگزینی قلم"
type: docs
weight: 70
url: /fa/androidjava/font-substitution/
keywords:
- "قلم"
- "قلم جایگزین"
- "جایگزینی قلم"
- "جایگزینی قلم"
- "جایگزینی قلم"
- "قانون جایگزینی"
- "قانون جایگزینی"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "پیکربندی قوانین جایگزینی قلم و بررسی قلم‌های جایگزین شده در Aspose.Slides برای Android از طریق Java هنگام رندر یا تبدیل ارائه‌ها."
---
## **بررسی کلی**

جایگزینی قلم به Aspose.Slides امکان استفاده از یک قلم موجود به جای قلم‌ئی را می‌دهد که هنگام رندر یا تبدیل یک ارائه قابل دسترسی نیست. این جایگزینی بر خروجی رندر شده تأثیر می‌گذارد؛ اما قلم اختصاص داده‌شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید قلمی را که در صورت عدم دسترسی به قلم خاصی استفاده شود، تعریف کنید و جایگزینی‌هایی که Aspose.Slides در حین رندر انجام می‌دهد را بررسی کنید. این کار به حفظ یکدستی خروجی در دستگاه‌های Android و محیط‌های دارای قلم‌های متفاوت کمک می‌کند.

## **دریافت جایگزینی‌های قلم**

از متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) برای تعیین قلم‌هایی که هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این متد اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کنند.

مثال زیر در Java تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

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

با استفاده از بارگذاری [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) که آرگومان `int[] slides` می‌پذیرد، فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این کار زمانی مفید است که بخواهید بخشی از یک ارائه را رندر یا خروجی بگیرید، یک ارائه بزرگ را به‌صورت افزایشی بررسی کنید، اسلایدهایی که به قلم‌های در دسترس نیستند را پیدا کنید، بسته قلمی حداقلی برای یک برنامه Android تهیه کنید یا تفاوت‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل اندیس‌های اسلاید به‌صورت یک‌پایه است: `1` اولین اسلاید را شناسا می‌کند. در مقابل، دسترسی‌گر مجموعه‌ی [Presentation.getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) از اندیس‌های صفرپایه استفاده می‌کند، بنابراین همان اسلاید با `presentation.getSlides().get_Item(0)` دسترسی‌پذیر است. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطای یک‑واحدی جلوگیری کنید.

این بارگذاری را از طریق متد [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getFontsManager--) صدا بزنید. این متد فقط جایگزینی‌های تعیین‌شده در حین رندر اسلایدهای انتخابی را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsubstitutioninfo/) است که شامل نام‌های قلم اصلی و جایگزین می‌باشد. نتیجه بازتاب‌دهنده‌ی محیط قلمی فعلی، قوانین بازگشت پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsubstrulecollection/) و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/androidjava/custom-font/) است.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخابی نیاز باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش پیش‌پرواز، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس یک فهرست مرتب از نگاشت‌های قلمی یکتا ایجاد می‌کند:

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

رابط [IFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/) هر دو بارگذاری را فراهم می‌کند. بسته به دامنهٔ عملیات رندر، یکی را انتخاب کنید:

| بارگذاری | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون آرگومان | نیاز به جایگزینی برای کل ارائه دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با `int[] slides` | نیاز به جایگزینی برای محدوده‌ای انتخاب‌شده، بررسی افزایشی یا خروجی جزئی دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید هنگام عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsubstcondition/) بسازید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) تعیین کنید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر در Java، در صورتی که `SomeRareFont` در دسترس نباشد، `Arial` را به‌جای آن استفاده می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را بررسی کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

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

{{% alert color="info" title="نکته" %}}

برای تغییر بدون شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به [جایگزینی قلم](/slides/fa/androidjava/font-replacement/) مراجعه کنید.

{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم جزئی از فرآیند استاندارد انتخاب قلم در حین رندر و تبدیل هستند. آن‌ها برای متن معمولی کار می‌کنند وقتی Aspose.Slides می‌تواند قلم غیرقابل دسترس را با قلم موجود تعریف‌شده در قانون جایگزین کند.

معادلات Office Math نیاز اضافه‌ای دارند. اگر یک معادله از **Cambria Math** استفاده کند، Aspose.Slides ممکن است به همان قلم دقیق برای محاسبه و رندر چیدمان معادله نیاز داشته باشد. قانون جایگزینی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور جایگزین کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** مورد نیاز است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را به‌صورت یک [قلم خارجی](/slides/fa/androidjava/custom-font/) بارگذاری کنید تا برنامه بتواند در حین رندر و تبدیل از آن استفاده کند.

این محدودیت فقط در مورد چیدمان معادله اعمال می‌شود. قوانین جایگزینی ذکرشده در بالا همچنان برای متن عادی ارائه اعمال می‌گردند.

## **سؤالات متداول**

**تفاوت جایگزینی قلم و جایگزینی کامل قلم چیست؟**

[جایگزینی قلم](/slides/fa/androidjava/font-replacement/) به‌صورت عمدی یک قلم را در سراسر ارائه با قلم دیگری عوض می‌کند. جایگزینی قلم، قلمی برای خروجی رندر شده انتخاب می‌کند هنگامی که شرط پیکربندی‌شده برآورده شود، مانند زمانی که قلم اصلی در دسترس نباشد.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنبالهٔ انتخاب قلم](/slides/fa/androidjava/font-selection-sequence/) طی رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، قانون تنها وقتی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و قانون جایگزینی تنظیم نشده باشد، چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه بستگی به قلم‌های موجود در محیط زمان اجرا دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری](/slides/fa/androidjava/custom-font/) کنید تا Aspose.Slides بتواند در حین رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول فراهم‌آوری قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی می‌تواند بین دستگاه‌های Android متفاوت باشد؟**

بله. قلم‌های سیستم موجود می‌توانند بین نسخه‌های Android، دستگاه‌ها و تولیدکنندگان متفاوت باشند، به‌طوری که قلمی که در یک محیط موجود است ممکن است در محیط دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را بین دستگاه‌های Android یکسان نگه دارم؟**

قلم‌های مورد نیاز را همراه برنامه بسته‌بندی کنید، آن‌ها را به‌صورت [قلم خارجی بارگذاری](/slides/fa/androidjava/custom-font/) کنید و هنگام مجوز، [قلم‌ها را تعبیه](/slides/fa/androidjava/embedded-font/) کنید. همچنین می‌توانید قبل از خروجی‌گیری از [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) استفاده کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.