---
title: Python üzerinden Java ile Sunumlarda Yedek Yazı Tiplerini Belirtin
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/python-java/create-fallback-font/
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
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile Aspose.Slides'ı öğrenerek PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, her cihaz ve işletim sisteminde tutarlı metin görüntülenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum işleme ve dışa aktarma işlemleri için yedek (fallback) yazı tipleri belirlemenizi sağlar. Yedek yazı tipleri, birincil yazı tipi belirli karakterler için glif içermediğinde kullanılır.

Yedek davranışı, yedek kuralları aracılığıyla yapılandırılır. Her kural, eksik glifleri aramak için kullanılacak bir Unicode aralığını bir veya daha fazla olası glif içeren yazı tipiyle ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tiplerini ekleyebilir veya kaldırabilir ve bir yedek yazı tipi kuralı koleksiyonunda birden çok kuralı düzenleyebilirsiniz.

Yedek kurallar, çalışma zamanı (runtime) render ayarlarıdır. Sunum dosyasını doğrudan değiştirmezler ve PPTX dosyası içinde depolanmazlar.

## **Yedek Kurallar**

Aspose.Slides, yedek yazı tiplerini uygulamak için kuralları belirtmek amacıyla [FontFallBackRule](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/) sınıfını sunar. Bu sınıf, eksik glifleri aramak için kullanılan bir Unicode aralığı ile gerekli glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Birden çok şekilde bir yazı tipi listesi belirtin.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Ayrıca mevcut bir [FontFallBackRule](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/) nesnesinde yedek bir yazı tipini [remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/#remove) ile kaldırabilir veya [addFallBackFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) ile yedek yazı tipleri ekleyebilirsiniz.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrulescollection/) birden çok Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtmeniz gerektiğinde [FontFallBackRule](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontfallbackrule/) nesnelerinin bir listesini düzenleyebilir.

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Yedek Yazı Tipleri Koleksiyonu Oluşturma](/slides/tr/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **SSS**

**Yedek bir yazı tipi, yazı tipi ikamesi ve yazı tipi gömmesi arasındaki fark nedir?**

Yedek bir yazı tipi yalnızca birincil yazı tipinde bulunmayan karakterler için kullanılır. [Yazı tipi ikamesi](/slides/tr/python-java/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipiyle değiştirir. [Yazı tipi gömmesi](/slides/tr/python-java/embedded-font/) yazı tiplerini çıktı dosyasına ekler, böylece alıcılar metni amaçlandığı gibi görüntüleyebilir.

**Yedek yazı tipleri PDF, PNG veya SVG gibi dışa aktarımlarda mı yoksa yalnızca ekrandaki render işlemlerinde mi uygulanır?**

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [render ve dışa aktarma işlemlerinde](/slides/tr/python-java/convert-presentation/) etkili olur.

**Yedek yazı tiplerinin yapılandırılması sunum dosyasını değiştirir mi ve ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Yedek kuralları kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görünmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinleri yedek seçiminde etkili olur mu?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/python-java/custom-font/) içinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona referans veren bir kural etkili olamaz.

**Yedek, WordArt, SmartArt ve grafikler için çalışır mı?**

Evet. Bu nesneler metin içerdiğinde aynı glif ikame mekanizması eksik karakterleri renderlemek için uygulanır.