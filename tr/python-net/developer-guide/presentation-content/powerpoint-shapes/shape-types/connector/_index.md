---
title: Python ile Sunumlarda Bağlayıcıları Yönet
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/python-net/connector/
keywords:
- bağlayıcı
- bağlayıcı türü
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- şekilleri bağla
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python uygulamalarını PowerPoint ve OpenDocument slaytlarında çizgiler çizmeye, bağlamaya ve otomatik yönlendirmeye güçlendirin—düz, dirsek ve eğimli bağlayıcılar üzerinde tam kontrol elde edin."
---
## **Giriş**

PowerPoint bağlayıcısı, iki şekli birbirine bağlayan ve şekiller slayt üzerinde hareket ettirildiğinde veya konumlandırıldığında hâlâ ekli kalan özel bir çizgidir. Bağlayıcılar şekillerin **bağlantı noktalarına** (yeşil noktalar) bağlanır. Bağlantı noktaları, işaretçi onlara yaklaştığında görünür. Belirli bağlayıcılarda bulunan **ayarlama tutamaçları** (sarı noktalar), bağlayıcının konumunu ve şeklini değiştirmenizi sağlar.

## **Bağlayıcı Türleri**

PowerPoint'te üç tür bağlayıcı kullanabilirsiniz: düz, dirsek (açılı) ve eğimli.

Aspose.Slides aşağıdaki bağlayıcı türlerini destekler:

| Bağlayıcı Türü                  | Görsel                                                     | Ayarlama noktası sayısı |
| ------------------------------- | ---------------------------------------------------------- | ----------------------- |
| `ShapeType.LINE`                | ![Çizgi bağlayıcı](shapetype-lineconnector.png)            | 0                       |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Düz bağlayıcı 1](shapetype-straightconnector1.png)      | 0                       |
| `ShapeType.BENT_CONNECTOR2`     | ![Eğik bağlayıcı 2](shapetype-bent-connector2.png)        | 0                       |
| `ShapeType.BENT_CONNECTOR3`     | ![Eğik bağlayıcı 3](shapetype-bentconnector3.png)         | 1                       |
| `ShapeType.BENT_CONNECTOR4`     | ![Eğik bağlayıcı 4](shapetype-bentconnector4.png)         | 2                       |
| `ShapeType.BENT_CONNECTOR5`     | ![Eğik bağlayıcı 5](shapetype-bentconnector5.png)         | 3                       |
| `ShapeType.CURVED_CONNECTOR2`   | ![Kavisli bağlayıcı 2](shapetype-curvedconnector2.png)     | 0                       |
| `ShapeType.CURVED_CONNECTOR3`   | ![Kavisli bağlayıcı 3](shapetype-curvedconnector3.png)     | 1                       |
| `ShapeType.CURVED_CONNECTOR4`   | ![Kavisli bağlayıcı 4](shapetype-curvedconnector4.png)     | 2                       |
| `ShapeType.CURVED_CONNECTOR5`   | ![Kavisli bağlayıcı 5](shapetype.curvedconnector5.png)     | 3                       |

## **Şekilleri Bağlayıcılarla Bağlama**

Bu bölüm, Aspose.Slides içinde şekilleri bağlayıcılarla nasıl birleştireceğinizi gösterir. Bir bağlayıcıyı slayta ekleyecek, başlangıç ve bitiş noktalarını hedef şekillere bağlayacaksınız. Bağlantı noktalarını kullanmak, şekiller hareket ettiğinde veya yeniden boyutlandırıldığında bağlayıcının şekillere “yapışık” kalmasını sağlar.

1. Presentation sınıfının bir örneğini oluşturun.
2. Slayta, indeksine göre bir referans alın.
3. `add_auto_shape` yöntemiyle [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) nesnesi tarafından sunulan iki [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) nesnesi ekleyin.
4. `add_connector` yöntemini kullanarak [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) nesnesi üzerinden bir bağlayıcı ekleyin ve bağlayıcı türünü belirtin.
5. Şekilleri bağlayıcı ile bağlayın.
6. En kısa bağlantı yolunu uygulamak için `reroute` yöntemini çağırın.
7. Sunumu kaydedin.

