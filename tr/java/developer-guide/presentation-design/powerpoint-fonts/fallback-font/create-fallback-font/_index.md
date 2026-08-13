---
title: Java'da Sunumlar İçin Fallback Yazı Tiplerini Belirleme
linktitle: Fallback Yazı Tipi
type: docs
weight: 10
url: /tr/java/create-fallback-font/
keywords:
- fallback yazı tipi
- fallback kuralı
- yazı tipi uygulama
- yazı tipi değiştirme
- Unicode aralığı
- eksik glif
- doğru glif
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides'i ustalaşarak PPT, PPTX ve ODP dosyalarında fallback yazı tiplerini ayarlayın, böylece herhangi bir cihaz veya işletim sisteminde tutarlı metin görüntüsü sağlanır."
---
## **Genel Bakış**

Aspose.Slides, sunum işleme ve dışa aktarma işlemleri için fallback (yedek) yazı tipleri belirlemenizi sağlar. Fallback yazı tipleri, birincil yazı tipinde belirli karakterler için glif bulunmadığında kullanılır.

Fallback davranışı, fallback kuralları aracılığıyla yapılandırılır. Her kural, bir Unicode aralığını gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan fallback yazı tiplerini ekleyebilir veya kaldırabilir ve birden fazla kuralı fallback yazı tipi kuralları koleksiyonunda organize edebilirsiniz.

Fallback kuralları çalışma zamanında kullanılan render ayarlarıdır. Sunum dosyasını değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Fallback Kuralları**

Aspose.Slides, fallback yazı tipini uygulamak için kuralları belirtmek amacıyla [IFontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFontFallBackRule) arayüzü ve [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) sınıfı, eksik gliflerin aranmasında kullanılan belirtilen Unicode aralığı ile doğru glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Birden fazla yol kullanarak yazı tipi listesini ekleyebilirsiniz:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Ayrıca mevcut bir [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) nesnesine fallback yazı tipi [kaldırabilir](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) veya [addFallBackFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ekleyebilirsiniz.

Birden fazla Unicode aralığı için fallback yazı tipi değiştirme kurallarını belirtmek gerektiğinde, [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRulesCollection) bir [FontFallBackRule](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule) nesneleri listesini düzenlemek için kullanılabilir.

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Fallback Yazı Tipi Koleksiyonu Oluştur](/slides/tr/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

### Fallback yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?

Bir fallback yazı tipi yalnızca birincil yazı tipinde bulunmayan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/java/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Yazı tipi gömmesi](/slides/tr/java/embedded-font/) ise yazı tiplerini çıktı dosyasının içine paketleyerek alıcıların metni olduğu gibi görmesini sağlar.

### Fallback yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa sadece ekranda render sırasında mı uygulanır?

Evet. Fallback, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [render ve dışa aktarma işlemlerinde](/slides/tr/java/convert-presentation/) etkili olur.

### Fallback yapılandırması sunum dosyasını değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?

Hayır. Fallback kuralları kodunuzda çalışan zaman render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

### İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri fallback seçimini etkiler mi?

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/java/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak bulunmuyorsa, ona referans veren kural etkili olamaz.

### Fallback WordArt, SmartArt ve grafiklerde çalışır mı?

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri render etmek için aynı glif ikame mekanizması uygulanır.