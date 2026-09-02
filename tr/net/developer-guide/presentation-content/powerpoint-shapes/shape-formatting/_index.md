---
title: PowerPoint Şekillerini .NET'te Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/net/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- kavşak stili biçimlendirme
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil şeffaflığı
- şekil döndürme
- 3B oluk efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak C#'ta PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin - PPT ve PPTX dosyaları için doldurma, çizgi ve efekt stillerini hassas ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerini değiştirerek veya etkiler uygulayarak biçimlendirebilirsiniz. Ayrıca şeklin iç kısmının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![PowerPoint’ta şekil biçimlendirme](format-shape-powerpoint.png)

Aspose.Slides for .NET, PowerPoint’te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve özellikler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar bu prosedürü özetler:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/net/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını belirleyin.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/net/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini belirleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir dikdörtgen `AutoShape`’in nasıl biçimlendirileceğini göstermektedir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dikdörtgen şeklin doldurma rengini ayarlayın.
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

## **Şekil Çizgilerine Eskiz Efekti Uygulama**

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [IShape.LineFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/lineformat/) kullanın, eskiz ayarlarına erişmek için [ILineFormat.SketchFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformat/sketchformat/) ve [ISketchFormat.SketchType](https://reference.aspose.com/slides/tr/net/aspose.slides/isketchformat/sketchtype/) kullanarak [LineSketchType](https://reference.aspose.com/slides/tr/net/aspose.slides/linesketchtype/) enum değerlerinden birini seçin.

Aşağıdaki C# kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/net/aspose.slides/linesketchtype/) efekti uygulamayı, açıkça atanan değeri okumayı ve efekti [LineSketchType.None](https://reference.aspose.com/slides/tr/net/aspose.slides/linesketchtype/) ile kaldırmayı gösterir:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

`ISketchFormat.SketchType` tarafından döndürülen değer, doğrudan şekle atanan ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya yerleşim slaytından kalıtılmışsa, [ILineFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformat/geteffective/) kullanın, [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformateffectivedata/sketchformat/) öğesine erişin ve [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/tr/net/aspose.slides/isketchformateffectivedata/sketchtype/) değerini okuyun. Etkili değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Köşe Biçimlendirme**

Üç köşe tipi seçeneği şunlardır:

* Yuvarlak
* Kiriş
* Köşeli

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirdiğinde **Yuvarlak** ayarını kullanır. Ancak keskin açıları olan bir şekil çizerken **Kiriş** seçeneğini tercih edebilirsiniz.

![Sunumdaki köşe stili](join-style-powerpoint.png)

Aşağıdaki C# kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Round köşe tipi ayarları kullanılarak üç dikdörtgenin nasıl oluşturulduğunu göstermektedir:

```c#
# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    # İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    # Rectangle tipinde üç otomatik şekil ekleyin.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    # Her dikdörtgen şeklin doldurma rengini ayarlayın.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    # Çizgi kalınlığını ayarlayın.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    # Her dikdörtgenin çizgi rengini ayarlayın.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    # Kavşak stilini ayarlayın.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    # Her dikdörtgene metin ekleyin.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    # PPTX dosyasını diske kaydedin.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Degrade Doldurma**

PowerPoint’te Degrade Doldurma, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin iki veya daha fazla rengi, birinin yavaşça diğerine geçecek şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle degrade doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/igradientformat/) arayüzü tarafından sunulan degrade durakları koleksiyonunun `Add` yöntemlerini kullanarak iki tercih ettiğiniz rengi belirli konumlarla ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir elips üzerinde degrade doldurma etkisinin nasıl uygulanacağını göstermektedir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Ellipse tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 55, 55, 150, 75);

    // Elipseye degrade biçimlendirmesi uygulayın.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Degradenin yönünü ayarlayın.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // İki degrade durak ekleyin.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Degrade doldurulmuş elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint’te Desen Doldurma, bir şekle iki renkli bir tasarım (nokta, çizgi, çapraz çizgi veya kare gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45’ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra kullanılan renkleri de istediğiniz gibi belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/net/aspose.slides/ipatternformat/backcolor/) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/net/aspose.slides/ipatternformat/forecolor/) özelliğini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir dikdörtgene desen doldurmanın nasıl uygulanacağını göstermektedir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Pattern olarak ayarlayın.
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

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint’te Resim Doldurma, bir şeklin içine bir görüntü ekleyerek şeklin arka planı gibi kullanılmasını sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görselden bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesi oluşturun.
1. Bu görseli şeklin `PictureFillFormat`’ındaki `Picture.Image` özelliğine atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıda aşağıdaki görseli içeren bir "lotus.png" dosyası olduğunu varsayalım:

![Lotus resmi](lotus.png)

Aşağıdaki C# kodu, bir şekli resim ile doldurmanın nasıl yapılacağını gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Doldurma tipini Picture olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Picture;

    // Resim doldurma modunu ayarlayın.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Bir görsel yükleyin ve sunum kaynaklarına ekleyin.
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

![Resim doldurulmuş şekil](picture-fill.png)

### **Doku Olarak Kırpılmış Resim**

Kırpılmış bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek isterseniz, [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/) sınıfının aşağıdaki özelliklerini kullanabilirsiniz:

- [PictureFillMode](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/picturefillmode/): Resim doldurma modunu `Tile` veya `Stretch` olarak ayarlar.
- [TileAlignment](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilealignment/): Döşemelerin şekil içinde hizalanmasını belirler.
- [TileFlip](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileflip/): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [TileOffsetX](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileoffsetx/): Döşemenin şeklin orijininin X eksenindeki (nokta cinsinden) kaymasını ayarlar.
- [TileOffsetY](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileoffsety/): Döşemenin şeklin orijininin Y eksenindeki (nokta cinsinden) kaymasını ayarlar.
- [TileScaleX](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [TileScaleY](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilescaley/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekline döşemeli resim doldurması ekleyip döşeme seçeneklerini nasıl yapılandıracağınızı gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide firstSlide = presentation.Slides[0];

    // Bir dikdörtgen otomatik şekil ekleyin.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma tipini Picture olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Picture;

    // Görseli yükleyin ve sunum kaynaklarına ekleyin.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Görseli şekle atayın.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Resim doldurma modunu ve döşeme özelliklerini yapılandırın.
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

## **Düz Renk Doldurma**

PowerPoint’te Düz Renk Doldurma, bir şekli tek ve tutarlı bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, degrade, doku veya desen içermez.

Aspose.Slides kullanarak bir şekle düz renk doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. İstediğiniz doldurma rengini şekle atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir PowerPoint slaytındaki dikdörtgene düz renk doldurmanın nasıl yapılacağını gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Solid olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Solid;

    // Doldurma rengini ayarlayın.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Düz renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint’te bir şekle düz renk, degrade, resim veya doku doldurması uyguladığınızda, doldurmanın opaklığını kontrol etmek için şeffaflık düzeyini de ayarlayabilirsiniz. Yüksek şeffaflık değeri, şeklin arka planı veya altındaki nesneleri kısmen görünür kılar.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color.FromArgb(alpha, baseColor)` kullanarak şeffaf bir renk tanımlayın (`alpha` bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir dikdörtgene şeffaf bir doldurma rengi uygulamanın nasıl yapılacağını gösterir:

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

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalamalar veya tasarım gereksinimleriyle konumlandırırken faydalı olabilir.

Bir slaytta bir şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin `Rotation` özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir şekli 5 derece döndürmenin nasıl yapılacağını gösterir:

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndürün.
    shape.Rotation = 5;

    // PPTX dosyasını diske kaydedin.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3B Oluk Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B oluk efektleri uygulamanıza imkan verir.

Bir şekle 3B oluk efektleri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliğini yapılandırarak oluk ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir şekle 3B oluk efektleri uygulamayı gösterir:

```c#
// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Slayta bir şekil ekle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Şeklin ThreeDFormat özelliklerini ayarla.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Sunumu PPTX dosyası olarak kaydet.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![3B oluk efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza imkan verir.

Bir şekle 3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
1. Şeklin [CameraType](https://reference.aspose.com/slides/tr/net/aspose.slides/icamera/cameratype/) ve [LightType](https://reference.aspose.com/slides/tr/net/aspose.slides/ilightrig/lighttype/) özelliklerini ayarlayarak 3B döndürmeyi tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir şekle 3B döndürme efektleri uygulamanın nasıl yapılacağını gösterir:

```c#
// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Sunumu PPTX dosyası olarak kaydet.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki C# kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslide/) üzerindeki yer tutucu tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Düzen üzerindeki yer tutucuya sahip slayttaki her şeklin biçimlendirmesini sıfırla.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Şekil biçimlendirmesi, nihai sunum dosya boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosyanın çoğu alanını kaplarken, renkler, efektler ve degrade gibi şekil parametreleri meta veri olarak saklanır ve neredeyse hiç ek boyut oluşturmaz.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta tespit edip gruplamak nasıl yapılır?**

Her şeklin temel biçimlendirme özelliklerini — dolgu, çizgi ve efekt ayarlarını — karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edip bu şekilleri mantıksal olarak gruplayın; bu, ileride stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyada saklayabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesine veya .POTX şablon dosyasına kaydedin. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilli şekilleri klonlayın ve gerekli yerlerde biçimlendirmeyi yeniden uygulayın.