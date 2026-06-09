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
- kavisli köşe
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, kavisli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştireceğinizi açıklar. `GeometryPath` ve `IGeometryPath` ile mevcut şekilleri nasıl değiştireceğinizi, temel yol düzenleme işlemlerini nasıl yapacağınızı, nokta ekleyip kaldıracağınızı ve güncellenen geometrinin şekle nasıl uygulanacağını gösterir.

Ayrıca, özel ve birleşik şekiller oluşturmayı, eğimli köşeli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi ve ek geometri özelleştirme senaryoları için `GeometryPath` ile `GraphicsPath` arasında dönüşüm yapmayı da gösterir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

Bir kareyi düşünün. PowerPoint’te **düzenleme noktaları** kullanarak şunları yapabilirsiniz  

* karenin köşesini içeriye ya da dışarıya hareket ettirme  
* bir köşe ya da noktanın eğrilik derecesini belirleme  
* kareye yeni noktalar ekleme  
* kare üzerindeki noktaları manipüle etme vb.  

Temelde, açıklanan görevleri herhangi bir şekil üzerinde gerçekleştirebilirsiniz. Düzenleme noktalarıyla bir şekli değiştirebilir ya da mevcut bir şekilden yeni bir şekil oluşturabilirsiniz. 

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenleme noktalarıyla düzenlemeye başlamadan önce, şekillerle ilgili aşağıdaki noktaları göz önünde bulundurmak isteyebilirsiniz:

* Bir şekil (veya yolu) ya kapalı ya da açıktır.  
* Tüm şekiller en az 2 köprü noktasından oluşur ve bu noktalar çizgilerle birbirine bağlanır.  
* Bir çizgi ya düz ya da kavisli olabilir. Köprü noktaları çizginin doğasını belirler.  
* Köprü noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:  
  * Bir köşe noktası, 2 düz çizginin bir açıda birleştiği noktadır.  
  * Bir yumuşak nokta, 2 tutamacın düz bir hatta bulunduğu ve çizgi segmentlerinin yumuşak bir eğriyle birleştiği noktadır. Bu durumda, tüm tutamaclar köprü noktasından eşit bir mesafede bulunur.  
  * Bir düz nokta, 2 tutamacın düz bir hatta bulunduğu ve çizgi segmentlerinin yumuşak bir eğriyle birleştiği noktadır. Bu durumda tutamacların köprü noktasından eşit mesafede olması gerekmez.  
* Köprü noktalarını hareket ettirerek ya da düzenleyerek (çizgilerin açılarını değiştirerek) şeklin görünümünü değiştirebilirsiniz.  

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [**GeometryPath**](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) sınıfını ve [**IGeometryPath**](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometrypath) arayüzünü sağlar.  

