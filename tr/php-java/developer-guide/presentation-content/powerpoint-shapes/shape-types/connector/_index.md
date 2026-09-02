---
title: PHP Kullanarak Sunumlarda Bağlayıcıları Yönet
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/php-java/connector/
keywords:
- bağlayıcı
- bağlayıcı tipi
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- bağlantı noktası
- ayar noktası
- şekilleri bağla
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint'teki düz, bükülmüş ve eğimli bağlayıcıları eklemeyi, bağlamayı, yeniden yönlendirmeyi, ayarlamayı ve incelemeyi öğrenin."
---
## **Genel Bakış**

Bağlayıcı, iki şekilden biri hareket ettiğinde bile iki şekle bağlı kalabilen bir çizgidir. Uçları, PowerPoint'te yeşil noktalarla gösterilen bağlantı noktalarına bağlanır. Bazı bükülmüş ve eğimli bağlayıcılar ayrıca turuncu noktalarla temsil edilen ayar noktalarını ortaya çıkarır; bu noktalar bağlantı segmentlerinin konumunu kontrol eder.

Aspose.Slides, bağlayıcıları [Connector](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/) sınıfı aracılığıyla temsil eder. Bağlayıcıları oluşturabilir, uçlarını şekillere bağlayabilir, bağlantı noktalarını seçebilir, yeniden yönlendirebilir ve ayar noktalarına sahip bağlayıcıların geometrisini değiştirebilirsiniz.

## **Bağlayıcı Türleri**

[ShapeType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapetype/) sınıfı düz, bükülmüş ve eğimli bağlayıcı ön ayarlarını içerir. Aşağıdaki tablo, mevcut bağlayıcı geometrilerini ve her ön ayarın tanımladığı ayar noktası sayısını gösterir.

| Bağlayıcı | Görsel | Ayar noktası sayısı |
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

Ayarlama noktalarının sayısı ve anlamı seçilen bağlayıcı ön ayarının bir parçasıdır. İki farklı bağlayıcı tipinin aynı koleksiyon düzenini gösterdiğini varsaymayın.

## **İki Şekli Bağla**

[ShapeCollection::addConnector](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addconnector/) yöntemiyle bir bağlayıcı ekleyebilir ve uçlarını bağlamak için [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/setstartshapeconnectedto/) ve [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/setendshapeconnectedto/) kullanabilirsiniz. Her iki uç da bağlandıktan sonra, [Connector::reroute](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/reroute/) şekiller arasında kısa bir yol seçer.

Aşağıdaki örnek, bir elipsi ve bir dikdörtgeni bükülmüş bir bağlayıcı ile bağlar:

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
`reroute` çağrısı, [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) ve [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) değerlerini değiştirebilir. Bu noktalar sabit kalmalıysa, yeniden yönlendirmeden sonra belirli bağlantı noktalarını atayın.
{{% /alert %}}

## **Bağlantı Noktası Seçme**

Bağlanabilir her şekil, bağlantı noktası sayısını [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getconnectionsitecount/) yöntemiyle raporlar. Bir bağlayıcı ucuna atamadan önce tercih edilen sıfır tabanlı site dizinini doğrulayın; site sayıları şekil geometrisine göre değişir.

Bu örnek, o site mevcut olduğunda bağlayıcıyı elips üzerindeki belirli bir siteye bağlar:

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

## **Bağlayıcı Noktasını Ayarla**

