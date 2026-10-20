---
title: Solução funcional para redimensionamento de gráfico em PPTX
type: docs
weight: 40
url: /pt/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para Node.js via Java. Defina dimensões fixas para o gráfico para manter consistentes os tamanhos do gráfico e do quadro OLE."
---
## **Visão geral**

Gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após a primeira ativação. Isso pode causar uma diferença perceptível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá-lo correspondendo as dimensões fixas do gráfico ao quadro OLE.

Em [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pt/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells para Node.js via Java e incorporá-lo em uma apresentação do PowerPoint usando Aspose.Slides para Node.js via Java. Para resolver o [object preview issue](/slides/pt/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), atribuimos a imagem do gráfico ao quadro de objeto OLE do gráfico. Na apresentação de saída, ao clicar duas vezes no quadro de objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro de objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro de objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do redimensionamento**

A pasta de trabalho do Excel incorporada tem suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. O quadro OLE no slide possui dimensões definidas de forma independente. Quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. Diferenças entre a janela da pasta de trabalho e o quadro OLE podem, portanto, fazer o objeto ser redimensionado.

## **Solução funcional**

Corresponda o tamanho do gráfico ao quadro OLE no slide e mantenha as dimensões do gráfico independentes da janela da pasta de trabalho. Esta solução funciona com uma nova apresentação ou um modelo existente.

O exemplo requer Aspose.Cells para Node.js via Java e Aspose.Slides para Node.js via Java. Instale os pacotes Node.js `aspose.cells`, `aspose.slides.via.java` e `java`. Execute os dois scripts CommonJS abaixo em processos Node.js separados, usando o mesmo diretório de trabalho, pois ambos os pacotes Aspose inicializam a ponte Java durante o carregamento. Ele cria um gráfico de colunas simples em uma planilha de gráfico ativa e incorpora a pasta de trabalho no formato XLS. Nenhuma imagem de visualização do gráfico é atribuída; o gráfico torna-se visível quando o objeto OLE é ativado no PowerPoint.

O exemplo cria uma nova apresentação com um quadro OLE de 9,5 × 4 polegadas posicionado a 0,5 polegada da borda esquerda e 1 polegada do topo. As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Usar um modelo](#use-a-template).

## **Definir um tamanho fixo para o gráfico**

Defina [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) como false para que as dimensões do gráfico sejam independentes da janela da pasta de trabalho. Defina as dimensões do [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) por meio de [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) e [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), convertendo pontos em pixels usando 96 pixels por polegada: um quadro que mede 684 × 288 pontos corresponde a um gráfico que mede 912 × 384 pixels. Defina [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) para o valor CUSTOM de `PrintSizeType`. O exemplo incorpora a pasta de trabalho com [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) e salva uma apresentação com um quadro OLE de 9,5 × 4 polegadas.

Salve este primeiro script como `create-fixed-chart.js`. Ele cria `chart-fixed-size.xls` com um gráfico que mede 912 × 384 pixels, correspondendo ao quadro de 684 × 288 pontos usado pelo segundo script. Nenhuma pasta de trabalho de entrada é necessária.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Corresponda às dimensões do quadro OLE em pontos (72 pontos por polegada).
    const width = 684; // 9,5 polegadas.
    const height = 288; // 4 polegadas.

    chart.setSizeWithWindow(false);
    // Converta pontos em pixels de gráfico usando 96 pixels por polegada.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(0);
```

Salve o segundo script como `embed-fixed-chart.js` e execute‑lo após `create-fixed-chart.js`. Ele lê a pasta de trabalho XLS gerada e salva `chart-fixed-size.pptx`. A ponte Java requer um array de bytes Java explícito para os dados da pasta de trabalho e valores float Java para as coordenadas e dimensões do quadro. A extensão `xls` corresponde ao formato salvo da pasta de trabalho.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
    const width = 684; // 9,5 polegadas.
    const height = 288; // 4 polegadas.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(0);
```

## **Usar um modelo**

A lógica de dimensionamento é a mesma para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.  
2. Verifique se o primeiro slide contém pelo menos três formas, então use a forma no índice 2 como o marcador de posição.  
3. Obtenha a largura e a altura do quadro a partir dessa forma, em vez de usar os valores fixos 684 e 288. Use as mesmas dimensões no script de criação da pasta de trabalho, mantendo os cálculos de dimensionamento inalterados, e regenere a pasta de trabalho XLS antes de incorporá‑la.  
4. Adicione o quadro OLE na posição do marcador de posição em vez das coordenadas fixas 36 e 72.  
5. Remova o marcador de posição antes de salvar a apresentação.

## **FAQ**

**Por que o meu gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**  
Isto acontece porque o Excel tenta restaurar o tamanho original da janela quando ativado pela primeira vez, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como posso manter os tamanhos do gráfico e do quadro OLE consistentes?**  
Defina dimensões fixas para o gráfico que correspondam ao quadro OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**A correspondência do tamanho da janela da pasta de trabalho é suficiente?**  
Corresponder apenas ao tamanho da janela da pasta de trabalho não impede de forma confiável que o quadro OLE mude de tamanho após a ativação. Use dimensões fixas para o gráfico como mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**  
Sim. Para um modelo, use as dimensões e a posição do marcador de posição. Para uma nova apresentação, especifique as dimensões e a posição do quadro diretamente.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**  
O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Seções relacionadas**

- [Criar gráficos do Excel e incorporá‑los como objetos OLE em apresentações](/slides/pt/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)