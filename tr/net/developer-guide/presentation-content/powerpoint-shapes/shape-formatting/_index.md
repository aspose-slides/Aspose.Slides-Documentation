---
title: PowerPoint Şekillerini .NET’te Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/net/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- birleştirme stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- katı renk dolgu
- şekil şeffaflığı
- şekil döndürme
- 3d kırpma efekti
- 3d döndürme efekti
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak C#’ta PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT ve PPTX dosyaları için dolgu, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar hatlarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin içinin nasıl doldurulacağını kontrol eden ayarları belirterek biçimlendirebilirsiniz.

![şekil biçimlendirme-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET, PowerPoint’te bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve özellikler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetler:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [çizgi stilini](https://reference.aspose.com/slides/tr/net/aspose.slides/linestyle/) ayarlayın.
1. Çizgi kalınlığını belirleyin.
1. Çizginin [çizgi stilini](https://reference.aspose.com/slides/tr/net/aspose.slides/linedashstyle/) ayarlayın.
1. Şeklin çizgi rengini belirleyin.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu bir dikdörtgen `AutoShape` ı nasıl biçimlendireceğinizi gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dikdörtgen şeklinin dolgu rengini ayarlayın.
    shape.FillFormat.FillType = FillType.NoFill;

    // Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Dikdörtgenin çizgi rengini ayarlayın.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Birleştirme Stilleri Biçimlendirme**

Üç birleştirme tipi seçeneği vardır:

* Round (Yuvarlak)
* Miter (Kutup)
* Bevel (Eğim)

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak, keskin açılı bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

Aşağıdaki C# kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round birleştirme tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle türünde üç otomatik şekil ekleyin.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin dolgu rengini ayarlayın.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Çizgi kalınlığını ayarlayın.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Her dikdörtgenin çizgi rengini ayarlayın.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Birleştirme stilini ayarlayın.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Her dikdörtgene metin ekleyin.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // PPTX dosyasını diske kaydedin.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradyan Dolgu**

PowerPoint’te Gradyan Dolgu, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki ya da daha fazla rengi birinin diğerine yavaşça karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulamak için:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/igradientformat/) arayüzünün sunduğu gradyan durak koleksiyonunun `Add` metodlarını kullanarak iki tercih ettiğiniz rengi tanımlı konumlarla ekleyin.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu bir elips üzerine gradyan dolgu etkisi nasıl uygulanır gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Ellipse türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye gradyan biçimlendirme uygulayın.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Gradyanın yönünü ayarlayın.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // İki gradyan durağı ekleyin.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Gradyan dolgu ile elips](gradient-fill.png)

## **Desen Dolgu**

PowerPoint’te Desen Dolgu, iki renkli bir tasarımı (nokta, çizgi, çapraz gölgeler veya kare gibi) bir şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45’ten fazla önceden tanımlı desen stili sunar. Önceden tanımlı bir desen seçtikten sonra, kullanılacak tam renkleri hâlâ belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulama adımları:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Arka Plan Rengini](https://reference.aspose.com/slides/tr/net/aspose.slides/ipatternformat/backcolor/) ayarlayın.
1. Desenin [Ön Plan Rengini](https://reference.aspose.com/slides/tr/net/aspose.slides/ipatternformat/forecolor/) ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu bir dikdörtgene desen dolgu nasıl uygulanır gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Pattern olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Pattern;

    // Desen stilini ayarlayın.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Desenin arka plan ve ön plan renklerini ayarlayın.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Desen dolgu ile dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint’te Resim Dolgu, bir şeklin içine bir görüntü eklemenizi – görüntüyü şeklin arka planı gibi kullanmanızı – sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim dolgu uygulama adımları:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim dolgu modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görselden bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesi oluşturun.
1. Bu görseli şeklin `PictureFillFormat` nesnesinin `Picture.Image` özelliğine atayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Şöyle bir “lotus.png” dosyamız olduğunu varsayalım:

![Lotus resmi](lotus.png)

Aşağıdaki C# kodu bir şekle resmi nasıl dolduracağınızı gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Dolgu tipini Picture olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Picture;

    // Resim dolgu modunu ayarlayın.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Bir resmi yükleyin ve sunum kaynaklarına ekleyin.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Resmi ayarlayın.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Resim dolgulu şekil](picture-fill.png)

### **Doku Olarak Döşeme Resmi**

Döşelenmiş bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/) arayüzünün ve [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/) sınıfının aşağıdaki özelliklerini kullanabilirsiniz:

- [PictureFillMode](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/picturefillmode/): Resim dolgu modunu – `Tile` ya da `Stretch` – ayarlar.
- [TileAlignment](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilealignment/): Şekil içinde döşemelerin hizalanmasını belirtir.
- [TileFlip](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileflip/): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [TileOffsetX](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileoffsetx/): Döşemenin şeklin orijinalinden yatay ofsetini (puan cinsinden) ayarlar.
- [TileOffsetY](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileoffsety/): Döşemenin şeklin orijinalinden dikey ofsetini (puan cinsinden) ayarlar.
- [TileScaleX](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [TileScaleY](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilescaley/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekle döşeme resimli dolgu ekleyip döşeme seçeneklerini yapılandırmayı gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide firstSlide = presentation.Slides[0];

    // Bir dikdörtgen otomatik şekil ekleyin.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu tipini Picture olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Picture;

    // Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Görüntüyü şekle atayın.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Resim dolgu modunu ve döşeme özelliklerini yapılandırın.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Dolgu**

PowerPoint’te Katı Renk Dolgu, bir şekli tek, tekdüze bir renkle dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku ya da desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle katı renk dolgu uygulamak için şu adımları izleyin:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Tercih ettiğiniz dolgu rengini şekle atayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir PowerPoint slaydındaki bir dikdörtgene katı renk dolgu nasıl uygulanır gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Solid olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Solid;

    // Dolgu rengini ayarlayın.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Katı renk dolgulu şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint’te bir şekle katı renk, gradyan, resim ya da doku dolgusu uyguladığınızda şeffaflık düzeyi ayarlayarak dolgunun opaklığını kontrol edebilirsiniz. Daha yüksek şeffaflık değeri şekli daha çok görünür kılar, arka planın ya da alt nesnelerin kısmen görünmesini sağlar.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color.FromArgb(alpha, baseColor)` ifadesini kullanarak şeffaflık içeren bir renk tanımlayın (alpha bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki C# kodu bir dikdörtgene şeffaf dolgu rengi nasıl uygulanır gösterir:

```c#
const int alpha = 128;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Katı bir dikdörtgen otomatik şekil ekleyin.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekleyin.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX dosyasını diske kaydedin.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama ya da tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir şekli slayt üzerinde döndürmek için şu adımları izleyin:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin `Rotation` özelliğini istenen açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki C# kodu şekli 5 derece döndürmeyi gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndürün.
    shape.Rotation = 5;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Şekil dönüşü](shape-rotation.png)

## **3D Kırpma Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D kırpma efektleri eklemenize imkan verir.

Bir şekle 3D kırpma efekti eklemek için şu adımları izleyin:

1. [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) ayarlarını yapılandırarak kırpma ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki C# kodu bir şekle 3D kırpma efektleri nasıl uygulanır gösterir:

```c#
 // Presentation sınıfının bir örneğini oluşturun.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];

     // Slayta bir şekil ekleyin.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
     shape.FillFormat.FillType = FillType.Solid;
     shape.FillFormat.SolidFillColor.Color = Color.Green;
     shape.LineFormat.FillFormat.FillType = FillType.Solid;
     shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
     shape.LineFormat.Width = 2.0;

     // Şeklin ThreeDFormat özelliklerini ayarlayın.
     shape.ThreeDFormat.Depth = 4;
     shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
     shape.ThreeDFormat.BevelTop.Height = 6;
     shape.ThreeDFormat.BevelTop.Width = 6;
     shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
     shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
     shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

     // Sunumu bir PPTX dosyası olarak kaydedin.
     presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
 }
```

Sonuç:

![3D kırpma efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri eklemenize imkan verir.

Bir şekle 3D döndürme uygulamak için:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [CameraType](https://reference.aspose.com/slides/tr/net/aspose.slides/icamera/cameratype/) ve [LightType](https://reference.aspose.com/slides/tr/net/aspose.slides/ilightrig/lighttype/) özelliklerini ayarlayarak 3D döndürmeyi tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki C# kodu bir şekle 3D döndürme etkisi nasıl uygulanır gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Sunumu bir PPTX dosyası olarak kaydedin.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![3D döndürme efekti](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki C# kodu, bir slaydın biçimlendirmesini sıfırlayarak [LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslide/) üzerindeki yer tutucuların konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürür:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Layout üzerindeki yer tutucuya sahip slayttaki her şekli sıfırla.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosyasının boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını oluşturur, şekil parametreleri (renkler, efektler, gradyanlar) ise meta veri olarak saklanır ve neredeyse ekstra bir boyut eklemez.

**Aynı biçimlendirmeyi paylaşan şekilleri bir slaytta nasıl tespit edip gruplayabilirim?**

Her şeklin ana biçimlendirme özelliklerini – dolgu, çizgi ve efekt ayarlarını – karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı kabul edip bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir kümesini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyada saklayabilir miyim?**

Evet. İstenilen stillere sahip örnek şekilleri bir şablon slayt dosyasında ya da .POTX şablon dosyasında tutun. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.