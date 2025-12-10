---
title: "كيفية استخراج النص من PPT و PPTX و ODP باستخدام Aspose.Slides"
linktitle: الشرائح
type: docs
weight: 30
url: /ar/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- منصات السحابة
- تكامل السحابة
- استخراج النص
- استخراج النص
- PPT
- PPTX
- ODP
- ملفات العروض التقديمية
- متعدد المنصات
- مستقل عن Office
- الملاحظات والتعليقات
- فهرسة الشركات
- إثراء البيانات
- .NET
- Aspose.Slides
description: "استخراج النص من العروض التقديمية على منصات السحابة الشائعة باستخدام واجهات برمجة تطبيقات Aspose.Slides، أتمتة البحث والتحليل والتصدير للـ PPT و PPTX و ODP."
---

## **المقدمة**

توفر Aspose.Slides **واجهة برمجة تطبيقات قوية وعالية المستوى** لاستخراج النص من ملفات العروض التقديمية، بما في ذلك **PPT، PPTX، و ODP**. على عكس Open XML SDK—الذي يدعم فقط PPTX ويتطلب تحليل XML معقد—تُبسّط Aspose.Slides عملية استخراج النص، مما يتيح لك التركيز على دمج المحتوى المستخرج في سير العمل الخاص بك.

## **استخراج النص بسرعة باستخدام PresentationFactory.Instance.GetPresentationText**

لاستخراج النص من عرض تقديمي، توفر **Aspose.Slides API** الطريقة الساكنة `PresentationFactory.Instance.GetPresentationText`. تتضمن عدة تجارب للعمل مع ملف عرض تقديمي أو تدفق بيانات، وتلتقط النص من **الشرائح، الشرائح الرئيسية، القوالب، الملاحظات، والتعليقات**. يتم الوصول إلى النص المستخرج عبر واجهة `IPresentationText`.

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


## **أنماط تشغيل GetPresentationText**

تتيح طريقة `GetPresentationText` في `PresentationFactory` ضبط استخراج النص باستخدام معامل `TextExtractionArrangingMode`، الذي يحدد كيفية تنظيم النص في النتيجة.

### **الأنماط المتوفرة**

- **TextExtractionArrangingMode.Unarranged** – يستخرج النص بشكل حر، متغاضٍ عن تخطيط الشريحة الأصلي.  
- **TextExtractionArrangingMode.Arranged** – يحافظ على ترتيب النص وفقًا لموقعه في كل شريحة.

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


## **المزايا الرئيسية لطرق PresentationFactory**

- **عدم الحاجة لتحميل العروض بالكامل**: يقلل من استهلاك الذاكرة ويزيد من سرعة المعالجة.  
- **محسن للملفات الكبيرة**: يتعامل بكفاءة حتى مع العروض الضخمة، مستخرجًا النص بسرعة.  
- **يسترجع الملاحظات والتعليقات**: يشمل تعليقات المستخدم لتغطية شاملة للمحتوى.  
- **مثالي للفهرسة وتحليل المحتوى**: مناسب للأنظمة المؤسسية التي تتطلب معالجة آلية وتغذية البيانات.  
- **مستقل عن Office**: يعمل دون الحاجة إلى تثبيت Microsoft PowerPoint، مقدمًا حلًا مستقلاً بالكامل.  
- **دعم متعدد الصيغ**: يعمل بسلاسة مع **PPT، PPTX، و ODP**.  
- **واجهة برمجة تطبيقات مرنة وقوية**: توفر طرقًا متعددة لاستخراج النص بشكل منظم.  
- **تغطية شاملة للشرائح**: يستخرج النص من **القوالب، الشرائح الرئيسية، الشرائح العادية، الخلفيات، ملاحظات المتحدث، والتعليقات**.  
- **توافق متعدد الأنظمة**: يعمل على **Windows، Linux، macOS**، وكذلك في بيئات السحابة.  
- **أداء عالي وقابلية توسع**: ملائم لتطبيقات **SaaS** والنشر على نطاق المؤسسات الكبيرة.

## **أنظمة التشغيل المدعومة**

تعمل Aspose.Slides على مجموعة متنوعة من أنظمة التشغيل:

- **Windows** (مثل Windows 7، 8، 10، 11، وإصدارات Server)  
- **Linux** (توزيعات متعددة تشمل Ubuntu، Debian، Fedora، CentOS، وغيرها)  
- **macOS** (بما فيها الإصدارات الحديثة مثل 10.15 Catalina وما بعدها)  

## **لغات البرمجة المدعومة**

يتكامل Aspose.Slides مع منصات ولغات متعددة:

- **C#** – مدعوم أساسًا عبر Aspose.Slides for .NET.  
- **Java** – واجهة برمجة تطبيقات كاملة المتاحة عبر Aspose.Slides for Java.  
- **C++** – استخدم Aspose.Slides للتطبيقات ذات الأداء الحاسم في C++.  
- **Python عبر .NET** – دمج وظائف Aspose.Slides باستخدام التوافق مع .NET.  
- **لغات .NET الأخرى المتوافقة** – استفد من المكتبة في أي بيئة تدعم .NET.

## **الخاتمة**

توفر Aspose.Slides **استخراج نص شامل** لعروض PowerPoint وOpenDocument، داعمة **تنوع صيغ الملفات، هيكلة النص البديهية، والتنفيذ السهل** مقارنةً بـ Open XML SDK. من **الشرائح والملاحظات إلى محتوى القوالب**، تُعد **Aspose.Slides** حلًا عالي الكفاءة ومزودًا بميزات غنية لاستخراج وإدارة نص العروض التقديمية.