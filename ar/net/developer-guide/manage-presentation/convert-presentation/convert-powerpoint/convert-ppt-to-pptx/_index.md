---
title: تحويل PPT إلى PPTX في .NET
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/net/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في .NET باستخدام Aspose.Slides. يتضمن أمثلة C# للتحويل الفردي وتحويل الدُفعات، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for .NET تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. تُظهر هذه المقالة كيفية تحويل ملف واحد أو دليل من الملفات وتشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

حمِّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، ثم استدعِ [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/). تُصرف العبارة `using` العرض وتحرِّر موارده عند انتهاء النطاق.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// تحميل عرض PPT القديم.
using var presentation = new Presentation("presentation.ppt");

// حفظ العرض بتنسيق PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

امتداد الملف لا يحدِّد تنسيق الإخراج بنفسه؛ إنَّ معامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) هو الذي يفعل ذلك. احفظ مسارات الإدخال والإخراج مختلفة إذا كنت تحتاج إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل عدة ملفات PPT**

المثال التالي يُحوِّل كل ملف `.ppt` في دليل واحد. يُعالج كل ملف على حدة، لذا فإن فشل تحويل ملف واحد لا يُوقف باقي الدفعة.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

لأعباء العمل الإنتاجية، سجِّل الاستثناء الكامل، وقرّر ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات التي فشل تحويلها إلى طابور إعادة محاولة أو مراجعة. يمكن أن تتسبب الملفات الفاسدة، والملفات المحمية بكلمة مرور تم فتحها دون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم في فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/net/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، القوالب، التخطيطات، النص، الأشكال، الصور، الجداول، والرسوم البيانية. ومع ذلك، لا تمثّل PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تطبيع أو حذف أو عرض مختلف لميزة قديمة لا تمتلك ما يُقابلها في PPTX أو غير مدعومة من المكتبة.

تحقَّق من الملف المحوَّل إذا كان يحتوي على رسوم متحركة، انتقالات، كائنات OLE مدمجة أو مربوطة، عناصر تحكم ActiveX، وسائط مدمجة، خطوط غير شائعة، أو ماكرو VBA. ملف PPTX عادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل مناسب يدعم الماكرو عندما يلزم بقاء VBA متاحًا. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيُفتح أو يُعرض فيها العرض المُحوَّل.

للوثائق الهامة، أعد فتح ملف PPTX المُنشأ برمجيًا وتفقد عدد الشرائح والمحتوى الرئيسي، ثم قارن مظهره وسلوك عرض الشرائح في العارض المقصود. لا تُعَدّ استدعاء [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) الناجح دليلًا على أن كل ميزة قديمة لها تمثيل PPTX دقيق.

## **متى يجب استخدام PPTX**

استخدم PPTX عندما يتم تحرير العرض في إصدارات PowerPoint الحالية، أو تبادله مع أنظمة تتعامل مع حزم Open XML، أو تخزينه بتنسيق يسهل فحصه واسترداده مقارنةً بـ PPT الثنائي القديم. احفظ ملف PPT الأصلي كنسخة أرشيفية أو نسخة احتياطية حتى يجتاز العرض المُحوَّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو نوع خروج آخر، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/slides/ar/net/convert-presentation/) بدلاً من الافتراض أن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **المحوِّل الإلكتروني**

لملفٍ متفرق أو لمقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدُفعية أو التعامل مع الأخطاء على مستوى التطبيق، استخدم API الخاص بـ .NET.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/slides/ar/net/ppt-vs-pptx/)
- [حفظ العروض التقديمية في .NET](/slides/ar/net/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/net/supported-file-formats/)
- [فتح العروض التقديمية في .NET](/slides/ar/net/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. يقوم Aspose.Slides for .NET بتحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ تحويل PPT إلى PPTX على جميع المحتويات بدقة تامة؟**

إنه يحافظ على محتوى العرض التقديمي الشائع، لكن لا يُضمن الحفاظ على الدقة الكاملة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُنشأ إذا كان يحتوي على ماكروهات، كائنات OLE أو ActiveX، وسائط، رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا وفرت كلمة المرور الصحيحة عند تحميل الملف. يؤدي عدم وجود كلمة مرور أو كلمة مرور غير صحيحة إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالملف الأصلي حتى تتحقق من صحة PPTX في العارضات وسير العمل التي تهمك. هذا يوفر نسخة احتياطية في حالة تحويل ميزة قديمة بشكل مختلف.