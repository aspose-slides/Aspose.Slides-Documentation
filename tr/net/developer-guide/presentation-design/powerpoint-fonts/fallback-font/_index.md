---
title: Sunumlar için .NET'te Yedek Yazı Tiplerini Yönet
linktitle: Yedek Yazı Tipi
type: docs
weight: 50
url: /tr/net/fallback-font/
keywords:
- yedek yazı tipi
- mevcut yazı tipi
- glif değiştirme
- yazı tipi belirtme
- kural belirtme
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in, orijinal yazı tipleri mevcut olmadığında PowerPoint ve OpenDocument sunumlarında metnin okunabilirliğini korumak için yedek yazı tiplerini nasıl kullandığını görün."
---
## **Giriş**

Yazı için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli glifi içermediğinde yedek (fallback) yazı tipleri kullanılır. Bu durumda, Aspose.Slides belirtilen yedek yazı tiplerinden birini kullanarak eksik glifi yerine koyabilir.

## **Yedek Yazı Tipi**

Aspose.Slides yedek yazı tipleri oluşturmanıza, bu yazı tiplerini yedek yazı tipleri koleksiyonuna eklemenize, belirli bir sunum için yedek yazı tipi koleksiyonunu ayarlamanıza, sunumdan yedek yazı tiplerini kaldırmanıza, yedek yazı tiplerinin uygulanacağı kuralları belirtmenize ve diğer işlemlere olanak tanır.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Yedek Yazı Tipi Oluştur](/slides/tr/net/create-fallback-font)
- [Yedek Yazı Tipleri Koleksiyonu Oluştur](/slides/tr/net/create-fallback-fonts-collection)
- [Yedek Yazı Tipi ile Sunumu Oluştur](/slides/tr/net/render-presentation-with-fallback-font)

## **SSS**

**Yedek yazı tipleri font ikamesinden nasıl farklıdır?**

Yedek yazı tipleri, birincil yazı tipi belirli glifleri içermediğinde, karakter bazında veya Unicode aralığı bazında uygulanır; yalnızca eksik karakterleri doldurur. [İkame](/slides/tr/net/font-substitution/) eksik veya mevcut olmayan bir yazı tipini, bir koşulun veya metin bölümünün tamamı için başka bir yazı tipiyle değiştirir. Birlikte kullanılabilirler, ancak kapsamları ve seçim mantıkları farklıdır.

**Yedek ayarları sunum dosyasına kaydedilir mi?**

Hayır. Yedek yapılandırması, kütüphane içinde işleme/oluşturma zamanında bulunur ve PPTX dosyasına seri hale getirilmez. Sunum yedek kurallarınızı depolamaz.

**Yedek, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı oluşturma hattından geçer; bu nedenle aynı yedek kuralları normal metin gibi uygulanır.