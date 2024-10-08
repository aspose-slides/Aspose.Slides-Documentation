---
title: تحويل إلى TIFF مع الملاحظات
type: docs
weight: 10
url: /ar/net/conversion-to-tiff-with-notes/
---

TIFF هو واحد من عدة تنسيقات صور مستخدمة على نطاق واسع التي تدعمها Aspose.Slides لـ .NET لتحويل عرض تقديمي مع ملاحظات إلى صور. يمكنك أيضًا إنشاء مصغرات الشرائح في عرض ملاحظات الشرائح. أدناه، يوجد مقطعي كود يوضحان كيفية إنشاء صور TIFF لعرض تقديمي في عرض ملاحظات الشرائح.

يمكن استخدام طريقة **Save** المعروضة بواسطة فئة **Presentation** لتحويل العرض التقديمي الكامل في عرض ملاحظات الشرائح إلى TIFF. يمكنك أيضًا إنشاء مصغرة شريحة في عرض ملاحظات الشرائح للشرائح الفردية.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **تحميل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)