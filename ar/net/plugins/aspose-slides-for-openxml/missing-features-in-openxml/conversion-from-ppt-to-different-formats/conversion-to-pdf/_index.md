---
title: التحويل إلى PDF
type: docs
weight: 30
url: /ar/net/conversion-to-pdf/
---

توثيقات PDF تُستخدم على نطاق واسع كصيغة معيارية لتبادل المستندات بين المؤسسات والقطاعات الحكومية والأفراد. إنها صيغة شائعة لذا يُطلب من المطورين غالبًا تحويل ملفات عروض Microsoft PowerPoint إلى وثائق PDF. إدراكًا لهذه المتطلبات المحتملة، تدعم Aspose.Slides for .NET تحويل العروض التقديمية إلى وثائق PDF دون الحاجة إلى أي مكوّن آخر.

**Aspose.Slides for .NET** تقدم فئة Presentation التي تمثّل ملف عرض تقديمي. تُظهر فئة **Presentation** طريقة Save التي يمكن استدعاؤها لتحويل العرض التقديمي بأكمله إلى مستند **PDF**. توفر فئة **PdfOptions** خيارات لإنشاء **PDF** مثل JpegQuality و TextCompression و Compliance وغيرها. يمكن استخدام هذه الخيارات للحصول على معيار PDF المطلوب.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Save the presentation to PDF with default options

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **تحميل مثال الكود**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)