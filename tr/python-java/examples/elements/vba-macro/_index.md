---
title: VBA Makrosu
type: docs
weight: 150
url: /tr/python-java/examples/elements/vba-macro/
keywords:
- kod örneği
- VBA
- makro
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında VBA makrolarını ekleme, erişme ve kaldırma işlemlerini net, pratik kod örnekleriyle yapın."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak VBA makrolarını ekleme, erişme ve kaldırma yöntemlerini göstermektedir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklanan şekilde kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **VBA Makrosu Ekle**
VBA projesi ve basit bir makro modülü içeren bir sunum oluşturun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **VBA Makrosuna Eriş**
VBA projesinden ilk modülü alın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **VBA Makrosunu Kaldır**
VBA projesinden bir modülü silin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```