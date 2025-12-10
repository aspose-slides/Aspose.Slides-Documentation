---
title: استخراج كائنات الفلاش من العروض التقديمية في C++
linktitle: فلاش
type: docs
weight: 10
url: /ar/cpp/flash/
keywords:
- استخراج الفلاش
- كائن الفلاش
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية استخراج كائنات الفلاش من شرائح PowerPoint و OpenDocument في C++ باستخدام Aspose.Slides، مع أمثلة شفرة كاملة وأفضل الممارسات."
---

## **استخراج كائنات الفلاش من العروض التقديمية**
Aspose.Slides for C++ يوفر آلية لاستخراج كائنات الفلاش من العرض التقديمي. يمكنك الوصول إلى عنصر التحكم بالفلاش بالاسم واستخراجه من العرض وتخزين بيانات كائن SWF.
``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```


## **الأسئلة الشائعة**

**ما صيغ العروض التقديمية التي يتم دعمها عند استخراج محتوى الفلاش؟**

[Aspose.Slides يدعم](/slides/ar/cpp/supported-file-formats/) صيغ PowerPoint الرئيسية مثل PPT و PPTX، لأنه يمكنه تحميل هذه الحاويات والوصول إلى تحكماتها، بما في ذلك عناصر ActiveX المتعلقة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 مع الحفاظ على تفاعلية الفلاش؟**

لا. Aspose.Slides لا ينفّذ محتوى SWF ولا يحول تفاعليته. بينما يدعم التصدير إلى [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/ar/cpp/export-to-html5/)، لن يتم تشغيل الفلاش في المتصفحات الحديثة بسبب انتهاء الدعم. المسار الموصى به هو استبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل تقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة عرض تقديمي؟**

لا. Aspose.Slides تتعامل مع الفلاش كبيانات ثنائية مضمّنة في الملف ولا تنفّذ محتوى SWF أثناء المعالجة.

**كيف يجب أن أتعامل مع العروض التقديمية التي تتضمن فلاشًا إلى جانب ملفات مضمّنة أخرى عبر OLE؟**

Aspose.Slides يدعم [استخراج كائنات OLE المضمّنة](/slides/ar/cpp/manage-ole/)، بحيث يمكنك معالجة جميع المحتويات المضمّنة ذات الصلة في خطوة واحدة، مع معالجة تحكمات الفلاش والوثائق المضمّنة عبر OLE الأخرى معًا.