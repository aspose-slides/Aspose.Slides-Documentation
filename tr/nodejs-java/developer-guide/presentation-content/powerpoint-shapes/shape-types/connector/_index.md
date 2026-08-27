---
title: JavaScript Kullanarak Sunumlarda Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/nodejs-java/connector/
keywords:
- bağlayıcı
- bağlayıcı türü
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- bağlama noktası
- ayarlama noktası
- şekilleri bağlamak
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Java üzerinden düz, bükülmüş ve eğimli PowerPoint bağlayıcılarını ekleme, bağlama, yeniden yönlendirme, ayarlama ve inceleme yöntemlerini öğrenin."
---
## **Genel Bakış**

Bir bağlayıcı, iki şekilden biri hareket ettiğinde bile iki şekle bağlı kalabilen bir çizgidir. Uçları, PowerPoint'te yeşil noktalarla temsil edilen bağlama noktalarına bağlanır. Bazı bükülmüş ve eğimli bağlayıcılar ayrıca turuncu noktalarla temsil edilen ayarlama noktalarını açığa çıkarır; bu noktalar, bağlayıcı segmentlerinin konumunu kontrol eder.

Aspose.Slides bağlayıcıları [Connector](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/) sınıfı aracılığıyla temsil eder. Bağlayıcıları oluşturabilir, uçlarını şekillere bağlayabilir, bağlama noktalarını seçebilir, yeniden yönlendirebilir ve ayarlama noktalarına sahip bağlayıcıların geometrisini değiştirebilirsiniz.

## **Bağlayıcı Türleri**

[ShapeType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapetype/) sınıfı, düz, bükülmüş ve eğimli bağlayıcı ön ayarlarını içerir. Aşağıdaki tablo, mevcut bağlayıcı geometrilerini ve her ön ayarın tanımladığı ayarlama noktalarının sayısını gösterir.

| Bağlayıcı | Görsel | Ayarlama noktalarının sayısı |
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

Ayarlama noktalarının sayısı ve anlamı, seçilen bağlayıcı ön ayarının bir parçasıdır. İki farklı bağlayıcı tipinin aynı koleksiyon düzenini ortaya koyduğunu varsaymayın.

## **İki Şekli Bağla**

[ShapeCollection.addConnector](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/addconnector/) kullanarak bir bağlayıcı ekleyin ve uçlarını bağlamak için [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) ve [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) yöntemlerini kullanın. Her iki uç bağlandıktan sonra, [Connector.reroute](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/reroute/) şekiller arasındaki kısa yolu seçer.

Aşağıdaki örnek, bir elips ve bir dikdörtgeni bükülmüş bir bağlayıcıyla birleştirir:

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

{{% alert color="warning" title="Warning" %}}
`reroute` çağrısı, [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) ve [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/) değerlerini değiştirebilir. Bu noktalar sabit kalmalıysa, yeniden yönlendirmeden sonra belirli bağlama noktalarını atayın.
{{% /alert %}}

## **Bir Bağlama Noktası Seç**

Her bağlanabilir şekil, bağlama noktalarının sayısını [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getconnectionsitecount/) aracılığıyla bildirir. Bağlayıcı ucuna atamadan önce tercih edilen sıfır‑tabanlı nokta indeksini doğrulayın; nokta sayıları şekil geometrisine göre değişir.

Bu örnek, elips üzerindeki belirli bir nokta mevcut olduğunda bağlayıcıyı o noktaya bağlar:

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

## **Bir Bağlayıcı Noktasını Ayarla**

Ayarlama noktalarına sahip bağlayıcılar, bu noktaları [GeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/geometryshape/) aracılığıyla ortaya çıkarır. Her bir [AdjustValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/) incelenmeli ve değeri değiştirmeden önce [getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/) değeri kontrol edilmelidir; değer daha sonra [setRawValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) ile ayarlanabilir. Ön ayar şekil ayarlamalarıyla ilgili genel kurallar, [Shape Manipulation](/slides/tr/nodejs-java/shape-manipulations/) bölümünde açıklanmıştır.

Bağlayıcı ayarlamalarının sayısı, sırası, anlamı ve geçerli değer aralığı bağlayıcı ön ayarına bağlıdır. Ayarlama türü salt‑okunur, ayarlama değeri ise yazılabilir. Aynı anlamsal tipe sahip birden fazla ayarlama bulunduğunda, salt‑okunur [getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/getname/) yöntemi ek tanımlama sağlar.

### **Bir Engelin Etrafından Geçirme**

Aşağıdaki düzenlemede, iki şekil arasındaki bir `BentConnector5` üçüncü bir şekilden geçer:

![connector-obstruction](connector-obstruction.png)

Bu kod, engelli bağlayıcıyı oluşturur:

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

Dikey bükülmeyi hareket ettirmek, bağlayıcının engeli atlayarak yol almasını sağlar:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Koleksiyon indeksi `1` her zaman dik bükülmeyi temsil eder diye varsaymak yerine, bu örnek `ConnectorBendPositionY` için arama yapar ve yalnızca beklenen anlamsal tip mevcutsa değiştirir:

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

Bir `BentConnector5` iki `ConnectorBendPositionX` ayarlaması ve bir `ConnectorBendPositionY` ayarlaması içerir. İhtiyacınız olan tip birden fazla kez bulunuyorsa, seçim yapmadan önce `getName` ve ön ayarın bilinen geometrisini inceleyin. Bir ayarlama `ShapeAdjustmentType.Custom` döndürürse, anlamı ve aralığı ön ayara özgü kabul edin ve sözleşme netleşene kadar değiştirmeyin.

