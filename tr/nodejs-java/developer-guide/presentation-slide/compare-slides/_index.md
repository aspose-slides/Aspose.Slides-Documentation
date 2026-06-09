---
title: "JavaScript'te Sunum Slaytlarını Karşılaştırma"
linktitle: "Slaytları Karşılaştır"
type: docs
weight: 50
url: /tr/nodejs-java/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını, Node.js için Aspose.Slides ile Java üzerinden programlı olarak karşılaştırın. Kod içinde slayt farklılıklarını hızlıca tespit edin."
---
## **Genel Bakış**

Aspose.Slides, `BaseSlide` sınıfı tarafından sağlanan `equals` metodunu kullanarak slaytları, yerleşim slaytlarını ve ana slaytları karşılaştırmanıza olanak tanır. Bu metod, karşılaştırılan slaytların yapı ve statik içerik açısından aynı olması durumunda `true` döndürür.

## **İki Slaytı Karşılaştır**

Equals metodu [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BaseSlide) sınıfına ve [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BaseSlide) sınıfına eklenmiştir. Yapı ve statik içerik açısından aynı olan slayt/yerleşim ve slayt/ana slaytlar için `true` döndürür.

İki slayt, tüm şekiller, stiller, metinler, animasyonlar ve diğer ayarlar vb. eşit olduğunda eşittir. Karşılaştırma, SlideId gibi benzersiz kimlik değerlerini ve Tarih Yer Tutucusu içindeki mevcut tarih değeri gibi dinamik içeriği dikkate almaz.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **SSS**

**Bir slaytın gizli olması, slaytların karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/gethidden/) bir sunum/oynatma düzeyi özelliğidir, görsel içerik değildir. İki belirli slaytın eşitliği, yapı ve statik içeriklerine göre belirlenir; bir slaytın gizli olması yalnız başına slaytları farklı kılmaz.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar bir slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklıysa, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik harici bir Excel dosyasına atıfta bulunuyorsa, o dosyanın içeriği dikkate alınır mı?**

Hayır. Karşılaştırma, yalnızca slaytların kendileri üzerinden yapılır. Harici veri kaynakları genellikle karşılaştırma sırasında okunmaz; sadece slaytın yapısında ve statik durumunda bulunanlar değerlendirilir.