---
title: Android'de Sunumlar İçin Yedek Yazı Tiplerini Belirleyin
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/androidjava/create-fallback-font/
keywords:
  - yedek yazı tipi
  - yedek kural
  - yazı tipi uygulama
  - yazı tipi değiştirme
  - Unicode aralığı
  - kaçırılan glif
  - uygun glif
  - PowerPoint
  - OpenDocument
  - sunum
  - Android
  - Java
  - Aspose.Slides
description: "Java üzerinden Android için Aspose.Slides'ı kullanarak PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, metnin tüm cihaz ve işletim sistemlerinde tutarlı görüntülenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek (fallback) yazı tipleri belirtmenizi sağlar. Yedek yazı tipleri, birincil yazı tipinde belirli karakterler için glif bulunmadığında kullanılır.

Yedekleme davranışı, yedekleme kuralları aracılığıyla yapılandırılır. Her kural, bir Unicode aralığını bir veya birden fazla, gerekli glifleri içerebilecek yazı tipiyle ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tipleri ekleyip kaldırabilir ve bir yedekleme yazı tipi kuralları koleksiyonunda birden çok kuralı düzenleyebilirsiniz.

Yedekleme kuralları çalışma zamanında render ayarlarıdır. Sunum dosyasını değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedekleme Kuralları**

Aspose.Slides, yedek bir yazı tipinin uygulanması için kuralları belirtmek üzere [IFontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IFontFallBackRule) arayüzü ve [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) sınıfı, kaçırılan glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek bir yazı tipi listesi arasındaki ilişkilendirmeyi temsil eder:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Çoklu yollarla yazı tipi listesini ekleyebilirsiniz:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Ayrıca mevcut [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) nesnesine yedek yazı tipini [remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) kaldırmak veya [addFallBackFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) eklemek mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRulesCollection) birden çok Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda [FontFallBackRule](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule) nesnelerinin bir listesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Fallback Yazı Tipi Koleksiyonu Oluştur](/slides/tr/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Fallback yazı tipi, yazı tipi ikamesi ve yazı tipi gömme arasındaki fark nedir?**

Fallback yazı tipi yalnızca birincil yazı tipinde bulunmayan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/androidjava/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Yazı tipi gömme](/slides/tr/androidjava/embedded-font/) yazı tiplerini çıktı dosyasının içine paketler, böylece alıcılar metni amaçlandığı gibi görüntüleyebilir.

**Fallback yazı tipleri PDF, PNG veya SVG gibi dışa aktarma işlemlerinde mi, yoksa sadece ekranda render sırasında mı uygulanır?**

Evet. Fallback, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [render ve dışa aktarma işlemlerinde](/slides/tr/androidjava/convert-presentation/) etkilidir.

**Fallback yapılandırması sunum dosyasını değiştirir mi ve ayar gelecekteki açılışlarda korunur mu?**

Hayır. Fallback kuralları kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri seti fallback seçimlerini etkiler mi?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/androidjava/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

**Fallback WordArt, SmartArt ve grafikler için çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri render etmek için aynı glif ikamesi mekanizması uygulanır.