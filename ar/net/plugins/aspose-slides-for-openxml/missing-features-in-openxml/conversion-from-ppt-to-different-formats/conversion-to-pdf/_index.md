---
title: التحويل إلى PDF
type: docs
weight: 30
url: /ar/net/conversion-to-pdf/
---

تُستخدم مستندات PDF بشكل واسع كتنسيق قياسي لتبادل المستندات بين المؤسسات والقطاعات الحكومية والأفراد. إنه تنسيق شائع لذلك يُطلب من المطورين غالبًا تحويل ملفات عروض تقديمية من Microsoft PowerPoint إلى مستندات PDF. إدراكًا لهذا الطلب المحتمل، يدعم Aspose.Slides لـ .NET تحويل العروض التقديمية إلى مستندات PDF دون استخدام أي مكون آخر.

**Aspose.Slides لـ .NET** يقدم فئة Presentation التي تمثل ملف عرض تقديمي. تكشف فئة **Presentation** عن طريقة Save التي يمكن استدعاؤها لتحويل العرض التقديمي بالكامل إلى مستند **PDF**. توفر فئة **PdfOptions** خيارات لإنشاء مستند **PDF** مثل JpegQuality وTextCompression وCompliance وغيرها. يمكن استخدام هذه الخيارات للحصول على المعايير المطلوبة لـ PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

// إنشئ كائن Presentation يمثل ملف عرض تقديمي

Presentation pres = new Presentation(srcFileName);

// احفظ العرض التقديمي كـ PDF مع الخيارات الافتراضية

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **تحميل رمز العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)