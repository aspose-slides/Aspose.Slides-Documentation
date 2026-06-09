---
title: ".NET'te Sunumlarda Bağlayıcıları Yönetme"
linktitle: "Bağlayıcı"
type: docs
weight: 10
url: /tr/net/connector/
keywords:
- "bağlayıcı"
- "bağlayıcı türü"
- "bağlayıcı noktası"
- "bağlayıcı çizgisi"
- "bağlayıcı açısı"
- "şekilleri bağla"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "PowerPoint slaytlarında .NET uygulamalarının çizim, bağlama ve otomatik yönlendirme yapmalarını sağlayın—düz, dirsek ve eğimli bağlayıcılar üzerinde tam kontrol elde edin."
---
## **Giriş**

PowerPoint bağlayıcıları iki şekli birbiriyle bağlayan özel hatlardır ve bir slaytta hareket ettirildiklerinde ya da konumları değiştirildiğinde bile şekillere yapışık kalırlar.  

Bağlayıcılar genellikle *bağlantı noktalarına* (yeşil noktalar) bağlanır; bu noktalar tüm şekillerde varsayılan olarak bulunur. Bağlantı noktaları, imleç yaklaştığında görünür.

*Ayarlama noktaları* (turuncu noktalar), yalnızca belirli bağlayıcılarda bulunur ve bağlayıcıların konum ve şekillerini değiştirmek için kullanılır.

## **Bağlayıcı Türleri**

PowerPoint’te düz, dirsek (köşeli) ve eğimli bağlayıcılar kullanabilirsiniz.  

Aspose.Slides aşağıdaki bağlayıcıları sunar:

| Bağlayıcı | Resim | Ayar noktası sayısı |
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

