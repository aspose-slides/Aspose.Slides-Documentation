---
title: Java'da PowerPoint Sunumlarını Animasyonlu GIF'lere Dönüştür
linktitle: PowerPoint'ten GIF'e
type: docs
weight: 65
url: /tr/java/convert-powerpoint-to-animated-gif/
keywords:
- animasyonlu GIF
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten GIF'e
- sunumdan GIF'e
- slayttan GIF'e
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarını (PPT, PPTX) animasyonlu GIF'lere kolayca dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarını sadece birkaç satır kodla animasyonlu GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, yaygın olarak desteklenen bir animasyon formatında paylaşmanız ve web sayfalarına, mesajlaşma uygulamalarına veya belgelere gömmeniz gerektiğinde kullanışlıdır. Bu makale, bir sunumu varsayılan ayarlarla GIF olarak dışa aktarmayı ve çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/gifoptions/) aracılığıyla yapılandırarak çıktıyı nasıl özelleştireceğinizi açıklar.

## **Varsayılan Ayarlarla Sunumları Animasyonlu GIF’e Dönüştürme**

Java’da bir sunumu standart ayarlarla animasyonlu GIF’e dönüştürmenizi gösteren örnek kod:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Animasyonlu GIF, varsayılan parametrelerle oluşturulacaktır. 

{{%  alert  title="TIP"  color="primary"  %}} 

GIF için parametreleri özelleştirmek istiyorsanız, [GifOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GifOptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda bakın. 

{{% /alert %}} 

## **Özel Ayarlarla Sunumları Animasyonlu GIF’e Dönüştürme**

Bu örnek kod, bir sunumu Java’da özel ayarlarla animasyonlu GIF’e dönüştürmenizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // oluşturulan GIF'in boyutu
	gifOptions.setDefaultDelay(2000); // her slaytın bir sonraki slayta geçmeden önce ne kadar gösterileceği
	gifOptions.setTransitionFps(35); // geçiş animasyonu kalitesini iyileştirmek için FPS'i artırın
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose tarafından geliştirilen ÜCRETSİZ bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüyü inceleyebilirsiniz. 

{{% /alert %}}

## **SSS**

**Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?**

Eksik yazı tiplerini yükleyin veya [yedek yazı tiplerini yapılandırın](/slides/tr/java/powerpoint-fonts/). Aspose.Slides ikame yapacaktır, ancak görünüm farklılık gösterebilir. Markalaşma için gerekli tiplerin kesinlikle kullanılabilir olduğundan emin olun.

**GIF çerçevelerine bir filigran ekleyebilir miyim?**

Evet. Dışa aktarmadan önce ana slayta veya ayrı ayrı slaytlara [yarı şeffaf bir nesne/logo ekleyin](/slides/tr/java/watermark/) — filigran her çerçevede görünecektir.