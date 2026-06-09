---
title: Aspose.Slides for .NET 14.5.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 14.5.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) sınıfları, yöntemleri, özellikleri vb., yeni [kısıtlamalar](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ve diğer [değişiklikler](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) içerir.

{{% /alert %}} 
## **Public API ve Geriye Uyumsuz Değişiklikler**
### **Eklenen Arayüzler, Sınıflar, Özellikler ve Yöntemler**
#### **Aspose.Slides.IPresentationInfo Arayüzü ve PresentationInfo Sınıfı Eklendi**
Sunum hakkında bilgi temsil eder.

- Boolean özellik IsEncrypted, sunum şifreli ise True, aksi takdirde False döndürür.
- LoadFormat özelliği, bir sunumun tipini alır.
#### **Aspose.Slides.IShape.IsGrouped Özelliği Eklendi**
Aspose.Slides.IShape.IsGrouped özelliği, bir şeklin gruplanıp gruplanmadığını belirler.
#### **Aspose.Slides.IShape.ParentGroup Özelliği Eklendi**
Aspose.Slides.IShape.ParentGroup özelliği, şekil grup içinde ise üst GroupShape nesnesini döndürür. Aksi takdirde null döner.
#### **Aspose.Slides.IShapeCollection.AddGroupShape() Yöntemi Eklendi**
Aspose.Slides.IShapeCollection.AddGroupShape() yöntemi yeni bir GroupShape oluşturur ve koleksiyonun sonuna ekler.
Yeni şekil eklendiğinde GroupShape çerçeve boyutu ve konumu içeriğe göre ayarlanır.
#### **Aspose.Slides.IShapeCollection.Clear() Yöntemi Eklendi**
Aspose.Slides.IShapeCollection.Clear() yöntemi koleksiyondaki tüm şekilleri kaldırır.
#### **Aspose.Slides.IShapeCollection.InsertGroupShape(int) Yöntemi Eklendi**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) yöntemi yeni bir GroupShape oluşturur ve belirtilen indeks konumunda koleksiyona ekler.
Yeni bir şekil eklendiğinde GroupShape çerçeve boyutu ve konumu içeriğe göre ayarlanır.
#### **IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Yöntemleri Eklendi**
Bu yöntemler, bir sunum dosyası veya akışı hakkında tam yüklemeden bilgi almayı sağlar.
#### **IPresentationFactory PresentationFactory.Instance Özelliği Eklendi**
Bu özellik, geliştiricilerin fabrikayı örneklemeden kullanabilmesini sağlar.
### **Kısıtlamalar**
#### **IShape.Frame'e Kısıtlamalar**
IShape.Frame için tanımsız değerlerin kullanılmasına yönelik kısıtlamalar eklenmiştir. IShape.Frame'e tanımsız bir çerçeve atamaya çalışan kod çoğu durumda anlamlı değildir (özellikle üst GroupShape birden fazla {{GroupShape}} içinde iç içe geçmişse). Örneğin:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

veya

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Bu tür kodlar belirsiz durumlara yol açabilir. Bu nedenle IShape.Frame için tanımsız değerlerin kullanımı kısıtlanmıştır. x, y, width, height, flipH, flipV ve rotationAngle değerlerinin tanımlı olması gerekir (float.NaN veya NullableBool.NotDefined olarak ayarlanmamalıdır). Yukarıdaki örnek kod şimdi ArgumentException hatası fırlatır.
Bu, aşağıdaki kullanım durumları için geçerlidir:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Tanımsız olamaz

IShapeCollection shapes = ...;

// x, y, width, height parametreleri float.NaN olamaz:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

Ancak IShape.RawFrame çerçeve özellikleri tanımsız olabilir. Bu, bir şeklin bir yer tutucuya bağlandığı durumlarda mantıklıdır. Bu durumda tanımsız şekil çerçeve değerleri üst yer tutucu şekilden devralınır. Eğer üst yer tutucu şekil yoksa, şekil IShape.RawFrame temel alınarak etkili çerçeveyi değerlendirirken varsayılan değerleri kullanır. Varsayılan değerler x, y, width, height, flipH, flipV ve rotationAngle için 0 ve NullableBool.False'tur. Örneğin:

``` csharp

 IShape shape = ...; // shape yer tutucuya bağlıdır

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// şimdi shape x, y, height, flipH, flipV değerlerini yer tutucudan devralır ve width=100 ve rotationAngle=0 değerlerini geçersiz kılar.

``` 
### **Değiştirilen Özellikler**
#### **Aspose.Slides.IShapeCollection.Parent Özelliğinin Adı ve Türü Değiştirildi**
- Aspose.Slides.IShapeCollection.Parent özelliğinin türü ISlideComponent'ten yeni IGroupShape arayüzüne değiştirildi. IGroupShape, ISlideComponent'in bir türevi olduğundan mevcut kodun uyarlamaya ihtiyacı yoktur.
- Aspose.Slides.IShapeCollection.Parent özelliğinin adı Parent'dan ParentGroup'a değiştirildi.
#### **Aspose.Slides.IShapeFrame.FlipH, .FlipV Özellik Türleri Değiştirildi**
- Aspose.Slides.IShapeFrame.FlipH özelliğinin türü bool'tan NullableBool'a değiştirildi.
- IShape.Frame özelliği, tüm özellikleri tanımlı değerlerle etkili bir IShapeFrame örneği döndürür.
- IShape.RawFrame özelliği, her özelliğin tanımsız olabileceği bir IShapeFrame örneği döndürür (özellikle FlipH veya FlipV NullableBool.NotDefined değere sahip olabilir).