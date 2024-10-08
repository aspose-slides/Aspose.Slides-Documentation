---
title: تحويل من صيغة PPT إلى صيغة PPTX
type: docs
weight: 20
url: /ar/net/conversion-from-ppt-to-pptx-format/
--- 

تعتبر ميزة Aspose.Slides الفريدة التي توفر مرونة في تحويل الإصدارات دون التأثير على العمل.
SaveFormat هو تعداد يمكنه تحويل الوثيقة إلى الإضافات المذكورة أدناه في الجدول.

|**اسم العضو**|**القيمة**|**الوصف**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|ملاحظات PDF|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|ملاحظات TIFF|14| |
|XPS|2| |

فيما يلي مقتطف من الكود يُظهر التحويل من PPT إلى PPTX ويمكنك القيام بذلك بالعكس أيضًا.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//إنشاء كائن Presentation يمثل ملف PPTX

Presentation pres = new Presentation(srcFileName);

//حفظ عرض PPTX إلى صيغة PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **تحميل كود المثال**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)