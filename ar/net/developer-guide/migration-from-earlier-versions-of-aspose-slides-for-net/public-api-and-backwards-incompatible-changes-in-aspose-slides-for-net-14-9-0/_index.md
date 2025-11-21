---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.9.0
linktitle: Aspose.Slides لـ .NET 14.9.0
type: docs
weight: 110
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- الترحيل
- الكود القديم
- الكود الحديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات API العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint (PPT، PPTX) و ODP بسلاسة."
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) وإلى جانب ذلك التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **إضافة وراثة من واجهات ICollection و Generic IEnumerable إلى ISmartArtNodeCollection**
الفئة Aspose.Slides.SmartArt.SmartArtNodeCollection (والواجهة المرتبطة Aspose.Slides.SmartArt.ISmartArtNodeCollection) ترث الواجهة العامة IEnumerable<ISmartArtNode> وواجهة ICollection.
#### **تمت إضافة قيمة Enum SmartArtLayoutType.Custom**
نوع تخطيط SmartArt المخصص يمثل مخططًا بقالب مخصص. لا يمكن تحميل المخططات المخصصة إلا من ملف عرض تقديمي ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **تمت إضافة فئة SmartArtShape والواجهة ISmartArtShape**
الفئة Aspose.Slides.SmartArt.SmartArtShape (والواجهة Aspose.Slides.SmartArt.ISmartArtShape) تمنح الوصول إلى الأشكال الفردية في مخطط SmartArt. يمكن استخدام SmartArtShape لتعديل FillFormat، LineFormat، إضافة روابط تشعبية وغيرها من المهام.

{{% alert color="primary" %}} 

**ملاحظة**: لا يدعم SmartArtShape خصائص IShape التالية: RawFrame, Frame, Rotation, X, Y, Width, Height ويطرح استثناء System.NotSupportedException عند محاولة الوصول إليها.

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
#### **تمت إضافة فئة SmartArtShapeCollection والواجهة ISmartArtShapeCollection وخاصية ISmartArtNode.Shapes**
الفئة Aspose.Slides.SmartArt.SmartArtShapeCollection (والواجهة Aspose.Slides.SmartArt.ISmartArtShapeCollection) تضيف القدرة على الوصول إلى الأشكال الفردية في مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. الخاصية SmartArtNode.Shapes تُعيد مجموعات جميع الأشكال المرتبطة بالعقدة.

{{% alert color="primary" %}} 

**ملاحظة**: اعتمادًا على SmartArtLayoutType قد يتم مشاركة SmartArtShape واحد بين عدة عقد.

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
#### **تمت إضافة طرق حفظ الشرائح مع الحفاظ على أرقام الصفحات**
تمت إضافة الطرق التالية:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

تسمح هذه الطرق للمطورين بحفظ شرائح عرض تقديمي محددة إلى صيغ PDF، XPS، TIFF، HTML. يُستخدم مصفوفة 'slides' لتحديد أرقام الصفحات، بدءًا من 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **تمت إضافة طرق استبدال الصور إلى PPImage، IPPImage**
تمت إضافة طرق جديدة:

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