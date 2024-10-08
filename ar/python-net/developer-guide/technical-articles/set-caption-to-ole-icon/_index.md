---
title: تعيين التسمية إلى أيقونة OLE
type: docs
weight: 160
url: /ar/python-net/set-caption-to-ole-icon/
---

تم إضافة خاصية جديدة **SubstitutePictureTitle** إلى واجهة **IOleObjectFrame** وclass **OleObjectFrame**. تتيح الحصول على، تعيين أو تغيير التسمية لأيقونة OLE. يعرض مقتطف الكود أدناه نموذجًا لإنشاء كائن Excel وتعيين تسميته.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة كائن OLE إلى الشريحة
    with open("oleSourceFile.xlsx", "rb") as ole_stream:
        data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.read(), "xlsx")

    ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

    # إضافة صورة إلى مجموعة الصور في العرض التقديمي
    with slides.Images.from_file("oleIconFile.ico") as image:
        pp_image = presentation.images.add_image(image)

    # تعيين الصورة كأيقونة لكائن OLE
    ole_frame.is_object_icon = True
    ole_frame.substitute_picture_format.picture.image = pp_image

    # تعيين تسمية لأيقونة OLE
    ole_frame.substitute_picture_title = "مثال على التسمية"
```