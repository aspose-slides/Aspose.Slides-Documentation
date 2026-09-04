---
title: ActiveX
type: docs
weight: 200
url: /pt/python-java/examples/elements/activex/
keywords:
- exemplo de código
- ActiveX
- controle ActiveX
- propriedades ActiveX
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Use o Aspose.Slides for Python via Java para adicionar, acessar, remover e configurar controles ActiveX em apresentações PowerPoint com exemplos de código práticos."
---
Este artigo demonstra como adicionar, acessar, remover e configurar controles ActiveX em uma apresentação usando **Aspose.Slides for Python via Java**.

Instale o pacote como descrito em [Instalação](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, depois importa a API após a JVM estar em execução. Os exemplos de acesso e remoção usam `add_activex.pptm`, criado pelo primeiro exemplo.

## **Adicionar um controle ActiveX**

Insira um controle do Windows Media Player no primeiro slide e salve a apresentação como um arquivo PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar um controle do Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Acessar um controle ActiveX**

Leia o nome e a configuração de reprodução automática do primeiro controle ActiveX no slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Acessar o primeiro controle ActiveX.
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

## **Remover um controle ActiveX**

Exclua o primeiro controle ActiveX do slide e salve a apresentação modificada.

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
            # Remover o primeiro controle ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Definir propriedades do ActiveX**

Adicione um controle do Windows Media Player, desative a reprodução automática e oculte os controles de reprodução. Use [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/pt/python-java/aspose.slides/controlpropertiescollection/#set_Item) para atribuir valores de propriedade como strings.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar um controle do Windows Media Player e configurar suas propriedades.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```