---
title: Kelola Penghubung dalam Presentasi dengan Python
linktitle: Penghubung
type: docs
weight: 10
url: /id/python-net/connector/
keywords:
- penghubung
- tipe penghubung
- titik penghubung
- garis penghubung
- sudut penghubung
- situs koneksi
- titik penyesuaian
- hubungkan bentuk
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan, melampirkan, mengatur ulang, menyesuaikan, dan memeriksa penghubung PowerPoint yang lurus, bengkok, dan melengkung dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Penghubung adalah garis yang dapat tetap melekat pada dua bentuk ketika salah satu bentuk dipindahkan. Ujungnya melekat pada situs koneksi, yang direpresentasikan oleh titik hijau di PowerPoint. Beberapa penghubung yang bengkok dan melengkung juga menampilkan titik penyesuaian, yang direpresentasikan oleh titik oranye, yang mengontrol posisi segmen penghubung individu.

Aspose.Slides merepresentasikan penghubung melalui antarmuka [IConnector](https://reference.aspose.com/slides/id/python-net/aspose.slides/iconnector/) . Anda dapat membuatnya, melekatkan ujungnya ke bentuk, memilih situs koneksi, mengatur ulang rutenya, dan memodifikasi geometri penghubung yang memiliki titik penyesuaian.

## **Jenis Penghubung**

Enum [ShapeType](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapetype/) mencakup preset penghubung lurus, bengkok, dan melengkung. Tabel berikut menunjukkan geometri penghubung yang tersedia dan jumlah titik penyesuaian yang didefinisikan oleh setiap preset.

| Penghubung | Image | Jumlah titik penyesuaian |
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

Jumlah dan makna titik penyesuaian merupakan bagian dari preset penghubung yang dipilih. Jangan menganggap bahwa dua jenis penghubung yang berbeda menampilkan tata letak koleksi yang sama.

## **Menghubungkan Dua Bentuk**

Gunakan [IShapeCollection.add_connector](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapecollection/add_connector/) untuk menambahkan penghubung, dan tetapkan properti [start_shape_connected_to](https://reference.aspose.com/slides/id/python-net/aspose.slides/iconnector/start_shape_connected_to/) serta [end_shape_connected_to](https://reference.aspose.com/slides/id/python-net/aspose.slides/iconnector/end_shape_connected_to/). Setelah kedua ujung terpasang, [IConnector.reroute](https://reference.aspose.com/slides/id/python-net/aspose.slides/iconnector/reroute/) memilih rute pendek antara bentuk‑bentuk tersebut.

Contoh berikut menghubungkan sebuah elips dan persegi panjang dengan penghubung bengkok:

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
Pemanggilan `reroute` dapat mengubah nilai [start_shape_connection_site_index](https://reference.aspose.com/slides/id/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) dan [end_shape_connection_site_index](https://reference.aspose.com/slides/id/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Tetapkan situs koneksi tertentu setelah pengaturan ulang jika situs tersebut harus tetap tetap.
{{% /alert %}}

## **Memilih Situs Koneksi**

Setiap bentuk yang dapat dihubungkan melaporkan jumlah situsnya melalui [connection_site_count](https://reference.aspose.com/slides/id/python-net/aspose.slides/igeometryshape/connection_site_count/). Validasi indeks situs berbasis nol yang diinginkan sebelum menetapkannya ke ujung penghubung; jumlah situs bervariasi menurut geometri bentuk.

Contoh ini melampirkan penghubung ke situs tertentu pada elips bila situs tersebut ada:

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

## **Menyesuaikan Titik Penghubung**

Penghubung dengan titik penyesuaian menampilkannya melalui [IGeometryShape.adjustments](https://reference.aspose.com/slides/id/python-net/aspose.slides/igeometryshape/adjustments/). Periksa setiap [IAdjustValue](https://reference.aspose.com/slides/id/python-net/aspose.slides/iadjustvalue/) dan periksa [type](https://reference.aspose.com/slides/id/python-net/aspose.slides/iadjustvalue/type/) sebelum mengubah [raw_value](https://reference.aspose.com/slides/id/python-net/aspose.slides/iadjustvalue/raw_value/). Untuk manipulasi bentuk umum, lihat [Shape Manipulation](/slides/id/python-net/shape-manipulations/).

Jumlah, urutan, makna, dan rentang nilai yang valid untuk penyesuaian penghubung tergantung pada preset penghubung. Properti `type` bersifat read‑only, sedangkan nilai penyesuaian dapat ditulis. Properti read‑only [name](https://reference.aspose.com/slides/id/python-net/aspose.slides/iadjustvalue/name/) memberikan identifikasi tambahan ketika sebuah penghubung berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

### **Mengelilingi Hambatan**

Pada tata letak berikut, penghubung `ShapeType.BENT_CONNECTOR5` antara dua bentuk melewati bentuk ketiga:

![connector-obstruction](connector-obstruction.png)

Kode ini membuat penghubung yang terhalang:

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

Memindahkan bengkok vertikal mengubah rute sehingga penghubung melewati hambatan:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Alih‑alih mengasumsikan bahwa indeks koleksi `1` selalu mewakili bengkok vertikal, contoh ini mencari `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` dan mengubahnya hanya ketika tipe semantik yang diharapkan hadir:

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

`ShapeType.BENT_CONNECTOR5` memiliki dua penyesuaian `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` dan satu penyesuaian `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Jika tipe yang Anda butuhkan muncul lebih dari sekali, periksa `name` dan geometri preset yang diketahui sebelum memilih satu. Jika sebuah penyesuaian melaporkan [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapeadjustmenttype/), perlakukan makna dan rentangnya sebagai spesifik preset dan jangan ubah sampai kontrak tersebut diketahui.

## **Menghubungkan Nilai Penyesuaian dengan Geometri Penghubung**

Untuk penghubung bengkok, nilai penyesuaian dapat digunakan untuk memperkirakan posisi segmen individu. Perhitungan ini spesifik untuk preset penghubung:

- `ShapeType.BENT_CONNECTOR4` biasanya menampilkan satu penyesuaian `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` dan satu `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Untuk posisi bengkok ini, `raw_value / 100000` menghasilkan fraksi lebar atau tinggi bingkai penghubung yang dipakai oleh contoh di bawah.
- Bingkai penghubung dapat diputar atau dibalik, sehingga koordinat bingkai harus diubah sebelum dibandingkan dengan koordinat slide.

Contoh berikut menggunakan `type` untuk mengidentifikasi penyesuaian terlebih dahulu. Mereka tidak memperlakukan indeks koleksi sebagai pengenal portabel.

### **Penghubung Tanpa Rotasi**

Tata letak awal berisi dua bentuk teks yang dihubungkan oleh `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Contoh ini memeriksa penghubung dan memperoleh penyesuaian bengkok horizontal dan vertikalnya:

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

Untuk mengubah kedua bengkok, temukan tiap tipe yang diharapkan dan ubah nilai hanya setelah keduanya ditemukan:

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

Hasilnya adalah penghubung yang segmen horizontal dan vertikalnya telah dipindahkan:

![connector-adjusted-1](connector-adjusted-1.png)

Setelah tipe semantik diketahui, nilainya dapat dikonversi ke koordinat bingkai penghubung. Contoh ini menggambar persegi panjang tipis di atas segmen vertikal yang dikendalikan oleh dua penyesuaian bengkok:

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

Bentuk panduan menandai segmen yang dihitung:

![connector-adjusted-2](connector-adjusted-2.png)

### **Penghubung Diputar atau Dibalik**

Ketika geometri penghubung yang sama diorientasikan secara vertikal, nilai [frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapeframe/flip_h/), dan [flip_v](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapeframe/flip_v/) memengaruhi konversi dari koordinat bingkai penghubung ke koordinat slide.

Contoh ini membuat dan menyesuaikan penghubung yang berorientasi vertikal:

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

Penghubung yang disesuaikan muncul secara vertikal di antara bentuk‑bentuk tersebut:

![connector-adjusted-3](connector-adjusted-3.png)

Untuk sudut rotasi arbitrer `alpha`, putar titik bingkai penghubung `(x, y)` sekitar pusat bingkai `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Kode berikut menangani orientasi 90‑derajat yang digunakan dalam contoh ini dan menggambar panduan merah di atas segmen penghubung yang bersesuaian:

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

Panduan merah menandai segmen yang dihitung setelah transformasi koordinat:

![connector-adjusted-4](connector-adjusted-4.png)

Formula ini menjelaskan preset yang digunakan dalam contoh, bukan model penghubung universal. Validasi tipe penyesuaian, orientasi bingkai, dan rentang nilai sebelum menerapkan perhitungan yang sama pada preset lain.

## **Menemukan Sudut Arah Penghubung**

Arah penghubung lurus dapat dihitung dari lebar dan tinggi, dengan flip horizontal dan vertikal diterapkan. Contoh berikut melaporkan sudut searah jarum jam dari sumbu horizontal positif dalam koordinat slide:

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

## **FAQ**

**Bagaimana saya dapat mengetahui apakah penghubung dapat melekat pada sebuah bentuk?**

Periksa [connection_site_count](https://reference.aspose.com/slides/id/python-net/aspose.slides/igeometryshape/connection_site_count/) pada bentuk. Jumlah positif berarti bentuk tersebut menampilkan situs koneksi. Validasi indeks situs yang dipilih sebelum menetapkannya ke salah satu ujung penghubung.

**Dapatkah saya mengidentifikasi penyesuaian penghubung berdasarkan indeks koleksinya?**

Indeks hanya bermakna untuk preset penghubung dan tata letak koleksi yang diketahui. Periksa [IAdjustValue.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/iadjustvalue/type/) sebelum mengubah nilai, dan gunakan [IAdjustValue.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/iadjustvalue/name/) sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari sekali.

**Apa yang terjadi ketika sebuah bentuk yang terhubung dihapus?**

Ujung penghubung yang bersangkutan menjadi terlepas. Penghubung tetap berada di slide dan dapat dihapus, diposisikan sebagai garis bebas, atau dilekatkan ke bentuk lain.

**Apakah ikatan penghubung dipertahankan saat slide disalin?**

Ikatan umumnya dipertahankan ketika bentuk‑bentuk yang terhubung disalin bersama slide. Jika sebuah penghubung disalin tanpa salah satu bentuk targetnya, ujung yang terpengaruh harus dilekatkan kembali.