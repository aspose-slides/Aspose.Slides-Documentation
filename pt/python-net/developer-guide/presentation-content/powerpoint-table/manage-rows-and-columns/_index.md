---
title: Gerenciar Linhas e Colunas em Tabelas do PowerPoint Usando Python
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/python-net/manage-rows-and-columns/
keywords:
- linha de tabela
- coluna de tabela
- primeira linha
- cabeçalho de tabela
- clonar linha
- clonar coluna
- copiar linha
- copiar coluna
- remover linha
- remover coluna
- formatação de texto da linha
- formatação de texto da coluna
- estilo de tabela
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides for Python via .NET e acelere a edição de apresentações e atualizações de dados."
---
## **Introdução**

Aspose.Slides for Python via .NET permite que você gerencie a estrutura e a formatação de tabelas em apresentações do PowerPoint através da classe [Tabela](https://reference.aspose.com/slides/python-net/aspose.slides/table/). É possível designar uma linha de cabeçalho, clonar ou remover linhas e colunas e aplicar formatação de texto a uma linha ou coluna inteira.

Este artigo explica essas operações com exemplos em Python. Também mostra como recuperar a predefinição de estilo de uma tabela para que você possa reutilizá‑la. Os índices de linhas e colunas da tabela são baseados em zero.

## **Controlar a Altura da Linha**

Use [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) para definir a altura mínima de uma linha em pontos. É um limite inferior, não uma altura fixa. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) devolve a altura real e é somente leitura. Acesse a linha através de [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

O exemplo carrega [row-height-input.pptx](row-height-input.pptx), que possui uma tabela como o primeiro shape no primeiro slide. Sua primeira linha começa em 70 pontos. As células usam texto Arial de 18 pt, quebra de linha automática e margens superior e inferior de 6 pt; o texto mais longo na segunda coluna quebra em várias linhas. O exemplo aumenta o mínimo para 100 pt, depois diminui para 20 pt, imprime a altura real após cada alteração e salva ambos os resultados.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Com a apresentação fornecida, aumentar o mínimo adiciona espaço à linha. Diminuí‑lo remove esse espaço extra, mas a altura real permanece maior que 20 pt porque o texto e as margens da célula exigem mais espaço. Reduzir apenas o mínimo não pode forçar a linha abaixo do espaço requerido pelo seu conteúdo.

Vários fatores afetam a altura real:

- **Texto e tamanho da fonte:** texto mais longo, quebras de linha explícitas ou uma fonte maior podem exigir mais espaço vertical.
- **Quebra de linha e largura da coluna:** com quebra ativada, uma [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) mais estreita pode gerar mais linhas. Uma coluna mais larga pode reduzir o espaço necessário verticalmente.
- **Margens da célula:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) e [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) adicionam espaço vertical. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) e [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) reduzem a largura disponível para o texto e podem causar quebras adicionais.

Para esta tabela sem células mescladas, a célula que necessita de mais espaço vertical determina o limite inferior impulsionado pelo conteúdo para a linha inteira. Para encurtar a linha, talvez seja necessário encurtar o texto, reduzir o tamanho da fonte ou das margens, ou alargar uma coluna.

