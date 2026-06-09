---
title: Android'de Sunumlar için Yedek Fontları Yönetme
linktitle: Yedek Font
type: docs
weight: 50
url: /tr/androidjava/fallback-font/
keywords:
- yedek font
- kullanılabilir font
- glif değişimi
- font belirtme
- kural belirtme
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'in, orijinal fontlar mevcut olmadığında PowerPoint ve OpenDocument sunumlarında metnin okunabilirliğini korumak için yedek fontları nasıl kullandığını görün."
---
## **Giriş**

Yedek font, metin için belirtilen font sistemde mevcut olduğunda ancak bu font gerekli bir glifi içermediğinde kullanılır. Bu durumda, glif değişimi için belirtilen yedek fontlardan birini kullanmak mümkündür.

## **Yedek Font**

Aspose.Slides, yedek fontlar oluşturmanıza, bunları yedek font koleksiyonuna eklemenize, belirli bir sunum için yedek font koleksiyonunu ayarlamanıza, sunumdan yedek fontları kaldırmanıza, yedek fontların uygulanacağı kuralları belirlemenize ve diğer işlemlere olanak tanır.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Yedek Font Oluştur](/slides/tr/androidjava/create-fallback-font)
- [Yedek Font Koleksiyonu Oluştur](/slides/tr/androidjava/create-fallback-fonts-collection)
- [Yedek Font ile Sunumu Oluştur](/slides/tr/androidjava/render-presentation-with-fallback-font)

## **SSS**

**Yedek fontlar font ikamesinden nasıl farklıdır?**

Yedek, birincil font belirli glifleri içermediğinde karakter başına veya Unicode aralığı başına uygulanır; yalnızca eksik karakterleri doldurur. [İkame](/slides/tr/androidjava/font-substitution/) eksik ya da mevcut olmayan bir fontu bir bütün metin akışı veya metin parçası için başka bir fontla değiştirir. Kombine edilebilirler, ancak kapsamları ve seçim mantıkları farklıdır.

**Yedek ayarları sunum dosyasının içinde kaydedilir mi?**

Hayır. Yedek yapılandırması, kütüphanede işleme/oluşturma zamanında bulunur ve PPTX dosyasına serileştirilmez. Sunum, yedek kurallarınızı depolamaz.

**Yedek, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı renderleme boru hattından geçer, bu yüzden aynı yedek kuralları normal metin gibi uygulanır.