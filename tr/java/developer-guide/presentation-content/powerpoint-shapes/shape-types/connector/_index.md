---
title: Java kullanarak Sunumlarda Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/java/connector/
keywords:
- bağlayıcı
- bağlayıcı tipi
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- şekilleri bağla
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java uygulamalarını PowerPoint slaytlarında çizim, bağlama ve otomatik yönlendirme yapabilme yeteneğiyle güçlendirin—düz, dirsek ve eğimli bağlayıcılar üzerinde tam kontrole sahip olun."
---
## **Giriş**

PowerPoint bağlayıcısı, iki şekli birbirine bağlayan veya ilişkilendiren özel bir çizgidir ve şekiller hareket ettirildiğinde veya konumları bir slaytta değiştirildiğinde bile şekillere bağlı kalır.  

Bağlayıcılar genellikle *bağlantı noktalarına* (yeşil noktalar) bağlanır; bu noktalar tüm şekillerde varsayılan olarak bulunur. Bağlantı noktaları, imleç onlara yaklaştığında görünür.  

*Ayarlama noktaları* (turuncu noktalar), yalnızca belirli bağlayıcılarda bulunur ve bağlayıcıların konum ve şekillerini değiştirmek için kullanılır.  

## **Bağlayıcı Türleri**

PowerPoint'te düz, dirsek (açılı) ve eğimli bağlayıcıları kullanabilirsiniz.  

Aspose.Slides bu bağlayıcıları sağlar:

| Bağlayıcı                      | Resim                                                        | Ayarlama noktası sayısı |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Şekilleri Bağlayıcılarla Bağlama**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İndeksi aracılığıyla bir slaytın referansını alın.  
1. `Shapes` nesnesi tarafından sağlanan `addAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/AutoShape) ekleyin.  
1. `Shapes` nesnesi tarafından sağlanan `addConnector` yöntemiyle bağlayıcı türünü tanımlayarak bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla bağlayın.  
1. En kısa bağlantı yolunu uygulamak için `reroute` yöntemini çağırın.  
1. Sunumu kaydedin.  

Bu Java kodu, iki şekil (bir elips ve bir dikdörtgen) arasında bir bağlayıcı (bükülmüş bağlayıcı) eklemenizi gösterir:

```Java
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
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
    
    // Bağlayıcıyı kullanarak şekilleri bağlar
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Şekiller arasındaki otomatik en kısa yolu ayarlayan reroute metodunu çağırır
    connector.reroute();
    
    // Sunumu kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` yöntemi bir bağlayıcıyı yeniden yönlendirir ve şekiller arasındaki en kısa yolu almasını zorlar. Hedefine ulaşmak için yöntem `setStartShapeConnectionSiteIndex` ve `setEndShapeConnectionSiteIndex` noktalarını değiştirebilir. 
{{% /alert %}} 

## **Bağlantı Noktası Belirleme**

Bir bağlayıcının iki şekli belirli noktalardan bağlamasını istiyorsanız, tercih ettiğiniz bağlantı noktalarını şu şekilde belirtmelisiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İndeksi aracılığıyla bir slaytın referansını alın.  
1. `Shapes` nesnesi tarafından sağlanan `addAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/AutoShape) ekleyin.  
1. `Shapes` nesnesi tarafından sağlanan `addConnector` yöntemiyle bağlayıcı türünü tanımlayarak bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla bağlayın.  
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

    // Bağlayıcıyı kullanarak şekilleri bağlar
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Elips şekli üzerinde tercih edilen bağlantı noktası indeksini ayarlar
    int wantedIndex = 6;

    // Tercih edilen indeksin maksimum site indeksi sayısından küçük olup olmadığını kontrol eder
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Elips otomatik şekli üzerinde tercih edilen bağlantı noktasını ayarlar
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Sunumu kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bağlayıcı Noktasını Ayarlama**

Mevcut bir bağlayıcıyı ayarlama noktaları aracılığıyla ayarlayabilirsiniz. Yalnızca ayarlama noktalarına sahip bağlayıcılar bu şekilde değiştirilebilir. **[Bağlayıcı Türleri](/slides/tr/java/connector/#types-of-connectors)** altındaki tabloya bakın.  

### **Basit Durum**

İki şekil (A ve B) arasındaki bağlayıcının üçüncü bir şekil (C) üzerinden geçtiği bir durumu düşünün:

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

Üçüncü şekilden kaçınmak veya onu atlatmak için bağlayıcıyı, dikey çizgisini sola kaydırarak şu şekilde ayarlayabiliriz:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Karmaşık Durumlar** 

Daha karmaşık ayarlamalar yapmak için aşağıdakileri göz önünde bulundurmalısınız:

* Bir bağlayıcının ayarlanabilir noktası, konumunu hesaplayan ve belirleyen bir formülle güçlü bir şekilde ilişkilidir. Bu yüzden noktanın konumundaki değişiklikler bağlayıcının şeklini değiştirebilir.  
* Bir bağlayıcının ayarlama noktaları, bir dizi içinde katı bir sırayla tanımlanır. Ayarlama noktaları bağlayıcının başlangıç noktasından sonuna doğru numaralandırılır.  
* Ayarlama noktası değerleri, bağlayıcı şeklinin genişlik/yükseklik yüzdesini yansıtır.  
  * Şekil, bağlayıcının başlangıç ve bitiş noktalarının 1000 ile çarpılmasıyla sınırlanır.  
  * İlk nokta, ikinci nokta ve üçüncü nokta sırasıyla genişlik yüzdesi, yükseklik yüzdesi ve tekrar genişlik yüzdesini tanımlar.  
* Bir bağlayıcının ayarlama noktalarının koordinatlarını belirleyen hesaplamalar için bağlayıcının dönüşünü ve yansımasını dikkate almanız gerekir. **Not**: **[Bağlayıcı Türleri](/slides/tr/java/connector/#types-of-connectors)** altında gösterilen tüm bağlayıcıların dönüş açısı 0'dır.  

#### **Durum 1**

İki metin çerçevesi nesnesinin bir bağlayıcı ile birbirine bağlandığı bir durumu düşünün:

![connector-shape-complex](connector-shape-complex.png)

```java
// Bir PPTX dosyasını temsil eden bir sunum sınıfını örnekler
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
    
    // Şekilleri bağlayıcıyla birbirine bağlar
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