As imagens abaixo mostram a mesma tabela na mesma escala. Nesta execução, as alturas reais foram 70, 100 e 55,2 pontos: a linha final permaneceu mais alta que seu mínimo de 20 pt. Medições de texto exatas podem variar conforme as fontes disponíveis no seu ambiente. Baixe os resultados salvos: [mínimo aumentado](row-height-increased.pptx) e [mínimo diminuído](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Diminuído: mínimo 20 pt, real 55,2 pt |
| --- | --- | --- |
| ![Tabela original com a primeira linha de 70 pt.](row-height-before.png) | ![Tabela após aumentar o mínimo da primeira linha para 100 pt.](row-height-increased.png) | ![Tabela após diminuir o mínimo da primeira linha para 20 pt; texto quebrado mantém a linha mais alta que o mínimo.](row-height-decreased.png) |

## **Definir a Primeira Linha como Cabeçalho**

Use a propriedade [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) para marcar a primeira linha para formatação de cabeçalho. Sua aparência depende do estilo de tabela aplicado.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Acesse a tabela armazenada como o primeiro shape no slide.
4. Ative a formatação de cabeçalho para sua primeira linha.
5. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide. Ele habilita a formatação de cabeçalho para a primeira linha e salva `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar uma Linha ou Coluna da Tabela**

Clone linhas ou colunas para reutilizar seu conteúdo e formatação. Você pode anexar uma cópia ao final da tabela ou inseri‑la em uma posição específica.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Clone as linhas necessárias.
6. Clone as colunas necessárias.
7. Salve a apresentação modificada.

O exemplo requer `Test.pptx` com ao menos um slide. Ele cria uma tabela com três colunas e cinco linhas, com dimensões especificadas em pontos. Anexa cópias da primeira linha e coluna, depois insere cópias da segunda linha e coluna no índice 3 (a quarta posição). A tabela resultante tem sete linhas e cinco colunas. O argumento `False` desabilita a clonagem em linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover uma Linha ou Coluna de uma Tabela**

Remova linhas ou colunas que não são mais necessárias em uma tabela. A remoção de um item desloca os índices das linhas ou colunas que o seguem.

1. Crie uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Defina as larguras das colunas e as alturas das linhas.
4. Adicione uma tabela com o método [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Remova a segunda linha e a segunda coluna.
6. Salve a apresentação modificada.

Este exemplo cria uma tabela de três por três e remove a linha e a coluna no índice 1, deixando uma tabela de dois por dois em `TestTable_out.pptx`. As dimensões estão em pontos. O argumento `False` desabilita a remoção de linhas ou colunas mescladas adjacentes; esta tabela não possui células mescladas.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Formatação de Texto no Nível da Linha da Tabela**

Aplique formatação de texto a uma linha inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Defina [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) para a primeira linha.
4. Defina [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) e [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) para a primeira linha.
5. Defina [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) para a segunda linha.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide e ao menos duas linhas. Ele aplica texto de 25 pt, alinhamento à direita e margem de parágrafo direita de 20 pt à primeira linha, depois define texto vertical na segunda linha.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Formatação de Texto no Nível da Coluna da Tabela**

Aplique formatação de texto a uma coluna inteira para manter suas células consistentes. Você pode definir propriedades de fonte, formatação de parágrafo e direção do texto sem formatar cada célula individualmente.

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acesse a tabela no primeiro slide.
3. Defina [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) para a primeira coluna.
4. Defina [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) e [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) para a primeira coluna.
5. Defina [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) para a segunda coluna.
6. Salve a apresentação modificada.

O exemplo requer `table.pptx` com uma tabela como o primeiro shape no primeiro slide e ao menos duas colunas. Ele aplica texto de 25 pt, alinhamento à direita e margem de parágrafo direita de 20 pt à primeira coluna, depois define texto vertical na segunda coluna.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter Propriedades de Estilo da Tabela**

Use a propriedade [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) para recuperar a predefinição aplicada a uma tabela e reutilizá‑la em outra tabela. Isso identifica a predefinição em vez de sobrescrições individuais de formatação de célula.

O exemplo cria uma tabela, aplica [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), e lê a predefinição de volta. Ele imprime `True` quando a predefinição recuperada corresponde à predefinição aplicada e salva a tabela em `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master e você ainda pode sobrescrever preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem ordenação ou filtros internos. Ordene seus dados em memória primeiro e, em seguida, repopule as linhas da tabela nessa ordem.

**Posso ter colunas listradas (banded) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas listradas e depois sobrescreva células específicas com formatação local; a formatação ao nível da célula tem precedência sobre o estilo da tabela.