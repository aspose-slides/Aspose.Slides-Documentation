---
title: ".NET'te Sunum Şekillerini Özelleştirme"
linktitle: "Özel Şekil"
type: docs
weight: 20
url: /tr/net/custom-shape/
keywords:
- "özel şekil"
- "şekil ekle"
- "şekil oluştur"
- "şekil değiştir"
- "şekil geometrisi"
- "geometri yolu"
- "yol noktaları"
- "düzenleme noktaları"
- "nokta ekle"
- "nokta kaldır"
- "düzenleme işlemi"
- "yuvarlatılmış köşe"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında şekil oluşturun ve özelleştirin: geometri yolları, yuvarlatılmış köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek Aspose.Slides'te sunum şekillerinin nasıl özelleştirileceğini açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemleri gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenen geometrinin bir şekle uygulanması için [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca özel ve birleşik şekiller oluşturma, köşeleri yuvarlatılmış şekiller inşa etme, bir şekil geometrisinin kapalı olup olmadığını belirleme ve ek geometri özelleştirme senaryoları için [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ile [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) arasındaki eski dönüştürmeyi kullanma konularını örnekler.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

PowerPoint'te **Düzenleme Noktaları** kullanarak bir kareyi değiştirebilirsiniz:

* Bir köşeyi içe ya da dışa hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin hatlarını değiştirebilmenizi veya mevcut bir şekli yeni bir şeklin temelini oluşturmak için kullanmanızı sağlar.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda bulundurun:

* Bir şeklin (veya yolunun) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan çapa noktalarından oluşur.
* Bir segment düz ya da eğri olabilir. Çapa noktaları ve kontrol tutamaçları şeklini belirler.
* Çapa noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Köşe noktasında, bitişik segmentler bir açıyla birleşebilir.
  * Yumuşak noktada, iki kontrol tutamaçı hizalanmış ve çapa noktasından eşit mesafededir.
  * Düz noktada, iki kontrol tutamaçı hizalanmış ancak çapa noktasından farklı mesafelerde olabilir.
* Çapa noktalarını hareket ettirmek veya tutamaçlarını ayarlamak şeklin hatlarını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) sınıfını ve [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) arayüzünü sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) örneği, [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) nesnesinin geometri yolunu temsil eder.
* [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) almak için [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) yöntemini kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ayarlamak üzere tek yollu şekillerde [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), çoklu yollar için ise [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) yöntemlerini kullanabilirsiniz.
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) ve [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) özellikleriyle bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) özelliği sayesinde bir [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) yolunu segment dizisi olarak alabilirsiniz.
* Aşağıdaki dönüşüm yöntemlerini destekleyen eski sürümlerde, [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) → [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) dönüşümü yapabilirsiniz.
* [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) sınıfındaki [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) ve [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) yöntemleriyle [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ve [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) arasında dönüşüm yapabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir dizin kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki sıfır‑bazlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekle ya da ekle. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| İki kontrol noktası ve bir son nokta ile kübik Bézier eğrisi ekle ya da ekle. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Tek bir kontrol noktası ve bir son nokta ile ikinci dereceden Bézier eğrisi ekle ya da ekle. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Belirtilen ölçüler ve derece cinsinden açıyla eliptik yay ekle. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Şu anki figürü, son noktasını başlangıç noktasına bağlayarak kapat. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Bir figürün başlangıç noktasını ayarla. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Sıfır‑bazlı bir dizindeki segmenti kaldır. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) kullanır ve düzenlenen yolu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile uygular. Koordinatlar şekle göre yereldir: yeni noktalar her iki açıdan da merkezde, soldan 100 puan, üstten 50 puan uzaktadır. 1 ve 4 segment indeksleri, bu noktaları üst ve alt kenarlara yerleştirerek kenarları içe doğru çeker.

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

![example1_image](custom_shape_1.png)

## **Şekilden Noktalar Kaldırma**

Bu örnek, bir kalp şeklindeki anahatı, sıfır‑bazlı 2. indeksdeki segmenti [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) ile kaldırarak değiştirir. Değiştirilen yolu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile uygulamak şeklin konturunu günceller.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız inşa eder. 100 ve 50 puan dış ve iç yarıçapların dönüşümlü olarak belirlenmesi uçları ve girintileri tanımlar; 72‑derecelik adım, beş ucu eşit aralıklarla yerleştirir. Yol, [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) ile kapatılır ve [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile bir dikdörtgen şekline uygulanarak anahattı değiştirilir.

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
![example3_image](custom_shape_3.png)

## **Birleşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte bir bölümleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yol da [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulanarak orta üçte bir boşluk bırakılan tek bir birleşik şekil elde edilir.

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
![example4_image](custom_shape_4.png)

## **Yuvarlatılmış Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) ile birleştirerek içe doğru kıvrımlı köşelere sahip bir şekil üretir. Her köşe boyutu, yay genişliği ve yüksekliğini puan cinsinden ayarlar; -90 derecelik süpürme ise saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ile uygulanır ve sunum PPTX formatında kaydedilir.

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

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Aşağıdaki yardımcı, her dolu olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) okur ve son segmentin [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) değerini [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) ile karşılaştırır. Boş olmayan yol olmadığında **false** döner. Bu, her yolun son komutunu inceler; yol içindeki her alt‑figürü taramaz. Örnek, bir dikdörtgen için `True` yazdırır.

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

