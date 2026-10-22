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
- eğri köşe
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğri köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştireceğinizi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemleri yapmak, nokta eklemek veya kaldırmak ve güncellenen geometriyi bir şekle geri uygulamak için [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca özel ve birleşik şekiller oluşturmayı, eğri köşeli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi ve kontur analizleri için şekil elemanlarını çıkarmayı da gösterir.

## **Düzenleme Noktalarını Kullanarak Bir Şekli Değiştirme**

* Bir köşeyi içe ya da dışa doğru hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktalarını kullanarak bir şeklin dış hatlarını değiştirebilir veya mevcut bir şekli yeni bir şeklin temeli olarak kullanabilirsiniz.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda bulundurun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanmış tutma noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Tutma noktaları ve kontrol tutamaçları şekli belirler.
* Tutma noktaları köşe noktası, düz nokta veya düzgün nokta olarak bulunur:
  * Köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Düzgün noktada, iki kontrol tutamaçı hizalıdır ve tutma noktasına eşit mesafededir.
  * Düz nokta için, iki kontrol tutamaçı hizalıdır ancak tutma noktasına farklı mesafelerde olabilir.
* Tutma noktalarını taşımak veya tutamaçlarını ayarlamak, şeklin dış hatlarını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) sınıfını sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) nesnesinin geometri yolunu temsil eder.
* Bir [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) almak için [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) yöntemini kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ayarlamak için şu yöntemleri kullanabilirsiniz: tek bir yola sahip şekiller için [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ve birden çok yola sahip şekiller için [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) ve [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) özelliklerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) özelliğiyle bir [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)​'in geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.

## **Basit Düzenleme İşlemleri**

Aşağıdaki yöntemleri kullanarak bir geometri yolunu düzenleyin. Bir indeks kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki sıfır tabanlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya araya ekleyin. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| İki kontrol noktası ve bir son nokta içeren kübik Bézier eğrisi ekleyin veya araya ekleyin. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Bir kontrol noktası ve bir son nokta içeren ikincil Bézier eğrisi ekleyin veya araya ekleyin. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Belirtilen boyut ve derecelerde bir eliptik yay ekleyin. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Bitiş noktasını başlangıç noktasına bağlayarak geçerli şekli kapatın. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Şeklin başlangıç noktasını ayarlayın. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Sıfır tabanlı bir indeksdeki segmenti kaldırın. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekle iki nokta eklemek için [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) kullanır ve düzenlenmiş yolu [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ile uygular. Koordinatlar şekle göre lokal olup, her iki yeni nokta da şeklin ortasında, soldan 100 puan ve yukarıdan 50 puan uzaklıktadır. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirir ve bu kenarları içe doğru çeker.

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

Bu örnek, [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) ile sıfır tabanlı 2 indeksindeki segmenti kaldırarak bir kalp şeklinin dış hattını değiştirir. Değiştirilen yolu [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ile uygulamak şeklin konturunu günceller.

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

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olarak kullanılması, uçları ve girintileri tanımlar; 72 derecelik adım beş ucu eşit şekilde aralar. Yol, [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) ile kapatılır ve [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) kullanılarak dikdörtgen bir şekle uygulanır, böylece dış hatı değiştirilir.

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

## **Bileşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte birleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) ile uygulamak, ortasındaki boşlukla tek bir bileşik şekil oluşturur.

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

## **Eğri Köşeli Özel Şekil Oluşturma**

Bu örnek, doğrudan segmentleri [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) ile birleştirerek içe doğru eğri köşeli bir şekil üretir. Her köşe boyutu, yayı puan cinsinden genişlik ve yükseklik olarak ayarlar ve -90 derecelik tarama, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ile uygulanır ve sunum PPTX formatında kaydedilir.

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

Aşağıdaki yardımcı, her dolu olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) okunur ve son segmentin [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) değeri [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) ile karşılaştırılır. Boş olmayan yollar yoksa false döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek, bir dikdörtgen için `True` yazdırır.

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

## **Şekil Elemanlarını Çıkar ve İncele**

Mevcut bir şekli, yol noktaları ve nokta türleri içeren elemanlar olarak incelemek için [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) kullanın. Her döndürülen [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) kendi [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) ve [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) dizilerini ortaya koyar. Bu temsil, kontur analizleri veya geometrinin özel çizim araçlarına aktarılması için faydalıdır.

Örnek, bir sunumu açar, ilk slayttaki ilk geometri şeklini bulur ve yol segmentlerini yazdırır. Hem düz hem de eğri segmentler içeren bir şekil içeren bir sunum kullanın; grup içindeki şekilleri aramaz.

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
                point_type = types[i] & 0x07  # Segment tipini tut, bayrakları hariç tut.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Hem kontrol noktalarını hem de son noktayı tüket.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Diziler indeks bazında eşleşir: `points[i]` bir noktadır ve `types[i]` onun rolünü tanımlar. Tip `0` bir şekli başlatır, tip `1` önceki noktadan geçerli noktaya doğru bir çizgi çizer. Kübik Bézier segmenti önceki son noktada başlar ve üç ardışık tip‑`3` girdisi kullanır: iki kontrol noktası ardından yeni son nokta. Döngü bu üç girişi birlikte tüketir ve son noktanın kapalı olup olmadığını kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi, kapalı bir alt yolu tespit etmek için `0x80` ayrı olarak test edilir. Örneğin, `129` (`0x81`) bir alt yolu kapatan bir çizgi son noktası, `131` (`0x83`) ise bir Bézier son noktasıdır. Yalnızca `1` veya `3` ile ham değeri karşılaştırmak bu durumları kaçırır. Dash (`0x10`) ve marker (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) biriminde ölçülür; X sağa, Y aşağı doğru artar. Grup dışı bir şekil için çıkarılan koordinatlar zaten [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) konumunu içerir ve mevcut genişlik‑yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin. Koordinatları, X ve Y değerlerini çıkartarak döndürülmemiş çerçeveye göre göreceli hale getirin.

Çıkarılan noktalar şeklin [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) ya da yatay‑düşey çevirilerini içermez. Görüntülenen konturu yeniden üretmek için bu dönüşümleri şeklin merkezine göre uygulayın. Gruplanmış şekillerde ayrıca grup koordinat haritalaması ve dönüşümlerini hesaba katın; çıkarılan noktaların son slayt koordinatları olduğunu varsaymayın ve bir çeviri ya da ölçekleme zaten çocuğun çerçevesinde yansıtılmışsa iki kez uygulamayın.

**İnceleme ve düzenleme arasındaki fark.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz ya da çizim kodunuz nokta/tür dizilerine ihtiyaç duyduğunda bu yöntemi tercih edin. Şeklin yerel koordinat sistemi içinde geometri komutlarına ihtiyacınız varsa veya geometrisini düzenlemek istiyorsanız [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) kullanın. Düzenlenmiş yolları [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) veya [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) ile uygulayın.

## **SSS**

**Geometri değiştirildikten sonra dolgu ve kenarlık ne olur?**  
Stil şekilde kalır; sadece kontur değişir. Dolgu ve kenarlık otomatik olarak yeni geometriye uygulanır.

**Bir özel şekli geometrisiyle birlikte doğru şekilde nasıl döndürebilirim?**  
Şeklin [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) özelliğini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğu için şekilyle birlikte döner.

**Sonucu “kilitlemek” için özel bir şekli görsele dönüştürebilir miyim?**  
Evet. Gerekli [slayt](/slides/tr/python-net/convert-powerpoint-to-png/) alanını veya [şekil](/slides/tr/python-net/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, karmaşık geometrilerle sonraki çalışmaları basitleştirir.