---
title: Sunumlarda Bağlayıcıları JavaScript Kullanarak Yönetme
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
- şekilleri bağla
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript uygulamalarının PowerPoint slaytlarında çizim, bağlama ve otomatik yönlendirme yaparak düz, dirsek ve eğimli bağlayıcılar üzerinde tam kontrol sağlamasını sağlar."
---
## **Giriş**

PowerPoint bağlayıcısı, iki şekli birbirine bağlayan özel bir çizgidir ve bir slaytta hareket ettirildiklerinde veya konumları değiştirildiğinde şekillere bağlı kalır. 

Bağlayıcılar genellikle *bağlantı noktalarına* (yeşil noktalar) bağlanır; bu noktalar tüm şekillerde varsayılan olarak bulunur. Bağlantı noktaları, imleç onlara yaklaştığında ortaya çıkar.

*Ayarlama noktaları* (turuncu noktalar), yalnızca belirli bağlayıcılarda bulunur ve bağlayıcıların konum ve şekillerini değiştirmek için kullanılır.

## **Bağlayıcı Türleri**

PowerPoint'te düz, dirsek (köşeli) ve eğimli bağlayıcıları kullanabilirsiniz. 

Aspose.Slides aşağıdaki bağlayıcıları sağlar:

| Bağlayıcı | Resim | Ayarlama nokta sayısı |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Şekilleri Bağlayıcılarla Bağlayın**

1. [Presentation](https://apireference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın referansını indeksine göre alın.  
1. `Shapes` nesnesi tarafından sunulan `addAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) ekleyin.  
1. Bağlayıcı tipini tanımlayarak `Shapes` nesnesi tarafından sunulan `addConnector` yöntemiyle bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla bağlayın.  
1. En kısa bağlantı yolunu uygulamak için `reroute` metodunu çağırın.  
1. Sunumu kaydedin.  

Bu JavaScript kodu, iki şekil (bir elips ve bir dikdörtgen) arasında bir bağlayıcı (bükülmüş bağlayıcı) eklemenizi gösterir:

```javascript
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // Belirli bir slayt için şekil koleksiyonuna erişir
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Bir Elips otomatik şekli ekler
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Bir Dikdörtgen otomatik şekli ekler
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Slayt şekil koleksiyonuna bir bağlayıcı şekli ekler
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Şekilleri bağlayıcıyı kullanarak bağlar
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Şekiller arasındaki otomatik en kısa yolu ayarlayan reroute yöntemini çağırır
    connector.reroute();
    // Sunumu kaydeder
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.reroute` yöntemi bir bağlayıcıyı yeniden yönlendirir ve şekiller arasındaki olabilecek en kısa yolu almasını zorlar. Bu amacı gerçekleştirmek için yöntem `setStartShapeConnectionSiteIndex` ve `setEndShapeConnectionSiteIndex` noktalarını değiştirebilir. 

{{% /alert %}} 

## **Bağlantı Noktasını Belirtin**

Bağlayıcının iki şekli belirli noktalardan bağlamasını istiyorsanız, tercih ettiğiniz bağlantı noktalarını şu şekilde belirtmelisiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın referansını indeksine göre alın.  
1. `Shapes` nesnesi tarafından sunulan `addAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) ekleyin.  
1. Bağlayıcı tipini tanımlayarak `Shapes` nesnesi tarafından sunulan `addConnector` yöntemiyle bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla bağlayın.  
1. Şekillerde tercih ettiğiniz bağlantı noktalarını ayarlayın.  
1. Sunumu kaydedin.  

Bu JavaScript kodu, tercih edilen bir bağlantı noktasının nasıl belirtileceğini gösterir:

