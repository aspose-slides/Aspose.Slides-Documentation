---
title: البحث والاستبدال النصي في عروض PowerPoint التقديمية باستخدام .NET
linktitle: البحث والاستبدال النصي
type: docs
weight: 55
url: /ar/net/search-and-replace-text/
keywords:
- بحث نص
- تظليل نص
- استبدال نص
- تعبير نمطي
- استدعاء نتيجة
- إطار نص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "بحث، تظليل، واستبدال النص في عروض PowerPoint التقديمية مع جمع كل مطابقة باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET البحث عن النص، وتظليله، واستبداله في إطار نصي فردي أو عبر العرض التقديمي بأكمله. يمكن لكل عملية أيضًا إبلاغ التطبيق عن كل مطابقة من خلال رد نداء للنتيجة. يتيح ذلك إمكانية تحديث العرض التقديمي وفي الوقت نفسه إنشاء مسار تدقيق يحتوي على النص المطابق، وسياقه، وموقعه، وإطار النص، ورقم الشريحة.

تُعَدُّ هذه الإمكانيات مفيدة للمراجعة، وإزالة المعلومات الحساسة، وفحص المصطلحات، وتنظيف القوالب، وتدفقات عمل التقارير الآلية.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم **"sample.pptx"** يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص تجريبي](sample_text.png)

## **اختيار نطاق البحث**

استخدم الأساليب على [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) لتقييد العملية على إطار نصي واحد. استخدم الأساليب على [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) لمعالجة كل النص القابل للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تظليل النص الحرفي | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlighttext/) |
| تظليل مطابقة التعبير النمطي | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlightregex/) |
| استبدال النص الحرفي | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replacetext/) |
| استبدال مطابقة التعبير النمطي | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replaceregex/) |

## **تكوين مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/wholewordsonly/) يقتصر المطابقات على الكلمات الكاملة.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/casesensitive/) يتحكم فيما إذا كان يجب تطابق حالة الأحرف.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/includenotes/) يتضمن ملاحظات الشرائح في عمليات البحث والاستبدال والتظليل على مستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي كائن .NET `Regex`، لذا تُحدَّد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات في التعبير وخياراته.

## **تحديد مالك إطار النص**

غالبًا ما تتلقى سير عمل معالجة النص العامة كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) أثناء البحث أو الاستبدال أو التحقق أو تصدير النص. استخدم [ITextFrame.ParentShape](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentshape/) و[ITextFrame.ParentCell](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentcell/) لتحديد أي كائن عرض تقديمي يملك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `ParentShape` | `ParentCell` |
|---|---|---|
| شكل AutoShape أو أي شكل آخر يحتوي على نص | الـ[IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) المالك | `null` |
| خلية جدول | `null` | الـ[ICell](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/) المالك |

كلا الخاصيتين هما خصائص تنقل للقراءة فقط. قراءتهما لا تحرك إطار النص ولا تغير مالكه. ينبغي على الكود العام فحص القيمتين للتحقق من كونهما `null` ومعالجة احتمال عدم توفر أي من المالكين.

المثال التالي يستخدم [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextframes/) للتنقل عبر جميع إطارات النص في عرض تقديمي. بالنسبة للأشكال، يوضح اسم الشكل، نوع الشكل، والشريحة التي يحتويها. بالنسبة لخلايا الجداول، يوضح إحداثيات العمود والصف (بدءًا من الصفر) والشريحة التي يحتويها.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

بالنسبة لمحتوى SmartArt، تنقل عبر الأشكال في [ISmartArtNode.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartartnode/shapes/) وافتح كل [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartartshape/textframe/). يمكن تتبع إطار النص إلى الشكل المرتبط من خلال [ITextFrame.ParentShape](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentshape/)، بينما يكون [ITextFrame.ParentCell](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentcell/) `null`. لذلك يتعامل فرع الشكل في المثال أيضًا مع النص الوارد من عقد SmartArt.

## **جمع معلومات المطابقة باستخدام رد النداء**

نفّذ [IFindResultCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/ifindresultcallback/) لتلقي إشعار عن كل مطابقة. توفر الطريقة [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ar/net/aspose.slides/ifindresultcallback/foundresult/) إطار النص المتعلق، النص الأصلي، النص المطابق، وموقع المطابقة.

لا يتلقى رد النداء رقم الشريحة مباشرة. تستمد التنفيذ أدناه رقم الشريحة من الشريحة الأصلية وتتعامل أيضًا مع النص الموجود في ملاحظات الشرائح. يسمح رقم شريحة قابل للتمييز بأن يمثل نموذج النتيجة نفسه النص المرتبط بأنواع الشرائح الأخرى.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

