---
title: مشكلة معاينة الكائن عند إضافة OleObjectFrame
linktitle: مشكلة كائن OLE
type: docs
weight: 10
url: /ar/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة المعاينة
- تضمين كائن
- تضمين ملف
- تغيير الكائن
- معاينة الكائن
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على سبب ظهور EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides لـ Node.js وكيفية إصلاح مشاكل المعاينة في عروض PPT و PPTX و ODP."
---
## **المقدمة**

باستخدام Aspose.Slides for Java، عندما تقوم بإضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/oleobjectframe/) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست عطلًا.

لمزيد من المعلومات حول التعامل مع كائنات OLE، راجع [Manage OLE](/slides/ar/nodejs-java/manage-ole/).

## **الشرح والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإعلامك بأنه تم تعديل كائن OLE ويجب تحديث صورة المعاينة.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/oleobjectframe/) إلى شريحة (لمزيد من التفاصيل، راجع مقالة "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا أردت التحقق والتأكد من أن كائن OLE الخاص بك قد أضيف إلى الشريحة، عليك النقر مزدوجًا على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الماوس الأيمن عليها واختيار **Object > Edit**.

![كائن OLE > تعديل](OLE_object_edit.png)

بعد ذلك يفتح PowerPoint كائن OLE المدمج.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتوي على رسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عندما تفتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT".

## **حلول أخرى**

### **الحل 1: استبدال رسالة "Embedded OLE Object" بصورة**

إذا كنت لا تريد إزالة رسالة "EMBEDDED OLE OBJECT" عن طريق فتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. توضح الأسطر التالية من الشيفرة العملية:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // إضافة صورة إلى موارد العرض التقديمي.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // تعيين عنوان والصورة لمعاينة كائن OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

ستتغير الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE الجديدة](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لـ PowerPoint**

يمكنك أيضًا إنشاء إضافة لبرنامج Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عندما تفتح العروض التقديمية في البرنامج.