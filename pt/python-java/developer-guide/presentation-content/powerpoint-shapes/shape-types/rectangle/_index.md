---
title: Adicionar Retângulos às Apresentações em Python via Java
linktitle: Retângulo
type: docs
weight: 80
url: /pt/python-java/rectangle/
keywords:
- adicionar retângulo
- criar retângulo
- forma de retângulo
- retângulo simples
- retângulo formatado
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Potencialize suas apresentações PowerPoint adicionando retângulos com Aspose.Slides para Python via Java - projete e modifique formas programaticamente com facilidade."
---
## **Visão geral**

Este artigo mostra como adicionar formas retangulares aos slides do PowerPoint usando Aspose.Slides. Ele cobre a criação de um retângulo simples, a criação de um retângulo formatado e a gravação da apresentação atualizada como um arquivo PPTX.

Você também verá como aplicar formatação básica de retângulo, como cor de preenchimento sólida, cor da linha e largura da linha. Além disso, a seção de perguntas frequentes do artigo aponta para tarefas relacionadas a retângulos, incluindo cantos arredondados, preenchimentos com imagem, efeitos visuais, hyperlinks, bloqueios de forma, opções de exportação e propriedades efetivas.

## **Adicionar um Retângulo a um Slide**

Para adicionar um retângulo simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Obtenha uma referência a um slide pelo seu índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) do tipo retângulo usando o método [addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um retângulo simples ao primeiro slide da apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instancie a classe Presentation que representa o arquivo PPTX.
presentation = Presentation()
try:
    # Obtenha o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicione uma forma retangular.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Grave o arquivo PPTX no disco.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar um Retângulo Formatado a um Slide**

Para adicionar um retângulo formatado a um slide, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Obtenha uma referência a um slide pelo seu índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) do tipo retângulo usando o método [addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).
- Defina o [fill type](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) do retângulo como sólido.
- Defina a cor do retângulo usando o método [setColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/colorformat/#setColor) na cor de preenchimento sólido do objeto [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/) associado ao objeto [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/).
- Defina a cor do contorno do retângulo.
- Defina a largura do contorno do retângulo.
- Grave a apresentação modificada como um arquivo PPTX.

As etapas acima são implementadas no exemplo abaixo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instancie a classe Presentation que representa o arquivo PPTX.
presentation = Presentation()
try:
    # Obtenha o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicione uma forma retangular.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formate o preenchimento do retângulo.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formate o contorno do retângulo.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Grave o arquivo PPTX no disco.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Como adiciono um retângulo com cantos arredondados?**

Use o [shape type](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/) de canto arredondado e ajuste o raio dos cantos nas propriedades da forma; o arredondamento também pode ser aplicado por canto via ajustes de geometria.

**Como preencho um retângulo com uma imagem (textura)?**

Selecione o [fill type](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) de imagem, forneça a fonte da imagem e configure os [stretching/tiling modes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillmode/).

**Um retângulo pode ter sombra e brilho?**

Sim. [Outer/inner shadow, glow, and soft edges](/slides/pt/python-java/shape-effect/) estão disponíveis com parâmetros ajustáveis.

**Posso transformar um retângulo em um botão com um hyperlink?**

Sim. [Assign a hyperlink](/slides/pt/python-java/manage-hyperlinks/) ao clique da forma (ir para um slide, arquivo, endereço web ou e‑mail).

**Como posso proteger um retângulo contra movimentação e alterações?**

[Use shape locks](/slides/pt/python-java/applying-protection-to-presentation/): você pode impedir movimentação, redimensionamento, seleção ou edição de texto para preservar o layout.

**Posso converter um retângulo em imagem raster ou SVG?**

Sim. Você pode [render the shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) para uma imagem com tamanho/escala especificados ou [export it as SVG](/slides/pt/python-java/create-shape-thumbnails/) para uso vetorial.

**Como obtenho rapidamente as propriedades reais (efetivas) de um retângulo considerando tema e herança?**

[Use the shape’s effective properties](/slides/pt/python-java/shape-effective-properties/): a API devolve valores calculados que levam em conta estilos de tema, layout e configurações locais, simplificando a análise de formatação.