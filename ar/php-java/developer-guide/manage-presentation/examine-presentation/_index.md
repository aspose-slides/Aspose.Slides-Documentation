---
title: فحص العرض التقديمي
type: docs
weight: 30
url: /php-java/examine-presentation/
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
- PHP
- Java
description: "قراءة وتعديل خصائص العرض التقديمي PowerPoint في PHP عبر Java"
---

يتيح لك Aspose.Slides لـ PHP عبر Java فحص عرض تقديمي لاكتشاف خصائصه وفهم سلوكه.

{{% alert title="معلومات" color="info" %}} 

تحتوي فصول [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) و [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **تحقق من صيغة العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في اكتشاف الصيغة (PPT، PPTX، ODP، وغيرها) الخاصة بالعرض التقديمي في الوقت الحالي.

يمكنك التحقق من صيغة العرض التقديمي دون تحميل العرض التقديمي. انظر إلى كود PHP هذا:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **الحصول على خصائص العرض التقديمي**

يعرض لك كود PHP هذا كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

قد ترغب في رؤية [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **تحديث خصائص العرض التقديمي**

يوفر Aspose.Slides أسلوب [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) الذي يسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض تقديمي PowerPoint مع خصائص الوثيقة الموضحة أدناه.

![الخصائص الأصلية لوثيقة العرض التقديمي PowerPoint](input_properties.png)

يوضح لك هذا المثال البرمجي كيفية تحرير بعض خصائص العرض التقديمي:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("عنواني");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

تظهر نتائج تغيير خصائص الوثيقة أدناه.

![الخصائص المعدلة لوثيقة العرض التقديمي PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وخصائص الأمان الخاصة به، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفراً](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محمي بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).