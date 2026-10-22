---
title: Python ile Java Üzerinden Sunum Şekillerini Özelleştirme
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
- nokta düzenle
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- eğri köşe
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğri köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, şekil geometrisini düzenleme noktaları ve geometri yolları aracılığıyla düzenleyerek Aspose.Slides içinde sunum şekillerini nasıl özelleştireceğinizi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemleri yapmak, nokta eklemek veya kaldırmak ve güncellenen geometriyi bir şekle uygulamak için [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca, özel ve birleşik şekiller oluşturmayı, köşeleri eğimli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi, şekil öğelerini incelemeyi ve Java AWT metin konturlarını geometri yollarına dönüştürmeyi gösterir.

## **Bir Şekli Düzenleme Noktalarıyla Değiştirme**

PowerPoint'te **Düzenleme Noktaları** kullanarak bir kareyi şu şekilde değiştirebilirsiniz:

* Köşeyi içeriye veya dışarıya taşıyın.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin ana hatlarını değiştirmek veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmak için kullanılabilir.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda bulundurun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanmış tutama noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Tutama noktaları ve kontrol sapları şekli belirler.
* Tutama noktaları köşe noktaları, düz noktalar veya pürüzsüz noktalar olarak bulunur:
  * Köşe noktasında, bitişik segmentler bir açıyla birleşebilir.
  * Pürüzsüz noktada, iki kontrol sapı hizalıdır ve tutama noktasına eşit mesafededir.
  * Düz noktada, iki kontrol sapı hizalıdır ancak tutama noktasına farklı mesafelerde olabilir.
* Tutama noktalarını hareket ettirmek veya saplarını ayarlamak şeklin dış hatlarını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) sınıfını sunar.

* Bir [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) nesnesinin bir geometri yolunu temsil eder.
* [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)'ı [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) örneğinden almak için [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) yöntemini kullanabilirsiniz.
* Bir şeklin [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)'ını ayarlamak için şu yöntemleri kullanabilirsiniz: tek bir yola sahip şekiller için [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), birden fazla yola sahip şekiller için [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) altında bulunan yöntemleri kullanabilirsiniz.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) ve [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) yöntemini kullanarak bir [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)'ın geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)'ı [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) aracılığıyla okuyabilir ve segmentleri bir [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) üzerine yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir indeks kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki sıfır tabanlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya ekleyin. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| İki kontrol noktası ve bir son nokta içeren kübik Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Bir kontrol noktası ve bir son nokta içeren ikinci dereceli Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Belirtilen ölçüler ve derece cinsinden açılarıyla eliptik bir yay ekleyin. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Şu anki şekli, son noktasını başlangıç noktasına bağlayarak kapatın. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Bir şeklin başlangıç noktasını ayarlayın. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Sıfır tabanlı bir indeksdeki segmenti kaldırın. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekle iki nokta ekler; [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) kullanılır ve düzenlenmiş yol, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır. Koordinatlar şekle göre yereldir: iki yeni nokta da şeklin merkezindedir, soldan 100 puan ve üstten 50 puan uzakta. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirir ve bu kenarları içeri çeker.

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

Bu örnek, bir kalp şeklinin dış hattını [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) kullanarak sıfır tabanlı 2 indeksindeki segmenti kaldırarak değiştirir. Değiştirilen yol, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır ve şeklin konturu güncellenir.

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

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. Dış ve iç yarıçapların 100 ve 50 puan olarak değişmesi, uçları ve girintileri tanımlar; 72 derece adım, beş ucu eşit aralarla yerleştirir. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) ile kapatılır ve [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) kullanılarak bir dikdörtgen şekle uygulanır, böylece dış hattı değiştirilir.

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

Bu örnek, bir şeklin üst ve alt üçte birleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yol da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulanarak ortasındaki bir boşlukla tek bir birleşik şekil oluşturulur.

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

## **Eğri Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) ile birleştirerek içe doğru eğimli köşelere sahip bir şekil üretir. Her köşe boyutu, yay genişliği ve yüksekliğini puan cinsinden ayarlar; -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır ve sunum PPTX formatında kaydedilir.

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

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenin**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) okunur ve son segmentin [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) değeri [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) ile karşılaştırılır. Boş yol olmadığında `False` döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek, bir dikdörtgen için `True` yazdırır.

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

## **Şekil Öğelerini Çıkarma ve İnceleme**

