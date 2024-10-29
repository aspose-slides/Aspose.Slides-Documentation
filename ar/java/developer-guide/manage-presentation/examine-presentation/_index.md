---
title: فحص العرض التقديمي
type: docs
weight: 30
url: /ar/java/examine-presentation/
keywords:
- PowerPoint
- العرض التقديمي
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص الوثيقة
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- PPTX
- PPT
- Java
description: "قراءة وتعديل خصائص العرض التقديمي في PowerPoint باستخدام Java"
---

يمكنك استخدام Aspose.Slides لـ Java لفحص العرض التقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="معلومات" color="info" %}} 

تحتوي فصول [PresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo) و [DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/) على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة التنسيق (PPT، PPTX، ODP، وغيرها) الذي يتواجد فيه العرض التقديمي في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. انظر إلى هذا الرمز في Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **الحصول على خصائص العرض التقديمي**

يعرض لك هذا الرمز في Java كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

قد ترغب في رؤية [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **تحديث خصائص العرض التقديمي**

يوفر Aspose.Slides طريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفرض أن لدينا عرض تقديمي في PowerPoint مع الخصائص الوثائقية الموضحة أدناه.

![الخصائص الوثائقية الأصلية للعرض التقديمي في PowerPoint](input_properties.png)

يعرض لك هذا المثال من الرمز كيفية تحرير بعض خصائص العرض التقديمي:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("عنواني");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

تظهر نتائج تغيير الخصائص الوثائقية أدناه.

![الخصائص الوثائقية المتغيرة للعرض التقديمي في PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وخصائص الأمان الخاصة به، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفرًا](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا من الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية عرض تقديمي](https://docs.aspose.com/slides/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).