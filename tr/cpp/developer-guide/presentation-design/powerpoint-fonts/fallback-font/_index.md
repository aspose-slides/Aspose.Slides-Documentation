---
title: C++'ta Sunumlar İçin Yedek Yazı Tiplerini Yönet
linktitle: Yedek Yazı Tipi
type: docs
weight: 50
url: /tr/cpp/fallback-font/
keywords:
- yedek yazı tipi
- kullanılabilir yazı tipi
- glif değişimi
- yazı tipi belirle
- kural belirle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'un yedek yazı tiplerini kullanarak, orijinal yazı tipleri mevcut olmadığında PowerPoint ve OpenDocument sunumlarında metnin okunabilirliğini nasıl koruduğunu görün."
---
## **Giriş**

Yedek yazı tipleri, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli bir glifi içermediğinde kullanılır. Bu durumda, Aspose.Slides eksik glifi değiştirmek için belirtilen yedek yazı tiplerinden birini kullanabilir.

## **Yedek Yazı Tipi**
Yedek yazı tipi, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak bu yazı tipi gerekli bir glifi içermediğinde kullanılır. Bu durumda, eksik glifi değiştirmek için belirtilen yedek yazı tiplerinden birini kullanmak mümkündür.

Aspose.Slides yedek yazı tipleri oluşturmayı, bunları yedek yazı tipleri koleksiyonuna eklemeyi, belirli bir sunum için yedek yazı tipleri koleksiyonunu ayarlamayı, sunumdan yedek yazı tiplerini kaldırmayı, yedek yazı tiplerinin uygulanacağı kuralları belirtmeyi ve diğer özellikleri sağlar.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Create Fallback Font](/slides/tr/cpp/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/tr/cpp/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/tr/cpp/render-presentation-with-fallback-font)

## **SSS**

**Yedek yazı tipleri yazı tipi ikamesinden nasıl farklıdır?**

Yedek, birincil yazı tipi belirli glifleri içermediğinde karakter başına ya da Unicode aralığı başına uygulanır; yalnızca eksik karakterleri doldurur. [Substitution](/slides/tr/cpp/font-substitution/) eksik ya da kullanılamayan bir yazı tipini tüm bir koşul ya da metin bölümü için başka bir yazı tipiyle değiştirir. Birlikte kullanılabilirler, ancak kapsamları ve seçim mantıkları farklıdır.

**Yedek ayarları sunum dosyasının içinde kaydedilir mi?**

Hayır. Yedek yapılandırması kütüphanede işleme/görüntüleme zamanında bulunur ve PPTX dosyasına serileştirilmez. Sunum, yedek kurallarınızı saklamaz.

**Yedek, PowerPoint nesneleri (SmartArt, grafikler, WordArt) ile oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı görüntüleme boru hattından geçer, bu yüzden aynı yedek kuralları normal metin gibi uygulanır.