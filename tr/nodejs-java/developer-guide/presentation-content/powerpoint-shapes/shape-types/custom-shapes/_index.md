---
title: JavaScript ile Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/nodejs-java/custom-shape/
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
- eğri köşe
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğri köşeler, bileşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta şekil geometrisini düzenleme noktaları ve geometri yolları aracılığıyla özelleştirerek sunum şekillerinin nasıl özelleştirileceğini açıklar. `GeometryPath` kullanarak mevcut şekilleri değiştirmek, temel yol düzenleme işlemleri yapmak, nokta eklemek veya kaldırmak ve güncellenmiş geometriyi bir şekle uygulamak gösterilir.

Ayrıca özel ve bileşik şekiller oluşturma, köşeleri eğimli şekiller inşa etme, bir şekil geometrisinin kapalı olup olmadığını belirleme ve ek geometri özelleştirme senaryoları için `GeometryPath` ile `java.awt.Shape` arasında dönüşüm yapma konuları da gösterilir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

Bir kareyi düşünün. PowerPoint'te **düzenleme noktaları** kullanarak

* karenin köşesini içeri ya da dışarı hareket ettirebilir,
* bir köşe ya da noktanın eğriliğini belirleyebilir,
* kareye yeni noktalar ekleyebilir,
* karenin üzerindeki noktaları manipüle edebilir, vb.

Temelde, bu görevleri herhangi bir şekil üzerinde gerçekleştirebilirsiniz. Düzenleme noktalarıyla mevcut bir şekilden yeni bir şekil oluşturabilir ya da şekli değiştirebilirsiniz.

## **Şekil Düzenleme İpuçları**

![genel_bakış_resmi](custom_shape_0.png)

PowerPoint şekillerini düzenleme noktalarıyla düzenlemeye başlamadan önce şekiller hakkında şu noktalara göz atmanız faydalı olabilir:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Şekil kapalıysa bir başlangıç ya da bitiş noktasına sahip değildir. Açık bir şeklin bir başlangıcı ve bitişi vardır. 
* Tüm şekiller en az 2 köşe noktasından oluşur ve bu noktalar birbirine çizgilerle bağlanır.
* Bir çizgi ya düz ya da eğridir. Köşe noktaları çizginin niteliğini belirler. 
* Köşe noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Köşe noktası, iki düz çizginin bir açıyla birleştiği noktadır. 
  * Yumuşak nokta, iki tutamağın aynı doğrultuda olduğu ve çizgi segmentlerinin yumuşak bir eğriyle birleştiği noktadır. Bu durumda tüm tutamaçlar köşe noktasından eşit mesafede bulunur. 
  * Düz nokta, iki tutamağın aynı doğrultuda olduğu ve çizgi segmentlerinin yumuşak bir eğriyle birleştiği noktadır. Bu durumda tutamaçlar köşe noktasından eşit mesafede olmak zorunda değildir. 
* Köşe noktalarını hareket ettirerek veya düzenleyerek (çizgi açılarını değiştirerek) şeklin görünümünü değiştirebilirsiniz. 

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides** aşağıdaki **GeometryPath** sınıfını sunar:

* Bir [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) örneği, [GeometryShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape) nesnesinin bir geometri yolunu temsil eder.
* `GeometryShape` örneğinden `GeometryPath` elde etmek için [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) metodunu kullanabilirsiniz.
* Bir şeklin `GeometryPath` değerini ayarlamak için *katı şekiller* için [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) ve *bileşik şekiller* için [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) metodlarını kullanabilirsiniz.
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) altındaki metodları kullanabilirsiniz.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) ve [GeometryPath.setFillMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) metodlarıyla bir geometri yolunun görünümünü belirleyebilirsiniz.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath#getPathData--) metodunu kullanarak bir `GeometryShape`ın geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) nesnesini [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) nesnesine dönüştürebilirsiniz.
* [ShapeUtil](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeUtil) sınıfındaki [geometryPathToGraphicsPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) ve [graphicsPathToGeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) metodlarıyla [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) ve [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) arasında ileri ve geri dönüşüm yapabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bu JavaScript kodu, aşağıdakileri göstermek için hazırlanmıştır:

**Yolun sonuna bir çizgi ekleme**

