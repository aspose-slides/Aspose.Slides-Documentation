---
title: دمج الخطوط في العروض التقديمية في .NET
linktitle: الخطوط المدمجة
type: docs
weight: 40
url: /ar/net/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على خط مدمج
- إضافة خط مدمج
- إزالة خط مدمج
- ضغط خط مدمج
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة الخطوط المدمجة في PowerPoint باستخدام Aspose.Slides لـ .NET. استخدم C# لإضافة، استرجاع، إزالة، وضغط الخطوط للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **المقدمة**

يخزن تضمين الخطوط بيانات الخط داخل عرض بوربوينت. عندما يدعم المشاهد الخطوط المضمَّنة، يمكنه عرض النص باستخدام تلك الخطوط حتى وإن لم تكن مثبتة على النظام المستهدف. يساعد ذلك في الحفاظ على فواصل الأسطر، وتباعد النص، وتنسيق الشريحة.

يتيح لك Aspose.Slides for .NET استرجاع، إضافة، وإزالة الخطوط المضمَّنة عبر الخاصية [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) لكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). يمكنك أيضًا تقليل حجم بيانات الخط المضمَّن بإزالة الأحرف التي لا يستخدمها العرض.

تعمل الأمثلة أدناه مع ملفات PPTX. قبل تضمين أي خط، تأكد من توافر بيانات الخط لـ Aspose.Slides وأن ترخيصه يسمح بالتضمين.

## **جلب وإزالة الخطوط المضمَّنة**

استخدم [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) لسرد الخطوط المخزَّنة في العرض. لإزالة أحدها، مرِّر خطًا من تلك القائمة إلى [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/)، ثم احفظ العرض.

يُدرج المثال التالي الخطوط المضمَّنة في `EmbeddedFonts.pptx` ويزيل خط Calibri إذا كان موجودًا:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

إزالة خط مضمَّن تحذف بيانات الخط المخزَّنة؛ لا تغير الخط المعيّن للنص. إذا كان الخط مثبتًا على النظام المستهدف، سيظل النص يستخدمه. وإلا، قد يتطلب العرض [font substitution](/slides/ar/net/font-substitution/)، مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وأذونات الإدراج**

استخدم الواجهة [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) لاسترجاع الخطوط المستخدمة في العرض. لكل خط، مرِّر كائنًا من نوع [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) والقيمة المطلوبة من [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) إلى [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). تُعيد الطريقة البيانات الثنائية لذلك نمط من الخط، أو `null` عندما يكون الخط أو النمط غير متاح. لا تُمرِّر نتيجة `null` إلى [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/)، لأن تلك الطريقة تتطلّب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) هو تعداد Flag يُظهر قيود الإدراج المخزَّنة في الخط:

- `Installable` يسمح بالإدراج والتثبيت الدائم على نظام آخر، وفقًا لترخيص الخط.
- `Restricted` يمنع الإدراج ما لم تُحصل على إذن من صاحب الحقوق القانونية للخط عندما يكون هذا هو علم الاستخدام الوحيد.
- `PreviewPrint` يسمح بالاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي الخط للقراءة فقط.
- `Editable` يسمح بالاستخدام المؤقت ويتيح تحرير المستند وحفظه.
- `NoSubsetting` هو قيد إضافي يمنع إدراج جزء فقط من الحروف. يُضمَّن جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BitmapOnly` هو قيد إضافي يسمح بتضمين ضربات البِت ماب فقط، وليس بيانات المخطط. إذا لم يحتوي الخط على ضربات بِت ماب، لا يمكن إدراجه.

القيم الأربعة الأولى تصف إذن الاستخدام، بينما يمكن دمج `NoSubsetting` و`BitmapOnly` معهما. تحقّق من المُعدِّلات باستخدام عمليات bitwise. نظرًا لأن `Installable` يساوي الصفر، لا تستخدم `HasFlag` لاكتشافه؛ قم بقناع بتات إذن الاستخدام وقارن النتيجة مع `Installable`. يجب أن تُعيّن الخطوط الحالية بحد أقصى علم إذن واحد. للتوافق مع الخطوط القديمة التي تعيّن أكثر من علم، يختار المساعد أدناه الأقل تقييدًا: `Editable` ثم `PreviewPrint` ثم `Restricted`.

يُجري المثال التالي تدقيقًا للبيانات العادية، السميكة، المائلة، والسميكة-المائلة المتوفرة لكل خط تُرجعهم الدالة `GetFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط التي هي BitmapOnly، الخطوط المحدودة للمعاينة والطباعة لأن الناتج يظل قابلًا للتحرير، والخطوط المُضمَّنة بالفعل. إذا كان لأي نمط متوفر `NoSubsetting`، يُضمَّن جميع الأحرف لتلك العائلة الخطية.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

