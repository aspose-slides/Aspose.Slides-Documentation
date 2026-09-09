---
title: Python üzerinden Java ile Sunumlarda Metin Bölüm Sınırlarını Alın
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/python-java/portion-bounds/
keywords:
- metin bölüm sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında metin bölüm sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraftaki belirli bir metin parçacığını temsil eder ve bu parçacıkla çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides içinde, bir metin parçacığının sınırlarını almak, bir paragrafın yalnızca bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde bölümler kullanılabilir.

Bu makale, bir bölümü [Portion.getRect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getRect) kullanarak sınırlayan dikdörtgeni nasıl alacağınızı gösterir. Ayrıca, bir bölümün başlangıç koordinatlarını [Portion.getCoordinates](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getCoordinates) kullanarak nasıl elde edeceğinizi gösterir. Ek olarak, tek bir metin parçacığına hiperlink uygulama, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı aracılığıyla nasıl çözüldüğünü anlama ve belirtilen bir yazı tipinin mevcut olmaması durumlarını ele alma gibi yaygın bölümle ilgili senaryoları vurgular.

## **Metin Bölümünün Sınırlarını Almak**

Metin bölümünün sınırlayan dikdörtgenini elde etmek için [Portion.getRect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getRect) kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Metin Bölümünün Koordinatlarını Almak**

Metin bölümünün başlangıç koordinatlarını elde etmek için [Portion.getCoordinates](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getCoordinates) kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **SSS**

**Tek bir paragraftaki metnin yalnızca bir kısmına hiperlink uygulayabilir miyim?**

Evet, bireysel bir bölüme [bir hiperlink atayın](/slides/tr/python-java/manage-hyperlinks/) yapabilirsiniz; yalnızca o parçacık tıklanabilir olur, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir bölüm neyi geçersiz kılar ve neyi paragraftan veya metin çerçevesinden alır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) üzerinde ayarlanmamışsa, Aspose.Slides onu [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/python-java/aspose.slides/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda yoksa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/python-java/font-selection-sequence/) uygulanır. Metin yeniden akabilir: ölçümler, heceleme ve genişlik değişebilir, bu da hassas konumlandırma için önemlidir.

**Paragrafın geri kalanından bağımsız olarak bölüme özgü metin dolgu şeffaflığı veya bir degrade ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/) düzeyinde metin rengi, dolgu ve şeffaflık, yan yana gelen parçacıklardan farklı olabilir.