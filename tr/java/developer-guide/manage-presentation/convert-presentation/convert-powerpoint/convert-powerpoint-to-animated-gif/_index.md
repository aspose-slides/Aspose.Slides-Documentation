---
title: Java'da PowerPoint Sunumlarını Hareketli GIF'lere Dönüştürme
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
description: "Aspose.Slides for Java ile PowerPoint sunumlarını (PPT, PPTX) kolayca hareketli GIF'lere dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, sadece birkaç kod satırıyla PowerPoint sunumlarını hareketli GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, yaygın olarak desteklenen bir animasyon formatında paylaşmanız gerektiğinde, web sayfalarına, mesajlaşma uygulamalarına veya belgelere gömülebilecek şekilde faydalıdır. Bu makale, bir sunumu varsayılan ayarlarla GIF olarak dışa aktarmayı ve çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/gifoptions/) aracılığıyla yapılandırarak çıktıyı özelleştirmeyi açıklar.

## **Varsayılan Ayarları Kullanarak Sunumları Hareketli GIF'e Dönüştürme**

Bu Java örnek kodu, standart ayarları kullanarak bir sunumu hareketli GIF'e nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Hareketli GIF, varsayılan parametrelerle oluşturulacaktır. 

{{%  alert  title="TIP"  color="info"  %}} 

GIF için parametreleri özelleştirmek isterseniz, [GifOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/GifOptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda bakın. 

{{% /alert %}} 

## **Özel Ayarları Kullanarak Sunumları Hareketli GIF'e Dönüştürme**

Bu örnek kod, Java'da özel ayarları kullanarak bir sunumu hareketli GIF'e nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // oluşturulan GIF'in boyutu  
	gifOptions.setDefaultDelay(2000); // her slaytın bir sonraki slayta geçene kadar ne kadar süre gösterileceği
	gifOptions.setTransitionFps(35); // daha iyi geçiş animasyonu kalitesi için FPS'yi artırın
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose tarafından geliştirilen ÜCRETSİZ bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsüne göz atabilirsiniz. 

{{% /alert %}}

## **SSS**

### Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?

Eksik yazı tiplerini kurun veya [yedek yazı tiplerini yapılandırın](/slides/tr/java/powerpoint-fonts/). Aspose.Slides yerini doldurur, ancak görünüm farklı olabilir. Marka tutarlılığı için gerekli karakter setlerinin açıkça mevcut olduğundan emin olun.

### GIF çerçevelerine bir filigran ekleyebilir miyim?

Evet. Dışa aktarmadan önce ana slayta veya bireysel slaytlara [yarı şeffaf bir nesne/logo ekleyin](/slides/tr/java/watermark/) — filigran her çerçevede görünecektir.