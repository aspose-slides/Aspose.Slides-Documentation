---
title: مشكلة معاينة الكائن عند إضافة OleObjectFrame
linktitle: مشكلة كائن OLE
type: docs
weight: 10
url: /ar/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة المعاينة
- كائن مدمج
- ملف مدمج
- تغيير الكائن
- معاينة الكائن
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على سبب ظهور EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides for Java وكيفية إصلاح مشاكل المعاينة في عروض PPT و PPTX و ODP."
---

## **المقدمة**

باستخدام Aspose.Slides for Java، عندما تقوم بإضافة [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) إلى شريحة، تظهر رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

لمزيد من المعلومات حول العمل مع كائنات OLE، راجع [Manage OLE](/slides/ar/java/manage-ole/). 

## **التفسير والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإبلاغك بأن كائن OLE قد تم تغييره ويتعين تحديث صورة المعاينة.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) إلى شريحة (للتفاصيل، راجع مقالة "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا أردت التحقق والتأكد من أن كائن OLE قد أُضيف إلى الشريحة، عليك النقر مزدوجًا على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الماوس الأيمن عليها واختيار **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

ثم يفتح PowerPoint كائن OLE المدمج.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتفظ برسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتُستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT". 

## **حلول أخرى**

### **الحل 1: استبدال رسالة "Embedded OLE Object" بصورة**

إذا لم ترغب في إزالة رسالة "EMBEDDED OLE OBJECT" بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. يوضح هذا الجزء من الشيفرة العملية:
```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // إضافة صورة إلى موارد العرض التقديمي.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // تعيين عنوان وصورة لمعاينة كائن OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


ثم تتغير الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE جديدة](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لبرنامج PowerPoint**

يمكنك أيضًا إنشاء إضافة لبرنامج Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.