---
title: Sunumlarda .NET ile Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/net/connector/
keywords:
- bağlayıcı
- bağlayıcı türü
- bağlayıcı noktası
- bağlayıcı çizgi
- bağlayıcı açı
- bağlantı noktası
- ayarlama noktası
- şekilleri bağla
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint’te düz, bükülmüş ve eğimli bağlayıcıları ekleme, bağlama, yeniden yönlendirme, ayarlama ve inceleme konularını öğrenin."
---
## **Genel Bakış**

Bir bağlayıcı, iki şekilden birinin hareket etmesi durumunda bile iki şekle bağlı kalabilen bir çizgidir. Uçları, PowerPoint’te yeşil noktalarla temsil edilen bağlantı noktalarına bağlanır. Bazı bükülmüş ve eğimli bağlayıcılar ayrıca turuncu noktalarla temsil edilen ayarlama noktalarını ortaya çıkarır; bu noktalar, bağlayıcı segmentlerinin konumunu kontrol eder.

Aspose.Slides, bağlayıcıları [IConnector](https://reference.aspose.com/slides/tr/net/aspose.slides/iconnector/) arayüzü aracılığıyla temsil eder. Bağlayıcıları oluşturabilir, uçlarını şekillere bağlayabilir, bağlantı noktalarını seçebilir, yeniden yönlendirebilir ve ayarlama noktalarına sahip bağlayıcıların geometrisini değiştirebilirsiniz.

## **Bağlayıcı Türleri**

[ShapeType](https://reference.aspose.com/slides/tr/net/aspose.slides/shapetype/) enumerasyonu düz, bükülmüş ve eğimli bağlayıcı ön ayarlarını içerir. Aşağıdaki tablo, mevcut bağlayıcı geometrilerini ve her ön ayar tarafından tanımlanan ayarlama noktası sayısını gösterir.

| Bağlayıcı | Resim | Ayarlama noktası sayısı |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ayarlama noktalarının sayısı ve anlamı seçilen bağlayıcı ön ayarının bir parçasıdır. İki farklı bağlayıcı türünün aynı koleksiyon düzenini ortaya çıkardığını varsaymayın.

## **İki Şekli Bağla**

[IShapeCollection.AddConnector](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addconnector/) metodunu kullanarak bir bağlayıcı ekleyin ve onun [StartShapeConnectedTo](https://reference.aspose.com/slides/tr/net/aspose.slides/connector/startshapeconnectedto/) ve [EndShapeConnectedTo](https://reference.aspose.com/slides/tr/net/aspose.slides/connector/endshapeconnectedto/) özelliklerini atayın. Her iki uç da bağlandıktan sonra, [IConnector.Reroute](https://reference.aspose.com/slides/tr/net/aspose.slides/iconnector/reroute/) şekiller arasındaki kısa bir yolu seçer.

Aşağıdaki örnek, bir elips ile bir dikdörtgeni bükülmüş bir bağlayıcıyla bağlar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
`Reroute` metodunu çağırmak, [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/connector/startshapeconnectionsiteindex/) ve [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/net/aspose.slides/connector/endshapeconnectionsiteindex/) değerlerini değiştirebilir. Bu sitelerin sabit kalması gerekiyorsa, yeniden yönlendirmeden sonra belirli bağlantı noktalarını atayın.
{{% /alert %}}

## **Bir Bağlantı Noktası Seçme**

Her bağlanabilir şekil, [ConnectionSiteCount](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/connectionsitecount/) aracılığıyla sitesayısını raporlar. Bağlayıcı ucuna atamadan önce tercih edilen sıfır‑tabanlı site indeksini doğrulayın; site sayıları şekil geometrisine göre değişir.

Bu örnek, elips üzerindeki belirli bir site mevcut olduğunda bağlayıcıyı o siteye bağlar:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Bir Bağlayıcı Noktasını Ayarlama**

Ayarlama noktalarına sahip bağlayıcılar, [IGeometryShape.Adjustments](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/adjustments/) aracılığıyla bu noktaları ortaya çıkarır. Her bir [IAdjustValue](https://reference.aspose.com/slides/tr/net/aspose.slides/iadjustvalue/) inceleyin ve [RawValue](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/rawvalue/) değiştirmeden önce [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/type/) özelliğine bakın. Önceden tanımlı şekil ayarlamalarını tanımlama kuralları [Shape Manipulation](/slides/tr/net/shape-manipulations/) içinde açıklanmıştır.

Ayarlama noktalarının sayısı, sırası, anlamı ve geçerli değer aralığı bağlayıcı ön ayarına bağlıdır. `Type` özelliği yalnızca okunabilir, ayarlama değeri ise yazılabilir. Bağlayıcıda aynı anlamsal türde birden fazla ayarlama bulunduğunda, ek tanımlama sağlayan salt‑okunur [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/name/) özelliği kullanılabilir.

### **Bir Engel Çevresinde Yönlendirme**

Aşağıdaki düzenlemede, iki şekil arasında bir `BentConnector5` üçüncü bir şekilden geçiyor:

![connector-obstruction](connector-obstruction.png)

Bu kod, engelli bağlayıcıyı oluşturur:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Dikey bükülmeyi hareket ettirmek, bağlayıcının engeli atlayacak şekilde rotasını değiştirir:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Koleksiyon indeksi `1` her zaman dik bükülmeyi temsil eder varsayımı yerine, bu örnek `ConnectorBendPositionY` arar ve yalnızca beklenen anlamsal tür mevcutsa değiştirir:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Bir `BentConnector5` iki `ConnectorBendPositionX` ve bir `ConnectorBendPositionY` ayarlamasına sahiptir. İhtiyacınız olan tür birden çok kez görülüyorsa, birini seçmeden önce `Name` ve o ön ayarın bilinen geometrisini inceleyin. Bir ayarlama `ShapeAdjustmentType.Custom` döndürürse, anlamını ve aralığını ön ayara özgü olarak değerlendirin ve sözleşme netleşene kadar değiştirmeyin.

## **Ayarlama Değerlerini Bağlayıcı Geometrisiyle İlişkilendirme**

Bükülmüş bağlayıcılar için ayarlama değerleri, bireysel segmentlerin konumlarını tahmin etmekte kullanılabilir. Bu hesaplamalar bağlayıcı ön ayarına özeldir:

- `BentConnector4` normalde bir `ConnectorBendPositionX` ve bir `ConnectorBendPositionY` ayarlaması ortaya çıkarır.
- Bu bükülme konumları için `RawValue / 100000f` ifadesi, aşağıdaki örneklerde kullanılan bağlayıcı çerçevesi genişliği ya da yüksekliğinin kesirini üretir.
- Bağlayıcı çerçevesi döndürülebilir veya çevrilebilir, bu yüzden çerçeve koordinatları slayt koordinatlarıyla karşılaştırılmadan önce dönüştürülmelidir.

Aşağıdaki örnekler, önce ayarlamaları tanımlamak için `Type` kullanır. Koleksiyon indekslerini taşınabilir tanımlayıcı olarak kullanmazlar.

### **Döndürülmemiş Bağlayıcı**

İlk düzen, iki metin şeklini `BentConnector4` ile birleştirir:

![connector-shape-complex](connector-shape-complex.png)

Bu örnek bağlayıcıyı inceler ve yatay ve düşey bükülme ayarlamalarını elde eder:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Her iki bükülmeyi de değiştirmek için, beklenen her türü bulup değerleri yalnızca ikisi de bulunduğunda değiştirin:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

Sonuç, yatay ve düşey segmentleri hareket etmiş bir bağlayıcıdır:

![connector-adjusted-1](connector-adjusted-1.png)

Anlamsal türler bilindiğinde, değerler bağlayıcı‑çerçeve koordinatlarına dönüştürülebilir. Bu örnek, iki bükülme ayarlaması tarafından kontrol edilen dikey segmentin üzerine ince bir dikdörtgen çizer:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Kılavuz şekil, hesaplanan segmenti işaret eder:

![connector-adjusted-2](connector-adjusted-2.png)

### **Döndürülmüş veya Çevrilmiş Bağlayıcı**

Aynı bağlayıcı geometrisi dikey yönlendirildiğinde, [Frame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeframe/fliph/) ve [FlipV](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeframe/flipv/) değerleri, bağlayıcı‑çerçeve koordinatlarından slayt koordinatlarına dönüşümü etkiler.

Bu örnek, dikey yönlendirilmiş bağlayıcıyı oluşturur ve ayarlar:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

Ayarlanmış bağlayıcı, şekiller arasında dikey olarak görünür:

![connector-adjusted-3](connector-adjusted-3.png)

Herhangi bir dönüş açısı `alpha` için, bağlayıcı‑çerçeve noktası `(x, y)` çerçeve merkezi `(x0, y0)` etrafında şu şekilde döndürülür:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Aşağıdaki kod, bu örnekte kullanılan 90 derece yönlendirmeyi ele alır ve ilgili bağlayıcı segmentinin üzerine kırmızı bir kılavuz çizer:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Koordinat dönüşümünden sonra kırmızı kılavuz, hesaplanan segmenti işaret eder:

![connector-adjusted-4](connector-adjusted-4.png)

Bu formüller örneklerde kullanılan ön ayarları tanımlar, evrensel bir bağlayıcı modeli oluşturmaz. Farklı bir ön ayar için aynı hesabı uygulamadan önce ayarlama türlerini, çerçeve yönelimini ve değer aralıklarını doğrulayın.

## **Bağlayıcı Yön Açısını Bulma**

Düz bir bağlayıcının yönü, genişlik ve yükseklik değerlerinden, yatay ve düşey çevirmeler uygulanarak hesaplanabilir. Aşağıdaki örnek, slayt koordinatlarında pozitif yatay eksene göre saat yönünde açıyı rapor eder:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **SSS**

**Bir bağlayıcının bir şekle bağlanıp bağlanamayacağını nasıl öğrenebilirim?**  
Şeklin `ConnectionSiteCount` değerini kontrol edin. Pozitif bir sayı, şeklin bağlantı noktaları sunduğunu gösterir. Bağlayıcı ucuna atamadan önce seçilen site indeksini doğrulayın.

**Bir bağlayıcı ayarlamasını koleksiyon indeksiyle tanımlayabilir miyim?**  
Bir indeks yalnızca bilinen bir bağlayıcı ön ayarı ve koleksiyon düzeni için anlamlıdır. Değeri değiştirmeden önce `IAdjustValue.Type` kontrol edin ve aynı anlamsal tür birden çok kez bulunuyorsa ek bilgi için `IAdjustValue.Name` kullanın.

**Bağlı bir şekil silindiğinde ne olur?**  
İlgili bağlayıcı ucu ayrılır. Bağlayıcı slaytta kalır ve silinebilir, serbest bir çizgi olarak konumlandırılabilir veya başka bir şekle bağlanabilir.

**Bir slayt kopyalandığında bağlayıcı bağlamaları korunur mu?**  
Bağlı şekiller slaytla birlikte kopyalandığında bağlamalar genellikle korunur. Bir bağlayıcı, hedef şekillerinden biri olmadan kopyalanırsa, etkilenmiş uç tekrar bağlanmalıdır.