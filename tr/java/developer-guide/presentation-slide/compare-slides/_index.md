---
title: Java’da Sunum Slaytlarını Karşılaştırın
linktitle: Slaytları Karşılaştır
type: docs
weight: 50
url: /tr/java/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile programlı olarak PowerPoint ve OpenDocument sunumlarını karşılaştırın. Kod içinde slayt farklılıklarını hızlı bir şekilde belirleyin."
---
## **Genel Bakış**

Aspose.Slides, `IBaseSlide` arayüzü ve `BaseSlide` sınıfı tarafından sağlanan `equals` yöntemini kullanarak slaytları, düzen slaytlarını ve ana slaytları karşılaştırmanıza olanak tanır. Bu yöntem, karşılaştırılan slaytların yapısı ve statik içeriği bakımından aynı olması durumunda `true` döndürür.

## **İki Slaytı Karşılaştır**

Equals yöntemi [IBaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IBaseSlide) arayüzüne ve [BaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/BaseSlide) sınıfına eklenmiştir. Yapısı ve statik içeriği bakımından aynı olan slayt/düzen ve slayt/ana slaytlar için true döndürür.

İki slayt, tüm şekiller, stiller, metinler, animasyonlar ve diğer ayarlar vb. aynı olduğunda eşittir. Karşılaştırma, SlideId gibi benzersiz tanımlayıcı değerleri ve Tarih Yer Tutucu'daki geçerli tarih değeri gibi dinamik içeriği dikkate almaz.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
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

**Bir slaytın gizli olması, slaytların kendisinin karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getHidden--) bir sunum/oynatım düzeyinde özelliktir, görsel içerik değildir. İki belirli slaytın eşitliği, yapı ve statik içerikleriyle belirlenir; bir slaytın gizli olması yalnızca slaytları farklı kılmaz.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar bir slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklıysa, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik harici bir Excel dosyasına referans veriyorsa, o dosyanın içeriği dikkate alınır mı?**

Hayır. Karşılaştırma, yalnızca slaytların kendisine dayanarak yapılır. Dış veri kaynakları genellikle karşılaştırma sırasında okunmaz; sadece slaytın yapısında ve statik durumunda bulunanlar dikkate alınır.