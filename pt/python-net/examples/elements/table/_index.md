---
title: Tabela
type: docs
weight: 120
url: /pt/python-net/examples/elements/table/
keywords:
- tabela
- adicionar tabela
- acessar tabela
- remover tabela
- mesclar células
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e formate tabelas em Python com Aspose.Slides: insira dados, mescle células, estilize bordas, alinhe conteúdo e importe/exporte para PPT, PPTX e ODP."
---
Exemplos de como adicionar tabelas, acessá-las, removê-las e mesclar células usando **Aspose.Slides for Python via .NET**.

## **Adicionar uma Tabela**

Crie uma tabela simples com duas linhas e duas colunas.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Definir larguras das colunas e alturas das linhas.
        widths = [80, 80]
        heights = [30, 30]

        # Adicionar uma forma de tabela ao slide.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar uma Tabela**

Recupere a primeira forma de tabela no slide.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Acessar a primeira tabela no slide.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Remover uma Tabela**

Exclua uma tabela de um slide.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Supondo que a primeira forma seja uma tabela.
        table = slide.shapes[0]

        # Remover a tabela do slide.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mesclar Células da Tabela**

Mescle células adjacentes de uma tabela em uma única célula.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Supondo que a primeira forma seja uma tabela.
        table = slide.shapes[0]

        # Mesclar células.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```