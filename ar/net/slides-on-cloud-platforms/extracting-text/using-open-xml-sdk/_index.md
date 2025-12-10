---
title: "كيفية استخراج النص من ملفات PPT و PPTX و ODP باستخدام Open XML SDK في .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /ar/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- منصات سحابية
- تكامل سحابي
- Open XML SDK
- استخراج نص PPTX
- معالجة شرائح .NET
- استخراج نص العرض التقديمي
- الشريحة الرئيسية
- ملاحظات المتحدث
- استخراج النص من الشرائح
- C#
description: "تعلم كيفية استخراج النص من ملفات PPT و PPTX و ODP في .NET باستخدام Open XML SDK، مع وصول قائم على XML، ونصائح الأداء، وحلول تحويل للتطبيقات السحابية."
---

## **Open XML SDK**

توفر **Open XML SDK** طريقةً مرتبةً وفعالةً للغاية لاستخراج النص من ملفات العروض التقديمية—وخاصة **PPTX** التي تتبع معيار Open XML. من خلال إتاحة الوصول المباشر إلى XML الأساسي، يُمكّن هذا SDK من معالجة محتوى الشرائح بشكل أسرع وأكثر مرونة مقارنةً بالطرق التقليدية.

## **Direct XML Access**

- **تحليل النص مباشرة**: يسمح لك Open XML SDK باستخراج النص من أجزاء XML دون عرض الشرائح.
- **العناصر المهيكلة**: لأن النص مخزن في علامات XML محددة جيدًا، يصبح من الأسهل استرجاعه ومعالجته.

### **Example: Extracting Text Directly from Slide XML Content**
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


## **Performance Advantages**

- **استخراج أسرع**: يتجاوز عبء فتح PowerPoint أو واجهات برمجة التطبيقات عالية المستوى.
- **استخدام أقل للذاكرة**: يتم الوصول فقط إلى أجزاء XML ذات الصلة، مما يقلل من استهلاك الموارد.
- **لا حاجة لبرنامج Microsoft PowerPoint**: يحررك من متطلبات التثبيت الإضافية.

### **Example: Efficiently Extracting Text Without Loading the Entire Presentation**
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


## **Identifying Text Elements**

### **Specifics of Extracting Text from Presentations**

عند استخراج النص من العروض التقديمية، ضع في الاعتبار العوامل التالية:

- **قد يتواجد النص في أقسام مختلفة**: شرائح عادية، شرائح رئيسية، تخطيطات، أو ملاحظات المتحدث.
- **العناصر النائبة الافتراضية**: يمكن أن تتضمن الشرائح الرئيسية والتخطيطات عناصر نائبة (مثل “Click to edit Master title style”) التي ليست جزءًا من محتوى العرض الفعلي.
- **تصفية النص الفارغ أو المخفي**: قد تكون بعض العناصر فارغة أو غير مقصودة للعرض.

### **Tags Containing Text**

في ملف **PPTX**، يُخزن النص عادةً في:

- عناصر `<a:t>` داخل `<a:p>` (فقرات)
- عناصر `<a:r>` (مقاطع نص داخل الفقرات)

### **Example: Extracting All Text Elements from a Slide**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## **ODP and PPT**

### **Inability to Extract Text Directly**

- على عكس **PPTX**، **PPT** (صيغة ثنائية) و **ODP** (عرض مستند OpenDocument) **غير مدعومة** من قبل Open XML SDK.
- **PPT** يخزن المحتوى في صيغة ثنائية مغلقة، مما يعقد استخراج النص.
- **ODP** يعتمد على **OpenDocument XML**، الذي يختلف هيكليًا عن PPTX.

### **Workaround: Converting to PPTX**

لاستخراج النص من **PPT** أو **ODP**، النهج الموصى به هو:

1. **تحويل PPT → PPTX** باستخدام PowerPoint أو أداة طرف ثالث.  
2. **تحويل ODP → PPTX** عبر LibreOffice أو PowerPoint.  
3. **استخراج النص** من PPTX الجديد باستخدام Open XML SDK.

### **Example: Converting ODP to PPTX via LibreOffice Command Line**
```sh
soffice --headless --convert-to pptx presentation.odp
```


## **Supported Platforms and Frameworks**

- **Windows**: .NET Framework 4.6.1 وما فوق، .NET Core 2.1+، .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+، .NET 5/6/7.
- **بيئات السحابة**: Microsoft Azure Functions، AWS Lambda (.NET Core)، حاويات Docker.
- **التوافق مع تطبيقات Office**: لا يلزم تثبيت Microsoft Office.
- **لغات البرمجة المدعومة**: يمكن استخدام Open XML SDK مع **C#**، **VB.NET**، **F#**، وغيرها من اللغات المدعومة في .NET.

## **Conclusion**

استخدام **Open XML SDK** لاستخراج نص **PPTX** يوفر كلًا من الكفاءة والوضوح، بينما يتطلب **PPT و ODP** خطوة تحويل أولية لمعالجة سلسة. اعتماد هذا النهج يضمن **أداءً عاليًا**، **مرونة**، و**توافقًا واسعًا** مع تطبيقات .NET الحديثة.