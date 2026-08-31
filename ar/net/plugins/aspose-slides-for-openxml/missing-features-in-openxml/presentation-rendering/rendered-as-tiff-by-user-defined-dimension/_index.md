---
title: تم العرض كـ Tiff بأبعاد يحددها المستخدم
type: docs
weight: 40
url: /ar/net/rendered-as-tiff-by-user-defined-dimension/
---
يبين المثال التالي كيفية تحويل عرض تقديمي إلى مستند TIFF بحجم صورة مخصص باستخدام فئة **TiffOptions**.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation(srcFileName);

//إنشاء كلاس TiffOptions
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//تحديد نوع الضغط
opts.CompressionType = TiffCompressionTypes.Default;

//أنواع الضغط
//Default - يحدد مخطط الضغط الافتراضي (LZW).
//None - يحدد عدم وجود ضغط.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.
//Resolution unit - دائمًا يساوي "2" (نقطة في البوصة)
//تحديد DPI الصورة
opts.DpiX = 200;

opts.DpiY = 100;

//تحديد حجم الصورة
opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **تنزيل مثال الشيفرة**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)