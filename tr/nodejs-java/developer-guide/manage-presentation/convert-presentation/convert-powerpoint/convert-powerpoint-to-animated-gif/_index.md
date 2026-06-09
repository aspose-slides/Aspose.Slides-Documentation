---
title: PowerPoint Sunumlarını JavaScript'te Animasyonlu GIF'lere Dönüştürme
linktitle: PowerPoint'tan GIF'e
type: docs
weight: 65
url: /tr/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- animasyonlu GIF
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan GIF'e
- sunumu GIF'e
- slaytı GIF'e
- PPT'den GIF'e
- PPTX'ten GIF'e
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ile Aspose.Slides for Node.js kullanarak PowerPoint sunumlarını (PPT, PPTX) kolayca animasyonlu GIF'lere dönüştürün. Hızlı, yüksek kalitede sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, sadece birkaç satır kodla PowerPoint sunumlarını animasyonlu GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, yaygın olarak desteklenen ve web sayfalarına, mesajlaşma uygulamalarına veya belgeler içinde gömülebilen bir formatta paylaşmanız gerektiğinde faydalıdır. Bu makale, bir sunumu varsayılan ayarlarla GIF olarak dışa aktarmayı ve çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/gifoptions/) aracılığıyla yapılandırarak çıktıyı özelleştirmeyi açıklar.

## **Varsayılan Ayarlarla Sunumları Animasyonlu GIF'e Dönüştürme**

Bu JavaScript örnek kodu, standart ayarlarla bir sunumu animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Animasyonlu GIF, varsayılan parametrelerle oluşturulacaktır. 

{{%  alert  title="TIP"  color="primary"  %}} 
GIF için parametreleri özelleştirmek istediğinizde, [GifOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GifOptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda göz atın. 
{{% /alert %}} 

## **Özel Ayarlarla Sunumları Animasyonlu GIF'e Dönüştürme**

Bu örnek kod, JavaScript'te özel ayarları kullanarak bir sunumu animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// oluşturulan GIF'in boyutu
    gifOptions.setDefaultDelay(2000);// her bir slaydın bir sonraki slayda geçmeden önce ne kadar süre gösterileceği
    gifOptions.setTransitionFps(35);// daha iyi geçiş animasyonu kalitesi için FPS'yi artırın
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose tarafından geliştirilen ücretsiz bir [Metni GIF'e Çevirici](https://products.aspose.app/slides/tr/text-to-gif) bulabilirsiniz. 
{{% /alert %}}

## **SSS**

**Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?**

Eksik yazı tiplerini yükleyin veya [yedek yazı tiplerini yapılandırın](/slides/tr/nodejs-java/powerpoint-fonts/). Aspose.Slides bunları değiştirecek, ancak görünüm farklılık gösterebilir. Marka tutarlılığı için gereken yazı tiplerinin sistemde kesin olarak mevcut olduğundan emin olun.

**GIF çerçevelerine bir filigran ekleyebilir miyim?**

Evet. Dışa aktarmadan önce ana slayta veya ayrı ayrı slaytlara [yarı saydam bir nesne/logo ekleyin](/slides/tr/nodejs-java/watermark/) — filigran her çerçevede görünecektir.