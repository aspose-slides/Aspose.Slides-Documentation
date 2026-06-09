---
title: Java'da Sunumlar İçin Yedek Yazı Tiplerini Belirleme
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/java/create-fallback-font/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi uygula
- yazı tipi değiştirme
- Unicode aralığı
- eksik glif
- uygun glif
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'yı kullanarak PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, böylece herhangi bir cihaz veya işletim sisteminde tutarlı metin görüntüsü sağlanır."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek yazı tipleri belirlemenizi sağlar. Yedek yazı tipleri, ana yazı tipinde belirli karakterler için glif bulunmadığında kullanılır.

Yedek davranışı, yedek kurallar aracılığıyla yapılandırılır. Her kural, gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tiplerini ekleyebilir veya çıkarabilirsiniz ve bir yedek yazı tipi kural koleksiyonunda birden fazla kuralı düzenleyebilirsiniz.

Yedek kurallar, çalışma zamanı render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kuralları**

Aspose.Slides, yedek bir yazı tipi uygulamak için kuralları belirtmek amacıyla [IFontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFontFallBackRule) arabirimini ve [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) sınıfı, eksik glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek yazı tipi listesini ilişkilendirir:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Ayrıca mevcut [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) nesnesine yedek yazı tipini [remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) ile kaldırmak ya da [addFallBackFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ile eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRulesCollection) birden fazla Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda, [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) nesnelerinin bir listesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Yedek Yazı Tipleri Koleksiyonu Oluştur](/slides/tr/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Yedek bir yazı tipi, yazı tipi ikamesi ve yazı tipi gömme arasındaki fark nedir?**

Yedek bir yazı tipi yalnızca ana yazı tipinde bulunmayan karakterler için kullanılır. [Font substitution](/slides/tr/java/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Font embedding](/slides/tr/java/embedded-font/) yazı tiplerini çıktı dosyasının içine paketler, böylece alıcılar metni amacına uygun şekilde görüntüleyebilir.

**Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa yalnızca ekranda render edilirken mi uygulanır?**

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [renderleme ve dışa aktarma işlemlerini](/slides/tr/java/convert-presentation/) etkiler.

**Yedek yapılandırması sunum dosyasını kendisini değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Yedek kurallar, kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri yedek seçimini etkiler mi?**

Evet. Motor, kullanılabilir sistem klasörlerinden ve sağladığınız herhangi bir [ek yol](/slides/tr/java/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

**Yedek, WordArt, SmartArt ve grafikler için çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri renderlemek için aynı glif ikame mekanizması uygulanır.