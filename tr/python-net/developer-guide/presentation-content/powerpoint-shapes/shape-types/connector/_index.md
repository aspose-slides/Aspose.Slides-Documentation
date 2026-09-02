---
title: Sunumlarda Python ile Bağlayıcıları Yönetme
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
- bağlama sitesi
- ayarlama noktası
- şekilleri bağla
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint bağlayıcılarını (düz, bükülmüş ve kavisli) eklemeyi, bağlamayı, yeniden yönlendirmeyi, ayarlamayı ve denetlemeyi öğrenin."
---
## **Genel Bakış**

Bir bağlayıcı, iki şekilden biri hareket ettiğinde bile iki şekle bağlı kalabilen bir çizgidir. Uçları, PowerPoint’te yeşil noktalarla gösterilen bağlama noktalarına bağlanır. Bazı bükülmüş ve kavisli bağlayıcılar ayrıca turuncu noktalarla temsil edilen ayarlama noktalarına sahiptir; bu noktalar, bağlayıcının bireysel segmentlerinin konumunu kontrol eder.

Aspose.Slides, bağlayıcıları [IConnector](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iconnector/) arayüzü üzerinden temsil eder. Bağlayıcıları oluşturabilir, uçlarını şekillere bağlayabilir, bağlama noktalarını seçebilir, yeniden yönlendirebilir ve ayarlama noktalarına sahip bağlayıcıların geometrisini değiştirebilirsiniz.

## **Bağlayıcı Türleri**

[ShapeType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapetype/) enumarasyonu, düz, bükülmüş ve kavisli bağlayıcı ön ayarlarını içerir. Aşağıdaki tablo, mevcut bağlayıcı geometrilerini ve her ön ayarın tanımladığı ayarlama nokta sayısını gösterir.

| Bağlayıcı | Görsel | Ayarlama nokta sayısı |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ayarlama noktalarının sayısı ve anlamı seçilen bağlayıcı ön ayarının bir parçasıdır. İki farklı bağlayıcı tipinin aynı koleksiyon düzenine sahip olduğunu varsaymayın.

## **İki Şekli Bağlama**

Bir bağlayıcı eklemek için [IShapeCollection.add_connector](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapecollection/add_connector/) yöntemini kullanın ve [start_shape_connected_to](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iconnector/start_shape_connected_to/) ve [end_shape_connected_to](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iconnector/end_shape_connected_to/) özelliklerini atayın. Her iki uç da bağlandıktan sonra [IConnector.reroute](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iconnector/reroute/) şekiller arasındaki kısa rotayı seçer.

Aşağıdaki örnek, bir elips ve bir dikdörtgeni bükülmüş bir bağlayıcıyla bağlar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}

`reroute` çağrısı, [start_shape_connection_site_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) ve [end_shape_connection_site_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) değerlerini değiştirebilir. Bu noktalar sabit kalmalıysa, yeniden yönlendirmeden sonra belirli bağlama noktalarını atayın.

{{% /alert %}}

## **Bir Bağlama Noktası Seçme**

Her bağlanabilir şekil, [connection_site_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/igeometryshape/connection_site_count/) aracılığıyla sahip olduğu site sayısını rapor eder. Bağlayıcı ucuna atamadan önce tercih edilen sıfır tabanlı site indeksini doğrulayın; site sayısı şekil geometrisine göre değişir.

Bu örnek, elips üzerindeki belirli bir site mevcutsa bağlayıcıyı o siteye bağlar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Bağlayıcı Noktasını Ayarlama**

