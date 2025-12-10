---
title: استخراج كائنات الفلاش من العروض التقديمية في .NET
linktitle: فلاش
type: docs
weight: 10
url: /ar/net/flash/
keywords:
- استخراج الفلاش
- كائن فلاش
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية استخراج كائنات الفلاش من شرائح PowerPoint و OpenDocument في .NET باستخدام Aspose.Slides، مع أمثلة شفرة C# كاملة وأفضل الممارسات."
---

## **استخراج كائنات الفلاش من العروض التقديمية**
Aspose.Slides for .NET يوفر إمكانية استخراج كائنات الفلاش من العرض التقديمي. يمكنك الوصول إلى عنصر التحكم الفلاش بالاسم واستخراجه من العرض التقديمي بما في ذلك تخزين بيانات كائن SWF.
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


## **الأسئلة الشائعة**

**ما صيغ العروض التقديمية المدعومة عند استخراج محتوى الفلاش؟**

[يدعم Aspose.Slides](/slides/ar/net/supported-file-formats/) صيغ PowerPoint الرئيسية مثل PPT و PPTX، حيث يمكنه تحميل هذه الحاويات والوصول إلى عناصر التحكم فيها، بما في ذلك عناصر ActiveX المتعلقة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 والحفاظ على التفاعل الفلاشي؟**

لا. لا يقوم Aspose.Slides بتنفيذ محتوى SWF أو تحويل تفاعله. بينما يتم دعم التصدير إلى [HTML](/slides/ar/net/convert-powerpoint-to-html/)/[HTML5](/slides/ar/net/export-to-html5/)، لن يتم تشغيل الفلاش في المتصفحات الحديثة بسبب انتهاء الدعم. المسار الموصى به هو استبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل يقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة عرض تقديمي؟**

لا. يتعامل Aspose.Slides مع الفلاش كبيانات ثنائية مضمَّنة في الملف ولا يقوم بتنفيذ محتوى SWF أثناء المعالجة.

**كيفية التعامل مع العروض التي تتضمن فلاش إلى جانب ملفات مضمَّنة أخرى عبر OLE؟**

يدعم Aspose.Slides [استخراج كائنات OLE المضمَّنة](/slides/ar/net/manage-ole/)، بحيث يمكنك معالجة جميع المحتويات المضمَّنة ذات الصلة في خطوة واحدة، والتعامل مع عناصر التحكم الفلاشية والوثائق الأخرى المضمَّنة عبر OLE معًا.