---
title: Solução Funcional para Redimensionamento de Gráficos no PPTX
type: docs
weight: 40
url: /pt/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para Java. Defina dimensões fixas para o gráfico para manter consistentes os tamanhos do gráfico e do quadro OLE."
---
## **Contexto**

Gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após a primeira ativação. Isso pode causar uma diferença perceptível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá‑lo correspondendo as dimensões fixas do gráfico ao quadro OLE.

Em [Criar Gráficos do Excel e Incorporá‑los como Objetos OLE em Apresentações](/slides/pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells para Java e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides para Java. Para resolver o [problema de visualização do objeto](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/), atribuímos a imagem do gráfico ao quadro do objeto OLE do gráfico. Na apresentação de saída, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e depois retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro do objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

A pasta de trabalho do Excel incorporada possui suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. O quadro OLE no slide tem dimensões definidas independentemente. Quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. Diferenças entre a janela da pasta de trabalho e o quadro OLE podem, portanto, causar o redimensionamento do objeto.

## **Solução Funcional**

Faça o tamanho do gráfico corresponder ao quadro OLE no slide e mantenha as dimensões do gráfico independentes da janela da pasta de trabalho. Esta solução funciona com uma nova apresentação ou com um modelo existente.

O exemplo requer Aspose.Cells para Java e Aspose.Slides para Java. Ele cria um gráfico de colunas simples em uma planilha de gráficos ativa e incorpora a pasta de trabalho no formato XLS. Nenhuma imagem de visualização do gráfico é atribuída; o gráfico torna‑se visível quando o objeto OLE é ativado no PowerPoint.

O exemplo cria uma nova apresentação com um quadro OLE de 9,5 × 4 polegadas posicionado a 0,5 polegada da borda esquerda e 1 polegada do topo. As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Usar um Modelo](#use-a-template).

## **Definir um Tamanho Fixado para o Gráfico**

Defina [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) como false para que as dimensões do gráfico sejam independentes da janela da pasta de trabalho. Defina as dimensões do [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) através de [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) e [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), convertendo pontos em pixels usando 96 pixels por polegada: um quadro que mede 684 × 288 pontos corresponde a um gráfico que mede 912 × 384 pixels. Defina [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) para o valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). O exemplo incorpora a pasta de trabalho com [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) e salva uma apresentação com um quadro OLE de 9,5 × 4 polegadas.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
        float width = 684f; // 9,5 polegadas.
        float height = 288f; // 4 polegadas.

        chart.setSizeWithWindow(false);
        // Converta pontos em pixels do gráfico usando 96 pixels por polegada.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Usar um Modelo**

A lógica de dimensionamento é a mesma para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.  
1. Verifique se o primeiro slide contém ao menos três formas, então use a forma no índice 2 como o espaço reservado.  
1. Use a largura e altura do quadro dessa forma em vez de usar os valores fixos 684 e 288. Mantenha os cálculos de dimensionamento inalterados.  
1. Adicione o quadro OLE na posição do espaço reservado em vez das coordenadas fixas 36 e 72.  
1. Remova o espaço reservado antes de salvar a apresentação.

## **FAQ**

**Por que o gráfico do Excel incorporado muda de tamanho depois de ser ativado no PowerPoint?**

Isso acontece porque o Excel tenta restaurar o tamanho original da janela na primeira ativação, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como posso manter os tamanhos do gráfico e do quadro OLE consistentes?**

Defina dimensões fixas para o gráfico que correspondam ao quadro OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**A correspondência do tamanho da janela da pasta de trabalho é suficiente?**

Correspondir apenas ao tamanho da janela da pasta de trabalho não impede de forma confiável que o quadro OLE mude de tamanho após a ativação. Use dimensões fixas para o gráfico conforme mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**

Sim. Para um modelo, use as dimensões e a posição do espaço reservado. Para uma nova apresentação, especifique diretamente as dimensões e a posição do quadro.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**

O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Seções Relacionadas**

- [Criar Gráficos do Excel e Incorporá‑los como Objetos OLE em Apresentações](/slides/pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)