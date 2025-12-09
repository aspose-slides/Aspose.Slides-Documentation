---
title: استخراج كائنات الفلاش من العروض التقديمية في .NET
linktitle: فلاش
type: docs
weight: 10
url: /ar/net/flash/
keywords:
- استخراج فلاش
- كائن فلاش
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية استخراج كائنات الفلاش من شرائح PowerPoint وOpenDocument في .NET باستخدام Aspose.Slides، مع أمثلة شفرة C# كاملة وأفضل الممارسات."
---

## **استخراج كائنات الفلاش من العرض التقديمي**
توفر Aspose.Slides for .NET إمكانية استخراج كائنات الفلاش من العرض التقديمي. يمكنك الوصول إلى عنصر التحكم بالفلاش بالاسم واستخراجه من العرض التقديمي بما في ذلك تخزين بيانات كائن SWF.
```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```


## **الأسئلة المتكررة**

**ما صيغ العروض التقديمية المدعومة عند استخراج محتوى الفلاش؟**

[Aspose.Slides يدعم](/slides/ar/net/supported-file-formats/) الصيغ الرئيسية لـ PowerPoint مثل PPT و PPTX، حيث يمكنه تحميل هذه الحاويات والوصول إلى عناصر التحكم فيها، بما في ذلك عناصر ActiveX المتعلقة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 والحفاظ على تفاعلية الفلاش؟**

لا. لا تقوم Aspose.Slides بتنفيذ محتوى SWF أو تحويل تفاعليته. بينما يتم دعم التصدير إلى [HTML](/slides/ar/net/convert-powerpoint-to-html/)/[HTML5](/slides/ar/net/export-to-html5/)، لن يعمل الفلاش في المتصفحات الحديثة نظراً لانتهاء الدعم. المسار الموصى به هو استبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل تقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة العرض التقديمي؟**

لا. تتعامل Aspose.Slides مع الفلاش كبيانات ثنائية مدمجة في الملف ولا تنفّذ محتوى SWF أثناء المعالجة.

**كيف ينبغي أن أتعامل مع العروض التقديمية التي تشمل فلاش إلى جانب ملفات مدمجة أخرى عبر OLE؟**

تدعم Aspose.Slides [استخراج كائنات OLE المدمجة](/slides/ar/net/manage-ole/)، بحيث يمكنك معالجة جميع المحتويات المدمجة المتعلقة في خطوة واحدة، مع التعامل مع عناصر التحكم بالفلاش والوثائق المدمجة عبر OLE الأخرى معًا.