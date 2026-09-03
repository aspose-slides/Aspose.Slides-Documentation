---
title: "جاسازی فونت‌ها در ارائه‌ها بر روی اندروید"
linktitle: "فونت‌های جاسازی‌شده"
type: docs
weight: 40
url: /fa/androidjava/embedded-font/
keywords:
- "افزودن فونت"
- "جاسازی فونت"
- "جاسازی فونت"
- "دریافت فونت جاسازی‌شده"
- "افزودن فونت جاسازی‌شده"
- "حذف فونت جاسازی‌شده"
- "فشرده‌سازی فونت جاسازی‌شده"
- "PowerPoint"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "فونت‌های جاسازی‌شده در PowerPoint را با Aspose.Slides برای Android از طریق Java مدیریت کنید. افزودن، بازیابی، حذف و فشرده‌سازی فونت‌ها برای حفظ ظاهر متن و کاهش حجم فایل."
---
## **مقدمه**

فونت‌های تعبیه‌شده داده‌های فونت را داخل یک ارائه PowerPoint ذخیره می‌کنند. وقتی یک نمایشگر از فونت‌های تعبیه‌شده پشتیبانی کند، می‌تواند متن را با آن فونت‌ها نمایش دهد حتی اگر بر روی سیستم هدف نصب نشده باشند. این کار به حفظ شکست خطوط، فاصله‌بندی متن و چیدمان اسلاید کمک می‌کند.

Aspose.Slides for Android via Java به شما امکان بازیابی، افزودن و حذف فونت‌های تعبیه‌شده را از طریق رابط [IFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/) که توسط [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getFontsManager--) برگردانده می‌شود، می‌دهد. همچنین می‌توانید با حذف کاراکترهایی که ارائه از آن‌ها استفاده نمی‌کند، حجم داده‌های فونت تعبیه‌شده را کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. پیش از تعبیه یک فونت، اطمینان حاصل کنید که داده‌های فونت برای Aspose.Slides در دسترس باشد و مجوز آن اجازه تعبیه را بدهد.

## **دریافت و حذف فونت‌های تعبیه‌شده**

از [getEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) برای فهرست کردن فونت‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یکی، یک فونت از آن فهرست را به [removeEmbeddedFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) بدهید، سپس ارائه را ذخیره کنید.

مثال زیر فونت‌های تعبیه‌شده در `EmbeddedFonts.pptx` را فهرست می‌کند و اگر Calibri موجود باشد، آن را حذف می‌کند:

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

حذف یک فونت تعبیه‌شده داده‌های ذخیره‌شده آن فونت را از بین می‌برد؛ فونت اختصاص‌یافته به متن تغییر نمی‌کند. اگر فونت بر روی سیستم هدف نصب شده باشد، متن همچنان می‌تواند از آن استفاده کند. در غیر این صورت، رندر ممکن است نیاز به [font substitution](/slides/fa/androidjava/font-substitution/) داشته باشد که می‌تواند بر چیدمان تأثیر بگذارد.

## **بررسی داده‌های فونت و مجوزهای تعبیه**

از رابط [IFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/) برای بررسی فونت‌ها قبل از تعبیه استفاده کنید. با فراخوانی [IFontsManager.getFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) فونت‌های مورد استفاده در ارائه را بازیابی کنید. برای هر فونت، یک شیء [IFontData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontdata/) و مقدار [FontStyleType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontstyletype/) مورد نیاز را به [IFontsManager.getFontBytes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) بدهید. این متد داده‌های باینی آن سبک فونت را برمی‌گرداند یا `null` می‌شود وقتی فونت یا سبک درخواست‌شده در دسترس نباشد. نتیجهٔ `null` را به [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) پاس ندهید، زیرا این متد به آرایهٔ بایتی نیاز دارد.

[EmbeddingLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/embeddinglevel/) یک شمارش پرچم‌دار است که محدودیت‌های تعبیه ذخیره‌شده در فونت را گزارش می‌دهد:

- `Installable` اجازه تعبیه و نصب دائم بر روی سیستم دیگر را می‌دهد، مشروط بر مجوز فونت.
- `Restricted` تعبیه را ممنوع می‌کند مگر این‌که از مالک قانونی فونت اجازه گرفته شود وقتی این تک پرچم مجوز استفاده باشد.
- `PreviewPrint` استفاده موقت برای مشاهده و چاپ را مجاز می‌کند؛ سند حاوی فونت باید فقط‑خواندنی باشد.
- `Editable` استفاده موقت را مجاز می‌کند و اجازه ویرایش و ذخیره سند را می‌دهد.
- `NoSubsetting` محدودیت اضافی است که فقط تعبیهٔ زیرمجموعه‌ای از گلیف‌ها را ممنوع می‌کند. وقتی این پرچم موجود باشد باید همهٔ کاراکترها تعبیه شوند.
- `BitmapOnly` محدودیت دیگری است که فقط ضربه‌های بیت‌مپ را برای تعبیه اجازه می‌دهد، نه دادهٔ خطی. اگر فونت ضربهٔ بیت‌مپ نداشته باشد، نمی‌تواند تعبیه شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آن‌ها ترکیب شوند. با عملیات بیتی این اصلاح‌کننده‌ها را بررسی کنید. چون `Installable` برابر صفر است، بیت‌های مجوز استفاده را ماسک کنید و نتیجه را با `Installable` مقایسه کنید نه اینکه آن را به عنوان یک پرچم بررسی کنید. فونت‌های فعلی باید حداکثر یک بیت مجوز استفاده داشته باشند. برای سازگاری با فونت‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، کمکی که در ادامه می‌آید کم‌ترین محدودیت را انتخاب می‌کند: ابتدا `Editable`، سپس `PreviewPrint`، و در نهایت `Restricted`.

