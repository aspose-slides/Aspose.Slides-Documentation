---
title: Gerenciar fundos de apresentação em Python via Java
linktitle: Fundo do slide
type: docs
weight: 20
url: /pt/python-java/presentation-background/
keywords:
- fundo de apresentação
- fundo de slide
- cor sólida
- cor gradiente
- fundo de imagem
- transparência de fundo
- propriedades de fundo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para Python via Java, com dicas de código para melhorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usadas como plano de fundo de slides. Você pode definir o plano de fundo para um **slide normal** (um único slide) ou um **slide mestre** (aplica‑se a vários slides de uma vez).

![Fundo do PowerPoint](powerpoint-background.png)

## **Definir um plano de fundo de cor sólida para um slide normal**

Aspose.Slides permite definir uma cor sólida como plano de fundo para um slide específico em uma apresentação — mesmo que a apresentação use um slide mestre. A alteração se aplica apenas ao slide selecionado.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) do plano de fundo do slide como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getsolidfillcolor) em [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma cor azul sólida como plano de fundo para um slide normal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Defina a cor de fundo do slide como azul.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Salve a apresentação no disco.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir um plano de fundo de cor sólida para um slide mestre**

Aspose.Slides permite definir uma cor sólida como plano de fundo para o slide mestre em uma apresentação. O slide mestre atua como um modelo que controla a formatação de todos os slides, portanto, ao escolher uma cor sólida para o plano de fundo do slide mestre, ela será aplicada a todos os slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/backgroundtype/) do slide mestre (por meio de [getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getmasters)) como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) do plano de fundo do slide mestre como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getsolidfillcolor) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma cor sólida (verde) como plano de fundo para um slide mestre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Defina a cor de fundo do slide mestre como verde.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Salve a apresentação no disco.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir um plano de fundo gradiente para um slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como plano de fundo de um slide, os gradientes podem deixar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor gradiente como plano de fundo para slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) do plano de fundo do slide como `Gradient`.
4. Use o método [getGradientFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getgradientformat) em [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/) para configurar as configurações de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma cor gradiente como plano de fundo para um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aplique um efeito de gradiente ao fundo.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Adicione as cores do gradiente. Sem paradas de gradiente, o fundo volta a usar um degradê padrão de preto para branco.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Salve a apresentação no disco.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir uma imagem como plano de fundo de slide**

Além de preenchimentos sólidos e gradientes, Aspose.Slides permite usar imagens como plano de fundo de slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) do plano de fundo do slide como `Picture`.
4. Carregue a imagem que deseja usar como plano de fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use o método [getPictureFillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getpicturefillformat) em [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/) para atribuir a imagem como plano de fundo.
7. Salve a apresentação modificada.

O exemplo Python a seguir mostra como definir uma imagem como plano de fundo de um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Defina as propriedades da imagem de fundo.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Carregue a imagem.
    image = Images.fromFile("Tulips.jpg")
    # Adicione a imagem à coleção de imagens da apresentação.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Salve a apresentação no disco.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O trecho de código a seguir mostra como definir o tipo de preenchimento de fundo como uma imagem em mosaico e modificar as propriedades de repetição:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Defina a imagem usada para o preenchimento de fundo.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Defina o modo de preenchimento da imagem como Ladrilho e ajuste as propriedades do ladrilho.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Observação" %}}
Ler mais: [Imagem em mosaico como textura](/slides/pt/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Alterar a transparência da imagem de fundo**

Você pode querer ajustar a transparência da imagem de fundo de um slide para que o conteúdo do slide se destaque. O código Python a seguir mostra como alterar a transparência da imagem de fundo de um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Por exemplo.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Obtenha a coleção de operações de transformação de imagem.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Encontre um efeito de transparência de porcentagem fixa existente.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Defina o novo valor de transparência.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obter o valor do plano de fundo do slide**

Aspose.Slides permite recuperar os valores efetivos de plano de fundo de um slide usando o método [getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/background/#geteffective) em [Background](https://reference.aspose.com/slides/pt/python-java/aspose.slides/background/). Os dados retornados expõem os formatos efetivos de preenchimento e efeito.

Usando o método [getBackground](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getbackground) da classe [BaseSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/), você pode obter o plano de fundo de um slide.

O exemplo Python a seguir mostra como obter o valor efetivo do plano de fundo de um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Crie uma instância da classe Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Recupere o fundo efetivo, levando em conta mestre, layout e tema.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Posso redefinir um plano de fundo personalizado e restaurar o plano de fundo do tema/layout?**

Sim. Remova o preenchimento personalizado do slide, e o plano de fundo será herdado novamente do slide de [layout](/slides/pt/python-java/slide-layout)/[master](/slides/pt/python-java/slide-master) correspondente (ou seja, do [plano de fundo do tema](/slides/pt/python-java/presentation-theme)).

**O que acontece com o plano de fundo se eu mudar o tema da apresentação mais tarde?**

Se um slide possui seu próprio preenchimento, ele permanecerá inalterado. Se o plano de fundo for herdado do [layout](/slides/pt/python-java/slide-layout)/[master](/slides/pt/python-java/slide-master), ele será atualizado para corresponder ao [novo tema](/slides/pt/python-java/presentation-theme).