---
title: فحص العرض التقديمي
type: docs
weight: 30
url: /net/examine-presentation/
keywords:
- باوربوينت
- عرض تقديمي
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص الوثيقة
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "قراءة وتعديل خصائص عرض باوربوينت التقديمي في C# أو .NET"
---

تسمح لك Aspose.Slides لـ .NET بفحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="معلومات" color="info" %}} 

تحتوي فئات [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) و [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يوجد فيه العرض التقديمي في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميل العرض. راجع هذا كود C#:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **الحصول على خصائص العرض التقديمي**

يظهر لك هذا الكود C# كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

قد ترغب في رؤية [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides طريقة [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنقل أن لدينا عرض تقديمي باوربوينت مع خصائص الوثيقة الموضحة أدناه.

![الخصائص الأصلية لوثيقة العرض التقديمي باوربوينت](input_properties.png)

يوضح لك هذا المثال كيفية تعديل بعض خصائص العرض التقديمي:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "العنوان الخاص بي";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

نتائج تغيير خصائص الوثيقة موضحة أدناه.

![الخصائص المعدلة لوثيقة العرض التقديمي باوربوينت](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وخصائصه الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفراً](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محمي ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محمي بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية عرض تقديمي](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).