---
title: Java’da Varsayılan Sunum Yazı Tiplerini Belirleme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/java/default-font/
keywords:
- varsayılan yazı tipi
- normal yazı tipi
- normal yazı tipi
- asya yazı tipi
- PDF dışa aktarım
- XPS dışa aktarım
- görüntü dışa aktarım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides'te varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görüntülere doğru bir şekilde dönüştürülmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum oluşturulurken kullanılan varsayılan yazı tiplerini belirlemenizi sağlar. Bu, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken faydalıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce `LoadOptions` aracılığıyla yapılandırılır.

`setDefaultRegularFont` yöntemi normal metin için varsayılan yazı tipini, `setDefaultAsianFont` yöntemi ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra sunum, belirtilen yazı tipleri kullanılarak yüklenebilir ve işlenebilir.

## **Bir Sunumu İşlemek İçin Varsayılan Yazı Tiplerini Kullanma**
Aspose.Slides, sunumu PDF, XPS veya küçük resimler olarak işlerken varsayılan yazı tipini ayarlamanıza izin verir. Bu makale, DefaultRegularFont ve DefaultAsianFont’un nasıl tanımlanacağını gösterir. Lütfen Aspose.Slides for Java API’sını kullanarak dış dizinlerden yazı tiplerini yüklemek için aşağıdaki adımları izleyin:

1. [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LoadOptions) bir örneği oluşturun.
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) değerini istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullandım.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) değerini istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte de Wingdings kullandım.
1. Sunumu Presentation ile yükleyin ve yükleme seçeneklerini ayarlayın.
1. Şimdi, sonuçları doğrulamak için slayt küçük resmi, PDF ve XPS oluşturun.

Yukarıdakilerin uygulaması aşağıda verilmiştir.

```java
// Varsayılan normal ve Asya yazı tiplerini tanımlamak için yükleme seçeneklerini kullanın
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Sunumu yükle
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Slayt küçük resmi oluştur
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // resmi diske kaydet.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDF oluştur
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPS oluştur
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**DefaultRegularFont ve DefaultAsianFont tam olarak neyi etkiler—yalnızca dışa aktarımı mı, yoksa küçük resimleri, PDF, XPS, HTML ve SVG’yi de mi?**

Tüm desteklenen çıktılar için işleme hattına katılırlar. Bu, slayt küçük resimleri, [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/java/convert-powerpoint-to-xps/), [raster görüntüler](/slides/tr/java/convert-powerpoint-to-png/), [HTML](/slides/tr/java/convert-powerpoint-to-html/), ve [SVG](/slides/tr/java/render-a-slide-as-an-svg-image/) dahil olmak üzere Aspose.Slides’ın bu hedeflerde aynı yerleşim ve glif çözümleme mantığını kullandığı anlamına gelir.

**Sadece bir PPTX dosyasını okuyup kaydederken varsayılan yazı tipleri uygulanır mı?**

Hayır. Varsayılan yazı tipleri, metnin ölçülmesi ve çizilmesi gerektiğinde önem kazanır. Sunumun doğrudan açılıp kaydedilmesi, depolanan yazı tipi akışlarını veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni işleyen veya yeniden düzenleyen işlemler sırasında devreye girer.

**Kendi yazı tipi klasörlerimi ekler ya da yazı tiplerini bellekte sağlarım, varsayılan yazı tiplerini seçerken bunlar dikkate alınır mı?**

Evet. [Custom font sources](/slides/tr/java/custom-font/) mevcut aile ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [fallback rule](/slides/tr/java/fallback-font/) önce bu kaynaklara bakar, bu da sunucularda ve kapsayıcılarda daha güvenilir kapsama sağlar.

**Varsayılan yazı tipleri metin ölçümlerini (kerning, avanceler) ve dolayısıyla satır sonlarını ve sarma işlemlerini etkiler mi?**

Evet. Yazı tipini değiştirmek glif ölçümlerini değiştirir ve işleme sırasında satır sonlarını, sarma ve sayfalama davranışını etkileyebilir. Yerleşim stabilitesi için [embed the original fonts](/slides/tr/java/embedded-font/) veya metrik olarak uyumlu varsayılan ve yedek aileler seçilmelidir.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**

Genellikle gerekmez, çünkü [embedded fonts](/slides/tr/java/embedded-font/) zaten tutarlı bir görünüm sağlar. Ancak gömülü alt küme tarafından kapsanmayan karakterler veya gömülü ve gömülmemiş metin karışımı olduğunda varsayılan yazı tipleri bir güvenlik ağı işlevi görür.