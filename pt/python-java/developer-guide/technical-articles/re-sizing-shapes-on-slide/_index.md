---
title: Redimensionar Formas em Slides de Apresentação em Python via Java
type: docs
weight: 110
url: /pt/python-java/resizing-shapes-on-slide/
aliases:
  - /pt/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para Python via Java — automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Ao alterar o tamanho do slide de uma apresentação, pode ser necessário redimensionar e reposicionar suas formas para que se ajustem às novas dimensões. Este artigo mostra como dimensionar formas manualmente e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar Formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique suas coordenadas horizontais e a largura pela razão entre a nova largura do slide e a largura original. Aplique a razão de altura correspondente às coordenadas verticais e à altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) com [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) para que o loop subsequente controle o dimensionamento. As razões são adimensionais; as posições e dimensões das formas são medidas em pontos. Razões diferentes de largura e altura podem distorcer as formas, e alterar as dimensões de uma forma não dimensiona seus tamanhos de fonte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Calcule fatores de escala horizontais e verticais independentes.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
As tabelas requerem tratamento separado: dimensione a largura das colunas e a altura das linhas em vez de atribuir a largura e altura geral da tabela. As alturas das linhas podem permanecer maiores que o solicitado se o conteúdo da célula exigir mais espaço.
{{% /alert %}}

O segundo exemplo oferece suporte a tabelas e processa formas em mestres e layouts, bem como em slides individuais, antes de salvar a apresentação redimensionada. Seu auxiliar manipula cada [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) dimensionando a largura das colunas com [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) e as alturas mínimas das linhas com [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Em seguida, dimensiona a posição da tabela sem dimensionar separadamente suas dimensões gerais.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # As dimensões da tabela são controladas pelas larguras das colunas e alturas das linhas.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Calcule fatores de escala horizontais e verticais independentes.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Redimensione formas definidas em mestres e layouts, bem como em slides individuais.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Por que as formas ficam distorcidas ou cortadas depois de redimensionar um slide?**

Se você alterar o tamanho do slide sem dimensionar as formas, elas mantêm suas posições e dimensões originais e podem ultrapassar o slide. Dimensionar a largura e a altura por razões diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera os limites da forma diretamente e destina‑se a slides sem tabelas. O segundo exemplo trata as tabelas separadamente. Verifique o layout resultante, particularmente texto e tabelas, pois esses exemplos não dimensionam os tamanhos de fonte e o conteúdo da tabela pode restringir as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Dimensione a largura das colunas pela razão de largura e as alturas mínimas das linhas pela razão de altura, depois dimensione a posição da tabela, como mostrado no segundo exemplo.

**Esse redimensionamento funciona para slides mestre e slides de layout?**

Sim. O segundo exemplo itera através de [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) e dos [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) de cada mestre e aplica a mesma lógica de redimensionamento às suas formas.

**Posso alterar a orientação de um slide (retrato/paisagem) ao redimensionar?**

Sim. Chame [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) após alterar o tamanho do slide e antes de ler as dimensões alvo, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho do slide que eu posso definir?**

Você pode especificar dimensões de slide personalizadas com [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). As dimensões suportadas também dependem do formato da apresentação e do aplicativo usado para abrir o arquivo.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para encaixar o layout original dentro das novas dimensões do slide, use a menor das razões de largura e altura para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço não utilizado em uma das bordas.