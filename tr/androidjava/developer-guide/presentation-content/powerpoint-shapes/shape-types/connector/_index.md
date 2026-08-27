---
title: Android'de Sunumlarda Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/androidjava/connector/
keywords:
- bağlayıcı
- bağlayıcı tipi
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- bağlantı noktası
- ayarlama noktası
- şekilleri bağla
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden düz, bükülmüş ve eğimli PowerPoint bağlayıcılarını eklemeyi, bağlamayı, yeniden yönlendirmeyi, ayarlamayı ve incelemeyi öğrenin."
---
## **Genel Bakış**

Bağlayıcı, şekillerden biri hareket ettiğinde bile iki şekle bağlı kalabilen bir çizgidir. Uçları, PowerPoint’te yeşil noktalarla gösterilen bağlantı noktalarına bağlanır. Bazı bükülmüş ve eğimli bağlayıcılar ayrıca turuncu noktalarla temsil edilen ayarlama noktalarına sahiptir; bu noktalar bireysel bağlayıcı segmentlerinin konumunu kontrol eder.

Aspose.Slides, bağlayıcıları [IConnector](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iconnector/) arayüzü aracılığıyla temsil eder. Bağlayıcıları oluşturabilir, uçlarını şekillere bağlayabilir, bağlantı noktalarını seçebilir, yeniden yönlendirebilir ve ayarlama noktalarına sahip bağlayıcıların geometrisini değiştirebilirsiniz.

## **Bağlayıcı Türleri**

[ShapeType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapetype/) sınıfı düz, bükülmüş ve eğimli bağlayıcı ön ayarlarını içerir. Aşağıdaki tablo, kullanılabilir bağlayıcı geometrilerini ve her ön ayar tarafından tanımlanan ayarlama noktası sayısını gösterir.

| Bağlayıcı | Görsel | Ayarlama Noktası Sayısı |
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

Ayarlama noktalarının sayısı ve anlamı seçilen bağlayıcı ön ayarının bir parçasıdır. İki farklı bağlayıcı tipinin aynı koleksiyon düzenini sergilediğini varsaymayın.

## **İki Şekli Bağlamak**

