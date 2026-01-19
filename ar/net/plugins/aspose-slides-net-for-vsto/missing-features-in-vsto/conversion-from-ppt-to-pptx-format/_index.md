---
title: تحويل من تنسيق PPT إلى PPTX
type: docs
weight: 20
url: /ar/net/conversion-from-ppt-to-pptx-format/
---

ميزة فريدة في Aspose.Slides توفر مرونة في تحويل الإصدارات دون التأثير على العمل.
SaveFormat هو تعداد يمكنه تحويل المستند إلى الامتدادات المذكورة أدناه في الجدول.

|**اسم العضو**|**القيمة**|**الوصف**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
فيما يلي مقطع شفرة يوضح التحويل من PPT إلى PPTX ويمكنك القيام بالعكس كذلك.

```csharp
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation(srcFileName);

//حفظ عرض PPTX بتنسيق PPTX
pres.Save(destFileName, SaveFormat.Pptx);
``` 
## **تنزيل مثال الشفرة**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)