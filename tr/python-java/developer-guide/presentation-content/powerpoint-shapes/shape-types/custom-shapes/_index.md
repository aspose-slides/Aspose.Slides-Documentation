---
title: Python ile Java üzerinden Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/python-java/custom-shape/
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
- yuvarlatılmış köşe
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, yuvarlatılmış köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek özelleştirmenin nasıl yapılacağını açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenmiş geometrinin bir şekle geri uygulanmasını göstermek için [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca özel ve birleşik şekiller oluşturmayı, yuvarlatılmış köşeli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi, şekil öğelerini incelemeyi ve Java AWT metin taslaklarını geometrik yollara dönüştürmeyi de demonstr eder.

## **Düzenleme Noktalarını Kullanarak Bir Şekli Değiştirme**

PowerPoint'te **Edit Points** kullanarak bir kareyi değiştirebilirsiniz:

* Bir köşeyi içe veya dışa hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin dış hatlarını değiştirmenizi veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmanızı sağlar.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken aşağıdaki kavramları aklınızda tutun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan çapa noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Çapa noktaları ve kontrol tutamaçları şeklin şeklini belirler.
* Çapa noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Köşe noktasında, bitişik segmentler bir açı ile buluşabilir.
  * Yumuşak noktada, iki kontrol tutamağı hizalanır ve çapa noktasına eşit mesafededir.
  * Düz noktada, iki kontrol tutamağı hizalanır ancak çapa noktasına farklı mesafelerde olabilir.
* Çapa noktalarını hareket ettirmek veya tutamaçlarını ayarlamak şeklin dış hattını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) sınıfını sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) nesnesinin bir geometri yolunu temsil eder.
* [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) elde etmek için [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) metodunu kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ayarlamak üzere şu metodları kullanabilirsiniz: tek bir yolu olan şekiller için [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), birden çok yolu olan şekiller için [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) altındaki metodları kullanabilirsiniz.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) ve [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) metodlarıyla bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) metoduyla bir [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) yolunu yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometrisi özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) nesnesini [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) aracılığıyla okuyup segmentleri bir [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) üzerine yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Aşağıdaki metodları kullanarak bir geometri yolunu düzenleyin. Dizini kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki o sıfır tabanlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya ekleyin. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| İki kontrol noktası ve bir uç noktası olan kübik Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Bir kontrol noktası ve bir uç noktası olan ikinci dereceden Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Belirtilen boyut ve derecelerde bir eliptik yay ekleyin. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Uç noktasını başlangıç noktasına bağlayarak mevcut şekli kapatın. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Bir şeklin başlangıç noktasını ayarlayın. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Sıfır tabanlı bir dizinde bir segmenti kaldırın. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) kullanır ve düzenlenmiş yolu [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ile uygular. Koordinatlar şekle göre lokal olup, her iki yeni nokta da merkezde, soldan 100 puan ve üstten 50 puan uzaktadır. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirerek bu kenarları içe doğru çeker.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Bir Şekilden Noktaları Kaldırma**

Bu örnek, [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) ile sıfır tabanlı 2. indeksteki segmenti kaldırarak kalp şeklindeki dış hattı değiştirir. Değiştirilmiş yolu [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulamak şeklin konturunu günceller.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olarak kullanılması, uçları ve girintileri tanımlar; 72 derece adım beş ucu eşit aralıklarla yerleştirir. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) ile kapatılır ve [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ile dikdörtgen bir şekle uygulanarak dış hattı değiştirilir.

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
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Bileşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte birleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulamak, orta üçte birinde bir boşluk oluşturan tek bir bileşik şekil üretir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Yuvarlatılmış Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) ile birleştirerek içe doğru kavisli köşelere sahip bir şekil oluşturur. Her köşenin boyutu, yay genişliği ve yüksekliğini puan cinsinden ayarlar ve -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır ve sunum PPTX formatında kaydedilir.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

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

Aşağıdaki yardımcı, her dolu olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) okur ve son segmentin [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) değerini [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) ile karşılaştırır. Boş olmayan yol olmadığında `False` döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek bir dikdörtgen için `True` yazdırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Geometri Yol Komutlarını İnceleme**

[contour.pptx](contour.pptx) dosyasını indirip uygulamanın çalışma dizinine koyun. İlk slayttaki ilk şekil, düz bir üst kenar, bir kübik Bézier eğrisi ve düz bir kapanış kenarı içerir. Şeklin yollarını okumak için [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) ve her yolun segmentlerini çizim sırasıyla okumak için [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) kullanın. Her segment için [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) komutu tanımlar ve [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) tarafından döndürülen değerlerin nasıl yorumlanacağını belirler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