Bir bağlayıcı eklemek için [IShapeCollection.addConnector](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) metodunu kullanın ve uçlarını bağlamak için [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) ve [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) metodlarını kullanın. Her iki uç da bağlandıktan sonra, [IConnector.reroute](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iconnector/#reroute--) kısa bir yol seçer.

Aşağıdaki örnek, bir elips ve bir dikdörtgeni bükülmüş bir bağlayıcı ile bağlar:

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

{{% alert color="warning" title="Uyarı" %}}
`reroute` çağrısı, [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) ve [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) değerlerini değiştirebilir. Bu sitelerin sabit kalması gerekiyorsa, yeniden yönlendirmeden sonra belirli bağlantı noktalarını atayın.
{{% /alert %}}

## **Bir Bağlantı Noktasını Seçme**

Bağlanabilir her şekil, [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) metodu aracılığıyla site sayısını raporlar. Bağlayıcı ucuna atamadan önce tercih edilen sıfır‑tabanlı site indeksini doğrulayın; site sayısı şeklin geometrisine göre değişir.

Bu örnek, elips üzerindeki belirli bir site mevcutsa bağlayıcıyı o siteye bağlar:

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

## **Bir Bağlayıcı Noktasını Ayarlama**

Ayarlama noktalarına sahip bağlayıcılar, [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) aracılığıyla bu noktaları sunar. Her bir [IAdjustValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/) incelenmeli ve değeri değiştirmeden önce [getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getType--) değeri kontrol edilmelidir; değişiklik [setRawValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) ile yapılır. Ön ayar şekil ayarlamaları tanımları, [Shape Manipulation](/slides/tr/androidjava/shape-manipulations/) bölümünde açıklanmıştır.

Ayarlama noktalarının sayısı, sırası, anlamı ve geçerli değer aralığı bağlayıcı ön ayarına bağlıdır. Ayarlama türü yalnızca‑okunur, değer ise yazılabilir. Aynı anlamsal türden birden fazla ayarlama olduğunda ek kimlik sağlamak için yalnızca‑okunur [getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getName--) yöntemi kullanılabilir.

### **Engel Çevresinde Rota**

Aşağıdaki yerleşimde, iki şekil arasındaki bir `BentConnector5` üçüncü bir şeklin içinden geçer:

![connector-obstruction](connector-obstruction.png)

Bu kod engelli bağlayıcıyı oluşturur:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Dikey bükmeyi hareket ettirmek, rotayı değiştirerek bağlayıcının engeli atlamasını sağlar:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Koleksiyon indeksi `1` her zaman dikey bükmeyi temsil eder varsayımı yerine, bu örnek `ConnectorBendPositionY` arar ve beklenen anlamsal tür mevcutsa yalnızca o zamanı değiştirir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

`BentConnector5` iki `ConnectorBendPositionX` ve bir `ConnectorBendPositionY` ayarlamasına sahiptir. İhtiyacınız olan tür birden fazla kez ortaya çıkarsa, seçim yapmadan önce `getName` ve ön ayarın bilinen geometrisini inceleyin. Bir ayarlama `ShapeAdjustmentType.Custom` döndürürse, anlamı ve aralığı ön ayara özgü olarak kabul edin ve bu sözleşme bilinmedikçe değiştirmeyin.

## **Bağlayıcı Geometrisine Ayarlama Değerlerini İlişkilendirme**

Bükülmüş bağlayıcılarda, ayarlama değerleri bireysel segment konumlarını tahmin etmek için kullanılabilir. Bu hesaplamalar bağlayıcı ön ayarına özeldir:

- `BentConnector4` normalde bir `ConnectorBendPositionX` ve bir `ConnectorBendPositionY` ayarlaması sunar.
- Bu bükülme konumları için, `getRawValue` tarafından döndürülen değeri `100000f` ile bölmek, aşağıdaki örneklerde kullanılan bağlayıcı çerçeve genişliği veya yüksekliği oranını verir.
- Bağlayıcı çerçevesi döndürülebilir veya çevrilebilir; bu nedenle çerçeve koordinatları kaydırı koordinatlarıyla karşılaştırılmadan önce dönüştürülmelidir.

Aşağıdaki örnekler, önce ayarlamaları tanımlamak için `getType` kullanır. Koleksiyon indekslerini taşınabilir tanımlayıcı olarak kullanmazlar.

### **Döndürülmemiş Bağlayıcı**

İlk yerleşim, iki metin şeklinin bir `BentConnector4` ile bağlandığını gösterir:

![connector-shape-complex](connector-shape-complex.png)

Bu örnek bağlayıcıyı inceler ve yatay ve dikey bükülme ayarlamalarını alır:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Her iki bükülmeyi değiştirmek için, beklenen her türü bulun ve her iki tür bulunduğunda değerleri değiştirin:

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

Sonuç, yatay ve dikey segmentleri hareket etmiş bir bağlayıcıdır:

![connector-adjusted-1](connector-adjusted-1.png)

Anlamsal türler bilindiğinde, değerler bağlayıcı‑çerçeve koordinatlarına dönüştürülebilir. Bu örnek, iki bükülme ayarlamasıyla kontrol edilen dikey segmentin üzerine ince bir dikdörtgen çizer:

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

Kılavuz şekil, hesaplanan segmenti işaretler:

![connector-adjusted-2](connector-adjusted-2.png)

### **Döndürülmüş veya Çevrilmiş Bağlayıcı**

Aynı bağlayıcı geometrisi dikey yönde olduğunda, [IShape.getFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeframe/#getFlipH--) ve [ShapeFrame.getFlipV](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapeframe/#getFlipV--) değerleri, bağlayıcı‑çerçeve koordinatlarından slayt koordinatlarına dönüşümü etkiler.

Bu örnek, dikey yönde yer alan bağlayıcıyı oluşturur ve ayarlar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
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

Ayarlanan bağlayıcı, şekiller arasında dikey olarak görünür:

![connector-adjusted-3](connector-adjusted-3.png)

Rastgele bir dönüş açısı `alpha` için, bir bağlayıcı‑çerçeve noktasını `(x, y)` çerçeve merkezi `(x0, y0)` etrafında döndürün:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Aşağıdaki kod, bu örnekte kullanılan 90‑gradelik yönelimleri işler ve ilgili bağlayıcı segmentinin üzerine kırmızı bir kılavuz çizer:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Kırmızı kılavuz, koordinat dönüşümünden sonra hesaplanan segmenti işaretler:

![connector-adjusted-4](connector-adjusted-4.png)

Bu formüller örneklerde kullanılan ön ayarları açıklar, evrensel bir bağlayıcı modeli değildir. Farklı bir ön ayara aynı hesabı uygulamadan önce ayarlama türlerini, çerçeve yönelimini ve değer aralıklarını doğrulayın.

## **Bağlayıcı Yön Açısını Bul**

Düz bir bağlayıcının yönü, genişlik ve yükseklik değerlerinden, yatay ve dikey çevirmeler uygulanarak hesaplanabilir. Aşağıdaki örnek, slayt koordinatlarında pozitif yatay eksenden saat yönünde açıyı rapor eder:

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

## **SSS**

**Bir bağlayıcının bir şekle bağlanıp bağlanamayacağını nasıl anlarım?**

Şeklin [getConnectionSiteCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) değerini kontrol edin. Pozitif bir sayı, şeklin bağlantı noktaları sunduğunu gösterir. Bağlayıcı ucuna atamadan önce seçilen site indeksini doğrulayın.

**Bir bağlayıcı ayarlamasını koleksiyon indeksiyle tanımlayabilir miyim?**

İndeks yalnızca bilinen bir bağlayıcı ön ayarı ve koleksiyon düzeni için anlamlıdır. Değeri değiştirmeden önce [IAdjustValue.getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getType--) denetleyin ve aynı anlamsal tür birden fazla kez oluştuğunda ek bilgi için [IAdjustValue.getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iadjustvalue/#getName--) kullanın.

**Bağlı bir şekil silindiğinde ne olur?**

İlgili bağlayıcı ucu ayrılır. Bağlayıcı slaytta kalır ve silinebilir, serbest bir çizgi olarak konumlandırılabilir veya başka bir şekle bağlanabilir.

**Bir slayt kopyalandığında bağlayıcı bağlamaları korunur mu?**

Bağlantılı şekiller slaytla birlikte kopyalandığında bağlamalar genellikle korunur. Bir bağlayıcı, hedef şekillerinden biri olmadan kopyalanırsa, etkilenen uç yeniden bağlanmalıdır.