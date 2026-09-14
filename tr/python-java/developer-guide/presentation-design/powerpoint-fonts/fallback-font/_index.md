---
title: Python üzerinden Java ile Sunumlar için Yedek Yazı Tiplerini Yönet
linktitle: Yedek Yazı Tipi
type: docs
weight: 50
url: /tr/python-java/fallback-font/
keywords:
- yedek yazı tipi
- mevcut yazı tipi
- glif değişimi
- yazı tipi belirtme
- kural belirtme
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ın, orijinal yazı tipleri mevcut olmadığında, PowerPoint ve OpenDocument sunumlarında metni okunabilir tutmak için yedek yazı tiplerini nasıl kullandığını görün."
---
## **Giriş**

Fallback (yedek) yazı tipleri, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli glifi içermediğinde kullanılır. Bu durumda Aspose.Slides belirtilen yedek yazı tiplerinden birini eksik glifi değiştirmek için kullanabilir.

## **Yedek Yazı Tipi**

Aspose.Slides yedek yazı tipleri oluşturmanıza, bunları bir yedek yazı tipi koleksiyonuna eklemenize, belirli bir sunum için yedek yazı tipi koleksiyonunu ayarlamanıza, yedek yazı tiplerini sunumdan kaldırmanıza, yedek yazı tiplerinin uygulanma kurallarını belirtmenize ve diğer ilgili işlemleri gerçekleştirmenize olanak tanır.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Yedek Yazı Tipi Oluştur](/slides/tr/python-java/create-fallback-font/)
- [Yedek Yazı Tipleri Koleksiyonu Oluştur](/slides/tr/python-java/create-fallback-fonts-collection/)
- [Yedek Yazı Tipi ile Sunumu Oluştur](/slides/tr/python-java/render-presentation-with-fallback-font/)

## **SSS**

**Yedek yazı tipleri yazı tipi ikamesinden nasıl farklıdır?**

Fallback, birincil yazı tipi belirli glifleri içermediğinde karakter başına veya Unicode aralığı başına uygulanır; sadece eksik karakterleri doldurur. [Substitution](/slides/tr/python-java/font-substitution/) ise eksik veya erişilemeyen bir yazı tipini bütün bir koşul veya metin bölümü için başka bir yazı tipiyle değiştirir. Birlikte kullanılabilirler, ancak kapsamları ve seçim mantıkları farklıdır.

**Yedek ayarları sunum dosyasının içinde kaydedilir mi?**

Hayır. Yedek yapılandırması kitaplıkta işleme/oluşturma zamanında yaşar ve PPTX dosyasına serileştirilmez. Sunum yedek kurallarınızı depolamaz.

**Yedek, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı renderleme hattından geçer, bu yüzden aynı yedek kurallar regular metin gibi uygulanır.