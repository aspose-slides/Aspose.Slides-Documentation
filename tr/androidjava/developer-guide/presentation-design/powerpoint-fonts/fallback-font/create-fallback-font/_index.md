---
title: Android'de Sunumlar İçin Yedek Yazı Tiplerini Belirtin
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/androidjava/create-fallback-font/
keywords:
- yedek yazı tipi
- yedek kuralı
- yazı tipini uygula
- yazı tipini değiştir
- Unicode aralığı
- eksik glif
- uygun glif
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides'ı ustalaştırarak PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, herhangi bir cihazda veya işletim sisteminde tutarlı metin görüntülenmesini güvence altına alın."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek yazı tipleri belirlemenizi sağlar. Yedek yazı tipleri, birincil yazı tipinin belirli karakterler için glif içermediği durumlarda kullanılır.

Yedek davranışı, yedek kurallar aracılığıyla yapılandırılır. Her kural, gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tipleri ekleyebilir veya kaldırabilir ve bir yedek yazı tipi kuralları koleksiyonunda birden fazla kuralı organize edebilirsiniz.

Yedek kurallar, çalışma zamanı renderleme ayarlarıdır. Sunum dosyasını doğrudan değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kurallar**

Aspose.Slides, bir yedek yazı tipi uygulamak için kuralları belirlemek amacıyla [IFontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IFontFallBackRule) arabirimini ve [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) sınıfı, kaçırılan glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Farklı yöntemlerle yazı tipi listesini ekleyebilirsiniz:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Ayrıca mevcut [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) nesnesine yedek yazı tipini [remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) kaldırmak veya [addFallBackFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRulesCollection) birden çok Unicode aralığı için yedek yazı tipi yerine koyma kurallarını belirtme ihtiyacı olduğunda, bir dizi [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) nesnesini düzenlemek için kullanılabilir.

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Yedek Yazı Tipi Koleksiyonu Oluştur](/slides/tr/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

### Yedek yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?

Yedek bir yazı tipi yalnızca birincil yazı tipinde eksik olan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/androidjava/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Yazı tipi gömmesi](/slides/tr/androidjava/embedded-font/) yazı tiplerini çıktı dosyasının içinde paketler, böylece alıcılar metni amaçlandığı gibi görüntüleyebilir.

### Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarmalarda mı yoksa yalnızca ekran üzerindeki renderlamada mı uygulanır?

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [renderleme ve dışa aktarma işlemleri](/slides/tr/androidjava/convert-presentation/) etkilidir.

### Yedek yapılandırması sunum dosyasını değiştirir mi ve ayar gelecekteki açılışlarda korunur mu?

Hayır. Yedek kurallar, kodunuzdaki çalışma zamanı renderleme ayarlarıdır; .pptx dosyasının içinde depolanmazlar ve PowerPoint'te görünmezler.

### İşletim sistemi (Windows/Linux/macOS) ve font dizinlerinin seti yedek seçiminde etkili olur mu?

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/androidjava/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

### Yedek, WordArt, SmartArt ve grafikler için çalışır mı?

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri renderlemek için aynı glif ikamesi mekanizması uygulanır.