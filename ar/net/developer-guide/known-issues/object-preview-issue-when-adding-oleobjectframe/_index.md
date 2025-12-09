---
title: مشكلة معاينة الكائن عند إضافة OleObjectFrame
linktitle: مشكلة كائن OLE
type: docs
weight: 10
url: /ar/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة المعاينة
- كائن مدمج
- ملف مدمج
- تغيير الكائن
- معاينة الكائن
- عرض تقديمي
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "تعرف على سبب ظهور EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides لـ .NET وكيفية إصلاح مشكلات المعاينة في عروض PPT، PPTX و ODP."
---

## **المقدمة**

باستخدام Aspose.Slides for .NET، عند إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى شريحة، تظهر رسالة “EMBEDDED OLE OBJECT” على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

لمزيد من المعلومات حول التعامل مع كائنات OLE، راجع [إدارة OLE](/slides/ar/net/manage-ole/). 

## **الشرح والحل**

يعرض Aspose.Slides رسالة “EMBEDDED OLE OBJECT” لإبلاغك بأنه تم تعديل كائن OLE ويجب تحديث صورة المعاينة.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى شريحة (للتفاصيل، راجع مقالة “إدارة OLE”) ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا أردت التحقق والتأكد من أن كائن OLE قد أُضيف إلى الشريحة، عليك النقر مزدوجاً على رسالة “EMBEDDED OLE OBJECT”، أو يمكنك النقر بزر الفأرة الأيمن عليها واختيار **كائن > تحرير**.

![كائن OLE > تحرير](OLE_object_edit.png)

يفتح PowerPoint بعد ذلك كائن OLE المدمج.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتفظ برسالة “EMBEDDED OLE OBJECT”. بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة “EMBEDDED OLE OBJECT” بالصورة الفعلية لكائن OLE. 

![معاينة كائن OLE](OLE_object_preview.png)

الآن قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، وعند فتحه مرة أخرى، لن ترى رسالة “EMBEDDED OLE OBJECT”. 

## **حلول أخرى**

### **الحل 1: استبدال رسالة "Embedded OLE Object" بصورة**

إذا كنت لا تريد إزالة رسالة “EMBEDDED OLE OBJECT” بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بالصورة المفضلة للمعاينة. تُظهر الأسطر التالية عملية ذلك:
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


تتحول الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE جديدة](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لبرنامج PowerPoint**

يمكنك أيضاً إنشاء إضافة لبرنامج Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.