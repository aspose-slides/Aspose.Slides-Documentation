---
title: تحديد صيغة العرض التقديمي الأصلية في .NET
linktitle: صيغة المصدر
type: docs
weight: 35
url: /ar/net/detect-presentation-source-format/
keywords:
- صيغة المصدر
- اكتشاف صيغة العرض
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "قراءة الصيغة الأصلية لعرض تم تحميله في C# باستخدام Aspose.Slides لـ .NET، مقارنة واجهات اكتشاف الصيغ، ومعالجة الملفات، التدفقات، والصيغ القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، اقرأ الخاصية للقراءة فقط [Presentation.SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sourceformat/) لتحديد صيغته الأصلية. الخاصية متاحة أيضاً عبر [IPresentation.SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/sourceformat/). استخدمها عندما يعتمد المعالجة اللاحقة على الصيغة التي تم تحميل الكائن الحالي منها.

صيغة المصدر تختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) المختارة لملف الإخراج. الحفظ إلى صيغة أخرى لا يغيّر صيغة المصدر للكائن الحالي.

## **قراءة صيغة المصدر لملف**

هذا المثال يتطلب ملف `sample.pptx` موجوداً. يقوم بتحميل الملف ويختار سياسة معالجة التطبيق باستخدام [Presentation.SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sourceformat/)، بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة صيغ أخرى. يطبع المثال السياسة المختارة؛ استبدل الرسائل بمنطق تطبيقك.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **التعرف على القيم المدعومة**

عدد [SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/sourceformat/) يميز الصيغ التالية للعروض التقديمية. الامتدادات أدناه هي امتدادات شائعة، وليست إعادة بناء لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | الصيغة |
| --- | --- | --- |
| `Ppt` | `.ppt` | عرض PowerPoint 97–2003 |
| `Pptx` | `.pptx` | عرض Office Open XML |
| `Pptm` | `.pptm` | عرض Office Open XML مع تمكين الماكرو |
| `Pps` | `.pps` | عرض شرائح PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | عرض شرائح Office Open XML |
| `Ppsm` | `.ppsm` | عرض شرائح Office Open XML مع تمكين الماكرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML مع تمكين الماكرو |
| `Odp` | `.odp` | عرض OpenDocument |
| `Otp` | `.otp` | قالب OpenDocument |
| `Fodp` | `.fodp` | عرض OpenDocument XML مسطح |
| `Xml` | `.xml` | عرض PowerPoint XML |

## **قراءة صيغة المصدر لتدفق بيانات**

هذا المثال يتطلب ملف `sample.pps` موجوداً. قراءة بايتاته إلى تدفق ذاكرة يحاكي إدخالًا مستلمًا بدون اسم ملف، مثل قيمة قاعدة بيانات أو مصفوفة بايتات تم رفعها. المُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) يتلقى فقط التدفق.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

تستخدم PPT و PPS و POT نفس الصيغة الثنائية الأساسية. عند التحميل عبر مسار ملف، يمكن للامتداد أن يساعد في تمييز عرض الشرائح أو القالب. بدون اسم ملف، قد يُبلغ عن محتوى PPS أو POT القديم كـ `SourceFormat.Ppt`؛ مثال PPS أعلاه يُبلغ عن `Ppt`.

إذا كان تطبيقك يحتاج إلى الحفاظ على هذا التمييز، احتفظ باسم الملف الأصلي أو بيانات التعريف الفرعية بشكل منفصل. الامتداد هو تلميح مفيد لهذه الأنواع القديمة، لكنه لا يجب أن يكون الأساس الوحيد لتحديد محتوى عرض تقديمي عشوائي.

## **مقارنة الاكتشاف قبل وبعد التحميل**

استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) و [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/loadformat/) عندما تحتاج إلى فحص ملف قبل تحميل نموذج كائن العرض بالكامل. استخدم [Presentation.SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sourceformat/) عندما يكون الكائن موجوداً بالفعل.

هذا المثال يتطلب `sample.pptx` ويطبع `Pptx` لكل من الفحصين. في الإنتاج، اختر الـ API المناسب لمرحلة المعالجة؛ العرض الذي تم تحميله بالفعل لا يحتاج إلى فحص ثانٍ فقط للحصول على صيغة المصدر.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

