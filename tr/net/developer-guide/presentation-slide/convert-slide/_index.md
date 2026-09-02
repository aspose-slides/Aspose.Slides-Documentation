---
title: ".NET'te Sunum Slaytlarını Görüntülere Dönüştürme"
linktitle: "Slayttan Görüntüye"
type: docs
weight: 41
url: /tr/net/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- slayttan TIFF
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PPT, PPTX ve ODP dosyalarındaki slaytları C# ile Aspose.Slides for .NET kullanarak görüntülere dönüştürün—hızlı, yüksek kaliteli işleme ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğerlerini içeren çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - The [ITiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/itiffoptions/) arayüzü, ya da
    - The [IRenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/irenderingoptions/) arayüzü.
2. Slayt görüntüsünü, [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) metodunu çağırarak oluşturun.

.NET'te, bir [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanıyan bir nesnedir. Bu sınıfın bir örneğini, görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmap'e Dönüştürme ve Görüntüleri PNG Olarak Kaydetme**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, bir slaytı bitmap'e dönüştürüp ardından görüntüyü JPEG veya tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu C# kodu, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından görüntüyü PNG formatında kaydetmeyi gösterir:

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

## **Özel Boyutlarda Slaytları Görüntülere Dönüştürme**

Belirli bir boyutta görüntü elde etmeniz gerekebilir. [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) üzerindeki bir aşırı yükleme kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) bir görüntüye dönüştürebilirsiniz. 

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

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştürme**

Bazı slaytlar not ve yorumlar içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere işlenmesini kontrol etmenizi sağlayan iki arayüz—[ITiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/irenderingoptions/)—sağlar. Her iki arayüz de, bir slaytı görüntüye dönüştürürken not ve yorumların işlenmesini yapılandırmanızı sağlayan `SlidesLayoutOptions` özelliğini içerir.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) sınıfı ile, sonuç görüntüde notlar ve yorumlar için tercih ettiğiniz konumu belirtebilirsiniz.

Bu C# kodu, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Sunum dosyasını yükle.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Render seçeneklerini oluştur.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Notların konumunu ayarla.
            CommentsPosition = CommentsPositions.Right,      // Yorumların konumunu ayarla.
            CommentsAreaWidth = 500,                         // Yorum alanının genişliğini ayarla.
            CommentsAreaColor = Color.AntiqueWhite           // Yorum alanının rengini ayarla.
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

{{% alert title="Not" color="warning" %}} 

Herhangi bir slayt-görüntü dönüşüm sürecinde, notların konumunu belirlemek için [NotesPosition](https://reference.aspose.com/slides/tr/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) özelliği `BottomFull` olarak ayarlanamaz, çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.

{{% /alert %}} 

## **TIFF Seçenekleri Kullanarak Slaytları Görüntülere Dönüştürme**

[ITiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti gibi parametreleri belirlemenize olanak tanıyarak sonuç TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu C# kodu, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah-beyaz bir görüntü üretmek için kullanıldığı bir dönüşüm sürecini gösterir:

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
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Piksel formatını ayarla (siyah ve beyaz).
        DpiX = 300,                                        // Yatay çözünürlüğü ayarla.
        DpiY = 300                                         // Dikey çözünürlüğü ayarla.
    };

    // Slaytı belirtilen seçeneklerle görüntüye dönüştür.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Görüntüyü TIFF formatında kaydet.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Tüm Slaytları Görüntülere Dönüştürme**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenizi sağlar; böylece tüm sunum bir dizi görüntüye dönüşür.

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

## **Renkli Emoji İşleme**

{{% alert title="Not" color="warning" %}} 
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru şekilde işlemek için, sunumda kullanılan emoji yazı tiplerinin dönüştürmeyi yapan sistemde kurulu ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu font yüklü değilse, emojiler çıktı görüntülerinde tek renkli (monokrom) görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların işlenmesini destekliyor mu?**

Hayır, `GetImage` metodu slaytı yalnızca statik bir görüntü olarak kaydeder, animasyonları içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar da normal slaytlar gibi işlenebilir. Sadece işleme döngüsüne dahil edildiğinden emin olun.

**Görseller gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerinin işlenmesini destekler.