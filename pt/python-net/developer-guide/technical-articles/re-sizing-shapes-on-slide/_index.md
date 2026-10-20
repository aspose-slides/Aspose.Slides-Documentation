---
title: Redimensionar formas em slides de apresentação em Python
type: docs
weight: 130
url: /pt/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /pt/python-net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para Python via .NET — automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Ao alterar o tamanho do slide de uma apresentação, pode ser necessário redimensionar e reposicionar suas formas para que se ajustem às novas dimensões. Este artigo mostra como dimensionar formas manualmente e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique suas coordenadas horizontais e largura pela razão entre a nova largura do slide e a largura original. Aplique a razão de altura correspondente às suas coordenadas verticais e altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) com [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) para que o loop subsequente controle o dimensionamento. As razões são adimensionais; as posições e dimensões das formas são medidas em pontos. Razões diferentes de largura e altura podem distorcer as formas, e alterar as dimensões de uma forma não redimensiona seus tamanhos de fonte.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Calcular fatores de escala horizontal e vertical independentes.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
As tabelas exigem tratamento separado: dimensione suas larguras de coluna e alturas de linha em vez de atribuir a largura e altura gerais da tabela. As alturas das linhas podem permanecer maiores que o solicitado se o conteúdo da célula exigir mais espaço.
{{% /alert %}}

O segundo exemplo suporta tabelas e processa formas em mestres e layouts, bem como em slides individuais, antes de salvar a apresentação redimensionada. Seu auxiliar manipula cada [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) dimensionando [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) e [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Em seguida, dimensiona a posição da tabela sem dimensionar separadamente suas dimensões globais.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # As dimensões da tabela são controladas pelas larguras das colunas e alturas das linhas.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Calcular fatores de escala horizontal e vertical independentes.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Redimensionar formas definidas em mestres e layouts, bem como em slides individuais.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Se você alterar o tamanho do slide sem dimensionar as formas, elas mantêm suas posições e dimensões originais e podem se estender além do slide. Dimensionar a largura e a altura por razões diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera os limites da forma diretamente e destina‑se a slides sem tabelas. O segundo exemplo lida com tabelas separadamente. Verifique o layout resultante, particularmente texto e tabelas, pois esses exemplos não dimensionam tamanhos de fonte e o conteúdo da tabela pode limitar as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Dimensione as larguras das colunas pela razão de largura e as alturas mínimas das linhas pela razão de altura, depois dimensione a posição da tabela, como mostrado no segundo exemplo.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim. O segundo exemplo percorre [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) e os [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) de cada mestre e aplica a mesma lógica de redimensionamento às suas formas.

**Posso alterar a orientação de um slide (retrato/paisagem) juntamente com o redimensionamento?**

Sim. Defina [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) após alterar o tamanho do slide e antes de ler as dimensões alvo, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho de slide que posso definir?**

Você pode especificar dimensões de slide personalizadas com [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). As dimensões suportadas também dependem do formato da apresentação e do aplicativo usado para abrir o arquivo.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para ajustar o layout original dentro das novas dimensões do slide, use a menor das razões de largura e altura para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço não utilizado ao longo de uma borda.