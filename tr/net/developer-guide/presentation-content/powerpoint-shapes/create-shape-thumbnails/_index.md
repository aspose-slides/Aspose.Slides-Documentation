---
title: .NET'te Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/net/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil renderi
- şekil işleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for .NET, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytlar Microsoft PowerPoint ile açılarak görüntülenebilir. Ancak bazı durumlarda geliştiricilerin şekillerin görüntülerini ayrı bir görüntüleyicide görmek istemesi gerekir. Böyle durumlarda Aspose.Slides for .NET, slayt şekillerinin küçük resimlerini oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.
Bu makale, slayt küçük resimlerini farklı şekillerde oluşturmayı açıklar:

- Bir slayt içinde bir şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Bir şeklin görünümünün sınırları içinde şekil küçük resmi oluşturma.

## **Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for .NET kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için:

1. `Presentation` sınıfının bir örneğini oluşturun.
1. Slaytı ID'si veya diziniyle referans alın.
1. Referans alınan slaytın şekil küçük resmi görüntüsünü varsayılan ölçekle alın.
1. Küçük resmi istediğiniz görüntü formatında kaydedin.

Aşağıdaki örnek şekil küçük resmi oluşturur.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Kullanıcı Tanımlı Ölçekleme Faktörü ile Küçük Resim Oluşturma**
Aspose.Slides for .NET kullanarak herhangi bir slayt şeklinin küçük resmini oluşturmak için:

1. `Presentation` sınıfının bir örneğini oluşturun.
1. Slaytı ID'si veya diziniyle referans alın.
1. Referans alınan slaytın şekil sınırlarıyla küçük resim görüntüsünü alın.
1. Küçük resmi istediğiniz görüntü formatında kaydedin.

Aşağıdaki örnek, kullanıcı tanımlı ölçekleme faktörüyle bir küçük resim oluşturur.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X ve Y eksenlerinde ölçekleme.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Sınıra Dayalı Şekil Görünümü Küçük Resmi Oluşturma**
Bu yöntem, geliştiricilerin şeklin görünümünün sınırları içinde bir küçük resim oluşturmasına olanak tanır. Tüm şekil efektlerini dikkate alır. Oluşturulan şekil küçük resmi slayt sınırlarıyla sınırlanır. Görünümünün sınırlı olduğu bir slayt şekli için küçük resim oluşturmak üzere aşağıdaki örnek kodu kullanın:

1. `Presentation` sınıfının bir örneğini oluşturun.
1. Slaytı ID'si veya diziniyle referans alın.
1. Referans alınan slaytın şekil sınırlarını görünüm olarak alarak küçük resim görüntüsünü alın.
1. Küçük resmi istediğiniz görüntü formatında kaydedin.

Aşağıdaki örnek, kullanıcı tanımlı ölçekleme faktörüyle bir küçük resim oluşturur.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X ve Y eksenlerinde ölçekleme.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Bir Şeklin Gerçek Görsel Sınırlarını Alın**

[IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arayüzünün çerçeve özellikleri—`X`, `Y`, `Width` ve `Height`—sunum modelinde saklanan dikdörtgeni açıklar. Gerçekten çizilen içerik bu çerçevenin dışına çıkabilir veya farklı bir eksenle hizalanmış dikdörtgen kaplayabilir. Döndürme, kenarlıklar, ok uçları, metin yerleşimi ve taşması, oluşturulan SmartArt geometrisi ve diğer çizim etkileri, kaplanan alanı değiştirebilir.

Bu kaplanan alanı bir resim oluşturmadan hesaplamak için [GetVisualBounds](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getvisualbounds/) kullanın. Metot, slayt koordinatlarında bir [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) döndürür. Döndürülen dikdörtgen slayta kırpılmaz; içerik slayt orijininin dışına uzandığında koordinatları negatif olabilir.

[GetVisualBounds](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getvisualbounds/) şu anda [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arayüzü tarafından bildirilmemektedir. Bu nedenle, slayttaki şekil koleksiyonundan alınan şekli bir arayüz değeri olarak tutun ve metodu çağırırken yalnızca dönüştürün.

Aşağıdaki örnek, çerçeve ve görsel sınırları alıp karşılaştırır:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Aynı [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef), yakınlardaki şekilleri `Left`, `Right`, `Top` veya `Bottom` kenarına hizalamak; oluşturulan bir yerleşimde yeterli alan ayırmak; ya da izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir. Görsel sınırlar, saklanan çerçeve tam olarak render sonucunu yansıtmayabilecek SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için özellikle yararlıdır.

Düzenleme veya doğrulama için koordinatlara ihtiyacınız olduğunda ve bir bitmap gerekmiyorsa [GetVisualBounds](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getvisualbounds/) kullanın. Şekli gerçekten çizmek istediğinizde ise [IShape.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getimage/) kullanın. [ShapeThumbnailBounds](https://reference.aspose.com/slides/tr/net/aspose.slides/shapethumbnailbounds/) ile `ShapeThumbnailBounds.Shape`, dış hat ayarları dahil şekil sınırlarından resmi boyutlandırırken, `ShapeThumbnailBounds.Appearance` resmi şeklin görünümünden boyutlandırır ve sonucu slayt sınırlarıyla kısıtlar. Buna karşıt olarak, [GetVisualBounds](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getvisualbounds/) yalnızca hesaplanan dikdörtgeni döndürür ve slayta kırpmaz.

## **SSS**

**Şekil küçük resimleri kaydedilirken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca içeriği SVG olarak kaydedilerek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/writeassvg/).

**Küçük resim oluşturulurken Şekil ve Görünüm sınırları arasındaki fark nedir?**

`Shape`, şeklin geometrisini kullanır; `Appearance` ise [görsel efektleri](/slides/tr/net/shape-effect/) (gölgeler, parıltılar vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenirse ne olur? Küçük resim olarak hâlâ oluşturulur mu?**

Gizli bir şekil modelin bir parçası olarak kalır ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/) (ör. [GroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartart/)) olarak temsil edilen herhangi bir nesne, küçük resim veya SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeler ve metin kaymalarını önlemek için [gerekli fontları sağlamalısınız](/slides/tr/net/custom-font/) (veya [font ikameleri yapılandırmalısınız](/slides/tr/net/font-substitution/)).