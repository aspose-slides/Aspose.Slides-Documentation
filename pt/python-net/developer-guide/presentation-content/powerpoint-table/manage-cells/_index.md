---
title: Gerenciar Células de Tabela em Apresentações com Python
linktitle: Gerenciar Células
type: docs
weight: 30
url: /pt/python-net/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie células de tabela do PowerPoint em Python: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para Python via .NET."
---
## **Visão Geral**

Aspose.Slides permite acessar e modificar células de tabelas em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de células, trabalhar com numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

Aspose.Slides usa índices baseados em zero. As coordenadas neste artigo são escritas como `(coluna, linha)`.

## **Identificar uma Célula de Tabela Mesclada**

O exemplo abre uma apresentação existente e acessa a primeira forma no primeiro slide como uma tabela. Ele assume que o slide e a forma existem e que a forma é uma tabela. Em seguida, itera por todas as linhas e colunas e usa [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) para identificar células em regiões mescladas. Para cada correspondência, ele imprime as coordenadas da célula na ordem `linha;coluna`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), e as coordenadas iniciais da região, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) e [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Remover Bordas de Células de Tabela**

Crie uma [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e adicione uma tabela ao seu primeiro slide com [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Larguras de coluna, alturas de linha e a posição da tabela são especificadas em pontos. O exemplo define todas as quatro bordas da célula como [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), tornando-as invisíveis.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar Bordas Diagonais de Célula**

Use [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) para desenhar uma linha do canto superior esquerdo para o canto inferior direito, e [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) para desenhar uma linha do canto inferior esquerdo para o canto superior direito. Uma diagonal pode marcar um cabeçalho de canto; ambas as diagonais podem formar um X para marcar a célula como não aplicável.

Cada diagonal é um [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). Em seu [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/), defina [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) como [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) e escolha um [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Defina a [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) da linha em pontos.

O exemplo cria três células em uma linha: uma diagonal descendente vermelha, uma diagonal ascendente azul e ambas as diagonais. Ele deixa as bordas superior, inferior, esquerda e direita da célula inalteradas.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Uma diagonal é uma propriedade de formatação, não uma divisão de célula. Cada célula mantém um único [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); as regiões em cada lado de uma diagonal não podem ser editadas independentemente.

A tabela salva, renderizada no Microsoft PowerPoint:

![Três células de tabela mostrando uma diagonal vermelha do canto superior esquerdo ao canto inferior direito, uma diagonal azul do canto inferior esquerdo ao canto superior direito e ambas as diagonais formando um X.](diagonal-cell-borders.png)

*Da esquerda para a direita: diagonal descendente (vermelha, 3 pt), diagonal ascendente (azul, 5 pt) e ambas as diagonais.*

## **Mesclar Células de Tabela**

Use [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) para combinar um intervalo retangular de células de tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mesclagem pode incluir células fora do intervalo especificado; `False` mantém a mesclagem dentro desse intervalo.

O exemplo cria uma tabela 4‑por‑4 com colunas e linhas de 70 pontos, então mescla as quatro células centrais de `(1, 1)` a `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela ainda tem quatro colunas e quatro linhas. Para acessar o conteúdo ou a formatação da célula mesclada, use sua posição superior esquerda: `table.rows[1][1]` neste exemplo. As outras posições no intervalo mesclado permanecem parte da grade da tabela, portanto os índices das células fora do intervalo não mudam.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Dividir Células de Tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e mudar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabelas do PowerPoint.

Este exemplo cria uma tabela 4‑por‑4 com colunas e linhas de 70 pontos e chama [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) na célula `(1, 1)`. Metade da largura de 70 pontos da célula é passada para criar duas células de largura igual.

Depois dessa divisão, as duas metades são acessadas como `table.rows[1][1]` e `table.rows[1][2]`. A grade da tabela agora tem cinco colunas: as células originalmente nas colunas 2 e 3 mudam para as colunas 3 e 4, respectivamente. Os índices de linha permanecem inalterados. Use esses índices de coluna atualizados ao acessar células após a divisão.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

<!-- visual-explanation:manage-cells:start -->
[![Uma célula não mesclada de 70 pontos se divide em duas células de 35 pontos, adicionando uma quinta coluna à grade e deslocando os índices à sua direita.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*A divisão de largura afeta a célula (1, 1), usando índices baseados em zero (coluna, linha). Outras linhas mantêm uma célula que abrange ambas as novas posições de coluna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividir Células Mescladas por Linha ou Coluna**

Para preparar células‑modelo mescladas para preenchimento de dados, use [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) para dividir ao longo de um limite de linha existente, ou [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) para dividir ao longo de um limite de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:

- Divisão de linha: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Divisão de coluna: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

O exemplo supõe que a apresentação possui uma tabela como primeira forma no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. A partir da posição inferior, ele usa [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) e [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) para localizar a origem e verifica ambas as extensões. `split_by_row_span` com índice 1 então separa as linhas 2 e 3 para nomes de produtos. Para uma mesclagem horizontal de duas colunas, use `split_by_col_span` com índice 1 em vez disso.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Recupere as células resultantes da tabela após a divisão.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

A grade da tabela e os índices das células ao redor permanecem inalterados. Recupere as células resultantes por suas coordenadas; aqui, ambas têm extensões de 1 e [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) devolve `False`. Regiões maiores podem permanecer parcialmente mescladas após uma divisão.

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula está vazia, mas herda a formatação da célula como preenchimento, bordas e margens. Preencha as células depois da divisão e defina explicitamente qualquer formatação de texto necessária.

A apresentação salva contém células separadas “Product A” e “Product B” com a formatação da célula do modelo mantida. Consulte a [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) para mais detalhes.

### **Dividir uma Célula em uma Altura Específica**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) recebe a altura da parte superior em pontos. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) recebe o número de linhas de grade existentes na parte superior. Para centralizar verticalmente uma célula de 40 pontos na coluna da direita, subtraia 40 da altura real da célula e divida o espaço restante igualmente acima e abaixo dela.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

A primeira divisão adiciona uma linha à grade, deixando os 90 pontos inferiores em `table.rows[1][1]`. A segunda divisão separa essa célula em uma célula do meio de 40 pontos e uma célula inferior de 50 pontos. As três células na coluna da direita agora têm alturas de 50, 40 e 50 pontos de cima para baixo. A célula da esquerda abrange todas as três linhas com sua altura original de 140 pontos.

![A célula esquerda abrange toda a altura da tabela ao lado de três células com “Middle” no centro.](split-by-height.png)

## **Alterar a Cor de Fundo da Célula de Tabela**

Este exemplo cria uma tabela com colunas de 150 pontos e linhas de 50 pontos. Ele define [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) como sólido e [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) como vermelho para a célula `(2, 3)`, na terceira coluna e quarta linha.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ela carrega a imagem com [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) e a adiciona à coleção de imagens da apresentação com [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode alterar sua proporção. Larguras de coluna e alturas de linha estão em pontos. A imagem carregada é descartada automaticamente quando seu bloco `with` termina.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Posso definir diferentes espessuras e estilos de linha para os diferentes lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha depois de definir uma foto como fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem se ajusta à nova célula; com ladrilhamento, os ladrilhos são recalculados.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/python-net/manage-hyperlinks/) são definidos no nível do texto (por porção) dentro do quadro de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (run) com formatação independente — família da fonte, estilo, tamanho e cor.