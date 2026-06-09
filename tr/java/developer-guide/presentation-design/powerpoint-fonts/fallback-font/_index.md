---
title: Java'da Sunumlar İçin Geri Dönüş Yazı Tiplerini Yönetme
linktitle: Geri Dönüş Yazı Tipi
type: docs
weight: 50
url: /tr/java/fallback-font/
keywords:
- geri dönüş yazı tipi
- mevcut yazı tipi
- glif değiştirme
- yazı tipi belirt
- kural belirt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java, orijinal yazı tipleri mevcut olmadığında, PowerPoint ve OpenDocument sunumlarında metnin okunabilirliğini korumak için geri dönüş yazı tiplerini nasıl kullandığını gösterir."
---
## **Introduction**

Geri dönüş (fallback) yazı tipleri, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli glifi içermediğinde kullanılır. Bu durumda, Aspose.Slides eksik glifi yerine koymak için belirtilen geri dönüş yazı tiplerinden birini kullanabilir.

## **Fallback Font**

Aspose.Slides, geri dönüş yazı tipleri oluşturmanıza, bunları geri dönüş yazı tipleri koleksiyonuna eklemenize, belirli bir sunum için geri dönüş yazı tipi koleksiyonunu ayarlamanıza, geri dönüş yazı tiplerini sunumdan kaldırmanıza, geri dönüş yazı tiplerinin uygulanacağı kuralları belirtmenize ve benzerlerine olanak tanır.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Geri Dönüş Yazı Tipi Oluştur](/slides/tr/java/create-fallback-font)
- [Geri Dönüş Yazı Tipleri Koleksiyonu Oluştur](/slides/tr/java/create-fallback-fonts-collection)
- [Geri Dönüş Yazı Tipi ile Sunumu Oluştur](/slides/tr/java/render-presentation-with-fallback-font)

## **FAQ**

**Geri dönüş yazı tipleri font ikamesinden nasıl farklıdır?**

Geri dönüş, birincil yazı tipi belirli glifleri içermediğinde, her karakter veya Unicode aralığı için uygulanır; yalnızca eksik karakterleri doldurur. [İkame](/slides/tr/java/font-substitution/) eksik veya bulunamayan bir yazı tipini tüm bir koşul veya metin bölümü için başka bir yazı tipiyle değiştirir. Birlikte kullanılabilirler, ancak kapsamları ve seçim mantıkları farklıdır.

**Geri dönüş ayarları sunum dosyasına kaydedilir mi?**

Hayır. Geri dönüş yapılandırması, kütüphanede işleme/oluşturma zamanında bulunur ve PPTX dosyasına serileştirilmez. Sunum, geri dönüş kurallarınızı saklamaz.

**Geri dönüş, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı oluşturma hattından geçer, bu yüzden aynı geri dönüş kuralları normal metin gibi uygulanır.