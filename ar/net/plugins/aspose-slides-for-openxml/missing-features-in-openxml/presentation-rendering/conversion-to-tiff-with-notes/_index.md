---
title: التحويل إلى Tiff مع الملاحظات
type: docs
weight: 10
url: /ar/net/conversion-to-tiff-with-notes/
---
TIFF هو أحد تنسيقات الصور المستخدمة على نطاق واسع التي يدعمها Aspose.Slides for .NET لتحويل عرض تقديمي يحتوي على ملاحظات إلى صور. يمكنك أيضاً إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. أدناه مثالان من كود يوضحان كيفية إنشاء صور TIFF لعرض تقديمي في وضع ملاحظات الشريحة.

يمكن استخدام طريقة **Save** التي تُعرِّفها فئة **Presentation** لتحويل كامل العرض التقديمي في وضع ملاحظات الشريحة إلى TIFF. يمكنك أيضاً إنشاء صورة مصغرة لشريحة في وضع ملاحظات الشريحة للشرائح الفردية.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation(srcFileName))
{
    //وضع ملاحظات المتحدث أسفل كل شريحة مُصدَّرة
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //حفظ العرض التقديمي كملف TIFF مع الملاحظات
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **تنزيل عينة الكود**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)