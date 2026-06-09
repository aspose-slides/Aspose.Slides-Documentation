---
title: Python'da Sunumlar için Yedek Yazı Tiplerini Yönetme
linktitle: Yedek Yazı Tipi
type: docs
weight: 50
url: /tr/python-net/fallback-font/
keywords:
- yedek yazı tipi
- mevcut yazı tipi
- glif değiştirme
- yazı tipi belirtme
- kural belirtme
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'in, orijinal yazı tipleri mevcut olmadığında PowerPoint ve OpenDocument sunumlarında metni okunabilir tutmak için yedek yazı tiplerini nasıl kullandığını görün."
---
## **Giriş**

Yedek yazı tipleri, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli bir glifi içermediğinde kullanılır. Bu durumda, Aspose.Slides eksik glifi yerine koymak için belirtilen yedek yazı tiplerinden birini kullanabilir.

## **Yedek Yazı Tipi**

Aspose.Slides yedek yazı tipleri oluşturmanıza, bunları yedek yazı tipleri koleksiyonuna eklemenize, belirli bir sunum için yedek yazı tipi koleksiyonunu ayarlamanıza, sunumdan yedek yazı tiplerini kaldırmanıza, yedek yazı tiplerinin uygulanacağı kuralları belirtmenize ve diğer işlemlere olanak tanır.

Bu özelliklere aşina olmak için aşağıdaki linkleri kullanın:

- [Yedek Yazı Tipi Oluştur](/slides/tr/python-net/create-fallback-font)
- [Yedek Yazı Tipi Koleksiyonu Oluştur](/slides/tr/python-net/create-fallback-fonts-collection)
- [Yedek Yazı Tipiyle Sunumu İşleme](/slides/tr/python-net/render-presentation-with-fallback-font)

## **SSS**

**Yedek yazı tipleri yazı tipi yerine koymadan nasıl farklıdır?**

Yedekleme, birincil yazı tipi belirli gliflere sahip olmadığında her karakter ya da Unicode aralığı başına uygulanır; yalnızca eksik karakterleri doldurur. [Yerine Koyma](/slides/tr/python-net/font-substitution/) ise eksik ya da bulunamayan bir yazı tipini tüm bir paragraf veya metin bölümü için başka bir yazı tipiyle değiştirir. İkisi bir arada kullanılabilir, ancak kapsamları ve seçim mantıkları farklıdır.

**Yedekleme ayarları sunum dosyasının içinde kaydedilir mi?**

Hayır. Yedekleme yapılandırması, kütüphanede işleme/rendering zamanında bulunur ve PPTX dosyasına serileştirilmez. Sunum yedekleme kurallarınızı depolamaz.

**Yedekleme, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı rendering boru hattından geçer, bu yüzden aynı yedekleme kuralları normal metin gibi uygulanır.