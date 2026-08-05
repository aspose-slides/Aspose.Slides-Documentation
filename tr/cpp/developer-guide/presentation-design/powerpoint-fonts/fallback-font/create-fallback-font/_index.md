---
title: C++ Sunumları İçin Yedek Yazı Tiplerini Belirtin
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/cpp/create-fallback-font/
keywords:
- yedek yazı tipi
- yedek kuralı
- yazı tipi uygulama
- yazı tipi değiştirme
- Unicode aralığı
- eksik glif
- uygun glif
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ için Aspose.Slides'i kullanarak PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, böylece herhangi bir cihazda veya işletim sisteminde tutarlı metin görüntüsü sağlanır."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarım işlemleri için yedek yazı tipleri belirlemenizi sağlar. Yedek yazı tipleri, birincil yazı tipi belirli karakterler için glif içermediğinde kullanılır.

Yedek davranışı, yedek kuralları aracılığıyla yapılandırılır. Her kural, gereken glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tipleri ekleyebilir veya kaldırabilir ve bir yedek yazı tipi kuralı koleksiyonunda birden fazla kuralı düzenleyebilirsiniz.

Yedek kurallar, çalışma zamanı render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kurallar**

Aspose.Slides, yedek bir yazı tipi uygulamak için kuralları belirtmek üzere [IFontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/) arayüzünü ve [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) sınıfı, kaçırılan glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek bir yazı tipi listesi arasındaki ilişkiyi temsil eder:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Çoklu yolları kullanarak yazı tipi listesini ekleyebilirsiniz:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Ayrıca mevcut [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) nesnesine yedek yazı tipi [Remove()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/remove/) ile kaldırmak veya [AddFallBackFonts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) ile eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrulescollection/) birden fazla Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda, bir [FontFallBackRule](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/) nesneleri listesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Yedek Yazı Tipleri Koleksiyonu Oluştur](/slides/tr/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Yedek yazı tipi, yazı tipi ikamesi ve yazı tipi gömme arasındaki fark nedir?**

Yedek bir yazı tipi yalnızca birincil yazı tipinde bulunmayan karakterler için kullanılır. [Font substitution](/slides/tr/cpp/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Font embedding](/slides/tr/cpp/embedded-font/) yazı tiplerini çıktı dosyasının içine paketleyerek alıcıların metni amaçlandığı gibi görüntülemesini sağlar.

**Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa yalnızca ekran üzerindeki renderlamada mı uygulanır?**

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [renderlama ve dışa aktarma işlemlerine](/slides/tr/cpp/convert-presentation/) etki eder.

**Yedek ayarlarını yapılandırmak sunum dosyasını kendisini değiştirir mi ve bu ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Yedek kurallar, kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri yedek seçimlerini etkiler mi?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/cpp/custom-font/) üzerinden yazı tiplerini çözer. Eğer bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

**Yedek, WordArt, SmartArt ve grafiklerde çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri renderlamak için aynı glif ikame mekanizması uygulanır.