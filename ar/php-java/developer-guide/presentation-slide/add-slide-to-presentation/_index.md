---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /php-java/add-slide-to-presentation/
---

## **إضافة شريحة إلى العرض التقديمي**
{{% alert color="primary" %}} 

قبل الحديث عن إضافة شرائح إلى ملفات العرض التقديمي، دعنا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي على **الشريحة الرئيسية / التخطيط** وشرائح **عادية** أخرى. وهذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة أو أكثر على الأقل. من المهم معرفة أن ملفات العرض التقديمي التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides لـ PHP عبر Java. تحتوي كل شريحة على معرّف فريد وجميع الشرائح العادية مرتبة وفقًا لترتيب محدد بواسطة الفهرس الذي يبدأ من الصفر.

{{% /alert %}} 

تسمح Aspose.Slides لـ PHP عبر Java للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
- إنشاء مثيل من [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) class عن طريق إعداد مرجع إلى خاصية [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (مجموعة من كائنات Slide المحتوى) المعروضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة الشرائح المحتوى عن طريق استدعاء [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) الطرق المعروضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- القيام ببعض العمل مع الشريحة الفارغة المضافة حديثًا.
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).

```php
  # إنشاء مثيل من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation();
  try {
    # إنشاء مثيل من فئة SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # إضافة شريحة فارغة إلى مجموعة الشرائح
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # القيام ببعض العمل على الشريحة المضافة حديثًا
    # حفظ ملف PPTX على القرص
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```