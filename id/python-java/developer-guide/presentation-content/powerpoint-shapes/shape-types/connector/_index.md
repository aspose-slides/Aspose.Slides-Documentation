---
title: Mengelola Connector dalam Presentasi dengan Python via Java
linktitle: Connector
type: docs
weight: 10
url: /id/python-java/connector/
keywords:
- connector
- jenis connector
- titik connector
- garis connector
- sudut connector
- situs koneksi
- titik penyesuaian
- menghubungkan shape
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan, mengaitkan, mengubah rute, menyesuaikan, dan memeriksa connector lurus, bengkok, dan melengkung di PowerPoint dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Connector adalah garis yang dapat tetap terhubung ke dua shape ketika salah satu shape bergerak. Ujung‑ujungnya terhubung ke situs koneksi, yang ditunjukkan oleh titik hijau di PowerPoint. Beberapa connector yang bengkok dan melengkung juga menampilkan titik penyesuaian, yang ditunjukkan oleh titik oranye, yang mengontrol posisi segmen connector individual.

Aspose.Slides merepresentasikan connector melalui kelas [Connector](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/) . Anda dapat membuatnya, mengaitkan ujungnya ke shape, memilih situs koneksi, mengubah rutenya, dan memodifikasi geometri connector yang memiliki titik penyesuaian.

## **Jenis Connector**

Kelas [ShapeType](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/) mencakup preset connector lurus, bengkok, dan melengkung. Tabel berikut menunjukkan geometri connector yang tersedia dan jumlah titik penyesuaian yang didefinisikan oleh masing‑masing preset.

| Connector | Gambar | Jumlah titik penyesuaian |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Jumlah dan arti titik penyesuaian merupakan bagian dari preset connector yang dipilih. Jangan menganggap bahwa dua jenis connector yang berbeda menampilkan tata letak koleksi yang sama.

## **Hubungkan Dua Shape**

