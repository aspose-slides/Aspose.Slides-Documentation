---
title: Solução Funcional para Redimensionamento de Gráficos em PPTX
type: docs
weight: 40
url: /pt/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides for Android via Java. Defina dimensões fixas para o gráfico a fim de manter os tamanhos do gráfico e da moldura OLE consistentes."
---
## **Visão geral**

Gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após sua primeira ativação. Isso pode causar uma diferença perceptível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá‑lo correspondendo as dimensões fixas do gráfico à moldura OLE.

Em [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pt/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells for Android via Java e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides for Android via Java. Para resolver o [object preview issue](/slides/pt/androidjava/object-preview-issue-when-adding-oleobjectframe/), atribuímos a imagem do gráfico à moldura do objeto OLE do gráfico. Na apresentação de saída, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho da moldura do objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto da moldura OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

A pasta de trabalho do Excel incorporada tem suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. A moldura OLE no slide tem dimensões definidas de forma independente. Quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. Diferenças entre a janela da pasta de trabalho e a moldura OLE podem, portanto, causar o redimensionamento do objeto.

## **Solução Funcional**

Corresponda o tamanho do gráfico à moldura OLE no slide e mantenha as dimensões do gráfico independentes da janela da pasta de trabalho. Esta solução funciona com uma nova apresentação ou com um modelo existente.

O exemplo requer Aspose.Cells for Android via Java e Aspose.Slides for Android via Java. Ele cria um gráfico de colunas simples em uma planilha de gráfico ativa e incorpora a pasta de trabalho no formato XLS. Chame `FixedChartSize.createPresentation(getFilesDir())` a partir de uma activity Android para salvar a saída no diretório interno de arquivos da aplicação. A ativação OLE requer PowerPoint desktop e uma instalação compatível do Excel. Nenhuma imagem de pré‑visualização do gráfico é atribuída; o gráfico torna‑se visível quando o objeto OLE é ativado no PowerPoint.

O exemplo cria uma nova apresentação com uma moldura OLE de 9,5 × 4 polegadas posicionada a 0,5 polegada da borda esquerda e 1 polegada do topo. As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Use a Template](#use-a-template).

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
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

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Usar um Modelo**

A lógica de dimensionamento é a mesma para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.  
2. Verifique se o primeiro slide contém pelo menos três formas, então use a forma no índice 2 como marcador de posição.  
3. Obtenha a largura e a altura da moldura dessa forma em vez de usar os valores fixos 684 e 288. Mantenha os cálculos de dimensionamento inalterados.  
4. Adicione a moldura OLE na posição do marcador de posição em vez das coordenadas fixas 36 e 72.  
5. Remova o marcador de posição antes de salvar a apresentação.

## **FAQ**

**Por que meu gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso ocorre porque o Excel tenta restaurar o tamanho original da janela quando ativado pela primeira vez, enquanto a moldura do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como manter os tamanhos do gráfico e da moldura OLE consistentes?**

Defina dimensões de gráfico fixas que correspondam à moldura OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**Correspondência do tamanho da janela da pasta de trabalho é suficiente?**

Correspondência apenas do tamanho da janela da pasta de trabalho não impede de forma confiável que a moldura OLE mude de tamanho após a ativação. Use dimensões de gráfico fixas como mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**

Sim. Para um modelo, use as dimensões e a posição do marcador de posição. Para uma nova apresentação, especifique as dimensões e a posição da moldura diretamente.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**

O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Definir um Tamanho de Gráfico Fixado**

Defina [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) como false para que as dimensões do gráfico sejam independentes da janela da pasta de trabalho. Defina as dimensões de [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) por meio de [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) e [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), convertendo pontos em pixels usando 96 pixels por polegada: uma moldura de 684 × 288 pontos corresponde a um gráfico de 912 × 384 pixels. Defina [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) para o valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). O exemplo incorpora a pasta de trabalho com [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) e salva uma apresentação com uma moldura OLE de 9,5 × 4 polegadas.

## **Related Sections**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pt/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)