---
title: Solução funcional para redimensionamento de gráficos no PPTX
type: docs
weight: 40
url: /pt/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides for PHP via Java. Defina dimensões de gráfico fixas para manter os tamanhos do gráfico e do quadro OLE consistentes."
---
## **Visão geral**

Os gráficos do Excel incorporados como objetos OLE em apresentações do PowerPoint usando componentes Aspose podem mudar de tamanho após a primeira ativação. Isso pode causar uma diferença visível na aparência do gráfico antes e depois da ativação. Este artigo explica por que o redimensionamento ocorre e mostra como evitá‑lo correspondendo as dimensões fixas do gráfico ao quadro OLE.

Em [Criar gráficos do Excel e incorporá‑los como objetos OLE em apresentações](/slides/pt/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells for PHP via Java e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides for PHP via Java. Para resolver o [problema de visualização do objeto](/slides/pt/php-java/object-preview-issue-when-adding-oleobjectframe/), atribuímos a imagem do gráfico ao quadro do objeto OLE do gráfico. Na apresentação resultante, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários podem editar a pasta de trabalho do Excel incorporada e depois retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE muda quando o usuário volta ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do redimensionamento**

A pasta de trabalho do Excel incorporada possui suas próprias dimensões de janela, que o Excel tenta manter quando o objeto é ativado pela primeira vez. O quadro OLE no slide tem dimensões definidas independentemente. Quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho do objeto para manter suas proporções como parte do processo de incorporação. As diferenças entre a janela da pasta de trabalho e o quadro OLE podem, portanto, causar o redimensionamento do objeto.

## **Solução funcional**

Corresponda o tamanho do gráfico ao quadro OLE no slide e mantenha as dimensões do gráfico independentes da janela da pasta de trabalho. Essa solução funciona com uma nova apresentação ou com um modelo existente.

O exemplo requer Aspose.Cells for PHP via Java e Aspose.Slides for PHP via Java. Configure ambos os produtos com a mesma instância do PHP/Java Bridge, carregue ambos os wrappers PHP e torne ambas as bibliotecas Java disponíveis para a ponte. Nenhum arquivo de entrada é necessário. Ele cria um gráfico de colunas simples em uma planilha de gráfico ativa e incorpora a pasta de trabalho no formato XLS. Nenhuma imagem de visualização do gráfico é atribuída; o gráfico torna‑se visível quando o objeto OLE é ativado no PowerPoint.

O exemplo cria uma nova apresentação com um quadro OLE de 9,5 × 4 polegadas posicionado 0,5 polegadas da borda esquerda e 1 polegada do topo. As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada). Para uma apresentação existente, veja [Usar um modelo](#use-a-template).

## **Definir um tamanho fixo para o gráfico**

Defina [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) como false para que as dimensões do gráfico sejam independentes da janela da pasta de trabalho. Defina as dimensões de [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) através de [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) e [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), convertendo pontos para pixels usando 96 pixels por polegada: um quadro medindo 684 × 288 pontos corresponde a um gráfico de 912 × 384 pixels. Defina [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) para o valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). O exemplo incorpora a pasta de trabalho com [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) e salva uma apresentação com um quadro OLE de 9,5 × 4 polegadas.

Os resultados numéricos do Java são convertidos com `java_values` antes de serem usados como índices PHP. Os bytes da pasta de trabalho permanecem em um array de bytes Java ao serem passados para [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // As coordenadas e dimensões do slide estão em pontos (72 pontos por polegada).
        $width = 684; // 9,5 polegadas.
        $height = 288; // 4 polegadas.

        $chart->setSizeWithWindow(false);
        // Converta pontos em pixels do gráfico usando 96 pixels por polegada.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Usar um modelo**

A lógica de dimensionamento é a mesma para uma apresentação existente. Para adaptar o exemplo:

1. Carregue a apresentação modelo em vez de criar uma apresentação vazia.  
2. Verifique se o primeiro slide contém pelo menos três formas, então use a forma no índice 2 como o marcador de posição.  
3. Pegue a largura e a altura do quadro dessa forma em vez de usar os valores fixos 684 e 288. Mantenha os cálculos de dimensionamento inalterados.  
4. Adicione o quadro OLE na posição do marcador de posição em vez das coordenadas fixas 36 e 72.  
5. Remova o marcador de posição antes de salvar a apresentação.

## **Perguntas frequentes**

**Por que o gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**  
Isso ocorre porque o Excel tenta restaurar o tamanho original da janela quando ativado pela primeira vez, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**Como posso manter os tamanhos do gráfico e do quadro OLE consistentes?**  
Defina dimensões fixas para o gráfico que correspondam ao quadro OLE e use um tamanho de impressão de gráfico personalizado antes de incorporar a pasta de trabalho. O exemplo acima mostra as configurações necessárias e as conversões de unidades.

**Correspondência ao tamanho da janela da pasta de trabalho é suficiente?**  
Correspondência apenas ao tamanho da janela da pasta de trabalho não impede de forma confiável que o quadro OLE mude de tamanho após a ativação. Use dimensões fixas para o gráfico como mostrado no exemplo.

**Esta solução funciona tanto com apresentações baseadas em modelo quanto com novas apresentações?**  
Sim. Para um modelo, use as dimensões e a posição do marcador de posição. Para uma nova apresentação, especifique as dimensões e a posição do quadro diretamente.

**Posso usar este exemplo com gráficos criados em outros programas de planilha?**  
O exemplo usa uma pasta de trabalho do Excel criada com Aspose.Cells. Ele não demonstra o comportamento de ativação para outros programas de planilha.

## **Seções relacionadas**

- [Criar gráficos do Excel e incorporá‑los como objetos OLE em apresentações](/slides/pt/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)