---
title: Mengelola Penghubung dalam Presentasi menggunakan PHP
linktitle: Penghubung
type: docs
weight: 10
url: /id/php-java/connector/
keywords:
- penghubung
- jenis penghubung
- titik penghubung
- garis penghubung
- sudut penghubung
- situs koneksi
- titik penyesuaian
- menghubungkan bentuk
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambah, menempel, mengarahkan ulang, menyesuaikan, dan memeriksa penghubung PowerPoint lurus, bengkok, dan melengkung dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Penghubung adalah sebuah garis yang dapat tetap terpasang pada dua bentuk ketika salah satu bentuk bergerak. Ujung‑ujungnya menempel pada situs koneksi, yang ditunjukkan oleh titik hijau di PowerPoint. Beberapa penghubung yang bengkok dan melengkung juga menampilkan titik penyesuaian, yang ditunjukkan oleh titik oranye, yang mengontrol posisi segmen penghubung individu.

Aspose.Slides merepresentasikan penghubung melalui kelas [Connector](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/). Anda dapat membuatnya, menempelkan ujungnya ke bentuk, memilih situs koneksi, mengarahkan ulang, dan memodifikasi geometri penghubung yang memiliki titik penyesuaian.

## **Jenis Penghubung**

Kelas [ShapeType](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapetype/) mencakup preset penghubung lurus, bengkok, dan melengkung. Tabel berikut menunjukkan geometri penghubung yang tersedia dan jumlah titik penyesuaian yang didefinisikan oleh masing‑masing preset.

| Penghubung | Image | Jumlah titik penyesuaian |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Jumlah dan arti titik penyesuaian merupakan bagian dari preset penghubung yang dipilih. Jangan mengasumsikan bahwa dua tipe penghubung yang berbeda menampilkan susunan koleksi yang sama.

## **Hubungkan Dua Bentuk**

Gunakan [ShapeCollection::addConnector](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addconnector/) untuk menambahkan penghubung, dan gunakan [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/setstartshapeconnectedto/) serta [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/setendshapeconnectedto/) untuk menempelkan ujung‑ujungnya. Setelah kedua ujung terpasang, [Connector::reroute](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/reroute/) memilih rute pendek di antara bentuk‑bentuk.

