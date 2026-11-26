---
title: PowerPoint Sunum Şekillerini .NET'te Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/net/custom-shape/
keywords:
- özel şekil
- şekil ekle
- şekil oluştur
- şekli değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- düzenleme noktaları
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- kıvrımlı köşe
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında şekilleri oluşturun ve özelleştirin: geometri yolları, kıvrımlı köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde şekil geometrisini düzenleme noktaları ve geometri yolları aracılığıyla düzenleyerek sunum şekillerini nasıl özelleştireceğinizi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, noktalar eklemek veya kaldırmak ve güncellenen geometriyi bir şekle uygulamak için [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca özel ve birleşik şekiller oluşturma, köşeleri kıvrımlı olan şekiller inşa etme, bir şekil geometrisinin kapalı olup olmadığını belirleme ve ek geometri özelleştirme senaryoları için [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ile [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) arasındaki eski dönüştürmeyi kullanma konularını da demonstrasyonlar.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

PowerPoint'te **Düzenleme Noktaları**nı kullanarak bir kareyi şu şekilde değiştirebilirsiniz:

* Bir köşeyi içe ya da dışa hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Noktaları düzenlemek, bir şeklin dış hatlarını değiştirmenizi veya mevcut bir şekli yeni bir şeklin temelini oluşturmak için kullanmanızı sağlar.

## **Şekil Düzenleme İpuçları**

![genel_bakıs_resmi](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda tutun:

* Bir şeklin (veya yolunun) kapalı ya da açık olabilir.
* Bir şeklin yolu, parçalarla bağlanan çapa (anchor) noktalarından oluşur.
* Bir parça düz veya kıvrımlı olabilir. Çapa noktaları ve kontrol kulpları şeklin biçimini belirler.
* Çapa noktaları köşe, düz ya da pürüzsüz nokta olarak bulunur:
  * Köşe noktasında, bitişik parçalar bir açıyla buluşur.
  * Pürüzsüz noktada, iki kontrol kulpu hizalanmıştır ve çapa noktasından eşit uzaklıktadır.
  * Düz noktada, iki kontrol kulpu hizalanmıştır ancak çapa noktasından farklı uzaklıklarda olabilir.
* Çapa noktalarını hareket ettirmek veya kulplarını ayarlamak, şeklin dış hattını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) sınıfını ve [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) arayüzünü sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) örneği, [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) nesnesinin geometri yolunu temsil eder.
* [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) almak için [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) yöntemini kullanabilirsiniz.
* Bir şeklin [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)’ını ayarlamak için tek yollu şekillerde [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), çok yollarlı şekillerde ise [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) yöntemlerini kullanabilirsiniz.
* Parçalar eklemek için [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) ve [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) özellikleriyle bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) özelliği, bir [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/)’ın yolunu parça dizisi olarak almanızı sağlar.
* Aşağıdaki dönüşüm yöntemlerini destekleyen eski sürümlerde, [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)’ı [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)’e dönüştürebilirsiniz.
* [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) sınıfındaki [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) ve [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) yöntemlerini kullanarak [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ve [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) arasında dönüşüm yapabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir dizin kabul eden aşırı yüklemeler, parçayı yolun sıfır‑tabanlı konumunda ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekle veya ekle. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| İki kontrol noktası ve bir son nokta içeren kübik Bézier eğrisi ekle veya ekle. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Tek bir kontrol noktası ve bir son nokta içeren ikinci dereceden Bézier eğrisi ekle veya ekle. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Belirtilen boyut ve derece cinsinden açıyla eliptik yay ekle. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Şeklin son noktasını başlangıç noktasına bağlayarak mevcut figürü kapat. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Bir figürün başlangıç noktasını ayarla. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Sıfır‑tabanlı bir dizindeki parçayı kaldır. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Şekle Özel Noktalar Eklemek**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) kullanır ve düzenlenmiş yolu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile uygular. Koordinatlar şekle göre yereldir: her iki yeni nokta da şeklin merkezinde, sol kenardan 100 puan ve üst kenardan 50 puan uzaktadır. Parça indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirerek bu kenarları içe doğru çeker.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![örnek1_resim](custom_shape_1.png)

## **Şekilden Noktalar Kaldırmak**

Bu örnek, [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) ile sıfır‑tabanlı 2 indeksindeki parçayı kaldırarak bir kalp dış hatını değiştirir. Değiştirilmiş yolu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile uygulamak, şeklin konturunu günceller.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![örnek2_resim](custom_shape_2.png)

## **Özel Bir Şekil Oluşturmak**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. Dış ve iç yarıçapların sırayla 100 ve 50 puan olması, uçları ve girintileri tanımlar; 72‑derecelik adım beş ucu eşit aralıklarla yerleştirir. Yol, [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) ile kapatılır ve [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile bir dikdörtgen şekle uygulanarak dış çizgisi değiştirilir.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![örnek3_resim](custom_shape_3.png)

## **Bileşik Bir Özel Şekil Oluşturmak**

