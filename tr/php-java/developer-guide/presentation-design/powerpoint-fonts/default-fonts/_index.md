---
title: PHP'de Varsayılan Sunum Yazı Tiplerini Belirtme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/php-java/default-font/
keywords:
- varsayılan yazı tipi
- düzenli yazı tipi
- normal yazı tipi
- Asya yazı tipi
- PDF dışa aktarımı
- XPS dışa aktarımı
- görsel dışa aktarımı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides'de varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görsellere doğru şekilde dönüştürülmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum render edildiğinde kullanılan varsayılan yazı tiplerini belirlemenizi sağlar. Bu, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken faydalıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce `LoadOptions` aracılığıyla yapılandırılır.

`setDefaultRegularFont` yöntemi, normal metin için varsayılan yazı tipini tanımlar, `setDefaultAsianFont` ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra sunum, belirtilen yazı tipleriyle yüklenebilir ve render edilebilir.

## **Sunumu Renderlemek İçin Varsayılan Yazı Tiplerini Kullanma**
Aspose.Slides, sunumu PDF, XPS veya küçük resimlere renderlerken varsayılan yazı tipini ayarlamanıza olanak tanır. Bu makale, DefaultRegularFont ve DefaultAsianFont'ı varsayılan yazı tipleri olarak nasıl tanımlayacağınızı gösterir. Lütfen aşağıdaki adımları izleyerek Aspose.Slides for PHP via Java API kullanarak dış dizinlerden yazı tiplerini yükleyin:

1. Bir [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LoadOptions) örneği oluşturun.
1. [DefaultRegularFont'u ayarlayın](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) istediğiniz yazı tipine. Aşağıdaki örnekte Wingdings kullandım.
1. [DefaultAsianFont'u ayarlayın](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) istediğiniz yazı tipine. Aşağıdaki örnekte Wingdings kullandım.
1. Presentation sınıfını ve ayarlanan load seçeneklerini kullanarak sunumu yükleyin.
1. Şimdi, slayt küçük resmi, PDF ve XPS oluşturup sonuçları doğrulayın.

Yukarıdakinin uygulaması aşağıda verilmiştir.

```php
  # Yükleme seçeneklerini kullanarak varsayılan düzenli ve Asya yazı tiplerini tanımla
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Sunumu yükle
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Slayt küçük resmi oluştur
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # görüntüyü diske kaydet.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # PDF oluştur
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # XPS oluştur
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**DefaultRegularFont ve DefaultAsianFont tam olarak neyi etkiler—sadece dışa aktarımı mı, yoksa küçük resimler, PDF, XPS, HTML ve SVG'yi de mi?**

Desteklenen tüm çıktıların renderleme işlem hattına katılırlar. Bu, slayt küçük resimlerini, [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/php-java/convert-powerpoint-to-xps/), [raster görüntüler](/slides/tr/php-java/convert-powerpoint-to-png/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/), ve [SVG](/slides/tr/php-java/render-a-slide-as-an-svg-image/) içerir, çünkü Aspose.Slides bu hedeflerde aynı düzen ve glif çözümleme mantığını kullanır.

**Varsayılan yazı tipleri, yalnızca okuma ve kaydetme işlemi sırasında, herhangi bir renderleme yapılmadan PPTX üzerine uygulanır mı?**

Hayır. Varsayılan yazı tipleri, metin ölçülüp çizilmesi gerektiğinde önemlidir. Bir sunumun doğrudan açılıp kaydedilmesi, depolanan yazı tipi düzenlerini veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni renderleyen veya yeniden akışa sokan işlemlerde devreye girer.

**Kendi yazı tipi klasörlerimi eklersem ya da bellekteki yazı tiplerini sağlarsam, varsayılan yazı tipleri seçilirken bunlar dikkate alınır mı?**

Evet. [Özel yazı tipi kaynakları](/slides/tr/php-java/custom-font/) motorun kullanabileceği mevcut aile ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [yedekleme kuralı](/slides/tr/php-java/fallback-font/) önce bu kaynaklara göre çözülür, sunucularda ve konteynerlerde daha güvenilir kapsama sağlar.

**Varsayılan yazı tipleri metin ölçümlerini (kerning, ilerlemeler) ve dolayısıyla satır sonlarını ve kaydırmayı etkiler mi?**

Evet. Yazı tipini değiştirmek glif ölçümlerini değiştirir ve renderleme sırasında satır sonlarını, kaydırmayı ve sayfalama işlemlerini etkileyebilir. Düzen istikrarı için, [orijinal yazı tiplerini gömün](/slides/tr/php-java/embedded-font/) ya da metrik olarak uyumlu varsayılan ve yedek aileleri seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**

Genellikle gerekli değildir, çünkü [gömülü yazı tipleri](/slides/tr/php-java/embedded-font/) zaten tutarlı bir görünüm sağlar. Varsayılan yazı tipleri, gömülü alt küme tarafından kapsanmayan karakterler veya bir dosyanın gömülü ve gömülmemiş metinleri karıştırdığı durumlarda bir güvenlik ağı olarak hâlâ yardımcı olur.