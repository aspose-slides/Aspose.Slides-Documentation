---
title: PowerPoint Sunumlarını .NET'te Hareketli GIF'lere Dönüştürme
linktitle: PowerPoint'ten GIF
type: docs
weight: 65
url: /tr/net/convert-powerpoint-to-animated-gif/
keywords:
- hareketli GIF
- PowerPoint dönüştürme
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten GIF'e
- sunumu GIF'e
- slaytı GIF'e
- PPT'den GIF'e
- PPTX'den GIF'e
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarını (PPT, PPTX) kolayca hareketli GIF'lere dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, birkaç satır kodla PowerPoint sunumlarını hareketli GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, yaygın olarak desteklenen bir hareketli formatta paylaşmanız gerektiğinde ve bu formatın web sayfalarına, mesajlaşma uygulamalarına veya belgelere gömülebilmesi durumunda kullanışlıdır. Bu makale, bir sunumu GIF olarak varsayılan ayarlarla dışa aktarmanın yanı sıra, kare boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/gifoptions/) kullanarak yapılandırarak çıktıyı nasıl özelleştireceğinizi açıklar.

## **Sunumları Varsayılan Ayarlarla Hareketli GIF'e Dönüştürme**

C# örnek kodu, bir sunumu standart ayarlarla hareketli GIF'e nasıl dönüştüreceğinizi gösterir:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Hareketli GIF, varsayılan parametrelerle oluşturulacaktır.

{{%  alert  title="TIP"  color="primary"  %}} 
GIF parametrelerini özelleştirmek isterseniz, [GifOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/gifoptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda bakın. 
{{% /alert %}} 

## **Sunumları Özel Ayarlarla Hareketli GIF'e Dönüştürme**

C#'ta özel ayarlarla bir sunumu hareketli GIF'e nasıl dönüştüreceğinizi gösteren örnek kod:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // oluşturulan GIF'in boyutu
        DefaultDelay = 2000, // her slaytın bir sonraki slayta geçene kadar gösterileceği süre
        TransitionFps = 35 // geçiş animasyonu kalitesini artırmak için FPS'i artırın
    });
}
```

{{% alert title="Info" color="info" %}}
Aspose tarafından geliştirilen ÜCRETSİZ bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsüne göz atmak isteyebilirsiniz. 
{{% /alert %}}

## **SSS**

**Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?**

Eksik yazı tiplerini yükleyin ya da [fallback yazı tiplerini yapılandırın](/slides/tr/net/powerpoint-fonts/). Aspose.Slides yerine koyma yapacaktır, ancak görünüm farklılık gösterebilir. Markalaşma için, gerekli tipografilerin kesinlikle mevcut olduğundan emin olun.

**GIF karelerine bir filigran ekleyebilir miyim?**

Evet. Dışa aktarmadan önce ana slayta ya da bireysel slaytlara [yarı saydam bir nesne/logo ekleyin](/slides/tr/net/watermark/) — filigran her karede görünecektir.