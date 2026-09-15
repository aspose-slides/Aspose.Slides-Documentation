---
title: Redimensionar formas em slides de apresentação em Python via Java
type: docs
weight: 110
url: /pt/python-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para Python via Java—automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Uma das perguntas mais comuns dos clientes do Aspose.Slides para Python via Java é como redimensionar formas de modo que, ao mudar o tamanho do slide, os dados não sejam cortados. Este breve artigo técnico mostra como fazer isso.

## **Redimensionar formas**

Para evitar que as formas fiquem desalinhadas quando o tamanho do slide mudar, atualize a posição e as dimensões de cada forma para que se ajustem ao novo layout do slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Carregar o arquivo de apresentação.
presentation = Presentation("sample.ppt")
try:
    # Obter o tamanho original do slide.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Alterar o tamanho do slide sem escalar as formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Obter o novo tamanho do slide.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Redimensionar e reposicionar formas em cada slide.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Escalar o tamanho da forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Escalar a posição da forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
As tabelas não precisam de tratamento especial: definir a largura e a altura de uma tabela redimensiona suas colunas e linhas proporcionalmente, portanto redimensionar novamente as alturas das linhas e larguras das colunas aplicaria a proporção duas vezes.
{{% /alert %}} 

O código acima altera apenas as formas nos slides. Slides mestres e slides de layout mantêm suas próprias formas, portanto redimensione‑as também quando desejar que toda a apresentação siga o novo tamanho do slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Obter o tamanho original do slide.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Alterar o tamanho do slide sem escalar as formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Obter o novo tamanho do slide.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Escalar o tamanho da forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Escalar a posição da forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Escalar o tamanho da forma.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Escalar a posição da forma.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Escalar o tamanho da forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Escalar a posição da forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Ao redimensionar um slide, as formas mantêm sua posição e tamanho originais, a menos que a escala seja alterada explicitamente. Isso pode fazer com que o conteúdo seja recortado ou que as formas fiquem desalinhadas.

**O código fornecido funciona para todos os tipos de forma?**

Sim. Definir a altura e a largura funciona para caixas de texto, imagens, gráficos e tabelas igualmente.

**Como redimensionar tabelas ao redimensionar um slide?**

Redimensione a própria forma da tabela, exatamente como qualquer outra forma. Suas linhas e colunas são ajustadas proporcionalmente, portanto não as redimensione novamente depois.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim, mas você também deve percorrer [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters) e [Presentation.getLayoutSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getLayoutSlides) e aplicar a mesma lógica de escala às suas formas para garantir consistência em toda a apresentação.

**Posso mudar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Você pode usar [SlideSize.setOrientation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesize/#setOrientation) para mudar a orientação. Certifique‑se de ajustar a lógica de escala adequadamente para preservar o layout.

**Existe um limite para o tamanho do slide que eu posso definir?**

Aspose.Slides suporta tamanhos personalizados, mas tamanhos muito grandes podem afetar o desempenho ou a compatibilidade com algumas versões do PowerPoint.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Você pode verificar o método [getAspectRatioLocked](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) da trava da forma antes de escalar. Se estiver travada, ajuste a largura ou a altura proporcionalmente em vez de escalá‑las individualmente.