Ayarlama noktasına sahip bağlayıcılar, [IGeometryShape.adjustments](https://reference.aspose.com/slides/tr/python-net/aspose.slides/igeometryshape/adjustments/) aracılığıyla bu noktaları ortaya çıkarır. Her bir [IAdjustValue](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iadjustvalue/) öğesini inceleyin ve [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iadjustvalue/type/) özelliğini kontrol ettikten sonra [raw_value](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iadjustvalue/raw_value/) değerini değiştirin. Genel şekil manipülasyonu için [Şekil Manipülasyonu](/slides/tr/python-net/shape-manipulations/) bölümüne bakın.

Bağlayıcı ayarlamaları sayısı, sırası, anlamı ve geçerli değer aralığı bağlayıcı ön ayarına bağlıdır. `type` özelliği yalnızca okunabilirken, ayarlama değeri yazılabilir. Aynı semantik tipe sahip birden fazla ayarlama varsa, ek kimlik için yalnızca okunabilir [name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iadjustvalue/name/) özelliği kullanılabilir.

### **Bir Engel Çevresinde Rotayı Belirleme**

Aşağıdaki yerleşimde, iki şekil arasında bir `ShapeType.BENT_CONNECTOR5` bağlayıcısı üçüncü bir şekilden geçmektedir:

![connector-obstruction](connector-obstruction.png)

Bu kod, engelli bağlayıcıyı oluşturur:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Dikey bükümü hareket ettirmek, bağlayıcının engeli aşmasını sağlayarak rotayı değiştirir:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Koleksiyon indeksi `1` her zaman dik büküm anlamına geliyormuş gibi varsaymak yerine, bu örnek `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` arar ve yalnızca beklenen semantik tip mevcutsa değiştirir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

Bir `ShapeType.BENT_CONNECTOR5` iki `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` ve bir `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` ayarlamasına sahiptir. Gerekli tip birden çok kez oluşursa, birini seçmeden önce `name` ve ön ayarın bilinen geometrisini inceleyin. Bir ayarlama [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapeadjustmenttype/) rapor ediyorsa, anlamını ve aralığını ön ayara özgü olarak ele alın ve bu sözleşme netleşene kadar değiştirmeyin.

## **Ayarlama Değerlerini Bağlayıcı Geometrisiyle İlişkilendirme**

Bükülmüş bağlayıcılar için ayarlama değerleri, bireysel segmentlerin konumlarını tahmin etmekte kullanılabilir. Bu hesaplamalar bağlayıcı ön ayarına özeldir:

- `ShapeType.BENT_CONNECTOR4` genellikle bir `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` ve bir `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` ayarlaması sunar.
- Bu bükülme konumları için `raw_value / 100000`, aşağıdaki örneklerde kullanılan bağlayıcı çerçeve genişliği veya yüksekliğinin kesirini üretir.
- Bir bağlayıcı çerçevesi döndürülebilir veya çevrilebilir; bu yüzden çerçeve koordinatları slayt koordinatlarıyla karşılaştırılmadan önce dönüştürülmelidir.

Aşağıdaki örnekler, önce ayarlamaları tanımlamak için `type` kullanır. Koleksiyon indekslerini taşınabilir tanımlayıcı olarak ele almazlar.

### **Döndürülmemiş Bağlayıcı**

Başlangıç yerleşimi, bir `ShapeType.BENT_CONNECTOR4` ile bağlanmış iki metin şekli içerir:

![connector-shape-complex](connector-shape-complex.png)

Bu örnek bağlayıcıyı inceler ve yatay ve dik bükülme ayarlamalarını elde eder:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Her iki bükülmeyi değiştirmek için, beklenen türleri bulup değerleri yalnızca ikisi de bulunduğunda değiştirin:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç, yatay ve dik segmentleri hareket etmiş bir bağlayıcıdır:

![connector-adjusted-1](connector-adjusted-1.png)

Semantik tipler bilindiğinde, değerler bağlayıcı çerçevesi koordinatlarına dönüştürülebilir. Bu örnek, iki bükülme ayarlamasıyla kontrol edilen dik segmentin üzerine ince bir dikdörtgen çizer:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Kılavuz şekil, hesaplanan segmenti işaretler:

![connector-adjusted-2](connector-adjusted-2.png)

### **Döndürülmüş veya Çevrilmiş Bağlayıcı**

Aynı bağlayıcı geometrisi dikey olarak yönlendirildiğinde, [frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapeframe/flip_h/) ve [flip_v](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapeframe/flip_v/) değerleri, bağlayıcı‑çerçeve koordinatlarından slayt koordinatlarına dönüşümü etkiler.

Bu örnek, dikey yönlendirilmiş bağlayıcıyı oluşturur ve ayarlar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Ayarlanan bağlayıcı şekiller arasında dikey olarak görünür:

![connector-adjusted-3](connector-adjusted-3.png)

Keyfi bir `alpha` döndürme açısı için, bağlayıcı‑çerçeve noktasını `(x, y)` çerçeve merkezi `(x0, y0)` etrafında şu şekilde döndürün:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Aşağıdaki kod, bu örnekte kullanılan 90‑derecelik yönelimi işler ve ilgili bağlayıcı segmenti üzerine kırmızı bir kılavuz çizer:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Kırmızı kılavuz, koordinat dönüşümünden sonra hesaplanan segmenti işaretler:

![connector-adjusted-4](connector-adjusted-4.png)

Bu formüller, örneklerde kullanılan ön ayarları tanımlar; evrensel bir bağlayıcı modeli değildir. Aynı hesabı farklı bir ön ayara uygulamadan önce ayarlama tiplerini, çerçeve yönelimini ve değer aralıklarını doğrulayın.

## **Bağlayıcı Yön Açısını Bulma**

Düz bir bağlayıcının yönü, genişliği ve yüksekliği kullanılarak, yatay ve dik dönüşler uygulanarak hesaplanabilir. Aşağıdaki örnek, slayt koordinatlarında pozitif yatay eksenden saat yönünde açıyı rapor eder:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **SSS**

**Bir bağlayıcının bir şekle bağlanıp bağlanamayacağını nasıl anlayabilirim?**

Şeklin [connection_site_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides/igeometryshape/connection_site_count/) değerini kontrol edin. Pozitif bir sayı, şeklin bağlama noktaları sunduğunu gösterir. Seçilen site indeksini, bağlayıcının herhangi bir ucuna atamadan önce doğrulayın.

**Bir bağlayıcı ayarlamasını koleksiyon indeksiyle tanımlayabilir miyim?**

Bir indeks, yalnızca bilinen bir bağlayıcı ön ayarı ve koleksiyon düzeni için anlamlıdır. Değeri değiştirmeden önce [IAdjustValue.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iadjustvalue/type/) kontrol edin ve aynı semantik tip birden çok kez ortaya çıktığında ek bilgi için [IAdjustValue.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iadjustvalue/name/) kullanın.

**Bağlı bir şekil silindiğinde ne olur?**

İlgili bağlayıcı ucu ayrılır. Bağlayıcı slaytta kalır ve silinebilir, serbest bir çizgi olarak konumlandırılabilir veya başka bir şekle bağlanabilir.

**Bir slayt kopyalandığında bağlayıcı bağlamaları korunur mu?**

Bağlı şekiller slayt ile birlikte kopyalandığında bağlamalar genellikle korunur. Bir bağlayıcı, hedef şekillerinden biri olmadan kopyalanırsa, etkilenen ucu yeniden bağlamak gerekir.