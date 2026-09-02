---
title: بحث واستبدال النص في عروض PowerPoint التقديمية باستخدام .NET
linktitle: بحث واستبدال النص
type: docs
weight: 55
url: /ar/net/search-and-replace-text/
keywords:
- بحث نص
- تظليل النص
- استبدال النص
- تعبير منتظم
- رد نداء للنتيجة
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "بحث وتظليل واستبدال النص في عروض PowerPoint التقديمية مع جمع كل مطابقة باستخدام Aspose.Slides للـ .NET."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET البحث وتظليل واستبدال النص في إطار نصي واحد أو عبر العرض التقديمي بأكمله. يمكن لكل عملية أيضًا إعلام التطبيق عن كل تطابق من خلال استدعاء نتيجة. يتيح ذلك إمكانية تحديث العرض التقديمي وفي الوقت نفسه بناء سجل تدقيق يحتوي على النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

هذه القدرات مفيدة للمراجعة وإزالة المعلومات الحساسة وفحص المصطلحات وتنظيف القوالب وتدفقات العمل الآلية للتقارير.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص عينة](sample_text.png)

## **اختر نطاق البحث**

استخدم الأساليب الموجودة في [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) لتحديد عملية لإطار نص واحد. استخدم الأساليب الموجودة في [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تظليل نص حرفي | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlighttext/) |
| تظليل تطابقات التعبير المنتظم | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlightregex/) |
| استبدال نص حرفي | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replacetext/) |
| استبدال تطابقات التعبير المنتظم | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replaceregex/) |

## **تكوين مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/wholewordsonly/) يقتصر المطابقات على الكلمات الكاملة.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/casesensitive/) يتحكم فيما إذا كان يجب أن يتطابق حجم الأحرف.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/includenotes/) يشمل ملاحظات الشرائح في عمليات البحث والاستبدال والتظليل على مستوى العرض التقديمي.

تستخدم عمليات التعبير المنتظم كائن .NET `Regex`، لذا تُحدَّد قواعد المطابقة مثل حساسية الأحرف وحدود الكلمات بواسطة التعبير وخياراته.

## **جمع معلومات المطابقة عبر استدعاء رد نداء**

قم بتنفيذ [IFindResultCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/ifindresultcallback/) لتلقي إشعار لكل مطابقة. طريقة [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ar/net/aspose.slides/ifindresultcallback/foundresult/) توفر إطار النص المتعلق، النص المصدر، النص المتطابق، وموقع المطابقة.

النداء لا يتلقى رقم الشريحة مباشرة. يُستخلص الرقم من الشريحة الأصلية في التنفيذ أدناه ويعالج أيضًا النص الموجود في ملاحظات الشريحة. يسمح رقم شريحة قابل للـ nullable باستخدام نموذج النتيجة نفسه لتمثيل النص المرتبط بأنواع شرائح أخرى.

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
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

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

في عمليات الاستبدال، يحتوي `FoundText` على النص الأصلي المتطابق، لذلك يمكن للنداء تسجيل المصطلحات المستبدلة بدقة.

## **تظليل النص**

استخدم طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlighttext/) لتظليل تطابقات النص الحرفي في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/) للتحكم في البحث ونداء لتجميع تفاصيل المطابقة.

يقوم مثال الشيفرة أدناه بتظليل جميع تكرارات الأحرف **"try"** ثم يظلل فقط الكلمة الكاملة **"to"**. كلا البحثين يبلغان نتائجهما إلى نفس النداء.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

النتيجة:

![النص المظلل](highlighted_text.png)

## **تظليل النص باستخدام التعبيرات المنتظمة**

طريقة [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlightregex/) تظلل تطابقات النص التي يُعثر عليها عبر تعبير منتظم في إطار نص.

الشيفرة التالية تظلل جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر وتجمع كل مطابقة:

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

![النص المظلل باستخدام التعبير المنتظم](highlighted_text_using_regex.png)

## **تظليل النص عبر العرض التقديمي**

استخدم [Presentation.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlighttext/) و[Presentation.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/highlightregex/) للبحث في جميع أطر النص القابلة للتطبيق في العرض التقديمي. يوضح المثال التالي تظليل مصطلح حرفي وجميع عناوين البريد الإلكتروني مع الحفاظ على مجموعات نتائج منفصلة للبحثين.

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

استخدم [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/) للنص الحرفي و[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) للاستبدال القائم على النمط. تقوم هذه الأساليب بتحديث النص المتطابق داخل إطار النص الحالي، مما يحتفظ بتنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي يوحّد تنوع تهجئة ثم يستبدل علامات النسخة. يسجل نفس النداء المصطلحات الأصلية المتطابقة في كلا العمليتين.

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

إذا امتدَّ مطابقة عبر أجزاء ذات تنسيق مختلف، راجع الناتج لتأكيد أي تنسيق يجب أن يُطبق على النص المستبدل.

## **استبدال النص عبر العرض التقديمي**

استخدم [Presentation.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replacetext/) و[Presentation.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/replaceregex/) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب وتحديث المصطلحات وإزالة المعلومات الحساسة.

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

احصل على إطار النص للشكل واستدعِ [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlighttext/)، [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlightregex/)، [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/)، أو [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) على ذلك الإطار. تُعالج الأساليب على مستوى العرض التقديمي جميع أطر النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الكتابة الصحيحة للأحرف؟**

ضع قيم `true` لـ [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/wholewordsonly/) و[TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/casesensitive/)، ثم مرّر الخيارات إلى طريقة تظليل أو استبدال النص الحرفي. بالنسبة للتعبيرات المنتظمة، حدّد حدود الكلمات وحساسية الأحرف داخل الـ .NET `Regex` نفسه.

**هل يمكن أن يشمل البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. ضع [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/includenotes/) على `true` عند استخدام عملية حرفية على مستوى العرض التقديمي. تُعيد تنفيذ النداء الموضّح أعلاه مطابقة في شريحة ملاحظات إلى رقم شريحة الأصل.

**كيف يمكنني إنشاء تقرير دون فحص العرض التقديمي مرة ثانية؟**

مرّر تنفيذًا لـ [IFindResultCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/ifindresultcallback/) إلى عملية التظليل أو الاستبدال. يتلقى النداء كل مطابقة أثناء تشغيل العملية، وبالتالي يمكن للتطبيق تخزين النص المصدر، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستنبط لتجميعه أو تصديره لاحقًا.

**هل يحافظ استبدال النص على تنسيقه؟**

تُعدّل [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replacetext/) و[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/replaceregex/) النص المتطابق داخل إطار النص الحالي وتحتفظ بتنسيق الجزء المحيط. إذا امتدَّ مطابقة عبر أجزاء ذات تنسيق مختلف، افحص النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.