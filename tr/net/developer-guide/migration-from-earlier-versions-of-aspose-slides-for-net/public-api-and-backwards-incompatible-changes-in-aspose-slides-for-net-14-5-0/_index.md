---
title: Aspose.Slides for .NET 14.5.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for .NET 14.5.0 API'siyle tanıtılan tüm [added](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) sınıfları, metodları, özellikleri ve benzerlerini, yeni [restrictions](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ve diğer [changes](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) listeler.

{{% /alert %}} 
## **Genel API ve Geriye Uyumsuz Değişiklikler**
### **Eklenen Arayüzler, Sınıflar, Özellikler ve Metodlar**
#### **Aspose.Slides.IPresentationInfo Arayüzü ve PresentationInfo Sınıfı Eklendi**
Sunum hakkında bilgi temsil eder.

- Boolean özellik IsEncrypted, sunum şifreli ise True, aksi takdirde False döndürür.
- LoadFormat özelliği, bir sunumun türünü alır.
#### **Aspose.Slides.IShape.IsGrouped Özelliği Eklendi**
Aspose.Slides.IShape.IsGrouped özelliği, bir şeklin gruplanıp gruplanmadığını belirler.
#### **Aspose.Slides.IShape.ParentGroup Özelliği Eklendi**
Aspose.Slides.IShape.ParentGroup özelliği, şekil gruplanmışsa üst GroupShape nesnesini döndürür. Aksi takdirde null döner.
#### **Aspose.Slides.IShapeCollection.AddGroupShape() Metodu Eklendi**
Aspose.Slides.IShapeCollection.AddGroupShape() metodu, yeni bir GroupShape oluşturur ve koleksiyonun sonuna ekler.
Yeni şekil eklendiğinde GroupShape çerçeve boyutu ve konumu içeriğe göre ayarlanır.
#### **Aspose.Slides.IShapeCollection.Clear() Metodu Eklendi**
Aspose.Slides.IShapeCollection.Clear() metodu, koleksiyondaki tüm şekilleri kaldırır.
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) Metodu Eklendi**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) metodu, yeni bir GroupShape oluşturur ve belirtilen indeks konumuna ekler.
Yeni bir şekil eklendiğinde GroupShape çerçeve boyutu ve konumu içeriğe göre ayarlanır.
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Metodları Eklendi**
Bu metodlar, sunumu tam yüklemeden bir sunum dosyası veya akışı hakkında bilgi almayı sağlar.
#### **IPresentationFactory PresentationFactory.Instance Özelliği Eklendi**
Bu özellik, geliştiricilerin fabrikayı örneklemeden kullanmasına olanak tanır.
### **Kısıtlamalar**
#### **IShape.Frame'e Kısıtlamalar**
IShape.Frame için tanımsız değerlerin kullanılmasına yönelik kısıtlamalar eklenmiştir. IShape.Frame'e tanımsız bir çerçeve atamaya çalışan kod çoğu durumda mantıklı değildir (özellikle üst GroupShape birden fazla {{GroupShape}} içine gömülü olduğunda). Örneğin:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// ArgumentException hatası fırlatır: çerçeve değerleri tanımlı olmalıdır.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

or

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// ArgumentException hatası fırlatır: x, y, genişlik ve yükseklik tanımlı olmalıdır.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Böyle bir kod belirsiz duruma yol açabilir. Bu nedenle IShape.Frame için tanımsız değerlerin kullanımı kısıtlanmıştır. x, y, width, height, flipH, flipV ve rotationAngle değerlerinin tanımlı olması gerekir (float.NaN veya NullableBool.NotDefined olarak ayarlanmamalıdır). Yukarıdaki örnek kod artık bir ArgumentException hatası fırlatır.
This applies to these use cases:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// x, y, genişlik ve yükseklik parametreleri float.NaN olamaz, ve flipH, flipV
// NullableBool.NotDefined olamaz:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Aynı kısıtlama, şekil oluşturan her metoda uygulanır:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Ancak IShape.RawFrame çerçeve özellikleri tanımsız olabilir. Bu, bir şeklin bir yer tutucuya bağlandığı durumlarda mantıklıdır. Bu durumda tanımsız şekil çerçevesi değerleri üst yer tutucu şekilden devralınır. Eğer üst yer tutucu şekil yoksa, şekil IShape.RawFrame temelinde etkili çerçeveyi değerlendirirken varsayılan değerleri kullanır. Varsayılan değerler x, y, width, height, flipH, flipV ve rotationAngle için 0 ve NullableBool.False'tur. Örneğin:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Şekil bir yer tutucuya bağlanmış
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // şimdi şekil x, y, yükseklik, flipH, flipV değerlerini yer tutucudan devralır ve genişlik=100 ve rotationAngle=0 olarak geçersiz kılar.
}
``` 
### **Değiştirilen Özellikler**
#### **Aspose.Slides.IShapeCollection.Parent Özellik İsmi ve Tipi Değiştirildi**
- Aspose.Slides.IShapeCollection.Parent özelliğinin tipi ISlideComponent'ten yeni IGroupShape arabirimine değiştirildi. IGroupShape, ISlideComponent'in bir türevi olduğundan mevcut kodda uyarlama gerekmez.
- Aspose.Slides.IShapeCollection.Parent özelliğinin adı Parent'tan ParentGroup'a değiştirildi.
#### **Aspose.Slides.IShapeFrame.FlipH, .FlipV Özellik Tipleri Değiştirildi**
- Aspose.Slides.IShapeFrame.FlipH özelliğinin tipi bool'tan NullableBool'a değiştirildi.
- IShape.Frame özelliği, tüm özellikleri tanımlı etkili değerlere sahip bir IShapeFrame örneği döndürür.
- IShape.RawFrame özelliği, her bir özelliğin tanımsız olabileceği (özellikle FlipH veya FlipV'nin NullableBool.NotDefined olabileceği) bir IShapeFrame örneği döndürür.