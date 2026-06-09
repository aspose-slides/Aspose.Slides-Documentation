---
title: PHP Sunumları için Yedek Yazı Tiplerini Yönetme
linktitle: Yedek Yazı Tipi
type: docs
weight: 50
url: /tr/php-java/fallback-font/
keywords:
- yedek yazı tipi
- mevcut yazı tipi
- glif değişimi
- yazı tipi belirtme
- kural belirtme
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP, orijinal yazı tipleri mevcut olmadığında PowerPoint ve OpenDocument sunumlarında metnin okunabilirliğini korumak için yedek yazı tipleri kullanır."
---
## **Giriş**

Yedek yazı tipleri, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli bir glifi içermediğinde kullanılır. Bu durumda, Aspose.Slides belirtilen yedek yazı tiplerinden birini eksik glifi değiştirmek için kullanabilir.

## **Yedek Yazı Tipi**
Yedek yazı tipi, metin için belirtilen yazı tipi sistemde mevcut olduğunda, ancak bu yazı tipi gerekli bir glifi içermediğinde kullanılır. Bu durumda, glif değişimi için belirtilen yedek yazı tiplerinden birini kullanmak mümkündür.

Aspose.Slides, yedek yazı tipleri oluşturmanıza, bunları yedek yazı tipleri koleksiyonuna eklemenize, belirli bir sunum için yedek yazı tipleri koleksiyonunu ayarlamanıza, sunumdan yedek yazı tiplerini kaldırmanıza, yedek yazı tiplerinin uygulanacağı kuralları belirtmenize ve diğer işlemlere olanak tanır.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Yedek Yazı Tipi Oluştur](/slides/tr/php-java/create-fallback-font)
- [Yedek Yazı Tipleri Koleksiyonu Oluştur](/slides/tr/php-java/create-fallback-fonts-collection)
- [Yedek Yazı Tipi ile Sunumu Oluştur](/slides/tr/php-java/render-presentation-with-fallback-font)

## **SSS**

**Yedek yazı tipleri, yazı tipi ikamesinden nasıl farklıdır?**

Yedek yazı tipleri, birincil yazı tipi belirli glifleri içermediğinde karakter bazında veya Unicode aralığı bazında uygulanır; yalnızca eksik karakterleri doldurur. [Substitution](/slides/tr/php-java/font-substitution/) ise eksik veya kullanılamayan bir yazı tipini tüm bir koşul veya metin bölümü için başka bir yazı tipiyle değiştirir. İkisi bir arada kullanılabilir, ancak kapsamları ve seçim mantıkları farklıdır.

**Yedek ayarları sunum dosyasının içinde kaydedilir mi?**

Hayır. Yedek yapılandırması işlem/oluşturma zamanında kütüphanede bulunur ve PPTX dosyasına serileştirilmez. Sunum, yedek kurallarınızı saklamaz.

**Yedek, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı oluşturma işlem hattından geçer, bu yüzden aynı yedek kuralları normal metin gibi uygulanır.