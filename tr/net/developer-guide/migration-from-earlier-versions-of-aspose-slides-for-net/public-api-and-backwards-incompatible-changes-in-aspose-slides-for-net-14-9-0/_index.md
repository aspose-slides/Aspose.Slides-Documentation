---
title: Aspose.Slides for .NET 14.9.0'de Genel API ve Geriye Dönük Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) sınıfları, yöntemleri, özellikleri vb. ve Aspose.Slides for .NET 14.9.0 API'siyle tanıtılan diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **ISmartArtNodeCollection'a ICollection ve Generic IEnumerable Arabirimlerinden Kalıtım Eklendi**
Aspose.Slides.SmartArt.SmartArtNodeCollection sınıfı (ve ilgili arayüzü Aspose.Slides.SmartArt.ISmartArtNodeCollection) generic arayüz IEnumerable<ISmartArtNode> ve arayüz ICollection'ı miras alır.
#### **SmartArtLayoutType.Custom Enum Değeri Eklendi**
Custom SmartArt düzen tipi, özel bir şablona sahip bir diyagramı temsil eder. Özel diyagramlar yalnızca bir sunum dosyasından yüklenebilir ve ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) yöntemiyle oluşturulamaz.
#### **SmartArtShape Sınıfı ve ISmartArtShape Arayüzü Eklendi**
Aspose.Slides.SmartArt.SmartArtShape sınıfı (ve onun arayüzü Aspose.Slides.SmartArt.ISmartArtShape) bir SmartArt diyagramındaki bireysel şekillere erişim sağlar. SmartArtShape, FillFormat, LineFormat değiştirmek, Hyperlink eklemek ve diğer görevler için kullanılabilir.

{{% alert color="info" %}} 

**Not**: SmartArtShape, IShape özellikleri RawFrame, Frame, Rotation, X, Y, Width, Height'ı desteklemez ve bunlara erişmeye çalışıldığında System.NotSupportedException fırlatır.

Kullanım örneği:

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
#### **SmartArtShapeCollection Sınıfı, ISmartArtShapeCollection Arayüzü ve ISmartArtNode.Shapes Özelliği Eklendi**
Aspose.Slides.SmartArt.SmartArtShapeCollection sınıfı (ve onun arayüzü Aspose.Slides.SmartArt.ISmartArtShapeCollection) bir SmartArt diyagramındaki bireysel şekillere erişim ekler. Koleksiyon, SmartArtNode ile ilişkilendirilmiş şekilleri içerir. SmartArtNode.Shapes özelliği, düğümle ilişkili tüm şekillerin koleksiyonlarını döndürür.

{{% alert color="info" %}} 

**Not**: SmartArtLayoutType'a bağlı olarak bir SmartArtShape birden fazla düğüm arasında paylaşılabilir.

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
#### **Sayfa Numaralarıyla Slaytları Kaydetme Yöntemleri Eklendi**
Aşağıdaki yöntemler eklendi:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Bu yöntemler, geliştiricilerin belirli sunum slaytlarını PDF, XPS, TIFF, HTML formatlarında kaydetmesine olanak tanır. 'slides' dizisi, sayfa numaralarını belirtmek için kullanılır ve 1'den başlar.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Slayt konumlarının dizisi

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **PPImage, IPPImage İçin Görüntü Değiştirme Yöntemleri Eklendi**
Yeni yöntemler eklendi:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //İlk yöntem

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //İkinci yöntem

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Üçüncü yöntem

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```