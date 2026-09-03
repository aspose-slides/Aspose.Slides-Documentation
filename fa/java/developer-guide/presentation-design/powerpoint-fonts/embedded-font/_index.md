---
title: "جاسازی فونت‌ها در ارائه‌ها با جاوا"
linktitle: "فونت‌های جاسازی‌شده"
type: docs
weight: 40
url: /fa/java/embedded-font/
keywords:
- "افزودن فونت"
- "جاسازی فونت"
- "جاسازی فونت"
- "دریافت فونت جاسازی‌شده"
- "افزودن فونت جاسازی‌شده"
- "حذف فونت جاسازی‌شده"
- "فشرده‌سازی فونت جاسازی‌شده"
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "فونت‌های جاسازی‌شده در PowerPoint را با Aspose.Slides برای Java مدیریت کنید. فونت‌ها را اضافه، بازیابی، حذف و فشرده‌سازی کنید تا ظاهر متن حفظ شود و حجم فایل کاهش یابد."
---
## **معرفی**

درج فونت‌ها داده‌های فونت را داخل یک ارائه PowerPoint ذخیره می‌کند. وقتی یک نمایشگر از فونت‌های درج‌شده پشتیبانی می‌کند، می‌تواند متن را با استفاده از آن فونت‌ها نمایش دهد حتی اگر بر روی سیستم هدف نصب نشده باشند. این به حفظ شکست خطوط، فاصله‌بندی متن و چیدمان اسلاید کمک می‌کند.

Aspose.Slides for Java به شما امکان می‌دهد فونت‌های درج‌شده را از طریق رابط [IFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/) که توسط [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getFontsManager--) برگردانده می‌شود، بازیابی، اضافه و حذف کنید. همچنین می‌توانید حجم داده‌های فونت‌های درج‌شده را با حذف کاراکترهایی که ارائه از آن‌ها استفاده نمی‌کند، کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. قبل از درج یک فونت، اطمینان حاصل کنید که داده‌های فونت برای Aspose.Slides در دسترس است و مجوز آن اجازه درج را می‌دهد.

## **دریافت و حذف فونت‌های درج‌شده**

از [getEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) برای فهرست کردن فونت‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یک فونت، یک فونت از آن فهرست را به [removeEmbeddedFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) پاس بدهید، سپس ارائه را ذخیره کنید.

مثال زیر فونت‌های درج‌شده در `EmbeddedFonts.pptx` را فهرست می‌کند و اگر Calibri موجود باشد آن را حذف می‌کند:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

حذف یک فونت درج‌شده داده‌های ذخیره‌شده آن فونت را حذف می‌کند؛ این تغییری در فونت اختصاص داده شده به متن ایجاد نمی‌کند. اگر فونت بر روی سیستم هدف نصب شده باشد، متن همچنان می‌تواند از آن استفاده کند. در غیر این صورت، نمایش ممکن است به [جایگزینی فونت](/slides/fa/java/font-substitution/) نیاز داشته باشد که می‌تواند بر چیدمان تأثیر بگذارد.

## **بررسی داده‌های فونت و مجوزهای درج**

از رابط [IFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/) برای بررسی فونت‌ها قبل از درج آن‌ها استفاده کنید. با فراخوانی [IFontsManager.getFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getFonts--) فونت‌های استفاده‌شده در ارائه را بازیابی کنید. برای هر فونت، یک شیء [IFontData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontstyletype/) را به [IFontsManager.getFontBytes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) پاس بدهید. این متد داده‌های باینری آن سبک فونت را برمی‌گرداند یا `null` زمانی که فونت یا سبک درخواست‌شده در دسترس نباشد. نتایج `null` را به [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) پاس ندهید، چون این متد یک آرایه بایت می‌خواهد.

[EmbeddingLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/embeddinglevel/) یک شمارش پرچم‌ها است که محدودیت‌های درج ذخیره‌شده در فونت را گزارش می‌دهد:
- `Installable` اجازه درج و نصب دائمی بر روی سیستم دیگر را می‌دهد، مشروط بر مجوز فونت.
- `Restricted` درج را ممنوع می‌کند مگر اینکه اجازه از مالک قانونی فونت دریافت شود زمانی که تنها پرچم مجوز استفاده باشد.
- `PreviewPrint` اجازه استفاده موقت برای مشاهده و چاپ را می‌دهد؛ سندی که شامل فونت باشد باید فقط‑خواندنی باشد.
- `Editable` اجازه استفاده موقت را می‌دهد و اجازه می‌دهد سند ویرایش و ذخیره شود.
- `NoSubsetting` یک محدودیت اضافه است که جلوگیری از درج فقط زیرمجموعه‌ای از گلیف‌ها می‌کند. زمانی که این پرچم موجود باشد، تمام کاراکترها درج شوند.
- `BitmapOnly` یک محدودیت اضافه است که فقط ضربه‌های بیتی (bitmap) را برای درج مجاز می‌داند، نه داده‌های طرح کلی. اگر فونت ضربه بیتی نداشته باشد، نمی‌تواند درج شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آن‌ها ترکیب شوند. اصلاح‌کننده‌ها را با عملگرهای بیتی بررسی کنید. چون `Installable` برابر صفر است، بیت‌های مجوز استفاده را ماسک کنید و نتایج را با `Installable` مقایسه کنید بجای اینکه آن را به عنوان یک پرچم چک کنید. فونت‌های جاری باید حداکثر یک بیت مجوز استفاده تنظیم کنند. برای سازگاری با فونت‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، ابزار کمکی زیر کم‌ترین محدودیت مجوز را انتخاب می‌کند: `Editable`، سپس `PreviewPrint`، سپس `Restricted`.