Mevcut bir şekli, yol noktaları ve nokta türleri içeren öğeler olarak incelemek için [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) kullanın. Döndürülen her öğeyi `jpype.JObject` ile [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) tipine dönüştürerek [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) ve [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) yöntemleriyle nokta ve tür dizilerini alın. Bu temsil, kontur analizi veya geometriyi özel çizim araçlarına aktarmak için yararlıdır.

Örnek, input.pptx dosyasını açar, ilk slayttaki ilk geometry şeklini bulur ve yol segmentlerini yazdırır. Hem düz hem de eğri segmentlere sahip bir şekil içeren bir sunum kullanarak her iki çıktıyı da görebilirsiniz. Gruplar içinde arama yapmaz.

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
                point_type = types[i] & 0x07  # Segment tipini tut, bayrakları hariç.
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

Diziler indeks bazında eşleşir: `points[i]` bir nokta, `types[i]` ise onun rolünü tanımlar. Tür `0` bir şekli başlatır, tür `1` önceki noktadan mevcut noktaya doğru bir çizgi çizer. Kübik Bézier segmenti, önceki son noktadan başlar ve üç ardışık tür-`3` girdisini kullanır: iki kontrol noktası ve yeni son nokta. Döngü bu üç girişi birlikte işler ve son noktanın kapalı olup olmadığını kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesini, kapalı bir alt yolu tespit etmek için ise `0x80` bayrağını ayrı ayrı test edin. Örneğin `129` (`0x81`) bir satır son noktası olup alt yolu kapatır, `131` (`0x83`) ise bir Bézier son noktası olup birini kapatır. Java bu bayrakları imzalı byte olarak saklar; maskelenmesi istenen bit değerlerini korur. Sadece `1` veya `3` ile ham değeri karşılaştırmak bu durumları kaçırır. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) biriminde ölçülür; X sağa, Y aşağı doğru artar. Gruplandırılmamış bir şekil için çıkarılan koordinatlar, zaten [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) ve [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin. X ve Y değerlerini çıkararak koordinatları döndürülmemiş çerçeveye göre elde edin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) tarafından döndürülen şekil dönüşünü veya yatay ve dikey çevirileri içermez. Görüntülenen konturu yeniden üretmek için bu dönüşümleri şeklin merkezine göre uygulayın. Gruplandırılmış şekillerde ayrıca grup koordinat haritalamasını ve dönüşümleri de hesaba katın; çıkarılan noktaların slayt üzerinde son render koordinatları olduğunu varsaymayın ve zaten çocuğun çerçevesinde yansıtılmışsa bir çeviri ya da ölçeklendirmeyi iki kez uygulamayın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz veya çizim kodunuz nokta/tür dizilerine ihtiyaç duyuyorsa bu yaklaşımı seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyacınız varsa veya geometrisini düzenlemek istiyorsanız [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) veya [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) aracılığıyla uygulayın.

## **Java AWT Şekilini GeometryPath'e Dönüştürme**

Bu örnek, metne dönüştürülmüş bir geometriyle bir dikdörtgen konturunu birleştirir. Konturun [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) yöntemi doldurulmasını devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html), bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin konturunu oluşturur. Onun [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceli, kübik ve kapatma segmentleri sağlar; örnek bunları bir [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) üzerinde yeniden oynatır.

Metin, 40 puanlık Arial yazı tipinde kullanılır. Kontur, yatay olarak 20 puan kaydırılır ve görsel üstü, şeklin üst kenarının 10 puan altında konumlandırılır. Metin yolu doldurulurken, orijinal dikdörtgen sadece bir kontur kalır. Her iki yol da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulanarak dikdörtgen ve metni içeren tek bir şekil üretilir.

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

    # Metinle yeni bir grafik yolu oluştur.
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

**Geometriyi değiştirdikten sonra dolgu ve kenarlık ne olur?**  
Stil şekille kalır; yalnızca kontur değişir. Dolgu ve kenarlık yeni geometriye otomatik olarak uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürürüm?**  
Şeklin [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) yöntemini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğu için şekil ile birlikte döner.

**Sonucu "kilitlemek" için özel bir şekli bir görüntüye dönüştürebilir miyim?**  
Evet. Gereken [slayt](/slides/tr/python-java/convert-powerpoint-to-png/) alanını ya da [şekil](/slides/tr/python-java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı basitleştirir.