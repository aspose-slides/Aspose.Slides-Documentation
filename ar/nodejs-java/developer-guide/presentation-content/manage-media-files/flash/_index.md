---
title: فلاش
type: docs
weight: 10
url: /ar/nodejs-java/flash/
description: استخراج كائنات الفلاش من عرض PowerPoint باستخدام JavaScript
---

## **استخراج كائنات الفلاش من العرض التقديمي**

توفر Aspose.Slides لـ Node.js عبر Java إمكانية استخراج كائنات الفلاش من العرض التقديمي. يمكنك الوصول إلى عنصر التحكم بالفلاش بالاسم واستخراجه من العرض التقديمي بما في ذلك تخزين بيانات كائن SWF.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**ما تنسيقات العروض التقديمية المدعومة عند استخراج محتوى الفلاش؟**

يدعم [Aspose.Slides](/slides/ar/nodejs-java/supported-file-formats/) تنسيقات PowerPoint الرئيسية مثل PPT و PPTX، لأنه يستطيع تحميل هذه الحاويات والوصول إلى عناصر التحكم فيها، بما في ذلك عناصر ActiveX المرتبطة بالفلاش.

**هل يمكنني تحويل عرض تقديمي يحتوي على فلاش إلى HTML5 مع الحفاظ على التفاعل الفلاشي؟**

لا. لا يقوم Aspose.Slides بتنفيذ محتوى SWF أو تحويل تفاعليته. بينما يُدعَم التصدير إلى [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/ar/nodejs-java/export-to-html5/)، فإن الفلاش لن يعمل في المتصفحات الحديثة بسبب انتهاء الدعم. يُنصَح باستبدال الفلاش ببدائل مثل الفيديو أو الرسوم المتحركة HTML5 قبل التصدير.

**من منظور الأمان، هل يقوم Aspose.Slides بتنفيذ ملفات SWF أثناء قراءة العرض التقديمي؟**

لا. يتعامل Aspose.Slides مع الفلاش كبيانات ثنائية مضمَّنة في الملف ولا ينفّذ محتوى SWF أثناء المعالجة.

**كيف يجب أن أتعامل مع العروض التقديمية التي تحتوي على فلاش مع ملفات مضمَّنة أخرى عبر OLE؟**

يدعم Aspose.Slides [استخراج كائنات OLE المضمَّنة](/slides/ar/nodejs-java/manage-ole/)، بحيث يمكنك معالجة جميع المحتويات المضمَّنة ذات الصلة في خطوة واحدة، ومعالجة عناصر تحكم الفلاش وغيرها من المستندات المضمنة عبر OLE معًا.