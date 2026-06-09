---
title: Android'de Sunumlarda Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/androidjava/connector/
keywords:
- bağlayıcı
- bağlayıcı türü
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- şekilleri bağla
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Java uygulamalarını Android'de PowerPoint slaytlarında çizim yapmaya, şekilleri bağlamaya ve çizgileri otomatik yönlendirmeye güçlendirin—düz, dirsek ve eğri bağlayıcılar üzerinde tam kontrol sağlayın."
---
## **Giriş**

PowerPoint bağlayıcısı, iki şekli birbiriyle bağlayan veya ilişkilendiren özel bir çizgidir ve bir slayt üzerindeki şekiller taşındığında veya yeniden konumlandırıldığında bile şekillere tutunur. 

Bağlayıcılar genellikle *bağlantı noktalarına* (yeşil noktalara) bağlanır; bu noktalar varsayılan olarak tüm şekillerde bulunur. Bağlantı noktaları, imleç onlara yaklaştığında ortaya çıkar.

*Ayarlama noktaları* (turuncu noktalar), yalnızca belirli bağlayıcılarda bulunur ve bağlayıcıların konum ve şekillerini değiştirmek için kullanılır.

## **Bağlayıcı Türleri**

PowerPoint'te düz, dirsek (köşeli) ve eğri bağlayıcıları kullanabilirsiniz. 

Aspose.Slides aşağıdaki bağlayıcıları sağlar:

| Bağlayıcı | Image | Ayarlama noktası sayısı |
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

## **Şekilleri Bağlayıcılarla Bağlama**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. `Shapes` nesnesinin sunduğu `addAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AutoShape) ekleyin.  
1. `Shapes` nesnesinin sunduğu `addConnector` yöntemiyle bağlayıcı tipini tanımlayarak bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyı kullanarak bağlayın.  
1. En kısa bağlantı yolunu uygulamak için `reroute` metodunu çağırın.  
1. Sunumu kaydedin.  

Bu Java kodu, iki şekil (bir elips ve dikdörtgen) arasında bir bağlayıcı (bükülmüş bağlayıcı) nasıl ekleyeceğinizi gösterir:

```Java
// PPTX dosyasını temsil eden bir sunum sınıfını örnekleyerek oluşturur
Presentation pres = new Presentation();
try {
    // Belirli bir slayt için şekil koleksiyonuna erişir
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Bir Elips otomatik şekli ekler
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Bir Dikdörtgen otomatik şekli ekler
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Bağlayıcı şekli slayt şekil koleksiyonuna ekler
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Şekilleri bağlayıcı kullanarak bağlar
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Şekiller arasında otomatik en kısa yolu ayarlayan reroute metodunu çağırır
    connector.reroute();
    
    // Sunumu kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOT"  color="warning"   %}} 

`Connector.reroute` metodu bir bağlayıcıyı yeniden yönlendirir ve şekiller arasındaki mümkün olan en kısa yolu almasını zorlar. Bu amacına ulaşmak için, metod `setStartShapeConnectionSiteIndex` ve `setEndShapeConnectionSiteIndex` noktalarını değiştirebilir. 

{{% /alert %}} 

## **Bağlantı Noktası Belirleme**

İki şekli belirli noktalarla bağlamak istiyorsanız, tercih ettiğiniz bağlantı noktalarını şu şekilde belirtmelisiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfından bir örnek oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. `Shapes` nesnesinin sunduğu `addAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AutoShape) ekleyin.  
1. `Shapes` nesnesinin sunduğu `addConnector` yöntemiyle bağlayıcı tipini tanımlayarak bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyı kullanarak bağlayın.  
1. Şekillerde tercih ettiğiniz bağlantı noktalarını ayarlayın.  
1. Sunumu kaydedin.  

Bu Java kodu, tercih edilen bir bağlantı noktasının belirtildiği bir işlemi gösterir:

```java
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
Presentation pres = new Presentation();
try {
    // Belirli bir slayt için şekil koleksiyonuna erişir
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Bir Elips otomatik şekli ekler
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Bir Dikdörtgen otomatik şekli ekler
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Bağlayıcı şekli slaytın şekil koleksiyonuna ekler
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Şekilleri bağlayıcı kullanarak bağlar
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Elips şekli üzerinde tercih edilen bağlantı noktası indeksini ayarlar
    int wantedIndex = 6;

    // Tercih edilen indeksin maksimum site indeks sayısından küçük olup olmadığını kontrol eder
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Tercih edilen bağlantı noktasını Elips otomatik şekline ayarlar
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Sunumu kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bağlayıcı Noktasını Ayarlama**

Mevcut bir bağlayıcıyı ayarlama noktaları üzerinden ayarlayabilirsiniz. Yalnızca ayarlama noktalarına sahip bağlayıcılar bu şekilde değiştirilebilir. **[Bağlayıcı Türleri](/slides/tr/androidjava/connector/#types-of-connectors)** altındaki tabloya bakın.

### **Basit Durum**

İki şekil (A ve B) arasında bir bağlayıcı üçüncü bir şekil (C) üzerinden geçtiği bir durumu düşünelim:

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Üçüncü şekli önlemek veya etrafından dolaşmak için bağlayıcıyı, dikey çizgisini sola hareket ettirerek şu şekilde ayarlayabiliriz:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Karmaşık Durumlar** 

Daha karmaşık ayarlamaları gerçekleştirmek için aşağıdaki hususları göz önünde bulundurmalısınız:

* Bir bağlayıcının ayarlanabilir noktası, konumunu hesaplayan ve belirleyen bir formülle güçlü bir şekilde bağlantılıdır. Bu yüzden noktanın konumundaki değişiklikler bağlayıcının şekline etki edebilir.  
* Bir bağlayıcının ayarlama noktaları bir dizi içinde belirli bir sırayla tanımlanır. Ayarlama noktaları, bağlayıcının başlangıç noktasından son noktasına doğru numaralanır.  
* Ayarlama noktası değerleri, bir bağlayıcı şeklinin genişlik/yükseklik oranını yansıtır.  
  * Şekil, bağlayıcının başlangıç ve bitiş noktalarının 1000 ile çarpılmasıyla sınırlanır.  
  * İlk nokta, ikinci nokta ve üçüncü nokta sırasıyla genişlik, yükseklik ve tekrar genişlik yüzdesini tanımlar.  
* Bir bağlayıcının ayarlama noktalarının koordinatlarını belirleyen hesaplamalarda, bağlayıcının dönüşünü ve yansımasını dikkate almanız gerekir. **Not**: **[Bağlayıcı Türleri](/slides/tr/androidjava/connector/#types-of-connectors)** altında gösterilen tüm bağlayıcıların dönüş açısı 0'dır.

#### **Durum 1**

İki metin çerçevesi nesnesinin bir bağlayıcı aracılığıyla birbirine bağlandığı bir durumu düşünelim:

![connector-shape-complex](connector-shape-complex.png)

```java
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
Presentation pres = new Presentation();
try {
    // Sunumdaki ilk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);
    // Bağlayıcı aracılığıyla birleştirilecek şekilleri ekler
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Bir bağlayıcı ekler
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Bağlayıcının yönünü belirtir
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Bağlayıcının rengini belirtir
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Bağlayıcı çizgisinin kalınlığını belirtir
    connector.getLineFormat().setWidth(3);
    
    // Şekilleri bağlayıcı ile birbirine bağlar
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Bağlayıcı için ayarlama noktalarını alır
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Ayarlama**

Bağlayıcının ayarlama noktası değerlerini, ilgili genişlik ve yükseklik yüzdelerini sırasıyla %20 ve %200 artırarak değiştirebiliriz:

```java
// Ayarlama noktalarının değerlerini değiştirir
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Sonuç:

![connector-adjusted-1](connector-adjusted-1.png)

Bağlayıcının koordinatlarını ve bireysel parçalarının şekillerini belirlememizi sağlayacak bir model tanımlamak için, connector.getAdjustments().get_Item(0) noktasındaki yatay bileşene karşılık gelen bir şekil oluşturalım:

```java
// Bağlayıcının dikey bileşenini çizer
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Sonuç:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Durum 2**

**Durum 1**'de temel prensipleri kullanarak basit bir bağlayıcı ayarlama işlemi gösterdik. Normal durumlarda, bağlayıcının dönüşünü ve görünümünü (connector.getRotation(), connector.getFrame().getFlipH() ve connector.getFrame().getFlipV() tarafından ayarlanır) dikkate almanız gerekir. Şimdi süreci göstereceğiz.

İlk olarak, slayta yeni bir metin çerçevesi nesnesi (**To 1**) (bağlantı amaçlı) ekleyelim ve onu zaten oluşturduğumuz nesnelere bağlayan yeni (yeşil) bir bağlayıcı oluşturalım.

```java
// Yeni bir bağlama nesnesi oluşturur
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Yeni bir bağlayıcı oluşturur
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Yeni oluşturulan bağlayıcıyı kullanarak nesneleri bağlar
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Bağlayıcı ayarlama noktalarını alır
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ayarlama noktalarının değerlerini değiştirir
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Sonuç:

![connector-adjusted-3](connector-adjusted-3.png)

İkinci olarak, yeni bağlayıcının ayarlama noktası connector.getAdjustments().get_Item(0) üzerinden geçen bağlayıcının yatay bileşenine karşılık gelecek bir şekil oluşturalım. Bağlayıcı verilerindeki connector.getRotation(), connector.getFrame().getFlipH() ve connector.getFrame().getFlipV() değerlerini kullanacağız ve verilen bir x0 noktasına göre dönüş için popüler koordinat dönüşüm formülünü uygulayacağız:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Bizim durumumuzda, nesnenin dönüş açısı 90 derecedir ve bağlayıcı dikey olarak görüntülenir, bu yüzden ilgili kod şöyledir:

```java
// Bağlayıcı koordinatlarını kaydeder
x = connector.getX();
y = connector.getY();
// Bağlayıcı koordinatlarını gerektiğinde düzeltir
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Ayarlama noktası değerini koordinat olarak alır
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Koordinatları dönüştürür; çünkü Sin(90) = 1 ve Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// İkinci ayarlama noktası değerini kullanarak yatay bileşenin genişliğini belirler
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Sonuç:

![connector-adjusted-4](connector-adjusted-4.png)

Basit ayarlamaları ve karmaşık ayarlama noktalarını (dönüş açıları olan ayarlama noktaları) içeren hesaplamaları gösterdik. Edindiğiniz bilgiyi kullanarak kendi modelinizi geliştirebilir (veya kod yazabilirsiniz) ve belirli slayt koordinatlarına göre bir `GraphicsPath` nesnesi elde edebilir ya da bir bağlayıcının ayarlama noktası değerlerini ayarlayabilirsiniz.

## **Bağlayıcı Çizgilerinin Açısını Bulma**

1. Sınıftan bir örnek oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. Bağlayıcı çizgi şeklini erişin.  
1. Çizgi genişliğini, yüksekliğini, şekil çerçevesi yüksekliğini ve şekil çerçevesi genişliğini kullanarak açıyı hesaplayın.  

Bu Java kodu, bir bağlayıcı çizgi şeklinin açısını nasıl hesapladığımızı gösterir:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **SSS**

**Bir bağlayıcının belirli bir şekle "yapıştırılabilir" olup olmadığını nasıl anlayabilirim?**

Şeklin [bağlantı noktalarını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--) sunduğundan emin olun. Hiçbir bağlantı noktası yoksa veya sayısı sıfırsa, yapıştırma mümkün değildir; bu durumda serbest uçları kullanıp manuel olarak konumlandırın. Bağlamadan önce site sayısını kontrol etmek mantıklıdır.

**Bağlantılı şekillerden birini sildiğimde bağlayıcı ne olur?**

Köşeleri ayrılacak; bağlayıcı slaytta serbest başlangıç/bitiş noktalarına sahip bir normal çizgi olarak kalır. Ya silinebilir ya da bağlantılar yeniden atanabilir ve gerekirse [reroute](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/connector/#reroute--) yapılabilir.

**Bir slaytı başka bir sunuma kopyaladığımda bağlayıcı bağlamaları korunur mu?**

Genellikle evet, hedef şekiller de kopyalanırsa. Slayt, bağlı şekiller olmadan başka bir dosyaya eklenirse, uçlar serbest kalır ve yeniden bağlamanız gerekir.