Bu örnek, bir şeklin üst ve alt üçte birlik kısımları için iki kapalı [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulamak, ortasındaki bir boşlukla tek bir birleşik şekil oluşturur.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![örnek4_resim](custom_shape_4.png)

## **Kıvrımlı Köşeli Özel Bir Şekil Oluşturmak**

Bu örnek, düz parçaları [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) ile birleştirerek içe doğru kıvrılmış köşelere sahip bir şekil oluşturur. Her köşe boyutu, yay genişliği ve yüksekliğini puan cinsinden ayarlar; -90 derecelik süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile uygulanır ve sunum PPTX formatında kaydedilir.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenmek**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış parçası ile bitip bitmediğini kontrol eder. [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) okunur ve son parçanın [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) değeri [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) ile karşılaştırılır. Boş olmayan yol bulunmadığında false döner. Bu kontrol, her yolun son komutunu inceler; yol içindeki her alt figürü denetlemez. Örnek, bir dikdörtgen için `True` yazdırır.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Geometri Yol Komutlarını İncelemek**

[contour.pptx](contour.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slayt, düz bir üst kenar, kübik Bézier eğrisi ve düz bir kapanış kenarı içeren bir şekil barındırır. Şeklin yollarını okumak için [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) kullanın. Her yol, [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) içinde çizim sırasına göre parçalarını listeler. Her parçanın [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) değeri, [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/) nasıl okunacağını belirler.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

Şekil, slaytta (200, 100) puan konumundadır. Raporlanan noktalar şekle göre yereldir; (0, 0) şeklin sol‑üst köşesindedir, x sağa, y aşağı doğru artar. Kapanış parçası ek koordinat olmadan başlangıç noktasına döner.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint şekli düz bir üst kenar, sağ üstten sol alta doğru kıvrımlı bir kenar ve düz bir sol kenar içerir](contour.png)

## **Şekil Elemanlarını Çıkarmak ve İncelemek**

[IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) kullanarak mevcut bir şekli yol noktaları ve nokta türleri içeren elemanlar olarak inceleyebilirsiniz. Dönen her [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/)’i, [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/)’e dönüştürerek [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) ve [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) dizilerini okuyabilirsiniz. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına aktarımı için faydalıdır.

Örnek, bir sunumu açar, ilk slayttaki ilk geometri şeklini bulur ve yol parçalarını yazdırır. Düz ve kıvrımlı parçalar içeren bir şekil içeren bir sunum kullanın; grup içindeki şekilleri aramaz.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Segment tipini sakla, bayrakları hariç tut.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Diziler indeks bazında eşleşir: `points[i]` bir noktadır, `types[i]` ise rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` önceki noktadan şimdiki noktaya bir çizgi çizer. Kübik Bézier parçası, önceki son noktadan başlar ve üç ardışık tip‑`3` girdisi kullanır: iki kontrol noktası ve yeni son nokta. Döngü bu üç girişi birlikte tüketir ve kapanış için son noktayı kontrol eder.

Nokta tipleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesini, kapalı alt yolu tespit etmek için `0x80` bayrağını ayrı ayrı test edin. Örneğin `129` (`0x81`) bir satır son noktası olup alt yolu kapatır; `131` (`0x83`) ise bir Bézier son noktası olup aynı işi yapar. Sadece `1` ya da `3` ile kontrol etmek bu durumları kaçırır. Çizgi (`0x10`) ve işaretleyici (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) biriminde ölçülür; X sağa, Y aşağı doğru artar. Grup dışı bir şekil için çıkarılan koordinatlar zaten şeklin [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) ve [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) konumunu içerir ve mevcut genişlik‑yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda, `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`‑`(220, 280)` olur. Şeklin konumunu tekrar eklemeyin. Koordinatları, X ve Y’yi çıkararak döndürülmemiş çerçeveye göre yerel hâle getirin.

Çıkarılan noktalar, şeklin [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) ya da yatay‑dikey çevirilerini içermez. Görüntülenen konturu yeniden üretmek için bu dönüşümleri şeklin merkezinde uygulayın. Gruplu şekillerde, grup koordinat eşlemesi ve dönüşümlerini de hesaba katın; çıkarılan noktaların son slayt koordinatları olduğunu varsaymayın ve çevirme ya da ölçeklemeyi iki kez uygulamayın.

**Denetleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz veya çizim kodunuz nokta/tür dizilerine ihtiyaç duyduğunda bu yöntemi tercih edin. Şeklin yerel koordinat sisteminde geometri komutlarına ihtiyacınız varsa veya geometrisini düzenlemek istiyorsanız [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) kullanın. Düzenlenmiş yolları [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) veya [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulayın.

## **GeometryPath’i GraphicsPath’e Dönüştürmek (System.Drawing.Drawing2D)**

Aşağıdaki örnek, [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) metodunu destekleyen (örnek: 25.10 sürümü) eski bir Aspose.Slides for .NET derlemesi ve `System.Drawing.Common` yüklü bir Windows ortamı gerektirir. Dönüşüm metodları, [versiyon 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) ile kaldırılmıştır.

Bu örnek, metne dönüştürülmüş bir geometrik metinle bir dikdörtgen konturu birleştirir. Konturun [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) doldurulmasını devre dışı bırakacak şekilde ayarlanmıştır. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) metin konturunu tutar; [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) bunu doldurulmuş bir geometri yoluna çevirir. Her iki yolu da [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulamak, dikdörtgen ve metni içinde barındıran tek bir şekil üretir. Ters yönde dönüşüm için [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) kullanın.

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![örnek5_resim](custom_shape_5.png)

## **SSS**

**Geometriyi değiştirdikten sonra dolgu ve dış hat ne olur?**

Stil şekil ile kalır; sadece kontur değişir. Dolgu ve dış hat yeni geometriye otomatik olarak uygulanır.

**Geometri ile birlikte özel bir şekli nasıl doğru bir şekilde döndürürüm?**

Şeklin [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) özelliğini kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğundan şekille birlikte döner.

**Özel bir şekli “kilitlemek” için bir görsele dönüştürebilir miyim?**

Evet. Gerekli [slide](/slides/tr/net/convert-powerpoint-to-png/) alanını ya da [shape](/slides/tr/net/create-shape-thumbnails/) kendisini raster formatına dışa aktarın; bu, karmaşık geometrilerle çalışmayı basitleştirir.