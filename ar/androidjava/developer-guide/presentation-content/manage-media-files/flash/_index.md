---
title: استخراج كائنات الفلاش من العروض التقديمية على Android
linktitle: فلاش
type: docs
weight: 10
url: /ar/androidjava/flash/
keywords:
- استخراج الفلاش
- كائن الفلاش
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرف على كيفية استخراج كائنات الفلاش من شرائح PowerPoint وOpenDocument باستخدام Java مع Aspose.Slides لنظام Android، مع نماذج شفرة كاملة وأفضل الممارسات."
---

## **استخراج كائنات الفلاش من العروض التقديمية**

Aspose.Slides for Android via Java يوفر وسيلة لاستخراج كائنات الفلاش من العرض التقديمي. يمكنك الوصول إلى عنصر التحكم الفلاش بالاسم واستخراجه من العرض التقديمي بما في ذلك تخزين بيانات كائن SWF.
```java
// إنشاء كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**ما صيغ العروض التقديمية المدعومة عند استخراج محتوى الفلاش؟**

[Aspose.Slides supports](/slides/ar/androidjava/supported-file-formats/) الصيغ الرئيسية لـ PowerPoint مثل PPT و PPTX، حيث يمكنه تحميل هذه الحاويات والوصول إلى عناصر التحكم فيها، بما في ذلك عناصر ActiveX المتعلقة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 والحفاظ على تفاعلية الفلاش؟**

لا. لا يقوم Aspose.Slides بتنفيذ محتوى SWF أو تحويل تفاعليته. بينما يدعم التصدير إلى [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/ar/androidjava/export-to-html5/)، لن يعمل الفلاش في المتصفحات الحديثة بسبب انتهاء الدعم. المسار الموصى به هو استبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل يقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة عرض تقديمي؟**

لا. يعامل Aspose.Slides الفلاش كبيانات ثنائية مدمجة في الملف ولا ينفذ محتوى SWF أثناء المعالجة.

**كيف يجب أن أتعامل مع العروض التقديمية التي تشمل فلاش مع ملفات مدمجة أخرى عبر OLE؟**

يدعم Aspose.Slides [extracting embedded OLE objects](/slides/ar/androidjava/manage-ole/)، بحيث يمكنك معالجة جميع المحتويات المدمجة ذات الصلة في خطوة واحدة، مع التعامل مع عناصر التحكم الفلاش والوثائق المدمجة عبر OLE الأخرى معًا.