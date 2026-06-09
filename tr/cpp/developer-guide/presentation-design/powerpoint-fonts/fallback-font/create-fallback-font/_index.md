---
title: C++'da Sunumlar İçin Yedek Yazı Tiplerini Belirleme
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/cpp/create-fallback-font/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi uygula
- yazı tipi değiştir
- Unicode aralığı
- eksik glif
- uygun glif
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ için Aspose.Slides'i öğrenerek PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, böylece herhangi bir cihaz veya işletim sisteminde tutarlı metin görüntülenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek (fallback) yazı tipleri belirtmenizi sağlar. Yedek yazı tipleri, birincil yazı tipinde belirli karakterler için glif bulunmadığında kullanılır.

Yedek davranışı, yedek kuralları aracılığıyla yapılandırılır. Her kural, bir Unicode aralığını, gerekli glifleri içerebilecek bir veya birden fazla yazı tipiyle ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tiplerini ekleyebilir veya kaldırabilir ve bir yedek yazı tipi kuralları koleksiyonunda birden çok kuralı düzenleyebilirsiniz.

Yedek kuralları, çalışma zamanında render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kurallar**

Aspose.Slides, yedek bir yazı tipinin uygulanması kurallarını belirtmek için [IFontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/) arayüzünü ve [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) sınıfı, kaçırılan gliflerin aranması için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Birden fazla yöntemle yazı tipi listesi ekleyebilirsiniz:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Mevcut bir [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) nesnesine yedek yazı tipini [Remove()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/remove/) kaldırmak veya [AddFallBackFonts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrulescollection/) birden çok Unicode aralığı için yedek yazı tipi değişim kurallarını belirtme ihtiyacı olduğunda, bir [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) nesneleri listesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Yedek Yazı Tipi Koleksiyonu Oluştur](/slides/tr/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Yedek yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?**

Yedek yazı tipi yalnızca birincil yazı tipinde eksik olan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/cpp/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Yazı tipi gömmesi](/slides/tr/cpp/embedded-font/) yazı tiplerini çıktı dosyasının içine paketler, böylece alıcılar metni amaçlandığı gibi görüntüleyebilir.

**Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarımlarda mı uygulanır, yoksa yalnızca ekrandaki renderda mı?**

Evet. Yedek, karakterlerin çizilmesi gerektiği fakat kaynak yazı tipinde bulunmadığı tüm [render ve dışa aktarma işlemlerini](/slides/tr/cpp/convert-presentation/) etkiler.

**Yedek yapılandırması sunum dosyasını kendisini değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Yedek kuralları, kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri seti yedek seçimlerini etkiler mi?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/cpp/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

**Yedek, WordArt, SmartArt ve grafikler için çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri renderlemek için aynı glif ikame mekanizması uygulanır.