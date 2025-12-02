---
title: مشكلة عرض المعاينة عند إضافة OleObjectFrame
linktitle: مشكلة كائن OLE
type: docs
weight: 10
url: /ar/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة المعاينة
- كائن مضمّن
- ملف مضمّن
- تم تغيير الكائن
- معاينة الكائن
- عرض تقديمي
- PowerPoint
- Python
- Aspose.Slides
description: "تعرف على السبب وراء ظهور EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides لـ Python وكيفية إصلاح مشاكل المعاينة في عروض PPT و PPTX و ODP."
---

## **المقدمة**

باستخدام Aspose.Slides for Python عبر .NET، عند إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

لمزيد من المعلومات حول العمل مع كائنات OLE، راجع [إدارة OLE](/slides/ar/python-net/manage-ole/). 

## **الشرح والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإعلامك بأن كائن OLE قد تم تغييره وأنه يجب تحديث صورة المعاينة.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى شريحة (للمزيد من التفاصيل، راجع مقالة "إدارة OLE") ثمفتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

إذا كنت ترغب في التحقق والتأكد من أن كائن OLE قد أُضيف إلى الشريحة، عليك النقر مزدوجًا على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الماوس الأيمن عليها واختيار خيار **Object > Edit**.

![كائن OLE > تحرير](OLE_object_edit.png)

ثم يفتح PowerPoint كائن OLE المضمن.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتفظ برسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

الآن، قد ترغب في حفظ العرض التقديمي للتأكد من تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT". 

## **حلول أخرى**

### **الحل 1: استبدال رسالة "Embedded OLE Object" بصورة**

إذا لم ترغب في إزالة رسالة "EMBEDDED OLE OBJECT" بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. تُظهر أسطر الكود التالية العملية:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # أضف صورة إلى موارد العرض التقديمي.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # ضبط عنوان وصورة معاينة كائن OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


الشريحة التي تحتوي على `OleObjectFrame` تتغير بعدها إلى ما يلي:

![صورة كائن OLE الجديد](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لـ PowerPoint**

يمكنك أيضًا إنشاء إضافة لـ Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.