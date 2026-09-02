---
title: Mengelola Konektor dalam Presentasi Menggunakan JavaScript
linktitle: Konektor
type: docs
weight: 10
url: /id/nodejs-java/connector/
keywords:
- konektor
- tipe konektor
- titik konektor
- garis konektor
- sudut konektor
- situs koneksi
- titik penyesuaian
- hubungkan bentuk
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan, menempelkan, mengubah rute, menyesuaikan, dan memeriksa konektor PowerPoint lurus, bengkok, dan melengkung dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Konektor adalah garis yang dapat tetap terhubung ke dua bentuk ketika salah satu bentuk bergerak. Ujungnya terhubung ke situs koneksi, yang diwakili oleh titik hijau di PowerPoint. Beberapa konektor bengkok dan melengkung juga menampilkan titik penyesuaian, yang diwakili oleh titik oranye, yang mengontrol posisi segmen konektor individual.

Aspose.Slides merepresentasikan konektor melalui kelas [Connector](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/). Anda dapat membuatnya, menempelkan ujungnya ke bentuk, memilih situs koneksi, mengubah rutenya, dan memodifikasi geometri konektor yang memiliki titik penyesuaian.

## **Jenis Konektor**

Kelas [ShapeType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapetype/) mencakup preset konektor lurus, bengkok, dan melengkung. Tabel berikut menunjukkan geometri konektor yang tersedia dan jumlah titik penyesuaian yang didefinisikan oleh setiap preset.

| Konektor | Gambar | Jumlah titik penyesuaian |
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

Jumlah dan makna titik penyesuaian merupakan bagian dari preset konektor yang dipilih. Jangan mengasumsikan bahwa dua tipe konektor berbeda menampilkan tata letak koleksi yang sama.

## **Hubungkan Dua Bentuk**

Gunakan [ShapeCollection.addConnector](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/addconnector/) untuk menambahkan sebuah konektor, dan gunakan [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) serta [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) untuk menempelkan ujung-ujungnya. Setelah kedua ujung terpasang, [Connector.reroute](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/reroute/) memilih rute pendek antara bentuk-bentuk tersebut.