Şekil slaytta (200, 100) puan konumundadır. Bildirilen koordinatlar şekle göre lokaldir; (0, 0) şeklin sol üst köşesindedir, x sağa, y aşağı doğru artar. Kapanış segmenti, ek koordinat olmadan başlangıç noktasına döner.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Üst kenarı düz, sağ üstten sol alta doğru eğimli bir kenarı ve sol kenarı düz olan PowerPoint şekli](contour.png)

## **Şekil Öğelerini Çıkarma ve İnceleme**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) metodunu kullanarak mevcut bir şekli yol noktaları ve nokta tiplerini içeren öğeler olarak inceleyebilirsiniz. Dönen her öğeyi `jpype.JObject` ile [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) tipine dönüştürüp [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) ve [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) metodlarıyla nokta ve tip dizilerini alabilirsiniz. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına geçirilmesi için kullanışlıdır.

Örnek, input.pptx dosyasını açar, ilk slayttaki ilk geometri şeklini doğrudan bulur ve yol segmentlerini yazdırır. Hem düz hem de eğimli segmentler içeren bir şeklin bulunduğu bir sunum kullanın; grup içindeki şekilleri taramaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Diziler indeks bazında eşleşir: `points[i]` bir nokta, `types[i]` ise onun rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` önceki noktadan mevcut noktaya bir çizgi çizer. Kübik Bézier segmenti önceki uç noktadan başlar ve ardışık üç tip-`3` girdisi kullanır: iki kontrol noktası ve yeni uç nokta. Döngü bu üç girdiyi birlikte tüketir ve kapanış için uç noktayı kontrol eder.

Nokta tipleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesini, kapalı alt yolu algılamak için `0x80` bayrağını ayrı ayrı test edin. Örneğin, `129` (`0x81`) bir hattı kapatan uç nokta, `131` (`0x83`) ise bir Bézier ucunu kapatır. Java bu bayrakları işaretli baytlar olarak saklar; maskeleme doğru bit değerlerini korur. Sadece `1` veya `3` ile ham değeri karşılaştırmak bu durumları göz ardı eder. Çizgi (`0x10`) ve işaretleyici (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) cinsinden ölçülür, X sağa, Y aşağı artar. Gruplandırılmamış bir şekil için çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) ve [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda, `120 × 80` boyutlu döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` olur. Şeklin konumunu tekrar eklemeyin. X ve Y değerlerini çıkararak döndürülmemiş çerçeveye göre koordinatları elde edin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) tarafından döndürülen şekil rotasyonunu veya yatay/vertikal çevirileri içermez. Görüntülenen konturu yeniden oluşturmak için bu dönüşümleri şeklin merkezine göre uygulayın. Gruplandırılmış şekillerde ayrıca grup koordinat haritalaması ve dönüşümlerini hesaba katın; çıkarılan noktaların slaytın nihai render koordinatları olduğunu varsaymayın ve eğer zaten çocuğun çerçevesinde yansıtılmışsa bir çeviri veya ölçekleme iki kez uygulanmasın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; değiştirilmesi orijinal şekli güncellemez. Analiz veya çizim kodunuz nokta/tip dizilerine ihtiyaç duyduğunda bu yaklaşımı seçin. Şeklin yerel koordinat sisteminde geometri komutlarına ihtiyacınız varsa veya geometrisini düzenlemek istiyorsanız [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) veya [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulayın.

## **Java AWT Şeklini GeometryPath'e Dönüştürme**

Bu örnek, metni geometrik olarak dönüştürülmüş bir dikdörtgen dış hattı ile birleştirir. Dış hattın [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) metodu doldurulmasını devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin dış hattını oluşturur. Bunun [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceden, kübik ve kapanış segmentlerini sağlar; örnek bunları bir [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) üzerine yeniden oynatır.

Metin, 40 puan Arial yazı tipinde kullanılır. Dış hat, yatayda 20 puan kaydırılır ve şeklin üst kenarının 10 puan altında görsel üst kenarı konumlandırılır. Metin yolu doldurulur, orijinal dikdörtgen ise yalnızca dış hat olarak kalır. Her iki yolu da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulamak, dikdörtgen ve metni içeren tek bir şekil üretir.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Şeklin geometri yolunu al.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Metin ile yeni bir grafik yolu oluştur.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
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

## **FAQ**

**Geometriyi değiştirdikten sonra dolgu ve kontur ne olur?**

Stil şekil ile kalır; sadece kontur değişir. Dolgu ve kontur otomatik olarak yeni geometrinin üzerine uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) metodunu kullanın; geometrinin şekille birlikte dönmesi, şeklin kendi koordinat sistemine bağlı olmasından kaynaklanır.

**Sonucu "kilitlemek" için özel bir şekli bir görüntüye dönüştürebilir miyim?**

Evet. Gerekli [slayt](/slides/tr/python-java/convert-powerpoint-to-png/) bölgesini veya [şekil](/slides/tr/python-java/create-shape-thumbnails/) kendisini raster formata dışa aktarın; bu, karmaşık geometrilerle sonraki çalışmayı basitleştirir.