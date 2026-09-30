---
title: Gerenciar Tabelas de Apresentação com Python
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/python-net/manage-table/
keywords:
- adicionar tabela
- criar tabela
- acessar tabela
- proporção de aspecto
- alinhar texto
- formatação de texto
- estilo da tabela
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e edite tabelas em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET. Descubra exemplos de código simples para otimizar seus fluxos de trabalho com tabelas."
---
## **Introdução**

As tabelas no PowerPoint organizam informações em linhas e colunas, facilitando a leitura e a comparação de valores.

Aspose.Slides fornece as classes [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) e [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) e outros tipos para permitir que você crie, atualize e gerencie tabelas em apresentações.

## **Criar uma Tabela do Zero**

Crie uma tabela especificando sua posição, larguras das colunas e alturas das linhas. Após adicioná‑la a um slide, você pode formatar as bordas das células, mesclar células e inserir texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Defina uma lista de larguras de coluna em pontos.
4. Defina uma lista de alturas de linha em pontos.
5. Adicione um objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ao slide usando o método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Percorra cada [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) para aplicar formatação nas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela.
8. Acesse a célula mesclada através da propriedade [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Defina o texto na célula mesclada.
10. Salve a apresentação modificada.

O exemplo abaixo cria uma tabela com três colunas e cinco linhas em (100, 50) pontos. Ele aplica bordas vermelhas com largura de 5 pontos, mescla as duas primeiras células da primeira linha e salva o resultado como `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, os índices das células são baseados em zero e usam a ordem (coluna, linha). A primeira célula tem índice (0, 0). Em Python, acesse uma célula com `table.rows[row_index][column_index]`; o índice da linha vem primeiro nesta expressão.

Por exemplo, as células de uma tabela com 4 colunas e 4 linhas são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este exemplo cria a tabela 4 × 4 ilustrada acima, com larguras de coluna e alturas de linha de 70 pontos e bordas de célula vermelhas com largura de 5 pontos. As coordenadas ilustram os índices das células; o exemplo deixa as células vazias e salva a tabela como `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar uma Tabela Existente**

As tabelas são armazenadas na coleção de shapes de um slide. Percorra os shapes para localizar uma tabela, então use a classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) para ler ou atualizar suas células.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Percorra os objetos [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) e pare quando uma tabela for encontrada. Se o slide contiver várias tabelas, use [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) para identificar a que você precisa.
4. Atualize o texto na célula alvo.
5. Salve a apresentação modificada.

O exemplo abaixo abre `UpdateExistingTable.pptx` e encontra a primeira tabela no primeiro slide. Ele define a célula na coluna 0, linha 1 como `New` e salva o resultado como `table1_out.pptx`. A entrada deve conter ao menos um slide, e a primeira tabela nesse slide deve ter ao menos uma coluna e duas linhas.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Para redimensionar uma linha em uma tabela existente e entender por que sua altura real pode exceder o mínimo solicitado, veja [Controlar Altura da Linha](/slides/pt/python-net/manage-rows-and-columns/#control-row-height).

## **Encontrar a Célula que Possui um TextFrame**

Quando um código genérico de processamento de texto recebe um [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de uma tabela, use a propriedade [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) para recuperar a [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) proprietária. Para um TextFrame de célula de tabela, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) está definido e [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) é `None`, mesmo que a própria tabela seja um shape.

As coordenadas da célula estão disponíveis através das propriedades somente leitura [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) e [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) também é somente leitura: fornece navegação para o proprietário, mas não altera a propriedade. Sempre verifique se a célula retornada é `None` antes de usá‑la.

Para um exemplo completo que identifica proprietários de célula‑tabela e shape, incluindo shapes associados a nós de SmartArt, veja [Pesquisar e Substituir Texto](/slides/pt/python-net/search-and-replace-text/).

## **Alinhar Texto em uma Tabela**

Você pode controlar o ancoramento vertical e a direção do texto de células individuais da tabela. O exemplo nesta seção centraliza o texto na primeira célula e o gira 270 graus.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ao slide.
4. Acesse um objeto [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) da tabela.
5. Acesse o primeiro [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) e defina seu texto e cor.
6. Defina o [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) e o [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) da célula.
7. Salve a apresentação modificada.

Este exemplo cria uma tabela 4 × 4 com larguras de coluna de 120 pontos e alturas de linha de 100 pontos. Ele formata o texto na célula (0, 0), adiciona valores às células restantes da primeira linha e salva o resultado como `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Formatação de Texto no Nível da Tabela**

Use [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) para aplicar formatação de texto a todas as células de uma tabela. Seus overloads aceitam formatação de parte, parágrafo e quadro de texto, permitindo definir essas propriedades sem percorrer células individualmente.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse um objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) do slide.
4. Defina o [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) para o texto.
5. Defina o [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) e o [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Defina o [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Salve a apresentação modificada.

O exemplo abaixo abre `table.pptx`, que deve conter ao menos um slide com uma tabela como seu primeiro shape. Ele define o tamanho da fonte para 25 pontos, alinha à direita os parágrafos com margem direita de 20 pontos e torna o texto vertical. A apresentação formatada é salva como `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter Propriedades de Estilo da Tabela**

Use [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) para ler ou atribuir um estilo predefinido a uma tabela. Este exemplo aplica [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) a uma tabela, imprime o nome do preset e atribui o mesmo preset a uma segunda tabela. Ambas as tabelas são salvas em `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Bloquear Proporção de Aspecto de uma Tabela**

A proporção de aspecto de uma tabela é a relação entre sua largura e sua altura. Use [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) para bloquear essa proporção em uma tabela.

O exemplo abaixo abre `pres.pptx`, que deve conter ao menos um slide com uma tabela como seu primeiro shape. Ele imprime o estado atual do bloqueio, habilita o bloqueio da proporção de aspecto, imprime o estado atualizado (`True`) e salva o resultado como `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela possui a propriedade [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), e os parágrafos têm [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use [bloqueios de shape](/slides/pt/python-net/applying-protection-to-presentation/) para desativar mover, redimensionar, selecionar, etc. Esses bloqueios também se aplicam às tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).