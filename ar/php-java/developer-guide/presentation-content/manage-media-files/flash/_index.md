---
title: استخراج كائنات الفلاش من العروض التقديمية في PHP
linktitle: فلاش
type: docs
weight: 10
url: /ar/php-java/flash/
keywords:
- استخراج فلاش
- كائن فلاش
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية استخراج كائنات الفلاش من شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لـ PHP عبر Java، مع عينات شفرة كاملة وأفضل الممارسات."
---

## **استخراج كائنات الفلاش من العروض التقديمية**

توفر Aspose.Slides لـ PHP عبر Java إمكانية استخراج كائنات الفلاش من عرض تقديمي. يمكنك الوصول إلى عنصر التحكم بالفلاش حسب الاسم واستخراجه من العرض بما في ذلك تخزين بيانات كائن SWF.
```php
  # إنشاء كائن فئة Presentation الذي يمثل ملف PPTX
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


## **الأسئلة المتكررة**

**ما صيغ العروض التقديمية المدعومة عند استخراج محتوى الفلاش؟**

[يدعم Aspose.Slides](/slides/ar/php-java/supported-file-formats/) صيغ PowerPoint الرئيسية مثل PPT و PPTX، لأنه يستطيع تحميل هذه الحاويات والوصول إلى عناصر التحكم فيها، بما في ذلك عناصر ActiveX المتعلقة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 مع الحفاظ على تفاعل الفلاش؟**

لا. لا يقوم Aspose.Slides بتنفيذ محتوى SWF أو تحويل تفاعله. بينما يُدعم التصدير إلى [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/ar/php-java/export-to-html5/)، لن يعمل الفلاش في المتصفحات الحديثة بسبب انتهاء الدعم. يُنصح باستبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل يقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة العرض التقديمي؟**

لا. يتعامل Aspose.Slides مع الفلاش كبيانات ثنائية مدمجة في الملف ولا ينفذ محتوى SWF أثناء المعالجة.

**كيف يجب أن أتعامل مع العروض التقديمية التي تشمل فلاش مع ملفات مدمجة أخرى عبر OLE؟**

يدعم Aspose.Slides [استخراج كائنات OLE المدمجة](/slides/ar/php-java/manage-ole/)، وبالتالي يمكنك معالجة كل المحتوى المدمج المتعلق في خطوة واحدة، مع التعامل مع عناصر التحكم بالفلاش وغيرها من المستندات المدمجة عبر OLE معًا.