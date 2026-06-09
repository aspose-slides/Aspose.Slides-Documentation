---
title: .NET'te Sunum Arka Planlarını Yönetin
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/net/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- katı renk
- geçiş rengi
- resim arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planları nasıl ayarlayacağınızı, sunumlarınızı güçlendirecek kod ipuçlarıyla öğrenin."
---
## **Giriş**

Katı renkler, geçişler ve resimler slayt arka planları için yaygın olarak kullanılır. Arka planı **normal bir slayt** (tek bir slayt) veya **üst slayt** (birden çok slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint background](powerpoint-background.png)

## **Normal Bir Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için, sunum bir üst slayt kullansa bile, arka planı katı bir renk olarak ayarlamanıza olanak tanır. Değişiklik yalnızca seçilen slayta uygulanır.

1. bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun.
2. slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) niteliğini `OwnBackground` olarak ayarlayın.
3. slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) niteliğini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/) üzerindeki [SolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/solidfillcolor/) özelliğini kullanarak katı arka plan rengini belirleyin.
5. değiştirilmiş sunumu kaydedin.

Aşağıdaki C# örneği, normal bir slayt için mavi bir katı renk arka planının nasıl ayarlanacağını gösterir:

```cs
// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Slaytın arka plan rengini mavi olarak ayarlayın.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Sunumu diske kaydedin.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Üst Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki üst slayt için arka planı katı bir renk olarak ayarlamanıza izin verir. Üst slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle üst slaytın arka planı için katı bir renk seçtiğinizde, bu renk her slayta uygulanır.

1. bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun.
2. üst slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) niteliğini ( `masters` aracılığıyla) `OwnBackground` olarak ayarlayın.
3. üst slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) niteliğini `Solid` olarak ayarlayın.
4. katı arka plan rengini belirlemek için [SolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/solidfillcolor/) özelliğini kullanın.
5. değiştirilmiş sunumu kaydedin.

Aşağıdaki C# örneği, üst slayt için katı bir renk (orman yeşili) arka planının nasıl ayarlanacağını gösterir:

```cs
// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Master slaytın arka plan rengini Orman Yeşili olarak ayarlayın.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Sunumu diske kaydedin.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Bir Slayt İçin Geçiş (Gradient) Arka Planı Ayarlama**

Geçiş, renklerin kademeli olarak değişmesiyle oluşturulan bir grafik etkisidir. Slayt arka planı olarak kullanıldığında, geçişler sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için geçiş rengi arka planı ayarlamanıza olanak tanır.

1. bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun.
2. slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) niteliğini `OwnBackground` olarak ayarlayın.
3. slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) niteliğini `Gradient` olarak ayarlayın.
4. tercih ettiğiniz geçiş ayarlarını yapılandırmak için [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/) üzerindeki [GradientFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/gradientformat/) özelliğini kullanın.
5. değiştirilmiş sunumu kaydedin.

Aşağıdaki C# örneği, bir slayt için geçiş rengi arka planının nasıl ayarlanacağını gösterir:

```cs
// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Arka plana bir geçiş efekti uygulayın.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Sunumu diske kaydedin.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Bir Slayt Arka Planı Olarak Resim Ayarlama**

Katı ve geçiş doldurmalarına ek olarak, Aspose.Slides resimleri slayt arka planı olarak kullanmanıza izin verir.

1. bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun.
2. slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) niteliğini `OwnBackground` olarak ayarlayın.
3. slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) niteliğini `Picture` olarak ayarlayın.
4. slayt arka planı olarak kullanmak istediğiniz resmi yükleyin.
5. resmi sunumun resim koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/) üzerindeki [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/picturefillformat/) özelliğini kullanarak resmi arka plan olarak atayın.
7. değiştirilmiş sunumu kaydedin.

Aşağıdaki C# örneği, bir slayt için arka plan resmi olarak nasıl ayarlanacağını gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Arka plan resmi özelliklerini ayarlayın.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Resmi yükleyin.
    IImage image = Images.FromFile("Tulips.jpg");
    // Resmi sunumun görüntü koleksiyonuna ekleyin.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Sunumu diske kaydedin.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Aşağıdaki kod örneği, arka plan doldurma tipini döşeli bir resim olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Arka plan doldurması için kullanılan resmi ayarlayın.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Resim doldurma modunu Döşeme olarak ayarlayın ve döşeme özelliklerini ayarlayın.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Daha fazla bilgi: [**Tile Picture As Texture**](/slides/tr/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Arka Plan Resmi Şeffaflığını Değiştirme**

Bir slaytın arka plan resminin şeffaflığını ayarlamak, slayt içeriğinin öne çıkmasını sağlayabilir. Aşağıdaki C# kodu, slayt arka planı resminin şeffaflığını nasıl değiştireceğinizi gösterir:

```cs
var transparencyValue = 30; // Örneğin.

// Resim dönüşüm işlemlerinin koleksiyonunu alın.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Mevcut sabit yüzde şeffaflık etkisini bulun.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Yeni şeffaflık değerini ayarlayın.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **Slayt Arka Plan Değerini Alma**

Aspose.Slides, bir slaytın geçerli arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ibackgroundeffectivedata/) arayüzünü sağlar. Bu arayüz, geçerli [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibackgroundeffectivedata/fillformat/) ve [EffectFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibackgroundeffectivedata/effectformat/) öğelerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslide/) sınıfının `background` özelliğini kullanarak bir slaytın geçerli arka planını elde edebilirsiniz.

Aşağıdaki C# örneği, bir slaytın geçerli arka plan değerinin nasıl alınacağını gösterir:

```cs
// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Master, düzen ve temayı dikkate alarak etkili arka planı alın.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **SSS**

**Özel bir arka planı sıfırlayıp tema/düzen arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel doldurmasını kaldırın; arka plan, ilgili [düzen](/slides/tr/net/slide-layout/)/[üst slayt](/slides/tr/net/slide-master/) slaytından (yani [tema arka planı](/slides/tr/net/presentation-theme/)) yeniden devralınır.

**Sunumun temasını daha sonra değiştirirsem arka plan ne olur?**

Slaytın kendi doldurması varsa değişmeden kalır. Arka plan, [düzen](/slides/tr/net/slide-layout/)/[üst slayt](/slides/tr/net/slide-master/) üzerinden devralınmışsa, yeni tema ile eşleşecek şekilde güncellenir.