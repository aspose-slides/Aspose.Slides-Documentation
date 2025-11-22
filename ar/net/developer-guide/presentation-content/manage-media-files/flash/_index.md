---
title: فلاش
type: docs
weight: 10
url: /ar/net/flash/
keywords: "استخراج الفلاش, عرض باوربوينت, C#, Csharp, Aspose.Slides for .NET"
description: "استخراج كائن الفلاش من عرض باوربوينت باستخدام C# أو .NET"
---

## **استخراج كائنات الفلاش من العرض التقديمي**
يُوفر Aspose.Slides for .NET إمكانية استخراج كائنات الفلاش من العرض التقديمي. يمكنك الوصول إلى عنصر التحكم الفلاش بالاسم واستخراجه من العرض التقديمي بما في ذلك تخزين بيانات كائنات SWF.
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

**ما هي صيغ العروض التقديمية المدعومة عند استخراج محتوى الفلاش؟**

[Aspose.Slides يدعم](/slides/ar/net/supported-file-formats/) الصيغ الرئيسية لبرنامج PowerPoint مثل PPT و PPTX، نظرًا لأنه يمكنه تحميل هذه الحاويات والوصول إلى عناصر التحكم فيها، بما في ذلك عناصر ActiveX المتعلقة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 والحفاظ على تفاعلية الفلاش؟**

لا. لا يقوم Aspose.Slides بتنفيذ محتوى SWF أو تحويل تفاعليته. بينما يدعم التصدير إلى [HTML](/slides/ar/net/convert-powerpoint-to-html/)/[HTML5](/slides/ar/net/export-to-html5/)، لن يعمل الفلاش في المتصفحات الحديثة بسبب انتهاء الدعم. المسار الموصى به هو استبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل يقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة العرض التقديمي؟**

لا. يتعامل Aspose.Slides مع الفلاش كبيانات ثنائية مدمجة في الملف ولا ينفذ محتوى SWF أثناء المعالجة.

**كيف يجب أن أتعامل مع العروض التقديمية التي تشمل فلاش مع ملفات مدمجة أخرى عبر OLE؟**

يدعم Aspose.Slides [استخراج كائنات OLE المدمجة](/slides/ar/net/manage-ole/)، لذا يمكنك معالجة جميع المحتويات المدمجة ذات الصلة في خطوة واحدة، مع التعامل مع عناصر تحكم الفلاش وغيرها من المستندات المدمجة عبر OLE معًا.