---
title: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /ar/php-java/convert-odp-to-pptx/
---

## **تحويل ODP إلى عرض PPTX/PPT**
تقدم Aspose.Slides لـ PHP عبر Java فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تمثل ملف عرض. يمكن الآن لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الوصول أيضًا إلى ODP من خلال مُنشئ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) عند إنشاء الكائن. يُظهر المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.

```php
// فتح ملف ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # حفظ عرض ODP بتنسيق PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **مثال حي**
يمكنك زيارة [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) التطبيق الويب، الذي تم بناؤه باستخدام **Aspose.Slides API.** يظهر التطبيق كيف يمكن تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.