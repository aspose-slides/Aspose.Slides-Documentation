---
title: Redimensionar Formas em Apresentações com Python
linktitle: Redimensionamento de Formas
type: docs
weight: 130
url: /pt/python-net/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para Python via .NET—automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Uma das dúvidas mais comuns dos clientes do Aspose.Slides for Python é como redimensionar formas de modo que, ao mudar o tamanho do slide, os dados não sejam cortados. Este breve artigo técnico mostra como fazer isso.

## **Redimensionar Formas**

Para impedir que as formas fiquem desalinhadas quando o tamanho do slide mudar, atualize a posição e as dimensões de cada forma para que elas se ajustem ao novo layout do slide.

```py
import aspose.slides as slides

# Carregar o arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    # Obter o tamanho original do slide.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Alterar o tamanho do slide sem dimensionar as formas existentes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Obter o novo tamanho do slide.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Redimensionar e reposicionar formas em cada slide.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Dimensionar o tamanho da forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Dimensionar a posição da forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Se um slide contiver uma tabela, o código acima não funcionará corretamente. Nesse caso, cada célula da tabela deve ser redimensionada.

{{% /alert %}} 

Use o código a seguir para redimensionar slides que contêm tabelas. Para tabelas, definir a largura ou altura é um caso especial: você deve ajustar individualmente as alturas das linhas e as larguras das colunas para mudar o tamanho geral da tabela.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Obter o tamanho original do slide.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Alterar o tamanho do slide sem dimensionar as formas existentes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Obter o novo tamanho do slide.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Dimensionar o tamanho da forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Dimensionar a posição da forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Dimensionar o tamanho da forma.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Dimensionar a posição da forma.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Dimensionar o tamanho da forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Dimensionar a posição da forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Ao redimensionar um slide, as formas mantêm sua posição e tamanho originais, a menos que a escala seja alterada explicitamente. Isso pode fazer com que o conteúdo seja recortado ou as formas fiquem desalinhadas.

**O código fornecido funciona para todos os tipos de forma?**

O exemplo básico funciona para a maioria dos tipos de forma (caixas de texto, imagens, gráficos etc.). No entanto, para tabelas, é necessário tratar linhas e colunas separadamente, já que a altura e a largura de uma tabela são determinadas pelas dimensões das células individuais.

**Como redimensionar tabelas ao redimensionar um slide?**

É preciso percorrer todas as linhas e colunas da tabela e redimensionar suas alturas e larguras proporcionalmente, como mostrado no segundo exemplo de código.

**Esse redimensionamento funciona para slides mestre e slides de layout?**

Sim, mas você também deve percorrer [Masters](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/masters/) e [Layout slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/layout_slides/) e aplicar a mesma lógica de escala às suas formas para garantir consistência em toda a apresentação.

**Posso mudar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Você pode usar [presentation.slide_size.orientation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/islidesize/orientation/) para mudar a orientação. Certifique-se de definir a lógica de escala adequadamente para preservar o layout.

**Existe um limite para o tamanho de slide que posso definir?**

O Aspose.Slides suporta tamanhos personalizados, mas tamanhos muito grandes podem afetar o desempenho ou a compatibilidade com algumas versões do PowerPoint.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Verifique a propriedade `aspect_ratio_locked` da forma antes de escalar. Se estiver bloqueada, ajuste a largura ou a altura proporcionalmente ao invés de escalá‑las individualmente.