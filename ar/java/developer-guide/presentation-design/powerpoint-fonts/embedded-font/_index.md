---
title: "تضمين الخطوط في العروض التقديمية باستخدام Java"
linktitle: "الخطوط المضمنة"
type: docs
weight: 40
url: /ar/java/embedded-font/
keywords:
- "إضافة خط"
- "تضمين خط"
- "تضمين الخطوط"
- "الحصول على الخط المضمن"
- "إضافة خط مضمّن"
- "إزالة الخط المضمن"
- "ضغط الخط المضمن"
- "PowerPoint"
- "عرض تقديمي"
- "Java"
- "Aspose.Slides"
description: "إدارة الخطوط المضمنة في PowerPoint باستخدام Aspose.Slides للغة Java. إضافة، استرجاع، إزالة، وضغط الخطوط للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **مقدمة**

تضمين الخطوط يخزن بيانات الخط داخل عرض PowerPoint. عندما يدعم المشاهد الخطوط المضمنة، يمكنه عرض النص باستخدام تلك الخطوط حتى وإن لم تكن مثبتة على النظام الهدف. يساعد ذلك في الحفاظ على فواصل الأسطر، ومسافات النص، وتخطيط الشريحة.

تتيح لك Aspose.Slides for Java استرجاع الخطوط المضمنة وإضافتها وإزالتها عبر واجهة [IFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/) التي تُرجعها الدالة [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getFontsManager--). يمكنك أيضًا تقليل حجم بيانات الخط المضمن عن طريق إزالة الأحرف التي لا يستخدمها العرض.

الأمثلة أدناه تعمل مع ملفات PPTX. قبل تضمين خط، تأكد من أن بيانات الخط متاحة لـ Aspose.Slides وأن رخصته تسمح بالتضمين.

## **الحصول على وإزالة الخطوط المضمنة**

استخدم [getEmbeddedFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) لقائمة الخطوط المخزنة في عرض تقديمي. لإزالة أحدها، مرّر خطًا من تلك القائمة إلى [removeEmbeddedFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)، ثم احفظ العرض.

المثال التالي يدرج الخطوط المضمنة في `EmbeddedFonts.pptx` ويزيل خط Calibri إذا كان موجودًا:

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

إزالة خط مضمّن تحذف بيانات الخط المخزنة؛ لكنها لا تغير الخط المعين للنص. إذا كان الخط مثبتًا على النظام الهدف، يمكن للنص الاستمرار في استخدامه. وإلا، قد يتطلب العرض [font substitution](/slides/ar/java/font-substitution/) مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وإذن التضمين**

استخدم واجهة [IFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ [IFontsManager.getFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getFonts--) لاسترجاع الخطوط المستخدمة في العرض. لكل خط، مرّر كائن [IFontData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontdata/) والقيمة المطلوبة من [FontStyleType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontstyletype/) إلى [IFontsManager.getFontBytes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). تُرجع الطريقة البيانات الثنائية لذلك نمط الخط، أو `null` عندما يكون الخط أو النمط المطلوب غير متوفر. لا تمرّر نتيجة `null` إلى [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-)، لأن هذه الطريقة تتطلب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/embeddinglevel/) هو تعداد للعلامات يُبلغ عن قيود التضمين المخزنة في الخط:

- `Installable` يسمح بالتضمين والتثبيت الدائم على نظام آخر، وفقًا لترخيص الخط.
- `Restricted` يمنع التضمين إلا إذا تم الحصول على إذن من مالك الخط القانوني عندما يكون هذا هو علم الإذن الوحيد للاستخدام.
- `PreviewPrint` يسمح بالاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي على الخط للقراءة فقط.
- `Editable` يسمح بالاستخدام المؤقت ويسمح بتحرير المستند وحفظه.
- `NoSubsetting` هو قييد إضافي يمنع تضمين جزء من الرموز فقط. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BitmapOnly` هو قييد إضافي يسمح بتضمين ضربات البت ماب فقط، وليس بيانات المخطط. إذا لم يحتوي الخط على ضربات بت ماب، لا يمكن تضمينه.

القيم الأربعة الأولى تصف إذن الاستخدام، بينما يمكن دمج `NoSubsetting` و `BitmapOnly` معهما. تحقق من المعدلات باستخدام عمليات البت. بما أن `Installable` يساوي صفرًا، قم بتمييز بتات إذن الاستخدام وقارن النتيجة بـ `Installable` بدلاً من فحصه كعلم. يجب أن تحدد الخطوط الحالية بت واحدة على الأكثر لإذن الاستخدام. للتوافق مع الخطوط القديمة التي تحدد أكثر من واحدة، يختار المساعد أدناه أقل إذن تقييد: `Editable`، ثم `PreviewPrint`، ثم `Restricted`.

المثال التالي يراجع البيانات العادية، السُمكة، المائلة، والسُمكة المائلة المتوفرة لكل خط يُرجَع بواسطة `getFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط ذات البت ماب فقط، الخطوط المحدودة للمعاينة والطباعة لأن الناتج يظل قابلاً للتعديل، والخطوط التي تم تضمينها بالفعل. إذا كان لأي نمط متاح `NoSubsetting`, فإنه يضمّن جميع الأحرف لتلك العائلة من الخطوط.

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

هذا الفحص يُبلغ عن القيود المرمّزة في كل ملف خط. لا يمنح رخصة، ولا يثبت أنك حصلت على الخط بصورة قانونية، ولا يحل محل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مضمّنة.

## **إضافة خطوط مضمّنة**

استخدم [addEmbeddedFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) لتضمين خط. تحمّل النسخ المتعددة إما كائن [IFontData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontdata/) أو مصفوفة بايت تحتوي على بيانات الخط. يحدد تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/java/com.aspose.slides/embedfontcharacters/) الأحرف التي سيتم تضمينها:

- [All](https://reference.aspose.com/slides/ar/java/com.aspose.slides/embedfontcharacters/) يضمّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المستلمون إلى تحرير العرض وإدخال نص جديد.
- [OnlyUsed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/embedfontcharacters/) يضمّن فقط الأحرف المستخدمة في العرض لتقليل حجم الملف. اختر هذا الخيار لعرض نهائي يهدف أساسًا إلى المشاهدة.

المثال التالي يستخدم [getFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getFonts--) لاسترجاع الخطوط المستخدمة في `Fonts.pptx` ويضمّن تلك غير المضمّنة بالفعل. يجب أن تكون الخطوط المراد إضافتها متاحة على الجهاز الذي يُشغل الكود. الخطوط المضمنة الحالية تحتفظ بمجموعة الأحرف الحالية.

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

## **ضغط الخطوط المضمّنة**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) يقلل بيانات الخط المضمّن بإزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها بالفعل، لذا يعتمد تقليل الحجم على مقدار بيانات الخط غير المستخدمة في العرض.

المثال التالي يضغط الخطوط في `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:

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

احتفظ بالملف الأصلي إذا كان المستلمون قد يحتاجون لإضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لم تعد متاحة من الخط المضمّن، حتى وإن كنت قد ضمت جميع الأحرف في البداية.

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كان سيتم استبدال الخط المضمّن أثناء العرض؟**

استدعِ [getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) في البيئة التي تقوم فيها بعرض العرض لترى الخطوط التي سيستبدلها Aspose.Slides. أيضًا افحص إعدادات [font substitution](/slides/ar/java/font-substitution/) و [font fallback](/slides/ar/java/fallback-font/). يوفر fallback معالجة الأحرف المفقودة، لذا لا يحل تضمين الخط مشكلة الأحرف التي لا يحتويها الخط نفسه.

**هل يجب عليّ تضمين الخطوط الشائعة مثل Arial و Calibri؟**

اتخذ القرار بناءً على البيئة المستهدفة. إذا كانت الخطوط المطلوبة متوفرة على كل جهاز يفتح أو يعرض العرض، فقد يزيد تضمينها حجم الملف بشكل غير ضروري. إذا كان من الممكن أن يفتقر المستلمون أو الخوادم إلى تلك الخطوط، يمكن لتضمينها أن يساعد في الحفاظ على المظهر المقصود، بشرط أن تسمح تراخيصها بذلك.