---
title: PowerPoint Şekillerini .NET'te Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/net/shape-formatting/
keywords:
- şekli biçimlendir
- çizgiyi biçimlendir
- eskiz efekti
- eskiz şekil çizgisi
- birleştirme stilini biçimlendir
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil işleme
- gri tonlu şekil işleme
- şekli döndür
- 3d kemer efekti
- 3d döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak C# ile PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT ve PPTX dosyaları için doldurma, çizgi ve efekt stillerini hassasiyet ve tam kontrol ile ayarlayın."
---
## **Giriş**

PowerPoint'ta slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerine etkiler uygulayarak veya değiştirerek biçimlendirebilirsiniz. Ayrıca, şekillerin içlerinin nasıl doldurulacağını kontrol eden ayarları belirterek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET, PowerPoint'ta mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arabirimler ve özellikler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin [line style](https://reference.aspose.com/slides/tr/net/aspose.slides/linestyle/) özelliğini ayarlayın.  
5. Çizgi genişliğini ayarlayın.  
6. Çizginin [dash style](https://reference.aspose.com/slides/tr/net/aspose.slides/linedashstyle/) özelliğini ayarlayın.  
7. Şeklin çizgi rengini ayarlayın.  
8. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Örnek C# kodu, bir dikdörtgen `AutoShape`'i nasıl biçimlendireceğinizi gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisini el çizimi gibi gösterir. Çizgi ayarlarına erişmek için [IShape.LineFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/lineformat/) , eskiz ayarlarına erişmek için [ILineFormat.SketchFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformat/sketchformat/) , ve [ISketchFormat.SketchType](https://reference.aspose.com/slides/tr/net/aspose.slides/isketchformat/sketchtype/) üzerinden [LineSketchType](https://reference.aspose.com/slides/tr/net/aspose.slides/linesketchtype/) adlı enum değerini seçmek için kullanın.

Aşağıdaki C# kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/net/aspose.slides/linesketchtype/) efekti nasıl uygulanır, açıkça atanmış değer nasıl okunur ve [LineSketchType.None](https://reference.aspose.com/slides/tr/net/aspose.slides/linesketchtype/) ile efekt nasıl kaldırılır gösterir:

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

`ISketchFormat.SketchType` tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi tema, ana slayt veya düzen slaytından devralınabiliyorsa, [ILineFormat.GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformat/geteffective/) , [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ilineformateffectivedata/sketchformat/) ve [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/tr/net/aspose.slides/isketchformateffectivedata/sketchtype/) kullanın. Etkili değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Birleştirme Stilleri Biçimlendirme**

İşte üç birleştirme tipi seçeneği:

* Yuvarlak
* Kiriş
* Köşe

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açıları olan bir şekil çiziyorsanız **Kiriş** seçeneğini tercih edebilirsiniz.

![The join style in the presentation](join-style-powerpoint.png)

Aşağıdaki C# kodu, yukarıdaki resimde gösterildiği gibi üç dikdörtgenin Miter, Köşe ve Yuvarlak birleştirme tipi ayarları kullanılarak nasıl oluşturulduğunu gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle (dikdörtgen) tipinde üç otomatik şekil ekleyin.
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

## **Gradyan Doldurma**

PowerPoint'ta Gradyan Doldurma, bir şekle sürekli bir renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça geçecek şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan doldurma uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.  
5. [IGradientFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/igradientformat/) arabirimi tarafından sağlanan gradyan durak koleksiyonunun `Add` metodlarını kullanarak, belirli konumlarla iki tercih ettiğiniz rengi ekleyin.  
6. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Ellipse tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye gradyan biçimlendirmesi uygulayın.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Gradyanın yönünü ayarlayın.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // İki gradyan durak ekleyin.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![The ellipse with gradient fill](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'ta Desen Doldurma, bir şekle iki renkli bir tasarım (nokta, çizgi, çapraz tarama veya kare gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınıza görsel çekicilik katmak için 45'ten fazla ön tanımlı desen stilini sunar. Ön tanımlı bir desen seçtikten sonra bile, kullanılacak renkleri kesin olarak belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.  
5. Ön tanımlı seçeneklerden bir desen stilini seçin.  
6. Desenin [Background Color](https://reference.aspose.com/slides/tr/net/aspose.slides/ipatternformat/backcolor/) özelliğini ayarlayın.  
7. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/net/aspose.slides/ipatternformat/forecolor/) özelliğini ayarlayın.  
8. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The rectangle with pattern fill](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'ta Resim Doldurma, bir şeklin içine bir resim eklemenizi sağlayan bir biçimlendirme seçeneğidir; böylece resim şeklin arka planı gibi kullanılır.

Aspose.Slides kullanarak bir şekle resim doldurma uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.  
5. Resim doldurma kipini `Tile` (veya tercih ettiğiniz başka bir kip) olarak ayarlayın.  
6. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesi oluşturun.  
7. Bu görüntüyü şeklin `PictureFillFormat` üzerindeki `Picture.Image` özelliğine atayın.  
8. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Örneğin aşağıdaki resimle bir "lotus.png" dosyamız olduğunu varsayalım:

![The lotus picture](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slaytı alın.
    ISlide slide = presentation.Slides[0];

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Doldurma tipini Picture olarak ayarlayın.
    shape.FillFormat.FillType = FillType.Picture;

    // Resim doldurma kipini ayarlayın.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Bir görüntü yükleyin ve sunum kaynaklarına ekleyin.
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

![The shape with picture fill](picture-fill.png)

### **Döşeme Resmini Doku Olarak Kullanma**

Eğer döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/picturefillformat/) sınıfı özelliklerini kullanabilirsiniz:

- [PictureFillMode](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/picturefillmode/): Resim doldurma kipini ayarlar — `Tile` veya `Stretch`.  
- [TileAlignment](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilealignment/): Döşemelerin şekil içinde hizalamasını belirtir.  
- [TileFlip](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileflip/): Döşemenin yatay, dikey veya her iki yönde ters çevrilip çevrilmeyeceğini kontrol eder.  
- [TileOffsetX](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileoffsetx/): Döşemenin şeklin orijinalinden yatay ofsetini (point cinsinden) ayarlar.  
- [TileOffsetY](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tileoffsety/): Döşemenin şeklin orijinalinden düşey ofsetini (point cinsinden) ayarlar.  
- [TileScaleX](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilescalex/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.  
- [TileScaleY](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/tilescaley/): Döşemenin düşey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşemeli resim doldurmasıyla bir dikdörtgen şekil eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Resim doldurma kipini ve döşeme özelliklerini yapılandırın.
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

![The tile options](tile-options.png)

## **Düz Renk Doldurma**

PowerPoint'ta Düz Renk Doldurma, bir şekli tek ve tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, gradeler, dokular veya desenler olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk doldurma uygulamak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
5. Şekle tercih ettiğiniz doldurma rengini atayın.  
6. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The shape with solid color fill](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'ta bir şekle düz renk, gradyan, resim veya doku doldurması uyguladığınızda, doldurmanın opaklığını kontrol etmek için bir şeffaflık seviyesi de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha geçirgen olmasını sağlar ve arka plan ya da alt nesnelerin kısmen görülmesine izin verir.

Aspose.Slides, doldurma için kullanılan renkteki alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
5. `Color.FromArgb(alpha, baseColor)` kullanarak şeffaf bir renk tanımlayın (`alpha` bileşeni şeffaflığı kontrol eder).  
6. Sunumu kaydedin.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The transparent shape](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimleriyle konumlandırırken faydalı olabilir.

Bir slayt üzerindeki bir şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin `Rotation` özelliğini istenen açıya ayarlayın.  
5. Sunumu kaydedin.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The shape rotation](shape-rotation.png)

## **3D Kemer Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D kemer efektleri uygulamanıza olanak tanır.

Bir şekle 3D kemer etkileri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliğini kemer ayarlarını tanımlamak için yapılandırın.  
5. Sunumu kaydedin.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Sunumu PPTX dosyası olarak kaydedin.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri uygulamanıza olanak tanır.

Bir şekle 3D döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slayta indeksine göre referans alın.  
3. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.  
4. Şeklin [CameraType](https://reference.aspose.com/slides/tr/net/aspose.slides/icamera/cameratype/) ve [LightType](https://reference.aspose.com/slides/tr/net/aspose.slides/ilightrig/lighttype/) özelliklerini ayarlayarak 3D döndürmeyi tanımlayın.  
5. Sunumu kaydedin.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Sunumu PPTX dosyası olarak kaydedin.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![The 3D rotation effect](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz İşleme Kontrolü**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/blackwhitemode/) özelliği, bir sunum siyah‑beyaz modunda görüntülendiğinde veya işlenirken bireysel bir şeklin nasıl işlendiğini belirtir. Bu özellik tek başına siyah‑beyaz görüntüyü etkinleştirmez ve normal renk modundaki şeklin doldurmasını, çizgisini veya diğer biçimlendirmelerini değiştirmez.

İstenilen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/tr/net/aspose.slides/blackwhitemode/) enum değerlerinden birini kullanın. Örneğin, `Automatic` render uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri renklendirme kullanır, `BlackWhite` yalnızca siyah ve beyazı, `Black` ve `White` tek bir rengi zorlar, `Color` normal renklendirmeyi korur ve `Hidden` siyah‑beyaz modunda şekli gizler. `NotDefined` ise şekil seviyesinde bir mod atanmadığını gösterir.

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

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Normal renk modunda, dikdörtgen turuncu doldurmasını korur. Siyah‑beyaz görüntüleme sürecinde, modu `Gray` olarak ayarlandığı için gri renklendirme kullanır. Bu, tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah‑beyaz görüntüleme ayarlarını dikkate alan diğer süreçler için ayrı bir görünüm tanımlamanıza olanak tanır.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki C# kodu, bir slaydın biçimlendirmesini nasıl sıfırlayacağınızı ve [LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslide/) üzerindeki yer tutuculu tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına nasıl geri döndüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Yer tutucuya sahip düzen slaydındaki her şekli sıfırla.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosya boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosyanın büyük bölümünü kaplar, şekil parametreleri (renkler, efektler, gradyanlar vb.) meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Bir slaytta aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir setini ayrı bir dosyada saklayıp diğer sunumlarda yeniden kullanabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt paketi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stil verilmiş şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.