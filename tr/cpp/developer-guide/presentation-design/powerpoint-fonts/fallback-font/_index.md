---
title: C++ Sunumları İçin Fallback Yazı Tiplerini Yönet
linktitle: Fallback Yazı Tipi
type: docs
weight: 50
url: /tr/cpp/fallback-font/
keywords:
- fallback yazı tipi
- mevcut yazı tipi
- glif değişimi
- yazı tipi belirt
- kural belirt
- PowerPoint
- OpenDocument
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++'nin fallback yazı tiplerini kullanarak, orijinal yazı tipleri mevcut olmadığında PowerPoint ve OpenDocument sunumlarında metnin okunabilirliğini nasıl koruduğunu görün."
---
## **Giriş**

Fallback yazı tipleri, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli glifi içermediğinde kullanılır. Bu durumda, Aspose.Slides eksik glifi yerine koymak için belirtilen fallback yazı tiplerinden birini kullanabilir.

## **Fallback Yazı Tipi**
Fallback yazı tipi, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak bu yazı tipi gerekli bir glifi içermediğinde kullanılır. Bu durumda, glif değişimi için belirtilen fallback yazı tiplerinden birini kullanmak mümkündür.

Aspose.Slides, fallback yazı tipleri oluşturmayı, bu yazı tiplerini fallback yazı tipi koleksiyonuna eklemeyi, belirli bir sunum için fallback yazı tipi koleksiyonunu ayarlamayı, sunumdan fallback yazı tiplerini kaldırmayı, fallback yazı tiplerinin uygulanacağı kuralları belirtmeyi ve diğer işlemleri sağlar.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Fallback Yazı Tipi Oluştur](/slides/tr/cpp/create-fallback-font)
- [Fallback Yazı Tipi Koleksiyonu Oluştur](/slides/tr/cpp/create-fallback-fonts-collection)
- [Fallback Yazı Tipi ile Sunumu İşleme](/slides/tr/cpp/render-presentation-with-fallback-font)

## **SSS**

**Fallback yazı tipleri yazı tipi ikamesinden nasıl farklıdır?**

Fallback, birincil yazı tipi belirli gliflere sahip olmadığında, karakter bazında ya da Unicode aralığı bazında uygulanır; yalnızca eksik karakterleri doldurur. [Substitution](/slides/tr/cpp/font-substitution/) eksik ya da bulunamayan bir yazı tipini tüm bir koşul ya da metin bölümü için başka bir yazı tipiyle değiştirir. Birlikte kullanılabilirler, ancak kapsamları ve seçim mantıkları farklıdır.

**Fallback ayarları sunum dosyasının içinde kaydedilir mi?**

Hayır. Fallback yapılandırması, kütüphanede işleme/görselleştirme zamanında bulunur ve PPTX dosyasına seri hale getirilmez. Sunum fallback kurallarınızı depolamaz.

**Fallback, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı rendering pipeline'dan geçer, bu yüzden aynı fallback kuralları normal metin gibi uygulanır.