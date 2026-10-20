---
title: Solução Funcional para Redimensionamento de Gráfico em PPTX
type: docs
weight: 40
url: /pt/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para Python via Java. Defina dimensões de gráfico fixas para manter os tamanhos do gráfico e do quadro OLE consistentes."
---
## **Contexto**

Gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após sua primeira ativação. Isso pode causar uma diferença perceptível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá-lo correspondendo as dimensões fixas do gráfico ao quadro OLE.

Em [Criar Gráficos do Excel e Incorporá-los como Objetos OLE em Apresentações](/slides/pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells para Python via Java e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides para Python via Java. Para resolver o [problema de visualização do objeto](/slides/pt/python-java/object-preview-issue-when-adding-oleobjectframe/), atribuimos a imagem do gráfico ao quadro de objeto OLE do gráfico. Na apresentação resultante, ao clicar duas vezes no quadro de objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e então retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro de objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro de objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

A pasta de trabalho do Excel incorporada tem suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. O quadro OLE no slide tem dimensões definidas de forma independente. Quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. Diferenças entre a janela da pasta de trabalho e o quadro OLE podem, portanto, causar o redimensionamento do objeto.

## **Solução Funcional**

O exemplo requer Aspose.Cells para Python via Java e Aspose.Slides para Python via Java. Ele cria um gráfico de colunas simples em uma planilha de gráfico ativa e incorpora a pasta de trabalho no formato XLS. Nenhuma imagem de visualização do gráfico é atribuída; o gráfico torna‑se visível quando o objeto OLE é ativado no PowerPoint.

O exemplo cria uma nova apresentação com um quadro OLE de 9,5 × 4 polegadas posicionado a 0,5 polegadas da borda esquerda e 1 polegada do topo. As coordenadas e dimensões dos slides estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Usar um Modelo](#use-a-template).

## **Definir um Tamanho de Gráfico Fixo**

Defina [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) como false para que as dimensões do gráfico sejam independentes da janela da pasta de trabalho. Defina as dimensões do [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) através de [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) e [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), convertendo pontos em pixels usando 96 pixels por polegada: um quadro medindo 684 × 288 pontos corresponde a um gráfico medindo 912 × 384 pixels. Defina [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) para o valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). O exemplo incorpora a pasta de trabalho com [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) e salva uma apresentação com um quadro OLE de 9,5 × 4 polegadas.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
        width = 684.0  # 9.5 polegadas.
        height = 288.0  # 4 polegadas.

        chart.setSizeWithWindow(False)
        # Converta pontos em pixels do gráfico usando 96 pixels por polegada.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Usar um Modelo**

A lógica de dimensionamento é a mesma para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.
1. Verifique se o primeiro slide contém pelo menos três formas, então use a forma no índice 2 como o marcador de posição.
1. Obtenha a largura e a altura do quadro a partir dessa forma em vez de usar os valores fixos 684 e 288. Mantenha os cálculos de dimensionamento inalterados.
1. Adicione o quadro OLE na posição do marcador de posição em vez das coordenadas fixas 36 e 72.
1. Remova o marcador de posição antes de salvar a apresentação.

## **Perguntas Frequentes**

**Por que meu gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso acontece porque o Excel tenta restaurar o tamanho original da janela quando ativado pela primeira vez, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. O PowerPoint e o Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como posso manter os tamanhos do gráfico e do quadro OLE consistentes?**

Defina dimensões de gráfico fixas que correspondam ao quadro OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**Correspondência do tamanho da janela da pasta de trabalho é suficiente?**

Apenas corresponder ao tamanho da janela da pasta de trabalho não impede de forma confiável que o quadro OLE mude de tamanho após a ativação. Use dimensões de gráfico fixas conforme mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**

Sim. Para um modelo, use as dimensões e a posição do marcador de posição. Para uma nova apresentação, indique diretamente as dimensões e a posição do quadro.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**

O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Seções Relacionadas**

- [Criar Gráficos do Excel e Incorporá-los como Objetos OLE em Apresentações](/slides/pt/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)