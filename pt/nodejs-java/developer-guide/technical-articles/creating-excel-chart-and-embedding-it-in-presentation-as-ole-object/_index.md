---
title: Criar gráficos do Excel e incorporá-los em apresentações como objetos OLE
type: docs
weight: 30
url: /pt/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Criar um gráfico do Excel com Aspose.Cells para Node.js via Java e incorporar a pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides, incluindo uma visualização do gráfico."
---
## **Visão geral**

Este artigo mostra como criar um gráfico de colunas do Excel com Aspose.Cells para Node.js via Java e incorporar sua pasta de trabalho em uma apresentação do PowerPoint com Aspose.Slides para Node.js via Java. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes que o objeto OLE seja ativado.

O resultado é um objeto Excel incorporado, não um gráfico nativo do PowerPoint. Editar a pasta de trabalho via OLE requer um aplicativo de desktop que suporte ativação OLE e uma instalação compatível do Excel.

## **Pré-requisitos**

Instale os pacotes Node.js `aspose.cells`, `aspose.slides.via.java` e `java`. Execute os exemplos como dois scripts CommonJS em processos Node.js separados: primeiro `create-chart.js`, depois `embed-chart.js`, usando o mesmo diretório de trabalho. Ambos os pacotes Aspose inicializam a ponte Java durante o carregamento, portanto esses exemplos os mantêm em processos separados. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhuma pasta de trabalho ou imagem existente é necessária. O primeiro script cria `ChartWorkbook.xlsx` e `ChartPreview.png`; o segundo lê esses arquivos e grava `OutputChart.pptx` no diretório de trabalho atual. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como a incorporação funciona**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
1. Torne a planilha de gráfico ativa para que a pasta de trabalho abra no gráfico.  
1. Defina a área de exibição OLE da pasta de trabalho e renderize o gráfico para PNG.  
1. Salve a pasta de trabalho como XLSX e incorpore seus bytes em um slide em um processo Node.js separado.  
1. Atribua o PNG como a visualização do objeto OLE e salve a apresentação como PPTX.  

O intervalo de exibição da pasta de trabalho e a moldura no slide têm papéis diferentes. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) aceita índices de linha e coluna de início/fim baseados em zero. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) aceita, em vez disso, a linha superior, coluna esquerda, linha inferior e coluna direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores direitos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo encaixa-a dentro do slide e centra-a preservando a proporção do PNG, em vez de esticar a visualização para preencher o slide.

## **Criar e incorporar o gráfico**

Salve o primeiro exemplo como `create-chart.js`. Ele preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série do gráfico. `ChartSheet` é selecionada como a planilha ativa antes de salvar a pasta de trabalho.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderize a visualização do gráfico e serialize a pasta de trabalho editável separadamente.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(0);
```

Salve o exemplo a seguir como `embed-chart.js`. Execute-o após `create-chart.js` ter criado ambos os arquivos de entrada. Ele centraliza a moldura OLE e preserva a proporção da imagem de visualização.

O segundo script incorpora a pasta de trabalho salva e usa o PNG como sua visualização. A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). O PNG é carregado diretamente a partir de seus bytes sem conversão intermediária de bitmap. A ponte Java requer arrays de bytes Java explícitos para a imagem e os dados da pasta de trabalho, e valores float Java para as coordenadas da moldura do slide. Atribuir isso através de [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) substitui o placeholder OLE padrão.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Ajuste a visualização dentro do slide sem mudar sua proporção.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(0);
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A visualização está centralizada no slide e mantém suas proporções.

![Gráfico de colunas do Excel exibido como a visualização de uma pasta de trabalho incorporada](excel-chart-ole-preview.png)

Em um ambiente de PowerPoint desktop compatível com Excel disponível, clique duas vezes no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e a edição dependem do suporte OLE e das configurações de segurança do aplicativo host.

## **Perguntas frequentes**

**Por que é necessária uma imagem de visualização?**

A pasta de trabalho incorporada e sua visualização no slide são conteúdos separados. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do placeholder padrão "EMBEDDED OLE OBJECT". Veja [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**A visualização é atualizada automaticamente quando altero a pasta de trabalho no código?**

Trate a visualização como uma captura instantânea. Ao atualizar os dados da pasta de trabalho programaticamente, regenere a imagem do gráfico e substitua a visualização assim como os dados da pasta de trabalho incorporados.

**Posso usar XLS em vez de XLSX?**

Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão de dados incorporados. A extensão deve corresponder ao formato real da pasta de trabalho; alterar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**

O aplicativo host pode atualizar a apresentação do objeto OLE ao ativar a pasta de trabalho. O intervalo de exibição OLE da pasta de trabalho e as dimensões da moldura do slide são ambos importantes. Veja [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/java/working-solution-for-chart-resizing-in-pptx/).

## **Seções relacionadas**

- [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)