لعمليات الاستبدال، يحتوي `FoundText` على النص الأصلي المطابق، لذا يمكن لرد النداء تسجيل أي مصطلحات تم استبدالها بالضبط.

## **تظليل النص**

استخدم طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlighttext/) لتظليل المطابقات النصية الحرفية في إطار نص. مرّر كائن [TextSearchOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/) للتحكم في البحث، ومرّر رد نداء لجمع تفاصيل المطابقة.

يُبرز المثال أدناه كل تكرارات الأحرف **"try"** ثم يبرز الكلمة الكاملة **"to"** فقط. كلا البحثين يرسلان مطابقاتهما إلى نفس رد النداء.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// احصل على الشكل الأول من الشريحة الأولى.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// ظلل كل ظهور لكلمة "try" في إطار النص.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// ظلل الكلمة الكاملة "to" فقط.
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

النتيجة:

![النص المظلل](highlighted_text.png)

## **تظليل النص باستخدام التعبيرات النمطية**

تُظلل طريقة [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlightregex/) مطابقة النص الموجودة بواسطة تعبير نمطي داخل إطار نص.

الكود التالي يظلل كل الكلمات التي تحتوي على سبعة أحرف أو أكثر ويجمع كل مطابقة:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

النتيجة:

![النص المظلل باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تظليل النص عبر عرض تقديمي**

استخدم [Presentation.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlighttext/) و[Presentation.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlightregex/) للبحث في كل إطارات النص القابلة للتطبيق في عرض تقديمي. يوضح المثال التالي تظليل مصطلح حرفي وكل عناوين البريد الإلكتروني مع الحفاظ على مجموعات نتائج منفصلة للبحثين.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **استبدال النص في إطار نص**

استخدم [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/) للنص الحرفي و[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) للاستبدال القائم على النمط. تقوم هذه الأساليب بتحديث النص المطابق داخل إطار النص القائم، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة نصية عادية.

المثال التالي يوحد شكل كتابة مختلفة ثم يستبدل تسميات الإصدارات. يسجل نفس رد النداء المصطلحات الأصلية المطابقة في كلتا العمليتين.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

إذا امتدت مطابقة واحدة عبر أجزاء ذات تنسيقات مختلفة، راجع النتيجة لتأكيد أي تنسيق يجب أن يُطبّق على النص المستبدل.

## **استبدال النص عبر عرض تقديمي**

استخدم [Presentation.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replacetext/) و[Presentation.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replaceregex/) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، وإزالة المعلومات الحساسة.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **تجميع المطابقات للتقارير**

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع المطابقات للتدقيق أو التقارير أو سير عمل المراجعة. يوضح المثال التالي تجميع النتائج المجمعة أولاً حسب الشريحة ثم حسب إطار النص:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **الأسئلة الشائعة**

**كيف يمكنني البحث في صندوق نص واحد فقط بدلاً من كامل العرض التقديمي؟**

احصل على إطار النص الخاص بالشكل واستدعِ [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlighttext/)، [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlightregex/)، [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/)، أو [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) على ذلك الإطار. تقوم الأساليب على مستوى العرض التقديمي بمعالجة جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع المحافظة على حالة الأحرف الصحيحة؟**

عيّن [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/wholewordsonly/) و[TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/casesensitive/) إلى `true`، ومرّر الخيارات إلى طريقة تظليل أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، حدِّد حدود الكلمات وحساسية الحالة داخل الـ`Regex` الخاص بـ .NET نفسه.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. عيّن [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/includenotes/) إلى `true` عند استخدام عملية نص حرفية على مستوى العرض التقديمي. يربط تنفيذ رد النداء الموضح أعلاه مطابقة في شريحة ملاحظات برقم الشريحة الأصلية.

**كيف يمكنني إنشاء تقرير دون فحص العرض التقديمي مرة ثانية؟**

مرّر تنفيذًا لـ [IFindResultCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/ifindresultcallback/) إلى عملية التظليل أو الاستبدال. يتلقى رد النداء كل مطابقة أثناء تشغيل العملية، بحيث يمكن للتطبيق تخزين النص الأصلي، والنص المطابق، والموقع، وإطار النص، ورقم الشريحة المستنتج لتجميعه أو تصديره لاحقًا.

**هل يحافظ استبدال النص على تنسيقه؟**

تُحافظ كل من [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/) و[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) على تنسيق الجزء المحيط عند تعديل النص المطابق داخل إطار النص القائم. إذا امتدت مطابقة عبر أجزاء ذات تنسيقات مختلفة، يجب فحص النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.