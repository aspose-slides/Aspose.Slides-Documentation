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
description: "تعرف على سبب ظهور EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides لـ .NET وكيفية إصلاح مشكلات المعاينة في عروض PPT و PPTX و ODP."
---

## **المقدمة**

باستخدام Aspose.Slides for .NET، عند إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

لمزيد من المعلومات حول العمل مع كائنات OLE، راجع [Manage OLE](/slides/ar/net/manage-ole/).

## **الشرح والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإعلامك بأنه تم تغيير كائن OLE وأنه يجب تحديث صورة المعاينة.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى شريحة (لمزيد من التفاصيل، راجع مقالة "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا كنت تريد التحقق من إضافة كائن OLE إلى الشريحة، عليك النقر المزدوج على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الماوس الأيمن عليها واختيار **Object > Edit**.

![كائن OLE > تعديل](OLE_object_edit.png)

ثم يقوم PowerPoint بفتح كائن OLE المدمج.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تعرض رسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT".

## **حلول أخرى**

### **الحل 1: استبدال رسالة "Embedded OLE Object" بصورة**

إذا لم ترغب في إزالة رسالة "EMBEDDED OLE OBJECT" عن طريق فتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة التي تفضلها. توضح الأسطر البرمجية التالية العملية:
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// إضافة صورة إلى موارد العرض التقديمي.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// تحديد عنوان والصورة لمعاينة كائن OLE.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


ستتغير الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE جديد](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لبرنامج PowerPoint**

يمكنك أيضًا إنشاء إضافة لبرنامج Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.