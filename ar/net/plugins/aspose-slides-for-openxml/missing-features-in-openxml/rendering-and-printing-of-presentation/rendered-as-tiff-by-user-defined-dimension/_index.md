---
title: تم تحويله إلى TIFF بواسطة أبعاد محددة من قبل المستخدم
type: docs
weight: 40
url: /ar/net/rendered-as-tiff-by-user-defined-dimension/
---

يوضح المثال التالي كيفية تحويل عرض تقديمي إلى وثيقة TIFF بحجم صورة مخصص باستخدام فئة **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//إنشاء كائن Presentation يمثل ملف عرض تقديمي

Presentation pres = new Presentation(srcFileName);

//إنشاء فئة TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//تعيين نوع الضغط

opts.CompressionType = TiffCompressionTypes.Default;

//أنواع الضغط

//Default - يحدد مخطط الضغط الافتراضي (LZW).

//None - يحدد عدم وجود ضغط.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.

//وحدة الدقة - تساوي دائمًا "2" (نقاط لكل بوصة)

//تعيين DPI للصورة

opts.DpiX = 200;

opts.DpiY = 100;

//تعيين حجم الصورة

opts.ImageSize = new Size(1728, 1078);

//حفظ العرض التقديمي بتنسيق TIFF مع حجم الصورة المحدد

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **تحميل رمز المثال**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)