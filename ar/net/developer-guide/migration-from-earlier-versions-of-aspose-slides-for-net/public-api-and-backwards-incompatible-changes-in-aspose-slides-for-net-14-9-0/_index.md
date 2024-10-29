---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.9.0
type: docs
weight: 110
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
---

{{% alert color="primary" %}}

تستعرض هذه الصفحة جميع الفئات، والأساليب، والخصائص المضافة أو المزالة، وغيرها من التغييرات التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 14.9.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة وراثة من واجهتي ICollection وGeneric IEnumerable إلى ISmartArtNodeCollection**
تورث فئة Aspose.Slides.SmartArt.SmartArtNodeCollection (والواجهة ذات الصلة Aspose.Slides.SmartArt.ISmartArtNodeCollection) الواجهة العامة IEnumerable<ISmartArtNode> وواجهة ICollection.
#### **تم إضافة قيمة  SmartArtLayoutType.Custom إلى التعداد**
يمثل نوع تخطيط SmartArt المخصص مخططًا باستخدام نموذج مخصص. لا يمكن تحميل المخططات المخصصة إلا من ملف عرض تقديمي ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **تمت إضافة فئة SmartArtShape وواجهة ISmartArtShape**
تتيح الفئة Aspose.Slides.SmartArt.SmartArtShape (وواجهتها Aspose.Slides.SmartArt.ISmartArtShape) الوصول إلى الأشكال الفردية في مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat وLineFormat وإضافة الارتباطات التشعبية وغيرها من المهام.

{{% alert color="primary" %}}

**ملحوظة**: لا تدعم SmartArtShape خصائص IShape RawFrame وFrame وRotation وX وY وWidth وHeight وتلقي استثناء System.NotSupportedException عند محاولة الوصول إليها.

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
#### **تمت إضافة فئة SmartArtShapeCollection، وواجهة ISmartArtShapeCollection، وخصائص ISmartArtNode.Shapes**
تضيف الفئة Aspose.Slides.SmartArt.SmartArtShapeCollection (وواجهتها Aspose.Slides.SmartArt.ISmartArtShapeCollection) الوصول إلى الأشكال الفردية في مخطط SmartArt. تحتوي المجموعة على أشكال مرتبطة بـ SmartArtNode. ترجع خصائص SmartArtNode.Shapes المجموعات لجميع الأشكال المرتبطة بالعقدة.

{{% alert color="primary" %}} 

**ملحوظة**: اعتمادًا على SmartArtLayoutType، يمكن مشاركة SmartArtShape واحدة بين عدة عقد.

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
#### **تمت إضافة أساليب لحفظ الشرائح مع الحفاظ على أرقام الصفحات**
تمت إضافة الأساليب التالية:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

تسمح هذه الأساليب للمطورين بحفظ الشرائح المحددة من العرض التقديمي بتنسيقات PDF وXPS وTIFF وHTML. يتم استخدام مصفوفة 'slides' لتحديد أرقام الصفحات، بدءًا من ١.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //مصفوفة لمواقع الشرائح

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **تمت إضافة طرق لاستبدال الصور إلى PPImage، IPPImage**
تمت إضافة طرق جديدة:

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