```python
import aspose.slides as slides

# Sunum sınıfını örnekleyerek bir PPTX dosyası oluştur.
with slides.Presentation() as presentation:

    # İlk slayt için şekiller koleksiyonuna eriş.
    shapes = presentation.slides[0].shapes

    # Bir elips AutoShape ekle.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Bir dikdörtgen AutoShape ekle.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Slayta bir bağlayıcı ekle.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Şekilleri bağlayıcıyla bağla.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # En kısa yolu ayarlamak için reroute metodunu çağır.
    connector.reroute()

    # Sunumu kaydet.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
`connector.reroute` yöntemi bir bağlayıcıyı yeniden yönlendirir ve şekiller arasındaki en kısa yolu almasını zorlar. Bunu yapmak için yöntem `start_shape_connection_site_index` ve `end_shape_connection_site_index` değerlerini değiştirebilir.
{{% /alert %}}

## **Bağlantı Noktalarını Belirleme**

Bu bölüm, Aspose.Slides içinde bir bağlayıcının bir şeklin belirli bir bağlantı noktasına nasıl bağlanacağını açıklar. Doğru bağlantı noktalarını hedefleyerek bağlayıcı yönlendirmesini ve düzenini kontrol edebilir, sunumlarınızda temiz ve öngörülebilir diyagramlar oluşturabilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun.
2. Slayta, indeksine göre bir referans alın.
3. `add_auto_shape` yöntemiyle [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) nesnesi tarafından sunulan iki [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) nesnesi ekleyin.
4. `add_connector` yöntemini [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) nesnesi üzerinde kullanarak bir bağlayıcı ekleyin ve bağlayıcı türünü belirtin.
5. Şekilleri bağlayıcı ile bağlayın.
6. Şekiller üzerinde tercih ettiğiniz bağlantı noktalarını ayarlayın.
7. Sunumu kaydedin.

```python
import aspose.slides as slides

# PPTX dosyası oluşturmak için Presentation sınıfını örnekle.
with slides.Presentation() as presentation:

    # İlk slayt için şekiller koleksiyonuna eriş.
    shapes = presentation.slides[0].shapes

    # Bir elips AutoShape ekle.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Bir dikdörtgen AutoShape ekle.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Bağlayıcıyı slaydın şekil koleksiyonuna ekle.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Şekilleri bağlayıcıyla bağla.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Elips üzerinde tercih edilen bağlantı site indeksi ayarla.
    site_index = 6

    # Tercih edilen indeksin mevcut site sayısı içinde olduğundan emin ol.
    if  ellipse.connection_site_count > site_index:
        # Elips AutoShape üzerinde tercih edilen bağlantı sitesini ata.
        connector.start_shape_connection_site_index = site_index

    # Sunumu kaydet.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Bağlayıcı Noktalarını Ayarlama**

