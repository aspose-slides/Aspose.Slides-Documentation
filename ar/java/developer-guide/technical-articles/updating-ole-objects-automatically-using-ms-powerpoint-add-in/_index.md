---
title: تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint
type: docs
weight: 10
url: /ar/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- كائن OLE
- تحديث OLE
- تلقائيًا
- إضافة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية تحديث مخططات OLE وكائناتها تلقائيًا في PowerPoint باستخدام إضافة و Aspose.Slides for Java، مع عرض أمثلة عملية ونصائح تحسين."
---

## **تحديث كائنات OLE تلقائيًا**

إحدى أكثر الأسئلة شيوعًا التي يطرحها عملاء Aspose.Slides for Java هي كيفية إنشاء أو تعديل المخططات القابلة للتحرير (أو كائنات OLE أخرى) بحيث يتم تحديثها تلقائيًا عند فتح العرض التقديمي. للأسف، لا يدعم PowerPoint الماكروهات الذاتية بنفس الطريقة التي يدعمها Excel وWord. الماكروهات المتاحة فقط هي `Auto_Open` و `Auto_Close`، وهذه تعمل تلقائيًا فقط من خلال إضافة. توضح هذه النصيحة التقنية القصيرة كيفية تحقيق ذلك.

أولاً، هناك عدة إضافات مجانية تضيف ميزة ماكرو Auto_Open إلى PowerPoint، على سبيل المثال [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) و[Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

بعد تثبيت إحدى هذه الإضافات، ما عليك سوى إضافة ماكرو `Auto_Open()` (أو `OnPresentationOpen()` إذا كنت تستخدم Event Generator) إلى عرض القالب الخاص بك كما هو موضح أدناه:
```java
// التكرار عبر كل شريحة في العرض التقديمي.
for (var oSlide : ActivePresentation.Slides) {
    // التكرار عبر جميع الأشكال في الشريحة الحالية.
    for (var oShape : oSlide.Shapes) {
        // التحقق مما إذا كان الشكل كائن OLE.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // تم العثور على كائن OLE. احصل على مرجع الكائن ثم قم بتحديثه.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // الآن، أوقف برنامج خادم OLE.
            // هذا يحرر الذاكرة ويمنع أي مشاكل.
            // أيضًا، اضبط oObject على Nothing لتحرير الكائن.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```


سيتم تحديث أي تغييرات تُجرى على كائنات OLE باستخدام Aspose.Slides for Java تلقائيًا عندما يفتح PowerPoint العرض التقديمي. إذا كان لديك العديد من كائنات OLE ولا تريد تحديثها جميعًا، ما عليك سوى إضافة علامة مخصصة إلى الأشكال التي تريد معالجتها والتحقق منها في الماكرو.