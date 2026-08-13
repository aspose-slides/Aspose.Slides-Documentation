---
title: .NET'te Sunum Arka Planlarını Yönet
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/net/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- katı renk
- degrade renk
- görüntü arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planları nasıl ayarlayacağınızı öğrenin, sunumlarınızı güçlendirecek kod ipuçlarıyla."
---
## **Giriş**

Katı renkler, degrade'ler ve görüntüler genellikle slayt arka planları için kullanılır. **Normal slayt** (tek bir slayt) veya **master slayt** (birden fazla slayta aynı anda uygulanır) için arka plan ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Slayt için Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için katı renkli arka plan ayarlamanıza olanak tanır—sunum bir master slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/) üzerindeki [SolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/solidfillcolor/) özelliğini kullanarak katı arka plan rengini belirleyin.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki C# örneği, normal bir slayt için mavi katı renk arka planı ayarlamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Slaydın arka plan rengini mavi olarak ayarla.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Sunumu diske kaydet.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Master Slayt için Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki master slayt için katı renkli arka plan ayarlamanıza olanak tanır. Master slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle master slaytın arka planına katı renk seçtiğinizde, bu renk her slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Master slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) (via `masters`) özelliğini `OwnBackground` olarak ayarlayın.
3. Master slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [SolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/solidfillcolor/) özelliğini kullanarak katı arka plan rengini belirleyin.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki C# örneği, master slayt için katı renk (orman yeşili) arka planı ayarlamayı gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Master slaytının arka plan rengini Orman Yeşili olarak ayarla.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Sunumu diske kaydet.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Slayt için Degrade Arka Planı Ayarlama**

Degrade, renklerin kademeli olarak değişmesiyle oluşturulan bir grafik etkisidir. Slayt arka planı olarak kullanıldığında, degrade sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için degrade renkli arka plan ayarlamanıza izin verir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/) üzerindeki [GradientFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/gradientformat/) özelliğini kullanarak istediğiniz degrade ayarlarını yapılandırın.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki C# örneği, bir slayt için degrade renk arka planı ayarlamayı gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Arka plana bir degrade etkisi uygula.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Sunumu diske kaydet.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Slayt Arka Planı Olarak Görüntü Ayarlama**

Katı ve degrade doldurmaların yanı sıra, Aspose.Slides slayt arka planı olarak görüntü kullanmanıza da izin verir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/net/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/) üzerindeki [PictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/fillformat/picturefillformat/) özelliğini kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilen sunumu kaydedin.

Aşağıdaki C# örneği, bir slayt için arka plan olarak bir görüntü ayarlamayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Arka plan görüntüsü özelliklerini ayarla.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Görüntüyü yükle.
    IImage image = Images.FromFile("Tulips.jpg");
    // Görüntüyü sunumun görüntü koleksiyonuna ekle.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Sunumu diske kaydet.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Aşağıdaki kod örneği, arka plan doldurma tipini döşeli bir resim olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Arka plan doldurması için kullanılan görüntüyü ayarla.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Resim doldurma modunu Döşeme olarak ayarla ve döşeme özelliklerini ayarla.
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

{{% alert color="info" %}}
Daha fazla okuyun: [**Tile Picture As Texture**](/slides/tr/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slaytın arka plan görüntüsünün şeffaflığını ayarlayarak slayt içeriğinin daha çok öne çıkmasını isteyebilirsiniz. Aşağıdaki C# kodu, bir slayt arka plan görüntüsünün şeffaflığını nasıl değiştireceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Örneğin.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Resim dönüşüm işlemleri koleksiyonunu al.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Mevcut sabit yüzde şeffaflık etkisini bul.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Yeni şeffaflık değerini ayarla.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Slayt Arka Plan Değerini Almak**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ibackgroundeffectivedata/) arayüzünü sağlar. Bu arayüz, etkili [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibackgroundeffectivedata/fillformat/) ve [EffectFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibackgroundeffectivedata/effectformat/) özelliklerini ortaya koyar.

[BaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslide/) sınıfının `background` özelliğini kullanarak bir slaytın etkili arka planını elde edebilirsiniz.

Aşağıdaki C# örneği, bir slaytın etkili arka plan değerini almayı gösterir:

```cs
using Aspose.Slides;

// Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Master, yerleşim ve temayı dikkate alarak etkili arka planı al.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **SSS**

### Özel bir arka planı sıfırlayıp tema/yerleşim arka planını geri yükleyebilir miyim?

Evet. Slaytın özel doldurmasını kaldırın, böylece arka plan tekrar ilgili [layout](/slides/tr/net/slide-layout/)/[master](/slides/tr/net/slide-master/) slaytundan (yani [theme background](/slides/tr/net/presentation-theme/)) devralınır.

### Sunum temasını daha sonra değiştirirsem arka plan ne olur?

Eğer bir slaytın kendi doldurması varsa, bu değişmeden kalır. Eğer arka plan [layout](/slides/tr/net/slide-layout/)/[master](/slides/tr/net/slide-master/) üzerinden devralınmışsa, yeni tema ile eşleşecek şekilde güncellenir.