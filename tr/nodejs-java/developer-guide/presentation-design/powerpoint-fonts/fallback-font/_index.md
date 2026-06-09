---
title: JavaScript'te Sunumlar İçin Yedek Yazı Tiplerini Yönetme
linktitle: Yedek Yazı Tipi
type: docs
weight: 50
url: /tr/nodejs-java/fallback-font/
keywords:
- yedek yazı tipi
- mevcut yazı tipi
- glif değişimi
- yazı tipi belirtme
- kural belirtme
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'nin yedek yazı tiplerini nasıl kullandığını, orijinal yazı tipleri mevcut olmadığında PowerPoint ve OpenDocument sunumlarında metnin okunabilirliğini korumak için inceleyin."
---
## **Giriş**

Yedek yazı tipleri, metin için belirtilen yazı tipi sistemde mevcut olduğunda ancak gerekli bir glifi içermediğinde kullanılır. Bu durumda, Aspose.Slides belirtilen yedek yazı tiplerinden birini kullanarak eksik glifi değiştirebilir.

## **Yedek Yazı Tipi**

Aspose.Slides yedek yazı tipleri oluşturmanıza, bunları yedek yazı tipleri koleksiyonuna eklemenize, belirli bir sunum için yedek yazı tipi koleksiyonunu ayarlamanıza, yedek yazı tiplerini sunumdan kaldırmanıza, yedek yazı tiplerinin uygulanacağı kuralları belirtmenize ve diğer işlemlere olanak tanır.

Bu özelliklere aşina olmak için aşağıdaki bağlantıları kullanın:

- [Yedek Yazı Tipi Oluştur](/slides/tr/nodejs-java/create-fallback-font)
- [Yedek Yazı Tipleri Koleksiyonu Oluştur](/slides/tr/nodejs-java/create-fallback-fonts-collection)
- [Yedek Yazı Tipi ile Sunumu İşleme](/slides/tr/nodejs-java/render-presentation-with-fallback-font)

## **SSS**

**Yedek yazı tipleri font değiştirme (substitution) ile nasıl farklıdır?**

Yedek yazı tipleri, birincil yazı tipi belirli glifleri içermediğinde, karakter bazında veya Unicode aralığı bazında uygulanır; sadece eksik karakterleri doldurur. [Substitution](/slides/tr/nodejs-java/font-substitution/) eksik veya kullanılamayan bir yazı tipini bir bütün olarak bir koşulda ya da metin parçasında başka bir yazı tipiyle değiştirir. İkisi birleştirilebilir, ancak kapsamları ve seçim mantıkları farklıdır.

**Yedek ayarları sunum dosyasında kaydedilir mi?**

Hayır. Yedek yapılandırması, kitaplıkta işleme/işleme zamanında bulunur ve PPTX dosyasına serileştirilmez. Sunum, yedek kurallarınızı depolamaz.

**Yedek, PowerPoint nesneleri (SmartArt, grafikler, WordArt) tarafından oluşturulan öğeleri etkiler mi?**

Evet. Bu nesneler içindeki metin aynı işleme boru hattından geçer, bu nedenle aynı yedek kuralları normal metin gibi uygulanır.