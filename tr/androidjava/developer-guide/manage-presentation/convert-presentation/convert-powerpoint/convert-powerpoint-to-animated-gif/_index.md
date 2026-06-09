---
title: "Android'de PowerPoint Sunumlarını Hareketli GIF'lere Dönüştürme"
linktitle: "PowerPoint'ten GIF"
type: docs
weight: 65
url: /tr/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- hareketli GIF
- PowerPoint dönüştürme
- sunum dönüştürme
- slayt dönüştürme
- PPT dönüştürme
- PPTX dönüştürme
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
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides ile PowerPoint sunumlarını (PPT, PPTX) kolayca hareketli GIF'lere dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, birkaç satır kodla PowerPoint sunumlarını hareketli GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, yaygın olarak desteklenen bir animasyon formatında paylaşmanız gerektiğinde, web sayfalarına, mesajlaşma uygulamalarına veya belgelere gömülebilir. Bu makale, bir sunumu varsayılan ayarlarla GIF olarak dışa aktarmayı ve çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/gifoptions/) aracılığıyla yapılandırarak çıktıyı özelleştirmeyi açıklar.

## **Varsayılan Ayarlarla Sunumları Hareketli GIF'e Dönüştürme**

Java'da bu örnek kod, standart ayarlarla bir sunumu hareketli GIF'e nasıl dönüştüreceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Hareketli GIF, varsayılan parametrelerle oluşturulacaktır.

{{%  alert  title="TIP"  color="primary"  %}} 
Eğer GIF için parametreleri özelleştirmek isterseniz, [GifOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/GifOptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda bakın.
{{% /alert %}} 

## **Özel Ayarlarla Sunumları Hareketli GIF'e Dönüştürme**

Bu örnek kod, Java'da özel ayarlarla bir sunumu hareketli GIF'e nasıl dönüştüreceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // oluşan GIF'in boyutu  
	gifOptions.setDefaultDelay(2000); // her slaytın bir sonraki slayta geçene kadar ne kadar gösterileceği
	gifOptions.setTransitionFps(35); // geçiş animasyonu kalitesini artırmak için FPS'i yükselt
	
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

Eksik yazı tiplerini yükleyin veya [fallback yazı tiplerini yapılandırın](/slides/tr/androidjava/powerpoint-fonts/). Aspose.Slides yerine koyma yapar, ancak görünüm farklılık gösterebilir. Markalaşma için gerekli tipografinin açıkça mevcut olduğundan emin olun.

**GIF çerçevelerine bir filigran ekleyebilir miyim?**

Evet. Dışa aktarmadan önce ana slayta veya ayrı ayrı slaytlara [yarı saydam bir nesne/logo ekleyin](/slides/tr/androidjava/watermark/) — filigran her çerçevenin üzerine yerleştirilecektir.