## **Ayarlama Değerlerini Bağlayıcı Geometrisiyle İlişkilendir**

Bükülmüş bağlayıcılar için ayarlama değerleri, bireysel segmentlerin konumlarını tahmin etmekte kullanılabilir. Bu hesaplamalar bağlayıcı ön ayarına özgüdür:

- `BentConnector4` genellikle bir `ConnectorBendPositionX` ve bir `ConnectorBendPositionY` ayarlaması ortaya çıkarır.
- Bu bükülme konumları için, `getRawValue` ile dönen değeri `100000` ile bölmek, aşağıdaki örneklerde kullanılan bağlayıcı çerçeve genişliği veya yüksekliğinin kesirini verir.
- Bağlayıcı çerçevesi döndürülebilir veya çevrilebilir; bu nedenle çerçeve koordinatları slayt koordinatlarıyla karşılaştırılmadan önce dönüştürülmelidir.

Aşağıdaki örnekler, önce ayarlamaları tanımlamak için `getType` kullanır. Koleksiyon indekslerini taşınabilir tanımlayıcı olarak kullanmazlar.

### **Döndürülmemiş Bağlayıcı**

İlk düzen, bir `BentConnector4` ile bağlanmış iki metin şekli içerir:

![connector-shape-complex](connector-shape-complex.png)

Bu örnek, bağlayıcıyı inceleyerek yatay ve dik bükülme ayarlamalarını alır:

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

Her iki bükülmeyi de değiştirmek için, beklenen türleri bulup değerleri yalnızca ikisi de bulunduğunda değiştirin:

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

Sonuç, yatay ve dik segmentleri hareket etmiş bir bağlayıcıdır:

![connector-adjusted-1](connector-adjusted-1.png)

Anlamsal tipler bilindiğinde, değerler bağlayıcı‑çerçeve koordinatlarına dönüştürülebilir. Bu örnek, iki bükülme ayarlamasıyla kontrol edilen dik segmentin üzerine ince bir dikdörtgen çizer:

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

Kılavuz şekil, hesaplanan segmenti işaretler:

![connector-adjusted-2](connector-adjusted-2.png)

### **Döndürülmüş veya Çevrilmiş Bağlayıcı**

Aynı bağlayıcı geometrisi dikey konumlandırıldığında, [Shape.getFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapeframe/getfliph/), ve [ShapeFrame.getFlipV](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapeframe/getflipv/) değerleri, bağlayıcı‑çerçeve koordinatlarının slayt koordinatlarına dönüşümünü etkiler.

Bu örnek, dikey yönlendirilmiş bağlayıcıyı oluşturur ve ayarlar:

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

Ayarlanan bağlayıcı, şekiller arasında dikey olarak görünür:

![connector-adjusted-3](connector-adjusted-3.png)

Arbitrary bir döndürme açısı `alpha` için, bağlayıcı‑çerçeve noktasını `(x, y)` çerçeve merkezi `(x0, y0)` etrafında döndürün:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Aşağıdaki kod, bu örnekte kullanılan 90‑derecelik yönlendirmeyi işler ve ilgili bağlayıcı segmentinin üzerine kırmızı bir kılavuz çizer:

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

Kırmızı kılavuz, koordinat dönüşümünden sonra hesaplanan segmenti işaretler:

![connector-adjusted-4](connector-adjusted-4.png)

Bu formüller, örneklerde kullanılan ön ayarları açıklar; evrensel bir bağlayıcı modeli değildir. Farklı bir ön ayara aynı hesabı uygulamadan önce ayarlama tiplerini, çerçeve yönünü ve değer aralıklarını doğrulayın.

## **Bağlayıcı Yön Açısını Bul**

Düz bir bağlayıcının yönü, genişlik ve yükseklik değerlerinden, yatay ve dik çevrimler uygulanarak hesaplanabilir. Aşağıdaki örnek, slayt koordinatlarında pozitif yatay eksenden saat yönünde açıyı raporlar:

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

## **SSS**

**Bir bağlayıcı bir şekle bağlanabilir mi, nasıl anlayabilirim?**  
Şeklin [getConnectionSiteCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getconnectionsitecount/) değerini kontrol edin. Pozitif bir sayı, şeklin bağlama noktaları sunduğu anlamına gelir. Bağlayıcı ucuna atamadan önce seçili nokta indeksini doğrulayın.

**Bir bağlayıcı ayarlamasını koleksiyon indeksine göre tanımlayabilir miyim?**  
İndeks, yalnızca bilinen bir bağlayıcı ön ayarı ve koleksiyon düzeni için anlamlıdır. Değeri değiştirmeden önce [AdjustValue.getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/) kontrol edin ve aynı anlamsal tip birden çok kez bulunuyorsa ek bilgi için [AdjustValue.getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/getname/) kullanın.

**Bağlı bir şekil silindiğinde ne olur?**  
İlgili bağlayıcı ucu ayrılır. Bağlayıcı slaytta kalır ve silinebilir, serbest bir çizgi olarak konumlandırılabilir veya başka bir şekle bağlanabilir.

**Bir slayt kopyalandığında bağlayıcı bağlamaları korunur mu?**  
Bağlantılı şekiller slaytla birlikte kopyalandığında bağlamalar genellikle korunur. Bir bağlayıcı, hedef şekillerinden biri olmadan kopyalanırsa, etkilenen uç yeniden bağlanmalıdır.