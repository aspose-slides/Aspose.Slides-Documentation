---
title: Python ile Java aracılığıyla Sunumlardan Paragraf Sınırlarını Almak
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/python-java/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Python için Aspose.Slides'ta Java aracılığıyla paragraf sınırlarını nasıl alacağınızı öğrenin ve PowerPoint sunumlarında metin konumlamasını optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta paragrafların sınırlarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. [Paragraph.getRect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#getRect) kullanarak bir [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) içinde paragraf dikdörtgeni nasıl alınacağını, tablo hücresi metin çerçevesi içindeki paragraf koordinatlarının nasıl elde edileceğini ve ölçüm birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **Bir Paragrafın Dikdörtgen Koordinatlarını Almak**

Bir paragrafın sınırlayıcı dikdörtgenini almak için [Paragraph.getRect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#getRect) kullanın.

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
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Bir Tablo Hücresi Metin Çerçevesi İçindeki Paragrafın Boyutunu Almak**

Bir tablo hücresi metin çerçevesindeki bir [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) boyutunu ve koordinatlarını almak için [Paragraph.getRect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#getRect) kullanın. Döndürülen dikdörtgen tablo hücresi metin çerçevesine görecelidir, bu nedenle slayt düzeyinde koordinatlara ihtiyacınız olduğunda tablo konumunu ve hücre offsetini ekleyin.

Aşağıdaki örnek, bir tablo hücresi içindeki paragraf sınırlarını alır ve bu sınırları görselleştirmek için slayta dikdörtgenler çizer:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Paragraflar puan (point) cinsinden ölçülür; 1 inç 72 puana eşittir. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. Eğer [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) için [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setWrapText) etkinleştirilmişse, metin alan genişliğine sığacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde güvenilir bir şekilde piksellere dönüştürülebilir mi?**

Evet. Puanları bu formülle piksel'e dönüştürün: pixels = points x (DPI / 72). Sonuç, oluşturma veya dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil mirasını dikkate alarak "etkili" paragraf biçimlendirme parametrelerini nasıl alırım?**

[effective paragraph formatting data structure](/slides/tr/python-java/shape-effective-properties/) kullanın; girinti, boşluk, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.