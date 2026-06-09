---
title: PowerPoint Sunum Şekillerinin Küçük Resimlerini .NET'te Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/net/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil resmi
- şekil oluşturma
- şekil renderleme
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for .NET, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, sunum dosyalarını Microsoft PowerPoint ile açarak görüntülenebilir. Ancak bazen geliştiricilerin şekillerin görüntülerini ayrı bir görüntüleyicide görmek istemesi gerekir. Bu gibi durumlarda Aspose.Slides for .NET, slayt şekillerinin küçük resim (thumbnail) görüntülerini oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.
Bu makale, slayt küçük resimlerini farklı şekillerde nasıl oluşturacağınızı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Bir şeklin görünüm sınırları içinde şekil küçük resmi oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for .NET kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için:

1. Create an instance of the [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) class.
1. ID veya indeksini kullanarak herhangi bir slaytın referansını alın.
1. Referans alınan slaytın şekil küçük resmi görüntüsünü varsayılan ölçekte alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

Aşağıdaki örnek bir şekil küçük resmi oluşturur.

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
Aspose.Slides for .NET kullanarak herhangi bir slayt şeklinin şekil küçük resmini oluşturmak için:

1. `Presentation` sınıfının bir örneğini oluşturun.
1. ID veya indeksini kullanarak herhangi bir slaytın referansını alın.
1. Referans alınan slaytın şekil sınırlarıyla küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

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

## **Sınır Tabanlı Şekil Görünümü Küçük Resmi Oluşturma**
Bu yöntem, şekillerin küçük resimlerini oluştururken geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim üretmelerine olanak tanır. Tüm şekil efektlerini dikkate alır. Oluşturulan şekil küçük resmi slayt sınırlarıyla kısıtlanır. Herhangi bir slayt şeklinin görünüm sınırları içinde bir küçük resim oluşturmak için aşağıdaki örnek kodu kullanın:

1. `Presentation` sınıfının bir örneğini oluşturun.
1. ID veya indeksini kullanarak herhangi bir slaytın referansını alın.
1. Referans alınan slaytın şekil sınırlarını görünüm olarak kullanarak küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

Aşağıdaki örnek, görünüm olarak sınırları kullanarak bir küçük resim oluşturur.

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

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/), ve diğerleri. Şekiller, şeklin içeriğini SVG olarak kaydederek ayrıca [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/writeassvg/).

**Küçük resim oluştururken Şekil ve Görünüm sınırları arasındaki fark nedir?**

`Shape`, şeklin geometrisini kullanır; `Appearance` ise [görsel efektleri](/slides/tr/net/shape-effect/) (gölge, parıltı vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenmişse ne olur? Yine de küçük resim olarak oluşturulur mu?**

Gizli bir şekil modelin bir parçası olarak kalır ve oluşturulabilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün üretilmesini engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne ([GroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartart/) dahil) küçük resim veya SVG olarak kaydedilebilir.

**Sistem tarafından yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeler ve metin akışını önlemek için [gerekli fontları sağlamalısınız](/slides/tr/net/custom-font/) (veya [font ikamelerini yapılandırmalısınız](/slides/tr/net/font-substitution/)).