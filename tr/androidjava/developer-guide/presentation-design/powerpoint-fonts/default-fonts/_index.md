---
title: Android için Varsayılan Sunum Yazı Tiplerini Belirleme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/androidjava/default-font/
keywords:
- varsayılan yazı tipi
- normal yazı tipi
- normal yazı tipi
- Asya yazı tipi
- PDF dışa aktarımı
- XPS dışa aktarımı
- görsel dışa aktarımı
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java üzerinden Android için Aspose.Slides'te varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görsellere doğru bir şekilde dönüştürülmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum renderlendiğinde kullanılan varsayılan yazı tiplerini belirtmenizi sağlar. Bu, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi biçimlere dışa aktarırken kullanışlıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce `LoadOptions` aracılığıyla yapılandırılır.

`setDefaultRegularFont` yöntemi normal metin için varsayılan yazı tipini tanımlar, `setDefaultAsianFont` ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra sunum, belirtilen yazı tipleri kullanılarak yüklenip renderlanabilir.

## **Sunumu Renderlamak İçin Varsayılan Yazı Tiplerini Kullanma**
Aspose.Slides, sunumu PDF, XPS ya da küçük resimlere renderlamak için varsayılan yazı tipini ayarlamanıza olanak tanır. Bu makale, DefaultRegular Font ve DefaultAsian Font'un varsayılan yazı tipi olarak nasıl tanımlanacağını gösterir. Lütfen aşağıdaki adımları takip ederek Aspose.Slides for Android via Java API kullanarak dış dizinlerden yazı tiplerini yükleyin:

1. Bir [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LoadOptions) örneği oluşturun.
2. [DefaultRegularFont'u Ayarla](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) istediğiniz yazı tipine. Aşağıdaki örnekte Wingdings kullandım.
3. [DefaultAsianFont'u Ayarla](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) istediğiniz yazı tipine. Aşağıdaki örnekte Wingdings kullandım.
4. Sunumu Presentation kullanarak ve yükleme seçeneklerini ayarlayarak yükleyin.
5. Şimdi, sonuçları doğrulamak için slayt küçük resmini, PDF ve XPS'yi oluşturun.

Yukarıdakinin uygulaması aşağıda verilmiştir.

```java
// Varsayılan normal ve Asya yazı tiplerini tanımlamak için yükleme seçeneklerini kullanın
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Sunumu yükle
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Slayt küçük resmini oluştur
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

**DefaultRegularFont ve DefaultAsianFont tam olarak neyi etkiler—sadece dışa aktarımı mı, yoksa küçük resimleri, PDF, XPS, HTML ve SVG'yi de mi?**

Tüm desteklenen çıktılar için renderleme hattına katılırlar. Bu, slayt küçük resimlerini, [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/tr/androidjava/convert-powerpoint-to-xps/), [raster görüntüler](/slides/tr/androidjava/convert-powerpoint-to-png/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/), ve [SVG](/slides/tr/androidjava/render-a-slide-as-an-svg-image/) içerir, çünkü Aspose.Slides bu hedefler arasında aynı yerleşim ve glif çözümleme mantığını kullanır.

**Temel olarak bir PPTX'i sadece okuyup kaydederken varsayılan yazı tipleri uygulanıyor mu?**

Hayır. Varsayılan yazı tipleri, metnin ölçülmesi ve çizilmesi gerektiğinde önemlidir. Bir sunumun doğrudan açık‑kaydet işlemi, saklanan yazı tipi koşullarını veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni renderlayan veya yeniden akışını sağlayan işlemlerde devreye girer.

**Kendi yazı tipi klasörlerimi eklersem veya bellekteki yazı tiplerini sağlarsam, varsayılan yazı tipleri seçilirken bunlar dikkate alınır mı?**

Evet. [Özel yazı tipi kaynakları](/slides/tr/androidjava/custom-font/) motorun kullanabileceği mevcut aile ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [geri dönüş kuralları](/slides/tr/androidjava/fallback-font/) önce bu kaynaklara bakarak çözülür, böylece sunucularda ve konteynerlerde daha güvenilir bir kapsama sağlanır.

**Varsayılan yazı tipleri metin ölçümlerini (kerning, ilerlemeler) ve dolayısıyla satır sonlarını ve kaydırmayı etkiler mi?**

Evet. Yazı tipini değiştirmek glif ölçümlerini değiştirir ve renderleme sırasında satır sonlarını, kaydırmayı ve sayfalama düzenini etkileyebilir. Düzen kararlılığı için, [orijinal yazı tiplerini gömün](/slides/tr/androidjava/embedded-font/) ya da ölçüsel olarak uyumlu varsayılan ve geri dönüş ailelerini seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**

Genellikle gerekli değildir, çünkü [gömülü yazı tipleri](/slides/tr/androidjava/embedded-font/) zaten tutarlı bir görünüm sağlar. Varsayılan yazı tipleri, gömülü alt küme tarafından kapsanmayan karakterler veya dosyanın hem gömülü hem de gömülmemiş metin karışımı içermesi durumunda bir güvenlik ağı olarak hâlâ yardımcı olur.