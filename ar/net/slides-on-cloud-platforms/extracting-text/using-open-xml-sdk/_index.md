---
title: "كيفية استخراج النص من ملفات PPT و PPTX و ODP باستخدام Open XML SDK في .NET"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /ar/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- "منصات سحابية"
- "تكامل سحابي"
- "Open XML SDK"
- "استخراج نص PPTX"
- "معالجة شرائح .NET"
- "استخراج نص العرض التقديمي"
- "الشريحة الرئيسية"
- "ملاحظات المتحدث"
- "استخراج النص من الشرائح"
- "C#"
description: "تعلم كيفية استخراج النص من ملفات PPT و PPTX و ODP في .NET باستخدام Open XML SDK، مع وصول مبني على XML، ونصائح أداء، وحلول تحويل للتطبيقات السحابية."
---

# استخراج النص من PPT و PPTX و ODP باستخدام Open XML SDK

## Open XML SDK

**Open XML SDK** يوفر طريقة عالية البنية وفعّالة لاستخراج النص من ملفات العروض التقديمية — خاصةً **PPTX** التي تتبع معيار Open XML. من خلال إعطاء وصول مباشر إلى XML الأساسي، يتيح هذا SDK سرعات أعلى وتعاملًا أكثر مرونة مع محتوى الشرائح مقارنةً بالطرق التقليدية.

## الوصول المباشر إلى XML

- **تحليل النص مباشرة**: يتيح لك Open XML SDK استخراج النص من أجزاء XML دون عرض الشرائح.
- **العناصر المنظمة**: لأن النص يُخزن في وسوم XML محددة جيدًا، يصبح استرجاعه ومعالجته أسهل.

### مثال: استخراج النص مباشرةً من محتوى XML للشرائح
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```


## مزايا الأداء

- **استخراج أسرع**: يتجاوز عبء فتح PowerPoint أو واجهات برمجة التطبيقات عالية المستوى.
- **استخدام أقل للذاكرة**: يتم الوصول فقط إلى أجزاء XML ذات الصلة، مما يقلل من استهلاك الموارد.
- **لا حاجة إلى Microsoft PowerPoint**: يحررك من متطلبات التثبيت الإضافية.

### مثال: استخراج النص بفعالية دون تحميل العرض الكامل
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```


## تحديد عناصر النص

### تفاصيل استخراج النص من العروض التقديمية

عند استخراج النص من العروض التقديمية، ضع في اعتبارك العوامل التالية:

- **قد يوجد النص في أقسام مختلفة**: الشرائح العادية، الشرائح الرئيسية، التخطيطات، أو ملاحظات المتحدث.
- **النصوص الافتراضية**: يمكن للشرائح الرئيسية والتخطيطات أن تتضمن نواقل (مثال: “انقر لتعديل نمط عنوان الشريحة الرئيسية”) التي لا تُعد محتوى فعليًا للعرض.
- **تصفية النص الفارغ أو المخفي**: قد تكون بعض العناصر فارغة أو غير مقصودة للعرض.

### الوسوم التي تحتوي على النص

في ملف **PPTX**، يُخزن النص عادةً في:

- عناصر `<a:t>` داخل `<a:p>` (فقرات)
- عناصر `<a:r>` (مقاطع نص داخل الفقرات)

### مثال: استخراج جميع عناصر النص من شريحة
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## ODP و PPT

### عدم القدرة على استخراج النص مباشرةً

- على عكس **PPTX**، فإن **PPT** (الصيغة الثنائية) و **ODP** (عرض OpenDocument) **غير مدعومة** من قبل Open XML SDK.
- **PPT** يخزن المحتوى في صيغة ثنائية مغلقة، مما يصعب استخراج النص.
- **ODP** يعتمد على **OpenDocument XML**، الذي يختلف هيكليًا عن PPTX.

### حل بديل: التحويل إلى PPTX

1. **تحويل PPT → PPTX** باستخدام PowerPoint أو أداة جهة ثالثة.  
2. **تحويل ODP → PPTX** عبر LibreOffice أو PowerPoint.  
3. **استخراج النص** من ملف PPTX الجديد باستخدام Open XML SDK.

### مثال: تحويل ODP إلى PPTX عبر سطر أوامر LibreOffice
```sh
soffice --headless --convert-to pptx presentation.odp
```


## الأنظمة الأساسية والأطر المدعومة

- **Windows**: .NET Framework 4.6.1 وما فوق، .NET Core 2.1+، .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+، .NET 5/6/7.
- **بيئات السحابة**: Microsoft Azure Functions، AWS Lambda (.NET Core)، حاويات Docker.
- **التوافق مع تطبيقات Office**: لا يتطلب تثبيت Microsoft Office.
- **لغات البرمجة المدعومة**: يمكن استخدام Open XML SDK مع **C#**، **VB.NET**، **F#**، وغيرها من اللغات المدعومة في .NET.

## الخلاصة

إن الاستفادة من **Open XML SDK** لاستخراج نص **PPTX** توفر كلاً من الكفاءة والوضوح، بينما يتطلب **PPT و ODP** خطوة تحويل أولية لضمان معالجة سلسة. اعتماد هذا النهج يضمن **أداءً عاليًا**، **مرونة**، و**توافقًا واسعًا** مع تطبيقات .NET الحديثة.