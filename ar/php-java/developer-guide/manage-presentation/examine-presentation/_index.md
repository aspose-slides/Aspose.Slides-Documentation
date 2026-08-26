---
title: استرجاع وتحديث معلومات العرض التقديمي بلغة PHP
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة PHP للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

تظهر هذه المقالة كيفية فحص معلومات العرض التقديمي في Aspose.Slides. توضح كيفية تحديد تنسيق العرض الحالي دون تحميل الملف بالكامل، قراءة خصائص المستند الخاصة به، وتحديث تلك الخصائص عند الحاجة.

تستند الأمثلة إلى واجهات برمجة التطبيقات [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/) وتظهر عمليات شائعة للعمل مع بيانات التعريف الخاصة بالعرض التقديمي.

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون فيه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض دون تحميله. انظر إلى هذا الكود PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **الحصول على خصائص العرض التقديمي**

يعرض لك هذا الكود PHP كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

قد ترغب في رؤية [الخصائص ضمن فئة DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **تحديث خصائص العرض التقديمي**

يوفر Aspose.Slides طريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) التي تسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفرض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يظهر لك مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وخصائص الأمان الخاصة به، قد تجد هذه الروابط مفيدة:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/php-java/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/php-java/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وأيها هي؟**

ابحث عن [معلومات الخطوط المدمجة](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getfonts/) لتحديد الخطوط الضرورية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

قم بالتكرار عبر [مجموعة الشرائح](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/) وتفقد علامة [المرئية لكل شريحة](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/gethidden/) .

**هل يمكنني اكتشاف ما إذا كان يتم استخدام حجم واتجاه شريحة مخصص، وما إذا كان يختلف عن الإعدادات الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getslidesize/) الحالي والاتجاه مع القيم المسبقة القياسية؛ هذا يساعد في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/)، تحقق من [مصدر البيانات](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/getdatasourcetype/) الخاص بها، وسجل ما إذا كانت البيانات داخلية أو مرتبطة بروابط، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احصر عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، رسوم متحركة، ووسائط متعددة؛ اعطِ تقديرًا تقريبيًا للتعقيد لتحديد النقاط المحتملة لأداء ضعيف.