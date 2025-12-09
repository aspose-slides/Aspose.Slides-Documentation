---
title: "التغييرات العامة لواجهة البرمجة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 14.9.0"
linktitle: "Aspose.Slides لـ .NET 14.9.0"
type: docs
weight: 110
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- ترحيل
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
description: "استعراض تحديثات واجهة البرمجة العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint PPT، PPTX و ODP."
---

{{% alert color="primary" %}} 

تُظهر هذه الصفحة جميع الفئات [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) والطرق والخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides لـ .NET 14.9.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة البرمجة** 
#### **إضافة الوراثة من واجهات ICollection و IEnumerable العامة إلى ISmartArtNodeCollection** 
الفئة Aspose.Slides.SmartArt.SmartArtNodeCollection (والواجهة المرتبطة Aspose.Slides.SmartArt.ISmartArtNodeCollection) ترث الواجهة العامة IEnumerable<ISmartArtNode> والواجهة ICollection. 
#### **إضافة قيمة Enum SmartArtLayoutType.Custom** 
تمثل قيمة SmartArtLayoutType.Custom تخطيط SmartArt مخصص. يمكن تحميل المخططات المخصصة فقط من ملف عرض تقديمي ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom). 
#### **إضافة الفئة SmartArtShape والواجهة ISmartArtShape** 
الفئة Aspose.Slides.SmartArt.SmartArtShape (والواجهة Aspose.Slides.SmartArt.ISmartArtShape) توفر وصولاً إلى الأشكال الفردية في مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat و LineFormat وإضافة Hyperlinks وغيرها من المهام. 

{{% alert color="primary" %}} 

**ملاحظة**: لا يدعم SmartArtShape خصائص IShape التالية: RawFrame, Frame, Rotation, X, Y, Width, Height، ويطرح استثناء System.NotSupportedException عند محاولة الوصول إليها. 

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
#### **إضافة الفئة SmartArtShapeCollection والواجهة ISmartArtShapeCollection وخصيصة ISmartArtNode.Shapes** 
الفئة Aspose.Slides.SmartArt.SmartArtShapeCollection (والواجهة Aspose.Slides.SmartArt.ISmartArtShapeCollection) تضيف وصولاً إلى الأشكال الفردية في مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. تعيد خاصية SmartArtNode.Shapes مجموعة كل الأشكال المرتبطة بالعقدة. 

{{% alert color="primary" %}} 

**ملاحظة**: اعتمادًا على SmartArtLayoutType، يمكن مشاركة SmartArtShape واحد بين عدة عقد. 

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pers.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

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
#### **الإبقاء على طرق حفظ الشرائح مع أرقام الصفحات** 
تم إضافة الطرق التالية: 

- void IPresentation.Save(string fname, int[] slides, SaveFormat format); 
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options); 
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format); 
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options); 

تتيح هذه الطرق للمطورين حفظ شرائح عرض تقديمي محددة إلى صيغ PDF، XPS، TIFF، HTML. يُستخدم مصفوفة 'slides' لتحديد أرقام الصفحات بدءًا من 1. 
Save(string fname, int[] slides, SaveFormat format); 

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //مصفوفة مواضع الشرائح

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **إضافة طرق استبدال الصور إلى PPImage و IPPImage** 
تم إضافة الطرق الجديدة: 

- IPPImage.ReplaceImage(byte[] newImageData) 
- IPPImage.ReplaceImage(Image newImage) 
- IPPImage.ReplaceImage(IPPImage newImage) 

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//الطريقة الأولى

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//الطريقة الثانية

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//الطريقة الثالثة

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```