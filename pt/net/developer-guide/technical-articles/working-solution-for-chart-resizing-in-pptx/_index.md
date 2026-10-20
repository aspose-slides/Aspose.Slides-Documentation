---
title: Solução Funcional para Redimensionamento de Gráficos no PPTX
type: docs
weight: 60
url: /pt/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para .NET. Defina dimensões fixas do gráfico para manter consistentes os tamanhos do gráfico e do quadro OLE."
---
## **Contexto**

Gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após a primeira ativação. Isso pode causar uma diferença perceptível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá-lo correspondendo as dimensões fixas do gráfico ao quadro OLE.

Em [Criar gráficos do Excel e incorporá-los como objetos OLE em apresentações](/slides/pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells para .NET e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides para .NET. Para resolver o [problema de visualização do objeto](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/), atribuímos a imagem do gráfico ao quadro OLE do gráfico. Na apresentação resultante, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e depois retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do redimensionamento**

A pasta de trabalho do Excel incorporada possui suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. O quadro OLE no slide tem dimensões definidas de forma independente. Quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. Diferenças entre a janela da pasta de trabalho e o quadro OLE podem, portanto, fazer o objeto ser redimensionado.

## **Solução Funcional**

Corresponda o tamanho do gráfico ao quadro OLE no slide e mantenha as dimensões do gráfico independentes da janela da pasta de trabalho. Esta solução funciona com uma nova apresentação ou um modelo existente.

O exemplo requer Aspose.Cells para .NET e Aspose.Slides para .NET. Ele cria um gráfico de colunas simples em uma planilha de gráfico ativa e incorpora a pasta de trabalho no formato XLS. Nenhuma imagem de pré‑visualização do gráfico é atribuída; o gráfico torna‑se visível quando o objeto OLE é ativado no PowerPoint.

O exemplo cria uma nova apresentação com um quadro OLE de 9,5 × 4 polegadas posicionado a 0,5 polegada da borda esquerda e 1 polegada do topo. As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Usar um modelo](#use-a-template).

## **Definir um tamanho de gráfico fixo**

Defina [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) como false para que as dimensões do gráfico sejam independentes da janela da pasta de trabalho. Defina as dimensões do [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) por meio de [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) e [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), convertendo pontos em pixels usando 96 pixels por polegada: um quadro com 684 × 288 pontos corresponde a um gráfico com 912 × 384 pixels. Defina [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) para o valor Custom de [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). O exemplo incorpora a pasta de trabalho com [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) e salva uma apresentação com um quadro OLE de 9,5 × 4 polegadas.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
var width = 684f; // 9,5 polegadas.
var height = 288f; // 4 polegadas.

chart.SizeWithWindow = false;
// Convert points to chart pixels using 96 pixels per inch.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Usar um modelo**

A lógica de dimensionamento é a mesma para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.  
1. Verifique se o primeiro slide contém ao menos três formas, então use a forma no índice 2 como espaço reservado.  
1. Obtenha a largura e a altura do quadro a partir dessa forma em vez de usar os valores fixos 684 e 288. Mantenha os cálculos de dimensionamento inalterados.  
1. Adicione o quadro OLE na posição do espaço reservado em vez das coordenadas fixas 36 e 72.  
1. Remova o espaço reservado antes de salvar a apresentação.

## **FAQ**

**Por que o gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso acontece porque o Excel tenta restaurar o tamanho original da janela quando é ativado pela primeira vez, enquanto o quadro do objeto OLE no PowerPoint possui suas próprias dimensões. O PowerPoint e o Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como posso manter os tamanhos do gráfico e do quadro OLE consistentes?**

Defina dimensões fixas para o gráfico que correspondam ao quadro OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**Correspondência do tamanho da janela da pasta de trabalho é suficiente?**

Correspondir apenas ao tamanho da janela da pasta de trabalho não impede de forma confiável que o quadro OLE mude de tamanho após a ativação. Use dimensões fixas para o gráfico conforme mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**

Sim. Para um modelo, use as dimensões e a posição do espaço reservado. Para uma nova apresentação, especifique diretamente as dimensões e a posição do quadro.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**

O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Seções relacionadas**

- [Criar gráficos do Excel e incorporá-los como objetos OLE em apresentações](/slides/pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Atualizar objetos OLE automaticamente usando um suplemento do PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)