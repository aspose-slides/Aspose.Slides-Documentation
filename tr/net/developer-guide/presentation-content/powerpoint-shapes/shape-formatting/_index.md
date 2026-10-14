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
- bağlantı stili biçimlendirme
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- siyah beyaz şekil işleme
- gri tonlamalı şekil işleme
- şekil döndürme
- 3B keskinlik efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak C# ile PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT ve PPTX dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlıklarına değişiklik yaparak veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![format-şekli-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET, PowerPoint'te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arabirimler ve özellikler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar bu prosedürü özetler:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [çizgi stilini](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) ayarlayın.  
1. Çizgi kalınlığını belirleyin.  
1. Çizginin [kesikli stilini](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) ayarlayın.  
1. Şeklin çizgi rengini belirleyin.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu bir dikdörtgen `AutoShape`i nasıl biçimlendireceğinizi gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dikdörtgen şeklinin doldurma rengini ayarla.
    shape.FillFormat.FillType = FillType.NoFill;

    // Dikdörtgenin çizgilerine biçimlendirme uygula.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Dikdörtgenin çizgi rengini ayarla.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTX dosyasını diske kaydet.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) kullanın, eskiz ayarlarına erişmek için [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) ve [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) ile [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) enum değerlerinden birini seçin.

Aşağıdaki C# kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, açıkça atanmış değeri nasıl okuyacağınızı ve [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) ile etkisini nasıl kaldıracağınızı gösterir:

