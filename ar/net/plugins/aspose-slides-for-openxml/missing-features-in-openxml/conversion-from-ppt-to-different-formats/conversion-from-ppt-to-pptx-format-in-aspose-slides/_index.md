---
title: التحويل من تنسيق PPT إلى تنسيق PPTX في Aspose.Slides
type: docs
weight: 10
url: /ar/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** for .NET الآن يتيح للمطورين الوصول إلى ملفات PPT باستخدام كائن من فئة Presentation وتحويله إلى صيغة PPTX المقابلة. حالياً، يدعم التحويل الجزئي من PPT إلى PPTX. للمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى رابط الوثائق هذا.

**Aspose.Slides** for .NET يقدم فئة Presentation التي تمثل ملف عرض PPTX. الآن يمكن لفئة Presentation أيضاً الوصول إلى ملفات PPT عند إنشاء الكائن.

``` csharp

 //Instantiate a Presentation object that represents a PPTX file

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Saving the PPTX presentation to PPTX format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)