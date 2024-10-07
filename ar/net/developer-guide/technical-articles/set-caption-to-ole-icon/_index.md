---
title: تعيين العنوان إلى أيقونة OLE
type: docs
weight: 160
url: /net/set-caption-to-ole-icon/
---

تم إضافة خاصية جديدة **SubstitutePictureTitle** إلى واجهة **IOleObjectFrame** وفئة **OleObjectFrame**. هذه الخاصية تسمح بالحصول على عنوان أيقونة OLE أو تعيينه أو تغييره. الشفرة التالية توضح مثالاً على إنشاء كائن Excel وتعيين عنوانه.

```csharp
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    // إضافة كائنات Ole
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.xlsx");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xlsx");

    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // إضافة كائن صورة
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    IPPImage image = pres.Images.AddImage(imgBuf);

    oof.SubstitutePictureFormat.Picture.Image = image;

    // تعيين العنوان إلى أيقونة OLE
    oof.SubstitutePictureTitle = "مثال على العنوان";
}
```