---
title: Python'da Sunum Slaytlarını Karşılaştır
linktitle: Slaytları Karşılaştır
type: docs
weight: 50
url: /tr/python-net/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarını programlı olarak karşılaştırın. Kodda slayt farklarını hızlıca tespit edin."
---
## **Genel Bakış**

Aspose.Slides, `BaseSlide` sınıfı tarafından sağlanan `equals` yöntemini kullanarak slaytları, düzen slaytlarını ve ana slaytları karşılaştırmanıza olanak tanır. Bu yöntem, karşılaştırılan slaytların yapı ve statik içerik açısından aynı olması durumunda `True` döndürür.

## **İki Slaytı Karşılaştır**
`equals` yöntemi [BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfına eklenmiştir. Yapı ve statik içerik açısından aynı olan slayt/yerleşim ve slayt/ana slaytlar için true döndürür.

İki slayt, tüm şekiller, stiller, metinler, animasyon ve diğer ayarlar aynıysa eşittir. vb. Karşılaştırma, SlideId gibi özgün tanımlayıcı değerlerini ve Tarih Yer Tutucusundaki geçerli tarih değeri gibi dinamik içeriği dikkate almaz.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **SSS**

**Bir slaytın gizli olması, slaytların kendisinin karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/hidden/) bir sunum/oynatım seviyesi özelliğidir, görsel içerik değildir. İki belirli slaytın eşitliği, yapı ve statik içerikleriyle belirlenir; bir slaytın gizli olması yalnızca slaytları farklı kılmaz.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar bir slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklıysa, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik dış bir Excel dosyasına referans veriyorsa, o dosyanın içeriği dikkate alınır mı?**

Hayır. Karşılaştırma, yalnızca slaytların kendisine dayanarak yapılır. Dış veri kaynakları genellikle karşılaştırma sırasında okunmaz; yalnızca slaytın yapısında ve statik durumunda bulunanlar dikkate alınır.