---
title: پیکربندی جایگزینی فونت در ارائه‌ها بر روی اندروید
linktitle: جایگزینی فونت
type: docs
weight: 70
url: /fa/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "قوانین جایگزینی فونت را پیکربندی کنید و فونت‌های جایگزین‌شده را در Aspose.Slides برای اندروید از طریق Java هنگام رندر یا تبدیل ارائه‌ها بررسی کنید."
---
## **نمای کلی**

جایگزینی فونت به Aspose.Slides امکان می‌دهد تا به جای فونتی که در هنگام رندر یا تبدیل ارائه قابل دسترسی نیست، از یک فونت موجود استفاده کند. این جایگزینی بر خروجی رندر شده تأثیر می‌گذارد؛ اما فونت اختصاص داده‌شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید فونتی را که در صورت عدم دسترسی به یک فونت خاص استفاده شود تعریف کنید و می‌توانید جایگزینی‌هایی را که Aspose.Slides هنگام رندر انجام می‌دهد بررسی کنید. این کار به حفظ ثبات خروجی در بین دستگاه‌های اندروید و محیط‌های دارای فونت‌های مختلف کمک می‌کند.

اگر فونتی در دسترس باشد اما قلم بولد اختصاصی نداشته باشد، به [مدیریت فونت‌ها بدون قلم بولد اختصاصی](/slides/fa/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) مراجعه کنید. آن بخش توضیح می‌دهد چگونه متن تحت تأثیر را در طول خروجی PDF رسترize کنید و پیامدهای انتخاب متن، جستجو و مقیاس‌بندی را بیان می‌کند.

## **دریافت جایگزینی‌های فونت**

از متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) برای تعیین اینکه کدام فونت‌ها هنگام رندر ارائه جایگزین می‌شوند استفاده کنید. این متد اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های فونت اصلی و جایگزین را شناسایی می‌کنند.

مثال زیر در جاوا تمام جایگزینی‌های فونت برای یک ارائه را فهرست می‌کند:

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

## **دریافت جایگزینی‌های فونت برای اسلایدهای انتخاب‌شده**

از overload متد [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با آرگومان `int[] slides` استفاده کنید تا فقط جایگزینی‌های لازم برای رندر اسلایدهای خاص را بررسی کنید. این روش وقتی که بخواهید بخشی از ارائه را رندر یا خروجی بگیرید، ارائه بزرگ را به‌صورت تدریجی بررسی کنید، اسلایدهایی که به فونت‌های در دسترس نیستند را شناسایی کنید، یک بستهٔ فونت حداقلی برای برنامهٔ اندروید آماده کنید یا متفاوتی‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید، مفید است.

آرایه `slides` شامل ایندکس‌های اسلاید مبتنی بر یک است: `1` اولین اسلاید را شناسایی می‌کند. برعکس، دسترسی‌گر مجموعهٔ [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) از ایندکس صفر مبنا استفاده می‌کند، بنابراین همان اسلاید به صورت `presentation.getSlides().get_Item(0)` دسترس‑پذیر است. هنگام ساخت آرایه باید این تفاوت را در نظر بگیرید تا خطای یک‑به‑یک رخ ندهد.

overload را از طریق متد [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) فراخوانی کنید. این متد فقط جایگزینی‌های تعیین‌شده در هنگام رندر اسلایدهای انتخاب‌شده را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) است که نام‌های فونت اصلی و جایگزین را شامل می‌شود. نتیجه محیط فونت فعلی، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) و [فونت‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/androidjava/custom-font/) را منعکس می‌کند.

همین جایگزینی ممکن است توسط بیش از یک اسلاید انتخاب‌شده نیاز باشد. هنگام ایجاد فهرست موجودی فونت یا گزارش پیش‌پروازی، نتایج را تکراری‌زدایی کنید. مثال زیر هر جایگزینی بازگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های یکتا فونت ایجاد می‌نماید:

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

رابط [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) هر دو overload را فراهم می‌کند. بر اساس دامنهٔ عملیات رندر، یکی را انتخاب کنید:

| Overload | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون آرگومان | شما به جایگزینی‌ها برای کل ارائه نیاز دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) با `int[] slides` | شما به جایگزینی‌ها برای یک بازهٔ انتخابی، بررسی تدریجی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی فونت**