هذا الفحص يُبلغ عن القيود المُرمَّزة في كل ملف خط. لا يمنح ترخيصًا، ولا يثبت أنك حصلت على الخط بصورة قانونية، ولا يُستبدل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مضمَّنة.

## **إضافة خطوط مضمَّنة**

استخدم [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) لتضمين خط. تُقبل التحميلات إما ككائن [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) أو مصفوفة بايت تحتوي على بيانات الخط. يحدد تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) الأحرف التي تُضمَّن:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) يُضمَّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المستلمون إلى تعديل العرض وإدخال نص جديد.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) يُضمَّن فقط الأحرف المستخدمة في العرض لتقليل حجم الملف. اختر هذا الخيار للعرض النهائي الذي يهدف أساسًا إلى العرض فقط.

يستخدم المثال التالي [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) لاسترجاع الخطوط المستخدمة في `Fonts.pptx` ويضمِّن تلك التي لم تُضمَّن بعد. يجب أن تكون الخطوط المُضافة متوفرة على الجهاز الذي يُشغَّل الكود. تحتفظ الخطوط المضمَّنة الموجودة بمجموعة الأحرف الحالية.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **ضغط الخطوط المضمَّنة**

يُقلِّل [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) بيانات الخط المضمَّن بإزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها بالفعل، لذا يعتمد تقليل الحجم على كمية بيانات الخط غير المستخدمة في العرض.

يُضغط المثال التالي الخطوط في `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

احتفظ بالملف الأصلي إذا كان المستلمون قد يحتاجون لإضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لا تعود متوفرة من الخط المضمَّن، حتى وإن كنت قد ضَمَّنت جميع الأحرف أصلاً.

لإعطاء أولوية للخط المسجل المتطابق أثناء التصدير دون إزالة الخط المضمَّن، راجع [Prefer Registered Fonts over Embedded Fonts](/slides/ar/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 أو أحدث).

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كان سيتم استبدال الخط المضمَّن أثناء العرض؟**

استدعِ [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) في البيئة التي تُظهر فيها العرض لتعرف أي خطوط سيستبدلها Aspose.Slides. كما يجب مراجعة إعدادات [font substitution](/slides/ar/net/font-substitution/) وقواعد [font fallback](/slides/ar/net/fallback-font/). يتعامل fallback مع الأحرف الناقصة، لذا لا يحل تضمين الخط مشكلة الأحرف التي لا يحتويها الخط نفسه.

**هل ينبغي عليّ تضمين خطوط شائعة مثل Arial وCalibri؟**

اتّخذ القرار بناءً على بيئة الهدف. إذا كانت الخطوط المطلوبة متوفرة على كل جهاز يفتح أو يعرض العرض، قد يزيد التضمين من حجم الملف دون فائدة. إذا كان من المحتمل أن يفتقر المستلمون أو الخوادم إلى تلك الخطوط، يمكن للتضمين أن يساعد في الحفاظ على المظهر المقصود، بشرط أن تسمح تراخيصها بذلك.