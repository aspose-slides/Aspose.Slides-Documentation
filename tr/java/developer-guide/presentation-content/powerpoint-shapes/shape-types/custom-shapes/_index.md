---
title: Sunum Şekillerini Java’da Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/java/custom-shape/
keywords:
- özel şekil
- şekil ekle
- şekil oluştur
- şekil değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- düzenleme noktaları
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- eğimli köşe
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarında şekil oluşturun ve özelleştirin: geometri yolları, eğimli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde şekil geometriğini düzenleme noktaları ve geometri yolları aracılığıyla düzenleyerek sunum şekillerini nasıl özelleştireceğinizi açıklar. `GeometryPath` ve `IGeometryPath` ile mevcut şekilleri nasıl değiştireceğinizi, temel yol düzenleme işlemlerini nasıl yapacağınızı, nokta ekleme veya kaldırma işlemlerini ve güncellenen geometrinin bir şekle nasıl uygulanacağını gösterir.

Ayrıca özel ve birleşik şekiller oluşturmayı, köşeleri eğimli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi ve ek geometri özelleştirme senaryoları için `GeometryPath` ile `java.awt.Shape` arasında dönüşüm yapmayı da gösterir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

Bir kareyi düşünün. PowerPoint’te **düzenleme noktalarını** kullanarak

* karenin köşesini içine ya da dışına hareket ettirebilir,
* bir köşe ya da nokta için eğriliği belirtebilir,
* kareye yeni noktalar ekleyebilir,
* kare üzerindeki noktalarıManipüle edebilirsiniz, vb.

Temelde, bu görevleri herhangi bir şekil üzerinde gerçekleştirebilirsiniz. Düzenleme noktalarını kullanarak bir şekli değiştirebilir ya da mevcut bir şekilden yeni bir şekil oluşturabilirsiniz.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenleme noktalarıyla düzenlemeye başlamadan önce şekillerle ilgili şu noktalara dikkat etmek isteyebilirsiniz:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şekil kapalı olduğunda bir başlangıç veya bitiş noktası yoktur. Açık olduğunda ise bir başlangıç ve bir bitiş noktası bulunur.
* Tüm şekiller en az iki, birbirine hatlarla bağlanmış çapa noktasına sahiptir.
* Bir çizgi düz ya da eğimli olabilir. Çapa noktaları çizginin niteliğini belirler.
* Çapa noktaları köşe noktası, düz nokta veya yumuşak nokta olarak bulunur:
  * Köşe noktası, iki düz hatın bir açıyla buluştuğu noktadır.
  * Yumuşak nokta, iki tutamağın düz bir hat üzerinde bulunduğu ve hat segmentlerinin yumuşak bir eğriyle birleştiği noktadır. Bu durumda tüm tutamaçlar çapa noktasından eşit bir mesafede bulunur.
  * Düz nokta, iki tutamağın düz bir hat üzerinde bulunduğu ve hat segmentlerinin bir eğri oluşturmak zorunda olmadığı noktadır. Bu durumda tutamaçların çapa noktasından eşit mesafede olması gerekmez.
* Çapa noktalarını hareket ettirerek veya düzenleyerek (çizgi açılarını değiştirerek) şeklin görünümünü değiştirebilirsiniz.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides** aşağıdaki sınıfları sağlar: [**GeometryPath**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) sınıfı ve [**IGeometryPath**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryPath) arayüzü.

* Bir [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) örneği, [IGeometryShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryShape) nesnesinin geometri yolunu temsil eder.
* `IGeometryShape` örneğinden `GeometryPath` alabilmek için [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) metodunu kullanabilirsiniz.
* Bir şeklin `GeometryPath` değerini ayarlamak için şu metodları kullanın: katı şekiller için [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) ve birleşik şekiller için [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-).
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryPath) altında bulunan metodları kullanabilirsiniz.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) ve [IGeometryPath.setFillMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) metodlarıyla bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryPath#getPathData--) metodunu kullanarak bir `GeometryShape` nesnesinin geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath)’i [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) tipine dönüştürebilirsiniz.
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) ve [graphicsPathToGeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) metodlarını ( [ShapeUtil](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeUtil) sınıfından) kullanarak [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath)’i [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)’e ve tersine dönüştürebilirsiniz.

## **Basit Düzenleme İşlemleri**

