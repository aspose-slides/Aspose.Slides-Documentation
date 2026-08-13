---
title: PowerPoint Sunumlarını .NET'te Animasyonlu GIF'lere Dönüştürme
linktitle: PowerPoint'tan GIF
type: docs
weight: 65
url: /tr/net/convert-powerpoint-to-animated-gif/
keywords:
- animasyonlu GIF
- PowerPoint dönüştürme
- sunum dönüştürme
- slayt dönüştürme
- PPT dönüştürme
- PPTX dönüştürme
- PowerPoint'tan GIF
- sunumdan GIF
- slayttan GIF
- PPT'den GIF
- PPTX'den GIF
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarını (PPT, PPTX) animasyonlu GIF'lere kolayca dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarını sadece birkaç kod satırıyla animasyonlu GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, geniş kitle tarafından desteklenen bir animasyon biçiminde paylaşmanız gerektiğinde, web sayfalarına, mesajlaşma uygulamalarına veya belgelerinize gömülebilir. Bu makale, bir sunumu varsayılan ayarlarla GIF olarak dışa aktarmayı ve çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/gifoptions/) ile yapılandırarak çıktıyı özelleştirmeyi açıklar.

## **Sunumları Varsayılan Ayarlarla Animasyonlu GIF'e Dönüştürme**

C# içinde bu örnek kod, bir sunumu standart ayarlarla animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Animasyonlu GIF, varsayılan parametrelerle oluşturulacaktır. 

{{% alert title="İPUCU" color="info" %}} 
GIF için parametreleri özelleştirmek isterseniz, [GifOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/gifoptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek kodu inceleyin. 
{{% /alert %}} 

## **Sunumları Özel Ayarlarla Animasyonlu GIF'e Dönüştürme**

Bu örnek kod, bir sunumu C# içinde özel ayarlarla animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // oluşan GIF'in boyutu  
        DefaultDelay = 2000, // her slaytın bir sonraki slayta geçmeden önce ne kadar süre gösterileceği
        TransitionFps = 35 // daha iyi geçiş animasyonu kalitesi için FPS'yi artırın
    });
}
```

{{% alert title="Bilgi" color="info" %}} 
Ücretsiz bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüye göz atmak isteyebilirsiniz; bu araç Aspose tarafından geliştirilmiştir. 
{{% /alert %}}

## **SSS**

### Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?

Eksik yazı tiplerini yükleyin veya [yedek yazı tiplerini yapılandır](/slides/tr/net/powerpoint-fonts/). Aspose.Slides yerine koyma yapar, ancak görünüm farklılık gösterebilir. Marka tutarlılığı için gereken tipografilerin kesinlikle mevcut olduğundan emin olun.

### GIF çerçevelerine filigran ekleyebilir miyim?

Evet. [Yarı saydam bir nesne/logo ekle](/slides/tr/net/watermark/) ana slayta ya da dışa aktarım öncesinde bireysel slaytlara ekleyin — filigran her çerçevede görünecektir.