## **Şekil Elemanlarını Çıkarma ve İnceleme**

Mevcut bir şekli, yol noktaları ve nokta türlerini içeren elemanlar olarak incelemek için [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) kullanın. Dönen her [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) nesnesini [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) türüne dönüştürerek [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) ve [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) dizilerini okuyabilirsiniz. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için kullanışlıdır.

Örnek bir sunumu açar, ilk slayttaki ilk geometri şekline ulaşır ve yol segmentlerini yazdırır. Çıktıyı görmek için düz ve eğri segmentler içeren bir şekil kullanan bir sunum seçin. Gruplar içinde arama yapılmaz.

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
        var pointType = types[i] & 0x07; // Segment tipini tut, bayrakları hariç tut.
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

Diziler indeks bazında eşleşir: `points[i]` bir noktayı, `types[i]` ise onun rolünü tanımlar. Tip **0** yeni bir figür başlatır, tip **1** önceki noktadan mevcut noktaya bir çizgi çizer. Kübik Bézier segmenti, önceki son noktadan başlar ve üç ardışık tip‑`3` girdisiyle tanımlanır: iki kontrol noktası ve yeni son nokta. Döngü bu üç girişi bir arada tüketir ve son noktanın kapalı olup olmadığını kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesini, kapalı alt‑yolu tespit etmek için `0x80` bayrağını ayrı ayrı test edin. Örneğin `129` (`0x81`) bir alt‑yolu kapatan çizgi son noktası, `131` (`0x83`) ise bir Bézier son noktası demektir. Sadece `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) cinsinden ölçülür; X sağa, Y aşağı doğru artar. Gruplandırılmamış bir şekil için çıkarılan koordinatlar zaten [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) ve [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) konumunu içerir ve mevcut genişlik‑yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin; X ve Y değerlerini çıkartarak koordinatları döndürülmemiş çerçeveye göre göreceli elde edin.

Çıkarılan noktalar, şeklin [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) veya yatay‑dikey çevirilerini içermez. Görünen konturu yeniden oluşturmak için bu dönüşümleri şeklin merkezine göre uygulayın. Gruplandırılmış şekillerde ayrıca grup koordinat haritalamasını ve dönüşümlerini hesaba katın; çıkarılan noktaların slayt üzerindeki nihai render koordinatları olduğunu varsaymayın ve çeviri ya da ölçeklendirmeyi iki kez uygulamayın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz ya da çizim kodunuz nokta/tür dizilerine ihtiyaç duyduğunda bu yaklaşımı seçin. Geometri komutlarını şeklin yerel koordinat sisteminde almak veya geometrisini düzenlemek istiyorsanız [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) kullanın. Düzenlenmiş yolları [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) veya [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulayın.

## **GeometryPath’i GraphicsPath’e (System.Drawing.Drawing2D) Dönüştürme**

Aşağıdaki örnek, [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) yöntemini destekleyen eski bir Aspose.Slides for .NET derlemesine (ör. sürüm 25.10) ve `System.Drawing.Common` yüklü bir Windows ortamına ihtiyaç duyar. Dönüştürme yöntemleri [sürüm 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) ile kaldırılmıştır.

Bu örnek, bir dikdörtgen anahattını metin geometrisine dönüştürülmüş haliyle birleştirir. Anahat için [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) doldurulmasını devre dışı bırakacak şekilde ayarlanır. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) metin anahatlarını saklar; [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) bunu doldurulmuş bir geometri yoluna dönüştürür. Her iki yol da [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulanarak dikdörtgen ve metni içeren tek bir şekil oluşturulur. Ters yönde dönüştürme için [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) kullanın.

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
![example5_image](custom_shape_5.png)

## **SSS**

**Geometriyi değiştirdikten sonra doldurma ve anahat ne olur?**

Stil şekle bağlı kalır; sadece kontur değişir. Doldurma ve anahat otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli, geometrisiyle birlikte nasıl doğru bir şekilde döndürürüm?**

Şeklin [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) özelliğini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğundan şekil ile birlikte döner.

**Özel bir şekli bir görüntüye dönüştürüp “kilitleyebilir” miyim?**

Evet. Gerekli [slide](/slides/tr/net/convert-powerpoint-to-png/) alanını ya da doğrudan [shape](/slides/tr/net/create-shape-thumbnails/) öğesini raster bir formata dışa aktarın; bu, karmaşık geometrilerle sonraki çalışmayı basitleştirir.