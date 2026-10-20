---
title: Criar gráficos do Excel e incorporá-los em apresentações como objetos OLE
type: docs
weight: 30
url: /pt/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Criar um gráfico do Excel com Aspose.Cells para Android via Java e incorporar a pasta de trabalho em uma apresentação PowerPoint com Aspose.Slides para Android via Java, incluindo uma visualização do gráfico."
---
## **Visão geral**

Este artigo demonstra como criar um gráfico de colunas do Excel com Aspose.Cells para Android via Java e incorporar sua pasta de trabalho em uma apresentação PowerPoint com Aspose.Slides para Android via Java. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes que o objeto OLE seja ativado.

O resultado é um objeto Excel incorporado, não um gráfico PowerPoint nativo. Editar a pasta de trabalho através do OLE requer um aplicativo de desktop que ofereça suporte à ativação OLE e uma instalação compatível do Excel.

## **Pré-requisitos**

Adicione Aspose.Cells para Android via Java e Aspose.Slides para Android via Java às dependências do seu projeto. Chame `ExcelChartEmbedding.createPresentation(getFilesDir())` a partir de uma atividade Android. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhum arquivo de entrada é necessário: o exemplo cria os dados e o gráfico em memória e, em seguida, grava `OutputChart.pptx` no diretório interno de arquivos do aplicativo. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como a incorporação funciona**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
2. Torne a planilha de gráfico a ativa para que a pasta de trabalho seja aberta no gráfico.  
3. Defina o intervalo de exibição OLE da pasta de trabalho e renderize o gráfico para PNG.  
4. Salve a pasta de trabalho como XLSX em memória e incorpore esses bytes em um slide.  
5. Atribua o PNG como a visualização do objeto OLE e salve a apresentação como PPTX.

O intervalo de exibição da pasta de trabalho e a moldura no slide têm papéis diferentes. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) aceita índices de linha e coluna iniciais/finais baseados em zero. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) aceita, em vez disso, a linha superior, a coluna à esquerda, a linha inferior e a coluna à direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores diretos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo a ajusta dentro do slide e a centraliza preservando a proporção do PNG, em vez de esticar a visualização para preencher o slide.

## **Criar e incorporar o gráfico**

O exemplo completo a seguir preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série de gráfico. `ChartSheet` é selecionada como a planilha ativa antes de salvar a pasta de trabalho.

A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). O PNG é carregado diretamente de seus bytes sem conversão intermediária de bitmap. A atribuição através de [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) substitui o placeholder OLE padrão.

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // Renderizar a visualização do gráfico e serializar a pasta de trabalho editável separadamente.
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

                        // Ajustar a visualização ao slide sem alterar sua proporção.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A visualização está centralizada no slide e mantém suas proporções.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

Em um ambiente PowerPoint de desktop compatível com Excel disponível, clique duas vezes no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e edição dependem do suporte OLE do aplicativo host e das configurações de segurança.

## **Perguntas frequentes**

**Por que é necessária uma imagem de pré‑visualização?**  
A pasta de trabalho incorporada e sua visualização no slide são conteúdos separados. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do placeholder padrão “EMBEDDED OLE OBJECT”. Veja [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**A visualização é atualizada automaticamente quando eu altero a pasta de trabalho no código?**  
Considere a visualização como uma captura estática. Ao atualizar os dados da pasta de trabalho programaticamente, gere novamente a imagem do gráfico e substitua tanto a visualização quanto os dados da pasta de trabalho incorporados.

**Posso usar XLS em vez de XLSX?**  
Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão dos dados incorporados. A extensão deve corresponder ao formato real da pasta de trabalho; mudar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**  
O aplicativo host pode atualizar a apresentação do objeto OLE quando ele ativa a pasta de trabalho. Tanto o intervalo de exibição OLE da pasta de trabalho quanto as dimensões da moldura do slide são relevantes. Consulte [Solução funcional para redimensionamento de planilha](/slides/pt/androidjava/working-solution-for-worksheet-resizing/).

## **Seções relacionadas**

- [Solução funcional para redimensionamento de planilha](/slides/pt/androidjava/working-solution-for-worksheet-resizing/)
- [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Gerenciar OLE](/slides/pt/androidjava/manage-ole/)