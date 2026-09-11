---
title: Python üzerinden Java ile Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/python-java/custom-shape/
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
- eğri köşe
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğri köşeler, bileşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştireceğinizi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenen geometriyi bir şekle uygulamak için [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca, özel ve bileşik şekiller oluşturma, eğri köşeli şekiller inşa etme, bir şekil geometrisinin kapalı olup olmadığını belirleme ve ek geometri özelleştirme senaryoları için [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) ile [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) arasında dönüştürme yöntemlerini de gösterir.

## **Düzenleme Noktaları Kullanarak Bir Şekli Değiştirme**

Bir kareyi düşünün. PowerPoint'te **düzenleme noktaları** kullanarak

* karenin köşesini içe ya da dışa hareket ettirebilir,
* bir köşe ya da noktanın kıvrımını belirleyebilir,
* kareye yeni noktalar ekleyebilir,
* karenin üzerindeki noktaları manipüle edebilir, vb.

Temelde, bu görevleri herhangi bir şekil üzerinde gerçekleştirebilirsiniz. Düzenleme noktaları sayesinde bir şekli değiştirebilir veya mevcut bir şekilden yeni bir şekil oluşturabilirsiniz.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenleme noktalarıyla düzenlemeye başlamadan önce, şekillerle ilgili şu noktalara dikkat etmek isteyebilirsiniz:

* Bir şeklin (veya yolunun) kapalı ya da açık olabilir.
* Şekil kapalıysa bir başlangıç ya da bitiş noktası yoktur. Açık bir şeklin ise bir başlangıcı ve bir bitişi vardır.
* Tüm şekiller en az 2 adet birbirine çizgiyle bağlanmış tutma noktasına sahiptir.
* Bir çizgi düz veya eğri olabilir. Tutma noktaları çizginin doğasını belirler.
* Tutma noktaları köşe noktası, düz nokta veya yumuşak nokta olarak bulunur:
  * Köşe noktası, iki düz çizginin bir açıyla birleştiği noktadır.
  * Yumuşak nokta, iki tutamağın düz bir hatta bulunduğu ve çizgi segmentlerinin sorunsuz bir eğriyle birleştiği noktadır. Bu durumda tüm tutamaçlar tutma noktasından eşit mesafede bulunur.
  * Düz nokta, iki tutamağın düz bir hatta bulunduğu ancak tutamaçların tutma noktasından eşit mesafede olmak zorunda olmadığı noktadır.
* Tutma noktalarını (çizgi açılarını değiştiren) hareket ettirerek veya düzenleyerek şeklin görünümünü değiştirebilirsiniz.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) sınıfını sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) nesnesinin geometri yolunu temsil eder.
* [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) elde etmek için [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/#getGeometryPaths) metodunu kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) ayarlamak istiyorsanız, *katı şekiller* için [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/#setGeometryPath), *bileşik şekiller* için ise [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/#setGeometryPaths) metodlarını kullanabilirsiniz.
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) altındaki metodları kullanabilirsiniz.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/#setStroke) ve [GeometryPath.setFillMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/#setFillMode) metodlarıyla bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/#getPathData) metodunu kullanarak bir [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) nin geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) i [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) a dönüştürebilirsiniz.
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeutil/) ve [graphicsPathToGeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeutil/) metodlarını ([ShapeUtil](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeutil/) sınıfından) kullanarak [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) i [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) e ve tersine dönüştürebilirsiniz.

## **Basit Düzenleme İşlemleri**

Aşağıdaki imzalar temel düzenleme işlemlerini gösterir:

**Bir yola bir çizgi ekle**:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Belirli bir konuma bir çizgi ekle**:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Bir yola bir kübik Bezier eğrisi ekle**:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Belirli bir konuma bir kübik Bezier eğrisi ekle**:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Bir yola bir ikinci dereceden Bezier eğrisi ekle**:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Belirli bir konuma bir ikinci dereceden Bezier eğrisi ekle**:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Verilen bir yay ekle**:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Mevcut figürü kapat**:

- `geometry_path.closeFigure()`

**Sonraki nokta için konumu ayarla**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Belirli bir indeksteki yol segmentini kaldır**:

- `geometry_path.removeAt(index)`

## **Bir Şekle Özel Noktalar Ekleme**
1. [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) sınıfından bir örnek oluşturun ve [ShapeType.Rectangle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/#Rectangle) tipini ayarlayın.
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) örneği alın.
3. Yol üzerindeki iki üst nokta arasına yeni bir nokta ekleyin.
4. Yol üzerindeki iki alt nokta arasına yeni bir nokta ekleyin.
5. Yolu şekle uygulayın.

Bu Python kodu, bir şekle özel noktalar eklemenizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Şekilden Noktalar Kaldırma**

1. [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) sınıfından bir örnek oluşturun ve [ShapeType.Heart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/#Heart) tipini ayarlayın. 
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) örneği alın.
3. Yol için segmenti kaldırın.
4. Yolu şekle uygulayın.

Bu Python kodu, bir şekilden noktaları nasıl kaldıracağınızı gösterir:

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

1. Şeklin noktalarını hesaplayın.
2. Bir [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) örneği oluşturun. 
3. Yolu noktalarla doldurun.
4. Bir [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) örneği oluşturun. 
5. Yolu şekle uygulayın.

Bu Python kodu, özel bir şekil oluşturmanızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Bileşik Özel Şekil Oluşturma**

1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) örneği oluşturun.
2. İlk bir [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) örneği oluşturun.
3. İkinci bir [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) örneği oluşturun.
4. Path'leri şekle uygulayın.

Bu Python kodu, bileşik bir özel şekil oluşturmanızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Eğri Köşeli Özel Şekil Oluşturma**

Bu Python kodu, içe doğru eğri köşeli bir özel şekil oluşturmanızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    shape.setGeometryPath(geometry_path)
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Kapalı bir şekil, tüm kenarlarının birleştiği ve boşluk bırakmadan tek bir sınır oluşturduğu şekil olarak tanımlanır. Bu şekil basit bir geometrik form ya da karmaşık bir özel kontur olabilir. Aşağıdaki kod örneği, bir şekil geometrisinin kapalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **GeometryPath'ı java.awt.Shape'ye Dönüştürme**

1. Bir [GeometryShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/) örneği oluşturun.
2. Bir [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) örneği oluşturun.
3. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) örneğini, [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) üzerinden yürüyerek ve her segmenti yolda yeniden oynatarak [GeometryPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometrypath/) örneğine dönüştürün.
4. Path'leri şekle uygulayın.

Bu Python kodu, bir grafik yolunu geometri yoluna dönüştürmek için yukarıdaki adımları uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    # Yeni bir şekil oluştur.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Şeklin geometri yolunu alın.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Metinle yeni bir grafik yolu oluştur.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Grafik yolunu geometri yoluna dönüştür.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Metin yolunu orijinal geometri yolu ile birlikte uygula.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometriyi değiştirdikten sonra dolgu ve kenarlık ne olur?**

Stil şekille kalır; sadece kontur değişir. Dolgu ve kenarlık otomatik olarak yeni geometriye uygulanır.

**Özel şekli ve geometrisini nasıl doğru şekilde döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setRotation) metodunu kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekilyle birlikte döner.

**Özel şekli bir görüntüye dönüştürüp sonucu “kilitleyebilir” miyim?**

Evet. Gerekli [slide](/slides/tr/python-java/convert-powerpoint-to-png/) alanını ya da [shape](/slides/tr/python-java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, ağır geometrilerle çalışmayı kolaylaştırır.