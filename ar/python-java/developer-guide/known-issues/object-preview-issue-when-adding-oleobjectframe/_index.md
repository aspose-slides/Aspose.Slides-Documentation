---
title: "مشكلة معاينة الكائن عند إضافة OleObjectFrame"
linktitle: "مشكلة كائن OLE"
type: docs
weight: 10
url: /ar/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشكلة المعاينة
- كائن مدمج
- ملف مدمج
- تغيير الكائن
- معاينة الكائن
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تعرف على سبب ظهور رسالة EMBEDDED OLE OBJECT عند إضافة OleObjectFrame في Aspose.Slides for Python عبر Java وكيفية إصلاح مشاكل المعاينة في عروض PPT و PPTX و ODP."
---
## **المقدمة**

عند استخدام Aspose.Slides for Python via Java لإضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) إلى شريحة، يتم عرض رسالة "EMBEDDED OLE OBJECT" على الشريحة الناتجة. هذه الرسالة مقصودة وليست خللًا.

لمزيد من المعلومات حول العمل مع كائنات OLE، راجع [Manage OLE](/slides/ar/python-java/manage-ole/).

## **الشرح والحل**

يعرض Aspose.Slides رسالة "EMBEDDED OLE OBJECT" لإعلامك بأن كائن OLE قد تم تغييره وأن صورة المعاينة بحاجة إلى التحديث.

على سبيل المثال، إذا أضفت مخطط Microsoft Excel كـ [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) إلى شريحة (لمزيد من التفاصيل، راجع مقالة "Manage OLE") ثم فتحت العرض التقديمي في Microsoft PowerPoint، سترى هذه الصورة على الشريحة:

![رسالة كائن OLE](OLE_object_message.png)

لتأكيد إضافة كائن OLE إلى الشريحة، انقر نقرًا مزدوجًا على رسالة "EMBEDDED OLE OBJECT"، أو انقر بزر الماوس الأيمن عليها واختر **Object > Edit**.

![كائن OLE > تحرير](OLE_object_edit.png)

بعد ذلك يفتح PowerPoint كائن OLE المضمن.

![بيانات كائن OLE](OLE_object_data.png)

قد تظل الشريحة تحتفظ برسالة "EMBEDDED OLE OBJECT". بمجرد النقر على كائن OLE، يتم تحديث معاينة الشريحة وتستبدل رسالة "EMBEDDED OLE OBJECT" بالصورة الفعلية لكائن OLE.

![معاينة كائن OLE](OLE_object_preview.png)

احفظ العرض التقديمي للحفاظ على صورة معاينة كائن OLE المحدثة. عند فتح العرض التقديمي مرة أخرى، لن ترى رسالة "EMBEDDED OLE OBJECT" بعد الآن.

## **حل آخر**

إذا لم ترغب في إزالة رسالة "EMBEDDED OLE OBJECT" بفتح العرض التقديمي في PowerPoint ثم حفظه، يمكنك استبدال الرسالة بصورة المعاينة المفضلة لديك. يوضح الشيفرة التالية العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # إضافة صورة إلى موارد العرض التقديمي.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # تعيين عنوان وصورة لمعاينة كائن OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

بعد ذلك تتغير الشريحة التي تحتوي على [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) إلى ما يلي:

![صورة كائن OLE جديدة](OLE_object_new_image.png)

## **الأسئلة المتكررة**

**لماذا تظهر رسالة "EMBEDDED OLE OBJECT"؟**

تشير الرسالة إلى أن كائن OLE قد تغير وأن صورة المعاينة الخاصة به تحتاج إلى التحديث. هذا السلوك مقصود.

**كيف يمكنني تحديث المعاينة في PowerPoint؟**

انقر نقرًا مزدوجًا على الرسالة أو اختر **Object > Edit** لفتح كائن OLE المضمن. انقر على كائن OLE لتحديث المعاينة، ثم احفظ العرض التقديمي.

**هل يمكنني استبدال الرسالة دون فتح العرض التقديمي في PowerPoint؟**

نعم. يمكنك تعيين صورة معاينة مفضلة لكائن OLE، كما هو موضح في مثال الشيفرة أعلاه.