---
title: Aspose.Slides for .NET 14.9.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides .NET için 14.9.0
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}}

Bu sayfa, Aspose.Slides for .NET 14.9.0 API'siyle tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) sınıfları, metodları, özellikleri ve benzerlerini, ayrıca diğer değişiklikleri listeler.

{{% /alert %}}
## **Genel API Değişiklikleri**
#### **ISmartArtNodeCollection'a ICollection ve Generic IEnumerable Arayüzlerinden Kalıtım Eklendi**
Aspose.Slides.SmartArt.SmartArtNodeCollection sınıfı (ve ilgili arayüz Aspose.Slides.SmartArt.ISmartArtNodeCollection) jenerik arayüz IEnumerable<ISmartArtNode> ve arayüz ICollection'i devralır.
#### **SmartArtLayoutType.Custom Enum Değeri Eklendi**
Custom SmartArt düzen tipi, özel bir şablona sahip bir diyagramı temsil eder. Özel diyagramlar yalnızca bir sunum dosyasından yüklenebilir ve ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) yöntemiyle oluşturulamaz.
#### **SmartArtShape Sınıfı ve ISmartArtShape Arayüzü Eklendi**
Aspose.Slides.SmartArt.SmartArtShape sınıfı (ve arayüzü Aspose.Slides.SmartArt.ISmartArtShape) SmartArt diyagramındaki bireysel şekillere erişim sağlar. SmartArtShape, FillFormat, LineFormat değiştirmek, Hyperlink eklemek ve diğer görevler için kullanılabilir.

{{% alert color="primary" %}}

**Not**: SmartArtShape, IShape özellikleri RawFrame, Frame, Rotation, X, Y, Width, Height'i desteklemez ve bunlara erişmeye çalıştığınızda System.NotSupportedException fırlatır.

Kullanım örneği:

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
#### **SmartArtShapeCollection Sınıfı, ISmartArtShapeCollection Arayüzü ve ISmartArtNode.Shapes Özelliği Eklendi**
Aspose.Slides.SmartArt.SmartArtShapeCollection sınıfı (ve arayüzü Aspose.Slides.SmartArt.ISmartArtShapeCollection) SmartArt diyagramındaki bireysel şekillere erişim sağlar. Koleksiyon, SmartArtNode ile ilişkili şekilleri içerir. SmartArtNode.Shapes özelliği, düğümle ilişkili tüm şekillerin koleksiyonunu döndürür.

{{% alert color="primary" %}}

**Not**: SmartArtLayoutType'a bağlı olarak bir SmartArtShape birkaç düğüm arasında paylaşılabilir.

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
#### **Sayfa Numaralarıyla Slaytları Kaydetme Yöntemleri Eklendi**
Aşağıdaki yöntemler eklendi:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Bu yöntemler, geliştiricilerin belirtilen sunum slaytlarını PDF, XPS, TIFF, HTML formatlarında kaydetmelerine olanak tanır. 'slides' dizisi, 1'den başlayarak sayfa numaralarını belirtmek için kullanılır.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Slayt konumlarının dizisi
presentation.Save(outFileName, slides, SaveFormat.Pdf);

```
#### **PPImage, IPPImage İçin Görüntü Değiştirme Yöntemleri Eklendi**
Yeni yöntemler eklendi:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//İlk yöntem

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);
//İkinci yöntem

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);
//Üçüncü yöntem

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```