Contoh berikut menghubungkan sebuah elips dan sebuah persegi panjang dengan penghubung bengkok:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Memanggil `reroute` dapat mengubah nilai [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) dan [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Tetapkan situs koneksi spesifik setelah pengalihan jika situs tersebut harus tetap tetap.
{{% /alert %}}

## **Pilih Situs Koneksi**

Setiap bentuk yang dapat dihubungkan melaporkan jumlah situsnya melalui [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getconnectionsitecount/). Validasi indeks situs berbasis nol yang diinginkan sebelum menetapkannya ke ujung penghubung; jumlah situs bervariasi menurut geometri bentuk.

Contoh ini menempelkan penghubung ke situs tertentu pada elips ketika situs tersebut ada:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sesuaikan Titik Penghubung**

Penghubung dengan titik penyesuaian menampilkan mereka melalui [GeometryShape::getAdjustments](https://reference.aspose.com/slides/id/php-java/aspose.slides/geometryshape/#getadjustments). Periksa setiap [AdjustValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/) dan periksa nilai [AdjustValue::getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/#gettype) sebelum mengubahnya dengan [AdjustValue::setRawValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/setrawvalue/). Aturan umum untuk mengidentifikasi penyesuaian bentuk preset dijelaskan di [Shape Manipulation](/slides/id/php-java/shape-manipulations/).

Jumlah, urutan, arti, dan rentang nilai yang valid untuk penyesuaian penghubung tergantung pada preset penghubung. Tipe penyesuaian bersifat read‑only, sedangkan nilai penyesuaian dapat ditulis. Metode read‑only [AdjustValue::getName](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/getname/) memberikan identifikasi tambahan ketika sebuah penghubung berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

### **Rute Mengelilingi Halangan**

Pada tata letak berikut, sebuah penghubung `BentConnector5` antara dua bentuk melewati bentuk ketiga:

![connector-obstruction](connector-obstruction.png)

Kode ini membuat penghubung yang terhalang:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Memindahkan bengkok vertikal mengubah rute sehingga penghubung melewati halangan:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Alih‑alih mengasumsikan bahwa indeks koleksi `1` selalu mewakili bengkok vertikal, contoh ini mencari `ConnectorBendPositionY` dan mengubahnya hanya ketika tipe semantik yang diharapkan ada:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Sebuah `BentConnector5` memiliki dua penyesuaian `ConnectorBendPositionX` dan satu penyesuaian `ConnectorBendPositionY`. Jika tipe yang Anda butuhkan muncul lebih dari satu kali, periksa `getName` dan geometri preset yang diketahui sebelum memilih salah satu. Jika sebuah penyesuaian melaporkan `ShapeAdjustmentType::Custom`, perlakukan arti dan rentangnya sebagai spesifik preset dan jangan ubah sampai kontrak tersebut diketahui.

## **Hubungkan Nilai Penyesuaian dengan Geometri Penghubung**

Untuk penghubung bengkok, nilai penyesuaian dapat digunakan untuk memperkirakan posisi segmen individu. Perhitungan ini spesifik untuk preset penghubung:

- `BentConnector4` biasanya menampilkan satu penyesuaian `ConnectorBendPositionX` dan satu `ConnectorBendPositionY`.
- Untuk posisi bengkok ini, membagi nilai yang dikembalikan oleh `getRawValue` dengan `100000` menghasilkan fraksi lebar atau tinggi bingkai penghubung yang digunakan pada contoh di bawah.
- Bingkai penghubung dapat diputar atau dibalik, sehingga koordinat bingkai harus ditransformasi sebelum dibandingkan dengan koordinat slide.

Contoh berikut menggunakan `getType` untuk mengidentifikasi penyesuaian terlebih dahulu. Mereka tidak memperlakukan indeks koleksi sebagai pengenal portabel.

### **Penghubung Tanpa Rotasi**

Tata letak awal berisi dua bentuk teks yang dihubungkan oleh sebuah `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Contoh ini memeriksa penghubung dan memperoleh penyesuaian bengkok horizontal dan vertikal:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Untuk mengubah kedua bengkok, temukan setiap tipe yang diharapkan dan modifikasi nilai hanya setelah keduanya ditemukan:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Hasilnya adalah penghubung yang segmen horizontal dan vertikalnya telah bergeser:

![connector-adjusted-1](connector-adjusted-1.png)

Setelah tipe semantik diketahui, nilainya dapat dikonversi menjadi koordinat bingkai penghubung. Contoh ini menggambar sebuah persegi panjang tipis di atas segmen vertikal yang dikendalikan oleh dua penyesuaian bengkok:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Bentuk panduan menandai segmen yang dihitung:

![connector-adjusted-2](connector-adjusted-2.png)

### **Penghubung Diputar atau Dibalik**

Ketika geometri penghubung yang sama berorientasi vertikal, nilai [Shape::getFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeframe/getfliph/), dan [ShapeFrame::getFlipV](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapeframe/getflipv/) memengaruhi konversi dari koordinat bingkai penghubung ke koordinat slide.

Contoh ini membuat dan menyesuaikan penghubung yang berorientasi vertikal:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Penghubung yang telah disesuaikan muncul secara vertikal di antara bentuk‑bentuk:

![connector-adjusted-3](connector-adjusted-3.png)

Untuk sudut rotasi sewenang‑wannanya `alpha`, putar titik bingkai penghubung `(x, y)` di sekitar pusat bingkai `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Kode berikut menangani orientasi 90 derajat yang digunakan dalam contoh ini dan menggambar panduan merah di atas segmen penghubung yang bersesuaian:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Panduan merah menandai segmen yang dihitung setelah transformasi koordinat:

![connector-adjusted-4](connector-adjusted-4.png)

Rumus‑rumus ini menjelaskan preset yang digunakan dalam contoh, bukan model penghubung universal. Validasi tipe penyesuaian, orientasi bingkai, dan rentang nilai sebelum menerapkan perhitungan yang sama pada preset yang berbeda.

## **Temukan Sudut Arah Penghubung**

Arah penghubung lurus dapat dihitung dari lebar dan tinggi, dengan flip horizontal serta vertical yang diterapkan. Contoh berikut melaporkan sudut searah jarum jam dari sumbu horizontal positif dalam koordinat slide:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Bagaimana cara mengetahui apakah sebuah penghubung dapat menempel pada sebuah bentuk?**

Periksa nilai [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getconnectionsitecount/). Jumlah positif berarti bentuk tersebut menampilkan situs koneksi. Validasi indeks situs yang dipilih sebelum menetapkannya ke salah satu ujung penghubung.

**Bisakah saya mengidentifikasi penyesuaian penghubung berdasarkan indeks koleksinya?**

Indeks hanya bermakna untuk preset penghubung dan susunan koleksi yang diketahui. Periksa [AdjustValue::getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/#gettype) sebelum memodifikasi nilai, dan gunakan [AdjustValue::getName](https://reference.aspose.com/slides/id/php-java/aspose.slides/adjustvalue/getname/) sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari sekali.

**Apa yang terjadi ketika sebuah bentuk yang terhubung dihapus?**

Ujung penghubung yang bersangkutan menjadi terlepas. Penghubung tetap berada di slide dan dapat dihapus, diposisikan sebagai garis bebas, atau ditempelkan ke bentuk lain.

**Apakah ikatan penghubung dipertahankan ketika sebuah slide disalin?**

Ikatan biasanya dipertahankan ketika bentuk‑bentuk yang terhubung disalin bersama slide. Jika sebuah penghubung disalin tanpa salah satu bentuk targetnya, ujung yang terpengaruh harus ditempelkan kembali.