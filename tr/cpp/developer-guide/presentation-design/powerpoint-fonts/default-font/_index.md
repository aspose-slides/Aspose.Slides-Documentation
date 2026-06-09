---
title: C++'ta Varsayılan Sunum Yazı Tiplerini Belirleyin
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/cpp/default-font/
keywords:
- varsayılan yazı tipi
- normal yazı tipi
- normal yazı tipi
- Asya yazı tipi
- PDF dışa aktarım
- XPS dışa aktarım
- görsel dışa aktarım
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görsellere doğru bir şekilde dönüştürülmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum render edildiğinde kullanılan varsayılan yazı tiplerini belirtmenizi sağlar. Bu, slayt önizlemeleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken kullanışlıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce `LoadOptions` aracılığıyla yapılandırılır.

`set_DefaultRegularFont` yöntemi, normal metin için varsayılan yazı tipini tanımlar, `set_DefaultAsianFont` ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra, sunum belirtilen yazı tipleri kullanılarak yüklenip render edilebilir.

## **Sunumu Render Etmek İçin Varsayılan Yazı Tiplerini Kullanma**
Aspose.Slides, sunumu PDF, XPS veya önizlemeler olarak render etmek için varsayılan yazı tipini ayarlamanıza olanak tanır. Bu makale, DefaultRegular Font ve DefaultAsian Font'un varsayılan yazı tipleri olarak nasıl tanımlanacağını gösterir. Lütfen Aspose.Slides for C++ API'sını kullanarak dış dizinlerden yazı tiplerini yüklemek için aşağıdaki adımları izleyin:

1. LoadOptions bir örnek oluşturun.  
1. DefaultRegularFont'u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullandım.  
1. DefaultAsianFont'u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullandım.  
1. Sunumu Presentation kullanarak ve yükleme seçeneklerini ayarlayarak yükleyin.  
1. Şimdi, sonuçları doğrulamak için slayt önizlemesini, PDF ve XPS'i oluşturun.

Yukarıdakinin uygulanması aşağıda verilmiştir.

```cpp
// Yükleme seçeneklerini kullanarak varsayılan normal ve Asya yazı tiplerini belirtin
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **SSS**

**DefaultRegularFont ve DefaultAsianFont tam olarak neyi etkiler—yalnızca dışa aktarmayı mı, yoksa önizlemeleri, PDF, XPS, HTML ve SVG'yi de mi?**

Tüm desteklenen çıktılar için renderleme hattına katılırlar. Bu, slayt önizlemelerini, [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/tr/cpp/convert-powerpoint-to-xps/), [Raster görüntüler](/slides/tr/cpp/convert-powerpoint-to-png/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/), ve [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/) içerir, çünkü Aspose.Slides bu hedeflerde aynı yerleşim ve glif çözümleme mantığını kullanır.

**Varsayılan yazı tipleri, sadece bir PPTX dosyasını okuma ve kaydetme işleminde, herhangi bir renderleme yapılmadan uygulanır mı?**

Hayır. Varsayılan yazı tipleri, metnin ölçülmesi ve çizilmesi gerektiğinde önem taşır. Bir sunumun doğrudan açılıp kaydedilmesi, saklanan yazı tipi dizilerini veya dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni render eden veya yeniden akışını sağlayan işlemler sırasında devreye girer.

**Kendi yazı tipi klasörlerimi eklersem veya bellekten yazı tipleri sağlarsam, varsayılan yazı tipleri seçilirken bunlar dikkate alınır mı?**

Evet. [Özel yazı tipi kaynakları](/slides/tr/cpp/custom-font/) motorun kullanabileceği mevcut aile ve glif kataloğunu genişletir. Varsayılan yazı tipleri ve herhangi bir [yedek kurallar](/slides/tr/cpp/fallback-font/) önce bu kaynaklara bakarak çözülür, bu da sunucularda ve konteynerlerde daha güvenilir bir kapsama sağlar.

**Varsayılan yazı tipleri metin metriklerini (kerning, ilerlemeler) ve dolayısıyla satır sonlarını ve kaydırmayı etkiler mi?**

Evet. Yazı tipini değiştirmek, glif metriklerini değiştirir ve renderleme sırasında satır sonlarını, kaydırmayı ve sayfalama işlemlerini etkileyebilir. Yerleşim kararlılığı için, [orijinal yazı tiplerini gömün](/slides/tr/cpp/embedded-font/) ya da metrik olarak uyumlu varsayılan ve yedek aileleri seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**

Genellikle gerekli değildir, çünkü [gömülü yazı tipleri](/slides/tr/cpp/embedded-font/) zaten tutarlı bir görünüm sağlar. Varsayılan yazı tipleri, gömülü alt küme tarafından kapsanmayan karakterler veya bir dosyanın gömülü ve gömülmemiş metinleri karıştırdığı durumlarda bir güvenlik ağı olarak hâlâ yardımcı olur.