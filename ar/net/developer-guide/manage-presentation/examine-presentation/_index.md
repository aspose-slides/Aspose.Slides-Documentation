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

Aspose.Slides لـ .NET يتيح لك فحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="Info" color="info" %}} 
{{% /alert %}} 

الصفوف [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) و[DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) تحتوي على الخصائص والطرق المستخدمة في العمليات هنا.

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون فيه العرض في الوقت الحالي.

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


قد ترغب في رؤية [الخصائص في فئة DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **تحديث خصائص العرض التقديمي**

Aspose.Slides يوفر الطريقة [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![الخصائص الأصلية للمستند في عرض PowerPoint](input_properties.png)

هذا المثال يوضح لك كيفية تعديل بعض خصائص العرض التقديمي:
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

![الخصائص المتغيرة للمستند في عرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على المزيد من المعلومات حول عرض تقديمي وسمات الأمان الخاصة به، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفرًا](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وأيها؟**

ابحث عن معلومات [embedded-font](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض، ثم قارن هذه الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) لتحديد الخطوط الحرجة للعرض.

**كيف أستطيع بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

تجوّل عبر [مجموعة الشرائح](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) وافحص [علامة الظهور](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم واتجاه شريحة مخصصين، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. قارن [حجم الشريحة الحالي](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) والاتجاه مع الإعدادات المسبقة القياسية؛ هذا يساعد على توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة للتحقق مما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)، وتحقق من [مصدر البيانات](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)، ولاحظ ما إذا كان البيانات داخلية أم مرتبطة، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح “الثقيلة” التي قد تبطئ العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، رسوم متحركة ووسائط متعددة؛ ثم أعطِ تقييمًا تقريبيًا للتعقيد لتحديد نقاط الاختناق المحتملة في الأداء.