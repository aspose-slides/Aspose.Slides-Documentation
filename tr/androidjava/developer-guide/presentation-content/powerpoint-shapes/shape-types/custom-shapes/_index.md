---
title: Android'de Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/androidjava/custom-shape/
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
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides kullanarak PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, kavisli köşeler, bileşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştireceğinizi açıklar. `GeometryPath` ve `IGeometryPath` ile mevcut şekilleri nasıl değiştireceğinizi, temel yol düzenleme işlemlerini nasıl gerçekleştireceğinizi, nokta ekleme veya kaldırma ve güncellenmiş geometrinin bir şekle nasıl uygulanacağını gösterir. Ayrıca, özel ve bileşik şekiller oluşturmayı, kavisli köşeli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi ve ek geometri özelleştirme senaryoları için `GeometryPath` ile `java.awt.Shape` arasında dönüşüm yapmayı gösterir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**
Bir kareyi düşünün. PowerPoint'te **düzenleme noktalarını** kullanarak şunları yapabilirsiniz

* köşenin içe ya da dışa hareket ettirmek
* bir köşe veya noktanın eğriliğini belirtmek
* kareye yeni noktalar eklemek
* kare üzerindeki noktaları manipüle etmek vb. 

Temelde, bu görevleri herhangi bir şekil üzerinde gerçekleştirebilirsiniz. Düzenleme noktalarını kullanarak bir şekli değiştirebilir veya mevcut bir şekilden yeni bir şekil oluşturabilirsiniz. 

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenleme noktalarıyla düzenlemeye başlamadan önce, şekillerle ilgili şu noktaları göz önünde bulundurabilirsiniz:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Kapalı bir şeklin bir başlangıç ya da bitiş noktası yoktur. Açık bir şeklin ise bir başlangıcı ve bir sonu vardır. 
* Tüm şekiller en az 2 bağlantı noktasından oluşur ve bunlar çizgilerle birbirine bağlanır
* Bir çizgi düz ya da kavisli olabilir. Bağlantı noktaları çizginin niteliğini belirler. 
* Bağlantı noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Köşe noktası, 2 düz çizginin bir açıyla birleştiği noktadır. 
  * Yumuşak nokta, 2 tutamağın düz bir hat üzerinde bulunduğu ve çizgi segmentlerinin sorunsuz bir eğriyle birleştiği noktadır. Bu durumda, tüm tutamaçlar bağlantı noktasından eşit mesafede bulunur. 
  * Düz nokta, 2 tutamağın düz bir hat üzerinde bulunduğu ancak çizgi segmentlerinin bir eğri oluşturduğu noktadır. Bu durumda, tutamaçların bağlantı noktasından eşit mesafede olması gerekmez. 
* Bağlantı noktalarını hareket ettirerek ya da düzenleyerek (çizgilerin açısını değiştirir) şeklin görünümünü değiştirebilirsiniz. 

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [**GeometryPath**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) sınıfını ve [**IGeometryPath**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryPath) arabirimini sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) örneği, [IGeometryShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryShape) nesnesinin geometri yolunu temsil eder.
* `IGeometryShape` örneğinden `GeometryPath` alınıp, [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) yöntemi kullanılarak elde edilebilir.
* Bir şekil için `GeometryPath` ayarlamak için şu yöntemler kullanılabilir: *katı şekiller* için [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) ve *bileşik şekiller* için [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-).
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryPath) altındaki yöntemleri kullanabilirsiniz.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) ve [IGeometryPath.setFillMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryPath#getPathData--) yöntemiyle bir `GeometryShape`ın geometri yolunu yol segmentlerinin bir dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) öğesini [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) öğesine dönüştürebilirsiniz.
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) ve [graphicsPathToGeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) yöntemlerini ([ShapeUtil](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeUtil) sınıfından) kullanarak [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) ile [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) arasında dönüşüm yapabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bu Java kodu size nasıl yapılacağını gösterir

