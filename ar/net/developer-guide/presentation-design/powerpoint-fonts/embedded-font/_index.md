---
title: تضمين الخطوط في العروض التقديمية في .NET
linktitle: خطوط مضمّنة
type: docs
weight: 40
url: /ar/net/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على خط مضمّن
- إضافة خط مضمّن
- إزالة خط مضمّن
- ضغط خط مضمّن
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة الخطوط المضمّنة في PowerPoint باستخدام Aspose.Slides لـ .NET. استخدم C# لإضافة الخطوط واسترجاعها وإزالتها وضغطها للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **المقدمة**

تضمين الخطوط يخزن بيانات الخط داخل عرض تقديمي ببرنامج PowerPoint. عندما يدعم عارض الخطوط المضمّنة، يمكنه عرض النص باستخدام تلك الخطوط حتى وإن لم تكن مثبتة على نظام الوجهة. يساعد ذلك في الحفاظ على فواصل الأسطر وتباعد النص وتخطيط الشريحة.

تتيح لك مكتبة Aspose.Slides لـ .NET استرجاع الخطوط المضمّنة وإضافتها وإزالتها عبر خاصية [FontsManager](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/fontsmanager/) لكائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). يمكنك أيضًا تقليل حجم بيانات الخط المضمّن عن طريق إزالة الأحرف التي لا يستخدمها العرض التقديمي.

الأمثلة أدناه تعمل مع ملفات PPTX. قبل تضمين خط، تأكد من أن بيانات الخط متاحة لـ Aspose.Slides وأن ترخيصه يسمح بالتضمين.

## **الحصول على الخطوط المضمّنة وإزالتها**

استخدم [GetEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getembeddedfonts/) لسرد الخطوط المخزنة في عرض تقديمي. لإزالة واحدة، مرّر خطًا من تلك القائمة إلى [RemoveEmbeddedFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/removeembeddedfont/)، ثم احفظ العرض التقديمي.

المثال التالي يسرد الخطوط المضمّنة في الملف `EmbeddedFonts.pptx` ويزيل خط Calibri إذا كان موجودًا:
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

إزالة خط مضمّن تحذف بيانات الخط المخزنة؛ ولا تغير الخط المعين للنص. إذا كان الخط مثبتًا على نظام الوجهة، يظل بإمكان النص استخدامه. وإلا قد يتطلب العرض [استبدال الخط](/slides/ar/net/font-substitution/)، مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وأذونات التضمين**

