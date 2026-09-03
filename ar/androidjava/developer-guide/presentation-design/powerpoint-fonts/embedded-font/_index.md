---
title: تضمين الخطوط في العروض التقديمية على Android
linktitle: الخطوط المدمجة
type: docs
weight: 40
url: /ar/androidjava/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- احصل على الخط المدمج
- إضافة خط مدمج
- إزالة خط مدمج
- ضغط خط مدمج
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة الخطوط المدمجة في PowerPoint باستخدام Aspose.Slides للـ Android عبر Java. إضافة، استرجاع، إزالة وضغط الخطوط للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **مقدمة**

يُخزّن تضمين الخطوط بيانات الخط داخل عرض PowerPoint. عندما يدعم عارض الخطوط المدمجة، يمكنه عرض النص باستخدام تلك الخطوط حتى لو لم تكن مثبتة على النظام المستهدف. يساعد ذلك في الحفاظ على فواصل الأسطر وتباعد النص وتنسيق الشريحة.

تتيح لك Aspose.Slides for Android عبر Java استرجاع الخطوط المدمجة وإضافتها وإزالتها من خلال واجهة [IFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/) التي تُرجعها الدالة [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getFontsManager--). يمكنك أيضًا تقليل حجم بيانات الخط المدمج بإزالة الأحرف التي لا يستخدمها العرض.

تعمل الأمثلة أدناه مع ملفات PPTX. قبل تضمين خط، تأكد من توفر بيانات الخط لـ Aspose.Slides وأن الترخيص يسمح بالتضمين.

## **الحصول على الخطوط المدمجة وإزالتها**

استخدم الدالة [getEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) لسرد الخطوط المخزنة في العرض. لإزالة أحدها، مرّر خطًا من تلك القائمة إلى الدالة [removeEmbeddedFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)، ثم احفظ العرض.

المثال التالي يسرد الخطوط المدمجة في الملف `EmbeddedFonts.pptx` ويزيل Calibri إذا كان موجودًا:

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

إزالة خط مدمج تحذف بيانات الخط المخزنة؛ لا تُغيّر الخط المعين للنص. إذا كان الخط مثبتًا على النظام المستهدف، سيظل النص يستخدمه. وإلا قد يتطلب العرض [font substitution](/slides/ar/androidjava/font-substitution/)، مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وإذن التضمين**

استخدم واجهة [IFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ الدالة [IFontsManager.getFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) لاسترجاع الخطوط المستخدمة في العرض. لكل خط، مرّر كائنًا من نوع [IFontData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontdata/) والقيمة المطلوبة من [FontStyleType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontstyletype/) إلى الدالة [IFontsManager.getFontBytes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). تُعيد الطريقة البيانات الثنائية لذلك نمط الخط، أو `null` عندما يكون الخط أو النمط غير متاح. لا تُمرّر نتيجة `null` إلى الدالة [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-)، لأن هذه الطريقة تتطلب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/embeddinglevel/) هو تعداد علمي يُظهر قيود التضمين المخزنة في الخط:

- `Installable` يسمح بالتضمين والتثبيت الدائم على نظام آخر، وفقًا لترخيص الخط.
- `Restricted` يمنع التضمين ما لم يُحصل على إذن من مالك الخط القانوني عندما يكون هذا العلم هو علم الإذن الوحيد للاستخدام.
- `PreviewPrint` يسمح بالاستعمال المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي على الخط للقراءة فقط.
- `Editable` يسمح بالاستعمال المؤقت ويسمح بتحرير المستند وحفظه.
- `NoSubsetting` هو قيود إضافية تمنع تضمين جزء فقط من الحروف. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BitmapOnly` هو قيود إضافية تسمح فقط بتضمين صيغ البت‌ماب، وليس بيانات المخطط. إذا لم يحتوي الخط على صيغ بت‌ماب، لا يمكن تضمينه.

القيم الأربعة الأولى تصف إذن الاستخدام، بينما يمكن دمج `NoSubsetting` و`BitmapOnly` معها. تحقق من المعدّلات باستخدام عمليات bitwise. نظرًا لأن `Installable` يساوي صفرًا، قم بتمييز بتات إذن الاستخدام وقارن النتيجة بـ `Installable` بدلاً من التحقق منها كعلم. يجب أن تحدد الخطوط الحالية علم إذن استخدام واحد على الأكثر. لتوافقية مع الخطوط القديمة التي قد تحدد أكثر من علم، يُختار المساعد أدناه أقل إذن تقييدًا: `Editable`، ثم `PreviewPrint`، ثم `Restricted`.

المثال التالي يُجرّب البيانات العادية، العريضة، المائلة، والعريضة‑المائلة المتوفرة لكل خط تُعيده الدالة `getFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط التي تدعم فقط البت‌ماب، الخطوط المحدودة للمعاينة والطباعة لأن الناتج يبقى قابلاً للتحرير، والخطوط التي تم تضمينها بالفعل. إذا كان أي نمط متاح يحتوي على `NoSubsetting`، يتم تضمين جميع الأحرف لتلك العائلة الخطية.

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

