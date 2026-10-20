---
title: Solução Funcional para Redimensionamento de Gráficos em PPTX
type: docs
weight: 60
url: /pt/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- Python via .NET
- Python
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para Python via .NET. Defina dimensões fixas para o gráfico a fim de manter os tamanhos do gráfico e do quadro OLE consistentes."
---
## **Visão geral**

Gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após sua primeira ativação. Isso pode causar uma diferença perceptível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá‑lo correspondendo as dimensões fixas do gráfico ao quadro OLE.

In [Criar Gráficos do Excel e Incorporá‑los como Objetos OLE em Apresentações](/slides/pt/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells for Python via .NET e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides for Python via .NET. Para resolver o [problema de visualização do objeto](/slides/pt/python-net/object-preview-issue-when-adding-oleobjectframe/), atribuímos a imagem do gráfico ao quadro do objeto OLE do gráfico. Na apresentação de saída, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e depois retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro do objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

O livro de trabalho do Excel incorporado tem suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. O quadro OLE no slide tem dimensões definidas de forma independente. Quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. Diferenças entre a janela da pasta de trabalho e o quadro OLE podem, portanto, fazer com que o objeto seja redimensionado.

## **Solução Funcional**

Combine o tamanho do gráfico ao quadro OLE no slide e mantenha as dimensões do gráfico independentes da janela da pasta de trabalho. Esta solução funciona com uma nova apresentação ou um modelo existente.

O exemplo requer Aspose.Cells for Python via .NET e Aspose.Slides for Python via .NET. Ele cria um gráfico de colunas simples em uma planilha de gráfico ativa e incorpora a pasta de trabalho no formato XLS. Nenhuma imagem de visualização do gráfico é atribuída; o gráfico torna‑se visível quando o objeto OLE é ativado no PowerPoint.

O exemplo cria uma nova apresentação com um quadro OLE de 9.5 × 4 polegadas posicionado a 0.5 polegadas da borda esquerda e 1 polegada do topo. As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Usar um Modelo](#use-a-template).

## **Definir um Tamanho Fixado para o Gráfico**

Defina [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) como false para que as dimensões do gráfico sejam independentes da janela da pasta de trabalho. Defina as dimensões do [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) por meio de [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) e [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), convertendo pontos em pixels usando 96 pixels por polegada: um quadro medindo 684 × 288 pontos corresponde a um gráfico medindo 912 × 384 pixels. Defina [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) para o valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). O exemplo incorpora a pasta de trabalho com [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) e salva uma apresentação com um quadro OLE de 9.5 × 4 polegadas.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
    width = 684.0  # 9,5 polegadas.
    height = 288.0  # 4 polegadas.

    chart.size_with_window = False
    # Converta pontos em pixels do gráfico usando 96 pixels por polegada.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar um Modelo**

O cálculo de dimensionamento é o mesmo para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.
1. Verifique se o slide inicial contém pelo menos três formas e, em seguida, use a forma no índice 2 como espaço reservado.
1. Obtenha a largura e a altura do quadro a partir dessa forma em vez de usar os valores fixos 684 e 288. Mantenha os cálculos de dimensionamento inalterados.
1. Adicione o quadro OLE na posição do espaço reservado em vez das coordenadas fixas 36 e 72.
1. Remova o espaço reservado antes de salvar a apresentação.

## **FAQ**

**Por que meu gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso acontece porque o Excel tenta restaurar o tamanho original da janela ao ser ativado pela primeira vez, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. O PowerPoint e o Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como posso manter os tamanhos do gráfico e do quadro OLE consistentes?**

Defina dimensões fixas para o gráfico que correspondam ao quadro OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**Correspondência do tamanho da janela da pasta de trabalho é suficiente?**

Corresponder apenas ao tamanho da janela da pasta de trabalho não impede de forma confiável o quadro OLE de mudar de tamanho após a ativação. Use dimensões fixas para o gráfico conforme mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**

Sim. Para um modelo, use as dimensões e a posição do espaço reservado. Para uma nova apresentação, especifique diretamente as dimensões e a posição do quadro.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**

O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Seções Relacionadas**

- [Criar Gráficos do Excel e Incorporá‑los como Objetos OLE em Apresentações](/slides/pt/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Atualizar Objetos OLE Automaticamente Usando um Complemento do PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)