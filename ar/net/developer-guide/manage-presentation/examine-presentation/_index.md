---
title: استرجاع وتحديث معلومات العرض التقديمي في .NET
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/net/examine-presentation/
keywords:
- تنسيق العرض
- خصائص العرض
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
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام .NET للحصول على رؤى أسرع ومراجعات محتوى أذكى."
---
## **نظرة عامة**

توضح هذه المقالة كيفية فحص معلومات العرض التقديمي في Aspose.Slides. تشرح كيفية تحديد تنسيق العرض التقديمي الحالي دون تحميل الملف بالكامل، قرائة خصائص المستند، وتحديث تلك الخصائص عند الحاجة.

تستند الأمثلة إلى واجهات برمجة التطبيقات [PresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/documentproperties/) وتوضح العمليات الشائعة للتعامل مع بيانات التعريف الخاصة بالعروض التقديمية.

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون عليه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود C#:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **الحصول على خصائص العرض التقديمي**

يظهر لك هذا الكود C# كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

قد ترغب في الاطلاع على [الخصائص ضمن فئة DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/documentproperties/#properties).

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides طريقة [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يعرض مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/net/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/net/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمّنة وما هي الخطوط المضمنة؟**

ابحث عن معلومات [embedded-font](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض التقديمي، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/getfonts/) لتحديد الخطوط الحرجة للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

قم بالتكرار عبر [slide collection](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/) وتفحص علامة [visibility flag](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم وشكل مخصص للشرائح، وما إذا كان يختلف عن الإعدادات الافتراضية؟**

نعم. قارن حجم [slide size](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slidesize/) الحالي والاتجاه مع القيم المسبقة القياسية؛ هذا يساعد على توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [charts](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/)، وتحقق من [data source](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chartdata/datasourcetype/) الخاص بها، ولاحظ ما إذا كانت البيانات داخلية أو مرتبطة بروابط، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم "الشرائح الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

بالنسبة لكل شريحة، احسب عدد الكائنات وابحث عن الصور الكبيرة، والشفافية، والظلال، والرسوم المتحركة، والوسائط المتعددة؛ ثم أعطِ كل شريحة درجة تعقيد تقريبية لتحديد النقاط الساخنة المحتملة للأداء.