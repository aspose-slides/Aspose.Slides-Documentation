---
title: Criar gráficos Excel e incorporá‑los em apresentações como objetos OLE
type: docs
weight: 50
url: /pt/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- apresentação
- Python
- Python via .NET
- Aspose.Slides
description: "Criar um gráfico Excel com Aspose.Cells for Python via .NET e incorporar a pasta de trabalho em uma apresentação PowerPoint com Aspose.Slides, incluindo uma visualização do gráfico."
---
## **Visão geral**

Este artigo mostra como criar um gráfico de colunas do Excel com Aspose.Cells for Python via .NET e incorporar sua pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides for Python via .NET. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes de o objeto OLE ser ativado.

O resultado é um objeto Excel incorporado, não um gráfico nativo do PowerPoint. Editar a pasta de trabalho via OLE requer um aplicativo desktop que ofereça suporte à ativação OLE e uma instalação compatível do Excel.

## **Pré-requisitos**

Instale os pacotes `aspose-cells-python` e `aspose-slides` em seu ambiente Python. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhum arquivo de entrada é necessário: o exemplo cria os dados e o gráfico na memória e, em seguida, grava `OutputChart.pptx` no diretório de trabalho atual. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como funciona a incorporação**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
1. Torne a planilha de gráfico ativa para que a pasta de trabalho seja aberta no gráfico.  
1. Defina a faixa de exibição OLE da pasta de trabalho e renderize o gráfico para PNG.  
1. Salve a pasta de trabalho como XLSX na memória e incorpore esses bytes em um slide.  
1. Atribua o PNG como visualização do objeto OLE e salve a apresentação como PPTX.

A faixa de exibição da pasta de trabalho e a moldura no slide têm funções diferentes. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) recebe índices de linha e coluna iniciais/finais baseados em zero. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) recebe, em vez disso, a linha superior, coluna esquerda, linha inferior e coluna direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores diretos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo a adapta dentro do slide e a centraliza preservando a proporção do PNG, em vez de esticar a visualização para preencher o slide.

## **Criar e incorporar o gráfico**

O exemplo completo a seguir preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série do gráfico. `ChartSheet` é selecionada como a planilha ativa antes de salvar a pasta de trabalho.

A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). O PNG é carregado diretamente de seu fluxo sem conversão intermediária de bitmap. Atribuí‑lo via [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) substitui o marcador de posição OLE padrão.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Renderizar a visualização do gráfico e serializar a pasta de trabalho editável separadamente.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Ajustar a visualização dentro do slide sem alterar sua proporção.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A visualização está centralizada no slide e mantém suas proporções.

![Gráfico de colunas do Excel exibido como visualização de uma pasta de trabalho incorporada](excel-chart-ole-preview.png)

Em um ambiente de desktop compatível com PowerPoint e com Excel disponível, dê um duplo clique no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e a edição dependem do suporte OLE do aplicativo host e das configurações de segurança.

## **Perguntas frequentes**

**Por que uma imagem de visualização é necessária?**

A pasta de trabalho incorporada e sua visualização no slide são conteúdos separados. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do marcador de posição padrão “EMBEDDED OLE OBJECT”. Veja [Object Preview Issue when Adding OleObjectFrame](/slides/pt/python-net/object-preview-issue-when-adding-oleobjectframe/).

**A visualização é atualizada automaticamente quando altero a pasta de trabalho no código?**

Considere a visualização como uma captura instantânea. Ao atualizar os dados da pasta de trabalho programaticamente, regenere a imagem do gráfico e substitua a visualização assim como os dados da pasta de trabalho incorporada.

**Posso usar XLS em vez de XLSX?**

Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão de dados incorporada. A extensão deve corresponder ao formato real da pasta de trabalho; mudar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**

O aplicativo host pode atualizar a apresentação do objeto OLE ao ativar a pasta de trabalho. Tanto a faixa de exibição OLE da pasta de trabalho quanto as dimensões da moldura no slide são relevantes. Veja [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/pt/python-net/working-solution-for-worksheet-resizing/).

## **Seções relacionadas**

- [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/pt/python-net/working-solution-for-worksheet-resizing/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/pt/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE Objects](/slides/pt/python-net/manage-ole/)