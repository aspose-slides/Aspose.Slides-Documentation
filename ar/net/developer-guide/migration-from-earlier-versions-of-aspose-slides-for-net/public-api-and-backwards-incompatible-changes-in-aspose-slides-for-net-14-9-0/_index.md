---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 14.9.0
linktitle: Aspose.Slides لـ .NET 14.9.0
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT, PPTX و ODP."
---
{{% alert color="info" %}} 

هذه الصفحة تُدرج جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) أو [مزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) لها، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تمت إضافة الوراثة من واجهات ICollection و IEnumerable العامة إلى ISmartArtNodeCollection**
الفئة Aspose.Slides.SmartArt.SmartArtNodeCollection (والواجهة المرتبطة Aspose.Slides.SmartArt.ISmartArtNodeCollection) ترث الواجهة العامة IEnumerable<ISmartArtNode> وواجهة ICollection.
#### **تمت إضافة قيمة التعداد SmartArtLayoutType.Custom**
نوع تخطيط SmartArt المخصص يمثل مخططًا بقالب مخصص. لا يمكن تحميل المخططات المخصصة إلا من ملف عرض تقديمي ولا يمكن إنشاءها عبر الطريقة ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **تمت إضافة الفئة SmartArtShape والواجهة ISmartArtShape**
الفئة Aspose.Slides.SmartArt.SmartArtShape (وواجهتها Aspose.Slides.SmartArt.ISmartArtShape) توفر الوصول إلى الأشكال الفردية في مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat، LineFormat، إضافة الروابط التشعبية وغيرها من المهام.

{{% alert color="info" %}} 

**ملاحظة**: لا يدعم SmartArtShape خصائص IShape وهي RawFrame و Frame و Rotation و X و Y و Width و Height، ويطرح استثناء System.NotSupportedException عند محاولة الوصول إليها.

مثال على الاستخدام:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **تمت إضافة الفئة SmartArtShapeCollection والواجهة ISmartArtShapeCollection وخاصية ISmartArtNode.Shapes**
الفئة Aspose.Slides.SmartArt.SmartArtShapeCollection (وواجهتها Aspose.Slides.SmartArt.ISmartArtShapeCollection) تضيف إمكانية الوصول إلى الأشكال الفردية في مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. تُرجع خاصية SmartArtNode.Shapes مجموعات كافة الأشكال المرتبطة بالعقدة.

{{% alert color="info" %}} 

**ملاحظة**: اعتمادًا على SmartArtLayoutType، يمكن أن يُشارك SmartArtShape واحد بين عدة عُقد.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **تمت إضافة طرق حفظ الشرائح مع الحفاظ على أرقام الصفحات**
تمت إضافة الطرق التالية:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

تسمح هذه الطرق للمطورين بحفظ شرائح العرض المحددة إلى صيغ PDF و XPS و TIFF و HTML. تُستخدم مصفوفة 'slides' لتحديد أرقام الصفحات، بدءًا من 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //مصفوفة مواضع الشرائح

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **تمت إضافة طرق استبدال الصور إلى PPImage و IPPImage**
طرق جديدة مضافة:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //الطريقة الأولى

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //الطريقة الثانية

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //الطريقة الثالثة

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```