```csharp
using Aspose.Slides;

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

`ISketchFormat.SketchType` tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaydından devralınabiliyorsa, [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) kullanın, [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) öğesine erişin ve [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) değerini okuyun. Etkili değer, miras çözülüp uygulanmış gerçek biçimlendirmeyi yansıtır:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Bağlantı Stilleri Biçimlendirme**

Üç bağlantı tipi seçeneği vardır:

* Yuvarlak
* Miter
* Köşe

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlantı stili](join-style-powerpoint.png)

Aşağıdaki C# kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Round bağlantı stili ayarlarıyla üç dikdörtgenin nasıl oluşturulduğunu gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) türünde üç otomatik şekil ekle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin doldurma rengini ayarla.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Çizgi kalınlığını ayarla.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Her dikdörtgenin çizgi rengini ayarla.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Bağlantı stilini ayarla.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Her dikdörtgene metin ekle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // PPTX dosyasını diske kaydet.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Degrade Doldurma**

PowerPoint'te Degrade Doldurma, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki ya da daha fazla renk ekleyerek birinin yavaşça diğerine geçmesini sağlayabilirsiniz.

Aspose.Slides kullanarak bir şekle degrade doldurma uygulamanın adımları:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.  
1. [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) arabiriminin degrade durak koleksiyonunun `Add` metodlarını kullanarak iki tercih ettiğiniz rengi tanımlı konumlarla ekleyin.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir elips üzerine degrade doldurma etkisinin nasıl uygulanacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Ellipse (elips) türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye degrade biçimlendirme uygula.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Degrade yönünü ayarla.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // İki degrade durak noktasını ekle.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // PPTX dosyasını diske kaydet.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Degrade doldurulmuş elips](gradient-fill.png)

Degrade, dışa aktarılan bir görüntüde PowerPoint'tekinden farklı görünüyorsa, [Bir Degrade İşleme Stili Seçin](/slides/tr/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda saklanan degrade doldurmayı değiştirmeden bir işleme stili seçebilirsiniz.

## **Desen Doldurma**

PowerPoint'te Desen Doldurma, iki renkli bir tasarımı (nokta, şerit, çapraz çizgiler veya kareler gibi) bir şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunularınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra bile, kullanılacak tam renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulamanın adımları:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.  
1. Ön tanımlı seçenekler arasından bir desen stili seçin.  
1. Desenin [Arka Plan Rengini](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) ayarlayın.  
1. Desenin [Ön Plan Rengini](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir dikdörtgene desen doldurma uygulamanın nasıl yapılacağını gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Pattern olarak ayarla.
    shape.FillFormat.FillType = FillType.Pattern;

    // Desen stilini ayarla.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Desenin arka plan ve ön plan renklerini ayarla.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // PPTX dosyasını diske kaydet.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'te Resim Doldurma, bir şeklin içine bir görüntü yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; böylece görüntü şeklin arka planı gibi davranır.

Aspose.Slides kullanarak bir şekle resim doldurma uygulamanın adımları:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.  
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.  
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) nesnesi oluşturun.  
1. Bu görüntüyü şeklin `PictureFillFormat` özelliğindeki `Picture.Image` özelliğine atayın.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki görüntü "lotus.png" adlı dosyayı göstermektedir:

![Lotus resmi](lotus.png)

Aşağıdaki C# kodu, bir şekle resim doldurma nasıl yapılacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Doldurma türünü Picture olarak ayarla.
    shape.FillFormat.FillType = FillType.Picture;

    // Resim doldurma modunu ayarla.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Bir görüntü yükle ve sunum kaynaklarına ekle.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Resmi ayarla.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // PPTX dosyasını diske kaydet.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Doku Olarak Döşeme Resmi**

Döşeli bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) sınıfının özelliklerini kullanabilirsiniz:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Resim doldurma modunu `Tile` ya da `Stretch` olarak ayarlar.  
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Döşemelerin şekil içinde hizalanmasını belirler.  
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.  
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Döşemenin yatay kaymasını (puan cinsinden) şeklin orijinalinden ayarlar.  
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Döşemenin dikey kaymasını (puan cinsinden) şeklin orijinalinden ayarlar.  
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.  
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekle döşeli resim doldurma ekleyip döşeme seçeneklerini yapılandırmayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide firstSlide = presentation.Slides[0];

    // Bir dikdörtgen otomatik şekil ekle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma türünü Picture olarak ayarla.
    shape.FillFormat.FillType = FillType.Picture;

    // Görüntüyü yükle ve sunum kaynaklarına ekle.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Görüntüyü şekle ata.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Resim doldurma modunu ve döşeme özelliklerini yapılandır.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // PPTX dosyasını diske kaydet.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

PowerPoint'te Katı Renk Doldurma, bir şekli tek bir, aynı renkle dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, degrade, doku ya da desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle katı renk doldurma uygulamak için şu adımları izleyin:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. İstediğiniz doldurma rengini şekle atayın.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki C# kodu, bir PowerPoint slaydındaki bir dikdörtgene katı renk doldurma nasıl uygulanır gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Solid olarak ayarla.
    shape.FillFormat.FillType = FillType.Solid;

    // Doldurma rengini ayarla.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX dosyasını diske kaydet.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'te bir şekle katı renk, degrade, resim ya da doku doldurma uyguladığınızda, doldurmanın opaklığını kontrol etmek için şeffaflık seviyesini de ayarlayabilirsiniz. Yüksek şeffaflık değeri, şeklin daha çok görünür olmasını sağlar; arka plan ya da alttaki nesneler kısmen görülür.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. `Color.FromArgb(alpha, baseColor)` kullanarak şeffaflığa sahip bir renk tanımlayın (`alpha` bileşeni şeffaflığı kontrol eder).  
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir dikdörtgene şeffaf bir doldurma renginin nasıl uygulanacağını gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Katı bir dikdörtgen otomatik şekil ekle.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekle.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX dosyasını diske kaydet.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama ya da tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin `Rotation` özelliğini istenen açıya ayarlayın.  
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir şekli 5 derece döndürmeyi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndür.
    shape.Rotation = 5;

    // PPTX dosyasını diske kaydet.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Şekil döndürülmesi](shape-rotation.png)

## **3B Keskinlik Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B keskinlik efektleri eklemenizi sağlar.

Bir şekle 3B keskinlik efekti eklemek için şu adımları izleyin:

1. [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) özelliğini ayarlayarak keskinlik ayarlarını tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir şekle 3B keskinlik efektinin nasıl uygulanacağını gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Sunumu bir PPTX dosyası olarak kaydet.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![3B keskinlik etkisi](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri eklemenizi sağlar.

Bir şekle 3B döndürme uygulamak için:

1. Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) ve [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) özelliklerini ayarlayarak 3B döndürmeyi tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki C# kodu, bir şekle 3B döndürme efektinin nasıl uygulanacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Sunumu bir PPTX dosyası olarak kaydet.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![3B döndürme etkisi](3D-rotation-effect.png)

## **Şekiller İçin Siyah‑Beyaz Rendering Kontrolü**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) özelliği, bir sunum siyah‑beyaz modunda görüntülendiğinde ya da işlendiğinde bireysel bir şeklin nasıl render edileceğini belirtir. Bu özellik tek başına siyah‑beyaz görüntülemeyi etkinleştirmez ve normal renk modundaki şeklin doldurma, çizgi veya diğer biçimlendirmelerini değiştirmez.

İstediğiniz davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) enumundan bir değer kullanın. Örneğin, `Automatic` render uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri renkleme kullanır, `BlackWhite` sadece siyah ve beyazı, `Black` ve `White` tek renk zorlar, `Color` normal renklemeyi korur ve `Hidden` siyah‑beyaz modunda şekli gizler. `NotDefined` ise şekil‑seviyesi bir modun atanmadığını gösterir.

Aşağıdaki C# kodu, renkli bir şekil oluşturur ve siyah‑beyaz görüntüleme modunda gri görünmesini sağlar:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Renk modunda turuncu doldurmayı tut, ancak siyah-beyaz modunda şekli gri renkle render et.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Normal renk modunda, dikdörtgen turuncu doldurmasını korur. Siyah‑beyaz görüntüleme akışında, modu `Gray` olarak ayarlandığı için gri renkle gösterilir. Bu, tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah‑beyaz görüntüleme ayarlarını dikkate alan diğer akışlar için ayrı bir görünüm tanımlamanıza olanak verir.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki C# kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri getirmeyi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Düzende yer tutucu bulunan slayttaki her şekli sıfırla.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Yalnızca çok az etkiler. Gömülü görüntüler ve medya dosyaları dosya alanının büyük bir kısmını oluştururken, renkler, efektler ve degrade gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut katmaz.

**Aynı biçimlendirmeye sahip şekilleri tespit edip gruplamak nasıl yapılır?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, daha sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda tekrar kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi ya da .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.