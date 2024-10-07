---
title: فلاش
type: docs
weight: 10
url: /php-java/flash/
description: استخراج كائنات الفلاش من عرض PowerPoint باستخدام PHP
---

## **استخراج كائنات الفلاش من العرض**

توفر Aspose.Slides لـ PHP عبر Java وسيلة لاستخراج كائنات الفلاش من عرض. يمكنك الوصول إلى عنصر التحكم في الفلاش بالاسم واستخراجه من العرض بما في ذلك تخزين بيانات كائن SWF.

```php
  # إنشاء كائن من فئة Presentation التي تمثل PPTX
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```