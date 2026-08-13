---
title: Sunumlar için .NET'te Yedek Yazı Tiplerini Belirtin
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/net/create-fallback-font/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi uygula
- yazı tipini değiştir
- Unicode aralığı
- eksik glif
- doğru glif
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i kullanarak PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, her cihazda veya işletim sisteminde tutarlı metin görüntüsünü güvence altına alın."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek (fallback) yazı tiplerini belirtmenizi sağlar. Yedek yazı tipleri, birincil yazı tipi belirli karakterler için glif içermediğinde kullanılır.

Yedek davranışı, yedek kuralları aracılığıyla yapılandırılır. Her kural, gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tiplerini ekleyebilir veya kaldırabilir ve bir yedek yazı tipi kural koleksiyonunda birden fazla kuralı düzenleyebilirsiniz.

Yedek kurallar, çalışma zamanı render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kurallar**

Aspose.Slides, bir yedek yazı tipi uygulamak için kuralları belirtmek amacıyla [IFontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/iFontFallBackRule) arayüzünü ve [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) sınıfı, eksik glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Birden fazla yol kullanarak yazı tipi listesi ekleyebilirsiniz:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Mevcut bir [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) nesnesine yedek yazı tipini [Remove()](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontfallbackrule/methods/remove) kaldırmak veya [AddFallBackFonts()](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrulescollection) birden çok Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda, [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) nesnelerinin bir listesini düzenlemek için kullanılabilir.

{{% alert color="info" title="See also" %}} 
- [Yedek Yazı Tipi Koleksiyonu Oluştur](/slides/tr/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

### Yedek yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?

Yedek yazı tipi yalnızca birincil yazı tipinde eksik olan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/net/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Yazı tipi gömmesi](/slides/tr/net/embedded-font/) yazı tiplerini çıktı dosyasının içine paketler, böylece alıcılar metni hedeflenen şekilde görüntüleyebilir.

### Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa yalnızca ekran render'ında mı uygulanır?

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [renderleme ve dışa aktarma işlemleri](/slides/tr/net/convert-presentation/) işlemlerini etkiler.

### Yedek yapılandırması sunum dosyasını kendisini değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?

Hayır. Yedek kurallar, kodunuzda çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

### İşletim sistemi (Windows/Linux/macOS) ve yazı tipi klasörleri seti yedek seçimini etkiler mi?

Evet. Motor, kullanılabilir sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/net/custom-font/) yolundan yazı tiplerini çözer. Eğer bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

### Yedek, WordArt, SmartArt ve grafiklerde çalışır mı?

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri renderlemek için aynı glif ikamesi mekanizması uygulanır.