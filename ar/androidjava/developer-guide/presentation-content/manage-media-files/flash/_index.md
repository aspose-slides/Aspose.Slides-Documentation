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
description: "تعلم كيفية استخراج كائنات الفلاش من شرائح PowerPoint و OpenDocument باستخدام Java مع Aspose.Slides لنظام Android، مع أمثلة كاملة على الشيفرة وأفضل الممارسات."
---

## **استخراج كائنات الفلاش من العروض التقديمية**

توفر Aspose.Slides لنظام Android عبر Java إمكانية استخراج كائنات الفلاش من العرض التقديمي. يمكنك الوصول إلى عنصر التحكم بالفلاش بالاسم واستخراجه من العرض التقديمي بما في ذلك تخزين بيانات كائن SWF.
```java
// إنشاء فئة Presentation التي تمثل ملف PPTX
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

**ما تنسيقات العروض التقديمية المدعومة عند استخراج محتوى الفلاش؟**

[يدعم Aspose.Slides](/slides/ar/androidjava/supported-file-formats/) تنسيقات PowerPoint الرئيسية مثل PPT و PPTX، حيث يمكنه تحميل هذه الحاويات والوصول إلى عناصر التحكم فيها، بما في ذلك عناصر ActiveX المتعلقة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 والحفاظ على التفاعل الفلاشي؟**

لا. لا يقوم Aspose.Slides بتنفيذ محتوى SWF أو تحويل تفاعله. بينما يتم دعم التصدير إلى [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/ar/androidjava/export-to-html5/)، لن يعمل الفلاش في المتصفحات الحديثة بسبب انتهاء الدعم. المسار الموصى به هو استبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل يقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة العرض التقديمي؟**

لا. يتعامل Aspose.Slides مع الفلاش كبيانات ثنائية مضمَّنة في الملف ولا ينفذ محتوى SWF أثناء المعالجة.

**كيف يجب أن أتعامل مع العروض التقديمية التي تتضمن فلاشًا مع ملفات مضمَّنة أخرى عبر OLE؟**

يدعم Aspose.Slides [استخراج كائنات OLE المضمَّنة](/slides/ar/androidjava/manage-ole/)، بحيث يمكنك معالجة جميع المحتويات المضمَّنة ذات الصلة في خطوة واحدة، ومعالجة عناصر التحكم بالفلاش وغيرها من المستندات المضمَّنة عبر OLE معًا.