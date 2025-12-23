---
title: استرجاع وتحديث معلومات العرض التقديمي في PHP
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
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---

Aspose.Slides for PHP عبر Java يسمح لك بفحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="Info" color="info" %}} 

تحتوي الفئات [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) و [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) على الخصائص والطرق المستخدمة في العمليات هنا.

{{% /alert %}} 

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة التنسيق (PPT، PPTX، ODP وغيرها) الذي يكون فيه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. شاهد هذا الكود PHP:
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


قد ترغب في رؤية [الخصائص الموجودة في DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) الفئة.

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) التي تسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![الخصائص الأصلية للمستند في عرض PowerPoint](input_properties.png)

يعرض لك مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:
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

![الخصائص المتغيرة للمستند في عرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وسماته الأمنية، قد تجد الروابط التالية مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفرًا](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا للكتابة (قراءة فقط)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وأيها؟**

ابحث عن [معلومات الخطوط المضمنة](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض التقديمي، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) لتحديد الخطوط الحرجة للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

استعرض مجموعة [slide collection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) وتفحص [visibility flag](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم واتجاه شريحة مخصصين، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. قارن [slide size](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) الحالي والاتجاه مع الإعدادات المسبقة القياسية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)، تحقق من [data source](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)، ولاحظ ما إذا كان البيانات داخلية أو مرتبطة، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، حركات، ووسائط متعددة؛ قم بتعيين درجة تعقيد تقريبية لتحديد نقاط الاختناق المحتملة في الأداء.