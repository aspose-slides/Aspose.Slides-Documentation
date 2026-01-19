---
title: تحويل إلى Tiff مع الملاحظات
type: docs
weight: 10
url: /ar/net/conversion-to-tiff-with-notes/
---

TIFF هو أحد تنسيقات الصور المستخدمة على نطاق واسع التي يدعمها Aspose.Slides for .NET لتحويل عرض تقديمي يحتوي على ملاحظات إلى صور. يمكنك أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. أدناه مثالان للشفرة يوضحان كيفية إنشاء صور TIFF لعرض تقديمي في عرض ملاحظات الشريحة.

طريقة **Save** التي تعرضها فئة **Presentation** يمكن استخدامها لتحويل العرض التقديمي بالكامل في عرض ملاحظات الشريحة إلى TIFF. يمكنك أيضًا إنشاء صورة مصغرة لشريحة في عرض ملاحظات الشريحة لشريحة فردية.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **تنزيل عينة الكود**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)