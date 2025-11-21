---
title: مشكلة معاينة الكائن عند إضافة OleObjectFrame
linktitle: مشكلة كائن OLE
type: docs
weight: 10
url: /ar/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة المعاينة
- تضمين الكائن
- تضمين الملف
- تغير الكائن
- معاينة الكائن
- عرض تقديمي
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "تعرف على سبب ظهور EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides for .NET وكيفية إصلاح مشاكل المعاينة في عروض PPT و PPTX و ODP."
---

## **مقدمة**

باستخدام Aspose.Slides for .NET، عندما تقوم بإضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

لمزيد من المعلومات حول العمل مع كائنات OLE، راجع [Manage OLE](/slides/ar/net/manage-ole/). 

## **الشرح والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإبلاغك بأنه تم تغيير كائن OLE وأن صورة المعاينة يجب تحديثها. 

على سبيل المثال، إذا قمت بإضافة مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى شريحة (لمزيد من التفاصيل، راجع مقاله "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا كنت تريد التحقق والتأكد من أنه تم إضافة كائن OLE إلى الشريحة، يجب أن تنقر مزدوجًا على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الفأرة الأيمن عليها واختيار خيار **Object > Edit**.

![كائن OLE > تعديل](OLE_object_edit.png)

ثم يفتح PowerPoint كائن OLE المضمن.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتفظ برسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT". 

## **حلول أخرى**

### **الحل 1: استبدال رسالة "Embedded OLE Object" بصورة**

إذا لم ترغب في إزالة رسالة "EMBEDDED OLE OBJECT" بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. تُظهر أسطر الشيفرة التالية العملية:
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


ثم تتغير الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE الجديد](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لـ PowerPoint**

يمكنك أيضًا إنشاء إضافة لبرنامج Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.