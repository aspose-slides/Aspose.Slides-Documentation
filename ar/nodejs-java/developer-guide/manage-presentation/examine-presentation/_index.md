---
title: فحص العرض التقديمي
type: docs
weight: 30
url: /ar/nodejs-java/examine-presentation/
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
- JavaScript
- Node
description: "قراءة وتعديل خصائص عرض PowerPoint التقديمي في Node"
---

Aspose.Slides for Node.js via Java يسمح لك بفحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="معلومات" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) and [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون عليه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود JavaScript:
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```


## **الحصول على خصائص العرض التقديمي**

يعرض لك هذا الكود JavaScript كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```


قد ترغب في الاطلاع على [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) class.

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يظهر لك مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:
```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المتغيرة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفراً](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محمياً من الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محمياً بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وأيها؟**

ابحث عن [معلومات الخطوط المضمَّنة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعلياً عبر المحتوى](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) لتحديد أي الخطوط حيوية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

تجول في [مجموعة الشرائح](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) وتفقد علامة [الرؤية](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم شريحة مخصص واتجاه، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslidesize/) الحالي والاتجاه مع الإعدادات المسبقة القياسية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. تجول عبر جميع [المخططات](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)، تحقق من [مصدر البيانات](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) الخاص بها، وسجل ما إذا كانت البيانات داخلية أو مبنية على روابط، بما في ذلك أي روابط معطلة.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تُبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن الصور الكبيرة، الشفافية، الظلال، الرسوم المتحركة، والوسائط المتعددة؛ ثم إعطِ درجة تعقيد تقريبية لتحديد نقاط الأداء المحتملة.