* Bir [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) örneği, [IGeometryShape](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape) nesnesinin bir geometri yolunu temsil eder.  
* `IGeometryShape` örneğinden `GeometryPath` elde etmek için [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/methods/getgeometrypaths) yöntemini kullanabilirsiniz.  
* Bir şekil için `GeometryPath` ayarlamak amacıyla şu yöntemleri kullanabilirsiniz: katı şekiller için *[IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/methods/setgeometrypath)* ve birleşik şekiller için *[IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/methods/setgeometrypaths)*.  
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometrypath) altındaki yöntemleri kullanabilirsiniz.  
* [IGeometryPath.Stroke](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometrypath/properties/stroke) ve [IGeometryPath.FillMode](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometrypath/properties/fillmode) özelliklerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.  
* [IGeometryPath.PathData](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometrypath/properties/pathdata) özelliği sayesinde bir `GeometryShape`'in geometri yolunu yol segmentlerinin bir dizisi olarak alabilirsiniz.  
* Ek şekil geometri özelleştirme seçeneklerine erişmek için [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) nesnesini [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) nesnesine dönüştürebilirsiniz.  
* [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/tr/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) ve [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) yöntemlerini ( [ShapeUtil](https://reference.aspose.com/slides/tr/net/aspose.slides.util/shapeutil) sınıfından) kullanarak [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) ile [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) arasında iki yönlü dönüşüm yapabilirsiniz.  

## **Basit Düzenleme İşlemleri**

Bu C# kodu, aşağıdakileri gösterir  

**Bir Çizgi Ekle** yolu sonuna  

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```  
**Bir Çizgi Ekle** belirli bir konuma bir yolda:  

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```  
**Kübik Bezier Eğrisi Ekle** yolu sonuna:  

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```  
**Kübik Bezier Eğrisi Ekle** belirli bir konuma bir yolda:  

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```  
**İkinciel Bezier Eğrisi Ekle** yolu sonuna:  

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```  
**İkinciel Bezier Eğrisi Ekle** belirli bir konuma bir yolda:  

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```  
**Belirli bir Yayı Sonlandır** yola ekle:  

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```  
**Mevcut Şekli Kapat** yola:  

``` csharp
void CloseFigure();
```  
**Sonraki Nokta için Konumu Ayarla**:  

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```  
**Belirli bir Dizindeki Yol Segmentini Kaldır**:  

``` csharp
void RemoveAt(int index);
```  

## **Bir Şekle Özel Noktalar Ekleme**

1. [GeometryShape](https://reference.aspose.com/slides/tr/net/aspose.slides/geometryshape) sınıfının bir örneğini oluşturun ve [ShapeType.Rectangle](https://reference.aspose.com/slides/tr/net/aspose.slides/shapetype) türünü ayarlayın.  
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) örneği alın.  
3. Yolun iki üst noktasının arasına yeni bir nokta ekleyin.  
4. Yolun iki alt noktasının arasına yeni bir nokta ekleyin.  
5. Yolu şekle uygulayın.  

Bu C# kodu, bir şekle özel noktalar eklemeyi gösterir:  

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```  

![example1_image](custom_shape_1.png)  

## **Bir Şekilden Noktaları Kaldırma**

1. [GeometryShape](https://reference.aspose.com/slides/tr/net/aspose.slides/geometryshape) sınıfının bir örneğini oluşturun ve [ShapeType.Heart](https://reference.aspose.com/slides/tr/net/aspose.slides/shapetype) türünü ayarlayın.  
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) örneği alın.  
3. Yol segmentini kaldırın.  
4. Yolu şekle uygulayın.  

Bu C# kodu, bir şekilden noktaları kaldırmayı gösterir:  

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```  
![example2_image](custom_shape_2.png)  

## **Özel Bir Şekil Oluşturma**

1. Şekil için noktaları hesaplayın.  
2. Bir [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) örneği oluşturun.  
3. Yolu noktalarla doldurun.  
4. Bir [GeometryShape](https://reference.aspose.com/slides/tr/net/aspose.slides/geometryshape) örneği oluşturun.  
5. Yolu şekle uygulayın.  

Bu C# kodu, özel bir şekil oluşturmayı gösterir:  

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```  
![example3_image](custom_shape_3.png)  

## **Bileşik Özel Şekil Oluşturma**

1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/net/aspose.slides/geometryshape) örneği oluşturun.  
2. İlk bir [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) örneği oluşturun.  
3. İkinci bir [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) örneği oluşturun.  
4. Yolları şekle uygulayın.  

Bu C# kodu, bir bileşik özel şekil oluşturmayı gösterir:  

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```  
![example4_image](custom_shape_4.png)  

## **Eğimli Köşeli Özel Şekil Oluşturma**

Bu C# kodu, içe doğru eğimli köşelere sahip bir özel şekil oluşturmayı gösterir;  

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```  

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Kapalı bir şekil, tüm kenarları birbirine bağlanarak boşluk bırakmadan tek bir sınır oluşturduğu anlamına gelir. Bu şekil basit bir geometrik form ya da karmaşık bir özel taslak olabilir. Aşağıdaki kod örneği, bir şekil geometrisinin kapalı olup olmadığını kontrol etmeyi gösterir:  

```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```  

## **GeometryPath'i GraphicsPath'e Dönüştürme (System.Drawing.Drawing2D)**

1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/net/aspose.slides/geometryshape) örneği oluşturun.  
2. [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) ad alanının [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) sınıfının bir örneğini oluşturun.  
3. [ShapeUtil](https://reference.aspose.com/slides/tr/net/aspose.slides.util/shapeutil) sınıfını kullanarak [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) örneğini [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath) örneğine dönüştürün.  
4. Yolları şekle uygulayın.  

Bu C# kodu, yukarıdaki adımların bir uygulamasını sunarak **GeometryPath**’i **GraphicsPath**’e dönüştürme sürecini gösterir:  

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```  
![example5_image](custom_shape_5.png)  

## **SSS**

**Geometriyi değiştirdikten sonra doldurma ve kontur ne olur?**  
Stil şekil ile kalır; sadece kontur değişir. Doldurma ve kontur otomatik olarak yeni geometriye uygulanır.  

**Özel bir şekli ve geometrisini doğru bir şekilde nasıl döndürürüm?**  
Şeklin [rotation](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/rotation/) özelliğini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğundan şekil ile birlikte döner.  

**Sonucu “kilitlemek” için bir özel şekli görüntüye dönüştürebilir miyim?**  
Evet. Gerekli [slaytı](/slides/tr/net/convert-powerpoint-to-png/) bölgesini ya da [şekli](/slides/tr/net/create-shape-thumbnails/) raster bir formata dışa aktarın; bu, ağır geometrilerle çalışmayı basitleştirir.