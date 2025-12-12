---
title: استرجاع وتحديث معلومات العرض التقديمي على أندرويد
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint و OpenDocument باستخدام Java للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً.
---

Aspose.Slides for Android via Java يسمح لك بفحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="Info" color="info" %}} 
تحتوي الفئتان PresentationInfo و DocumentProperties على الخصائص والطرق المستخدمة في العمليات هنا.
{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون فيه العرض حاليًا.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود Java:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **الحصول على خصائص العرض التقديمي**

يظهر لك هذا الكود Java كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```


قد ترغب في الاطلاع على الخصائص تحت فئة DocumentProperties.

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة PresentationInfo.updateDocumentProperties التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يظهر لك مثال الكود هذا كيفية تعديل بعض خصائص العرض:
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المتغيرة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وسماته الأمنية، قد تجد الروابط التالية مفيدة:

- [التحقق مما إذا كان العرض مُشفّرًا](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض محميًا من الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة المتداولة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وأيها؟**

ابحث عن معلومات الخطوط المدمجة على مستوى العرض التقديمي، ثم قارِن تلك الإدخالات مع مجموعة الخطوط المستخدمة فعليًا عبر المحتوى لتحديد أي الخطوط ضرورية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

استعرض مجموعة الشرائح وتفحَّص علامة الرؤية لكل شريحة.

**هل يمكنني الكشف عما إذا كان يتم استخدام حجم وش_orientation مخصص للشرائح، وما إذا كان يختلف عن الإعدادات الافتراضية؟**

نعم. قارن حجم الشريحة الحالي وتوجيهها مع القيم الافتراضية؛ يساعد ذلك في توقع سلوك الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع المخططات، افحص مصدر بياناتها، وحدد ما إذا كانت البيانات داخلية أو مرتبطة، بما في ذلك الروابط المكسورة.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن الصور الكبيرة، والشفافية، والظلال، والرسوم المتحركة، والوسائط المتعددة؛ ثم أعطِ كل شريحة درجة تعقيد تقريبية لتحديد نقاط الاختناق المحتملة.