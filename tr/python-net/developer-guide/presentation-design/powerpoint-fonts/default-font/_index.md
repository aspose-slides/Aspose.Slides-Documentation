---
title: Python ile Sunumlarda Varsayılan Yazı Tiplerini Özelleştirme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/python-net/default-font/
keywords:
- varsayılan yazı tipi
- düz yazı tipi
- normal yazı tipi
- Asya yazı tipi
- PDF dışa aktarım
- XPS dışa aktarım
- görsel dışa aktarım
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python'da varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görsellere doğru dönüştürülmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum oluşturulduğunda kullanılan varsayılan yazı tiplerini belirtmenizi sağlar. Bu özellik, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken kullanışlıdır. Varsayılan yazı tipleri, sunum yüklemeden önce `LoadOptions` aracılığıyla yapılandırılır.

`default_regular_font` özelliği normal metin için varsayılan yazı tipini, `default_asian_font` ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra sunum, belirtilen yazı tipleriyle yüklenip oluşturulabilir.

## **Sunumu Oluştururken Varsayılan Yazı Tiplerinin Kullanılması**

Aspose.Slides, sunumu PDF, XPS veya küçük resimlere dönüştürürken varsayılan yazı tipini ayarlamanıza olanak tanır. Bu makale, DefaultRegularFont ve DefaultAsianFont’un varsayılan yazı tipleri olarak nasıl tanımlanacağını gösterir. Aspose.Slides for Python via .NET API’sini kullanarak dış dizinlerden yazı tiplerini yüklemek için aşağıdaki adımları izleyin:

1. Bir LoadOptions örneği oluşturun.  
2. DefaultRegularFont’u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullanılmıştır.  
3. DefaultAsianFont’u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte yine Wingdings kullanılmıştır.  
4. Presentation ile sunumu yükleyin ve yükleme seçeneklerini ayarlayın.  
5. Şimdi slayt küçük resmi, PDF ve XPS oluşturup sonuçları doğrulayın.

Yukarıdaki uygulamanın kodu aşağıda verilmiştir.

```py
import aspose.slides as slides

# Load seçeneklerini kullanarak varsayılan normal ve Asian yazı tiplerini tanımla# Load seçeneklerini kullanarak varsayılan normal ve Asian yazı tiplerini tanımla
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Sunumu yükle
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Slayt küçük resmi oluştur
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF oluştur
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS oluştur
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **SSS**

**default_regular_font ve default_asian_font tam olarak neyi etkiler—sadece dışa aktarımı mı, yoksa küçük resimleri, PDF, XPS, HTML ve SVG’yi de mi?**

Bu ayarlar, desteklenen tüm çıkış formatları için işleme zincirine katılır. Bu, slayt küçük resimlerini, [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/tr/python-net/convert-powerpoint-to-xps/), [raster görüntülerini](/slides/tr/python-net/convert-powerpoint-to-png/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) ve [SVG](/slides/tr/python-net/render-a-slide-as-an-svg-image/) dahil eder; çünkü Aspose.Slides bu hedeflerde aynı yerleşim ve glif çözümleme mantığını kullanır.

**Sadece bir PPTX dosyasını okuma ve kaydetme işlemi sırasında varsayılan yazı tipleri uygulanır mı?**

Hayır. Varsayılan yazı tipleri, metin ölçülüp çizildiğinde devreye girer. Bir sunumun doğrudan açılıp kaydedilmesi, depolanan yazı tipi koşullarını veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni render eden veya yeniden akışa sokan işlemlerde kullanılır.

**Kendi yazı tipi klasörlerimi eklersem veya yazı tiplerini bellekte sağlarsam, varsayılan yazı tipleri seçilirken bunlar dikkate alınır mı?**

Evet. [Custom font sources](/slides/tr/python-net/custom-font/) motorun kullanabileceği yazı tipi ailesi ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [fallback rules](/slides/tr/python-net/fallback-font/) önce bu kaynaklara bakar; bu da sunucularda ve konteynerlerde daha güvenilir kapsama sağlar.

**Varsayılan yazı tipleri metin ölçümlerini (kerning, advance) ve dolayısıyla satır sonlarını ve kaydırma işlemlerini etkiler mi?**

Evet. Yazı tipini değiştirmek glif ölçümlerini değiştirir ve render sırasında satır sonları, kaydırma ve sayfalama üzerinde etkili olabilir. Yerleşim istikrarı için [embed the original fonts](/slides/tr/python-net/embedded-font/) yapın veya metrik olarak uyumlu varsayar ve yedek aileleri seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**

Genellikle gerekmez, çünkü [embedded fonts](/slides/tr/python-net/embedded-font/) zaten tutarlı bir görünüm sağlar. Varsayılan yazı tipleri, gömülü alt küme tarafından kapsanmayan karakterler veya dosyanın gömülü ve gömülmemiş metin karışımı içerdiği durumlarda bir güvenlik ağı görevi görür.