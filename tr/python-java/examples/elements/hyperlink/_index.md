---
title: Köprü
type: docs
weight: 130
url: /tr/python-java/examples/elements/hyperlink/
keywords:
- kod örneği
- köprü
- köprü ekle
- köprüyü al
- köprüyü kaldır
- köprüyü güncelle
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java içinde köprü ekleme ve yönetme: PPT, PPTX ve ODP sunumlarında bağlantıları oluşturma, erişme, kaldırma ve güncelleme."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak şekillerdeki köprüleri ekleme, erişme, kaldırma ve güncelleme işlemlerini göstermektedir.

Paketi, [Installation](/slides/tr/python-java/installation/) içinde açıklandığı gibi kurun. Her örnek, JVM başlatılmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Köprü Ekle**

Harici bir web sitesine yönlendiren bir köprüye sahip bir dikdörtgen şekil oluşturun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Köprüyü Eriş**

Bir şeklin metin bölümünden köprü bilgilerini okuyun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Köprüyü Kaldır**

Bir şeklin metnindeki köprüyü temizleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Köprüyü Güncelle**

Mevcut bir köprünün hedefini değiştirin. Köprü içeren metni güvenli bir şekilde güncelleyen PowerPoint'in davranışını taklit eden [HyperlinkManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkmanager/) kullanarak metni değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Mevcut metin içinde bir köprüyü değiştirmek, şu şekilde yapılmalıdır:
    # HyperlinkManager kullanılarak, özelliği doğrudan ayarlamaktan ziyade.
    # Bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şeklini taklit eder.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```