استخدم واجهة [IFontsManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ [IFontsManager.GetFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getfonts/) لاسترجاع الخطوط المستخدمة في العرض التقديمي. لكل خط، مرّر كائن [IFontData](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontdata/) والقيمة المطلوبة من [FontStyleType](https://reference.aspose.com/slides/ar/net/aspose.slides/fontstyletype/) إلى [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getfontbytes/). تُعيد الطريقة البيانات الثنائية لذلك النمط من الخط، أو `null` عندما يكون الخط أو النمط المطلوب غير متوفر. لا تمرّر نتيجة `null` إلى [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getfontembeddinglevel/)، لأن هذه الطريقة تتطلب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/ar/net/aspose.slides/embeddinglevel/) هو تعداد علميات يُبلغ عن قيود التضمين المخزنة في الخط:

- `Installable` يسمح بالتضمين والتثبيت الدائم على نظام آخر، وفقًا لترخيص الخط.
- `Restricted` يحظر التضمين ما لم يتم الحصول على إذن من صاحب الخط القانوني عندما يكون هذا هو علم الإذن الوحيد.
- `PreviewPrint` يسمح بالاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي على الخط للقراءة فقط.
- `Editable` يسمح بالاستخدام المؤقت ويسمح بتحرير وحفظ المستند.
- `NoSubsetting` هو قيد إضافي يمنع تضمين جزء فقط من الأحرف. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BitmapOnly` هو قيد إضافي يسمح بتضمين ضربات البت ماب فقط، وليس بيانات المخطط. إذا لم يحتوي الخط على ضربات بت ماب، لا يمكن تضمينه.

القيم الأربعة الأولى تصف أذونات الاستخدام، بينما يمكن الجمع بين `NoSubsetting` و `BitmapOnly` معها. تحقق من المعدّلات باستخدام عمليات بتية. لأن قيمة `Installable` هي صفر، لا تستخدم `HasFlag` لاكتشافها؛ بل قم بتمويه بتات أذونات الاستخدام ومقارنة النتيجة بـ `Installable`. يجب على الخطوط الحالية تعيين بت واحد كحد أقصى لأذونات الاستخدام. للتوافق مع الخطوط القديمة التي تعين أكثر من بت واحد، يختار المساعد أدناه أقل إذن تقييدًا: `Editable`، ثم `PreviewPrint`، ثم `Restricted`.

المثال التالي يراجع بيانات الخط العادي، السميك، المائل، والسميك المائل المتاحة لكل خط يُرجعها `GetFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط التي تدعم البت ماب فقط، الخطوط المحدودة للعرض والطباعة لأن المخرجات تبقى قابلة للتحرير، والخطوط التي تم تضمينها بالفعل. إذا كان لأي نمط متاح علم `NoSubsetting`، فسيتم تضمين جميع الأحرف لتلك العائلة من الخطوط.
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

هذا الفحص يُبلغ عن القيود المشفرة في كل ملف خط. لا يمنحك ترخيصًا، ولا يثبت أنك حصلت على الخط قانونيًا، ولا يحل محل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مضمّنة.

## **إضافة خطوط مضمّنة**

استخدم [AddEmbeddedFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/addembeddedfont/) لتضمين خط. تدعم التحميلات الزائدة إما كائن [IFontData](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontdata/) أو مصفوفة بايت تحتوي على بيانات الخط. تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/net/aspose.slides.export/embedfontcharacters/) يتحكم في الأحرف التي يتم تضمينها:

- [All](https://reference.aspose.com/slides/ar/net/aspose.slides.export/embedfontcharacters/) يضمّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المتلقون إلى تحرير العرض وإدخال نص جديد.
- [OnlyUsed](https://reference.aspose.com/slides/ar/net/aspose.slides.export/embedfontcharacters/) يضمّن فقط الأحرف المستخدمة في العرض لتقليل حجم الملف. اختر هذا الخيار لعرض نهائي موجه أساسًا للعرض.

المثال التالي يستخدم [GetFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getfonts/) لاسترجاع الخطوط المستخدمة في الملف `Fonts.pptx` ويضمّن تلك التي لم تُضمّن بعد. يجب أن تكون الخطوط المطلوب إضافتها متوفرة على الجهاز الذي يشغل الكود. الخطوط المضمّنة الحالية تحتفظ بمجموعة أحرفها الحالية.
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

## **ضغط الخطوط المضمّنة**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/compressembeddedfonts/) يقلل بيانات الخط المضمّن بإزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها مسبقًا، لذا يعتمد تقليل الحجم على كمية بيانات الخط غير المستخدمة في العرض.

المثال التالي يضغط الخطوط في الملف `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

احتفظ بالملف الأصلي إذا كان المتلقون قد يحتاجون لإضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لا تعود متاحة من الخط المضمّن، حتى وإن كنت قد ضمنت جميع الأحرف أصلاً.

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كان الخط المضمّن سيظل يُستبدل أثناء العرض؟**

استدعِ [GetSubstitutions](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getsubstitutions/) في البيئة التي تعرض فيها العرض التقديمي لتعرف أي الخطوط سيستبدلها Aspose.Slides. تحقق أيضًا من إعدادات [استبدال الخط](/slides/ar/net/font-substitution/) وقواعد [الخط الاحتياطي](/slides/ar/net/fallback-font/). يتعامل الخط الاحتياطي مع الأحرف المفقودة، لذا لا يحل تضمين الخط مشكلة الأحرف التي لا يحتويها الخط نفسه.

**هل يجب عليّ تضمين الخطوط الشائعة مثل Arial و Calibri؟**

اعتمد اتخاذ القرار على بيئة الهدف. إذا كانت الخطوط المطلوبة متوفرة على كل جهاز يفتح أو يعرض العرض التقديمي، قد يؤدي تضمينها إلى زيادة حجم الملف دون ضرورة. إذا كان من الممكن أن يفتقر المتلقون أو الخوادم إلى تلك الخطوط، يمكن لتضمينها أن يساعد في الحفاظ على المظهر المقصود، بشرط أن تسمح التراخيص بذلك.