---
title: عنـــنـيـن لامـنـا لــمــعـاـيـنـة الكـنـنـج عــنـد إضـاـفـة OleObjectFrame
linktitle: عنــنـِيـن لــمعــاييـنـه OLE
type: docs
weight: 10
url: /ar/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة المعاينة
- عنصر نائب للمعاينة
- حسب التصميم
- كائن مضمّن
- ملف مضمّن
- تغيير الكائن
- معاينة الكائن
- عرض تقديمي
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "لماذا يظهر كائن OLE المضاف باستخدام Aspose.Slides for .NET عنصرًا نائبًا باسم EMBEDDED OLE OBJECT حتى يتم تحديث معاينته، وكيفية تعيين صورة المعاينة الخاصة بك."
---
## **المقدمة**

باستخدام Aspose.Slides for .NET، عند إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

للمزيد من المعلومات حول العمل مع كائنات OLE، راجع [Manage OLE](/slides/ar/net/manage-ole/).

## **الشرح والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإعلامك بأنه تم تعديل كائن OLE وأنه يجب تحديث صورة المعاينة.

على سبيل المثال، إذا قمت بإضافة مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) إلى شريحة (للمزيد من التفاصيل، راجع مقالة "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا أردت التحقق والتأكيد على أن كائن OLE الخاص بك تم إضافته إلى الشريحة، عليك النقر نقراً مزدوجاً على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الماوس الأيمن عليها واختيار **Object > Edit**.

![كائن OLE > تحرير](OLE_object_edit.png)

ثم يفتح PowerPoint كائن OLE المضمن.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتوي على رسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT".

## **حلول أخرى**

### **الحل 1: استبدال رسالة "EMBEDDED OLE OBJECT" بصورة**

إذا لم ترغب في إزالة رسالة "EMBEDDED OLE OBJECT" بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. تسلط هذه الأسطر البرمجية الضوء على العملية:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// إضافة صورة إلى موارد العرض التقديمي.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// تعيين الصورة لمعاينة كائن OLE.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

ثم تتغير الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE الجديد](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لبرنامج PowerPoint**

يمكنك أيضًا إنشاء إضافة لبرنامج Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.