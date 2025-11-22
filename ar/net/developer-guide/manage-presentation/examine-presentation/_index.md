---
title: فحص العرض التقديمي
type: docs
weight: 30
url: /ar/net/examine-presentation/
keywords:
- PowerPoint
- عرض تقديمي
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "قراءة وتعديل خصائص عرض PowerPoint التقديمي باستخدام C# أو .NET"
---

Aspose.Slides for .NET يتيح لك فحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه. 

{{% alert title="Info" color="info" %}} 

الفئات [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) و[DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) تحتوي على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة أي تنسيق (PPT، PPTX، ODP، وغيرها) يكون العرض التقديمي في وضعه الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود C#:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **الحصول على خصائص العرض التقديمي**

هذا الكود C# يوضح لك كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```


قد ترغب في مشاهدة [properties under the DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) الفئة.

## **تحديث خصائص العرض التقديمي**

Aspose.Slides يوفر الطريقة [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

هذا المثال البرمجي يوضح لك كيفية تعديل بعض خصائص العرض:
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


نتائج تغيير خصائص المستند موضحة أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض محميًا بكلمة مرور](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض محميًا من الكتابة (قراءة فقط)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وما هي الخطوط المضمنة؟**

ابحث عن معلومات [embedded-font](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) لتحديد أي الخطوط حيوية للعرض.

**كيف أستطيع بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

تجول عبر [slide collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) وتفحص علامة [visibility flag](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم وشكل شريحة مخصص، وما إذا كانا مختلفين عن الإعدادات الافتراضية؟**

نعم. قارن [slide size](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) الحالي والاتجاه مع القوالب القياسية؛ هذا يساعد على توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)، وتحقق من [data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)، واشعر ما إذا كانت البيانات داخلية أو مرتبطة، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم "الشرائح الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، حركات، ووسائط متعددة؛ وامنحها درجة تعقيد تقريبية لتحديد نقاط الاختناق المحتملة في الأداء.