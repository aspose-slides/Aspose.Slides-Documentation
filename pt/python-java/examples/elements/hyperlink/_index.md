---
title: Hyperlink
type: docs
weight: 130
url: /pt/python-java/examples/elements/hyperlink/
keywords:
- exemplo de código
- hyperlink
- adicionar hyperlink
- acessar hyperlink
- remover hyperlink
- atualizar hyperlink
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Adicionar e gerenciar hyperlinks no Aspose.Slides para Python via Java: criar, acessar, remover e atualizar links em apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como adicionar, acessar, remover e atualizar hyperlinks em formas usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Instalação](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM e, em seguida, importa a API após a JVM estar em execução.

## **Adicionar um Hyperlink**

Crie uma forma retangular com um hyperlink apontando para um site externo.

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

## **Acessar um Hyperlink**

Leia as informações do hyperlink a partir da porção de texto de uma forma.

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

## **Remover um Hyperlink**

Remova o hyperlink do texto de uma forma.

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

## **Atualizar um Hyperlink**

Altere o destino de um hyperlink existente. Use [HyperlinkManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/) para modificar texto que já contém um hyperlink, o que imita como o PowerPoint atualiza hyperlinks de forma segura.

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

    # Alterar um hyperlink dentro de texto existente deve ser feito via
    # HyperlinkManager em vez de definir a propriedade diretamente.
    # Isso imita como o PowerPoint atualiza hyperlinks com segurança.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```