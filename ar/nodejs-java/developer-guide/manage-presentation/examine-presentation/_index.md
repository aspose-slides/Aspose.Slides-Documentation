---
title: استرجاع وتحديث معلومات العرض التقديمي في JavaScript
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام JavaScript للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

توضح هذه المقالة كيفية فحص معلومات العرض التقديمي في Aspose.Slides. تشرح كيفية تحديد تنسيق العرض التقديمي الحالي دون تحميل الملف بالكامل، قراءة خصائص المستند الخاصة به، وتحديث تلك الخصائص عند الحاجة.

تستند الأمثلة إلى واجهات برمجة التطبيقات [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/) وتوضح العمليات النموذجية للعمل مع بيانات تعريف العرض التقديمي.

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة أي تنسيق (PPT، PPTX، ODP، وغيرها) يكون العرض التقديمي فيه في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الكود JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

قد ترغب في الاطلاع على [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يعرض لك مثال الشيفرة هذا كيفية تعديل بعض خصائص العرض التقديمي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وسمات الأمان الخاصة به، قد تجد هذه الروابط مفيدة:

- [العروض التقديمية المحمية بكلمة مرور](/slides/ar/nodejs-java/password-protected-presentation/)
- [العروض التقديمية المحمية ضد الكتابة](/slides/ar/nodejs-java/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمّنة وأيها؟**

ابحث عن [معلومات الخطوط المضمّنة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض التقديمي، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getfonts/) لتحديد الخطوط الضرورية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

قم بالتكرار عبر [مجموعة الشرائح](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidecollection/) وتفقد علامة [الرؤية](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/gethidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم وشكل مخصص للشرائح، وما إذا كان يختلفان عن القيم الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslidesize/) الحالي واتجاهها مع الإعدادات المسبقة القياسية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/)، تحقق من [مصدر البيانات](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) الخاص بها، وسجل ما إذا كانت البيانات داخلية أو مرتبطة بروابط، بما في ذلك أي روابط معطلة.

**كيف يمكنني تقييم الشرائح «الثقيلة» التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن الصور الكبيرة، الشفافية، الظلال، الرسوم المتحركة، والوسائط المتعددة؛ ثم عيّن درجة تعقيد تقريبية لتحديد نقاط الضغط المحتملة على الأداء.