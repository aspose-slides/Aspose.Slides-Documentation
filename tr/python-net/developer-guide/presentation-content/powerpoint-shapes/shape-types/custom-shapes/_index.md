---
title: Python ile Sunumlarda Şekilleri Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/python-net/custom-shape/
keywords:
- özel şekil
- şekil ekle
- şekil oluştur
- şekli değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- nokta düzenleme
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- kavisli köşe
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarında şekil oluşturun ve özelleştirin: geometri yolları, kavisli köşeler, bileşik şekiller."
---
## **Giriş**

Bir kareyi düşünün. PowerPoint'te **Edit Points** kullanarak şunları yapabilirsiniz:

* bir karenin köşesini içeriye ya da dışarıya hareket ettirin,
* bir köşenin ya da noktanın eğriliğini ayarlayın,
* kareye yeni noktalar ekleyin,
* noktasını manipüle edin.

Bu işlemleri herhangi bir şekle uygulayabilirsiniz. **Edit Points** ile bir şekli değiştirebilir veya mevcut bir şekilden yeni bir şekil oluşturabilirsiniz.

## **Şekil Düzenleme İpuçları**

!["Edit Points" komutu](custom_shape_0.png)

PowerPoint şekillerini **Edit Points** ile düzenlemeye başlamadan önce, şekillerle ilgili şu notları göz önünde bulundurun:

* Bir şekil (veya yolu) **closed** ya da **open** olabilir.
* Kapalı bir şeklin başlangıç ya da bitiş noktası yoktur; açık bir şeklin bir başlangıcı ve bir sonu vardır.
* Her şeklin en az iki, çizgi segmentleriyle bağlanan anchor noktası vardır.
* Bir segment düz ya da eğridir; anchor noktaları segmentin doğasını belirler.
* Anchor noktaları **corner**, **smooth** veya **straight** olabilir:
  * Bir **corner** noktası, iki düz segmentin bir açıda buluştuğu yerdir.
  * Bir **smooth** noktasının iki kolu aynı doğrultudadır ve komşu segmentler düzgün bir eğri oluşturur. Bu durumda, iki kol da anchor noktasına aynı mesafededir.
  * Bir **straight** nokta da iki aynı doğrultuda kol içerir ve komşu segmentler düzgün bir eğri oluşturur. Bu durumda, kolların anchor noktasına olan mesafeleri aynı olmak zorunda değildir.
* Anchor noktalarını hareket ettirerek veya düzenleyerek (segment açılarını değiştirerek) şeklin görünümünü değiştirebilirsiniz.

PowerPoint şekillerini düzenlemek için Aspose.Slides, [GeometryPath](https://reference.aspose.com/slides/tr/python-net/aspose.slides/geometrypath/) sınıfını sunar.

* Bir [GeometryPath] örneği, bir [GeometryShape] nesnesinin geometri yolunu temsil eder.
* Bir [GeometryShape] örneğinden [GeometryPath] elde etmek için [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/tr/python-net/aspose.slides/geometryshape/get_geometry_paths/) metodunu kullanın.
* Bir şekil için [GeometryPath] ayarlamak üzere, *solid shapes* için [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/tr/python-net/aspose.slides/geometryshape/set_geometry_path/) ve *composite shapes* için [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/tr/python-net/aspose.slides/geometryshape/set_geometry_paths/) kullanın.
* [GeometryPath] üzerindeki metodları kullanarak segment ekleyin.
* [GeometryPath.stroke] ve [GeometryPath.fill_mode] özelliklerini kullanarak bir geometri yolunun görünümünü kontrol edin.
* [GeometryPath.path_data] özelliğini kullanarak bir şeklin geometri yolunu segment dizisi olarak alın.

## **Basit Düzenleme İşlemleri**

Aşağıdaki yöntemler basit düzenleme işlemleri için kullanılır.

**Bir çizgi ekle** yolun sonuna:

```py
line_to(point)
line_to(x, y)
```

**Bir çizgi ekle** yol içinde belirtilen konumda:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Kübik Bezier eğrisi ekle** yolun sonuna:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Kübik Bezier eğrisi ekle** yol içinde belirtilen konumda:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Kare Bezier eğrisi ekle** yolun sonuna:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Kare Bezier eğrisi ekle** yol içinde belirtilen konumda:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Bir yay ekle** yoluna:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Geçerli şekli kapat** yol içinde:

```py
close_figure()
```

**Sonraki nokta için konumu ayarla**:

```py
move_to(point)
move_to(x, y)
```

**Verilen indeksdeki yol segmentini kaldır**:

```py
remove_at(index)
```

## **Şekillere Özel Noktalar Ekle**

Burada, kendi nokta dizinizi ekleyerek serbest biçimli bir şekil tanımlamayı öğreneceksiniz. Sıralı noktalar ve segment tiplerini (düz ya da eğri) belirleyerek ve isteğe bağlı olarak yolu kapatarak, slaytlarınıza doğrudan kesin özel grafikler—poligonlar, ikonlar, açıklama balonları veya logolar—çizebilirsiniz.

1. [GeometryShape] sınıfının bir örneğini oluşturun ve [ShapeType.RECTANGLE] ayarlayın.
2. Şekilden bir [GeometryPath] örneği alın.
3. Yoldaki iki üst nokta arasına yeni bir nokta ekleyin.
4. Yoldaki iki alt nokta arasına yeni bir nokta ekleyin.
5. Güncellenen yolu şekle uygulayın.

Aşağıdaki Python kodu, bir şekle özel noktalar eklemeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Özel noktalar](custom_shape_1.png)