مثال زیر داده‌های معمولی، ضخیم، ایتالیک و ضخیم‑ایتالیک موجود برای هر فونت برگردانده شده توسط `getFonts` را بررسی می‌کند. استایل‌های ناموجود، فونت‌های محدود، فونت‌های فقط‑بیت‌مپ، فونت‌های محدود به پیش‌نمایش و چاپ (چون خروجی ویرایش‌پذیر باقی می‌ماند) و فونت‌هایی که از قبل تعبیه شده‌اند را نادیده می‌گیرد. اگر هر استایل موجود دارای `NoSubsetting` باشد، تمام کاراکترهای آن خانوادهٔ فونت تعبیه می‌شود.

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

این بررسی محدودیت‌های رمزگذاری‌شده در هر فایل فونت را گزارش می‌دهد. این کار مجوزی نمی‌دهد، ثابت نمی‌کند که فونت را به‌صورت قانونی به‌دست آورده‌اید و جایگزین بررسی توافق‌نامهٔ مجوز فونت پیش از توزیع یک نسخهٔ تعبیه‌شده نمی‌شود.

## **افزودن فونت‌های تعبیه‌شده**

از [addEmbeddedFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) برای تعبیه یک فونت استفاده کنید. بارگذاری‌های متفاوت آن یا یک شیء [IFontData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontdata/) یا یک آرایهٔ بایتی حاوی داده‌های فونت را می‌پذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/embedfontcharacters/) تعیین می‌کند که چه کاراکتری گنجانده شود:

- [All](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/embedfontcharacters/) تمام کاراکترهای فونت را تعبیه می‌کند. وقتی دریافت‌کنندگان نیاز به ویرایش ارائه و وارد کردن متن جدید دارند از این گزینه استفاده کنید.
- [OnlyUsed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/embedfontcharacters/) فقط کاراکترهایی که در ارائه استفاده شده‌اند را تعبیه می‌کند تا حجم فایل کاهش یابد. برای یک ارائهٔ نهایی که عمدتاً برای مشاهده است این گزینه را انتخاب کنید.

مثال زیر از [getFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) برای بازیابی فونت‌های استفاده‌شده در `Fonts.pptx` استفاده می‌کند و آن‌هایی را که هنوز تعبیه نشده‌اند، اضافه می‌کند. فونت‌های مورد افزودن باید بر روی دستگاه Android موجود یا در Aspose.Slides ثبت شده باشند. فونت‌های تعبیه‌شدهٔ موجود مجموعهٔ کاراکتری فعلی خود را حفظ می‌کنند.

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

## **فشرده‌سازی فونت‌های تعبیه‌شده**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) داده‌های فونت تعبیه‌شده را با حذف کاراکترهای استفاده‑نشده کاهش می‌دهد. این متد بر فونت‌هایی که قبلاً تعبیه شده‌اند عمل می‌کند، بنابراین میزان کاهش اندازه به میزان دادهٔ فونت استفاده‑نشدهٔ موجود در ارائه بستگی دارد.

مثال زیر فونت‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به‌عنوان یک فایل جداگانه ذخیره می‌سازد:

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

اگر دریافت‌کنندگان ممکن است بعداً نیاز به افزودن متن داشته باشند، فایل اصلی را نگه دارید. کاراکترهای حذف‌شده در طول فشرده‌سازی دیگر از فونت تعبیه‌شده در دسترس نیستند، حتی اگر در ابتدا همهٔ کاراکترها تعبیه شده باشند.

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک فونت تعبیه‌شده در طول رندر هنوز جایگزین می‌شود یا خیر؟**

در محیطی که ارائه را رندر می‌کنید، [getSubstitutions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) را فراخوانی کنید تا ببینید Aspose.Slides کدام فونت‌ها را جایگزین خواهد کرد. همچنین تنظیمات [font substitution](/slides/fa/androidjava/font-substitution/) و قوانین [font fallback](/slides/fa/androidjava/fallback-font/) را بررسی کنید. Fallback کاراکترهای گم‌شده را مدیریت می‌کند، بنابراین تعبیه یک فونت کاراکترهایی که خود فونت شامل آن‌ها نیست حل نمی‌کند.

**آیا باید فونت‌های عمومی مانند Arial و Calibri را تعبیه کنم؟**

تصمیم را بر اساس محیط هدف بگیرید. اگر فونت‌های مورد نیاز بر روی هر دستگاهی که ارائه را باز یا رندر می‌کند موجود باشند، تعبیه آن‌ها ممکن است حجم فایل را بی‌دلیل افزایش دهد. اگر دریافت‌کنندگان یا سرورها ممکن است این فونت‌ها را نداشته باشند، تعبیه آن‌ها می‌تواند به حفظ ظاهر دلخواه کمک کند، به شرطی که مجوزهای آن‌ها این کار را اجازه دهد.