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
- estilo de tabela
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e edite tabelas em slides PowerPoint e OpenDocument com Aspose.Slides para Python via .NET. Descubra exemplos de código simples para simplificar seus fluxos de trabalho com tabelas."
---
## **Introdução**

Uma tabela no PowerPoint é uma maneira eficiente de apresentar informações. Informações organizadas em uma grade de células (linhas e colunas) são simples e fáceis de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/), a classe [Cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cell/) e outros tipos relacionados para ajudá-lo a criar, atualizar e gerenciar tabelas em qualquer apresentação.

## **Criar Tabelas do Zero**

Esta seção mostra como criar uma tabela do zero no Aspose.Slides adicionando uma forma de tabela a um slide, definindo suas linhas e colunas e definindo tamanhos precisos. Você também verá como preencher células com texto, ajustar alinhamento e bordas e personalizar a aparência da tabela.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Defina um array de larguras de colunas.
4. Defina um array de alturas de linhas.
5. Adicione uma [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) ao slide.
6. Itere sobre cada [Cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cell/) e formate suas bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células na primeira linha da tabela.
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) de uma [Cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cell/).
9. Adicione texto ao [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
10. Salve a apresentação modificada.

O exemplo Python a seguir mostra como criar uma tabela em uma apresentação:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Definir larguras de colunas e alturas de linhas.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Adicionar uma forma de tabela ao slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Definir o formato da borda para cada célula.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Mesclar células de (linha 0, coluna 0) até (linha 1, coluna 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Adicionar texto à célula mesclada.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Salvar a apresentação no disco.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeração em Tabelas Padrão**

Em uma tabela padrão, a numeração das células é simples e baseada em zero. A primeira célula em uma tabela tem índice (0, 0) (coluna 0, linha 0).

Por exemplo, em uma tabela com 4 colunas e 4 linhas, as células são numeradas da seguinte forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

O exemplo Python a seguir mostra como referenciar células usando essa numeração baseada em zero:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Acessar uma Tabela Existente**

Esta seção explica como localizar e trabalhar com uma tabela existente em uma apresentação usando Aspose.Slides. Você aprenderá como encontrar a tabela em um slide, acessar suas linhas, colunas e células e atualizar o conteúdo ou a formatação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide que contém a tabela pelo seu índice.
3. Itere por todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) até encontrar a tabela.
4. Use o objeto [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) para trabalhar com a tabela.
5. Salve a apresentação modificada.

{{% alert color="info" %}}
Se o slide contém várias tabelas, é melhor procurar a tabela que você precisa pela propriedade `alternative_text`.
{{% /alert %}}

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanciar a classe Presentation para carregar um arquivo PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    table = None

    # Percorrer as formas e referenciar a primeira tabela encontrada.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Definir o texto da primeira célula na primeira linha.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Salvar a apresentação modificada no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alinhar Texto em Tabelas**

Esta seção mostra como controlar o alinhamento de texto dentro das células da tabela usando Aspose.Slides. Você aprenderá a definir o alinhamento horizontal e vertical das células para manter seu conteúdo claro e consistente.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) ao slide.
4. Acesse um objeto [Cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cell/) da tabela.
5. Alinhe o texto verticalmente.
6. Salve a apresentação modificada.

O exemplo Python a seguir mostra como alinhar o texto em uma tabela:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Criar uma instância da classe Presentation.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Definir larguras de colunas e alturas de linhas.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Adicionar uma forma de tabela ao slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Centralizar o texto e definir orientação vertical.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Salvar a apresentação no disco.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Formatação de Texto no Nível da Tabela**

Esta seção mostra como aplicar formatação de texto no nível da tabela no Aspose.Slides para que cada célula herde um estilo consistente e unificado. Você aprenderá a definir tamanhos de fonte, alinhamentos e margens globalmente.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione uma [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) ao slide.
4. Defina o tamanho da fonte (altura da fonte) para o texto.
5. Defina o alinhamento do parágrafo e as margens.
6. Defina a orientação vertical do texto.
7. Salve a apresentação modificada.

O exemplo Python a seguir mostra como aplicar suas opções de formatação preferidas ao texto em uma tabela:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Cria uma instância da classe Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Define o tamanho da fonte para todas as células da tabela.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Define texto alinhado à direita e margem direita para todas as células da tabela.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Define a orientação vertical do texto para todas as células da tabela.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar Estilos de Tabela Incorporados**

Aspose.Slides permite formatar tabelas usando estilos pré-definidos diretamente no código. O exemplo demonstra a criação de uma tabela, a aplicação de um estilo incorporado e a gravação do resultado — uma maneira eficiente de garantir formatação consistente e profissional.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Bloquear Proporção de Aspecto das Tabelas**

A proporção de aspecto de uma forma é a relação entre suas dimensões. Aspose.Slides fornece a propriedade `aspect_ratio_locked`, que permite bloquear a proporção de aspecto para tabelas e outras formas.

O exemplo Python a seguir mostra como bloquear a proporção de aspecto para uma tabela:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para toda a tabela e o texto em suas células?**

Sim. A tabela expõe a propriedade [right_to_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/right_to_left/), e os parágrafos possuem [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/right_to_left/). Usar ambos garante a ordem RTL correta e a renderização dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use [shape locks](/slides/pt/python-net/applying-protection-to-presentation/) para desativar movimentação, redimensionamento, seleção etc. Esses bloqueios também se aplicam às tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).