برای مشخص کردن فونتی که Aspose.Slides باید هنگام عدم دسترسی به فونت منبع استفاده کند:

1. ارائه را بارگذاری کنید.  
2. تعریف‌های فونت برای فونت منبع و جایگزین ایجاد کنید.  
3. یک [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/) بسازید.  
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/) اضافه کنید.  
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) تنظیم کنید.  
6. ارائه را رندر یا تبدیل کنید.

مثال زیر در جاوا `Arial` را به‌جای `SomeRareFont` زمانی که `SomeRareFont` در دسترس نیست جایگزین می‌کند و سپس اولین اسلاید را برای تأیید نتیجه رندر می‌نماید. فونت جایگزین باید برای Aspose.Slides در دسترس باشد.

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
برای تغییر بدون شرط فونت‌های استفاده‑شده در تمام ارائه، به [جایگزینی فونت](/slides/fa/androidjava/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای فونت‌های معادلات ریاضی**

قوانین جایگزینی فونت جزئی از فرآیند استاندارد انتخاب فونت در طول رندر و تبدیل هستند. آن‌ها برای متن‌های عادی کار می‌کنند وقتی Aspose.Slides می‌تواند یک فونت غیرقابل دسترسی را با فونت موجود تعیین‌شده توسط یک قانون جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر معادله‌ای از **Cambria Math** استفاده کند، Aspose.Slides ممکن است به همان فونت دقیق برای محاسبه و رندر چیدمان معادله نیاز داشته باشد. قانونی که یک فونت ریاضی دیگر مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند برای این منظور **Cambria Math** را برگزیده و رندر ممکن است همچنان گزارش دهد که **Cambria Math** مورد نیاز است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را به‌عنوان یک [فونت خارجی](/slides/fa/androidjava/custom-font/) بارگذاری کنید تا برنامه بتواند در طول رندر و تبدیل از آن استفاده کند.

این محدودیت فقط به چیدمان معادله اعمال می‌شود. قوانین جایگزینی توضیح‌داده‌شده در بالا همچنان برای متن عادی ارائه اعمال می‌شوند.

## **سؤالات متداول**

**تفاوت بین جایگزینی فونت و جایگزینی (substitution) فونت چیست؟**  
[جایگزینی فونت](/slides/fa/androidjava/font-replacement/) به‌صورت عمدی یک فونت را در تمام ارائه با فونت دیگری عوض می‌کند. جایگزینی فونت یک فونت را برای خروجی رندر شده انتخاب می‌کند زمانی که شرط پیکربندی‌شده برآورده شود، مثلاً زمانی که فونت اصلی در دسترس نباشد.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**  
قوانین در [دنبالهٔ انتخاب فونت](/slides/fa/androidjava/font-selection-sequence/) در طول رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به فونت منبع دسترسی پیدا کند.

**زمانی که یک فونت گم شود و هیچ قانون جایگزینی پیکربندی نشده باشد چه می‌شود؟**  
Aspose.Slides نزدیک‌ترین فونت موجود را بر اساس فرآیند انتخاب فونت خود انتخاب می‌کند. نتیجه به فونت‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم فونت‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری شود؟**  
بله. می‌توانید [فونت‌های خارجی را بارگذاری](/slides/fa/androidjava/custom-font/) کنید تا Aspose.Slides بتواند در طول رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose فونت‌ها را همراه کتابخانه توزیع می‌کند؟**  
خیر. شما مسئول تهیه فونت‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی می‌توانند بین دستگاه‌های اندروید متفاوت باشند؟**  
بله. فونت‌های سیستمی موجود می‌توانند بین نسخه‌های اندروید، دستگاه‌ها و تولیدکنندگان متفاوت باشند، بنابراین فونتی که در یک محیط در دسترس است ممکن است در محیط دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب فونت را در بین دستگاه‌های اندروید یکسان نگه دارم؟**  
فونت‌های مورد نیاز یکسان را همراه برنامه بسته‌بندی کنید، [آن‌ها را به‌عنوان فونت خارجی بارگذاری](/slides/fa/androidjava/custom-font/) کنید و وقتی مجوز اجازه می‌دهد [فونت‌ها را تعبیه](/slides/fa/androidjava/embedded-font/) کنید. همچنین می‌توانید قبل از خروجی‌گیری از [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) برای شناسایی جایگزینی‌های غیرمنتظره استفاده کنید.