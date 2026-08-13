---
title: C++ Sunumlarında Geri Dönüş Yazı Tiplerini Belirleyin
linktitle: Geri Dönüş Yazı Tipi
type: docs
weight: 10
url: /tr/cpp/create-fallback-font/
keywords:
- geri dönüş yazı tipi
- geri dönüş kuralı
- yazı tipi uygula
- yazı tipi değiştirme
- Unicode aralığı
- eksik glif
- uygun glif
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ için Aspose.Slides'i öğrenerek PPT, PPTX ve ODP dosyalarında geri dönüş yazı tiplerini ayarlayın, her cihazda veya işletim sisteminde tutarlı metin gösterimini güvence altına alın."
---
## **Genel Bakış**

Aspose.Slides, sunum işleme ve dışa aktarma işlemleri için geri dönüş yazı tiplerini belirtmenize olanak tanır. Geri dönüş yazı tipleri, birincil yazı tipinde belirli karakterler için glif bulunmadığında kullanılır.

Geri dönüş davranışı, geri dönüş kuralları aracılığıyla yapılandırılır. Her kural, gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan geri dönüş yazı tipleri ekleyebilir veya kaldırabilir ve birden fazla kuralı bir geri dönüş yazı tipi kural koleksiyonunda düzenleyebilirsiniz.

Geri dönüş kuralları, çalışma zamanı işleme ayarlarıdır. Sunum dosyasını doğrudan değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Geri Dönüş Kuralları**

Aspose.Slides, bir geri dönüş yazı tipini uygulamak için kuralları belirtmenizi sağlayan [IFontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/) arayüzünü ve [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) sınıfı, eksik glifleri aramak için kullanılan belirli Unicode aralığı ile uygun glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Yazı tipi listesini eklemenin birden fazla yolu vardır:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Ayrıca, mevcut bir [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) nesnesine geri dönüş yazı tipini [Remove()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/remove/) ile kaldırmak veya [AddFallBackFonts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrulescollection/) birden çok Unicode aralığı için geri dönüş yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda, bir [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) nesnesi listesini düzenlemek için kullanılabilir.

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Geri Dönüş Yazı Tipi Koleksiyonu Oluştur](/slides/tr/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

### Bir geri dönüş yazı tipi, yazı tipi ikamesi ve yazı tipi gömme arasındaki fark nedir?

Geri dönüş yazı tipi yalnızca birincil yazı tipinde bulunmayan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/cpp/font-substitution/) belirli bir yazı tipini tamamen başka bir yazı tipiyle değiştirir. [Yazı tipi gömme](/slides/tr/cpp/embedded-font/) ise yazı tiplerini çıktı dosyasının içine paketleyerek alıcıların metni amaçlandığı gibi görmesini sağlar.

### Geri dönüş yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa yalnızca ekrandaki işleme sırasında mı uygulanır?

Evet. Geri dönüş, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [işleme ve dışa aktarma işlemleri](/slides/tr/cpp/convert-presentation/) işlemlerini etkiler.

### Geri dönüş yapılandırması sunum dosyasını değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?

Hayır. Geri dönüş kuralları, kodunuzdaki çalışma zamanı işleme ayarlarıdır; .pptx dosyasına kaydedilmez ve PowerPoint’te görünmez.

### İşletim sistemi (Windows/Linux/macOS) ve yazı tipi klasörleri kümesi geri dönüş seçimini etkiler mi?

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/cpp/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

### Geri dönüş, WordArt, SmartArt ve grafiklerde çalışır mı?

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri işlemek için aynı glif değiştirme mekanizması uygulanır.