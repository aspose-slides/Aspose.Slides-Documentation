---
title: "واجهة برمجة تطبيقات عامة وتغييرات غير متوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 14.9.0"
linktitle: "Aspose.Slides for .NET 14.9.0"
type: docs
weight: 110
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- الهجرة
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

تُظهر هذه الصفحة جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **إضافة الوراثة من واجهات ICollection و IEnumerable العامة إلى ISmartArtNodeCollection**
الفئة Aspose.Slides.SmartArt.SmartArtNodeCollection (والواجهة المرتبطة Aspose.Slides.SmartArt.ISmartArtNodeCollection) ترث الواجهة العامة IEnumerable<ISmartArtNode> وواجهة ICollection.
#### **إضافة قيمة تعداد SmartArtLayoutType.Custom**
نوع تخطيط SmartArt المخصص يمثل مخططًا بقالب مخصص. لا يمكن تحميل المخططات المخصصة إلا من ملف عرض تقديمي ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **إضافة فئة SmartArtShape والواجهة ISmartArtShape**
فئة Aspose.Slides.SmartArt.SmartArtShape (وواجهتها Aspose.Slides.SmartArt.ISmartArtShape) توفر الوصول إلى الأشكال الفردية في مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat، LineFormat، إضافة وصلات تشعبية وغيرها من المهام.

{{% alert color="primary" %}} 

**ملاحظة**: لا يدعم SmartArtShape خصائص IShape التالية RawFrame و Frame و Rotation و X و Y و Width و Height، ويطرح استثناء System.NotSupportedException عند محاولة الوصول إليها.

مثال على الاستخدام:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **إضافة فئة SmartArtShapeCollection والواجهة ISmartArtShapeCollection وخاصية ISmartArtNode.Shapes**
فئة Aspose.Slides.SmartArt.SmartArtShapeCollection (وواجهتها Aspose.Slides.SmartArt.ISmartArtShapeCollection) توفر الوصول إلى الأشكال الفردية في مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. خاصية SmartArtNode.Shapes تُعيد مجموعات جميع الأشكال المرتبطة بالعقدة.

{{% alert color="primary" %}} 

**ملاحظة**: بناءً على SmartArtLayoutType قد يتم مشاركة SmartArtShape واحد بين عدة عقد.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **إضافة طرق حفظ الشرائح مع الحفاظ على أرقام الصفحات**
تمت إضافة الطرق التالية:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

تسمح هذه الطرق للمطورين بحفظ الشرائح المحددة من العرض التقديمي إلى صيغ PDF أو XPS أو TIFF أو HTML. يُستخدم مصفوفة “slides” لتحديد أرقام الصفحات، بدءًا من 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **إضافة طرق استبدال الصور إلى PPImage, IPPImage**
تم إضافة طرق جديدة:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//First method

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Second method

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Third method

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```