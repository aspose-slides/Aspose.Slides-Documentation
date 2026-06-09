---
title: ".NET'te Sunumlar için Yedek Yazı Tiplerini Belirleyin"
linktitle: "Yedek Yazı Tipi"
type: docs
weight: 10
url: /tr/net/create-fallback-font/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi uygula
- yazı tipi değiştir
- Unicode aralığı
- eksik glif
- doğru glif
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayarak, herhangi bir cihazda veya işletim sisteminde tutarlı metin görüntülenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek yazı tiplerini belirtmenizi sağlar. Yedek yazı tipleri, birincil yazı tipi belirli karakterler için glifler içermediğinde kullanılır.

Yedek davranışı, yedek kurallar aracılığıyla yapılandırılır. Her kural, gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tiplerini ekleyip çıkarabilir ve bir yedek yazı tipi kurallar koleksiyonunda birden fazla kuralı düzenleyebilirsiniz.

Yedek kurallar, çalışma zamanında render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kurallar**

Aspose.Slides, yedek bir yazı tipi uygulamak için kuralları belirtmek amacıyla [IFontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/iFontFallBackRule) arayüzünü ve [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) sınıfı, eksik glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Birden fazla yöntemle yazı tipi listesini ekleyebilirsiniz:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Ayrıca mevcut bir [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) nesnesine yedek yazı tipini [Remove()](https://reference.aspose.com/slides/tr/net/aspose.slides/ifontfallbackrule/methods/remove) ile kaldırmak ya da [AddFallBackFonts()](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ile eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrulescollection)Birden fazla Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda, bir [FontFallBackRule](https://reference.aspose.com/slides/tr/net/aspose.slides/FontFallBackRule) nesnelerinin listesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="See also" %}} 
- [Yedek Yazı Tipi Koleksiyonu Oluştur](/slides/tr/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Yedek yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?**

Yedek bir yazı tipi yalnızca birincil yazı tipinde eksik olan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/net/font-substitution/) belirli bir yazı tipini tamamen başka bir yazı tipiyle değiştirir. [Yazı tipi gömmesi](/slides/tr/net/embedded-font/) ise yazı tiplerini çıktı dosyasına paketleyerek alıcıların metni amaçlandığı gibi görüntülemesini sağlar.

**Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa yalnızca ekran render'ında mı uygulanır?**

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [rendering and export operations](/slides/tr/net/convert-presentation/) üzerinde etkilidir.

**Yedek yapılandırması sunum dosyasını kendisini değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Yedek kurallar, kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmezler.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinlerinin kümesi yedek seçimini etkiler mi?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/net/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

**Yedek, WordArt, SmartArt ve grafikler için çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri render etmek için aynı glif ikame mekanizması uygulanır.