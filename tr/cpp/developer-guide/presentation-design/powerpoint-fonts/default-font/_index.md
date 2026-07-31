---
title: C++'da Varsayılan Sunum Yazı Tiplerini Belirleme
linktitle: Varsayılan Yazı Tipi
type: docs
weight: 30
url: /tr/cpp/default-font/
keywords:
- varsayılan yazı tipi
- düzen yazı tipi
- normal yazı tipi
- Asya yazı tipi
- PDF dışa aktarma
- XPS dışa aktarma
- görüntü dışa aktarma
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'de varsayılan yazı tiplerini ayarlayarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) dosyalarının PDF, XPS ve görüntülere doğru şekilde dönüştürülmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum render edildiğinde kullanılan varsayılan yazı tiplerini belirlemenizi sağlar. Bu, slayt küçük resimleri oluştururken veya bir sunumu PDF ve XPS gibi formatlara dışa aktarırken kullanışlıdır. Varsayılan yazı tipleri, sunum yüklenmeden önce `LoadOptions` aracılığıyla yapılandırılır.

`set_DefaultRegularFont` yöntemi, normal metin için varsayılan yazı tipini tanımlar, `set_DefaultAsianFont` ise Asya metni için varsayılan yazı tipini tanımlar. Bu seçenekler ayarlandıktan sonra, sunum belirtilen yazı tipleri kullanılarak yüklenip render edilebilir.

## **Sunumu Render İçin Varsayılan Yazı Tiplerini Kullanma**
Aspose.Slides, sunumu PDF, XPS veya küçük resimlere render ederken varsayılan yazı tipini ayarlamanıza izin verir. Bu makale, DefaultRegular Font ve DefaultAsian Font'un varsayılan yazı tipi olarak nasıl tanımlanacağını gösterir. Aspose.Slides for C++ API'sini kullanarak dış dizinlerden yazı tiplerini yüklemek için aşağıdaki adımları izleyin:

1. LoadOptions bir örnek oluşturun.
1. DefaultRegularFont'u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullandım.
1. DefaultAsianFont'u istediğiniz yazı tipine ayarlayın. Aşağıdaki örnekte Wingdings kullandım.
1. Sunumu Presentation kullanarak ve yükleme seçeneklerini ayarlayarak yükleyin.
1. Şimdi, sonuçları doğrulamak için slayt küçük resmi, PDF ve XPS oluşturun.

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

**DefaultRegularFont ve DefaultAsianFont tam olarak neyi etkiler—sadece dışa aktarmayı mı, yoksa küçük resimleri, PDF, XPS, HTML ve SVG'yi de mi?**

Hepsi desteklenen çıktılar için render işlem hattına katılırlar. Bu, slayt küçük resimlerini, [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/tr/cpp/convert-powerpoint-to-xps/), [raster görüntüler](/slides/tr/cpp/convert-powerpoint-to-png/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/), ve [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/) içerir, çünkü Aspose.Slides bu hedeflerde aynı düzen ve glif çözümleme mantığını kullanır.

**Varsayılan yazı tipleri, sadece okuyup bir PPTX'i kaydederken herhangi bir renderlemeden olmadan uygulanır mı?**

Hayır. Varsayılan yazı tipleri, metnin ölçülmesi ve çizilmesi gerektiğinde önemlidir. Sunumun doğrudan açılıp kaydedilmesi, saklanan yazı tipi dizilerini ya da dosyanın yapısını değiştirmez. Varsayılan yazı tipleri, metni render eden veya yeniden akışa sokan işlemlerde devreye girer.

**Kendi yazı tipi klasörlerimi eklersem ya da bellekteki yazı tiplerini sağlarsam, varsayılan yazı tiplerini seçerken dikkate alınır mı?**

Evet. [Özel yazı tipi kaynakları](/slides/tr/cpp/custom-font/) motorun kullanabileceği mevcut aile ve glif katalogunu genişletir. Varsayılan yazı tipleri ve herhangi bir [geri dönüş kuralları](/slides/tr/cpp/fallback-font/) önce bu kaynaklara bakarak çözülür, bu da sunucularda ve konteynerlerde daha güvenilir bir kapsama sağlar.

**Varsayılan yazı tipleri metin metriklerini (kerning, ilerlemeler) ve dolayısıyla satır sonlarını ve kaydırmayı etkiler mi?**

Evet. Yazı tipini değiştirmek glif metriklerini değiştirir ve render sırasında satır sonlarını, kaydırmayı ve sayfalama işlemlerini etkileyebilir. Düzen istikrarı için, [orijinal yazı tiplerini göm](/slides/tr/cpp/embedded-font/) ya da metrik olarak uyumlu varsayılan ve geri dönüş ailelerini seçin.

**Sunumda kullanılan tüm yazı tipleri gömülü ise varsayılan yazı tiplerini ayarlamanın bir anlamı var mı?**

Genellikle gerekli değildir, çünkü [gömülü yazı tipleri](/slides/tr/cpp/embedded-font/) zaten tutarlı bir görünüm sağlar. Varsayılan yazı tipleri, gömülü alt küme tarafından kapsanmayan karakterler veya bir dosya gömülü ve gömülmemiş metni karıştırdığında bir güvenlik ağı olarak hâlâ faydalıdır.