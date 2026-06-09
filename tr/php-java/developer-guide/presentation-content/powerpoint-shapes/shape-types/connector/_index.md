---
title: PHP Kullanarak Sunularda Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/php-java/connector/
keywords:
- bağlayıcı
- bağlayıcı türü
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- şekilleri bağla
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP uygulamalarının PowerPoint slaytlarında çizim, bağlama ve otomatik yönlendirme yapabilmesini sağlar — düz, dirsek ve eğimli bağlayıcılar üzerinde tam kontrol elde edin."
---
## **Giriş**

PowerPoint bağlayıcısı, iki şekli birbirine bağlayan veya ilişkilendiren özel bir çizgidir ve şekiller taşındığında ya da bir slaytta yeniden konumlandırıldığında bile şekillere bağlı kalır. 

Bağlayıcılar genellikle *bağlantı noktalarına* (yeşil noktalar) bağlanır; bu noktalar varsayılan olarak tüm şekillerde bulunur. Bağlantı noktaları, imleç onlara yaklaştığında görünür.

*Ayarlama noktaları* (turuncu noktalar), yalnızca belirli bağlayıcılarda bulunur ve bağlayıcıların konum ve şekillerini değiştirmek için kullanılır.

## **Bağlayıcı Türleri**

PowerPoint'te düz, dirsek (köşeli) ve eğimli bağlayıcıları kullanabilirsiniz. 

Aspose.Slides bu bağlayıcıları sağlar:

| Bağlayıcı | Görsel | Ayarlama noktası sayısı |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Şekilleri Bağlayıcılarla Bağlama**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
1. İndeks aracılığıyla bir slaydın referansını alın.  
1. `Shapes` nesnesi tarafından sunulan `addAutoShape` yöntemini kullanarak slayta iki [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/AutoShape) ekleyin.  
1. `Shapes` nesnesi tarafından sunulan `addConnector` yöntemini kullanarak bağlayıcı türünü belirterek bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyı kullanarak bağlayın.  
1. `reroute` yöntemini çağırarak en kısa bağlantı yolunu uygulayın.  
1. Sunumu kaydedin.  

Bu PHP kodu, iki şekil (bir elips ve bir dikdörtgen) arasında bir bağlayıcı (bükülmüş bağlayıcı) eklemenizi gösterir:

```php
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # Belirli bir slayd için şekil koleksiyonuna erişir
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Elips otomatik şekli ekler
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Dikdörtgen otomatik şekli ekler
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Slayt şekil koleksiyonuna bir bağlayıcı şekli ekler
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Şekilleri bağlayıcıyı kullanarak bağlar
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Şekiller arasındaki otomatik en kısa yolu ayarlayan reroute metodunu çağırır
    $connector->reroute();
    # Sunumu kaydeder
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute` yöntemi bir bağlayıcıyı yeniden yönlendirir ve şekiller arasındaki en kısa yolu almasını zorlar. Hedefine ulaşmak için yöntem, `setStartShapeConnectionSiteIndex` ve `setEndShapeConnectionSiteIndex` noktalarını değiştirebilir. 

{{% /alert %}} 

## **Bir Bağlantı Noktası Belirtme**

Bir bağlayıcının iki şekli belirli noktalar üzerinden bağlamasını istiyorsanız, tercih ettiğiniz bağlantı noktalarını şu şekilde belirtmeniz gerekir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
1. İndeks aracılığıyla bir slaydın referansını alın.  
1. `Shapes` nesnesi tarafından sunulan `addAutoShape` yöntemini kullanarak slayta iki [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/AutoShape) ekleyin.  
1. `Shapes` nesnesi tarafından sunulan `addConnector` yöntemini kullanarak bağlayıcı türünü belirterek bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyı kullanarak bağlayın.  
1. Şekillerde tercih ettiğiniz bağlantı noktalarını ayarlayın.  
1. Sunumu kaydedin.  

Bu PHP kodu, tercih edilen bir bağlantı noktasının belirtildiği bir işlemi gösterir:

