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
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerencie facilmente células de tabela no PowerPoint e OpenDocument com Aspose.Slides para Python via .NET. Domine o acesso, modificação e estilo de células rapidamente para automação de slides fluida."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabelas em apresentações do PowerPoint. Este artigo explica como identificar células mescladas, remover bordas das células, trabalhar com a numeração das células após mesclar ou dividir, alterar a cor de fundo de uma célula e inserir uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como arquivo PPTX.

## **Identificar células mescladas da tabela**

As tabelas costumam conter células mescladas para cabeçalhos ou para agrupar dados relacionados. Nesta seção, você verá como determinar se uma célula específica pertence a uma região mesclada e como referenciar a célula mestre (superior‑esquerda) para ler ou formatar todo o bloco de forma consistente.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha a tabela do primeiro slide.
1. Percorra as linhas e colunas da tabela para encontrar células mescladas.
1. Exiba uma mensagem quando células mescladas forem encontradas.

O código Python a seguir identifica células mescladas em uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Supondo que a primeira forma no primeiro slide seja uma tabela.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Remover bordas das células da tabela**

Às vezes, as bordas da tabela distraem o conteúdo ou criam desordem visual. Esta seção mostra como remover bordas de células selecionadas—ou de lados específicos de uma célula—para obter um layout mais limpo e melhor alinhado ao design do slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha o slide pelo seu índice.
1. Defina um array de larguras de coluna.
1. Defina um array de alturas de linha.
1. Adicione uma tabela ao slide usando o método [add_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_table/).
1. Percorra cada célula para limpar as bordas superior, inferior, esquerda e direita.
1. Salve a apresentação modificada como arquivo PPTX.

O código Python a seguir demonstra como remover bordas das células da tabela:

```python
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo PPTX.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Definir colunas com larguras e linhas com alturas.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Adicionar uma forma de tabela ao slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Limpar o preenchimento da borda para cada célula.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Salvar o arquivo PPTX no disco.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeração em células mescladas**

Se você mesclar dois pares de células—por exemplo, (1, 1) × (2, 1) e (1, 2) × (2, 2)—a tabela resultante manterá a mesma numeração de células da tabela sem mesclar. O código Python a seguir demonstra esse comportamento:

```python
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo PPTX.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Definir colunas com larguras e linhas com alturas.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Adicionar uma forma de tabela ao slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Mesclar células (1,1) e (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Mesclar células (1, 2) e (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Imprimir os índices das células.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Salvar o arquivo PPTX no disco.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Saída:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Numeração em células divididas**

No exemplo anterior, quando as células da tabela foram mescladas, a numeração nas demais células não mudou. Agora, criamos uma tabela regular (sem células mescladas) e dividimos a célula (1, 1) para produzir uma tabela especial. Preste atenção à numeração dessa tabela—pode parecer incomum. No entanto, é assim que o Microsoft PowerPoint numera as células da tabela, e o Aspose.Slides segue o mesmo comportamento.

O código Python a seguir demonstra esse comportamento:

```python
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo PPTX.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Definir larguras de coluna e alturas de linha.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Adicionar uma forma de tabela ao slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Dividir a célula (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Imprimir os índices das células.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Salvar o arquivo PPTX no disco.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Saída:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Alterar a cor de fundo da célula da tabela**

O exemplo Python a seguir demonstra como alterar a cor de fundo de uma célula da tabela:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Criar uma nova tabela.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Definir a cor de fundo para uma célula.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Inserir imagens em células da tabela**

Esta seção mostra como inserir uma imagem em uma célula de tabela no Aspose.Slides. Ela cobre a aplicação de preenchimento de imagem na célula alvo e a configuração de opções de exibição, como esticar ou repetir.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo seu índice.
1. Defina um array de larguras de coluna.
1. Defina um array de alturas de linha.
1. Adicione uma tabela ao slide com o método [add_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_table/).
1. Carregue a imagem a partir de um arquivo.
1. Adicione a imagem às imagens da apresentação para obter um [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/).
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da célula da tabela como `PICTURE`.
1. Aplique a imagem à célula da tabela e escolha um modo de preenchimento (por exemplo, `STRETCH`).
1. Salve a apresentação como arquivo PPTX.

O código Python a seguir mostra como colocar uma imagem dentro de uma célula da tabela ao criar a tabela:

```python
import aspose.slides as slides

# Instanciar um objeto Presentation.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Definir larguras de coluna e alturas de linha.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Adicionar uma forma de tabela ao slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Carregar a imagem e adicioná‑la à apresentação para obter um PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Aplicar a imagem à primeira célula da tabela.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Salvar a apresentação no disco.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso definir espessuras e estilos de linha diferentes para lados distintos de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cellformat/border_top/),[bottom](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cellformat/border_bottom/),[left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cellformat/border_left/),[right](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cellformat/border_right/) têm propriedades separadas, de modo que a espessura e o estilo de cada lado podem ser diferentes. Isso decorre do controle de borda por lado demonstrado no artigo.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha após definir uma foto como fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem ajusta‑se à nova célula; com repetição, os blocos são recalculados. O artigo menciona os modos de exibição da imagem em uma célula.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/python-net/manage-hyperlinks/) são definidos no nível do texto (porção) dentro do quadro de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [portions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) (execuções) com formatação independente—família da fonte, estilo, tamanho e cor.