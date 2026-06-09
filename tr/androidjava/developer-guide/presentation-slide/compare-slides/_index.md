---
title: Android'de Sunum Slaytlarını Karşılaştır
linktitle: Slaytları Karşılaştır
type: docs
weight: 50
url: /tr/androidjava/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint ve OpenDocument sunumlarını programlı olarak karşılaştırın. Java kodunda slayt farklarını hızlıca belirleyin."
---
## **Genel Bakış**

Aspose.Slides, `IBaseSlide` arayüzü ve `BaseSlide` sınıfı tarafından sağlanan `equals` yöntemi kullanarak slaytları, yerleşim slaytlarını ve ana slaytları karşılaştırmanıza olanak tanır. Bu yöntem, karşılaştırılan slaytlar yapı ve statik içerik açısından aynı olduğunda `true` döndürür.

## **İki Slaytı Karşılaştır**

Equals yöntemi [IBaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBaseSlide) arayüzüne ve [BaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/BaseSlide) sınıfına eklenmiştir. Yapı ve statik içerik açısından aynı olan slayt/yerleşim ve slayt/ana slaytlar için true döndürür.

İki slayt, tüm şekiller, stiller, metinler, animasyonlar ve diğer ayarlar vb. eşit olduğunda eşittir. Karşılaştırma, benzersiz kimlik değerlerini (ör. SlideId) ve dinamik içeriği (ör. Tarih Yer Tutucusundaki geçerli tarih değeri) dikkate almaz.

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

**Bir slaytın gizli olması, slaytların kendilerinin karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getHidden--) bir sunum/oynatım düzeyi özelliğidir, görsel içerik değildir. İki belirli slaytın eşitliği yapı ve statik içerikleriyle belirlenir; bir slaytın gizli olması sadece slaytları farklı kılmaz.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar bir slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklıysa, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik harici bir Excel dosyasına referans veriyorsa, dosyanın içeriği dikkate alınır mı?**

Hayır. Karşılaştırma, yalnızca slaytların kendilerine dayanarak yapılır. Dış veri kaynakları genellikle karşılaştırma sırasında okunmaz; yalnızca slaytın yapı ve statik durumunda bulunanlar dikkate alınır.