---
title: ActiveX
type: docs
weight: 200
url: /tr/python-java/examples/elements/activex/
keywords:
- kod örneği
- ActiveX
- ActiveX kontrolü
- ActiveX özellikleri
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında ActiveX kontrollerini eklemek, erişmek, kaldırmak ve yapılandırmak için pratik kod örnekleri."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak bir sunumda ActiveX kontrolünü ekleme, erişme, kaldırma ve yapılandırma yöntemlerini gösterir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır. Erişim ve kaldırma örnekleri, ilk örnek tarafından oluşturulan `add_activex.pptm` dosyasını kullanır.

## **ActiveX Kontrolü Ekle**

İlk slayta bir Windows Media Player kontrolü ekleyin ve sunumu PPTM dosyası olarak kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player kontrolü ekle.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX Kontrolüne Erişme**

Slayttaki ilk ActiveX kontrolünün adını ve otomatik oynatma ayarını okuyun.

```python
import jpale
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # İlk ActiveX kontrolüne eriş.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **ActiveX Kontrolünü Kaldırma**

Slayttan ilk ActiveX kontrolünü silin ve değiştirilen sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # İlk ActiveX kontrolünü kaldır.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX Özelliklerini Ayarlama**

Bir Windows Media Player kontrolü ekleyin, otomatik oynatmayı devre dışı bırakın ve oynatma kontrollerini gizleyin. Özellik değerlerini dize olarak atamak için [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/tr/python-java/aspose.slides/controlpropertiescollection/#set_Item) kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player kontrolü ekle ve özelliklerini yapılandır.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```