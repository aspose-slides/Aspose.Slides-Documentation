---
title: Gerenciar linhas e colunas em tabelas PowerPoint usando Python
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/python-net/manage-rows-and-columns/
keywords:
- linha de tabela
- coluna de tabela
- primeira linha
- cabeçalho da tabela
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
description: "Gerencie linhas e colunas de tabelas no PowerPoint e OpenDocument com Aspose.Slides para Python via .NET e acelere a edição de apresentações e a atualização de dados."
---
## **Visão geral**

Este artigo mostra como gerenciar linhas e colunas de tabelas em apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python. Você aprenderá como adicionar, inserir, clonar e excluir linhas ou colunas, marcar a primeira linha como cabeçalho, ajustar tamanho e layout e aplicar formatação de texto e estilo no nível da linha ou da coluna. Cada tarefa é demonstrada com trechos de código compactos e autocontidos baseados na API [Tabela](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/), para que você possa encontrar rapidamente uma tabela em um slide e remodelar sua estrutura de acordo com seu design.

## **Definir a primeira linha como cabeçalho**

Marque a primeira linha da tabela como cabeçalho para distinguir claramente os títulos das colunas dos dados. No Aspose.Slides para Python, basta habilitar a opção *First Row* da tabela para aplicar a formatação de cabeçalho definida pelo estilo de tabela selecionado.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação.  
1. Acesse o slide pelo seu índice.  
1. Itere por todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) para encontrar a tabela relevante.  
1. Defina a primeira linha da tabela como cabeçalho.  

Este código Python mostra como definir a primeira linha de uma tabela como seu cabeçalho:

```python
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Iterar pelos shapes e obter uma referência à tabela.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Definir a primeira linha da tabela como cabeçalho.
    table.first_row = True
    
    # Salvar a apresentação no disco.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonar uma linha ou coluna de tabela**

Clone qualquer linha ou coluna de tabela e insira a cópia na posição desejada na tabela. A duplicata preserva o conteúdo das células, a formatação e os tamanhos, permitindo expandir layouts de forma rápida e consistente.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação.  
1. Acesse o slide pelo seu índice.  
1. Defina um array de larguras de coluna.  
1. Defina um array de alturas de linha.  
1. Adicione uma [Tabela](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) ao slide usando `add_table(x, y, column_widths, row_heights)`.  
1. Clone uma linha de tabela.  
1. Clone uma coluna de tabela.  
1. Salve a apresentação modificada.  

Este código Python mostra como clonar uma linha e uma coluna de uma tabela PowerPoint:

```python
 import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Definir larguras das colunas e alturas das linhas.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Adicionar uma tabela ao slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Adicionar texto à linha 1, coluna 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Adicionar texto à linha 2, coluna 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Clonar a linha 1 ao final da tabela.
    table.rows.add_clone(table.rows[0], False)

    # Adicionar texto à linha 1, coluna 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Adicionar texto à linha 2, coluna 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Clonar a linha 2 como a 4ª linha da tabela.
    table.rows.insert_clone(3,table.rows[1], False)

    # Clonar a primeira coluna ao final.
    table.columns.add_clone(table.columns[0], False)

    # Clonar a segunda coluna no índice 3 (a 4ª posição).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Salvar a apresentação no disco.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover uma linha ou coluna de uma tabela**

Simplifique uma tabela removendo qualquer linha ou coluna pelo índice usando Aspose.Slides para Python — o layout é ajustado automaticamente enquanto preserva a formatação das células restantes. Isso é útil para simplificar grades de dados ou excluir marcadores de posição sem reconstruir a tabela.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação.  
1. Acesse o slide pelo seu índice.  
1. Defina um array de larguras de coluna.  
1. Defina um array de alturas de linha.  
1. Adicione um ITable ao slide usando `add_table(x, y, column_widths, row_heights)`.  
1. Remova a linha da tabela.  
1. Remova a coluna da tabela.  
1. Salve a apresentação modificada.  

O código Python a seguir mostra como remover uma linha e uma coluna de uma tabela:

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

## **Definir formatação de texto no nível da linha da tabela**

Aplique um estilo de texto consistente a uma linha inteira da tabela em um único passo. Com Aspose.Slides para Python, você pode definir família de fonte, tamanho, peso, cor e alinhamento para todas as células da linha de uma vez, mantendo cabeçalhos ou faixas de dados uniformes.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação.  
1. Acesse o slide pelo seu índice.  
1. Acesse o objeto [Tabela](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) relevante no slide.  
1. Defina a altura da fonte para as células da primeira linha.  
1. Defina o alinhamento e a margem direita para as células da primeira linha.  
1. Defina o tipo de texto vertical para as células da segunda linha.  
1. Salve a apresentação modificada.  

Este código Python demonstra a operação.

```python
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Definir a altura da fonte para as células da primeira linha.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Definir o alinhamento de texto e a margem direita das células da primeira linha.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Definir o tipo de texto vertical para as células da segunda linha.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Salvar a apresentação no disco.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir formatação de texto no nível da coluna da tabela**

Aplique um estilo de texto consistente a uma coluna inteira da tabela de uma só vez. Com Aspose.Slides para Python, você pode definir família de fonte, tamanho, peso, cor e alinhamento para todas as células de uma coluna, criando faixas verticais uniformes para cabeçalhos ou dados.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação.  
1. Acesse o slide pelo seu índice.  
1. Acesse o objeto [Tabela](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) relevante no slide.  
1. Defina a altura da fonte para as células da primeira coluna.  
1. Defina o alinhamento e a margem direita para as células da primeira coluna.  
1. Defina o tipo de texto vertical para as células da segunda coluna.  
1. Salve a apresentação modificada.  

O código Python a seguir demonstra a operação:

```python
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Definir a altura da fonte das células da primeira coluna.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Definir o alinhamento de texto e a margem direita das células da primeira coluna.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Definir o tipo de texto vertical das células da segunda coluna.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Salvar a apresentação no disco.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter propriedades de estilo da tabela**

Aspose.Slides permite recuperar as propriedades de estilo de uma tabela para que você possa reutilizá‑las em outra tabela ou em outro local. O código Python a seguir mostra como obter as propriedades de estilo de um estilo de tabela predefinido:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela já criada?**

Sim. A tabela herda o tema do slide/layout/master e ainda é possível substituir preenchimentos, bordas e cores de texto sobre esse tema.

**Posso classificar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem classificação ou filtros integrados. Classifique seus dados na memória primeiro e, em seguida, repopule as linhas da tabela nessa ordem.

**Posso ter colunas listradas enquanto mantenho cores personalizadas em células específicas?**

Sim. Ative colunas listradas e depois substitua células específicas com formatação local; a formatação ao nível da célula tem precedência sobre o estilo da tabela.