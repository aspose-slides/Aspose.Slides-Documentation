---
title: پیکربندی جایگزینی قلم در ارائه‌ها با استفاده از Java
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/java/font-substitution/
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
- Java
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین شده را در Aspose.Slides برای Java هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **بررسی کلی**

جایگزینی قلم به Aspose.Slides امکان می‌دهد تا در صورت عدم دسترسی به یک قلم هنگام رندر یا تبدیل ارائه، از یک قلم موجود استفاده کند. این جایگزینی فقط بر خروجی رندر شده اثر می‌گذارد؛ قلم اختصاص داده شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید قلم مورد استفاده را زمانی که یک قلم خاص در دسترس نیست تعریف کنید و جایگزینی‌هایی که Aspose.Slides در طول رندر انجام می‌دهد را بررسی کنید. این کار به حفظ سازگاری خروجی در محیط‌هایی با قلم‌های نصب‌شده متفاوت کمک می‌کند.

## **دریافت جایگزینی قلم‌ها**

از متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) برای تعیین اینکه کدام قلم‌ها هنگام رندر ارائه جایگزین می‌شوند استفاده کنید. این متد اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام قلم اصلی و قلم جایگزین را شناسایی می‌کند.

مثال جاوا زیر تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

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

## **دریافت جایگزینی قلم‌ها برای اسلایدهای منتخب**

از overload متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با آرگومان `int[] slides` استفاده کنید تا فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این کار زمانی مفید است که بخواهید بخشی از ارائه را رندر یا صادر کنید، یک ارائه بزرگ را به‌صورت تدریجی بررسی کنید، اسلایدهایی که به قلم‌های ناموجود وابسته‌اند پیدا کنید، یک بسته قلم حداقلی برای سرور یا کانتینر آماده کنید، یا تفاوت‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل اندیس‌های اسلاید به‌صورت یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، accessor مجموعه [Presentation.getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) از ایندکس صفرپایه استفاده می‌کند، بنابراین همان اسلاید با `presentation.getSlides().get_Item(0)` دسترسی‌پذیر است. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطای یک‑جای‌گیری جلوگیری کنید.

این overload را از طریق متد [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getFontsManager--) فراخوانی کنید. این متد فقط جایگزینی‌هایی را برمی‌گرداند که در حین رندر اسلایدهای منتخب تعیین شده‌اند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstitutioninfo/) است که نام قلم اصلی و قلم جایگزین را شامل می‌شود. نتیجه بازتاب‌دهندهٔ محیط قلم فعلی، قوانین fallback پیکربندی‌شده، قواعد جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsubstrulecollection/) و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/java/custom-font/) است.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید منتخب مورد نیاز باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش پیش‌پرواز، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس یک فهرست مرتب‌شده از نگاشت‌های قلم منحصر به فرد ایجاد می‌کند:

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

رابط [IFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/) هر دو overload را فراهم می‌کند. یکی را برحسب دامنهٔ عملیات رندر انتخاب کنید:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون آرگومان | نیاز به جایگزینی برای کل ارائه دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با `int[] slides` | نیاز به جایگزینی برای بازهٔ منتخب، بررسی تدریجی یا خروجی جزئی دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای تعیین قلمی که Aspose.Slides باید وقتی قلم منبع در دسترس نیست استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstcondition/) بسازید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) تنظیم کنید.
6. ارائه را رندر یا تبدیل کنید.

مثال جاوا زیر `Arial` را به‌جای `SomeRareFont` زمانی که `SomeRareFont` در دسترس نیست، جایگزین می‌کند و سپس اولین اسلاید را رندر می‌زند تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

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
برای تغییر بدون شرط قلم‌های استفاده‌شده در سراسر ارائه، به [جایگزینی قلم](/slides/fa/java/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم بخشی از فرآیند استاندارد انتخاب قلم هستند که در حین رندر و تبدیل استفاده می‌شوند. این قوانین برای متن عادی کاربرد دارند، زمانی که Aspose.Slides می‌تواند قلم ناموجود را با قلم موجود تعریف‌شده توسط قانون جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر یک معادله از **Cambria Math** استفاده کند، ممکن است Aspose.Slides برای محاسبه و رندر قالب‌بندی معادله به همان قلم دقیقاً نیاز داشته باشد. قانونی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را در این منظور جایگزین کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین پیشنهادی، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/java/custom-font/) بارگذاری کنید.

این محدودیت فقط برای قالب‌بندی معادله اعمال می‌شود. قوانین جایگزینی توضیح داده‌شده در بالا همچنان برای متن عادی ارائه معتبر است.

## **سوالات متداول**

**تفاوت جایگزینی قلم و جایگزینی فونت چیست؟**

[جایگزینی قلم](/slides/fa/java/font-replacement/) به‌صورت عمدی یک قلم را با قلم دیگر در سراسر ارائه تغییر می‌دهد. جایگزینی قلم یک قلم را برای خروجی رندر شده وقتی شرط پیکربندی‌شده برآورده شود، مانند عدم دسترسی به قلم اصلی، انتخاب می‌کند.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در [دنبالهٔ انتخاب قلم](/slides/fa/java/font-selection-sequence/) در طول رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، قانون تنها زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و هیچ قانون جایگزینی پیکربندی نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری](/slides/fa/java/custom-font/) کنید تا Aspose.Slides در طول رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول فراهم‌آوری قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی بین Windows، Linux و macOS می‌توانند متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم‌ها بسته به سیستم‌عامل متفاوت است، بنابراین قلمی که در یک ماشین موجود است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای یکدست نگه دارم؟**

از همان فایل‌ها و نسخه‌های قلم بر روی هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری](/slides/fa/java/custom-font/) کنید و هنگام امکان [قلم‌ها را درون‌ساز](/slides/fa/java/embedded-font/) کنید. همچنین می‌توانید قبل از صادرات با [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) فراخوانی کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.