---
title: Python'da Sunumlar İçin Geri Dönüş Yazı Tiplerini Belirleme
linktitle: Geri Dönüş Yazı Tipi
type: docs
weight: 10
url: /tr/python-net/create-fallback-font/
keywords:
- geri dönüş yazı tipi
- geri dönüş kuralı
- yazı tipini uygula
- yazı tipini değiştir
- Unicode aralığı
- eksik glif
- uygun glif
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "ASP.NET üzerinden Python için Aspose.Slides'i öğrenerek PPT, PPTX ve ODP dosyalarında geri dönüş yazı tiplerini ayarlayın, böylece her cihazda veya işletim sisteminde tutarlı metin görüntülenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için geri dönüş yazı tiplerini belirtmenizi sağlar. Geri dönüş yazı tipleri, birincil yazı tipi belirli karakterler için glif içermediğinde kullanılır.

Geri dönüş davranışı, geri dönüş kuralları aracılığıyla yapılandırılır. Her kural, bir Unicode aralığını gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan geri dönüş yazı tiplerini ekleyebilir veya kaldırabilir ve birden fazla kuralı bir geri dönüş yazı tipi kuralları koleksiyonunda düzenleyebilirsiniz.

Geri dönüş kuralları, çalışma zamanında render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Geri Dönüş Yazı Tiplerini Belirtme**

Aspose.Slides, bir geri dönüş yazı tipi uygulamak için kuralları belirtmek üzere [FontFallBackRule](https://reference.aspose.com/slides/tr/python-net/aspose.slides/FontFallBackRule/) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/python-net/aspose.slides/FontFallBackRule/) sınıfı, eksik glifleri aramak için kullanılan belirtilen Unicode aralığı ile uygun glifleri içerebilecek yazı tipleri listesini ilişkilendirir:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Birden fazla yöntemle yazı tipi listesini ekleyebilirsiniz:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Ayrıca mevcut [FontFallBackRule](https://reference.aspose.com/slides/tr/python-net/aspose.slides/FontFallBackRule/) nesnesine geri dönüş yazı tipini [remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontfallbackrule/remove/) etmek veya [add_fall_back_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontfallbackrulescollection/) birden fazla Unicode aralığı için geri dönüş yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda [FontFallBackRule](https://reference.aspose.com/slides/tr/python-net/aspose.slides/FontFallBackRule/) nesnelerinin bir listesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="Ayrıca Bakınız" %}} 
- [Fallback Font Koleksiyonu Oluştur](/slides/tr/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Geri dönüş yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?**

Geri dönüş yazı tipi yalnızca birincil yazı tipinde eksik olan karakterler için kullanılır. [Font substitution](/slides/tr/python-net/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Font embedding](/slides/tr/python-net/embedded-font/) yazı tiplerini çıktı dosyasının içinde paketleyerek alıcıların metni amaçlandığı gibi görmesini sağlar.

**Geri dönüş yazı tipleri PDF, PNG veya SVG gibi dışa aktarımlarda mı yoksa yalnızca ekrandaki renderlamada mı uygulanır?**

Evet. Geri dönüş, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [renderleme ve dışa aktarma işlemleri](/slides/tr/python-net/convert-presentation/) işlemlerini etkiler.

**Geri dönüş yapılandırması sunum dosyasını kendisini değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Geri dönüş kuralları kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri seti geri dönüş seçimlerini etkiler mi?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/python-net/custom-font/) ek yollarından yazı tiplerini çözer. Eğer bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren kural etkili olamaz.

**Geri dönüş WordArt, SmartArt ve grafikler için çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, aynı glif ikame mekanizması eksik karakterleri renderlamak için uygulanır.