هذا الفحص يُظهر القيود المرمّزة في كل ملف خط. لا يمنح ترخيصًا، ولا يثبت أنك حصلت على الخط بصورة قانونية، ولا يُستبدل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مدمجة.

## **إضافة خطوط مدمجة**

استخدم الدالة [addEmbeddedFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) لتضمين خط. تُقبل عمليات التحميل إما ككائن من نوع [IFontData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontdata/) أو مصفوفة بايت تحتوي على بيانات الخط. يتحكم تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/embedfontcharacters/) في الأحرف المضمّنة:

- [All](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/embedfontcharacters/) يُضمِّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المستلمون إلى تحرير العرض وإدخال نص جديد.
- [OnlyUsed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/embedfontcharacters/) يُضمِّن الأحرف المستخدمة فقط في العرض لتقليل حجم الملف. اختر هذا الخيار لعرض نهائي يُقصد به العرض الأساسي فقط.

المثال التالي يستخدم الدالة [getFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) لاسترجاع الخطوط المستخدمة في الملف `Fonts.pptx` ويضمِّن تلك التي لم تُضمّن بعد. يجب أن تكون الخطوط التي ستُضاف متوفرة على جهاز Android أو مُسجَّلة مع Aspose.Slides. الخطوط المدمجة الموجودة تحتفظ بمجموعة الأحرف الحالية.

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

## **ضغط الخطوط المدمجة**

تُقلل الدالة [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) من بيانات الخط المدمج بإزالة الأحرف غير المستخدمة. تعمل على الخطوط التي تم تضمينها بالفعل، لذا يعتمد تقليل الحجم على كمية البيانات غير المستخدمة الموجودة في العرض.

المثال التالي يضغط الخطوط في الملف `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:

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

احتفظ بالملف الأصلي إذا كان المستلمون قد يحتاجون لإضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لا تُصبح متاحة بعد ذلك من الخط المدمج، حتى لو كنت قد ضمّنت جميع الأحرف أصلاً.

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كان سيُستبدل خط مدمج أثناء العرض؟**

استدعِ الدالة [getSubstitutions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) في البيئة التي تُظهر فيها العرض لمعرفة الخطوط التي سيستبدلها Aspose.Slides. كما يجب فحص إعدادات [font substitution](/slides/ar/androidjava/font-substitution/) وقواعد [font fallback](/slides/ar/androidjava/fallback-font/). يُعالج fallback الأحرف المفقودة، لذا لا يحل تضمين الخط مشكلة الأحرف التي لا يحتويها الخط نفسه.

**هل يجب عليّ تضمين خطوط شائعة مثل Arial و Calibri؟**

اعتمد القرار على البيئة المستهدفة. إذا كانت الخطوط المطلوبة متوفرة على كل جهاز يفتح أو يعرض العرض، قد يزيد التضمين من حجم الملف دون فائدة. إذا كان من المحتمل أن يفتقر المستلمون أو الخوادم إلى تلك الخطوط، فإن تضمينها قد يساعد على الحفاظ على المظهر المقصود، شريطة أن تسمح تراخيصها بذلك.