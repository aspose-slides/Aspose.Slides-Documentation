---
title: استرجاع وتحديث معلومات العرض التقديمي في .NET
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/net/examine-presentation/
keywords:
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام .NET للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---

تتيح لك Aspose.Slides for .NET فحص عرض تقديمي لاكتشاف خصائصه وفهم سلوكه. 

{{% alert title="Info" color="info" %}} 
تحتوي الفئات [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) و[DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) على الخصائص والطرق المستخدمة في العمليات هنا.
{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو تنسيق العرض (PPT، PPTX، ODP، وغيرها) في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود C#:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **احصل على خصائص العرض التقديمي**

يعرض لك هذا الكود C# كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ...
```


قد ترغب في الاطلاع على [الخصائص ضمن فئة DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) فئة.

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides طريقة [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) التي تتيح لك تعديل خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يوضح لك مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المتغيرة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وسماته الأمنية، قد تجد الروابط التالية مفيدة:

- [التحقق مما إذا كان العرض مشفرًا](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض محميًا ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمّنة وأيها؟**

ابحث عن [معلومات الخطوط المضمّنة](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) لتحديد أي الخطوط حرجة للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

تصفح [مجموعة الشرائح](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) وتفقد [علامة الظهور](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم وشكل مخصص للشرائح، وما إذا كان يختلف عن الإعدادات الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) الحالي والاتجاه مع الإعدادات الافتراضية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)، تحقق من [مصدر البيانات](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) الخاص بها، ولاحظ ما إذا كانت البيانات داخلية أو مرتبطة بروابط، بما في ذلك الروابط المعطوبة.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تبطئ العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن الصور الكبيرة، والشفافية، والظلال، والرسوم المتحركة، والوسائط المتعددة؛ ثم أعطِ درجة تعقيد تقريبية لتحديد نقاط الأداء المحتملة.