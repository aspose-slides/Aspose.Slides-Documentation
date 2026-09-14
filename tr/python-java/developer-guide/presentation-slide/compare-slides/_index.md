---
title: Python'da Sunum Slaytlarını Karşılaştır
linktitle: Slaytları Karşılaştır
type: docs
weight: 50
url: /tr/python-java/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarını programlı olarak karşılaştırın. Kod içinde slayt farklarını hızlıca belirleyin."
---
## **Genel Bakış**

Aspose.Slides, [BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) sınıfı tarafından sağlanan [equals](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#equals) yöntemini kullanarak slaytları, slayt düzenlerini ve ana slaytları karşılaştırmanıza olanak tanır. Bu yöntem, karşılaştırılan slaytlar yapı ve statik içerik açısından aynı olduğunda `True` döndürür.

## **İki Slaytı Karşılaştır**

[BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) sınıfındaki [equals](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#equals) yöntemi, yapı ve statik içerik açısından aynı olan slaytlar, slayt düzenleri ve ana slaytlar için `True` döndürür.

İki slayt, şekilleri, stilleri, metinleri, animasyonları ve diğer ayarları aynı ise eşittir. Karşılaştırma, slayt kimlikleri gibi benzersiz tanımlayıcı değerleri veya tarih yer tutucusundaki mevcut tarih gibi dinamik içeriği dikkate almaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **SSS**

**Bir slaytın gizli olması, slaytların kendisinin karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getHidden) bir sunum/oynatma seviyesi özelliğidir, görsel içerik değildir. İki belirli slaytın eşitliği, yapı ve statik içerikleriyle belirlenir; bir slaytın gizli olması slaytları farklı kılmaz.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar bir slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklıysa, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik harici bir Excel dosyasına başvuruyorsa, o dosyanın içeriği dikkate alınır mı?**

Hayır. Karşılaştırma yalnızca slaytların kendisine dayanarak yapılır. Harici veri kaynakları genellikle karşılaştırma sırasında okunmaz; sadece slaytın yapısında ve statik durumunda bulunanlar değerlendirilir.