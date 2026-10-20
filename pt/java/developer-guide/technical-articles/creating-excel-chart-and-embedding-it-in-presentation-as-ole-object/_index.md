---
title: Criar gráficos do Excel e incorporá-los em apresentações como objetos OLE
type: docs
weight: 30
url: /pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Crie um gráfico do Excel com Aspose.Cells for Java e incorpore a pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides, incluindo uma visualização do gráfico."
---
## **Visão geral**

Este artigo mostra como criar um gráfico de colunas do Excel com Aspose.Cells for Java e incorporar sua pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides for Java. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes de o objeto OLE ser ativado.

O resultado é um objeto Excel incorporado, não um gráfico nativo do PowerPoint. Editar a pasta de trabalho via OLE requer um aplicativo desktop que suporte ativação OLE e uma instalação compatível do Excel.

## **Pré-requisitos**

Adicione Aspose.Cells for Java e Aspose.Slides for Java às dependências do seu projeto. Execute o exemplo dentro de um método Java. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhum arquivo de entrada é necessário: o exemplo cria os dados e o gráfico na memória, depois grava `OutputChart.pptx` no diretório de trabalho atual. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como a incorporação funciona**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
2. Torne a planilha de gráfico ativa para que a pasta de trabalho seja aberta no gráfico.  
3. Defina a faixa de exibição OLE da pasta de trabalho e renderize o gráfico para PNG.  
4. Salve a pasta de trabalho como XLSX na memória e incorpore esses bytes em um slide.  
5. Atribua o PNG como a visualização do objeto OLE e salve a apresentação como PPTX.

A faixa de exibição da pasta de trabalho e a moldura no slide têm papéis diferentes. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) aceita índices de linha e coluna de início/fim baseados em zero. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) aceita, em vez disso, a linha superior, coluna esquerda, linha inferior e coluna direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores diretos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo a ajusta dentro do slide e a centraliza preservando a proporção do PNG, em vez de esticar a visualização para preencher o slide.

## **Criar e incorporar o gráfico**

O exemplo completo a seguir preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série do gráfico. `ChartSheet` é selecionada como a planilha ativa antes de salvar a pasta de trabalho.

A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). O PNG é carregado diretamente de seus bytes sem conversão intermediária de bitmap. Atribuí‑lo através de [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) substitui o espaço reservado padrão do OLE.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Renderize a visualização do gráfico e serialize a pasta de trabalho editável separadamente.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Ajuste a visualização dentro do slide sem alterar sua proporção.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A visualização está centralizada no slide e mantém suas proporções.

![Gráfico de colunas do Excel exibido como visualização de uma pasta de trabalho incorporada](excel-chart-ole-preview.png)

Em um ambiente desktop do PowerPoint compatível, com o Excel disponível, clique duas vezes no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e a edição dependem do suporte OLE do aplicativo host e das configurações de segurança.

## **Perguntas frequentes**

**Por que uma imagem de visualização é necessária?**

A pasta de trabalho incorporada e sua visualização no slide são conteúdos separados. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do espaço reservado padrão “EMBEDDED OLE OBJECT”. Consulte [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/).

**A visualização é atualizada automaticamente quando eu altero a pasta de trabalho no código?**

Considere a visualização como uma captura instantânea. Ao atualizar programaticamente os dados da pasta de trabalho, gere novamente a imagem do gráfico e substitua tanto a visualização quanto os dados da pasta de trabalho incorporada.

**Posso usar XLS em vez de XLSX?**

Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão de dados incorporados. A extensão deve corresponder ao formato real da pasta de trabalho; alterar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**

O aplicativo host pode atualizar a apresentação do objeto OLE ao ativar a pasta de trabalho. Tanto a faixa de exibição OLE da pasta de trabalho quanto as dimensões da moldura do slide são relevantes. Consulte [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/java/working-solution-for-chart-resizing-in-pptx/).

## **Seções relacionadas**

- [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/)
- [Atualizar objetos OLE automaticamente usando um suplemento do PowerPoint](/slides/pt/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)