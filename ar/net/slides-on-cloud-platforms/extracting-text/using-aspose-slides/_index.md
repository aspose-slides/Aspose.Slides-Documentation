---
title: "كيفية استخراج النص من PPT و PPTX و ODP باستخدام Aspose.Slides"
linktitle: "شرائح"
type: docs
weight: 30
url: /ar/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- منصات سحابية
- تكامل سحابي
- استخراج النص
- استخراج النص
- PPT
- PPTX
- ODP
- ملفات العروض التقديمية
- متعدد المنصات
- مستقل عن Office
- الملاحظات والتعليقات
- فهرسة مؤسسية
- إثراء البيانات
- .NET
- Aspose.Slides
description: "استخراج النص من العروض التقديمية على منصات سحابية شائعة باستخدام واجهات برمجة تطبيقات Aspose.Slides، مما يتيح أتمتة البحث والتحليل والتصدير لـ PPT و PPTX و ODP."
---

# استخراج النص من PPT، PPTX، و ODP – Slides

توفر Aspose.Slides **واجهة برمجة تطبيقات قوية وعالية المستوى** لاستخراج النص من ملفات العروض التقديمية، بما في ذلك **PPT و PPTX و ODP**. على عكس Open XML SDK—الذي يدعم PPTX فقط ويتطلب تحليل XML معقد—تبسط Aspose.Slides عملية استخراج النص، مما يسمح لك بالتركيز على دمج المحتوى المستخرج في سير العمل الخاص بك.

## استخراج النص سريعًا باستخدام PresentationFactory.Instance.GetPresentationText

لاستخراج النص من عرض تقديمي، توفر **Aspose.Slides API** الطريقة الثابتة `PresentationFactory.Instance.GetPresentationText`. تشمل عدة إصدارات متداخلة للعمل مع ملف عرض تقديمي أو تدفق بيانات، وتلتقط النص من **الشرائح، الشرائح الرئيسة، التخطيطات، الملاحظات، والتعليقات**. يُمكن الوصول إلى النص المستخرج عبر الواجهة `IPresentationText`.

مثال على الاستخدام:
```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```


## أوضاع التشغيل لطريقة GetPresentationText

تتيح طريقة `GetPresentationText` في `PresentationFactory` ضبط استخراج النص بدقة باستخدام معامل `TextExtractionArrangingMode`، والذي يتحكم في كيفية تنظيم النص في الناتج.

### أوضاع متاحة:

- **TextExtractionArrangingMode.Unarranged** – يستخرج النص بصورة غير مرتبة، متجاهلاً تخطيط الشريحة الأصلي.  
- **TextExtractionArrangingMode.Arranged** – يحافظ على ترتيب النص وفقًا لموقعه على كل شريحة.  

مثال على الاستخدام:
```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## المزايا الأساسية لطرق PresentationFactory

- **No Need to Load Entire Presentations**: يقلل من استهلاك الذاكرة ويزيد من سرعة المعالجة.  
- **Optimized for Large Files**: يتعامل بكفاءة حتى مع العروض الكبيرة، مستخرجًا النص بسرعة.  
- **Retrieves Notes and Comments**: يتضمن تعليقات المستخدم لتغطية شاملة للمحتوى.  
- **Ideal for Indexing and Content Analysis**: مثالي للأنظمة المؤسسية التي تتطلب معالجة آلية وتخصيب البيانات.  
- **Office-Independent**: يعمل دون الحاجة إلى تثبيت Microsoft PowerPoint، مقدماً حلاً مستقلاً تمامًا.  
- **Multi-Format Support**: يدعم بكل سلاسة **PPT، PPTX، و ODP**.  
- **Flexible, Powerful API**: يوفر طرقًا متعددة لاستخراج النص المنظم.  
- **Complete Slide Coverage**: يستخرج النص من **التخطيطات، الشرائح الرئيسة، الشرائح العادية، الخلفيات، ملاحظات المتحدث، والتعليقات**.  
- **Cross-Platform Compatibility**: يعمل على **Windows، Linux، macOS**، وفي بيئات السحابة.  
- **High Performance and Scalability**: مناسب لتطبيقات **SaaS** والنشر المؤسسي على نطاق واسع.  

## أنظمة التشغيل المدعومة

Aspose.Slides يعمل على مجموعة متنوعة من أنظمة التشغيل:

- **Windows** (مثل Windows 7، 8، 10، 11 وإصدارات Server)  
- **Linux** (توزيعات مختلفة، بما في ذلك Ubuntu، Debian، Fedora، CentOS، إلخ)  
- **macOS** (بما في ذلك الإصدارات الحديثة مثل 10.15 Catalina وما بعده)  

## لغات البرمجة المدعومة

Aspose.Slides يتكامل مع منصات ولغات متعددة:

- **C#** – مدعومة أساسًا عبر Aspose.Slides for .NET.  
- **Java** – واجهة برمجة تطبيقات كاملة الميزات متاحة مع Aspose.Slides for Java.  
- **C++** – استفد من Aspose.Slides لتطبيقات C++ ذات المتطلبات العالية للأداء.  
- **Python via .NET** – دمج وظائف Aspose.Slides باستخدام التوافق مع .NET.  
- **Other .NET-Compatible Languages** – استخدم المكتبة في أي بيئة مدعومة من .NET.  

## الخلاصة

توفر Aspose.Slides **استخراج نص شامل** لعروض PowerPoint و OpenDocument، مع دعم **صيغ ملفات مختلفة، هيكلة نصية بديهية، وتنفيذ بسيط** مقارنةً بـ Open XML SDK. من **الشرائح والملاحظات إلى محتوى القوالب**، تُعد **Aspose.Slides** حلاً عالي الكفاءة وذو ميزات متعددة لاستخراج وإدارة نصوص العروض التقديمية.