النتائج لها أنواع تعداد مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/sourceformat/). لا تقارنهما بتحويل القيم العددية أو تفترض أن كل صيغة لديها نتائج اكتشاف متطابقة. في فحص الحفظ وإعادة الفتح الموضح أدناه، تم الإبلاغ عن PowerPoint XML كـ `LoadFormat.Unknown` قبل التحميل و`SourceFormat.Xml` بعد التحميل.

## **الحفاظ على صيغ المصدر والإخراج منفصلة**

هذا المثال يتطلب `sample.pptx` ويكتب `converted.odp`. يطبع `Pptx` قبل وبعد حفظ النسخة الأصلية. فقط النسخة الجديدة التي تم تحميلها من إخراج ODP تُبلغ عن `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

العرض الذي تم إنشاؤه من الصفر باستخدام `new Presentation()` يُبلغ عن `SourceFormat.Pptx`. لا يوجد ملف إدخال: هذه هي القيمة الافتراضية لكائن تم إنشاؤه حديثاً، ليست دليلًا على تحميل ملف PPTX. تتبع ما إذا كان تطبيقك قد أنشأ أو حمّل الكائن بشكل منفصل إذا كان هذا التمييز مهمًا.

## **تحويل صيغة المصدر إلى امتداد**

المثال التالي يتطلب `sample.pptx`. يربط كل قيمة مدعومة حالياً في [SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/sourceformat/) بامتداد شائع، دون تحليل اسم الملف المدخل. الفحص الاحتياطي يتجنب تعيين امتداد صامت لقيمة غير معروفة.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

هذا الربط لا يبدل ملفًا ولا يستعيد نوع فرعي قديم مفقود أثناء تحميل التدفق. للحفظ الفعلي، اختر [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) صراحةً، أو استخدم التحويل الموضح في [Save Presentations in Their Original Format](/slides/ar/net/save-presentation/#save-presentations-in-their-original-format).

## **التحقق من الصيغ عبر الحفظ وإعادة الفتح**

هذا المثال المستقل يخلق عرضًا ويكتب ثلاثة ملفات في دليل العمل، مستبدلاً الملفات ذات نفس الأسماء. يعيد فتح كل مخرج إما عبر المسار أو عبر تدفق ذاكرة. بالنسبة إلى PPTX و ODP، كلا المسارين يُبلغان عن الصيغة المحفوظة. بالنسبة إلى PPS، يُبلغ التحميل عبر المسار عن `Pps`، بينما التحميل من نفس البايتات دون اسم ملف يُبلغ عن `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

نفس الفحص مع جميع الصيغ المذكورة أعلاه أنتج النتائج التالية للعروض المولدة مع امتدادات مطابقة:

| صيغة الحفظ | SourceFormat من مسار ملف | SourceFormat من تدفق بدون اسم |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` على التوالي | كما في مسار الملف |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` على التوالي | كما في مسار الملف |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` على التوالي | كما في مسار الملف |
| ODP, OTP | `Odp`, `Otp` على التوالي | كما في مسار الملف |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

في هذه الفحوصات، كان التوحيد الوحيد لصيغة المصدر هو تحويل PPS/POT إلى `Ppt` للتدفق بدون اسم. يصف الجدول تحديد الصيغة، وليس الحفاظ على كل ميزة في العرض أثناء التحويل.

## **الأسئلة المتكررة**

**هل تغيير الحفظ إلى ODP صيغة المصدر لعرض تم تحميله من PPTX؟**

لا. الكائن الحالي لا يزال يُبلغ عن `Pptx`. الكائن الذي تم تحميله من ملف ODP المحفوظ يُبلغ عن `Odp`.

**هل يمكن للتدفق دائمًا تمييز عرض تقديمي قديم، أو عرض شرائح، أو قالب؟**

لا. الصيغة الثنائية مشتركة بين PPT و PPS و POT. احتفظ باسم الملف أو بيانات التعريف الفرعية بشكل منفصل عندما يكون هذا التمييز مطلوبًا.

**أي API يجب أن أستخدمه إذا كان العرض قد تم تحميله بالفعل؟**

اقرأ [Presentation.SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sourceformat/). استخدم [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) للفحص قبل التحميل.