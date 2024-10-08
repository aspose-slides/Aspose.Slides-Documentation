---
title: تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint
type: docs
weight: 10
url: /ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **حول تحديث كائنات OLE تلقائيًا**
أحد الأسئلة الأكثر شيوعًا التي يطرحها عملاء Aspose.Slides لـ .NET هو كيفية إنشاء أو تغيير المخططات القابلة للتحرير أو أي كائنات OLE أخرى وجعلها تُحدث تلقائيًا عند فتح العرض التقديمي. للأسف، PowerPoint لا يدعم أي ماكرو تلقائي، المتاحة في Excel وWord. الوحيدان المتاحان هما ماكرو Auto_Open وAuto_Close. ومع ذلك، فإن تلك تعمل تلقائيًا فقط من إضافة. هذه النصيحة الفنية القصيرة توضح كيفية تحقيق ذلك.

أولاً، هناك عدة إضافات مجانية تضيف ميزة ماكرو Auto_Open إلى PowerPoint مثل [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) و[Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

بعد تثبيت مثل هذه الإضافة، ما عليك سوى إضافة ماكرو Auto_Open() (OnPresentationOpen() في حالة "Event Generator") إلى عرضك التقديمي النموذجي كما هو موضح أدناه:

```c#
public void Auto_Open()
{
    Shape oShape;
    Slide oSlide;
    object oGraph;

    // Loop through each slide in the presentation.
    foreach (var oSlide in ActivePresentation.Slides)
    {

        // Loop through all the shapes on the current slide.
        foreach (var oShape in oSlide.Shapes)
        {

            // Check whether the shape is an OLE object.
            if (oShape.Type == msoEmbeddedOLEObject)
            {

                // Found an OLE object; obtain object reference, and then update.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Now, quit out of the OLE server program. This frees
                // memory, and prevents any problems. Also, set oObject equal
                // to Nothing to release the object.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

{{% alert color="primary" %}} 

أية تغييرات تُجرى على كائنات OLE باستخدام Aspose.Slides لـ .NET، ستُحدث تلقائيًا عند فتح PowerPoint العرض التقديمي. إذا كان لديك العديد من كائنات OLE في عرض تقديمي معين ولا ترغب في تحديثها جميعًا، ما عليك سوى إضافة علامة مخصصة إلى الأشكال التي تحتاج إلى معالجتها والتحقق منها في الماكرو.

{{% /alert %}}