**Bir satır ekle** bir yolun sonuna

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Bir satır ekle** bir yolda belirtilen konuma:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Kübik Bezier eğrisi ekle** bir yolun sonuna:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Kübik Bezier eğrisi ekle** bir yolda belirtilen konuma:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Karesel Bezier eğrisi ekle** bir yolun sonuna:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Karesel Bezier eğrisi ekle** bir yolda belirtilen konuma:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Verilen bir yay ekle** bir yola:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Yolun mevcut şekilini kapat**:

``` java
public void closeFigure();
```
**Sonraki nokta için konumu ayarla**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Verilen bir indeks'teki yol segmentini kaldır**:

``` java
public void removeAt(int index);
```

## **Bir Şekle Özel Noktalar Ekle**
1. [GeometryShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType.Rectangle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) sınıfının bir örneğini alın.
3. Yol üzerindeki iki üst nokta arasında yeni bir nokta ekleyin.
4. Yol üzerindeki iki alt nokta arasında yeni bir nokta ekleyin.
5. Yolu şekle uygulayın.

Bu Java kodu, bir şekle özel noktalar eklemenin nasıl yapılacağını gösterir:

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

## **Şekilden Noktaları Kaldır**

1. [GeometryShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType.Heart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) sınıfının bir örneğini alın.
3. Yolun segmentini kaldırın.
4. Yolu şekle uygulayın.

Bu Java kodu, bir şekilden noktaları kaldırmanın nasıl yapılacağını gösterir:

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

##  **Özel Bir Şekil Oluşturma**

1. Şekil için noktaları hesaplayın.
2. [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) sınıfının bir örneğini oluşturun.
3. Yolu noktalarla doldurun.
4. [GeometryShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun.
5. Yolu şekle uygulayın.

Bu Java kodu, özel bir şekil oluşturmanın nasıl yapılacağını gösterir:

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


## **Bileşik Özel Şekil Oluşturma**

  1. [GeometryShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun.
  2. İlk [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) sınıf örneğini oluşturun.
  3. İkinci [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) sınıf örneğini oluşturun.
  4. Yolları şekle uygulayın.

Bu Java kodu, bileşik bir özel şekil oluşturmayı gösterir:

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

## **Kavisli Köşeli Özel Şekil Oluşturma**

Bu Java kodu, içe doğru kavisli köşelere sahip bir özel şekil oluşturmanın nasıl yapılacağını gösterir;

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

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenin**

Kapalı bir şekil, tüm kenarlarının birbirine bağlandığı ve boşluk bırakmadan tek bir sınır oluşturduğu şekil olarak tanımlanır. Böyle bir şekil basit bir geometrik form ya da karmaşık bir özel kontur olabilir. Aşağıdaki kod örneği, bir şekil geometrisinin kapalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

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

## **GeometryPath'i java.awt.Shape'e Dönüştürme** 

1. [GeometryShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun.
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) sınıfının bir örneğini oluşturun.
3. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) örneğini [ShapeUtil](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeUtil) kullanarak [GeometryPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GeometryPath) örneğine dönüştürün.
4. Yolları şekle uygulayın.

Bu Java kodu—yukarıdaki adımların bir uygulaması—**GeometryPath**'i **GraphicsPath**'e dönüştürme sürecini göstermektedir:

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

    // Şekle yeni geometri yolu ve orijinal geometri yolunun birleşimini ayarla
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometri değiştirildikten sonra dolgu ve kontur ne olur?**

Stil şekilde kalır; sadece kontur değişir. Dolgu ve kontur otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#setRotation-float-) metodunu kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekille birlikte döner.

**Sonucu “kilitlemek” için özel bir şekli görüntüye dönüştürebilir miyim?**

Evet. Gerekli [slaytı](/slides/tr/androidjava/convert-powerpoint-to-png/) alanını ya da [şekli](/slides/tr/androidjava/create-shape-thumbnails/) raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.