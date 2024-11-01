---
title: تعيين العنوان لأيقونة OLE
type: docs
weight: 130
url: /ar/java/set-caption-to-ole-icon/
---

لقد تم إضافة طرق جديدة **getSubstitutePictureTitle** و **setSubstitutePictureTitle** إلى واجهة **IOleObjectFrame** وclass **OleObjectFrame**. يسمح ذلك بالحصول على العنوان أو تعيينه أو تغييره لأيقونة OLE. تُظهر مقطع الشفرة أدناه مثالًا على إنشاء كائن Excel وتعيين عنوانه.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// إضافة كائن OLE إلى الشريحة
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

// إضافة صورة إلى مجموعة الصور في العرض التقديمي
IImage image = Images.fromFile("oleIconFile.ico");
IPPImage ppImage = presentation.getImages().addImage(image);
image.dispose();

// تعيين الصورة كأيقونة لكائن OLE
oleFrame.setObjectIcon(true);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);

// تعيين عنوان لأيقونة OLE
oleFrame.setSubstitutePictureTitle("مثال على العنوان");
```