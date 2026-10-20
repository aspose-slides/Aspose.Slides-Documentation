---
title: Criar gráficos do Excel e incorporá-los em apresentações como objetos OLE
type: docs
weight: 30
url: /pt/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico do Excel
- incorporar gráfico
- objeto OLE
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie um gráfico do Excel com Aspose.Cells for PHP via Java e incorpore a pasta de trabalho em uma apresentação PowerPoint com Aspose.Slides for PHP via Java, incluindo uma visualização do gráfico."
---
## **Visão geral**

Este artigo mostra como criar um gráfico de colunas do Excel com Aspose.Cells for PHP via Java e incorporar sua pasta de trabalho em uma apresentação PowerPoint com Aspose.Slides for PHP via Java. A pasta de trabalho incorporada contém tanto os dados de origem quanto o gráfico. Uma visualização PNG separada exibe o gráfico no slide antes de o objeto OLE ser ativado.

O resultado é um objeto Excel incorporado, não um gráfico nativo do PowerPoint. Editar a pasta de trabalho via OLE requer um aplicativo de desktop que suporte a ativação OLE e uma instalação compatível do Excel.

## **Pré-requisitos**

Configure o Aspose.Cells for PHP via Java e o Aspose.Slides for PHP via Java com a mesma instância do PHP/Java Bridge. Carregue ambos os wrappers PHP e torne as bibliotecas Java de ambos os produtos disponíveis para a ponte. O Microsoft Office não é necessário para gerar a apresentação com essas bibliotecas.

Nenhum arquivo de entrada é necessário: o exemplo cria os dados e o gráfico na memória, depois grava `OutputChart.pptx` no diretório de trabalho atual. Aplique licenças para ambos os produtos ao executar fora do modo de avaliação.

## **Como a incorporação funciona**

1. Crie uma pasta de trabalho com uma planilha de dados e uma planilha de gráfico.  
2. Torne a planilha de gráfico ativa para que a pasta de trabalho abra no gráfico.  
3. Defina o intervalo de exibição OLE da pasta de trabalho e renderize o gráfico para PNG.  
4. Salve a pasta de trabalho como XLSX na memória e incorpore esses bytes em um slide.  
5. Atribua o PNG como a visualização do objeto OLE e salve a apresentação como PPTX.

O intervalo de exibição da pasta de trabalho e a moldura no slide têm papéis diferentes. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) recebe índices de linha e coluna de início/fim baseados em zero. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) recebe, em vez disso, a linha superior, a coluna esquerda, a linha inferior e a coluna direita. O exemplo usa o índice de linha 55 e o índice de coluna 25 como limites inferiores diretos; esses valores são escolhas de layout, não o número de linhas ou colunas de dados.

A moldura do slide usa pontos. O exemplo a ajusta dentro do slide e a centraliza preservando a proporção do PNG, em vez de esticar a visualização para preencher o slide.

## **Criar e incorporar o gráfico**

O exemplo completo a seguir preenche `DataSheet` com quatro linhas e cinco colunas de valores. Cada linha se torna uma série do gráfico. `ChartSheet` é selecionada como a planilha ativa antes de salvar a pasta de trabalho.

A pasta de trabalho é salva explicitamente como XLSX, correspondendo à extensão `xlsx` passada para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Os resultados numéricos do Java são convertidos com `java_values` antes que o PHP execute operações aritméticas, enquanto os dados binários permanecem em arrays de bytes Java. O PNG é carregado diretamente de seus bytes sem uma conversão intermediária de bitmap. Atribuí‑lo através de [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) substitui o placeholder OLE padrão.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Mantenha o PNG e o XLSX como arrays de bytes Java ao passá-los para Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Ajuste e centralize a visualização preservando sua proporção.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Resultado esperado**

`OutputChart.pptx` contém um slide com uma pasta de trabalho Excel incorporada e uma visualização do gráfico. A pasta de trabalho contém os dados originais e um gráfico de colunas com quatro séries. A visualização está centralizada no slide e mantém suas proporções.

![Gráfico de colunas do Excel exibido como visualização de uma pasta de trabalho incorporada](excel-chart-ole-preview.png)

Em um ambiente desktop PowerPoint compatível com Excel disponível, clique duas vezes no objeto para ativar e editar a pasta de trabalho incorporada. A ativação e a edição dependem do suporte OLE do aplicativo host e das configurações de segurança.

## **Perguntas frequentes**

**Por que é necessária uma imagem de visualização?**  
A pasta de trabalho incorporada e sua visualização no slide são conteúdos separados. Forneça uma imagem do gráfico para que o slide mostre o gráfico em vez do placeholder padrão "EMBEDDED OLE OBJECT". Veja [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/php-java/object-preview-issue-when-adding-oleobjectframe/).

**A visualização é atualizada automaticamente quando altero a pasta de trabalho no código?**  
Considere a visualização como uma captura. Ao atualizar os dados da pasta de trabalho programaticamente, regenere a imagem do gráfico e substitua a visualização bem como os dados da pasta de trabalho incorporada.

**Posso usar XLS em vez de XLSX?**  
Sim. Salve a pasta de trabalho no formato XLS e use `xls` como a extensão de dados incorporados. A extensão deve corresponder ao formato real da pasta de trabalho; mudar apenas a extensão não converte os dados.

**Por que o objeto pode mudar de tamanho após a ativação?**  
O aplicativo host pode atualizar a apresentação do objeto OLE ao ativar a pasta de trabalho. Tanto o intervalo de exibição OLE da pasta de trabalho quanto as dimensões da moldura do slide são importantes. Veja [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/java/working-solution-for-chart-resizing-in-pptx/).

## **Seções relacionadas**

- [Solução funcional para redimensionamento de gráfico em PPTX](/slides/pt/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de visualização de objeto ao adicionar OleObjectFrame](/slides/pt/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Gerenciar objetos OLE](/slides/pt/php-java/manage-ole/)