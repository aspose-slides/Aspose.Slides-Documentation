---
title: التحويل إلى XPS
type: docs
weight: 40
url: /ar/net/conversion-to-xps/
---

**تنسيق XPS** يُستخدم أيضًا على نطاق واسع لتبادل البيانات. تُدير Aspose.Slides لـ .NET أهميته وتوفر الدعم المدمج لتحويل العرض التقديمي إلى مستند XPS.

يمكن استخدام طريقة **Save** المعروضة من قِبَل فئة Presentation لتحويل العرض التقديمي بالكامل إلى مستند **XPS**. علاوة على ذلك، تعرض فئة **XpsOptions** خاصية **SaveMetafileAsPng** التي يمكن تعيينها إلى true أو false حسب المتطلبات.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **تحميل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)