Contoh berikut menghubungkan sebuah elips dan sebuah persegi panjang dengan konektor bengkok:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Peringatan" %}}
Memanggil `reroute` dapat mengubah nilai [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) dan [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Tetapkan situs koneksi tertentu setelah pengalihan rute jika situs tersebut harus tetap tetap.
{{% /alert %}}

## **Pilih Situs Koneksi**

Setiap bentuk yang dapat dihubungkan melaporkan jumlah situsnya melalui [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Validasi indeks situs berbasis nol yang diinginkan sebelum menetapkannya ke ujung konektor; jumlah situs bervariasi tergantung geometri bentuk.

Contoh ini menempelkan konektor ke situs tertentu pada elips ketika situs tersebut ada:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sesuaikan Titik Konektor**

Konektor dengan titik penyesuaian menampilkannya melalui [GeometryShape.getAdjustments](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/geometryshape/). Inspeksi setiap [AdjustValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/) dan periksa nilai [getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/) sebelum mengubahnya dengan [setRawValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Aturan umum untuk mengidentifikasi penyesuaian bentuk preset dijelaskan dalam [Shape Manipulation](/slides/id/nodejs-java/shape-manipulations/).

Jumlah, urutan, makna, dan rentang nilai yang sah untuk penyesuaian konektor tergantung pada preset konektor. Tipe penyesuaian bersifat baca‑saja, sedangkan nilai penyesuaian dapat ditulis. Metode baca‑saja [getName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/getname/) memberikan identifikasi tambahan ketika sebuah konektor berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

### **Rute Mengelilingi Hambatan**

Dalam tata letak berikut, sebuah konektor `BentConnector5` antara dua bentuk melewati bentuk ketiga:

![connector-obstruction](connector-obstruction.png)

Kode ini membuat konektor yang terhalang:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Memindahkan bengkok vertikal mengubah rute sehingga konektor melewati hambatan:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Alih‑alih mengasumsikan bahwa indeks koleksi `1` selalu mewakili bengkok vertikal, contoh ini mencari `ConnectorBendPositionY` dan mengubahnya hanya ketika tipe semantik yang diharapkan ada:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Sebuah `BentConnector5` memiliki dua penyesuaian `ConnectorBendPositionX` dan satu penyesuaian `ConnectorBendPositionY`. Jika tipe yang Anda butuhkan muncul lebih dari sekali, inspeksi `getName` dan geometri yang diketahui dari preset tersebut sebelum memilih satu. Jika sebuah penyesuaian melaporkan `ShapeAdjustmentType.Custom`, perlakukan makna dan rentangnya sebagai spesifik preset dan jangan ubah sampai kontrak tersebut diketahui.

## **Hubungkan Nilai Penyesuaian dengan Geometri Konektor**

Untuk konektor bengkok, nilai penyesuaian dapat digunakan untuk memperkirakan posisi segmen individual. Perhitungan ini spesifik untuk preset konektor:

- `BentConnector4` biasanya menampilkan satu penyesuaian `ConnectorBendPositionX` dan satu `ConnectorBendPositionY`.
- Untuk posisi bengkok ini, membagi nilai yang dikembalikan oleh `getRawValue` dengan `100000` menghasilkan pecahan lebar atau tinggi bingkai konektor yang digunakan oleh contoh di bawah.
- Sebuah bingkai konektor dapat diputar atau dibalik, sehingga koordinat bingkai harus ditransformasi sebelum dibandingkan dengan koordinat slide.

Contoh berikut menggunakan `getType` untuk mengidentifikasi penyesuaian terlebih dahulu. Mereka tidak memperlakukan indeks koleksi sebagai pengenal yang dapat dipindahkan.

### **Konektor Tidak Diputar**

Tata letak awal berisi dua bentuk teks yang terhubung oleh sebuah `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Contoh ini menginspeksi konektor dan memperoleh penyesuaian bengkok horizontal serta vertikal:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Untuk mengubah kedua bengkok, temukan setiap tipe yang diharapkan dan modifikasi nilai hanya setelah keduanya ditemukan:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Hasilnya adalah konektor yang segmen horizontal dan vertikalnya telah bergeser:

![connector-adjusted-1](connector-adjusted-1.png)

Setelah tipe semantik diketahui, nilainya dapat dikonversi ke koordinat bingkai konektor. Contoh ini menggambar sebuah persegi panjang tipis di atas segmen vertikal yang dikendalikan oleh dua penyesuaian bengkok:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Bentuk panduan menandai segmen yang dihitung:

![connector-adjusted-2](connector-adjusted-2.png)

### **Konektor Diputar atau Dibalik**

Ketika geometri konektor yang sama diarahkan secara vertikal, nilai [Shape.getFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapeframe/getfliph/), dan [ShapeFrame.getFlipV](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapeframe/getflipv/) memengaruhi konversi dari koordinat bingkai konektor ke koordinat slide.

Contoh ini membuat dan menyesuaikan konektor yang diarahkan vertikal:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Konektor yang disesuaikan muncul secara vertikal di antara bentuk-bentuk:

![connector-adjusted-3](connector-adjusted-3.png)

Untuk sudut rotasi sewenang‑wannnya `alpha`, putar sebuah titik bingkai konektor `(x, y)` sekitar pusat bingkai `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Kode berikut menangani orientasi 90‑derajat yang digunakan dalam contoh ini dan menggambar panduan merah di atas segmen konektor yang bersesuaian:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Panduan merah menandai segmen yang dihitung setelah transformasi koordinat:

![connector-adjusted-4](connector-adjusted-4.png)

Rumus ini menjelaskan preset yang digunakan dalam contoh, bukan model konektor universal. Validasi tipe penyesuaian, orientasi bingkai, dan rentang nilai sebelum menerapkan perhitungan yang sama pada preset yang berbeda.

## **Temukan Sudut Arah Konektor**

Arah sebuah konektor lurus dapat dihitung dari lebar dan tinggi, dengan pembalikan horizontal serta vertikal diterapkan. Contoh berikut melaporkan sudut searah jarum jam dari sumbu horizontal positif dalam koordinat slide:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui apakah sebuah konektor dapat menempel ke sebuah bentuk?**

Periksa nilai [getConnectionSiteCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getconnectionsitecount/) pada bentuk. Nilai positif berarti bentuk menampilkan situs koneksi. Validasi indeks situs yang dipilih sebelum menetapkannya ke salah satu ujung konektor.

**Apakah saya dapat mengidentifikasi penyesuaian konektor berdasarkan indeks koleksinya?**

Indeks hanya bermakna untuk preset konektor yang diketahui dan tata letak koleksi yang diketahui. Periksa [AdjustValue.getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/) sebelum memodifikasi nilai, dan gunakan [AdjustValue.getName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/adjustvalue/getname/) sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari sekali.

**Apa yang terjadi ketika sebuah bentuk yang terhubung dihapus?**

Ujung konektor yang bersangkutan menjadi tidak terpasang. Konektor tetap berada di slide dan dapat dihapus, diposisikan sebagai garis bebas, atau ditempelkan ke bentuk lain.

**Apakah ikatan konektor dipertahankan ketika sebuah slide disalin?**

Ikatan biasanya dipertahankan saat bentuk‑bentuk yang terhubung disalin bersama slide. Jika sebuah konektor disalin tanpa salah satu bentuk targetnya, ujung yang terpengaruh harus ditempelkan kembali.