```javascript
lineTo(point);
lineTo(x, y);
```
**Yol üzerindeki belirli bir konuma bir çizgi ekleme**:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Yolun sonuna bir kübik Bezier eğrisi ekleme**:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Yol üzerindeki belirli bir konuma bir kübik Bezier eğrisi ekleme**:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Yolun sonuna bir ikinci dereceden Bezier eğrisi ekleme**:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Yol üzerindeki belirli bir konuma ikinci dereceden Bezier eğrisi ekleme**:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Yola verilen bir yay ekleme**:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Yolun mevcut figürünü kapatma**:

```javascript
closeFigure();
```
**Bir sonraki nokta için konum ayarlama**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Belirli bir indeksteki yol segmentini kaldırma**:

```javascript
removeAt(index);
```

## **Şekle Özel Noktalar Ekleme**
1. [GeometryShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType.Rectangle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) örneği alın.
3. Yoldaki iki üst nokta arasına yeni bir nokta ekleyin.
4. Yoldaki iki alt nokta arasına yeni bir nokta ekleyin.
5. Yolu şekle uygulayın.

Bu JavaScript kodu, bir şekle özel noktalar eklemeyi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![örnek1_resmi](custom_shape_1.png)

## **Şekilden Noktaları Kaldırma**

1. [GeometryShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType.Heart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) örneği alın.
3. Yoldaki segmenti kaldırın.
4. Yolu şekle uygulayın.

Bu JavaScript kodu, bir şekilden noktaları kaldırmayı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![örnek2_resmi](custom_shape_2.png)

## **Özel Şekil Oluşturma**

1. Şeklin noktalarını hesaplayın.
2. Bir [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) örneği oluşturun.
3. Yolu noktalarla doldurun.
4. Bir [GeometryShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape) örneği oluşturun.
5. Yolu şekle uygulayın.

Bu JavaScript, özel bir şekil oluşturmayı gösterir:

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![örnek3_resmi](custom_shape_3.png)


## **Bileşik Özel Şekil Oluşturma**

1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape) örneği oluşturun.
2. İlk bir [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) örneği oluşturun.
3. İkinci bir [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) örneği oluşturun.
4. Yolları şekle uygulayın.

Bu JavaScript kodu, bileşik bir özel şekil oluşturmayı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![örnek4_resmi](custom_shape_4.png)

## **Eğrisiz Köşeli Özel Şekil Oluşturma**

Bu JavaScript kodu, içe doğru eğimli köşelere sahip bir özel şekil oluşturmayı gösterir:

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Kapalı bir şekil, tüm kenarları birbirine bağlanarak boşluk bırakmadan tek bir sınır oluşturur. Bu şekil basit bir geometrik form ya da karmaşık bir özel kontur olabilir. Aşağıdaki kod örneği, bir şekil geometrisinin kapalı olup olmadığını kontrol etmeyi gösterir:

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **GeometryPath'i java.awt.Shape'e Dönüştürme**

1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape) örneği oluşturun.
2. Bir [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) örneği oluşturun.
3. [ShapeUtil](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeUtil) kullanarak [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) örneğini [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryPath) örneğine dönüştürün.
4. Yolları şekle uygulayın.

Bu JavaScript kodu—yukarıdaki adımların bir uygulaması—**GeometryPath**'i **GraphicsPath**'e dönüştürme sürecini gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Yeni şekil oluştur
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Şeklin geometri yolunu al
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Metin içeren yeni grafik yolu oluştur
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Grafik yolunu geometri yoluna dönüştür
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Şekle yeni geometri yolu ve orijinal geometri yolunun kombinasyonunu ayarla
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![örnek5_resmi](custom_shape_5.png)

## **SSS**

**Geometriyi değiştirdikten sonra doldurma ve kenarlık ne olur?**

Stil şekil ile birlikte kalır; sadece kontur değişir. Doldurma ve kenarlık yeni geometriye otomatik olarak uygulanır.

**Özel bir şekli ve geometrisini doğru şekilde nasıl döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/setrotation/) metodunu kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekille birlikte döner.

**Özel bir şekli bir görüntüye dönüştürüp sonucu “kilitleyebilir” miyim?**

Evet. Gerekli [slaytı](/slides/tr/nodejs-java/convert-powerpoint-to-png/) alanını ya da [şekli](/slides/tr/nodejs-java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, ağır geometrilerle çalışmayı basitleştirir.