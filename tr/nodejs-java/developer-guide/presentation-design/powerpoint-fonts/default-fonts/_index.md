---
title: JavaScript'te Varsayılan Sunum Yazı Tiplerini Belirleme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/nodejs-java/default-font/
keywords:
- varsayılan yazı tipi
- normal yazı tipi
- standart yazı tipi
- asya yazı tipi
- PDF dışa aktarımı
- XPS dışa aktarımı
- görüntü dışa aktarımı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'ta Java aracılığıyla varsayılan yazı tiplerini ayarlayın; bu sayede PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görüntülere doğru şekilde dönüştürülmesini sağlar."
---
## **Genel Bakış**

Aspose.Slides, bir sunum oluşturulduğunda kullanılan varsayılan yazı tiplerini belirlemenizi sağlar. Bu, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken faydalıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce `LoadOptions` aracılığıyla yapılandırılır.

`setDefaultRegularFont` yöntemi normal metin için varsayılan yazı tipini tanımlarken, `setDefaultAsianFont` Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra, sunum belirtilen yazı tipleriyle yüklenip oluşturulabilir.

## **Sunumu Oluştururken Varsayılan Yazı Tiplerini Kullanma**
Aspose.Slides, sunumu PDF, XPS veya küçük resimlere dönüştürürken kullanılacak varsayılan yazı tipini ayarlamanıza izin verir. Bu makale, DefaultRegularFont ve DefaultAsianFont’un varsayılan yazı tipi olarak nasıl tanımlanacağını gösterir. Aşağıdaki adımları izleyerek Aspose.Slides for Node.js via Java API ile harici dizinlerden yazı tipleri yükleyin:

1. Bir [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/LoadOptions) örneği oluşturun.
2. [DefaultRegularFont'ı ayarlayın](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) istediğiniz yazı tipine. Aşağıdaki örnekte Wingdings kullandım.
3. [DefaultAsianFont'ı ayarlayın](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) istediğiniz yazı tipine. Aşağıdaki örnekte de Wingdings kullandım.
4. Sunumu `Presentation` ile yükleyin ve yükleme seçeneklerini ayarlayın.
5. Şimdi slayt küçük resmi, PDF ve XPS oluşturup sonuçları doğrulayın.

Yukarıdaki uygulama aşağıda gösterilmiştir.

```javascript
// Yükleme seçeneklerini kullanarak varsayılan normal ve asya yazı tiplerini tanımlayın
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Sunumu yükle
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Slayt küçük resmi oluştur
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // Görüntüyü diske kaydet.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // PDF oluştur
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // XPS oluştur
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**DefaultRegularFont ve DefaultAsianFont tam olarak neyi etkiler—sadece dışa aktarma mı, yoksa küçük resimler, PDF, XPS, HTML ve SVG de mi?**

Bu yazı tipleri, desteklenen tüm çıktılar için oluşturma işlem hattına katılır. Bu, slayt küçük resimleri, [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/nodejs-java/convert-powerpoint-to-xps/), [raster görüntüler](/slides/tr/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/) ve [SVG](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/) dahil olmak üzere tüm hedeflerde aynı düzen ve glif çözümleme mantığını kullanan Aspose.Slides için geçerlidir.

**Bir PPTX dosyasını yalnızca okuma ve kaydetme işlemi yaparken varsayılan yazı tipleri uygulanır mı?**

Hayır. Varsayılan yazı tipleri, metnin ölçülüp çizilmesi gerektiğinde devreye girer. Sunumun sadece açık‑kaydet işlemi, depolanan yazı tipi dizilerini veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni oluşturma veya yeniden akışa sokma gibi işlemler sırasında kullanılır.

**Kendi yazı tipi klasörlerimi eklersem ya da yazı tiplerini bellekten sağlarsam, varsayılan yazı tipleri seçiminde dikkate alınır mı?**

Evet. [Özel yazı tipi kaynakları](/slides/tr/nodejs-java/custom-font/) motorun kullanabileceği aile ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [yedekleme kuralı](/slides/tr/nodejs-java/fallback-font/) bu kaynaklara öncelikle bakar; bu da sunucularda ve konteynerlerde daha güvenilir kapsama sağlar.

**Varsayılan yazı tipleri metin ölçümlerini (kerning, ilerlemeler) ve dolayısıyla satır sonlarını ve sarmalamayı etkiler mi?**

Evet. Yazı tipini değiştirmek glif ölçümlerini değiştirir ve oluşturma sırasında satır sonları, sarmalama ve sayfalama üzerinde etkili olur. Düzeni korumak için [orijinal yazı tiplerini gömün](/slides/tr/nodejs-java/embedded-font/) veya metrik olarak uyumlu varsayılan ve yedek aileleri seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**

Çoğu zaman gerekli değildir, çünkü [gömülü yazı tipleri](/slides/tr/nodejs-java/embedded-font/) zaten tutarlı bir görünüm sağlar. Ancak gömülü alt küme tarafından kapsanmayan karakterler veya dosyanın gömülü ve gömülü olmayan metin karışımı içermesi durumunda varsayılan yazı tipleri bir güvenlik ağı görevi görür.