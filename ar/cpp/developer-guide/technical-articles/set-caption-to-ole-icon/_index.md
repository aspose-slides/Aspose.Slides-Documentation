---
title: تعيين العنوان لأيونة OLE
type: docs
weight: 110
url: /cpp/set-caption-to-ole-icon/
---

تم إضافة طرق **get_SubstitutePictureTitle()** و **set_SubstitutePictureTitle()** إلى فئات **IOleObjectFrame** و **OleObjectFrame**. يسمح ذلك بالحصول على عنوان أيونة OLE أو تعيينه أو تغييره. الكود أدناه يوضح مثالًا لإنشاء كائن Excel وتعيين عنوانه.

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// إضافة كائن OLE إلى الشريحة
auto allBytes = System::IO::File::ReadAllBytes(u"oleSourceFile.xlsx");
auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(allBytes, "xlsx");

auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    
// إضافة صورة إلى مجموعة الصور في العرض التقديمي
auto image = Images::FromFile(u"oleIconFile.ico");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// تعيين الصورة كأيقونة للكائن OLE
oleFrame->set_IsObjectIcon(true);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);

// تعيين عنوان لأيونة OLE
oleFrame->set_SubstitutePictureTitle(u"مثال على عنوان");
```