Bağlayıcının koordinatlarını ve bireysel bölümlerinin şeklini belirlememize izin veren bir model tanımlamak için, `connector.getAdjustments().get_Item(0)` noktasındaki bağlayıcının yatay bileşenine karşılık gelen bir şekil oluşturalım:

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

**Durum 1**'de, temel prensipler kullanarak basit bir bağlayıcı ayarlama işlemini gösterdik. Normal durumlarda, bağlayıcı dönüşünü ve görüntülenmesini (`connector.getRotation()`, `connector.getFrame().getFlipH()`, ve `connector.getFrame().getFlipV()` tarafından ayarlanır) dikkate almanız gerekir. Şimdi bu süreci göstereceğiz.

İlk olarak, slayta yeni bir metin çerçevesi nesnesi (**To 1**) ekleyelim (bağlantı amacıyla) ve onu zaten oluşturduğumuz nesnelere bağlayan yeni (yeşil) bir bağlayıcı oluşturalım.

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
// Bağlayıcının ayarlama noktalarını alır
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ayarlama noktalarının değerlerini değiştirir
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Sonuç:

![connector-adjusted-3](connector-adjusted-3.png)

İkinci olarak, yeni bağlayıcının ayarlama noktası `connector.getAdjustments().get_Item(0)` üzerinden geçen bağlayıcının yatay bileşenine karşılık gelen bir şekil oluşturalım. `connector.getRotation()`, `connector.getFrame().getFlipH()` ve `connector.getFrame().getFlipV()` için bağlayıcı verilerindeki değerleri kullanacağız ve verilen x0 noktasına göre dönüş için yaygın koordinat dönüşüm formülünü uygulayacağız:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Bizim durumumuzda, nesnenin dönüş açısı 90 derecedir ve bağlayıcı dikey olarak gösterilir, bu yüzden ilgili kod şudur:

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
//  Koordinatları dönüştürür çünkü Sin(90) = 1 ve Cos(90) = 0
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

Basit ayarlamaları ve karmaşık ayarlama noktalarını (dönüş açılarıyla birlikte ayarlama noktaları) içeren hesaplamaları gösterdik. Edinilen bilgiyle kendi modelinizi geliştirebilir (veya kod yazabilirsiniz) ve belirli slayt koordinatlarına göre bir `GraphicsPath` nesnesi elde edebilir veya bir bağlayıcının ayarlama noktası değerlerini ayarlayabilirsiniz.

## **Bağlayıcı Çizgilerinin Açısını Bulma**

1. Sınıfın bir örneğini oluşturun.  
1. İndeksi aracılığıyla bir slaytın referansını alın.  
1. Bağlayıcı çizgi şeklini erişin.  
1. Açıyı hesaplamak için çizgi genişliğini, yüksekliğini, şekil çerçevesi yüksekliğini ve şekil çerçevesi genişliğini kullanın.  

Bu Java kodu, bir bağlayıcı çizgi şeklinin açısını hesapladığımız bir işlemi gösterir:

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

**Bir bağlayıcının belirli bir şekle “yapıştırılıp yapıştırılamadığını” nasıl anlayabilirim?**  
Şeklin [bağlantı noktalarını](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getConnectionSiteCount--) sağladığından emin olun. Eğer yoksa ya da sayısı sıfırsa, yapıştırma mümkün değildir; bu durumda serbest uç noktalarını kullanıp manuel olarak konumlandırın. Bağlamadan önce noktaların sayısını kontrol etmek mantıklıdır.  

**Bağlı şekillerden birini sildiğimde bağlayıcı ne olur?**  
Uçları ayrılır; bağlayıcı slaytta serbest başlangıç/bitişli normal bir çizgi olarak kalır. Ya silebilir ya da bağlantıları yeniden atayabilirsiniz ve gerekirse [reroute](https://reference.aspose.com/slides/tr/java/com.aspose.slides/connector/#reroute--) yapabilirsiniz.  

**Bir slaytı başka bir sunuma kopyaladığımda bağlayıcı bağları korunur mu?**  
Genellikle evet, hedef şekiller de kopyalanırsa. Slayt, bağlı şekiller olmadan başka bir dosyaya eklenirse, uçlar serbest kalır ve onları yeniden bağlamanız gerekir.