---
title: Android'de PowerPoint Sunumlarını Animasyonlu GIF'lere Dönüştürme
linktitle: PowerPoint'ten GIF'e
type: docs
weight: 65
url: /tr/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- animasyonlu GIF
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten GIF'e
- sunumdan GIF'e
- slayttan GIF'e
- PPT'den GIF'e
- PPTX'den GIF'e
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden PowerPoint sunumlarını (PPT, PPTX) animasyonlu GIF'lere kolayca dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, sadece birkaç kod satırıyla PowerPoint sunumlarını animasyonlu GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, geniş çapta desteklenen bir animasyonlu formatta paylaşmanız ve web sayfalarına, mesajlaşma uygulamalarına veya belgelere gömebilmeniz gerektiğinde faydalıdır. Bu makale, bir sunumu GIF olarak varsayılan ayarlarla dışa aktarmanın ve çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/gifoptions/) üzerinden yapılandırarak çıktıyı özelleştirmenin nasıl yapılacağını açıklar.

## **Varsayılan Ayarları Kullanarak Sunumları Animasyonlu GIF'e Dönüştürme**

Bu Java örnek kodu, standart ayarları kullanarak bir sunumu animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


Animasyonlu GIF, varsayılan parametrelerle oluşturulacaktır. 

{{%  alert  title="İPUCU"  color="info"  %}} 

GIF parametrelerini özelleştirmek isterseniz, [GifOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GifOptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda bakın.

{{% /alert %}} 

## **Özel Ayarları Kullanarak Sunumları Animasyonlu GIF'e Dönüştürme**

Bu örnek kod, Java'da özel ayarlar kullanarak bir sunumu animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // oluşturulan GIF'in boyutu
	gifOptions.setDefaultDelay(2000); // her slaytın bir sonraki slayta geçene kadar gösterileceği süre
	gifOptions.setTransitionFps(35); // geçiş animasyon kalitesini artırmak için FPS'i yükselt
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}

Aspose tarafından geliştirilen ÜCRETSİZ bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüyü incelemek isteyebilirsiniz. 

{{% /alert %}}

## **SSS**

### Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?

Eksik yazı tiplerini yükleyin veya [fallback yazı tiplerini yapılandırın](/slides/tr/androidjava/powerpoint-fonts/). Aspose.Slides yerini alacaktır, ancak görünüm farklılık gösterebilir. Markalaşma için gerekli tipografilerin kesinlikle bulunabilir olduğundan emin olun.

### GIF çerçevelerine bir filigran ekleyebilir miyim?

Evet. Dışa aktarmadan önce ana slayta veya bireysel slaytlara [yarı saydam bir nesne/logo](/slides/tr/androidjava/watermark/) ekleyin — filigran her çerçevede görünecektir.