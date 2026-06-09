---
title: Sunum Slaytlarını .NET'te Görüntülere Dönüştürme
linktitle: Slayttan Görüntüye
type: docs
weight: 41
url: /tr/net/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan PNG'ye
- slayttan JPEG'e
- slayttan bitmap'e
- slayttan TIFF'e
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak C# ile PPT, PPTX ve ODP dosyalarındaki slaytları görüntülere dönüştürün—hızlı, yüksek kaliteli renderleme ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [ITiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/itiffoptions/) arayüzü, veya
    - [IRenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/irenderingoptions/) arayüzü.
2. Slayt görüntüsünü oluşturmak için [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) metodunu çağırın.

.NET'te, [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanıyan bir nesnedir. Bu sınıfın bir örneğini kullanarak BMP, JPG, PNG vb. çeşitli formatlarda görüntüleri kaydedebilirsiniz.

## **Slaytları Bitmapi'ye Dönüştürmek ve PNG Olarak Görüntüleri Kaydetmek**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, slaytı bitmap'e dönüştürüp ardından görüntüyü JPEG veya tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu C# kodu, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi gösterir:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Sunumdaki ilk slaytı bitmap'e dönüştür.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Görüntüyü PNG formatında kaydet.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Özel Boyutlarla Slaytları Görüntülere Dönüştürmek**

Belirli bir boyutta bir görüntü almanız gerekebilir. [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) metodunun bir aşırı yüklemesini kullanarak bir slaytı belirli boyutlarda (genişlik ve yükseklik) görüntüye dönüştürebilirsiniz. 

Bu örnek kod bunu nasıl yapacağınızı gösterir:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Sunumdaki ilk slaytı belirtilen boyutta bitmap'e dönüştür.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Görüntüyü JPEG formatında kaydet.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Not ve Yorum İçeren Slaytları Görüntülere Dönüştürmek**

Bazı slaytlar not ve yorumlar içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere render edilmesini kontrol etmenizi sağlayan iki arayüz—[ITiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/irenderingoptions/)—sunar. Her iki arayüz de `SlidesLayoutOptions` özelliğini içerir; bu özellik, bir slaytı görüntüye dönüştürürken not ve yorumların render edilmesini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) sınıfı ile sonuç görüntüde not ve yorumların istediğiniz konumunu belirtebilirsiniz.

Bu C# kodu, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Bir sunum dosyası yükle.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Rendering seçeneklerini oluştur.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Notların konumunu ayarla.
            CommentsPosition = CommentsPositions.Right,      // Yorumların konumunu ayarla.
            CommentsAreaWidth = 500,                         // Yorum alanının genişliğini ayarla.
            CommentsAreaColor = Color.AntiqueWhite           // Yorum alanı için rengi ayarla.
        }
    };

    // Sunumun ilk slaytını görüntüye dönüştür.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Görüntüyü GIF formatında kaydet.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

Herhangi bir slayt‑görüntü dönüştürme işleminde, [NotesPosition](https://reference.aspose.com/slides/tr/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) özelliği `BottomFull` (notların konumunu belirlemek için) olarak ayarlanamaz çünkü bir notun metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.

{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştürmek**

[ITiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenizi sağlayarak oluşturulan TIFF görüntüsü üzerinde daha fazla kontrol sunar.

Bu C# kodu, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretmek için kullanıldığı bir dönüştürme sürecini gösterir:

```cs
// Sunum dosyasını yükle.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Sunumdan ilk slaytı al.
    ISlide slide = presentation.Slides[0];

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Görüntü boyutunu ayarla.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Piksel formatını ayarla (siyah beyaz).
        DpiX = 300,                                        // Yatay çözünürlüğü ayarla.
        DpiY = 300                                         // Dikey çözünürlüğü ayarla.
    };

    // Belirtilen seçeneklerle slaytı görüntüye dönüştür.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Görüntüyü TIFF formatında kaydet.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Tüm Slaytları Görüntülere Dönüştürmek**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır; böylece bütün sunum etkili bir şekilde bir dizi görüntüye çevrilir.

Bu örnek kod, bir sunumdaki tüm slaytları C# ile görüntülere nasıl dönüştüreceğinizi gösterir:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Sunumu slayt slayt görüntülere render et.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Gizli slaytları kontrol et (gizli slaytları render etme).
        if (presentation.Slides[i].Hidden)
            continue;

        // Slaytı bir görüntüye dönüştür.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Görüntüyü JPEG formatında kaydet.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **SSS**

**1. Aspose.Slides, animasyonlu slaytların render edilmesini destekliyor mu?**

Hayır, `GetImage` metodu slaytı yalnızca statik bir görüntü olarak kaydeder, animasyonlar dahil edilmez.

**2. Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar da normal slaytlar gibi işlenebilir. İşleme döngüsünde yer aldıklarından emin olun.

**3. Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerinin render edilmesini destekler.