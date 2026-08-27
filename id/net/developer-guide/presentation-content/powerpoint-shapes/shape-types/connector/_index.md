---
title: Mengelola Penghubung dalam Presentasi di .NET
linktitle: Penghubung
type: docs
weight: 10
url: /id/net/connector/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan, melampirkan, mengubah rute, menyesuaikan, dan memeriksa penghubung PowerPoint lurus, bengkok, dan melengkung dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Penghubung adalah garis yang dapat tetap terpasang pada dua bentuk ketika salah satu bentuk bergerak. Ujungnya terhubung ke situs koneksi, yang ditampilkan sebagai titik hijau di PowerPoint. Beberapa penghubung bengkok dan melengkung juga menampilkan titik penyesuaian, yang ditampilkan sebagai titik oranye, yang mengontrol posisi segmen penghubung individu.

Aspose.Slides merepresentasikan penghubung melalui antarmuka [IConnector](https://reference.aspose.com/slides/id/net/aspose.slides/iconnector/) . Anda dapat membuatnya, mengaitkan ujungnya ke bentuk, memilih situs koneksi, mengubah rute mereka, dan memodifikasi geometri penghubung yang memiliki titik penyesuaian.

## **Jenis Penghubung**

Enum [ShapeType](https://reference.aspose.com/slides/id/net/aspose.slides/shapetype/) mencakup preset penghubung lurus, bengkok, dan melengkung. Tabel berikut menunjukkan geometri penghubung yang tersedia dan jumlah titik penyesuaian yang didefinisikan oleh setiap preset.

| Penghubung | Gambar | Jumlah titik penyesuaian |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Jumlah dan makna titik penyesuaian merupakan bagian dari preset penghubung yang dipilih. Jangan berasumsi bahwa dua tipe penghubung berbeda menampilkan tata letak koleksi yang sama.

## **Hubungkan Dua Bentuk**

Gunakan [IShapeCollection.AddConnector](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addconnector/) untuk menambahkan penghubung, dan tetapkan properti [StartShapeConnectedTo](https://reference.aspose.com/slides/id/net/aspose.slides/connector/startshapeconnectedto/) serta [EndShapeConnectedTo](https://reference.aspose.com/slides/id/net/aspose.slides/connector/endshapeconnectedto/) . Setelah kedua ujung terpasang, [IConnector.Reroute](https://reference.aspose.com/slides/id/net/aspose.slides/iconnector/reroute/) memilih rute singkat antara bentuk-bentuk tersebut.

Contoh berikut menghubungkan sebuah elips dan persegi panjang dengan penghubung bengkok:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
Memanggil `Reroute` dapat mengubah nilai [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/net/aspose.slides/connector/startshapeconnectionsiteindex/) dan [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/net/aspose.slides/connector/endshapeconnectionsiteindex/) . Tetapkan situs koneksi spesifik setelah melakukan reroute jika situs tersebut harus tetap tetap.
{{% /alert %}}

## **Pilih Situs Koneksi**

Setiap bentuk yang dapat dihubungkan melaporkan jumlah situsnya melalui [ConnectionSiteCount](https://reference.aspose.com/slides/id/net/aspose.slides/shape/connectionsitecount/). Validasikan indeks situs berbasis nol yang diinginkan sebelum menetapkannya ke ujung penghubung; jumlah situs bervariasi tergantung pada geometri bentuk.

Contoh ini mengaitkan penghubung ke situs tertentu pada elips ketika situs tersebut ada:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Sesuaikan Titik Penghubung**

Penghubung dengan titik penyesuaian menampilkannya melalui [IGeometryShape.Adjustments](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/adjustments/). Periksa setiap [IAdjustValue](https://reference.aspose.com/slides/id/net/aspose.slides/iadjustvalue/) dan periksa [Type](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/type/) sebelum mengubah [RawValue](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/rawvalue/). Aturan umum untuk mengidentifikasi penyesuaian bentuk preset dijelaskan dalam [Shape Manipulation](/slides/id/net/shape-manipulations/).

Jumlah, urutan, makna, dan rentang nilai yang valid dari penyesuaian penghubung bergantung pada preset penghubung. Properti `Type` bersifat read‑only, sementara nilai penyesuaian dapat ditulis. Properti read‑only [Name](https://reference.aspose.com/slides/id/net/aspose.slides/adjustvalue/name/) memberikan identifikasi tambahan ketika sebuah penghubung berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

### **Rute Mengelilingi Rintangan**

Pada tata letak berikut, sebuah penghubung `BentConnector5` antara dua bentuk melewati bentuk ketiga:

![connector-obstruction](connector-obstruction.png)

Kode berikut membuat penghubung yang terhalang:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Menggerakkan bengkok vertikal mengubah rute sehingga penghubung melewati rintangan:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Alih‑alih mengasumsikan bahwa indeks koleksi `1` selalu mewakili bengkok vertikal, contoh ini mencari `ConnectorBendPositionY` dan mengubahnya hanya ketika tipe semantik yang diharapkan ada:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Sebuah `BentConnector5` memiliki dua penyesuaian `ConnectorBendPositionX` dan satu penyesuaian `ConnectorBendPositionY`. Jika tipe yang Anda butuhkan muncul lebih dari satu kali, periksa `Name` dan geometri preset yang diketahui sebelum memilih salah satu. Jika sebuah penyesuaian melaporkan `ShapeAdjustmentType.Custom`, perlakukan makna dan rentangnya sebagai spesifik preset dan jangan ubah sampai kontrak tersebut diketahui.

## **Hubungkan Nilai Penyesuaian dengan Geometri Penghubung**

Untuk penghubung bengkok, nilai penyesuaian dapat digunakan untuk memperkirakan posisi segmen individu. Perhitungan ini spesifik untuk preset penghubung:

- `BentConnector4` biasanya menampilkan satu penyesuaian `ConnectorBendPositionX` dan satu `ConnectorBendPositionY` .
- Untuk posisi bengkok ini, `RawValue / 100000f` menghasilkan fraksi lebar atau tinggi kerangka penghubung yang digunakan oleh contoh di bawah.
- Kerangka penghubung dapat diputar atau dibalik, sehingga koordinat kerangka harus ditransformasi sebelum dibandingkan dengan koordinat slide.

Contoh berikut menggunakan `Type` untuk mengidentifikasi penyesuaian terlebih dahulu. Mereka tidak memperlakukan indeks koleksi sebagai pengenal yang dapat dipindahkan.

### **Penghubung Tanpa Rotasi**

Tata letak awal berisi dua bentuk teks yang terhubung oleh sebuah `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Contoh ini memeriksa penghubung dan memperoleh penyesuaian bengkok horizontal serta vertikal:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Untuk mengubah kedua bengkok, temukan setiap tipe yang diharapkan dan ubah nilainya hanya setelah keduanya ditemukan:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

Hasilnya adalah penghubung yang segmen horizontal dan vertikalnya telah berpindah:

![connector-adjusted-1](connector-adjusted-1.png)

Setelah tipe semantik diketahui, nilainya dapat dikonversi ke koordinat kerangka penghubung. Contoh ini menggambar persegi panjang tipis di atas segmen vertikal yang dikendalikan oleh dua penyesuaian bengkok:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Bentuk panduan menandai segmen yang dihitung:

![connector-adjusted-2](connector-adjusted-2.png)

### **Penghubung yang Diputar atau Dibalik**

Ketika geometri penghubung yang sama diarahkan secara vertikal, nilai [Frame](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/id/net/aspose.slides/shapeframe/fliph/), dan [FlipV](https://reference.aspose.com/slides/id/net/aspose.slides/shapeframe/flipv/) memengaruhi konversi dari koordinat kerangka penghubung ke koordinat slide.

Contoh ini membuat dan menyesuaikan penghubung yang berorientasi vertikal:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

Penghubung yang disesuaikan muncul secara vertikal di antara bentuk-bentuk:

![connector-adjusted-3](connector-adjusted-3.png)

Untuk sudut rotasi sewenang‑wenang `alpha`, putar titik kerangka penghubung `(x, y)` mengelilingi pusat kerangka `(x0, y0)` :

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Kode berikut menangani orientasi 90 derajat yang digunakan dalam contoh ini dan menggambar panduan merah di atas segmen penghubung yang bersesuaian:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Panduan merah menandai segmen yang dihitung setelah transformasi koordinat:

![connector-adjusted-4](connector-adjusted-4.png)

Rumus‑rumus ini menggambarkan preset yang digunakan dalam contoh, bukan model penghubung universal. Validasikan tipe penyesuaian, orientasi kerangka, dan rentang nilai sebelum menerapkan perhitungan yang sama pada preset lain.

## **Temukan Sudut Arah Penghubung**

Arah penghubung lurus dapat dihitung dari lebar dan tinggi, dengan flip horizontal serta vertikal diterapkan. Contoh berikut melaporkan sudut searah jarum jam dari sumbu horizontal positif dalam koordinat slide:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **FAQ**

**Bagaimana saya dapat mengetahui apakah sebuah penghubung dapat dipasang ke sebuah bentuk?**

Periksa `ConnectionSiteCount` pada bentuk. Jumlah positif berarti bentuk tersebut menyediakan situs koneksi. Validasikan indeks situs yang dipilih sebelum menetapkannya ke ujung penghubung mana pun.

**Apakah saya dapat mengidentifikasi penyesuaian penghubung berdasarkan indeks koleksinya?**

Indeks hanya bermakna untuk preset penghubung dan tata letak koleksi yang diketahui. Periksa `IAdjustValue.Type` sebelum mengubah nilai, dan gunakan `IAdjustValue.Name` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari satu kali.

**Apa yang terjadi ketika sebuah bentuk yang terhubung dihapus?**

Ujung penghubung yang bersangkutan menjadi terlepas. Penghubung tetap ada pada slide dan dapat dihapus, diposisikan sebagai garis bebas, atau dipasang ke bentuk lain.

**Apakah pengikatan penghubung dipertahankan ketika slide disalin?**

Pengikatan biasanya dipertahankan ketika bentuk‑bentuk yang terhubung disalin bersama slide. Jika sebuah penghubung disalin tanpa salah satu bentuk targetnya, ujung yang terpengaruh harus dipasang kembali.