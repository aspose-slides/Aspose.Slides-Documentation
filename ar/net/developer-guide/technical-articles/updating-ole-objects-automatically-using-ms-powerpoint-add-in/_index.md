---
title: تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint
type: docs
weight: 10
url: /ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- كائن OLE
- تحديث OLE
- تلقائيًا
- إضافة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية تحديث مخططات OLE وكائناتها تلقائيًا في PowerPoint باستخدام إضافة و Aspose.Slides for .NET، مع أمثلة عملية ونصائح تحسين."
---

## **تحديث كائنات OLE تلقائيًا**

أحد أكثر الأسئلة شيوعًا التي يطرحها عملاء Aspose.Slides for .NET هو كيفية إنشاء أو تعديل المخططات القابلة للتحرير (أو كائنات OLE أخرى) بحيث يتم تحديثها تلقائيًا عند فتح العرض التقديمي. للأسف، لا يدعم PowerPoint الماكروهات التلقائية بنفس الطريقة التي يدعمها Excel وWord. الماكروهات المتاحة الوحيدة هي `Auto_Open` و`Auto_Close`، وهذه تعمل تلقائيًا فقط من خلال إضافة. توضح هذه النصيحة التقنية القصيرة كيفية تحقيق ذلك.

أولاً، هناك عدة إضافات مجانية متاحة تضيف ميزة ماكرو Auto_Open إلى PowerPoint، على سبيل المثال [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) و[Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

بعد تثبيت إحدى هذه الإضافات، قم ببساطة بإضافة ماكرو `Auto_Open()` (أو `OnPresentationOpen()` إذا كنت تستخدم Event Generator) إلى قالب العرض التقديمي كما هو موضح أدناه:
```cs
public void Auto_Open()
{
    // التكرار عبر كل شريحة في العرض التقديمي.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // التكرار عبر جميع الأشكال في الشريحة الحالية.
        foreach (var oShape in oSlide.Shapes)
        {
            // التحقق مما إذا كان الشكل كائن OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // تم العثور على كائن OLE. احصل على مرجع الكائن ثم قم بتحديثه.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // الآن، قم بإغلاق برنامج خادم OLE.
                // هذا يحرر الذاكرة، ويمنع أي مشكلات.
                // أيضًا، عيّن oObject إلى Nothing لتحرير الكائن.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```


أي تغييرات تُجرى على كائنات OLE باستخدام Aspose.Slides for .NET سيتم تحديثها تلقائيًا عندما يفتح PowerPoint العرض التقديمي. إذا كان لديك العديد من كائنات OLE ولا ترغب في تحديثها جميعًا، فقم ببساطة بإضافة علامة مخصصة إلى الأشكال التي تحتاج إلى معالجتها وتحقق منها في الماكرو.