Ayarlama noktalarına sahip bağlayıcılar, bunları [GeometryShape::getAdjustments](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometryshape/#getadjustments) aracılığıyla ortaya çıkarır. Her bir [AdjustValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/) öğesini inceleyin ve [AdjustValue::setRawValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/setrawvalue/) ile değiştirmeden önce [AdjustValue::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/#gettype) değerini kontrol edin. Ön ayarlı şekil ayarlarını tanımlama konusunda genel kurallar [Shape Manipulation](/slides/tr/php-java/shape-manipulations/) içinde açıklanmıştır.

Bağlayıcı ayarlarının sayısı, sırası, anlamı ve geçerli değer aralığı bağlayıcı ön ayarına bağlıdır. Ayar türü yalnızca okunabilir iken, ayar değeri yazılabilir. Aynı anlamsal türe sahip birden fazla ayar içeren bağlayıcılarda ek tanımlama sağlayan yalnızca okunabilir [AdjustValue::getName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/getname/) yöntemidir.

### **Bir Engel Çevresinde Rota**

Aşağıdaki yerleşimde, iki şekil arasındaki `BentConnector5` bağlayıcısı üçüncü bir şekilden geçer:

![connector-obstruction](connector-obstruction.png)

Bu kod, engelli bağlayıcıyı oluşturur:

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

Dikey bükülme hareket ettirildiğinde rota değişir ve bağlayıcı engeli atlar:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Toplu dizin `1` in her zaman dikey bükülmeyi temsil ettiğini varsaymak yerine, bu örnek `ConnectorBendPositionY` öğesini arar ve yalnızca beklenen anlamsal tür mevcut olduğunda değiştirir:

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

`BentConnector5` iki `ConnectorBendPositionX` ayarı ve bir `ConnectorBendPositionY` ayarı içerir. İhtiyacınız olan tür birden fazla kez bulunuyorsa, seçim yapmadan önce `getName` ve o ön ayarın bilinen geometrisini inceleyin. Bir ayar `ShapeAdjustmentType::Custom` rapor ediyorsa, anlamını ve aralığını ön ayara özgü olarak değerlendirin ve bu sözleşme bilinene kadar değiştirmeyin.

## **Ayarlama Değerlerini Bağlayıcı Geometrisine Bağlamak**

Bükülmüş bağlayıcılar için ayar değerleri, bireysel segmentlerin konumlarını tahmin etmekte kullanılabilir. Bu hesaplamalar bağlayıcı ön ayarına özgüdür:

- `BentConnector4` normalde bir `ConnectorBendPositionX` ve bir `ConnectorBendPositionY` ayarı ortaya çıkar.
- Bu bükülme konumları için, `getRawValue` tarafından döndürülen değeri `100000` ile bölmek, aşağıdaki örneklerde kullanılan bağlayıcı çerçevesi genişliğinin ya da yüksekliğinin kesirini verir.
- Bir bağlayıcı çerçevesi döndürülebilir veya çevrilebilir, bu yüzden çerçeve koordinatları slayt koordinatlarıyla karşılaştırılmadan önce dönüştürülmelidir.

Aşağıdaki örnekler, önce `getType` kullanarak ayarları tanımlar. Toplu dizinleri taşınabilir tanımlayıcılar olarak ele almazlar.

### **Döndürülmemiş Bağlayıcı**

İlk yerleşimde, bir `BentConnector4` ile bağlanmış iki metin şekli bulunur:

![connector-shape-complex](connector-shape-complex.png)

Bu örnek bağlayıcıyı inceler ve yatay ve dikey bükülme ayarlarını alır:

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

Her iki bükülmeyi de değiştirmek için, her beklenen türü bulun ve her ikisi bulunduğunda değerleri değiştirin:

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

Sonuç, yatay ve dikey segmentleri hareket etmiş bir bağlayıcıdır:

![connector-adjusted-1](connector-adjusted-1.png)

Anlamsal türler belirlendikten sonra, değerleri bağlayıcı-çerçeve koordinatlarına dönüştürebilirsiniz. Bu örnek, iki bükülme ayarı tarafından kontrol edilen dikey segmentin üzerine ince bir dikdörtgen çizer:

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

Yardımcı şekil, hesaplanan segmenti işaretler:

![connector-adjusted-2](connector-adjusted-2.png)

### **Döndürülmüş veya Çevrilmiş Bağlayıcı**

Aynı bağlayıcı geometrisi dikey olarak yönlendirildiğinde, [Shape::getFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeframe/getfliph/) ve [ShapeFrame::getFlipV](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeframe/getflipv/) değerleri, bağlayıcı-çerçeve koordinatlarından slayt koordinatlarına dönüşümü etkiler.

Bu örnek, dikey yönlendirilmiş bağlayıcıyı oluşturur ve ayarlar:

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

Ayarlanmış bağlayıcı şekiller arasında dikey olarak görünür:

![connector-adjusted-3](connector-adjusted-3.png)

Keyfi bir `alpha` döndürme açısı için, bir bağlayıcı-çerçeve noktası `(x, y)` çerçeve merkezi `(x0, y0)` etrafında şu şekilde döndürülür:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Aşağıdaki kod, bu örnekte kullanılan 90 derece yönelimi işler ve ilgili bağlayıcı segmenti üzerine kırmızı bir rehber çizer:

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

Kırmızı rehber, koordinat dönüşümünden sonraki hesaplanan segmenti işaretler:

![connector-adjusted-4](connector-adjusted-4.png)

Bu formüller, örneklerde kullanılan ön ayarları açıklar; evrensel bir bağlayıcı modeli değildir. Aynı hesabı farklı bir ön ayara uygulamadan önce ayar türlerini, çerçeve yönelimini ve değer aralıklarını doğrulayın.

## **Bağlayıcı Yön Açısını Bulma**

Düz bir bağlayıcının yönü, genişliği ve yüksekliği kullanılarak, yatay ve dikey çevirmeler uygulanarak hesaplanabilir. Aşağıdaki örnek, slayt koordinatlarında pozitif yatay eksenden saat yönünde açıyı rapor eder:

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

## **SSS**

**Bir bağlayıcının bir şekle bağlanıp bağlanamayacağını nasıl anlayabilirim?**

[Shape::getConnectionSiteCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getconnectionsitecount/) değerini kontrol edin. Pozitif bir sayı, şeklin bağlantı noktaları sunduğu anlamına gelir. Bağlayıcı uçlarından birine atamadan önce seçilen site dizinini doğrulayın.

**Bir bağlayıcı ayarını koleksiyon indeksine göre tanımlayabilir miyim?**

Bir indeks yalnızca bilinen bir bağlayıcı ön ayarı ve koleksiyon düzeni için anlamlıdır. Bir değeri değiştirmeden önce [AdjustValue::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/#gettype) kontrol edin ve aynı anlamsal tür birden fazla kez ortaya çıktığında ek bilgi olarak [AdjustValue::getName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/getname/) kullanın.

**Bağlı bir şekil silindiğinde ne olur?**

İlgili bağlayıcı ucu ayrılır. Bağlayıcı slaytta kalır ve silinebilir, serbest bir çizgi olarak konumlandırılabilir veya başka bir şekle bağlanabilir.

**Bir slayt kopyalandığında bağlayıcı bağlamaları korunur mu?**

Bağlamalar, bağlı şekiller slaytla birlikte kopyalandığında genellikle korunur. Bir bağlayıcı, hedef şekillerinden biri olmadan kopyalanırsa, etkilenen uç tekrar bağlanmalıdır.