Bu Java kodu aşağıdakileri gösterir

**Bir yolun sonuna bir çizgi ekleme**

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Bir yolda belirli bir konuma çizgi ekleme:**

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Bir yolun sonuna kübik Bezier eğrisi ekleme:**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Bir yolda belirli bir konuma kübik Bezier eğrisi ekleme:**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Bir yolun sonuna ikisel Bezier eğrisi ekleme:**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Bir yolda belirli bir konuma ikisel Bezier eğrisi ekleme:**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Verilen bir yay ekleme:**

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Bir yolun mevcut figürünü kapatma:**

``` java
public void closeFigure();
```
**Sonraki nokta konumunu ayarlama:**

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Belirli bir indeksteki yol segmentini kaldırma:**

``` java
public void removeAt(int index);
```

## **Bir Şekle Özel Noktalar Ekleme**
1. [GeometryShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType.Rectangle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) örneği alın.
3. Yol üzerindeki iki üst noktası arasına yeni bir nokta ekleyin.
4. Yol üzerindeki iki alt nokta arasına yeni bir nokta ekleyin.
5. Yolu şekle uygulayın.

Bu Java kodu, bir şekle özel noktalar eklemeyi gösterir:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **Bir Şekilden Noktaları Kaldırma**

1. [GeometryShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType.Heart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) örneği alın.
3. Yol için segmenti kaldırın.
4. Yolu şekle uygulayın.

Bu Java kodu, bir şekilden noktaları kaldırmayı gösterir:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

1. Şeklin noktalarını hesaplayın.
2. Bir [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) örneği oluşturun.
3. Yolu noktalara doldurun.
4. Bir [GeometryShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryShape) örneği oluşturun.
5. Yolu şekle uygulayın.

Bu Java kodu, özel bir şekil oluşturmayı gösterir:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}

```
![example3_image](custom_shape_3.png)


## **Birleşik Özel Şekil Oluşturma**

  1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryShape) örneği oluşturun.
  2. İlk bir [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) örneği oluşturun.
  3. İkinci bir [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) örneği oluşturun.
  4. Yolları şekle uygulayın.

Bu Java kodu, birleşik bir özel şekil oluşturmayı gösterir:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Eğimli Köşeli Özel Şekil Oluşturma**

Bu Java kodu, eğimli köşelere (içeriye doğru) sahip bir özel şekil oluşturmayı gösterir:

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Kapalı bir şekil, tüm kenarlarının birbirine bağlandığı ve boşluk bırakmadan tek bir sınır oluşturduğu şekil olarak tanımlanır. Bu şekil basit bir geometrik form ya da karmaşık bir özel kontur olabilir. Aşağıdaki kod örneği, bir şekil geometrisinin kapalı olup olmadığını kontrol etmeyi gösterir:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **GeometryPath’i java.awt.Shape’a Dönüştürme**

1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryShape) örneği oluşturun.
2. Bir [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) örneği oluşturun.
3. [ShapeUtil](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeUtil) kullanarak [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) örneğini [GeometryPath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GeometryPath) örneğine dönüştürün.
4. Yolları şekle uygulayın.

Yukarıdaki adımları gerçekleştiren bu Java kodu, **GeometryPath**’i **GraphicsPath**’a dönüştürme sürecini gösterir:

``` java
Presentation pres = new Presentation();
try {
    // Yeni şekil oluştur
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Şeklin geometri yolunu al
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Metin ile yeni grafik yolu oluştur
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Grafik yolunu geometri yoluna dönüştür
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Yeni geometri yolu ve orijinal geometri yolunun birleşimini şekle ayarla
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometriyi değiştirdikten sonra dolgu ve kenarlık ne olur?**

Stil şekille kalır; sadece kontur değişir. Dolgu ve kenarlık yeni geometrinin üzerine otomatik olarak uygulanır.

**Özel şekli ve geometrisini aynı anda doğru şekilde nasıl döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#setRotation-float-) metodunu kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğu için şekilyle birlikte döner.

**Özel şekli bir görsele dönüştürüp sonucu “kilitleyebilir” miyim?**

Evet. Gerekli [slide](/slides/tr/java/convert-powerpoint-to-png/) alanını ya da [shape](/slides/tr/java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, ağır geometrilerle çalışmayı kolaylaştırır.