مثال زیر داده‌های معمولی، بولد، ایتالیک و بولد‑ایتالیک موجود برای هر فونتی که توسط `getFonts` بازگردانده می‌شود را بررسی می‌کند. سبک‌های در دسترس نیست، فونت‌های محدود، فونت‌های فقط‑bitmap، فونت‌هایی که به پیش‌نمایش و چاپ محدود شده‌اند (چون خروجی ویرایش‌پذیر می‌ماند) و فونت‌های که قبلاً درج شده‌اند را نادیده می‌گیرد. اگر هر سبک در دسترس `NoSubsetting` داشته باشد، تمام کاراکترهای آن خانواده فونت را درج می‌کند.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این بررسی محدودیت‌های کدگذاری‌شده در هر فایل فونت را گزارش می‌دهد. این کار مجوزی نمی‌دهد، ثابت نمی‌کند که فونت را به طور قانونی به دست آورده‌اید، و جایگزین بررسی توافق‌نامه لایسنس فونت قبل از توزیع یک نسخهٔ درج‌شده نمی‌شود.

## **اضافه کردن فونت‌های درج‌شده**

از [addEmbeddedFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) برای درج یک فونت استفاده کنید. نسخه‌های بارگذاری‌شده آن یا یک شیء [IFontData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontdata/) یا یک آرایه بایت حاوی داده‌های فونت را می‌پذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/fa/java/com.aspose.slides/embedfontcharacters/) تعیین می‌کند که کدام کاراکترها شامل شوند:
- [All](https://reference.aspose.com/slides/fa/java/com.aspose.slides/embedfontcharacters/) تمام کاراکترهای فونت را درج می‌کند. از این گزینه زمانی استفاده کنید که گیرندگان نیاز به ویرایش ارائه و وارد کردن متن جدید داشته باشند.
- [OnlyUsed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/embedfontcharacters/) فقط کاراکترهای استفاده‌شده در ارائه را درج می‌کند تا حجم فایل کاهش یابد. این گزینه را برای ارائهٔ نهایی که عمدتاً برای مشاهده است انتخاب کنید.

مثال زیر از [getFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getFonts--) برای بازیابی فونت‌های استفاده‌شده در `Fonts.pptx` استفاده می‌کند و آن‌هایی را که هنوز درج نشده‌اند درج می‌کند. فونت‌های برای اضافه شدن باید بر روی ماشینی که کد را اجرا می‌کند در دسترس باشند. فونت‌های درج‌شدهٔ موجود مجموعه کاراکترهای فعلی خود را حفظ می‌کنند.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **فشرده‌سازی فونت‌های درج‌شده**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) داده‌های فونت درج‌شده را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این متد بر روی فونت‌هایی که قبلاً درج شده‌اند عمل می‌کند، بنابراین میزان کاهش اندازه بستگی به مقدار داده‌های فونت استفاده‌نشده در ارائه دارد.

مثال زیر فونت‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به عنوان یک فایل جداگانه ذخیره می‌کند:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر ممکن است گیرندگان بعداً نیاز به افزودن متن داشته باشند فایل اصلی را نگه دارید. کاراکترهای حذف‌شده در حین فشرده‌سازی دیگر از فونت درج‌شده در دسترس نیستند، حتی اگر در ابتدا تمام کاراکترها را درج کرده باشید.

## **پرسش‌های متداول**

**چگونه می‌توانم بررسی کنم که آیا یک فونت درج‌شده هنگام رندر هنوز جایگزین می‌شود؟**

در محیطی که ارائه را رندر می‌کنید، [getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) را فراخوانی کنید تا ببینید Aspose.Slides چه فونت‌هایی را جایگزین می‌کند. همچنین تنظیمات [جایگزینی فونت](/slides/fa/java/font-substitution/) و قوانین [پشتیبان‌گذاری فونت](/slides/fa/java/fallback-font/) را بررسی کنید. پشتیبان‌گذاری کاراکترهای مفقود را مدیریت می‌کند، بنابراین درج یک فونت کاراکتری که خود فونت ندارد را حل نمی‌کند.

**آیا باید فونت‌های رایج مانند Arial و Calibri را درج کنم؟**

تصمیم را بر اساس محیط هدف بگیرید. اگر فونت‌های مورد نیاز بر روی هر دستگاهی که ارائه را باز یا رندر می‌کند موجود باشد، درج آن‌ها ممکن است حجم فایل را به طور غیرضروری افزایش دهد. اگر گیرندگان یا سرورها ممکن است این فونت‌ها را نداشته باشند، درج آن‌ها می‌تواند به حفظ ظاهر موردنظر کمک کند، به شرطی که مجوزهای آن‌ها اجازه دهد.