Gunakan [ShapeCollection.addConnector](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addConnector) untuk menambahkan connector, dan gunakan [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/#setStartShapeConnectedTo) serta [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/#setEndShapeConnectedTo) untuk mengaitkan ujung‑ujungnya. Setelah kedua ujung terhubung, [Connector.reroute](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/#reroute) memilih rute pendek antara shape.

Contoh berikut menghubungkan sebuah elips dan sebuah persegi panjang dengan connector bengkok:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Memanggil [reroute](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/#reroute) dapat mengubah nilai [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) dan [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Tetapkan situs koneksi tertentu setelah reroute jika situs tersebut harus tetap tetap.
{{% /alert %}}

## **Pilih Situs Koneksi**

Setiap shape yang dapat dihubungkan melaporkan jumlah situsnya melalui [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getConnectionSiteCount). Validasi indeks situs berbasis nol yang diinginkan sebelum menetapkannya ke ujung connector; jumlah situs bervariasi menurut geometri shape.

Contoh ini mengaitkan connector ke situs tertentu pada elips bila situs tersebut ada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sesuaikan Titik Connector**

Connector dengan titik penyesuaian menampilkannya melalui [GeometryShape.getAdjustments](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/#getAdjustments). Periksa setiap [AdjustValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/) dan periksa nilai [getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getType) sebelum mengubahnya dengan [setRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#setRawValue). Aturan umum untuk mengidentifikasi penyesuaian shape preset dijelaskan di [Shape Manipulation](/slides/id/python-java/shape-manipulations/).

Jumlah, urutan, arti, dan rentang nilai yang valid untuk penyesuaian connector tergantung pada preset connector. Tipe penyesuaian bersifat read‑only, sedangkan nilai penyesuaian dapat ditulis. Metode read‑only [getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getName) memberikan identifikasi tambahan ketika sebuah connector berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

### **Rute Mengelilingi Halangan**

Dalam tata letak berikut, sebuah connector [BentConnector5](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector5) antara dua shape melintasi shape ketiga:

![connector-obstruction](connector-obstruction.png)

Kode berikut membuat connector yang terhalang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Memindahkan bengkok vertikal mengubah rute sehingga connector mengelak dari halangan:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Alih‑alih mengasumsikan bahwa indeks koleksi `1` selalu mewakili bengkok vertikal, contoh ini mencari [ConnectorBendPositionY](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) dan mengubahnya hanya ketika tipe semantik yang diharapkan ada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sebuah [BentConnector5](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector5) memiliki dua penyesuaian [ConnectorBendPositionX](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) dan satu penyesuaian [ConnectorBendPositionY](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Jika tipe yang Anda perlukan muncul lebih dari sekali, periksa [getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getName) dan geometri preset yang diketahui sebelum memilih satu. Jika sebuah penyesuaian melaporkan [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#Custom), perlakukan arti dan rentangnya sebagai spesifik preset dan jangan ubah hingga kontrak tersebut diketahui.

## **Hubungkan Nilai Penyesuaian dengan Geometri Connector**

Untuk connector bengkok, nilai penyesuaian dapat digunakan untuk memperkirakan posisi segmen individual. Perhitungan ini spesifik untuk preset connector:

- [BentConnector4](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector4) biasanya menampilkan satu penyesuaian [ConnectorBendPositionX](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) dan satu penyesuaian [ConnectorBendPositionY](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Untuk posisi bengkok ini, membagi nilai yang dikembalikan oleh [getRawValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getRawValue) dengan `100000.0` menghasilkan fraksi lebar atau tinggi frame connector yang digunakan pada contoh di bawah.
- Sebuah frame connector dapat diputar atau dibalik, sehingga koordinat frame harus diubah sebelum dibandingkan dengan koordinat slide.

Contoh berikut menggunakan [getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getType) untuk mengidentifikasi penyesuaian terlebih dahulu. Mereka tidak memperlakukan indeks koleksi sebagai pengenal yang dapat dipindahkan.

### **Connector Tanpa Rotasi**

Tata letak awal berisi dua shape teks yang terhubung oleh sebuah [BentConnector4](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Contoh ini memeriksa connector dan memperoleh penyesuaian bengkok horizontal dan vertikalnya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Untuk mengubah kedua bengkok, temukan setiap tipe yang diharapkan dan modifikasi nilai hanya setelah keduanya ditemukan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya adalah connector dengan segmen horizontal dan vertikal yang telah bergeser:

![connector-adjusted-1](connector-adjusted-1.png)

Setelah tipe semantik diketahui, nilainya dapat dikonversi ke koordinat frame connector. Contoh ini menggambar persegi panjang tipis di atas segmen vertikal yang dikendalikan oleh dua penyesuaian bengkok:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Shape panduan menandai segmen yang dihitung:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connector Berputar atau Terbalik**

Ketika geometri connector yang sama diorientasikan secara vertikal, nilai [Shape.getFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeframe/#getFlipH), dan [ShapeFrame.getFlipV](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeframe/#getFlipV) memengaruhi konversi dari koordinat frame connector ke koordinat slide.

Contoh ini membuat dan menyesuaikan connector yang berorientasi vertikal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Connector yang disesuaikan muncul secara vertikal di antara shape:

![connector-adjusted-3](connector-adjusted-3.png)

Untuk sudut rotasi sewenang‑wenang `alpha`, putar titik frame connector `(x, y)` mengelilingi pusat frame `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Kode berikut menangani orientasi 90‑derajat yang digunakan dalam contoh ini dan menggambar panduan merah di atas segmen connector yang bersesuaian:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Panduan merah menandai segmen yang dihitung setelah transformasi koordinat:

![connector-adjusted-4](connector-adjusted-4.png)

Rumus‑rumus ini menggambarkan preset yang dipakai dalam contoh, bukan model connector universal. Validasi tipe penyesuaian, orientasi frame, dan rentang nilai sebelum menerapkan perhitungan yang sama pada preset lain.

## **Temukan Sudut Arah Connector**

Arah connector lurus dapat dihitung dari lebar dan tinggi, dengan flip horizontal serta vertikal diterapkan. Contoh berikut melaporkan sudut searah jarum jam dari sumbu horizontal positif dalam koordinat slide:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**Bagaimana cara mengetahui apakah sebuah connector dapat terhubung ke sebuah shape?**

Periksa nilai [getConnectionSiteCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getConnectionSiteCount) pada shape. Nilai positif berarti shape menyediakan situs koneksi. Validasi indeks situs yang dipilih sebelum menetapkannya ke ujung connector mana pun.

**Bisakah saya mengidentifikasi penyesuaian connector berdasarkan indeks koleksinya?**

Indeks hanya bermakna untuk preset connector dan tata letak koleksi yang diketahui. Periksa [AdjustValue.getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getType) sebelum memodifikasi nilai, dan gunakan [AdjustValue.getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/adjustvalue/#getName) sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari sekali.

**Apa yang terjadi ketika sebuah shape yang terhubung dihapus?**

Ujung connector yang bersangkutan menjadi terlepas. Connector tetap berada di slide dan dapat dihapus, diposisikan sebagai garis bebas, atau dihubungkan ke shape lain.

**Apakah ikatan connector dipertahankan saat slide disalin?**

Ikatan biasanya dipertahankan ketika shape yang terhubung disalin bersama slide. Jika sebuah connector disalin tanpa salah satu shape targetnya, ujung yang terpengaruh harus dipasang kembali.