```php
  # PPTX dosyasını temsil eden bir sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # Belirli bir slayt için şekil koleksiyonuna erişir
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Elips otomatik şekli ekler
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Dikdörtgen otomatik şekli ekler
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Slaydın şekil koleksiyonuna bir bağlayıcı şekli ekler
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Şekilleri bağlayıcıyı kullanarak bağlar
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Elips şekli üzerinde tercih edilen bağlantı noktası indeksini ayarlar
    $wantedIndex = 6;
    # Tercih edilen indeksin maksimum site indeks sayısından küçük olup olmadığını kontrol eder
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Elips otomatik şekli üzerinde tercih edilen bağlantı noktasını ayarlar
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Sunumu kaydeder
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Bağlayıcı Noktasını Ayarlama**

Mevcut bir bağlayıcıyı ayarlama noktaları aracılığıyla ayarlayabilirsiniz. Yalnızca ayarlama noktalarına sahip bağlayıcılar bu şekilde değiştirilebilir. **[Bağlayıcı Türleri](/slides/tr/php-java/connector/#types-of-connectors)** altındaki tabloya bakın.

### **Basit Durum**

İki şekil (A ve B) arasındaki bir bağlayıcının üçüncü bir şekil (C) üzerinden geçtiği bir durumu düşünün:

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Üçüncü şekilden kaçınmak veya geçmek için bağlayıcıyı dikey çizgisini sola kaydırarak şu şekilde ayarlayabiliriz:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Karmaşık Durumlar** 

Daha karmaşık ayarlamalar yapmak için aşağıdaki hususları dikkate almanız gerekir:

* Bir bağlayıcının ayarlanabilir noktası, konumunu hesaplayan ve belirleyen bir formülle güçlü bir şekilde bağlantılıdır. Bu yüzden noktanın konumundaki değişiklikler bağlayıcının şekilini değiştirebilir.  
* Bir bağlayıcının ayarlama noktaları bir dizi içinde katı bir sırayla tanımlanır. Ayarlama noktaları, bağlayıcının başlangıç noktasından sonuna doğru numaralandırılır.  
* Ayarlama noktası değerleri, bir bağlayıcı şeklinin genişlik/yükseklik oranının yüzdesini yansıtır.  
  * Şekil, bağlayıcının başlangıç ve bitiş noktalarının 1000 ile çarpılmasıyla sınırlanır.  
  * Birinci nokta, ikinci nokta ve üçüncü nokta sırasıyla genişlik yüzdesini, yükseklik yüzdesini ve tekrar genişlik yüzdesini tanımlar.  
* Bir bağlayıcının ayarlama noktalarının koordinatlarını belirleyen hesaplamalar için bağlayıcının dönüşünü ve yansıtmasını göz önünde bulundurmanız gerekir. **Not**: **[Bağlayıcı Türleri](/slides/tr/php-java/connector/#types-of-connectors)** altında gösterilen tüm bağlayıcıların dönüş açısı 0'dır.

#### **Durum 1**

İki metin çerçevesi nesnesinin bir bağlayıcı aracılığıyla birbirine bağlandığı bir durumu düşünün:

![connector-shape-complex](connector-shape-complex.png)

```php
  # PPTX dosyasını temsil eden bir sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # Sunumdaki ilk slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # Bağlayıcı aracılığıyla birleştirilecek şekilleri ekler
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Bir bağlayıcı ekler
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Bağlayıcının yönünü belirler
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Bağlayıcının rengini belirler
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Bağlayıcı çizgisinin kalınlığını belirler
    $connector->getLineFormat()->setWidth(3);
    # Şekilleri bağlayıcı ile birbirine bağlar
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Bağlayıcı için ayarlama noktalarını alır
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Ayarlama**

Bağlayıcının ayarlama noktası değerlerini, ilgili genişlik ve yükseklik yüzdesini sırasıyla %20 ve %200 artırarak değiştirebiliriz:

```php
  # Ayarlama noktalarının değerlerini değiştirir
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Sonuç:

![connector-adjusted-1](connector-adjusted-1.png)

Bağlayıcının koordinatlarını ve bireysel parçalarının şeklini belirlememizi sağlayan bir modeli tanımlamak için, connector.getAdjustments().get_Item(0) noktasındaki yatay bileşene karşılık gelen bir şekil oluşturalım:

```php
  # Bağlayıcının dikey bileşenini çizer
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Sonuç:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Durum 2**

