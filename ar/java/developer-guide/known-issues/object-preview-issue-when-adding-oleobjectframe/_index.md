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
description: "تعلم لماذا يظهر EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides for Java وكيفية إصلاح مشاكل المعاينة في عروض PPT و PPTX و ODP."
---
## **المقدمة**

باستخدام Aspose.Slides for Java، عند إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/oleobjectframe/) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأً.

لمزيد من المعلومات حول العمل مع كائنات OLE، راجع [Manage OLE](/slides/ar/java/manage-ole/). 

## **الشرح والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإعلامك بأنه تم تعديل كائن OLE ويجب تحديث صورة المعاينة. 

على سبيل المثال، إذا قمت بإضافة مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/oleobjectframe/) إلى شريحة (للتفاصيل، راجع مقالة "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، ستظهر الصورة التالية على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا أردت التحقق والتأكيد من أن كائن OLE قد أُضيف إلى الشريحة، عليك النقر مزدوجهً على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الفأرة الأيمن واختيار **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

ثم يفتح PowerPoint كائن OLE المضمن.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تعرض رسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE. 

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT". 

## **حل آخر**

إذا لم ترغب في إزالة رسالة "EMBEDDED OLE OBJECT" بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. توضح السطور البرمجية التالية العملية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // أضف صورة إلى موارد العرض التقديمي.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // اضبط عنوانًا والصورة لمعاينة كائن OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

ثم تتغير الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE الجديدة](OLE_object_new_image.png)