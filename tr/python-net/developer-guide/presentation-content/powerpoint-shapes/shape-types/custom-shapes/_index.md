---
title: Python'da Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/python-net/custom-shape/
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
- kavisli köşe
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, kavisli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, sunum şekillerini Aspose.Slides içinde düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek özelleştirmenin nasıl yapılacağını açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, noktalar eklemek veya kaldırmak ve güncellenmiş geometriyi bir şekle geri uygulamak için [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir. Ayrıca, özel ve bileşik şekiller oluşturmayı, kırılmış köşeli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi ve kontur analizi için şekil öğelerini çıkarmayı da gösterir.

## **Bir Şekli Düzenleme Noktalarıyla Değiştirme**

PowerPoint'te bir kareyi **Düzenleme Noktaları** ile değiştirebilirsiniz:

* Köşeyi içe veya dışa doğru hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin dış hatını değiştirmek veya mevcut bir şekli yeni bir şeklin temelini oluşturmak için kullanılır.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken, şu kavramları aklınızda bulundurun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan ankraj noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Ankraj noktaları ve kontrol kulpları şekli belirler.
* Ankraj noktaları köşe noktaları, düz noktalar veya pürüzsüz noktalar olarak bulunur:
  * Köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Pürüzsüz noktada, iki kontrol kulpu hizalanmış ve ankraj noktasına eşit uzaklıktadır.
  * Düz noktada, iki kontrol kulpu hizalanmıştır ancak ankraj noktasına farklı uzaklıklarda olabilir.
* Ankraj noktalarını hareket ettirmek veya kulplarını ayarlamak şeklin dış hatlarını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) sınıfını sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) nesnesinin geometri yolunu temsil eder.
* Bir [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) nesnesini [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) örneğinden almak için [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) metodunu kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ayarlamak üzere şu yöntemleri kullanabilirsiniz: tek yollu şekiller için [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ve çoklu yol içeren şekiller için [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) ve [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) özelliklerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) özelliğini kullanarak bir [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) nin geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.

## **Basit Düzenleme İşlemleri**

Geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir dizin kabul eden aşırı yüklemeler, yolun segment dizisinde sıfır tabanlı konumda bir segment ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya ekleyin. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| İki kontrol noktası ve bir bitiş noktasıyla kübik Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Bir kontrol noktası ve bir bitiş noktasıyla ikinci derece Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Belirtilen boyut ve derecelerde bir eliptik yay ekleyin. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Bitiş noktasını başlangıç noktasına bağlayarak geçerli şekli kapatın. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Şeklin başlangıç noktasını ayarlayın. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Sıfır tabanlı bir dizindeki segmenti kaldırın. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) kullanır ve düzenlenmiş yolu [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ile uygular. Koordinatlar şekle göre yereldir: her iki yeni nokta da şeklin merkezinde, soldan 100 puan ve üstten 50 puan uzakta bulunur. 1 ve 4 segment dizinleri bu noktaları üst ve alt kenarlara yerleştirir ve bu kenarları içe doğru çeker.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Bir Şekilden Noktaları Kaldırma**

Bu örnek, [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) ile sıfır tabanlı 2. dizindeki segmenti kaldırarak kalp şeklindeki dış hatı değiştirir. Değiştirilen yolu [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ile uygulamak şeklin konturunu günceller.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```

![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olması uçları ve girintileri tanımlar; 72 derece adım beş ucu eşit olarak yayar. Yol, [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) ile kapatılır ve [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ile bir dikdörtgen şekle uygulanarak dış hatı değiştirilir.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```

![example3_image](custom_shape_3.png)

## **Bileşik Özel Bir Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte bir kısımları için iki kapalı [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) ile uygulamak, ortasında bir boşluk bulunan tek bir bileşik şekil oluşturur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```

![example4_image](custom_shape_4.png)

## **Kırılmış Köşeli Özel Bir Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) ile birleştirerek içe doğru kıvrımlı köşelere sahip bir şekil oluşturur. Her köşe boyutu yay genişliği ve yüksekliğini puan cinsinden ayarlar ve -90 derece dönme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ile uygulanır ve sunum PPTX formatında kaydedilir.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) okur ve son segmentin [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) değerini [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) ile karşılaştırır. Boş yol olmadığında false döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek, bir dikdörtgen için `True` yazdırır.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Geometri Yol Komutlarını İnceleme**

İndirilen [contour.pptx](contour.pptx) dosyasını çalışma dizininize koyun. İlk slayttaki ilk şeklin düz bir üst kenarı, bir kübik Bézier eğrisi ve düz bir kapanış kenarı vardır. Şeklin yollarını okumak için [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) kullanın. Her yol için, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) segmentleri çizim sırasına göre listeler. Her segmentin [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) onun [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) nasıl yorumlanacağını belirler.

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

Şekil slaytta (200, 100) puan konumundadır. Raporlanan koordinatlar şekle göre yereldir. Üst‑sol köşesi (0, 0)’dır, x sağa, y aşağıya doğru artar. Kapanış segmenti ek koordinat olmadan başlangıç noktasına döner.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![Üst kenarı düz, sağ üstten sol alta doğru kıvrımlı bir kenarı ve sol kenarı düz olan PowerPoint şekli](contour.png)

## **Şekil Öğelerini Çıkarma ve İnceleme**

[GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) kullanarak mevcut bir şekli yol noktaları ve nokta türlerini içeren öğeler olarak inceleyin. Dönen her [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) kendi [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) ve [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) dizilerini gösterir. Bu temsil, kontur analizi ya da geometrinin özel çizim araçlarına aktarılması için faydalıdır.

Örnek bir sunumu açar, ilk slayttaki ilk geometri şeklini doğrudan bulur ve yol segmentlerini yazdırır. Hem düz hem de eğri segment içeren bir şekli içeren bir sunum kullanarak her iki çıktıyı da görebilirsiniz. Grupların içinde arama yapmaz.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Segment tipini koru, bayrakları hariç tut.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Hem kontrol noktalarını hem de bitiş noktasını tüket.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Diziler indeks göre eşleşir: `points[i]` bir noktadır ve `types[i]` onun rolünü tanımlar. Tip `0` bir şekli başlatır, tip `1` önceki noktadan mevcut noktaya bir çizgi çizer. Kübik Bézier segmenti önceki bitiş noktasından başlar ve ardışık üç tip-`3` girdisi kullanır: iki kontrol noktası ve ardından yeni bitiş noktası. Döngü bu üç girişi birlikte tüketir ve bitiş noktasının kapanışını kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi uygulanır ve kapalı bir alt yol tespit etmek için `0x80` ayrı ayrı test edilir. Örneğin, `129` (`0x81`) bir alt yolu kapatan çizgi bitiş noktasını, `131` (`0x83`) ise bir Bézier bitiş noktasını kapatır. Yalnızca ham değeri `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar, X sağa, Y aşağı doğru artan puan (1/72 inç) biriminde ölçülür. Gruplandırılmamış bir şekil için, çıkarılan koordinatlar zaten [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) konumunu içerir ve mevcut genişlik ve yüksekliğini yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` dir. Şeklin konumunu tekrar eklemeyin. X ve Y değerlerini çıkararak döndürülmemiş çerçeveye göre koordinatları elde edin.

Çıkarılan noktalar şeklin [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) ya da yatay ve dikey çevirilerini uygulamaz. Görüntülenen konturu yeniden elde etmek için bu dönüşümleri şeklin merkezi etrafında uygulayın. Gruplandırılmış şekiller için grup koordinat haritalamasını ve dönüşümleri de hesaba katın; çıkarılan noktaların nihai slayt koordinatları olduğunu varsaymayın ve eğer çocuk çerçevesinde zaten yansıtılmışsa bir çeviri veya ölçekleme iki kez uygulanmasın.

**İnceleme ve düzenleme karşılaştırması.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz veya çizim kodunuz nokta/tür dizilerine ihtiyaç duyduğunda bu yöntemi seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyacınız varsa ya da geometrisini düzenlemek istiyorsanız [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) kullanın. Düzenlenmiş yolları [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) veya [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) aracılığıyla uygulayın.

## **SSS**

**Geometriyi değiştirdikten sonra dolgu ve dış hat ne olur?**  
Stil şekille kalır; sadece kontur değişir. Dolgu ve dış hat otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürürüm?**  
Şeklin [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) özelliğini kullanın; geometri şekille birlikte döner çünkü şeklin kendi koordinat sistemine bağlanmıştır.

**Sonucu "kilitlemek" için özel bir şekli görüntüye dönüştürebilir miyim?**  
Evet. Gerekli [slide](/slides/tr/python-net/convert-powerpoint-to-png/) alanını veya [shape](/slides/tr/python-net/create-shape-thumbnails/) öğesini raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.