##  **Şekillerden Nokta Kaldırma**

Bazen özel bir şekil, geometrisini karmaşıklaştıran ya da render edilmesini etkileyen gereksiz noktalara sahiptir. Bu bölüm, bir şeklin yolundan belirli noktaları kaldırarak konturu basitleştirmenizi ve daha temiz, daha kesin sonuçlar elde etmenizi gösterir.

1. [GeometryShape] sınıfının bir örneğini oluşturun ve [ShapeType.HEART] tipini ayarlayın.
2. Şekilden bir [GeometryPath] örneği alın.
3. Yoldan bir segment kaldırın.
4. Güncellenen yolu şekle uygulayın.

Aşağıdaki Python kodu, bir şekilden nokta kaldırmayı gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Kaldırılan noktalar](custom_shape_2.png)

##  **Özel Şekiller Oluşturma**

Çizgiler, yaylar ve Bézier eğrilerinden oluşan bir [GeometryPath] tanımlayarak özel vektör şekilleri oluşturun. Bu bölüm, sıfırdan bir özel geometri oluşturmayı ve ortaya çıkan şekli slaytınıza eklemeyi gösterir.

1. Şekil için noktaları hesaplayın.
2. [GeometryPath] sınıfının bir örneğini oluşturun.
3. Yolu noktalarla doldurun.
4. [GeometryShape] sınıfının bir örneğini oluşturun.
5. Yolu şekle uygulayın.

Aşağıdaki Python kodu, bir özel şekil oluşturmayı gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Özel şekil](custom_shape_3.png)

## **Bileşik Özel Şekiller Oluşturma**

Bileşik bir özel şekil oluşturmak, bir slaytta birden çok geometri yolunu tek, yeniden kullanılabilir bir şekle birleştirmenizi sağlar. Bu yolları tanımlayıp birleştirerek standart şekil setinin ötesinde karmaşık görseller oluşturabilirsiniz.

1. [GeometryShape] sınıfının bir örneğini oluşturun.
2. [GeometryPath] sınıfının ilk örneğini oluşturun.
3. [GeometryPath] sınıfının ikinci örneğini oluşturun.
4. Her iki yolu da şekle uygulayın.

Aşağıdaki Python kodu, bir bileşik özel şekil oluşturmayı gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Bileşik şekil](custom_shape_4.png)

## **Kavisli Köşeli Özel Şekiller Oluşturma**

Bu bölüm, bir geometry path kullanarak düzgün kavisli köşelere sahip bir özel şekil çizmeyi gösterir. Düz segmentleri ve dairesel yayları birleştirerek konturu oluşturacak ve tamamlanan şekli slaytınıza ekleyeceksiniz.

Aşağıdaki Python kodu, kavisli köşeli bir özel şekil oluşturmayı gösterir:

```py
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

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Kavisli köşeler](custom_shape_6.png)

## **Bir Şeklin Geometrisinin Kapalı Olup Olmadığını Belirleme**

Kapalı bir şekil, tüm kenarlarının birbirine bağlandığı ve boşluk bırakmadan tek bir sınır oluşturduğu şekil olarak tanımlanır. Böyle bir şekil basit bir geometrik form ya da karmaşık bir özel kontur olabilir. Aşağıdaki kod örneği, bir şeklin geometrisinin kapalı olup olmadığını kontrol etmeyi gösterir:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **SSS**

**Geometriyi değiştirdikten sonra doldurma ve kenarlık ne olacak?**

Stil şekille kalır; sadece kontur değişir. Doldurma ve kenarlık yeni geometriye otomatik olarak uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürebilirim?**

Şeklin [rotation] (döndürme) özelliğini kullanın; geometri şekille birlikte döner çünkü şeklin kendi koordinat sistemine bağlıdır.

**Sonucu 'kilitlemek' için bir özel şekli görüntüye dönüştürebilir miyim?**

Evet. Gerekli [slide](/slides/tr/python-net/convert-powerpoint-to-png/) bölgesini veya [shape](/slides/tr/python-net/create-shape-thumbnails/) öğesini raster formatına dışa aktarın; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.