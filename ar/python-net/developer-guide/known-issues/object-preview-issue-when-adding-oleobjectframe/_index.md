---
title: "مشكلة معاينة الكائن عند إضافة OleObjectFrame"
linktitle: "مشكلة كائن OLE"
type: docs
weight: 10
url: /ar/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة معاينة
- كائن مدمج
- ملف مدمج
- تم تعديل الكائن
- معاينة الكائن
- عرض تقديمي
- PowerPoint
- Python
- Aspose.Slides
description: "تعرّف على سبب ظهور رسالة EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides للغة Python وكيفية إصلاح مشاكل المعاينة في عروض PPT و PPTX و ODP."
---

## **المقدمة**

باستخدام Aspose.Slides للغة Python عبر .NET، عند إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خطأ.

لمزيد من المعلومات حول التعامل مع كائنات OLE، راجع [Manage OLE](/slides/ar/python-net/manage-ole/).

## **الشرح والحل**

تقوم Aspose.Slides بعرض رسالة "EMBEDDED OLE OBJECT" لإعلامك بأن كائن OLE قد تم تغييره ويجب تحديث صورة المعاينة.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى شريحة (لمزيد من التفاصيل، راجع مقال "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![OLE object message](OLE_object_message.png)

إذا كنت تريد التحقق والتأكد من أن كائن OLE الخاص بك تم إضافته إلى الشريحة، عليك النقر مزدوجًا على رسالة "EMBEDDED OLE OBJECT"، أو يمكنك النقر بزر الماوس الأيمن عليها واختيار **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

ثم يفتح PowerPoint كائن OLE المضمّن.

![OLE object data](OLE_object_data.png)

قد تحتفظ الشريحة برسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![OLE object preview](OLE_object_preview.png)

الآن، قد ترغب في حفظ عرضك التقديمي لضمان تحديث صورة كائن OLE بشكل صحيح. بهذه الطريقة، بعد حفظ العرض التقديمي، عند فتحه مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT".

## **حلول أخرى**

### **الحل 1: استبدال رسالة "Embedded OLE Object" بصورة**

إذا كنت لا تريد إزالة رسالة "EMBEDDED OLE OBJECT" بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. توضح سطور الشيفرة التالية العملية:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # إضافة صورة إلى موارد العرض التقديمي.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # تعيين عنوان وصورة معاينة كائن OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


الشريحة التي تحتوي على `OleObjectFrame` تتغير إلى ما يلي:

![New OLE object image](OLE_object_new_image.png)

### **الحل 2: إنشاء إضافة لبرنامج PowerPoint**

يمكنك أيضًا إنشاء إضافة لبرنامج Microsoft PowerPoint تقوم بتحديث جميع كائنات OLE عند فتح العروض التقديمية في البرنامج.