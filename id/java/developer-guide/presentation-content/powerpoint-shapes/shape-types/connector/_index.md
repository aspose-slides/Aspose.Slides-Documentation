---
title: Kelola Penghubung dalam Presentasi di Java
linktitle: Penghubung
type: docs
weight: 10
url: /id/java/connector/
keywords:
- penghubung
- tipe penghubung
- titik penghubung
- garis penghubung
- sudut penghubung
- situs koneksi
- titik penyesuaian
- menghubungkan bentuk
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan, menempelkan, mengubah rute, menyesuaikan, dan memeriksa penghubung PowerPoint lurus, bengkok, dan melengkung dengan Aspose.Slides untuk Java."
---
## **Gambaran Umum**

Penghubung adalah sebuah garis yang dapat tetap terpasang pada dua bentuk ketika salah satu bentuk bergerak. Ujung‑ujungnya terhubung ke situs koneksi, yang direpresentasikan oleh titik hijau di PowerPoint. Beberapa penghubung yang bengkok dan melengkung juga memiliki titik penyesuaian, yang direpresentasikan oleh titik oranye, yang mengontrol posisi segmen‑segmen penghubung secara individual.

Aspose.Slides merepresentasikan penghubung melalui antarmuka [IConnector](https://reference.aspose.com/slides/id/java/com.aspose.slides/iconnector/). Anda dapat membuatnya, menempelkan ujung‑ujungnya ke bentuk, memilih situs koneksi, mengubah rutenya, dan memodifikasi geometri penghubung yang memiliki titik penyesuaian.

## **Jenis Penghubung**

Kelas [ShapeType](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapetype/) mencakup preset penghubung lurus, bengkok, dan melengkung. Tabel berikut menunjukkan geometri penghubung yang tersedia dan jumlah titik penyesuaian yang didefinisikan oleh masing‑masing preset.

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

Jumlah dan arti titik penyesuaian merupakan bagian dari preset penghubung yang dipilih. Jangan berasumsi bahwa dua tipe penghubung yang berbeda menampilkan susunan koleksi yang sama.

## **Sambungkan Dua Bentuk**

Gunakan [IShapeCollection.addConnector](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) untuk menambahkan penghubung, dan gunakan [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) serta [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) untuk menempelkan ujung‑ujungnya. Setelah kedua ujung terpasang, [IConnector.reroute](https://reference.aspose.com/slides/id/java/com.aspose.slides/iconnector/#reroute--) memilih rute pendek di antara kedua bentuk.

Contoh berikut menghubungkan sebuah elips dan persegi panjang dengan penghubung bengkok:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Memanggil `reroute` dapat mengubah nilai [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) dan [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Tetapkan situs koneksi tertentu setelah mereroute bila situs‑situs tersebut harus tetap tetap.
{{% /alert %}}

## **Pilih Situs Koneksi**

Setiap bentuk yang dapat dihubungkan melaporkan jumlah situsnya melalui [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Validasi indeks situs berbasis nol yang diinginkan sebelum menugaskannya ke ujung penghubung; jumlah situs bervariasi tergantung pada geometri bentuk.

Contoh ini menempelkan penghubung ke situs tertentu pada elips bila situs tersebut ada:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sesuaikan Titik Penghubung**

Penghubung dengan titik penyesuaian mengeksposnya melalui [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/id/java/com.aspose.slides/igeometryshape/#getAdjustments--). Periksa setiap [IAdjustValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/) dan nilai [getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#getType--)‑nya sebelum mengubahnya dengan [setRawValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). Aturan umum untuk mengidentifikasi penyesuaian bentuk preset dijelaskan dalam [Shape Manipulation](/slides/id/java/shape-manipulations/).

Jumlah, urutan, arti, dan rentang nilai yang sah dari penyesuaian penghubung bergantung pada preset penghubung. Tipe penyesuaian bersifat read‑only, sedangkan nilai penyesuaian dapat ditulis. Metode read‑only [getName](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#getName--) memberikan identifikasi tambahan ketika sebuah penghubung berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

### **Rute Mengelilingi Rintangan**

Pada tata letak berikut, sebuah penghubung `BentConnector5` di antara dua bentuk melewati bentuk ketiga:

![connector-obstruction](connector-obstruction.png)

Kode ini membuat penghubung yang terhalang:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Memindahkan bengkok vertikal mengubah rute sehingga penghubung melewati rintangan:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Alih‑alihasumsikan bahwa indeks koleksi `1` selalu mewakili bengkok vertikal, contoh ini mencari `ConnectorBendPositionY` dan mengubahnya hanya ketika tipe semantik yang diharapkan ada:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Sebuah `BentConnector5` memiliki dua penyesuaian `ConnectorBendPositionX` dan satu penyesuaian `ConnectorBendPositionY`. Jika tipe yang Anda butuhkan muncul lebih dari satu kali, periksa `getName` dan geometri preset yang diketahui sebelum memilih satu. Jika sebuah penyesuaian melaporkan `ShapeAdjustmentType.Custom`, perlakukan arti dan rentangnya sebagai spesifik preset dan jangan ubah sampai kontrak tersebut diketahui.

## **Hubungkan Nilai Penyesuaian dengan Geometri Penghubung**

Untuk penghubung bengkok, nilai penyesuaian dapat digunakan untuk memperkirakan posisi segmen‑segmen individual. Perhitungan ini spesifik untuk preset penghubung:

- `BentConnector4` biasanya menampilkan satu penyesuaian `ConnectorBendPositionX` dan satu `ConnectorBendPositionY`.
- Untuk posisi bengkok ini, membagi nilai yang dikembalikan oleh `getRawValue` dengan `100000f` menghasilkan fraksi lebar atau tinggi bingkai penghubung yang digunakan pada contoh di bawah.
- Bingkai penghubung dapat diputar atau dibalik, sehingga koordinat bingkai harus ditransformasikan sebelum dibandingkan dengan koordinat slide.

Contoh‑contoh berikut menggunakan `getType` untuk mengidentifikasi penyesuaian terlebih dahulu. Mereka tidak memperlakukan indeks koleksi sebagai pengidentifikasi portabel.

### **Penghubung Tanpa Rotasi**

Tata letak awal berisi dua bentuk teks yang dihubungkan oleh sebuah `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Contoh ini memeriksa penghubung dan mendapatkan penyesuaian bengkok horizontal serta vertikalnya:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Untuk mengubah kedua bengkok, temukan masing‑masing tipe yang diharapkan dan modifikasi nilainya hanya setelah keduanya ditemukan:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Hasilnya adalah penghubung dengan segmen horizontal dan vertikal yang telah berpindah:

![connector-adjusted-1](connector-adjusted-1.png)

Setelah tipe semantik diketahui, nilainya dapat dikonversi ke koordinat bingkai‑penghubung. Contoh ini menggambar sebuah persegi panjang tipis di atas segmen vertikal yang dikendalikan oleh dua penyesuaian bengkok:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Bentuk panduan menandai segmen yang dihitung:

![connector-adjusted-2](connector-adjusted-2.png)

### **Penghubung Diputar atau Dibelokkan**

Ketika geometri penghubung yang sama berorientasi vertikal, nilai [IShape.getFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapeframe/#getFlipH--), dan [ShapeFrame.getFlipV](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapeframe/#getFlipV--) memengaruhi konversi dari koordinat bingkai‑penghubung ke koordinat slide.

Contoh ini membuat dan menyesuaikan penghubung berorientasi vertikal:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Penghubung yang telah disesuaikan muncul secara vertikal di antara bentuk‑bentuk:

![connector-adjusted-3](connector-adjusted-3.png)

Untuk sudut rotasi sewenang‑wenang `alpha`, putar titik bingkai‑penghubung `(x, y)` sekitar pusat bingkai `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Kode berikut menangani orientasi 90‑derajat yang dipakai dalam contoh ini dan menggambar panduan merah di atas segmen penghubung yang bersesuaian:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Panduan merah menandai segmen yang dihitung setelah transformasi koordinat:

![connector-adjusted-4](connector-adjusted-4.png)

Rumus‑rumus ini menjelaskan preset yang dipakai dalam contoh, bukan model penghubung universal. Validasi tipe penyesuaian, orientasi bingkai, dan rentang nilai sebelum menerapkan perhitungan yang sama pada preset lain.

## **Temukan Sudut Arah Penghubung**

Arah sebuah penghubung lurus dapat dihitung dari lebar dan tingginya, dengan pembalikan horizontal serta vertikal diterapkan. Contoh berikut melaporkan sudut searah jarum jam dari sumbu horizontal positif dalam koordinat slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bagaimana saya mengetahui apakah sebuah penghubung dapat menempel pada sebuah bentuk?**

Periksa nilai [getConnectionSiteCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getConnectionSiteCount--) pada bentuk. Jumlah positif berarti bentuk tersebut mengekspor situs koneksi. Validasi indeks situs yang dipilih sebelum menugaskannya ke salah satu ujung penghubung.

**Apakah saya dapat mengidentifikasi penyesuaian penghubung melalui indeks koleksinya?**

Indeks hanya bermakna untuk preset penghubung dan susunan koleksi yang diketahui. Periksa [IAdjustValue.getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#getType--) sebelum memodifikasi nilai, dan gunakan [IAdjustValue.getName](https://reference.aspose.com/slides/id/java/com.aspose.slides/iadjustvalue/#getName--) sebagai informasi tambahan bila tipe semantik yang sama muncul lebih dari satu kali.

**Apa yang terjadi ketika bentuk yang terhubung dihapus?**

Ujung penghubung yang bersangkutan menjadi terlepas. Penghubung tetap berada di slide dan dapat dihapus, diposisikan sebagai garis bebas, atau ditempelkan ke bentuk lain.

**Apakah ikatan penghubung dipertahankan ketika slide disalin?**

Ikatan umumnya dipertahankan ketika bentuk‑bentuk yang terhubung disalin bersama slide. Jika sebuah penghubung disalin tanpa salah satu bentuk targetnya, ujung yang terpengaruh harus ditempelkan kembali.