## **Bağlayıcıları Kullanarak Şekilleri Bağlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksi üzerinden bir slayt referansı alın.  
1. `Shapes` nesnesi tarafından sunulan `AddAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.  
1. Bağlayıcı türünü belirterek `Shapes` nesnesi tarafından sunulan `AddConnector` yöntemiyle bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla birleştirin.  
1. En kısa bağlantı yolunu uygulamak için `Reroute` yöntemini çağırın.  
1. Sunumu kaydedin.  

Bu C# kodu, iki şekil (bir elips ve bir dikdörtgen) arasında bir bükülmüş bağlayıcı eklemenizi gösterir:

```c#
// PPTX dosyasını temsil eden bir sunum sınıfı örneği oluşturur
using (Presentation input = new Presentation())
{                
    // Belirli bir slayt için şekil koleksiyonuna erişir
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Bir Elips otomatik şekli ekler
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Bir Dikdörtgen otomatik şekli ekler
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Bağlayıcı şekli slayt şekil koleksiyonuna ekler
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Şekilleri bağlayıcıyı kullanarak bağlar
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Şekiller arasındaki otomatik en kısa yolu ayarlayan reroute yöntemini çağırır
    connector.Reroute();

    // Sunumu kaydeder
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

`Connector.Reroute` yöntemi bir bağlayıcıyı yeniden yönlendirir ve şekiller arasında mümkün olan en kısa yolu almasını zorlar. Bu amacı gerçekleştirmek için yöntem, `StartShapeConnectionSiteIndex` ve `EndShapeConnectionSiteIndex` noktalarını değiştirebilir. 

{{% /alert %}} 

## **Bağlantı Noktası Belirleme**
Bağlayıcının iki şekli belirli noktalardan bağlamasını istiyorsanız, tercih ettiğiniz bağlantı noktalarını şu şekilde belirtmelisiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksi üzerinden bir slayt referansı alın.  
1. `Shapes` nesnesi tarafından sunulan `AddAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.  
1. Bağlayıcı türünü belirterek `Shapes` nesnesi tarafından sunulan `AddConnector` yöntemiyle bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla birleştirin.  
1. Şekiller üzerindeki tercih ettiğiniz bağlantı noktalarını ayarlayın.  
1. Sunumu kaydedin.  

Bu C# kodu, tercih edilen bir bağlantı noktasının nasıl belirtileceğini göstermektedir:

```c#
 // PPTX dosyasını temsil eden bir sunum sınıfı örneği oluşturur
 using (Presentation presentation = new Presentation())
 {
     // Belirli bir slayt için şekil koleksiyonuna erişir
     IShapeCollection shapes = presentation.Slides[0].Shapes;

     // Slaytın şekil koleksiyonuna bir bağlayıcı şekli ekler
     IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

     // Bir Elips otomatik şekli ekler
     IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

     // Bir Dikdörtgen otomatik şekli ekler
     IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

     // Şekilleri bağlayıcıyı kullanarak bağlar
     connector.StartShapeConnectedTo = ellipse;
     connector.EndShapeConnectedTo = rectangle;

     // Elips şekli üzerinde tercih edilen bağlantı nokta indeksini ayarlar
     uint wantedIndex = 6;

     // Tercih edilen indeksin maksimum site indeks sayısından küçük olup olmadığını kontrol eder
     if (ellipse.ConnectionSiteCount > wantedIndex)
     {
         // Elips otomatik şekline tercih edilen bağlantı noktasını ayarlar
         connector.StartShapeConnectionSiteIndex = wantedIndex;
     }

     // Sunumu kaydeder
     presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
 }
```

## **Bağlayıcı Noktasını Ayarlama**

Mevcut bir bağlayıcıyı ayarlama noktalarıyla ayarlayabilirsiniz. Yalnızca ayarlama noktalarına sahip bağlayıcılar bu şekilde değiştirilebilir. **[Bağlayıcı Türleri](/slides/tr/net/connector/#types-of-connectors)** altındaki tabloya bakın. 

### **Basit Durum**

İki şekil (A ve B) arasındaki bağlayıcının üçüncü bir şekil (C) üzerinden geçtiği bir durumu düşünün:

![connector-obstruction](connector-obstruction.png)

Kod:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Üçüncü şekilden kaçınmak veya onu atlamak için bağlayıcının dikey hattını aşağıdaki gibi sola kaydırarak ayarlayabiliriz:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Karmaşık Durumlar** 

Daha karmaşık ayarlamalar yapmak için şu hususları göz önünde bulundurmalısınız:

* Bir bağlayıcının ayarlanabilir noktası, konumunu hesaplayan ve belirleyen bir formüle sıkı sıkıya bağlıdır. Bu nedenle noktanın konumundaki değişiklikler bağlayıcının şeklini etkileyebilir.  
* Bağlayıcının ayarlama noktaları, bir dizi içinde kesin bir sırayla tanımlanır. Ayarlama noktaları, bağlayıcının başlangıç noktasından bitiş noktasına doğru numaralandırılır.  
* Ayarlama noktası değerleri, bağlayıcı şeklinin genişlik/yükseklik yüzdesini yansıtır.  
  * Şekil, bağlayıcının başlangıç ve bitiş noktalarıyla çarpılan 1000 ile sınırlıdır.  
  * İlk nokta, ikinci nokta ve üçüncü nokta sırasıyla genişlik yüzdesi, yükseklik yüzdesi ve tekrar genişlik yüzdesini tanımlar.  
* Bir bağlayıcının ayarlama noktalarının koordinatlarını belirleyen hesaplamalarda, bağlayıcının dönüşü ve yansıması dikkate alınmalıdır. **Not**: **[Bağlayıcı Türleri](/slides/tr/net/connector/#types-of-connectors)** altındaki tüm bağlayıcıların dönüş açısı 0’dır.

#### **Durum 1**

İki metin çerçevesi nesnesinin bir bağlayıcı aracılığıyla birbirine bağlandığı bir durumu düşünün:

![connector-shape-complex](connector-shape-complex.png)

Kod:

```c#
// PPTX dosyasını temsil eden bir sunum sınıfı örneği oluşturur
Presentation pres = new Presentation();
// Sunumdaki ilk slaytı alır
ISlide sld = pres.Slides[0];
// Bağlayıcı ile birleştirilecek şekilleri ekler
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Bağlayıcı ekler
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Bağlayıcının yönünü belirler
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Bağlayıcının rengini belirler
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Bağlayıcı çizgisinin kalınlığını belirler
connector.LineFormat.Width = 3;

// Şekilleri bağlayıcı ile birbirine bağlar
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Bağlayıcı için ayarlama noktalarını alır
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Ayarlama**

Bağlayıcının ayarlama noktası değerlerini, ilgili genişlik ve yükseklik yüzdelerini sırasıyla %20 ve %200 artırarak değiştirebiliriz:

```c#
// Ayarlama noktalarının değerlerini değiştirir
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Sonuç:

![connector-adjusted-1](connector-adjusted-1.png)

Bireysel parçaların koordinatlarını ve şeklini belirlememizi sağlayan bir model oluşturmak için, bağlayıcının `Adjustments[0]` noktasındaki yatay bileşeni temsil eden bir şekil oluşturalım:

```c#
// Bağlayıcının dikey bileşenini çizer

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Sonuç:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Durum 2**

**Durum 1**’de temel prensiplerle basit bir bağlayıcı ayarlama işlemi gösterdik. Normal durumlarda, bağlayıcı dönüşü ve gösterimi (`connector.Rotation`, `connector.Frame.FlipH`, `connector.Frame.FlipV`) dikkate alınmalıdır. Şimdi bu süreci göstereceğiz.

İlk olarak, slayta yeni bir metin çerçevesi nesnesi (**To 1**) ekleyip (bağlantı amaçlı) zaten oluşturduğumuz nesnelere bağlayan yeni bir (yeşil) bağlayıcı ekleyelim.

```c#
// Yeni bir bağlama nesnesi oluşturur
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Yeni bir bağlayıcı oluşturur
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Yeni oluşturulan bağlayıcıyı kullanarak nesneleri bağlar
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Bağlayıcı ayarlama noktalarını alır
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Ayarlama noktalarının değerlerini değiştirir
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Sonuç:

![connector-adjusted-3](connector-adjusted-3.png)

İkinci olarak, yeni bağlayıcının ayarlama noktası `connector.Adjustments[0]` üzerinden geçen yatay bileşeni temsil eden bir şekil oluşturalım. Bağlayıcı verilerindeki `connector.Rotation`, `connector.Frame.FlipH` ve `connector.Frame.FlipV` değerlerini kullanarak, verilen bir x0 noktasına göre dönüş için yaygın koordinat dönüşüm formülünü uygulayalım:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Bizim durumumuzda, nesnenin dönüş açısı 90 derecedir ve bağlayıcı dikey olarak görüntülenir; bu yüzden ilgili kod şu şekildedir:

```c#
// Bağlayıcı koordinatlarını kaydeder
x = connector.X;
y = connector.Y;
// Bağlayıcı koordinatlarını gerektiğinde düzeltir
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Ayarlama noktası değerini koordinat olarak alır
x += connector.Width * adjValue_0.RawValue / 100000;
//  Koordinatları dönüştürür çünkü Sin(90) = 1 ve Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// İkinci ayarlama noktası değerini kullanarak yatay bileşenin genişliğini belirler
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
```

Sonuç:

![connector-adjusted-4](connector-adjusted-4.png)

Basit ayarlamalar ve dönüş açısı içeren karmaşık ayarlama noktalarıyla ilgili hesaplamaları gösterdik. Edindiğiniz bilgiyle, belirli slayt koordinatlarına dayalı bir `GraphicsPath` nesnesi elde etmek ya da bir bağlayıcının ayarlama nokta değerlerini ayarlamak için kendi modelinizi (veya kodunuzu) geliştirebilirsiniz.

## **Bağlayıcı Çizgilerinin Açısını Bulma**
1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksi üzerinden bir slayt referansı alın.  
1. Bağlayıcı çizgi şeklini erişin.  
1. Açıyı hesaplamak için çizgi genişliği, yüksekliği, şekil çerçevesi yüksekliği ve şekil çerçevesi genişliğini kullanın.  

Bu C# kodu, bir bağlayıcı çizgi şeklinin açısını nasıl hesaplayacağınızı gösterir:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **SSS**

**Bir bağlayıcının belirli bir şekle “yapışıp yapışmadığını” nasıl anlayabilirim?**  

Şeklin [bağlantı noktalarını](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/connectionsitecount/) expose ettiğini kontrol edin. Hiçbiri yoksa veya sayı sıfırsa, yapışma mümkün değildir; bu durumda serbest uçları kullanıp manuel konumlandırmalısınız. Bağlantı nokta sayısını eklemeden önce kontrol etmek akıllıca olur.

**Bağlantılı şekillerden birini silersem bağlayıcı ne olur?**  

Uçları ayrılır; bağlayıcı slaytta serbest başlangıç/bitiş noktalarına sahip normal bir çizgi olarak kalır. Ya silebilir ya da bağlantıları yeniden atayabilir ve gerekirse [reroute](https://reference.aspose.com/slides/tr/net/aspose.slides/connector/reroute/) yapabilirsiniz.

**Bir slaytı başka bir sunuma kopyaladığımda bağlayıcı bağlamaları korunur mu?**  

Genellikle evet, hedef şekiller de kopyalanırsa korunur. Slayt, bağlanmış şekiller olmadan başka bir dosyaya eklenirse uçlar serbest olur ve yeniden bağlamanız gerekir.