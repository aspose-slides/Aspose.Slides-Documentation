---
title: "JavaScript'te Sunumlar İçin Yedek Yazı Tiplerini Belirleme"
linktitle: "Yedek Yazı Tipi"
type: docs
weight: 10
url: /tr/nodejs-java/create-fallback-font/
keywords:
- "yedek yazı tipi"
- "yedek kural"
- "yazı tipi uygulama"
- "yazı tipi değiştirme"
- "Unicode aralığı"
- "eksik glif"
- "uygun glif"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js'i JavaScript'te PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlamak için ustalaşın, böylece herhangi bir cihazda veya işletim sisteminde tutarlı metin görüntüsü sağlanır."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek yazı tipleri belirlemenize olanak tanır. Yedek yazı tipleri, birincil yazı tipi belirli karakterler için glif içermediğinde kullanılır.

Yedek davranışı yedek kurallar aracılığıyla yapılandırılır. Her kural, gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tiplerini ekleyebilir veya kaldırabilir ve bir yedek yazı tipi kuralları koleksiyonunda birden çok kuralı düzenleyebilirsiniz.

Yedek kurallar, çalışma zamanı render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kuralları**

Aspose.Slides, yedek bir yazı tipi uygulamak için kuralları belirtmek amacıyla [FontFallBackRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule) sınıfını ve [FontFallBackRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule) sınıfı, eksik glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek bir yazı tipi listesi arasındaki ilişkiyi temsil eder:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Birden çok yol kullanarak yazı tipi listesini ekleyebilirsiniz:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Ayrıca mevcut bir [FontFallBackRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule) nesnesine yedek yazı tipini [remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) veya [addFallBackFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRulesCollection) birden çok Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda, bir dizi [FontFallBackRule](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule) nesnesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Yedek Yazı Tipi Koleksiyonu Oluştur](/slides/tr/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Yedek yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?**

Yedek bir yazı tipi yalnızca birincil yazı tipinde eksik olan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/nodejs-java/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Yazı tipi gömmesi](/slides/tr/nodejs-java/embedded-font/) yazı tiplerini çıkış dosyasının içine paketler, böylece alıcılar metni amaçlandığı gibi görüntüleyebilir.

**Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa yalnızca ekrandaki renderda mı uygulanır?**

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [render ve dışa aktarma işlemlerini](/slides/tr/nodejs-java/convert-presentation/) etkiler.

**Yedek yapılandırması sunum dosyasını kendisini değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Yedek kuralları kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri seti yedek seçimini etkiler mi?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/nodejs-java/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

**Yedek, WordArt, SmartArt ve grafiklerde çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri renderlemek için aynı glif ikamesi mekanizması uygulanır.