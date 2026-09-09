---
title: Metin Kutusu
type: docs
weight: 40
url: /tr/python-java/examples/elements/text-box/
keywords:
- kod örneği
- metin kutusu
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java içinde metin kutularıyla çalışın: PowerPoint ve OpenDocument sunumlarında metin ekleyin, biçimlendirin, bulun ve kaldırın."
---
**Aspose.Slides for Python via Java** içinde bir metin kutusu, metin içeren bir otomatik şekildir. Neredeyse tüm şekiller metin içerebilir, ancak tipik bir metin kutusunun dolgu ya da kenarlığı yoktur ve yalnızca metni gösterir.

Bu kılavuz, programlı olarak metin kutularını nasıl ekleyeceğinizi, erişeceğinizi ve kaldıracağınızı açıklar.

Paketi, [Kurulum](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Metin Kutusu Ekle**

Bir dikdörtgen oluşturun, dolgu ve kenarlığını kaldırın ve biçimlendirilmiş metni atayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Bir dikdörtgen şekil oluştur.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Dolgu ve kenarlığı kaldırarak yalnızca metni göster.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Varsayılan metin biçimlendirmesini ayarla.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **İçeriğe Göre Metin Kutularına Erişim**

Örnek bir metin kutusu ekleyin, ardından metni "Slide" anahtar kelimesini içeren şekilleri bulun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Eşleşen metin kutusunu kullan.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **İçeriğe Göre Metin Kutularını Kaldır**

İlk slaytta belirli bir anahtar kelimeyi içeren metin kutularını bulun ve silin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="İpucu" %}}
İterasyon sırasında şekil koleksiyonunu değiştirmemek için, eşleşen şekilleri kaldırmadan önce ayrı bir listede toplayın.
{{% /alert %}}