```javascript
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // Belirli bir slayt için şekil koleksiyonuna erişir
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Bir Elips otomatik şekli ekler
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Bir Dikdörtgen otomatik şekli ekler
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Slaytın şekil koleksiyonuna bir bağlayıcı şekli ekler
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Bağlayıcıyı kullanarak şekilleri bağlar
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Elips şekli için tercih edilen bağlantı nokta indeksini ayarlar
    var wantedIndex = 6;
    // Tercih edilen indeksin maksimum site indeks sayısından küçük olup olmadığını kontrol eder
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Elips otomatik şekli üzerinde tercih edilen bağlantı noktasını ayarlar
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Sunumu kaydeder
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bağlayıcı Noktasını Ayarla**

Varolan bir bağlayıcıyı ayarlama noktaları aracılığıyla ayarlayabilirsiniz. Yalnızca ayarlama noktalarına sahip bağlayıcılar bu şekilde değiştirilebilir. **[Bağlayıcı Türleri](/slides/tr/nodejs-java/connector/#types-of-connectors)** altındaki tabloya bakın.

### **Basit Durum**

İki şekil (A ve B) arasındaki bağlayıcının üçüncü bir şekil (C) üzerinden geçtiği bir durumu düşünün:

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Üçüncü şekli engellemek veya etrafından geçmek için bağlayıcıyı aşağıdaki gibi dikey çizgisini sola kaydırarak ayarlayabiliriz:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Karmaşık Durumlar** 

Daha karmaşık ayarlamalar yapmak için aşağıdaki hususları dikkate almanız gerekir:

* Bir bağlayıcının ayarlanabilir noktası, konumunu hesaplayan ve belirleyen bir formülle güçlü bir şekilde ilişkilidir. Bu nedenle noktanın konumundaki değişiklikler bağlayıcının şeklini etkileyebilir.  
* Bağlayıcının ayarlama noktaları, bir dizi içinde kesin bir sırayla tanımlanır. Ayarlama noktaları, bağlayıcının başlangıç noktasından bitiş noktasına doğru numaralandırılır.  
* Ayarlama noktası değerleri, bağlayıcı şeklinin genişlik/yükseklik yüzdesini yansıtır.  
  * Şekil, bağlayıcının başlangıç ve bitiş noktaları ile 1000 ile çarpılarak sınırlanır.  
  * İlk nokta, ikinci nokta ve üçüncü nokta sırasıyla genişlik, yükseklik ve tekrar genişlik yüzdesini tanımlar.  
* Bağlayıcının ayarlama noktalarının koordinatlarını belirleyen hesaplamalarda bağlayıcının dönüşü ve yansıtılması göz önünde bulundurulmalıdır. **Not**: **[Bağlayıcı Türleri](/slides/tr/nodejs-java/connector/#types-of-connectors)** altında gösterilen tüm bağlayıcıların dönüş açısı 0'dır.

#### **Durum 1**

İki metin çerçevesi nesnesinin bir bağlayıcı aracılığıyla birbirine bağlandığı bir durumu düşünün:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // Sunumdaki ilk slaytı alır
    var sld = pres.getSlides().get_Item(0);
    // Bağlayıcı aracılığıyla birleştirilecek şekilleri ekler
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Bir bağlayıcı ekler
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Bağlayıcının yönünü belirler
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Bağlayıcının rengini belirler
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Bağlayıcı çizgisinin kalınlığını belirler
    connector.getLineFormat().setWidth(3);
    // Şekilleri bağlayıcı ile birbirine bağlar
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Bağlayıcı için ayarlama noktalarını alır
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Ayarlama**

Bağlayıcının ayarlama noktası değerlerini, ilgili genişlik ve yükseklik yüzdesini sırasıyla %20 ve %200 artırarak değiştirebiliriz:

```javascript
// Ayarlama noktalarının değerlerini değiştirir
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Sonuç:

![connector-adjusted-1](connector-adjusted-1.png)

Bağlayıcının bireysel parçalarının koordinatlarını ve şeklini belirleyen bir model tanımlamak için, `connector.getAdjustments().get_Item(0)` noktasındaki yatay bileşene karşılık gelen bir şekil oluşturalım:

```javascript
// Bağlayıcının dikey bileşenini çizer
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Sonuç:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Durum 2**

**Durum 1**'de temel prensipleri kullanarak basit bir bağlayıcı ayarlama işlemi gösterdik. Normal durumlarda, bağlayıcının dönüşü ve görüntüsü (`connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()`) dikkate alınmalıdır. Şimdi süreci gösterelim.

İlk olarak, slayda yeni bir metin çerçevesi nesnesi (**To 1**) ekleyelim (bağlantı amacıyla) ve onu zaten oluşturduğumuz nesnelere bağlayan yeni bir (yeşil) bağlayıcı oluşturalım.

```javascript
// Yeni bir bağlama nesnesi oluşturur
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Yeni bir bağlayıcı oluşturur
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Yeni oluşturulan bağlayıcıyı kullanarak nesneleri bağlar
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Bağlayıcının ayarlama noktalarını alır
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ayarlama noktalarının değerlerini değiştirir
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Sonuç:

![connector-adjusted-3](connector-adjusted-3.png)

İkinci olarak, yeni bağlayıcının ayarlama noktası `connector.getAdjustments().get_Item(0)` üzerinden geçen yatay bileşene karşılık gelen bir şekil oluşturalım. Bağlayıcı verilerinden `connector.getRotation()`, `connector.getFrame().getFlipH()`, `connector.getFrame().getFlipV()` değerlerini kullanacağız ve verilen bir nokta x0 etrafında dönüş için popüler koordinat dönüşüm formülünü uygulayacağız:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Bizim durumumuzda nesnenin dönüş açısı 90 derecedir ve bağlayıcı dikey olarak görüntülenir, bu yüzden ilgili kod şu şekildedir:

```javascript
// Bağlayıcı koordinatlarını kaydeder
x = connector.getX();
y = connector.getY();
// Bağlayıcı koordinatlarını gerektiğinde düzeltir
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Ayarlama noktası değerini koordinat olarak alır
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Koordinatları dönüştürür; çünkü Sin(90) = 1 ve Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// İkinci ayarlama noktası değerini kullanarak yatay bileşenin genişliğini belirler
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Sonuç:

![connector-adjusted-4](connector-adjusted-4.png)

Basit ayarlamalar ve dönüş açılarına sahip karmaşık ayarlama noktaları içeren hesaplamaları gösterdik. Edinilen bilgiyle, bir `GraphicsPath` nesnesi elde etmek ya da belirli slayt koordinatlarına dayalı olarak bir bağlayıcının ayarlama noktası değerlerini ayarlamak için kendi modelinizi geliştirebilir (veya kod yazabilirsiniz).

## **Bağlayıcı Çizgilerinin Açısını Bul**

1. Sınıfın bir örneğini oluşturun.  
1. Slaytın referansını indeksine göre alın.  
1. Bağlayıcı çizgi şekline erişin.  
1. Açıyı hesaplamak için çizgi genişliği, yüksekliği, şekil çerçeve yüksekliği ve şekil çerçeve genişliğini kullanın.  

Bu JavaScript kodu, bir bağlayıcı çizgi şeklinin açısını nasıl hesaplayacağımızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **SSS**

**Bir bağlayıcının belirli bir şekle “yapıştırılıp” yapıştırılamadığını nasıl anlayabilirim?**

Şeklin [bağlantı noktalarını](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getconnectionsitecount/) ortaya koyduğunu kontrol edin. Hiç bağlantı noktası yoksa veya sayısı sıfırsa, yapıştırma mevcut değildir; bu durumda serbest uçlar kullanıp konumlarını manuel olarak ayarlayın. Bağlantı noktasını eklemeden önce sayıyı kontrol etmek mantıklıdır.

**Bağlantılı şekillerden birini silersem bağlayıcı ne olur?**

Uçları ayrılır; bağlayıcı slaytta serbest başlangıç/bitişe sahip normal bir çizgi olarak kalır. Ya silebilir ya da bağlantıları yeniden atayabilir ve gerekirse [reroute](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/reroute/) yapabilirsiniz.

**Bir slaytı başka bir sunuma kopyaladığımda bağlayıcı bağlamaları korunur mu?**

Genel olarak evet, hedef şekiller de kopyalanırsa korunur. Slayt, bağlı şekiller olmadan başka bir dosyaya eklenirse uçlar serbest olur ve yeniden eklemeniz gerekir.