---
title: Not
type: docs
weight: 240
url: /tr/python-java/examples/elements/note/
keywords:
- kod örneği
- not
- konuşmacı notu
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da slayt notlarıyla çalışın: PowerPoint ve OpenDocument sunumlarında konuşmacı notlarını ekleyin, okuyun, kaldırın ve güncelleyin."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak not slaytlarını ekleme, okuma, kaldırma ve güncelleme yöntemlerini göstermektedir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'i başlatmadan önce `asposeslides` kütüphanesini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Not Slaytı Ekle**

Bir not slaytı oluşturun ve ona metin atayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Not Slaytı Eriş**

Mevcut bir not slaytından metni okuyun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Not Slaytı Kaldır**

Bir slayt ile ilişkilendirilmiş not slaytını kaldırın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Not Metnini Güncelle**

Bir not slaytının metnini değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```