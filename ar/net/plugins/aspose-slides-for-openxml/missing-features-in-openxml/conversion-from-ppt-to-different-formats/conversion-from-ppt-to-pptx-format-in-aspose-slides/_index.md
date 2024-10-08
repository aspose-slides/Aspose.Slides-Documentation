---
title: التحويل من صيغة PPT إلى صيغة PPTX في Aspose.Slides
type: docs
weight: 10
url: /ar/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** لـ .NET الآن يسهل على المطورين الوصول إلى PPT باستخدام مثيل فئة Presentation وتحويله إلى صيغة PPTX المناسبة. حاليًا، يدعم التحويل الجزئي من PPT إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى متابعة هذا الرابط الوثائقي.

**Aspose.Slides** لـ .NET يقدم فئة Presentation التي تمثل ملف عرض PPTX. يمكن الآن أيضًا لفئة Presentation الوصول إلى PPT من خلال Presentation عندما يتم إنشاء الكائن.

``` csharp

 //إنشاء كائن Presentation يمثل ملف PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//حفظ عرض PPTX بصيغة PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **تنزيل كود العينة**
- [Codeplex](http://goo.gl/LklO0x)
- [Github](https://github.com/asposemarketplace/Aspose_for_OpenXML/releases/download/6/Conversion.PPT.to.PPTX.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)