**Durum 1**'de, temel prensipleri kullanarak basit bir bağlayıcı ayarlama işlemini gösterdik. Normal durumlarda, bağlayıcının dönüşünü ve görüntülenmesini (connector.getRotation(), connector.getFrame().getFlipH() ve connector.getFrame().getFlipV() tarafından ayarlanır) göz önünde bulundurmanız gerekir. Şimdi süreci göstereceğiz.

İlk olarak, slayta yeni bir metin çerçevesi nesnesi (**To 1**) ekleyelim (bağlantı amacıyla) ve onu zaten oluşturduğumuz nesnelere bağlayan yeni (yeşil) bir bağlayıcı oluşturalım.

```php
  # Yeni bir bağlama nesnesi oluşturur
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Yeni bir bağlayıcı oluşturur
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Yeni oluşturulan bağlayıcıyı kullanarak nesneleri bağlar
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Bağlayıcının ayarlama noktalarını alır
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Ayarlama noktalarının değerlerini değiştirir
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Sonuç:

![connector-adjusted-3](connector-adjusted-3.png)

İkinci olarak, yeni bağlayıcının ayarlama noktası connector.getAdjustments().get_Item(0) üzerinden geçen bağlayıcının yatay bileşenine karşılık gelen bir şekil oluşturalım. connector.getRotation(), connector.getFrame().getFlipH() ve connector.getFrame().getFlipV() için bağlayıcı verilerindeki değerleri kullanacağız ve verilen bir x0 noktasına göre dönüş koordinat dönüşüm formülünü uygulayacağız:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Bizim durumumuzda nesnenin dönüş açısı 90 derecedir ve bağlayıcı dikey olarak görüntülenir, bu yüzden ilgili kod şu şekildedir:

```php
  # Bağlayıcı koordinatlarını kaydeder
  $x = $connector->getX();
  $y = $connector->getY();
  # Bağlayıcı koordinatlarını gerektiğinde düzeltir
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Ayar nokta değerini koordinat olarak alır
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Koordinatları dönüştürür; çünkü Sin(90) = 1 ve Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # İkinci ayar nokta değerini kullanarak yatay bileşenin genişliğini belirler
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Sonuç:

![connector-adjusted-4](connector-adjusted-4.png)

Basit ayarlamaları ve karmaşık ayarlama noktalarını (dönüş açısına sahip ayarlama noktaları) içeren hesaplamaları gösterdik. Edinilen bilgiyi kullanarak, belirli slayt koordinatlarına dayalı bir `GraphicsPath` nesnesi elde etmek veya hatta bir bağlayıcının ayarlama noktası değerlerini ayarlamak için kendi modelinizi (veya kodunuzu) geliştirebilirsiniz.

## **Bağlayıcı Çizgilerinin Açısını Bulma**

1. Sınıfın bir örneğini oluşturun.  
1. İndeks aracılığıyla bir slaydın referansını alın.  
1. Bağlayıcı çizgi şekline erişin.  
1. Çizgi genişliği, yüksekliği, şekil çerçevesi yüksekliği ve şekil çerçevesi genişliğini kullanarak açıyı hesaplayın.  

Bu PHP kodu, bir bağlayıcı çizgi şeklinin açısını hesapladığımız bir işlemi gösterir:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Bir bağlayıcının belirli bir şekle "yapışıp yapışmayacağını" nasıl anlayabilirim?**

Şeklin [bağlantı noktalarını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getconnectionsitecount/) ortaya koyup koymadığını kontrol edin. Hiçbiri yoksa veya sayı sıfırsa, yapışma mevcut değildir; bu durumda serbest uç noktalarını kullanıp manuel olarak konumlandırın. Bağlamadan önce nokta sayısını kontrol etmek mantıklıdır.

**Bağlı şekillerden birini sildiğimde bağlayıcıya ne olur?**

Uçları ayrılır; bağlayıcı slaytta serbest başlangıç/bitiş noktalarına sahip sıradan bir çizgi olarak kalır. Ya silebilir ya da bağlantıları yeniden atayabilir ve gerekirse [reroute](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/reroute/) yöntemini kullanabilirsiniz.

**Bir slaytı başka bir sunuma kopyaladığınızda bağlayıcı bağları korunur mu?**

Genellikle evet, hedef şekiller de kopyalandığında. Slayt, bağlı şekiller olmadan başka bir dosyaya eklenirse, uçlar serbest kalır ve bunları yeniden bağlamanız gerekir.