Bağlayıcıları ayarlama noktalarını kullanarak değiştirebilirsiniz. Yalnızca ayarlama noktalarını sunan bağlayıcılar bu şekilde düzenlenebilir. Hangi bağlayıcıların ayarlamayı desteklediği hakkında ayrıntılar için [Bağlayıcı Türleri](/slides/tr/python-net/connector/#connector-types) altındaki tabloya bakın.

### **Basit Durum**

İki şekil (A ve B) arasında bir bağlayıcı, üçüncü bir şekil (C) ile kesişiyorsa:

![Bağlayıcı engeli](connector-obstruction.png)

Kod örneği:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Üçüncü şekilden kaçınmak için bağlayıcının dikey segmentini sola kaydırarak düzenleyin:

![Düzeltilmiş bağlayıcı engeli](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Karmaşık Durumlar**

Daha gelişmiş ayarlamalar için aşağıdakileri göz önünde bulundurun:

- Bir bağlayıcının ayarlanabilir noktası, konumunu belirleyen bir formülle yönetilir. Bu noktanın değiştirilmesi, bağlayıcının genel şeklini değiştirebilir.
- Bağlayıcının ayarlama noktaları, bağlayıcının başlangıcından sonuna kadar numaralandırılmış, kesin bir sıralı dizide saklanır.
- Ayarlama noktası değerleri, bağlayıcı şeklinin genişlik/yükseklik yüzdelerini temsil eder.
  - Şekil, bağlayıcının başlangıç ve bitiş noktalarıyla sınırlanır ve 1000 ile ölçeklenir.
  - Birinci, ikinci ve üçüncü ayarlama noktaları sırasıyla: genişlik yüzdesi, yükseklik yüzdesi ve tekrar genişlik yüzdesi temsil eder.
- Ayarlama noktalarının koordinatlarını hesaplarken, bağlayıcının dönüş ve yansımasını dikkate alın. **Not:** [Connector Types](/slides/tr/python-net/connector/#connector-types) altında listelenen tüm bağlayıcılar için dönüş açısı 0'dır.

#### **Durum 1**

İki metin çerçevesi nesnesinin bir bağlayıcı ile bağlandığı bir durum düşünün:

![Bağlı şekiller](connector-shape-complex.png)

Kod örneği:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX dosyası oluşturmak için Presentation sınıfını örnekle.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # İlk slaytı al.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Bir bağlayıcı ekle.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Bağlayıcının yönünü ayarla.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Bağlayıcının rengini ayarla.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Bağlayıcının çizgi kalınlığını ayarla.
    connector.line_format.width = 3

    # Şekilleri bağlayıcıyla bağla.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Bağlayıcının ayarlama noktalarını al.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Ayarlama**

Bağlayıcının ayarlama nokta değerlerini, genişlik yüzdesini %20, yükseklik yüzdesini ise %200 artırarak değiştirin:

```python
    # Ayarlama noktalarının değerlerini değiştir.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Sonuç:

![Bağlayıcı ayarı 1](connector-adjusted-1.png)

`connector.adjustments[0]` konumundaki dik bileşeni temsil eden bir şekil oluşturarak bağlayıcının segmentlerinin koordinat ve şeklini belirlememizi sağlayan bir model tanımlayın:

```python
    # Bağlayıcının dikey bileşenini çiz.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Sonuç:

![Bağlayıcı ayarı 2](connector-adjusted-2.png)

#### **Durum 2**

**Durum 1**'de temel prensiplerle basit bir bağlayıcı ayarlaması gösterdik. Tipik senaryolarda, bağlayıcının dönüşünü ve görüntü ayarlarını (`connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v`) dikkate almanız gerekir. Sürecin nasıl çalıştığını aşağıda bulabilirsiniz.

İlk olarak, slayta yeni bir metin çerçevesi nesnesi (**To 1**) ekleyin (bağlantı için) ve mevcut nesnelerle bağlayan yeni bir yeşil bağlayıcı oluşturun.

```python
    # Yeni bir hedef nesne oluştur.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Yeni bir bağlayıcı oluştur.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Yeni oluşturulan bağlayıcıyı kullanarak nesneleri bağla.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Bağlayıcının ayarlama noktalarını al.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Ayarlama noktalarının değerlerini değiştir.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Sonuç:

![Bağlayıcı ayarı 3](connector-adjusted-3.png)

İkinci olarak, yeni bağlayıcının ayarlama noktası `connector.adjustments[0]` üzerinden geçen **yatay** segmenti temsil eden bir şekil oluşturun. `connector.rotation`, `connector.frame.flip_h` ve `connector.frame.flip_v` değerlerini kullanın ve verilen `x0` noktasına göre dönüş için standart koordinat dönüşüm formülünü uygulayın:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Bizim durumumuzda nesnenin dönüş açısı 90 derece ve bağlayıcı dikey olarak görüntüleniyor, bu yüzden ilgili kod aşağıdaki gibidir:

```python
    # Bağlayıcı koordinatlarını kaydet.
    x = connector.x
    y = connector.y
    
    # Bağlayıcı koordinatlarını tersse düzelt.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Ayarlama noktası değerini koordinat olarak kullan.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Koordinatları dönüştür; çünkü sin(90°) = 1 ve cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # İkinci ayarlama noktası değerini kullanarak yatay segmentin genişliğini belirle.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Sonuç:

![Bağlayıcı ayarı 4](connector-adjusted-4.png)

Basit ayarlamaları ve dönüşü de dikkate alan daha karmaşık ayarlama noktalarını içeren hesaplamaları gösterdik. Bu bilgiyle, kendi modelinizi geliştirebilir veya belirli slayt koordinatlarına göre bir `GraphicsPath` nesnesi elde etmek ya da bağlayıcının ayarlama noktası değerlerini ayarlamak için kod yazabilirsiniz.

## **Bağlayıcı Çizgi Açılarının Bulunması**

Aşağıdaki örnek, Aspose.Slides kullanarak bir slayttaki bağlayıcı çizgi açılarını nasıl belirleyeceğinizi gösterir. Bağlayıcının uç noktalarını okuyacak ve yönünü hesaplayarak oklar, etiketler ve diğer şekillerin tam olarak hizalanmasını sağlayacaksınız.

1. Presentation sınıfının bir örneğini oluşturun.
2. İndexe göre slayta bir referans alın.
3. Bağlayıcı çizgi şekline erişin.
4. Çizginin genişliği ve yüksekliği ile şekil çerçevesinin genişliği ve yüksekliğini kullanarak açıyı hesaplayın.

Aşağıdaki Python kodu, bir bağlayıcı çizgi şeklinin açısını nasıl hesaplayacağınızı gösterir:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Bir bağlayıcının belirli bir şekle "yapıştırılıp" yapıştırılamadığını nasıl anlayabilirim?**

Şeklin [bağlantı noktalarını](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/connection_site_count/) açığa çıkarıp çıkarmadığını kontrol edin. Hiç bağlantı noktası yoksa veya sayısı sıfırsa, yapıştırma özelliği mevcut değildir; bu durumda serbest uçları kullanıp konumlarını manuel olarak ayarlamanız gerekir. Bağlayıcıyı eklemeden önce site sayısını kontrol etmek mantıklıdır.

**Bağlantılı şekillerden birini sildiğimde bağlayıcıya ne olur?**

Uçları kopar; bağlayıcı serbest bir başlangıç/bitişle normal bir çizgi olarak slaytta kalır. İsterseniz silebilir ya da bağlantıları yeniden atayabilir ve gerekirse [reroute](https://reference.aspose.com/slides/tr/python-net/aspose.slides/connector/reroute/) metodunu kullanabilirsiniz.

**Bir slaytı başka bir sunuma kopyaladığımda bağlayıcı bağlamaları korunur mu?**

Genellikle evet, hedef şekiller de kopyalandığı sürece korunur. Slayt, bağlanmış şekiller olmadan başka bir dosyaya eklenirse uçlar serbest olur ve yeniden bağlamanız gerekir.