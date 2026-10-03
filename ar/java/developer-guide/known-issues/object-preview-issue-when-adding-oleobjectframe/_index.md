---
title: عنصر نائب للمعاينة عند إضافة OleObjectFrame
linktitle: عنصر نائب للمعاينة OLE
type: docs
weight: 10
url: /ar/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة في المعاينة
- عنصر نائب للمعاينة
- حسب التصميم
- كائن مضمّن
- ملف مضمّن
- تم تغيير الكائن
- معاينة الكائن
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "لماذا يُظهر كائن OLE يُضاف باستخدام Aspose.Slides for Java عنصرًا نائبًا EMBEDDED OLE OBJECT حتى يتم تحديث معاينته، وكيفية تعيين صورة معاينة خاصة بك."
---
## **المقدمة**

باستخدام Aspose.Slides for Java، عند إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/oleobjectframe/) إلى شريحة، يتم عرض رسالة “EMBEDDED OLE OBJECT” على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

لمزيد من المعلومات حول التعامل مع كائنات OLE، راجع [إدارة OLE](/slides/ar/java/manage-ole/).

## **التوضيح والحل**

يعرض Aspose.Slides رسالة “EMBEDDED OLE OBJECT” لإعلامك بأن كائن OLE قد تم تغييره ويجب تحديث صورة المعاينة.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/oleobjectframe/) إلى شريحة (للمزيد من التفاصيل، راجع مقالة “إدارة OLE”) ثم فتحت العرض التقديمي في Microsoft PowerPoint، ستظهر هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا أردت التحقق والتأكيد أن كائن OLE قد أضيف إلى الشريحة، عليك النقر مزدوجًا على رسالة “EMBEDDED OLE OBJECT”، أو يمكنك النقر بزر الفأرة الأيمن عليها واختيار **كائن > تحرير**.

![كائن OLE > تحرير](OLE_object_edit.png)

ثم يفتح PowerPoint كائن OLE المضمن.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتفظ برسالة “EMBEDDED OLE OBJECT”. بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة “EMBEDDED OLE OBJECT” بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عندما تفتح العرض مرة أخرى، لن ترى رسالة “EMBEDDED OLE OBJECT”.

## **حل آخر**

إذا لم ترغب في إزالة رسالة “EMBEDDED OLE OBJECT” بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة التي تفضلها. توضح الأسطر البرمجية التالية العملية. تفترض أن الشكل الأول على الشريحة الأولى من *embeddedOLE.pptx* هو إطار كائن OLE وأن *myImage.png* يحتوي على الصورة التي تريد عرضها، وتقوم بحفظ النتيجة كـ *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // أضف صورة إلى موارد العرض التقديمي.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // تعيين الصورة لمعاينة كائن OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تتحول الشريحة التي تحتوي على `OleObjectFrame` إلى ما يلي:

![صورة كائن OLE جديدة](OLE_object_new_image.png)