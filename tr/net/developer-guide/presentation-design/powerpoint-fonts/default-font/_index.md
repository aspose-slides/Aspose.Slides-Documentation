---
title: .NET'te Varsayılan Sunum Yazı Tiplerini Belirleme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/net/default-font/
keywords:
- varsayılan yazı tipi
- normal yazı tipi
- normal yazı tipi
- Asya yazı tipi
- PDF dışa aktarım
- XPS dışa aktarım
- görüntü dışa aktarım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET için Aspose.Slides'te varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dönüşümünün PDF, XPS ve görüntülere düzgün yapılmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum render edildiğinde kullanılan varsayılan yazı tiplerini belirlemenizi sağlar. Bu, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken kullanışlıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce `LoadOptions` aracılığıyla yapılandırılır.

`DefaultRegularFont` özelliği, normal metin için varsayılan yazı tipini tanımlar, `DefaultAsianFont` ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra, sunum belirtilen yazı tipleri kullanılarak yüklenebilir ve render edilebilir.

## **Sunumu Render Etmek İçin Varsayılan Yazı Tiplerini Kullanma**
Aspose.Slides, sunumu PDF, XPS veya küçük resimlere render ederken varsayılan yazı tipini ayarlamanıza izin verir. Bu makale, DefaultRegularFont ve DefaultAsianFont yazı tiplerini varsayılan olarak nasıl tanımlayacağınızı gösterir. Lütfen aşağıdaki adımları izleyerek Aspose.Slides for .NET API'si ile harici dizinlerden yazı tiplerini yükleyin:

1. LoadOptions bir örnek oluşturun.  
2. DefaultRegularFont'u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullandım.  
3. DefaultAsianFont'u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullandım.  
4. Presentation kullanarak ve yükleme seçeneklerini ayarlayarak sunumu yükleyin.  
5. Şimdi, sonuçları doğrulamak için slayt küçük resmini, PDF ve XPS'i oluşturun.  

Yukarıdakilerin uygulanması aşağıda verilmiştir.

```c#
// Yükleme seçeneklerini kullanarak varsayılan normal ve Asya yazı tiplerini belirtin
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **SSS**

**DefaultRegularFont ve DefaultAsianFont tam olarak neyi etkiler—yalnızca dışa aktarım mı, yoksa küçük resimler, PDF, XPS, HTML ve SVG de mi?**  
Tüm desteklenen çıktıların renderleme işlem hattına katılırlar. Bu, slayt küçük resimlerini, [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [XPS](/slides/tr/net/convert-powerpoint-to-xps/), [rastr görüntüler](/slides/tr/net/convert-powerpoint-to-png/), [HTML](/slides/tr/net/convert-powerpoint-to-html/), ve [SVG](/slides/tr/net/render-a-slide-as-an-svg-image/) içerir, çünkü Aspose.Slides bu hedefler arasında aynı düzen ve glif çözümleme mantığını kullanır.

**Varsayılan yazı tipleri, sadece okumak ve bir PPTX dosyasını render etmeden kaydetmek durumunda uygulanır mı?**  
Hayır. Varsayılan yazı tipleri, metnin ölçülmesi ve çizilmesi gerektiğinde önemlidir. Bir sunumun doğrudan açık‑kaydet işlemi, saklanan yazı tipi akışlarını veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni render eden veya yeniden akışını sağlayan işlemler sırasında devreye girer.

**Kendi yazı tipi klasörlerimi eklersem veya bellekteki yazı tiplerini sağlarsam, varsayılan yazı tipleri seçilirken bunlar dikkate alınır mı?**  
Evet. [Özel yazı tipi kaynakları](/slides/tr/net/custom-font/) motorun kullanabileceği mevcut aile ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [yedekleme kuralı](/slides/tr/net/fallback-font/) önce bu kaynaklara göre çözülür, bu da sunucularda ve konteynerlerde daha güvenilir kapsama sağlar.

**Varsayılan yazı tipleri metin metriklerini (kerning, ilerlemeler) ve dolayısıyla satır sonlarını ve kaydırmayı etkiler mi?**  
Evet. Yazı tipini değiştirmek, glif metriklerini değiştirir ve renderleme sırasında satır sonlarını, kaydırmayı ve sayfalama işlemini etkileyebilir. Düzen istikrarı için, [orijinal yazı tiplerini gömün](/slides/tr/net/embedded-font/) veya metrik olarak uyumlu varsayılan ve yedek aileleri seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**  
Genellikle gerekli değildir, çünkü [gömülü yazı tipleri](/slides/tr/net/embedded-font/) zaten tutarlı bir görünüm sağlar. Varsayılan yazı tipleri, gömülü alt küme tarafından kapsanmayan karakterler için veya bir dosyanın gömülü ve gömülmemiş metinleri karıştırdığı durumlarda bir güvenlik ağı olarak hâlâ yardımcı olur.