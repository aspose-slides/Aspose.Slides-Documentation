---
title: فحص العرض التقديمي
type: docs
weight: 30
url: /androidjava/examine-presentation/
keywords:
- PowerPoint
- عرض تقديمي
- صيغة العرض التقديمي
- خصائص العرض التقديمي
- خصائص الوثيقة
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- PPTX
- PPT
- أندرويد
- جافا
description: "قراءة وتعديل خصائص عرض PowerPoint في أندرويد عبر جافا"
---

Aspose.Slides لـ أندرويد عبر جافا يتيح لك فحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="معلومات" color="info" %}} 

تحتوي فئة [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) وفئة [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **تحقق من صيغة العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة الصيغة (PPT، PPTX، ODP، وغيرها) التي يوجد بها العرض التقديمي في الوقت الحالي.

يمكنك التحقق من صيغة العرض التقديمي دون تحميل العرض التقديمي. راجع هذا الكود في جافا:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **الحصول على خصائص العرض التقديمي**

هذا الكود في جافا يوضح لك كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

قد ترغب في رؤية [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **تحديث خصائص العرض التقديمي**

يوفر Aspose.Slides الطريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنقل أن لدينا عرض PowerPoint يحتوي على خصائص الوثيقة الموضحة أدناه.

![الخصائص الأصلية للوثيقة الخاصة بالعرض التقديمي PowerPoint](input_properties.png)

هذا المثال من الكود يوضح لك كيفية تعديل بعض خصائص العرض التقديمي:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("عنواني");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

تظهر نتائج تغيير خصائص الوثيقة أدناه.

![الخصائص المعدلة للوثيقة الخاصة بالعرض التقديمي PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وخصائصه الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفراً](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).